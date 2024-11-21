namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using BPMSoft.Core;
	using GeneratedWebFormService;
	using BPMSoft.Core.Factories;

	#region Class: WebFormSubmitPreProcessHandler

	/// <summary>
	/// Handles pre process handling for form submit saving.
	/// </summary>
	/// <seealso cref="BPMSoft.Configuration.IGeneratedWebFormPreProcessHandler" />
	public class WebFormSubmitPreProcessHandler : IGeneratedWebFormPreProcessHandler
	{

		#region Properties: Protected

		protected UserConnection UserConnection { get; set; }

		protected FormData FormData { get; set; }

		private ITouchSource _sourceHelper;
		public ITouchSource SourceHelper {
			get => _sourceHelper ?? (_sourceHelper =
				ClassFactory.Get<ITouchSource>(new ConstructorArgument("userConnection", UserConnection)));
			set => _sourceHelper = value;
		}

		#endregion

		#region Methods: Private

		private void AddFormFieldValue(string fieldName, string value) {
			var fieldsData = FormData.formFieldsData.ToList();
			var formField = fieldsData.FirstOrDefault(f => f.name.Equals(fieldName));
			if (formField == null && !string.IsNullOrWhiteSpace(value)) {
				fieldsData.Add(new FormFieldsData() {
					name = fieldName,
					value = value
				});
				FormData.formFieldsData = fieldsData.ToArray();
			}
		}

		#endregion

		#region Methods: Protected

		protected void EditFormData() {
			var bpmHref = FormData.formFieldsData.SingleOrDefault(x => x.name == "BpmHref")?.value;
			var bpmRef = FormData.formFieldsData.SingleOrDefault(x => x.name == "BpmRef")?.value;
			if (bpmHref == null && bpmRef == null) {
				return;
			}
			var result = SourceHelper.ComputeMediumAndSource(FormData);
			if (result.Source != Guid.Empty) {
				AddFormFieldValue("SourceId", result.Source.ToString());
			}
			if (result.Medium != Guid.Empty) {
				AddFormFieldValue("ChannelId", result.Medium.ToString());
			}
			AddFormFieldValue("Referrer", bpmRef);
			AddFormFieldValue("UtmMediumStr", SourceHelper.BpmHrefParameters["utm_medium"]);
			AddFormFieldValue("UtmSourceStr", SourceHelper.BpmHrefParameters["utm_source"]);
			AddFormFieldValue("UtmCampaignStr", SourceHelper.BpmHrefParameters["utm_campaign"]);
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Executes the the pre processing for specified landing page.
		/// </summary>
		/// <param name="userConnection">The user connection.</param>
		/// <param name="formData">The form data.</param>
		/// <param name="paramsGenerator">The parameters generator.</param>
		/// <returns>
		/// Processed form data.
		/// </returns>
		public FormData Execute(UserConnection userConnection, FormData formData,
				IWebFormImportParamsGenerator paramsGenerator) {
			UserConnection = userConnection;
			FormData = formData;
			EditFormData();
			return FormData;
		}

		#endregion

	}

	#endregion

}

