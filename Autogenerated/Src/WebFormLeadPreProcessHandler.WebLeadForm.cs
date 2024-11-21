namespace BPMSoft.Configuration
{
	using GeneratedWebFormService;
	using Core;
	using Core.Factories;

	#region Class: WebFormLeadPreProcessHandler

	/// <summary>
	/// Handles pre process handling for lead saving.
	/// </summary>
	/// <seealso cref="BPMSoft.Configuration.IGeneratedWebFormPreProcessHandler" />
	public class WebFormLeadPreProcessHandler: IGeneratedWebFormPreProcessHandler
	{

		#region Properties: Protected

		protected UserConnection UserConnection {
			get;
			set;
		}

		#endregion

		#region Methods: Protected

		protected void SetUpWebFormMapper(IWebFormImportParamsGenerator paramsGenerator) {
			paramsGenerator.DefaultValueManager = ClassFactory.Get<LeadDefaultValueManager>();
		}

		protected void EditFormData(FormData formData) {
			foreach (FormFieldsData formFieldsData in formData.formFieldsData) {
				CorrectNameValue(formFieldsData);
				CorrectGeographicalColumns(formFieldsData);
			}
		}

		protected void CorrectGeographicalColumns(FormFieldsData formFieldsData) {
			if (!WebFormHelper.IsGeographicalColumn(formFieldsData.name)) {
				return;
			}
			var column = WebFormHelper.GetGeographicalUnitColumn(formFieldsData.name, 
				formFieldsData.value, 
				UserConnection);
			formFieldsData.name = column.Key;
			formFieldsData.value = column.Value;
		}

		protected void CorrectNameValue(FormFieldsData formFieldsData) {
			var editedColumn = NameValueCorrector.GetCorrectNameValue(formFieldsData.name, formFieldsData.value);
			formFieldsData.name = editedColumn.Key;
			formFieldsData.value = editedColumn.Value;
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
			SetUpWebFormMapper(paramsGenerator);
			EditFormData(formData);
			return formData;
		}

		#endregion

	}

	#endregion

}

