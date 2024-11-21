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

	#region Class: SysEntitySchemaRecordRightSchema

	/// <exclude/>
	[IsVirtual]
	public class SysEntitySchemaRecordRightSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysEntitySchemaRecordRightSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysEntitySchemaRecordRightSchema(SysEntitySchemaRecordRightSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysEntitySchemaRecordRightSchema(SysEntitySchemaRecordRightSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("509cef8b-8cdf-48e4-a41c-c0159f1e0bf7");
			RealUId = new Guid("509cef8b-8cdf-48e4-a41c-c0159f1e0bf7");
			Name = "SysEntitySchemaRecordRight";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("1dc808dc-d1fb-499f-bb7f-3d5f3114e3a4")) == null) {
				Columns.Add(CreateRecordIdColumn());
			}
			if (Columns.FindByUId(new Guid("3d68cb45-def6-4b0e-9c5f-89e871d87454")) == null) {
				Columns.Add(CreateSysAdminUnitColumn());
			}
			if (Columns.FindByUId(new Guid("ea741da6-982c-4724-b77f-9dd39edaf88f")) == null) {
				Columns.Add(CreateOperationColumn());
			}
			if (Columns.FindByUId(new Guid("190b9412-9fbe-4030-874e-8b5bc3e4829e")) == null) {
				Columns.Add(CreateColumn4Column());
			}
			if (Columns.FindByUId(new Guid("d56c9154-4e56-4f2f-a365-b115dd8d4d1d")) == null) {
				Columns.Add(CreateSourceColumn());
			}
			if (Columns.FindByUId(new Guid("e46f5f2d-4622-4524-bf7d-7ea1a86e66c5")) == null) {
				Columns.Add(CreatePositionColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateRecordIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("1dc808dc-d1fb-499f-bb7f-3d5f3114e3a4"),
				Name = @"RecordId",
				CreatedInSchemaUId = new Guid("509cef8b-8cdf-48e4-a41c-c0159f1e0bf7"),
				ModifiedInSchemaUId = new Guid("509cef8b-8cdf-48e4-a41c-c0159f1e0bf7"),
				CreatedInPackageId = new Guid("c692daa9-de5e-4e96-afd3-e992ed86681c")
			};
		}

		protected virtual EntitySchemaColumn CreateSysAdminUnitColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("3d68cb45-def6-4b0e-9c5f-89e871d87454"),
				Name = @"SysAdminUnit",
				ReferenceSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				CreatedInSchemaUId = new Guid("509cef8b-8cdf-48e4-a41c-c0159f1e0bf7"),
				ModifiedInSchemaUId = new Guid("509cef8b-8cdf-48e4-a41c-c0159f1e0bf7"),
				CreatedInPackageId = new Guid("c692daa9-de5e-4e96-afd3-e992ed86681c")
			};
		}

		protected virtual EntitySchemaColumn CreateOperationColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("ea741da6-982c-4724-b77f-9dd39edaf88f"),
				Name = @"Operation",
				ReferenceSchemaUId = new Guid("01618739-cd25-41bf-9cda-86594ea9f512"),
				CreatedInSchemaUId = new Guid("509cef8b-8cdf-48e4-a41c-c0159f1e0bf7"),
				ModifiedInSchemaUId = new Guid("509cef8b-8cdf-48e4-a41c-c0159f1e0bf7"),
				CreatedInPackageId = new Guid("c692daa9-de5e-4e96-afd3-e992ed86681c")
			};
		}

		protected virtual EntitySchemaColumn CreateColumn4Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("190b9412-9fbe-4030-874e-8b5bc3e4829e"),
				Name = @"Column4",
				ReferenceSchemaUId = new Guid("0305bb65-8332-47b3-8550-3d5c3e59cb3e"),
				CreatedInSchemaUId = new Guid("509cef8b-8cdf-48e4-a41c-c0159f1e0bf7"),
				ModifiedInSchemaUId = new Guid("509cef8b-8cdf-48e4-a41c-c0159f1e0bf7"),
				CreatedInPackageId = new Guid("c692daa9-de5e-4e96-afd3-e992ed86681c")
			};
		}

		protected virtual EntitySchemaColumn CreateSourceColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("d56c9154-4e56-4f2f-a365-b115dd8d4d1d"),
				Name = @"Source",
				ReferenceSchemaUId = new Guid("f990ac27-1b3c-4090-bea2-694e259c8c2c"),
				CreatedInSchemaUId = new Guid("509cef8b-8cdf-48e4-a41c-c0159f1e0bf7"),
				ModifiedInSchemaUId = new Guid("509cef8b-8cdf-48e4-a41c-c0159f1e0bf7"),
				CreatedInPackageId = new Guid("c692daa9-de5e-4e96-afd3-e992ed86681c")
			};
		}

		protected virtual EntitySchemaColumn CreatePositionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("e46f5f2d-4622-4524-bf7d-7ea1a86e66c5"),
				Name = @"Position",
				CreatedInSchemaUId = new Guid("509cef8b-8cdf-48e4-a41c-c0159f1e0bf7"),
				ModifiedInSchemaUId = new Guid("509cef8b-8cdf-48e4-a41c-c0159f1e0bf7"),
				CreatedInPackageId = new Guid("c692daa9-de5e-4e96-afd3-e992ed86681c")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysEntitySchemaRecordRight(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysEntitySchemaRecordRight_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysEntitySchemaRecordRightSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysEntitySchemaRecordRightSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("509cef8b-8cdf-48e4-a41c-c0159f1e0bf7"));
		}

		#endregion

	}

	#endregion

	#region Class: SysEntitySchemaRecordRight

	/// <summary>
	/// User access to object.
	/// </summary>
	public class SysEntitySchemaRecordRight : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysEntitySchemaRecordRight(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysEntitySchemaRecordRight";
		}

		public SysEntitySchemaRecordRight(SysEntitySchemaRecordRight source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Record Id.
		/// </summary>
		public Guid RecordId {
			get {
				return GetTypedColumnValue<Guid>("RecordId");
			}
			set {
				SetColumnValue("RecordId", value);
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
		/// Object.
		/// </summary>
		public SysAdminUnit SysAdminUnit {
			get {
				return _sysAdminUnit ??
					(_sysAdminUnit = LookupColumnEntities.GetEntity("SysAdminUnit") as SysAdminUnit);
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
		public Guid Column4Id {
			get {
				return GetTypedColumnValue<Guid>("Column4Id");
			}
			set {
				SetColumnValue("Column4Id", value);
				_column4 = null;
			}
		}

		/// <exclude/>
		public string Column4Name {
			get {
				return GetTypedColumnValue<string>("Column4Name");
			}
			set {
				SetColumnValue("Column4Name", value);
				if (_column4 != null) {
					_column4.Name = value;
				}
			}
		}

		private SysEntitySchemaRecOprRightLvl _column4;
		/// <summary>
		/// Access level.
		/// </summary>
		public SysEntitySchemaRecOprRightLvl Column4 {
			get {
				return _column4 ??
					(_column4 = LookupColumnEntities.GetEntity("Column4") as SysEntitySchemaRecOprRightLvl);
			}
		}

		/// <exclude/>
		public Guid SourceId {
			get {
				return GetTypedColumnValue<Guid>("SourceId");
			}
			set {
				SetColumnValue("SourceId", value);
				_source = null;
			}
		}

		/// <exclude/>
		public string SourceName {
			get {
				return GetTypedColumnValue<string>("SourceName");
			}
			set {
				SetColumnValue("SourceName", value);
				if (_source != null) {
					_source.Name = value;
				}
			}
		}

		private SysEntitySchemaRecRightSource _source;
		/// <summary>
		/// Access right source.
		/// </summary>
		public SysEntitySchemaRecRightSource Source {
			get {
				return _source ??
					(_source = LookupColumnEntities.GetEntity("Source") as SysEntitySchemaRecRightSource);
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

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysEntitySchemaRecordRight_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysEntitySchemaRecordRightDeleted", e);
			Deleting += (s, e) => ThrowEvent("SysEntitySchemaRecordRightDeleting", e);
			Inserted += (s, e) => ThrowEvent("SysEntitySchemaRecordRightInserted", e);
			Inserting += (s, e) => ThrowEvent("SysEntitySchemaRecordRightInserting", e);
			Saved += (s, e) => ThrowEvent("SysEntitySchemaRecordRightSaved", e);
			Saving += (s, e) => ThrowEvent("SysEntitySchemaRecordRightSaving", e);
			Validating += (s, e) => ThrowEvent("SysEntitySchemaRecordRightValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysEntitySchemaRecordRight(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysEntitySchemaRecordRight_BaseEventsProcess

	/// <exclude/>
	public partial class SysEntitySchemaRecordRight_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : SysEntitySchemaRecordRight
	{

		public SysEntitySchemaRecordRight_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysEntitySchemaRecordRight_BaseEventsProcess";
			SchemaUId = new Guid("509cef8b-8cdf-48e4-a41c-c0159f1e0bf7");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("509cef8b-8cdf-48e4-a41c-c0159f1e0bf7");
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

	#region Class: SysEntitySchemaRecordRight_BaseEventsProcess

	/// <exclude/>
	public class SysEntitySchemaRecordRight_BaseEventsProcess : SysEntitySchemaRecordRight_BaseEventsProcess<SysEntitySchemaRecordRight>
	{

		public SysEntitySchemaRecordRight_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysEntitySchemaRecordRight_BaseEventsProcess

	public partial class SysEntitySchemaRecordRight_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysEntitySchemaRecordRightEventsProcess

	/// <exclude/>
	public class SysEntitySchemaRecordRightEventsProcess : SysEntitySchemaRecordRight_BaseEventsProcess
	{

		public SysEntitySchemaRecordRightEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

