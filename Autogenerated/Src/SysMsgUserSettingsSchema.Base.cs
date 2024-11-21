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

	#region Class: SysMsgUserSettingsSchema

	/// <exclude/>
	public class SysMsgUserSettingsSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysMsgUserSettingsSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysMsgUserSettingsSchema(SysMsgUserSettingsSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysMsgUserSettingsSchema(SysMsgUserSettingsSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("275886f1-0236-4087-bd52-02ddab97b088");
			RealUId = new Guid("275886f1-0236-4087-bd52-02ddab97b088");
			Name = "SysMsgUserSettings";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("44fdfc85-5ad4-4bdd-a5b8-a40d8b0a37b5")) == null) {
				Columns.Add(CreateUserColumn());
			}
			if (Columns.FindByUId(new Guid("285b8849-30e9-46c3-8d82-e8c9f5333291")) == null) {
				Columns.Add(CreateConnectionParamsColumn());
			}
			if (Columns.FindByUId(new Guid("0d8ef1ad-a785-4fe3-bd31-0da05dbbe4f0")) == null) {
				Columns.Add(CreateSysMsgLibColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateUserColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("44fdfc85-5ad4-4bdd-a5b8-a40d8b0a37b5"),
				Name = @"User",
				ReferenceSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("275886f1-0236-4087-bd52-02ddab97b088"),
				ModifiedInSchemaUId = new Guid("275886f1-0236-4087-bd52-02ddab97b088"),
				CreatedInPackageId = new Guid("773ffacd-4a58-4934-8cb2-5bf23386d08f")
			};
		}

		protected virtual EntitySchemaColumn CreateConnectionParamsColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("285b8849-30e9-46c3-8d82-e8c9f5333291"),
				Name = @"ConnectionParams",
				CreatedInSchemaUId = new Guid("275886f1-0236-4087-bd52-02ddab97b088"),
				ModifiedInSchemaUId = new Guid("275886f1-0236-4087-bd52-02ddab97b088"),
				CreatedInPackageId = new Guid("773ffacd-4a58-4934-8cb2-5bf23386d08f")
			};
		}

		protected virtual EntitySchemaColumn CreateSysMsgLibColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("0d8ef1ad-a785-4fe3-bd31-0da05dbbe4f0"),
				Name = @"SysMsgLib",
				ReferenceSchemaUId = new Guid("89b9f170-8aed-4f41-8659-c787b50df837"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("275886f1-0236-4087-bd52-02ddab97b088"),
				ModifiedInSchemaUId = new Guid("275886f1-0236-4087-bd52-02ddab97b088"),
				CreatedInPackageId = new Guid("c5b7d83b-a4c9-4615-a42e-7e250cad1309")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysMsgUserSettings(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysMsgUserSettings_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysMsgUserSettingsSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysMsgUserSettingsSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("275886f1-0236-4087-bd52-02ddab97b088"));
		}

		#endregion

	}

	#endregion

	#region Class: SysMsgUserSettings

	/// <summary>
	/// User settings in message exchange system.
	/// </summary>
	public class SysMsgUserSettings : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysMsgUserSettings(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysMsgUserSettings";
		}

		public SysMsgUserSettings(SysMsgUserSettings source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid UserId {
			get {
				return GetTypedColumnValue<Guid>("UserId");
			}
			set {
				SetColumnValue("UserId", value);
				_user = null;
			}
		}

		/// <exclude/>
		public string UserName {
			get {
				return GetTypedColumnValue<string>("UserName");
			}
			set {
				SetColumnValue("UserName", value);
				if (_user != null) {
					_user.Name = value;
				}
			}
		}

		private SysAdminUnit _user;
		/// <summary>
		/// User.
		/// </summary>
		public SysAdminUnit User {
			get {
				return _user ??
					(_user = LookupColumnEntities.GetEntity("User") as SysAdminUnit);
			}
		}

		/// <summary>
		/// Connection parameters.
		/// </summary>
		public string ConnectionParams {
			get {
				return GetTypedColumnValue<string>("ConnectionParams");
			}
			set {
				SetColumnValue("ConnectionParams", value);
			}
		}

		/// <exclude/>
		public Guid SysMsgLibId {
			get {
				return GetTypedColumnValue<Guid>("SysMsgLibId");
			}
			set {
				SetColumnValue("SysMsgLibId", value);
				_sysMsgLib = null;
			}
		}

		/// <exclude/>
		public string SysMsgLibName {
			get {
				return GetTypedColumnValue<string>("SysMsgLibName");
			}
			set {
				SetColumnValue("SysMsgLibName", value);
				if (_sysMsgLib != null) {
					_sysMsgLib.Name = value;
				}
			}
		}

		private SysMsgLib _sysMsgLib;
		/// <summary>
		/// Message exchange library.
		/// </summary>
		public SysMsgLib SysMsgLib {
			get {
				return _sysMsgLib ??
					(_sysMsgLib = LookupColumnEntities.GetEntity("SysMsgLib") as SysMsgLib);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysMsgUserSettings_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysMsgUserSettingsDeleted", e);
			Deleting += (s, e) => ThrowEvent("SysMsgUserSettingsDeleting", e);
			Inserted += (s, e) => ThrowEvent("SysMsgUserSettingsInserted", e);
			Inserting += (s, e) => ThrowEvent("SysMsgUserSettingsInserting", e);
			Saved += (s, e) => ThrowEvent("SysMsgUserSettingsSaved", e);
			Saving += (s, e) => ThrowEvent("SysMsgUserSettingsSaving", e);
			Validating += (s, e) => ThrowEvent("SysMsgUserSettingsValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysMsgUserSettings(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysMsgUserSettings_BaseEventsProcess

	/// <exclude/>
	public partial class SysMsgUserSettings_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : SysMsgUserSettings
	{

		public SysMsgUserSettings_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysMsgUserSettings_BaseEventsProcess";
			SchemaUId = new Guid("275886f1-0236-4087-bd52-02ddab97b088");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("275886f1-0236-4087-bd52-02ddab97b088");
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

	#region Class: SysMsgUserSettings_BaseEventsProcess

	/// <exclude/>
	public class SysMsgUserSettings_BaseEventsProcess : SysMsgUserSettings_BaseEventsProcess<SysMsgUserSettings>
	{

		public SysMsgUserSettings_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysMsgUserSettings_BaseEventsProcess

	public partial class SysMsgUserSettings_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysMsgUserSettingsEventsProcess

	/// <exclude/>
	public class SysMsgUserSettingsEventsProcess : SysMsgUserSettings_BaseEventsProcess
	{

		public SysMsgUserSettingsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

