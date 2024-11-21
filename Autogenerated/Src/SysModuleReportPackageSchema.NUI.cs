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

	#region Class: SysModuleReportPackageSchema

	/// <exclude/>
	public class SysModuleReportPackageSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public SysModuleReportPackageSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysModuleReportPackageSchema(SysModuleReportPackageSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysModuleReportPackageSchema(SysModuleReportPackageSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("78d5e8c7-9fff-4dce-bac0-491eafab82f6");
			RealUId = new Guid("78d5e8c7-9fff-4dce-bac0-491eafab82f6");
			Name = "SysModuleReportPackage";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("14a29563-3c13-443c-a7aa-8d0c90d831c2");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("78d5e8c7-9fff-4dce-bac0-491eafab82f6");
			column.CreatedInPackageId = new Guid("14a29563-3c13-443c-a7aa-8d0c90d831c2");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("78d5e8c7-9fff-4dce-bac0-491eafab82f6");
			column.CreatedInPackageId = new Guid("14a29563-3c13-443c-a7aa-8d0c90d831c2");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("78d5e8c7-9fff-4dce-bac0-491eafab82f6");
			column.CreatedInPackageId = new Guid("14a29563-3c13-443c-a7aa-8d0c90d831c2");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("78d5e8c7-9fff-4dce-bac0-491eafab82f6");
			column.CreatedInPackageId = new Guid("14a29563-3c13-443c-a7aa-8d0c90d831c2");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("78d5e8c7-9fff-4dce-bac0-491eafab82f6");
			column.CreatedInPackageId = new Guid("14a29563-3c13-443c-a7aa-8d0c90d831c2");
			return column;
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("78d5e8c7-9fff-4dce-bac0-491eafab82f6");
			column.CreatedInPackageId = new Guid("14a29563-3c13-443c-a7aa-8d0c90d831c2");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("78d5e8c7-9fff-4dce-bac0-491eafab82f6");
			column.CreatedInPackageId = new Guid("14a29563-3c13-443c-a7aa-8d0c90d831c2");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("78d5e8c7-9fff-4dce-bac0-491eafab82f6");
			column.CreatedInPackageId = new Guid("14a29563-3c13-443c-a7aa-8d0c90d831c2");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysModuleReportPackage(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysModuleReportPackage_NUIEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysModuleReportPackageSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysModuleReportPackageSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("78d5e8c7-9fff-4dce-bac0-491eafab82f6"));
		}

		#endregion

	}

	#endregion

	#region Class: SysModuleReportPackage

	/// <summary>
	/// Package of section printables.
	/// </summary>
	public class SysModuleReportPackage : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public SysModuleReportPackage(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysModuleReportPackage";
		}

		public SysModuleReportPackage(SysModuleReportPackage source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysModuleReportPackage_NUIEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysModuleReportPackageDeleted", e);
			Inserting += (s, e) => ThrowEvent("SysModuleReportPackageInserting", e);
			Validating += (s, e) => ThrowEvent("SysModuleReportPackageValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysModuleReportPackage(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysModuleReportPackage_NUIEventsProcess

	/// <exclude/>
	public partial class SysModuleReportPackage_NUIEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : SysModuleReportPackage
	{

		public SysModuleReportPackage_NUIEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysModuleReportPackage_NUIEventsProcess";
			SchemaUId = new Guid("78d5e8c7-9fff-4dce-bac0-491eafab82f6");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("78d5e8c7-9fff-4dce-bac0-491eafab82f6");
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

	#region Class: SysModuleReportPackage_NUIEventsProcess

	/// <exclude/>
	public class SysModuleReportPackage_NUIEventsProcess : SysModuleReportPackage_NUIEventsProcess<SysModuleReportPackage>
	{

		public SysModuleReportPackage_NUIEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysModuleReportPackage_NUIEventsProcess

	public partial class SysModuleReportPackage_NUIEventsProcess<TEntity>
	{

		#region Methods: Public

		public override void CheckCanManageLookups() {
		}

		#endregion

	}

	#endregion


	#region Class: SysModuleReportPackageEventsProcess

	/// <exclude/>
	public class SysModuleReportPackageEventsProcess : SysModuleReportPackage_NUIEventsProcess
	{

		public SysModuleReportPackageEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

