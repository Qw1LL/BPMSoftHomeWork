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

	#region Class: OperatorStateSchema

	/// <exclude/>
	public class OperatorStateSchema : BPMSoft.Configuration.BaseCodeLookupSchema
	{

		#region Constructors: Public

		public OperatorStateSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public OperatorStateSchema(OperatorStateSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public OperatorStateSchema(OperatorStateSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("77c870a3-c8d9-41a0-abb2-60ddb7fcd9f7");
			RealUId = new Guid("77c870a3-c8d9-41a0-abb2-60ddb7fcd9f7");
			Name = "OperatorState";
			ParentSchemaUId = new Guid("2681062b-df59-4e52-89ed-f9b7dc909ab2");
			ExtendParent = false;
			CreatedInPackageId = new Guid("ad806488-98f4-482b-bb58-5e43a394961e");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryImageColumn() {
			base.InitializePrimaryImageColumn();
			PrimaryImageColumn = CreateImageColumn();
			if (Columns.FindByUId(PrimaryImageColumn.UId) == null) {
				Columns.Add(PrimaryImageColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("86c4ade6-323c-4c19-9913-2205bbed96ec")) == null) {
				Columns.Add(CreateOperatorAvailableColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateImageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Image")) {
				UId = new Guid("2d8b2337-31ea-4b15-9bc5-0d55b196f95c"),
				Name = @"Image",
				CreatedInSchemaUId = new Guid("77c870a3-c8d9-41a0-abb2-60ddb7fcd9f7"),
				ModifiedInSchemaUId = new Guid("77c870a3-c8d9-41a0-abb2-60ddb7fcd9f7"),
				CreatedInPackageId = new Guid("ad806488-98f4-482b-bb58-5e43a394961e")
			};
		}

		protected virtual EntitySchemaColumn CreateOperatorAvailableColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("86c4ade6-323c-4c19-9913-2205bbed96ec"),
				Name = @"OperatorAvailable",
				CreatedInSchemaUId = new Guid("77c870a3-c8d9-41a0-abb2-60ddb7fcd9f7"),
				ModifiedInSchemaUId = new Guid("77c870a3-c8d9-41a0-abb2-60ddb7fcd9f7"),
				CreatedInPackageId = new Guid("ad806488-98f4-482b-bb58-5e43a394961e")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new OperatorState(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new OperatorState_OmnichannelMessagingEventsProcess(userConnection);
		}

		public override object Clone() {
			return new OperatorStateSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new OperatorStateSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("77c870a3-c8d9-41a0-abb2-60ddb7fcd9f7"));
		}

		#endregion

	}

	#endregion

	#region Class: OperatorState

	/// <summary>
	/// Operator state.
	/// </summary>
	public class OperatorState : BPMSoft.Configuration.BaseCodeLookup
	{

		#region Constructors: Public

		public OperatorState(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "OperatorState";
		}

		public OperatorState(OperatorState source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Operator available.
		/// </summary>
		public bool OperatorAvailable {
			get {
				return GetTypedColumnValue<bool>("OperatorAvailable");
			}
			set {
				SetColumnValue("OperatorAvailable", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new OperatorState_OmnichannelMessagingEventsProcess(UserConnection);
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
			return new OperatorState(this);
		}

		#endregion

	}

	#endregion

	#region Class: OperatorState_OmnichannelMessagingEventsProcess

	/// <exclude/>
	public partial class OperatorState_OmnichannelMessagingEventsProcess<TEntity> : BPMSoft.Configuration.BaseCodeLookup_BaseEventsProcess<TEntity> where TEntity : OperatorState
	{

		public OperatorState_OmnichannelMessagingEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "OperatorState_OmnichannelMessagingEventsProcess";
			SchemaUId = new Guid("77c870a3-c8d9-41a0-abb2-60ddb7fcd9f7");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("77c870a3-c8d9-41a0-abb2-60ddb7fcd9f7");
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

	#region Class: OperatorState_OmnichannelMessagingEventsProcess

	/// <exclude/>
	public class OperatorState_OmnichannelMessagingEventsProcess : OperatorState_OmnichannelMessagingEventsProcess<OperatorState>
	{

		public OperatorState_OmnichannelMessagingEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: OperatorState_OmnichannelMessagingEventsProcess

	public partial class OperatorState_OmnichannelMessagingEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: OperatorStateEventsProcess

	/// <exclude/>
	public class OperatorStateEventsProcess : OperatorState_OmnichannelMessagingEventsProcess
	{

		public OperatorStateEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

