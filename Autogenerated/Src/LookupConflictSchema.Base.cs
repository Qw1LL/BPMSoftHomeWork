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

	#region Class: LookupConflictSchema

	/// <exclude/>
	public class LookupConflictSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public LookupConflictSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public LookupConflictSchema(LookupConflictSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public LookupConflictSchema(LookupConflictSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("21e82875-e7fa-4566-bc93-58c591ef5c56");
			RealUId = new Guid("21e82875-e7fa-4566-bc93-58c591ef5c56");
			Name = "LookupConflict";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("0f84a5fb-7bfc-4b1f-a3c2-2485abba38ea")) == null) {
				Columns.Add(CreateDestinationSchemaNameColumn());
			}
			if (Columns.FindByUId(new Guid("e701ab55-e254-462f-b876-c71fc6509851")) == null) {
				Columns.Add(CreateDestinationRecordIdColumn());
			}
			if (Columns.FindByUId(new Guid("d225f613-509e-4b0d-a654-a822fa86bea5")) == null) {
				Columns.Add(CreateDestinationColumnNameColumn());
			}
			if (Columns.FindByUId(new Guid("3cc86f34-ec47-4db3-9211-ddf94295bb92")) == null) {
				Columns.Add(CreateLookupSchemaNameColumn());
			}
			if (Columns.FindByUId(new Guid("069d909b-eb72-4f68-9f61-6e3269521229")) == null) {
				Columns.Add(CreateLookupSchemaDisplayColumnNameColumn());
			}
			if (Columns.FindByUId(new Guid("6b64d393-8ebe-4e25-ae40-cd37e98c5d25")) == null) {
				Columns.Add(CreateLookupSchemaDisplayColumnValueColumn());
			}
			if (Columns.FindByUId(new Guid("dd1129aa-3bd5-42be-a20c-0024c3ce3bc0")) == null) {
				Columns.Add(CreateLookupRecordIdColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateDestinationSchemaNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("0f84a5fb-7bfc-4b1f-a3c2-2485abba38ea"),
				Name = @"DestinationSchemaName",
				CreatedInSchemaUId = new Guid("21e82875-e7fa-4566-bc93-58c591ef5c56"),
				ModifiedInSchemaUId = new Guid("21e82875-e7fa-4566-bc93-58c591ef5c56"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateDestinationRecordIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("e701ab55-e254-462f-b876-c71fc6509851"),
				Name = @"DestinationRecordId",
				CreatedInSchemaUId = new Guid("21e82875-e7fa-4566-bc93-58c591ef5c56"),
				ModifiedInSchemaUId = new Guid("21e82875-e7fa-4566-bc93-58c591ef5c56"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateDestinationColumnNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("d225f613-509e-4b0d-a654-a822fa86bea5"),
				Name = @"DestinationColumnName",
				CreatedInSchemaUId = new Guid("21e82875-e7fa-4566-bc93-58c591ef5c56"),
				ModifiedInSchemaUId = new Guid("21e82875-e7fa-4566-bc93-58c591ef5c56"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateLookupSchemaNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("3cc86f34-ec47-4db3-9211-ddf94295bb92"),
				Name = @"LookupSchemaName",
				CreatedInSchemaUId = new Guid("21e82875-e7fa-4566-bc93-58c591ef5c56"),
				ModifiedInSchemaUId = new Guid("21e82875-e7fa-4566-bc93-58c591ef5c56"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateLookupSchemaDisplayColumnNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("069d909b-eb72-4f68-9f61-6e3269521229"),
				Name = @"LookupSchemaDisplayColumnName",
				CreatedInSchemaUId = new Guid("21e82875-e7fa-4566-bc93-58c591ef5c56"),
				ModifiedInSchemaUId = new Guid("21e82875-e7fa-4566-bc93-58c591ef5c56"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateLookupSchemaDisplayColumnValueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("6b64d393-8ebe-4e25-ae40-cd37e98c5d25"),
				Name = @"LookupSchemaDisplayColumnValue",
				CreatedInSchemaUId = new Guid("21e82875-e7fa-4566-bc93-58c591ef5c56"),
				ModifiedInSchemaUId = new Guid("21e82875-e7fa-4566-bc93-58c591ef5c56"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateLookupRecordIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("dd1129aa-3bd5-42be-a20c-0024c3ce3bc0"),
				Name = @"LookupRecordId",
				CreatedInSchemaUId = new Guid("21e82875-e7fa-4566-bc93-58c591ef5c56"),
				ModifiedInSchemaUId = new Guid("21e82875-e7fa-4566-bc93-58c591ef5c56"),
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
			return new LookupConflict(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new LookupConflict_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new LookupConflictSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new LookupConflictSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("21e82875-e7fa-4566-bc93-58c591ef5c56"));
		}

		#endregion

	}

	#endregion

	#region Class: LookupConflict

	/// <summary>
	/// Lookup values to be validated by user.
	/// </summary>
	public class LookupConflict : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public LookupConflict(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "LookupConflict";
		}

		public LookupConflict(LookupConflict source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Solution item referring to lookup value.
		/// </summary>
		public string DestinationSchemaName {
			get {
				return GetTypedColumnValue<string>("DestinationSchemaName");
			}
			set {
				SetColumnValue("DestinationSchemaName", value);
			}
		}

		/// <summary>
		/// Id of record referring to lookup value.
		/// </summary>
		public Guid DestinationRecordId {
			get {
				return GetTypedColumnValue<Guid>("DestinationRecordId");
			}
			set {
				SetColumnValue("DestinationRecordId", value);
			}
		}

		/// <summary>
		/// Lookup field name.
		/// </summary>
		public string DestinationColumnName {
			get {
				return GetTypedColumnValue<string>("DestinationColumnName");
			}
			set {
				SetColumnValue("DestinationColumnName", value);
			}
		}

		/// <summary>
		/// Lookup name.
		/// </summary>
		public string LookupSchemaName {
			get {
				return GetTypedColumnValue<string>("LookupSchemaName");
			}
			set {
				SetColumnValue("LookupSchemaName", value);
			}
		}

		/// <summary>
		/// Field name to be displayed in lookup.
		/// </summary>
		public string LookupSchemaDisplayColumnName {
			get {
				return GetTypedColumnValue<string>("LookupSchemaDisplayColumnName");
			}
			set {
				SetColumnValue("LookupSchemaDisplayColumnName", value);
			}
		}

		/// <summary>
		/// Value of lookup field that was not found.
		/// </summary>
		public string LookupSchemaDisplayColumnValue {
			get {
				return GetTypedColumnValue<string>("LookupSchemaDisplayColumnValue");
			}
			set {
				SetColumnValue("LookupSchemaDisplayColumnValue", value);
			}
		}

		/// <summary>
		/// Lookup value selected by user.
		/// </summary>
		public Guid LookupRecordId {
			get {
				return GetTypedColumnValue<Guid>("LookupRecordId");
			}
			set {
				SetColumnValue("LookupRecordId", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new LookupConflict_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("LookupConflictDeleted", e);
			Inserting += (s, e) => ThrowEvent("LookupConflictInserting", e);
			Validating += (s, e) => ThrowEvent("LookupConflictValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new LookupConflict(this);
		}

		#endregion

	}

	#endregion

	#region Class: LookupConflict_BaseEventsProcess

	/// <exclude/>
	public partial class LookupConflict_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : LookupConflict
	{

		public LookupConflict_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "LookupConflict_BaseEventsProcess";
			SchemaUId = new Guid("21e82875-e7fa-4566-bc93-58c591ef5c56");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("21e82875-e7fa-4566-bc93-58c591ef5c56");
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

	#region Class: LookupConflict_BaseEventsProcess

	/// <exclude/>
	public class LookupConflict_BaseEventsProcess : LookupConflict_BaseEventsProcess<LookupConflict>
	{

		public LookupConflict_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: LookupConflict_BaseEventsProcess

	public partial class LookupConflict_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: LookupConflictEventsProcess

	/// <exclude/>
	public class LookupConflictEventsProcess : LookupConflict_BaseEventsProcess
	{

		public LookupConflictEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

