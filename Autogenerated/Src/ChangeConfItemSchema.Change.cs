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

	#region Class: ChangeConfItemSchema

	/// <exclude/>
	public class ChangeConfItemSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public ChangeConfItemSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ChangeConfItemSchema(ChangeConfItemSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ChangeConfItemSchema(ChangeConfItemSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("ce02c720-1208-4151-b0e6-f3f56cc8ac55");
			RealUId = new Guid("ce02c720-1208-4151-b0e6-f3f56cc8ac55");
			Name = "ChangeConfItem";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("6765f9e4-48b7-413e-ad8c-4edb0a7c067c");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("e28189d5-9cd1-420d-824f-7d030fbc3f74")) == null) {
				Columns.Add(CreateChangeColumn());
			}
			if (Columns.FindByUId(new Guid("3636400f-5747-4ffb-9b7e-d97426ff02f7")) == null) {
				Columns.Add(CreateConfItemColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateChangeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("e28189d5-9cd1-420d-824f-7d030fbc3f74"),
				Name = @"Change",
				ReferenceSchemaUId = new Guid("de5c8d59-d372-407d-8c09-f0523e057e40"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("ce02c720-1208-4151-b0e6-f3f56cc8ac55"),
				ModifiedInSchemaUId = new Guid("ce02c720-1208-4151-b0e6-f3f56cc8ac55"),
				CreatedInPackageId = new Guid("6765f9e4-48b7-413e-ad8c-4edb0a7c067c")
			};
		}

		protected virtual EntitySchemaColumn CreateConfItemColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("3636400f-5747-4ffb-9b7e-d97426ff02f7"),
				Name = @"ConfItem",
				ReferenceSchemaUId = new Guid("ad707075-cf25-40bf-85c1-f5da38cf0d5d"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("ce02c720-1208-4151-b0e6-f3f56cc8ac55"),
				ModifiedInSchemaUId = new Guid("ce02c720-1208-4151-b0e6-f3f56cc8ac55"),
				CreatedInPackageId = new Guid("6765f9e4-48b7-413e-ad8c-4edb0a7c067c")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ChangeConfItem(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ChangeConfItem_ChangeEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ChangeConfItemSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ChangeConfItemSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ce02c720-1208-4151-b0e6-f3f56cc8ac55"));
		}

		#endregion

	}

	#endregion

	#region Class: ChangeConfItem

	/// <summary>
	/// Конфигурационные единицы в изменениях.
	/// </summary>
	public class ChangeConfItem : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public ChangeConfItem(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ChangeConfItem";
		}

		public ChangeConfItem(ChangeConfItem source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid ChangeId {
			get {
				return GetTypedColumnValue<Guid>("ChangeId");
			}
			set {
				SetColumnValue("ChangeId", value);
				_change = null;
			}
		}

		/// <exclude/>
		public string ChangeNumber {
			get {
				return GetTypedColumnValue<string>("ChangeNumber");
			}
			set {
				SetColumnValue("ChangeNumber", value);
				if (_change != null) {
					_change.Number = value;
				}
			}
		}

		private Change _change;
		/// <summary>
		/// Изменение.
		/// </summary>
		public Change Change {
			get {
				return _change ??
					(_change = LookupColumnEntities.GetEntity("Change") as Change);
			}
		}

		/// <exclude/>
		public Guid ConfItemId {
			get {
				return GetTypedColumnValue<Guid>("ConfItemId");
			}
			set {
				SetColumnValue("ConfItemId", value);
				_confItem = null;
			}
		}

		/// <exclude/>
		public string ConfItemName {
			get {
				return GetTypedColumnValue<string>("ConfItemName");
			}
			set {
				SetColumnValue("ConfItemName", value);
				if (_confItem != null) {
					_confItem.Name = value;
				}
			}
		}

		private ConfItem _confItem;
		/// <summary>
		/// Конфигурационная единица.
		/// </summary>
		public ConfItem ConfItem {
			get {
				return _confItem ??
					(_confItem = LookupColumnEntities.GetEntity("ConfItem") as ConfItem);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ChangeConfItem_ChangeEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ChangeConfItemDeleted", e);
			Validating += (s, e) => ThrowEvent("ChangeConfItemValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ChangeConfItem(this);
		}

		#endregion

	}

	#endregion

	#region Class: ChangeConfItem_ChangeEventsProcess

	/// <exclude/>
	public partial class ChangeConfItem_ChangeEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : ChangeConfItem
	{

		public ChangeConfItem_ChangeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ChangeConfItem_ChangeEventsProcess";
			SchemaUId = new Guid("ce02c720-1208-4151-b0e6-f3f56cc8ac55");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("ce02c720-1208-4151-b0e6-f3f56cc8ac55");
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

	#region Class: ChangeConfItem_ChangeEventsProcess

	/// <exclude/>
	public class ChangeConfItem_ChangeEventsProcess : ChangeConfItem_ChangeEventsProcess<ChangeConfItem>
	{

		public ChangeConfItem_ChangeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ChangeConfItem_ChangeEventsProcess

	public partial class ChangeConfItem_ChangeEventsProcess<TEntity>
	{

		#region Methods: Public

		public override void LocalMessageExecuting(EntityChangeType changeType) {
			var lmHelper = new BPMSoft.Configuration.LocalMessageHelper(this.Entity, UserConnection, changeType);
			lmHelper.CreateLocalMessage();
		}

		#endregion

	}

	#endregion


	#region Class: ChangeConfItemEventsProcess

	/// <exclude/>
	public class ChangeConfItemEventsProcess : ChangeConfItem_ChangeEventsProcess
	{

		public ChangeConfItemEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

