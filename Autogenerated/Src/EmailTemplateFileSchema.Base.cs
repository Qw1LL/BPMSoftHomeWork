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

	#region Class: EmailTemplateFileSchema

	/// <exclude/>
	public class EmailTemplateFileSchema : BPMSoft.Configuration.FileSchema
	{

		#region Constructors: Public

		public EmailTemplateFileSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public EmailTemplateFileSchema(EmailTemplateFileSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public EmailTemplateFileSchema(EmailTemplateFileSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("564f83f0-60f1-4da5-9d44-97fa61b3fbaf");
			RealUId = new Guid("564f83f0-60f1-4da5-9d44-97fa61b3fbaf");
			Name = "EmailTemplateFile";
			ParentSchemaUId = new Guid("556c5867-60a7-4456-aae1-a57a122bef70");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("69007759-6a70-4547-81f9-2d61339fb9ed")) == null) {
				Columns.Add(CreateEmailTemplateColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateEmailTemplateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("69007759-6a70-4547-81f9-2d61339fb9ed"),
				Name = @"EmailTemplate",
				ReferenceSchemaUId = new Guid("93030575-f70f-4041-902e-c4badaf62c63"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("564f83f0-60f1-4da5-9d44-97fa61b3fbaf"),
				ModifiedInSchemaUId = new Guid("564f83f0-60f1-4da5-9d44-97fa61b3fbaf"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new EmailTemplateFile(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new EmailTemplateFile_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new EmailTemplateFileSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new EmailTemplateFileSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("564f83f0-60f1-4da5-9d44-97fa61b3fbaf"));
		}

		#endregion

	}

	#endregion

	#region Class: EmailTemplateFile

	/// <summary>
	/// Email template attachment.
	/// </summary>
	public class EmailTemplateFile : BPMSoft.Configuration.File
	{

		#region Constructors: Public

		public EmailTemplateFile(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "EmailTemplateFile";
		}

		public EmailTemplateFile(EmailTemplateFile source)
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

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new EmailTemplateFile_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("EmailTemplateFileDeleted", e);
			Inserting += (s, e) => ThrowEvent("EmailTemplateFileInserting", e);
			Updated += (s, e) => ThrowEvent("EmailTemplateFileUpdated", e);
			Validating += (s, e) => ThrowEvent("EmailTemplateFileValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new EmailTemplateFile(this);
		}

		#endregion

	}

	#endregion

	#region Class: EmailTemplateFile_BaseEventsProcess

	/// <exclude/>
	public partial class EmailTemplateFile_BaseEventsProcess<TEntity> : BPMSoft.Configuration.File_PRMPortalEventsProcess<TEntity> where TEntity : EmailTemplateFile
	{

		public EmailTemplateFile_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "EmailTemplateFile_BaseEventsProcess";
			SchemaUId = new Guid("564f83f0-60f1-4da5-9d44-97fa61b3fbaf");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("564f83f0-60f1-4da5-9d44-97fa61b3fbaf");
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

	#region Class: EmailTemplateFile_BaseEventsProcess

	/// <exclude/>
	public class EmailTemplateFile_BaseEventsProcess : EmailTemplateFile_BaseEventsProcess<EmailTemplateFile>
	{

		public EmailTemplateFile_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: EmailTemplateFile_BaseEventsProcess

	public partial class EmailTemplateFile_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: EmailTemplateFileEventsProcess

	/// <exclude/>
	public class EmailTemplateFileEventsProcess : EmailTemplateFile_BaseEventsProcess
	{

		public EmailTemplateFileEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

