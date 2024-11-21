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

	#region Class: SysProcessIntermediateEventSchema

	/// <exclude/>
	public class SysProcessIntermediateEventSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysProcessIntermediateEventSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysProcessIntermediateEventSchema(SysProcessIntermediateEventSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysProcessIntermediateEventSchema(SysProcessIntermediateEventSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("0b8d365b-7348-4ef1-97d7-c5dbd6c86141");
			RealUId = new Guid("0b8d365b-7348-4ef1-97d7-c5dbd6c86141");
			Name = "SysProcessIntermediateEvent";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("6f903fc3-cfd6-46a3-8e62-8aff4e508b90")) == null) {
				Columns.Add(CreateSysProcessElementColumn());
			}
			if (Columns.FindByUId(new Guid("9df49c63-44c3-45e0-aca6-c95a04ee42f8")) == null) {
				Columns.Add(CreateMessageColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateSysProcessElementColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("6f903fc3-cfd6-46a3-8e62-8aff4e508b90"),
				Name = @"SysProcessElement",
				ReferenceSchemaUId = new Guid("a195aa99-8c5b-47e0-a9a6-9bac0ddd5bd0"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("0b8d365b-7348-4ef1-97d7-c5dbd6c86141"),
				ModifiedInSchemaUId = new Guid("0b8d365b-7348-4ef1-97d7-c5dbd6c86141"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateMessageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("9df49c63-44c3-45e0-aca6-c95a04ee42f8"),
				Name = @"Message",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("0b8d365b-7348-4ef1-97d7-c5dbd6c86141"),
				ModifiedInSchemaUId = new Guid("0b8d365b-7348-4ef1-97d7-c5dbd6c86141"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysProcessIntermediateEvent(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysProcessIntermediateEvent_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysProcessIntermediateEventSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysProcessIntermediateEventSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("0b8d365b-7348-4ef1-97d7-c5dbd6c86141"));
		}

		#endregion

	}

	#endregion

	#region Class: SysProcessIntermediateEvent

	/// <summary>
	/// Process event.
	/// </summary>
	public class SysProcessIntermediateEvent : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysProcessIntermediateEvent(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysProcessIntermediateEvent";
		}

		public SysProcessIntermediateEvent(SysProcessIntermediateEvent source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid SysProcessElementId {
			get {
				return GetTypedColumnValue<Guid>("SysProcessElementId");
			}
			set {
				SetColumnValue("SysProcessElementId", value);
				_sysProcessElement = null;
			}
		}

		private SysProcessElementData _sysProcessElement;
		/// <summary>
		/// Process item.
		/// </summary>
		public SysProcessElementData SysProcessElement {
			get {
				return _sysProcessElement ??
					(_sysProcessElement = LookupColumnEntities.GetEntity("SysProcessElement") as SysProcessElementData);
			}
		}

		/// <summary>
		/// Event.
		/// </summary>
		public string Message {
			get {
				return GetTypedColumnValue<string>("Message");
			}
			set {
				SetColumnValue("Message", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysProcessIntermediateEvent_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysProcessIntermediateEventDeleted", e);
			Deleting += (s, e) => ThrowEvent("SysProcessIntermediateEventDeleting", e);
			Inserted += (s, e) => ThrowEvent("SysProcessIntermediateEventInserted", e);
			Inserting += (s, e) => ThrowEvent("SysProcessIntermediateEventInserting", e);
			Saved += (s, e) => ThrowEvent("SysProcessIntermediateEventSaved", e);
			Saving += (s, e) => ThrowEvent("SysProcessIntermediateEventSaving", e);
			Validating += (s, e) => ThrowEvent("SysProcessIntermediateEventValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysProcessIntermediateEvent(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysProcessIntermediateEvent_BaseEventsProcess

	/// <exclude/>
	public partial class SysProcessIntermediateEvent_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : SysProcessIntermediateEvent
	{

		public SysProcessIntermediateEvent_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysProcessIntermediateEvent_BaseEventsProcess";
			SchemaUId = new Guid("0b8d365b-7348-4ef1-97d7-c5dbd6c86141");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("0b8d365b-7348-4ef1-97d7-c5dbd6c86141");
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

	#region Class: SysProcessIntermediateEvent_BaseEventsProcess

	/// <exclude/>
	public class SysProcessIntermediateEvent_BaseEventsProcess : SysProcessIntermediateEvent_BaseEventsProcess<SysProcessIntermediateEvent>
	{

		public SysProcessIntermediateEvent_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysProcessIntermediateEvent_BaseEventsProcess

	public partial class SysProcessIntermediateEvent_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysProcessIntermediateEventEventsProcess

	/// <exclude/>
	public class SysProcessIntermediateEventEventsProcess : SysProcessIntermediateEvent_BaseEventsProcess
	{

		public SysProcessIntermediateEventEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

