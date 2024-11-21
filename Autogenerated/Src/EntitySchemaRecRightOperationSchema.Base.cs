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

	#region Class: EntitySchemaRecRightOperationSchema

	/// <exclude/>
	public class EntitySchemaRecRightOperationSchema : BPMSoft.Configuration.BaseValueLookupSchema
	{

		#region Constructors: Public

		public EntitySchemaRecRightOperationSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public EntitySchemaRecRightOperationSchema(EntitySchemaRecRightOperationSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public EntitySchemaRecRightOperationSchema(EntitySchemaRecRightOperationSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("01618739-cd25-41bf-9cda-86594ea9f512");
			RealUId = new Guid("01618739-cd25-41bf-9cda-86594ea9f512");
			Name = "EntitySchemaRecRightOperation";
			ParentSchemaUId = new Guid("04f67f0c-0a27-4616-987e-60e378854b0f");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
			DesignLocalizationSchemaName = @"SysEntitySchRecRightOprLcz";
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("01618739-cd25-41bf-9cda-86594ea9f512");
			column.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("01618739-cd25-41bf-9cda-86594ea9f512");
			column.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			return column;
		}

		protected override EntitySchemaColumn CreateValueColumn() {
			EntitySchemaColumn column = base.CreateValueColumn();
			column.ModifiedInSchemaUId = new Guid("01618739-cd25-41bf-9cda-86594ea9f512");
			column.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new EntitySchemaRecRightOperation(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new EntitySchemaRecRightOperation_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new EntitySchemaRecRightOperationSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new EntitySchemaRecRightOperationSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("01618739-cd25-41bf-9cda-86594ea9f512"));
		}

		#endregion

	}

	#endregion

	#region Class: EntitySchemaRecRightOperation

	/// <summary>
	/// Operation for Access to Record in Object.
	/// </summary>
	public class EntitySchemaRecRightOperation : BPMSoft.Configuration.BaseValueLookup
	{

		#region Constructors: Public

		public EntitySchemaRecRightOperation(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "EntitySchemaRecRightOperation";
		}

		public EntitySchemaRecRightOperation(EntitySchemaRecRightOperation source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new EntitySchemaRecRightOperation_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("EntitySchemaRecRightOperationDeleted", e);
			Deleting += (s, e) => ThrowEvent("EntitySchemaRecRightOperationDeleting", e);
			Inserted += (s, e) => ThrowEvent("EntitySchemaRecRightOperationInserted", e);
			Inserting += (s, e) => ThrowEvent("EntitySchemaRecRightOperationInserting", e);
			Saved += (s, e) => ThrowEvent("EntitySchemaRecRightOperationSaved", e);
			Saving += (s, e) => ThrowEvent("EntitySchemaRecRightOperationSaving", e);
			Validating += (s, e) => ThrowEvent("EntitySchemaRecRightOperationValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new EntitySchemaRecRightOperation(this);
		}

		#endregion

	}

	#endregion

	#region Class: EntitySchemaRecRightOperation_BaseEventsProcess

	/// <exclude/>
	public partial class EntitySchemaRecRightOperation_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseValueLookup_BaseEventsProcess<TEntity> where TEntity : EntitySchemaRecRightOperation
	{

		public EntitySchemaRecRightOperation_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "EntitySchemaRecRightOperation_BaseEventsProcess";
			SchemaUId = new Guid("01618739-cd25-41bf-9cda-86594ea9f512");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("01618739-cd25-41bf-9cda-86594ea9f512");
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

	#region Class: EntitySchemaRecRightOperation_BaseEventsProcess

	/// <exclude/>
	public class EntitySchemaRecRightOperation_BaseEventsProcess : EntitySchemaRecRightOperation_BaseEventsProcess<EntitySchemaRecRightOperation>
	{

		public EntitySchemaRecRightOperation_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: EntitySchemaRecRightOperation_BaseEventsProcess

	public partial class EntitySchemaRecRightOperation_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: EntitySchemaRecRightOperationEventsProcess

	/// <exclude/>
	public class EntitySchemaRecRightOperationEventsProcess : EntitySchemaRecRightOperation_BaseEventsProcess
	{

		public EntitySchemaRecRightOperationEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

