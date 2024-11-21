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

	#region Class: AppBuildSchema

	/// <exclude/>
	public class AppBuildSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public AppBuildSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public AppBuildSchema(AppBuildSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public AppBuildSchema(AppBuildSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("1ab6b15a-9bca-4d63-86cd-857f7e534540");
			RealUId = new Guid("1ab6b15a-9bca-4d63-86cd-857f7e534540");
			Name = "AppBuild";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("9c7400f1-0695-43fe-9c49-b6941624a4de");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("3200c767-fd3f-28a2-a9f9-1f08e5701a34")) == null) {
				Columns.Add(CreateContentColumn());
			}
			if (Columns.FindByUId(new Guid("c97dda78-4b27-87f2-e9b6-93bc914cced5")) == null) {
				Columns.Add(CreateFileNameColumn());
			}
			if (Columns.FindByUId(new Guid("4ace6cb2-e394-96bd-f3ea-8ad2042fe56e")) == null) {
				Columns.Add(CreateSysSchemaColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateContentColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Binary")) {
				UId = new Guid("3200c767-fd3f-28a2-a9f9-1f08e5701a34"),
				Name = @"Content",
				CreatedInSchemaUId = new Guid("1ab6b15a-9bca-4d63-86cd-857f7e534540"),
				ModifiedInSchemaUId = new Guid("1ab6b15a-9bca-4d63-86cd-857f7e534540"),
				CreatedInPackageId = new Guid("9c7400f1-0695-43fe-9c49-b6941624a4de")
			};
		}

		protected virtual EntitySchemaColumn CreateFileNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("c97dda78-4b27-87f2-e9b6-93bc914cced5"),
				Name = @"FileName",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("1ab6b15a-9bca-4d63-86cd-857f7e534540"),
				ModifiedInSchemaUId = new Guid("1ab6b15a-9bca-4d63-86cd-857f7e534540"),
				CreatedInPackageId = new Guid("9c7400f1-0695-43fe-9c49-b6941624a4de")
			};
		}

		protected virtual EntitySchemaColumn CreateSysSchemaColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("4ace6cb2-e394-96bd-f3ea-8ad2042fe56e"),
				Name = @"SysSchema",
				ReferenceSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("1ab6b15a-9bca-4d63-86cd-857f7e534540"),
				ModifiedInSchemaUId = new Guid("1ab6b15a-9bca-4d63-86cd-857f7e534540"),
				CreatedInPackageId = new Guid("f8e35d47-670b-410c-af82-890d687cab22")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new AppBuild(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new AppBuild_AngularDesignerEventsProcess(userConnection);
		}

		public override object Clone() {
			return new AppBuildSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new AppBuildSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("1ab6b15a-9bca-4d63-86cd-857f7e534540"));
		}

		#endregion

	}

	#endregion

	#region Class: AppBuild

	/// <summary>
	/// AppBuild.
	/// </summary>
	public class AppBuild : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public AppBuild(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "AppBuild";
		}

		public AppBuild(AppBuild source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// FileName.
		/// </summary>
		public string FileName {
			get {
				return GetTypedColumnValue<string>("FileName");
			}
			set {
				SetColumnValue("FileName", value);
			}
		}

		/// <exclude/>
		public Guid SysSchemaId {
			get {
				return GetTypedColumnValue<Guid>("SysSchemaId");
			}
			set {
				SetColumnValue("SysSchemaId", value);
				_sysSchema = null;
			}
		}

		/// <exclude/>
		public string SysSchemaCaption {
			get {
				return GetTypedColumnValue<string>("SysSchemaCaption");
			}
			set {
				SetColumnValue("SysSchemaCaption", value);
				if (_sysSchema != null) {
					_sysSchema.Caption = value;
				}
			}
		}

		private SysSchema _sysSchema;
		/// <summary>
		/// SysSchema.
		/// </summary>
		public SysSchema SysSchema {
			get {
				return _sysSchema ??
					(_sysSchema = LookupColumnEntities.GetEntity("SysSchema") as SysSchema);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new AppBuild_AngularDesignerEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new AppBuild(this);
		}

		#endregion

	}

	#endregion

	#region Class: AppBuild_AngularDesignerEventsProcess

	/// <exclude/>
	public partial class AppBuild_AngularDesignerEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : AppBuild
	{

		public AppBuild_AngularDesignerEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "AppBuild_AngularDesignerEventsProcess";
			SchemaUId = new Guid("1ab6b15a-9bca-4d63-86cd-857f7e534540");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("1ab6b15a-9bca-4d63-86cd-857f7e534540");
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

	#region Class: AppBuild_AngularDesignerEventsProcess

	/// <exclude/>
	public class AppBuild_AngularDesignerEventsProcess : AppBuild_AngularDesignerEventsProcess<AppBuild>
	{

		public AppBuild_AngularDesignerEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: AppBuild_AngularDesignerEventsProcess

	public partial class AppBuild_AngularDesignerEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: AppBuildEventsProcess

	/// <exclude/>
	public class AppBuildEventsProcess : AppBuild_AngularDesignerEventsProcess
	{

		public AppBuildEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

