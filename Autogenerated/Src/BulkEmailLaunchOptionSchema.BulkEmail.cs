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

	#region Class: BulkEmailLaunchOptionSchema

	/// <exclude/>
	public class BulkEmailLaunchOptionSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public BulkEmailLaunchOptionSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public BulkEmailLaunchOptionSchema(BulkEmailLaunchOptionSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public BulkEmailLaunchOptionSchema(BulkEmailLaunchOptionSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("03f7cbaa-4ed0-42d8-99ae-724f0b680fe7");
			RealUId = new Guid("03f7cbaa-4ed0-42d8-99ae-724f0b680fe7");
			Name = "BulkEmailLaunchOption";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("196dac4c-8195-4488-a569-0010bfda9cdc");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("00791caf-e9bc-4b15-94ee-4564257ba4c1")) == null) {
				Columns.Add(CreateCategoryColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateCategoryColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("00791caf-e9bc-4b15-94ee-4564257ba4c1"),
				Name = @"Category",
				ReferenceSchemaUId = new Guid("13cffa88-d296-4202-8bee-d023d51a8454"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("03f7cbaa-4ed0-42d8-99ae-724f0b680fe7"),
				ModifiedInSchemaUId = new Guid("03f7cbaa-4ed0-42d8-99ae-724f0b680fe7"),
				CreatedInPackageId = new Guid("196dac4c-8195-4488-a569-0010bfda9cdc")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new BulkEmailLaunchOption(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new BulkEmailLaunchOption_BulkEmailEventsProcess(userConnection);
		}

		public override object Clone() {
			return new BulkEmailLaunchOptionSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new BulkEmailLaunchOptionSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("03f7cbaa-4ed0-42d8-99ae-724f0b680fe7"));
		}

		#endregion

	}

	#endregion

	#region Class: BulkEmailLaunchOption

	/// <summary>
	/// Вариант запуска рассылки.
	/// </summary>
	public class BulkEmailLaunchOption : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public BulkEmailLaunchOption(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "BulkEmailLaunchOption";
		}

		public BulkEmailLaunchOption(BulkEmailLaunchOption source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid CategoryId {
			get {
				return GetTypedColumnValue<Guid>("CategoryId");
			}
			set {
				SetColumnValue("CategoryId", value);
				_category = null;
			}
		}

		/// <exclude/>
		public string CategoryName {
			get {
				return GetTypedColumnValue<string>("CategoryName");
			}
			set {
				SetColumnValue("CategoryName", value);
				if (_category != null) {
					_category.Name = value;
				}
			}
		}

		private BulkEmailCategory _category;
		/// <summary>
		/// Категория.
		/// </summary>
		public BulkEmailCategory Category {
			get {
				return _category ??
					(_category = LookupColumnEntities.GetEntity("Category") as BulkEmailCategory);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new BulkEmailLaunchOption_BulkEmailEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("BulkEmailLaunchOptionDeleted", e);
			Validating += (s, e) => ThrowEvent("BulkEmailLaunchOptionValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new BulkEmailLaunchOption(this);
		}

		#endregion

	}

	#endregion

	#region Class: BulkEmailLaunchOption_BulkEmailEventsProcess

	/// <exclude/>
	public partial class BulkEmailLaunchOption_BulkEmailEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : BulkEmailLaunchOption
	{

		public BulkEmailLaunchOption_BulkEmailEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "BulkEmailLaunchOption_BulkEmailEventsProcess";
			SchemaUId = new Guid("03f7cbaa-4ed0-42d8-99ae-724f0b680fe7");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("03f7cbaa-4ed0-42d8-99ae-724f0b680fe7");
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

	#region Class: BulkEmailLaunchOption_BulkEmailEventsProcess

	/// <exclude/>
	public class BulkEmailLaunchOption_BulkEmailEventsProcess : BulkEmailLaunchOption_BulkEmailEventsProcess<BulkEmailLaunchOption>
	{

		public BulkEmailLaunchOption_BulkEmailEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: BulkEmailLaunchOption_BulkEmailEventsProcess

	public partial class BulkEmailLaunchOption_BulkEmailEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: BulkEmailLaunchOptionEventsProcess

	/// <exclude/>
	public class BulkEmailLaunchOptionEventsProcess : BulkEmailLaunchOption_BulkEmailEventsProcess
	{

		public BulkEmailLaunchOptionEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

