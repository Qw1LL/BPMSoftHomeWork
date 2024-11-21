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

	#region Class: EmailFolderColumnValuesSettingSchema

	/// <exclude/>
	public class EmailFolderColumnValuesSettingSchema : BPMSoft.Configuration.EmailFolderColumnValuesSetting_Invoice_BPMSoftSchema
	{

		#region Constructors: Public

		public EmailFolderColumnValuesSettingSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public EmailFolderColumnValuesSettingSchema(EmailFolderColumnValuesSettingSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public EmailFolderColumnValuesSettingSchema(EmailFolderColumnValuesSettingSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("fc6c7209-dfa0-46fd-975f-dc7686282613");
			Name = "EmailFolderColumnValuesSetting";
			ParentSchemaUId = new Guid("77ffb765-d7ad-4f91-9027-92cdf97b4c1f");
			ExtendParent = true;
			CreatedInPackageId = new Guid("ac4f354d-348b-46bb-8e82-8cde7d879f9f");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("e8280c5b-8590-4a0e-940b-9d73025026cf")) == null) {
				Columns.Add(CreateDocumentColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateDocumentColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("e8280c5b-8590-4a0e-940b-9d73025026cf"),
				Name = @"Document",
				ReferenceSchemaUId = new Guid("8b33b6b2-19f7-4222-9161-b4054b3fbb09"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("fc6c7209-dfa0-46fd-975f-dc7686282613"),
				ModifiedInSchemaUId = new Guid("fc6c7209-dfa0-46fd-975f-dc7686282613"),
				CreatedInPackageId = new Guid("ac4f354d-348b-46bb-8e82-8cde7d879f9f")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new EmailFolderColumnValuesSetting(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new EmailFolderColumnValuesSetting_DocumentEventsProcess(userConnection);
		}

		public override object Clone() {
			return new EmailFolderColumnValuesSettingSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new EmailFolderColumnValuesSettingSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("fc6c7209-dfa0-46fd-975f-dc7686282613"));
		}

		#endregion

	}

	#endregion

	#region Class: EmailFolderColumnValuesSetting

	/// <summary>
	/// Настройка значений полей в группе e-mail.
	/// </summary>
	public class EmailFolderColumnValuesSetting : BPMSoft.Configuration.EmailFolderColumnValuesSetting_Invoice_BPMSoft
	{

		#region Constructors: Public

		public EmailFolderColumnValuesSetting(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "EmailFolderColumnValuesSetting";
		}

		public EmailFolderColumnValuesSetting(EmailFolderColumnValuesSetting source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid DocumentId {
			get {
				return GetTypedColumnValue<Guid>("DocumentId");
			}
			set {
				SetColumnValue("DocumentId", value);
				_document = null;
			}
		}

		/// <exclude/>
		public string DocumentNumber {
			get {
				return GetTypedColumnValue<string>("DocumentNumber");
			}
			set {
				SetColumnValue("DocumentNumber", value);
				if (_document != null) {
					_document.Number = value;
				}
			}
		}

		private Document _document;
		/// <summary>
		/// Документ.
		/// </summary>
		public Document Document {
			get {
				return _document ??
					(_document = LookupColumnEntities.GetEntity("Document") as Document);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new EmailFolderColumnValuesSetting_DocumentEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("EmailFolderColumnValuesSettingDeleted", e);
			Validating += (s, e) => ThrowEvent("EmailFolderColumnValuesSettingValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new EmailFolderColumnValuesSetting(this);
		}

		#endregion

	}

	#endregion

	#region Class: EmailFolderColumnValuesSetting_DocumentEventsProcess

	/// <exclude/>
	public partial class EmailFolderColumnValuesSetting_DocumentEventsProcess<TEntity> : BPMSoft.Configuration.EmailFolderColumnValuesSetting_InvoiceEventsProcess<TEntity> where TEntity : EmailFolderColumnValuesSetting
	{

		public EmailFolderColumnValuesSetting_DocumentEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "EmailFolderColumnValuesSetting_DocumentEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("fc6c7209-dfa0-46fd-975f-dc7686282613");
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

	#region Class: EmailFolderColumnValuesSetting_DocumentEventsProcess

	/// <exclude/>
	public class EmailFolderColumnValuesSetting_DocumentEventsProcess : EmailFolderColumnValuesSetting_DocumentEventsProcess<EmailFolderColumnValuesSetting>
	{

		public EmailFolderColumnValuesSetting_DocumentEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: EmailFolderColumnValuesSetting_DocumentEventsProcess

	public partial class EmailFolderColumnValuesSetting_DocumentEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: EmailFolderColumnValuesSettingEventsProcess

	/// <exclude/>
	public class EmailFolderColumnValuesSettingEventsProcess : EmailFolderColumnValuesSetting_DocumentEventsProcess
	{

		public EmailFolderColumnValuesSettingEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

