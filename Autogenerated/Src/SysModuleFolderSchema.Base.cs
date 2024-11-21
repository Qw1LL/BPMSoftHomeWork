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

	#region Class: SysModuleFolderSchema

	/// <exclude/>
	public class SysModuleFolderSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysModuleFolderSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysModuleFolderSchema(SysModuleFolderSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysModuleFolderSchema(SysModuleFolderSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("88fa8985-5bbd-4975-95b1-51caec10987a");
			RealUId = new Guid("88fa8985-5bbd-4975-95b1-51caec10987a");
			Name = "SysModuleFolder";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateCaptionColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("152f8eaf-18f2-46ee-8e4e-14a67c9e0c55")) == null) {
				Columns.Add(CreateImageColumn());
			}
			if (Columns.FindByUId(new Guid("97407921-8bfb-49da-b017-66b9c02c7235")) == null) {
				Columns.Add(CreatePositionColumn());
			}
			if (Columns.FindByUId(new Guid("a6f040f0-ece5-4688-8c0d-6fcde5d73255")) == null) {
				Columns.Add(CreateParentColumn());
			}
			if (Columns.FindByUId(new Guid("76fc3042-489e-467e-ab73-24e4a452c0b0")) == null) {
				Columns.Add(CreateLocationColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateCaptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("6f045fb2-15d1-4256-831f-256f9ad225a6"),
				Name = @"Caption",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("88fa8985-5bbd-4975-95b1-51caec10987a"),
				ModifiedInSchemaUId = new Guid("88fa8985-5bbd-4975-95b1-51caec10987a"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				IsLocalizable = true
			};
		}

		protected virtual EntitySchemaColumn CreateImageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Image")) {
				UId = new Guid("152f8eaf-18f2-46ee-8e4e-14a67c9e0c55"),
				Name = @"Image",
				CreatedInSchemaUId = new Guid("88fa8985-5bbd-4975-95b1-51caec10987a"),
				ModifiedInSchemaUId = new Guid("88fa8985-5bbd-4975-95b1-51caec10987a"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreatePositionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("97407921-8bfb-49da-b017-66b9c02c7235"),
				Name = @"Position",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("88fa8985-5bbd-4975-95b1-51caec10987a"),
				ModifiedInSchemaUId = new Guid("88fa8985-5bbd-4975-95b1-51caec10987a"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateParentColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("a6f040f0-ece5-4688-8c0d-6fcde5d73255"),
				Name = @"Parent",
				ReferenceSchemaUId = new Guid("5ca90b6a-93e7-4448-befe-ab5166ec2cfe"),
				CreatedInSchemaUId = new Guid("88fa8985-5bbd-4975-95b1-51caec10987a"),
				ModifiedInSchemaUId = new Guid("88fa8985-5bbd-4975-95b1-51caec10987a"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateLocationColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("76fc3042-489e-467e-ab73-24e4a452c0b0"),
				Name = @"Location",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("88fa8985-5bbd-4975-95b1-51caec10987a"),
				ModifiedInSchemaUId = new Guid("88fa8985-5bbd-4975-95b1-51caec10987a"),
				CreatedInPackageId = new Guid("467e8661-453f-46e6-ab9a-2749b5699bb7")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysModuleFolder(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysModuleFolder_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysModuleFolderSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysModuleFolderSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("88fa8985-5bbd-4975-95b1-51caec10987a"));
		}

		#endregion

	}

	#endregion

	#region Class: SysModuleFolder

	/// <summary>
	/// Workplace.
	/// </summary>
	public class SysModuleFolder : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysModuleFolder(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysModuleFolder";
		}

		public SysModuleFolder(SysModuleFolder source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Title.
		/// </summary>
		public string Caption {
			get {
				return GetTypedColumnValue<string>("Caption");
			}
			set {
				SetColumnValue("Caption", value);
			}
		}

		/// <summary>
		/// Position.
		/// </summary>
		public int Position {
			get {
				return GetTypedColumnValue<int>("Position");
			}
			set {
				SetColumnValue("Position", value);
			}
		}

		/// <exclude/>
		public Guid ParentId {
			get {
				return GetTypedColumnValue<Guid>("ParentId");
			}
			set {
				SetColumnValue("ParentId", value);
				_parent = null;
			}
		}

		/// <exclude/>
		public string ParentName {
			get {
				return GetTypedColumnValue<string>("ParentName");
			}
			set {
				SetColumnValue("ParentName", value);
				if (_parent != null) {
					_parent.Name = value;
				}
			}
		}

		private City _parent;
		/// <summary>
		/// Parent.
		/// </summary>
		public City Parent {
			get {
				return _parent ??
					(_parent = LookupColumnEntities.GetEntity("Parent") as City);
			}
		}

		/// <summary>
		/// Location.
		/// </summary>
		public string Location {
			get {
				return GetTypedColumnValue<string>("Location");
			}
			set {
				SetColumnValue("Location", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysModuleFolder_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysModuleFolderDeleted", e);
			Deleting += (s, e) => ThrowEvent("SysModuleFolderDeleting", e);
			Inserted += (s, e) => ThrowEvent("SysModuleFolderInserted", e);
			Inserting += (s, e) => ThrowEvent("SysModuleFolderInserting", e);
			Saved += (s, e) => ThrowEvent("SysModuleFolderSaved", e);
			Saving += (s, e) => ThrowEvent("SysModuleFolderSaving", e);
			Validating += (s, e) => ThrowEvent("SysModuleFolderValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysModuleFolder(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysModuleFolder_BaseEventsProcess

	/// <exclude/>
	public partial class SysModuleFolder_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : SysModuleFolder
	{

		public SysModuleFolder_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysModuleFolder_BaseEventsProcess";
			SchemaUId = new Guid("88fa8985-5bbd-4975-95b1-51caec10987a");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("88fa8985-5bbd-4975-95b1-51caec10987a");
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

	#region Class: SysModuleFolder_BaseEventsProcess

	/// <exclude/>
	public class SysModuleFolder_BaseEventsProcess : SysModuleFolder_BaseEventsProcess<SysModuleFolder>
	{

		public SysModuleFolder_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysModuleFolder_BaseEventsProcess

	public partial class SysModuleFolder_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysModuleFolderEventsProcess

	/// <exclude/>
	public class SysModuleFolderEventsProcess : SysModuleFolder_BaseEventsProcess
	{

		public SysModuleFolderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

