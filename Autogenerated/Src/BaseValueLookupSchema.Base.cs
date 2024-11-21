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

	#region Class: BaseValueLookupSchema

	/// <exclude/>
	public class BaseValueLookupSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public BaseValueLookupSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public BaseValueLookupSchema(BaseValueLookupSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public BaseValueLookupSchema(BaseValueLookupSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("04f67f0c-0a27-4616-987e-60e378854b0f");
			RealUId = new Guid("04f67f0c-0a27-4616-987e-60e378854b0f");
			Name = "BaseValueLookup";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("981348e2-b15b-4ae9-91cb-0ba6582d4731")) == null) {
				Columns.Add(CreateValueColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateValueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("981348e2-b15b-4ae9-91cb-0ba6582d4731"),
				Name = @"Value",
				CreatedInSchemaUId = new Guid("04f67f0c-0a27-4616-987e-60e378854b0f"),
				ModifiedInSchemaUId = new Guid("04f67f0c-0a27-4616-987e-60e378854b0f"),
				CreatedInPackageId = new Guid("773ffacd-4a58-4934-8cb2-5bf23386d08f")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new BaseValueLookup(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new BaseValueLookup_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new BaseValueLookupSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new BaseValueLookupSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("04f67f0c-0a27-4616-987e-60e378854b0f"));
		}

		#endregion

	}

	#endregion

	#region Class: BaseValueLookup

	/// <summary>
	/// Base Lookup with Value.
	/// </summary>
	public class BaseValueLookup : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public BaseValueLookup(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "BaseValueLookup";
		}

		public BaseValueLookup(BaseValueLookup source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Value.
		/// </summary>
		public int Value {
			get {
				return GetTypedColumnValue<int>("Value");
			}
			set {
				SetColumnValue("Value", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new BaseValueLookup_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("BaseValueLookupDeleted", e);
			Deleting += (s, e) => ThrowEvent("BaseValueLookupDeleting", e);
			Inserted += (s, e) => ThrowEvent("BaseValueLookupInserted", e);
			Inserting += (s, e) => ThrowEvent("BaseValueLookupInserting", e);
			Saved += (s, e) => ThrowEvent("BaseValueLookupSaved", e);
			Saving += (s, e) => ThrowEvent("BaseValueLookupSaving", e);
			Validating += (s, e) => ThrowEvent("BaseValueLookupValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new BaseValueLookup(this);
		}

		#endregion

	}

	#endregion

	#region Class: BaseValueLookup_BaseEventsProcess

	/// <exclude/>
	public partial class BaseValueLookup_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : BaseValueLookup
	{

		public BaseValueLookup_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "BaseValueLookup_BaseEventsProcess";
			SchemaUId = new Guid("04f67f0c-0a27-4616-987e-60e378854b0f");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("04f67f0c-0a27-4616-987e-60e378854b0f");
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

	#region Class: BaseValueLookup_BaseEventsProcess

	/// <exclude/>
	public class BaseValueLookup_BaseEventsProcess : BaseValueLookup_BaseEventsProcess<BaseValueLookup>
	{

		public BaseValueLookup_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: BaseValueLookup_BaseEventsProcess

	public partial class BaseValueLookup_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: BaseValueLookupEventsProcess

	/// <exclude/>
	public class BaseValueLookupEventsProcess : BaseValueLookup_BaseEventsProcess
	{

		public BaseValueLookupEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

