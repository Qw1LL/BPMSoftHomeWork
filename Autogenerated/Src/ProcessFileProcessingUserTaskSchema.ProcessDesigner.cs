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

	#region Class: ProcessFileProcessingUserTask

	[DesignModeProperty(Name = "ObjectFiles", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "6c620dd2026e560c489f030c5be5f2c3", CaptionResourceItem = "Parameters.ObjectFiles.Caption", DescriptionResourceItem = "Parameters.ObjectFiles.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ResultActionType", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "6c620dd2026e560c489f030c5be5f2c3", CaptionResourceItem = "Parameters.ResultActionType.Caption", DescriptionResourceItem = "Parameters.ResultActionType.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ConnectedObjectColumnUId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "6c620dd2026e560c489f030c5be5f2c3", CaptionResourceItem = "Parameters.ConnectedObjectColumnUId.Caption", DescriptionResourceItem = "Parameters.ConnectedObjectColumnUId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ConnectedObjectId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "6c620dd2026e560c489f030c5be5f2c3", CaptionResourceItem = "Parameters.ConnectedObjectId.Caption", DescriptionResourceItem = "Parameters.ConnectedObjectId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "TargetEntitySchemaUId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "6c620dd2026e560c489f030c5be5f2c3", CaptionResourceItem = "Parameters.TargetEntitySchemaUId.Caption", DescriptionResourceItem = "Parameters.TargetEntitySchemaUId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "CreatedObjectFileIds", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "6c620dd2026e560c489f030c5be5f2c3", CaptionResourceItem = "Parameters.CreatedObjectFileIds.Caption", DescriptionResourceItem = "Parameters.CreatedObjectFileIds.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Files", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "6c620dd2026e560c489f030c5be5f2c3", CaptionResourceItem = "Parameters.Files.Caption", DescriptionResourceItem = "Parameters.Files.Caption", UseSolutionStorage = true)]
	/// <exclude/>
	public partial class ProcessFileProcessingUserTask : ProcessUserTask
	{

		#region Constructors: Public

		public ProcessFileProcessingUserTask(UserConnection userConnection)
			: base(userConnection) {
			SchemaUId = new Guid("6c620dd2-026e-560c-489f-030c5be5f2c3");
		}

		#endregion

		#region Properties: Public

		public virtual ICompositeObjectList<ICompositeObject> ObjectFiles {
			get;
			set;
		}

		public virtual int ResultActionType {
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

		public virtual ICompositeObjectList<ICompositeObject> CreatedObjectFileIds {
			get;
			set;
		}

		public virtual ICompositeObjectList<ICompositeObject> Files {
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
			WriteSerializableObject<ICompositeObjectList<ICompositeObject>>(writer, "ObjectFiles", ObjectFiles);
			if (!HasMapping("ResultActionType")) {
				writer.WriteValue("ResultActionType", ResultActionType, 0);
			}
			if (!HasMapping("ConnectedObjectColumnUId")) {
				writer.WriteValue("ConnectedObjectColumnUId", ConnectedObjectColumnUId, Guid.Empty);
			}
			if (!HasMapping("ConnectedObjectId")) {
				writer.WriteValue("ConnectedObjectId", ConnectedObjectId, Guid.Empty);
			}
			if (!HasMapping("TargetEntitySchemaUId")) {
				writer.WriteValue("TargetEntitySchemaUId", TargetEntitySchemaUId, Guid.Empty);
			}
			WriteSerializableObject<ICompositeObjectList<ICompositeObject>>(writer, "CreatedObjectFileIds", CreatedObjectFileIds);
			WriteSerializableObject<ICompositeObjectList<ICompositeObject>>(writer, "Files", Files);
			writer.WriteFinishObject();
		}

		#endregion

		#region Methods: Protected

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			switch (reader.CurrentName) {
				case "ObjectFiles":
					ObjectFiles = ReadSerializableObject<ICompositeObjectList<ICompositeObject>>(reader);
				break;
				case "ResultActionType":
					ResultActionType = reader.GetIntValue();
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
				case "CreatedObjectFileIds":
					CreatedObjectFileIds = ReadSerializableObject<ICompositeObjectList<ICompositeObject>>(reader);
				break;
				case "Files":
					Files = ReadSerializableObject<ICompositeObjectList<ICompositeObject>>(reader);
				break;
			}
		}

		#endregion

	}

	#endregion

}

