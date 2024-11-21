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

	#region Class: VwServiceInConfItemSchema

	/// <exclude/>
	public class VwServiceInConfItemSchema : BPMSoft.Configuration.ServiceInConfItemSchema
	{

		#region Constructors: Public

		public VwServiceInConfItemSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwServiceInConfItemSchema(VwServiceInConfItemSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwServiceInConfItemSchema(VwServiceInConfItemSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("f352fdd7-1847-46e6-a7bc-cd3772b42761");
			RealUId = new Guid("f352fdd7-1847-46e6-a7bc-cd3772b42761");
			Name = "VwServiceInConfItem";
			ParentSchemaUId = new Guid("ef0acf4c-0272-4e3b-9391-e12cf13cec33");
			ExtendParent = false;
			CreatedInPackageId = new Guid("4516643a-023b-4e8c-93a2-5f32ae9ffe7d");
			IsDBView = true;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("582f8b4a-aec6-4bfc-aa4b-6c0752cf9ede")) == null) {
				Columns.Add(CreateDependencyCategoryReverseColumn());
			}
			if (Columns.FindByUId(new Guid("fb18483d-ee4b-4bd2-b0e3-2fc96e3c32f2")) == null) {
				Columns.Add(CreateDependencyTypeCategoryColumn());
			}
			if (Columns.FindByUId(new Guid("70e64548-4af6-4245-88c6-aa88dfc02606")) == null) {
				Columns.Add(CreateDependencyTypeReverseNameColumn());
			}
		}

		protected override EntitySchemaColumn CreateDependencyTypeColumn() {
			EntitySchemaColumn column = base.CreateDependencyTypeColumn();
			column.IsSimpleLookup = true;
			column.ModifiedInSchemaUId = new Guid("f352fdd7-1847-46e6-a7bc-cd3772b42761");
			return column;
		}

		protected virtual EntitySchemaColumn CreateDependencyCategoryReverseColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("582f8b4a-aec6-4bfc-aa4b-6c0752cf9ede"),
				Name = @"DependencyCategoryReverse",
				ReferenceSchemaUId = new Guid("5624aa9d-ec9a-4ea9-bf68-1059ef974609"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("f352fdd7-1847-46e6-a7bc-cd3772b42761"),
				ModifiedInSchemaUId = new Guid("f352fdd7-1847-46e6-a7bc-cd3772b42761"),
				CreatedInPackageId = new Guid("4516643a-023b-4e8c-93a2-5f32ae9ffe7d"),
				IsSimpleLookup = true
			};
		}

		protected virtual EntitySchemaColumn CreateDependencyTypeCategoryColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("fb18483d-ee4b-4bd2-b0e3-2fc96e3c32f2"),
				Name = @"DependencyTypeCategory",
				ReferenceSchemaUId = new Guid("5624aa9d-ec9a-4ea9-bf68-1059ef974609"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("f352fdd7-1847-46e6-a7bc-cd3772b42761"),
				ModifiedInSchemaUId = new Guid("f352fdd7-1847-46e6-a7bc-cd3772b42761"),
				CreatedInPackageId = new Guid("2acda023-1ff7-4efb-a488-cbf6ac347a40")
			};
		}

		protected virtual EntitySchemaColumn CreateDependencyTypeReverseNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("70e64548-4af6-4245-88c6-aa88dfc02606"),
				Name = @"DependencyTypeReverseName",
				CreatedInSchemaUId = new Guid("f352fdd7-1847-46e6-a7bc-cd3772b42761"),
				ModifiedInSchemaUId = new Guid("f352fdd7-1847-46e6-a7bc-cd3772b42761"),
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
			return new VwServiceInConfItem(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwServiceInConfItem_ServiceModelEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwServiceInConfItemSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwServiceInConfItemSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("f352fdd7-1847-46e6-a7bc-cd3772b42761"));
		}

		#endregion

	}

	#endregion

	#region Class: VwServiceInConfItem

	/// <summary>
	/// Сервис в конфигурационной единице (представление).
	/// </summary>
	public class VwServiceInConfItem : BPMSoft.Configuration.ServiceInConfItem
	{

		#region Constructors: Public

		public VwServiceInConfItem(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwServiceInConfItem";
		}

		public VwServiceInConfItem(VwServiceInConfItem source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid DependencyCategoryReverseId {
			get {
				return GetTypedColumnValue<Guid>("DependencyCategoryReverseId");
			}
			set {
				SetColumnValue("DependencyCategoryReverseId", value);
				_dependencyCategoryReverse = null;
			}
		}

		/// <exclude/>
		public string DependencyCategoryReverseName {
			get {
				return GetTypedColumnValue<string>("DependencyCategoryReverseName");
			}
			set {
				SetColumnValue("DependencyCategoryReverseName", value);
				if (_dependencyCategoryReverse != null) {
					_dependencyCategoryReverse.Name = value;
				}
			}
		}

		private DependencyCategory _dependencyCategoryReverse;
		/// <summary>
		/// Обратная категория.
		/// </summary>
		public DependencyCategory DependencyCategoryReverse {
			get {
				return _dependencyCategoryReverse ??
					(_dependencyCategoryReverse = LookupColumnEntities.GetEntity("DependencyCategoryReverse") as DependencyCategory);
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

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new VwServiceInConfItem_ServiceModelEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("VwServiceInConfItemDeleted", e);
			Validating += (s, e) => ThrowEvent("VwServiceInConfItemValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new VwServiceInConfItem(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwServiceInConfItem_ServiceModelEventsProcess

	/// <exclude/>
	public partial class VwServiceInConfItem_ServiceModelEventsProcess<TEntity> : BPMSoft.Configuration.ServiceInConfItem_ServiceModelEventsProcess<TEntity> where TEntity : VwServiceInConfItem
	{

		public VwServiceInConfItem_ServiceModelEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwServiceInConfItem_ServiceModelEventsProcess";
			SchemaUId = new Guid("f352fdd7-1847-46e6-a7bc-cd3772b42761");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("f352fdd7-1847-46e6-a7bc-cd3772b42761");
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

	#region Class: VwServiceInConfItem_ServiceModelEventsProcess

	/// <exclude/>
	public class VwServiceInConfItem_ServiceModelEventsProcess : VwServiceInConfItem_ServiceModelEventsProcess<VwServiceInConfItem>
	{

		public VwServiceInConfItem_ServiceModelEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VwServiceInConfItem_ServiceModelEventsProcess

	public partial class VwServiceInConfItem_ServiceModelEventsProcess<TEntity>
	{

		#region Methods: Public

		public override void LocalMessageExecuting(EntityChangeType changeType) {
			var lmHelper = new BPMSoft.Configuration.LocalMessageHelper(this.Entity, UserConnection, changeType);
			lmHelper.CreateLocalMessage();
		}

		#endregion

	}

	#endregion


	#region Class: VwServiceInConfItemEventsProcess

	/// <exclude/>
	public class VwServiceInConfItemEventsProcess : VwServiceInConfItem_ServiceModelEventsProcess
	{

		public VwServiceInConfItemEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

