namespace BPMSoft.Configuration
{
	using System.Collections.Generic;
	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Entities.Events;

	#region Class: FormSubmitEntityEventListener

	/// <summary>
	/// Listener for <see cref="FormSubmit"/> entity events.
	/// </summary>
	/// <seealso cref="BaseEntityEventListener" />
	[EntityEventListener(SchemaName = nameof(FormSubmit))]
	public class FormSubmitEntityEventListener : BaseEntityEventListener
	{

		#region Properties: Public

		/// <summary>
		/// Instance of <see cref="MarketingUtmParser"/> to find linked entities by utm params.
		/// </summary>
		private MarketingUtmParser _utmParser;
		public MarketingUtmParser UtmParser {
			get => _utmParser ?? (_utmParser = new MarketingUtmParser());
			set => _utmParser = value;
		}

		#endregion

		#region Methods: Private

		private void BindLinkedEntities(FormSubmit entity) {
			if (!entity.WebFormData.FetchFromDB("Id", entity.WebFormDataId, new[] { "Data" })) {
				return;
			}
			var formDataJson = entity.WebFormData.GetTypedColumnValue<string>("Data");
			var formData = Json.Deserialize<Dictionary<string, string>>(formDataJson);
			if (!formData.TryGetValue("BpmHref", out var url) || string.IsNullOrWhiteSpace(url)) {
				return;
			}
			TryBindCampaign(entity, url);
			TryBindBulkEmail(entity, url);
		}

		private void TryBindBulkEmail(FormSubmit entity, string url) {
			var bulkEmailId = UtmParser.GetBulkEmailByUtm(entity.UserConnection, url);
			if (bulkEmailId.IsNotEmpty()) {
				entity.SetColumnValue("BulkEmailId", bulkEmailId);
			}
		}

		private void TryBindCampaign(FormSubmit entity, string url) {
			var campaignId = UtmParser.GetCampaignByUtm(entity.UserConnection, url);
			if (campaignId.IsNotEmpty()) {
				entity.SetColumnValue("CampaignId", campaignId);
			}
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Handles <see cref="FormSubmit"/> entity <see cref="OnInserting"/> event.
		/// </summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="e">The <see cref="T:BPMSoft.Core.Entities.EntityBeforeEventArgs" /> instance containing the
		/// event data.</param>
		public override void OnInserting(object sender, EntityBeforeEventArgs e) {
			base.OnInserting(sender, e);
			var entity = (FormSubmit)sender;
			BindLinkedEntities(entity);
		}

		#endregion

	}

	#endregion

}


