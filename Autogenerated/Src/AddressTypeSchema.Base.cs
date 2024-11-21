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

	#region Class: AddressType_Base_BPMSoftSchema

	/// <exclude/>
	public class AddressType_Base_BPMSoftSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public AddressType_Base_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public AddressType_Base_BPMSoftSchema(AddressType_Base_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public AddressType_Base_BPMSoftSchema(AddressType_Base_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("50837bfc-43ff-466b-94bb-de0847eecd1b");
			RealUId = new Guid("50837bfc-43ff-466b-94bb-de0847eecd1b");
			Name = "AddressType_Base_BPMSoft";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("7421096a-1fe8-477b-b718-8d66554c0f97")) == null) {
				Columns.Add(CreateForContactColumn());
			}
			if (Columns.FindByUId(new Guid("4c02f622-12ca-4649-a1bf-17cf7a94b168")) == null) {
				Columns.Add(CreateForAccountColumn());
			}
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("50837bfc-43ff-466b-94bb-de0847eecd1b");
			column.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("50837bfc-43ff-466b-94bb-de0847eecd1b");
			column.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			return column;
		}

		protected virtual EntitySchemaColumn CreateForContactColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("7421096a-1fe8-477b-b718-8d66554c0f97"),
				Name = @"ForContact",
				CreatedInSchemaUId = new Guid("50837bfc-43ff-466b-94bb-de0847eecd1b"),
				ModifiedInSchemaUId = new Guid("50837bfc-43ff-466b-94bb-de0847eecd1b"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateForAccountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("4c02f622-12ca-4649-a1bf-17cf7a94b168"),
				Name = @"ForAccount",
				CreatedInSchemaUId = new Guid("50837bfc-43ff-466b-94bb-de0847eecd1b"),
				ModifiedInSchemaUId = new Guid("50837bfc-43ff-466b-94bb-de0847eecd1b"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new AddressType_Base_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new AddressType_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new AddressType_Base_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new AddressType_Base_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("50837bfc-43ff-466b-94bb-de0847eecd1b"));
		}

		#endregion

	}

	#endregion

	#region Class: AddressType_Base_BPMSoft

	/// <summary>
	/// Address type.
	/// </summary>
	public class AddressType_Base_BPMSoft : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public AddressType_Base_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "AddressType_Base_BPMSoft";
		}

		public AddressType_Base_BPMSoft(AddressType_Base_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Use in contacts.
		/// </summary>
		public bool ForContact {
			get {
				return GetTypedColumnValue<bool>("ForContact");
			}
			set {
				SetColumnValue("ForContact", value);
			}
		}

		/// <summary>
		/// Use in accounts.
		/// </summary>
		public bool ForAccount {
			get {
				return GetTypedColumnValue<bool>("ForAccount");
			}
			set {
				SetColumnValue("ForAccount", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new AddressType_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("AddressType_Base_BPMSoftDeleted", e);
			Deleting += (s, e) => ThrowEvent("AddressType_Base_BPMSoftDeleting", e);
			Inserted += (s, e) => ThrowEvent("AddressType_Base_BPMSoftInserted", e);
			Inserting += (s, e) => ThrowEvent("AddressType_Base_BPMSoftInserting", e);
			Saved += (s, e) => ThrowEvent("AddressType_Base_BPMSoftSaved", e);
			Saving += (s, e) => ThrowEvent("AddressType_Base_BPMSoftSaving", e);
			Validating += (s, e) => ThrowEvent("AddressType_Base_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new AddressType_Base_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: AddressType_BaseEventsProcess

	/// <exclude/>
	public partial class AddressType_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : AddressType_Base_BPMSoft
	{

		public AddressType_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "AddressType_BaseEventsProcess";
			SchemaUId = new Guid("50837bfc-43ff-466b-94bb-de0847eecd1b");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("50837bfc-43ff-466b-94bb-de0847eecd1b");
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

	#region Class: AddressType_BaseEventsProcess

	/// <exclude/>
	public class AddressType_BaseEventsProcess : AddressType_BaseEventsProcess<AddressType_Base_BPMSoft>
	{

		public AddressType_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: AddressType_BaseEventsProcess

	public partial class AddressType_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

