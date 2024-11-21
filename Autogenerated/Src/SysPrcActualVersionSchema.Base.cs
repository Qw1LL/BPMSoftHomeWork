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

	#region Class: SysPrcActualVersionSchema

	/// <exclude/>
	public class SysPrcActualVersionSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysPrcActualVersionSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysPrcActualVersionSchema(SysPrcActualVersionSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysPrcActualVersionSchema(SysPrcActualVersionSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("8ae8036d-83a8-491c-ae1d-bf2f1b9ff2ee");
			RealUId = new Guid("8ae8036d-83a8-491c-ae1d-bf2f1b9ff2ee");
			Name = "SysPrcActualVersion";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("3949d191-f356-45da-a437-95abb1839b71");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("2d01445a-bdd7-4d32-997d-f7d675a618ec")) == null) {
				Columns.Add(CreateRootVersionSchemaColumn());
			}
			if (Columns.FindByUId(new Guid("1e810c3d-f15c-4511-afc4-6e69f1e6c7a5")) == null) {
				Columns.Add(CreateActualVersionSchemaColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateRootVersionSchemaColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("2d01445a-bdd7-4d32-997d-f7d675a618ec"),
				Name = @"RootVersionSchema",
				ReferenceSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsValueCloneable = false,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("8ae8036d-83a8-491c-ae1d-bf2f1b9ff2ee"),
				ModifiedInSchemaUId = new Guid("8ae8036d-83a8-491c-ae1d-bf2f1b9ff2ee"),
				CreatedInPackageId = new Guid("3949d191-f356-45da-a437-95abb1839b71")
			};
		}

		protected virtual EntitySchemaColumn CreateActualVersionSchemaColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("1e810c3d-f15c-4511-afc4-6e69f1e6c7a5"),
				Name = @"ActualVersionSchema",
				ReferenceSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("8ae8036d-83a8-491c-ae1d-bf2f1b9ff2ee"),
				ModifiedInSchemaUId = new Guid("8ae8036d-83a8-491c-ae1d-bf2f1b9ff2ee"),
				CreatedInPackageId = new Guid("3949d191-f356-45da-a437-95abb1839b71")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysPrcActualVersion(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysPrcActualVersion_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysPrcActualVersionSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysPrcActualVersionSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("8ae8036d-83a8-491c-ae1d-bf2f1b9ff2ee"));
		}

		#endregion

	}

	#endregion

	#region Class: SysPrcActualVersion

	/// <summary>
	/// Actual process version.
	/// </summary>
	public class SysPrcActualVersion : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysPrcActualVersion(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysPrcActualVersion";
		}

		public SysPrcActualVersion(SysPrcActualVersion source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid RootVersionSchemaId {
			get {
				return GetTypedColumnValue<Guid>("RootVersionSchemaId");
			}
			set {
				SetColumnValue("RootVersionSchemaId", value);
				_rootVersionSchema = null;
			}
		}

		/// <exclude/>
		public string RootVersionSchemaCaption {
			get {
				return GetTypedColumnValue<string>("RootVersionSchemaCaption");
			}
			set {
				SetColumnValue("RootVersionSchemaCaption", value);
				if (_rootVersionSchema != null) {
					_rootVersionSchema.Caption = value;
				}
			}
		}

		private SysSchema _rootVersionSchema;
		/// <summary>
		/// Root version.
		/// </summary>
		public SysSchema RootVersionSchema {
			get {
				return _rootVersionSchema ??
					(_rootVersionSchema = LookupColumnEntities.GetEntity("RootVersionSchema") as SysSchema);
			}
		}

		/// <exclude/>
		public Guid ActualVersionSchemaId {
			get {
				return GetTypedColumnValue<Guid>("ActualVersionSchemaId");
			}
			set {
				SetColumnValue("ActualVersionSchemaId", value);
				_actualVersionSchema = null;
			}
		}

		/// <exclude/>
		public string ActualVersionSchemaCaption {
			get {
				return GetTypedColumnValue<string>("ActualVersionSchemaCaption");
			}
			set {
				SetColumnValue("ActualVersionSchemaCaption", value);
				if (_actualVersionSchema != null) {
					_actualVersionSchema.Caption = value;
				}
			}
		}

		private SysSchema _actualVersionSchema;
		/// <summary>
		/// Actual version.
		/// </summary>
		public SysSchema ActualVersionSchema {
			get {
				return _actualVersionSchema ??
					(_actualVersionSchema = LookupColumnEntities.GetEntity("ActualVersionSchema") as SysSchema);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysPrcActualVersion_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysPrcActualVersionDeleted", e);
			Validating += (s, e) => ThrowEvent("SysPrcActualVersionValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysPrcActualVersion(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysPrcActualVersion_BaseEventsProcess

	/// <exclude/>
	public partial class SysPrcActualVersion_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : SysPrcActualVersion
	{

		public SysPrcActualVersion_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysPrcActualVersion_BaseEventsProcess";
			SchemaUId = new Guid("8ae8036d-83a8-491c-ae1d-bf2f1b9ff2ee");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("8ae8036d-83a8-491c-ae1d-bf2f1b9ff2ee");
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

	#region Class: SysPrcActualVersion_BaseEventsProcess

	/// <exclude/>
	public class SysPrcActualVersion_BaseEventsProcess : SysPrcActualVersion_BaseEventsProcess<SysPrcActualVersion>
	{

		public SysPrcActualVersion_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysPrcActualVersion_BaseEventsProcess

	public partial class SysPrcActualVersion_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysPrcActualVersionEventsProcess

	/// <exclude/>
	public class SysPrcActualVersionEventsProcess : SysPrcActualVersion_BaseEventsProcess
	{

		public SysPrcActualVersionEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

