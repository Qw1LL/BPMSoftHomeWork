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

	#region Class: MonthSchema

	/// <exclude/>
	public class MonthSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public MonthSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public MonthSchema(MonthSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public MonthSchema(MonthSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("4c00fdb7-6950-46fb-be0e-fde9e48925d2");
			RealUId = new Guid("4c00fdb7-6950-46fb-be0e-fde9e48925d2");
			Name = "Month";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("bf2b2686-d2dc-4cea-a366-00448cb52a66")) == null) {
				Columns.Add(CreateNumberColumn());
			}
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("4c00fdb7-6950-46fb-be0e-fde9e48925d2");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("4c00fdb7-6950-46fb-be0e-fde9e48925d2");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("4c00fdb7-6950-46fb-be0e-fde9e48925d2");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("4c00fdb7-6950-46fb-be0e-fde9e48925d2");
			return column;
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("4c00fdb7-6950-46fb-be0e-fde9e48925d2");
			column.CreatedInPackageId = new Guid("c692daa9-de5e-4e96-afd3-e992ed86681c");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("4c00fdb7-6950-46fb-be0e-fde9e48925d2");
			column.CreatedInPackageId = new Guid("c692daa9-de5e-4e96-afd3-e992ed86681c");
			return column;
		}

		protected virtual EntitySchemaColumn CreateNumberColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("bf2b2686-d2dc-4cea-a366-00448cb52a66"),
				Name = @"Number",
				CreatedInSchemaUId = new Guid("4c00fdb7-6950-46fb-be0e-fde9e48925d2"),
				ModifiedInSchemaUId = new Guid("4c00fdb7-6950-46fb-be0e-fde9e48925d2"),
				CreatedInPackageId = new Guid("c692daa9-de5e-4e96-afd3-e992ed86681c")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new Month(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Month_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new MonthSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new MonthSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("4c00fdb7-6950-46fb-be0e-fde9e48925d2"));
		}

		#endregion

	}

	#endregion

	#region Class: Month

	/// <summary>
	/// Month.
	/// </summary>
	public class Month : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public Month(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Month";
		}

		public Month(Month source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Number.
		/// </summary>
		public int Number {
			get {
				return GetTypedColumnValue<int>("Number");
			}
			set {
				SetColumnValue("Number", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Month_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("MonthDeleted", e);
			Deleting += (s, e) => ThrowEvent("MonthDeleting", e);
			Inserted += (s, e) => ThrowEvent("MonthInserted", e);
			Inserting += (s, e) => ThrowEvent("MonthInserting", e);
			Saved += (s, e) => ThrowEvent("MonthSaved", e);
			Saving += (s, e) => ThrowEvent("MonthSaving", e);
			Validating += (s, e) => ThrowEvent("MonthValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new Month(this);
		}

		#endregion

	}

	#endregion

	#region Class: Month_BaseEventsProcess

	/// <exclude/>
	public partial class Month_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : Month
	{

		public Month_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Month_BaseEventsProcess";
			SchemaUId = new Guid("4c00fdb7-6950-46fb-be0e-fde9e48925d2");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("4c00fdb7-6950-46fb-be0e-fde9e48925d2");
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

	#region Class: Month_BaseEventsProcess

	/// <exclude/>
	public class Month_BaseEventsProcess : Month_BaseEventsProcess<Month>
	{

		public Month_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: Month_BaseEventsProcess

	public partial class Month_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: MonthEventsProcess

	/// <exclude/>
	public class MonthEventsProcess : Month_BaseEventsProcess
	{

		public MonthEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

