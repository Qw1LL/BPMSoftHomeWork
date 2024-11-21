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

	#region Class: LendingStateSchema

	/// <exclude/>
	public class LendingStateSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public LendingStateSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public LendingStateSchema(LendingStateSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public LendingStateSchema(LendingStateSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("967d4133-7d63-492f-a8f3-e406d06c6bbd");
			RealUId = new Guid("967d4133-7d63-492f-a8f3-e406d06c6bbd");
			Name = "LendingState";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("2f566863-6a05-41ae-bb68-b647818b8f61");
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

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new LendingState(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new LendingState_WebFormEventsProcess(userConnection);
		}

		public override object Clone() {
			return new LendingStateSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new LendingStateSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("967d4133-7d63-492f-a8f3-e406d06c6bbd"));
		}

		#endregion

	}

	#endregion

	#region Class: LendingState

	/// <summary>
	/// Landing status.
	/// </summary>
	public class LendingState : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public LendingState(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "LendingState";
		}

		public LendingState(LendingState source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new LendingState_WebFormEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("LendingStateDeleted", e);
			Validating += (s, e) => ThrowEvent("LendingStateValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new LendingState(this);
		}

		#endregion

	}

	#endregion

	#region Class: LendingState_WebFormEventsProcess

	/// <exclude/>
	public partial class LendingState_WebFormEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : LendingState
	{

		public LendingState_WebFormEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "LendingState_WebFormEventsProcess";
			SchemaUId = new Guid("967d4133-7d63-492f-a8f3-e406d06c6bbd");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("967d4133-7d63-492f-a8f3-e406d06c6bbd");
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

	#region Class: LendingState_WebFormEventsProcess

	/// <exclude/>
	public class LendingState_WebFormEventsProcess : LendingState_WebFormEventsProcess<LendingState>
	{

		public LendingState_WebFormEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: LendingState_WebFormEventsProcess

	public partial class LendingState_WebFormEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: LendingStateEventsProcess

	/// <exclude/>
	public class LendingStateEventsProcess : LendingState_WebFormEventsProcess
	{

		public LendingStateEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

