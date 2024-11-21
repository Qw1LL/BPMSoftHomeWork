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

	#region Class: SysRepositorySchema

	/// <exclude/>
	public class SysRepositorySchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysRepositorySchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysRepositorySchema(SysRepositorySchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysRepositorySchema(SysRepositorySchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("7b8d899e-40bf-4430-9665-908f653acf41");
			RealUId = new Guid("7b8d899e-40bf-4430-9665-908f653acf41");
			Name = "SysRepository";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("c0d667fc-f22f-4d2e-8f98-6d81fc470df4");
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
			if (Columns.FindByUId(new Guid("a92149ac-72eb-4ad5-981a-1014b61819a1")) == null) {
				Columns.Add(CreateAddressColumn());
			}
			if (Columns.FindByUId(new Guid("3115227e-59d0-46ff-91d6-fef33b1cd7d3")) == null) {
				Columns.Add(CreateIsActiveColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("7b8d899e-40bf-4430-9665-908f653acf41");
			column.CreatedInPackageId = new Guid("c0d667fc-f22f-4d2e-8f98-6d81fc470df4");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("7b8d899e-40bf-4430-9665-908f653acf41");
			column.CreatedInPackageId = new Guid("c0d667fc-f22f-4d2e-8f98-6d81fc470df4");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("7b8d899e-40bf-4430-9665-908f653acf41");
			column.CreatedInPackageId = new Guid("c0d667fc-f22f-4d2e-8f98-6d81fc470df4");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("7b8d899e-40bf-4430-9665-908f653acf41");
			column.CreatedInPackageId = new Guid("c0d667fc-f22f-4d2e-8f98-6d81fc470df4");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("7b8d899e-40bf-4430-9665-908f653acf41");
			column.CreatedInPackageId = new Guid("c0d667fc-f22f-4d2e-8f98-6d81fc470df4");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("7b8d899e-40bf-4430-9665-908f653acf41");
			column.CreatedInPackageId = new Guid("c0d667fc-f22f-4d2e-8f98-6d81fc470df4");
			return column;
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("e3093367-5df1-4d54-8722-c7b9e1f327f8"),
				Name = @"Name",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("7b8d899e-40bf-4430-9665-908f653acf41"),
				ModifiedInSchemaUId = new Guid("7b8d899e-40bf-4430-9665-908f653acf41"),
				CreatedInPackageId = new Guid("c0d667fc-f22f-4d2e-8f98-6d81fc470df4")
			};
		}

		protected virtual EntitySchemaColumn CreateAddressColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("a92149ac-72eb-4ad5-981a-1014b61819a1"),
				Name = @"Address",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("7b8d899e-40bf-4430-9665-908f653acf41"),
				ModifiedInSchemaUId = new Guid("7b8d899e-40bf-4430-9665-908f653acf41"),
				CreatedInPackageId = new Guid("c0d667fc-f22f-4d2e-8f98-6d81fc470df4")
			};
		}

		protected virtual EntitySchemaColumn CreateIsActiveColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("3115227e-59d0-46ff-91d6-fef33b1cd7d3"),
				Name = @"IsActive",
				CreatedInSchemaUId = new Guid("7b8d899e-40bf-4430-9665-908f653acf41"),
				ModifiedInSchemaUId = new Guid("7b8d899e-40bf-4430-9665-908f653acf41"),
				CreatedInPackageId = new Guid("4767b46b-cabd-4943-ac62-3ddefc193e0b")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysRepository(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysRepository_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysRepositorySchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysRepositorySchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("7b8d899e-40bf-4430-9665-908f653acf41"));
		}

		#endregion

	}

	#endregion

	#region Class: SysRepository

	/// <summary>
	/// Storages list.
	/// </summary>
	public class SysRepository : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysRepository(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysRepository";
		}

		public SysRepository(SysRepository source)
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
		/// Storage address.
		/// </summary>
		public string Address {
			get {
				return GetTypedColumnValue<string>("Address");
			}
			set {
				SetColumnValue("Address", value);
			}
		}

		/// <summary>
		/// Active.
		/// </summary>
		public bool IsActive {
			get {
				return GetTypedColumnValue<bool>("IsActive");
			}
			set {
				SetColumnValue("IsActive", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysRepository_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysRepositoryDeleted", e);
			Inserting += (s, e) => ThrowEvent("SysRepositoryInserting", e);
			Validating += (s, e) => ThrowEvent("SysRepositoryValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysRepository(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysRepository_BaseEventsProcess

	/// <exclude/>
	public partial class SysRepository_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : SysRepository
	{

		public SysRepository_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysRepository_BaseEventsProcess";
			SchemaUId = new Guid("7b8d899e-40bf-4430-9665-908f653acf41");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("7b8d899e-40bf-4430-9665-908f653acf41");
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

	#region Class: SysRepository_BaseEventsProcess

	/// <exclude/>
	public class SysRepository_BaseEventsProcess : SysRepository_BaseEventsProcess<SysRepository>
	{

		public SysRepository_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysRepository_BaseEventsProcess

	public partial class SysRepository_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysRepositoryEventsProcess

	/// <exclude/>
	public class SysRepositoryEventsProcess : SysRepository_BaseEventsProcess
	{

		public SysRepositoryEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

