namespace BPMSoft.Configuration
{
	using System;
	using BPMSoft.Core.Campaign;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;

	#region Class: CampaignAddObjectFlowElement

	/// <summary>
	/// Executable add object element at campaign.
	/// </summary>
	public class CampaignAddObjectFlowElement : CampaignBaseCrudObjectFlowElement
	{

		#region Methods: Private

		private Entity GetNewEntity() {
			var entitySchema = UserConnection.EntitySchemaManager.GetInstanceByName(EntityName);
			var newEntity = entitySchema.CreateEntity(UserConnection);
			newEntity.SetDefColumnValues();
			newEntity.UseAdminRights = false;
			return newEntity;
		}

		private void FillContactColumnValue(ref Entity entity, string contactColumnName, Guid contactId) {
			var column = entity.Schema.Columns.FindByName(contactColumnName);
			entity.SetColumnValue(column, contactId);
		}

		private bool CreateNewEntity(CmpgnAddObjElEntity entitySettings, Guid contactId, Guid participantId) {
			var newEntity = GetNewEntity();
			FillContactColumnValue(ref newEntity, entitySettings.ContactColumnPath, contactId);
			FillEntityColumns(newEntity, contactId, entitySettings.Columns, entitySettings.RestrictedColumns);
			try {
				return newEntity.Save(false);
			} catch (Exception ex) {
				CampaignLogger.ErrorFormat(nameof(CampaignAddObjectFlowElement), ex, newEntity.SchemaName,
					$"ParticipantId = {participantId}");
			}
			return false;
		}

		private CmpgnAddObjElEntity GetEntitySettingsFromLookup() {
			var lookupEsq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, nameof(CmpgnAddObjElEntity)) {
				UseAdminRights = false,
				IgnoreDisplayValues = true
			};
			lookupEsq.AddAllSchemaColumns(true);
			var filter = lookupEsq.CreateFilterWithParameters(FilterComparisonType.Equal,
				nameof(CmpgnAddObjElEntity.EntityName), EntityName);
			lookupEsq.Filters.Add(filter);
			var entities = lookupEsq.GetEntityCollection(UserConnection);
			if (entities.Count == 0) {
				var message = string.Format(EntitySettingsNotFoundExceptionMessage, EntityName);
				throw new Exception(message);
			}
			return new CmpgnAddObjElEntity(UserConnection) {
				EntityName = entities[0].GetTypedColumnValue<string>(nameof(CmpgnAddObjElEntity.EntityName)),
				ContactColumnPath = entities[0]
					.GetTypedColumnValue<string>(nameof(CmpgnAddObjElEntity.ContactColumnPath)),
				Columns = entities[0].GetTypedColumnValue<string>(nameof(CmpgnAddObjElEntity.Columns)),
				RestrictedColumns = entities[0]
					.GetTypedColumnValue<string>(nameof(CmpgnAddObjElEntity.RestrictedColumns))
			};
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Executes current flow element in fragment.
		/// </summary>
		/// <returns>Count of participants which has been processed.</returns>
		protected override int FragmentExecute() {
			var entitySettings = GetEntitySettingsFromLookup();
			var audienceByContact = GetAudienceContacts();
			foreach (var contact in audienceByContact) {
				var participantId = contact.Key;
				var contactId = contact.Value;
				var isEntityCreated = CreateNewEntity(entitySettings, contactId, participantId);
				if (!isEntityCreated) {
					UpdateParicipantStatus(participantId, CampaignConstants.CampaignParticipantErrorStatusId);
				}
			}
			return SetItemCompleted((Select)GetAudienceQuery());
		}

		#endregion

	}

	#endregion

}
