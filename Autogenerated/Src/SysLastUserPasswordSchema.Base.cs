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

	#region Class: SysLastUserPasswordSchema

	/// <exclude/>
	public class SysLastUserPasswordSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysLastUserPasswordSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysLastUserPasswordSchema(SysLastUserPasswordSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysLastUserPasswordSchema(SysLastUserPasswordSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("c96e4557-0519-475b-91f1-87157612a911");
			RealUId = new Guid("c96e4557-0519-475b-91f1-87157612a911");
			Name = "SysLastUserPassword";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("e2771718-9ef5-4118-8671-7ba5d8df475d");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("668707f0-7962-4510-aabf-7322e740f9db")) == null) {
				Columns.Add(CreateSysAdminUnitColumn());
			}
			if (Columns.FindByUId(new Guid("dc30f243-4e72-4fba-8f4b-ec5309683a1b")) == null) {
				Columns.Add(CreatePasswordColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("c96e4557-0519-475b-91f1-87157612a911");
			column.CreatedInPackageId = new Guid("e2771718-9ef5-4118-8671-7ba5d8df475d");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("c96e4557-0519-475b-91f1-87157612a911");
			column.CreatedInPackageId = new Guid("e2771718-9ef5-4118-8671-7ba5d8df475d");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("c96e4557-0519-475b-91f1-87157612a911");
			column.CreatedInPackageId = new Guid("e2771718-9ef5-4118-8671-7ba5d8df475d");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("c96e4557-0519-475b-91f1-87157612a911");
			column.CreatedInPackageId = new Guid("e2771718-9ef5-4118-8671-7ba5d8df475d");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("c96e4557-0519-475b-91f1-87157612a911");
			column.CreatedInPackageId = new Guid("e2771718-9ef5-4118-8671-7ba5d8df475d");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("c96e4557-0519-475b-91f1-87157612a911");
			column.CreatedInPackageId = new Guid("e2771718-9ef5-4118-8671-7ba5d8df475d");
			return column;
		}

		protected virtual EntitySchemaColumn CreateSysAdminUnitColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("668707f0-7962-4510-aabf-7322e740f9db"),
				Name = @"SysAdminUnit",
				ReferenceSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("c96e4557-0519-475b-91f1-87157612a911"),
				ModifiedInSchemaUId = new Guid("c96e4557-0519-475b-91f1-87157612a911"),
				CreatedInPackageId = new Guid("e2771718-9ef5-4118-8671-7ba5d8df475d")
			};
		}

		protected virtual EntitySchemaColumn CreatePasswordColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("HashText")) {
				UId = new Guid("dc30f243-4e72-4fba-8f4b-ec5309683a1b"),
				Name = @"Password",
				CreatedInSchemaUId = new Guid("c96e4557-0519-475b-91f1-87157612a911"),
				ModifiedInSchemaUId = new Guid("c96e4557-0519-475b-91f1-87157612a911"),
				CreatedInPackageId = new Guid("e2771718-9ef5-4118-8671-7ba5d8df475d")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysLastUserPassword(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysLastUserPassword_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysLastUserPasswordSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysLastUserPasswordSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("c96e4557-0519-475b-91f1-87157612a911"));
		}

		#endregion

	}

	#endregion

	#region Class: SysLastUserPassword

	/// <summary>
	/// User passwords.
	/// </summary>
	public class SysLastUserPassword : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysLastUserPassword(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysLastUserPassword";
		}

		public SysLastUserPassword(SysLastUserPassword source)
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
		/// User.
		/// </summary>
		public SysAdminUnit SysAdminUnit {
			get {
				return _sysAdminUnit ??
					(_sysAdminUnit = LookupColumnEntities.GetEntity("SysAdminUnit") as SysAdminUnit);
			}
		}

		/// <summary>
		/// Password.
		/// </summary>
		public string Password {
			get {
				return GetTypedColumnValue<string>("Password");
			}
			set {
				SetColumnValue("Password", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysLastUserPassword_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysLastUserPasswordDeleted", e);
			Inserting += (s, e) => ThrowEvent("SysLastUserPasswordInserting", e);
			Validating += (s, e) => ThrowEvent("SysLastUserPasswordValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysLastUserPassword(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysLastUserPassword_BaseEventsProcess

	/// <exclude/>
	public partial class SysLastUserPassword_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : SysLastUserPassword
	{

		public SysLastUserPassword_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysLastUserPassword_BaseEventsProcess";
			SchemaUId = new Guid("c96e4557-0519-475b-91f1-87157612a911");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("c96e4557-0519-475b-91f1-87157612a911");
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

	#region Class: SysLastUserPassword_BaseEventsProcess

	/// <exclude/>
	public class SysLastUserPassword_BaseEventsProcess : SysLastUserPassword_BaseEventsProcess<SysLastUserPassword>
	{

		public SysLastUserPassword_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysLastUserPassword_BaseEventsProcess

	public partial class SysLastUserPassword_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysLastUserPasswordEventsProcess

	/// <exclude/>
	public class SysLastUserPasswordEventsProcess : SysLastUserPassword_BaseEventsProcess
	{

		public SysLastUserPasswordEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

