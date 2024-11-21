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

	#region Class: SysIsolatedRecordSchema

	/// <exclude/>
	public class SysIsolatedRecordSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysIsolatedRecordSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysIsolatedRecordSchema(SysIsolatedRecordSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysIsolatedRecordSchema(SysIsolatedRecordSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("d0dba5bf-0248-4a93-9396-583751d97281");
			RealUId = new Guid("d0dba5bf-0248-4a93-9396-583751d97281");
			Name = "SysIsolatedRecord";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("7e406f3f-0514-4d14-a20b-c3a59a45194f");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateEntitySchemaNameColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("3653f165-0d35-45ea-8acf-48a669a5a28a")) == null) {
				Columns.Add(CreateRecordIdColumn());
			}
			if (Columns.FindByUId(new Guid("fa580cbe-be37-4f0d-b166-aed558042ea0")) == null) {
				Columns.Add(CreateExternalAccessColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateEntitySchemaNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("537fa4ca-25c5-4484-b722-f3e5b730adad"),
				Name = @"EntitySchemaName",
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("d0dba5bf-0248-4a93-9396-583751d97281"),
				ModifiedInSchemaUId = new Guid("d0dba5bf-0248-4a93-9396-583751d97281"),
				CreatedInPackageId = new Guid("7e406f3f-0514-4d14-a20b-c3a59a45194f")
			};
		}

		protected virtual EntitySchemaColumn CreateRecordIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("3653f165-0d35-45ea-8acf-48a669a5a28a"),
				Name = @"RecordId",
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("d0dba5bf-0248-4a93-9396-583751d97281"),
				ModifiedInSchemaUId = new Guid("d0dba5bf-0248-4a93-9396-583751d97281"),
				CreatedInPackageId = new Guid("7e406f3f-0514-4d14-a20b-c3a59a45194f")
			};
		}

		protected virtual EntitySchemaColumn CreateExternalAccessColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("fa580cbe-be37-4f0d-b166-aed558042ea0"),
				Name = @"ExternalAccess",
				ReferenceSchemaUId = new Guid("f3858e46-ea38-412e-af4a-2011f08718ae"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("d0dba5bf-0248-4a93-9396-583751d97281"),
				ModifiedInSchemaUId = new Guid("d0dba5bf-0248-4a93-9396-583751d97281"),
				CreatedInPackageId = new Guid("edb637f8-a36b-404a-83af-5c35db85ff97")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysIsolatedRecord(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysIsolatedRecord_ExternalAccessEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysIsolatedRecordSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysIsolatedRecordSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("d0dba5bf-0248-4a93-9396-583751d97281"));
		}

		#endregion

	}

	#endregion

	#region Class: SysIsolatedRecord

	/// <summary>
	/// SysIsolatedRecord.
	/// </summary>
	public class SysIsolatedRecord : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysIsolatedRecord(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysIsolatedRecord";
		}

		public SysIsolatedRecord(SysIsolatedRecord source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Entity schema name.
		/// </summary>
		public string EntitySchemaName {
			get {
				return GetTypedColumnValue<string>("EntitySchemaName");
			}
			set {
				SetColumnValue("EntitySchemaName", value);
			}
		}

		/// <summary>
		/// Record id.
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
		public Guid ExternalAccessId {
			get {
				return GetTypedColumnValue<Guid>("ExternalAccessId");
			}
			set {
				SetColumnValue("ExternalAccessId", value);
				_externalAccess = null;
			}
		}

		/// <exclude/>
		public string ExternalAccessAccessReason {
			get {
				return GetTypedColumnValue<string>("ExternalAccessAccessReason");
			}
			set {
				SetColumnValue("ExternalAccessAccessReason", value);
				if (_externalAccess != null) {
					_externalAccess.AccessReason = value;
				}
			}
		}

		private ExternalAccess _externalAccess;
		/// <summary>
		/// Created by external access.
		/// </summary>
		public ExternalAccess ExternalAccess {
			get {
				return _externalAccess ??
					(_externalAccess = LookupColumnEntities.GetEntity("ExternalAccess") as ExternalAccess);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysIsolatedRecord_ExternalAccessEventsProcess(UserConnection);
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
			return new SysIsolatedRecord(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysIsolatedRecord_ExternalAccessEventsProcess

	/// <exclude/>
	public partial class SysIsolatedRecord_ExternalAccessEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : SysIsolatedRecord
	{

		public SysIsolatedRecord_ExternalAccessEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysIsolatedRecord_ExternalAccessEventsProcess";
			SchemaUId = new Guid("d0dba5bf-0248-4a93-9396-583751d97281");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("d0dba5bf-0248-4a93-9396-583751d97281");
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

	#region Class: SysIsolatedRecord_ExternalAccessEventsProcess

	/// <exclude/>
	public class SysIsolatedRecord_ExternalAccessEventsProcess : SysIsolatedRecord_ExternalAccessEventsProcess<SysIsolatedRecord>
	{

		public SysIsolatedRecord_ExternalAccessEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysIsolatedRecord_ExternalAccessEventsProcess

	public partial class SysIsolatedRecord_ExternalAccessEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysIsolatedRecordEventsProcess

	/// <exclude/>
	public class SysIsolatedRecordEventsProcess : SysIsolatedRecord_ExternalAccessEventsProcess
	{

		public SysIsolatedRecordEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

