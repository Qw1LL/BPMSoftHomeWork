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

	#region Class: ServiceRelationshipSchema

	/// <exclude/>
	public class ServiceRelationshipSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public ServiceRelationshipSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ServiceRelationshipSchema(ServiceRelationshipSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ServiceRelationshipSchema(ServiceRelationshipSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("118bea13-6a06-4fbe-8485-8a14ef5da205");
			RealUId = new Guid("118bea13-6a06-4fbe-8485-8a14ef5da205");
			Name = "ServiceRelationship";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("2acda023-1ff7-4efb-a488-cbf6ac347a40");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("449209e1-836c-4830-aba9-8a98ff2be04e")) == null) {
				Columns.Add(CreateServiceItemAColumn());
			}
			if (Columns.FindByUId(new Guid("ba2fb605-eb8e-4e7b-9aee-362f194bda8b")) == null) {
				Columns.Add(CreateServiceItemBColumn());
			}
			if (Columns.FindByUId(new Guid("707d3e62-0c80-465e-b924-d02a0f8ae37f")) == null) {
				Columns.Add(CreateDependencyCategoryColumn());
			}
			if (Columns.FindByUId(new Guid("0825deeb-fada-4929-859d-a1ab6fd71ae7")) == null) {
				Columns.Add(CreateDependencyTypeColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateServiceItemAColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("449209e1-836c-4830-aba9-8a98ff2be04e"),
				Name = @"ServiceItemA",
				ReferenceSchemaUId = new Guid("c6c44f0a-193e-4b5c-b35e-220a60c06898"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("118bea13-6a06-4fbe-8485-8a14ef5da205"),
				ModifiedInSchemaUId = new Guid("118bea13-6a06-4fbe-8485-8a14ef5da205"),
				CreatedInPackageId = new Guid("2acda023-1ff7-4efb-a488-cbf6ac347a40")
			};
		}

		protected virtual EntitySchemaColumn CreateServiceItemBColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("ba2fb605-eb8e-4e7b-9aee-362f194bda8b"),
				Name = @"ServiceItemB",
				ReferenceSchemaUId = new Guid("c6c44f0a-193e-4b5c-b35e-220a60c06898"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("118bea13-6a06-4fbe-8485-8a14ef5da205"),
				ModifiedInSchemaUId = new Guid("118bea13-6a06-4fbe-8485-8a14ef5da205"),
				CreatedInPackageId = new Guid("2acda023-1ff7-4efb-a488-cbf6ac347a40")
			};
		}

		protected virtual EntitySchemaColumn CreateDependencyCategoryColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("707d3e62-0c80-465e-b924-d02a0f8ae37f"),
				Name = @"DependencyCategory",
				ReferenceSchemaUId = new Guid("5624aa9d-ec9a-4ea9-bf68-1059ef974609"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("118bea13-6a06-4fbe-8485-8a14ef5da205"),
				ModifiedInSchemaUId = new Guid("118bea13-6a06-4fbe-8485-8a14ef5da205"),
				CreatedInPackageId = new Guid("2acda023-1ff7-4efb-a488-cbf6ac347a40"),
				IsSimpleLookup = true
			};
		}

		protected virtual EntitySchemaColumn CreateDependencyTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("0825deeb-fada-4929-859d-a1ab6fd71ae7"),
				Name = @"DependencyType",
				ReferenceSchemaUId = new Guid("97de7670-a897-47d4-a2a5-68b9739ef7dc"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("118bea13-6a06-4fbe-8485-8a14ef5da205"),
				ModifiedInSchemaUId = new Guid("118bea13-6a06-4fbe-8485-8a14ef5da205"),
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
			return new ServiceRelationship(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ServiceRelationship_ServiceModelEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ServiceRelationshipSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ServiceRelationshipSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("118bea13-6a06-4fbe-8485-8a14ef5da205"));
		}

		#endregion

	}

	#endregion

	#region Class: ServiceRelationship

	/// <summary>
	/// Связанные сервисы.
	/// </summary>
	public class ServiceRelationship : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public ServiceRelationship(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ServiceRelationship";
		}

		public ServiceRelationship(ServiceRelationship source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid ServiceItemAId {
			get {
				return GetTypedColumnValue<Guid>("ServiceItemAId");
			}
			set {
				SetColumnValue("ServiceItemAId", value);
				_serviceItemA = null;
			}
		}

		/// <exclude/>
		public string ServiceItemAName {
			get {
				return GetTypedColumnValue<string>("ServiceItemAName");
			}
			set {
				SetColumnValue("ServiceItemAName", value);
				if (_serviceItemA != null) {
					_serviceItemA.Name = value;
				}
			}
		}

		private ServiceItem _serviceItemA;
		/// <summary>
		/// Сервис А.
		/// </summary>
		public ServiceItem ServiceItemA {
			get {
				return _serviceItemA ??
					(_serviceItemA = LookupColumnEntities.GetEntity("ServiceItemA") as ServiceItem);
			}
		}

		/// <exclude/>
		public Guid ServiceItemBId {
			get {
				return GetTypedColumnValue<Guid>("ServiceItemBId");
			}
			set {
				SetColumnValue("ServiceItemBId", value);
				_serviceItemB = null;
			}
		}

		/// <exclude/>
		public string ServiceItemBName {
			get {
				return GetTypedColumnValue<string>("ServiceItemBName");
			}
			set {
				SetColumnValue("ServiceItemBName", value);
				if (_serviceItemB != null) {
					_serviceItemB.Name = value;
				}
			}
		}

		private ServiceItem _serviceItemB;
		/// <summary>
		/// Сервис Б.
		/// </summary>
		public ServiceItem ServiceItemB {
			get {
				return _serviceItemB ??
					(_serviceItemB = LookupColumnEntities.GetEntity("ServiceItemB") as ServiceItem);
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
			var process = new ServiceRelationship_ServiceModelEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ServiceRelationshipDeleted", e);
			Validating += (s, e) => ThrowEvent("ServiceRelationshipValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ServiceRelationship(this);
		}

		#endregion

	}

	#endregion

	#region Class: ServiceRelationship_ServiceModelEventsProcess

	/// <exclude/>
	public partial class ServiceRelationship_ServiceModelEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : ServiceRelationship
	{

		public ServiceRelationship_ServiceModelEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ServiceRelationship_ServiceModelEventsProcess";
			SchemaUId = new Guid("118bea13-6a06-4fbe-8485-8a14ef5da205");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("118bea13-6a06-4fbe-8485-8a14ef5da205");
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

	#region Class: ServiceRelationship_ServiceModelEventsProcess

	/// <exclude/>
	public class ServiceRelationship_ServiceModelEventsProcess : ServiceRelationship_ServiceModelEventsProcess<ServiceRelationship>
	{

		public ServiceRelationship_ServiceModelEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ServiceRelationship_ServiceModelEventsProcess

	public partial class ServiceRelationship_ServiceModelEventsProcess<TEntity>
	{

		#region Methods: Public

		public override void LocalMessageExecuting(EntityChangeType changeType) {
			var lmHelper = new BPMSoft.Configuration.LocalMessageHelper(this.Entity, UserConnection, changeType);
			lmHelper.CreateLocalMessage();
		}

		#endregion

	}

	#endregion


	#region Class: ServiceRelationshipEventsProcess

	/// <exclude/>
	public class ServiceRelationshipEventsProcess : ServiceRelationship_ServiceModelEventsProcess
	{

		public ServiceRelationshipEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

