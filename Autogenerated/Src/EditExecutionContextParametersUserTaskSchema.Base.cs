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

	#region Class: EditExecutionContextParametersUserTask

	[DesignModeProperty(Name = "DetailName", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "6db39ba861ad43fdadbac3797298adc4", CaptionResourceItem = "Parameters.DetailName.Caption", DescriptionResourceItem = "Parameters.DetailName.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "DetailCaption", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "6db39ba861ad43fdadbac3797298adc4", CaptionResourceItem = "Parameters.DetailCaption.Caption", DescriptionResourceItem = "Parameters.DetailCaption.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "DetailSchemaName", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "6db39ba861ad43fdadbac3797298adc4", CaptionResourceItem = "Parameters.DetailSchemaName.Caption", DescriptionResourceItem = "Parameters.DetailSchemaName.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "AttributeName", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "6db39ba861ad43fdadbac3797298adc4", CaptionResourceItem = "Parameters.AttributeName.Caption", DescriptionResourceItem = "Parameters.AttributeName.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "AttributeValue", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "6db39ba861ad43fdadbac3797298adc4", CaptionResourceItem = "Parameters.AttributeValue.Caption", DescriptionResourceItem = "Parameters.AttributeValue.Caption", UseSolutionStorage = true)]
	/// <exclude/>
	public class EditExecutionContextParametersUserTask : ProcessUserTask
	{

		#region Constructors: Public

		public EditExecutionContextParametersUserTask(UserConnection userConnection)
			: base(userConnection) {
			SchemaUId = new Guid("6db39ba8-61ad-43fd-adba-c3797298adc4");
		}

		#endregion

		#region Properties: Public

		public virtual string DetailName {
			get;
			set;
		}

		public virtual string DetailCaption {
			get;
			set;
		}

		public virtual string DetailSchemaName {
			get;
			set;
		}

		public virtual string AttributeName {
			get;
			set;
		}

		public virtual string AttributeValue {
			get;
			set;
		}

		#endregion

		#region Methods: Protected

		protected override bool InternalExecute(ProcessExecutingContext context) {
			return true;
		}

		#endregion

		#region Methods: Public

		public override bool CompleteExecuting(params object[] parameters) {
			return base.CompleteExecuting(parameters);
		}

		public override void CancelExecuting(params object[] parameters) {
			base.CancelExecuting(parameters);
		}

		public override string GetExecutionData() {
			return string.Empty;
		}

		public override void WritePropertiesData(DataWriter writer) {
			writer.WriteStartObject(Name);
			base.WritePropertiesData(writer);
			if (Status == Core.Process.ProcessStatus.Inactive) {
				writer.WriteFinishObject();
				return;
			}
			if (!HasMapping("DetailName")) {
				writer.WriteValue("DetailName", DetailName, null);
			}
			if (!HasMapping("DetailCaption")) {
				writer.WriteValue("DetailCaption", DetailCaption, null);
			}
			if (!HasMapping("DetailSchemaName")) {
				writer.WriteValue("DetailSchemaName", DetailSchemaName, null);
			}
			if (!HasMapping("AttributeName")) {
				writer.WriteValue("AttributeName", AttributeName, null);
			}
			if (!HasMapping("AttributeValue")) {
				writer.WriteValue("AttributeValue", AttributeValue, null);
			}
			writer.WriteFinishObject();
		}

		#endregion

		#region Methods: Protected

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			switch (reader.CurrentName) {
				case "DetailName":
					DetailName = reader.GetStringValue();
				break;
				case "DetailCaption":
					DetailCaption = reader.GetStringValue();
				break;
				case "DetailSchemaName":
					DetailSchemaName = reader.GetStringValue();
				break;
				case "AttributeName":
					AttributeName = reader.GetStringValue();
				break;
				case "AttributeValue":
					AttributeValue = reader.GetStringValue();
				break;
			}
		}

		#endregion

	}

	#endregion

}

