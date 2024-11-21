namespace BPMSoft.Core.Process.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Configuration;
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

	#region Class: DeleteDataUserTask

	[DesignModeGroup(Name = "Общие", Position = 1, UseSolutionStorage = true, ResourceManager = "40f4a8f2edca432da5ea03e8577b4691", CaptionResourceItem = "Parameters.EntitySchemaId.Group", DescriptionResourceItem = "Parameters.EntitySchemaId.Group")]
	[DesignModeProperty(Name = "EntitySchemaId", Group = "Общие", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "40f4a8f2edca432da5ea03e8577b4691", CaptionResourceItem = "Parameters.EntitySchemaId.Caption", DescriptionResourceItem = "Parameters.EntitySchemaId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "DataSourceFilters", Group = "Общие", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "40f4a8f2edca432da5ea03e8577b4691", CaptionResourceItem = "Parameters.DataSourceFilters.Caption", DescriptionResourceItem = "Parameters.DataSourceFilters.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "IsMatchConditions", Group = "Общие", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "40f4a8f2edca432da5ea03e8577b4691", CaptionResourceItem = "Parameters.IsMatchConditions.Caption", DescriptionResourceItem = "Parameters.IsMatchConditions.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ConsiderTimeInFilter", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "40f4a8f2edca432da5ea03e8577b4691", CaptionResourceItem = "Parameters.ConsiderTimeInFilter.Caption", DescriptionResourceItem = "Parameters.ConsiderTimeInFilter.Caption", UseSolutionStorage = true)]
	/// <exclude/>
	public partial class DeleteDataUserTask : ProcessUserTask
	{

		#region Constructors: Public

		public DeleteDataUserTask(UserConnection userConnection)
			: base(userConnection) {
			SchemaUId = new Guid("40f4a8f2-edca-432d-a5ea-03e8577b4691");
			_considerTimeInFilter = () => { return true; };
		}

		#endregion

		#region Properties: Public

		public virtual Guid EntitySchemaId {
			get;
			set;
		}

		public virtual string DataSourceFilters {
			get;
			set;
		}

		public virtual bool IsMatchConditions {
			get;
			set;
		}

		private Func<bool> _considerTimeInFilter;
		public virtual bool ConsiderTimeInFilter {
			get {
				return (_considerTimeInFilter ?? (_considerTimeInFilter = () => false)).Invoke();
			}
			set {
				_considerTimeInFilter = () => { return value; };
			}
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
			if (!HasMapping("EntitySchemaId")) {
				writer.WriteValue("EntitySchemaId", EntitySchemaId, Guid.Empty);
			}
			if (!HasMapping("DataSourceFilters")) {
				writer.WriteValue("DataSourceFilters", DataSourceFilters, null);
			}
			if (!HasMapping("IsMatchConditions")) {
				writer.WriteValue("IsMatchConditions", IsMatchConditions, false);
			}
			if (!HasMapping("ConsiderTimeInFilter")) {
				writer.WriteValue("ConsiderTimeInFilter", ConsiderTimeInFilter, false);
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
				case "DataSourceFilters":
					DataSourceFilters = reader.GetStringValue();
				break;
				case "IsMatchConditions":
					IsMatchConditions = reader.GetBoolValue();
				break;
				case "ConsiderTimeInFilter":
					ConsiderTimeInFilter = reader.GetBoolValue();
				break;
			}
		}

		#endregion

	}

	#endregion

}

