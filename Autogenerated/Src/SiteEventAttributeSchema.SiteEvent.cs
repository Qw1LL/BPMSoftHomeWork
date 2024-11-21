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

	#region Class: SiteEventAttributeSchema

	/// <exclude/>
	public class SiteEventAttributeSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SiteEventAttributeSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SiteEventAttributeSchema(SiteEventAttributeSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SiteEventAttributeSchema(SiteEventAttributeSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("f65a195e-31b6-4db8-93a8-e7985f482c14");
			RealUId = new Guid("f65a195e-31b6-4db8-93a8-e7985f482c14");
			Name = "SiteEventAttribute";
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
			if (Columns.FindByUId(new Guid("b6b6df82-cfa4-4c02-8a75-3ed7eb1e7ce8")) == null) {
				Columns.Add(CreateTypeColumn());
			}
			if (Columns.FindByUId(new Guid("558b3551-e5d6-438f-b64e-8adc56dac7bf")) == null) {
				Columns.Add(CreateDescriptionColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("f65a195e-31b6-4db8-93a8-e7985f482c14");
			column.CreatedInPackageId = new Guid("2a23e39e-fab7-43e0-a89e-cc22e5c8d6ed");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("f65a195e-31b6-4db8-93a8-e7985f482c14");
			column.CreatedInPackageId = new Guid("2a23e39e-fab7-43e0-a89e-cc22e5c8d6ed");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("f65a195e-31b6-4db8-93a8-e7985f482c14");
			column.CreatedInPackageId = new Guid("2a23e39e-fab7-43e0-a89e-cc22e5c8d6ed");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("f65a195e-31b6-4db8-93a8-e7985f482c14");
			column.CreatedInPackageId = new Guid("2a23e39e-fab7-43e0-a89e-cc22e5c8d6ed");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("f65a195e-31b6-4db8-93a8-e7985f482c14");
			column.CreatedInPackageId = new Guid("2a23e39e-fab7-43e0-a89e-cc22e5c8d6ed");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("f65a195e-31b6-4db8-93a8-e7985f482c14");
			column.CreatedInPackageId = new Guid("2a23e39e-fab7-43e0-a89e-cc22e5c8d6ed");
			return column;
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("1ba51632-d95e-42d8-a756-e8bc2fc0bf2e"),
				Name = @"Name",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("f65a195e-31b6-4db8-93a8-e7985f482c14"),
				ModifiedInSchemaUId = new Guid("f65a195e-31b6-4db8-93a8-e7985f482c14"),
				CreatedInPackageId = new Guid("2a23e39e-fab7-43e0-a89e-cc22e5c8d6ed")
			};
		}

		protected virtual EntitySchemaColumn CreateTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("b6b6df82-cfa4-4c02-8a75-3ed7eb1e7ce8"),
				Name = @"Type",
				ReferenceSchemaUId = new Guid("32d760d3-5121-4add-97bb-7f8cf2974b52"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("f65a195e-31b6-4db8-93a8-e7985f482c14"),
				ModifiedInSchemaUId = new Guid("f65a195e-31b6-4db8-93a8-e7985f482c14"),
				CreatedInPackageId = new Guid("2a23e39e-fab7-43e0-a89e-cc22e5c8d6ed")
			};
		}

		protected virtual EntitySchemaColumn CreateDescriptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("558b3551-e5d6-438f-b64e-8adc56dac7bf"),
				Name = @"Description",
				CreatedInSchemaUId = new Guid("f65a195e-31b6-4db8-93a8-e7985f482c14"),
				ModifiedInSchemaUId = new Guid("f65a195e-31b6-4db8-93a8-e7985f482c14"),
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
			return new SiteEventAttribute(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SiteEventAttribute_SiteEventEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SiteEventAttributeSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SiteEventAttributeSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("f65a195e-31b6-4db8-93a8-e7985f482c14"));
		}

		#endregion

	}

	#endregion

	#region Class: SiteEventAttribute

	/// <summary>
	/// Атрибут события сайта.
	/// </summary>
	public class SiteEventAttribute : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SiteEventAttribute(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SiteEventAttribute";
		}

		public SiteEventAttribute(SiteEventAttribute source)
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
		public Guid TypeId {
			get {
				return GetTypedColumnValue<Guid>("TypeId");
			}
			set {
				SetColumnValue("TypeId", value);
				_type = null;
			}
		}

		/// <exclude/>
		public string TypeName {
			get {
				return GetTypedColumnValue<string>("TypeName");
			}
			set {
				SetColumnValue("TypeName", value);
				if (_type != null) {
					_type.Name = value;
				}
			}
		}

		private SiteEventAttributeType _type;
		/// <summary>
		/// Тип значения.
		/// </summary>
		public SiteEventAttributeType Type {
			get {
				return _type ??
					(_type = LookupColumnEntities.GetEntity("Type") as SiteEventAttributeType);
			}
		}

		/// <summary>
		/// Описание.
		/// </summary>
		public string Description {
			get {
				return GetTypedColumnValue<string>("Description");
			}
			set {
				SetColumnValue("Description", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SiteEventAttribute_SiteEventEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SiteEventAttributeDeleted", e);
			Validating += (s, e) => ThrowEvent("SiteEventAttributeValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SiteEventAttribute(this);
		}

		#endregion

	}

	#endregion

	#region Class: SiteEventAttribute_SiteEventEventsProcess

	/// <exclude/>
	public partial class SiteEventAttribute_SiteEventEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : SiteEventAttribute
	{

		public SiteEventAttribute_SiteEventEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SiteEventAttribute_SiteEventEventsProcess";
			SchemaUId = new Guid("f65a195e-31b6-4db8-93a8-e7985f482c14");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("f65a195e-31b6-4db8-93a8-e7985f482c14");
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

	#region Class: SiteEventAttribute_SiteEventEventsProcess

	/// <exclude/>
	public class SiteEventAttribute_SiteEventEventsProcess : SiteEventAttribute_SiteEventEventsProcess<SiteEventAttribute>
	{

		public SiteEventAttribute_SiteEventEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SiteEventAttribute_SiteEventEventsProcess

	public partial class SiteEventAttribute_SiteEventEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SiteEventAttributeEventsProcess

	/// <exclude/>
	public class SiteEventAttributeEventsProcess : SiteEventAttribute_SiteEventEventsProcess
	{

		public SiteEventAttributeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

