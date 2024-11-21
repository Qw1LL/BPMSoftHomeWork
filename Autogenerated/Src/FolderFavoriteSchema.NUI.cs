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

	#region Class: FolderFavoriteSchema

	/// <exclude/>
	public class FolderFavoriteSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public FolderFavoriteSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public FolderFavoriteSchema(FolderFavoriteSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public FolderFavoriteSchema(FolderFavoriteSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("0ecb85d4-228f-4ccb-9ba5-716b6a4335bf");
			RealUId = new Guid("0ecb85d4-228f-4ccb-9ba5-716b6a4335bf");
			Name = "FolderFavorite";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("43f796d0-2535-4ae5-88b4-0c05eb1809e5");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("10e0123a-4cfa-41fc-82be-81c4bd5b8dc6")) == null) {
				Columns.Add(CreateSysAdminUnitColumn());
			}
			if (Columns.FindByUId(new Guid("4d24b8ff-9dda-4d8b-8c05-4b74b36ec731")) == null) {
				Columns.Add(CreateFolderIdColumn());
			}
			if (Columns.FindByUId(new Guid("b4acab41-c8b0-4e52-a535-93985f9d9af2")) == null) {
				Columns.Add(CreateFolderEntitySchemaUIdColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("0ecb85d4-228f-4ccb-9ba5-716b6a4335bf");
			column.CreatedInPackageId = new Guid("43f796d0-2535-4ae5-88b4-0c05eb1809e5");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("0ecb85d4-228f-4ccb-9ba5-716b6a4335bf");
			column.CreatedInPackageId = new Guid("43f796d0-2535-4ae5-88b4-0c05eb1809e5");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("0ecb85d4-228f-4ccb-9ba5-716b6a4335bf");
			column.CreatedInPackageId = new Guid("43f796d0-2535-4ae5-88b4-0c05eb1809e5");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("0ecb85d4-228f-4ccb-9ba5-716b6a4335bf");
			column.CreatedInPackageId = new Guid("43f796d0-2535-4ae5-88b4-0c05eb1809e5");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("0ecb85d4-228f-4ccb-9ba5-716b6a4335bf");
			column.CreatedInPackageId = new Guid("43f796d0-2535-4ae5-88b4-0c05eb1809e5");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("0ecb85d4-228f-4ccb-9ba5-716b6a4335bf");
			column.CreatedInPackageId = new Guid("43f796d0-2535-4ae5-88b4-0c05eb1809e5");
			return column;
		}

		protected virtual EntitySchemaColumn CreateSysAdminUnitColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("10e0123a-4cfa-41fc-82be-81c4bd5b8dc6"),
				Name = @"SysAdminUnit",
				ReferenceSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("0ecb85d4-228f-4ccb-9ba5-716b6a4335bf"),
				ModifiedInSchemaUId = new Guid("0ecb85d4-228f-4ccb-9ba5-716b6a4335bf"),
				CreatedInPackageId = new Guid("43f796d0-2535-4ae5-88b4-0c05eb1809e5"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.SystemValue,
					ValueSource = SystemValueManager.GetInstanceByName(@"CurrentUser")
				}
			};
		}

		protected virtual EntitySchemaColumn CreateFolderIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("4d24b8ff-9dda-4d8b-8c05-4b74b36ec731"),
				Name = @"FolderId",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("0ecb85d4-228f-4ccb-9ba5-716b6a4335bf"),
				ModifiedInSchemaUId = new Guid("0ecb85d4-228f-4ccb-9ba5-716b6a4335bf"),
				CreatedInPackageId = new Guid("43f796d0-2535-4ae5-88b4-0c05eb1809e5")
			};
		}

		protected virtual EntitySchemaColumn CreateFolderEntitySchemaUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("b4acab41-c8b0-4e52-a535-93985f9d9af2"),
				Name = @"FolderEntitySchemaUId",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("0ecb85d4-228f-4ccb-9ba5-716b6a4335bf"),
				ModifiedInSchemaUId = new Guid("0ecb85d4-228f-4ccb-9ba5-716b6a4335bf"),
				CreatedInPackageId = new Guid("43f796d0-2535-4ae5-88b4-0c05eb1809e5")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new FolderFavorite(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new FolderFavorite_NUIEventsProcess(userConnection);
		}

		public override object Clone() {
			return new FolderFavoriteSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new FolderFavoriteSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("0ecb85d4-228f-4ccb-9ba5-716b6a4335bf"));
		}

		#endregion

	}

	#endregion

	#region Class: FolderFavorite

	/// <summary>
	/// Favorite folder.
	/// </summary>
	public class FolderFavorite : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public FolderFavorite(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "FolderFavorite";
		}

		public FolderFavorite(FolderFavorite source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid SysAdminUnitId {
			get {
				return GetTypedColumnValue<Guid>("SysAdminUnitId");
			}
			set {
				SetColumnValue("SysAdminUnitId", value);
				_sysAdminUnit = null;
			}
		}

		/// <exclude/>
		public string SysAdminUnitName {
			get {
				return GetTypedColumnValue<string>("SysAdminUnitName");
			}
			set {
				SetColumnValue("SysAdminUnitName", value);
				if (_sysAdminUnit != null) {
					_sysAdminUnit.Name = value;
				}
			}
		}

		private SysAdminUnit _sysAdminUnit;
		/// <summary>
		/// User.
		/// </summary>
		public SysAdminUnit SysAdminUnit {
			get {
				return _sysAdminUnit ??
					(_sysAdminUnit = LookupColumnEntities.GetEntity("SysAdminUnit") as SysAdminUnit);
			}
		}

		/// <summary>
		/// Folder.
		/// </summary>
		public Guid FolderId {
			get {
				return GetTypedColumnValue<Guid>("FolderId");
			}
			set {
				SetColumnValue("FolderId", value);
			}
		}

		/// <summary>
		/// Folder schema.
		/// </summary>
		public Guid FolderEntitySchemaUId {
			get {
				return GetTypedColumnValue<Guid>("FolderEntitySchemaUId");
			}
			set {
				SetColumnValue("FolderEntitySchemaUId", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new FolderFavorite_NUIEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("FolderFavoriteDeleted", e);
			Inserting += (s, e) => ThrowEvent("FolderFavoriteInserting", e);
			Validating += (s, e) => ThrowEvent("FolderFavoriteValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new FolderFavorite(this);
		}

		#endregion

	}

	#endregion

	#region Class: FolderFavorite_NUIEventsProcess

	/// <exclude/>
	public partial class FolderFavorite_NUIEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : FolderFavorite
	{

		public FolderFavorite_NUIEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "FolderFavorite_NUIEventsProcess";
			SchemaUId = new Guid("0ecb85d4-228f-4ccb-9ba5-716b6a4335bf");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("0ecb85d4-228f-4ccb-9ba5-716b6a4335bf");
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

	#region Class: FolderFavorite_NUIEventsProcess

	/// <exclude/>
	public class FolderFavorite_NUIEventsProcess : FolderFavorite_NUIEventsProcess<FolderFavorite>
	{

		public FolderFavorite_NUIEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: FolderFavorite_NUIEventsProcess

	public partial class FolderFavorite_NUIEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: FolderFavoriteEventsProcess

	/// <exclude/>
	public class FolderFavoriteEventsProcess : FolderFavorite_NUIEventsProcess
	{

		public FolderFavoriteEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

