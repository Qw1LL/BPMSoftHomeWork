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

	#region Class: ChangeServiceItemSchema

	/// <exclude/>
	public class ChangeServiceItemSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public ChangeServiceItemSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ChangeServiceItemSchema(ChangeServiceItemSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ChangeServiceItemSchema(ChangeServiceItemSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("bbbcff7c-51ff-48c5-a2f4-27e67177e346");
			RealUId = new Guid("bbbcff7c-51ff-48c5-a2f4-27e67177e346");
			Name = "ChangeServiceItem";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("6765f9e4-48b7-413e-ad8c-4edb0a7c067c");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("98af0988-2ac7-40ba-af79-0a90b83e29fd")) == null) {
				Columns.Add(CreateChangeColumn());
			}
			if (Columns.FindByUId(new Guid("f4eb3b27-cacb-45ee-b163-07d4e17fbc40")) == null) {
				Columns.Add(CreateServiceItemColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateChangeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("98af0988-2ac7-40ba-af79-0a90b83e29fd"),
				Name = @"Change",
				ReferenceSchemaUId = new Guid("de5c8d59-d372-407d-8c09-f0523e057e40"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("bbbcff7c-51ff-48c5-a2f4-27e67177e346"),
				ModifiedInSchemaUId = new Guid("bbbcff7c-51ff-48c5-a2f4-27e67177e346"),
				CreatedInPackageId = new Guid("6765f9e4-48b7-413e-ad8c-4edb0a7c067c")
			};
		}

		protected virtual EntitySchemaColumn CreateServiceItemColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("f4eb3b27-cacb-45ee-b163-07d4e17fbc40"),
				Name = @"ServiceItem",
				ReferenceSchemaUId = new Guid("c6c44f0a-193e-4b5c-b35e-220a60c06898"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("bbbcff7c-51ff-48c5-a2f4-27e67177e346"),
				ModifiedInSchemaUId = new Guid("bbbcff7c-51ff-48c5-a2f4-27e67177e346"),
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
			return new ChangeServiceItem(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ChangeServiceItem_ChangeEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ChangeServiceItemSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ChangeServiceItemSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("bbbcff7c-51ff-48c5-a2f4-27e67177e346"));
		}

		#endregion

	}

	#endregion

	#region Class: ChangeServiceItem

	/// <summary>
	/// Сервис изменения.
	/// </summary>
	public class ChangeServiceItem : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public ChangeServiceItem(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ChangeServiceItem";
		}

		public ChangeServiceItem(ChangeServiceItem source)
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
		public Guid ServiceItemId {
			get {
				return GetTypedColumnValue<Guid>("ServiceItemId");
			}
			set {
				SetColumnValue("ServiceItemId", value);
				_serviceItem = null;
			}
		}

		/// <exclude/>
		public string ServiceItemName {
			get {
				return GetTypedColumnValue<string>("ServiceItemName");
			}
			set {
				SetColumnValue("ServiceItemName", value);
				if (_serviceItem != null) {
					_serviceItem.Name = value;
				}
			}
		}

		private ServiceItem _serviceItem;
		/// <summary>
		/// Сервис.
		/// </summary>
		public ServiceItem ServiceItem {
			get {
				return _serviceItem ??
					(_serviceItem = LookupColumnEntities.GetEntity("ServiceItem") as ServiceItem);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ChangeServiceItem_ChangeEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ChangeServiceItemDeleted", e);
			Validating += (s, e) => ThrowEvent("ChangeServiceItemValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ChangeServiceItem(this);
		}

		#endregion

	}

	#endregion

	#region Class: ChangeServiceItem_ChangeEventsProcess

	/// <exclude/>
	public partial class ChangeServiceItem_ChangeEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : ChangeServiceItem
	{

		public ChangeServiceItem_ChangeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ChangeServiceItem_ChangeEventsProcess";
			SchemaUId = new Guid("bbbcff7c-51ff-48c5-a2f4-27e67177e346");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("bbbcff7c-51ff-48c5-a2f4-27e67177e346");
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

	#region Class: ChangeServiceItem_ChangeEventsProcess

	/// <exclude/>
	public class ChangeServiceItem_ChangeEventsProcess : ChangeServiceItem_ChangeEventsProcess<ChangeServiceItem>
	{

		public ChangeServiceItem_ChangeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ChangeServiceItem_ChangeEventsProcess

	public partial class ChangeServiceItem_ChangeEventsProcess<TEntity>
	{

		#region Methods: Public

		public override void LocalMessageExecuting(EntityChangeType changeType) {
			var lmHelper = new BPMSoft.Configuration.LocalMessageHelper(this.Entity, UserConnection, changeType);
			lmHelper.CreateLocalMessage();
		}

		#endregion

	}

	#endregion


	#region Class: ChangeServiceItemEventsProcess

	/// <exclude/>
	public class ChangeServiceItemEventsProcess : ChangeServiceItem_ChangeEventsProcess
	{

		public ChangeServiceItemEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

