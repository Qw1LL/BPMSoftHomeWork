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

	#region Class: DependencyTypeSchema

	/// <exclude/>
	public class DependencyTypeSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public DependencyTypeSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public DependencyTypeSchema(DependencyTypeSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public DependencyTypeSchema(DependencyTypeSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("97de7670-a897-47d4-a2a5-68b9739ef7dc");
			RealUId = new Guid("97de7670-a897-47d4-a2a5-68b9739ef7dc");
			Name = "DependencyType";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("2acda023-1ff7-4efb-a488-cbf6ac347a40");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("4e2ef733-6a97-4295-b422-616f59e2b4b4")) == null) {
				Columns.Add(CreateForServiceServiceColumn());
			}
			if (Columns.FindByUId(new Guid("7e9ad29f-9901-4c8d-8632-f3d62fa33a9e")) == null) {
				Columns.Add(CreateForConfItemConfItemColumn());
			}
			if (Columns.FindByUId(new Guid("bc560ce3-9f4c-4a02-b97c-20efd936723e")) == null) {
				Columns.Add(CreateForServiceConfItemColumn());
			}
			if (Columns.FindByUId(new Guid("f8e623e7-c507-46af-8970-fbd238c9c335")) == null) {
				Columns.Add(CreateReverseTypeNameColumn());
			}
			if (Columns.FindByUId(new Guid("7451be60-b87f-4ee8-88c5-12d503c00ca9")) == null) {
				Columns.Add(CreateDependencyCategoryColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateForServiceServiceColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("4e2ef733-6a97-4295-b422-616f59e2b4b4"),
				Name = @"ForServiceService",
				CreatedInSchemaUId = new Guid("97de7670-a897-47d4-a2a5-68b9739ef7dc"),
				ModifiedInSchemaUId = new Guid("97de7670-a897-47d4-a2a5-68b9739ef7dc"),
				CreatedInPackageId = new Guid("2acda023-1ff7-4efb-a488-cbf6ac347a40")
			};
		}

		protected virtual EntitySchemaColumn CreateForConfItemConfItemColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("7e9ad29f-9901-4c8d-8632-f3d62fa33a9e"),
				Name = @"ForConfItemConfItem",
				CreatedInSchemaUId = new Guid("97de7670-a897-47d4-a2a5-68b9739ef7dc"),
				ModifiedInSchemaUId = new Guid("97de7670-a897-47d4-a2a5-68b9739ef7dc"),
				CreatedInPackageId = new Guid("2acda023-1ff7-4efb-a488-cbf6ac347a40")
			};
		}

		protected virtual EntitySchemaColumn CreateForServiceConfItemColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("bc560ce3-9f4c-4a02-b97c-20efd936723e"),
				Name = @"ForServiceConfItem",
				CreatedInSchemaUId = new Guid("97de7670-a897-47d4-a2a5-68b9739ef7dc"),
				ModifiedInSchemaUId = new Guid("97de7670-a897-47d4-a2a5-68b9739ef7dc"),
				CreatedInPackageId = new Guid("2acda023-1ff7-4efb-a488-cbf6ac347a40")
			};
		}

		protected virtual EntitySchemaColumn CreateReverseTypeNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("f8e623e7-c507-46af-8970-fbd238c9c335"),
				Name = @"ReverseTypeName",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("97de7670-a897-47d4-a2a5-68b9739ef7dc"),
				ModifiedInSchemaUId = new Guid("97de7670-a897-47d4-a2a5-68b9739ef7dc"),
				CreatedInPackageId = new Guid("2acda023-1ff7-4efb-a488-cbf6ac347a40"),
				IsLocalizable = true
			};
		}

		protected virtual EntitySchemaColumn CreateDependencyCategoryColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("7451be60-b87f-4ee8-88c5-12d503c00ca9"),
				Name = @"DependencyCategory",
				ReferenceSchemaUId = new Guid("5624aa9d-ec9a-4ea9-bf68-1059ef974609"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("97de7670-a897-47d4-a2a5-68b9739ef7dc"),
				ModifiedInSchemaUId = new Guid("97de7670-a897-47d4-a2a5-68b9739ef7dc"),
				CreatedInPackageId = new Guid("2acda023-1ff7-4efb-a488-cbf6ac347a40"),
				IsSimpleLookup = true
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new DependencyType(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new DependencyType_ServiceModelEventsProcess(userConnection);
		}

		public override object Clone() {
			return new DependencyTypeSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new DependencyTypeSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("97de7670-a897-47d4-a2a5-68b9739ef7dc"));
		}

		#endregion

	}

	#endregion

	#region Class: DependencyType

	/// <summary>
	/// Тип зависимости объектов.
	/// </summary>
	public class DependencyType : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public DependencyType(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "DependencyType";
		}

		public DependencyType(DependencyType source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Сервис-Сервис.
		/// </summary>
		public bool ForServiceService {
			get {
				return GetTypedColumnValue<bool>("ForServiceService");
			}
			set {
				SetColumnValue("ForServiceService", value);
			}
		}

		/// <summary>
		/// Конфигурация-Конфигурация.
		/// </summary>
		public bool ForConfItemConfItem {
			get {
				return GetTypedColumnValue<bool>("ForConfItemConfItem");
			}
			set {
				SetColumnValue("ForConfItemConfItem", value);
			}
		}

		/// <summary>
		/// Сервис-Конфигурация.
		/// </summary>
		public bool ForServiceConfItem {
			get {
				return GetTypedColumnValue<bool>("ForServiceConfItem");
			}
			set {
				SetColumnValue("ForServiceConfItem", value);
			}
		}

		/// <summary>
		/// Название обратного типа зависимости.
		/// </summary>
		public string ReverseTypeName {
			get {
				return GetTypedColumnValue<string>("ReverseTypeName");
			}
			set {
				SetColumnValue("ReverseTypeName", value);
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

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new DependencyType_ServiceModelEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("DependencyTypeDeleted", e);
			Validating += (s, e) => ThrowEvent("DependencyTypeValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new DependencyType(this);
		}

		#endregion

	}

	#endregion

	#region Class: DependencyType_ServiceModelEventsProcess

	/// <exclude/>
	public partial class DependencyType_ServiceModelEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : DependencyType
	{

		public DependencyType_ServiceModelEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "DependencyType_ServiceModelEventsProcess";
			SchemaUId = new Guid("97de7670-a897-47d4-a2a5-68b9739ef7dc");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("97de7670-a897-47d4-a2a5-68b9739ef7dc");
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

	#region Class: DependencyType_ServiceModelEventsProcess

	/// <exclude/>
	public class DependencyType_ServiceModelEventsProcess : DependencyType_ServiceModelEventsProcess<DependencyType>
	{

		public DependencyType_ServiceModelEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: DependencyType_ServiceModelEventsProcess

	public partial class DependencyType_ServiceModelEventsProcess<TEntity>
	{

		#region Methods: Public

		public override void LocalMessageExecuting(EntityChangeType changeType) {
			var lmHelper = new BPMSoft.Configuration.LocalMessageHelper(this.Entity, UserConnection, changeType);
			lmHelper.CreateLocalMessage();
		}

		#endregion

	}

	#endregion


	#region Class: DependencyTypeEventsProcess

	/// <exclude/>
	public class DependencyTypeEventsProcess : DependencyType_ServiceModelEventsProcess
	{

		public DependencyTypeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

