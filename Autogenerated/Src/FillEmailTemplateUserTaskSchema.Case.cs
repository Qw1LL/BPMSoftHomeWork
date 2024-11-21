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
	using System.Linq;
	using System.Text.RegularExpressions;
	using System.Web;

	#region Class: FillEmailTemplateUserTask

	[DesignModeProperty(Name = "Subject", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "06a1cb59b0dc424ab7032b704cdce8a1", CaptionResourceItem = "Parameters.Subject.Caption", DescriptionResourceItem = "Parameters.Subject.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Body", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "06a1cb59b0dc424ab7032b704cdce8a1", CaptionResourceItem = "Parameters.Body.Caption", DescriptionResourceItem = "Parameters.Body.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "RecordId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "06a1cb59b0dc424ab7032b704cdce8a1", CaptionResourceItem = "Parameters.RecordId.Caption", DescriptionResourceItem = "Parameters.RecordId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "TemplateId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "06a1cb59b0dc424ab7032b704cdce8a1", CaptionResourceItem = "Parameters.TemplateId.Caption", DescriptionResourceItem = "Parameters.TemplateId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "SysEntitySchemaId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "06a1cb59b0dc424ab7032b704cdce8a1", CaptionResourceItem = "Parameters.SysEntitySchemaId.Caption", DescriptionResourceItem = "Parameters.SysEntitySchemaId.Caption", UseSolutionStorage = true)]
	/// <exclude/>
	public partial class FillEmailTemplateUserTask : ProcessUserTask
	{

		#region Constructors: Public

		public FillEmailTemplateUserTask(UserConnection userConnection)
			: base(userConnection) {
			SchemaUId = new Guid("06a1cb59-b0dc-424a-b703-2b704cdce8a1");
		}

		#endregion

		#region Properties: Public

		public virtual string Subject {
			get;
			set;
		}

		public virtual string Body {
			get;
			set;
		}

		public virtual Guid RecordId {
			get;
			set;
		}

		public virtual Guid TemplateId {
			get;
			set;
		}

		public virtual Guid SysEntitySchemaId {
			get;
			set;
		}

		private LocalizableString _noDataLocalizableString;
		public LocalizableString NoDataLocalizableString {
			get {
				return _noDataLocalizableString ?? (_noDataLocalizableString = new LocalizableString(Storage, Schema.GetResourceManagerName(), "LocalizableStrings.NoDataLocalizableString.Value"));
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
			if (!HasMapping("Subject")) {
				writer.WriteValue("Subject", Subject, null);
			}
			if (!HasMapping("Body")) {
				writer.WriteValue("Body", Body, null);
			}
			if (!HasMapping("RecordId")) {
				writer.WriteValue("RecordId", RecordId, Guid.Empty);
			}
			if (!HasMapping("TemplateId")) {
				writer.WriteValue("TemplateId", TemplateId, Guid.Empty);
			}
			if (!HasMapping("SysEntitySchemaId")) {
				writer.WriteValue("SysEntitySchemaId", SysEntitySchemaId, Guid.Empty);
			}
			writer.WriteFinishObject();
		}

		#endregion

		#region Methods: Protected

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			switch (reader.CurrentName) {
				case "Subject":
					Subject = reader.GetStringValue();
				break;
				case "Body":
					Body = reader.GetStringValue();
				break;
				case "RecordId":
					RecordId = reader.GetGuidValue();
				break;
				case "TemplateId":
					TemplateId = reader.GetGuidValue();
				break;
				case "SysEntitySchemaId":
					SysEntitySchemaId = reader.GetGuidValue();
				break;
			}
		}

		#endregion

	}

	#endregion

}

