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

	#region Class: ConnectionTypeSchema

	/// <exclude/>
	public class ConnectionTypeSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public ConnectionTypeSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ConnectionTypeSchema(ConnectionTypeSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ConnectionTypeSchema(ConnectionTypeSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("15ae9439-ba1c-415d-875c-c2aa884f658e");
			RealUId = new Guid("15ae9439-ba1c-415d-875c-c2aa884f658e");
			Name = "ConnectionType";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("316b74f8-2b91-48b6-8fd9-afebf5f18b05")) == null) {
				Columns.Add(CreateValueColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateValueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("316b74f8-2b91-48b6-8fd9-afebf5f18b05"),
				Name = @"Value",
				CreatedInSchemaUId = new Guid("15ae9439-ba1c-415d-875c-c2aa884f658e"),
				ModifiedInSchemaUId = new Guid("15ae9439-ba1c-415d-875c-c2aa884f658e"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ConnectionType(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ConnectionType_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ConnectionTypeSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ConnectionTypeSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("15ae9439-ba1c-415d-875c-c2aa884f658e"));
		}

		#endregion

	}

	#endregion

	#region Class: ConnectionType

	/// <summary>
	/// User connection type.
	/// </summary>
	public class ConnectionType : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public ConnectionType(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ConnectionType";
		}

		public ConnectionType(ConnectionType source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Value.
		/// </summary>
		public int Value {
			get {
				return GetTypedColumnValue<int>("Value");
			}
			set {
				SetColumnValue("Value", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ConnectionType_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ConnectionTypeDeleted", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ConnectionType(this);
		}

		#endregion

	}

	#endregion

	#region Class: ConnectionType_BaseEventsProcess

	/// <exclude/>
	public partial class ConnectionType_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : ConnectionType
	{

		public ConnectionType_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ConnectionType_BaseEventsProcess";
			SchemaUId = new Guid("15ae9439-ba1c-415d-875c-c2aa884f658e");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("15ae9439-ba1c-415d-875c-c2aa884f658e");
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

	#region Class: ConnectionType_BaseEventsProcess

	/// <exclude/>
	public class ConnectionType_BaseEventsProcess : ConnectionType_BaseEventsProcess<ConnectionType>
	{

		public ConnectionType_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ConnectionType_BaseEventsProcess

	public partial class ConnectionType_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ConnectionTypeEventsProcess

	/// <exclude/>
	public class ConnectionTypeEventsProcess : ConnectionType_BaseEventsProcess
	{

		public ConnectionTypeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

