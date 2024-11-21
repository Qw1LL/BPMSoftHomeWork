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

	#region Class: SysEntitySchemaRecordDefRightSchema

	/// <exclude/>
	[IsVirtual]
	public class SysEntitySchemaRecordDefRightSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysEntitySchemaRecordDefRightSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysEntitySchemaRecordDefRightSchema(SysEntitySchemaRecordDefRightSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysEntitySchemaRecordDefRightSchema(SysEntitySchemaRecordDefRightSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("2023116e-cdb5-49ab-9e44-315deba610b8");
			RealUId = new Guid("2023116e-cdb5-49ab-9e44-315deba610b8");
			Name = "SysEntitySchemaRecordDefRight";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("da2e27e4-45dc-4041-949e-25041f52bc84")) == null) {
				Columns.Add(CreateAuthorColumn());
			}
			if (Columns.FindByUId(new Guid("4d59ed87-eb02-40c1-a313-093a1d56427d")) == null) {
				Columns.Add(CreateGranteeColumn());
			}
			if (Columns.FindByUId(new Guid("aad5dad3-f79d-4259-b41e-28091d8ba81a")) == null) {
				Columns.Add(CreateOperationColumn());
			}
			if (Columns.FindByUId(new Guid("dfe9fd43-db84-4526-8206-131381e9effa")) == null) {
				Columns.Add(CreateRightLevelColumn());
			}
			if (Columns.FindByUId(new Guid("04aaec36-56c3-44a5-8e2c-49a52c23d99b")) == null) {
				Columns.Add(CreatePositionColumn());
			}
			if (Columns.FindByUId(new Guid("0e13b37d-f7ae-4127-8749-01c1e67487b9")) == null) {
				Columns.Add(CreateSubjectSchemaUIdColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateAuthorColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("da2e27e4-45dc-4041-949e-25041f52bc84"),
				Name = @"Author",
				ReferenceSchemaUId = new Guid("d5d01fcd-6d8c-4b29-9e58-cca3ffe62364"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("2023116e-cdb5-49ab-9e44-315deba610b8"),
				ModifiedInSchemaUId = new Guid("2023116e-cdb5-49ab-9e44-315deba610b8"),
				CreatedInPackageId = new Guid("06ab5269-0eb4-4ce1-a02d-5953e0f92289")
			};
		}

		protected virtual EntitySchemaColumn CreateGranteeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("4d59ed87-eb02-40c1-a313-093a1d56427d"),
				Name = @"Grantee",
				ReferenceSchemaUId = new Guid("d5d01fcd-6d8c-4b29-9e58-cca3ffe62364"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("2023116e-cdb5-49ab-9e44-315deba610b8"),
				ModifiedInSchemaUId = new Guid("2023116e-cdb5-49ab-9e44-315deba610b8"),
				CreatedInPackageId = new Guid("06ab5269-0eb4-4ce1-a02d-5953e0f92289")
			};
		}

		protected virtual EntitySchemaColumn CreateOperationColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("aad5dad3-f79d-4259-b41e-28091d8ba81a"),
				Name = @"Operation",
				ReferenceSchemaUId = new Guid("01618739-cd25-41bf-9cda-86594ea9f512"),
				CreatedInSchemaUId = new Guid("2023116e-cdb5-49ab-9e44-315deba610b8"),
				ModifiedInSchemaUId = new Guid("2023116e-cdb5-49ab-9e44-315deba610b8"),
				CreatedInPackageId = new Guid("06ab5269-0eb4-4ce1-a02d-5953e0f92289")
			};
		}

		protected virtual EntitySchemaColumn CreateRightLevelColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("dfe9fd43-db84-4526-8206-131381e9effa"),
				Name = @"RightLevel",
				ReferenceSchemaUId = new Guid("0305bb65-8332-47b3-8550-3d5c3e59cb3e"),
				CreatedInSchemaUId = new Guid("2023116e-cdb5-49ab-9e44-315deba610b8"),
				ModifiedInSchemaUId = new Guid("2023116e-cdb5-49ab-9e44-315deba610b8"),
				CreatedInPackageId = new Guid("06ab5269-0eb4-4ce1-a02d-5953e0f92289")
			};
		}

		protected virtual EntitySchemaColumn CreatePositionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("04aaec36-56c3-44a5-8e2c-49a52c23d99b"),
				Name = @"Position",
				CreatedInSchemaUId = new Guid("2023116e-cdb5-49ab-9e44-315deba610b8"),
				ModifiedInSchemaUId = new Guid("2023116e-cdb5-49ab-9e44-315deba610b8"),
				CreatedInPackageId = new Guid("06ab5269-0eb4-4ce1-a02d-5953e0f92289")
			};
		}

		protected virtual EntitySchemaColumn CreateSubjectSchemaUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("0e13b37d-f7ae-4127-8749-01c1e67487b9"),
				Name = @"SubjectSchemaUId",
				CreatedInSchemaUId = new Guid("2023116e-cdb5-49ab-9e44-315deba610b8"),
				ModifiedInSchemaUId = new Guid("2023116e-cdb5-49ab-9e44-315deba610b8"),
				CreatedInPackageId = new Guid("06ab5269-0eb4-4ce1-a02d-5953e0f92289")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysEntitySchemaRecordDefRight(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysEntitySchemaRecordDefRight_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysEntitySchemaRecordDefRightSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysEntitySchemaRecordDefRightSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("2023116e-cdb5-49ab-9e44-315deba610b8"));
		}

		#endregion

	}

	#endregion

	#region Class: SysEntitySchemaRecordDefRight

	/// <summary>
	/// Default permissions.
	/// </summary>
	public class SysEntitySchemaRecordDefRight : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysEntitySchemaRecordDefRight(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysEntitySchemaRecordDefRight";
		}

		public SysEntitySchemaRecordDefRight(SysEntitySchemaRecordDefRight source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid AuthorId {
			get {
				return GetTypedColumnValue<Guid>("AuthorId");
			}
			set {
				SetColumnValue("AuthorId", value);
				_author = null;
			}
		}

		/// <exclude/>
		public string AuthorName {
			get {
				return GetTypedColumnValue<string>("AuthorName");
			}
			set {
				SetColumnValue("AuthorName", value);
				if (_author != null) {
					_author.Name = value;
				}
			}
		}

		private VwSysAdminUnit _author;
		/// <summary>
		/// Created by.
		/// </summary>
		public VwSysAdminUnit Author {
			get {
				return _author ??
					(_author = LookupColumnEntities.GetEntity("Author") as VwSysAdminUnit);
			}
		}

		/// <exclude/>
		public Guid GranteeId {
			get {
				return GetTypedColumnValue<Guid>("GranteeId");
			}
			set {
				SetColumnValue("GranteeId", value);
				_grantee = null;
			}
		}

		/// <exclude/>
		public string GranteeName {
			get {
				return GetTypedColumnValue<string>("GranteeName");
			}
			set {
				SetColumnValue("GranteeName", value);
				if (_grantee != null) {
					_grantee.Name = value;
				}
			}
		}

		private VwSysAdminUnit _grantee;
		/// <summary>
		/// User/role.
		/// </summary>
		public VwSysAdminUnit Grantee {
			get {
				return _grantee ??
					(_grantee = LookupColumnEntities.GetEntity("Grantee") as VwSysAdminUnit);
			}
		}

		/// <exclude/>
		public Guid OperationId {
			get {
				return GetTypedColumnValue<Guid>("OperationId");
			}
			set {
				SetColumnValue("OperationId", value);
				_operation = null;
			}
		}

		/// <exclude/>
		public string OperationName {
			get {
				return GetTypedColumnValue<string>("OperationName");
			}
			set {
				SetColumnValue("OperationName", value);
				if (_operation != null) {
					_operation.Name = value;
				}
			}
		}

		private EntitySchemaRecRightOperation _operation;
		/// <summary>
		/// Operation.
		/// </summary>
		public EntitySchemaRecRightOperation Operation {
			get {
				return _operation ??
					(_operation = LookupColumnEntities.GetEntity("Operation") as EntitySchemaRecRightOperation);
			}
		}

		/// <exclude/>
		public Guid RightLevelId {
			get {
				return GetTypedColumnValue<Guid>("RightLevelId");
			}
			set {
				SetColumnValue("RightLevelId", value);
				_rightLevel = null;
			}
		}

		/// <exclude/>
		public string RightLevelName {
			get {
				return GetTypedColumnValue<string>("RightLevelName");
			}
			set {
				SetColumnValue("RightLevelName", value);
				if (_rightLevel != null) {
					_rightLevel.Name = value;
				}
			}
		}

		private SysEntitySchemaRecOprRightLvl _rightLevel;
		/// <summary>
		/// Access level.
		/// </summary>
		public SysEntitySchemaRecOprRightLvl RightLevel {
			get {
				return _rightLevel ??
					(_rightLevel = LookupColumnEntities.GetEntity("RightLevel") as SysEntitySchemaRecOprRightLvl);
			}
		}

		/// <summary>
		/// Position.
		/// </summary>
		public int Position {
			get {
				return GetTypedColumnValue<int>("Position");
			}
			set {
				SetColumnValue("Position", value);
			}
		}

		/// <summary>
		/// Unique identifier of schema in workspace.
		/// </summary>
		public Guid SubjectSchemaUId {
			get {
				return GetTypedColumnValue<Guid>("SubjectSchemaUId");
			}
			set {
				SetColumnValue("SubjectSchemaUId", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysEntitySchemaRecordDefRight_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysEntitySchemaRecordDefRightDeleted", e);
			Deleting += (s, e) => ThrowEvent("SysEntitySchemaRecordDefRightDeleting", e);
			Inserted += (s, e) => ThrowEvent("SysEntitySchemaRecordDefRightInserted", e);
			Inserting += (s, e) => ThrowEvent("SysEntitySchemaRecordDefRightInserting", e);
			Saved += (s, e) => ThrowEvent("SysEntitySchemaRecordDefRightSaved", e);
			Saving += (s, e) => ThrowEvent("SysEntitySchemaRecordDefRightSaving", e);
			Validating += (s, e) => ThrowEvent("SysEntitySchemaRecordDefRightValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysEntitySchemaRecordDefRight(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysEntitySchemaRecordDefRight_BaseEventsProcess

	/// <exclude/>
	public partial class SysEntitySchemaRecordDefRight_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : SysEntitySchemaRecordDefRight
	{

		public SysEntitySchemaRecordDefRight_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysEntitySchemaRecordDefRight_BaseEventsProcess";
			SchemaUId = new Guid("2023116e-cdb5-49ab-9e44-315deba610b8");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("2023116e-cdb5-49ab-9e44-315deba610b8");
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

	#region Class: SysEntitySchemaRecordDefRight_BaseEventsProcess

	/// <exclude/>
	public class SysEntitySchemaRecordDefRight_BaseEventsProcess : SysEntitySchemaRecordDefRight_BaseEventsProcess<SysEntitySchemaRecordDefRight>
	{

		public SysEntitySchemaRecordDefRight_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysEntitySchemaRecordDefRight_BaseEventsProcess

	public partial class SysEntitySchemaRecordDefRight_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysEntitySchemaRecordDefRightEventsProcess

	/// <exclude/>
	public class SysEntitySchemaRecordDefRightEventsProcess : SysEntitySchemaRecordDefRight_BaseEventsProcess
	{

		public SysEntitySchemaRecordDefRightEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

