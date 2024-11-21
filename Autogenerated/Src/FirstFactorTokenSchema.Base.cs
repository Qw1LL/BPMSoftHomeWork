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

	#region Class: FirstFactorTokenSchema

	/// <exclude/>
	public class FirstFactorTokenSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public FirstFactorTokenSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public FirstFactorTokenSchema(FirstFactorTokenSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public FirstFactorTokenSchema(FirstFactorTokenSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("78e1015a-9dc6-46dd-ac13-0395c7791bb4");
			RealUId = new Guid("78e1015a-9dc6-46dd-ac13-0395c7791bb4");
			Name = "FirstFactorToken";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("13b9c287-707b-4588-95dc-f40709dfb679");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("8e355e5e-b135-9624-afdb-0b26687ae6f2")) == null) {
				Columns.Add(CreateTokenValueColumn());
			}
			if (Columns.FindByUId(new Guid("dc6a8eb6-9d4d-7bc7-39a0-88a5d72cb7f2")) == null) {
				Columns.Add(CreateSysAdminUnitColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateTokenValueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("8e355e5e-b135-9624-afdb-0b26687ae6f2"),
				Name = @"TokenValue",
				CreatedInSchemaUId = new Guid("78e1015a-9dc6-46dd-ac13-0395c7791bb4"),
				ModifiedInSchemaUId = new Guid("78e1015a-9dc6-46dd-ac13-0395c7791bb4"),
				CreatedInPackageId = new Guid("13b9c287-707b-4588-95dc-f40709dfb679")
			};
		}

		protected virtual EntitySchemaColumn CreateSysAdminUnitColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("dc6a8eb6-9d4d-7bc7-39a0-88a5d72cb7f2"),
				Name = @"SysAdminUnit",
				ReferenceSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("78e1015a-9dc6-46dd-ac13-0395c7791bb4"),
				ModifiedInSchemaUId = new Guid("78e1015a-9dc6-46dd-ac13-0395c7791bb4"),
				CreatedInPackageId = new Guid("13b9c287-707b-4588-95dc-f40709dfb679")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new FirstFactorToken(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new FirstFactorToken_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new FirstFactorTokenSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new FirstFactorTokenSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("78e1015a-9dc6-46dd-ac13-0395c7791bb4"));
		}

		#endregion

	}

	#endregion

	#region Class: FirstFactorToken

	/// <summary>
	/// FirstFactorToken.
	/// </summary>
	public class FirstFactorToken : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public FirstFactorToken(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "FirstFactorToken";
		}

		public FirstFactorToken(FirstFactorToken source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// TokenValue.
		/// </summary>
		public Guid TokenValue {
			get {
				return GetTypedColumnValue<Guid>("TokenValue");
			}
			set {
				SetColumnValue("TokenValue", value);
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
			var process = new FirstFactorToken_BaseEventsProcess(UserConnection);
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
			return new FirstFactorToken(this);
		}

		#endregion

	}

	#endregion

	#region Class: FirstFactorToken_BaseEventsProcess

	/// <exclude/>
	public partial class FirstFactorToken_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : FirstFactorToken
	{

		public FirstFactorToken_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "FirstFactorToken_BaseEventsProcess";
			SchemaUId = new Guid("78e1015a-9dc6-46dd-ac13-0395c7791bb4");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("78e1015a-9dc6-46dd-ac13-0395c7791bb4");
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

	#region Class: FirstFactorToken_BaseEventsProcess

	/// <exclude/>
	public class FirstFactorToken_BaseEventsProcess : FirstFactorToken_BaseEventsProcess<FirstFactorToken>
	{

		public FirstFactorToken_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: FirstFactorToken_BaseEventsProcess

	public partial class FirstFactorToken_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: FirstFactorTokenEventsProcess

	/// <exclude/>
	public class FirstFactorTokenEventsProcess : FirstFactorToken_BaseEventsProcess
	{

		public FirstFactorTokenEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

