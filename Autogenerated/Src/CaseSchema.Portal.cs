namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Configuration;
	using BPMSoft.Configuration.RightsService;
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
	using CoreSysSettings = BPMSoft.Core.Configuration.SysSettings;
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
	using System.Text;

	#region Class: Case_Portal_BPMSoftSchema

	/// <exclude/>
	public class Case_Portal_BPMSoftSchema : BPMSoft.Configuration.Case_CMDB_BPMSoftSchema
	{

		#region Constructors: Public

		public Case_Portal_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public Case_Portal_BPMSoftSchema(Case_Portal_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public Case_Portal_BPMSoftSchema(Case_Portal_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateIX_RegisteredOn_DescIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = false
			};
			index.UId = new Guid("9ed6688c-3e02-47af-9124-e38e20904716");
			index.Name = "IX_RegisteredOn_Desc";
			index.CreatedInSchemaUId = new Guid("117d32f9-8275-4534-8411-1c66115ce9cd");
			index.ModifiedInSchemaUId = new Guid("117d32f9-8275-4534-8411-1c66115ce9cd");
			index.CreatedInPackageId = new Guid("a7919973-994c-4956-b846-530c9ef3b289");
			EntitySchemaIndexColumn registeredOnIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("aa03e37c-3527-4b5c-a16c-53fbc178b41e"),
				ColumnUId = new Guid("c91a9a6f-008d-4b2e-83d5-03868ad68c99"),
				CreatedInSchemaUId = new Guid("117d32f9-8275-4534-8411-1c66115ce9cd"),
				ModifiedInSchemaUId = new Guid("117d32f9-8275-4534-8411-1c66115ce9cd"),
				CreatedInPackageId = new Guid("a7919973-994c-4956-b846-530c9ef3b289"),
				OrderDirection = OrderDirectionStrict.Descending
			};
			index.Columns.Add(registeredOnIndexColumn);
			return index;
		}

		private EntitySchemaIndex CreateIX_SolutionOverdue_AttributesIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = false
			};
			index.UId = new Guid("9ad0ba05-3b32-4561-8bfc-870aee9c951c");
			index.Name = "IX_SolutionOverdue_Attributes";
			index.CreatedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c");
			index.ModifiedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c");
			index.CreatedInPackageId = new Guid("c3c90037-274c-4793-841e-197eb228d3cd");
			EntitySchemaIndexColumn solutionProvidedOnIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("4f3631c8-b14e-4591-a25a-b9207401cfa2"),
				ColumnUId = new Guid("81552f0a-fd92-4865-9533-f4c3ab2861a7"),
				CreatedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c"),
				ModifiedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c"),
				CreatedInPackageId = new Guid("c3c90037-274c-4793-841e-197eb228d3cd"),
				OrderDirection = OrderDirectionStrict.Descending
			};
			index.Columns.Add(solutionProvidedOnIndexColumn);
			EntitySchemaIndexColumn solutionDateIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("5de35510-255d-4f3f-8119-9a3f9b8082f5"),
				ColumnUId = new Guid("624839d1-3bd0-45e0-95d1-28326703f19c"),
				CreatedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c"),
				ModifiedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c"),
				CreatedInPackageId = new Guid("c3c90037-274c-4793-841e-197eb228d3cd"),
				OrderDirection = OrderDirectionStrict.Descending
			};
			index.Columns.Add(solutionDateIndexColumn);
			EntitySchemaIndexColumn solutionOverdueIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("8dab4368-f988-43de-a48e-bbf238fc3237"),
				ColumnUId = new Guid("0fa66efc-d2d0-47b9-abab-9e3ad2ea82d3"),
				CreatedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c"),
				ModifiedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c"),
				CreatedInPackageId = new Guid("c3c90037-274c-4793-841e-197eb228d3cd"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(solutionOverdueIndexColumn);
			return index;
		}

		private EntitySchemaIndex CreateIX_ResponseOverdue_AttributesIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = false
			};
			index.UId = new Guid("8d002ad1-0715-4bdc-aa5e-8be1a5e39381");
			index.Name = "IX_ResponseOverdue_Attributes";
			index.CreatedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c");
			index.ModifiedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c");
			index.CreatedInPackageId = new Guid("c3c90037-274c-4793-841e-197eb228d3cd");
			EntitySchemaIndexColumn respondedOnIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("14abc9af-1b98-4ee2-b236-3a9576b1770f"),
				ColumnUId = new Guid("02612dc8-7243-4acb-b0bd-abbd19e24136"),
				CreatedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c"),
				ModifiedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c"),
				CreatedInPackageId = new Guid("c3c90037-274c-4793-841e-197eb228d3cd"),
				OrderDirection = OrderDirectionStrict.Descending
			};
			index.Columns.Add(respondedOnIndexColumn);
			EntitySchemaIndexColumn responseDateIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("c3226bd5-beb9-48ea-9383-30fb120d4f4d"),
				ColumnUId = new Guid("25280121-c075-441f-b4f8-feeb6cc7ca38"),
				CreatedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c"),
				ModifiedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c"),
				CreatedInPackageId = new Guid("c3c90037-274c-4793-841e-197eb228d3cd"),
				OrderDirection = OrderDirectionStrict.Descending
			};
			index.Columns.Add(responseDateIndexColumn);
			EntitySchemaIndexColumn responseOverdueIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("a4aaaa1e-d84e-48a2-84ac-04c35a6fad1e"),
				ColumnUId = new Guid("1ed4e080-0bf8-4f4f-97e8-b3e22f3240a0"),
				CreatedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c"),
				ModifiedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c"),
				CreatedInPackageId = new Guid("c3c90037-274c-4793-841e-197eb228d3cd"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(responseOverdueIndexColumn);
			return index;
		}

		private EntitySchemaIndex CreateIDX_SubjectIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = false
			};
			index.UId = new Guid("e675ceca-ff2f-44c2-bd1a-f2c1af261cba");
			index.Name = "IDX_Subject";
			index.CreatedInSchemaUId = new Guid("117d32f9-8275-4534-8411-1c66115ce9cd");
			index.ModifiedInSchemaUId = new Guid("117d32f9-8275-4534-8411-1c66115ce9cd");
			index.CreatedInPackageId = new Guid("ff020f92-eb95-49ea-a251-6a0ed7e274a5");
			EntitySchemaIndexColumn subjectIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("5f164afe-e5a5-40a6-9e32-b7f83656bba8"),
				ColumnUId = new Guid("ffe8526d-044f-4222-a1ef-fca83a0772d8"),
				CreatedInSchemaUId = new Guid("117d32f9-8275-4534-8411-1c66115ce9cd"),
				ModifiedInSchemaUId = new Guid("117d32f9-8275-4534-8411-1c66115ce9cd"),
				CreatedInPackageId = new Guid("ff020f92-eb95-49ea-a251-6a0ed7e274a5"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(subjectIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("eb77295e-ed97-455b-9789-b59e647eaff4");
			Name = "Case_Portal_BPMSoft";
			ParentSchemaUId = new Guid("117d32f9-8275-4534-8411-1c66115ce9cd");
			ExtendParent = true;
			CreatedInPackageId = new Guid("45ba80cd-f9d9-41f0-bc12-0d4745b932db");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateIX_RegisteredOn_DescIndex());
			Indexes.Add(CreateIX_SolutionOverdue_AttributesIndex());
			Indexes.Add(CreateIX_ResponseOverdue_AttributesIndex());
			Indexes.Add(CreateIDX_SubjectIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new Case_Portal_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Case_PortalEventsProcess(userConnection);
		}

		public override object Clone() {
			return new Case_Portal_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new Case_Portal_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("eb77295e-ed97-455b-9789-b59e647eaff4"));
		}

		#endregion

	}

	#endregion

	#region Class: Case_Portal_BPMSoft

	/// <summary>
	/// Обращение.
	/// </summary>
	public class Case_Portal_BPMSoft : BPMSoft.Configuration.Case_CMDB_BPMSoft
	{

		#region Constructors: Public

		public Case_Portal_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Case_Portal_BPMSoft";
		}

		public Case_Portal_BPMSoft(Case_Portal_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Case_PortalEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("Case_Portal_BPMSoftDeleted", e);
			Saved += (s, e) => ThrowEvent("Case_Portal_BPMSoftSaved", e);
			Saving += (s, e) => ThrowEvent("Case_Portal_BPMSoftSaving", e);
			SaveError += (s, e) => ThrowEvent("Case_Portal_BPMSoftSaveError", e);
			Validating += (s, e) => ThrowEvent("Case_Portal_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new Case_Portal_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: Case_PortalEventsProcess

	/// <exclude/>
	public partial class Case_PortalEventsProcess<TEntity> : BPMSoft.Configuration.Case_CMDBEventsProcess<TEntity> where TEntity : Case_Portal_BPMSoft
	{

		public Case_PortalEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Case_PortalEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("eb77295e-ed97-455b-9789-b59e647eaff4");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		public virtual Guid OldContactId {
			get;
			set;
		}

		private ProcessFlowElement _eventSubProcess4;
		public ProcessFlowElement EventSubProcess4 {
			get {
				return _eventSubProcess4 ?? (_eventSubProcess4 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventSubProcess4",
					SchemaElementUId = new Guid("6aa29e17-158b-418e-90ba-40126fef7dfe"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _startMessage6;
		public ProcessFlowElement StartMessage6 {
			get {
				return _startMessage6 ?? (_startMessage6 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "StartMessage6",
					SchemaElementUId = new Guid("61adac11-e0ce-400f-bc57-4a4e533e616c"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessThrowMessageEvent _intermediateThrowMessageEvent1;
		public ProcessThrowMessageEvent IntermediateThrowMessageEvent1 {
			get {
				return _intermediateThrowMessageEvent1 ?? (_intermediateThrowMessageEvent1 = new ProcessThrowMessageEvent() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaIntermediateThrowMessageEvent",
					Name = "IntermediateThrowMessageEvent1",
					SchemaElementUId = new Guid("55a59700-b6f2-45c2-95ac-36428422953e"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Message = "CaseInserting",
						ThrowToBase = true,
				});
			}
		}

		private ProcessScriptTask _setEmptyOwnerScriptTask;
		public ProcessScriptTask SetEmptyOwnerScriptTask {
			get {
				return _setEmptyOwnerScriptTask ?? (_setEmptyOwnerScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "SetEmptyOwnerScriptTask",
					SchemaElementUId = new Guid("1c39d39d-39de-47ef-8787-2d7e3152c6dc"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = SetEmptyOwnerScriptTaskExecute,
				});
			}
		}

		private ProcessFlowElement _eventSubProcess5;
		public ProcessFlowElement EventSubProcess5 {
			get {
				return _eventSubProcess5 ?? (_eventSubProcess5 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventSubProcess5",
					SchemaElementUId = new Guid("1782e20a-cce0-442f-a0ac-832bdf976ccc"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _caseSavedStartMessage;
		public ProcessFlowElement CaseSavedStartMessage {
			get {
				return _caseSavedStartMessage ?? (_caseSavedStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "CaseSavedStartMessage",
					SchemaElementUId = new Guid("b461cd29-d3f1-4ce2-af6d-f94f62f5c037"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessThrowMessageEvent _baseCaseSaved;
		public ProcessThrowMessageEvent BaseCaseSaved {
			get {
				return _baseCaseSaved ?? (_baseCaseSaved = new ProcessThrowMessageEvent() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaIntermediateThrowMessageEvent",
					Name = "BaseCaseSaved",
					SchemaElementUId = new Guid("5ee06747-a8ce-4fff-af35-7b652461e7af"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Message = "CaseSaved",
						ThrowToBase = true,
				});
			}
		}

		private ProcessScriptTask _caseSavedScriptTask;
		public ProcessScriptTask CaseSavedScriptTask {
			get {
				return _caseSavedScriptTask ?? (_caseSavedScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "CaseSavedScriptTask",
					SchemaElementUId = new Guid("609094a6-78ca-474b-8128-cbc58d434eef"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = CaseSavedScriptTaskExecute,
				});
			}
		}

		private ProcessFlowElement _eventSubProcess6;
		public ProcessFlowElement EventSubProcess6 {
			get {
				return _eventSubProcess6 ?? (_eventSubProcess6 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventSubProcess6",
					SchemaElementUId = new Guid("907a17e3-36ea-4f4a-9a02-1e31adfa6f1c"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _caseSavingStartMessage;
		public ProcessFlowElement CaseSavingStartMessage {
			get {
				return _caseSavingStartMessage ?? (_caseSavingStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "CaseSavingStartMessage",
					SchemaElementUId = new Guid("07851372-07b8-4613-94cd-a3544cb65205"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessThrowMessageEvent _baseCaseSaving;
		public ProcessThrowMessageEvent BaseCaseSaving {
			get {
				return _baseCaseSaving ?? (_baseCaseSaving = new ProcessThrowMessageEvent() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaIntermediateThrowMessageEvent",
					Name = "BaseCaseSaving",
					SchemaElementUId = new Guid("cb6c74a4-240c-4bf3-b1bb-054813817120"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Message = "CaseSaving",
						ThrowToBase = true,
				});
			}
		}

		private ProcessScriptTask _portalCaseSavingScriptTask;
		public ProcessScriptTask PortalCaseSavingScriptTask {
			get {
				return _portalCaseSavingScriptTask ?? (_portalCaseSavingScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "PortalCaseSavingScriptTask",
					SchemaElementUId = new Guid("fe7ac697-80e2-4a92-a45b-96e7b8eb6115"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = PortalCaseSavingScriptTaskExecute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[EventSubProcess4.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess4 };
			FlowElements[StartMessage6.SchemaElementUId] = new Collection<ProcessFlowElement> { StartMessage6 };
			FlowElements[IntermediateThrowMessageEvent1.SchemaElementUId] = new Collection<ProcessFlowElement> { IntermediateThrowMessageEvent1 };
			FlowElements[SetEmptyOwnerScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { SetEmptyOwnerScriptTask };
			FlowElements[EventSubProcess5.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess5 };
			FlowElements[CaseSavedStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { CaseSavedStartMessage };
			FlowElements[BaseCaseSaved.SchemaElementUId] = new Collection<ProcessFlowElement> { BaseCaseSaved };
			FlowElements[CaseSavedScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { CaseSavedScriptTask };
			FlowElements[EventSubProcess6.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess6 };
			FlowElements[CaseSavingStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { CaseSavingStartMessage };
			FlowElements[BaseCaseSaving.SchemaElementUId] = new Collection<ProcessFlowElement> { BaseCaseSaving };
			FlowElements[PortalCaseSavingScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { PortalCaseSavingScriptTask };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "EventSubProcess4":
						break;
					case "StartMessage6":
						e.Context.QueueTasks.Enqueue("IntermediateThrowMessageEvent1");
						break;
					case "IntermediateThrowMessageEvent1":
						e.Context.QueueTasks.Enqueue("SetEmptyOwnerScriptTask");
						break;
					case "SetEmptyOwnerScriptTask":
						break;
					case "EventSubProcess5":
						break;
					case "CaseSavedStartMessage":
						e.Context.QueueTasks.Enqueue("BaseCaseSaved");
						break;
					case "BaseCaseSaved":
						e.Context.QueueTasks.Enqueue("CaseSavedScriptTask");
						break;
					case "CaseSavedScriptTask":
						break;
					case "EventSubProcess6":
						break;
					case "CaseSavingStartMessage":
						e.Context.QueueTasks.Enqueue("BaseCaseSaving");
						break;
					case "BaseCaseSaving":
						e.Context.QueueTasks.Enqueue("PortalCaseSavingScriptTask");
						break;
					case "PortalCaseSavingScriptTask":
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("StartMessage6");
			ActivatedEventElements.Add("CaseSavedStartMessage");
			ActivatedEventElements.Add("CaseSavingStartMessage");
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			switch (context.QueueTasks.Peek()) {
				case "EventSubProcess4":
					context.QueueTasks.Dequeue();
					break;
				case "StartMessage6":
					context.QueueTasks.Dequeue();
					context.SenderName = "StartMessage6";
					result = StartMessage6.Execute(context);
					break;
				case "IntermediateThrowMessageEvent1":
					context.QueueTasks.Dequeue();
					base.ThrowEvent(context, "CaseInserting");
					result = IntermediateThrowMessageEvent1.Execute(context);
					break;
				case "SetEmptyOwnerScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "SetEmptyOwnerScriptTask";
					result = SetEmptyOwnerScriptTask.Execute(context, SetEmptyOwnerScriptTaskExecute);
					break;
				case "EventSubProcess5":
					context.QueueTasks.Dequeue();
					break;
				case "CaseSavedStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "CaseSavedStartMessage";
					result = CaseSavedStartMessage.Execute(context);
					break;
				case "BaseCaseSaved":
					context.QueueTasks.Dequeue();
					base.ThrowEvent(context, "CaseSaved");
					result = BaseCaseSaved.Execute(context);
					break;
				case "CaseSavedScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "CaseSavedScriptTask";
					result = CaseSavedScriptTask.Execute(context, CaseSavedScriptTaskExecute);
					break;
				case "EventSubProcess6":
					context.QueueTasks.Dequeue();
					break;
				case "CaseSavingStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "CaseSavingStartMessage";
					result = CaseSavingStartMessage.Execute(context);
					break;
				case "BaseCaseSaving":
					context.QueueTasks.Dequeue();
					base.ThrowEvent(context, "CaseSaving");
					result = BaseCaseSaving.Execute(context);
					break;
				case "PortalCaseSavingScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "PortalCaseSavingScriptTask";
					result = PortalCaseSavingScriptTask.Execute(context, PortalCaseSavingScriptTaskExecute);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool SetEmptyOwnerScriptTaskExecute(ProcessExecutingContext context) {
			if (UserConnection.CurrentUser.ConnectionType == UserType.SSP) {
				Entity.SetColumnValue("OwnerId", null);
			}
			return true;
		}

		public virtual bool CaseSavedScriptTaskExecute(ProcessExecutingContext context) {
			bool isUserConnection = UserConnection is SSPUserConnection;
			if(!isUserConnection) {
				SetPortalCaseRights();
			}
			return true;
		}

		public virtual bool PortalCaseSavingScriptTaskExecute(ProcessExecutingContext context) {
			OldContactId = Entity.GetTypedOldColumnValue<Guid>("ContactId");
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "CaseInserting":
							if (ActivatedEventElements.Contains("StartMessage6")) {
							context.QueueTasks.Enqueue("StartMessage6");
							ProcessQueue(context);
							return;
						}
						break;
					case "Case_Portal_BPMSoftSaved":
							if (ActivatedEventElements.Contains("CaseSavedStartMessage")) {
							context.QueueTasks.Enqueue("CaseSavedStartMessage");
							ProcessQueue(context);
							return;
						}
						break;
					case "Case_Portal_BPMSoftSaving":
							if (ActivatedEventElements.Contains("CaseSavingStartMessage")) {
							context.QueueTasks.Enqueue("CaseSavingStartMessage");
							ProcessQueue(context);
							return;
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: Case_PortalEventsProcess

	/// <exclude/>
	public class Case_PortalEventsProcess : Case_PortalEventsProcess<Case_Portal_BPMSoft>
	{

		public Case_PortalEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

