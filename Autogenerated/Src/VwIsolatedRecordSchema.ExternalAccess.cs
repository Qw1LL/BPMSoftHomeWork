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

	#region Class: VwIsolatedRecordSchema

	/// <exclude/>
	public class VwIsolatedRecordSchema : BPMSoft.Configuration.SysIsolatedRecordSchema
	{

		#region Constructors: Public

		public VwIsolatedRecordSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwIsolatedRecordSchema(VwIsolatedRecordSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwIsolatedRecordSchema(VwIsolatedRecordSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("4a1e15a3-a526-4b0f-b362-077730219ad1");
			RealUId = new Guid("4a1e15a3-a526-4b0f-b362-077730219ad1");
			Name = "VwIsolatedRecord";
			ParentSchemaUId = new Guid("d0dba5bf-0248-4a93-9396-583751d97281");
			ExtendParent = false;
			CreatedInPackageId = new Guid("5e504a85-b356-4f9f-8a4b-82ad398dd0cf");
			IsDBView = true;
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
			if (Columns.FindByUId(new Guid("c79ffbbb-d551-47e9-8e88-a65607f60c87")) == null) {
				Columns.Add(CreateEntitySchemaColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("da515b5b-3f53-4be6-a2bb-e8eab0fdae7f"),
				Name = @"Name",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("4a1e15a3-a526-4b0f-b362-077730219ad1"),
				ModifiedInSchemaUId = new Guid("4a1e15a3-a526-4b0f-b362-077730219ad1"),
				CreatedInPackageId = new Guid("5e504a85-b356-4f9f-8a4b-82ad398dd0cf")
			};
		}

		protected virtual EntitySchemaColumn CreateEntitySchemaColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("c79ffbbb-d551-47e9-8e88-a65607f60c87"),
				Name = @"EntitySchema",
				ReferenceSchemaUId = new Guid("90fa6d02-3e93-45d6-a72b-58dcffa411ae"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("4a1e15a3-a526-4b0f-b362-077730219ad1"),
				ModifiedInSchemaUId = new Guid("4a1e15a3-a526-4b0f-b362-077730219ad1"),
				CreatedInPackageId = new Guid("5e504a85-b356-4f9f-8a4b-82ad398dd0cf")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new VwIsolatedRecord(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwIsolatedRecord_ExternalAccessEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwIsolatedRecordSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwIsolatedRecordSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("4a1e15a3-a526-4b0f-b362-077730219ad1"));
		}

		#endregion

	}

	#endregion

	#region Class: VwIsolatedRecord

	/// <summary>
	/// VwIsolatedRecord.
	/// </summary>
	public class VwIsolatedRecord : BPMSoft.Configuration.SysIsolatedRecord
	{

		#region Constructors: Public

		public VwIsolatedRecord(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwIsolatedRecord";
		}

		public VwIsolatedRecord(VwIsolatedRecord source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Display value.
		/// </summary>
		public string Name {
			get {
				return GetTypedColumnValue<string>("Name");
			}
			set {
				SetColumnValue("Name", value);
			}
		}

		/// <exclude/>
		public Guid EntitySchemaId {
			get {
				return GetTypedColumnValue<Guid>("EntitySchemaId");
			}
			set {
				SetColumnValue("EntitySchemaId", value);
				_entitySchema = null;
			}
		}

		/// <exclude/>
		public string EntitySchemaCaption {
			get {
				return GetTypedColumnValue<string>("EntitySchemaCaption");
			}
			set {
				SetColumnValue("EntitySchemaCaption", value);
				if (_entitySchema != null) {
					_entitySchema.Caption = value;
				}
			}
		}

		private VwSysSchemaInfo _entitySchema;
		/// <summary>
		/// Entity schema.
		/// </summary>
		public VwSysSchemaInfo EntitySchema {
			get {
				return _entitySchema ??
					(_entitySchema = LookupColumnEntities.GetEntity("EntitySchema") as VwSysSchemaInfo);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new VwIsolatedRecord_ExternalAccessEventsProcess(UserConnection);
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
			return new VwIsolatedRecord(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwIsolatedRecord_ExternalAccessEventsProcess

	/// <exclude/>
	public partial class VwIsolatedRecord_ExternalAccessEventsProcess<TEntity> : BPMSoft.Configuration.SysIsolatedRecord_ExternalAccessEventsProcess<TEntity> where TEntity : VwIsolatedRecord
	{

		public VwIsolatedRecord_ExternalAccessEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwIsolatedRecord_ExternalAccessEventsProcess";
			SchemaUId = new Guid("4a1e15a3-a526-4b0f-b362-077730219ad1");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("4a1e15a3-a526-4b0f-b362-077730219ad1");
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

	#region Class: VwIsolatedRecord_ExternalAccessEventsProcess

	/// <exclude/>
	public class VwIsolatedRecord_ExternalAccessEventsProcess : VwIsolatedRecord_ExternalAccessEventsProcess<VwIsolatedRecord>
	{

		public VwIsolatedRecord_ExternalAccessEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VwIsolatedRecord_ExternalAccessEventsProcess

	public partial class VwIsolatedRecord_ExternalAccessEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: VwIsolatedRecordEventsProcess

	/// <exclude/>
	public class VwIsolatedRecordEventsProcess : VwIsolatedRecord_ExternalAccessEventsProcess
	{

		public VwIsolatedRecordEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

