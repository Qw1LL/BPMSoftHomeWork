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

	#region Class: DuplicatesReferenceSchema

	/// <exclude/>
	public class DuplicatesReferenceSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public DuplicatesReferenceSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public DuplicatesReferenceSchema(DuplicatesReferenceSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public DuplicatesReferenceSchema(DuplicatesReferenceSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("f408bfb2-1d02-427a-b13e-c98248d23983");
			RealUId = new Guid("f408bfb2-1d02-427a-b13e-c98248d23983");
			Name = "DuplicatesReference";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("3a9b3622-1aee-4236-a76a-37f568d4d4b8");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("46750261-7ebc-43f3-99fe-60e4e55781f7")) == null) {
				Columns.Add(CreateObjectNameColumn());
			}
			if (Columns.FindByUId(new Guid("e04a931a-93d2-422f-9501-8dec37de14c5")) == null) {
				Columns.Add(CreateTableNameColumn());
			}
			if (Columns.FindByUId(new Guid("f2d78916-f6ec-4832-9d7f-b33191fa533a")) == null) {
				Columns.Add(CreateColumnNameColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateObjectNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("46750261-7ebc-43f3-99fe-60e4e55781f7"),
				Name = @"ObjectName",
				CreatedInSchemaUId = new Guid("f408bfb2-1d02-427a-b13e-c98248d23983"),
				ModifiedInSchemaUId = new Guid("f408bfb2-1d02-427a-b13e-c98248d23983"),
				CreatedInPackageId = new Guid("3a9b3622-1aee-4236-a76a-37f568d4d4b8")
			};
		}

		protected virtual EntitySchemaColumn CreateTableNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("e04a931a-93d2-422f-9501-8dec37de14c5"),
				Name = @"TableName",
				CreatedInSchemaUId = new Guid("f408bfb2-1d02-427a-b13e-c98248d23983"),
				ModifiedInSchemaUId = new Guid("f408bfb2-1d02-427a-b13e-c98248d23983"),
				CreatedInPackageId = new Guid("3a9b3622-1aee-4236-a76a-37f568d4d4b8")
			};
		}

		protected virtual EntitySchemaColumn CreateColumnNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("f2d78916-f6ec-4832-9d7f-b33191fa533a"),
				Name = @"ColumnName",
				CreatedInSchemaUId = new Guid("f408bfb2-1d02-427a-b13e-c98248d23983"),
				ModifiedInSchemaUId = new Guid("f408bfb2-1d02-427a-b13e-c98248d23983"),
				CreatedInPackageId = new Guid("3a9b3622-1aee-4236-a76a-37f568d4d4b8")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new DuplicatesReference(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new DuplicatesReference_DeduplicationEventsProcess(userConnection);
		}

		public override object Clone() {
			return new DuplicatesReferenceSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new DuplicatesReferenceSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("f408bfb2-1d02-427a-b13e-c98248d23983"));
		}

		#endregion

	}

	#endregion

	#region Class: DuplicatesReference

	/// <summary>
	/// Duplicates reference.
	/// </summary>
	public class DuplicatesReference : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public DuplicatesReference(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "DuplicatesReference";
		}

		public DuplicatesReference(DuplicatesReference source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Object name.
		/// </summary>
		public string ObjectName {
			get {
				return GetTypedColumnValue<string>("ObjectName");
			}
			set {
				SetColumnValue("ObjectName", value);
			}
		}

		/// <summary>
		/// Table name.
		/// </summary>
		public string TableName {
			get {
				return GetTypedColumnValue<string>("TableName");
			}
			set {
				SetColumnValue("TableName", value);
			}
		}

		/// <summary>
		/// Column name.
		/// </summary>
		public string ColumnName {
			get {
				return GetTypedColumnValue<string>("ColumnName");
			}
			set {
				SetColumnValue("ColumnName", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new DuplicatesReference_DeduplicationEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("DuplicatesReferenceDeleted", e);
			Validating += (s, e) => ThrowEvent("DuplicatesReferenceValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new DuplicatesReference(this);
		}

		#endregion

	}

	#endregion

	#region Class: DuplicatesReference_DeduplicationEventsProcess

	/// <exclude/>
	public partial class DuplicatesReference_DeduplicationEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : DuplicatesReference
	{

		public DuplicatesReference_DeduplicationEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "DuplicatesReference_DeduplicationEventsProcess";
			SchemaUId = new Guid("f408bfb2-1d02-427a-b13e-c98248d23983");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("f408bfb2-1d02-427a-b13e-c98248d23983");
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

	#region Class: DuplicatesReference_DeduplicationEventsProcess

	/// <exclude/>
	public class DuplicatesReference_DeduplicationEventsProcess : DuplicatesReference_DeduplicationEventsProcess<DuplicatesReference>
	{

		public DuplicatesReference_DeduplicationEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: DuplicatesReference_DeduplicationEventsProcess

	public partial class DuplicatesReference_DeduplicationEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: DuplicatesReferenceEventsProcess

	/// <exclude/>
	public class DuplicatesReferenceEventsProcess : DuplicatesReference_DeduplicationEventsProcess
	{

		public DuplicatesReferenceEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

