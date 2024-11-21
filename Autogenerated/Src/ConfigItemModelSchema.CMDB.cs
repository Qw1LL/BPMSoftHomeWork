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

	#region Class: ConfigItemModelSchema

	/// <exclude/>
	public class ConfigItemModelSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public ConfigItemModelSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ConfigItemModelSchema(ConfigItemModelSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ConfigItemModelSchema(ConfigItemModelSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("763b998e-00b3-4b83-90c4-bed9c7715dc7");
			RealUId = new Guid("763b998e-00b3-4b83-90c4-bed9c7715dc7");
			Name = "ConfigItemModel";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("305fcfca-4160-4398-90a9-d5e84be0ae12");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("95e22dd5-ec6e-479d-9c97-83cd33a6ca2b")) == null) {
				Columns.Add(CreateConfItemTypeColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("763b998e-00b3-4b83-90c4-bed9c7715dc7");
			column.CreatedInPackageId = new Guid("305fcfca-4160-4398-90a9-d5e84be0ae12");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("763b998e-00b3-4b83-90c4-bed9c7715dc7");
			column.CreatedInPackageId = new Guid("305fcfca-4160-4398-90a9-d5e84be0ae12");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("763b998e-00b3-4b83-90c4-bed9c7715dc7");
			column.CreatedInPackageId = new Guid("305fcfca-4160-4398-90a9-d5e84be0ae12");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("763b998e-00b3-4b83-90c4-bed9c7715dc7");
			column.CreatedInPackageId = new Guid("305fcfca-4160-4398-90a9-d5e84be0ae12");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("763b998e-00b3-4b83-90c4-bed9c7715dc7");
			column.CreatedInPackageId = new Guid("305fcfca-4160-4398-90a9-d5e84be0ae12");
			return column;
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("763b998e-00b3-4b83-90c4-bed9c7715dc7");
			column.CreatedInPackageId = new Guid("305fcfca-4160-4398-90a9-d5e84be0ae12");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("763b998e-00b3-4b83-90c4-bed9c7715dc7");
			column.CreatedInPackageId = new Guid("305fcfca-4160-4398-90a9-d5e84be0ae12");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("763b998e-00b3-4b83-90c4-bed9c7715dc7");
			column.CreatedInPackageId = new Guid("305fcfca-4160-4398-90a9-d5e84be0ae12");
			return column;
		}

		protected virtual EntitySchemaColumn CreateConfItemTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("95e22dd5-ec6e-479d-9c97-83cd33a6ca2b"),
				Name = @"ConfItemType",
				ReferenceSchemaUId = new Guid("da6e81b8-7237-4bb1-b5b1-b1e80977025e"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("763b998e-00b3-4b83-90c4-bed9c7715dc7"),
				ModifiedInSchemaUId = new Guid("763b998e-00b3-4b83-90c4-bed9c7715dc7"),
				CreatedInPackageId = new Guid("ffa69c6a-c8bb-4a61-bc00-b0bcd40a9862")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ConfigItemModel(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ConfigItemModel_CMDBEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ConfigItemModelSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ConfigItemModelSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("763b998e-00b3-4b83-90c4-bed9c7715dc7"));
		}

		#endregion

	}

	#endregion

	#region Class: ConfigItemModel

	/// <summary>
	/// Модель конфигурационной единицы.
	/// </summary>
	public class ConfigItemModel : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public ConfigItemModel(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ConfigItemModel";
		}

		public ConfigItemModel(ConfigItemModel source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid ConfItemTypeId {
			get {
				return GetTypedColumnValue<Guid>("ConfItemTypeId");
			}
			set {
				SetColumnValue("ConfItemTypeId", value);
				_confItemType = null;
			}
		}

		/// <exclude/>
		public string ConfItemTypeName {
			get {
				return GetTypedColumnValue<string>("ConfItemTypeName");
			}
			set {
				SetColumnValue("ConfItemTypeName", value);
				if (_confItemType != null) {
					_confItemType.Name = value;
				}
			}
		}

		private ConfigItemType _confItemType;
		/// <summary>
		/// Тип конфигурационной единицы.
		/// </summary>
		public ConfigItemType ConfItemType {
			get {
				return _confItemType ??
					(_confItemType = LookupColumnEntities.GetEntity("ConfItemType") as ConfigItemType);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ConfigItemModel_CMDBEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ConfigItemModelDeleted", e);
			Inserting += (s, e) => ThrowEvent("ConfigItemModelInserting", e);
			Validating += (s, e) => ThrowEvent("ConfigItemModelValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ConfigItemModel(this);
		}

		#endregion

	}

	#endregion

	#region Class: ConfigItemModel_CMDBEventsProcess

	/// <exclude/>
	public partial class ConfigItemModel_CMDBEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : ConfigItemModel
	{

		public ConfigItemModel_CMDBEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ConfigItemModel_CMDBEventsProcess";
			SchemaUId = new Guid("763b998e-00b3-4b83-90c4-bed9c7715dc7");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("763b998e-00b3-4b83-90c4-bed9c7715dc7");
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

	#region Class: ConfigItemModel_CMDBEventsProcess

	/// <exclude/>
	public class ConfigItemModel_CMDBEventsProcess : ConfigItemModel_CMDBEventsProcess<ConfigItemModel>
	{

		public ConfigItemModel_CMDBEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ConfigItemModel_CMDBEventsProcess

	public partial class ConfigItemModel_CMDBEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ConfigItemModelEventsProcess

	/// <exclude/>
	public class ConfigItemModelEventsProcess : ConfigItemModel_CMDBEventsProcess
	{

		public ConfigItemModelEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

