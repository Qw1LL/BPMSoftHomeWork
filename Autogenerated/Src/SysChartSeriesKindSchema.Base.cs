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

	#region Class: SysChartSeriesKindSchema

	/// <exclude/>
	public class SysChartSeriesKindSchema : BPMSoft.Configuration.BaseCodeImageLookupSchema
	{

		#region Constructors: Public

		public SysChartSeriesKindSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysChartSeriesKindSchema(SysChartSeriesKindSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysChartSeriesKindSchema(SysChartSeriesKindSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("a849b7de-affd-4b8f-8fce-7ab875ec42cd");
			RealUId = new Guid("a849b7de-affd-4b8f-8fce-7ab875ec42cd");
			Name = "SysChartSeriesKind";
			ParentSchemaUId = new Guid("c21771d2-01fa-4646-96b0-e4b69e582b44");
			ExtendParent = false;
			CreatedInPackageId = new Guid("c5d1282b-7a3f-4441-aec0-d272080d37f8");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryImageColumn() {
			base.InitializePrimaryImageColumn();
			PrimaryImageColumn = CreateImageColumn();
			if (Columns.FindByUId(PrimaryImageColumn.UId) == null) {
				Columns.Add(PrimaryImageColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("a849b7de-affd-4b8f-8fce-7ab875ec42cd");
			column.CreatedInPackageId = new Guid("c5d1282b-7a3f-4441-aec0-d272080d37f8");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("a849b7de-affd-4b8f-8fce-7ab875ec42cd");
			column.CreatedInPackageId = new Guid("c5d1282b-7a3f-4441-aec0-d272080d37f8");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("a849b7de-affd-4b8f-8fce-7ab875ec42cd");
			column.CreatedInPackageId = new Guid("c5d1282b-7a3f-4441-aec0-d272080d37f8");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("a849b7de-affd-4b8f-8fce-7ab875ec42cd");
			column.CreatedInPackageId = new Guid("c5d1282b-7a3f-4441-aec0-d272080d37f8");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("a849b7de-affd-4b8f-8fce-7ab875ec42cd");
			column.CreatedInPackageId = new Guid("c5d1282b-7a3f-4441-aec0-d272080d37f8");
			return column;
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("a849b7de-affd-4b8f-8fce-7ab875ec42cd");
			column.CreatedInPackageId = new Guid("c5d1282b-7a3f-4441-aec0-d272080d37f8");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("a849b7de-affd-4b8f-8fce-7ab875ec42cd");
			column.CreatedInPackageId = new Guid("c5d1282b-7a3f-4441-aec0-d272080d37f8");
			return column;
		}

		protected override EntitySchemaColumn CreateCodeColumn() {
			EntitySchemaColumn column = base.CreateCodeColumn();
			column.ModifiedInSchemaUId = new Guid("a849b7de-affd-4b8f-8fce-7ab875ec42cd");
			column.CreatedInPackageId = new Guid("c5d1282b-7a3f-4441-aec0-d272080d37f8");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("a849b7de-affd-4b8f-8fce-7ab875ec42cd");
			column.CreatedInPackageId = new Guid("c5d1282b-7a3f-4441-aec0-d272080d37f8");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysChartSeriesKind(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysChartSeriesKind_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysChartSeriesKindSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysChartSeriesKindSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("a849b7de-affd-4b8f-8fce-7ab875ec42cd"));
		}

		#endregion

	}

	#endregion

	#region Class: SysChartSeriesKind

	/// <summary>
	/// Chart diagram type.
	/// </summary>
	public class SysChartSeriesKind : BPMSoft.Configuration.BaseCodeImageLookup
	{

		#region Constructors: Public

		public SysChartSeriesKind(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysChartSeriesKind";
		}

		public SysChartSeriesKind(SysChartSeriesKind source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysChartSeriesKind_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysChartSeriesKindDeleted", e);
			Inserting += (s, e) => ThrowEvent("SysChartSeriesKindInserting", e);
			Validating += (s, e) => ThrowEvent("SysChartSeriesKindValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysChartSeriesKind(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysChartSeriesKind_BaseEventsProcess

	/// <exclude/>
	public partial class SysChartSeriesKind_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseCodeImageLookup_BaseEventsProcess<TEntity> where TEntity : SysChartSeriesKind
	{

		public SysChartSeriesKind_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysChartSeriesKind_BaseEventsProcess";
			SchemaUId = new Guid("a849b7de-affd-4b8f-8fce-7ab875ec42cd");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("a849b7de-affd-4b8f-8fce-7ab875ec42cd");
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

	#region Class: SysChartSeriesKind_BaseEventsProcess

	/// <exclude/>
	public class SysChartSeriesKind_BaseEventsProcess : SysChartSeriesKind_BaseEventsProcess<SysChartSeriesKind>
	{

		public SysChartSeriesKind_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysChartSeriesKind_BaseEventsProcess

	public partial class SysChartSeriesKind_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysChartSeriesKindEventsProcess

	/// <exclude/>
	public class SysChartSeriesKindEventsProcess : SysChartSeriesKind_BaseEventsProcess
	{

		public SysChartSeriesKindEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

