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

	#region Class: SysAdminUnitTypeSchema

	/// <exclude/>
	public class SysAdminUnitTypeSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public SysAdminUnitTypeSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysAdminUnitTypeSchema(SysAdminUnitTypeSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysAdminUnitTypeSchema(SysAdminUnitTypeSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("e58cf897-de3a-48fb-a0a2-38943bf0ad06");
			RealUId = new Guid("e58cf897-de3a-48fb-a0a2-38943bf0ad06");
			Name = "SysAdminUnitType";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("95203cbf-4cfb-4bee-9697-f3ba43648e0e")) == null) {
				Columns.Add(CreateValueColumn());
			}
			if (Columns.FindByUId(new Guid("3c2afb75-3112-40d7-86b6-babab25f6de9")) == null) {
				Columns.Add(CreateImageColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateValueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("95203cbf-4cfb-4bee-9697-f3ba43648e0e"),
				Name = @"Value",
				CreatedInSchemaUId = new Guid("e58cf897-de3a-48fb-a0a2-38943bf0ad06"),
				ModifiedInSchemaUId = new Guid("e58cf897-de3a-48fb-a0a2-38943bf0ad06"),
				CreatedInPackageId = new Guid("773ffacd-4a58-4934-8cb2-5bf23386d08f")
			};
		}

		protected virtual EntitySchemaColumn CreateImageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Image")) {
				UId = new Guid("3c2afb75-3112-40d7-86b6-babab25f6de9"),
				Name = @"Image",
				CreatedInSchemaUId = new Guid("e58cf897-de3a-48fb-a0a2-38943bf0ad06"),
				ModifiedInSchemaUId = new Guid("e58cf897-de3a-48fb-a0a2-38943bf0ad06"),
				CreatedInPackageId = new Guid("467e8661-453f-46e6-ab9a-2749b5699bb7")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysAdminUnitType(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysAdminUnitType_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysAdminUnitTypeSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysAdminUnitTypeSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("e58cf897-de3a-48fb-a0a2-38943bf0ad06"));
		}

		#endregion

	}

	#endregion

	#region Class: SysAdminUnitType

	/// <summary>
	/// Object Permission Type.
	/// </summary>
	public class SysAdminUnitType : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public SysAdminUnitType(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysAdminUnitType";
		}

		public SysAdminUnitType(SysAdminUnitType source)
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
			var process = new SysAdminUnitType_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysAdminUnitTypeDeleted", e);
			Deleting += (s, e) => ThrowEvent("SysAdminUnitTypeDeleting", e);
			Inserted += (s, e) => ThrowEvent("SysAdminUnitTypeInserted", e);
			Inserting += (s, e) => ThrowEvent("SysAdminUnitTypeInserting", e);
			Saved += (s, e) => ThrowEvent("SysAdminUnitTypeSaved", e);
			Saving += (s, e) => ThrowEvent("SysAdminUnitTypeSaving", e);
			Validating += (s, e) => ThrowEvent("SysAdminUnitTypeValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysAdminUnitType(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysAdminUnitType_BaseEventsProcess

	/// <exclude/>
	public partial class SysAdminUnitType_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : SysAdminUnitType
	{

		public SysAdminUnitType_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysAdminUnitType_BaseEventsProcess";
			SchemaUId = new Guid("e58cf897-de3a-48fb-a0a2-38943bf0ad06");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("e58cf897-de3a-48fb-a0a2-38943bf0ad06");
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

	#region Class: SysAdminUnitType_BaseEventsProcess

	/// <exclude/>
	public class SysAdminUnitType_BaseEventsProcess : SysAdminUnitType_BaseEventsProcess<SysAdminUnitType>
	{

		public SysAdminUnitType_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysAdminUnitType_BaseEventsProcess

	public partial class SysAdminUnitType_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysAdminUnitTypeEventsProcess

	/// <exclude/>
	public class SysAdminUnitTypeEventsProcess : SysAdminUnitType_BaseEventsProcess
	{

		public SysAdminUnitTypeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

