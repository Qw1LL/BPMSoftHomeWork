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

	#region Class: SiteEvent_SiteEvent_BPMSoftSchema

	/// <exclude/>
	public class SiteEvent_SiteEvent_BPMSoftSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SiteEvent_SiteEvent_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SiteEvent_SiteEvent_BPMSoftSchema(SiteEvent_SiteEvent_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SiteEvent_SiteEvent_BPMSoftSchema(SiteEvent_SiteEvent_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("93a880c8-dea8-47d5-9b79-1d7fd8259ca0");
			RealUId = new Guid("93a880c8-dea8-47d5-9b79-1d7fd8259ca0");
			Name = "SiteEvent_SiteEvent_BPMSoft";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("c65af0e3-7594-46d5-990b-d36fcba84a2a");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateSourceColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("5f2dfdd1-5ddb-4839-a83b-8d148e1cf3eb")) == null) {
				Columns.Add(CreateEventDateColumn());
			}
			if (Columns.FindByUId(new Guid("f8f51db4-b012-4188-95c5-f45fae88386e")) == null) {
				Columns.Add(CreateContactColumn());
			}
			if (Columns.FindByUId(new Guid("5bd488d1-8090-4458-9e7d-0b82c5b88358")) == null) {
				Columns.Add(CreateTagColumn());
			}
			if (Columns.FindByUId(new Guid("82ff1d2a-0f1d-4d23-9877-bf07d2a26238")) == null) {
				Columns.Add(CreateSiteEventTypeColumn());
			}
			if (Columns.FindByUId(new Guid("8ddbde42-34bb-4a31-8b08-9c4dcf9c55c0")) == null) {
				Columns.Add(CreateLeadTypeColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("93a880c8-dea8-47d5-9b79-1d7fd8259ca0");
			column.CreatedInPackageId = new Guid("c65af0e3-7594-46d5-990b-d36fcba84a2a");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("93a880c8-dea8-47d5-9b79-1d7fd8259ca0");
			column.CreatedInPackageId = new Guid("c65af0e3-7594-46d5-990b-d36fcba84a2a");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("93a880c8-dea8-47d5-9b79-1d7fd8259ca0");
			column.CreatedInPackageId = new Guid("c65af0e3-7594-46d5-990b-d36fcba84a2a");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("93a880c8-dea8-47d5-9b79-1d7fd8259ca0");
			column.CreatedInPackageId = new Guid("c65af0e3-7594-46d5-990b-d36fcba84a2a");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("93a880c8-dea8-47d5-9b79-1d7fd8259ca0");
			column.CreatedInPackageId = new Guid("c65af0e3-7594-46d5-990b-d36fcba84a2a");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("93a880c8-dea8-47d5-9b79-1d7fd8259ca0");
			column.CreatedInPackageId = new Guid("c65af0e3-7594-46d5-990b-d36fcba84a2a");
			return column;
		}

		protected virtual EntitySchemaColumn CreateEventDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("5f2dfdd1-5ddb-4839-a83b-8d148e1cf3eb"),
				Name = @"EventDate",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("93a880c8-dea8-47d5-9b79-1d7fd8259ca0"),
				ModifiedInSchemaUId = new Guid("93a880c8-dea8-47d5-9b79-1d7fd8259ca0"),
				CreatedInPackageId = new Guid("c65af0e3-7594-46d5-990b-d36fcba84a2a")
			};
		}

		protected virtual EntitySchemaColumn CreateContactColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("f8f51db4-b012-4188-95c5-f45fae88386e"),
				Name = @"Contact",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("93a880c8-dea8-47d5-9b79-1d7fd8259ca0"),
				ModifiedInSchemaUId = new Guid("93a880c8-dea8-47d5-9b79-1d7fd8259ca0"),
				CreatedInPackageId = new Guid("c65af0e3-7594-46d5-990b-d36fcba84a2a")
			};
		}

		protected virtual EntitySchemaColumn CreateSourceColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("1c056690-3783-4fad-b9cd-26354f4d2f0d"),
				Name = @"Source",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("93a880c8-dea8-47d5-9b79-1d7fd8259ca0"),
				ModifiedInSchemaUId = new Guid("93a880c8-dea8-47d5-9b79-1d7fd8259ca0"),
				CreatedInPackageId = new Guid("c65af0e3-7594-46d5-990b-d36fcba84a2a"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @" "
				}
			};
		}

		protected virtual EntitySchemaColumn CreateTagColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("5bd488d1-8090-4458-9e7d-0b82c5b88358"),
				Name = @"Tag",
				CreatedInSchemaUId = new Guid("93a880c8-dea8-47d5-9b79-1d7fd8259ca0"),
				ModifiedInSchemaUId = new Guid("93a880c8-dea8-47d5-9b79-1d7fd8259ca0"),
				CreatedInPackageId = new Guid("c65af0e3-7594-46d5-990b-d36fcba84a2a")
			};
		}

		protected virtual EntitySchemaColumn CreateSiteEventTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("82ff1d2a-0f1d-4d23-9877-bf07d2a26238"),
				Name = @"SiteEventType",
				ReferenceSchemaUId = new Guid("e7274000-f0ef-4995-991a-37f0ace69fe3"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("93a880c8-dea8-47d5-9b79-1d7fd8259ca0"),
				ModifiedInSchemaUId = new Guid("93a880c8-dea8-47d5-9b79-1d7fd8259ca0"),
				CreatedInPackageId = new Guid("c65af0e3-7594-46d5-990b-d36fcba84a2a")
			};
		}

		protected virtual EntitySchemaColumn CreateLeadTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("8ddbde42-34bb-4a31-8b08-9c4dcf9c55c0"),
				Name = @"LeadType",
				ReferenceSchemaUId = new Guid("e0dbeb22-4932-4eee-a8f2-a247a5fce888"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("93a880c8-dea8-47d5-9b79-1d7fd8259ca0"),
				ModifiedInSchemaUId = new Guid("93a880c8-dea8-47d5-9b79-1d7fd8259ca0"),
				CreatedInPackageId = new Guid("c65af0e3-7594-46d5-990b-d36fcba84a2a")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SiteEvent_SiteEvent_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SiteEvent_SiteEventEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SiteEvent_SiteEvent_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SiteEvent_SiteEvent_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("93a880c8-dea8-47d5-9b79-1d7fd8259ca0"));
		}

		#endregion

	}

	#endregion

	#region Class: SiteEvent_SiteEvent_BPMSoft

	/// <summary>
	/// Событие сайта.
	/// </summary>
	public class SiteEvent_SiteEvent_BPMSoft : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SiteEvent_SiteEvent_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SiteEvent_SiteEvent_BPMSoft";
		}

		public SiteEvent_SiteEvent_BPMSoft(SiteEvent_SiteEvent_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Дата/время.
		/// </summary>
		public DateTime EventDate {
			get {
				return GetTypedColumnValue<DateTime>("EventDate");
			}
			set {
				SetColumnValue("EventDate", value);
			}
		}

		/// <exclude/>
		public Guid ContactId {
			get {
				return GetTypedColumnValue<Guid>("ContactId");
			}
			set {
				SetColumnValue("ContactId", value);
				_contact = null;
			}
		}

		/// <exclude/>
		public string ContactName {
			get {
				return GetTypedColumnValue<string>("ContactName");
			}
			set {
				SetColumnValue("ContactName", value);
				if (_contact != null) {
					_contact.Name = value;
				}
			}
		}

		private Contact _contact;
		/// <summary>
		/// Контакт.
		/// </summary>
		public Contact Contact {
			get {
				return _contact ??
					(_contact = LookupColumnEntities.GetEntity("Contact") as Contact);
			}
		}

		/// <summary>
		/// Источник.
		/// </summary>
		public string Source {
			get {
				return GetTypedColumnValue<string>("Source");
			}
			set {
				SetColumnValue("Source", value);
			}
		}

		/// <summary>
		/// Тег.
		/// </summary>
		public string Tag {
			get {
				return GetTypedColumnValue<string>("Tag");
			}
			set {
				SetColumnValue("Tag", value);
			}
		}

		/// <exclude/>
		public Guid SiteEventTypeId {
			get {
				return GetTypedColumnValue<Guid>("SiteEventTypeId");
			}
			set {
				SetColumnValue("SiteEventTypeId", value);
				_siteEventType = null;
			}
		}

		/// <exclude/>
		public string SiteEventTypeName {
			get {
				return GetTypedColumnValue<string>("SiteEventTypeName");
			}
			set {
				SetColumnValue("SiteEventTypeName", value);
				if (_siteEventType != null) {
					_siteEventType.Name = value;
				}
			}
		}

		private SiteEventType _siteEventType;
		/// <summary>
		/// Тип события.
		/// </summary>
		public SiteEventType SiteEventType {
			get {
				return _siteEventType ??
					(_siteEventType = LookupColumnEntities.GetEntity("SiteEventType") as SiteEventType);
			}
		}

		/// <exclude/>
		public Guid LeadTypeId {
			get {
				return GetTypedColumnValue<Guid>("LeadTypeId");
			}
			set {
				SetColumnValue("LeadTypeId", value);
				_leadType = null;
			}
		}

		/// <exclude/>
		public string LeadTypeName {
			get {
				return GetTypedColumnValue<string>("LeadTypeName");
			}
			set {
				SetColumnValue("LeadTypeName", value);
				if (_leadType != null) {
					_leadType.Name = value;
				}
			}
		}

		private LeadType _leadType;
		/// <summary>
		/// Тип потребности.
		/// </summary>
		public LeadType LeadType {
			get {
				return _leadType ??
					(_leadType = LookupColumnEntities.GetEntity("LeadType") as LeadType);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SiteEvent_SiteEventEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SiteEvent_SiteEvent_BPMSoftDeleted", e);
			Validating += (s, e) => ThrowEvent("SiteEvent_SiteEvent_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SiteEvent_SiteEvent_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: SiteEvent_SiteEventEventsProcess

	/// <exclude/>
	public partial class SiteEvent_SiteEventEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : SiteEvent_SiteEvent_BPMSoft
	{

		public SiteEvent_SiteEventEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SiteEvent_SiteEventEventsProcess";
			SchemaUId = new Guid("93a880c8-dea8-47d5-9b79-1d7fd8259ca0");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("93a880c8-dea8-47d5-9b79-1d7fd8259ca0");
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

	#region Class: SiteEvent_SiteEventEventsProcess

	/// <exclude/>
	public class SiteEvent_SiteEventEventsProcess : SiteEvent_SiteEventEventsProcess<SiteEvent_SiteEvent_BPMSoft>
	{

		public SiteEvent_SiteEventEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SiteEvent_SiteEventEventsProcess

	public partial class SiteEvent_SiteEventEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

