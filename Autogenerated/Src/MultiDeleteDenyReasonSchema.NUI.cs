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

	#region Class: MultiDeleteDenyReasonSchema

	/// <exclude/>
	public class MultiDeleteDenyReasonSchema : BPMSoft.Configuration.BaseCodeLookupSchema
	{

		#region Constructors: Public

		public MultiDeleteDenyReasonSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public MultiDeleteDenyReasonSchema(MultiDeleteDenyReasonSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public MultiDeleteDenyReasonSchema(MultiDeleteDenyReasonSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("0319bfbd-378c-4187-ad1f-d8f0c6d80c24");
			RealUId = new Guid("0319bfbd-378c-4187-ad1f-d8f0c6d80c24");
			Name = "MultiDeleteDenyReason";
			ParentSchemaUId = new Guid("2681062b-df59-4e52-89ed-f9b7dc909ab2");
			ExtendParent = false;
			CreatedInPackageId = new Guid("db43ba5c-9334-4bce-a1f8-d5a6f72577ed");
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
			return new MultiDeleteDenyReason(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new MultiDeleteDenyReason_NUIEventsProcess(userConnection);
		}

		public override object Clone() {
			return new MultiDeleteDenyReasonSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new MultiDeleteDenyReasonSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("0319bfbd-378c-4187-ad1f-d8f0c6d80c24"));
		}

		#endregion

	}

	#endregion

	#region Class: MultiDeleteDenyReason

	/// <summary>
	/// Cause for inability to delete records.
	/// </summary>
	public class MultiDeleteDenyReason : BPMSoft.Configuration.BaseCodeLookup
	{

		#region Constructors: Public

		public MultiDeleteDenyReason(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "MultiDeleteDenyReason";
		}

		public MultiDeleteDenyReason(MultiDeleteDenyReason source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new MultiDeleteDenyReason_NUIEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("MultiDeleteDenyReasonDeleted", e);
			Validating += (s, e) => ThrowEvent("MultiDeleteDenyReasonValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new MultiDeleteDenyReason(this);
		}

		#endregion

	}

	#endregion

	#region Class: MultiDeleteDenyReason_NUIEventsProcess

	/// <exclude/>
	public partial class MultiDeleteDenyReason_NUIEventsProcess<TEntity> : BPMSoft.Configuration.BaseCodeLookup_BaseEventsProcess<TEntity> where TEntity : MultiDeleteDenyReason
	{

		public MultiDeleteDenyReason_NUIEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "MultiDeleteDenyReason_NUIEventsProcess";
			SchemaUId = new Guid("0319bfbd-378c-4187-ad1f-d8f0c6d80c24");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("0319bfbd-378c-4187-ad1f-d8f0c6d80c24");
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

	#region Class: MultiDeleteDenyReason_NUIEventsProcess

	/// <exclude/>
	public class MultiDeleteDenyReason_NUIEventsProcess : MultiDeleteDenyReason_NUIEventsProcess<MultiDeleteDenyReason>
	{

		public MultiDeleteDenyReason_NUIEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: MultiDeleteDenyReason_NUIEventsProcess

	public partial class MultiDeleteDenyReason_NUIEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: MultiDeleteDenyReasonEventsProcess

	/// <exclude/>
	public class MultiDeleteDenyReasonEventsProcess : MultiDeleteDenyReason_NUIEventsProcess
	{

		public MultiDeleteDenyReasonEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

