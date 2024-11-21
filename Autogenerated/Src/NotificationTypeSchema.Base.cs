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

	#region Class: NotificationTypeSchema

	/// <exclude/>
	public class NotificationTypeSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public NotificationTypeSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public NotificationTypeSchema(NotificationTypeSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public NotificationTypeSchema(NotificationTypeSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("ef45b183-3adb-4b37-a099-8d28e9ee9b3a");
			RealUId = new Guid("ef45b183-3adb-4b37-a099-8d28e9ee9b3a");
			Name = "NotificationType";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("271744d8-d0f2-48d8-a4d0-e376f30523b7");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateNameColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("8da94426-6354-4e76-b1ba-62927cd8a68f"),
				Name = @"Name",
				CreatedInSchemaUId = new Guid("ef45b183-3adb-4b37-a099-8d28e9ee9b3a"),
				ModifiedInSchemaUId = new Guid("ef45b183-3adb-4b37-a099-8d28e9ee9b3a"),
				CreatedInPackageId = new Guid("271744d8-d0f2-48d8-a4d0-e376f30523b7")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new NotificationType(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new NotificationType_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new NotificationTypeSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new NotificationTypeSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ef45b183-3adb-4b37-a099-8d28e9ee9b3a"));
		}

		#endregion

	}

	#endregion

	#region Class: NotificationType

	/// <summary>
	/// Type of notifications.
	/// </summary>
	public class NotificationType : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public NotificationType(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "NotificationType";
		}

		public NotificationType(NotificationType source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Name.
		/// </summary>
		/// <remarks>
		/// Name of type.
		/// </remarks>
		public string Name {
			get {
				return GetTypedColumnValue<string>("Name");
			}
			set {
				SetColumnValue("Name", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new NotificationType_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("NotificationTypeDeleted", e);
			Validating += (s, e) => ThrowEvent("NotificationTypeValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new NotificationType(this);
		}

		#endregion

	}

	#endregion

	#region Class: NotificationType_BaseEventsProcess

	/// <exclude/>
	public partial class NotificationType_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : NotificationType
	{

		public NotificationType_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "NotificationType_BaseEventsProcess";
			SchemaUId = new Guid("ef45b183-3adb-4b37-a099-8d28e9ee9b3a");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("ef45b183-3adb-4b37-a099-8d28e9ee9b3a");
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

	#region Class: NotificationType_BaseEventsProcess

	/// <exclude/>
	public class NotificationType_BaseEventsProcess : NotificationType_BaseEventsProcess<NotificationType>
	{

		public NotificationType_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: NotificationType_BaseEventsProcess

	public partial class NotificationType_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: NotificationTypeEventsProcess

	/// <exclude/>
	public class NotificationTypeEventsProcess : NotificationType_BaseEventsProcess
	{

		public NotificationTypeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

