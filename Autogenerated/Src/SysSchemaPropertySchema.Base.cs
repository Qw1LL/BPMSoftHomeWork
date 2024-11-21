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

	#region Class: SysSchemaPropertySchema

	/// <exclude/>
	public class SysSchemaPropertySchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysSchemaPropertySchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysSchemaPropertySchema(SysSchemaPropertySchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysSchemaPropertySchema(SysSchemaPropertySchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("477e2c73-d48b-4a5d-9a46-d1ee851f1bde");
			RealUId = new Guid("477e2c73-d48b-4a5d-9a46-d1ee851f1bde");
			Name = "SysSchemaProperty";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("0903f9a6-9359-4827-87a5-bf44e36cd1a8")) == null) {
				Columns.Add(CreateNameColumn());
			}
			if (Columns.FindByUId(new Guid("c7c1ddcb-43be-4bdc-a986-3f87cc4e6f6d")) == null) {
				Columns.Add(CreateValueColumn());
			}
			if (Columns.FindByUId(new Guid("35e93a15-f107-4d17-a719-d0f8c6649531")) == null) {
				Columns.Add(CreateSysSchemaColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("0903f9a6-9359-4827-87a5-bf44e36cd1a8"),
				Name = @"Name",
				CreatedInSchemaUId = new Guid("477e2c73-d48b-4a5d-9a46-d1ee851f1bde"),
				ModifiedInSchemaUId = new Guid("477e2c73-d48b-4a5d-9a46-d1ee851f1bde"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateValueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("c7c1ddcb-43be-4bdc-a986-3f87cc4e6f6d"),
				Name = @"Value",
				CreatedInSchemaUId = new Guid("477e2c73-d48b-4a5d-9a46-d1ee851f1bde"),
				ModifiedInSchemaUId = new Guid("477e2c73-d48b-4a5d-9a46-d1ee851f1bde"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateSysSchemaColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("35e93a15-f107-4d17-a719-d0f8c6649531"),
				Name = @"SysSchema",
				ReferenceSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("477e2c73-d48b-4a5d-9a46-d1ee851f1bde"),
				ModifiedInSchemaUId = new Guid("477e2c73-d48b-4a5d-9a46-d1ee851f1bde"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysSchemaProperty(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysSchemaProperty_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysSchemaPropertySchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysSchemaPropertySchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("477e2c73-d48b-4a5d-9a46-d1ee851f1bde"));
		}

		#endregion

	}

	#endregion

	#region Class: SysSchemaProperty

	/// <summary>
	/// Schema property.
	/// </summary>
	public class SysSchemaProperty : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysSchemaProperty(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysSchemaProperty";
		}

		public SysSchemaProperty(SysSchemaProperty source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Name.
		/// </summary>
		public string Name {
			get {
				return GetTypedColumnValue<string>("Name");
			}
			set {
				SetColumnValue("Name", value);
			}
		}

		/// <summary>
		/// Value.
		/// </summary>
		public string Value {
			get {
				return GetTypedColumnValue<string>("Value");
			}
			set {
				SetColumnValue("Value", value);
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
		/// Schema.
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
			var process = new SysSchemaProperty_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysSchemaPropertyDeleted", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysSchemaProperty(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysSchemaProperty_BaseEventsProcess

	/// <exclude/>
	public partial class SysSchemaProperty_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : SysSchemaProperty
	{

		public SysSchemaProperty_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysSchemaProperty_BaseEventsProcess";
			SchemaUId = new Guid("477e2c73-d48b-4a5d-9a46-d1ee851f1bde");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("477e2c73-d48b-4a5d-9a46-d1ee851f1bde");
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

	#region Class: SysSchemaProperty_BaseEventsProcess

	/// <exclude/>
	public class SysSchemaProperty_BaseEventsProcess : SysSchemaProperty_BaseEventsProcess<SysSchemaProperty>
	{

		public SysSchemaProperty_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysSchemaProperty_BaseEventsProcess

	public partial class SysSchemaProperty_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysSchemaPropertyEventsProcess

	/// <exclude/>
	public class SysSchemaPropertyEventsProcess : SysSchemaProperty_BaseEventsProcess
	{

		public SysSchemaPropertyEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

