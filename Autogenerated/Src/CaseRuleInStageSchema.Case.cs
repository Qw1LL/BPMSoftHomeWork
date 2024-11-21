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

	#region Class: CaseRuleInStageSchema

	/// <exclude/>
	public class CaseRuleInStageSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public CaseRuleInStageSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public CaseRuleInStageSchema(CaseRuleInStageSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public CaseRuleInStageSchema(CaseRuleInStageSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("306d12c2-6f43-4e30-9265-448e3fe36474");
			RealUId = new Guid("306d12c2-6f43-4e30-9265-448e3fe36474");
			Name = "CaseRuleInStage";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("a7919973-994c-4956-b846-530c9ef3b289");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("205da7bf-0ec7-4ed1-a68a-871deb13b77a")) == null) {
				Columns.Add(CreatePositionColumn());
			}
			if (Columns.FindByUId(new Guid("db00a017-b3c3-4508-b2f9-70d4ad74a6d2")) == null) {
				Columns.Add(CreateActiveColumn());
			}
			if (Columns.FindByUId(new Guid("77443fe5-f234-44f3-87b6-b1395e92173a")) == null) {
				Columns.Add(CreateCaseRuleHandlerColumn());
			}
			if (Columns.FindByUId(new Guid("cdff65f8-a47e-4e78-8ebf-8b8b0c32a437")) == null) {
				Columns.Add(CreateCaseNextStatusColumn());
			}
		}

		protected virtual EntitySchemaColumn CreatePositionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("205da7bf-0ec7-4ed1-a68a-871deb13b77a"),
				Name = @"Position",
				CreatedInSchemaUId = new Guid("306d12c2-6f43-4e30-9265-448e3fe36474"),
				ModifiedInSchemaUId = new Guid("306d12c2-6f43-4e30-9265-448e3fe36474"),
				CreatedInPackageId = new Guid("a7919973-994c-4956-b846-530c9ef3b289")
			};
		}

		protected virtual EntitySchemaColumn CreateActiveColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("db00a017-b3c3-4508-b2f9-70d4ad74a6d2"),
				Name = @"Active",
				CreatedInSchemaUId = new Guid("306d12c2-6f43-4e30-9265-448e3fe36474"),
				ModifiedInSchemaUId = new Guid("306d12c2-6f43-4e30-9265-448e3fe36474"),
				CreatedInPackageId = new Guid("a7919973-994c-4956-b846-530c9ef3b289")
			};
		}

		protected virtual EntitySchemaColumn CreateCaseRuleHandlerColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("77443fe5-f234-44f3-87b6-b1395e92173a"),
				Name = @"CaseRuleHandler",
				ReferenceSchemaUId = new Guid("6a2df2cb-bf84-4136-9edc-500f0b94a3d3"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("306d12c2-6f43-4e30-9265-448e3fe36474"),
				ModifiedInSchemaUId = new Guid("306d12c2-6f43-4e30-9265-448e3fe36474"),
				CreatedInPackageId = new Guid("a7919973-994c-4956-b846-530c9ef3b289")
			};
		}

		protected virtual EntitySchemaColumn CreateCaseNextStatusColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("cdff65f8-a47e-4e78-8ebf-8b8b0c32a437"),
				Name = @"CaseNextStatus",
				ReferenceSchemaUId = new Guid("e43e673d-fdd2-45d5-8672-a2bca1a14f00"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("306d12c2-6f43-4e30-9265-448e3fe36474"),
				ModifiedInSchemaUId = new Guid("306d12c2-6f43-4e30-9265-448e3fe36474"),
				CreatedInPackageId = new Guid("a7919973-994c-4956-b846-530c9ef3b289")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new CaseRuleInStage(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new CaseRuleInStage_CaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new CaseRuleInStageSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new CaseRuleInStageSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("306d12c2-6f43-4e30-9265-448e3fe36474"));
		}

		#endregion

	}

	#endregion

	#region Class: CaseRuleInStage

	/// <summary>
	/// Обработчик правила в состоянии.
	/// </summary>
	public class CaseRuleInStage : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public CaseRuleInStage(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "CaseRuleInStage";
		}

		public CaseRuleInStage(CaseRuleInStage source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Позиция.
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
		/// Активно.
		/// </summary>
		public bool Active {
			get {
				return GetTypedColumnValue<bool>("Active");
			}
			set {
				SetColumnValue("Active", value);
			}
		}

		/// <exclude/>
		public Guid CaseRuleHandlerId {
			get {
				return GetTypedColumnValue<Guid>("CaseRuleHandlerId");
			}
			set {
				SetColumnValue("CaseRuleHandlerId", value);
				_caseRuleHandler = null;
			}
		}

		/// <exclude/>
		public string CaseRuleHandlerName {
			get {
				return GetTypedColumnValue<string>("CaseRuleHandlerName");
			}
			set {
				SetColumnValue("CaseRuleHandlerName", value);
				if (_caseRuleHandler != null) {
					_caseRuleHandler.Name = value;
				}
			}
		}

		private CaseRuleHandler _caseRuleHandler;
		/// <summary>
		/// Правило.
		/// </summary>
		public CaseRuleHandler CaseRuleHandler {
			get {
				return _caseRuleHandler ??
					(_caseRuleHandler = LookupColumnEntities.GetEntity("CaseRuleHandler") as CaseRuleHandler);
			}
		}

		/// <exclude/>
		public Guid CaseNextStatusId {
			get {
				return GetTypedColumnValue<Guid>("CaseNextStatusId");
			}
			set {
				SetColumnValue("CaseNextStatusId", value);
				_caseNextStatus = null;
			}
		}

		/// <exclude/>
		public string CaseNextStatusName {
			get {
				return GetTypedColumnValue<string>("CaseNextStatusName");
			}
			set {
				SetColumnValue("CaseNextStatusName", value);
				if (_caseNextStatus != null) {
					_caseNextStatus.Name = value;
				}
			}
		}

		private CaseNextStatus _caseNextStatus;
		/// <summary>
		/// Следующее состояние.
		/// </summary>
		public CaseNextStatus CaseNextStatus {
			get {
				return _caseNextStatus ??
					(_caseNextStatus = LookupColumnEntities.GetEntity("CaseNextStatus") as CaseNextStatus);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new CaseRuleInStage_CaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("CaseRuleInStageDeleted", e);
			Validating += (s, e) => ThrowEvent("CaseRuleInStageValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new CaseRuleInStage(this);
		}

		#endregion

	}

	#endregion

	#region Class: CaseRuleInStage_CaseEventsProcess

	/// <exclude/>
	public partial class CaseRuleInStage_CaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : CaseRuleInStage
	{

		public CaseRuleInStage_CaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "CaseRuleInStage_CaseEventsProcess";
			SchemaUId = new Guid("306d12c2-6f43-4e30-9265-448e3fe36474");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("306d12c2-6f43-4e30-9265-448e3fe36474");
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

	#region Class: CaseRuleInStage_CaseEventsProcess

	/// <exclude/>
	public class CaseRuleInStage_CaseEventsProcess : CaseRuleInStage_CaseEventsProcess<CaseRuleInStage>
	{

		public CaseRuleInStage_CaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: CaseRuleInStage_CaseEventsProcess

	public partial class CaseRuleInStage_CaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: CaseRuleInStageEventsProcess

	/// <exclude/>
	public class CaseRuleInStageEventsProcess : CaseRuleInStage_CaseEventsProcess
	{

		public CaseRuleInStageEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

