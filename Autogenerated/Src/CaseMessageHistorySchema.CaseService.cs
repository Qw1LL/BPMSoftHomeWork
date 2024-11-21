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

	#region Class: CaseMessageHistorySchema

	/// <exclude/>
	public class CaseMessageHistorySchema : BPMSoft.Configuration.BaseMessageHistorySchema
	{

		#region Constructors: Public

		public CaseMessageHistorySchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public CaseMessageHistorySchema(CaseMessageHistorySchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public CaseMessageHistorySchema(CaseMessageHistorySchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("9abf0257-2d36-47ca-920c-b9fb084275d6");
			RealUId = new Guid("9abf0257-2d36-47ca-920c-b9fb084275d6");
			Name = "CaseMessageHistory";
			ParentSchemaUId = new Guid("a8f74749-bbc1-47a6-84b6-10e974356e91");
			ExtendParent = false;
			CreatedInPackageId = new Guid("7d3205ce-da60-44b8-8696-491424df7e53");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeMasterRecordColumn() {
			base.InitializeMasterRecordColumn();
			MasterRecordColumn = CreateCaseColumn();
			if (Columns.FindByUId(MasterRecordColumn.UId) == null) {
				Columns.Add(MasterRecordColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected virtual EntitySchemaColumn CreateCaseColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("142350b0-b4ac-4d14-8a81-e0e829b2269a"),
				Name = @"Case",
				ReferenceSchemaUId = new Guid("117d32f9-8275-4534-8411-1c66115ce9cd"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("9abf0257-2d36-47ca-920c-b9fb084275d6"),
				ModifiedInSchemaUId = new Guid("9abf0257-2d36-47ca-920c-b9fb084275d6"),
				CreatedInPackageId = new Guid("7d3205ce-da60-44b8-8696-491424df7e53")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new CaseMessageHistory(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new CaseMessageHistory_CaseServiceEventsProcess(userConnection);
		}

		public override object Clone() {
			return new CaseMessageHistorySchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new CaseMessageHistorySchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("9abf0257-2d36-47ca-920c-b9fb084275d6"));
		}

		#endregion

	}

	#endregion

	#region Class: CaseMessageHistory

	/// <summary>
	/// История сообщений по обращению.
	/// </summary>
	public class CaseMessageHistory : BPMSoft.Configuration.BaseMessageHistory
	{

		#region Constructors: Public

		public CaseMessageHistory(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "CaseMessageHistory";
		}

		public CaseMessageHistory(CaseMessageHistory source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid CaseId {
			get {
				return GetTypedColumnValue<Guid>("CaseId");
			}
			set {
				SetColumnValue("CaseId", value);
				_case = null;
			}
		}

		/// <exclude/>
		public string CaseNumber {
			get {
				return GetTypedColumnValue<string>("CaseNumber");
			}
			set {
				SetColumnValue("CaseNumber", value);
				if (_case != null) {
					_case.Number = value;
				}
			}
		}

		private Case _case;
		/// <summary>
		/// Обращение.
		/// </summary>
		public Case Case {
			get {
				return _case ??
					(_case = LookupColumnEntities.GetEntity("Case") as Case);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new CaseMessageHistory_CaseServiceEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("CaseMessageHistoryDeleted", e);
			Validating += (s, e) => ThrowEvent("CaseMessageHistoryValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new CaseMessageHistory(this);
		}

		#endregion

	}

	#endregion

	#region Class: CaseMessageHistory_CaseServiceEventsProcess

	/// <exclude/>
	public partial class CaseMessageHistory_CaseServiceEventsProcess<TEntity> : BPMSoft.Configuration.BaseMessageHistory_MessageEventsProcess<TEntity> where TEntity : CaseMessageHistory
	{

		public CaseMessageHistory_CaseServiceEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "CaseMessageHistory_CaseServiceEventsProcess";
			SchemaUId = new Guid("9abf0257-2d36-47ca-920c-b9fb084275d6");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("9abf0257-2d36-47ca-920c-b9fb084275d6");
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

	#region Class: CaseMessageHistory_CaseServiceEventsProcess

	/// <exclude/>
	public class CaseMessageHistory_CaseServiceEventsProcess : CaseMessageHistory_CaseServiceEventsProcess<CaseMessageHistory>
	{

		public CaseMessageHistory_CaseServiceEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: CaseMessageHistory_CaseServiceEventsProcess

	public partial class CaseMessageHistory_CaseServiceEventsProcess<TEntity>
	{

		#region Methods: Public

		public override void LocalMessageExecuting(EntityChangeType changeType) {
			var lmHelper = new BPMSoft.Configuration.LocalMessageHelper(this.Entity, UserConnection, changeType);
			lmHelper.CreateLocalMessage();
		}

		#endregion

	}

	#endregion


	#region Class: CaseMessageHistoryEventsProcess

	/// <exclude/>
	public class CaseMessageHistoryEventsProcess : CaseMessageHistory_CaseServiceEventsProcess
	{

		public CaseMessageHistoryEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

