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

	#region Class: ObjectFileProcessingUserTask

	[DesignModeProperty(Name = "SourceEntitySchemaUId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "9387c7948d845925ab77c47e7d876286", CaptionResourceItem = "Parameters.SourceEntitySchemaUId.Caption", DescriptionResourceItem = "Parameters.SourceEntitySchemaUId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "DataSourceFilters", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "9387c7948d845925ab77c47e7d876286", CaptionResourceItem = "Parameters.DataSourceFilters.Caption", DescriptionResourceItem = "Parameters.DataSourceFilters.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "TargetEntitySchemaUId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "9387c7948d845925ab77c47e7d876286", CaptionResourceItem = "Parameters.TargetEntitySchemaUId.Caption", DescriptionResourceItem = "Parameters.TargetEntitySchemaUId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "RecordsToRead", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "9387c7948d845925ab77c47e7d876286", CaptionResourceItem = "Parameters.RecordsToRead.Caption", DescriptionResourceItem = "Parameters.RecordsToRead.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "OrderByInfo", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "9387c7948d845925ab77c47e7d876286", CaptionResourceItem = "Parameters.OrderByInfo.Caption", DescriptionResourceItem = "Parameters.OrderByInfo.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "CreatedObjectFileIds", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "9387c7948d845925ab77c47e7d876286", CaptionResourceItem = "Parameters.CreatedObjectFileIds.Caption", DescriptionResourceItem = "Parameters.CreatedObjectFileIds.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ConnectedObjectId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "9387c7948d845925ab77c47e7d876286", CaptionResourceItem = "Parameters.ConnectedObjectId.Caption", DescriptionResourceItem = "Parameters.ConnectedObjectId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ConnectedObjectColumnUId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "9387c7948d845925ab77c47e7d876286", CaptionResourceItem = "Parameters.ConnectedObjectColumnUId.Caption", DescriptionResourceItem = "Parameters.ConnectedObjectColumnUId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ResultActionType", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "9387c7948d845925ab77c47e7d876286", CaptionResourceItem = "Parameters.ResultActionType.Caption", DescriptionResourceItem = "Parameters.ResultActionType.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ObjectFiles", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "9387c7948d845925ab77c47e7d876286", CaptionResourceItem = "Parameters.ObjectFiles.Caption", DescriptionResourceItem = "Parameters.ObjectFiles.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ConsiderTimeInFilter", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "9387c7948d845925ab77c47e7d876286", CaptionResourceItem = "Parameters.ConsiderTimeInFilter.Caption", DescriptionResourceItem = "Parameters.ConsiderTimeInFilter.Caption", UseSolutionStorage = true)]
	/// <exclude/>
	public partial class ObjectFileProcessingUserTask : ProcessUserTask
	{

		#region Constructors: Public

		public ObjectFileProcessingUserTask(UserConnection userConnection)
			: base(userConnection) {
			SchemaUId = new Guid("9387c794-8d84-5925-ab77-c47e7d876286");
			_considerTimeInFilter = () => { return true; };
		}

		#endregion

		#region Properties: Public

		public virtual Guid SourceEntitySchemaUId {
			get;
			set;
		}

		public virtual string DataSourceFilters {
			get;
			set;
		}

		public virtual Guid TargetEntitySchemaUId {
			get;
			set;
		}

		private int _recordsToRead = 50;
		public virtual int RecordsToRead {
			get {
				return _recordsToRead;
			}
			set {
				_recordsToRead = value;
			}
		}

		public virtual string OrderByInfo {
			get;
			set;
		}

		public virtual ICompositeObjectList<ICompositeObject> CreatedObjectFileIds {
			get;
			set;
		}

		public virtual Guid ConnectedObjectId {
			get;
			set;
		}

		public virtual Guid ConnectedObjectColumnUId {
			get;
			set;
		}

		public virtual int ResultActionType {
			get;
			set;
		}

		public virtual ICompositeObjectList<ICompositeObject> ObjectFiles {
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
			if (!HasMapping("SourceEntitySchemaUId")) {
				writer.WriteValue("SourceEntitySchemaUId", SourceEntitySchemaUId, Guid.Empty);
			}
			if (!HasMapping("DataSourceFilters")) {
				writer.WriteValue("DataSourceFilters", DataSourceFilters, null);
			}
			if (!HasMapping("TargetEntitySchemaUId")) {
				writer.WriteValue("TargetEntitySchemaUId", TargetEntitySchemaUId, Guid.Empty);
			}
			if (!HasMapping("RecordsToRead")) {
				writer.WriteValue("RecordsToRead", RecordsToRead, 0);
			}
			if (!HasMapping("OrderByInfo")) {
				writer.WriteValue("OrderByInfo", OrderByInfo, null);
			}
			WriteSerializableObject<ICompositeObjectList<ICompositeObject>>(writer, "CreatedObjectFileIds", CreatedObjectFileIds);
			if (!HasMapping("ConnectedObjectId")) {
				writer.WriteValue("ConnectedObjectId", ConnectedObjectId, Guid.Empty);
			}
			if (!HasMapping("ConnectedObjectColumnUId")) {
				writer.WriteValue("ConnectedObjectColumnUId", ConnectedObjectColumnUId, Guid.Empty);
			}
			if (!HasMapping("ResultActionType")) {
				writer.WriteValue("ResultActionType", ResultActionType, 0);
			}
			WriteSerializableObject<ICompositeObjectList<ICompositeObject>>(writer, "ObjectFiles", ObjectFiles);
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
				case "SourceEntitySchemaUId":
					SourceEntitySchemaUId = reader.GetGuidValue();
				break;
				case "DataSourceFilters":
					DataSourceFilters = reader.GetStringValue();
				break;
				case "TargetEntitySchemaUId":
					TargetEntitySchemaUId = reader.GetGuidValue();
				break;
				case "RecordsToRead":
					RecordsToRead = reader.GetIntValue();
				break;
				case "OrderByInfo":
					OrderByInfo = reader.GetStringValue();
				break;
				case "CreatedObjectFileIds":
					CreatedObjectFileIds = ReadSerializableObject<ICompositeObjectList<ICompositeObject>>(reader);
				break;
				case "ConnectedObjectId":
					ConnectedObjectId = reader.GetGuidValue();
				break;
				case "ConnectedObjectColumnUId":
					ConnectedObjectColumnUId = reader.GetGuidValue();
				break;
				case "ResultActionType":
					ResultActionType = reader.GetIntValue();
				break;
				case "ObjectFiles":
					ObjectFiles = ReadSerializableObject<ICompositeObjectList<ICompositeObject>>(reader);
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

