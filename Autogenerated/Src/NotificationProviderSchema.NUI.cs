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

	#region Class: NotificationProviderSchema

	/// <exclude/>
	public class NotificationProviderSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public NotificationProviderSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public NotificationProviderSchema(NotificationProviderSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public NotificationProviderSchema(NotificationProviderSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("74494ba7-82f2-4966-84cc-3af84d4eb6fb");
			RealUId = new Guid("74494ba7-82f2-4966-84cc-3af84d4eb6fb");
			Name = "NotificationProvider";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("61be812f-b09a-4a44-9ef0-5c4c5cd6d152");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("a664c9a9-6373-437f-9be3-23f33a134628")) == null) {
				Columns.Add(CreateClassNameColumn());
			}
			if (Columns.FindByUId(new Guid("c84e4a7d-70dc-4ad9-9ac5-bd885086b5b9")) == null) {
				Columns.Add(CreateTypeColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("74494ba7-82f2-4966-84cc-3af84d4eb6fb");
			column.CreatedInPackageId = new Guid("61be812f-b09a-4a44-9ef0-5c4c5cd6d152");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("74494ba7-82f2-4966-84cc-3af84d4eb6fb");
			column.CreatedInPackageId = new Guid("61be812f-b09a-4a44-9ef0-5c4c5cd6d152");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("74494ba7-82f2-4966-84cc-3af84d4eb6fb");
			column.CreatedInPackageId = new Guid("61be812f-b09a-4a44-9ef0-5c4c5cd6d152");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("74494ba7-82f2-4966-84cc-3af84d4eb6fb");
			column.CreatedInPackageId = new Guid("61be812f-b09a-4a44-9ef0-5c4c5cd6d152");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("74494ba7-82f2-4966-84cc-3af84d4eb6fb");
			column.CreatedInPackageId = new Guid("61be812f-b09a-4a44-9ef0-5c4c5cd6d152");
			return column;
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("74494ba7-82f2-4966-84cc-3af84d4eb6fb");
			column.CreatedInPackageId = new Guid("61be812f-b09a-4a44-9ef0-5c4c5cd6d152");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("74494ba7-82f2-4966-84cc-3af84d4eb6fb");
			column.CreatedInPackageId = new Guid("61be812f-b09a-4a44-9ef0-5c4c5cd6d152");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("74494ba7-82f2-4966-84cc-3af84d4eb6fb");
			column.CreatedInPackageId = new Guid("61be812f-b09a-4a44-9ef0-5c4c5cd6d152");
			return column;
		}

		protected virtual EntitySchemaColumn CreateClassNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("a664c9a9-6373-437f-9be3-23f33a134628"),
				Name = @"ClassName",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("74494ba7-82f2-4966-84cc-3af84d4eb6fb"),
				ModifiedInSchemaUId = new Guid("74494ba7-82f2-4966-84cc-3af84d4eb6fb"),
				CreatedInPackageId = new Guid("61be812f-b09a-4a44-9ef0-5c4c5cd6d152")
			};
		}

		protected virtual EntitySchemaColumn CreateTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("c84e4a7d-70dc-4ad9-9ac5-bd885086b5b9"),
				Name = @"Type",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("74494ba7-82f2-4966-84cc-3af84d4eb6fb"),
				ModifiedInSchemaUId = new Guid("74494ba7-82f2-4966-84cc-3af84d4eb6fb"),
				CreatedInPackageId = new Guid("61be812f-b09a-4a44-9ef0-5c4c5cd6d152"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"0"
				}
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new NotificationProvider(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new NotificationProvider_NUIEventsProcess(userConnection);
		}

		public override object Clone() {
			return new NotificationProviderSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new NotificationProviderSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("74494ba7-82f2-4966-84cc-3af84d4eb6fb"));
		}

		#endregion

	}

	#endregion

	#region Class: NotificationProvider

	/// <summary>
	/// Notification provider.
	/// </summary>
	public class NotificationProvider : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public NotificationProvider(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "NotificationProvider";
		}

		public NotificationProvider(NotificationProvider source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Class name.
		/// </summary>
		public string ClassName {
			get {
				return GetTypedColumnValue<string>("ClassName");
			}
			set {
				SetColumnValue("ClassName", value);
			}
		}

		/// <summary>
		/// Type.
		/// </summary>
		public int Type {
			get {
				return GetTypedColumnValue<int>("Type");
			}
			set {
				SetColumnValue("Type", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new NotificationProvider_NUIEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("NotificationProviderDeleted", e);
			Inserting += (s, e) => ThrowEvent("NotificationProviderInserting", e);
			Validating += (s, e) => ThrowEvent("NotificationProviderValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new NotificationProvider(this);
		}

		#endregion

	}

	#endregion

	#region Class: NotificationProvider_NUIEventsProcess

	/// <exclude/>
	public partial class NotificationProvider_NUIEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : NotificationProvider
	{

		public NotificationProvider_NUIEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "NotificationProvider_NUIEventsProcess";
			SchemaUId = new Guid("74494ba7-82f2-4966-84cc-3af84d4eb6fb");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("74494ba7-82f2-4966-84cc-3af84d4eb6fb");
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

	#region Class: NotificationProvider_NUIEventsProcess

	/// <exclude/>
	public class NotificationProvider_NUIEventsProcess : NotificationProvider_NUIEventsProcess<NotificationProvider>
	{

		public NotificationProvider_NUIEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: NotificationProvider_NUIEventsProcess

	public partial class NotificationProvider_NUIEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: NotificationProviderEventsProcess

	/// <exclude/>
	public class NotificationProviderEventsProcess : NotificationProvider_NUIEventsProcess
	{

		public NotificationProviderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

