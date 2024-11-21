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

	#region Class: TimelineTileSettingSchema

	/// <exclude/>
	public class TimelineTileSettingSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public TimelineTileSettingSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public TimelineTileSettingSchema(TimelineTileSettingSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public TimelineTileSettingSchema(TimelineTileSettingSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("d17a3a86-aa8a-4aea-8c3a-cda031f871bd");
			RealUId = new Guid("d17a3a86-aa8a-4aea-8c3a-cda031f871bd");
			Name = "TimelineTileSetting";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("04616156-81b0-4bd8-a77a-6f9ebf8f30a2");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateNameColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializePrimaryImageColumn() {
			base.InitializePrimaryImageColumn();
			PrimaryImageColumn = CreateImageColumn();
			if (Columns.FindByUId(PrimaryImageColumn.UId) == null) {
				Columns.Add(PrimaryImageColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("918342e9-dcff-4929-87f3-d9b49261f5e3")) == null) {
				Columns.Add(CreateDataColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("f83c3cc5-20ec-402b-94ad-2fb679b7c388"),
				Name = @"Name",
				CreatedInSchemaUId = new Guid("d17a3a86-aa8a-4aea-8c3a-cda031f871bd"),
				ModifiedInSchemaUId = new Guid("d17a3a86-aa8a-4aea-8c3a-cda031f871bd"),
				CreatedInPackageId = new Guid("04616156-81b0-4bd8-a77a-6f9ebf8f30a2"),
				IsLocalizable = true
			};
		}

		protected virtual EntitySchemaColumn CreateDataColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Binary")) {
				UId = new Guid("918342e9-dcff-4929-87f3-d9b49261f5e3"),
				Name = @"Data",
				CreatedInSchemaUId = new Guid("d17a3a86-aa8a-4aea-8c3a-cda031f871bd"),
				ModifiedInSchemaUId = new Guid("d17a3a86-aa8a-4aea-8c3a-cda031f871bd"),
				CreatedInPackageId = new Guid("04616156-81b0-4bd8-a77a-6f9ebf8f30a2")
			};
		}

		protected virtual EntitySchemaColumn CreateImageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Image")) {
				UId = new Guid("4adcf165-ec1c-4f2e-854c-462d2d8e6386"),
				Name = @"Image",
				CreatedInSchemaUId = new Guid("d17a3a86-aa8a-4aea-8c3a-cda031f871bd"),
				ModifiedInSchemaUId = new Guid("d17a3a86-aa8a-4aea-8c3a-cda031f871bd"),
				CreatedInPackageId = new Guid("04616156-81b0-4bd8-a77a-6f9ebf8f30a2")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new TimelineTileSetting(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new TimelineTileSetting_TimelineEventsProcess(userConnection);
		}

		public override object Clone() {
			return new TimelineTileSettingSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new TimelineTileSettingSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("d17a3a86-aa8a-4aea-8c3a-cda031f871bd"));
		}

		#endregion

	}

	#endregion

	#region Class: TimelineTileSetting

	/// <summary>
	/// Timeline tile setting.
	/// </summary>
	public class TimelineTileSetting : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public TimelineTileSetting(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "TimelineTileSetting";
		}

		public TimelineTileSetting(TimelineTileSetting source)
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

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new TimelineTileSetting_TimelineEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("TimelineTileSettingDeleted", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new TimelineTileSetting(this);
		}

		#endregion

	}

	#endregion

	#region Class: TimelineTileSetting_TimelineEventsProcess

	/// <exclude/>
	public partial class TimelineTileSetting_TimelineEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : TimelineTileSetting
	{

		public TimelineTileSetting_TimelineEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "TimelineTileSetting_TimelineEventsProcess";
			SchemaUId = new Guid("d17a3a86-aa8a-4aea-8c3a-cda031f871bd");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("d17a3a86-aa8a-4aea-8c3a-cda031f871bd");
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

	#region Class: TimelineTileSetting_TimelineEventsProcess

	/// <exclude/>
	public class TimelineTileSetting_TimelineEventsProcess : TimelineTileSetting_TimelineEventsProcess<TimelineTileSetting>
	{

		public TimelineTileSetting_TimelineEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: TimelineTileSetting_TimelineEventsProcess

	public partial class TimelineTileSetting_TimelineEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: TimelineTileSettingEventsProcess

	/// <exclude/>
	public class TimelineTileSettingEventsProcess : TimelineTileSetting_TimelineEventsProcess
	{

		public TimelineTileSettingEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

