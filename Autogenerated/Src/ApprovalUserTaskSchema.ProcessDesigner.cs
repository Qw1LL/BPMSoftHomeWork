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
	using System.Data;
	using System.Globalization;

	#region Class: ApprovalUserTaskSchemaExtension

	/// <exclude/>
	public class ApprovalUserTaskSchemaExtension : ProcessUserTaskSchemaExtension
	{

		#region Methods: Public

		public override Dictionary<Guid, string> GetResultParameterAllValues(UserConnection userConnection, ProcessSchemaUserTask schemaUserTask) {
			var result = new Dictionary<Guid, string>();
			Select select = new Select(userConnection)
				.Column("VisaStatus", "Id")
				.Column("VisaStatus", "Name")
				.From("VisaStatus")
				.Where("VisaStatus", "IsFinal").IsEqual(Column.Const(true)) as Select;
			using (DBExecutor dbExecutor = userConnection.EnsureDBConnection()) {
				using (IDataReader dataReader = select.ExecuteReader(dbExecutor)) {
					while (dataReader.Read()) {
						Guid key = dataReader.GetColumnValue<Guid>("Id");
						string value = dataReader.GetColumnValue<string>("Name");
						result.Add(key, value);
					}
				}
			}
			return result;
		}

		#endregion

	}

	#endregion

	#region Class: ApprovalUserTask

	[DesignModeProperty(Name = "Purpose", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "51179e03650d4492862d9943005c26b4", CaptionResourceItem = "Parameters.Purpose.Caption", DescriptionResourceItem = "Parameters.Purpose.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "EntitySchemaUId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "51179e03650d4492862d9943005c26b4", CaptionResourceItem = "Parameters.EntitySchemaUId.Caption", DescriptionResourceItem = "Parameters.EntitySchemaUId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "RecordId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "51179e03650d4492862d9943005c26b4", CaptionResourceItem = "Parameters.RecordId.Caption", DescriptionResourceItem = "Parameters.RecordId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ResultParameter", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "51179e03650d4492862d9943005c26b4", CaptionResourceItem = "Parameters.ResultParameter.Caption", DescriptionResourceItem = "Parameters.ResultParameter.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ApproverType", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "51179e03650d4492862d9943005c26b4", CaptionResourceItem = "Parameters.ApproverType.Caption", DescriptionResourceItem = "Parameters.ApproverType.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "EmployeeId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "51179e03650d4492862d9943005c26b4", CaptionResourceItem = "Parameters.EmployeeId.Caption", DescriptionResourceItem = "Parameters.EmployeeId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "RoleId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "51179e03650d4492862d9943005c26b4", CaptionResourceItem = "Parameters.RoleId.Caption", DescriptionResourceItem = "Parameters.RoleId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "IsAllowedToDelegate", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "51179e03650d4492862d9943005c26b4", CaptionResourceItem = "Parameters.IsAllowedToDelegate.Caption", DescriptionResourceItem = "Parameters.IsAllowedToDelegate.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ApprovalSchemaUId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "51179e03650d4492862d9943005c26b4", CaptionResourceItem = "Parameters.ApprovalSchemaUId.Caption", DescriptionResourceItem = "Parameters.ApprovalSchemaUId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "CurrentApprovalId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "51179e03650d4492862d9943005c26b4", CaptionResourceItem = "Parameters.CurrentApprovalId.Caption", DescriptionResourceItem = "Parameters.CurrentApprovalId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "MasterColumnUId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "51179e03650d4492862d9943005c26b4", CaptionResourceItem = "Parameters.MasterColumnUId.Caption", DescriptionResourceItem = "Parameters.MasterColumnUId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "IsSendEmailToApprovers", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "51179e03650d4492862d9943005c26b4", CaptionResourceItem = "Parameters.IsSendEmailToApprovers.Caption", DescriptionResourceItem = "Parameters.IsSendEmailToApprovers.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "IsSendEmailToAuthor", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "51179e03650d4492862d9943005c26b4", CaptionResourceItem = "Parameters.IsSendEmailToAuthor.Caption", DescriptionResourceItem = "Parameters.IsSendEmailToAuthor.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ApproverEmailTemplate", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "51179e03650d4492862d9943005c26b4", CaptionResourceItem = "Parameters.ApproverEmailTemplate.Caption", DescriptionResourceItem = "Parameters.ApproverEmailTemplate.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "AuthorEmailTemplate", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "51179e03650d4492862d9943005c26b4", CaptionResourceItem = "Parameters.AuthorEmailTemplate.Caption", DescriptionResourceItem = "Parameters.AuthorEmailTemplate.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "IgnoreEmailErrors", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "51179e03650d4492862d9943005c26b4", CaptionResourceItem = "Parameters.IgnoreEmailErrors.Caption", DescriptionResourceItem = "Parameters.IgnoreEmailErrors.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "IsRequiredDigitalSignature", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "51179e03650d4492862d9943005c26b4", CaptionResourceItem = "Parameters.IsRequiredDigitalSignature.Caption", DescriptionResourceItem = "Parameters.IsRequiredDigitalSignature.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "SectionId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "51179e03650d4492862d9943005c26b4", CaptionResourceItem = "Parameters.SectionId.Caption", DescriptionResourceItem = "Parameters.SectionId.Caption", UseSolutionStorage = true)]
	/// <exclude/>
	public partial class ApprovalUserTask : ProcessUserTask
	{

		#region Constructors: Public

		public ApprovalUserTask(UserConnection userConnection)
			: base(userConnection) {
			SchemaUId = new Guid("51179e03-650d-4492-862d-9943005c26b4");
		}

		#endregion

		#region Properties: Public

		private LocalizableString _purpose;
		public virtual LocalizableString Purpose {
			get {
				return _purpose ?? (_purpose = new LocalizableString());
			}
			set {
				_purpose = value;
			}
		}

		public virtual Guid EntitySchemaUId {
			get;
			set;
		}

		public virtual Guid RecordId {
			get;
			set;
		}

		public virtual Guid ResultParameter {
			get;
			set;
		}

		public virtual int ApproverType {
			get;
			set;
		}

		public virtual Guid EmployeeId {
			get;
			set;
		}

		public virtual Guid RoleId {
			get;
			set;
		}

		public virtual bool IsAllowedToDelegate {
			get;
			set;
		}

		public virtual Guid ApprovalSchemaUId {
			get;
			set;
		}

		public virtual Guid CurrentApprovalId {
			get;
			set;
		}

		public virtual Guid MasterColumnUId {
			get;
			set;
		}

		public virtual bool IsSendEmailToApprovers {
			get;
			set;
		}

		public virtual bool IsSendEmailToAuthor {
			get;
			set;
		}

		public virtual Guid ApproverEmailTemplate {
			get;
			set;
		}

		public virtual Guid AuthorEmailTemplate {
			get;
			set;
		}

		private bool _ignoreEmailErrors = true;
		public virtual bool IgnoreEmailErrors {
			get {
				return _ignoreEmailErrors;
			}
			set {
				_ignoreEmailErrors = value;
			}
		}

		public virtual bool IsRequiredDigitalSignature {
			get;
			set;
		}

		public virtual Guid SectionId {
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
			if (!HasMapping("EntitySchemaUId")) {
				writer.WriteValue("EntitySchemaUId", EntitySchemaUId, Guid.Empty);
			}
			if (!HasMapping("RecordId")) {
				writer.WriteValue("RecordId", RecordId, Guid.Empty);
			}
			if (!HasMapping("ResultParameter")) {
				writer.WriteValue("ResultParameter", ResultParameter, Guid.Empty);
			}
			if (!HasMapping("ApproverType")) {
				writer.WriteValue("ApproverType", ApproverType, 0);
			}
			if (!HasMapping("EmployeeId")) {
				writer.WriteValue("EmployeeId", EmployeeId, Guid.Empty);
			}
			if (!HasMapping("RoleId")) {
				writer.WriteValue("RoleId", RoleId, Guid.Empty);
			}
			if (!HasMapping("IsAllowedToDelegate")) {
				writer.WriteValue("IsAllowedToDelegate", IsAllowedToDelegate, false);
			}
			if (!HasMapping("ApprovalSchemaUId")) {
				writer.WriteValue("ApprovalSchemaUId", ApprovalSchemaUId, Guid.Empty);
			}
			if (!HasMapping("CurrentApprovalId")) {
				writer.WriteValue("CurrentApprovalId", CurrentApprovalId, Guid.Empty);
			}
			if (!HasMapping("MasterColumnUId")) {
				writer.WriteValue("MasterColumnUId", MasterColumnUId, Guid.Empty);
			}
			if (!HasMapping("IsSendEmailToApprovers")) {
				writer.WriteValue("IsSendEmailToApprovers", IsSendEmailToApprovers, false);
			}
			if (!HasMapping("IsSendEmailToAuthor")) {
				writer.WriteValue("IsSendEmailToAuthor", IsSendEmailToAuthor, false);
			}
			if (!HasMapping("ApproverEmailTemplate")) {
				writer.WriteValue("ApproverEmailTemplate", ApproverEmailTemplate, Guid.Empty);
			}
			if (!HasMapping("AuthorEmailTemplate")) {
				writer.WriteValue("AuthorEmailTemplate", AuthorEmailTemplate, Guid.Empty);
			}
			if (!HasMapping("IgnoreEmailErrors")) {
				writer.WriteValue("IgnoreEmailErrors", IgnoreEmailErrors, false);
			}
			if (!HasMapping("IsRequiredDigitalSignature")) {
				writer.WriteValue("IsRequiredDigitalSignature", IsRequiredDigitalSignature, false);
			}
			if (!HasMapping("SectionId")) {
				writer.WriteValue("SectionId", SectionId, Guid.Empty);
			}
			writer.WriteFinishObject();
		}

		#endregion

		#region Methods: Protected

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			switch (reader.CurrentName) {
				case "Purpose":
					Purpose = reader.GetLocalizableStringValue();
				break;
				case "EntitySchemaUId":
					EntitySchemaUId = reader.GetGuidValue();
				break;
				case "RecordId":
					RecordId = reader.GetGuidValue();
				break;
				case "ResultParameter":
					ResultParameter = reader.GetGuidValue();
				break;
				case "ApproverType":
					ApproverType = reader.GetIntValue();
				break;
				case "EmployeeId":
					EmployeeId = reader.GetGuidValue();
				break;
				case "RoleId":
					RoleId = reader.GetGuidValue();
				break;
				case "IsAllowedToDelegate":
					IsAllowedToDelegate = reader.GetBoolValue();
				break;
				case "ApprovalSchemaUId":
					ApprovalSchemaUId = reader.GetGuidValue();
				break;
				case "CurrentApprovalId":
					CurrentApprovalId = reader.GetGuidValue();
				break;
				case "MasterColumnUId":
					MasterColumnUId = reader.GetGuidValue();
				break;
				case "IsSendEmailToApprovers":
					IsSendEmailToApprovers = reader.GetBoolValue();
				break;
				case "IsSendEmailToAuthor":
					IsSendEmailToAuthor = reader.GetBoolValue();
				break;
				case "ApproverEmailTemplate":
					ApproverEmailTemplate = reader.GetGuidValue();
				break;
				case "AuthorEmailTemplate":
					AuthorEmailTemplate = reader.GetGuidValue();
				break;
				case "IgnoreEmailErrors":
					IgnoreEmailErrors = reader.GetBoolValue();
				break;
				case "IsRequiredDigitalSignature":
					IsRequiredDigitalSignature = reader.GetBoolValue();
				break;
				case "SectionId":
					SectionId = reader.GetGuidValue();
				break;
			}
		}

		#endregion

	}

	#endregion

}

