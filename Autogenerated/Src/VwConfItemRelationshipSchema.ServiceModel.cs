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

	#region Class: VwConfItemRelationshipSchema

	/// <exclude/>
	public class VwConfItemRelationshipSchema : BPMSoft.Configuration.ConfItemRelationshipSchema
	{

		#region Constructors: Public

		public VwConfItemRelationshipSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwConfItemRelationshipSchema(VwConfItemRelationshipSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwConfItemRelationshipSchema(VwConfItemRelationshipSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("65578748-393a-4f5b-a7d7-58bd2f49da66");
			RealUId = new Guid("65578748-393a-4f5b-a7d7-58bd2f49da66");
			Name = "VwConfItemRelationship";
			ParentSchemaUId = new Guid("8857f5ff-b876-481c-9c05-7d93c08f7704");
			ExtendParent = false;
			CreatedInPackageId = new Guid("4516643a-023b-4e8c-93a2-5f32ae9ffe7d");
			IsDBView = true;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("6c1f9b9c-dbda-472c-84a4-ff3cff97e215")) == null) {
				Columns.Add(CreateIsCopyColumn());
			}
			if (Columns.FindByUId(new Guid("5d31fa0e-0297-4690-a668-cc08862638bd")) == null) {
				Columns.Add(CreateDependencyTypeCategoryColumn());
			}
			if (Columns.FindByUId(new Guid("c42c10c3-8b0e-4481-ac0d-3b75c0896a80")) == null) {
				Columns.Add(CreateDependencyTypeReverseNameColumn());
			}
		}

		protected override EntitySchemaColumn CreateDependencyCategoryColumn() {
			EntitySchemaColumn column = base.CreateDependencyCategoryColumn();
			column.RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel;
			column.ModifiedInSchemaUId = new Guid("65578748-393a-4f5b-a7d7-58bd2f49da66");
			return column;
		}

		protected override EntitySchemaColumn CreateDependencyTypeColumn() {
			EntitySchemaColumn column = base.CreateDependencyTypeColumn();
			column.IsSimpleLookup = true;
			column.ModifiedInSchemaUId = new Guid("65578748-393a-4f5b-a7d7-58bd2f49da66");
			return column;
		}

		protected virtual EntitySchemaColumn CreateIsCopyColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("6c1f9b9c-dbda-472c-84a4-ff3cff97e215"),
				Name = @"IsCopy",
				CreatedInSchemaUId = new Guid("65578748-393a-4f5b-a7d7-58bd2f49da66"),
				ModifiedInSchemaUId = new Guid("65578748-393a-4f5b-a7d7-58bd2f49da66"),
				CreatedInPackageId = new Guid("2acda023-1ff7-4efb-a488-cbf6ac347a40")
			};
		}

		protected virtual EntitySchemaColumn CreateDependencyTypeCategoryColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("5d31fa0e-0297-4690-a668-cc08862638bd"),
				Name = @"DependencyTypeCategory",
				ReferenceSchemaUId = new Guid("5624aa9d-ec9a-4ea9-bf68-1059ef974609"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("65578748-393a-4f5b-a7d7-58bd2f49da66"),
				ModifiedInSchemaUId = new Guid("65578748-393a-4f5b-a7d7-58bd2f49da66"),
				CreatedInPackageId = new Guid("2acda023-1ff7-4efb-a488-cbf6ac347a40"),
				IsSimpleLookup = true
			};
		}

		protected virtual EntitySchemaColumn CreateDependencyTypeReverseNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("c42c10c3-8b0e-4481-ac0d-3b75c0896a80"),
				Name = @"DependencyTypeReverseName",
				CreatedInSchemaUId = new Guid("65578748-393a-4f5b-a7d7-58bd2f49da66"),
				ModifiedInSchemaUId = new Guid("65578748-393a-4f5b-a7d7-58bd2f49da66"),
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
			return new VwConfItemRelationship(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwConfItemRelationship_ServiceModelEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwConfItemRelationshipSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwConfItemRelationshipSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("65578748-393a-4f5b-a7d7-58bd2f49da66"));
		}

		#endregion

	}

	#endregion

	#region Class: VwConfItemRelationship

	/// <summary>
	/// Связанные конфигурационные единицы (представление).
	/// </summary>
	public class VwConfItemRelationship : BPMSoft.Configuration.ConfItemRelationship
	{

		#region Constructors: Public

		public VwConfItemRelationship(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwConfItemRelationship";
		}

		public VwConfItemRelationship(VwConfItemRelationship source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Признак копии строки.
		/// </summary>
		public bool IsCopy {
			get {
				return GetTypedColumnValue<bool>("IsCopy");
			}
			set {
				SetColumnValue("IsCopy", value);
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
			var process = new VwConfItemRelationship_ServiceModelEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("VwConfItemRelationshipDeleted", e);
			Validating += (s, e) => ThrowEvent("VwConfItemRelationshipValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new VwConfItemRelationship(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwConfItemRelationship_ServiceModelEventsProcess

	/// <exclude/>
	public partial class VwConfItemRelationship_ServiceModelEventsProcess<TEntity> : BPMSoft.Configuration.ConfItemRelationship_ServiceModelEventsProcess<TEntity> where TEntity : VwConfItemRelationship
	{

		public VwConfItemRelationship_ServiceModelEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwConfItemRelationship_ServiceModelEventsProcess";
			SchemaUId = new Guid("65578748-393a-4f5b-a7d7-58bd2f49da66");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("65578748-393a-4f5b-a7d7-58bd2f49da66");
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

	#region Class: VwConfItemRelationship_ServiceModelEventsProcess

	/// <exclude/>
	public class VwConfItemRelationship_ServiceModelEventsProcess : VwConfItemRelationship_ServiceModelEventsProcess<VwConfItemRelationship>
	{

		public VwConfItemRelationship_ServiceModelEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VwConfItemRelationship_ServiceModelEventsProcess

	public partial class VwConfItemRelationship_ServiceModelEventsProcess<TEntity>
	{

		#region Methods: Public

		public override void LocalMessageExecuting(EntityChangeType changeType) {
			var lmHelper = new BPMSoft.Configuration.LocalMessageHelper(this.Entity, UserConnection, changeType);
			lmHelper.CreateLocalMessage();
		}

		#endregion

	}

	#endregion


	#region Class: VwConfItemRelationshipEventsProcess

	/// <exclude/>
	public class VwConfItemRelationshipEventsProcess : VwConfItemRelationship_ServiceModelEventsProcess
	{

		public VwConfItemRelationshipEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

