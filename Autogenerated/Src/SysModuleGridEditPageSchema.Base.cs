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

	#region Class: SysModuleGridEditPageSchema

	/// <exclude/>
	public class SysModuleGridEditPageSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysModuleGridEditPageSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysModuleGridEditPageSchema(SysModuleGridEditPageSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysModuleGridEditPageSchema(SysModuleGridEditPageSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("14b308a7-fd06-49c8-a7dc-d6300477874a");
			RealUId = new Guid("14b308a7-fd06-49c8-a7dc-d6300477874a");
			Name = "SysModuleGridEditPage";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("fed5dba8-1311-4de4-be36-10dd1616a919")) == null) {
				Columns.Add(CreateTypeColumnValueColumn());
			}
			if (Columns.FindByUId(new Guid("eb588a60-8cd4-4e88-88d5-4b799e86a1f6")) == null) {
				Columns.Add(CreateSysModuleGridPageColumn());
			}
			if (Columns.FindByUId(new Guid("9ddd4796-d296-40af-b819-890e1a6dc123")) == null) {
				Columns.Add(CreateSysEditPageSchemaColumn());
			}
			if (Columns.FindByUId(new Guid("10e8f119-30cc-47eb-b50f-a8576b8a847d")) == null) {
				Columns.Add(CreateSysModuleGridPageUIdColumn());
			}
			if (Columns.FindByUId(new Guid("bde84b42-4c78-4b87-bdde-09e8b4f5051d")) == null) {
				Columns.Add(CreateSysEditPageSchemaUIdColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateTypeColumnValueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("fed5dba8-1311-4de4-be36-10dd1616a919"),
				Name = @"TypeColumnValue",
				CreatedInSchemaUId = new Guid("14b308a7-fd06-49c8-a7dc-d6300477874a"),
				ModifiedInSchemaUId = new Guid("14b308a7-fd06-49c8-a7dc-d6300477874a"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateSysModuleGridPageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("eb588a60-8cd4-4e88-88d5-4b799e86a1f6"),
				Name = @"SysModuleGridPage",
				ReferenceSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				CreatedInSchemaUId = new Guid("14b308a7-fd06-49c8-a7dc-d6300477874a"),
				ModifiedInSchemaUId = new Guid("14b308a7-fd06-49c8-a7dc-d6300477874a"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateSysEditPageSchemaColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("9ddd4796-d296-40af-b819-890e1a6dc123"),
				Name = @"SysEditPageSchema",
				ReferenceSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				CreatedInSchemaUId = new Guid("14b308a7-fd06-49c8-a7dc-d6300477874a"),
				ModifiedInSchemaUId = new Guid("14b308a7-fd06-49c8-a7dc-d6300477874a"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateSysModuleGridPageUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("10e8f119-30cc-47eb-b50f-a8576b8a847d"),
				Name = @"SysModuleGridPageUId",
				CreatedInSchemaUId = new Guid("14b308a7-fd06-49c8-a7dc-d6300477874a"),
				ModifiedInSchemaUId = new Guid("14b308a7-fd06-49c8-a7dc-d6300477874a"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateSysEditPageSchemaUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("bde84b42-4c78-4b87-bdde-09e8b4f5051d"),
				Name = @"SysEditPageSchemaUId",
				CreatedInSchemaUId = new Guid("14b308a7-fd06-49c8-a7dc-d6300477874a"),
				ModifiedInSchemaUId = new Guid("14b308a7-fd06-49c8-a7dc-d6300477874a"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysModuleGridEditPage(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysModuleGridEditPage_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysModuleGridEditPageSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysModuleGridEditPageSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("14b308a7-fd06-49c8-a7dc-d6300477874a"));
		}

		#endregion

	}

	#endregion

	#region Class: SysModuleGridEditPage

	/// <summary>
	/// Section editing.
	/// </summary>
	public class SysModuleGridEditPage : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysModuleGridEditPage(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysModuleGridEditPage";
		}

		public SysModuleGridEditPage(SysModuleGridEditPage source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Type value.
		/// </summary>
		public Guid TypeColumnValue {
			get {
				return GetTypedColumnValue<Guid>("TypeColumnValue");
			}
			set {
				SetColumnValue("TypeColumnValue", value);
			}
		}

		/// <exclude/>
		public Guid SysModuleGridPageId {
			get {
				return GetTypedColumnValue<Guid>("SysModuleGridPageId");
			}
			set {
				SetColumnValue("SysModuleGridPageId", value);
				_sysModuleGridPage = null;
			}
		}

		/// <exclude/>
		public string SysModuleGridPageCaption {
			get {
				return GetTypedColumnValue<string>("SysModuleGridPageCaption");
			}
			set {
				SetColumnValue("SysModuleGridPageCaption", value);
				if (_sysModuleGridPage != null) {
					_sysModuleGridPage.Caption = value;
				}
			}
		}

		private SysSchema _sysModuleGridPage;
		/// <summary>
		/// Section list.
		/// </summary>
		public SysSchema SysModuleGridPage {
			get {
				return _sysModuleGridPage ??
					(_sysModuleGridPage = LookupColumnEntities.GetEntity("SysModuleGridPage") as SysSchema);
			}
		}

		/// <exclude/>
		public Guid SysEditPageSchemaId {
			get {
				return GetTypedColumnValue<Guid>("SysEditPageSchemaId");
			}
			set {
				SetColumnValue("SysEditPageSchemaId", value);
				_sysEditPageSchema = null;
			}
		}

		/// <exclude/>
		public string SysEditPageSchemaCaption {
			get {
				return GetTypedColumnValue<string>("SysEditPageSchemaCaption");
			}
			set {
				SetColumnValue("SysEditPageSchemaCaption", value);
				if (_sysEditPageSchema != null) {
					_sysEditPageSchema.Caption = value;
				}
			}
		}

		private SysSchema _sysEditPageSchema;
		/// <summary>
		/// Card page.
		/// </summary>
		public SysSchema SysEditPageSchema {
			get {
				return _sysEditPageSchema ??
					(_sysEditPageSchema = LookupColumnEntities.GetEntity("SysEditPageSchema") as SysSchema);
			}
		}

		/// <summary>
		/// Unique identifier of section list.
		/// </summary>
		public Guid SysModuleGridPageUId {
			get {
				return GetTypedColumnValue<Guid>("SysModuleGridPageUId");
			}
			set {
				SetColumnValue("SysModuleGridPageUId", value);
			}
		}

		/// <summary>
		/// Unique identifier of card page.
		/// </summary>
		public Guid SysEditPageSchemaUId {
			get {
				return GetTypedColumnValue<Guid>("SysEditPageSchemaUId");
			}
			set {
				SetColumnValue("SysEditPageSchemaUId", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysModuleGridEditPage_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysModuleGridEditPageDeleted", e);
			Deleting += (s, e) => ThrowEvent("SysModuleGridEditPageDeleting", e);
			Inserted += (s, e) => ThrowEvent("SysModuleGridEditPageInserted", e);
			Inserting += (s, e) => ThrowEvent("SysModuleGridEditPageInserting", e);
			Saved += (s, e) => ThrowEvent("SysModuleGridEditPageSaved", e);
			Saving += (s, e) => ThrowEvent("SysModuleGridEditPageSaving", e);
			Validating += (s, e) => ThrowEvent("SysModuleGridEditPageValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysModuleGridEditPage(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysModuleGridEditPage_BaseEventsProcess

	/// <exclude/>
	public partial class SysModuleGridEditPage_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : SysModuleGridEditPage
	{

		public SysModuleGridEditPage_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysModuleGridEditPage_BaseEventsProcess";
			SchemaUId = new Guid("14b308a7-fd06-49c8-a7dc-d6300477874a");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("14b308a7-fd06-49c8-a7dc-d6300477874a");
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

	#region Class: SysModuleGridEditPage_BaseEventsProcess

	/// <exclude/>
	public class SysModuleGridEditPage_BaseEventsProcess : SysModuleGridEditPage_BaseEventsProcess<SysModuleGridEditPage>
	{

		public SysModuleGridEditPage_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysModuleGridEditPage_BaseEventsProcess

	public partial class SysModuleGridEditPage_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysModuleGridEditPageEventsProcess

	/// <exclude/>
	public class SysModuleGridEditPageEventsProcess : SysModuleGridEditPage_BaseEventsProcess
	{

		public SysModuleGridEditPageEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

