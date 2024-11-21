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

	#region Class: SpecificationListItemSchema

	/// <exclude/>
	public class SpecificationListItemSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SpecificationListItemSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SpecificationListItemSchema(SpecificationListItemSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SpecificationListItemSchema(SpecificationListItemSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("99bb0a66-4041-4261-a6f2-f37806ba3f65");
			RealUId = new Guid("99bb0a66-4041-4261-a6f2-f37806ba3f65");
			Name = "SpecificationListItem";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("caa0a55b-ca92-4b47-9a26-59cfe4fac97e");
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
			if (Columns.FindByUId(new Guid("7104983f-4e78-4adf-9720-14f8a09b9552")) == null) {
				Columns.Add(CreateSpecificationColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("99bb0a66-4041-4261-a6f2-f37806ba3f65");
			column.CreatedInPackageId = new Guid("caa0a55b-ca92-4b47-9a26-59cfe4fac97e");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("99bb0a66-4041-4261-a6f2-f37806ba3f65");
			column.CreatedInPackageId = new Guid("caa0a55b-ca92-4b47-9a26-59cfe4fac97e");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("99bb0a66-4041-4261-a6f2-f37806ba3f65");
			column.CreatedInPackageId = new Guid("caa0a55b-ca92-4b47-9a26-59cfe4fac97e");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("99bb0a66-4041-4261-a6f2-f37806ba3f65");
			column.CreatedInPackageId = new Guid("caa0a55b-ca92-4b47-9a26-59cfe4fac97e");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("99bb0a66-4041-4261-a6f2-f37806ba3f65");
			column.CreatedInPackageId = new Guid("caa0a55b-ca92-4b47-9a26-59cfe4fac97e");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("99bb0a66-4041-4261-a6f2-f37806ba3f65");
			column.CreatedInPackageId = new Guid("caa0a55b-ca92-4b47-9a26-59cfe4fac97e");
			return column;
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("60055368-3d68-4aea-ab71-1fce0acd881a"),
				Name = @"Name",
				CreatedInSchemaUId = new Guid("99bb0a66-4041-4261-a6f2-f37806ba3f65"),
				ModifiedInSchemaUId = new Guid("99bb0a66-4041-4261-a6f2-f37806ba3f65"),
				CreatedInPackageId = new Guid("caa0a55b-ca92-4b47-9a26-59cfe4fac97e"),
				IsLocalizable = true
			};
		}

		protected virtual EntitySchemaColumn CreateSpecificationColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("7104983f-4e78-4adf-9720-14f8a09b9552"),
				Name = @"Specification",
				ReferenceSchemaUId = new Guid("ec3cebc4-ea18-40ea-9b0f-e348570481ef"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("99bb0a66-4041-4261-a6f2-f37806ba3f65"),
				ModifiedInSchemaUId = new Guid("99bb0a66-4041-4261-a6f2-f37806ba3f65"),
				CreatedInPackageId = new Guid("caa0a55b-ca92-4b47-9a26-59cfe4fac97e")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SpecificationListItem(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SpecificationListItem_SpecificationEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SpecificationListItemSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SpecificationListItemSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("99bb0a66-4041-4261-a6f2-f37806ba3f65"));
		}

		#endregion

	}

	#endregion

	#region Class: SpecificationListItem

	/// <summary>
	/// Значение характеристики.
	/// </summary>
	public class SpecificationListItem : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SpecificationListItem(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SpecificationListItem";
		}

		public SpecificationListItem(SpecificationListItem source)
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
		public Guid SpecificationId {
			get {
				return GetTypedColumnValue<Guid>("SpecificationId");
			}
			set {
				SetColumnValue("SpecificationId", value);
				_specification = null;
			}
		}

		/// <exclude/>
		public string SpecificationName {
			get {
				return GetTypedColumnValue<string>("SpecificationName");
			}
			set {
				SetColumnValue("SpecificationName", value);
				if (_specification != null) {
					_specification.Name = value;
				}
			}
		}

		private Specification _specification;
		/// <summary>
		/// Характеристика.
		/// </summary>
		public Specification Specification {
			get {
				return _specification ??
					(_specification = LookupColumnEntities.GetEntity("Specification") as Specification);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SpecificationListItem_SpecificationEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SpecificationListItemDeleted", e);
			Inserting += (s, e) => ThrowEvent("SpecificationListItemInserting", e);
			Validating += (s, e) => ThrowEvent("SpecificationListItemValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SpecificationListItem(this);
		}

		#endregion

	}

	#endregion

	#region Class: SpecificationListItem_SpecificationEventsProcess

	/// <exclude/>
	public partial class SpecificationListItem_SpecificationEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : SpecificationListItem
	{

		public SpecificationListItem_SpecificationEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SpecificationListItem_SpecificationEventsProcess";
			SchemaUId = new Guid("99bb0a66-4041-4261-a6f2-f37806ba3f65");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("99bb0a66-4041-4261-a6f2-f37806ba3f65");
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

	#region Class: SpecificationListItem_SpecificationEventsProcess

	/// <exclude/>
	public class SpecificationListItem_SpecificationEventsProcess : SpecificationListItem_SpecificationEventsProcess<SpecificationListItem>
	{

		public SpecificationListItem_SpecificationEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SpecificationListItem_SpecificationEventsProcess

	public partial class SpecificationListItem_SpecificationEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SpecificationListItemEventsProcess

	/// <exclude/>
	public class SpecificationListItemEventsProcess : SpecificationListItem_SpecificationEventsProcess
	{

		public SpecificationListItemEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

