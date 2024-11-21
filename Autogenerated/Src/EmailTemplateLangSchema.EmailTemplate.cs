namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.DcmProcess;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;
	using BPMSoft.Core.Process;
	using BPMSoft.Core.Process.Configuration;
	using BPMSoft.GlobalSearch.Indexing;
	using BPMSoft.UI.WebControls.Controls;
	using BPMSoft.UI.WebControls.Utilities.Json.Converters;
	using DataContract = BPMSoft.Nui.ServiceModel.DataContract;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Data;
	using System.Drawing;
	using System.Globalization;
	using System.IO;
	using System.Linq;

	#region Class: EmailTemplateLangSchema

	/// <exclude/>
	public class EmailTemplateLangSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public EmailTemplateLangSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public EmailTemplateLangSchema(EmailTemplateLangSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public EmailTemplateLangSchema(EmailTemplateLangSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("eb3fb47a-d515-42d3-b9bd-4ebc26c70d8a");
			RealUId = new Guid("eb3fb47a-d515-42d3-b9bd-4ebc26c70d8a");
			Name = "EmailTemplateLang";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("91d5b8ed-2389-4812-9e17-f329888285e6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("8e987603-7a9c-4048-bee5-5d49d148bd87")) == null) {
				Columns.Add(CreateEmailTemplateColumn());
			}
			if (Columns.FindByUId(new Guid("a12c37f1-725a-4ae2-a325-4373726c4c5f")) == null) {
				Columns.Add(CreateSubjectColumn());
			}
			if (Columns.FindByUId(new Guid("941d83c1-a31e-4326-ae3a-2e1c8da26bbd")) == null) {
				Columns.Add(CreateBodyColumn());
			}
			if (Columns.FindByUId(new Guid("ce75e51b-1906-49f4-9b2f-12a60e74bbbf")) == null) {
				Columns.Add(CreateLanguageColumn());
			}
			if (Columns.FindByUId(new Guid("c809fefc-91b7-4395-a561-7c7d440342b4")) == null) {
				Columns.Add(CreateIsHtmlBodyColumn());
			}
			if (Columns.FindByUId(new Guid("a6438ce3-71e3-4b77-9af2-a529133f9513")) == null) {
				Columns.Add(CreateTemplateConfigColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateEmailTemplateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("8e987603-7a9c-4048-bee5-5d49d148bd87"),
				Name = @"EmailTemplate",
				ReferenceSchemaUId = new Guid("93030575-f70f-4041-902e-c4badaf62c63"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("eb3fb47a-d515-42d3-b9bd-4ebc26c70d8a"),
				ModifiedInSchemaUId = new Guid("eb3fb47a-d515-42d3-b9bd-4ebc26c70d8a"),
				CreatedInPackageId = new Guid("91d5b8ed-2389-4812-9e17-f329888285e6")
			};
		}

		protected virtual EntitySchemaColumn CreateSubjectColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("a12c37f1-725a-4ae2-a325-4373726c4c5f"),
				Name = @"Subject",
				CreatedInSchemaUId = new Guid("eb3fb47a-d515-42d3-b9bd-4ebc26c70d8a"),
				ModifiedInSchemaUId = new Guid("eb3fb47a-d515-42d3-b9bd-4ebc26c70d8a"),
				CreatedInPackageId = new Guid("91d5b8ed-2389-4812-9e17-f329888285e6")
			};
		}

		protected virtual EntitySchemaColumn CreateBodyColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("941d83c1-a31e-4326-ae3a-2e1c8da26bbd"),
				Name = @"Body",
				CreatedInSchemaUId = new Guid("eb3fb47a-d515-42d3-b9bd-4ebc26c70d8a"),
				ModifiedInSchemaUId = new Guid("eb3fb47a-d515-42d3-b9bd-4ebc26c70d8a"),
				CreatedInPackageId = new Guid("91d5b8ed-2389-4812-9e17-f329888285e6")
			};
		}

		protected virtual EntitySchemaColumn CreateLanguageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("ce75e51b-1906-49f4-9b2f-12a60e74bbbf"),
				Name = @"Language",
				ReferenceSchemaUId = new Guid("2f96cb61-7e14-41e5-980a-bcb856edab51"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("eb3fb47a-d515-42d3-b9bd-4ebc26c70d8a"),
				ModifiedInSchemaUId = new Guid("eb3fb47a-d515-42d3-b9bd-4ebc26c70d8a"),
				CreatedInPackageId = new Guid("91d5b8ed-2389-4812-9e17-f329888285e6")
			};
		}

		protected virtual EntitySchemaColumn CreateIsHtmlBodyColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("c809fefc-91b7-4395-a561-7c7d440342b4"),
				Name = @"IsHtmlBody",
				CreatedInSchemaUId = new Guid("eb3fb47a-d515-42d3-b9bd-4ebc26c70d8a"),
				ModifiedInSchemaUId = new Guid("eb3fb47a-d515-42d3-b9bd-4ebc26c70d8a"),
				CreatedInPackageId = new Guid("91d5b8ed-2389-4812-9e17-f329888285e6")
			};
		}

		protected virtual EntitySchemaColumn CreateTemplateConfigColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("a6438ce3-71e3-4b77-9af2-a529133f9513"),
				Name = @"TemplateConfig",
				CreatedInSchemaUId = new Guid("eb3fb47a-d515-42d3-b9bd-4ebc26c70d8a"),
				ModifiedInSchemaUId = new Guid("eb3fb47a-d515-42d3-b9bd-4ebc26c70d8a"),
				CreatedInPackageId = new Guid("91d5b8ed-2389-4812-9e17-f329888285e6")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new EmailTemplateLang(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new EmailTemplateLang_EmailTemplateEventsProcess(userConnection);
		}

		public override object Clone() {
			return new EmailTemplateLangSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new EmailTemplateLangSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("eb3fb47a-d515-42d3-b9bd-4ebc26c70d8a"));
		}

		#endregion

	}

	#endregion

	#region Class: EmailTemplateLang

	/// <summary>
	/// Email template localization.
	/// </summary>
	public class EmailTemplateLang : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public EmailTemplateLang(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "EmailTemplateLang";
		}

		public EmailTemplateLang(EmailTemplateLang source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid EmailTemplateId {
			get {
				return GetTypedColumnValue<Guid>("EmailTemplateId");
			}
			set {
				SetColumnValue("EmailTemplateId", value);
				_emailTemplate = null;
			}
		}

		/// <exclude/>
		public string EmailTemplateName {
			get {
				return GetTypedColumnValue<string>("EmailTemplateName");
			}
			set {
				SetColumnValue("EmailTemplateName", value);
				if (_emailTemplate != null) {
					_emailTemplate.Name = value;
				}
			}
		}

		private EmailTemplate _emailTemplate;
		/// <summary>
		/// Email template.
		/// </summary>
		public EmailTemplate EmailTemplate {
			get {
				return _emailTemplate ??
					(_emailTemplate = LookupColumnEntities.GetEntity("EmailTemplate") as EmailTemplate);
			}
		}

		/// <summary>
		/// Email subject.
		/// </summary>
		public string Subject {
			get {
				return GetTypedColumnValue<string>("Subject");
			}
			set {
				SetColumnValue("Subject", value);
			}
		}

		/// <summary>
		/// Body.
		/// </summary>
		public string Body {
			get {
				return GetTypedColumnValue<string>("Body");
			}
			set {
				SetColumnValue("Body", value);
			}
		}

		/// <exclude/>
		public Guid LanguageId {
			get {
				return GetTypedColumnValue<Guid>("LanguageId");
			}
			set {
				SetColumnValue("LanguageId", value);
				_language = null;
			}
		}

		/// <exclude/>
		public string LanguageName {
			get {
				return GetTypedColumnValue<string>("LanguageName");
			}
			set {
				SetColumnValue("LanguageName", value);
				if (_language != null) {
					_language.Name = value;
				}
			}
		}

		private SysLanguage _language;
		/// <summary>
		/// Template language.
		/// </summary>
		public SysLanguage Language {
			get {
				return _language ??
					(_language = LookupColumnEntities.GetEntity("Language") as SysLanguage);
			}
		}

		/// <summary>
		/// HTML-formatted body.
		/// </summary>
		public bool IsHtmlBody {
			get {
				return GetTypedColumnValue<bool>("IsHtmlBody");
			}
			set {
				SetColumnValue("IsHtmlBody", value);
			}
		}

		/// <summary>
		/// Template config.
		/// </summary>
		public string TemplateConfig {
			get {
				return GetTypedColumnValue<string>("TemplateConfig");
			}
			set {
				SetColumnValue("TemplateConfig", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new EmailTemplateLang_EmailTemplateEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("EmailTemplateLangDeleted", e);
			Validating += (s, e) => ThrowEvent("EmailTemplateLangValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new EmailTemplateLang(this);
		}

		#endregion

	}

	#endregion

	#region Class: EmailTemplateLang_EmailTemplateEventsProcess

	/// <exclude/>
	public partial class EmailTemplateLang_EmailTemplateEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : EmailTemplateLang
	{

		public EmailTemplateLang_EmailTemplateEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "EmailTemplateLang_EmailTemplateEventsProcess";
			SchemaUId = new Guid("eb3fb47a-d515-42d3-b9bd-4ebc26c70d8a");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("eb3fb47a-d515-42d3-b9bd-4ebc26c70d8a");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: EmailTemplateLang_EmailTemplateEventsProcess

	/// <exclude/>
	public class EmailTemplateLang_EmailTemplateEventsProcess : EmailTemplateLang_EmailTemplateEventsProcess<EmailTemplateLang>
	{

		public EmailTemplateLang_EmailTemplateEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: EmailTemplateLang_EmailTemplateEventsProcess

	public partial class EmailTemplateLang_EmailTemplateEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: EmailTemplateLangEventsProcess

	/// <exclude/>
	public class EmailTemplateLangEventsProcess : EmailTemplateLang_EmailTemplateEventsProcess
	{

		public EmailTemplateLangEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

