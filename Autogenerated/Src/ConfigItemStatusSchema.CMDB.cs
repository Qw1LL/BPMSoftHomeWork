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

	#region Class: ConfigItemStatus_CMDB_BPMSoftSchema

	/// <exclude/>
	public class ConfigItemStatus_CMDB_BPMSoftSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public ConfigItemStatus_CMDB_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ConfigItemStatus_CMDB_BPMSoftSchema(ConfigItemStatus_CMDB_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ConfigItemStatus_CMDB_BPMSoftSchema(ConfigItemStatus_CMDB_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("0f634f04-a6ca-42b3-abe9-3d780c7e9b34");
			RealUId = new Guid("0f634f04-a6ca-42b3-abe9-3d780c7e9b34");
			Name = "ConfigItemStatus_CMDB_BPMSoft";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("305fcfca-4160-4398-90a9-d5e84be0ae12");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("14d8fc5b-9e90-4d95-bf9f-7f40c7e06957")) == null) {
				Columns.Add(CreateIsFinalColumn());
			}
			if (Columns.FindByUId(new Guid("bd7e2f3a-5a60-4a1f-8f5e-62c958433570")) == null) {
				Columns.Add(CreateActiveColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("0f634f04-a6ca-42b3-abe9-3d780c7e9b34");
			column.CreatedInPackageId = new Guid("305fcfca-4160-4398-90a9-d5e84be0ae12");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("0f634f04-a6ca-42b3-abe9-3d780c7e9b34");
			column.CreatedInPackageId = new Guid("305fcfca-4160-4398-90a9-d5e84be0ae12");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("0f634f04-a6ca-42b3-abe9-3d780c7e9b34");
			column.CreatedInPackageId = new Guid("305fcfca-4160-4398-90a9-d5e84be0ae12");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("0f634f04-a6ca-42b3-abe9-3d780c7e9b34");
			column.CreatedInPackageId = new Guid("305fcfca-4160-4398-90a9-d5e84be0ae12");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("0f634f04-a6ca-42b3-abe9-3d780c7e9b34");
			column.CreatedInPackageId = new Guid("305fcfca-4160-4398-90a9-d5e84be0ae12");
			return column;
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("0f634f04-a6ca-42b3-abe9-3d780c7e9b34");
			column.CreatedInPackageId = new Guid("305fcfca-4160-4398-90a9-d5e84be0ae12");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("0f634f04-a6ca-42b3-abe9-3d780c7e9b34");
			column.CreatedInPackageId = new Guid("305fcfca-4160-4398-90a9-d5e84be0ae12");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("0f634f04-a6ca-42b3-abe9-3d780c7e9b34");
			column.CreatedInPackageId = new Guid("305fcfca-4160-4398-90a9-d5e84be0ae12");
			return column;
		}

		protected virtual EntitySchemaColumn CreateIsFinalColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("14d8fc5b-9e90-4d95-bf9f-7f40c7e06957"),
				Name = @"IsFinal",
				CreatedInSchemaUId = new Guid("0f634f04-a6ca-42b3-abe9-3d780c7e9b34"),
				ModifiedInSchemaUId = new Guid("0f634f04-a6ca-42b3-abe9-3d780c7e9b34"),
				CreatedInPackageId = new Guid("305fcfca-4160-4398-90a9-d5e84be0ae12")
			};
		}

		protected virtual EntitySchemaColumn CreateActiveColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("bd7e2f3a-5a60-4a1f-8f5e-62c958433570"),
				Name = @"Active",
				CreatedInSchemaUId = new Guid("0f634f04-a6ca-42b3-abe9-3d780c7e9b34"),
				ModifiedInSchemaUId = new Guid("0f634f04-a6ca-42b3-abe9-3d780c7e9b34"),
				CreatedInPackageId = new Guid("5e04cf06-d887-4a59-8f25-ecb636f87370")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ConfigItemStatus_CMDB_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ConfigItemStatus_CMDBEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ConfigItemStatus_CMDB_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ConfigItemStatus_CMDB_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("0f634f04-a6ca-42b3-abe9-3d780c7e9b34"));
		}

		#endregion

	}

	#endregion

	#region Class: ConfigItemStatus_CMDB_BPMSoft

	/// <summary>
	/// Состояние конфигурационной единицы.
	/// </summary>
	public class ConfigItemStatus_CMDB_BPMSoft : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public ConfigItemStatus_CMDB_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ConfigItemStatus_CMDB_BPMSoft";
		}

		public ConfigItemStatus_CMDB_BPMSoft(ConfigItemStatus_CMDB_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Конечное.
		/// </summary>
		public bool IsFinal {
			get {
				return GetTypedColumnValue<bool>("IsFinal");
			}
			set {
				SetColumnValue("IsFinal", value);
			}
		}

		/// <summary>
		/// Активное состояние .
		/// </summary>
		public bool Active {
			get {
				return GetTypedColumnValue<bool>("Active");
			}
			set {
				SetColumnValue("Active", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ConfigItemStatus_CMDBEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ConfigItemStatus_CMDB_BPMSoftDeleted", e);
			Inserting += (s, e) => ThrowEvent("ConfigItemStatus_CMDB_BPMSoftInserting", e);
			Validating += (s, e) => ThrowEvent("ConfigItemStatus_CMDB_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ConfigItemStatus_CMDB_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: ConfigItemStatus_CMDBEventsProcess

	/// <exclude/>
	public partial class ConfigItemStatus_CMDBEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : ConfigItemStatus_CMDB_BPMSoft
	{

		public ConfigItemStatus_CMDBEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ConfigItemStatus_CMDBEventsProcess";
			SchemaUId = new Guid("0f634f04-a6ca-42b3-abe9-3d780c7e9b34");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("0f634f04-a6ca-42b3-abe9-3d780c7e9b34");
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

	#region Class: ConfigItemStatus_CMDBEventsProcess

	/// <exclude/>
	public class ConfigItemStatus_CMDBEventsProcess : ConfigItemStatus_CMDBEventsProcess<ConfigItemStatus_CMDB_BPMSoft>
	{

		public ConfigItemStatus_CMDBEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ConfigItemStatus_CMDBEventsProcess

	public partial class ConfigItemStatus_CMDBEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

