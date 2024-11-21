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

	#region Class: ReleaseServiceItemSchema

	/// <exclude/>
	public class ReleaseServiceItemSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public ReleaseServiceItemSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ReleaseServiceItemSchema(ReleaseServiceItemSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ReleaseServiceItemSchema(ReleaseServiceItemSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("43f60faf-ee53-4424-8ec9-f66108a3a590");
			RealUId = new Guid("43f60faf-ee53-4424-8ec9-f66108a3a590");
			Name = "ReleaseServiceItem";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("8f6c7b14-ae87-449c-8189-cf99b9eef0e5");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("228e1fda-e928-4c5c-80d3-7bbf56432d6f")) == null) {
				Columns.Add(CreateReleaseColumn());
			}
			if (Columns.FindByUId(new Guid("48583067-b44e-4c0a-9c6a-75f465f73778")) == null) {
				Columns.Add(CreateServiceItemColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateReleaseColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("228e1fda-e928-4c5c-80d3-7bbf56432d6f"),
				Name = @"Release",
				ReferenceSchemaUId = new Guid("0bf3a274-e5da-4fc7-94c4-3ae233598714"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("43f60faf-ee53-4424-8ec9-f66108a3a590"),
				ModifiedInSchemaUId = new Guid("43f60faf-ee53-4424-8ec9-f66108a3a590"),
				CreatedInPackageId = new Guid("8f6c7b14-ae87-449c-8189-cf99b9eef0e5")
			};
		}

		protected virtual EntitySchemaColumn CreateServiceItemColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("48583067-b44e-4c0a-9c6a-75f465f73778"),
				Name = @"ServiceItem",
				ReferenceSchemaUId = new Guid("c6c44f0a-193e-4b5c-b35e-220a60c06898"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("43f60faf-ee53-4424-8ec9-f66108a3a590"),
				ModifiedInSchemaUId = new Guid("43f60faf-ee53-4424-8ec9-f66108a3a590"),
				CreatedInPackageId = new Guid("8f6c7b14-ae87-449c-8189-cf99b9eef0e5")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ReleaseServiceItem(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ReleaseServiceItem_ReleaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ReleaseServiceItemSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ReleaseServiceItemSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("43f60faf-ee53-4424-8ec9-f66108a3a590"));
		}

		#endregion

	}

	#endregion

	#region Class: ReleaseServiceItem

	/// <summary>
	/// Сервис релиза.
	/// </summary>
	public class ReleaseServiceItem : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public ReleaseServiceItem(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ReleaseServiceItem";
		}

		public ReleaseServiceItem(ReleaseServiceItem source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid ReleaseId {
			get {
				return GetTypedColumnValue<Guid>("ReleaseId");
			}
			set {
				SetColumnValue("ReleaseId", value);
				_release = null;
			}
		}

		/// <exclude/>
		public string ReleaseNumber {
			get {
				return GetTypedColumnValue<string>("ReleaseNumber");
			}
			set {
				SetColumnValue("ReleaseNumber", value);
				if (_release != null) {
					_release.Number = value;
				}
			}
		}

		private Release _release;
		/// <summary>
		/// Релиз.
		/// </summary>
		public Release Release {
			get {
				return _release ??
					(_release = LookupColumnEntities.GetEntity("Release") as Release);
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
			var process = new ReleaseServiceItem_ReleaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ReleaseServiceItemDeleted", e);
			Validating += (s, e) => ThrowEvent("ReleaseServiceItemValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ReleaseServiceItem(this);
		}

		#endregion

	}

	#endregion

	#region Class: ReleaseServiceItem_ReleaseEventsProcess

	/// <exclude/>
	public partial class ReleaseServiceItem_ReleaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : ReleaseServiceItem
	{

		public ReleaseServiceItem_ReleaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ReleaseServiceItem_ReleaseEventsProcess";
			SchemaUId = new Guid("43f60faf-ee53-4424-8ec9-f66108a3a590");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("43f60faf-ee53-4424-8ec9-f66108a3a590");
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

	#region Class: ReleaseServiceItem_ReleaseEventsProcess

	/// <exclude/>
	public class ReleaseServiceItem_ReleaseEventsProcess : ReleaseServiceItem_ReleaseEventsProcess<ReleaseServiceItem>
	{

		public ReleaseServiceItem_ReleaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ReleaseServiceItem_ReleaseEventsProcess

	public partial class ReleaseServiceItem_ReleaseEventsProcess<TEntity>
	{

		#region Methods: Public

		public override void LocalMessageExecuting(EntityChangeType changeType) {
			var lmHelper = new BPMSoft.Configuration.LocalMessageHelper(this.Entity, UserConnection, changeType);
			lmHelper.CreateLocalMessage();
		}

		#endregion

	}

	#endregion


	#region Class: ReleaseServiceItemEventsProcess

	/// <exclude/>
	public class ReleaseServiceItemEventsProcess : ReleaseServiceItem_ReleaseEventsProcess
	{

		public ReleaseServiceItemEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

