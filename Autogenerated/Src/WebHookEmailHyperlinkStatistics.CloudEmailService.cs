namespace BPMSoft.Configuration
{
	using System;
	using Core;
	using Core.DB;

	#region Class: EmailHyperlinkStatistics

	public class EmailHyperlinkStatistics : BaseWebHook
	{

		#region Properties: Public

		public Guid EmailId {
			get;
			set;
		}

		public string HyperLink {
			get;
			set;
		}

		#endregion

		public int Clicks {
			get;
			set;
		}

		#region Methods: Public

		public override string GetGroupKey() {
			return base.GetGroupKey() + EmailId.ToString() + HyperLink;
		}

		public override void HandleWebHook(UserConnection userConnection) {
			int hyperLinkRId = WebHookUtilities.GetHyperLinkRId(userConnection, HyperLink, EmailId);
			if (hyperLinkRId == 0) {
				return;
			}
			new Update(userConnection, "BulkEmailHyperlink")
				.Set("ClicksCount", Column.Parameter(Clicks))
				.Where("BulkEmailId").IsEqual(Column.Parameter(EmailId))
				.And("RId").IsEqual(Column.Parameter(hyperLinkRId)).Execute();
		}

		#endregion

	}
	
	#endregion

}
