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
	using CoreCampaignSchema = Core.Campaign.CampaignSchema;

	/// <summary>
	/// Contains methods for maintaining audience elements in campaign.
	/// </summary>
	public abstract class BaseCampaignAudienceElementHandler : CampaignEventHandlerBase, IOnCampaignAfterSave,
		IOnCampaignCopy
	{

		#region Fields: Protected

		/// <summary>
		/// Name of the element handler.
		/// </summary>
		protected string elementHandlerName;

		/// <summary>
		/// The UId of the ContactFolder schema.
		/// </summary>
		protected Guid ContactFolderSchemaUId = new Guid("AA35AFC4-CB11-42A9-B17E-2FFEF173EEB6");

		#endregion

		#region Properties: Public

		/// <summary>
		/// An instance of the <see cref="FolderHelper"/>.
		/// </summary>
		private FolderHelper _folderHelper;
		public FolderHelper FolderHelper {
			get {
				return _folderHelper ?? (_folderHelper = new FolderHelper());
			}
			set {
				_folderHelper = value;
			}
		}

		#endregion

		#region Methods: Private

		private IEnumerable<BaseCampaignAudienceElement> GetModifiedAudienceElements() {
			var currentElements = GetAudienceElements(CampaignSchema);
			if (CampaignSchema.InitialSchema == null) {
				return currentElements;
			}
			var initialElements = GetAudienceElements(CampaignSchema.InitialSchema);
			var sameElements = initialElements.Join(currentElements,
					initial => initial.UId,
					current => current.UId,
					(initial, current) => (initial.FolderId == current.FolderId, current))
				.Where(x => x.Item1)
				.Select(x => x.Item2);
			return currentElements.Except(sameElements);
		}

		private Guid GetFolderSchemaUId(string entitySchemaName) {
			var folderSchemaName = entitySchemaName + "Folder";
			var entitySchema = UserConnection.EntitySchemaManager.FindItemByName(folderSchemaName);
			return entitySchema == null ? Guid.Empty : entitySchema.UId;
		}

		/// <summary>
		/// Updates CampaignItem with connected ContactFolder id for the list of elements.
		/// </summary>
		/// <param name="elements">List of <see cref="BaseCampaignAudienceElement"/>.</param>
		private void UpdateConnectedFoldersInfo(IEnumerable<BaseCampaignAudienceElement> elements) {
			foreach (var element in elements) {
				var folderId = element.FolderId.IsEmpty() ? null as Guid? : element.FolderId;
				var schemaInfo = element.GetAudienceEntitySchemaInfo(UserConnection);
				var schemaUId = GetFolderSchemaUId(schemaInfo.schemaName);
				schemaUId = schemaUId.IsEmpty() ? ContactFolderSchemaUId : schemaUId;
				UpdateCampaignItemConnectedRecordInfo(element.UId, schemaUId, folderId);
			}
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Returns the list of concrete campaign audience elements, specific for derived handler.
		/// </summary>
		/// <param name="schema">Campaign schema instance.</param>
		/// <returns>List of concrete campaign audience elements.</returns>
		protected abstract IEnumerable<BaseCampaignAudienceElement> GetAudienceElements(CoreCampaignSchema schema);

		/// <summary>
		/// Writes validation message to validation results.
		/// </summary>
		/// <param name="audienceElements">Collection of the audience elements.</param>
		/// <param name="folderIds">Collection of identifiers of the broken folders.</param>
		/// <param name="message">Text of the validation message.</param>
		/// <param name="level">The level of the validation message.</param>
		protected void WriteValidationInfo(IEnumerable<BaseCampaignAudienceElement> audienceElements,
				List<Guid> folderIds, string message, CampaignValidationInfoLevel level) {
			foreach (var folderId in folderIds) {
				var element = audienceElements.FirstOrDefault(x => x.FolderId == folderId);
				if (element == null) {
					continue;
				}
				string validationInfoMessage = string.Format(message, element.Caption);
				CampaignSchema.AddValidationInfo(validationInfoMessage, level);
			}
		}

		/// <summary>
		/// Checks existense of folders in loaded collection. Writes results to validation info.
		/// </summary>
		protected void CheckFoldersExistense(IEnumerable<BaseCampaignAudienceElement> audienceElements,
				List<FolderInfoModel> folders){
			foreach (BaseCampaignAudienceElement element in audienceElements) {
				if (!folders.Any(x => x.Id == element.FolderId)) {
					string message = GetLczStringValue(elementHandlerName, "FolderNotFoundError");
					string validationInfoMessage = string.Format(message, element.Caption);
					CampaignSchema.AddValidationInfo(validationInfoMessage, CampaignValidationInfoLevel.Error);
				}
			}
		}

		/// <summary>
		/// Loads folders information from storage.
		/// </summary>
		/// <param name="audienceElements">Collection of audience elements.</param>
		/// <returns>Collection of the loaded folders.</returns>
		protected List<FolderInfoModel> LoadFoldersInfo(IEnumerable<BaseCampaignAudienceElement> audienceElements) {
			var folderGroups = audienceElements.GroupBy(x => x.AudienceSchemaId);
			var folders = new List<FolderInfoModel>();
			foreach (var group in folderGroups) {
				var folderIds = group.Select(x => x.FolderId).ToList();
				var entitySchemaInfo = group.First().GetAudienceEntitySchemaInfo(UserConnection);
				var folderSchemaName = entitySchemaInfo.schemaName + "Folder";
				var infoModels = FolderHelper.GetFoldersInfo(folderSchemaName, folderIds, UserConnection);
				infoModels.ForEach(x => x.EntitySchemaName = entitySchemaInfo.schemaName);
				folders.AddRange(infoModels);
			}
			return folders;
		}

		/// <summary>
		/// Finds dynamic folders without filters.
		/// </summary>
		/// <param name="folders">Collection of folders.</param>
		/// <returns>List of identifiers of the folders without filters.</returns>
		protected List<Guid> FindFoldersWithNoFilter(List<FolderInfoModel> folders) {
			var foldersWithNoFilter = new List<Guid>();
			foreach (FolderInfoModel folder in folders) {
				if (folder.TypeId == MarketingConsts.FolderTypeDynamicId) {
					var entityTableName = folder.EntitySchemaName.IsNullOrWhiteSpace()
						? "Contact"
						: folder.EntitySchemaName;
					var hasFilter = FolderHelper.CheckSearchDataHasFilter(entityTableName, folder.SearchDataBin,
						UserConnection);
					if (!hasFilter) {
						foldersWithNoFilter.Add(folder.Id);
					}
				}
			}
			return foldersWithNoFilter;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Updates connected records info (RecordId and SchemaUId fields) after campaign has been copied.
		/// </summary>
		[Order(2)]
		public void OnCopy() {
			try {
				var allElements = GetAudienceElements(CampaignSchema);
				UpdateConnectedFoldersInfo(allElements);
			} catch (Exception ex) {
				CampaignLogger.ErrorFormat(elementHandlerName, ex, CampaignSchema.EntityId);
				throw;
			}
		}

		/// <summary>
		/// Updates connected records info (RecordId and SchemaUId fields) after campaign has been saved.
		/// </summary>
		public void OnAfterSave() {
			try {
				var modifiedElements = GetModifiedAudienceElements();
				UpdateConnectedFoldersInfo(modifiedElements);
			} catch (Exception ex) {
				CampaignLogger.ErrorFormat(elementHandlerName, ex, CampaignSchema.EntityId);
				throw;
			}
		}

		#endregion

	}
}

