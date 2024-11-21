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

	#region Class: LeadSalesDirectionSchema

	/// <exclude/>
	public class LeadSalesDirectionSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public LeadSalesDirectionSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public LeadSalesDirectionSchema(LeadSalesDirectionSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public LeadSalesDirectionSchema(LeadSalesDirectionSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("f33b8854-69ea-4cc2-9e84-5c40c7276215");
			RealUId = new Guid("f33b8854-69ea-4cc2-9e84-5c40c7276215");
			Name = "LeadSalesDirection";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("4261e5b6-ac7c-4768-a57f-7066cca089f2");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("f33b8854-69ea-4cc2-9e84-5c40c7276215");
			column.CreatedInPackageId = new Guid("4261e5b6-ac7c-4768-a57f-7066cca089f2");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("f33b8854-69ea-4cc2-9e84-5c40c7276215");
			column.CreatedInPackageId = new Guid("4261e5b6-ac7c-4768-a57f-7066cca089f2");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("f33b8854-69ea-4cc2-9e84-5c40c7276215");
			column.CreatedInPackageId = new Guid("4261e5b6-ac7c-4768-a57f-7066cca089f2");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("f33b8854-69ea-4cc2-9e84-5c40c7276215");
			column.CreatedInPackageId = new Guid("4261e5b6-ac7c-4768-a57f-7066cca089f2");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("f33b8854-69ea-4cc2-9e84-5c40c7276215");
			column.CreatedInPackageId = new Guid("4261e5b6-ac7c-4768-a57f-7066cca089f2");
			return column;
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("f33b8854-69ea-4cc2-9e84-5c40c7276215");
			column.CreatedInPackageId = new Guid("4261e5b6-ac7c-4768-a57f-7066cca089f2");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("f33b8854-69ea-4cc2-9e84-5c40c7276215");
			column.CreatedInPackageId = new Guid("4261e5b6-ac7c-4768-a57f-7066cca089f2");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("f33b8854-69ea-4cc2-9e84-5c40c7276215");
			column.CreatedInPackageId = new Guid("4261e5b6-ac7c-4768-a57f-7066cca089f2");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new LeadSalesDirection(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new LeadSalesDirection_LeadEventsProcess(userConnection);
		}

		public override object Clone() {
			return new LeadSalesDirectionSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new LeadSalesDirectionSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("f33b8854-69ea-4cc2-9e84-5c40c7276215"));
		}

		#endregion

	}

	#endregion

	#region Class: LeadSalesDirection

	/// <summary>
	/// Направление продаж лида.
	/// </summary>
	public class LeadSalesDirection : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public LeadSalesDirection(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "LeadSalesDirection";
		}

		public LeadSalesDirection(LeadSalesDirection source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new LeadSalesDirection_LeadEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("LeadSalesDirectionDeleted", e);
			Inserting += (s, e) => ThrowEvent("LeadSalesDirectionInserting", e);
			Validating += (s, e) => ThrowEvent("LeadSalesDirectionValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new LeadSalesDirection(this);
		}

		#endregion

	}

	#endregion

	#region Class: LeadSalesDirection_LeadEventsProcess

	/// <exclude/>
	public partial class LeadSalesDirection_LeadEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : LeadSalesDirection
	{

		public LeadSalesDirection_LeadEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "LeadSalesDirection_LeadEventsProcess";
			SchemaUId = new Guid("f33b8854-69ea-4cc2-9e84-5c40c7276215");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("f33b8854-69ea-4cc2-9e84-5c40c7276215");
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

	#region Class: LeadSalesDirection_LeadEventsProcess

	/// <exclude/>
	public class LeadSalesDirection_LeadEventsProcess : LeadSalesDirection_LeadEventsProcess<LeadSalesDirection>
	{

		public LeadSalesDirection_LeadEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: LeadSalesDirection_LeadEventsProcess

	public partial class LeadSalesDirection_LeadEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: LeadSalesDirectionEventsProcess

	/// <exclude/>
	public class LeadSalesDirectionEventsProcess : LeadSalesDirection_LeadEventsProcess
	{

		public LeadSalesDirectionEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

