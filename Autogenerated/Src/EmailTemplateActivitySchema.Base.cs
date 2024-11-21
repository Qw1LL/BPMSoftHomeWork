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

	#region Class: EmailTemplateActivitySchema

	/// <exclude/>
	public class EmailTemplateActivitySchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public EmailTemplateActivitySchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public EmailTemplateActivitySchema(EmailTemplateActivitySchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public EmailTemplateActivitySchema(EmailTemplateActivitySchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("e725b7b3-8623-4990-9854-d75b5f43a660");
			RealUId = new Guid("e725b7b3-8623-4990-9854-d75b5f43a660");
			Name = "EmailTemplateActivity";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("dd9ce9b5-566f-4853-b4f3-e5089971b14a")) == null) {
				Columns.Add(CreateEmailTemplateColumn());
			}
			if (Columns.FindByUId(new Guid("ad70594f-20fa-4f6b-81ed-2a9dc68491a5")) == null) {
				Columns.Add(CreateActivityColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateEmailTemplateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("dd9ce9b5-566f-4853-b4f3-e5089971b14a"),
				Name = @"EmailTemplate",
				ReferenceSchemaUId = new Guid("93030575-f70f-4041-902e-c4badaf62c63"),
				CreatedInSchemaUId = new Guid("e725b7b3-8623-4990-9854-d75b5f43a660"),
				ModifiedInSchemaUId = new Guid("e725b7b3-8623-4990-9854-d75b5f43a660"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateActivityColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("ad70594f-20fa-4f6b-81ed-2a9dc68491a5"),
				Name = @"Activity",
				ReferenceSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				CreatedInSchemaUId = new Guid("e725b7b3-8623-4990-9854-d75b5f43a660"),
				ModifiedInSchemaUId = new Guid("e725b7b3-8623-4990-9854-d75b5f43a660"),
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
			return new EmailTemplateActivity(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new EmailTemplateActivity_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new EmailTemplateActivitySchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new EmailTemplateActivitySchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("e725b7b3-8623-4990-9854-d75b5f43a660"));
		}

		#endregion

	}

	#endregion

	#region Class: EmailTemplateActivity

	/// <summary>
	/// Connection between email template and activity.
	/// </summary>
	public class EmailTemplateActivity : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public EmailTemplateActivity(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "EmailTemplateActivity";
		}

		public EmailTemplateActivity(EmailTemplateActivity source)
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

		/// <exclude/>
		public Guid ActivityId {
			get {
				return GetTypedColumnValue<Guid>("ActivityId");
			}
			set {
				SetColumnValue("ActivityId", value);
				_activity = null;
			}
		}

		/// <exclude/>
		public string ActivityTitle {
			get {
				return GetTypedColumnValue<string>("ActivityTitle");
			}
			set {
				SetColumnValue("ActivityTitle", value);
				if (_activity != null) {
					_activity.Title = value;
				}
			}
		}

		private Activity _activity;
		/// <summary>
		/// Activity.
		/// </summary>
		public Activity Activity {
			get {
				return _activity ??
					(_activity = LookupColumnEntities.GetEntity("Activity") as Activity);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new EmailTemplateActivity_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("EmailTemplateActivityDeleted", e);
			Deleting += (s, e) => ThrowEvent("EmailTemplateActivityDeleting", e);
			Inserted += (s, e) => ThrowEvent("EmailTemplateActivityInserted", e);
			Inserting += (s, e) => ThrowEvent("EmailTemplateActivityInserting", e);
			Saved += (s, e) => ThrowEvent("EmailTemplateActivitySaved", e);
			Saving += (s, e) => ThrowEvent("EmailTemplateActivitySaving", e);
			Validating += (s, e) => ThrowEvent("EmailTemplateActivityValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new EmailTemplateActivity(this);
		}

		#endregion

	}

	#endregion

	#region Class: EmailTemplateActivity_BaseEventsProcess

	/// <exclude/>
	public partial class EmailTemplateActivity_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : EmailTemplateActivity
	{

		public EmailTemplateActivity_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "EmailTemplateActivity_BaseEventsProcess";
			SchemaUId = new Guid("e725b7b3-8623-4990-9854-d75b5f43a660");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("e725b7b3-8623-4990-9854-d75b5f43a660");
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

	#region Class: EmailTemplateActivity_BaseEventsProcess

	/// <exclude/>
	public class EmailTemplateActivity_BaseEventsProcess : EmailTemplateActivity_BaseEventsProcess<EmailTemplateActivity>
	{

		public EmailTemplateActivity_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: EmailTemplateActivity_BaseEventsProcess

	public partial class EmailTemplateActivity_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: EmailTemplateActivityEventsProcess

	/// <exclude/>
	public class EmailTemplateActivityEventsProcess : EmailTemplateActivity_BaseEventsProcess
	{

		public EmailTemplateActivityEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

