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

	#region Class: ServiceInConfItemSchema

	/// <exclude/>
	public class ServiceInConfItemSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public ServiceInConfItemSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ServiceInConfItemSchema(ServiceInConfItemSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ServiceInConfItemSchema(ServiceInConfItemSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("ef0acf4c-0272-4e3b-9391-e12cf13cec33");
			RealUId = new Guid("ef0acf4c-0272-4e3b-9391-e12cf13cec33");
			Name = "ServiceInConfItem";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("4516643a-023b-4e8c-93a2-5f32ae9ffe7d");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("4fdd0a6e-8cc1-4c8c-8c97-b73350649bbb")) == null) {
				Columns.Add(CreateServiceItemColumn());
			}
			if (Columns.FindByUId(new Guid("cf52e41d-0007-463e-9df4-96091daffa73")) == null) {
				Columns.Add(CreateConfItemColumn());
			}
			if (Columns.FindByUId(new Guid("bb0bb68a-4f72-483c-b4d7-66febe2ddcc1")) == null) {
				Columns.Add(CreateDependencyCategoryColumn());
			}
			if (Columns.FindByUId(new Guid("cc92151e-2069-436f-af46-e22d9f6d1332")) == null) {
				Columns.Add(CreateDependencyTypeColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateServiceItemColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("4fdd0a6e-8cc1-4c8c-8c97-b73350649bbb"),
				Name = @"ServiceItem",
				ReferenceSchemaUId = new Guid("c6c44f0a-193e-4b5c-b35e-220a60c06898"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("ef0acf4c-0272-4e3b-9391-e12cf13cec33"),
				ModifiedInSchemaUId = new Guid("ef0acf4c-0272-4e3b-9391-e12cf13cec33"),
				CreatedInPackageId = new Guid("4516643a-023b-4e8c-93a2-5f32ae9ffe7d")
			};
		}

		protected virtual EntitySchemaColumn CreateConfItemColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("cf52e41d-0007-463e-9df4-96091daffa73"),
				Name = @"ConfItem",
				ReferenceSchemaUId = new Guid("ad707075-cf25-40bf-85c1-f5da38cf0d5d"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("ef0acf4c-0272-4e3b-9391-e12cf13cec33"),
				ModifiedInSchemaUId = new Guid("ef0acf4c-0272-4e3b-9391-e12cf13cec33"),
				CreatedInPackageId = new Guid("4516643a-023b-4e8c-93a2-5f32ae9ffe7d")
			};
		}

		protected virtual EntitySchemaColumn CreateDependencyCategoryColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("bb0bb68a-4f72-483c-b4d7-66febe2ddcc1"),
				Name = @"DependencyCategory",
				ReferenceSchemaUId = new Guid("5624aa9d-ec9a-4ea9-bf68-1059ef974609"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("ef0acf4c-0272-4e3b-9391-e12cf13cec33"),
				ModifiedInSchemaUId = new Guid("ef0acf4c-0272-4e3b-9391-e12cf13cec33"),
				CreatedInPackageId = new Guid("4516643a-023b-4e8c-93a2-5f32ae9ffe7d"),
				IsSimpleLookup = true
			};
		}

		protected virtual EntitySchemaColumn CreateDependencyTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("cc92151e-2069-436f-af46-e22d9f6d1332"),
				Name = @"DependencyType",
				ReferenceSchemaUId = new Guid("97de7670-a897-47d4-a2a5-68b9739ef7dc"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("ef0acf4c-0272-4e3b-9391-e12cf13cec33"),
				ModifiedInSchemaUId = new Guid("ef0acf4c-0272-4e3b-9391-e12cf13cec33"),
				CreatedInPackageId = new Guid("2acda023-1ff7-4efb-a488-cbf6ac347a40")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ServiceInConfItem(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ServiceInConfItem_ServiceModelEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ServiceInConfItemSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ServiceInConfItemSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ef0acf4c-0272-4e3b-9391-e12cf13cec33"));
		}

		#endregion

	}

	#endregion

	#region Class: ServiceInConfItem

	/// <summary>
	/// Сервис в конфигурационной единице.
	/// </summary>
	public class ServiceInConfItem : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public ServiceInConfItem(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ServiceInConfItem";
		}

		public ServiceInConfItem(ServiceInConfItem source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

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

		/// <exclude/>
		public Guid DependencyCategoryId {
			get {
				return GetTypedColumnValue<Guid>("DependencyCategoryId");
			}
			set {
				SetColumnValue("DependencyCategoryId", value);
				_dependencyCategory = null;
			}
		}

		/// <exclude/>
		public string DependencyCategoryName {
			get {
				return GetTypedColumnValue<string>("DependencyCategoryName");
			}
			set {
				SetColumnValue("DependencyCategoryName", value);
				if (_dependencyCategory != null) {
					_dependencyCategory.Name = value;
				}
			}
		}

		private DependencyCategory _dependencyCategory;
		/// <summary>
		/// Категория.
		/// </summary>
		public DependencyCategory DependencyCategory {
			get {
				return _dependencyCategory ??
					(_dependencyCategory = LookupColumnEntities.GetEntity("DependencyCategory") as DependencyCategory);
			}
		}

		/// <exclude/>
		public Guid DependencyTypeId {
			get {
				return GetTypedColumnValue<Guid>("DependencyTypeId");
			}
			set {
				SetColumnValue("DependencyTypeId", value);
				_dependencyType = null;
			}
		}

		/// <exclude/>
		public string DependencyTypeName {
			get {
				return GetTypedColumnValue<string>("DependencyTypeName");
			}
			set {
				SetColumnValue("DependencyTypeName", value);
				if (_dependencyType != null) {
					_dependencyType.Name = value;
				}
			}
		}

		private DependencyType _dependencyType;
		/// <summary>
		/// Тип.
		/// </summary>
		public DependencyType DependencyType {
			get {
				return _dependencyType ??
					(_dependencyType = LookupColumnEntities.GetEntity("DependencyType") as DependencyType);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ServiceInConfItem_ServiceModelEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ServiceInConfItemDeleted", e);
			Validating += (s, e) => ThrowEvent("ServiceInConfItemValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ServiceInConfItem(this);
		}

		#endregion

	}

	#endregion

	#region Class: ServiceInConfItem_ServiceModelEventsProcess

	/// <exclude/>
	public partial class ServiceInConfItem_ServiceModelEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : ServiceInConfItem
	{

		public ServiceInConfItem_ServiceModelEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ServiceInConfItem_ServiceModelEventsProcess";
			SchemaUId = new Guid("ef0acf4c-0272-4e3b-9391-e12cf13cec33");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("ef0acf4c-0272-4e3b-9391-e12cf13cec33");
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

	#region Class: ServiceInConfItem_ServiceModelEventsProcess

	/// <exclude/>
	public class ServiceInConfItem_ServiceModelEventsProcess : ServiceInConfItem_ServiceModelEventsProcess<ServiceInConfItem>
	{

		public ServiceInConfItem_ServiceModelEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ServiceInConfItem_ServiceModelEventsProcess

	public partial class ServiceInConfItem_ServiceModelEventsProcess<TEntity>
	{

		#region Methods: Public

		public override void LocalMessageExecuting(EntityChangeType changeType) {
			var lmHelper = new BPMSoft.Configuration.LocalMessageHelper(this.Entity, UserConnection, changeType);
			lmHelper.CreateLocalMessage();
		}

		#endregion

	}

	#endregion


	#region Class: ServiceInConfItemEventsProcess

	/// <exclude/>
	public class ServiceInConfItemEventsProcess : ServiceInConfItem_ServiceModelEventsProcess
	{

		public ServiceInConfItemEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

