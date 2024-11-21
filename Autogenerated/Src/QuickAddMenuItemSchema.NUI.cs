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

	#region Class: QuickAddMenuItemSchema

	/// <exclude/>
	public class QuickAddMenuItemSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public QuickAddMenuItemSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public QuickAddMenuItemSchema(QuickAddMenuItemSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public QuickAddMenuItemSchema(QuickAddMenuItemSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("a526ee14-e5f7-4174-8f48-ad030d8862af");
			RealUId = new Guid("a526ee14-e5f7-4174-8f48-ad030d8862af");
			Name = "QuickAddMenuItem";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("8c3dfc4f-625c-4884-8962-32e1cb97064e");
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
			if (Columns.FindByUId(new Guid("055b00cf-3a59-407c-810c-4c4642774ef7")) == null) {
				Columns.Add(CreateSysModuleEditColumn());
			}
			if (Columns.FindByUId(new Guid("b743c56b-8c92-4c20-8fc7-fa62299d16fe")) == null) {
				Columns.Add(CreateQuickAddMenuSettingsColumn());
			}
			if (Columns.FindByUId(new Guid("881e0a65-a92c-4a78-af62-796dc72312ba")) == null) {
				Columns.Add(CreatePositionColumn());
			}
			if (Columns.FindByUId(new Guid("2326f2b8-6c93-4b44-9760-d043a3b4a6fe")) == null) {
				Columns.Add(CreateDescriptionColumn());
			}
			if (Columns.FindByUId(new Guid("46eb4526-ff5c-4fe0-80d0-5c5fae89ecbc")) == null) {
				Columns.Add(CreateModuleUIdColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("a526ee14-e5f7-4174-8f48-ad030d8862af");
			column.CreatedInPackageId = new Guid("8c3dfc4f-625c-4884-8962-32e1cb97064e");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("a526ee14-e5f7-4174-8f48-ad030d8862af");
			column.CreatedInPackageId = new Guid("8c3dfc4f-625c-4884-8962-32e1cb97064e");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("a526ee14-e5f7-4174-8f48-ad030d8862af");
			column.CreatedInPackageId = new Guid("8c3dfc4f-625c-4884-8962-32e1cb97064e");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("a526ee14-e5f7-4174-8f48-ad030d8862af");
			column.CreatedInPackageId = new Guid("8c3dfc4f-625c-4884-8962-32e1cb97064e");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("a526ee14-e5f7-4174-8f48-ad030d8862af");
			column.CreatedInPackageId = new Guid("8c3dfc4f-625c-4884-8962-32e1cb97064e");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("a526ee14-e5f7-4174-8f48-ad030d8862af");
			column.CreatedInPackageId = new Guid("8c3dfc4f-625c-4884-8962-32e1cb97064e");
			return column;
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("17031297-a36e-490d-b08f-9ae1088678dd"),
				Name = @"Name",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("a526ee14-e5f7-4174-8f48-ad030d8862af"),
				ModifiedInSchemaUId = new Guid("a526ee14-e5f7-4174-8f48-ad030d8862af"),
				CreatedInPackageId = new Guid("8c3dfc4f-625c-4884-8962-32e1cb97064e"),
				IsLocalizable = true
			};
		}

		protected virtual EntitySchemaColumn CreateSysModuleEditColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("055b00cf-3a59-407c-810c-4c4642774ef7"),
				Name = @"SysModuleEdit",
				ReferenceSchemaUId = new Guid("24666f2d-049f-4867-ae2c-db681c40c001"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("a526ee14-e5f7-4174-8f48-ad030d8862af"),
				ModifiedInSchemaUId = new Guid("a526ee14-e5f7-4174-8f48-ad030d8862af"),
				CreatedInPackageId = new Guid("8c3dfc4f-625c-4884-8962-32e1cb97064e")
			};
		}

		protected virtual EntitySchemaColumn CreateQuickAddMenuSettingsColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("b743c56b-8c92-4c20-8fc7-fa62299d16fe"),
				Name = @"QuickAddMenuSettings",
				ReferenceSchemaUId = new Guid("4aa8a1e1-77b5-421c-9e74-303810fbc561"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("a526ee14-e5f7-4174-8f48-ad030d8862af"),
				ModifiedInSchemaUId = new Guid("a526ee14-e5f7-4174-8f48-ad030d8862af"),
				CreatedInPackageId = new Guid("8c3dfc4f-625c-4884-8962-32e1cb97064e")
			};
		}

		protected virtual EntitySchemaColumn CreatePositionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("881e0a65-a92c-4a78-af62-796dc72312ba"),
				Name = @"Position",
				CreatedInSchemaUId = new Guid("a526ee14-e5f7-4174-8f48-ad030d8862af"),
				ModifiedInSchemaUId = new Guid("a526ee14-e5f7-4174-8f48-ad030d8862af"),
				CreatedInPackageId = new Guid("8c3dfc4f-625c-4884-8962-32e1cb97064e")
			};
		}

		protected virtual EntitySchemaColumn CreateDescriptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("2326f2b8-6c93-4b44-9760-d043a3b4a6fe"),
				Name = @"Description",
				CreatedInSchemaUId = new Guid("a526ee14-e5f7-4174-8f48-ad030d8862af"),
				ModifiedInSchemaUId = new Guid("a526ee14-e5f7-4174-8f48-ad030d8862af"),
				CreatedInPackageId = new Guid("8c3dfc4f-625c-4884-8962-32e1cb97064e"),
				IsMultiLineText = true
			};
		}

		protected virtual EntitySchemaColumn CreateModuleUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("46eb4526-ff5c-4fe0-80d0-5c5fae89ecbc"),
				Name = @"ModuleUId",
				CreatedInSchemaUId = new Guid("a526ee14-e5f7-4174-8f48-ad030d8862af"),
				ModifiedInSchemaUId = new Guid("a526ee14-e5f7-4174-8f48-ad030d8862af"),
				CreatedInPackageId = new Guid("ac4f7f0f-d5d5-4e8b-997a-a2f7c46f033e"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"8D65B81D-23E1-440E-9075-F106C1E66831"
				}
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new QuickAddMenuItem(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new QuickAddMenuItem_NUIEventsProcess(userConnection);
		}

		public override object Clone() {
			return new QuickAddMenuItemSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new QuickAddMenuItemSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("a526ee14-e5f7-4174-8f48-ad030d8862af"));
		}

		#endregion

	}

	#endregion

	#region Class: QuickAddMenuItem

	/// <summary>
	/// Item of the quick add menu.
	/// </summary>
	public class QuickAddMenuItem : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public QuickAddMenuItem(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "QuickAddMenuItem";
		}

		public QuickAddMenuItem(QuickAddMenuItem source)
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

		/// <exclude/>
		public Guid SysModuleEditId {
			get {
				return GetTypedColumnValue<Guid>("SysModuleEditId");
			}
			set {
				SetColumnValue("SysModuleEditId", value);
				_sysModuleEdit = null;
			}
		}

		/// <exclude/>
		public string SysModuleEditPageCaption {
			get {
				return GetTypedColumnValue<string>("SysModuleEditPageCaption");
			}
			set {
				SetColumnValue("SysModuleEditPageCaption", value);
				if (_sysModuleEdit != null) {
					_sysModuleEdit.PageCaption = value;
				}
			}
		}

		private SysModuleEdit _sysModuleEdit;
		/// <summary>
		/// Add page.
		/// </summary>
		public SysModuleEdit SysModuleEdit {
			get {
				return _sysModuleEdit ??
					(_sysModuleEdit = LookupColumnEntities.GetEntity("SysModuleEdit") as SysModuleEdit);
			}
		}

		/// <exclude/>
		public Guid QuickAddMenuSettingsId {
			get {
				return GetTypedColumnValue<Guid>("QuickAddMenuSettingsId");
			}
			set {
				SetColumnValue("QuickAddMenuSettingsId", value);
				_quickAddMenuSettings = null;
			}
		}

		/// <exclude/>
		public string QuickAddMenuSettingsName {
			get {
				return GetTypedColumnValue<string>("QuickAddMenuSettingsName");
			}
			set {
				SetColumnValue("QuickAddMenuSettingsName", value);
				if (_quickAddMenuSettings != null) {
					_quickAddMenuSettings.Name = value;
				}
			}
		}

		private QuickAddMenuSettings _quickAddMenuSettings;
		/// <summary>
		/// Quick add menu setup.
		/// </summary>
		public QuickAddMenuSettings QuickAddMenuSettings {
			get {
				return _quickAddMenuSettings ??
					(_quickAddMenuSettings = LookupColumnEntities.GetEntity("QuickAddMenuSettings") as QuickAddMenuSettings);
			}
		}

		/// <summary>
		/// Position.
		/// </summary>
		public int Position {
			get {
				return GetTypedColumnValue<int>("Position");
			}
			set {
				SetColumnValue("Position", value);
			}
		}

		/// <summary>
		/// Description.
		/// </summary>
		public string Description {
			get {
				return GetTypedColumnValue<string>("Description");
			}
			set {
				SetColumnValue("Description", value);
			}
		}

		/// <summary>
		/// Handling module.
		/// </summary>
		public Guid ModuleUId {
			get {
				return GetTypedColumnValue<Guid>("ModuleUId");
			}
			set {
				SetColumnValue("ModuleUId", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new QuickAddMenuItem_NUIEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("QuickAddMenuItemDeleted", e);
			Inserting += (s, e) => ThrowEvent("QuickAddMenuItemInserting", e);
			Validating += (s, e) => ThrowEvent("QuickAddMenuItemValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new QuickAddMenuItem(this);
		}

		#endregion

	}

	#endregion

	#region Class: QuickAddMenuItem_NUIEventsProcess

	/// <exclude/>
	public partial class QuickAddMenuItem_NUIEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : QuickAddMenuItem
	{

		public QuickAddMenuItem_NUIEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "QuickAddMenuItem_NUIEventsProcess";
			SchemaUId = new Guid("a526ee14-e5f7-4174-8f48-ad030d8862af");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("a526ee14-e5f7-4174-8f48-ad030d8862af");
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

	#region Class: QuickAddMenuItem_NUIEventsProcess

	/// <exclude/>
	public class QuickAddMenuItem_NUIEventsProcess : QuickAddMenuItem_NUIEventsProcess<QuickAddMenuItem>
	{

		public QuickAddMenuItem_NUIEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: QuickAddMenuItem_NUIEventsProcess

	public partial class QuickAddMenuItem_NUIEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: QuickAddMenuItemEventsProcess

	/// <exclude/>
	public class QuickAddMenuItemEventsProcess : QuickAddMenuItem_NUIEventsProcess
	{

		public QuickAddMenuItemEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

