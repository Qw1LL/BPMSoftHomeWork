namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Configuration;
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

	#region Class: Case_Case_BPMSoftSchema

	/// <exclude/>
	public class Case_Case_BPMSoftSchema : BPMSoft.Configuration.BaseCaseSchema
	{

		#region Constructors: Public

		public Case_Case_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public Case_Case_BPMSoftSchema(Case_Case_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public Case_Case_BPMSoftSchema(Case_Case_BPMSoftSchema source)
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
			UId = new Guid("117d32f9-8275-4534-8411-1c66115ce9cd");
			RealUId = new Guid("117d32f9-8275-4534-8411-1c66115ce9cd");
			Name = "Case_Case_BPMSoft";
			ParentSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c");
			ExtendParent = false;
			CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeOwnerColumn() {
			base.InitializeOwnerColumn();
			OwnerColumn = CreateOwnerColumn();
			if (Columns.FindByUId(OwnerColumn.UId) == null) {
				Columns.Add(OwnerColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("a587b494-47f3-4b27-be42-a259e579f061")) == null) {
				Columns.Add(CreateParentCaseColumn());
			}
			if (Columns.FindByUId(new Guid("b59a15ea-751e-4fd8-8281-f1a3dc7190ff")) == null) {
				Columns.Add(CreateParentActivityColumn());
			}
		}

		protected override EntitySchemaColumn CreateNumberColumn() {
			EntitySchemaColumn column = base.CreateNumberColumn();
			column.IsIndexed = true;
			column.ModifiedInSchemaUId = new Guid("117d32f9-8275-4534-8411-1c66115ce9cd");
			return column;
		}

		protected override EntitySchemaColumn CreateStatusColumn() {
			EntitySchemaColumn column = base.CreateStatusColumn();
			column.ModifiedInSchemaUId = new Guid("117d32f9-8275-4534-8411-1c66115ce9cd");
			return column;
		}

		protected override EntitySchemaColumn CreatePriorityColumn() {
			EntitySchemaColumn column = base.CreatePriorityColumn();
			column.ModifiedInSchemaUId = new Guid("117d32f9-8275-4534-8411-1c66115ce9cd");
			return column;
		}

		protected override EntitySchemaColumn CreateOriginColumn() {
			EntitySchemaColumn column = base.CreateOriginColumn();
			column.ModifiedInSchemaUId = new Guid("117d32f9-8275-4534-8411-1c66115ce9cd");
			return column;
		}

		protected override EntitySchemaColumn CreateCategoryColumn() {
			EntitySchemaColumn column = base.CreateCategoryColumn();
			column.ModifiedInSchemaUId = new Guid("117d32f9-8275-4534-8411-1c66115ce9cd");
			return column;
		}

		protected override EntitySchemaColumn CreateSatisfactionLevelCommentColumn() {
			EntitySchemaColumn column = base.CreateSatisfactionLevelCommentColumn();
			column.IsValueCloneable = false;
			column.ModifiedInSchemaUId = new Guid("117d32f9-8275-4534-8411-1c66115ce9cd");
			return column;
		}

		protected virtual EntitySchemaColumn CreateParentCaseColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("a587b494-47f3-4b27-be42-a259e579f061"),
				Name = @"ParentCase",
				ReferenceSchemaUId = new Guid("117d32f9-8275-4534-8411-1c66115ce9cd"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("117d32f9-8275-4534-8411-1c66115ce9cd"),
				ModifiedInSchemaUId = new Guid("117d32f9-8275-4534-8411-1c66115ce9cd"),
				CreatedInPackageId = new Guid("ff020f92-eb95-49ea-a251-6a0ed7e274a5")
			};
		}

		protected virtual EntitySchemaColumn CreateParentActivityColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("b59a15ea-751e-4fd8-8281-f1a3dc7190ff"),
				Name = @"ParentActivity",
				ReferenceSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("117d32f9-8275-4534-8411-1c66115ce9cd"),
				ModifiedInSchemaUId = new Guid("117d32f9-8275-4534-8411-1c66115ce9cd"),
				CreatedInPackageId = new Guid("c3c90037-274c-4793-841e-197eb228d3cd")
			};
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
			return new Case_Case_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Case_CaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new Case_Case_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new Case_Case_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("117d32f9-8275-4534-8411-1c66115ce9cd"));
		}

		#endregion

	}

	#endregion

	#region Class: Case_Case_BPMSoft

	/// <summary>
	/// Обращение.
	/// </summary>
	public class Case_Case_BPMSoft : BPMSoft.Configuration.BaseCase
	{

		#region Constructors: Public

		public Case_Case_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Case_Case_BPMSoft";
		}

		public Case_Case_BPMSoft(Case_Case_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid ParentCaseId {
			get {
				return GetTypedColumnValue<Guid>("ParentCaseId");
			}
			set {
				SetColumnValue("ParentCaseId", value);
				_parentCase = null;
			}
		}

		/// <exclude/>
		public string ParentCaseNumber {
			get {
				return GetTypedColumnValue<string>("ParentCaseNumber");
			}
			set {
				SetColumnValue("ParentCaseNumber", value);
				if (_parentCase != null) {
					_parentCase.Number = value;
				}
			}
		}

		private Case _parentCase;
		/// <summary>
		/// Родительское обращение.
		/// </summary>
		public Case ParentCase {
			get {
				return _parentCase ??
					(_parentCase = LookupColumnEntities.GetEntity("ParentCase") as Case);
			}
		}

		/// <exclude/>
		public Guid ParentActivityId {
			get {
				return GetTypedColumnValue<Guid>("ParentActivityId");
			}
			set {
				SetColumnValue("ParentActivityId", value);
				_parentActivity = null;
			}
		}

		/// <exclude/>
		public string ParentActivityTitle {
			get {
				return GetTypedColumnValue<string>("ParentActivityTitle");
			}
			set {
				SetColumnValue("ParentActivityTitle", value);
				if (_parentActivity != null) {
					_parentActivity.Title = value;
				}
			}
		}

		private Activity _parentActivity;
		/// <summary>
		/// Родительская активность.
		/// </summary>
		public Activity ParentActivity {
			get {
				return _parentActivity ??
					(_parentActivity = LookupColumnEntities.GetEntity("ParentActivity") as Activity);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Case_CaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("Case_Case_BPMSoftDeleted", e);
			Deleting += (s, e) => ThrowEvent("Case_Case_BPMSoftDeleting", e);
			Inserting += (s, e) => ThrowEvent("Case_Case_BPMSoftInserting", e);
			Saved += (s, e) => ThrowEvent("Case_Case_BPMSoftSaved", e);
			Saving += (s, e) => ThrowEvent("Case_Case_BPMSoftSaving", e);
			Validating += (s, e) => ThrowEvent("Case_Case_BPMSoftValidating", e);
			DefColumnValuesSet += (s, e) => ThrowEvent("Case_Case_BPMSoftDefColumnValuesSet", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new Case_Case_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: Case_CaseEventsProcess

	/// <exclude/>
	public partial class Case_CaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseCase_CaseEventsProcess<TEntity> where TEntity : Case_Case_BPMSoft
	{

		#region Class: OldOwnerSynchronizeSubjectRemindingFlowElement

		/// <exclude/>
		public class OldOwnerSynchronizeSubjectRemindingFlowElement : SynchronizeSubjectRemindingUserTask
		{

			public OldOwnerSynchronizeSubjectRemindingFlowElement(UserConnection userConnection, Case_CaseEventsProcess<TEntity> process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "OldOwnerSynchronizeSubjectReminding";
				IsLogging = false;
				SchemaElementUId = new Guid("d56b15a9-c6cc-40d1-aace-33874aa8dbab");
				CreatedInSchemaUId = process.InternalSchemaUId;
			}

		}

		#endregion

		#region Class: GenerateNumberUserTaskFlowElement

		/// <exclude/>
		public class GenerateNumberUserTaskFlowElement : GenerateSequenseNumberUserTask
		{

			public GenerateNumberUserTaskFlowElement(UserConnection userConnection, Case_CaseEventsProcess<TEntity> process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "GenerateNumberUserTask";
				IsLogging = false;
				SchemaElementUId = new Guid("a12485ee-3852-431a-9e82-0ba099749841");
				CreatedInSchemaUId = process.InternalSchemaUId;
			}

		}

		#endregion

		public Case_CaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Case_CaseEventsProcess";
			SchemaUId = new Guid("117d32f9-8275-4534-8411-1c66115ce9cd");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("117d32f9-8275-4534-8411-1c66115ce9cd");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		public virtual Guid OldOwnerId {
			get;
			set;
		}

		public virtual Guid NewOwnerId {
			get;
			set;
		}

		public virtual bool IsNeedSendRemind {
			get;
			set;
		}

		public virtual bool SendToOldOwner {
			get;
			set;
		}

		public virtual bool SendToNewOwner {
			get;
			set;
		}

		private ProcessFlowElement _eventSubProcess1;
		public ProcessFlowElement EventSubProcess1 {
			get {
				return _eventSubProcess1 ?? (_eventSubProcess1 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventSubProcess1",
					SchemaElementUId = new Guid("e9dc6350-b621-40d0-971c-27b294f57e3b"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _startMessage1;
		public ProcessFlowElement StartMessage1 {
			get {
				return _startMessage1 ?? (_startMessage1 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "StartMessage1",
					SchemaElementUId = new Guid("e46e3222-04fa-4aee-b53f-4c8ba8116818"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _oldScriptPrepareSynchronizeRemindings;
		public ProcessScriptTask OldScriptPrepareSynchronizeRemindings {
			get {
				return _oldScriptPrepareSynchronizeRemindings ?? (_oldScriptPrepareSynchronizeRemindings = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "OldScriptPrepareSynchronizeRemindings",
					SchemaElementUId = new Guid("1ff4178d-b591-4f0d-a302-073fe18b95a3"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = OldScriptPrepareSynchronizeRemindingsExecute,
				});
			}
		}

		private OldOwnerSynchronizeSubjectRemindingFlowElement _oldOwnerSynchronizeSubjectReminding;
		public OldOwnerSynchronizeSubjectRemindingFlowElement OldOwnerSynchronizeSubjectReminding {
			get {
				return _oldOwnerSynchronizeSubjectReminding ?? (_oldOwnerSynchronizeSubjectReminding = new OldOwnerSynchronizeSubjectRemindingFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ProcessInclusiveGateway _inclusiveGateway1;
		public ProcessInclusiveGateway InclusiveGateway1 {
			get {
				return _inclusiveGateway1 ?? (_inclusiveGateway1 = new ProcessInclusiveGateway() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaInclusiveGateway",
					Name = "InclusiveGateway1",
					SchemaElementUId = new Guid("9e5c2e36-2fa2-407a-8905-d8f0e4135dcb"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Question = new LocalizableString(Storage, Schema.GetResourceManagerName(),
					"EventsProcessSchema.BaseElements.InclusiveGateway1.Question"),
						IsDecisionRequired = false,
						BranchingMode = GatewayBranchingMode.Auto,
						DecisionMode = GetewayDecisionSelectionMode.Single,
						ShowUserDecisionDialog = (processId, gatewayName) => {},
				});
			}
		}

		private ProcessScriptTask _newScriptPrepareSynchronizeRemindings;
		public ProcessScriptTask NewScriptPrepareSynchronizeRemindings {
			get {
				return _newScriptPrepareSynchronizeRemindings ?? (_newScriptPrepareSynchronizeRemindings = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "NewScriptPrepareSynchronizeRemindings",
					SchemaElementUId = new Guid("10307809-1e7d-4af7-b2db-4ce4e948355e"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = NewScriptPrepareSynchronizeRemindingsExecute,
				});
			}
		}

		private ProcessThrowMessageEvent _intermediateThrowMessageEvent4;
		public ProcessThrowMessageEvent IntermediateThrowMessageEvent4 {
			get {
				return _intermediateThrowMessageEvent4 ?? (_intermediateThrowMessageEvent4 = new ProcessThrowMessageEvent() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaIntermediateThrowMessageEvent",
					Name = "IntermediateThrowMessageEvent4",
					SchemaElementUId = new Guid("de7d5aff-ef1e-4de2-bbea-1aca03bebcd8"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Message = "SynchronizeRemindings",
				});
			}
		}

		private ProcessFlowElement _startMessage4;
		public ProcessFlowElement StartMessage4 {
			get {
				return _startMessage4 ?? (_startMessage4 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "StartMessage4",
					SchemaElementUId = new Guid("39414ca4-8f12-4a14-9f96-55552793d9a5"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _emptyScriptTask;
		public ProcessScriptTask EmptyScriptTask {
			get {
				return _emptyScriptTask ?? (_emptyScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "EmptyScriptTask",
					SchemaElementUId = new Guid("db4aa9ae-1774-459b-b980-2fa818185cba"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = EmptyScriptTaskExecute,
				});
			}
		}

		private ProcessExclusiveGateway _exclusiveGateway1;
		public ProcessExclusiveGateway ExclusiveGateway1 {
			get {
				return _exclusiveGateway1 ?? (_exclusiveGateway1 = new ProcessExclusiveGateway() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaExclusiveGateway",
					Name = "ExclusiveGateway1",
					SchemaElementUId = new Guid("25b3a2b3-1b9d-4e6b-a42a-d73683447b25"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Question = new LocalizableString(Storage, Schema.GetResourceManagerName(),
					"EventsProcessSchema.BaseElements.ExclusiveGateway1.Question"),
						IsDecisionRequired = false,
						BranchingMode = GatewayBranchingMode.Auto,
						DecisionMode = GetewayDecisionSelectionMode.Single,
						ShowUserDecisionDialog = (processId, gatewayName) => {},
				});
			}
		}

		private ProcessFlowElement _startMessage5;
		public ProcessFlowElement StartMessage5 {
			get {
				return _startMessage5 ?? (_startMessage5 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "StartMessage5",
					SchemaElementUId = new Guid("b02d6fc6-2f15-4205-8852-288ad6387947"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _caseValidatingScriptTask;
		public ProcessScriptTask CaseValidatingScriptTask {
			get {
				return _caseValidatingScriptTask ?? (_caseValidatingScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "CaseValidatingScriptTask",
					SchemaElementUId = new Guid("3c19423a-d705-48e0-a38a-f6859ba5b636"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = CaseValidatingScriptTaskExecute,
				});
			}
		}

		private ProcessFlowElement _eventSubProcess2;
		public ProcessFlowElement EventSubProcess2 {
			get {
				return _eventSubProcess2 ?? (_eventSubProcess2 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventSubProcess2",
					SchemaElementUId = new Guid("c60cd728-87a7-4489-bcc4-1662b51c8f74"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _startMessage2;
		public ProcessFlowElement StartMessage2 {
			get {
				return _startMessage2 ?? (_startMessage2 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "StartMessage2",
					SchemaElementUId = new Guid("575fdd36-3e2c-4ccc-91e0-965fec1451d4"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _startMessage3;
		public ProcessFlowElement StartMessage3 {
			get {
				return _startMessage3 ?? (_startMessage3 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "StartMessage3",
					SchemaElementUId = new Guid("b089b5d0-c1c7-462d-b3b4-22378f8cfce8"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _caseSavingScriptTask;
		public ProcessScriptTask CaseSavingScriptTask {
			get {
				return _caseSavingScriptTask ?? (_caseSavingScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "CaseSavingScriptTask",
					SchemaElementUId = new Guid("b3f7a8a0-9776-4556-97ae-b15ebe58306e"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = CaseSavingScriptTaskExecute,
				});
			}
		}

		private ProcessThrowMessageEvent _intermediateThrowMessageEvent5;
		public ProcessThrowMessageEvent IntermediateThrowMessageEvent5 {
			get {
				return _intermediateThrowMessageEvent5 ?? (_intermediateThrowMessageEvent5 = new ProcessThrowMessageEvent() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaIntermediateThrowMessageEvent",
					Name = "IntermediateThrowMessageEvent5",
					SchemaElementUId = new Guid("f0926220-9df1-41a6-89a5-0212529dd0e8"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Message = "SynchronizeRemindings",
				});
			}
		}

		private ProcessScriptTask _setProcessParametersScriptTask;
		public ProcessScriptTask SetProcessParametersScriptTask {
			get {
				return _setProcessParametersScriptTask ?? (_setProcessParametersScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "SetProcessParametersScriptTask",
					SchemaElementUId = new Guid("7d1ffbbc-421d-4b33-99c0-2c3e68e755ff"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = SetProcessParametersScriptTaskExecute,
				});
			}
		}

		private ProcessFlowElement _eventSubProcess3;
		public ProcessFlowElement EventSubProcess3 {
			get {
				return _eventSubProcess3 ?? (_eventSubProcess3 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventSubProcess3",
					SchemaElementUId = new Guid("d17bc44d-05ce-41a4-b6db-f9e9eccea1cd"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _caseInsertingStartMessage;
		public ProcessFlowElement CaseInsertingStartMessage {
			get {
				return _caseInsertingStartMessage ?? (_caseInsertingStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "CaseInsertingStartMessage",
					SchemaElementUId = new Guid("b98917cf-2f76-4258-b9b8-d955cfd80800"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessExclusiveGateway _needGenerateExclusiveGateway;
		public ProcessExclusiveGateway NeedGenerateExclusiveGateway {
			get {
				return _needGenerateExclusiveGateway ?? (_needGenerateExclusiveGateway = new ProcessExclusiveGateway() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaExclusiveGateway",
					Name = "NeedGenerateExclusiveGateway",
					SchemaElementUId = new Guid("d220fa56-b3b1-4e4e-af86-7af24cfe9041"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Question = new LocalizableString(Storage, Schema.GetResourceManagerName(),
					"EventsProcessSchema.BaseElements.NeedGenerateExclusiveGateway.Question"),
						IsDecisionRequired = false,
						BranchingMode = GatewayBranchingMode.Auto,
						DecisionMode = GetewayDecisionSelectionMode.Single,
						ShowUserDecisionDialog = (processId, gatewayName) => {},
				});
			}
		}

		private ProcessExclusiveGateway _exclusiveGateway2;
		public ProcessExclusiveGateway ExclusiveGateway2 {
			get {
				return _exclusiveGateway2 ?? (_exclusiveGateway2 = new ProcessExclusiveGateway() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaExclusiveGateway",
					Name = "ExclusiveGateway2",
					SchemaElementUId = new Guid("f99ca610-4bc6-4ea5-814c-68852f20e20b"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Question = new LocalizableString(Storage, Schema.GetResourceManagerName(),
					"EventsProcessSchema.BaseElements.ExclusiveGateway2.Question"),
						IsDecisionRequired = false,
						BranchingMode = GatewayBranchingMode.Auto,
						DecisionMode = GetewayDecisionSelectionMode.Single,
						ShowUserDecisionDialog = (processId, gatewayName) => {},
				});
			}
		}

		private ProcessScriptTask _setNumberScriptTask;
		public ProcessScriptTask SetNumberScriptTask {
			get {
				return _setNumberScriptTask ?? (_setNumberScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "SetNumberScriptTask",
					SchemaElementUId = new Guid("c87893b2-1b9c-4691-a509-d3f6f9e5631f"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = SetNumberScriptTaskExecute,
				});
			}
		}

		private ProcessScriptTask _setGeneratedNumberScript;
		public ProcessScriptTask SetGeneratedNumberScript {
			get {
				return _setGeneratedNumberScript ?? (_setGeneratedNumberScript = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "SetGeneratedNumberScript",
					SchemaElementUId = new Guid("3f9056e8-5ead-4880-bd13-c030019ec8f8"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = SetGeneratedNumberScriptExecute,
				});
			}
		}

		private GenerateNumberUserTaskFlowElement _generateNumberUserTask;
		public GenerateNumberUserTaskFlowElement GenerateNumberUserTask {
			get {
				return _generateNumberUserTask ?? (_generateNumberUserTask = new GenerateNumberUserTaskFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ProcessScriptTask _setPortalNumberScriptTask;
		public ProcessScriptTask SetPortalNumberScriptTask {
			get {
				return _setPortalNumberScriptTask ?? (_setPortalNumberScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "SetPortalNumberScriptTask",
					SchemaElementUId = new Guid("b98e3401-639c-4df5-a402-4214ccb8edbe"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = SetPortalNumberScriptTaskExecute,
				});
			}
		}

		private ProcessTerminateEvent _terminate1;
		public ProcessTerminateEvent Terminate1 {
			get {
				return _terminate1 ?? (_terminate1 = new ProcessTerminateEvent() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaTerminateEvent",
					Name = "Terminate1",
					SchemaElementUId = new Guid("4886fa94-41d9-4422-bd9c-a271ab80a0b2"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _setSymptomsScriptTask;
		public ProcessScriptTask SetSymptomsScriptTask {
			get {
				return _setSymptomsScriptTask ?? (_setSymptomsScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "SetSymptomsScriptTask",
					SchemaElementUId = new Guid("f233228e-9fb3-4a6a-8328-765813405eda"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = SetSymptomsScriptTaskExecute,
				});
			}
		}

		private ProcessConditionalFlow _conditionalFlow1;
		public ProcessConditionalFlow ConditionalFlow1 {
			get {
				return _conditionalFlow1 ?? (_conditionalFlow1 = new ProcessConditionalFlow() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaConditionalFlow",
					Name = "ConditionalFlow1",
					SchemaElementUId = new Guid("109bded3-a3b0-4a70-b267-436bb84135b9"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						MatchBranchingDecisions = new BranchingDecisionCollection() {
				},
				});
			}
		}

		private ProcessConditionalFlow _conditionalFlow2;
		public ProcessConditionalFlow ConditionalFlow2 {
			get {
				return _conditionalFlow2 ?? (_conditionalFlow2 = new ProcessConditionalFlow() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaConditionalFlow",
					Name = "ConditionalFlow2",
					SchemaElementUId = new Guid("681e6224-86ca-4074-b5cd-ea90d495e5dd"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						MatchBranchingDecisions = new BranchingDecisionCollection() {
				},
				});
			}
		}

		private ProcessConditionalFlow _conditionalFlow3;
		public ProcessConditionalFlow ConditionalFlow3 {
			get {
				return _conditionalFlow3 ?? (_conditionalFlow3 = new ProcessConditionalFlow() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaConditionalFlow",
					Name = "ConditionalFlow3",
					SchemaElementUId = new Guid("c6de67fa-22af-471e-9325-1ba18a90c9ab"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						MatchBranchingDecisions = new BranchingDecisionCollection() {
				},
				});
			}
		}

		private ProcessConditionalFlow _conditionalFlow4;
		public ProcessConditionalFlow ConditionalFlow4 {
			get {
				return _conditionalFlow4 ?? (_conditionalFlow4 = new ProcessConditionalFlow() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaConditionalFlow",
					Name = "ConditionalFlow4",
					SchemaElementUId = new Guid("fab3c8e7-86fb-45c5-a0f1-18da3ef32360"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						MatchBranchingDecisions = new BranchingDecisionCollection() {
				},
				});
			}
		}

		private ProcessConditionalFlow _conditionalFlow5;
		public ProcessConditionalFlow ConditionalFlow5 {
			get {
				return _conditionalFlow5 ?? (_conditionalFlow5 = new ProcessConditionalFlow() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaConditionalFlow",
					Name = "ConditionalFlow5",
					SchemaElementUId = new Guid("96f257c1-5a8d-4255-9ca8-255f97f700d5"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						MatchBranchingDecisions = new BranchingDecisionCollection() {
				},
				});
			}
		}

		private LocalizableString _serviceRequestName;
		public LocalizableString ServiceRequestName {
			get {
				return _serviceRequestName ?? (_serviceRequestName = new LocalizableString(Storage, Schema.GetResourceManagerName(), "EventsProcessSchema.LocalizableStrings.ServiceRequestName.Value"));
			}
		}

		private LocalizableString _newOwnerCaption;
		public LocalizableString NewOwnerCaption {
			get {
				return _newOwnerCaption ?? (_newOwnerCaption = new LocalizableString(Storage, Schema.GetResourceManagerName(), "EventsProcessSchema.LocalizableStrings.NewOwnerCaption.Value"));
			}
		}

		private LocalizableString _newOwnerMessage;
		public LocalizableString NewOwnerMessage {
			get {
				return _newOwnerMessage ?? (_newOwnerMessage = new LocalizableString(Storage, Schema.GetResourceManagerName(), "EventsProcessSchema.LocalizableStrings.NewOwnerMessage.Value"));
			}
		}

		private LocalizableString _oldOwnerCaption;
		public LocalizableString OldOwnerCaption {
			get {
				return _oldOwnerCaption ?? (_oldOwnerCaption = new LocalizableString(Storage, Schema.GetResourceManagerName(), "EventsProcessSchema.LocalizableStrings.OldOwnerCaption.Value"));
			}
		}

		private LocalizableString _oldOwnerMessage;
		public LocalizableString OldOwnerMessage {
			get {
				return _oldOwnerMessage ?? (_oldOwnerMessage = new LocalizableString(Storage, Schema.GetResourceManagerName(), "EventsProcessSchema.LocalizableStrings.OldOwnerMessage.Value"));
			}
		}

		private LocalizableString _subjectByString;
		public LocalizableString SubjectByString {
			get {
				return _subjectByString ?? (_subjectByString = new LocalizableString(Storage, Schema.GetResourceManagerName(), "EventsProcessSchema.LocalizableStrings.SubjectByString.Value"));
			}
		}

		private LocalizableString _subjectForString;
		public LocalizableString SubjectForString {
			get {
				return _subjectForString ?? (_subjectForString = new LocalizableString(Storage, Schema.GetResourceManagerName(), "EventsProcessSchema.LocalizableStrings.SubjectForString.Value"));
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[EventSubProcess1.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess1 };
			FlowElements[StartMessage1.SchemaElementUId] = new Collection<ProcessFlowElement> { StartMessage1 };
			FlowElements[OldScriptPrepareSynchronizeRemindings.SchemaElementUId] = new Collection<ProcessFlowElement> { OldScriptPrepareSynchronizeRemindings };
			FlowElements[OldOwnerSynchronizeSubjectReminding.SchemaElementUId] = new Collection<ProcessFlowElement> { OldOwnerSynchronizeSubjectReminding };
			FlowElements[InclusiveGateway1.SchemaElementUId] = new Collection<ProcessFlowElement> { InclusiveGateway1 };
			FlowElements[NewScriptPrepareSynchronizeRemindings.SchemaElementUId] = new Collection<ProcessFlowElement> { NewScriptPrepareSynchronizeRemindings };
			FlowElements[IntermediateThrowMessageEvent4.SchemaElementUId] = new Collection<ProcessFlowElement> { IntermediateThrowMessageEvent4 };
			FlowElements[StartMessage4.SchemaElementUId] = new Collection<ProcessFlowElement> { StartMessage4 };
			FlowElements[EmptyScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { EmptyScriptTask };
			FlowElements[ExclusiveGateway1.SchemaElementUId] = new Collection<ProcessFlowElement> { ExclusiveGateway1 };
			FlowElements[StartMessage5.SchemaElementUId] = new Collection<ProcessFlowElement> { StartMessage5 };
			FlowElements[CaseValidatingScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { CaseValidatingScriptTask };
			FlowElements[EventSubProcess2.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess2 };
			FlowElements[StartMessage2.SchemaElementUId] = new Collection<ProcessFlowElement> { StartMessage2 };
			FlowElements[StartMessage3.SchemaElementUId] = new Collection<ProcessFlowElement> { StartMessage3 };
			FlowElements[CaseSavingScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { CaseSavingScriptTask };
			FlowElements[IntermediateThrowMessageEvent5.SchemaElementUId] = new Collection<ProcessFlowElement> { IntermediateThrowMessageEvent5 };
			FlowElements[SetProcessParametersScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { SetProcessParametersScriptTask };
			FlowElements[EventSubProcess3.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess3 };
			FlowElements[CaseInsertingStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { CaseInsertingStartMessage };
			FlowElements[NeedGenerateExclusiveGateway.SchemaElementUId] = new Collection<ProcessFlowElement> { NeedGenerateExclusiveGateway };
			FlowElements[ExclusiveGateway2.SchemaElementUId] = new Collection<ProcessFlowElement> { ExclusiveGateway2 };
			FlowElements[SetNumberScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { SetNumberScriptTask };
			FlowElements[SetGeneratedNumberScript.SchemaElementUId] = new Collection<ProcessFlowElement> { SetGeneratedNumberScript };
			FlowElements[GenerateNumberUserTask.SchemaElementUId] = new Collection<ProcessFlowElement> { GenerateNumberUserTask };
			FlowElements[SetPortalNumberScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { SetPortalNumberScriptTask };
			FlowElements[Terminate1.SchemaElementUId] = new Collection<ProcessFlowElement> { Terminate1 };
			FlowElements[SetSymptomsScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { SetSymptomsScriptTask };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "EventSubProcess1":
						break;
					case "StartMessage1":
						e.Context.QueueTasks.Enqueue("IntermediateThrowMessageEvent4");
						break;
					case "OldScriptPrepareSynchronizeRemindings":
						e.Context.QueueTasks.Enqueue("OldOwnerSynchronizeSubjectReminding");
						break;
					case "OldOwnerSynchronizeSubjectReminding":
							e.Context.QueueTasks.Enqueue("EmptyScriptTask");
						break;
					case "InclusiveGateway1":
						bool isInclusiveGateway1ConditionsEvulateted = false;
						if (ConditionalFlow2ExpressionExecute()) {
							e.Context.QueueTasks.Enqueue("OldScriptPrepareSynchronizeRemindings");
							isInclusiveGateway1ConditionsEvulateted = true;
						} 
						if (ConditionalFlow3ExpressionExecute()) {
							e.Context.QueueTasks.Enqueue("NewScriptPrepareSynchronizeRemindings");
							isInclusiveGateway1ConditionsEvulateted = true;
						} 
						if (!isInclusiveGateway1ConditionsEvulateted) {
							e.Context.QueueTasks.Enqueue("EmptyScriptTask");
						} 
						break;
					case "NewScriptPrepareSynchronizeRemindings":
						e.Context.QueueTasks.Enqueue("EmptyScriptTask");
						break;
					case "IntermediateThrowMessageEvent4":
						break;
					case "StartMessage4":
						e.Context.QueueTasks.Enqueue("ExclusiveGateway1");
						break;
					case "EmptyScriptTask":
						break;
					case "ExclusiveGateway1":
						if (ConditionalFlow1ExpressionExecute()) {
							e.Context.QueueTasks.Enqueue("InclusiveGateway1");
							break;
						}
						e.Context.QueueTasks.Enqueue("EmptyScriptTask");
						break;
					case "StartMessage5":
						e.Context.QueueTasks.Enqueue("CaseValidatingScriptTask");
						break;
					case "CaseValidatingScriptTask":
						break;
					case "EventSubProcess2":
						break;
					case "StartMessage2":
						e.Context.QueueTasks.Enqueue("SetProcessParametersScriptTask");
						break;
					case "StartMessage3":
						e.Context.QueueTasks.Enqueue("CaseSavingScriptTask");
						break;
					case "CaseSavingScriptTask":
						break;
					case "IntermediateThrowMessageEvent5":
						break;
					case "SetProcessParametersScriptTask":
						e.Context.QueueTasks.Enqueue("IntermediateThrowMessageEvent5");
						break;
					case "EventSubProcess3":
						break;
					case "CaseInsertingStartMessage":
						e.Context.QueueTasks.Enqueue("SetSymptomsScriptTask");
						break;
					case "NeedGenerateExclusiveGateway":
						if (ConditionalFlow4ExpressionExecute()) {
							e.Context.QueueTasks.Enqueue("ExclusiveGateway2");
							break;
						}
						e.Context.QueueTasks.Enqueue("Terminate1");
						break;
					case "ExclusiveGateway2":
						if (ConditionalFlow5ExpressionExecute()) {
							e.Context.QueueTasks.Enqueue("SetNumberScriptTask");
							break;
						}
						e.Context.QueueTasks.Enqueue("SetPortalNumberScriptTask");
						break;
					case "SetNumberScriptTask":
						e.Context.QueueTasks.Enqueue("GenerateNumberUserTask");
						break;
					case "SetGeneratedNumberScript":
						break;
					case "GenerateNumberUserTask":
							e.Context.QueueTasks.Enqueue("SetGeneratedNumberScript");
						break;
					case "SetPortalNumberScriptTask":
						break;
					case "Terminate1":
						break;
					case "SetSymptomsScriptTask":
						e.Context.QueueTasks.Enqueue("NeedGenerateExclusiveGateway");
						break;
			}
			ProcessQueue(e.Context);
		}

		private bool ConditionalFlow1ExpressionExecute() {
			return Convert.ToBoolean(IsNeedSendRemind || Entity.IsInDeleting);
		}

		private bool ConditionalFlow2ExpressionExecute() {
			return Convert.ToBoolean(UserConnection.CurrentUser.ConnectionType != UserType.SSP && (SendToOldOwner || Entity.IsInDeleting));
		}

		private bool ConditionalFlow3ExpressionExecute() {
			return Convert.ToBoolean(SendToNewOwner);
		}

		private bool ConditionalFlow4ExpressionExecute() {
			return Convert.ToBoolean(string.IsNullOrEmpty(Entity.GetTypedColumnValue<string>("Number")));
		}

		private bool ConditionalFlow5ExpressionExecute() {
			return Convert.ToBoolean(UserConnection.CurrentUser.ConnectionType != UserType.SSP);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("StartMessage1");
			ActivatedEventElements.Add("StartMessage4");
			ActivatedEventElements.Add("StartMessage5");
			ActivatedEventElements.Add("StartMessage2");
			ActivatedEventElements.Add("StartMessage3");
			ActivatedEventElements.Add("CaseInsertingStartMessage");
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			switch (context.QueueTasks.Peek()) {
				case "EventSubProcess1":
					context.QueueTasks.Dequeue();
					break;
				case "StartMessage1":
					context.QueueTasks.Dequeue();
					context.SenderName = "StartMessage1";
					result = StartMessage1.Execute(context);
					break;
				case "OldScriptPrepareSynchronizeRemindings":
					context.QueueTasks.Dequeue();
					context.SenderName = "OldScriptPrepareSynchronizeRemindings";
					result = OldScriptPrepareSynchronizeRemindings.Execute(context, OldScriptPrepareSynchronizeRemindingsExecute);
					break;
				case "OldOwnerSynchronizeSubjectReminding":
					context.QueueTasks.Dequeue();
					context.SenderName = "OldOwnerSynchronizeSubjectReminding";
					result = OldOwnerSynchronizeSubjectReminding.Execute(context);
					break;
				case "InclusiveGateway1":
					context.QueueTasks.Dequeue();
					context.SenderName = "InclusiveGateway1";
					result = InclusiveGateway1.Execute(context);
					break;
				case "NewScriptPrepareSynchronizeRemindings":
					context.QueueTasks.Dequeue();
					context.SenderName = "NewScriptPrepareSynchronizeRemindings";
					result = NewScriptPrepareSynchronizeRemindings.Execute(context, NewScriptPrepareSynchronizeRemindingsExecute);
					break;
				case "IntermediateThrowMessageEvent4":
					context.QueueTasks.Dequeue();
					result = IntermediateThrowMessageEvent4.Execute(context);
					break;
				case "StartMessage4":
					context.QueueTasks.Dequeue();
					context.SenderName = "StartMessage4";
					result = StartMessage4.Execute(context);
					break;
				case "EmptyScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "EmptyScriptTask";
					result = EmptyScriptTask.Execute(context, EmptyScriptTaskExecute);
					break;
				case "ExclusiveGateway1":
					context.QueueTasks.Dequeue();
					context.SenderName = "ExclusiveGateway1";
					result = ExclusiveGateway1.Execute(context);
					break;
				case "StartMessage5":
					context.QueueTasks.Dequeue();
					context.SenderName = "StartMessage5";
					result = StartMessage5.Execute(context);
					break;
				case "CaseValidatingScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "CaseValidatingScriptTask";
					result = CaseValidatingScriptTask.Execute(context, CaseValidatingScriptTaskExecute);
					break;
				case "EventSubProcess2":
					context.QueueTasks.Dequeue();
					break;
				case "StartMessage2":
					context.QueueTasks.Dequeue();
					context.SenderName = "StartMessage2";
					result = StartMessage2.Execute(context);
					break;
				case "StartMessage3":
					context.QueueTasks.Dequeue();
					context.SenderName = "StartMessage3";
					result = StartMessage3.Execute(context);
					break;
				case "CaseSavingScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "CaseSavingScriptTask";
					result = CaseSavingScriptTask.Execute(context, CaseSavingScriptTaskExecute);
					break;
				case "IntermediateThrowMessageEvent5":
					context.QueueTasks.Dequeue();
					result = IntermediateThrowMessageEvent5.Execute(context);
					break;
				case "SetProcessParametersScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "SetProcessParametersScriptTask";
					result = SetProcessParametersScriptTask.Execute(context, SetProcessParametersScriptTaskExecute);
					break;
				case "EventSubProcess3":
					context.QueueTasks.Dequeue();
					break;
				case "CaseInsertingStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "CaseInsertingStartMessage";
					result = CaseInsertingStartMessage.Execute(context);
					break;
				case "NeedGenerateExclusiveGateway":
					context.QueueTasks.Dequeue();
					context.SenderName = "NeedGenerateExclusiveGateway";
					result = NeedGenerateExclusiveGateway.Execute(context);
					break;
				case "ExclusiveGateway2":
					context.QueueTasks.Dequeue();
					context.SenderName = "ExclusiveGateway2";
					result = ExclusiveGateway2.Execute(context);
					break;
				case "SetNumberScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "SetNumberScriptTask";
					result = SetNumberScriptTask.Execute(context, SetNumberScriptTaskExecute);
					break;
				case "SetGeneratedNumberScript":
					context.QueueTasks.Dequeue();
					context.SenderName = "SetGeneratedNumberScript";
					result = SetGeneratedNumberScript.Execute(context, SetGeneratedNumberScriptExecute);
					break;
				case "GenerateNumberUserTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "GenerateNumberUserTask";
					result = GenerateNumberUserTask.Execute(context);
					break;
				case "SetPortalNumberScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "SetPortalNumberScriptTask";
					result = SetPortalNumberScriptTask.Execute(context, SetPortalNumberScriptTaskExecute);
					break;
				case "Terminate1":
					context.QueueTasks.Dequeue();
					break;
				case "SetSymptomsScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "SetSymptomsScriptTask";
					result = SetSymptomsScriptTask.Execute(context, SetSymptomsScriptTaskExecute);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool OldScriptPrepareSynchronizeRemindingsExecute(ProcessExecutingContext context) {
			OldOwnerSynchronizeSubjectReminding.IsSubjectDelete = Entity.IsInDeleting;
			OldOwnerSynchronizeSubjectReminding.IsListSubjectReminds = true;
			OldOwnerSynchronizeSubjectReminding.TypeCaption = string.Format(ServiceRequestName, Entity.GetTypedColumnValue<string>("Number"));
			OldOwnerSynchronizeSubjectReminding.Active = !Entity.IsInDeleting;
			OldOwnerSynchronizeSubjectReminding.SubjectPrimaryColumnValue = Entity.GetTypedColumnValue<Guid>("Id");
			OldOwnerSynchronizeSubjectReminding.Contact = OldOwnerId;
			OldOwnerSynchronizeSubjectReminding.Source = RemindingConsts.RemindingSourceOwnerId;
			OldOwnerSynchronizeSubjectReminding.RemindTime = UserConnection.CurrentUser.GetCurrentDateTime();
			OldOwnerSynchronizeSubjectReminding.SysEntitySchema = Entity.Schema.UId;
			OldOwnerSynchronizeSubjectReminding.SubjectCaption = string.Format(OldOwnerMessage, 
				Entity.GetTypedColumnValue<string>("Number"), Entity.GetTypedColumnValue<string>("Subject"));
			OldOwnerSynchronizeSubjectReminding.NotificationType = CaseConsts.NotificationTypeNotificationId;
			return true;
		}

		public virtual bool NewScriptPrepareSynchronizeRemindingsExecute(ProcessExecutingContext context) {
			Entity remindingEntity = UserConnection.EntitySchemaManager.GetInstanceByName("Reminding")
				.CreateEntity(UserConnection);
			var caseId = Entity.GetTypedColumnValue<Guid>("Id");;
			var ownerId = NewOwnerId;
			var number = Entity.GetTypedColumnValue<string>("Number");
			var condition = new Dictionary<string, object> {
				{
					"Author", UserConnection.CurrentUser.ContactId
				}, {
					"Contact", ownerId
				}, {
					"Source", RemindingConsts.RemindingSourceAuthorId
				}, {
					"Number", number
				}
			};
			var str = new StringBuilder();
			foreach (object value in condition.Values) {
				str.Append(value);
			}
			string hash = FileUtilities.GetMD5Hash(Encoding.Unicode.GetBytes(str.ToString()));
			remindingEntity.SetDefColumnValues();
			remindingEntity.SetColumnValue("AuthorId", UserConnection.CurrentUser.ContactId);
			remindingEntity.SetColumnValue("ContactId", ownerId);
			remindingEntity.SetColumnValue("SourceId", RemindingConsts.RemindingSourceAuthorId);
			remindingEntity.SetColumnValue("RemindTime", UserConnection.CurrentUser.GetCurrentDateTime());
			string caseSubject = Entity.GetTypedColumnValue<string>("Subject");
			caseSubject = caseSubject.Length > 300 ? caseSubject.Substring(0, 300) : caseSubject;
			var subjectCaption = string.Format(NewOwnerMessage,
			Entity.GetTypedColumnValue<string>("Number"), caseSubject);
			remindingEntity.SetColumnValue("SubjectCaption", subjectCaption);
			var caseSchema = UserConnection.EntitySchemaManager.GetInstanceByName("Case");
			remindingEntity.SetColumnValue("SysEntitySchemaId", caseSchema.UId);
			remindingEntity.SetColumnValue("SubjectId", caseId);
			remindingEntity.SetColumnValue("Hash", hash);
			remindingEntity.Save();
			return true;
		}

		public virtual bool EmptyScriptTaskExecute(ProcessExecutingContext context) {
			return true;
		}

		public virtual bool CaseValidatingScriptTaskExecute(ProcessExecutingContext context) {
			if (Entity.GetChangedColumnValues().Any(c =>
					((c.Name == "SatisfactionLevelId" && c.OldValue != c.Value) 
					|| (c.Name == "SatisfactionLevelComment" 
					&& !(String.IsNullOrEmpty(c.OldValue as string) && String.IsNullOrEmpty(c.Value as string)))))) {
				if(!UserConnection.DBSecurityEngine.GetCanExecuteOperation("CanChangeCaseSatisfactionLevel")) {
					string validationMessageText = new LocalizableString(UserConnection.Workspace.ResourceStorage,
						"CasePage", "LocalizableStrings.SatisfactionLevelTip.Value");
					Entity.ValidationMessages.Add(
						new EntityValidationMessage {
							Text = validationMessageText
						});
					return false;
				}
			}
			return true;
		}

		public virtual bool CaseSavingScriptTaskExecute(ProcessExecutingContext context) {
			SetProcessParameters();
			if(IsStatusChanged(Entity) && UserConnection.GetIsFeatureEnabled("CaseRuleApplier")) {
				CaseRuleApplier ruleApplier = new CaseRuleApplier(UserConnection);
				ruleApplier.Execute(Entity);
			}
			return true;
		}

		public virtual bool SetProcessParametersScriptTaskExecute(ProcessExecutingContext context) {
			SetProcessParameters();
			return true;
		}

		public virtual bool SetNumberScriptTaskExecute(ProcessExecutingContext context) {
			Entity.Schema.Name = "Case";
			GenerateNumberUserTask.EntitySchema = Entity.Schema;
			return true;
		}

		public virtual bool SetGeneratedNumberScriptExecute(ProcessExecutingContext context) {
			string code = string.Empty;
			code = GenerateNumberUserTask.ResultCode;
			if(!string.IsNullOrEmpty(code)) {
				Entity.SetColumnValue("Number", code);
			}
			return true;
		}

		public virtual bool SetPortalNumberScriptTaskExecute(ProcessExecutingContext context) {
			Entity.Schema.Name = "Case";
			string code = string.Empty;
			var systemUserConnection = UserConnection.AppConnection.SystemUserConnection;
			var generateNumberUserTask = 
				new BPMSoft.Core.Process.Configuration.GenerateSequenseNumberUserTask(systemUserConnection);
			generateNumberUserTask.EntitySchema = Entity.Schema;
			generateNumberUserTask.UId = Guid.NewGuid();
			generateNumberUserTask.Owner = this;
			generateNumberUserTask.Name = "SetPortalNumberScriptTaskExecute";
			code = generateNumberUserTask.GenerateSequenseNumber(Entity.Schema, systemUserConnection);
			if(!string.IsNullOrEmpty(code)) {
				Entity.SetColumnValue("Number", code);
			}
			SetPortalCaseSubject();
			return true;
		}

		public virtual bool SetSymptomsScriptTaskExecute(ProcessExecutingContext context) {
			if(string.IsNullOrEmpty(Entity.GetTypedColumnValue<string>("Symptoms"))) {
			 var subject = Entity.GetTypedColumnValue<string>("Subject");
			 Entity.SetColumnValue("Symptoms", subject);
			}
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "Case_Case_BPMSoftSaved":
							if (ActivatedEventElements.Contains("StartMessage1")) {
							context.QueueTasks.Enqueue("StartMessage1");
						}
						break;
					case "SynchronizeRemindings":
							if (ActivatedEventElements.Contains("StartMessage4")) {
							context.QueueTasks.Enqueue("StartMessage4");
						}
						break;
					case "Case_Case_BPMSoftValidating":
							if (ActivatedEventElements.Contains("StartMessage5")) {
							context.QueueTasks.Enqueue("StartMessage5");
						}
						break;
					case "Case_Case_BPMSoftDeleting":
							if (ActivatedEventElements.Contains("StartMessage2")) {
							context.QueueTasks.Enqueue("StartMessage2");
						}
						break;
					case "Case_Case_BPMSoftSaving":
							if (ActivatedEventElements.Contains("StartMessage3")) {
							context.QueueTasks.Enqueue("StartMessage3");
						}
						break;
					case "Case_Case_BPMSoftInserting":
							if (ActivatedEventElements.Contains("CaseInsertingStartMessage")) {
							context.QueueTasks.Enqueue("CaseInsertingStartMessage");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: Case_CaseEventsProcess

	/// <exclude/>
	public class Case_CaseEventsProcess : Case_CaseEventsProcess<Case_Case_BPMSoft>
	{

		public Case_CaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

