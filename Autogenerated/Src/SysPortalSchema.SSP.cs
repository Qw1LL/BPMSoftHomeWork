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

	#region Class: SysPortalSchema

	/// <exclude/>
	public class SysPortalSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysPortalSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysPortalSchema(SysPortalSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysPortalSchema(SysPortalSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("ebe236ab-e6c0-4155-981e-59a2c6800c8c");
			RealUId = new Guid("ebe236ab-e6c0-4155-981e-59a2c6800c8c");
			Name = "SysPortal";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("fc741efe-5ee7-42c9-8935-9d298f1913b5");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateNameColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("ebe236ab-e6c0-4155-981e-59a2c6800c8c");
			column.CreatedInPackageId = new Guid("fc741efe-5ee7-42c9-8935-9d298f1913b5");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("ebe236ab-e6c0-4155-981e-59a2c6800c8c");
			column.CreatedInPackageId = new Guid("fc741efe-5ee7-42c9-8935-9d298f1913b5");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("ebe236ab-e6c0-4155-981e-59a2c6800c8c");
			column.CreatedInPackageId = new Guid("fc741efe-5ee7-42c9-8935-9d298f1913b5");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("ebe236ab-e6c0-4155-981e-59a2c6800c8c");
			column.CreatedInPackageId = new Guid("fc741efe-5ee7-42c9-8935-9d298f1913b5");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("ebe236ab-e6c0-4155-981e-59a2c6800c8c");
			column.CreatedInPackageId = new Guid("fc741efe-5ee7-42c9-8935-9d298f1913b5");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("ebe236ab-e6c0-4155-981e-59a2c6800c8c");
			column.CreatedInPackageId = new Guid("fc741efe-5ee7-42c9-8935-9d298f1913b5");
			return column;
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("3ed83510-e90b-4113-8b62-ad7ddb9e8b85"),
				Name = @"Name",
				CreatedInSchemaUId = new Guid("ebe236ab-e6c0-4155-981e-59a2c6800c8c"),
				ModifiedInSchemaUId = new Guid("ebe236ab-e6c0-4155-981e-59a2c6800c8c"),
				CreatedInPackageId = new Guid("fc741efe-5ee7-42c9-8935-9d298f1913b5")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysPortal(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysPortal_SSPEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysPortalSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysPortalSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ebe236ab-e6c0-4155-981e-59a2c6800c8c"));
		}

		#endregion

	}

	#endregion

	#region Class: SysPortal

	/// <summary>
	/// Portal.
	/// </summary>
	public class SysPortal : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysPortal(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysPortal";
		}

		public SysPortal(SysPortal source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Name.
		/// </summary>
		public string Name {
			get {
				return GetTypedColumnValue<string>("Name");
			}
			set {
				SetColumnValue("Name", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysPortal_SSPEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysPortalDeleted", e);
			Validating += (s, e) => ThrowEvent("SysPortalValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysPortal(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysPortal_SSPEventsProcess

	/// <exclude/>
	public partial class SysPortal_SSPEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : SysPortal
	{

		public SysPortal_SSPEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysPortal_SSPEventsProcess";
			SchemaUId = new Guid("ebe236ab-e6c0-4155-981e-59a2c6800c8c");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("ebe236ab-e6c0-4155-981e-59a2c6800c8c");
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

	#region Class: SysPortal_SSPEventsProcess

	/// <exclude/>
	public class SysPortal_SSPEventsProcess : SysPortal_SSPEventsProcess<SysPortal>
	{

		public SysPortal_SSPEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysPortal_SSPEventsProcess

	public partial class SysPortal_SSPEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysPortalEventsProcess

	/// <exclude/>
	public class SysPortalEventsProcess : SysPortal_SSPEventsProcess
	{

		public SysPortalEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

