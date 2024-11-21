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

	#region Class: SysMsgUserStateReasonSchema

	/// <exclude/>
	public class SysMsgUserStateReasonSchema : BPMSoft.Configuration.BaseCodeImageLookupSchema
	{

		#region Constructors: Public

		public SysMsgUserStateReasonSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysMsgUserStateReasonSchema(SysMsgUserStateReasonSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysMsgUserStateReasonSchema(SysMsgUserStateReasonSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("1a286a70-31d9-40f9-9583-7e81ccf743a1");
			RealUId = new Guid("1a286a70-31d9-40f9-9583-7e81ccf743a1");
			Name = "SysMsgUserStateReason";
			ParentSchemaUId = new Guid("c21771d2-01fa-4646-96b0-e4b69e582b44");
			ExtendParent = false;
			CreatedInPackageId = new Guid("7689c850-1a27-48e1-bfba-7dca05204845");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("eadd9d6f-9fe1-46fc-87a8-9167c91ae635")) == null) {
				Columns.Add(CreateSysMsgUserStateColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("1a286a70-31d9-40f9-9583-7e81ccf743a1");
			column.CreatedInPackageId = new Guid("7689c850-1a27-48e1-bfba-7dca05204845");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("1a286a70-31d9-40f9-9583-7e81ccf743a1");
			column.CreatedInPackageId = new Guid("7689c850-1a27-48e1-bfba-7dca05204845");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("1a286a70-31d9-40f9-9583-7e81ccf743a1");
			column.CreatedInPackageId = new Guid("7689c850-1a27-48e1-bfba-7dca05204845");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("1a286a70-31d9-40f9-9583-7e81ccf743a1");
			column.CreatedInPackageId = new Guid("7689c850-1a27-48e1-bfba-7dca05204845");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("1a286a70-31d9-40f9-9583-7e81ccf743a1");
			column.CreatedInPackageId = new Guid("7689c850-1a27-48e1-bfba-7dca05204845");
			return column;
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.DataValueType = DataValueTypeManager.GetInstanceByName("ShortText");
			column.ModifiedInSchemaUId = new Guid("1a286a70-31d9-40f9-9583-7e81ccf743a1");
			column.CreatedInPackageId = new Guid("7689c850-1a27-48e1-bfba-7dca05204845");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("1a286a70-31d9-40f9-9583-7e81ccf743a1");
			column.CreatedInPackageId = new Guid("7689c850-1a27-48e1-bfba-7dca05204845");
			return column;
		}

		protected override EntitySchemaColumn CreateCodeColumn() {
			EntitySchemaColumn column = base.CreateCodeColumn();
			column.ModifiedInSchemaUId = new Guid("1a286a70-31d9-40f9-9583-7e81ccf743a1");
			column.CreatedInPackageId = new Guid("7689c850-1a27-48e1-bfba-7dca05204845");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("1a286a70-31d9-40f9-9583-7e81ccf743a1");
			column.CreatedInPackageId = new Guid("7689c850-1a27-48e1-bfba-7dca05204845");
			return column;
		}

		protected override EntitySchemaColumn CreateImageColumn() {
			EntitySchemaColumn column = base.CreateImageColumn();
			column.ModifiedInSchemaUId = new Guid("1a286a70-31d9-40f9-9583-7e81ccf743a1");
			column.CreatedInPackageId = new Guid("7689c850-1a27-48e1-bfba-7dca05204845");
			return column;
		}

		protected virtual EntitySchemaColumn CreateSysMsgUserStateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("eadd9d6f-9fe1-46fc-87a8-9167c91ae635"),
				Name = @"SysMsgUserState",
				ReferenceSchemaUId = new Guid("bb85a556-c9b9-41ee-acfa-eabc9bfb84ac"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("1a286a70-31d9-40f9-9583-7e81ccf743a1"),
				ModifiedInSchemaUId = new Guid("1a286a70-31d9-40f9-9583-7e81ccf743a1"),
				CreatedInPackageId = new Guid("7689c850-1a27-48e1-bfba-7dca05204845")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysMsgUserStateReason(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysMsgUserStateReason_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysMsgUserStateReasonSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysMsgUserStateReasonSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("1a286a70-31d9-40f9-9583-7e81ccf743a1"));
		}

		#endregion

	}

	#endregion

	#region Class: SysMsgUserStateReason

	/// <summary>
	/// User status reason while messaging.
	/// </summary>
	public class SysMsgUserStateReason : BPMSoft.Configuration.BaseCodeImageLookup
	{

		#region Constructors: Public

		public SysMsgUserStateReason(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysMsgUserStateReason";
		}

		public SysMsgUserStateReason(SysMsgUserStateReason source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid SysMsgUserStateId {
			get {
				return GetTypedColumnValue<Guid>("SysMsgUserStateId");
			}
			set {
				SetColumnValue("SysMsgUserStateId", value);
				_sysMsgUserState = null;
			}
		}

		/// <exclude/>
		public string SysMsgUserStateName {
			get {
				return GetTypedColumnValue<string>("SysMsgUserStateName");
			}
			set {
				SetColumnValue("SysMsgUserStateName", value);
				if (_sysMsgUserState != null) {
					_sysMsgUserState.Name = value;
				}
			}
		}

		private SysMsgUserState _sysMsgUserState;
		/// <summary>
		/// User status.
		/// </summary>
		public SysMsgUserState SysMsgUserState {
			get {
				return _sysMsgUserState ??
					(_sysMsgUserState = LookupColumnEntities.GetEntity("SysMsgUserState") as SysMsgUserState);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysMsgUserStateReason_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysMsgUserStateReasonDeleted", e);
			Inserting += (s, e) => ThrowEvent("SysMsgUserStateReasonInserting", e);
			Validating += (s, e) => ThrowEvent("SysMsgUserStateReasonValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysMsgUserStateReason(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysMsgUserStateReason_BaseEventsProcess

	/// <exclude/>
	public partial class SysMsgUserStateReason_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseCodeImageLookup_BaseEventsProcess<TEntity> where TEntity : SysMsgUserStateReason
	{

		public SysMsgUserStateReason_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysMsgUserStateReason_BaseEventsProcess";
			SchemaUId = new Guid("1a286a70-31d9-40f9-9583-7e81ccf743a1");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("1a286a70-31d9-40f9-9583-7e81ccf743a1");
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

	#region Class: SysMsgUserStateReason_BaseEventsProcess

	/// <exclude/>
	public class SysMsgUserStateReason_BaseEventsProcess : SysMsgUserStateReason_BaseEventsProcess<SysMsgUserStateReason>
	{

		public SysMsgUserStateReason_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysMsgUserStateReason_BaseEventsProcess

	public partial class SysMsgUserStateReason_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysMsgUserStateReasonEventsProcess

	/// <exclude/>
	public class SysMsgUserStateReasonEventsProcess : SysMsgUserStateReason_BaseEventsProcess
	{

		public SysMsgUserStateReasonEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

