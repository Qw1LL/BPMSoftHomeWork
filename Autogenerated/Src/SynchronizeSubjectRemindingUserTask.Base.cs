namespace BPMSoft.Core.Process.Configuration
{

	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using System.Linq;
	using BPMSoft.Common;
	using BPMSoft.Configuration;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Process;
	using BPMSoft.UI.WebControls.Controls;

	#region Class: SynchronizeSubjectRemindingUserTask

	/// <exclude/>
	public partial class SynchronizeSubjectRemindingUserTask
	{

		#region Methods: Protected

		protected override bool InternalExecute(ProcessExecutingContext context) {
			if (Author == null) {
				Author = UserConnection.CurrentUser.ContactId;
			}
			var remindingSchema = UserConnection.EntitySchemaManager.GetInstanceByName("Reminding");
			var remindingSchemaColumns = remindingSchema.Columns;
			bool remindingExists = false;
			var entitySchemaManager = UserConnection.EntitySchemaManager;
			var query = new EntitySchemaQuery(entitySchemaManager, "Reminding") {
				UseAdminRights = GlobalAppSettings.FeatureUseAdminRightsInEmbeddedLogic
			};
			query.AddAllSchemaColumns();
			query.Filters.Add(query.CreateFilterWithParameters(FilterComparisonType.Equal, "SubjectId", SubjectPrimaryColumnValue));
			if(!IsSubjectDelete &&  !IsSingleReminder) {
				query.Filters.Add(query.CreateFilterWithParameters(FilterComparisonType.Equal, "Contact", Contact));
			}
			query.Filters.Add(query.CreateFilterWithParameters(FilterComparisonType.Equal, "Source", (Guid) Source));
			query.Filters.Add(query.CreateFilterWithParameters(FilterComparisonType.Equal, "SysEntitySchema.SysWorkspace.Id", UserConnection.Workspace.Id));
			var entities = query.GetEntityCollection(UserConnection);
			if (IsSingleReminder) {
				var entityToDelete = entities.Where(e => {
					var contactId = e.GetTypedColumnValue<Guid>("ContactId");
					return !contactId.Equals(Contact);
				});
				while(entityToDelete.Any()) {
					entityToDelete.First().Delete();
				}
			}
			remindingExists = entities.Count > 0 && !IsListSubjectReminds;
			Entity requiredReminding = entities.Count == 0 || IsListSubjectReminds
				? remindingSchema.CreateEntity(UserConnection)
				: entities[0];
			requiredReminding.UseAdminRights = GlobalAppSettings.FeatureUseAdminRightsInEmbeddedLogic;
			
			if (Active){
				if(!remindingExists) {
					requiredReminding.SetDefColumnValues();
					requiredReminding.PrimaryColumnValue = Guid.NewGuid();
				}
				if (SubjectPrimaryColumnValue != Guid.Empty) {
					requiredReminding.SetColumnValue(
						remindingSchemaColumns.GetByName("SubjectId").ColumnValueName, 
						SubjectPrimaryColumnValue
					);
					if (!string.IsNullOrEmpty(SubjectCaption)) {
						var subjectCaptionColumn = remindingSchemaColumns.GetByName("SubjectCaption");
						var subjectCaptionColumnSize = ((TextDataValueType)subjectCaptionColumn.DataValueType).Size;
						var subjectCaptionValue = SubjectCaption.Length > subjectCaptionColumnSize
							? SubjectCaption.Substring(0, subjectCaptionColumnSize)
							: SubjectCaption;
						requiredReminding.SetColumnValue(
									remindingSchemaColumns.GetByName("SubjectCaption").ColumnValueName, 
									subjectCaptionValue);
					} else {
						if(SysEntitySchema != Guid.Empty) {
							var subjectSchema = UserConnection.EntitySchemaManager.GetInstanceByUId(SysEntitySchema);
							var subjectEntity = subjectSchema.CreateEntity(UserConnection);
							if (subjectEntity.FetchFromDB(SubjectPrimaryColumnValue)) {
								requiredReminding.SetColumnValue(
									remindingSchemaColumns.GetByName("SubjectCaption").ColumnValueName, 
									subjectEntity.GetTypedColumnValue<String>(subjectSchema.GetPrimaryDisplayColumnName())
								);
							}
						}
					}
				}
				if (Contact != Guid.Empty) {
					requiredReminding.SetColumnValue(
						remindingSchemaColumns.GetByName("Contact").ColumnValueName, 
						Contact
					);
				}
				if (!string.IsNullOrEmpty(TypeCaption)) {
					var typeCaptionColumn = remindingSchemaColumns.GetByName("TypeCaption");
					if (typeCaptionColumn != null) {
						requiredReminding.SetColumnValue(typeCaptionColumn.ColumnValueName, TypeCaption);
					}
				}
				if ((Guid)Source != Guid.Empty) {
					requiredReminding.SetColumnValue(
						remindingSchemaColumns.GetByName("Source").ColumnValueName, 
						(Guid)Source
					);
				}
				requiredReminding.SetColumnValue(
					remindingSchemaColumns.GetByName("RemindTime").ColumnValueName, 
					RemindTime
				);
				if ((Guid)Author != Guid.Empty) {
					requiredReminding.SetColumnValue(
						remindingSchemaColumns.GetByName("Author").ColumnValueName, 
						(Guid)Author
					);
				}
				requiredReminding.SetColumnValue(
					remindingSchemaColumns.GetByName("Description").ColumnValueName, 
					Description
				);
				if (SysEntitySchema != Guid.Empty) {
					requiredReminding.SetColumnValue(
						remindingSchemaColumns.GetByName("SysEntitySchema").ColumnValueName,
						SysEntitySchema
					);
				}
				if (PopupTitle.IsNotNullOrWhiteSpace()) {
					requiredReminding.SetColumnValue("PopupTitle", PopupTitle);
				}
				if (UserConnection.GetIsFeatureEnabled("NotificationV2")) {
					requiredReminding.SetColumnValue("IsNeedToSend", true);
				}
				requiredReminding.SetColumnValue(
					remindingSchemaColumns.GetByName("NotificationType").ColumnValueName, 
					NotificationType
				);
				requiredReminding.Save();
			} else {
				if(!IsListSubjectReminds && !IsSubjectDelete) {
					requiredReminding.Delete();
				} else {
					DeleteRemindingList(entities);
				}
			}
			return true;
		}

		#endregion

		#region Methods: Public

		public virtual void DeleteRemindingList(EntityCollection entities) {
			while(entities.Any()) {
				entities.First().Delete();
			}
		}

		#endregion

	}

	#endregion

}

