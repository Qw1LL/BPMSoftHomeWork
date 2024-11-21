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

	#region Class: ChangeDataUserTask

	[DesignModeProperty(Name = "EntitySchemaUId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "d3021ca774504678a117060171eb2976", CaptionResourceItem = "Parameters.EntitySchemaUId.Caption", DescriptionResourceItem = "Parameters.EntitySchemaUId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "IsMatchConditions", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "d3021ca774504678a117060171eb2976", CaptionResourceItem = "Parameters.IsMatchConditions.Caption", DescriptionResourceItem = "Parameters.IsMatchConditions.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "DataSourceFilters", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "d3021ca774504678a117060171eb2976", CaptionResourceItem = "Parameters.DataSourceFilters.Caption", DescriptionResourceItem = "Parameters.DataSourceFilters.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "RecordColumnValues", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "d3021ca774504678a117060171eb2976", CaptionResourceItem = "Parameters.RecordColumnValues.Caption", DescriptionResourceItem = "Parameters.RecordColumnValues.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ConsiderTimeInFilter", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "d3021ca774504678a117060171eb2976", CaptionResourceItem = "Parameters.ConsiderTimeInFilter.Caption", DescriptionResourceItem = "Parameters.ConsiderTimeInFilter.Caption", UseSolutionStorage = true)]
	/// <exclude/>
	public partial class ChangeDataUserTask : ProcessUserTask
	{

		#region Constructors: Public

		public ChangeDataUserTask(UserConnection userConnection)
			: base(userConnection) {
			SchemaUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976");
			_isMatchConditions = () => { return true; };
			_considerTimeInFilter = () => { return true; };
		}

		#endregion

		#region Properties: Public

		public virtual Guid EntitySchemaUId {
			get;
			set;
		}

		private Func<bool> _isMatchConditions;
		public virtual bool IsMatchConditions {
			get {
				return (_isMatchConditions ?? (_isMatchConditions = () => false)).Invoke();
			}
			set {
				_isMatchConditions = () => { return value; };
			}
		}

		public virtual string DataSourceFilters {
			get;
			set;
		}

		private EntityColumnMappingValues _recordColumnValues;
		public virtual EntityColumnMappingValues RecordColumnValues {
			get {
				return _recordColumnValues ?? ( _recordColumnValues = new EntityColumnMappingValues (
					new Dictionary<string, object>(),
					new Dictionary<string, string>()));
			}
			set {
				_recordColumnValues = value;
			}
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
			if (!HasMapping("EntitySchemaUId")) {
				writer.WriteValue("EntitySchemaUId", EntitySchemaUId, Guid.Empty);
			}
			if (!HasMapping("IsMatchConditions")) {
				writer.WriteValue("IsMatchConditions", IsMatchConditions, false);
			}
			if (!HasMapping("DataSourceFilters")) {
				writer.WriteValue("DataSourceFilters", DataSourceFilters, null);
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
				case "EntitySchemaUId":
					EntitySchemaUId = reader.GetGuidValue();
				break;
				case "IsMatchConditions":
					IsMatchConditions = reader.GetBoolValue();
				break;
				case "DataSourceFilters":
					DataSourceFilters = reader.GetStringValue();
				break;
				case "RecordColumnValues":
					if (UseFlowEngineMode) {
						RecordColumnValues = reader.GetValue<EntityColumnMappingValues>();
					}
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

