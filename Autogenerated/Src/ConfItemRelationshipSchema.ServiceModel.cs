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

	#region Class: ConfItemRelationshipSchema

	/// <exclude/>
	public class ConfItemRelationshipSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public ConfItemRelationshipSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ConfItemRelationshipSchema(ConfItemRelationshipSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ConfItemRelationshipSchema(ConfItemRelationshipSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("8857f5ff-b876-481c-9c05-7d93c08f7704");
			RealUId = new Guid("8857f5ff-b876-481c-9c05-7d93c08f7704");
			Name = "ConfItemRelationship";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("4516643a-023b-4e8c-93a2-5f32ae9ffe7d");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("01612ecc-abf7-4399-af90-6e9e507fd2bd")) == null) {
				Columns.Add(CreateConfItemAColumn());
			}
			if (Columns.FindByUId(new Guid("e1c56d8a-583c-4067-bae7-420eade26979")) == null) {
				Columns.Add(CreateConfItemBColumn());
			}
			if (Columns.FindByUId(new Guid("611377a0-ae64-4d0f-b50e-c15db72bac75")) == null) {
				Columns.Add(CreateDependencyCategoryColumn());
			}
			if (Columns.FindByUId(new Guid("fc83d1eb-1845-4b41-b836-d6b2c8cadf6a")) == null) {
				Columns.Add(CreateDependencyTypeColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateConfItemAColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("01612ecc-abf7-4399-af90-6e9e507fd2bd"),
				Name = @"ConfItemA",
				ReferenceSchemaUId = new Guid("ad707075-cf25-40bf-85c1-f5da38cf0d5d"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("8857f5ff-b876-481c-9c05-7d93c08f7704"),
				ModifiedInSchemaUId = new Guid("8857f5ff-b876-481c-9c05-7d93c08f7704"),
				CreatedInPackageId = new Guid("4516643a-023b-4e8c-93a2-5f32ae9ffe7d")
			};
		}

		protected virtual EntitySchemaColumn CreateConfItemBColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("e1c56d8a-583c-4067-bae7-420eade26979"),
				Name = @"ConfItemB",
				ReferenceSchemaUId = new Guid("ad707075-cf25-40bf-85c1-f5da38cf0d5d"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("8857f5ff-b876-481c-9c05-7d93c08f7704"),
				ModifiedInSchemaUId = new Guid("8857f5ff-b876-481c-9c05-7d93c08f7704"),
				CreatedInPackageId = new Guid("4516643a-023b-4e8c-93a2-5f32ae9ffe7d")
			};
		}

		protected virtual EntitySchemaColumn CreateDependencyCategoryColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("611377a0-ae64-4d0f-b50e-c15db72bac75"),
				Name = @"DependencyCategory",
				ReferenceSchemaUId = new Guid("5624aa9d-ec9a-4ea9-bf68-1059ef974609"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("8857f5ff-b876-481c-9c05-7d93c08f7704"),
				ModifiedInSchemaUId = new Guid("8857f5ff-b876-481c-9c05-7d93c08f7704"),
				CreatedInPackageId = new Guid("4516643a-023b-4e8c-93a2-5f32ae9ffe7d"),
				IsSimpleLookup = true
			};
		}

		protected virtual EntitySchemaColumn CreateDependencyTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("fc83d1eb-1845-4b41-b836-d6b2c8cadf6a"),
				Name = @"DependencyType",
				ReferenceSchemaUId = new Guid("97de7670-a897-47d4-a2a5-68b9739ef7dc"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("8857f5ff-b876-481c-9c05-7d93c08f7704"),
				ModifiedInSchemaUId = new Guid("8857f5ff-b876-481c-9c05-7d93c08f7704"),
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
			return new ConfItemRelationship(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ConfItemRelationship_ServiceModelEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ConfItemRelationshipSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ConfItemRelationshipSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("8857f5ff-b876-481c-9c05-7d93c08f7704"));
		}

		#endregion

	}

	#endregion

	#region Class: ConfItemRelationship

	/// <summary>
	/// Связанные конфигурационные единицы.
	/// </summary>
	public class ConfItemRelationship : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public ConfItemRelationship(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ConfItemRelationship";
		}

		public ConfItemRelationship(ConfItemRelationship source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid ConfItemAId {
			get {
				return GetTypedColumnValue<Guid>("ConfItemAId");
			}
			set {
				SetColumnValue("ConfItemAId", value);
				_confItemA = null;
			}
		}

		/// <exclude/>
		public string ConfItemAName {
			get {
				return GetTypedColumnValue<string>("ConfItemAName");
			}
			set {
				SetColumnValue("ConfItemAName", value);
				if (_confItemA != null) {
					_confItemA.Name = value;
				}
			}
		}

		private ConfItem _confItemA;
		/// <summary>
		/// Конфигурационная единица А.
		/// </summary>
		public ConfItem ConfItemA {
			get {
				return _confItemA ??
					(_confItemA = LookupColumnEntities.GetEntity("ConfItemA") as ConfItem);
			}
		}

		/// <exclude/>
		public Guid ConfItemBId {
			get {
				return GetTypedColumnValue<Guid>("ConfItemBId");
			}
			set {
				SetColumnValue("ConfItemBId", value);
				_confItemB = null;
			}
		}

		/// <exclude/>
		public string ConfItemBName {
			get {
				return GetTypedColumnValue<string>("ConfItemBName");
			}
			set {
				SetColumnValue("ConfItemBName", value);
				if (_confItemB != null) {
					_confItemB.Name = value;
				}
			}
		}

		private ConfItem _confItemB;
		/// <summary>
		/// Конфигурационная единица Б.
		/// </summary>
		public ConfItem ConfItemB {
			get {
				return _confItemB ??
					(_confItemB = LookupColumnEntities.GetEntity("ConfItemB") as ConfItem);
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
			var process = new ConfItemRelationship_ServiceModelEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ConfItemRelationshipDeleted", e);
			Validating += (s, e) => ThrowEvent("ConfItemRelationshipValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ConfItemRelationship(this);
		}

		#endregion

	}

	#endregion

	#region Class: ConfItemRelationship_ServiceModelEventsProcess

	/// <exclude/>
	public partial class ConfItemRelationship_ServiceModelEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : ConfItemRelationship
	{

		public ConfItemRelationship_ServiceModelEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ConfItemRelationship_ServiceModelEventsProcess";
			SchemaUId = new Guid("8857f5ff-b876-481c-9c05-7d93c08f7704");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("8857f5ff-b876-481c-9c05-7d93c08f7704");
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

	#region Class: ConfItemRelationship_ServiceModelEventsProcess

	/// <exclude/>
	public class ConfItemRelationship_ServiceModelEventsProcess : ConfItemRelationship_ServiceModelEventsProcess<ConfItemRelationship>
	{

		public ConfItemRelationship_ServiceModelEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ConfItemRelationship_ServiceModelEventsProcess

	public partial class ConfItemRelationship_ServiceModelEventsProcess<TEntity>
	{

		#region Methods: Public

		public override void LocalMessageExecuting(EntityChangeType changeType) {
			var lmHelper = new BPMSoft.Configuration.LocalMessageHelper(this.Entity, UserConnection, changeType);
			lmHelper.CreateLocalMessage();
		}

		#endregion

	}

	#endregion


	#region Class: ConfItemRelationshipEventsProcess

	/// <exclude/>
	public class ConfItemRelationshipEventsProcess : ConfItemRelationship_ServiceModelEventsProcess
	{

		public ConfItemRelationshipEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

