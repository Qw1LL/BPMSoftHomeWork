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

	#region Class: SetDuplicateCheckedStatus

	[DesignModeProperty(Name = "SchemaId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "a1d98c566dd14621863504fcdfb8f792", CaptionResourceItem = "Parameters.SchemaId.Caption", DescriptionResourceItem = "Parameters.SchemaId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Data", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "a1d98c566dd14621863504fcdfb8f792", CaptionResourceItem = "Parameters.Data.Caption", DescriptionResourceItem = "Parameters.Data.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "RecordId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "a1d98c566dd14621863504fcdfb8f792", CaptionResourceItem = "Parameters.RecordId.Caption", DescriptionResourceItem = "Parameters.RecordId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "DuplicateSchemaName", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "a1d98c566dd14621863504fcdfb8f792", CaptionResourceItem = "Parameters.DuplicateSchemaName.Caption", DescriptionResourceItem = "Parameters.DuplicateSchemaName.Caption", UseSolutionStorage = true)]
	/// <exclude/>
	public class SetDuplicateCheckedStatus : ProcessUserTask
	{

		#region Constructors: Public

		public SetDuplicateCheckedStatus(UserConnection userConnection)
			: base(userConnection) {
			SchemaUId = new Guid("a1d98c56-6dd1-4621-8635-04fcdfb8f792");
		}

		#endregion

		#region Properties: Public

		public virtual Guid SchemaId {
			get;
			set;
		}

		public virtual Object Data {
			get;
			set;
		}

		public virtual Guid RecordId {
			get;
			set;
		}

		public virtual string DuplicateSchemaName {
			get;
			set;
		}

		#endregion

		#region Methods: Protected

		protected override bool InternalExecute(ProcessExecutingContext context) {
			Guid duplicateSchemaId = Guid.Empty;
			Guid contactSchemaId = new Guid("16BE3651-8FE2-4159-8DD0-A803D4683DD3");
			Guid accountSchemaId = new Guid("25D7C1AB-1DE0-4501-B402-02E0E5A72D6E");
			Guid notDuplicateStatus = new Guid("00401284-F36B-1410-918D-20CF308CCED1");
			if (SchemaId == contactSchemaId) {
				duplicateSchemaId = new Guid("AFD8D870-9C6A-4482-B90E-53682AED6618");
			} else if (SchemaId == accountSchemaId) {
				duplicateSchemaId = new Guid("A477264B-2D69-48B7-9268-E9B4D39EBF83");
			} else {
				return true;
			}
			var duplicateSchema = UserConnection.EntitySchemaManager.GetInstanceByUId(duplicateSchemaId);
			DuplicateSchemaName = duplicateSchema.Name;
			var duplicates = Data as List<Guid>;
			foreach (var duplicateId in duplicates) {
				if (IsAlreadyExcluded(duplicateId)) {
					continue;
				}
				Insert insert = new Insert(UserConnection).Into(DuplicateSchemaName);
				insert.Set("StatusOfDuplicateId", Column.Parameter(notDuplicateStatus));
				insert.Set("Entity1Id", Column.Parameter(RecordId));
				insert.Set("Entity2Id", Column.Parameter(duplicateId));
				insert.Execute();
			}
			return true;
		}

		#endregion

		#region Methods: Public

		public override bool CompleteExecuting(params object[] parameters) {
			return base.CompleteExecuting(parameters);
		}

		public virtual bool IsAlreadyExcluded(Guid duplicateId) {
			int result = 0;
			Select select = new Select(UserConnection)
								.Column(Func.Count("Id")).As("IdCount")					
								.From(DuplicateSchemaName)
									.Where().
									OpenBlock("Entity1Id")
										.IsEqual(Column.Parameter(RecordId))
										.And("Entity2Id")
										.IsEqual(Column.Parameter(duplicateId))
									.CloseBlock()
									.Or()
									.OpenBlock("Entity1Id")
										.IsEqual(Column.Parameter(duplicateId))
										.And("Entity2Id")
										.IsEqual(Column.Parameter(RecordId))
									.CloseBlock() as Select;
			using (var dbExecutor = UserConnection.EnsureDBConnection()) {
				result = select.ExecuteScalar<int>(dbExecutor);	
			}
			return result > 0;
		}

		public override void WritePropertiesData(DataWriter writer) {
			writer.WriteStartObject(Name);
			base.WritePropertiesData(writer);
			if (Status == Core.Process.ProcessStatus.Inactive) {
				writer.WriteFinishObject();
				return;
			}
			if (!HasMapping("SchemaId")) {
				writer.WriteValue("SchemaId", SchemaId, Guid.Empty);
			}
			if (Data != null) {
				if (Data.GetType().IsSerializable || Data.GetType().GetInterface("ISerializable") != null) {
					writer.WriteSerializableObjectValue("Data", Data, null);
				}
			}
			if (!HasMapping("RecordId")) {
				writer.WriteValue("RecordId", RecordId, Guid.Empty);
			}
			if (!HasMapping("DuplicateSchemaName")) {
				writer.WriteValue("DuplicateSchemaName", DuplicateSchemaName, null);
			}
			writer.WriteFinishObject();
		}

		#endregion

		#region Methods: Protected

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			switch (reader.CurrentName) {
				case "SchemaId":
					SchemaId = reader.GetGuidValue();
				break;
				case "Data":
					Data = reader.GetSerializableObjectValue();
				break;
				case "RecordId":
					RecordId = reader.GetGuidValue();
				break;
				case "DuplicateSchemaName":
					DuplicateSchemaName = reader.GetStringValue();
				break;
			}
		}

		#endregion

	}

	#endregion

}

