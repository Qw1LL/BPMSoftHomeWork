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

	#region Class: BaseLczEntitySchema

	/// <exclude/>
	[IsVirtual]
	public class BaseLczEntitySchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public BaseLczEntitySchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public BaseLczEntitySchema(BaseLczEntitySchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public BaseLczEntitySchema(BaseLczEntitySchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("b7cd8e8f-a017-4f73-b1fe-efb9e938e1d2");
			RealUId = new Guid("b7cd8e8f-a017-4f73-b1fe-efb9e938e1d2");
			Name = "BaseLczEntity";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("6b414fa0-2b95-4f53-bef6-4d1234de71e0")) == null) {
				Columns.Add(CreateRecordColumn());
			}
			if (Columns.FindByUId(new Guid("00fbb35a-18af-426e-9bc0-6a7ee6784a06")) == null) {
				Columns.Add(CreateColumnUIdColumn());
			}
			if (Columns.FindByUId(new Guid("22c1f20f-ee4c-4699-b988-238aaec3ff93")) == null) {
				Columns.Add(CreateSysCultureColumn());
			}
			if (Columns.FindByUId(new Guid("b8234209-35dc-4ca6-a959-e570754bfa1e")) == null) {
				Columns.Add(CreateValueColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateRecordColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("6b414fa0-2b95-4f53-bef6-4d1234de71e0"),
				Name = @"Record",
				ReferenceSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("b7cd8e8f-a017-4f73-b1fe-efb9e938e1d2"),
				ModifiedInSchemaUId = new Guid("b7cd8e8f-a017-4f73-b1fe-efb9e938e1d2"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateColumnUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("00fbb35a-18af-426e-9bc0-6a7ee6784a06"),
				Name = @"ColumnUId",
				CreatedInSchemaUId = new Guid("b7cd8e8f-a017-4f73-b1fe-efb9e938e1d2"),
				ModifiedInSchemaUId = new Guid("b7cd8e8f-a017-4f73-b1fe-efb9e938e1d2"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateSysCultureColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("22c1f20f-ee4c-4699-b988-238aaec3ff93"),
				Name = @"SysCulture",
				ReferenceSchemaUId = new Guid("ffc193e1-04bc-472b-bdc0-3333d1df84e4"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("b7cd8e8f-a017-4f73-b1fe-efb9e938e1d2"),
				ModifiedInSchemaUId = new Guid("b7cd8e8f-a017-4f73-b1fe-efb9e938e1d2"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateValueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("b8234209-35dc-4ca6-a959-e570754bfa1e"),
				Name = @"Value",
				CreatedInSchemaUId = new Guid("b7cd8e8f-a017-4f73-b1fe-efb9e938e1d2"),
				ModifiedInSchemaUId = new Guid("b7cd8e8f-a017-4f73-b1fe-efb9e938e1d2"),
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
			return new BaseLczEntity(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new BaseLczEntity_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new BaseLczEntitySchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new BaseLczEntitySchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("b7cd8e8f-a017-4f73-b1fe-efb9e938e1d2"));
		}

		#endregion

	}

	#endregion

	#region Class: BaseLczEntity

	/// <summary>
	/// Localization base object.
	/// </summary>
	public class BaseLczEntity : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public BaseLczEntity(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "BaseLczEntity";
		}

		public BaseLczEntity(BaseLczEntity source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid RecordId {
			get {
				return GetTypedColumnValue<Guid>("RecordId");
			}
			set {
				SetColumnValue("RecordId", value);
				_record = null;
			}
		}

		/// <exclude/>
		public string RecordName {
			get {
				return GetTypedColumnValue<string>("RecordName");
			}
			set {
				SetColumnValue("RecordName", value);
				if (_record != null) {
					_record.Name = value;
				}
			}
		}

		private BaseLookup _record;
		/// <summary>
		/// Record Id.
		/// </summary>
		public BaseLookup Record {
			get {
				return _record ??
					(_record = LookupColumnEntities.GetEntity("Record") as BaseLookup);
			}
		}

		/// <summary>
		/// Column Id.
		/// </summary>
		public Guid ColumnUId {
			get {
				return GetTypedColumnValue<Guid>("ColumnUId");
			}
			set {
				SetColumnValue("ColumnUId", value);
			}
		}

		/// <exclude/>
		public Guid SysCultureId {
			get {
				return GetTypedColumnValue<Guid>("SysCultureId");
			}
			set {
				SetColumnValue("SysCultureId", value);
				_sysCulture = null;
			}
		}

		/// <exclude/>
		public string SysCultureName {
			get {
				return GetTypedColumnValue<string>("SysCultureName");
			}
			set {
				SetColumnValue("SysCultureName", value);
				if (_sysCulture != null) {
					_sysCulture.Name = value;
				}
			}
		}

		private SysCulture _sysCulture;
		/// <summary>
		/// Culture.
		/// </summary>
		public SysCulture SysCulture {
			get {
				return _sysCulture ??
					(_sysCulture = LookupColumnEntities.GetEntity("SysCulture") as SysCulture);
			}
		}

		/// <summary>
		/// Value.
		/// </summary>
		public string Value {
			get {
				return GetTypedColumnValue<string>("Value");
			}
			set {
				SetColumnValue("Value", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new BaseLczEntity_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("BaseLczEntityDeleted", e);
			Inserting += (s, e) => ThrowEvent("BaseLczEntityInserting", e);
			Validating += (s, e) => ThrowEvent("BaseLczEntityValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new BaseLczEntity(this);
		}

		#endregion

	}

	#endregion

	#region Class: BaseLczEntity_BaseEventsProcess

	/// <exclude/>
	public partial class BaseLczEntity_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : BaseLczEntity
	{

		public BaseLczEntity_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "BaseLczEntity_BaseEventsProcess";
			SchemaUId = new Guid("b7cd8e8f-a017-4f73-b1fe-efb9e938e1d2");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("b7cd8e8f-a017-4f73-b1fe-efb9e938e1d2");
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

	#region Class: BaseLczEntity_BaseEventsProcess

	/// <exclude/>
	public class BaseLczEntity_BaseEventsProcess : BaseLczEntity_BaseEventsProcess<BaseLczEntity>
	{

		public BaseLczEntity_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: BaseLczEntity_BaseEventsProcess

	public partial class BaseLczEntity_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: BaseLczEntityEventsProcess

	/// <exclude/>
	public class BaseLczEntityEventsProcess : BaseLczEntity_BaseEventsProcess
	{

		public BaseLczEntityEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

