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

	#region Class: IntegrationResultSchema

	/// <exclude/>
	public class IntegrationResultSchema : BPMSoft.Configuration.BaseCodeLookupSchema
	{

		#region Constructors: Public

		public IntegrationResultSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public IntegrationResultSchema(IntegrationResultSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public IntegrationResultSchema(IntegrationResultSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("fb695ee6-670b-4dc7-9118-7df4ccf95ed7");
			RealUId = new Guid("fb695ee6-670b-4dc7-9118-7df4ccf95ed7");
			Name = "IntegrationResult";
			ParentSchemaUId = new Guid("2681062b-df59-4e52-89ed-f9b7dc909ab2");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("fb695ee6-670b-4dc7-9118-7df4ccf95ed7");
			column.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("fb695ee6-670b-4dc7-9118-7df4ccf95ed7");
			column.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			return column;
		}

		protected override EntitySchemaColumn CreateCodeColumn() {
			EntitySchemaColumn column = base.CreateCodeColumn();
			column.ModifiedInSchemaUId = new Guid("fb695ee6-670b-4dc7-9118-7df4ccf95ed7");
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
			return new IntegrationResult(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new IntegrationResult_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new IntegrationResultSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new IntegrationResultSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("fb695ee6-670b-4dc7-9118-7df4ccf95ed7"));
		}

		#endregion

	}

	#endregion

	#region Class: IntegrationResult

	/// <summary>
	/// Integration result.
	/// </summary>
	public class IntegrationResult : BPMSoft.Configuration.BaseCodeLookup
	{

		#region Constructors: Public

		public IntegrationResult(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "IntegrationResult";
		}

		public IntegrationResult(IntegrationResult source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new IntegrationResult_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("IntegrationResultDeleted", e);
			Inserting += (s, e) => ThrowEvent("IntegrationResultInserting", e);
			Validating += (s, e) => ThrowEvent("IntegrationResultValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new IntegrationResult(this);
		}

		#endregion

	}

	#endregion

	#region Class: IntegrationResult_BaseEventsProcess

	/// <exclude/>
	public partial class IntegrationResult_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseCodeLookup_BaseEventsProcess<TEntity> where TEntity : IntegrationResult
	{

		public IntegrationResult_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "IntegrationResult_BaseEventsProcess";
			SchemaUId = new Guid("fb695ee6-670b-4dc7-9118-7df4ccf95ed7");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("fb695ee6-670b-4dc7-9118-7df4ccf95ed7");
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

	#region Class: IntegrationResult_BaseEventsProcess

	/// <exclude/>
	public class IntegrationResult_BaseEventsProcess : IntegrationResult_BaseEventsProcess<IntegrationResult>
	{

		public IntegrationResult_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: IntegrationResult_BaseEventsProcess

	public partial class IntegrationResult_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: IntegrationResultEventsProcess

	/// <exclude/>
	public class IntegrationResultEventsProcess : IntegrationResult_BaseEventsProcess
	{

		public IntegrationResultEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

