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

	#region Class: SysPackageDependencySchema

	/// <exclude/>
	public class SysPackageDependencySchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysPackageDependencySchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysPackageDependencySchema(SysPackageDependencySchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysPackageDependencySchema(SysPackageDependencySchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateIUSysPackageDependencyIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = true
			};
			index.UId = new Guid("ba965c2e-9ac7-42ae-a536-a735885488bd");
			index.Name = "IUSysPackageDependency";
			index.CreatedInSchemaUId = new Guid("16e4e4cb-df27-4968-b6aa-53fb05a4930e");
			index.ModifiedInSchemaUId = new Guid("16e4e4cb-df27-4968-b6aa-53fb05a4930e");
			index.CreatedInPackageId = new Guid("80155737-b02e-45ce-84b4-f0a3630e5d9b");
			EntitySchemaIndexColumn sysPackageIdIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("bc81cbd0-f635-4c94-bb6d-7c262e7168b3"),
				ColumnUId = new Guid("d32e6ee6-285a-42fc-966f-639a4f11155c"),
				CreatedInSchemaUId = new Guid("16e4e4cb-df27-4968-b6aa-53fb05a4930e"),
				ModifiedInSchemaUId = new Guid("16e4e4cb-df27-4968-b6aa-53fb05a4930e"),
				CreatedInPackageId = new Guid("80155737-b02e-45ce-84b4-f0a3630e5d9b"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(sysPackageIdIndexColumn);
			EntitySchemaIndexColumn dependOnPackageIdIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("4c67d57b-f753-4940-abd1-8bd3d0fddffc"),
				ColumnUId = new Guid("cf935ff5-e4ae-4f42-b7ef-2b291f93fc1b"),
				CreatedInSchemaUId = new Guid("16e4e4cb-df27-4968-b6aa-53fb05a4930e"),
				ModifiedInSchemaUId = new Guid("16e4e4cb-df27-4968-b6aa-53fb05a4930e"),
				CreatedInPackageId = new Guid("80155737-b02e-45ce-84b4-f0a3630e5d9b"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(dependOnPackageIdIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("16e4e4cb-df27-4968-b6aa-53fb05a4930e");
			RealUId = new Guid("16e4e4cb-df27-4968-b6aa-53fb05a4930e");
			Name = "SysPackageDependency";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("d32e6ee6-285a-42fc-966f-639a4f11155c")) == null) {
				Columns.Add(CreateSysPackageColumn());
			}
			if (Columns.FindByUId(new Guid("cf935ff5-e4ae-4f42-b7ef-2b291f93fc1b")) == null) {
				Columns.Add(CreateDependOnPackageColumn());
			}
			if (Columns.FindByUId(new Guid("9eb77032-011e-4e09-aace-f6f67de4f121")) == null) {
				Columns.Add(CreateDependOnPackageVersionColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateSysPackageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("d32e6ee6-285a-42fc-966f-639a4f11155c"),
				Name = @"SysPackage",
				ReferenceSchemaUId = new Guid("ca400a85-ec48-4b42-8e50-271929d27871"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("16e4e4cb-df27-4968-b6aa-53fb05a4930e"),
				ModifiedInSchemaUId = new Guid("16e4e4cb-df27-4968-b6aa-53fb05a4930e"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateDependOnPackageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("cf935ff5-e4ae-4f42-b7ef-2b291f93fc1b"),
				Name = @"DependOnPackage",
				ReferenceSchemaUId = new Guid("ca400a85-ec48-4b42-8e50-271929d27871"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("16e4e4cb-df27-4968-b6aa-53fb05a4930e"),
				ModifiedInSchemaUId = new Guid("16e4e4cb-df27-4968-b6aa-53fb05a4930e"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateDependOnPackageVersionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("9eb77032-011e-4e09-aace-f6f67de4f121"),
				Name = @"DependOnPackageVersion",
				CreatedInSchemaUId = new Guid("16e4e4cb-df27-4968-b6aa-53fb05a4930e"),
				ModifiedInSchemaUId = new Guid("16e4e4cb-df27-4968-b6aa-53fb05a4930e"),
				CreatedInPackageId = new Guid("58989fa1-7b3a-4f33-8264-ccd39fc37194")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateIUSysPackageDependencyIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysPackageDependency(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysPackageDependency_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysPackageDependencySchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysPackageDependencySchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("16e4e4cb-df27-4968-b6aa-53fb05a4930e"));
		}

		#endregion

	}

	#endregion

	#region Class: SysPackageDependency

	/// <summary>
	/// Package dependencies.
	/// </summary>
	public class SysPackageDependency : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysPackageDependency(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysPackageDependency";
		}

		public SysPackageDependency(SysPackageDependency source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid SysPackageId {
			get {
				return GetTypedColumnValue<Guid>("SysPackageId");
			}
			set {
				SetColumnValue("SysPackageId", value);
				_sysPackage = null;
			}
		}

		/// <exclude/>
		public string SysPackageName {
			get {
				return GetTypedColumnValue<string>("SysPackageName");
			}
			set {
				SetColumnValue("SysPackageName", value);
				if (_sysPackage != null) {
					_sysPackage.Name = value;
				}
			}
		}

		private SysPackage _sysPackage;
		/// <summary>
		/// Package.
		/// </summary>
		public SysPackage SysPackage {
			get {
				return _sysPackage ??
					(_sysPackage = LookupColumnEntities.GetEntity("SysPackage") as SysPackage);
			}
		}

		/// <exclude/>
		public Guid DependOnPackageId {
			get {
				return GetTypedColumnValue<Guid>("DependOnPackageId");
			}
			set {
				SetColumnValue("DependOnPackageId", value);
				_dependOnPackage = null;
			}
		}

		/// <exclude/>
		public string DependOnPackageName {
			get {
				return GetTypedColumnValue<string>("DependOnPackageName");
			}
			set {
				SetColumnValue("DependOnPackageName", value);
				if (_dependOnPackage != null) {
					_dependOnPackage.Name = value;
				}
			}
		}

		private SysPackage _dependOnPackage;
		/// <summary>
		/// Depends on package.
		/// </summary>
		public SysPackage DependOnPackage {
			get {
				return _dependOnPackage ??
					(_dependOnPackage = LookupColumnEntities.GetEntity("DependOnPackage") as SysPackage);
			}
		}

		/// <summary>
		/// Depends on package version.
		/// </summary>
		public string DependOnPackageVersion {
			get {
				return GetTypedColumnValue<string>("DependOnPackageVersion");
			}
			set {
				SetColumnValue("DependOnPackageVersion", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysPackageDependency_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysPackageDependencyDeleted", e);
			Inserting += (s, e) => ThrowEvent("SysPackageDependencyInserting", e);
			Validating += (s, e) => ThrowEvent("SysPackageDependencyValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysPackageDependency(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysPackageDependency_BaseEventsProcess

	/// <exclude/>
	public partial class SysPackageDependency_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : SysPackageDependency
	{

		public SysPackageDependency_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysPackageDependency_BaseEventsProcess";
			SchemaUId = new Guid("16e4e4cb-df27-4968-b6aa-53fb05a4930e");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("16e4e4cb-df27-4968-b6aa-53fb05a4930e");
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

	#region Class: SysPackageDependency_BaseEventsProcess

	/// <exclude/>
	public class SysPackageDependency_BaseEventsProcess : SysPackageDependency_BaseEventsProcess<SysPackageDependency>
	{

		public SysPackageDependency_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysPackageDependency_BaseEventsProcess

	public partial class SysPackageDependency_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysPackageDependencyEventsProcess

	/// <exclude/>
	public class SysPackageDependencyEventsProcess : SysPackageDependency_BaseEventsProcess
	{

		public SysPackageDependencyEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

