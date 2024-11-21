namespace BPMSoft.Core.Process.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Configuration;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Process;
	using BPMSoft.UI.WebControls.Controls;
	using BPMSoft.UI.WebControls.Utilities.Json.Converters;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: AddDataUserTask

	[DesignModeGroup(Name = "Общие", Position = 1, UseSolutionStorage = true, ResourceManager = "db6abed10c5f455b80532665378cdb71", CaptionResourceItem = "Parameters.EntitySchemaId.Group", DescriptionResourceItem = "Parameters.EntitySchemaId.Group")]
	[DesignModeProperty(Name = "EntitySchemaId", Group = "Общие", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "db6abed10c5f455b80532665378cdb71", CaptionResourceItem = "Parameters.EntitySchemaId.Caption", DescriptionResourceItem = "Parameters.EntitySchemaId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "DataSourceFilters", Group = "Общие", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "db6abed10c5f455b80532665378cdb71", CaptionResourceItem = "Parameters.DataSourceFilters.Caption", DescriptionResourceItem = "Parameters.DataSourceFilters.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "RecordAddMode", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "db6abed10c5f455b80532665378cdb71", CaptionResourceItem = "Parameters.RecordAddMode.Caption", DescriptionResourceItem = "Parameters.RecordAddMode.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "FilterEntitySchemaId", Group = "Общие", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "db6abed10c5f455b80532665378cdb71", CaptionResourceItem = "Parameters.FilterEntitySchemaId.Caption", DescriptionResourceItem = "Parameters.FilterEntitySchemaId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "RecordDefValues", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "db6abed10c5f455b80532665378cdb71", CaptionResourceItem = "Parameters.RecordDefValues.Caption", DescriptionResourceItem = "Parameters.RecordDefValues.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "RecordId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "db6abed10c5f455b80532665378cdb71", CaptionResourceItem = "Parameters.RecordId.Caption", DescriptionResourceItem = "Parameters.RecordId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ConsiderTimeInFilter", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "db6abed10c5f455b80532665378cdb71", CaptionResourceItem = "Parameters.ConsiderTimeInFilter.Caption", DescriptionResourceItem = "Parameters.ConsiderTimeInFilter.Caption", UseSolutionStorage = true)]
	/// <exclude/>
	public partial class AddDataUserTask : ProcessUserTask
	{

		#region Constructors: Public

		public AddDataUserTask(UserConnection userConnection)
			: base(userConnection) {
			SchemaUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71");
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

		public virtual string RecordAddMode {
			get;
			set;
		}

		public virtual Guid FilterEntitySchemaId {
			get;
			set;
		}

		private EntityColumnMappingValues _recordDefValues;
		public virtual EntityColumnMappingValues RecordDefValues {
			get {
				return _recordDefValues ?? ( _recordDefValues = new EntityColumnMappingValues (
					new Dictionary<string, object>(),
					new Dictionary<string, string>()));
			}
			set {
				_recordDefValues = value;
			}
		}

		public virtual Guid RecordId {
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

		private LocalizableString _invalidRightExpressionParameterValueException;
		public LocalizableString InvalidRightExpressionParameterValueException {
			get {
				return _invalidRightExpressionParameterValueException ?? (_invalidRightExpressionParameterValueException = new LocalizableString(Storage, Schema.GetResourceManagerName(), "LocalizableStrings.InvalidRightExpressionParameterValueException.Value"));
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
			if (!HasMapping("RecordAddMode")) {
				writer.WriteValue("RecordAddMode", RecordAddMode, null);
			}
			if (!HasMapping("FilterEntitySchemaId")) {
				writer.WriteValue("FilterEntitySchemaId", FilterEntitySchemaId, Guid.Empty);
			}
			if (!HasMapping("RecordId")) {
				writer.WriteValue("RecordId", RecordId, Guid.Empty);
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
				case "RecordAddMode":
					RecordAddMode = reader.GetStringValue();
				break;
				case "FilterEntitySchemaId":
					FilterEntitySchemaId = reader.GetGuidValue();
				break;
				case "RecordDefValues":
					if (UseFlowEngineMode) {
						RecordDefValues = reader.GetValue<EntityColumnMappingValues>();
					}
				break;
				case "RecordId":
					RecordId = reader.GetGuidValue();
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

