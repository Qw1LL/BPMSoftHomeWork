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
	using System.Linq;

	#region Class: ReadDataUserTask

	[DesignModeProperty(Name = "DataSourceFilters", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "cb455b6f78ff4b1eb241c2bbc0b37e9f", CaptionResourceItem = "Parameters.DataSourceFilters.Caption", DescriptionResourceItem = "Parameters.DataSourceFilters.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ResultType", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "cb455b6f78ff4b1eb241c2bbc0b37e9f", CaptionResourceItem = "Parameters.ResultType.Caption", DescriptionResourceItem = "Parameters.ResultType.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ReadSomeTopRecords", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "cb455b6f78ff4b1eb241c2bbc0b37e9f", CaptionResourceItem = "Parameters.ReadSomeTopRecords.Caption", DescriptionResourceItem = "Parameters.ReadSomeTopRecords.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "NumberOfRecords", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "cb455b6f78ff4b1eb241c2bbc0b37e9f", CaptionResourceItem = "Parameters.NumberOfRecords.Caption", DescriptionResourceItem = "Parameters.NumberOfRecords.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "FunctionType", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "cb455b6f78ff4b1eb241c2bbc0b37e9f", CaptionResourceItem = "Parameters.FunctionType.Caption", DescriptionResourceItem = "Parameters.FunctionType.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "AggregationColumnName", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "cb455b6f78ff4b1eb241c2bbc0b37e9f", CaptionResourceItem = "Parameters.AggregationColumnName.Caption", DescriptionResourceItem = "Parameters.AggregationColumnName.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "OrderInfo", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "cb455b6f78ff4b1eb241c2bbc0b37e9f", CaptionResourceItem = "Parameters.OrderInfo.Caption", DescriptionResourceItem = "Parameters.OrderInfo.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ResultEntity", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "cb455b6f78ff4b1eb241c2bbc0b37e9f", CaptionResourceItem = "Parameters.ResultEntity.Caption", DescriptionResourceItem = "Parameters.ResultEntity.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ResultCount", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "cb455b6f78ff4b1eb241c2bbc0b37e9f", CaptionResourceItem = "Parameters.ResultCount.Caption", DescriptionResourceItem = "Parameters.ResultCount.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ResultIntegerFunction", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "cb455b6f78ff4b1eb241c2bbc0b37e9f", CaptionResourceItem = "Parameters.ResultIntegerFunction.Caption", DescriptionResourceItem = "Parameters.ResultIntegerFunction.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ResultFloatFunction", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "cb455b6f78ff4b1eb241c2bbc0b37e9f", CaptionResourceItem = "Parameters.ResultFloatFunction.Caption", DescriptionResourceItem = "Parameters.ResultFloatFunction.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ResultDateTimeFunction", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "cb455b6f78ff4b1eb241c2bbc0b37e9f", CaptionResourceItem = "Parameters.ResultDateTimeFunction.Caption", DescriptionResourceItem = "Parameters.ResultDateTimeFunction.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ResultRowsCount", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "cb455b6f78ff4b1eb241c2bbc0b37e9f", CaptionResourceItem = "Parameters.ResultRowsCount.Caption", DescriptionResourceItem = "Parameters.ResultRowsCount.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "CanReadUncommitedData", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "cb455b6f78ff4b1eb241c2bbc0b37e9f", CaptionResourceItem = "Parameters.CanReadUncommitedData.Caption", DescriptionResourceItem = "Parameters.CanReadUncommitedData.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ResultEntityCollection", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "cb455b6f78ff4b1eb241c2bbc0b37e9f", CaptionResourceItem = "Parameters.ResultEntityCollection.Caption", DescriptionResourceItem = "Parameters.ResultEntityCollection.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "EntityColumnMetaPathes", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "cb455b6f78ff4b1eb241c2bbc0b37e9f", CaptionResourceItem = "Parameters.EntityColumnMetaPathes.Caption", DescriptionResourceItem = "Parameters.EntityColumnMetaPathes.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "IgnoreDisplayValues", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "cb455b6f78ff4b1eb241c2bbc0b37e9f", CaptionResourceItem = "Parameters.IgnoreDisplayValues.Caption", DescriptionResourceItem = "Parameters.IgnoreDisplayValues.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ResultCompositeObjectList", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "cb455b6f78ff4b1eb241c2bbc0b37e9f", CaptionResourceItem = "Parameters.ResultCompositeObjectList.Caption", DescriptionResourceItem = "Parameters.ResultCompositeObjectList.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ConsiderTimeInFilter", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "cb455b6f78ff4b1eb241c2bbc0b37e9f", CaptionResourceItem = "Parameters.ConsiderTimeInFilter.Caption", DescriptionResourceItem = "Parameters.ConsiderTimeInFilter.Caption", UseSolutionStorage = true)]
	/// <exclude/>
	public partial class ReadDataUserTask : ProcessUserTask
	{

		#region Constructors: Public

		public ReadDataUserTask(UserConnection userConnection)
			: base(userConnection) {
			SchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f");
			_considerTimeInFilter = () => { return true; };
		}

		#endregion

		#region Properties: Public

		public virtual string DataSourceFilters {
			get;
			set;
		}

		private int _resultType = 0;
		public virtual int ResultType {
			get {
				return _resultType;
			}
			set {
				_resultType = value;
			}
		}

		public virtual bool ReadSomeTopRecords {
			get;
			set;
		}

		public virtual int NumberOfRecords {
			get;
			set;
		}

		public virtual int FunctionType {
			get;
			set;
		}

		public virtual string AggregationColumnName {
			get;
			set;
		}

		public virtual string OrderInfo {
			get;
			set;
		}

		private Entity _resultEntity;
		public virtual Entity ResultEntity {
			get {
				return _resultEntity ?? (_resultEntity = new Entity(UserConnection));
			}
			set {
				_resultEntity = value;
			}
		}

		public virtual int ResultCount {
			get;
			set;
		}

		public virtual int ResultIntegerFunction {
			get;
			set;
		}

		public virtual Decimal ResultFloatFunction {
			get;
			set;
		}

		public virtual DateTime ResultDateTimeFunction {
			get;
			set;
		}

		public virtual int ResultRowsCount {
			get;
			set;
		}

		private bool _canReadUncommitedData = true;
		public virtual bool CanReadUncommitedData {
			get {
				return _canReadUncommitedData;
			}
			set {
				_canReadUncommitedData = value;
			}
		}

		public virtual EntityCollection ResultEntityCollection {
			get;
			set;
		}

		public virtual string EntityColumnMetaPathes {
			get;
			set;
		}

		public virtual bool IgnoreDisplayValues {
			get;
			set;
		}

		public virtual ICompositeObjectList<ICompositeObject> ResultCompositeObjectList {
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
			if (!HasMapping("DataSourceFilters")) {
				writer.WriteValue("DataSourceFilters", DataSourceFilters, null);
			}
			if (!HasMapping("ResultType")) {
				writer.WriteValue("ResultType", ResultType, 0);
			}
			if (!HasMapping("ReadSomeTopRecords")) {
				writer.WriteValue("ReadSomeTopRecords", ReadSomeTopRecords, false);
			}
			if (!HasMapping("NumberOfRecords")) {
				writer.WriteValue("NumberOfRecords", NumberOfRecords, 0);
			}
			if (!HasMapping("FunctionType")) {
				writer.WriteValue("FunctionType", FunctionType, 0);
			}
			if (!HasMapping("AggregationColumnName")) {
				writer.WriteValue("AggregationColumnName", AggregationColumnName, null);
			}
			if (!HasMapping("OrderInfo")) {
				writer.WriteValue("OrderInfo", OrderInfo, null);
			}
			if (ResultEntity != null && ResultEntity.Schema != null) {
				if (UseFlowEngineMode) {
					ResultEntity.Write(writer, "ResultEntity");
				} else {
					string serializedEntity = Entity.SerializeToJson(ResultEntity);
					writer.WriteValue("ResultEntity", serializedEntity, null);
				}
			}
			if (!HasMapping("ResultCount")) {
				writer.WriteValue("ResultCount", ResultCount, 0);
			}
			if (!HasMapping("ResultIntegerFunction")) {
				writer.WriteValue("ResultIntegerFunction", ResultIntegerFunction, 0);
			}
			if (!HasMapping("ResultFloatFunction")) {
				writer.WriteValue("ResultFloatFunction", ResultFloatFunction, 0m);
			}
			if (!HasMapping("ResultDateTimeFunction")) {
				writer.WriteValue("ResultDateTimeFunction", ResultDateTimeFunction, DateTime.ParseExact("01.01.0001 0:00", "dd.MM.yyyy H:mm", CultureInfo.InvariantCulture));
			}
			if (!HasMapping("ResultRowsCount")) {
				writer.WriteValue("ResultRowsCount", ResultRowsCount, 0);
			}
			if (!HasMapping("CanReadUncommitedData")) {
				writer.WriteValue("CanReadUncommitedData", CanReadUncommitedData, false);
			}
			if (!HasMapping("EntityColumnMetaPathes")) {
				writer.WriteValue("EntityColumnMetaPathes", EntityColumnMetaPathes, null);
			}
			if (!HasMapping("IgnoreDisplayValues")) {
				writer.WriteValue("IgnoreDisplayValues", IgnoreDisplayValues, false);
			}
			WriteSerializableObject<ICompositeObjectList<ICompositeObject>>(writer, "ResultCompositeObjectList", ResultCompositeObjectList);
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
				case "DataSourceFilters":
					DataSourceFilters = reader.GetStringValue();
				break;
				case "ResultType":
					ResultType = reader.GetIntValue();
				break;
				case "ReadSomeTopRecords":
					ReadSomeTopRecords = reader.GetBoolValue();
				break;
				case "NumberOfRecords":
					NumberOfRecords = reader.GetIntValue();
				break;
				case "FunctionType":
					FunctionType = reader.GetIntValue();
				break;
				case "AggregationColumnName":
					AggregationColumnName = reader.GetStringValue();
				break;
				case "OrderInfo":
					OrderInfo = reader.GetStringValue();
				break;
				case "ResultEntity":
					if (UseFlowEngineMode) {
						ResultEntity = reader.GetValue<Entity>();
					} else {
						ResultEntity = Entity.DeserializeFromJson(UserConnection, reader.GetValue<System.String>());
					}
				break;
				case "ResultCount":
					ResultCount = reader.GetIntValue();
				break;
				case "ResultIntegerFunction":
					ResultIntegerFunction = reader.GetIntValue();
				break;
				case "ResultFloatFunction":
					ResultFloatFunction = reader.GetValue<System.Decimal>();
				break;
				case "ResultDateTimeFunction":
					ResultDateTimeFunction = reader.GetDateTimeValue();
				break;
				case "ResultRowsCount":
					ResultRowsCount = reader.GetIntValue();
				break;
				case "CanReadUncommitedData":
					CanReadUncommitedData = reader.GetBoolValue();
				break;
				case "EntityColumnMetaPathes":
					EntityColumnMetaPathes = reader.GetStringValue();
				break;
				case "IgnoreDisplayValues":
					IgnoreDisplayValues = reader.GetBoolValue();
				break;
				case "ResultCompositeObjectList":
					ResultCompositeObjectList = ReadSerializableObject<ICompositeObjectList<ICompositeObject>>(reader);
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

