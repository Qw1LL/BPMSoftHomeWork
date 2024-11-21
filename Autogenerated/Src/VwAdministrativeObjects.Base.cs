namespace BPMSoft.Configuration
{

	using DataContract = BPMSoft.Nui.ServiceModel.DataContract;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Data;
	using System.Drawing;
	using System.Globalization;
	using System.IO;
	using System.Linq;
	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.DcmProcess;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;
	using BPMSoft.Core.OperationLog;
	using BPMSoft.Core.Packages;
	using BPMSoft.Core.Process;
	using BPMSoft.Core.Process.Configuration;
	using BPMSoft.GlobalSearch.Indexing;
	using BPMSoft.UI.WebControls.Controls;
	using BPMSoft.UI.WebControls.Utilities.Json.Converters;

	#region Class: VwAdministrativeObjects_BaseEventsProcess

	public partial class VwAdministrativeObjects_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		public virtual void AddRightsForColumns(Guid SysSchemaUId) {
			var entitySchemaManager = UserConnection.EntitySchemaManager;
			var schema = entitySchemaManager.GetInstanceByUId(SysSchemaUId) as EntitySchema;
			
			QueryParameter schemaIdParameter = new QueryParameter("SchemaUId", SysSchemaUId);
			QueryParameter subjectColumnUIdParameter = new QueryParameter("SubjectColumnUId", null);
			QueryParameter idParameter = new QueryParameter("Id", null);
			var defaultAdminUnitId = Guid.Empty;
			var defaultAdminUnitName = string.Empty;
			var adminUnit = GetRootAdminUnitRecordId();
			if (adminUnit != null) {
				defaultAdminUnitId = adminUnit.Item1;
				defaultAdminUnitName = adminUnit.Item2;
			}
			var defaultRightLevelId = new Guid("007F04EE-1FE1-DF11-971B-001D60E938C6");
			var defaultPosition = 0;
			Select conditionSelect = new Select(UserConnection).From("VwSysEntitySchemaColumnRight").
										Column("Id").
									Where("SubjectColumnUId").IsEqual(subjectColumnUIdParameter).
										And("SubjectSchemaUId").IsEqual(schemaIdParameter) as Select;
			Select select = new Select(UserConnection).Top(1).From("SysOneRecord").
								Column(idParameter).As("Id").
								Column(Column.Parameter(defaultAdminUnitId)).As("SysAdminUnitId").
								Column(Column.Const(defaultRightLevelId)).As("RightLevelId").
								Column(Column.Const(defaultPosition)).As("Position").
								Column(subjectColumnUIdParameter).As("SubjectColumnUId").
								Column(schemaIdParameter).As("SubjectSchemaUId").
							Where().Not().Exists(conditionSelect) as Select;
			InsertSelect insert = new InsertSelect(UserConnection).Into("VwSysEntitySchemaColumnRight").
										Set("Id", "SysAdminUnitId", "RightLevelId", "Position", "SubjectColumnUId", "SubjectSchemaUId").
								FromSelect(select)
			as InsertSelect;
			foreach (var column in schema.Columns) {
				subjectColumnUIdParameter.Value = column.UId;
				idParameter.Value = Guid.NewGuid();
				insert.Execute();
				OperationLogger.Instance.LogEntitySchemaColumnRightEdit(UserConnection, defaultAdminUnitName, schema.UId, column.UId, defaultRightLevelId, defaultPosition);
			}
			return;
		}

		public virtual Tuple<Guid, string> GetRootAdminUnitRecordId() {
			Select select =
				new Select(UserConnection).Top(1)
					.Column("Id")
					.Column("Name")
				.From("SysAdminUnit")
				.Where("SysAdminUnitTypeValue").IsEqual(Column.Parameter(0))
					.And("ConnectionType").IsEqual(Column.Parameter(UserType.General))
					.And("ParentRoleId").IsNull() as Select;
			Tuple<Guid, string> result = null;
			select.ExecuteReader((IDataReader dr) => {
				result = new Tuple<Guid, string>(
					UserConnection.DBTypeConverter.DBValueToGuid(dr["Id"]),
					dr.GetColumnValue<string>("Name"));
			});
			return result;
		}

		public virtual void AddRightsForOperations(Guid schemaUId) {
			QueryParameter schemaIdParameter = new QueryParameter("SchemaUId", schemaUId);
			QueryParameter canReadParameter = new QueryParameter("CanRead", true);
			QueryParameter canAppendParameter = new QueryParameter("CanAppend", true);
			QueryParameter canEditParameter = new QueryParameter("CanEdit", true);
			QueryParameter canDeleteParameter = new QueryParameter("CanDelete", true);
			QueryParameter idParameter = new QueryParameter("Id", Guid.NewGuid());
			var defaultAdminUnitId = Guid.Empty;
			var defaultAdminUnitName = string.Empty;
			var adminUnit = GetRootAdminUnitRecordId();
			if (adminUnit != null) {
				defaultAdminUnitId = adminUnit.Item1;
				defaultAdminUnitName = adminUnit.Item2;
			}
			var defaultPosition = 0;
			Select conditionSelect = new Select(UserConnection).From("SysEntitySchemaOperationRight").
										Column("Id").
									Where("SubjectSchemaUId").IsEqual(schemaIdParameter) as Select;
			Select select = new Select(UserConnection).Top(1).From("SysEntitySchemaOperationRight").
								Column(idParameter).As("Id").
								Column(Column.Parameter(defaultAdminUnitId)).As("SysAdminUnitId").
								Column(Column.Const(defaultPosition)).As("Position").
								Column(schemaIdParameter).As("SubjectSchemUId").
								Column(canReadParameter).As("CanRead").
								Column(canEditParameter).As("CanEdit").
								Column(canAppendParameter).As("CanAppend").
								Column(canDeleteParameter).As("CanDelete").
							Where().Not().Exists(conditionSelect) as Select;
			InsertSelect insert = new InsertSelect(UserConnection).Into("SysEntitySchemaOperationRight").
										Set("Id", "SysAdminUnitId", "Position", "SubjectSchemaUId", 
										"CanRead", "CanEdit", "CanAppend", "CanDelete").
								FromSelect(select) as InsertSelect;
			insert.Execute();
			return;
		}

		public virtual void CreateRightRecordsSchema(Guid entitySchemaId) {
			var schemaManager = UserConnection.GetSchemaManager("EntitySchemaManager") as EntitySchemaManager;
			var schema = schemaManager.FindInstanceByUId(entitySchemaId);
			if (schema == null) {
				return;
			}
			if (!UserConnection.DBSecurityEngine.GetIsEntitySchemaAdministratedByRecords(schema)) {
				UserConnection.DBSecurityEngine.SetEntitySchemaAdministratedByRecords(schema, true);
			}
			var rightsSchema = UserConnection.DBSecurityEngine.GetRecordRightsSchema(schema);
			EntitySchemaColumn hierarchyColumn = schema.HierarchyColumn;
			if (hierarchyColumn != null && hierarchyColumn.ReferenceSchemaUId.IsEmpty()) {
				hierarchyColumn.ReferenceSchema = schema;
				schema.Columns.FindByName(hierarchyColumn.Name).ReferenceSchema = schema;
			}
			if (UserConnection.DBMetaScript.GetIsEntitySchemaExist(rightsSchema.Name)) {
				return;
			}
			DBMetaActionCollection actions = new DBMetaActionCollection(UserConnection);
			UserConnection.DBMetaScript.AddEntitySchemaSavingActions(actions, rightsSchema);
			actions.SpreadAndSort();
			foreach (var item in actions) {
				BaseGroupAction groupAction = item as BaseGroupAction;
				if (groupAction != null) {
					SetGroupActionsDefaultValues(groupAction);
				}
			}
			DBMetaScript dbMetaScript = UserConnection.DBMetaScript;
			dbMetaScript.ExecuteActions(actions);
		}

		public virtual void SetGroupActionsDefaultValues(BaseGroupAction groupAction) {
			foreach (var item in groupAction.Actions) {
				SetColumnValueAction setValueAction = item as SetColumnValueAction;
				if (setValueAction != null) {
					setValueAction.Value = setValueAction.EntitySchemaColumn.DataValueType.DefValue;
				}
				BaseGroupAction _groupAction = item as BaseGroupAction;
				if (_groupAction != null) {
					SetGroupActionsDefaultValues(_groupAction);
				}
			}
		}

		public virtual void SetIsTrackChangesInDB(bool value, EntitySchema schema) {
		}

		public override void CheckCanManageLookups() {
		}

		#endregion

	}

	#endregion

}

