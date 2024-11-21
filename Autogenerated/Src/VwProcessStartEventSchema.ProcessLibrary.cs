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

	#region Class: VwProcessStartEventSchema

	/// <exclude/>
	public class VwProcessStartEventSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public VwProcessStartEventSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwProcessStartEventSchema(VwProcessStartEventSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwProcessStartEventSchema(VwProcessStartEventSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("b096de9e-16fb-48f0-ab1c-537fc8c82d25");
			RealUId = new Guid("b096de9e-16fb-48f0-ab1c-537fc8c82d25");
			Name = "VwProcessStartEvent";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("f6d60a9d-cc0e-4590-a0d7-ea277724b939");
			IsDBView = true;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("a31e3bd0-f607-47c0-9711-b93c3bfb92a7")) == null) {
				Columns.Add(CreateEntitySchemaNameColumn());
			}
			if (Columns.FindByUId(new Guid("62d64411-ebbd-481b-b8b3-48f8952362e4")) == null) {
				Columns.Add(CreateRecordChangeTypeNameColumn());
			}
			if (Columns.FindByUId(new Guid("48b0b201-b27e-4791-8bd0-c667190fdeb7")) == null) {
				Columns.Add(CreateProcessElementUIdColumn());
			}
			if (Columns.FindByUId(new Guid("7554a551-2fed-4c56-89a6-87f80924f1fd")) == null) {
				Columns.Add(CreateProcessUIdColumn());
			}
			if (Columns.FindByUId(new Guid("4897c01f-6238-4d22-8ec2-230308f36869")) == null) {
				Columns.Add(CreateElementNameColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateEntitySchemaNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("a31e3bd0-f607-47c0-9711-b93c3bfb92a7"),
				Name = @"EntitySchemaName",
				CreatedInSchemaUId = new Guid("b096de9e-16fb-48f0-ab1c-537fc8c82d25"),
				ModifiedInSchemaUId = new Guid("b096de9e-16fb-48f0-ab1c-537fc8c82d25"),
				CreatedInPackageId = new Guid("f6d60a9d-cc0e-4590-a0d7-ea277724b939")
			};
		}

		protected virtual EntitySchemaColumn CreateRecordChangeTypeNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("62d64411-ebbd-481b-b8b3-48f8952362e4"),
				Name = @"RecordChangeTypeName",
				CreatedInSchemaUId = new Guid("b096de9e-16fb-48f0-ab1c-537fc8c82d25"),
				ModifiedInSchemaUId = new Guid("b096de9e-16fb-48f0-ab1c-537fc8c82d25"),
				CreatedInPackageId = new Guid("f6d60a9d-cc0e-4590-a0d7-ea277724b939")
			};
		}

		protected virtual EntitySchemaColumn CreateProcessElementUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("48b0b201-b27e-4791-8bd0-c667190fdeb7"),
				Name = @"ProcessElementUId",
				CreatedInSchemaUId = new Guid("b096de9e-16fb-48f0-ab1c-537fc8c82d25"),
				ModifiedInSchemaUId = new Guid("b096de9e-16fb-48f0-ab1c-537fc8c82d25"),
				CreatedInPackageId = new Guid("f6d60a9d-cc0e-4590-a0d7-ea277724b939")
			};
		}

		protected virtual EntitySchemaColumn CreateProcessUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("7554a551-2fed-4c56-89a6-87f80924f1fd"),
				Name = @"ProcessUId",
				CreatedInSchemaUId = new Guid("b096de9e-16fb-48f0-ab1c-537fc8c82d25"),
				ModifiedInSchemaUId = new Guid("b096de9e-16fb-48f0-ab1c-537fc8c82d25"),
				CreatedInPackageId = new Guid("f6d60a9d-cc0e-4590-a0d7-ea277724b939")
			};
		}

		protected virtual EntitySchemaColumn CreateElementNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("4897c01f-6238-4d22-8ec2-230308f36869"),
				Name = @"ElementName",
				CreatedInSchemaUId = new Guid("b096de9e-16fb-48f0-ab1c-537fc8c82d25"),
				ModifiedInSchemaUId = new Guid("b096de9e-16fb-48f0-ab1c-537fc8c82d25"),
				CreatedInPackageId = new Guid("f6d60a9d-cc0e-4590-a0d7-ea277724b939")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new VwProcessStartEvent(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwProcessStartEvent_ProcessLibraryEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwProcessStartEventSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwProcessStartEventSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("b096de9e-16fb-48f0-ab1c-537fc8c82d25"));
		}

		#endregion

	}

	#endregion

	#region Class: VwProcessStartEvent

	/// <summary>
	/// VwProcessStartEvent.
	/// </summary>
	public class VwProcessStartEvent : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public VwProcessStartEvent(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwProcessStartEvent";
		}

		public VwProcessStartEvent(VwProcessStartEvent source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Object.
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
		/// Signal type.
		/// </summary>
		public string RecordChangeTypeName {
			get {
				return GetTypedColumnValue<string>("RecordChangeTypeName");
			}
			set {
				SetColumnValue("RecordChangeTypeName", value);
			}
		}

		/// <summary>
		/// ProcessElementUId.
		/// </summary>
		public Guid ProcessElementUId {
			get {
				return GetTypedColumnValue<Guid>("ProcessElementUId");
			}
			set {
				SetColumnValue("ProcessElementUId", value);
			}
		}

		/// <summary>
		/// ProcessUId.
		/// </summary>
		public Guid ProcessUId {
			get {
				return GetTypedColumnValue<Guid>("ProcessUId");
			}
			set {
				SetColumnValue("ProcessUId", value);
			}
		}

		/// <summary>
		/// Element name.
		/// </summary>
		public string ElementName {
			get {
				return GetTypedColumnValue<string>("ElementName");
			}
			set {
				SetColumnValue("ElementName", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new VwProcessStartEvent_ProcessLibraryEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("VwProcessStartEventDeleted", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new VwProcessStartEvent(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwProcessStartEvent_ProcessLibraryEventsProcess

	/// <exclude/>
	public partial class VwProcessStartEvent_ProcessLibraryEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : VwProcessStartEvent
	{

		public VwProcessStartEvent_ProcessLibraryEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwProcessStartEvent_ProcessLibraryEventsProcess";
			SchemaUId = new Guid("b096de9e-16fb-48f0-ab1c-537fc8c82d25");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("b096de9e-16fb-48f0-ab1c-537fc8c82d25");
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

	#region Class: VwProcessStartEvent_ProcessLibraryEventsProcess

	/// <exclude/>
	public class VwProcessStartEvent_ProcessLibraryEventsProcess : VwProcessStartEvent_ProcessLibraryEventsProcess<VwProcessStartEvent>
	{

		public VwProcessStartEvent_ProcessLibraryEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VwProcessStartEvent_ProcessLibraryEventsProcess

	public partial class VwProcessStartEvent_ProcessLibraryEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: VwProcessStartEventEventsProcess

	/// <exclude/>
	public class VwProcessStartEventEventsProcess : VwProcessStartEvent_ProcessLibraryEventsProcess
	{

		public VwProcessStartEventEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

