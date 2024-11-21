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

	#region Class: SysRepositoryUserSchema

	/// <exclude/>
	public class SysRepositoryUserSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysRepositoryUserSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysRepositoryUserSchema(SysRepositoryUserSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysRepositoryUserSchema(SysRepositoryUserSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("fdc5e370-b9bf-4a5b-9bef-68a57f56b711");
			RealUId = new Guid("fdc5e370-b9bf-4a5b-9bef-68a57f56b711");
			Name = "SysRepositoryUser";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("c0d667fc-f22f-4d2e-8f98-6d81fc470df4");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("999f2848-f499-4c9a-b72f-056e7ba38192")) == null) {
				Columns.Add(CreateSysRepositoryColumn());
			}
			if (Columns.FindByUId(new Guid("349c67c3-c3de-4619-9f88-3087eca3c935")) == null) {
				Columns.Add(CreateSysAdminUnitColumn());
			}
			if (Columns.FindByUId(new Guid("e4b5bbb9-7eb7-43fe-b7e3-928e005df72f")) == null) {
				Columns.Add(CreateLoginColumn());
			}
			if (Columns.FindByUId(new Guid("e760e83b-c0c6-4c42-8595-514b48088ccf")) == null) {
				Columns.Add(CreatePasswordColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("fdc5e370-b9bf-4a5b-9bef-68a57f56b711");
			column.CreatedInPackageId = new Guid("c0d667fc-f22f-4d2e-8f98-6d81fc470df4");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("fdc5e370-b9bf-4a5b-9bef-68a57f56b711");
			column.CreatedInPackageId = new Guid("c0d667fc-f22f-4d2e-8f98-6d81fc470df4");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("fdc5e370-b9bf-4a5b-9bef-68a57f56b711");
			column.CreatedInPackageId = new Guid("c0d667fc-f22f-4d2e-8f98-6d81fc470df4");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("fdc5e370-b9bf-4a5b-9bef-68a57f56b711");
			column.CreatedInPackageId = new Guid("c0d667fc-f22f-4d2e-8f98-6d81fc470df4");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("fdc5e370-b9bf-4a5b-9bef-68a57f56b711");
			column.CreatedInPackageId = new Guid("c0d667fc-f22f-4d2e-8f98-6d81fc470df4");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("fdc5e370-b9bf-4a5b-9bef-68a57f56b711");
			column.CreatedInPackageId = new Guid("c0d667fc-f22f-4d2e-8f98-6d81fc470df4");
			return column;
		}

		protected virtual EntitySchemaColumn CreateSysRepositoryColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("999f2848-f499-4c9a-b72f-056e7ba38192"),
				Name = @"SysRepository",
				ReferenceSchemaUId = new Guid("7b8d899e-40bf-4430-9665-908f653acf41"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("fdc5e370-b9bf-4a5b-9bef-68a57f56b711"),
				ModifiedInSchemaUId = new Guid("fdc5e370-b9bf-4a5b-9bef-68a57f56b711"),
				CreatedInPackageId = new Guid("c0d667fc-f22f-4d2e-8f98-6d81fc470df4")
			};
		}

		protected virtual EntitySchemaColumn CreateSysAdminUnitColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("349c67c3-c3de-4619-9f88-3087eca3c935"),
				Name = @"SysAdminUnit",
				ReferenceSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("fdc5e370-b9bf-4a5b-9bef-68a57f56b711"),
				ModifiedInSchemaUId = new Guid("fdc5e370-b9bf-4a5b-9bef-68a57f56b711"),
				CreatedInPackageId = new Guid("c0d667fc-f22f-4d2e-8f98-6d81fc470df4")
			};
		}

		protected virtual EntitySchemaColumn CreateLoginColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("e4b5bbb9-7eb7-43fe-b7e3-928e005df72f"),
				Name = @"Login",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("fdc5e370-b9bf-4a5b-9bef-68a57f56b711"),
				ModifiedInSchemaUId = new Guid("fdc5e370-b9bf-4a5b-9bef-68a57f56b711"),
				CreatedInPackageId = new Guid("c0d667fc-f22f-4d2e-8f98-6d81fc470df4")
			};
		}

		protected virtual EntitySchemaColumn CreatePasswordColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("SecureText")) {
				UId = new Guid("e760e83b-c0c6-4c42-8595-514b48088ccf"),
				Name = @"Password",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("fdc5e370-b9bf-4a5b-9bef-68a57f56b711"),
				ModifiedInSchemaUId = new Guid("fdc5e370-b9bf-4a5b-9bef-68a57f56b711"),
				CreatedInPackageId = new Guid("c0d667fc-f22f-4d2e-8f98-6d81fc470df4")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysRepositoryUser(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysRepositoryUser_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysRepositoryUserSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysRepositoryUserSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("fdc5e370-b9bf-4a5b-9bef-68a57f56b711"));
		}

		#endregion

	}

	#endregion

	#region Class: SysRepositoryUser

	/// <summary>
	/// Storage users.
	/// </summary>
	public class SysRepositoryUser : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysRepositoryUser(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysRepositoryUser";
		}

		public SysRepositoryUser(SysRepositoryUser source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid SysRepositoryId {
			get {
				return GetTypedColumnValue<Guid>("SysRepositoryId");
			}
			set {
				SetColumnValue("SysRepositoryId", value);
				_sysRepository = null;
			}
		}

		/// <exclude/>
		public string SysRepositoryName {
			get {
				return GetTypedColumnValue<string>("SysRepositoryName");
			}
			set {
				SetColumnValue("SysRepositoryName", value);
				if (_sysRepository != null) {
					_sysRepository.Name = value;
				}
			}
		}

		private SysRepository _sysRepository;
		/// <summary>
		/// Storage.
		/// </summary>
		public SysRepository SysRepository {
			get {
				return _sysRepository ??
					(_sysRepository = LookupColumnEntities.GetEntity("SysRepository") as SysRepository);
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
		/// User.
		/// </summary>
		public SysAdminUnit SysAdminUnit {
			get {
				return _sysAdminUnit ??
					(_sysAdminUnit = LookupColumnEntities.GetEntity("SysAdminUnit") as SysAdminUnit);
			}
		}

		/// <summary>
		/// Storage login.
		/// </summary>
		public string Login {
			get {
				return GetTypedColumnValue<string>("Login");
			}
			set {
				SetColumnValue("Login", value);
			}
		}

		/// <summary>
		/// Storage password.
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
			var process = new SysRepositoryUser_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysRepositoryUserDeleted", e);
			Inserting += (s, e) => ThrowEvent("SysRepositoryUserInserting", e);
			Validating += (s, e) => ThrowEvent("SysRepositoryUserValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysRepositoryUser(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysRepositoryUser_BaseEventsProcess

	/// <exclude/>
	public partial class SysRepositoryUser_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : SysRepositoryUser
	{

		public SysRepositoryUser_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysRepositoryUser_BaseEventsProcess";
			SchemaUId = new Guid("fdc5e370-b9bf-4a5b-9bef-68a57f56b711");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("fdc5e370-b9bf-4a5b-9bef-68a57f56b711");
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

	#region Class: SysRepositoryUser_BaseEventsProcess

	/// <exclude/>
	public class SysRepositoryUser_BaseEventsProcess : SysRepositoryUser_BaseEventsProcess<SysRepositoryUser>
	{

		public SysRepositoryUser_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysRepositoryUser_BaseEventsProcess

	public partial class SysRepositoryUser_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysRepositoryUserEventsProcess

	/// <exclude/>
	public class SysRepositoryUserEventsProcess : SysRepositoryUser_BaseEventsProcess
	{

		public SysRepositoryUserEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

