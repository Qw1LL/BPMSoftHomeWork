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

	#region Class: AppWrapperSchema

	/// <exclude/>
	public class AppWrapperSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public AppWrapperSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public AppWrapperSchema(AppWrapperSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public AppWrapperSchema(AppWrapperSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("e8e44543-b124-494a-a61f-002e2692bb3b");
			RealUId = new Guid("e8e44543-b124-494a-a61f-002e2692bb3b");
			Name = "AppWrapper";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("9c7400f1-0695-43fe-9c49-b6941624a4de");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("40f49907-9d50-3b90-e04d-049b6e2fb1dc")) == null) {
				Columns.Add(CreateFileNameColumn());
			}
			if (Columns.FindByUId(new Guid("2bb04e77-357e-b86f-be4c-0d8494a10630")) == null) {
				Columns.Add(CreateContentColumn());
			}
			if (Columns.FindByUId(new Guid("5edb949b-2d3e-abbf-bb60-fc4dcfd02b26")) == null) {
				Columns.Add(CreatePageSchemaUIdColumn());
			}
			if (Columns.FindByUId(new Guid("a2b64605-72c4-39aa-5086-bf01a4e9a5a9")) == null) {
				Columns.Add(CreateAppBuildColumn());
			}
			if (Columns.FindByUId(new Guid("9d1a28f9-157e-da66-67ba-8edf6920c2cb")) == null) {
				Columns.Add(CreateDisplayValueColumn());
			}
			if (Columns.FindByUId(new Guid("9ea25392-6a5e-f023-d473-088df8a62f90")) == null) {
				Columns.Add(CreateUIdColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateFileNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("40f49907-9d50-3b90-e04d-049b6e2fb1dc"),
				Name = @"FileName",
				CreatedInSchemaUId = new Guid("e8e44543-b124-494a-a61f-002e2692bb3b"),
				ModifiedInSchemaUId = new Guid("e8e44543-b124-494a-a61f-002e2692bb3b"),
				CreatedInPackageId = new Guid("9c7400f1-0695-43fe-9c49-b6941624a4de")
			};
		}

		protected virtual EntitySchemaColumn CreateContentColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Binary")) {
				UId = new Guid("2bb04e77-357e-b86f-be4c-0d8494a10630"),
				Name = @"Content",
				CreatedInSchemaUId = new Guid("e8e44543-b124-494a-a61f-002e2692bb3b"),
				ModifiedInSchemaUId = new Guid("e8e44543-b124-494a-a61f-002e2692bb3b"),
				CreatedInPackageId = new Guid("9c7400f1-0695-43fe-9c49-b6941624a4de")
			};
		}

		protected virtual EntitySchemaColumn CreatePageSchemaUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("5edb949b-2d3e-abbf-bb60-fc4dcfd02b26"),
				Name = @"PageSchemaUId",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("e8e44543-b124-494a-a61f-002e2692bb3b"),
				ModifiedInSchemaUId = new Guid("e8e44543-b124-494a-a61f-002e2692bb3b"),
				CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f")
			};
		}

		protected virtual EntitySchemaColumn CreateAppBuildColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("a2b64605-72c4-39aa-5086-bf01a4e9a5a9"),
				Name = @"AppBuild",
				ReferenceSchemaUId = new Guid("1ab6b15a-9bca-4d63-86cd-857f7e534540"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("e8e44543-b124-494a-a61f-002e2692bb3b"),
				ModifiedInSchemaUId = new Guid("e8e44543-b124-494a-a61f-002e2692bb3b"),
				CreatedInPackageId = new Guid("f8e35d47-670b-410c-af82-890d687cab22")
			};
		}

		protected virtual EntitySchemaColumn CreateDisplayValueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("9d1a28f9-157e-da66-67ba-8edf6920c2cb"),
				Name = @"DisplayValue",
				CreatedInSchemaUId = new Guid("e8e44543-b124-494a-a61f-002e2692bb3b"),
				ModifiedInSchemaUId = new Guid("e8e44543-b124-494a-a61f-002e2692bb3b"),
				CreatedInPackageId = new Guid("7caa1191-0432-4e0f-844b-f486a44152ed")
			};
		}

		protected virtual EntitySchemaColumn CreateUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("9ea25392-6a5e-f023-d473-088df8a62f90"),
				Name = @"UId",
				CreatedInSchemaUId = new Guid("e8e44543-b124-494a-a61f-002e2692bb3b"),
				ModifiedInSchemaUId = new Guid("e8e44543-b124-494a-a61f-002e2692bb3b"),
				CreatedInPackageId = new Guid("7caa1191-0432-4e0f-844b-f486a44152ed")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new AppWrapper(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new AppWrapper_AngularDesignerEventsProcess(userConnection);
		}

		public override object Clone() {
			return new AppWrapperSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new AppWrapperSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("e8e44543-b124-494a-a61f-002e2692bb3b"));
		}

		#endregion

	}

	#endregion

	#region Class: AppWrapper

	/// <summary>
	/// AppWrapper.
	/// </summary>
	public class AppWrapper : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public AppWrapper(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "AppWrapper";
		}

		public AppWrapper(AppWrapper source)
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

		public Guid PageSchemaUId {
			get {
				return GetTypedColumnValue<Guid>("PageSchemaUId");
			}
			set {
				SetColumnValue("PageSchemaUId", value);
			}
		}

		/// <exclude/>
		public Guid AppBuildId {
			get {
				return GetTypedColumnValue<Guid>("AppBuildId");
			}
			set {
				SetColumnValue("AppBuildId", value);
				_appBuild = null;
			}
		}

		private AppBuild _appBuild;
		/// <summary>
		/// AppBuild.
		/// </summary>
		public AppBuild AppBuild {
			get {
				return _appBuild ??
					(_appBuild = LookupColumnEntities.GetEntity("AppBuild") as AppBuild);
			}
		}

		/// <summary>
		/// DisplayValue.
		/// </summary>
		public string DisplayValue {
			get {
				return GetTypedColumnValue<string>("DisplayValue");
			}
			set {
				SetColumnValue("DisplayValue", value);
			}
		}

		/// <summary>
		/// UId.
		/// </summary>
		public Guid UId {
			get {
				return GetTypedColumnValue<Guid>("UId");
			}
			set {
				SetColumnValue("UId", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new AppWrapper_AngularDesignerEventsProcess(UserConnection);
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
			return new AppWrapper(this);
		}

		#endregion

	}

	#endregion

	#region Class: AppWrapper_AngularDesignerEventsProcess

	/// <exclude/>
	public partial class AppWrapper_AngularDesignerEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : AppWrapper
	{

		public AppWrapper_AngularDesignerEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "AppWrapper_AngularDesignerEventsProcess";
			SchemaUId = new Guid("e8e44543-b124-494a-a61f-002e2692bb3b");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("e8e44543-b124-494a-a61f-002e2692bb3b");
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

	#region Class: AppWrapper_AngularDesignerEventsProcess

	/// <exclude/>
	public class AppWrapper_AngularDesignerEventsProcess : AppWrapper_AngularDesignerEventsProcess<AppWrapper>
	{

		public AppWrapper_AngularDesignerEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: AppWrapper_AngularDesignerEventsProcess

	public partial class AppWrapper_AngularDesignerEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: AppWrapperEventsProcess

	/// <exclude/>
	public class AppWrapperEventsProcess : AppWrapper_AngularDesignerEventsProcess
	{

		public AppWrapperEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

