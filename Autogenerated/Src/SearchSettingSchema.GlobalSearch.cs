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

	#region Class: SearchSettingSchema

	/// <exclude/>
	public class SearchSettingSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SearchSettingSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SearchSettingSchema(SearchSettingSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SearchSettingSchema(SearchSettingSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("d2a3ad5c-12b6-46a5-8593-94e59c4fc1c6");
			RealUId = new Guid("d2a3ad5c-12b6-46a5-8593-94e59c4fc1c6");
			Name = "SearchSetting";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("4f1a03e7-b704-4e8f-b18d-5d9d9b146893");
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
			if (Columns.FindByUId(new Guid("306b9536-f683-4c92-876d-fec0e0ba45ce")) == null) {
				Columns.Add(CreateSettingsColumn());
			}
			if (Columns.FindByUId(new Guid("ed3da4aa-18d2-48f9-be2a-eb9c1331e5b0")) == null) {
				Columns.Add(CreateSearchEntityColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateSettingsColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("306b9536-f683-4c92-876d-fec0e0ba45ce"),
				Name = @"Settings",
				CreatedInSchemaUId = new Guid("d2a3ad5c-12b6-46a5-8593-94e59c4fc1c6"),
				ModifiedInSchemaUId = new Guid("d2a3ad5c-12b6-46a5-8593-94e59c4fc1c6"),
				CreatedInPackageId = new Guid("4f1a03e7-b704-4e8f-b18d-5d9d9b146893")
			};
		}

		protected virtual EntitySchemaColumn CreateSearchEntityColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("ed3da4aa-18d2-48f9-be2a-eb9c1331e5b0"),
				Name = @"SearchEntity",
				ReferenceSchemaUId = new Guid("90fa6d02-3e93-45d6-a72b-58dcffa411ae"),
				IsIndexed = true,
				IsWeakReference = true,
				CreatedInSchemaUId = new Guid("d2a3ad5c-12b6-46a5-8593-94e59c4fc1c6"),
				ModifiedInSchemaUId = new Guid("d2a3ad5c-12b6-46a5-8593-94e59c4fc1c6"),
				CreatedInPackageId = new Guid("4f1a03e7-b704-4e8f-b18d-5d9d9b146893")
			};
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("7a5e77fd-b75e-4d28-a82b-68e18593c68e"),
				Name = @"Name",
				CreatedInSchemaUId = new Guid("d2a3ad5c-12b6-46a5-8593-94e59c4fc1c6"),
				ModifiedInSchemaUId = new Guid("d2a3ad5c-12b6-46a5-8593-94e59c4fc1c6"),
				CreatedInPackageId = new Guid("4f1a03e7-b704-4e8f-b18d-5d9d9b146893")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SearchSetting(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SearchSetting_GlobalSearchEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SearchSettingSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SearchSettingSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("d2a3ad5c-12b6-46a5-8593-94e59c4fc1c6"));
		}

		#endregion

	}

	#endregion

	#region Class: SearchSetting

	/// <summary>
	/// Global search setting.
	/// </summary>
	public class SearchSetting : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SearchSetting(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SearchSetting";
		}

		public SearchSetting(SearchSetting source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Search config.
		/// </summary>
		public string Settings {
			get {
				return GetTypedColumnValue<string>("Settings");
			}
			set {
				SetColumnValue("Settings", value);
			}
		}

		/// <exclude/>
		public Guid SearchEntityId {
			get {
				return GetTypedColumnValue<Guid>("SearchEntityId");
			}
			set {
				SetColumnValue("SearchEntityId", value);
				_searchEntity = null;
			}
		}

		/// <exclude/>
		public string SearchEntityCaption {
			get {
				return GetTypedColumnValue<string>("SearchEntityCaption");
			}
			set {
				SetColumnValue("SearchEntityCaption", value);
				if (_searchEntity != null) {
					_searchEntity.Caption = value;
				}
			}
		}

		private VwSysSchemaInfo _searchEntity;
		/// <summary>
		/// Search entity.
		/// </summary>
		public VwSysSchemaInfo SearchEntity {
			get {
				return _searchEntity ??
					(_searchEntity = LookupColumnEntities.GetEntity("SearchEntity") as VwSysSchemaInfo);
			}
		}

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
			var process = new SearchSetting_GlobalSearchEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SearchSettingDeleted", e);
			Validating += (s, e) => ThrowEvent("SearchSettingValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SearchSetting(this);
		}

		#endregion

	}

	#endregion

	#region Class: SearchSetting_GlobalSearchEventsProcess

	/// <exclude/>
	public partial class SearchSetting_GlobalSearchEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : SearchSetting
	{

		public SearchSetting_GlobalSearchEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SearchSetting_GlobalSearchEventsProcess";
			SchemaUId = new Guid("d2a3ad5c-12b6-46a5-8593-94e59c4fc1c6");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("d2a3ad5c-12b6-46a5-8593-94e59c4fc1c6");
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

	#region Class: SearchSetting_GlobalSearchEventsProcess

	/// <exclude/>
	public class SearchSetting_GlobalSearchEventsProcess : SearchSetting_GlobalSearchEventsProcess<SearchSetting>
	{

		public SearchSetting_GlobalSearchEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SearchSetting_GlobalSearchEventsProcess

	public partial class SearchSetting_GlobalSearchEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SearchSettingEventsProcess

	/// <exclude/>
	public class SearchSettingEventsProcess : SearchSetting_GlobalSearchEventsProcess
	{

		public SearchSettingEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

