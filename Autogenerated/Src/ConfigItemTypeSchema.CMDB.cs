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

	#region Class: ConfigItemTypeSchema

	/// <exclude/>
	public class ConfigItemTypeSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public ConfigItemTypeSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ConfigItemTypeSchema(ConfigItemTypeSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ConfigItemTypeSchema(ConfigItemTypeSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("da6e81b8-7237-4bb1-b5b1-b1e80977025e");
			RealUId = new Guid("da6e81b8-7237-4bb1-b5b1-b1e80977025e");
			Name = "ConfigItemType";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("305fcfca-4160-4398-90a9-d5e84be0ae12");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("b2e80537-a48f-40af-90bf-915bcfb0ecbc")) == null) {
				Columns.Add(CreateConfItemCategoryColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("da6e81b8-7237-4bb1-b5b1-b1e80977025e");
			column.CreatedInPackageId = new Guid("305fcfca-4160-4398-90a9-d5e84be0ae12");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("da6e81b8-7237-4bb1-b5b1-b1e80977025e");
			column.CreatedInPackageId = new Guid("305fcfca-4160-4398-90a9-d5e84be0ae12");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("da6e81b8-7237-4bb1-b5b1-b1e80977025e");
			column.CreatedInPackageId = new Guid("305fcfca-4160-4398-90a9-d5e84be0ae12");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("da6e81b8-7237-4bb1-b5b1-b1e80977025e");
			column.CreatedInPackageId = new Guid("305fcfca-4160-4398-90a9-d5e84be0ae12");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("da6e81b8-7237-4bb1-b5b1-b1e80977025e");
			column.CreatedInPackageId = new Guid("305fcfca-4160-4398-90a9-d5e84be0ae12");
			return column;
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("da6e81b8-7237-4bb1-b5b1-b1e80977025e");
			column.CreatedInPackageId = new Guid("305fcfca-4160-4398-90a9-d5e84be0ae12");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("da6e81b8-7237-4bb1-b5b1-b1e80977025e");
			column.CreatedInPackageId = new Guid("305fcfca-4160-4398-90a9-d5e84be0ae12");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("da6e81b8-7237-4bb1-b5b1-b1e80977025e");
			column.CreatedInPackageId = new Guid("305fcfca-4160-4398-90a9-d5e84be0ae12");
			return column;
		}

		protected virtual EntitySchemaColumn CreateConfItemCategoryColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("b2e80537-a48f-40af-90bf-915bcfb0ecbc"),
				Name = @"ConfItemCategory",
				ReferenceSchemaUId = new Guid("f3a5c486-27e1-46aa-b693-148bffe3b87c"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("da6e81b8-7237-4bb1-b5b1-b1e80977025e"),
				ModifiedInSchemaUId = new Guid("da6e81b8-7237-4bb1-b5b1-b1e80977025e"),
				CreatedInPackageId = new Guid("3bc94b8f-9e47-4d1d-84d1-651293d36a8b")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ConfigItemType(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ConfigItemType_CMDBEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ConfigItemTypeSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ConfigItemTypeSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("da6e81b8-7237-4bb1-b5b1-b1e80977025e"));
		}

		#endregion

	}

	#endregion

	#region Class: ConfigItemType

	/// <summary>
	/// Тип конфигурационной единицы.
	/// </summary>
	public class ConfigItemType : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public ConfigItemType(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ConfigItemType";
		}

		public ConfigItemType(ConfigItemType source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid ConfItemCategoryId {
			get {
				return GetTypedColumnValue<Guid>("ConfItemCategoryId");
			}
			set {
				SetColumnValue("ConfItemCategoryId", value);
				_confItemCategory = null;
			}
		}

		/// <exclude/>
		public string ConfItemCategoryName {
			get {
				return GetTypedColumnValue<string>("ConfItemCategoryName");
			}
			set {
				SetColumnValue("ConfItemCategoryName", value);
				if (_confItemCategory != null) {
					_confItemCategory.Name = value;
				}
			}
		}

		private ConfigItemCategory _confItemCategory;
		/// <summary>
		/// Категория конфигурационной единицы.
		/// </summary>
		public ConfigItemCategory ConfItemCategory {
			get {
				return _confItemCategory ??
					(_confItemCategory = LookupColumnEntities.GetEntity("ConfItemCategory") as ConfigItemCategory);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ConfigItemType_CMDBEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ConfigItemTypeDeleted", e);
			Inserting += (s, e) => ThrowEvent("ConfigItemTypeInserting", e);
			Validating += (s, e) => ThrowEvent("ConfigItemTypeValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ConfigItemType(this);
		}

		#endregion

	}

	#endregion

	#region Class: ConfigItemType_CMDBEventsProcess

	/// <exclude/>
	public partial class ConfigItemType_CMDBEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : ConfigItemType
	{

		public ConfigItemType_CMDBEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ConfigItemType_CMDBEventsProcess";
			SchemaUId = new Guid("da6e81b8-7237-4bb1-b5b1-b1e80977025e");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("da6e81b8-7237-4bb1-b5b1-b1e80977025e");
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

	#region Class: ConfigItemType_CMDBEventsProcess

	/// <exclude/>
	public class ConfigItemType_CMDBEventsProcess : ConfigItemType_CMDBEventsProcess<ConfigItemType>
	{

		public ConfigItemType_CMDBEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ConfigItemType_CMDBEventsProcess

	public partial class ConfigItemType_CMDBEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ConfigItemTypeEventsProcess

	/// <exclude/>
	public class ConfigItemTypeEventsProcess : ConfigItemType_CMDBEventsProcess
	{

		public ConfigItemTypeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

