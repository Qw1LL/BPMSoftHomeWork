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

	#region Class: SiteEventAttrListItemSchema

	/// <exclude/>
	public class SiteEventAttrListItemSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SiteEventAttrListItemSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SiteEventAttrListItemSchema(SiteEventAttrListItemSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SiteEventAttrListItemSchema(SiteEventAttrListItemSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("0db0c5bb-0ff9-4e93-81a3-30451163dbb8");
			RealUId = new Guid("0db0c5bb-0ff9-4e93-81a3-30451163dbb8");
			Name = "SiteEventAttrListItem";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("2a23e39e-fab7-43e0-a89e-cc22e5c8d6ed");
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
			if (Columns.FindByUId(new Guid("0fd93989-4f70-46a0-9af2-95f1832ae60c")) == null) {
				Columns.Add(CreateSiteEventAttributeColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("0db0c5bb-0ff9-4e93-81a3-30451163dbb8");
			column.CreatedInPackageId = new Guid("2a23e39e-fab7-43e0-a89e-cc22e5c8d6ed");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("0db0c5bb-0ff9-4e93-81a3-30451163dbb8");
			column.CreatedInPackageId = new Guid("2a23e39e-fab7-43e0-a89e-cc22e5c8d6ed");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("0db0c5bb-0ff9-4e93-81a3-30451163dbb8");
			column.CreatedInPackageId = new Guid("2a23e39e-fab7-43e0-a89e-cc22e5c8d6ed");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("0db0c5bb-0ff9-4e93-81a3-30451163dbb8");
			column.CreatedInPackageId = new Guid("2a23e39e-fab7-43e0-a89e-cc22e5c8d6ed");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("0db0c5bb-0ff9-4e93-81a3-30451163dbb8");
			column.CreatedInPackageId = new Guid("2a23e39e-fab7-43e0-a89e-cc22e5c8d6ed");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("0db0c5bb-0ff9-4e93-81a3-30451163dbb8");
			column.CreatedInPackageId = new Guid("2a23e39e-fab7-43e0-a89e-cc22e5c8d6ed");
			return column;
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("284a6b45-06cc-48aa-9026-a4eff5cefdc3"),
				Name = @"Name",
				CreatedInSchemaUId = new Guid("0db0c5bb-0ff9-4e93-81a3-30451163dbb8"),
				ModifiedInSchemaUId = new Guid("0db0c5bb-0ff9-4e93-81a3-30451163dbb8"),
				CreatedInPackageId = new Guid("2a23e39e-fab7-43e0-a89e-cc22e5c8d6ed")
			};
		}

		protected virtual EntitySchemaColumn CreateSiteEventAttributeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("0fd93989-4f70-46a0-9af2-95f1832ae60c"),
				Name = @"SiteEventAttribute",
				ReferenceSchemaUId = new Guid("f65a195e-31b6-4db8-93a8-e7985f482c14"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("0db0c5bb-0ff9-4e93-81a3-30451163dbb8"),
				ModifiedInSchemaUId = new Guid("0db0c5bb-0ff9-4e93-81a3-30451163dbb8"),
				CreatedInPackageId = new Guid("2a23e39e-fab7-43e0-a89e-cc22e5c8d6ed")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SiteEventAttrListItem(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SiteEventAttrListItem_SiteEventEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SiteEventAttrListItemSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SiteEventAttrListItemSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("0db0c5bb-0ff9-4e93-81a3-30451163dbb8"));
		}

		#endregion

	}

	#endregion

	#region Class: SiteEventAttrListItem

	/// <summary>
	/// Значение атрибута события сайта.
	/// </summary>
	public class SiteEventAttrListItem : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SiteEventAttrListItem(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SiteEventAttrListItem";
		}

		public SiteEventAttrListItem(SiteEventAttrListItem source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Название.
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
		public Guid SiteEventAttributeId {
			get {
				return GetTypedColumnValue<Guid>("SiteEventAttributeId");
			}
			set {
				SetColumnValue("SiteEventAttributeId", value);
				_siteEventAttribute = null;
			}
		}

		/// <exclude/>
		public string SiteEventAttributeName {
			get {
				return GetTypedColumnValue<string>("SiteEventAttributeName");
			}
			set {
				SetColumnValue("SiteEventAttributeName", value);
				if (_siteEventAttribute != null) {
					_siteEventAttribute.Name = value;
				}
			}
		}

		private SiteEventAttribute _siteEventAttribute;
		/// <summary>
		/// Атрибут.
		/// </summary>
		public SiteEventAttribute SiteEventAttribute {
			get {
				return _siteEventAttribute ??
					(_siteEventAttribute = LookupColumnEntities.GetEntity("SiteEventAttribute") as SiteEventAttribute);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SiteEventAttrListItem_SiteEventEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SiteEventAttrListItemDeleted", e);
			Validating += (s, e) => ThrowEvent("SiteEventAttrListItemValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SiteEventAttrListItem(this);
		}

		#endregion

	}

	#endregion

	#region Class: SiteEventAttrListItem_SiteEventEventsProcess

	/// <exclude/>
	public partial class SiteEventAttrListItem_SiteEventEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : SiteEventAttrListItem
	{

		public SiteEventAttrListItem_SiteEventEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SiteEventAttrListItem_SiteEventEventsProcess";
			SchemaUId = new Guid("0db0c5bb-0ff9-4e93-81a3-30451163dbb8");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("0db0c5bb-0ff9-4e93-81a3-30451163dbb8");
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

	#region Class: SiteEventAttrListItem_SiteEventEventsProcess

	/// <exclude/>
	public class SiteEventAttrListItem_SiteEventEventsProcess : SiteEventAttrListItem_SiteEventEventsProcess<SiteEventAttrListItem>
	{

		public SiteEventAttrListItem_SiteEventEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SiteEventAttrListItem_SiteEventEventsProcess

	public partial class SiteEventAttrListItem_SiteEventEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SiteEventAttrListItemEventsProcess

	/// <exclude/>
	public class SiteEventAttrListItemEventsProcess : SiteEventAttrListItem_SiteEventEventsProcess
	{

		public SiteEventAttrListItemEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

