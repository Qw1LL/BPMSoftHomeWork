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

	#region Class: SysGridPageSchema

	/// <exclude/>
	public class SysGridPageSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysGridPageSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysGridPageSchema(SysGridPageSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysGridPageSchema(SysGridPageSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("d19658bd-987d-4cd5-9006-0e9d6edc9104");
			RealUId = new Guid("d19658bd-987d-4cd5-9006-0e9d6edc9104");
			Name = "SysGridPage";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("16d28ad3-07f7-422e-9800-81b4c697e499")) == null) {
				Columns.Add(CreateSysPageSchemaColumn());
			}
			if (Columns.FindByUId(new Guid("d7f3729f-ed7e-4ef4-b05b-b599cc2889a7")) == null) {
				Columns.Add(CreateSysEntitySchemaColumn());
			}
			if (Columns.FindByUId(new Guid("d91ae947-7565-40fa-ac19-78f6f4d33760")) == null) {
				Columns.Add(CreateTypeColumnUIdColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateSysPageSchemaColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("16d28ad3-07f7-422e-9800-81b4c697e499"),
				Name = @"SysPageSchema",
				ReferenceSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				CreatedInSchemaUId = new Guid("d19658bd-987d-4cd5-9006-0e9d6edc9104"),
				ModifiedInSchemaUId = new Guid("d19658bd-987d-4cd5-9006-0e9d6edc9104"),
				CreatedInPackageId = new Guid("773ffacd-4a58-4934-8cb2-5bf23386d08f")
			};
		}

		protected virtual EntitySchemaColumn CreateSysEntitySchemaColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("d7f3729f-ed7e-4ef4-b05b-b599cc2889a7"),
				Name = @"SysEntitySchema",
				ReferenceSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				CreatedInSchemaUId = new Guid("d19658bd-987d-4cd5-9006-0e9d6edc9104"),
				ModifiedInSchemaUId = new Guid("d19658bd-987d-4cd5-9006-0e9d6edc9104"),
				CreatedInPackageId = new Guid("773ffacd-4a58-4934-8cb2-5bf23386d08f")
			};
		}

		protected virtual EntitySchemaColumn CreateTypeColumnUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("d91ae947-7565-40fa-ac19-78f6f4d33760"),
				Name = @"TypeColumnUId",
				CreatedInSchemaUId = new Guid("d19658bd-987d-4cd5-9006-0e9d6edc9104"),
				ModifiedInSchemaUId = new Guid("d19658bd-987d-4cd5-9006-0e9d6edc9104"),
				CreatedInPackageId = new Guid("773ffacd-4a58-4934-8cb2-5bf23386d08f")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysGridPage(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysGridPage_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysGridPageSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysGridPageSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("d19658bd-987d-4cd5-9006-0e9d6edc9104"));
		}

		#endregion

	}

	#endregion

	#region Class: SysGridPage

	/// <summary>
	/// List page.
	/// </summary>
	public class SysGridPage : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysGridPage(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysGridPage";
		}

		public SysGridPage(SysGridPage source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid SysPageSchemaId {
			get {
				return GetTypedColumnValue<Guid>("SysPageSchemaId");
			}
			set {
				SetColumnValue("SysPageSchemaId", value);
				_sysPageSchema = null;
			}
		}

		/// <exclude/>
		public string SysPageSchemaCaption {
			get {
				return GetTypedColumnValue<string>("SysPageSchemaCaption");
			}
			set {
				SetColumnValue("SysPageSchemaCaption", value);
				if (_sysPageSchema != null) {
					_sysPageSchema.Caption = value;
				}
			}
		}

		private SysSchema _sysPageSchema;
		/// <summary>
		/// Page.
		/// </summary>
		public SysSchema SysPageSchema {
			get {
				return _sysPageSchema ??
					(_sysPageSchema = LookupColumnEntities.GetEntity("SysPageSchema") as SysSchema);
			}
		}

		/// <exclude/>
		public Guid SysEntitySchemaId {
			get {
				return GetTypedColumnValue<Guid>("SysEntitySchemaId");
			}
			set {
				SetColumnValue("SysEntitySchemaId", value);
				_sysEntitySchema = null;
			}
		}

		/// <exclude/>
		public string SysEntitySchemaCaption {
			get {
				return GetTypedColumnValue<string>("SysEntitySchemaCaption");
			}
			set {
				SetColumnValue("SysEntitySchemaCaption", value);
				if (_sysEntitySchema != null) {
					_sysEntitySchema.Caption = value;
				}
			}
		}

		private SysSchema _sysEntitySchema;
		/// <summary>
		/// Object.
		/// </summary>
		public SysSchema SysEntitySchema {
			get {
				return _sysEntitySchema ??
					(_sysEntitySchema = LookupColumnEntities.GetEntity("SysEntitySchema") as SysSchema);
			}
		}

		/// <summary>
		/// Type column.
		/// </summary>
		public Guid TypeColumnUId {
			get {
				return GetTypedColumnValue<Guid>("TypeColumnUId");
			}
			set {
				SetColumnValue("TypeColumnUId", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysGridPage_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysGridPageDeleted", e);
			Deleting += (s, e) => ThrowEvent("SysGridPageDeleting", e);
			Inserted += (s, e) => ThrowEvent("SysGridPageInserted", e);
			Inserting += (s, e) => ThrowEvent("SysGridPageInserting", e);
			Saved += (s, e) => ThrowEvent("SysGridPageSaved", e);
			Saving += (s, e) => ThrowEvent("SysGridPageSaving", e);
			Validating += (s, e) => ThrowEvent("SysGridPageValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysGridPage(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysGridPage_BaseEventsProcess

	/// <exclude/>
	public partial class SysGridPage_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : SysGridPage
	{

		public SysGridPage_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysGridPage_BaseEventsProcess";
			SchemaUId = new Guid("d19658bd-987d-4cd5-9006-0e9d6edc9104");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("d19658bd-987d-4cd5-9006-0e9d6edc9104");
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

	#region Class: SysGridPage_BaseEventsProcess

	/// <exclude/>
	public class SysGridPage_BaseEventsProcess : SysGridPage_BaseEventsProcess<SysGridPage>
	{

		public SysGridPage_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysGridPage_BaseEventsProcess

	public partial class SysGridPage_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysGridPageEventsProcess

	/// <exclude/>
	public class SysGridPageEventsProcess : SysGridPage_BaseEventsProcess
	{

		public SysGridPageEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

