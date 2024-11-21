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

	#region Class: SysEditPageSchema

	/// <exclude/>
	public class SysEditPageSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysEditPageSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysEditPageSchema(SysEditPageSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysEditPageSchema(SysEditPageSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("1eee8a5d-b51c-4a52-8143-a7f2d2df2747");
			RealUId = new Guid("1eee8a5d-b51c-4a52-8143-a7f2d2df2747");
			Name = "SysEditPage";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("680349ce-f390-4cf7-8ed2-4684d1ec37b8")) == null) {
				Columns.Add(CreateSysPageSchemaColumn());
			}
			if (Columns.FindByUId(new Guid("9f14ceb3-2455-47a4-951c-e7ace5f508ca")) == null) {
				Columns.Add(CreateSysGridPageColumn());
			}
			if (Columns.FindByUId(new Guid("ff1603fa-811e-49ae-9ce7-bf86b7ee18b5")) == null) {
				Columns.Add(CreateSysEntitySchemaColumn());
			}
			if (Columns.FindByUId(new Guid("7781829d-4468-4a88-8a06-5570c5e892a8")) == null) {
				Columns.Add(CreateTypeColumnValueColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateSysPageSchemaColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("680349ce-f390-4cf7-8ed2-4684d1ec37b8"),
				Name = @"SysPageSchema",
				ReferenceSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				CreatedInSchemaUId = new Guid("1eee8a5d-b51c-4a52-8143-a7f2d2df2747"),
				ModifiedInSchemaUId = new Guid("1eee8a5d-b51c-4a52-8143-a7f2d2df2747"),
				CreatedInPackageId = new Guid("c692daa9-de5e-4e96-afd3-e992ed86681c")
			};
		}

		protected virtual EntitySchemaColumn CreateSysGridPageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("9f14ceb3-2455-47a4-951c-e7ace5f508ca"),
				Name = @"SysGridPage",
				ReferenceSchemaUId = new Guid("d19658bd-987d-4cd5-9006-0e9d6edc9104"),
				CreatedInSchemaUId = new Guid("1eee8a5d-b51c-4a52-8143-a7f2d2df2747"),
				ModifiedInSchemaUId = new Guid("1eee8a5d-b51c-4a52-8143-a7f2d2df2747"),
				CreatedInPackageId = new Guid("c692daa9-de5e-4e96-afd3-e992ed86681c")
			};
		}

		protected virtual EntitySchemaColumn CreateSysEntitySchemaColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("ff1603fa-811e-49ae-9ce7-bf86b7ee18b5"),
				Name = @"SysEntitySchema",
				ReferenceSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				CreatedInSchemaUId = new Guid("1eee8a5d-b51c-4a52-8143-a7f2d2df2747"),
				ModifiedInSchemaUId = new Guid("1eee8a5d-b51c-4a52-8143-a7f2d2df2747"),
				CreatedInPackageId = new Guid("c692daa9-de5e-4e96-afd3-e992ed86681c")
			};
		}

		protected virtual EntitySchemaColumn CreateTypeColumnValueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("7781829d-4468-4a88-8a06-5570c5e892a8"),
				Name = @"TypeColumnValue",
				CreatedInSchemaUId = new Guid("1eee8a5d-b51c-4a52-8143-a7f2d2df2747"),
				ModifiedInSchemaUId = new Guid("1eee8a5d-b51c-4a52-8143-a7f2d2df2747"),
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
			return new SysEditPage(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysEditPage_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysEditPageSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysEditPageSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("1eee8a5d-b51c-4a52-8143-a7f2d2df2747"));
		}

		#endregion

	}

	#endregion

	#region Class: SysEditPage

	/// <summary>
	/// Edit page.
	/// </summary>
	public class SysEditPage : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysEditPage(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysEditPage";
		}

		public SysEditPage(SysEditPage source)
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
		public Guid SysGridPageId {
			get {
				return GetTypedColumnValue<Guid>("SysGridPageId");
			}
			set {
				SetColumnValue("SysGridPageId", value);
				_sysGridPage = null;
			}
		}

		private SysGridPage _sysGridPage;
		/// <summary>
		/// List page.
		/// </summary>
		public SysGridPage SysGridPage {
			get {
				return _sysGridPage ??
					(_sysGridPage = LookupColumnEntities.GetEntity("SysGridPage") as SysGridPage);
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
		/// Type.
		/// </summary>
		public Guid TypeColumnValue {
			get {
				return GetTypedColumnValue<Guid>("TypeColumnValue");
			}
			set {
				SetColumnValue("TypeColumnValue", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysEditPage_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysEditPageDeleted", e);
			Deleting += (s, e) => ThrowEvent("SysEditPageDeleting", e);
			Inserted += (s, e) => ThrowEvent("SysEditPageInserted", e);
			Inserting += (s, e) => ThrowEvent("SysEditPageInserting", e);
			Saved += (s, e) => ThrowEvent("SysEditPageSaved", e);
			Saving += (s, e) => ThrowEvent("SysEditPageSaving", e);
			Validating += (s, e) => ThrowEvent("SysEditPageValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysEditPage(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysEditPage_BaseEventsProcess

	/// <exclude/>
	public partial class SysEditPage_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : SysEditPage
	{

		public SysEditPage_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysEditPage_BaseEventsProcess";
			SchemaUId = new Guid("1eee8a5d-b51c-4a52-8143-a7f2d2df2747");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("1eee8a5d-b51c-4a52-8143-a7f2d2df2747");
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

	#region Class: SysEditPage_BaseEventsProcess

	/// <exclude/>
	public class SysEditPage_BaseEventsProcess : SysEditPage_BaseEventsProcess<SysEditPage>
	{

		public SysEditPage_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysEditPage_BaseEventsProcess

	public partial class SysEditPage_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysEditPageEventsProcess

	/// <exclude/>
	public class SysEditPageEventsProcess : SysEditPage_BaseEventsProcess
	{

		public SysEditPageEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

