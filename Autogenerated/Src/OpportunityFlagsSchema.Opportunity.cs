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

	#region Class: OpportunityFlagsSchema

	/// <exclude/>
	public class OpportunityFlagsSchema : BPMSoft.Configuration.BaseImageLookupSchema
	{

		#region Constructors: Public

		public OpportunityFlagsSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public OpportunityFlagsSchema(OpportunityFlagsSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public OpportunityFlagsSchema(OpportunityFlagsSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("2af0d41a-12ea-4b73-a5f4-da3fe7f9d0fd");
			RealUId = new Guid("2af0d41a-12ea-4b73-a5f4-da3fe7f9d0fd");
			Name = "OpportunityFlags";
			ParentSchemaUId = new Guid("b4a781bd-bacd-4ba1-a16b-48c09a21f087");
			ExtendParent = false;
			CreatedInPackageId = new Guid("5d4440f3-755f-4128-9701-bb9585b17c33");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("2af0d41a-12ea-4b73-a5f4-da3fe7f9d0fd");
			column.CreatedInPackageId = new Guid("5d4440f3-755f-4128-9701-bb9585b17c33");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("2af0d41a-12ea-4b73-a5f4-da3fe7f9d0fd");
			column.CreatedInPackageId = new Guid("5d4440f3-755f-4128-9701-bb9585b17c33");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("2af0d41a-12ea-4b73-a5f4-da3fe7f9d0fd");
			column.CreatedInPackageId = new Guid("5d4440f3-755f-4128-9701-bb9585b17c33");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("2af0d41a-12ea-4b73-a5f4-da3fe7f9d0fd");
			column.CreatedInPackageId = new Guid("5d4440f3-755f-4128-9701-bb9585b17c33");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("2af0d41a-12ea-4b73-a5f4-da3fe7f9d0fd");
			column.CreatedInPackageId = new Guid("5d4440f3-755f-4128-9701-bb9585b17c33");
			return column;
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("2af0d41a-12ea-4b73-a5f4-da3fe7f9d0fd");
			column.CreatedInPackageId = new Guid("5d4440f3-755f-4128-9701-bb9585b17c33");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("2af0d41a-12ea-4b73-a5f4-da3fe7f9d0fd");
			column.CreatedInPackageId = new Guid("5d4440f3-755f-4128-9701-bb9585b17c33");
			return column;
		}

		protected override EntitySchemaColumn CreateImageColumn() {
			EntitySchemaColumn column = base.CreateImageColumn();
			column.ModifiedInSchemaUId = new Guid("2af0d41a-12ea-4b73-a5f4-da3fe7f9d0fd");
			column.CreatedInPackageId = new Guid("5d4440f3-755f-4128-9701-bb9585b17c33");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("2af0d41a-12ea-4b73-a5f4-da3fe7f9d0fd");
			column.CreatedInPackageId = new Guid("5d4440f3-755f-4128-9701-bb9585b17c33");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new OpportunityFlags(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new OpportunityFlags_OpportunityEventsProcess(userConnection);
		}

		public override object Clone() {
			return new OpportunityFlagsSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new OpportunityFlagsSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("2af0d41a-12ea-4b73-a5f4-da3fe7f9d0fd"));
		}

		#endregion

	}

	#endregion

	#region Class: OpportunityFlags

	/// <summary>
	/// Флаги продажи.
	/// </summary>
	public class OpportunityFlags : BPMSoft.Configuration.BaseImageLookup
	{

		#region Constructors: Public

		public OpportunityFlags(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "OpportunityFlags";
		}

		public OpportunityFlags(OpportunityFlags source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new OpportunityFlags_OpportunityEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("OpportunityFlagsDeleted", e);
			Inserting += (s, e) => ThrowEvent("OpportunityFlagsInserting", e);
			Validating += (s, e) => ThrowEvent("OpportunityFlagsValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new OpportunityFlags(this);
		}

		#endregion

	}

	#endregion

	#region Class: OpportunityFlags_OpportunityEventsProcess

	/// <exclude/>
	public partial class OpportunityFlags_OpportunityEventsProcess<TEntity> : BPMSoft.Configuration.BaseImageLookup_BaseEventsProcess<TEntity> where TEntity : OpportunityFlags
	{

		public OpportunityFlags_OpportunityEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "OpportunityFlags_OpportunityEventsProcess";
			SchemaUId = new Guid("2af0d41a-12ea-4b73-a5f4-da3fe7f9d0fd");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("2af0d41a-12ea-4b73-a5f4-da3fe7f9d0fd");
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

	#region Class: OpportunityFlags_OpportunityEventsProcess

	/// <exclude/>
	public class OpportunityFlags_OpportunityEventsProcess : OpportunityFlags_OpportunityEventsProcess<OpportunityFlags>
	{

		public OpportunityFlags_OpportunityEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: OpportunityFlags_OpportunityEventsProcess

	public partial class OpportunityFlags_OpportunityEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: OpportunityFlagsEventsProcess

	/// <exclude/>
	public class OpportunityFlagsEventsProcess : OpportunityFlags_OpportunityEventsProcess
	{

		public OpportunityFlagsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

