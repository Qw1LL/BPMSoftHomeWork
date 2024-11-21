 namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Linq;
	using BPMSoft.Common;
	using BPMSoft.Core.Attributes;
	using BPMSoft.Core.Campaign;
	using BPMSoft.Core.Campaign.EventHandler;
	using BPMSoft.Core.DB;

	#region Class: EmailConditionalTransitionElementHandler

	/// <summary>
	/// Class to handle campaign events on all email conditional transition elements of campaign schema.
	/// </summary>
	public sealed class EmailConditionalTransitionElementHandler : CampaignEventHandlerBase, IOnCampaignCopy
	{

		#region Constants: Public

		/// <summary>
		/// Name of current transition element handler.
		/// </summary>
		public const string ElementHandlerName = "EmailConditionalTransitionElementHandler";

		#endregion

		#region Methods: Private

		private Select GetExistingHyperlinksSelectQuery(IEnumerable<Guid> hyperlinkIds,
				IEnumerable<Guid> newBulkEmailIds) {
			var exisitngHyperlinksSelect = new Select(UserConnection)
				.Column("Id")
				.Column("Hash")
				.Column("BulkEmailId")
				.Column("BpmTrackId")
				.Column("BpmReplicaMask")
				.From("BulkEmailHyperlink")
				.Where("Id")
					.In(Column.Parameters(hyperlinkIds))
				.Or("BulkEmailId")
					.In(Column.Parameters(newBulkEmailIds)) as Select;
			exisitngHyperlinksSelect.SpecifyNoLockHints();
			return exisitngHyperlinksSelect;
		}

		private Guid FindClonedHyperlinkIdByHash(Guid hyperlinkId, Guid targetBulkEmailId,
				IEnumerable<BulkEmailHyperlinkModel> hyperlinksCollection) {
			Guid hash = hyperlinksCollection.FirstOrDefault(x => x.Id == hyperlinkId).Hash;
			var clonedHyperlink = hyperlinksCollection
				.FirstOrDefault(x => x.Hash == hash
					&& x.BulkEmailId == targetBulkEmailId);
			return clonedHyperlink.Id;
		}

		private Guid FindClonedHyperlinkIdByTrackId(Guid hyperlinkId, Guid targetBulkEmailId,
				IEnumerable<BulkEmailHyperlinkModel> hyperlinksCollection) {
			var hyperlink = hyperlinksCollection.FirstOrDefault(x => x.Id == hyperlinkId);
			var clonedHyperlink = hyperlinksCollection
				.FirstOrDefault(x => x.BpmReplicaMask == hyperlink.BpmReplicaMask
					&& x.BpmTrackId == hyperlink.BpmTrackId
					&& x.BulkEmailId == targetBulkEmailId);
			return clonedHyperlink.Id;
		}

		private Guid FindClonedHyperlinkId(Guid hyperlinkId, Guid targetBulkEmailId,
				IEnumerable<BulkEmailHyperlinkModel> hyperlinksCollection, bool findByTrackId) {
			if (findByTrackId) {
				return FindClonedHyperlinkIdByTrackId(hyperlinkId, targetBulkEmailId,
					hyperlinksCollection);
			} else {
				return FindClonedHyperlinkIdByHash(hyperlinkId, targetBulkEmailId, hyperlinksCollection);
			}
		}

		private IEnumerable<Guid> FindClonedHyperlinkIds(IEnumerable<BulkEmailHyperlinkModel> hyperlinksCollection,
				IEnumerable<Guid> sourceHyperlinkIds, Guid targetBulkEmailId) {
			var clonedHyperLinkIds = new List<Guid>();
			var findByTrackId = hyperlinksCollection
				.Where(x => x.BulkEmailId == targetBulkEmailId)
				.Any(h => h.BpmTrackId > 0);
			foreach (var hyperlinkId in sourceHyperlinkIds) {
				var clonedHyperlinkId = FindClonedHyperlinkId(hyperlinkId, targetBulkEmailId,
					hyperlinksCollection, findByTrackId);
				clonedHyperLinkIds.Add(clonedHyperlinkId);
			}
			return clonedHyperLinkIds;
		}

		private IEnumerable<EmailConditionalTransitionElement> FindEmailTransitionElementsWithHyperlinks() {
			 return CampaignSchema.FlowElements
				.Where(x => x.ElementType.HasFlag(CampaignSchemaElementType.Transition)
					&& x is EmailConditionalTransitionElement)
				.Select(x => x as EmailConditionalTransitionElement)
				.Where(x => x.HyperlinkId.Any());
		}

		private void RebindEmailHyperlinkIds() {
			var emailTransitions = FindEmailTransitionElementsWithHyperlinks();
			if (emailTransitions.Any()) {
				var hyperlinksCollection = GetExistingHyperlinks(emailTransitions);
				foreach (var transition in emailTransitions) {
					var targetBulkEmailId = (transition.SourceRef as MarketingEmailElement).MarketingEmailId;
					var hyperlinkIdsToRebind = hyperlinksCollection
						.Where(x => transition.HyperlinkId.ToList().Contains(x.Id))
						.Select(h => h.Id);
					var newHyperLinkIds = FindClonedHyperlinkIds(hyperlinksCollection, hyperlinkIdsToRebind,
						targetBulkEmailId);
					transition.HyperlinkId = newHyperLinkIds;
				}
			}
		}

		private IEnumerable<BulkEmailHyperlinkModel> GetExistingHyperlinks(
				IEnumerable<EmailConditionalTransitionElement> emailTransitions) {
			List<BulkEmailHyperlinkModel> hyperlinks = new List<BulkEmailHyperlinkModel>();
			var hyperlinkIds = new List<Guid>();
			IEnumerable<Guid> clonedBulkEmailIds = emailTransitions.Select(x => 
				(x.SourceRef as MarketingEmailElement).MarketingEmailId);
			emailTransitions.ForEach(x => hyperlinkIds.AddRange(x.HyperlinkId));
			var exisitngHyperlinksSelect = GetExistingHyperlinksSelectQuery(hyperlinkIds, clonedBulkEmailIds);
			exisitngHyperlinksSelect.ExecuteReader(reader => hyperlinks.Add(new BulkEmailHyperlinkModel {
				Id = reader.GetColumnValue<Guid>("Id"),
				Hash = reader.GetColumnValue<Guid>("Hash"),
				BulkEmailId = reader.GetColumnValue<Guid>("BulkEmailId"),
				BpmTrackId = reader.GetColumnValue<int>("BpmTrackId"),
				BpmReplicaMask = reader.GetColumnValue<int>("BpmReplicaMask")
			}));
			return hyperlinks;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Creates copy of transitions' data and links it to transitions.
		/// </summary>
		[Order(3)]
		public void OnCopy() {
			try {
				RebindEmailHyperlinkIds();
			} catch (Exception ex) {
				string message = GetLczStringValue(ElementHandlerName, "OnCopyException");
				CampaignLogger.ErrorFormat(message, ex, CampaignSchema.EntityId);
				throw;
			}
		}

		#endregion

	}

	#endregion

	#region Class: BulkEmailHyperlinkModel

	/// <summary>
	/// Class to represent lightweight data of BulkEmailHyperlink entity.
	/// </summary>
	internal class BulkEmailHyperlinkModel
	{

		#region Properties: Public

		public Guid Id { get; set; }

		public Guid Hash { get; set; }

		public Guid BulkEmailId { get; set; }

		public int BpmTrackId { get; set; }

		public int BpmReplicaMask { get; set; }

		#endregion

	}

	#endregion

}

