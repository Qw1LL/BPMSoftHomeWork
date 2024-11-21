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

	#region Class: SysLookupSchema

	/// <exclude/>
	public class SysLookupSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public SysLookupSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysLookupSchema(SysLookupSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysLookupSchema(SysLookupSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("aa3cc352-3095-43c9-ace8-6301f50a0a80");
			RealUId = new Guid("aa3cc352-3095-43c9-ace8-6301f50a0a80");
			Name = "SysLookup";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
			DesignLocalizationSchemaName = @"SysSysLookupLcz";
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("23c7bb46-18f7-491a-9b92-c5a0edca930f")) == null) {
				Columns.Add(CreateSysFolderColumn());
			}
			if (Columns.FindByUId(new Guid("f3217323-afc6-447c-804a-15fa195d05d2")) == null) {
				Columns.Add(CreateIsSystemColumn());
			}
			if (Columns.FindByUId(new Guid("4bf49c30-d507-421a-b144-3fba3208b580")) == null) {
				Columns.Add(CreateIsSimpleColumn());
			}
			if (Columns.FindByUId(new Guid("ce28b9f4-8f90-43cc-8c04-ddfe968c59b2")) == null) {
				Columns.Add(CreateSysEditPageSchemaUIdColumn());
			}
			if (Columns.FindByUId(new Guid("9ca3a204-8d60-45a6-b16e-9384872071c3")) == null) {
				Columns.Add(CreateSysGridPageSchemaUIdColumn());
			}
			if (Columns.FindByUId(new Guid("cb2be0a9-94bf-4cde-8efb-eb6862e3b6e0")) == null) {
				Columns.Add(CreateSysEntitySchemaUIdColumn());
			}
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.IsLocalizable = false;
			column.ModifiedInSchemaUId = new Guid("aa3cc352-3095-43c9-ace8-6301f50a0a80");
			column.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.IsLocalizable = false;
			column.ModifiedInSchemaUId = new Guid("aa3cc352-3095-43c9-ace8-6301f50a0a80");
			column.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			return column;
		}

		protected virtual EntitySchemaColumn CreateSysFolderColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("23c7bb46-18f7-491a-9b92-c5a0edca930f"),
				Name = @"SysFolder",
				ReferenceSchemaUId = new Guid("5403f977-1005-41a3-99a1-5ff37806bbbf"),
				CreatedInSchemaUId = new Guid("aa3cc352-3095-43c9-ace8-6301f50a0a80"),
				ModifiedInSchemaUId = new Guid("aa3cc352-3095-43c9-ace8-6301f50a0a80"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateIsSystemColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("f3217323-afc6-447c-804a-15fa195d05d2"),
				Name = @"IsSystem",
				CreatedInSchemaUId = new Guid("aa3cc352-3095-43c9-ace8-6301f50a0a80"),
				ModifiedInSchemaUId = new Guid("aa3cc352-3095-43c9-ace8-6301f50a0a80"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"False"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateIsSimpleColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("4bf49c30-d507-421a-b144-3fba3208b580"),
				Name = @"IsSimple",
				CreatedInSchemaUId = new Guid("aa3cc352-3095-43c9-ace8-6301f50a0a80"),
				ModifiedInSchemaUId = new Guid("aa3cc352-3095-43c9-ace8-6301f50a0a80"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"False"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateSysEditPageSchemaUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("ce28b9f4-8f90-43cc-8c04-ddfe968c59b2"),
				Name = @"SysEditPageSchemaUId",
				CreatedInSchemaUId = new Guid("aa3cc352-3095-43c9-ace8-6301f50a0a80"),
				ModifiedInSchemaUId = new Guid("aa3cc352-3095-43c9-ace8-6301f50a0a80"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateSysGridPageSchemaUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("9ca3a204-8d60-45a6-b16e-9384872071c3"),
				Name = @"SysGridPageSchemaUId",
				CreatedInSchemaUId = new Guid("aa3cc352-3095-43c9-ace8-6301f50a0a80"),
				ModifiedInSchemaUId = new Guid("aa3cc352-3095-43c9-ace8-6301f50a0a80"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateSysEntitySchemaUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("cb2be0a9-94bf-4cde-8efb-eb6862e3b6e0"),
				Name = @"SysEntitySchemaUId",
				CreatedInSchemaUId = new Guid("aa3cc352-3095-43c9-ace8-6301f50a0a80"),
				ModifiedInSchemaUId = new Guid("aa3cc352-3095-43c9-ace8-6301f50a0a80"),
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
			return new SysLookup(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysLookup_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysLookupSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysLookupSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("aa3cc352-3095-43c9-ace8-6301f50a0a80"));
		}

		#endregion

	}

	#endregion

	#region Class: SysLookup

	/// <summary>
	/// Lookup (system).
	/// </summary>
	public class SysLookup : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public SysLookup(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysLookup";
		}

		public SysLookup(SysLookup source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid SysFolderId {
			get {
				return GetTypedColumnValue<Guid>("SysFolderId");
			}
			set {
				SetColumnValue("SysFolderId", value);
				_sysFolder = null;
			}
		}

		/// <exclude/>
		public string SysFolderName {
			get {
				return GetTypedColumnValue<string>("SysFolderName");
			}
			set {
				SetColumnValue("SysFolderName", value);
				if (_sysFolder != null) {
					_sysFolder.Name = value;
				}
			}
		}

		private SysLookupFolder _sysFolder;
		/// <summary>
		/// Folder.
		/// </summary>
		public SysLookupFolder SysFolder {
			get {
				return _sysFolder ??
					(_sysFolder = LookupColumnEntities.GetEntity("SysFolder") as SysLookupFolder);
			}
		}

		/// <summary>
		/// System.
		/// </summary>
		/// <remarks>
		/// Important system lookup used in business processes. Changes are prohibited.
		/// </remarks>
		public bool IsSystem {
			get {
				return GetTypedColumnValue<bool>("IsSystem");
			}
			set {
				SetColumnValue("IsSystem", value);
			}
		}

		/// <summary>
		/// Simple.
		/// </summary>
		/// <remarks>
		/// Simple lookup with small number of records. Cached.
		/// </remarks>
		public bool IsSimple {
			get {
				return GetTypedColumnValue<bool>("IsSimple");
			}
			set {
				SetColumnValue("IsSimple", value);
			}
		}

		/// <summary>
		/// Unique identifier of edit page.
		/// </summary>
		public Guid SysEditPageSchemaUId {
			get {
				return GetTypedColumnValue<Guid>("SysEditPageSchemaUId");
			}
			set {
				SetColumnValue("SysEditPageSchemaUId", value);
			}
		}

		/// <summary>
		/// Unique identifier of list page.
		/// </summary>
		public Guid SysGridPageSchemaUId {
			get {
				return GetTypedColumnValue<Guid>("SysGridPageSchemaUId");
			}
			set {
				SetColumnValue("SysGridPageSchemaUId", value);
			}
		}

		/// <summary>
		/// Unique identifier of object.
		/// </summary>
		public Guid SysEntitySchemaUId {
			get {
				return GetTypedColumnValue<Guid>("SysEntitySchemaUId");
			}
			set {
				SetColumnValue("SysEntitySchemaUId", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysLookup_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysLookupDeleted", e);
			Deleting += (s, e) => ThrowEvent("SysLookupDeleting", e);
			Inserted += (s, e) => ThrowEvent("SysLookupInserted", e);
			Inserting += (s, e) => ThrowEvent("SysLookupInserting", e);
			Saved += (s, e) => ThrowEvent("SysLookupSaved", e);
			Saving += (s, e) => ThrowEvent("SysLookupSaving", e);
			Validating += (s, e) => ThrowEvent("SysLookupValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysLookup(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysLookup_BaseEventsProcess

	/// <exclude/>
	public partial class SysLookup_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : SysLookup
	{

		public SysLookup_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysLookup_BaseEventsProcess";
			SchemaUId = new Guid("aa3cc352-3095-43c9-ace8-6301f50a0a80");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("aa3cc352-3095-43c9-ace8-6301f50a0a80");
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

	#region Class: SysLookup_BaseEventsProcess

	/// <exclude/>
	public class SysLookup_BaseEventsProcess : SysLookup_BaseEventsProcess<SysLookup>
	{

		public SysLookup_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysLookup_BaseEventsProcess

	public partial class SysLookup_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysLookupEventsProcess

	/// <exclude/>
	public class SysLookupEventsProcess : SysLookup_BaseEventsProcess
	{

		public SysLookupEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

