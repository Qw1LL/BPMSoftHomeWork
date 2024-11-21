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

	#region Class: CashflowTypeSchema

	/// <exclude/>
	public class CashflowTypeSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public CashflowTypeSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public CashflowTypeSchema(CashflowTypeSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public CashflowTypeSchema(CashflowTypeSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("22a9cf97-97de-4d60-9d09-9922849cfeb0");
			RealUId = new Guid("22a9cf97-97de-4d60-9d09-9922849cfeb0");
			Name = "CashflowType";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("fe2bb0e4-061e-41b1-be85-5078c802043f");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("22a9cf97-97de-4d60-9d09-9922849cfeb0");
			column.CreatedInPackageId = new Guid("fe2bb0e4-061e-41b1-be85-5078c802043f");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("22a9cf97-97de-4d60-9d09-9922849cfeb0");
			column.CreatedInPackageId = new Guid("fe2bb0e4-061e-41b1-be85-5078c802043f");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("22a9cf97-97de-4d60-9d09-9922849cfeb0");
			column.CreatedInPackageId = new Guid("fe2bb0e4-061e-41b1-be85-5078c802043f");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("22a9cf97-97de-4d60-9d09-9922849cfeb0");
			column.CreatedInPackageId = new Guid("fe2bb0e4-061e-41b1-be85-5078c802043f");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("22a9cf97-97de-4d60-9d09-9922849cfeb0");
			column.CreatedInPackageId = new Guid("fe2bb0e4-061e-41b1-be85-5078c802043f");
			return column;
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("22a9cf97-97de-4d60-9d09-9922849cfeb0");
			column.CreatedInPackageId = new Guid("fe2bb0e4-061e-41b1-be85-5078c802043f");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("22a9cf97-97de-4d60-9d09-9922849cfeb0");
			column.CreatedInPackageId = new Guid("fe2bb0e4-061e-41b1-be85-5078c802043f");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("22a9cf97-97de-4d60-9d09-9922849cfeb0");
			column.CreatedInPackageId = new Guid("fe2bb0e4-061e-41b1-be85-5078c802043f");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new CashflowType(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new CashflowType_ProjectEventsProcess(userConnection);
		}

		public override object Clone() {
			return new CashflowTypeSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new CashflowTypeSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("22a9cf97-97de-4d60-9d09-9922849cfeb0"));
		}

		#endregion

	}

	#endregion

	#region Class: CashflowType

	/// <summary>
	/// Тип операции.
	/// </summary>
	public class CashflowType : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public CashflowType(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "CashflowType";
		}

		public CashflowType(CashflowType source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new CashflowType_ProjectEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("CashflowTypeDeleted", e);
			Inserting += (s, e) => ThrowEvent("CashflowTypeInserting", e);
			Validating += (s, e) => ThrowEvent("CashflowTypeValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new CashflowType(this);
		}

		#endregion

	}

	#endregion

	#region Class: CashflowType_ProjectEventsProcess

	/// <exclude/>
	public partial class CashflowType_ProjectEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : CashflowType
	{

		public CashflowType_ProjectEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "CashflowType_ProjectEventsProcess";
			SchemaUId = new Guid("22a9cf97-97de-4d60-9d09-9922849cfeb0");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("22a9cf97-97de-4d60-9d09-9922849cfeb0");
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

	#region Class: CashflowType_ProjectEventsProcess

	/// <exclude/>
	public class CashflowType_ProjectEventsProcess : CashflowType_ProjectEventsProcess<CashflowType>
	{

		public CashflowType_ProjectEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: CashflowType_ProjectEventsProcess

	public partial class CashflowType_ProjectEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: CashflowTypeEventsProcess

	/// <exclude/>
	public class CashflowTypeEventsProcess : CashflowType_ProjectEventsProcess
	{

		public CashflowTypeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

