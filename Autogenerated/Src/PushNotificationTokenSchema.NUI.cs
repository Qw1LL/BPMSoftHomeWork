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

	#region Class: PushNotificationTokenSchema

	/// <exclude/>
	public class PushNotificationTokenSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public PushNotificationTokenSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public PushNotificationTokenSchema(PushNotificationTokenSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public PushNotificationTokenSchema(PushNotificationTokenSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("fedf93e5-48af-4c6c-a612-53b86dd7cf69");
			RealUId = new Guid("fedf93e5-48af-4c6c-a612-53b86dd7cf69");
			Name = "PushNotificationToken";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("62eca4a1-acc6-4a36-b0ab-f43c90a8a369");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("d816bac6-25a3-4f80-8c30-d1f92b0c8d1a")) == null) {
				Columns.Add(CreateTokenColumn());
			}
			if (Columns.FindByUId(new Guid("09c047d0-45f6-4b9f-b086-021c540ebf2a")) == null) {
				Columns.Add(CreateServiceColumn());
			}
			if (Columns.FindByUId(new Guid("1b9fa52b-76b3-4822-87fb-4591cf585268")) == null) {
				Columns.Add(CreateSysAdminUnitColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateTokenColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("d816bac6-25a3-4f80-8c30-d1f92b0c8d1a"),
				Name = @"Token",
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("fedf93e5-48af-4c6c-a612-53b86dd7cf69"),
				ModifiedInSchemaUId = new Guid("fedf93e5-48af-4c6c-a612-53b86dd7cf69"),
				CreatedInPackageId = new Guid("62eca4a1-acc6-4a36-b0ab-f43c90a8a369")
			};
		}

		protected virtual EntitySchemaColumn CreateServiceColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("09c047d0-45f6-4b9f-b086-021c540ebf2a"),
				Name = @"Service",
				ReferenceSchemaUId = new Guid("823395a1-42be-4826-ad71-0ab38f575d57"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("fedf93e5-48af-4c6c-a612-53b86dd7cf69"),
				ModifiedInSchemaUId = new Guid("fedf93e5-48af-4c6c-a612-53b86dd7cf69"),
				CreatedInPackageId = new Guid("62eca4a1-acc6-4a36-b0ab-f43c90a8a369")
			};
		}

		protected virtual EntitySchemaColumn CreateSysAdminUnitColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("1b9fa52b-76b3-4822-87fb-4591cf585268"),
				Name = @"SysAdminUnit",
				ReferenceSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("fedf93e5-48af-4c6c-a612-53b86dd7cf69"),
				ModifiedInSchemaUId = new Guid("fedf93e5-48af-4c6c-a612-53b86dd7cf69"),
				CreatedInPackageId = new Guid("6ba26f98-9709-4408-98d0-761f0c4bf2aa")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new PushNotificationToken(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new PushNotificationToken_NUIEventsProcess(userConnection);
		}

		public override object Clone() {
			return new PushNotificationTokenSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new PushNotificationTokenSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("fedf93e5-48af-4c6c-a612-53b86dd7cf69"));
		}

		#endregion

	}

	#endregion

	#region Class: PushNotificationToken

	/// <summary>
	/// Push notification token.
	/// </summary>
	public class PushNotificationToken : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public PushNotificationToken(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "PushNotificationToken";
		}

		public PushNotificationToken(PushNotificationToken source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Token.
		/// </summary>
		public string Token {
			get {
				return GetTypedColumnValue<string>("Token");
			}
			set {
				SetColumnValue("Token", value);
			}
		}

		/// <exclude/>
		public Guid ServiceId {
			get {
				return GetTypedColumnValue<Guid>("ServiceId");
			}
			set {
				SetColumnValue("ServiceId", value);
				_service = null;
			}
		}

		private PushNotificationService _service;
		/// <summary>
		/// Service.
		/// </summary>
		public PushNotificationService Service {
			get {
				return _service ??
					(_service = LookupColumnEntities.GetEntity("Service") as PushNotificationService);
			}
		}

		/// <exclude/>
		public Guid SysAdminUnitId {
			get {
				return GetTypedColumnValue<Guid>("SysAdminUnitId");
			}
			set {
				SetColumnValue("SysAdminUnitId", value);
				_sysAdminUnit = null;
			}
		}

		/// <exclude/>
		public string SysAdminUnitName {
			get {
				return GetTypedColumnValue<string>("SysAdminUnitName");
			}
			set {
				SetColumnValue("SysAdminUnitName", value);
				if (_sysAdminUnit != null) {
					_sysAdminUnit.Name = value;
				}
			}
		}

		private SysAdminUnit _sysAdminUnit;
		/// <summary>
		/// SysAdminUnit.
		/// </summary>
		public SysAdminUnit SysAdminUnit {
			get {
				return _sysAdminUnit ??
					(_sysAdminUnit = LookupColumnEntities.GetEntity("SysAdminUnit") as SysAdminUnit);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new PushNotificationToken_NUIEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("PushNotificationTokenDeleted", e);
			Validating += (s, e) => ThrowEvent("PushNotificationTokenValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new PushNotificationToken(this);
		}

		#endregion

	}

	#endregion

	#region Class: PushNotificationToken_NUIEventsProcess

	/// <exclude/>
	public partial class PushNotificationToken_NUIEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : PushNotificationToken
	{

		public PushNotificationToken_NUIEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "PushNotificationToken_NUIEventsProcess";
			SchemaUId = new Guid("fedf93e5-48af-4c6c-a612-53b86dd7cf69");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("fedf93e5-48af-4c6c-a612-53b86dd7cf69");
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

	#region Class: PushNotificationToken_NUIEventsProcess

	/// <exclude/>
	public class PushNotificationToken_NUIEventsProcess : PushNotificationToken_NUIEventsProcess<PushNotificationToken>
	{

		public PushNotificationToken_NUIEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: PushNotificationToken_NUIEventsProcess

	public partial class PushNotificationToken_NUIEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: PushNotificationTokenEventsProcess

	/// <exclude/>
	public class PushNotificationTokenEventsProcess : PushNotificationToken_NUIEventsProcess
	{

		public PushNotificationTokenEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

