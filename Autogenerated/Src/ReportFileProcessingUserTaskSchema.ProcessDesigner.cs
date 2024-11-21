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

	#region Class: ReportFileProcessingUserTask

	[DesignModeProperty(Name = "DataSourceFilters", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "c2bf041654c66c5658e041162c7795f0", CaptionResourceItem = "Parameters.DataSourceFilters.Caption", DescriptionResourceItem = "Parameters.DataSourceFilters.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "IsSeparateReports", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "c2bf041654c66c5658e041162c7795f0", CaptionResourceItem = "Parameters.IsSeparateReports.Caption", DescriptionResourceItem = "Parameters.IsSeparateReports.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ReportId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "c2bf041654c66c5658e041162c7795f0", CaptionResourceItem = "Parameters.ReportId.Caption", DescriptionResourceItem = "Parameters.ReportId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ResultActionType", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "c2bf041654c66c5658e041162c7795f0", CaptionResourceItem = "Parameters.ResultActionType.Caption", DescriptionResourceItem = "Parameters.ResultActionType.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ReportName", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "c2bf041654c66c5658e041162c7795f0", CaptionResourceItem = "Parameters.ReportName.Caption", DescriptionResourceItem = "Parameters.ReportName.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "CreatedObjectFileIds", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "c2bf041654c66c5658e041162c7795f0", CaptionResourceItem = "Parameters.CreatedObjectFileIds.Caption", DescriptionResourceItem = "Parameters.CreatedObjectFileIds.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ConnectedObjectColumnUId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "c2bf041654c66c5658e041162c7795f0", CaptionResourceItem = "Parameters.ConnectedObjectColumnUId.Caption", DescriptionResourceItem = "Parameters.ConnectedObjectColumnUId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ConnectedObjectId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "c2bf041654c66c5658e041162c7795f0", CaptionResourceItem = "Parameters.ConnectedObjectId.Caption", DescriptionResourceItem = "Parameters.ConnectedObjectId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "TargetEntitySchemaUId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "c2bf041654c66c5658e041162c7795f0", CaptionResourceItem = "Parameters.TargetEntitySchemaUId.Caption", DescriptionResourceItem = "Parameters.TargetEntitySchemaUId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ReportFiles", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "c2bf041654c66c5658e041162c7795f0", CaptionResourceItem = "Parameters.ReportFiles.Caption", DescriptionResourceItem = "Parameters.ReportFiles.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ReportNameDataSourceColumnUId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "c2bf041654c66c5658e041162c7795f0", CaptionResourceItem = "Parameters.ReportNameDataSourceColumnUId.Caption", DescriptionResourceItem = "Parameters.ReportNameDataSourceColumnUId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ConsiderTimeInFilter", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "c2bf041654c66c5658e041162c7795f0", CaptionResourceItem = "Parameters.ConsiderTimeInFilter.Caption", DescriptionResourceItem = "Parameters.ConsiderTimeInFilter.Caption", UseSolutionStorage = true)]
	/// <exclude/>
	public partial class ReportFileProcessingUserTask : ProcessUserTask
	{

		#region Constructors: Public

		public ReportFileProcessingUserTask(UserConnection userConnection)
			: base(userConnection) {
			SchemaUId = new Guid("c2bf0416-54c6-6c56-58e0-41162c7795f0");
			_considerTimeInFilter = () => { return true; };
		}

		#endregion

		#region Properties: Public

		public virtual string DataSourceFilters {
			get;
			set;
		}

		public virtual bool IsSeparateReports {
			get;
			set;
		}

		public virtual Guid ReportId {
			get;
			set;
		}

		public virtual int ResultActionType {
			get;
			set;
		}

		public virtual string ReportName {
			get;
			set;
		}

		public virtual ICompositeObjectList<ICompositeObject> CreatedObjectFileIds {
			get;
			set;
		}

		public virtual Guid ConnectedObjectColumnUId {
			get;
			set;
		}

		public virtual Guid ConnectedObjectId {
			get;
			set;
		}

		public virtual Guid TargetEntitySchemaUId {
			get;
			set;
		}

		public virtual ICompositeObjectList<ICompositeObject> ReportFiles {
			get;
			set;
		}

		public virtual Guid ReportNameDataSourceColumnUId {
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
			if (!HasMapping("IsSeparateReports")) {
				writer.WriteValue("IsSeparateReports", IsSeparateReports, false);
			}
			if (!HasMapping("ReportId")) {
				writer.WriteValue("ReportId", ReportId, Guid.Empty);
			}
			if (!HasMapping("ResultActionType")) {
				writer.WriteValue("ResultActionType", ResultActionType, 0);
			}
			if (!HasMapping("ReportName")) {
				writer.WriteValue("ReportName", ReportName, null);
			}
			WriteSerializableObject<ICompositeObjectList<ICompositeObject>>(writer, "CreatedObjectFileIds", CreatedObjectFileIds);
			if (!HasMapping("ConnectedObjectColumnUId")) {
				writer.WriteValue("ConnectedObjectColumnUId", ConnectedObjectColumnUId, Guid.Empty);
			}
			if (!HasMapping("ConnectedObjectId")) {
				writer.WriteValue("ConnectedObjectId", ConnectedObjectId, Guid.Empty);
			}
			if (!HasMapping("TargetEntitySchemaUId")) {
				writer.WriteValue("TargetEntitySchemaUId", TargetEntitySchemaUId, Guid.Empty);
			}
			WriteSerializableObject<ICompositeObjectList<ICompositeObject>>(writer, "ReportFiles", ReportFiles);
			if (!HasMapping("ReportNameDataSourceColumnUId")) {
				writer.WriteValue("ReportNameDataSourceColumnUId", ReportNameDataSourceColumnUId, Guid.Empty);
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
				case "DataSourceFilters":
					DataSourceFilters = reader.GetStringValue();
				break;
				case "IsSeparateReports":
					IsSeparateReports = reader.GetBoolValue();
				break;
				case "ReportId":
					ReportId = reader.GetGuidValue();
				break;
				case "ResultActionType":
					ResultActionType = reader.GetIntValue();
				break;
				case "ReportName":
					ReportName = reader.GetStringValue();
				break;
				case "CreatedObjectFileIds":
					CreatedObjectFileIds = ReadSerializableObject<ICompositeObjectList<ICompositeObject>>(reader);
				break;
				case "ConnectedObjectColumnUId":
					ConnectedObjectColumnUId = reader.GetGuidValue();
				break;
				case "ConnectedObjectId":
					ConnectedObjectId = reader.GetGuidValue();
				break;
				case "TargetEntitySchemaUId":
					TargetEntitySchemaUId = reader.GetGuidValue();
				break;
				case "ReportFiles":
					ReportFiles = ReadSerializableObject<ICompositeObjectList<ICompositeObject>>(reader);
				break;
				case "ReportNameDataSourceColumnUId":
					ReportNameDataSourceColumnUId = reader.GetGuidValue();
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

