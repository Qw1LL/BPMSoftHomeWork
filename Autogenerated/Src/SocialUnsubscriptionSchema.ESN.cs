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

	#region Class: SocialUnsubscriptionSchema

	/// <exclude/>
	public class SocialUnsubscriptionSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SocialUnsubscriptionSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SocialUnsubscriptionSchema(SocialUnsubscriptionSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SocialUnsubscriptionSchema(SocialUnsubscriptionSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("7ee52afe-1f7d-4719-81b4-b53d7879d6b2");
			RealUId = new Guid("7ee52afe-1f7d-4719-81b4-b53d7879d6b2");
			Name = "SocialUnsubscription";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("45651080-8a86-4041-b656-96c6d9b69016");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("cbe95c26-cd0d-4d0c-b916-d7b7e95e68b6")) == null) {
				Columns.Add(CreateSysAdminUnitColumn());
			}
			if (Columns.FindByUId(new Guid("3d07984a-3a6f-4646-9ed7-16f7a29874d3")) == null) {
				Columns.Add(CreateEntityIdColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("7ee52afe-1f7d-4719-81b4-b53d7879d6b2");
			column.CreatedInPackageId = new Guid("45651080-8a86-4041-b656-96c6d9b69016");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("7ee52afe-1f7d-4719-81b4-b53d7879d6b2");
			column.CreatedInPackageId = new Guid("45651080-8a86-4041-b656-96c6d9b69016");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("7ee52afe-1f7d-4719-81b4-b53d7879d6b2");
			column.CreatedInPackageId = new Guid("45651080-8a86-4041-b656-96c6d9b69016");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("7ee52afe-1f7d-4719-81b4-b53d7879d6b2");
			column.CreatedInPackageId = new Guid("45651080-8a86-4041-b656-96c6d9b69016");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("7ee52afe-1f7d-4719-81b4-b53d7879d6b2");
			column.CreatedInPackageId = new Guid("45651080-8a86-4041-b656-96c6d9b69016");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("7ee52afe-1f7d-4719-81b4-b53d7879d6b2");
			column.CreatedInPackageId = new Guid("45651080-8a86-4041-b656-96c6d9b69016");
			return column;
		}

		protected virtual EntitySchemaColumn CreateSysAdminUnitColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("cbe95c26-cd0d-4d0c-b916-d7b7e95e68b6"),
				Name = @"SysAdminUnit",
				ReferenceSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("7ee52afe-1f7d-4719-81b4-b53d7879d6b2"),
				ModifiedInSchemaUId = new Guid("7ee52afe-1f7d-4719-81b4-b53d7879d6b2"),
				CreatedInPackageId = new Guid("45651080-8a86-4041-b656-96c6d9b69016")
			};
		}

		protected virtual EntitySchemaColumn CreateEntityIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("3d07984a-3a6f-4646-9ed7-16f7a29874d3"),
				Name = @"EntityId",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("7ee52afe-1f7d-4719-81b4-b53d7879d6b2"),
				ModifiedInSchemaUId = new Guid("7ee52afe-1f7d-4719-81b4-b53d7879d6b2"),
				CreatedInPackageId = new Guid("45651080-8a86-4041-b656-96c6d9b69016")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SocialUnsubscription(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SocialUnsubscription_ESNEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SocialUnsubscriptionSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SocialUnsubscriptionSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("7ee52afe-1f7d-4719-81b4-b53d7879d6b2"));
		}

		#endregion

	}

	#endregion

	#region Class: SocialUnsubscription

	/// <summary>
	/// Unfollow.
	/// </summary>
	public class SocialUnsubscription : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SocialUnsubscription(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SocialUnsubscription";
		}

		public SocialUnsubscription(SocialUnsubscription source)
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
		/// Object instance.
		/// </summary>
		public Guid EntityId {
			get {
				return GetTypedColumnValue<Guid>("EntityId");
			}
			set {
				SetColumnValue("EntityId", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SocialUnsubscription_ESNEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SocialUnsubscriptionDeleted", e);
			Inserting += (s, e) => ThrowEvent("SocialUnsubscriptionInserting", e);
			Validating += (s, e) => ThrowEvent("SocialUnsubscriptionValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SocialUnsubscription(this);
		}

		#endregion

	}

	#endregion

	#region Class: SocialUnsubscription_ESNEventsProcess

	/// <exclude/>
	public partial class SocialUnsubscription_ESNEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : SocialUnsubscription
	{

		public SocialUnsubscription_ESNEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SocialUnsubscription_ESNEventsProcess";
			SchemaUId = new Guid("7ee52afe-1f7d-4719-81b4-b53d7879d6b2");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("7ee52afe-1f7d-4719-81b4-b53d7879d6b2");
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

	#region Class: SocialUnsubscription_ESNEventsProcess

	/// <exclude/>
	public class SocialUnsubscription_ESNEventsProcess : SocialUnsubscription_ESNEventsProcess<SocialUnsubscription>
	{

		public SocialUnsubscription_ESNEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SocialUnsubscription_ESNEventsProcess

	public partial class SocialUnsubscription_ESNEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SocialUnsubscriptionEventsProcess

	/// <exclude/>
	public class SocialUnsubscriptionEventsProcess : SocialUnsubscription_ESNEventsProcess
	{

		public SocialUnsubscriptionEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

