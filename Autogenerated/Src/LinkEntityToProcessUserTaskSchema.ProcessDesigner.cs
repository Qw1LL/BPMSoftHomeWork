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
	using System.Data;
	using System.Globalization;

	#region Class: LinkEntityToProcessUserTask

	[DesignModeGroup(Name = "Общие", Position = 1, UseSolutionStorage = true, ResourceManager = "fcace79b610349928a1f8e443114321a", CaptionResourceItem = "Parameters.EntityId.Group", DescriptionResourceItem = "Parameters.EntityId.Group")]
	[DesignModeProperty(Name = "EntityId", Group = "Общие", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "fcace79b610349928a1f8e443114321a", CaptionResourceItem = "Parameters.EntityId.Caption", DescriptionResourceItem = "Parameters.EntityId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "EntitySchemaId", Group = "Общие", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "fcace79b610349928a1f8e443114321a", CaptionResourceItem = "Parameters.EntitySchemaId.Caption", DescriptionResourceItem = "Parameters.EntitySchemaId.Caption", UseSolutionStorage = true)]
	/// <exclude/>
	public partial class LinkEntityToProcessUserTask : ProcessUserTask
	{

		#region Constructors: Public

		public LinkEntityToProcessUserTask(UserConnection userConnection)
			: base(userConnection) {
			SchemaUId = new Guid("fcace79b-6103-4992-8a1f-8e443114321a");
		}

		#endregion

		#region Properties: Public

		public virtual Guid EntityId {
			get;
			set;
		}

		public virtual Guid EntitySchemaId {
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
				if (!HasMapping("EntityId")) {
					writer.WriteValue("EntityId", EntityId, Guid.Empty);
				}
			}
			if (UseFlowEngineMode) {
				if (!HasMapping("EntitySchemaId")) {
					writer.WriteValue("EntitySchemaId", EntitySchemaId, Guid.Empty);
				}
			}
			writer.WriteFinishObject();
		}

		#endregion

		#region Methods: Protected

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			switch (reader.CurrentName) {
				case "EntityId":
					if (!UseFlowEngineMode) {
						break;
					}
					EntityId = reader.GetGuidValue();
				break;
				case "EntitySchemaId":
					if (!UseFlowEngineMode) {
						break;
					}
					EntitySchemaId = reader.GetGuidValue();
				break;
			}
		}

		#endregion

	}

	#endregion

}

