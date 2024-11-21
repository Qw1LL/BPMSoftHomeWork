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

	#region Class: LeadMessageHistorySchema

	/// <exclude/>
	public class LeadMessageHistorySchema : BPMSoft.Configuration.BaseMessageHistorySchema
	{

		#region Constructors: Public

		public LeadMessageHistorySchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public LeadMessageHistorySchema(LeadMessageHistorySchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public LeadMessageHistorySchema(LeadMessageHistorySchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("19aba57e-291a-4968-a7cb-2a1471bf327f");
			RealUId = new Guid("19aba57e-291a-4968-a7cb-2a1471bf327f");
			Name = "LeadMessageHistory";
			ParentSchemaUId = new Guid("a8f74749-bbc1-47a6-84b6-10e974356e91");
			ExtendParent = false;
			CreatedInPackageId = new Guid("2b000645-6072-461d-8963-11edfee86881");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeMasterRecordColumn() {
			base.InitializeMasterRecordColumn();
			MasterRecordColumn = CreateLeadColumn();
			if (Columns.FindByUId(MasterRecordColumn.UId) == null) {
				Columns.Add(MasterRecordColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected virtual EntitySchemaColumn CreateLeadColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("76d98fdb-8b72-4b96-a023-bcfc9aaa82b5"),
				Name = @"Lead",
				ReferenceSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("19aba57e-291a-4968-a7cb-2a1471bf327f"),
				ModifiedInSchemaUId = new Guid("19aba57e-291a-4968-a7cb-2a1471bf327f"),
				CreatedInPackageId = new Guid("2b000645-6072-461d-8963-11edfee86881")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new LeadMessageHistory(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new LeadMessageHistory_PRMBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new LeadMessageHistorySchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new LeadMessageHistorySchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("19aba57e-291a-4968-a7cb-2a1471bf327f"));
		}

		#endregion

	}

	#endregion

	#region Class: LeadMessageHistory

	/// <summary>
	/// История сообщений по лиду.
	/// </summary>
	public class LeadMessageHistory : BPMSoft.Configuration.BaseMessageHistory
	{

		#region Constructors: Public

		public LeadMessageHistory(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "LeadMessageHistory";
		}

		public LeadMessageHistory(LeadMessageHistory source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid LeadId {
			get {
				return GetTypedColumnValue<Guid>("LeadId");
			}
			set {
				SetColumnValue("LeadId", value);
				_lead = null;
			}
		}

		/// <exclude/>
		public string LeadLeadName {
			get {
				return GetTypedColumnValue<string>("LeadLeadName");
			}
			set {
				SetColumnValue("LeadLeadName", value);
				if (_lead != null) {
					_lead.LeadName = value;
				}
			}
		}

		private Lead _lead;
		/// <summary>
		/// Лид.
		/// </summary>
		public Lead Lead {
			get {
				return _lead ??
					(_lead = LookupColumnEntities.GetEntity("Lead") as Lead);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new LeadMessageHistory_PRMBaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("LeadMessageHistoryDeleted", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new LeadMessageHistory(this);
		}

		#endregion

	}

	#endregion

	#region Class: LeadMessageHistory_PRMBaseEventsProcess

	/// <exclude/>
	public partial class LeadMessageHistory_PRMBaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseMessageHistory_MessageEventsProcess<TEntity> where TEntity : LeadMessageHistory
	{

		public LeadMessageHistory_PRMBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "LeadMessageHistory_PRMBaseEventsProcess";
			SchemaUId = new Guid("19aba57e-291a-4968-a7cb-2a1471bf327f");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("19aba57e-291a-4968-a7cb-2a1471bf327f");
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

	#region Class: LeadMessageHistory_PRMBaseEventsProcess

	/// <exclude/>
	public class LeadMessageHistory_PRMBaseEventsProcess : LeadMessageHistory_PRMBaseEventsProcess<LeadMessageHistory>
	{

		public LeadMessageHistory_PRMBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: LeadMessageHistory_PRMBaseEventsProcess

	public partial class LeadMessageHistory_PRMBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: LeadMessageHistoryEventsProcess

	/// <exclude/>
	public class LeadMessageHistoryEventsProcess : LeadMessageHistory_PRMBaseEventsProcess
	{

		public LeadMessageHistoryEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

