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

	#region Class: CheckRecordReadRightsUserTask

	[DesignModeProperty(Name = "EntitySchemaName", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "6ac0d57d73a64bdf919c0f8ff020c9fd", CaptionResourceItem = "Parameters.EntitySchemaName.Caption", DescriptionResourceItem = "Parameters.EntitySchemaName.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "RecordId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "6ac0d57d73a64bdf919c0f8ff020c9fd", CaptionResourceItem = "Parameters.RecordId.Caption", DescriptionResourceItem = "Parameters.RecordId.Caption", UseSolutionStorage = true)]
	/// <exclude/>
	public partial class CheckRecordReadRightsUserTask : ProcessUserTask
	{

		#region Constructors: Public

		public CheckRecordReadRightsUserTask(UserConnection userConnection)
			: base(userConnection) {
			SchemaUId = new Guid("6ac0d57d-73a6-4bdf-919c-0f8ff020c9fd");
		}

		#endregion

		#region Properties: Public

		public virtual string EntitySchemaName {
			get;
			set;
		}

		public virtual Guid RecordId {
			get;
			set;
		}

		#endregion

		#region Methods: Public

		public override void WritePropertiesData(DataWriter writer) {
			writer.WriteStartObject(Name);
			base.WritePropertiesData(writer);
			if (Status == Core.Process.ProcessStatus.Inactive) {
				writer.WriteFinishObject();
				return;
			}
			if (UseFlowEngineMode) {
				if (!HasMapping("EntitySchemaName")) {
					writer.WriteValue("EntitySchemaName", EntitySchemaName, null);
				}
			}
			if (UseFlowEngineMode) {
				if (!HasMapping("RecordId")) {
					writer.WriteValue("RecordId", RecordId, Guid.Empty);
				}
			}
			writer.WriteFinishObject();
		}

		#endregion

		#region Methods: Protected

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			switch (reader.CurrentName) {
				case "EntitySchemaName":
					if (!UseFlowEngineMode) {
						break;
					}
					EntitySchemaName = reader.GetStringValue();
				break;
				case "RecordId":
					if (!UseFlowEngineMode) {
						break;
					}
					RecordId = reader.GetGuidValue();
				break;
			}
		}

		#endregion

	}

	#endregion

}

