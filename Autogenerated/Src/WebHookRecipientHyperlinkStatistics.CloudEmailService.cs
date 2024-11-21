namespace BPMSoft.Configuration
{
	using System;
	using Core;
	using Core.DB;

	#region Class: RecipientHyperlinkStatistics

	public class RecipientHyperlinkStatistics : BaseWebHook
	{

		#region Properties: Public

		public Guid RecipientUId {
			get;
			set;
		}

		public string HyperLink {
			get;
			set;
		}

		public Guid EmailId {
			get;
			set;
		}

		#endregion

		#region Methods: Public

		public override string GetGroupKey() {
			return base.GetGroupKey() + RecipientUId.ToString() + HyperLink;
		}

		public override void HandleWebHook(UserConnection userConnection) {
			int hyperLinkRId = WebHookUtilities.GetHyperLinkRId(userConnection, HyperLink, EmailId);
			if (hyperLinkRId == 0) {
				return;
			}
			var selectQuery = new Select(userConnection)
				.Column("BulkEmail", "RId")
				.Column("Contact", "RId")
				.Column(Column.Parameter(hyperLinkRId))
				.Column(Column.Parameter(EventDate))
				.Column(Column.Parameter(RecipientUId))
				.From("BulkEmailTarget")
				.InnerJoin("BulkEmail").On("BulkEmailTarget", "BulkEmailId").IsEqual("BulkEmail", "Id")
				.InnerJoin("Contact").On("BulkEmailTarget", "ContactId").IsEqual("Contact", "Id")
				.Where().Not().Exists(new Select(userConnection)
					.Column(Column.Const(1))
					.From("MandrillClicks")
					.Where("MandrillClicks", "RecipientUId").IsEqual(Column.Parameter(RecipientUId))
					.And("MandrillClicks", "HyperlinkRId").IsEqual(Column.Parameter(hyperLinkRId)))
				.And("BulkEmailTarget","MandrillId").IsEqual(Column.Parameter(RecipientUId)) as Select;
			selectQuery.SpecifyNoLockHints();
			new InsertSelect(userConnection).Into("MandrillClicks")
				.Set("BulkEmailRId", "ContactRId", "HyperlinkRId", "TimeStamp", "RecipientUId")
				.FromSelect(selectQuery).Execute();
		}

		#endregion

	}
	
	#endregion

}
