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

	#region Class: ESNNotificationTypeSchema

	/// <exclude/>
	public class ESNNotificationTypeSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public ESNNotificationTypeSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ESNNotificationTypeSchema(ESNNotificationTypeSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ESNNotificationTypeSchema(ESNNotificationTypeSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("50ccb888-a445-4deb-95d1-452c96fcd984");
			RealUId = new Guid("50ccb888-a445-4deb-95d1-452c96fcd984");
			Name = "ESNNotificationType";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("85692de8-da76-4104-833d-8e3ae998c1d9");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateActionColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializePrimaryImageColumn() {
			base.InitializePrimaryImageColumn();
			PrimaryImageColumn = CreateIconColumn();
			if (Columns.FindByUId(PrimaryImageColumn.UId) == null) {
				Columns.Add(PrimaryImageColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("50ccb888-a445-4deb-95d1-452c96fcd984");
			column.CreatedInPackageId = new Guid("85692de8-da76-4104-833d-8e3ae998c1d9");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("50ccb888-a445-4deb-95d1-452c96fcd984");
			column.CreatedInPackageId = new Guid("85692de8-da76-4104-833d-8e3ae998c1d9");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("50ccb888-a445-4deb-95d1-452c96fcd984");
			column.CreatedInPackageId = new Guid("85692de8-da76-4104-833d-8e3ae998c1d9");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("50ccb888-a445-4deb-95d1-452c96fcd984");
			column.CreatedInPackageId = new Guid("85692de8-da76-4104-833d-8e3ae998c1d9");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("50ccb888-a445-4deb-95d1-452c96fcd984");
			column.CreatedInPackageId = new Guid("85692de8-da76-4104-833d-8e3ae998c1d9");
			return column;
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.IsLocalizable = false;
			column.ModifiedInSchemaUId = new Guid("50ccb888-a445-4deb-95d1-452c96fcd984");
			column.CreatedInPackageId = new Guid("85692de8-da76-4104-833d-8e3ae998c1d9");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("50ccb888-a445-4deb-95d1-452c96fcd984");
			column.CreatedInPackageId = new Guid("85692de8-da76-4104-833d-8e3ae998c1d9");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("50ccb888-a445-4deb-95d1-452c96fcd984");
			column.CreatedInPackageId = new Guid("85692de8-da76-4104-833d-8e3ae998c1d9");
			return column;
		}

		protected virtual EntitySchemaColumn CreateActionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("a4de0840-eb56-4d68-a52a-50dd4e7e115c"),
				Name = @"Action",
				CreatedInSchemaUId = new Guid("50ccb888-a445-4deb-95d1-452c96fcd984"),
				ModifiedInSchemaUId = new Guid("50ccb888-a445-4deb-95d1-452c96fcd984"),
				CreatedInPackageId = new Guid("85692de8-da76-4104-833d-8e3ae998c1d9"),
				IsLocalizable = true
			};
		}

		protected virtual EntitySchemaColumn CreateIconColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ImageLookup")) {
				UId = new Guid("66faaed4-c85e-4322-b1b4-5ac530206f23"),
				Name = @"Icon",
				ReferenceSchemaUId = new Guid("93986bfe-2dbd-46bc-9bf9-d03dfefbf3b8"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("50ccb888-a445-4deb-95d1-452c96fcd984"),
				ModifiedInSchemaUId = new Guid("50ccb888-a445-4deb-95d1-452c96fcd984"),
				CreatedInPackageId = new Guid("85692de8-da76-4104-833d-8e3ae998c1d9")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ESNNotificationType(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ESNNotificationType_ESNEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ESNNotificationTypeSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ESNNotificationTypeSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("50ccb888-a445-4deb-95d1-452c96fcd984"));
		}

		#endregion

	}

	#endregion

	#region Class: ESNNotificationType

	/// <summary>
	/// ESN notification type.
	/// </summary>
	public class ESNNotificationType : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public ESNNotificationType(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ESNNotificationType";
		}

		public ESNNotificationType(ESNNotificationType source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Task.
		/// </summary>
		public string Action {
			get {
				return GetTypedColumnValue<string>("Action");
			}
			set {
				SetColumnValue("Action", value);
			}
		}

		/// <exclude/>
		public Guid IconId {
			get {
				return GetTypedColumnValue<Guid>("IconId");
			}
			set {
				SetColumnValue("IconId", value);
				_icon = null;
			}
		}

		/// <exclude/>
		public string IconName {
			get {
				return GetTypedColumnValue<string>("IconName");
			}
			set {
				SetColumnValue("IconName", value);
				if (_icon != null) {
					_icon.Name = value;
				}
			}
		}

		private SysImage _icon;
		/// <summary>
		/// Type icon.
		/// </summary>
		public SysImage Icon {
			get {
				return _icon ??
					(_icon = LookupColumnEntities.GetEntity("Icon") as SysImage);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ESNNotificationType_ESNEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ESNNotificationTypeDeleted", e);
			Inserting += (s, e) => ThrowEvent("ESNNotificationTypeInserting", e);
			Validating += (s, e) => ThrowEvent("ESNNotificationTypeValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ESNNotificationType(this);
		}

		#endregion

	}

	#endregion

	#region Class: ESNNotificationType_ESNEventsProcess

	/// <exclude/>
	public partial class ESNNotificationType_ESNEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : ESNNotificationType
	{

		public ESNNotificationType_ESNEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ESNNotificationType_ESNEventsProcess";
			SchemaUId = new Guid("50ccb888-a445-4deb-95d1-452c96fcd984");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("50ccb888-a445-4deb-95d1-452c96fcd984");
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

	#region Class: ESNNotificationType_ESNEventsProcess

	/// <exclude/>
	public class ESNNotificationType_ESNEventsProcess : ESNNotificationType_ESNEventsProcess<ESNNotificationType>
	{

		public ESNNotificationType_ESNEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ESNNotificationType_ESNEventsProcess

	public partial class ESNNotificationType_ESNEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ESNNotificationTypeEventsProcess

	/// <exclude/>
	public class ESNNotificationTypeEventsProcess : ESNNotificationType_ESNEventsProcess
	{

		public ESNNotificationTypeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

