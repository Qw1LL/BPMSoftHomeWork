namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using BPMSoft.Common;
	using BPMSoft.Core.DB;

	#region Class: EmailConditionalTransitionFlowElement

	/// <summary>
	/// Email conditional transition process element.
	/// </summary>
	public class EmailConditionalTransitionFlowElement : ConditionalTransitionFlowElement
	{

		#region Properties: Private

		/// <summary>
		/// Collection of responses without click.
		/// </summary>
		private IEnumerable<Guid> ResponsesWithoutClick {
			get => BpmTrackIds.Any() || Hyperlinks.Any()
				? EmailResponses.Where(x => x != MarketingConsts.BulkEmailResponseClickedId
					&& x != MarketingConsts.BulkEmailResponseRepliedId)
				: EmailResponses.Where(x => x != MarketingConsts.BulkEmailResponseRepliedId);
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Unique identifier of bulk email.
		/// </summary>
		public Guid BulkEmailId { get; set; }

		/// <summary>
		/// Collection of selected email response ids.
		/// </summary>
		public IEnumerable<Guid> EmailResponses { get; set; }

		/// <summary>
		/// Collection of selected hyperlink ids.
		/// </summary>
		public IEnumerable<Guid> Hyperlinks { get; set; }

		/// <summary>
		/// Collection of selected hyperlink track ids.
		/// </summary>
		public IEnumerable<int> BpmTrackIds { get; set; }

		#endregion

		#region Methods: Private

		private void ExtendWithResponses() {
			TransitionQuery.CheckArgumentNull("TransitionQuery");
			Select responseSelect = GetSelectByParticipantResponses();
			Select clicksSelect = GetSelectByParticipantClicks();
			if (responseSelect != null && clicksSelect != null) {
				responseSelect.Union(clicksSelect);
			} else if (clicksSelect != null) {
				responseSelect = clicksSelect;
			}
			Select repliesSelect = GetSelectByParticipantReplies();
			if (responseSelect != null && repliesSelect != null) {
				responseSelect.Union(repliesSelect);
			} else if (repliesSelect != null) {
				responseSelect = repliesSelect;
			}
			if (responseSelect != null) {
				TransitionQuery.And("Id").In(responseSelect);
			}
		}

		private Select GetSelectByParticipantClicks() {
			if (EmailResponses.Contains(MarketingConsts.BulkEmailResponseClickedId)) {
				var clickedQuerySelect = new Select(UserConnection);
				clickedQuerySelect.Column("cpet2", "CampaignParticipantId")
					.From("MandrillClicks").As("mc")
					.InnerJoin("CmpgnPrtcpntEmailTarget").As("cpet2")
						.On("cpet2", "MandrillRecipientUId").IsEqual("mc", "RecipientUId")
					.InnerJoin("BulkEmail").As("be")
						.On("be", "RId").IsEqual("mc", "BulkEmailRId")
					.Where("cpet2", "WasUsed").IsEqual(Column.Parameter(false))
						.And("be", "Id").IsEqual(Column.Parameter(BulkEmailId));
				if (BpmTrackIds.Any()) {
					clickedQuerySelect.And("beh", "BpmTrackId").In(Column.Parameters(BpmTrackIds));
					clickedQuerySelect.InnerJoin("BulkEmailHyperlink").As("beh")
						.On("beh", "RId").IsEqual("mc", "HyperlinkRId");
				} else {
					if (Hyperlinks.Any()) {
						clickedQuerySelect.And("beh", "Id").In(Column.Parameters(Hyperlinks));
						clickedQuerySelect.InnerJoin("BulkEmailHyperlink").As("beh")
							.On("beh", "RId").IsEqual("mc", "HyperlinkRId");
					}
				}
				clickedQuerySelect.SpecifyNoLockHints();
				return clickedQuerySelect;
			}
			return null;
		}

		private Select GetSelectByParticipantReplies() {
			if (UserConnection.GetIsFeatureEnabled("BulkEmailReplyTo")
					&& EmailResponses.Contains(MarketingConsts.BulkEmailResponseRepliedId)) {
				var repliesQuerySelect = new Select(UserConnection);
				repliesQuerySelect.Column("cpet3", "CampaignParticipantId")
					.From("BulkEmailReply").As("ber")
					.InnerJoin("CmpgnPrtcpntEmailTarget").As("cpet3")
						.On("cpet3", "MandrillRecipientUId").IsEqual("ber", "MandrillId")
					.Where("cpet3", "WasUsed").IsEqual(Column.Parameter(false))
						.And("ber", "BulkEmailId").IsEqual(Column.Parameter(BulkEmailId));
				repliesQuerySelect.SpecifyNoLockHints();
				return repliesQuerySelect;
			}
			return null;
		}

		private Select GetSelectByParticipantResponses() {
			IEnumerable<Guid> emailResponses = ResponsesWithoutClick;
			if (BulkEmailId == default(Guid) || !emailResponses.Any()) {
				return null;
			}
			var responseSelect = new Select(UserConnection)
				.Column("cpet", "CampaignParticipantId")
				.From("BulkEmailTarget").As("bet")
				.InnerJoin("CmpgnPrtcpntEmailTarget").As("cpet")
					.On("bet", "MandrillId").IsEqual("cpet", "MandrillRecipientUId")
					.And("cpet", "WasUsed").IsEqual(Column.Parameter(false))
				.Where("bet", "BulkEmailId").IsEqual(Column.Parameter(BulkEmailId))
					.And("bet", "BulkEmailResponseId").In(Column.Parameters(emailResponses)) as Select;
			responseSelect.SpecifyNoLockHints();
			return responseSelect;
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Returns query that includes additional logic.
		/// </summary>
		/// <returns>Base <see cref="Update"/> extended with time and filter conditions.</returns>
		protected override void CreateQuery() {
			base.CreateQuery();
			ExtendWithResponses();
		}

		#endregion

	}

	#endregion

}

