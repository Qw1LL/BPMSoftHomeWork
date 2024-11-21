namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Specialized;
	using System.Web;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;

	#region Class: MarketingUtmParser

	/// <summary>
	/// Class to parse url parameters to find linked marketing entities.
	/// </summary>
	public class MarketingUtmParser
	{

		#region Constants: Private

		private const string BulkEmailRIdParameter = "bulk_email_rid";
		private const string PartnerParameter = "partner";
		private const string UtmCampaignParameter = "utm_campaign";

		#endregion

		#region Methods: Private

		private NameValueCollection GetUrlParameters(string url) {
			NameValueCollection urlParameters = null;
			Uri uri;
			if (Uri.TryCreate(url, UriKind.Absolute, out uri)) {
				urlParameters = HttpUtility.ParseQueryString(uri.Query);
			}
			return urlParameters;
		}

		private Guid GetBulkEmailId(UserConnection userConnection, string rId) {
			var select = new Select(userConnection).Top(1)
					.Column(nameof(BulkEmail.Id))
					.From(nameof(BulkEmail))
					.Where("RId").IsEqual(Column.Parameter(rId)) as Select;
			select.SpecifyNoLockHints();
			return select.ExecuteScalar<Guid>();
		}

		private Guid GetCampaignId(UserConnection userConnection, string utmCampaign) {
			var select = new Select(userConnection).Top(1)
				.Column(nameof(Campaign.Id))
				.From(nameof(Campaign))
				.Where(nameof(Campaign.UtmCampaign)).IsEqual(Column.Parameter(utmCampaign))
				.OrderByAsc(nameof(Campaign.CreatedOn)) as Select;
			select.SpecifyNoLockHints();
			return select.ExecuteScalar<Guid>();
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Finds first marketing campaign by utm_campaign url parameter.
		/// </summary>
		/// <param name="url">URL with parameters.</param>
		/// <returns>Campaign unique identifier or <see cref="Guid.Empty"/> value.</returns>
		public virtual Guid GetCampaignByUtm(UserConnection userConnection, string url) {
			var urlParams = GetUrlParameters(url);
			if (urlParams == null || urlParams[UtmCampaignParameter] == null) {
				return Guid.Empty;
			}
			var utmCampaign = urlParams[UtmCampaignParameter];
			return GetCampaignId(userConnection, utmCampaign);
		}

		/// <summary>
		/// Finds first bulk email by bulk_email_rid url parameter.
		/// </summary>
		/// <param name="url">URL with parameters.</param>
		/// <returns>Bulk email unique identifier or <see cref="Guid.Empty"/> value.</returns>
		public virtual Guid GetBulkEmailByUtm(UserConnection userConnection, string url) {
			var urlParams = GetUrlParameters(url);
			if (urlParams == null || urlParams[BulkEmailRIdParameter] == null
					|| urlParams[PartnerParameter] != null) {
				return Guid.Empty;
			}
			var rId = urlParams[BulkEmailRIdParameter];
			return GetBulkEmailId(userConnection, rId);
		}

		#endregion

	}

	#endregion

}

