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

	#region Class: PushNotificationServiceSchema

	/// <exclude/>
	public class PushNotificationServiceSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public PushNotificationServiceSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public PushNotificationServiceSchema(PushNotificationServiceSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public PushNotificationServiceSchema(PushNotificationServiceSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("823395a1-42be-4826-ad71-0ab38f575d57");
			RealUId = new Guid("823395a1-42be-4826-ad71-0ab38f575d57");
			Name = "PushNotificationService";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("62eca4a1-acc6-4a36-b0ab-f43c90a8a369");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("86b64869-43ab-462a-a1d0-ce1c27fcd07d")) == null) {
				Columns.Add(CreateNameColumn());
			}
			if (Columns.FindByUId(new Guid("2c07fa2c-d664-4638-9c43-ae6a1ae89678")) == null) {
				Columns.Add(CreateSettingsColumn());
			}
			if (Columns.FindByUId(new Guid("8a8fad30-c514-493f-8b0b-01d2aca7f667")) == null) {
				Columns.Add(CreateEnabledColumn());
			}
			if (Columns.FindByUId(new Guid("6d98a794-2938-4d30-8095-f9cbec57705f")) == null) {
				Columns.Add(CreateClassNameColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("86b64869-43ab-462a-a1d0-ce1c27fcd07d"),
				Name = @"Name",
				CreatedInSchemaUId = new Guid("823395a1-42be-4826-ad71-0ab38f575d57"),
				ModifiedInSchemaUId = new Guid("823395a1-42be-4826-ad71-0ab38f575d57"),
				CreatedInPackageId = new Guid("62eca4a1-acc6-4a36-b0ab-f43c90a8a369")
			};
		}

		protected virtual EntitySchemaColumn CreateSettingsColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("2c07fa2c-d664-4638-9c43-ae6a1ae89678"),
				Name = @"Settings",
				CreatedInSchemaUId = new Guid("823395a1-42be-4826-ad71-0ab38f575d57"),
				ModifiedInSchemaUId = new Guid("823395a1-42be-4826-ad71-0ab38f575d57"),
				CreatedInPackageId = new Guid("62eca4a1-acc6-4a36-b0ab-f43c90a8a369")
			};
		}

		protected virtual EntitySchemaColumn CreateEnabledColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("8a8fad30-c514-493f-8b0b-01d2aca7f667"),
				Name = @"Enabled",
				CreatedInSchemaUId = new Guid("823395a1-42be-4826-ad71-0ab38f575d57"),
				ModifiedInSchemaUId = new Guid("823395a1-42be-4826-ad71-0ab38f575d57"),
				CreatedInPackageId = new Guid("62eca4a1-acc6-4a36-b0ab-f43c90a8a369")
			};
		}

		protected virtual EntitySchemaColumn CreateClassNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("6d98a794-2938-4d30-8095-f9cbec57705f"),
				Name = @"ClassName",
				CreatedInSchemaUId = new Guid("823395a1-42be-4826-ad71-0ab38f575d57"),
				ModifiedInSchemaUId = new Guid("823395a1-42be-4826-ad71-0ab38f575d57"),
				CreatedInPackageId = new Guid("62eca4a1-acc6-4a36-b0ab-f43c90a8a369")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new PushNotificationService(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new PushNotificationService_NUIEventsProcess(userConnection);
		}

		public override object Clone() {
			return new PushNotificationServiceSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new PushNotificationServiceSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("823395a1-42be-4826-ad71-0ab38f575d57"));
		}

		#endregion

	}

	#endregion

	#region Class: PushNotificationService

	/// <summary>
	/// Push notification service.
	/// </summary>
	public class PushNotificationService : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public PushNotificationService(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "PushNotificationService";
		}

		public PushNotificationService(PushNotificationService source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Name.
		/// </summary>
		public string Name {
			get {
				return GetTypedColumnValue<string>("Name");
			}
			set {
				SetColumnValue("Name", value);
			}
		}

		/// <summary>
		/// Settings.
		/// </summary>
		public string Settings {
			get {
				return GetTypedColumnValue<string>("Settings");
			}
			set {
				SetColumnValue("Settings", value);
			}
		}

		/// <summary>
		/// Enabled.
		/// </summary>
		public bool Enabled {
			get {
				return GetTypedColumnValue<bool>("Enabled");
			}
			set {
				SetColumnValue("Enabled", value);
			}
		}

		/// <summary>
		/// ClassName.
		/// </summary>
		public string ClassName {
			get {
				return GetTypedColumnValue<string>("ClassName");
			}
			set {
				SetColumnValue("ClassName", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new PushNotificationService_NUIEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("PushNotificationServiceDeleted", e);
			Validating += (s, e) => ThrowEvent("PushNotificationServiceValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new PushNotificationService(this);
		}

		#endregion

	}

	#endregion

	#region Class: PushNotificationService_NUIEventsProcess

	/// <exclude/>
	public partial class PushNotificationService_NUIEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : PushNotificationService
	{

		public PushNotificationService_NUIEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "PushNotificationService_NUIEventsProcess";
			SchemaUId = new Guid("823395a1-42be-4826-ad71-0ab38f575d57");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("823395a1-42be-4826-ad71-0ab38f575d57");
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

	#region Class: PushNotificationService_NUIEventsProcess

	/// <exclude/>
	public class PushNotificationService_NUIEventsProcess : PushNotificationService_NUIEventsProcess<PushNotificationService>
	{

		public PushNotificationService_NUIEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: PushNotificationService_NUIEventsProcess

	public partial class PushNotificationService_NUIEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: PushNotificationServiceEventsProcess

	/// <exclude/>
	public class PushNotificationServiceEventsProcess : PushNotificationService_NUIEventsProcess
	{

		public PushNotificationServiceEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

