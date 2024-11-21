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

	#region Class: CallFolderSchema

	/// <exclude/>
	public class CallFolderSchema : BPMSoft.Configuration.CallFolder_Base_BPMSoftSchema
	{

		#region Constructors: Public

		public CallFolderSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public CallFolderSchema(CallFolderSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public CallFolderSchema(CallFolderSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("b40e8d89-4e65-4f51-baef-af1408366ee4");
			Name = "CallFolder";
			ParentSchemaUId = new Guid("d20408e6-4859-42ac-8c7a-e8ce7e63dc5b");
			ExtendParent = true;
			CreatedInPackageId = new Guid("4eb36ce5-c20b-4142-85d7-04f72012f119");
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
			return new CallFolder(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new CallFolder_CaseServiceEventsProcess(userConnection);
		}

		public override object Clone() {
			return new CallFolderSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new CallFolderSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("b40e8d89-4e65-4f51-baef-af1408366ee4"));
		}

		#endregion

	}

	#endregion

	#region Class: CallFolder

	/// <summary>
	/// Группа звонка.
	/// </summary>
	public class CallFolder : BPMSoft.Configuration.CallFolder_Base_BPMSoft
	{

		#region Constructors: Public

		public CallFolder(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "CallFolder";
		}

		public CallFolder(CallFolder source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new CallFolder_CaseServiceEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("CallFolderDeleted", e);
			Validating += (s, e) => ThrowEvent("CallFolderValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new CallFolder(this);
		}

		#endregion

	}

	#endregion

	#region Class: CallFolder_CaseServiceEventsProcess

	/// <exclude/>
	public partial class CallFolder_CaseServiceEventsProcess<TEntity> : BPMSoft.Configuration.CallFolder_BaseEventsProcess<TEntity> where TEntity : CallFolder
	{

		public CallFolder_CaseServiceEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "CallFolder_CaseServiceEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("b40e8d89-4e65-4f51-baef-af1408366ee4");
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

	#region Class: CallFolder_CaseServiceEventsProcess

	/// <exclude/>
	public class CallFolder_CaseServiceEventsProcess : CallFolder_CaseServiceEventsProcess<CallFolder>
	{

		public CallFolder_CaseServiceEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: CallFolder_CaseServiceEventsProcess

	public partial class CallFolder_CaseServiceEventsProcess<TEntity>
	{

		#region Methods: Public

		public override void LocalMessageExecuting(EntityChangeType changeType) {
			var lmHelper = new BPMSoft.Configuration.LocalMessageHelper(this.Entity, UserConnection, changeType);
			lmHelper.CreateLocalMessage();
		}

		#endregion

	}

	#endregion


	#region Class: CallFolderEventsProcess

	/// <exclude/>
	public class CallFolderEventsProcess : CallFolder_CaseServiceEventsProcess
	{

		public CallFolderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

