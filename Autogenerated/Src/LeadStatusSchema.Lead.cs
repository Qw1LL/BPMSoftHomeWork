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

	#region Class: LeadStatusSchema

	/// <exclude/>
	public class LeadStatusSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public LeadStatusSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public LeadStatusSchema(LeadStatusSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public LeadStatusSchema(LeadStatusSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("8afb33a4-8b82-4325-a15b-44a8b4ccd7f3");
			RealUId = new Guid("8afb33a4-8b82-4325-a15b-44a8b4ccd7f3");
			Name = "LeadStatus";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("35a9dba7-616b-4d9a-9bb2-9343f4c634d9")) == null) {
				Columns.Add(CreateActiveColumn());
			}
			if (Columns.FindByUId(new Guid("c24217b0-3421-4c31-b1e1-5d1ca5bb45c1")) == null) {
				Columns.Add(CreateColorColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("8afb33a4-8b82-4325-a15b-44a8b4ccd7f3");
			column.CreatedInPackageId = new Guid("b58d2c33-e1a2-4365-b7e9-3120dc2c01fc");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("8afb33a4-8b82-4325-a15b-44a8b4ccd7f3");
			column.CreatedInPackageId = new Guid("b58d2c33-e1a2-4365-b7e9-3120dc2c01fc");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("8afb33a4-8b82-4325-a15b-44a8b4ccd7f3");
			column.CreatedInPackageId = new Guid("b58d2c33-e1a2-4365-b7e9-3120dc2c01fc");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("8afb33a4-8b82-4325-a15b-44a8b4ccd7f3");
			column.CreatedInPackageId = new Guid("b58d2c33-e1a2-4365-b7e9-3120dc2c01fc");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("8afb33a4-8b82-4325-a15b-44a8b4ccd7f3");
			column.CreatedInPackageId = new Guid("b58d2c33-e1a2-4365-b7e9-3120dc2c01fc");
			return column;
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("8afb33a4-8b82-4325-a15b-44a8b4ccd7f3");
			column.CreatedInPackageId = new Guid("b58d2c33-e1a2-4365-b7e9-3120dc2c01fc");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("8afb33a4-8b82-4325-a15b-44a8b4ccd7f3");
			column.CreatedInPackageId = new Guid("b58d2c33-e1a2-4365-b7e9-3120dc2c01fc");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("8afb33a4-8b82-4325-a15b-44a8b4ccd7f3");
			column.CreatedInPackageId = new Guid("b58d2c33-e1a2-4365-b7e9-3120dc2c01fc");
			return column;
		}

		protected virtual EntitySchemaColumn CreateActiveColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("35a9dba7-616b-4d9a-9bb2-9343f4c634d9"),
				Name = @"Active",
				CreatedInSchemaUId = new Guid("8afb33a4-8b82-4325-a15b-44a8b4ccd7f3"),
				ModifiedInSchemaUId = new Guid("8afb33a4-8b82-4325-a15b-44a8b4ccd7f3"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateColorColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Color")) {
				UId = new Guid("c24217b0-3421-4c31-b1e1-5d1ca5bb45c1"),
				Name = @"Color",
				CreatedInSchemaUId = new Guid("8afb33a4-8b82-4325-a15b-44a8b4ccd7f3"),
				ModifiedInSchemaUId = new Guid("8afb33a4-8b82-4325-a15b-44a8b4ccd7f3"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new LeadStatus(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new LeadStatus_LeadEventsProcess(userConnection);
		}

		public override object Clone() {
			return new LeadStatusSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new LeadStatusSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("8afb33a4-8b82-4325-a15b-44a8b4ccd7f3"));
		}

		#endregion

	}

	#endregion

	#region Class: LeadStatus

	/// <summary>
	/// Состояние лидов.
	/// </summary>
	public class LeadStatus : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public LeadStatus(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "LeadStatus";
		}

		public LeadStatus(LeadStatus source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Активно.
		/// </summary>
		public bool Active {
			get {
				return GetTypedColumnValue<bool>("Active");
			}
			set {
				SetColumnValue("Active", value);
			}
		}

		/// <summary>
		/// Цвет.
		/// </summary>
		public Color Color {
			get {
				return GetTypedColumnValue<Color>("Color");
			}
			set {
				SetColumnValue("Color", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new LeadStatus_LeadEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("LeadStatusDeleted", e);
			Deleting += (s, e) => ThrowEvent("LeadStatusDeleting", e);
			Inserted += (s, e) => ThrowEvent("LeadStatusInserted", e);
			Inserting += (s, e) => ThrowEvent("LeadStatusInserting", e);
			Saved += (s, e) => ThrowEvent("LeadStatusSaved", e);
			Saving += (s, e) => ThrowEvent("LeadStatusSaving", e);
			Validating += (s, e) => ThrowEvent("LeadStatusValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new LeadStatus(this);
		}

		#endregion

	}

	#endregion

	#region Class: LeadStatus_LeadEventsProcess

	/// <exclude/>
	public partial class LeadStatus_LeadEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : LeadStatus
	{

		public LeadStatus_LeadEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "LeadStatus_LeadEventsProcess";
			SchemaUId = new Guid("8afb33a4-8b82-4325-a15b-44a8b4ccd7f3");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("8afb33a4-8b82-4325-a15b-44a8b4ccd7f3");
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

	#region Class: LeadStatus_LeadEventsProcess

	/// <exclude/>
	public class LeadStatus_LeadEventsProcess : LeadStatus_LeadEventsProcess<LeadStatus>
	{

		public LeadStatus_LeadEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: LeadStatus_LeadEventsProcess

	public partial class LeadStatus_LeadEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: LeadStatusEventsProcess

	/// <exclude/>
	public class LeadStatusEventsProcess : LeadStatus_LeadEventsProcess
	{

		public LeadStatusEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

