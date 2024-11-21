namespace BPMSoft.Core.Process.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Process;
	using BPMSoft.UI.WebControls.Controls;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: GetIsProcessLinkedToEntityUserTaskSchemaExtension

	/// <exclude/>
	public class GetIsProcessLinkedToEntityUserTaskSchemaExtension : ProcessUserTaskSchemaExtension
	{

		#region Methods: Public

		public override Dictionary<Guid, string> GetResultParameterAllValues(UserConnection userConnection, ProcessSchemaUserTask schemaUserTask) {
			var esq = new EntitySchemaQuery(userConnection.EntitySchemaManager, "SysProcessStatus");
			esq.AddAllSchemaColumns();
			EntityCollection rows = esq.GetEntityCollection(userConnection);
			var resultParameterAllValues = new Dictionary<Guid, string>();
			foreach (var row in rows) {
				resultParameterAllValues[row.PrimaryColumnValue] = row.PrimaryDisplayColumnValue;
			}
			return resultParameterAllValues;
		}

		#endregion

	}

	#endregion

	#region Class: GetIsProcessLinkedToEntityUserTask

	[DesignModeProperty(Name = "EntitySchemaId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "922701f4cd044753acb8d8a0e37f6ad3", CaptionResourceItem = "Parameters.EntitySchemaId.Caption", DescriptionResourceItem = "Parameters.EntitySchemaId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "RecordId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "922701f4cd044753acb8d8a0e37f6ad3", CaptionResourceItem = "Parameters.RecordId.Caption", DescriptionResourceItem = "Parameters.RecordId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ProcessStatusId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "922701f4cd044753acb8d8a0e37f6ad3", CaptionResourceItem = "Parameters.ProcessStatusId.Caption", DescriptionResourceItem = "Parameters.ProcessStatusId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Result", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "922701f4cd044753acb8d8a0e37f6ad3", CaptionResourceItem = "Parameters.Result.Caption", DescriptionResourceItem = "Parameters.Result.Caption", UseSolutionStorage = true)]
	/// <exclude/>
	public class GetIsProcessLinkedToEntityUserTask : ProcessUserTask
	{

		#region Constructors: Public

		public GetIsProcessLinkedToEntityUserTask(UserConnection userConnection)
			: base(userConnection) {
			SchemaUId = new Guid("922701f4-cd04-4753-acb8-d8a0e37f6ad3");
		}

		#endregion

		#region Properties: Public

		public virtual Guid EntitySchemaId {
			get;
			set;
		}

		public virtual Guid RecordId {
			get;
			set;
		}

		public virtual Guid ProcessStatusId {
			get;
			set;
		}

		public virtual bool Result {
			get;
			set;
		}

		#endregion

		#region Methods: Protected

		protected override bool InternalExecute(ProcessExecutingContext context) {
			var schema = UserConnection.EntitySchemaManager.FindItemByUId(EntitySchemaId);
			var schemaUId = (schema != null) ? schema.UId : ((Select)
				new Select(UserConnection).Column("UId").From("SysSchema").Where("Id").IsEqual(Column.Parameter(EntitySchemaId)))
				.ExecuteScalar<Guid>();
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "SysProcessLog");
			esq.AddColumn(esq.RootSchema.PrimaryColumn.Name);
			esq.RowCount = 1;
			var filters = new EntitySchemaQueryFilterCollection(esq);
			var entitySchemaFilter = esq.CreateFilterWithParameters(FilterComparisonType.Equal,
				"[SysProcessEntity:SysProcess].EntitySchemaUId", schemaUId);
			filters.Add(entitySchemaFilter);
			var entityFilter = esq.CreateFilterWithParameters(FilterComparisonType.Equal,
				"[SysProcessEntity:SysProcess].EntityId", RecordId);
			filters.Add(entityFilter);
			var processFilter = esq.CreateFilterWithParameters(FilterComparisonType.Equal,
				"[SysSchema:Id:SysSchema].UId", Owner.SchemaUId);
			filters.Add(processFilter);
			if (ProcessStatusId != Guid.Empty) {
			var processStatusFilter = esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Status", ProcessStatusId);
				filters.Add(processStatusFilter);
			}
			filters.LogicalOperation = LogicalOperationStrict.And;
			esq.Filters.Add(filters);
			var rows = esq.GetEntityCollection(UserConnection);
			Result = rows.Count > 0;
			return true;
		}

		#endregion

		#region Methods: Public

		public override bool CompleteExecuting(params object[] parameters) {
			return base.CompleteExecuting(parameters);
		}

		public override void CancelExecuting(params object[] parameters) {
			base.CancelExecuting(parameters);
		}

		public override string GetExecutionData() {
			return string.Empty;
		}

		public override void WritePropertiesData(DataWriter writer) {
			writer.WriteStartObject(Name);
			base.WritePropertiesData(writer);
			if (Status == Core.Process.ProcessStatus.Inactive) {
				writer.WriteFinishObject();
				return;
			}
			if (!HasMapping("EntitySchemaId")) {
				writer.WriteValue("EntitySchemaId", EntitySchemaId, Guid.Empty);
			}
			if (!HasMapping("RecordId")) {
				writer.WriteValue("RecordId", RecordId, Guid.Empty);
			}
			if (!HasMapping("ProcessStatusId")) {
				writer.WriteValue("ProcessStatusId", ProcessStatusId, Guid.Empty);
			}
			if (!HasMapping("Result")) {
				writer.WriteValue("Result", Result, false);
			}
			writer.WriteFinishObject();
		}

		#endregion

		#region Methods: Protected

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			switch (reader.CurrentName) {
				case "EntitySchemaId":
					EntitySchemaId = reader.GetGuidValue();
				break;
				case "RecordId":
					RecordId = reader.GetGuidValue();
				break;
				case "ProcessStatusId":
					ProcessStatusId = reader.GetGuidValue();
				break;
				case "Result":
					Result = reader.GetBoolValue();
				break;
			}
		}

		#endregion

	}

	#endregion

}

