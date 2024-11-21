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
	using BPMSoft.Core.Store;
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

	#region Class: SysModuleVisaSchema

	/// <exclude/>
	public class SysModuleVisaSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysModuleVisaSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysModuleVisaSchema(SysModuleVisaSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysModuleVisaSchema(SysModuleVisaSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("1980906b-3a10-489c-b67c-30d74100b8cb");
			RealUId = new Guid("1980906b-3a10-489c-b67c-30d74100b8cb");
			Name = "SysModuleVisa";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("f06e2eda-824e-415b-8e16-bcd4bd1cec90")) == null) {
				Columns.Add(CreateUseCustomNotificationProviderColumn());
			}
			if (Columns.FindByUId(new Guid("dc6037ae-6e25-4920-ab27-10d3dd9e2e1e")) == null) {
				Columns.Add(CreateVisaSchemaUIdColumn());
			}
			if (Columns.FindByUId(new Guid("5868314d-f071-4b55-9ccc-a5557609f72c")) == null) {
				Columns.Add(CreateMasterColumnUIdColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateUseCustomNotificationProviderColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("f06e2eda-824e-415b-8e16-bcd4bd1cec90"),
				Name = @"UseCustomNotificationProvider",
				CreatedInSchemaUId = new Guid("1980906b-3a10-489c-b67c-30d74100b8cb"),
				ModifiedInSchemaUId = new Guid("1980906b-3a10-489c-b67c-30d74100b8cb"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateVisaSchemaUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("dc6037ae-6e25-4920-ab27-10d3dd9e2e1e"),
				Name = @"VisaSchemaUId",
				CreatedInSchemaUId = new Guid("1980906b-3a10-489c-b67c-30d74100b8cb"),
				ModifiedInSchemaUId = new Guid("1980906b-3a10-489c-b67c-30d74100b8cb"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateMasterColumnUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("5868314d-f071-4b55-9ccc-a5557609f72c"),
				Name = @"MasterColumnUId",
				CreatedInSchemaUId = new Guid("1980906b-3a10-489c-b67c-30d74100b8cb"),
				ModifiedInSchemaUId = new Guid("1980906b-3a10-489c-b67c-30d74100b8cb"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysModuleVisa(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysModuleVisa_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysModuleVisaSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysModuleVisaSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("1980906b-3a10-489c-b67c-30d74100b8cb"));
		}

		#endregion

	}

	#endregion

	#region Class: SysModuleVisa

	/// <summary>
	/// Section approval settings.
	/// </summary>
	public class SysModuleVisa : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysModuleVisa(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysModuleVisa";
		}

		public SysModuleVisa(SysModuleVisa source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// UseCustomNotificationProvider.
		/// </summary>
		public bool UseCustomNotificationProvider {
			get {
				return GetTypedColumnValue<bool>("UseCustomNotificationProvider");
			}
			set {
				SetColumnValue("UseCustomNotificationProvider", value);
			}
		}

		/// <summary>
		/// Visa schema identifier.
		/// </summary>
		public Guid VisaSchemaUId {
			get {
				return GetTypedColumnValue<Guid>("VisaSchemaUId");
			}
			set {
				SetColumnValue("VisaSchemaUId", value);
			}
		}

		/// <summary>
		/// Section entity column identifier.
		/// </summary>
		public Guid MasterColumnUId {
			get {
				return GetTypedColumnValue<Guid>("MasterColumnUId");
			}
			set {
				SetColumnValue("MasterColumnUId", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysModuleVisa_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysModuleVisaDeleted", e);
			Saving += (s, e) => ThrowEvent("SysModuleVisaSaving", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysModuleVisa(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysModuleVisa_BaseEventsProcess

	/// <exclude/>
	public partial class SysModuleVisa_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : SysModuleVisa
	{

		public SysModuleVisa_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysModuleVisa_BaseEventsProcess";
			SchemaUId = new Guid("1980906b-3a10-489c-b67c-30d74100b8cb");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("1980906b-3a10-489c-b67c-30d74100b8cb");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		private ProcessFlowElement _eventSubProcess3_8f17dbbf2a9a4ceb976aea813b51feaf;
		public ProcessFlowElement EventSubProcess3_8f17dbbf2a9a4ceb976aea813b51feaf {
			get {
				return _eventSubProcess3_8f17dbbf2a9a4ceb976aea813b51feaf ?? (_eventSubProcess3_8f17dbbf2a9a4ceb976aea813b51feaf = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventSubProcess3_8f17dbbf2a9a4ceb976aea813b51feaf",
					SchemaElementUId = new Guid("8f17dbbf-2a9a-4ceb-976a-ea813b51feaf"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _startMessage3_7adbd29fbe7f44bfbb742ab4fcae87c4;
		public ProcessFlowElement StartMessage3_7adbd29fbe7f44bfbb742ab4fcae87c4 {
			get {
				return _startMessage3_7adbd29fbe7f44bfbb742ab4fcae87c4 ?? (_startMessage3_7adbd29fbe7f44bfbb742ab4fcae87c4 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "StartMessage3_7adbd29fbe7f44bfbb742ab4fcae87c4",
					SchemaElementUId = new Guid("7adbd29f-be7f-44bf-bb74-2ab4fcae87c4"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _scriptTask3_6cf309493e44498f94d2b735636ea708;
		public ProcessScriptTask ScriptTask3_6cf309493e44498f94d2b735636ea708 {
			get {
				return _scriptTask3_6cf309493e44498f94d2b735636ea708 ?? (_scriptTask3_6cf309493e44498f94d2b735636ea708 = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptTask3_6cf309493e44498f94d2b735636ea708",
					SchemaElementUId = new Guid("6cf30949-3e44-498f-94d2-b735636ea708"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ScriptTask3_6cf309493e44498f94d2b735636ea708Execute,
				});
			}
		}

		private ProcessTerminateEvent _terminateEvent1_dff9ba1b625243819b89d3500370d8e9;
		public ProcessTerminateEvent TerminateEvent1_dff9ba1b625243819b89d3500370d8e9 {
			get {
				return _terminateEvent1_dff9ba1b625243819b89d3500370d8e9 ?? (_terminateEvent1_dff9ba1b625243819b89d3500370d8e9 = new ProcessTerminateEvent() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaTerminateEvent",
					Name = "TerminateEvent1_dff9ba1b625243819b89d3500370d8e9",
					SchemaElementUId = new Guid("dff9ba1b-6252-4381-9b89-d3500370d8e9"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[EventSubProcess3_8f17dbbf2a9a4ceb976aea813b51feaf.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess3_8f17dbbf2a9a4ceb976aea813b51feaf };
			FlowElements[StartMessage3_7adbd29fbe7f44bfbb742ab4fcae87c4.SchemaElementUId] = new Collection<ProcessFlowElement> { StartMessage3_7adbd29fbe7f44bfbb742ab4fcae87c4 };
			FlowElements[ScriptTask3_6cf309493e44498f94d2b735636ea708.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptTask3_6cf309493e44498f94d2b735636ea708 };
			FlowElements[TerminateEvent1_dff9ba1b625243819b89d3500370d8e9.SchemaElementUId] = new Collection<ProcessFlowElement> { TerminateEvent1_dff9ba1b625243819b89d3500370d8e9 };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "EventSubProcess3_8f17dbbf2a9a4ceb976aea813b51feaf":
						break;
					case "StartMessage3_7adbd29fbe7f44bfbb742ab4fcae87c4":
						e.Context.QueueTasks.Enqueue("ScriptTask3_6cf309493e44498f94d2b735636ea708");
						break;
					case "ScriptTask3_6cf309493e44498f94d2b735636ea708":
						e.Context.QueueTasks.Enqueue("TerminateEvent1_dff9ba1b625243819b89d3500370d8e9");
						break;
					case "TerminateEvent1_dff9ba1b625243819b89d3500370d8e9":
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("StartMessage3_7adbd29fbe7f44bfbb742ab4fcae87c4");
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			switch (context.QueueTasks.Peek()) {
				case "EventSubProcess3_8f17dbbf2a9a4ceb976aea813b51feaf":
					context.QueueTasks.Dequeue();
					break;
				case "StartMessage3_7adbd29fbe7f44bfbb742ab4fcae87c4":
					context.QueueTasks.Dequeue();
					context.SenderName = "StartMessage3_7adbd29fbe7f44bfbb742ab4fcae87c4";
					result = StartMessage3_7adbd29fbe7f44bfbb742ab4fcae87c4.Execute(context);
					break;
				case "ScriptTask3_6cf309493e44498f94d2b735636ea708":
					context.QueueTasks.Dequeue();
					context.SenderName = "ScriptTask3_6cf309493e44498f94d2b735636ea708";
					result = ScriptTask3_6cf309493e44498f94d2b735636ea708.Execute(context, ScriptTask3_6cf309493e44498f94d2b735636ea708Execute);
					break;
				case "TerminateEvent1_dff9ba1b625243819b89d3500370d8e9":
					context.QueueTasks.Dequeue();
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool ScriptTask3_6cf309493e44498f94d2b735636ea708Execute(ProcessExecutingContext context) {
			ClearCache();
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "SysModuleVisaSaving":
							if (ActivatedEventElements.Contains("StartMessage3_7adbd29fbe7f44bfbb742ab4fcae87c4")) {
							context.QueueTasks.Enqueue("StartMessage3_7adbd29fbe7f44bfbb742ab4fcae87c4");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: SysModuleVisa_BaseEventsProcess

	/// <exclude/>
	public class SysModuleVisa_BaseEventsProcess : SysModuleVisa_BaseEventsProcess<SysModuleVisa>
	{

		public SysModuleVisa_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysModuleVisa_BaseEventsProcess

	public partial class SysModuleVisa_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		public virtual void ClearCache() {
			Store.Cache[CacheLevel.Application].ExpireGroup(CachedSysModuleVisaRepository.SysModuleVisaCacheGroupName);
		}

		#endregion

	}

	#endregion


	#region Class: SysModuleVisaEventsProcess

	/// <exclude/>
	public class SysModuleVisaEventsProcess : SysModuleVisa_BaseEventsProcess
	{

		public SysModuleVisaEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

