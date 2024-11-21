namespace BPMSoft.Core.Process.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Data.Common;
	using System.Linq;
	using System.Runtime.CompilerServices;
	using global::Common.Logging;
	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Configuration;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Process;

	#region Class: ChangeAdminRightsUserTask

	/// <exclude/>
	public partial class ChangeAdminRightsUserTask
	{

		#region Fields: Private

		private ILog _traceLog;

		#endregion

		#region Methods: Private

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void TraceLog(Func<Guid, string> message) {
			if (_traceLog.IsTraceEnabled) {
				_traceLog.Trace(message(UId));
			}
		}

		private void SetupTraceLogger() {
			string name = nameof(ChangeAdminRightsUserTask);
			try {
				name += ":" + Owner?.Schema?.Name;
			} catch (Exception e) {
				Log.Warn(e);
			}
			_traceLog = LogManager.GetLogger(name);
		}

		#endregion

		#region Methods: Protected

		/// <inheritdoc />
		protected override bool InternalExecute(ProcessExecutingContext context) {
			SetupTraceLogger();
			TraceLog(uId => $"{uId} Enter");
			if (EntitySchemaUId == Guid.Empty) {
				TraceLog(uId => $"{uId} Exit: EntitySchemaUId is empty");
				return true;
			}
			var deleteRights = !string.IsNullOrEmpty(DeleteRights)
				? Json.Deserialize<List<Dictionary<string, object>>>(DeleteRights)
				: new List<Dictionary<string, object>>(0);
			var addRights = !string.IsNullOrEmpty(AddRights)
				? Json.Deserialize<List<Dictionary<string, object>>>(AddRights)
				: new List<Dictionary<string, object>>(0);
			if (deleteRights.Count == 0 && addRights.Count == 0) {
				TraceLog(uId => $"{uId} Exit: deleteRights and addRights empty");
				return true;
			}
			EntitySchemaManager entitySchemaManager = UserConnection.EntitySchemaManager;
			EntitySchema entitySchema = entitySchemaManager.FindInstanceByUId(EntitySchemaUId);
			if (entitySchema == null) {
				TraceLog(uId => $"{uId} Exit: entitySchema null");
				return true;
			}
			if (!entitySchema.AdministratedByRecords) {
				TraceLog(uId => $"{uId} Exit: entitySchema AdministratedByRecords=false");
				return true;
			}
			var entitySchemaQuery = new EntitySchemaQuery(entitySchema) {
				UseAdminRights = false
			};
			entitySchemaQuery.PrimaryQueryColumn.IsAlwaysSelect = true;
			if (!string.IsNullOrEmpty(DataSourceFilters)) {
				ProcessUserTaskUtilities.SpecifyESQFilters(UserConnection, this, entitySchema, entitySchemaQuery,
					DataSourceFilters);
				bool isEmptyFilter = entitySchemaQuery.Filters.Count == 0;
				if (!isEmptyFilter && entitySchemaQuery.Filters.Count == 1) {
					if (entitySchemaQuery.Filters[0] is EntitySchemaQueryFilterCollection filterGroup &&
							filterGroup.Count == 0) {
						TraceLog(uId => $"{uId} Exit: filters empty");
						return true;
					}
				}
			}
			Select selectQuery = entitySchemaQuery.GetSelectQuery(UserConnection);
			var entityRecordIdList = new List<Guid>();
			selectQuery.ExecuteReader(reader => {
				Guid entityRecordId = reader.GetGuid(0);
				entityRecordIdList.Add(entityRecordId);
			});
			TraceLog(uId => $"{uId} entityRecordIdList: {string.Join(",", entityRecordIdList)}");
			DBSecurityEngine dbSecurityEngine = UserConnection.DBSecurityEngine;
			string schemaName = entitySchema.Name;
			bool useDenyRecordRights = entitySchema.UseDenyRecordRights;
			foreach (Guid entityRecordId in entityRecordIdList) {
				foreach (Dictionary<string, object> deleteRight in deleteRights) {
					DeleteRecordRight(dbSecurityEngine, entityRecordId, schemaName, deleteRight);
				}
				for (int i = addRights.Count - 1; i >= 0; i--) {
					AddRecordRight(dbSecurityEngine, entityRecordId, schemaName, useDenyRecordRights, addRights[i]);
				}
			}
			return true;
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc />
		public override string GetExecutionData() {
			return string.Empty;
		}

		public virtual void DeleteRecordRight(DBSecurityEngine dbSecurityEngine, Guid entityRecordId,
				string entitySchemaName, Dictionary<string, object> recordRight) {
			bool canRead = (bool)recordRight["CanRead"];
			bool canEdit = (bool)recordRight["CanEdit"];
			bool canDelete = (bool)recordRight["CanDelete"];
			var recordRightGrantee = (string)recordRight["Grantee"];
			switch (recordRightGrantee) {
				case "Role":
				case "Employee":
				case "DataSourceFilter":
					List<KeyValuePair<Guid, string>> adminUnitIds = GetAdminUnitIds(recordRight);
					TraceLog(uId => $"{uId} delete rights for {string.Join(",", adminUnitIds.Select(a => a.Key))}. " +
						$"canRead={canRead} canEdit={canEdit} canDelete={canDelete}");
					foreach(KeyValuePair<Guid, string> adminUnitId in adminUnitIds) {
						if (canRead) {
							dbSecurityEngine.ForceDeleteEntitySchemaRecordRightLevel(adminUnitId.Key,
								EntitySchemaRecordRightOperation.Read, entitySchemaName, entityRecordId);
						}
						if (canEdit) {
							dbSecurityEngine.ForceDeleteEntitySchemaRecordRightLevel(adminUnitId.Key,
								EntitySchemaRecordRightOperation.Edit, entitySchemaName, entityRecordId);
						}
						if (canDelete) {
							dbSecurityEngine.ForceDeleteEntitySchemaRecordRightLevel(adminUnitId.Key,
								EntitySchemaRecordRightOperation.Delete, entitySchemaName, entityRecordId);
						}
					}
					break;
				case "AllRolesAndUsers":
					TraceLog(uId => $"{uId} delete rights for all. " +
						$"canRead={canRead} canEdit={canEdit} canDelete={canDelete}");
					if (canRead) {
						dbSecurityEngine
							.ForceDeleteAllEntitySchemaRecordRightLevel(EntitySchemaRecordRightOperation.Read,
								entitySchemaName, entityRecordId);
					}
					if (canEdit) {
						dbSecurityEngine
							.ForceDeleteAllEntitySchemaRecordRightLevel(EntitySchemaRecordRightOperation.Edit,
								entitySchemaName, entityRecordId);
					}
					if (canDelete) {
						dbSecurityEngine
							.ForceDeleteAllEntitySchemaRecordRightLevel(EntitySchemaRecordRightOperation.Delete,
								entitySchemaName, entityRecordId);
					}
					break;
				default:
					TraceLog(uId => $"{uId} Unsupported grantee: {recordRightGrantee}");
					break;
			}
		}

		public virtual void AddRecordRight(DBSecurityEngine dbSecurityEngine, Guid entityRecordId,
				string entitySchemaName, bool useDenyRecordRight, Dictionary<string, object> recordRight) {
			bool canRead = (bool)recordRight["CanRead"];
			bool canEdit = (bool)recordRight["CanEdit"];
			bool canDelete = (bool)recordRight["CanDelete"];
			var rightLevel = (EntitySchemaRecordRightLevel)(int.Parse((string)recordRight["OperationRightLevel"]));
			List<KeyValuePair<Guid, string>> adminUnitIds = GetAdminUnitIds(recordRight);
			TraceLog(uId => $"{uId} add rights for {string.Join(",", adminUnitIds.Select(a => a.Key))}. " +
				$"canRead={canRead} canEdit={canEdit} canDelete={canDelete}, rightLevel={rightLevel}");
			foreach(KeyValuePair<Guid, string> adminUnitId in adminUnitIds) {
				try {
					if (canRead) {
						dbSecurityEngine.SetEntitySchemaRecordOperationRightLevel(adminUnitId.Key, entitySchemaName,
							entityRecordId, EntitySchemaRecordRightOperation.Read, rightLevel, useDenyRecordRight,
							true);
					}
					if (canEdit) {
						dbSecurityEngine.SetEntitySchemaRecordOperationRightLevel(adminUnitId.Key, entitySchemaName,
							entityRecordId, EntitySchemaRecordRightOperation.Edit, rightLevel, useDenyRecordRight,
							true);
					}
					if (canDelete) {
						dbSecurityEngine.SetEntitySchemaRecordOperationRightLevel(adminUnitId.Key, entitySchemaName,
							entityRecordId, EntitySchemaRecordRightOperation.Delete, rightLevel, useDenyRecordRight,
							true);
					}
				} catch (DbException e) {
					Log.Error($"Error while executing ChangeAdminRightsUserTask \"{Name}\" in process \"{Owner.Name}\":" +
						$" can not add rights to {adminUnitId.Value}, SysAdminUnit \"{adminUnitId.Key}\".", e);
				}
			}
		}

		public virtual List<KeyValuePair<Guid, string>> GetAdminUnitIds(Dictionary<string, object> recordRight) {
			BaseProcessSchemaElement userTask = GetSchemaElement();
			var parametersMetaInfo = (IProcessParametersMetaInfo)userTask;
			ProcessSchemaParameterCollection parameters = parametersMetaInfo.ForceGetParameters();
			var source = (ProcessSchemaParameterValueSource)(int.Parse((string)recordRight["Source"]));
			var value = (string)recordRight["Value"];
			var adminUnitIds = new List<KeyValuePair<Guid, string>>();
			var recordRightGrantee = (string)recordRight["Grantee"];
			TraceLog(uId => $"{uId} Grantee:{recordRightGrantee} Source:{source}");
			switch(recordRightGrantee) {
				case "Role":
					switch (source) {
						case ProcessSchemaParameterValueSource.Script:
							const string granteeDescription = "Role (script)";
							var parameterUId = new Guid((string)recordRight["Id"]);
							if (UseFlowEngineMode) {
								var parameterMapInfo = new ProcessParameterMapInfo(SchemaElementUId.ToString(),
									parameterUId.ToString());

								// TODO rewrite using GetParameterValue method
								var valueProvider = ((ProcessComponentSet)Owner).ParameterValueProvider;
								object parameterValue = valueProvider.GetParameterValue(parameterMapInfo);
								adminUnitIds.Add(
									new KeyValuePair<Guid, string>((Guid)parameterValue, granteeDescription));
								TraceLog(uId =>
									$"{uId} Role from script: {parameterValue} parameterUId: {parameterUId}");
							} else {
								foreach (ProcessSchemaParameter parameter in parameters ) {
									if (parameter.UId.Equals(parameterUId)) {
										adminUnitIds.Add(new KeyValuePair<Guid, string>(
											(Guid)this.GetPropertyValue(parameter.Name), granteeDescription));
										break;
									}
								}
							}
							break;
						case ProcessSchemaParameterValueSource.ConstValue:
							adminUnitIds.Add(new KeyValuePair<Guid, string>(new Guid(value), "Role (constant)"));
							break;
						case ProcessSchemaParameterValueSource.Mapping:
							object paramValue = Owner.GetParameterValueByMetaPath((string)recordRight["RuntimeValue"]);
							if (paramValue != null) {
								adminUnitIds.Add(new KeyValuePair<Guid, string>((Guid)paramValue, "Role (parameter)"));
							}
							break;
						case ProcessSchemaParameterValueSource.SystemValue:
							object systemValue = UserConnection.SystemValueManager.GetValue(UserConnection,
								new Guid(value));
							if (systemValue != null) {
								adminUnitIds.Add(
									new KeyValuePair<Guid, string>((Guid)systemValue, "Role (system value)"));
							}
							break;
						case ProcessSchemaParameterValueSource.SystemSetting:
							object systemSettings = BPMSoft.Core.Configuration.SysSettings.GetValue(UserConnection,
								value);
							if (systemSettings != null) {
								adminUnitIds.Add(
									new KeyValuePair<Guid, string>((Guid)systemSettings, "Role (system setting)"));
							}
							break;
					}
					break;
				case "Employee":
					Guid contactId = Guid.Empty;
					switch (source) {
						case ProcessSchemaParameterValueSource.Script:
						var parameterUId = new Guid((string)recordRight["Id"]);
						if (UseFlowEngineMode) {
							var parameterMapInfo = new ProcessParameterMapInfo(SchemaElementUId.ToString(),
								parameterUId.ToString());

							// TODO rewrite using GetParameterValue method
							var valueProvider = ((ProcessComponentSet)Owner).ParameterValueProvider;
							object parameterValue = valueProvider.GetParameterValue(parameterMapInfo);
							contactId = (Guid)parameterValue;
							TraceLog(uId =>
								$"{uId} Employee from script: {parameterValue} parameterUId: {parameterUId}");
						} else {
							foreach (ProcessSchemaParameter parameter in parameters) {
								if (parameter.UId == parameterUId) {
									contactId = (Guid)this.GetPropertyValue(parameter.Name);
									break;
								}
							}
						}
						break;
						case ProcessSchemaParameterValueSource.ConstValue:
							contactId = new Guid(value);
							break;
						case ProcessSchemaParameterValueSource.Mapping:
							object paramValue = Owner.GetParameterValueByMetaPath((string)recordRight["RuntimeValue"]);
							if (paramValue != null) {
								contactId = (Guid)paramValue;
							}
							break;
						case ProcessSchemaParameterValueSource.SystemValue:
							SystemValueManager systemValueManager = UserConnection.SystemValueManager;
							object systemValue = systemValueManager.GetValue(UserConnection, new Guid(value));
							if (systemValue != null) {
								contactId = (Guid)systemValue;
							}
							break;
						case ProcessSchemaParameterValueSource.SystemSetting:
							object systemSettings = BPMSoft.Core.Configuration.SysSettings
								.GetValue(UserConnection, value);
							if (systemSettings != null) {
								contactId = (Guid)systemSettings;
							}
							break;
					}
					if (contactId == Guid.Empty) {
						TraceLog(uId => $"{uId} Contact Id is empty.");
						break;
					}
					var adminUnitIdSelect = (Select)new Select(UserConnection)
							.Column("Id")
						.From("SysAdminUnit").WithHints(Hints.NoLock)
						.Where("ContactId").IsEqual(new QueryParameter(contactId));
					using (DBExecutor dbExecutor = UserConnection.EnsureDBConnection()) {
						using (IDataReader dataReader = adminUnitIdSelect.ExecuteReader(dbExecutor)) {
							if (dataReader.Read()) {
								Guid adminUnitId = UserConnection.DBTypeConverter.DBValueToGuid(dataReader[0]);
								adminUnitIds.Add(
									new KeyValuePair<Guid, string>(adminUnitId, $"Employee \"{contactId}\""));
								TraceLog(uId => $"{uId} Employee from script adminUnitId: {adminUnitId}");
							}
						}
					}
					break;
				case "DataSourceFilter":
					EntitySchemaManager entitySchemaManager = UserConnection.EntitySchemaManager;
					EntitySchema contactSchema = entitySchemaManager.FindInstanceByName("Contact");
					var entitySchemaQuery = new EntitySchemaQuery(contactSchema) {
						UseAdminRights = false
					};
					entitySchemaQuery.AddAllSchemaColumns();
					entitySchemaQuery.PrimaryQueryColumn.IsAlwaysSelect = true;
					var dataSourceFilters = (string)recordRight["Value"];
					if (!string.IsNullOrEmpty(dataSourceFilters)) {
						ProcessUserTaskUtilities.SpecifyESQFilters(UserConnection, this, contactSchema,
							entitySchemaQuery, dataSourceFilters);
					}
					EntityCollection entityCollection = entitySchemaQuery.GetEntityCollection(UserConnection);
					var contactIdParameter = new QueryParameter("ContactId", null, "Guid");
					var adminsUnitIdSelect = (Select)new Select(UserConnection)
						.Column("Id")
							.From("SysAdminUnit").WithHints(Hints.NoLock)
						.Where("ContactId").IsEqual(contactIdParameter);
					adminsUnitIdSelect.InitializeParameters();
					foreach (Entity entity in entityCollection) {
						contactIdParameter.Value = entity.PrimaryColumnValue;
						using (DBExecutor dbExecutor = UserConnection.EnsureDBConnection()) {
							using (IDataReader dataReader = adminsUnitIdSelect.ExecuteReader(dbExecutor)) {
								if (dataReader.Read()) {
									Guid adminUnitId = UserConnection.DBTypeConverter.DBValueToGuid(dataReader[0]);
									adminUnitIds.Add(new KeyValuePair<Guid, string>(adminUnitId,
										$"Selected employees {(Guid)contactIdParameter.Value}"));
									TraceLog(uId => $"{uId} Employee from script adminUnitId: " +
										"{adminUnitId} contact Id: {contactIdParameter}");
								} else {
									TraceLog(uId =>
										$"{uId} Not found admin unit for contact Id: {entity.PrimaryColumnValue}");
								}
							}
						}
					}
					break;
			}
			return adminUnitIds;
		}

		#endregion

	}

	#endregion

}
