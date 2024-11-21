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

	#region Class: TimelinePageSettingSchema

	/// <exclude/>
	public class TimelinePageSettingSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public TimelinePageSettingSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public TimelinePageSettingSchema(TimelinePageSettingSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public TimelinePageSettingSchema(TimelinePageSettingSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("657e9446-2d2f-4531-a636-f42ea2aee1b7");
			RealUId = new Guid("657e9446-2d2f-4531-a636-f42ea2aee1b7");
			Name = "TimelinePageSetting";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("01a896a6-511e-4cd8-b0ee-ac1da9bba8f4");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("b16d81eb-d1fc-4977-8005-7c914268ef0e")) == null) {
				Columns.Add(CreateKeyColumn());
			}
			if (Columns.FindByUId(new Guid("ecc876bf-5813-4ea5-9b21-1586f898467f")) == null) {
				Columns.Add(CreateDataColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateKeyColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("b16d81eb-d1fc-4977-8005-7c914268ef0e"),
				Name = @"Key",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("657e9446-2d2f-4531-a636-f42ea2aee1b7"),
				ModifiedInSchemaUId = new Guid("657e9446-2d2f-4531-a636-f42ea2aee1b7"),
				CreatedInPackageId = new Guid("01a896a6-511e-4cd8-b0ee-ac1da9bba8f4")
			};
		}

		protected virtual EntitySchemaColumn CreateDataColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Binary")) {
				UId = new Guid("ecc876bf-5813-4ea5-9b21-1586f898467f"),
				Name = @"Data",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("657e9446-2d2f-4531-a636-f42ea2aee1b7"),
				ModifiedInSchemaUId = new Guid("657e9446-2d2f-4531-a636-f42ea2aee1b7"),
				CreatedInPackageId = new Guid("01a896a6-511e-4cd8-b0ee-ac1da9bba8f4")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new TimelinePageSetting(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new TimelinePageSetting_TimelineEventsProcess(userConnection);
		}

		public override object Clone() {
			return new TimelinePageSettingSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new TimelinePageSettingSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("657e9446-2d2f-4531-a636-f42ea2aee1b7"));
		}

		#endregion

	}

	#endregion

	#region Class: TimelinePageSetting

	/// <summary>
	/// Timeline page setting.
	/// </summary>
	public class TimelinePageSetting : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public TimelinePageSetting(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "TimelinePageSetting";
		}

		public TimelinePageSetting(TimelinePageSetting source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Key.
		/// </summary>
		public string Key {
			get {
				return GetTypedColumnValue<string>("Key");
			}
			set {
				SetColumnValue("Key", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new TimelinePageSetting_TimelineEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("TimelinePageSettingDeleted", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new TimelinePageSetting(this);
		}

		#endregion

	}

	#endregion

	#region Class: TimelinePageSetting_TimelineEventsProcess

	/// <exclude/>
	public partial class TimelinePageSetting_TimelineEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : TimelinePageSetting
	{

		public TimelinePageSetting_TimelineEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "TimelinePageSetting_TimelineEventsProcess";
			SchemaUId = new Guid("657e9446-2d2f-4531-a636-f42ea2aee1b7");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("657e9446-2d2f-4531-a636-f42ea2aee1b7");
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

	#region Class: TimelinePageSetting_TimelineEventsProcess

	/// <exclude/>
	public class TimelinePageSetting_TimelineEventsProcess : TimelinePageSetting_TimelineEventsProcess<TimelinePageSetting>
	{

		public TimelinePageSetting_TimelineEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: TimelinePageSetting_TimelineEventsProcess

	public partial class TimelinePageSetting_TimelineEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: TimelinePageSettingEventsProcess

	/// <exclude/>
	public class TimelinePageSettingEventsProcess : TimelinePageSetting_TimelineEventsProcess
	{

		public TimelinePageSettingEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

