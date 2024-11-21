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

	#region Class: SysEntityOperationSchema

	/// <exclude/>
	public class SysEntityOperationSchema : BPMSoft.Configuration.BaseCodeLookupSchema
	{

		#region Constructors: Public

		public SysEntityOperationSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysEntityOperationSchema(SysEntityOperationSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysEntityOperationSchema(SysEntityOperationSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("a6af1d7b-0bba-4146-8868-c677c0fb9212");
			RealUId = new Guid("a6af1d7b-0bba-4146-8868-c677c0fb9212");
			Name = "SysEntityOperation";
			ParentSchemaUId = new Guid("2681062b-df59-4e52-89ed-f9b7dc909ab2");
			ExtendParent = false;
			CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = true;
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
			return new SysEntityOperation(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysEntityOperation_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysEntityOperationSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysEntityOperationSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("a6af1d7b-0bba-4146-8868-c677c0fb9212"));
		}

		#endregion

	}

	#endregion

	#region Class: SysEntityOperation

	/// <summary>
	/// Entity operation.
	/// </summary>
	public class SysEntityOperation : BPMSoft.Configuration.BaseCodeLookup
	{

		#region Constructors: Public

		public SysEntityOperation(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysEntityOperation";
		}

		public SysEntityOperation(SysEntityOperation source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysEntityOperation_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysEntityOperation(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysEntityOperation_BaseEventsProcess

	/// <exclude/>
	public partial class SysEntityOperation_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseCodeLookup_BaseEventsProcess<TEntity> where TEntity : SysEntityOperation
	{

		public SysEntityOperation_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysEntityOperation_BaseEventsProcess";
			SchemaUId = new Guid("a6af1d7b-0bba-4146-8868-c677c0fb9212");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("a6af1d7b-0bba-4146-8868-c677c0fb9212");
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

	#region Class: SysEntityOperation_BaseEventsProcess

	/// <exclude/>
	public class SysEntityOperation_BaseEventsProcess : SysEntityOperation_BaseEventsProcess<SysEntityOperation>
	{

		public SysEntityOperation_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysEntityOperation_BaseEventsProcess

	public partial class SysEntityOperation_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysEntityOperationEventsProcess

	/// <exclude/>
	public class SysEntityOperationEventsProcess : SysEntityOperation_BaseEventsProcess
	{

		public SysEntityOperationEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

