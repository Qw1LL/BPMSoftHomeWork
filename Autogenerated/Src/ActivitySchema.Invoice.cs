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
	using BPMSoft.Core.Store;
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
	using System.Text;
	using System.Text.RegularExpressions;
	using System.Web;

	#region Class: Activity_Invoice_BPMSoftSchema

	/// <exclude/>
	public class Activity_Invoice_BPMSoftSchema : BPMSoft.Configuration.Activity_CMDB_BPMSoftSchema
	{

		#region Constructors: Public

		public Activity_Invoice_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public Activity_Invoice_BPMSoftSchema(Activity_Invoice_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public Activity_Invoice_BPMSoftSchema(Activity_Invoice_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("7b272db6-05e4-4667-982a-38d6b4c35dd1");
			Name = "Activity_Invoice_BPMSoft";
			ParentSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89");
			ExtendParent = true;
			CreatedInPackageId = new Guid("eceefca3-5a45-46fe-8b09-e72ef0cd9d7e");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("8da997ed-5182-472b-8818-6d146ca6b156")) == null) {
				Columns.Add(CreateInvoiceColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateInvoiceColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("8da997ed-5182-472b-8818-6d146ca6b156"),
				Name = @"Invoice",
				ReferenceSchemaUId = new Guid("bfb313dd-bb55-4e1b-8e42-3d346e0da7c5"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("7b272db6-05e4-4667-982a-38d6b4c35dd1"),
				ModifiedInSchemaUId = new Guid("7b272db6-05e4-4667-982a-38d6b4c35dd1"),
				CreatedInPackageId = new Guid("eceefca3-5a45-46fe-8b09-e72ef0cd9d7e")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new Activity_Invoice_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Activity_InvoiceEventsProcess(userConnection);
		}

		public override object Clone() {
			return new Activity_Invoice_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new Activity_Invoice_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("7b272db6-05e4-4667-982a-38d6b4c35dd1"));
		}

		#endregion

	}

	#endregion

	#region Class: Activity_Invoice_BPMSoft

	/// <summary>
	/// Активность.
	/// </summary>
	public class Activity_Invoice_BPMSoft : BPMSoft.Configuration.Activity_CMDB_BPMSoft
	{

		#region Constructors: Public

		public Activity_Invoice_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Activity_Invoice_BPMSoft";
		}

		public Activity_Invoice_BPMSoft(Activity_Invoice_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid InvoiceId {
			get {
				return GetTypedColumnValue<Guid>("InvoiceId");
			}
			set {
				SetColumnValue("InvoiceId", value);
				_invoice = null;
			}
		}

		/// <exclude/>
		public string InvoiceNumber {
			get {
				return GetTypedColumnValue<string>("InvoiceNumber");
			}
			set {
				SetColumnValue("InvoiceNumber", value);
				if (_invoice != null) {
					_invoice.Number = value;
				}
			}
		}

		private Invoice _invoice;
		/// <summary>
		/// Счет.
		/// </summary>
		public Invoice Invoice {
			get {
				return _invoice ??
					(_invoice = LookupColumnEntities.GetEntity("Invoice") as Invoice);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Activity_InvoiceEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("Activity_Invoice_BPMSoftDeleted", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new Activity_Invoice_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: Activity_InvoiceEventsProcess

	/// <exclude/>
	public partial class Activity_InvoiceEventsProcess<TEntity> : BPMSoft.Configuration.Activity_CMDBEventsProcess<TEntity> where TEntity : Activity_Invoice_BPMSoft
	{

		public Activity_InvoiceEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Activity_InvoiceEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("7b272db6-05e4-4667-982a-38d6b4c35dd1");
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

	#region Class: Activity_InvoiceEventsProcess

	/// <exclude/>
	public class Activity_InvoiceEventsProcess : Activity_InvoiceEventsProcess<Activity_Invoice_BPMSoft>
	{

		public Activity_InvoiceEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: Activity_InvoiceEventsProcess

	public partial class Activity_InvoiceEventsProcess<TEntity>
	{

		#region Methods: Public

		public override void PrepereSynchronizeSubjectRemindingUserTask(SynchronizeSubjectRemindingUserTask userTask, Guid contact, DateTime remindTime, bool active, Guid source) {
			base.PrepereSynchronizeSubjectRemindingUserTask(userTask, contact, remindTime, active, source);
			bool isFeatureEnabled = FeatureUtilities.GetIsFeatureEnabled(UserConnection, "NotificationV2");
			if (isFeatureEnabled && active) {
				IRemindingTextFormer textFormer = ClassFactory.Get<ActivityRemindingTextFormer>(
					new ConstructorArgument("userConnection", UserConnection));
				string accountName = GetLookupDisplayColumnValue(Entity, "Account");
				string contactName = GetLookupDisplayColumnValue(Entity, "Contact");
				string title = Entity.GetTypedColumnValue<string>("Title");
				userTask.SubjectCaption = textFormer.GetBody(new Dictionary<string, object> {
					{"AccountName", accountName},
					{"ContactName", contactName},
					{"Title", title}
				});
				userTask.PopupTitle = textFormer.GetTitle(new Dictionary<string, object>());
			}
		}

		#endregion

	}

	#endregion

}

