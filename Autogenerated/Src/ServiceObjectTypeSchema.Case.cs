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

	#region Class: ServiceObjectTypeSchema

	/// <exclude/>
	public class ServiceObjectTypeSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public ServiceObjectTypeSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ServiceObjectTypeSchema(ServiceObjectTypeSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ServiceObjectTypeSchema(ServiceObjectTypeSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("84de8928-d67f-4b9c-b224-62f16f7d2598");
			RealUId = new Guid("84de8928-d67f-4b9c-b224-62f16f7d2598");
			Name = "ServiceObjectType";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("84de8928-d67f-4b9c-b224-62f16f7d2598");
			column.CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("84de8928-d67f-4b9c-b224-62f16f7d2598");
			column.CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("84de8928-d67f-4b9c-b224-62f16f7d2598");
			column.CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("84de8928-d67f-4b9c-b224-62f16f7d2598");
			column.CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("84de8928-d67f-4b9c-b224-62f16f7d2598");
			column.CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485");
			return column;
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("84de8928-d67f-4b9c-b224-62f16f7d2598");
			column.CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("84de8928-d67f-4b9c-b224-62f16f7d2598");
			column.CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("84de8928-d67f-4b9c-b224-62f16f7d2598");
			column.CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ServiceObjectType(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ServiceObjectType_CaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ServiceObjectTypeSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ServiceObjectTypeSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("84de8928-d67f-4b9c-b224-62f16f7d2598"));
		}

		#endregion

	}

	#endregion

	#region Class: ServiceObjectType

	/// <summary>
	/// Тип объекта обслуживания.
	/// </summary>
	public class ServiceObjectType : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public ServiceObjectType(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ServiceObjectType";
		}

		public ServiceObjectType(ServiceObjectType source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ServiceObjectType_CaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ServiceObjectTypeDeleted", e);
			Inserting += (s, e) => ThrowEvent("ServiceObjectTypeInserting", e);
			Validating += (s, e) => ThrowEvent("ServiceObjectTypeValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ServiceObjectType(this);
		}

		#endregion

	}

	#endregion

	#region Class: ServiceObjectType_CaseEventsProcess

	/// <exclude/>
	public partial class ServiceObjectType_CaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : ServiceObjectType
	{

		public ServiceObjectType_CaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ServiceObjectType_CaseEventsProcess";
			SchemaUId = new Guid("84de8928-d67f-4b9c-b224-62f16f7d2598");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("84de8928-d67f-4b9c-b224-62f16f7d2598");
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

	#region Class: ServiceObjectType_CaseEventsProcess

	/// <exclude/>
	public class ServiceObjectType_CaseEventsProcess : ServiceObjectType_CaseEventsProcess<ServiceObjectType>
	{

		public ServiceObjectType_CaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ServiceObjectType_CaseEventsProcess

	public partial class ServiceObjectType_CaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ServiceObjectTypeEventsProcess

	/// <exclude/>
	public class ServiceObjectTypeEventsProcess : ServiceObjectType_CaseEventsProcess
	{

		public ServiceObjectTypeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

