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

	#region Class: EntityTypeLookupSchema

	/// <exclude/>
	public class EntityTypeLookupSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public EntityTypeLookupSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public EntityTypeLookupSchema(EntityTypeLookupSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public EntityTypeLookupSchema(EntityTypeLookupSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("af2a225a-93db-4552-b08c-d134a5e9361a");
			RealUId = new Guid("af2a225a-93db-4552-b08c-d134a5e9361a");
			Name = "EntityTypeLookup";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("781ea0d0-6d7f-4b9d-8a06-13b9d6d7e7c2");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("b5c25dea-5ba9-4416-a7eb-4822982d5f6b")) == null) {
				Columns.Add(CreateEntityNameColumn());
			}
			if (Columns.FindByUId(new Guid("bb476184-47a2-4679-960f-71dce2f1fa15")) == null) {
				Columns.Add(CreateMenuItemCaptionColumn());
			}
			if (Columns.FindByUId(new Guid("65234ad8-7150-492e-aeee-7601cb33ea8e")) == null) {
				Columns.Add(CreateSysSettingImageColumn());
			}
			if (Columns.FindByUId(new Guid("80919e0b-9b0f-45cf-aed5-a37adf4fc53f")) == null) {
				Columns.Add(CreatePositionColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateEntityNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("b5c25dea-5ba9-4416-a7eb-4822982d5f6b"),
				Name = @"EntityName",
				CreatedInSchemaUId = new Guid("af2a225a-93db-4552-b08c-d134a5e9361a"),
				ModifiedInSchemaUId = new Guid("af2a225a-93db-4552-b08c-d134a5e9361a"),
				CreatedInPackageId = new Guid("781ea0d0-6d7f-4b9d-8a06-13b9d6d7e7c2")
			};
		}

		protected virtual EntitySchemaColumn CreateMenuItemCaptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("bb476184-47a2-4679-960f-71dce2f1fa15"),
				Name = @"MenuItemCaption",
				CreatedInSchemaUId = new Guid("af2a225a-93db-4552-b08c-d134a5e9361a"),
				ModifiedInSchemaUId = new Guid("af2a225a-93db-4552-b08c-d134a5e9361a"),
				CreatedInPackageId = new Guid("781ea0d0-6d7f-4b9d-8a06-13b9d6d7e7c2"),
				IsLocalizable = true
			};
		}

		protected virtual EntitySchemaColumn CreateSysSettingImageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("65234ad8-7150-492e-aeee-7601cb33ea8e"),
				Name = @"SysSettingImage",
				CreatedInSchemaUId = new Guid("af2a225a-93db-4552-b08c-d134a5e9361a"),
				ModifiedInSchemaUId = new Guid("af2a225a-93db-4552-b08c-d134a5e9361a"),
				CreatedInPackageId = new Guid("781ea0d0-6d7f-4b9d-8a06-13b9d6d7e7c2")
			};
		}

		protected virtual EntitySchemaColumn CreatePositionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("80919e0b-9b0f-45cf-aed5-a37adf4fc53f"),
				Name = @"Position",
				CreatedInSchemaUId = new Guid("af2a225a-93db-4552-b08c-d134a5e9361a"),
				ModifiedInSchemaUId = new Guid("af2a225a-93db-4552-b08c-d134a5e9361a"),
				CreatedInPackageId = new Guid("781ea0d0-6d7f-4b9d-8a06-13b9d6d7e7c2")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new EntityTypeLookup(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new EntityTypeLookup_UIv2EventsProcess(userConnection);
		}

		public override object Clone() {
			return new EntityTypeLookupSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new EntityTypeLookupSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("af2a225a-93db-4552-b08c-d134a5e9361a"));
		}

		#endregion

	}

	#endregion

	#region Class: EntityTypeLookup

	/// <summary>
	/// Attachment detail lookup.
	/// </summary>
	public class EntityTypeLookup : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public EntityTypeLookup(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "EntityTypeLookup";
		}

		public EntityTypeLookup(EntityTypeLookup source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Entity name.
		/// </summary>
		public string EntityName {
			get {
				return GetTypedColumnValue<string>("EntityName");
			}
			set {
				SetColumnValue("EntityName", value);
			}
		}

		/// <summary>
		/// Menu item.
		/// </summary>
		public string MenuItemCaption {
			get {
				return GetTypedColumnValue<string>("MenuItemCaption");
			}
			set {
				SetColumnValue("MenuItemCaption", value);
			}
		}

		/// <summary>
		/// Name of system setting with image.
		/// </summary>
		public string SysSettingImage {
			get {
				return GetTypedColumnValue<string>("SysSettingImage");
			}
			set {
				SetColumnValue("SysSettingImage", value);
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

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new EntityTypeLookup_UIv2EventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("EntityTypeLookupDeleted", e);
			Validating += (s, e) => ThrowEvent("EntityTypeLookupValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new EntityTypeLookup(this);
		}

		#endregion

	}

	#endregion

	#region Class: EntityTypeLookup_UIv2EventsProcess

	/// <exclude/>
	public partial class EntityTypeLookup_UIv2EventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : EntityTypeLookup
	{

		public EntityTypeLookup_UIv2EventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "EntityTypeLookup_UIv2EventsProcess";
			SchemaUId = new Guid("af2a225a-93db-4552-b08c-d134a5e9361a");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("af2a225a-93db-4552-b08c-d134a5e9361a");
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

	#region Class: EntityTypeLookup_UIv2EventsProcess

	/// <exclude/>
	public class EntityTypeLookup_UIv2EventsProcess : EntityTypeLookup_UIv2EventsProcess<EntityTypeLookup>
	{

		public EntityTypeLookup_UIv2EventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: EntityTypeLookup_UIv2EventsProcess

	public partial class EntityTypeLookup_UIv2EventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: EntityTypeLookupEventsProcess

	/// <exclude/>
	public class EntityTypeLookupEventsProcess : EntityTypeLookup_UIv2EventsProcess
	{

		public EntityTypeLookupEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

