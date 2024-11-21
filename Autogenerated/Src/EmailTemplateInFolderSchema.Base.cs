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

	#region Class: EmailTemplateInFolderSchema

	/// <exclude/>
	public class EmailTemplateInFolderSchema : BPMSoft.Configuration.BaseItemInFolderSchema
	{

		#region Constructors: Public

		public EmailTemplateInFolderSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public EmailTemplateInFolderSchema(EmailTemplateInFolderSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public EmailTemplateInFolderSchema(EmailTemplateInFolderSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("0fc644a8-3248-45df-b30c-113d4ada2bcf");
			RealUId = new Guid("0fc644a8-3248-45df-b30c-113d4ada2bcf");
			Name = "EmailTemplateInFolder";
			ParentSchemaUId = new Guid("4f63bafb-e9e7-4082-b92e-66b97c14017c");
			ExtendParent = false;
			CreatedInPackageId = new Guid("a47bce9d-aced-4280-8524-3a778ba32af0");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("f3a31482-c390-4961-bcaf-e7af5545ffb1")) == null) {
				Columns.Add(CreateEmailTemplateColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("0fc644a8-3248-45df-b30c-113d4ada2bcf");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("0fc644a8-3248-45df-b30c-113d4ada2bcf");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("0fc644a8-3248-45df-b30c-113d4ada2bcf");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("0fc644a8-3248-45df-b30c-113d4ada2bcf");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("0fc644a8-3248-45df-b30c-113d4ada2bcf");
			return column;
		}

		protected override EntitySchemaColumn CreateFolderColumn() {
			EntitySchemaColumn column = base.CreateFolderColumn();
			column.ReferenceSchemaUId = new Guid("5614039e-1c38-4850-b9ca-138c8ab4d7ea");
			column.ColumnValueName = @"FolderId";
			column.DisplayColumnValueName = @"FolderName";
			column.ModifiedInSchemaUId = new Guid("0fc644a8-3248-45df-b30c-113d4ada2bcf");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("0fc644a8-3248-45df-b30c-113d4ada2bcf");
			return column;
		}

		protected virtual EntitySchemaColumn CreateEmailTemplateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("f3a31482-c390-4961-bcaf-e7af5545ffb1"),
				Name = @"EmailTemplate",
				ReferenceSchemaUId = new Guid("93030575-f70f-4041-902e-c4badaf62c63"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsValueCloneable = false,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("0fc644a8-3248-45df-b30c-113d4ada2bcf"),
				ModifiedInSchemaUId = new Guid("0fc644a8-3248-45df-b30c-113d4ada2bcf"),
				CreatedInPackageId = new Guid("a47bce9d-aced-4280-8524-3a778ba32af0")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new EmailTemplateInFolder(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new EmailTemplateInFolder_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new EmailTemplateInFolderSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new EmailTemplateInFolderSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("0fc644a8-3248-45df-b30c-113d4ada2bcf"));
		}

		#endregion

	}

	#endregion

	#region Class: EmailTemplateInFolder

	/// <summary>
	/// Email message template in Folder.
	/// </summary>
	public class EmailTemplateInFolder : BPMSoft.Configuration.BaseItemInFolder
	{

		#region Constructors: Public

		public EmailTemplateInFolder(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "EmailTemplateInFolder";
		}

		public EmailTemplateInFolder(EmailTemplateInFolder source)
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
		/// Email message template.
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
			var process = new EmailTemplateInFolder_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new EmailTemplateInFolder(this);
		}

		#endregion

	}

	#endregion

	#region Class: EmailTemplateInFolder_BaseEventsProcess

	/// <exclude/>
	public partial class EmailTemplateInFolder_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseItemInFolder_BaseEventsProcess<TEntity> where TEntity : EmailTemplateInFolder
	{

		public EmailTemplateInFolder_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "EmailTemplateInFolder_BaseEventsProcess";
			SchemaUId = new Guid("0fc644a8-3248-45df-b30c-113d4ada2bcf");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("0fc644a8-3248-45df-b30c-113d4ada2bcf");
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

	#region Class: EmailTemplateInFolder_BaseEventsProcess

	/// <exclude/>
	public class EmailTemplateInFolder_BaseEventsProcess : EmailTemplateInFolder_BaseEventsProcess<EmailTemplateInFolder>
	{

		public EmailTemplateInFolder_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: EmailTemplateInFolder_BaseEventsProcess

	public partial class EmailTemplateInFolder_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: EmailTemplateInFolderEventsProcess

	/// <exclude/>
	public class EmailTemplateInFolderEventsProcess : EmailTemplateInFolder_BaseEventsProcess
	{

		public EmailTemplateInFolderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

