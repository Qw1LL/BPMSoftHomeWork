namespace BPMSoft.Core.Process.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Configuration.OpportunityManagement;
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

	#region Class: StartOpportunityManagementProcessUserTask

	[DesignModeProperty(Name = "ProcessSchemaUId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "c5d7981de1a342e493e7ced58a337bba", CaptionResourceItem = "Parameters.ProcessSchemaUId.Caption", DescriptionResourceItem = "Parameters.ProcessSchemaUId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "OpportunityId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "c5d7981de1a342e493e7ced58a337bba", CaptionResourceItem = "Parameters.OpportunityId.Caption", DescriptionResourceItem = "Parameters.OpportunityId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "CustomPropertyValues", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "c5d7981de1a342e493e7ced58a337bba", CaptionResourceItem = "Parameters.CustomPropertyValues.Caption", DescriptionResourceItem = "Parameters.CustomPropertyValues.Caption", UseSolutionStorage = true)]
	/// <exclude/>
	public partial class StartOpportunityManagementProcessUserTask : ProcessUserTask
	{

		#region Constructors: Public

		public StartOpportunityManagementProcessUserTask(UserConnection userConnection)
			: base(userConnection) {
			SchemaUId = new Guid("c5d7981d-e1a3-42e4-93e7-ced58a337bba");
		}

		#endregion

		#region Properties: Public

		public virtual Guid ProcessSchemaUId {
			get;
			set;
		}

		public virtual Guid OpportunityId {
			get;
			set;
		}

		public virtual string CustomPropertyValues {
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
			if (!HasMapping("ProcessSchemaUId")) {
				writer.WriteValue("ProcessSchemaUId", ProcessSchemaUId, Guid.Empty);
			}
			if (!HasMapping("OpportunityId")) {
				writer.WriteValue("OpportunityId", OpportunityId, Guid.Empty);
			}
			if (!HasMapping("CustomPropertyValues")) {
				writer.WriteValue("CustomPropertyValues", CustomPropertyValues, null);
			}
			writer.WriteFinishObject();
		}

		#endregion

		#region Methods: Protected

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			switch (reader.CurrentName) {
				case "ProcessSchemaUId":
					ProcessSchemaUId = reader.GetGuidValue();
				break;
				case "OpportunityId":
					OpportunityId = reader.GetGuidValue();
				break;
				case "CustomPropertyValues":
					CustomPropertyValues = reader.GetStringValue();
				break;
			}
		}

		#endregion

	}

	#endregion

}

