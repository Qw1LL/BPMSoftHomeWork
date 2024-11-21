namespace BPMSoft.Configuration
{
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using BPMSoft.Core.Attributes;
	using BPMSoft.Core.Campaign;
	using BPMSoft.Core.Campaign.EventHandler;
	using CoreCampaignSchema = Core.Campaign.CampaignSchema;

	/// <summary>
	/// Contains methods for maintaining Add Audience elements in campaign.
	/// </summary>
	public sealed class AddCampaignAudienceElementHandler : BaseCampaignAudienceElementHandler, IOnCampaignValidate
	{

		#region Constructors: Public

		public AddCampaignAudienceElementHandler() {
			elementHandlerName = GetType().Name;
		}

		#endregion

		#region Methods: Private

		private void WriteFilterValidationInfo(BaseCampaignAudienceElement element) {
			var message = GetLczStringValue(elementHandlerName, "FilterWithNoConditionWarning");
			var validationInfoMessage = string.Format(message, element.Caption);
			CampaignSchema.AddValidationInfo(validationInfoMessage, CampaignValidationInfoLevel.Warning);
		}

		private void ValidateFolders(IEnumerable<BaseCampaignAudienceElement> elements) {
			if (!elements.Any()) {
				return;
			}
			var folders = LoadFoldersInfo(elements);
			CheckFoldersExistense(elements, folders);
			var foldersWithNoFilter = FindFoldersWithNoFilter(folders);
			string message = GetLczStringValue(elementHandlerName, "FolderWithNoConditionWarning");
			WriteValidationInfo(elements, foldersWithNoFilter, message, CampaignValidationInfoLevel.Warning);
		}

		private void ValidateFilters(IEnumerable<AddCampaignParticipantElement> elements) {
			foreach (var element in elements) {
				var searchData = Encoding.UTF8.GetBytes(element.Filter);
				var schemaName = element.GetAudienceEntitySchemaInfo(UserConnection).schemaName;
				var searchDataHasFilter = FolderHelper.CheckSearchDataHasFilter(schemaName, searchData, UserConnection);
				if (!searchDataHasFilter) {
					WriteFilterValidationInfo(element);
				}
			}
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Returns the list of <see cref="AddCampaignParticipantElement"/> campaign audience elements.
		/// </summary>
		/// <param name="schema">Campaign schema instance.</param>
		/// <returns>List of concrete campaign audience elements.</returns>
		protected override IEnumerable<BaseCampaignAudienceElement> GetAudienceElements(CoreCampaignSchema schema) {
			return schema.FlowElements.OfType<AddCampaignParticipantElement>();
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Validates Add Audience elements on campaign validation. Searches folders with no conditions.
		/// </summary>
		[Order(1)]
		public void OnValidate() {
			var elements = GetAudienceElements(CampaignSchema).OfType<AddCampaignParticipantElement>();
			if (!elements.Any()) {
				return;
			}
			var elementsWithFolders = elements.Where(x => !x.HasFilter);
			ValidateFolders(elementsWithFolders);
			var elementsWithFilters = elements.Where(x => x.HasFilter);
			ValidateFilters(elementsWithFilters);
		}

		#endregion

	}
}

