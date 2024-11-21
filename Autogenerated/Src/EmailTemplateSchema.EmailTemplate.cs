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

	#region Class: EmailTemplateSchema

	/// <exclude/>
	public class EmailTemplateSchema : BPMSoft.Configuration.EmailTemplate_Base_BPMSoftSchema
	{

		#region Constructors: Public

		public EmailTemplateSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public EmailTemplateSchema(EmailTemplateSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public EmailTemplateSchema(EmailTemplateSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("40f5736d-c37a-458a-8281-9ad1a30a2626");
			Name = "EmailTemplate";
			ParentSchemaUId = new Guid("93030575-f70f-4041-902e-c4badaf62c63");
			ExtendParent = true;
			CreatedInPackageId = new Guid("1e4ad1e5-2250-4ed2-b7a6-c8515fbf7a50");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("f73ea119-e10f-4db3-a89f-02b338f69444")) == null) {
				Columns.Add(CreateConfigTypeColumn());
			}
			if (Columns.FindByUId(new Guid("1fea7f02-7faa-4a8b-a1f9-ee4e05fef97d")) == null) {
				Columns.Add(CreatePreviewImageColumn());
			}
		}

		protected override EntitySchemaColumn CreateObjectColumn() {
			EntitySchemaColumn column = base.CreateObjectColumn();
			column.ModifiedInSchemaUId = new Guid("40f5736d-c37a-458a-8281-9ad1a30a2626");
			return column;
		}

		protected override EntitySchemaColumn CreateSendIndividualEmailColumn() {
			EntitySchemaColumn column = base.CreateSendIndividualEmailColumn();
			column.DefValue = new EntitySchemaColumnDef() {
				Source = EntitySchemaColumnDefSource.Const,
				ValueSource = @"e75ac3fe-be9b-4a01-87db-c7dffd354f8c"
			};
			column.ModifiedInSchemaUId = new Guid("40f5736d-c37a-458a-8281-9ad1a30a2626");
			return column;
		}

		protected override EntitySchemaColumn CreateTemplateConfigColumn() {
			EntitySchemaColumn column = base.CreateTemplateConfigColumn();
			column.IsLocalizable = false;
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("40f5736d-c37a-458a-8281-9ad1a30a2626");
			return column;
		}

		protected virtual EntitySchemaColumn CreateConfigTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("f73ea119-e10f-4db3-a89f-02b338f69444"),
				Name = @"ConfigType",
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("40f5736d-c37a-458a-8281-9ad1a30a2626"),
				ModifiedInSchemaUId = new Guid("40f5736d-c37a-458a-8281-9ad1a30a2626"),
				CreatedInPackageId = new Guid("575d1c0e-f3b6-4688-ab25-9f9b4dae2d69"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"0"
				}
			};
		}

		protected virtual EntitySchemaColumn CreatePreviewImageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("1fea7f02-7faa-4a8b-a1f9-ee4e05fef97d"),
				Name = @"PreviewImage",
				ReferenceSchemaUId = new Guid("93986bfe-2dbd-46bc-9bf9-d03dfefbf3b8"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("40f5736d-c37a-458a-8281-9ad1a30a2626"),
				ModifiedInSchemaUId = new Guid("40f5736d-c37a-458a-8281-9ad1a30a2626"),
				CreatedInPackageId = new Guid("575d1c0e-f3b6-4688-ab25-9f9b4dae2d69")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new EmailTemplate(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new EmailTemplate_EmailTemplateEventsProcess(userConnection);
		}

		public override object Clone() {
			return new EmailTemplateSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new EmailTemplateSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("40f5736d-c37a-458a-8281-9ad1a30a2626"));
		}

		#endregion

	}

	#endregion

	#region Class: EmailTemplate

	/// <summary>
	/// Message template.
	/// </summary>
	public class EmailTemplate : BPMSoft.Configuration.EmailTemplate_Base_BPMSoft
	{

		#region Constructors: Public

		public EmailTemplate(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "EmailTemplate";
		}

		public EmailTemplate(EmailTemplate source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Config type.
		/// </summary>
		public int ConfigType {
			get {
				return GetTypedColumnValue<int>("ConfigType");
			}
			set {
				SetColumnValue("ConfigType", value);
			}
		}

		/// <exclude/>
		public Guid PreviewImageId {
			get {
				return GetTypedColumnValue<Guid>("PreviewImageId");
			}
			set {
				SetColumnValue("PreviewImageId", value);
				_previewImage = null;
			}
		}

		/// <exclude/>
		public string PreviewImageName {
			get {
				return GetTypedColumnValue<string>("PreviewImageName");
			}
			set {
				SetColumnValue("PreviewImageName", value);
				if (_previewImage != null) {
					_previewImage.Name = value;
				}
			}
		}

		private SysImage _previewImage;
		/// <summary>
		/// Preview image.
		/// </summary>
		public SysImage PreviewImage {
			get {
				return _previewImage ??
					(_previewImage = LookupColumnEntities.GetEntity("PreviewImage") as SysImage);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new EmailTemplate_EmailTemplateEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("EmailTemplateDeleted", e);
			Validating += (s, e) => ThrowEvent("EmailTemplateValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new EmailTemplate(this);
		}

		#endregion

	}

	#endregion

	#region Class: EmailTemplate_EmailTemplateEventsProcess

	/// <exclude/>
	public partial class EmailTemplate_EmailTemplateEventsProcess<TEntity> : BPMSoft.Configuration.EmailTemplate_BaseEventsProcess<TEntity> where TEntity : EmailTemplate
	{

		public EmailTemplate_EmailTemplateEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "EmailTemplate_EmailTemplateEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("40f5736d-c37a-458a-8281-9ad1a30a2626");
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

	#region Class: EmailTemplate_EmailTemplateEventsProcess

	/// <exclude/>
	public class EmailTemplate_EmailTemplateEventsProcess : EmailTemplate_EmailTemplateEventsProcess<EmailTemplate>
	{

		public EmailTemplate_EmailTemplateEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: EmailTemplate_EmailTemplateEventsProcess

	public partial class EmailTemplate_EmailTemplateEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: EmailTemplateEventsProcess

	/// <exclude/>
	public class EmailTemplateEventsProcess : EmailTemplate_EmailTemplateEventsProcess
	{

		public EmailTemplateEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

