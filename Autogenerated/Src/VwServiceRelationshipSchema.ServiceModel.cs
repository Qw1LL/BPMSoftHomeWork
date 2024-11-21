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

	#region Class: VwServiceRelationshipSchema

	/// <exclude/>
	public class VwServiceRelationshipSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public VwServiceRelationshipSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwServiceRelationshipSchema(VwServiceRelationshipSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwServiceRelationshipSchema(VwServiceRelationshipSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("3708db29-d754-44ad-95ce-aaf09d2a6138");
			RealUId = new Guid("3708db29-d754-44ad-95ce-aaf09d2a6138");
			Name = "VwServiceRelationship";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("2acda023-1ff7-4efb-a488-cbf6ac347a40");
			IsDBView = true;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("b8e4c88a-40bc-45b3-95c2-e86a16b8c171")) == null) {
				Columns.Add(CreateServiceItemAColumn());
			}
			if (Columns.FindByUId(new Guid("084788d9-7402-4915-a184-d2055ec901ca")) == null) {
				Columns.Add(CreateServiceItemBColumn());
			}
			if (Columns.FindByUId(new Guid("2f4c5305-cdf0-42e4-9d80-2771c71a71b5")) == null) {
				Columns.Add(CreateDependencyCategoryColumn());
			}
			if (Columns.FindByUId(new Guid("e366773d-03be-4eda-9610-28e02598f4cb")) == null) {
				Columns.Add(CreateDependencyTypeColumn());
			}
			if (Columns.FindByUId(new Guid("7f69409e-99e2-4124-ba84-5e34db4f5da4")) == null) {
				Columns.Add(CreateDependencyTypeCategoryColumn());
			}
			if (Columns.FindByUId(new Guid("e14c3235-52f9-4667-ae7c-4538c3fff7cb")) == null) {
				Columns.Add(CreateDependencyTypeReverseNameColumn());
			}
			if (Columns.FindByUId(new Guid("77bd3e91-ad4e-4623-90f5-0012628bd25d")) == null) {
				Columns.Add(CreateIsCopyColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.IsValueCloneable = true;
			column.ModifiedInSchemaUId = new Guid("3708db29-d754-44ad-95ce-aaf09d2a6138");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.IsValueCloneable = false;
			column.ModifiedInSchemaUId = new Guid("3708db29-d754-44ad-95ce-aaf09d2a6138");
			return column;
		}

		protected virtual EntitySchemaColumn CreateServiceItemAColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("b8e4c88a-40bc-45b3-95c2-e86a16b8c171"),
				Name = @"ServiceItemA",
				ReferenceSchemaUId = new Guid("c6c44f0a-193e-4b5c-b35e-220a60c06898"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("3708db29-d754-44ad-95ce-aaf09d2a6138"),
				ModifiedInSchemaUId = new Guid("3708db29-d754-44ad-95ce-aaf09d2a6138"),
				CreatedInPackageId = new Guid("2acda023-1ff7-4efb-a488-cbf6ac347a40")
			};
		}

		protected virtual EntitySchemaColumn CreateServiceItemBColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("084788d9-7402-4915-a184-d2055ec901ca"),
				Name = @"ServiceItemB",
				ReferenceSchemaUId = new Guid("c6c44f0a-193e-4b5c-b35e-220a60c06898"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("3708db29-d754-44ad-95ce-aaf09d2a6138"),
				ModifiedInSchemaUId = new Guid("3708db29-d754-44ad-95ce-aaf09d2a6138"),
				CreatedInPackageId = new Guid("2acda023-1ff7-4efb-a488-cbf6ac347a40")
			};
		}

		protected virtual EntitySchemaColumn CreateDependencyCategoryColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("2f4c5305-cdf0-42e4-9d80-2771c71a71b5"),
				Name = @"DependencyCategory",
				ReferenceSchemaUId = new Guid("5624aa9d-ec9a-4ea9-bf68-1059ef974609"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("3708db29-d754-44ad-95ce-aaf09d2a6138"),
				ModifiedInSchemaUId = new Guid("3708db29-d754-44ad-95ce-aaf09d2a6138"),
				CreatedInPackageId = new Guid("2acda023-1ff7-4efb-a488-cbf6ac347a40"),
				IsSimpleLookup = true
			};
		}

		protected virtual EntitySchemaColumn CreateDependencyTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("e366773d-03be-4eda-9610-28e02598f4cb"),
				Name = @"DependencyType",
				ReferenceSchemaUId = new Guid("97de7670-a897-47d4-a2a5-68b9739ef7dc"),
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("3708db29-d754-44ad-95ce-aaf09d2a6138"),
				ModifiedInSchemaUId = new Guid("3708db29-d754-44ad-95ce-aaf09d2a6138"),
				CreatedInPackageId = new Guid("2acda023-1ff7-4efb-a488-cbf6ac347a40"),
				IsSimpleLookup = true
			};
		}

		protected virtual EntitySchemaColumn CreateDependencyTypeCategoryColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("7f69409e-99e2-4124-ba84-5e34db4f5da4"),
				Name = @"DependencyTypeCategory",
				ReferenceSchemaUId = new Guid("5624aa9d-ec9a-4ea9-bf68-1059ef974609"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("3708db29-d754-44ad-95ce-aaf09d2a6138"),
				ModifiedInSchemaUId = new Guid("3708db29-d754-44ad-95ce-aaf09d2a6138"),
				CreatedInPackageId = new Guid("2acda023-1ff7-4efb-a488-cbf6ac347a40")
			};
		}

		protected virtual EntitySchemaColumn CreateDependencyTypeReverseNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("e14c3235-52f9-4667-ae7c-4538c3fff7cb"),
				Name = @"DependencyTypeReverseName",
				CreatedInSchemaUId = new Guid("3708db29-d754-44ad-95ce-aaf09d2a6138"),
				ModifiedInSchemaUId = new Guid("3708db29-d754-44ad-95ce-aaf09d2a6138"),
				CreatedInPackageId = new Guid("2acda023-1ff7-4efb-a488-cbf6ac347a40")
			};
		}

		protected virtual EntitySchemaColumn CreateIsCopyColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("77bd3e91-ad4e-4623-90f5-0012628bd25d"),
				Name = @"IsCopy",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("3708db29-d754-44ad-95ce-aaf09d2a6138"),
				ModifiedInSchemaUId = new Guid("3708db29-d754-44ad-95ce-aaf09d2a6138"),
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
			return new VwServiceRelationship(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwServiceRelationship_ServiceModelEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwServiceRelationshipSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwServiceRelationshipSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("3708db29-d754-44ad-95ce-aaf09d2a6138"));
		}

		#endregion

	}

	#endregion

	#region Class: VwServiceRelationship

	/// <summary>
	/// Связанные сервисы (представление).
	/// </summary>
	public class VwServiceRelationship : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public VwServiceRelationship(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwServiceRelationship";
		}

		public VwServiceRelationship(VwServiceRelationship source)
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

		/// <exclude/>
		public Guid DependencyTypeCategoryId {
			get {
				return GetTypedColumnValue<Guid>("DependencyTypeCategoryId");
			}
			set {
				SetColumnValue("DependencyTypeCategoryId", value);
				_dependencyTypeCategory = null;
			}
		}

		/// <exclude/>
		public string DependencyTypeCategoryName {
			get {
				return GetTypedColumnValue<string>("DependencyTypeCategoryName");
			}
			set {
				SetColumnValue("DependencyTypeCategoryName", value);
				if (_dependencyTypeCategory != null) {
					_dependencyTypeCategory.Name = value;
				}
			}
		}

		private DependencyCategory _dependencyTypeCategory;
		/// <summary>
		/// Категория типа зависимости объектов.
		/// </summary>
		public DependencyCategory DependencyTypeCategory {
			get {
				return _dependencyTypeCategory ??
					(_dependencyTypeCategory = LookupColumnEntities.GetEntity("DependencyTypeCategory") as DependencyCategory);
			}
		}

		/// <summary>
		/// Название обратного типа зависимости.
		/// </summary>
		public string DependencyTypeReverseName {
			get {
				return GetTypedColumnValue<string>("DependencyTypeReverseName");
			}
			set {
				SetColumnValue("DependencyTypeReverseName", value);
			}
		}

		/// <summary>
		/// Копия.
		/// </summary>
		public bool IsCopy {
			get {
				return GetTypedColumnValue<bool>("IsCopy");
			}
			set {
				SetColumnValue("IsCopy", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new VwServiceRelationship_ServiceModelEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("VwServiceRelationshipDeleted", e);
			Validating += (s, e) => ThrowEvent("VwServiceRelationshipValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new VwServiceRelationship(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwServiceRelationship_ServiceModelEventsProcess

	/// <exclude/>
	public partial class VwServiceRelationship_ServiceModelEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : VwServiceRelationship
	{

		public VwServiceRelationship_ServiceModelEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwServiceRelationship_ServiceModelEventsProcess";
			SchemaUId = new Guid("3708db29-d754-44ad-95ce-aaf09d2a6138");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("3708db29-d754-44ad-95ce-aaf09d2a6138");
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

	#region Class: VwServiceRelationship_ServiceModelEventsProcess

	/// <exclude/>
	public class VwServiceRelationship_ServiceModelEventsProcess : VwServiceRelationship_ServiceModelEventsProcess<VwServiceRelationship>
	{

		public VwServiceRelationship_ServiceModelEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VwServiceRelationship_ServiceModelEventsProcess

	public partial class VwServiceRelationship_ServiceModelEventsProcess<TEntity>
	{

		#region Methods: Public

		public override void LocalMessageExecuting(EntityChangeType changeType) {
			var lmHelper = new BPMSoft.Configuration.LocalMessageHelper(this.Entity, UserConnection, changeType);
			lmHelper.CreateLocalMessage();
		}

		#endregion

	}

	#endregion


	#region Class: VwServiceRelationshipEventsProcess

	/// <exclude/>
	public class VwServiceRelationshipEventsProcess : VwServiceRelationship_ServiceModelEventsProcess
	{

		public VwServiceRelationshipEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

