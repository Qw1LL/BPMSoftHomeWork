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

	#region Class: IntegrationDirectionSchema

	/// <exclude/>
	public class IntegrationDirectionSchema : BPMSoft.Configuration.BaseCodeLookupSchema
	{

		#region Constructors: Public

		public IntegrationDirectionSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public IntegrationDirectionSchema(IntegrationDirectionSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public IntegrationDirectionSchema(IntegrationDirectionSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("0ad85e2e-9a97-41f2-9fe5-7e6b8af16844");
			RealUId = new Guid("0ad85e2e-9a97-41f2-9fe5-7e6b8af16844");
			Name = "IntegrationDirection";
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
			column.ModifiedInSchemaUId = new Guid("0ad85e2e-9a97-41f2-9fe5-7e6b8af16844");
			column.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("0ad85e2e-9a97-41f2-9fe5-7e6b8af16844");
			column.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			return column;
		}

		protected override EntitySchemaColumn CreateCodeColumn() {
			EntitySchemaColumn column = base.CreateCodeColumn();
			column.ModifiedInSchemaUId = new Guid("0ad85e2e-9a97-41f2-9fe5-7e6b8af16844");
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
			return new IntegrationDirection(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new IntegrationDirection_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new IntegrationDirectionSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new IntegrationDirectionSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("0ad85e2e-9a97-41f2-9fe5-7e6b8af16844"));
		}

		#endregion

	}

	#endregion

	#region Class: IntegrationDirection

	/// <summary>
	/// Integration direction.
	/// </summary>
	public class IntegrationDirection : BPMSoft.Configuration.BaseCodeLookup
	{

		#region Constructors: Public

		public IntegrationDirection(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "IntegrationDirection";
		}

		public IntegrationDirection(IntegrationDirection source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new IntegrationDirection_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("IntegrationDirectionDeleted", e);
			Inserting += (s, e) => ThrowEvent("IntegrationDirectionInserting", e);
			Validating += (s, e) => ThrowEvent("IntegrationDirectionValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new IntegrationDirection(this);
		}

		#endregion

	}

	#endregion

	#region Class: IntegrationDirection_BaseEventsProcess

	/// <exclude/>
	public partial class IntegrationDirection_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseCodeLookup_BaseEventsProcess<TEntity> where TEntity : IntegrationDirection
	{

		public IntegrationDirection_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "IntegrationDirection_BaseEventsProcess";
			SchemaUId = new Guid("0ad85e2e-9a97-41f2-9fe5-7e6b8af16844");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("0ad85e2e-9a97-41f2-9fe5-7e6b8af16844");
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

	#region Class: IntegrationDirection_BaseEventsProcess

	/// <exclude/>
	public class IntegrationDirection_BaseEventsProcess : IntegrationDirection_BaseEventsProcess<IntegrationDirection>
	{

		public IntegrationDirection_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: IntegrationDirection_BaseEventsProcess

	public partial class IntegrationDirection_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: IntegrationDirectionEventsProcess

	/// <exclude/>
	public class IntegrationDirectionEventsProcess : IntegrationDirection_BaseEventsProcess
	{

		public IntegrationDirectionEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

