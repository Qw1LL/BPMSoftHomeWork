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

	#region Class: SearchDuplicatesUserTask

	[DesignModeProperty(Name = "EntitySchemaId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "bdea8a2dd51f438ea40cf707f4f48ce4", CaptionResourceItem = "Parameters.EntitySchemaId.Caption", DescriptionResourceItem = "Parameters.EntitySchemaId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Rules", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "bdea8a2dd51f438ea40cf707f4f48ce4", CaptionResourceItem = "Parameters.Rules.Caption", DescriptionResourceItem = "Parameters.Rules.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "GoldRecordId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "bdea8a2dd51f438ea40cf707f4f48ce4", CaptionResourceItem = "Parameters.GoldRecordId.Caption", DescriptionResourceItem = "Parameters.GoldRecordId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "EntityId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "bdea8a2dd51f438ea40cf707f4f48ce4", CaptionResourceItem = "Parameters.EntityId.Caption", DescriptionResourceItem = "Parameters.EntityId.Caption", UseSolutionStorage = true)]
	/// <exclude/>
	public partial class SearchDuplicatesUserTask : ProcessUserTask
	{

		#region Constructors: Public

		public SearchDuplicatesUserTask(UserConnection userConnection)
			: base(userConnection) {
			SchemaUId = new Guid("bdea8a2d-d51f-438e-a40c-f707f4f48ce4");
		}

		#endregion

		#region Properties: Public

		public virtual Guid EntitySchemaId {
			get;
			set;
		}

		public virtual string Rules {
			get;
			set;
		}

		public virtual Guid GoldRecordId {
			get;
			set;
		}

		public virtual Guid EntityId {
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
			if (!HasMapping("EntitySchemaId")) {
				writer.WriteValue("EntitySchemaId", EntitySchemaId, Guid.Empty);
			}
			if (!HasMapping("Rules")) {
				writer.WriteValue("Rules", Rules, null);
			}
			if (!HasMapping("GoldRecordId")) {
				writer.WriteValue("GoldRecordId", GoldRecordId, Guid.Empty);
			}
			if (!HasMapping("EntityId")) {
				writer.WriteValue("EntityId", EntityId, Guid.Empty);
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
				case "Rules":
					Rules = reader.GetStringValue();
				break;
				case "GoldRecordId":
					GoldRecordId = reader.GetGuidValue();
				break;
				case "EntityId":
					EntityId = reader.GetGuidValue();
				break;
			}
		}

		#endregion

	}

	#endregion

}

