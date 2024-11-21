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

	#region Class: TotpSetupTokenSchema

	/// <exclude/>
	public class TotpSetupTokenSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public TotpSetupTokenSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public TotpSetupTokenSchema(TotpSetupTokenSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public TotpSetupTokenSchema(TotpSetupTokenSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("cbde20a4-a8cf-4679-9155-68af722b5f73");
			RealUId = new Guid("cbde20a4-a8cf-4679-9155-68af722b5f73");
			Name = "TotpSetupToken";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("49991372-aa4c-bf89-2c73-e34cc5e07e74")) == null) {
				Columns.Add(CreateSysAdminUnitColumn());
			}
			if (Columns.FindByUId(new Guid("18476dea-e9d4-ca20-f3c2-c13d88cc03bb")) == null) {
				Columns.Add(CreateTokenValueColumn());
			}
			if (Columns.FindByUId(new Guid("25c4258a-130b-53c4-b2f5-770f3240f13e")) == null) {
				Columns.Add(CreateSecretValueColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateSysAdminUnitColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("49991372-aa4c-bf89-2c73-e34cc5e07e74"),
				Name = @"SysAdminUnit",
				ReferenceSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("cbde20a4-a8cf-4679-9155-68af722b5f73"),
				ModifiedInSchemaUId = new Guid("cbde20a4-a8cf-4679-9155-68af722b5f73"),
				CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f")
			};
		}

		protected virtual EntitySchemaColumn CreateTokenValueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("18476dea-e9d4-ca20-f3c2-c13d88cc03bb"),
				Name = @"TokenValue",
				CreatedInSchemaUId = new Guid("cbde20a4-a8cf-4679-9155-68af722b5f73"),
				ModifiedInSchemaUId = new Guid("cbde20a4-a8cf-4679-9155-68af722b5f73"),
				CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f")
			};
		}

		protected virtual EntitySchemaColumn CreateSecretValueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("SecureText")) {
				UId = new Guid("25c4258a-130b-53c4-b2f5-770f3240f13e"),
				Name = @"SecretValue",
				CreatedInSchemaUId = new Guid("cbde20a4-a8cf-4679-9155-68af722b5f73"),
				ModifiedInSchemaUId = new Guid("cbde20a4-a8cf-4679-9155-68af722b5f73"),
				CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new TotpSetupToken(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new TotpSetupToken_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new TotpSetupTokenSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new TotpSetupTokenSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("cbde20a4-a8cf-4679-9155-68af722b5f73"));
		}

		#endregion

	}

	#endregion

	#region Class: TotpSetupToken

	/// <summary>
	/// TotpSetupToken.
	/// </summary>
	public class TotpSetupToken : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public TotpSetupToken(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "TotpSetupToken";
		}

		public TotpSetupToken(TotpSetupToken source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

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

		/// <summary>
		/// SecretValue.
		/// </summary>
		public string SecretValue {
			get {
				return GetTypedColumnValue<string>("SecretValue");
			}
			set {
				SetColumnValue("SecretValue", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new TotpSetupToken_BaseEventsProcess(UserConnection);
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
			return new TotpSetupToken(this);
		}

		#endregion

	}

	#endregion

	#region Class: TotpSetupToken_BaseEventsProcess

	/// <exclude/>
	public partial class TotpSetupToken_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : TotpSetupToken
	{

		public TotpSetupToken_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "TotpSetupToken_BaseEventsProcess";
			SchemaUId = new Guid("cbde20a4-a8cf-4679-9155-68af722b5f73");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("cbde20a4-a8cf-4679-9155-68af722b5f73");
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

	#region Class: TotpSetupToken_BaseEventsProcess

	/// <exclude/>
	public class TotpSetupToken_BaseEventsProcess : TotpSetupToken_BaseEventsProcess<TotpSetupToken>
	{

		public TotpSetupToken_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: TotpSetupToken_BaseEventsProcess

	public partial class TotpSetupToken_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: TotpSetupTokenEventsProcess

	/// <exclude/>
	public class TotpSetupTokenEventsProcess : TotpSetupToken_BaseEventsProcess
	{

		public TotpSetupTokenEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

