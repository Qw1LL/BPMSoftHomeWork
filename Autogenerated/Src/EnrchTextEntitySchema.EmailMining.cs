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

	#region Class: EnrchTextEntitySchema

	/// <exclude/>
	public class EnrchTextEntitySchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public EnrchTextEntitySchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public EnrchTextEntitySchema(EnrchTextEntitySchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public EnrchTextEntitySchema(EnrchTextEntitySchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("e16b324c-1d23-46e5-878b-1591324f532f");
			RealUId = new Guid("e16b324c-1d23-46e5-878b-1591324f532f");
			Name = "EnrchTextEntity";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("c1529436-dee9-4290-84f1-87386440a2b1");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateHashColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("447807b8-522b-4a4c-a626-313557ddb0ee")) == null) {
				Columns.Add(CreateEnrchEmailDataColumn());
			}
			if (Columns.FindByUId(new Guid("4a8c8d6f-38a4-41bc-9b3a-1fe633d36f31")) == null) {
				Columns.Add(CreateTypeColumn());
			}
			if (Columns.FindByUId(new Guid("34c1d542-5a17-4491-a3c2-cb112d9e6ac1")) == null) {
				Columns.Add(CreateJsonDataColumn());
			}
			if (Columns.FindByUId(new Guid("c92e96cc-9f70-449d-a293-7356efbf8b21")) == null) {
				Columns.Add(CreateParentColumn());
			}
			if (Columns.FindByUId(new Guid("fbe986b2-8cec-438d-814c-b0f1efeab3f6")) == null) {
				Columns.Add(CreateDuplicationStatusColumn());
			}
			if (Columns.FindByUId(new Guid("1f000672-c264-4118-ae2f-95a0c91309f9")) == null) {
				Columns.Add(CreateSourceColumn());
			}
			if (Columns.FindByUId(new Guid("0ed98c09-1186-4125-9f79-4594a2dd8539")) == null) {
				Columns.Add(CreateHashVersionColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateEnrchEmailDataColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("447807b8-522b-4a4c-a626-313557ddb0ee"),
				Name = @"EnrchEmailData",
				ReferenceSchemaUId = new Guid("26d5f6ad-8525-4ceb-b3e5-af8fdf2964f6"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("e16b324c-1d23-46e5-878b-1591324f532f"),
				ModifiedInSchemaUId = new Guid("e16b324c-1d23-46e5-878b-1591324f532f"),
				CreatedInPackageId = new Guid("c1529436-dee9-4290-84f1-87386440a2b1")
			};
		}

		protected virtual EntitySchemaColumn CreateTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("4a8c8d6f-38a4-41bc-9b3a-1fe633d36f31"),
				Name = @"Type",
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("e16b324c-1d23-46e5-878b-1591324f532f"),
				ModifiedInSchemaUId = new Guid("e16b324c-1d23-46e5-878b-1591324f532f"),
				CreatedInPackageId = new Guid("c1529436-dee9-4290-84f1-87386440a2b1")
			};
		}

		protected virtual EntitySchemaColumn CreateJsonDataColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("34c1d542-5a17-4491-a3c2-cb112d9e6ac1"),
				Name = @"JsonData",
				CreatedInSchemaUId = new Guid("e16b324c-1d23-46e5-878b-1591324f532f"),
				ModifiedInSchemaUId = new Guid("e16b324c-1d23-46e5-878b-1591324f532f"),
				CreatedInPackageId = new Guid("c1529436-dee9-4290-84f1-87386440a2b1")
			};
		}

		protected virtual EntitySchemaColumn CreateHashColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("60398d95-9d61-4b73-b236-2b0d55b5ebd1"),
				Name = @"Hash",
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("e16b324c-1d23-46e5-878b-1591324f532f"),
				ModifiedInSchemaUId = new Guid("e16b324c-1d23-46e5-878b-1591324f532f"),
				CreatedInPackageId = new Guid("c1529436-dee9-4290-84f1-87386440a2b1")
			};
		}

		protected virtual EntitySchemaColumn CreateParentColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("c92e96cc-9f70-449d-a293-7356efbf8b21"),
				Name = @"Parent",
				ReferenceSchemaUId = new Guid("e16b324c-1d23-46e5-878b-1591324f532f"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("e16b324c-1d23-46e5-878b-1591324f532f"),
				ModifiedInSchemaUId = new Guid("e16b324c-1d23-46e5-878b-1591324f532f"),
				CreatedInPackageId = new Guid("c1529436-dee9-4290-84f1-87386440a2b1")
			};
		}

		protected virtual EntitySchemaColumn CreateDuplicationStatusColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("fbe986b2-8cec-438d-814c-b0f1efeab3f6"),
				Name = @"DuplicationStatus",
				CreatedInSchemaUId = new Guid("e16b324c-1d23-46e5-878b-1591324f532f"),
				ModifiedInSchemaUId = new Guid("e16b324c-1d23-46e5-878b-1591324f532f"),
				CreatedInPackageId = new Guid("b6327e89-1dee-4b6f-a695-226c016beae1")
			};
		}

		protected virtual EntitySchemaColumn CreateSourceColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("1f000672-c264-4118-ae2f-95a0c91309f9"),
				Name = @"Source",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("e16b324c-1d23-46e5-878b-1591324f532f"),
				ModifiedInSchemaUId = new Guid("e16b324c-1d23-46e5-878b-1591324f532f"),
				CreatedInPackageId = new Guid("b6327e89-1dee-4b6f-a695-226c016beae1")
			};
		}

		protected virtual EntitySchemaColumn CreateHashVersionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("0ed98c09-1186-4125-9f79-4594a2dd8539"),
				Name = @"HashVersion",
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("e16b324c-1d23-46e5-878b-1591324f532f"),
				ModifiedInSchemaUId = new Guid("e16b324c-1d23-46e5-878b-1591324f532f"),
				CreatedInPackageId = new Guid("b6327e89-1dee-4b6f-a695-226c016beae1")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new EnrchTextEntity(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new EnrchTextEntity_EmailMiningEventsProcess(userConnection);
		}

		public override object Clone() {
			return new EnrchTextEntitySchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new EnrchTextEntitySchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("e16b324c-1d23-46e5-878b-1591324f532f"));
		}

		#endregion

	}

	#endregion

	#region Class: EnrchTextEntity

	/// <summary>
	/// Unprocessed enriched data.
	/// </summary>
	public class EnrchTextEntity : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public EnrchTextEntity(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "EnrchTextEntity";
		}

		public EnrchTextEntity(EnrchTextEntity source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid EnrchEmailDataId {
			get {
				return GetTypedColumnValue<Guid>("EnrchEmailDataId");
			}
			set {
				SetColumnValue("EnrchEmailDataId", value);
				_enrchEmailData = null;
			}
		}

		/// <exclude/>
		public string EnrchEmailDataHash {
			get {
				return GetTypedColumnValue<string>("EnrchEmailDataHash");
			}
			set {
				SetColumnValue("EnrchEmailDataHash", value);
				if (_enrchEmailData != null) {
					_enrchEmailData.Hash = value;
				}
			}
		}

		private EnrchEmailData _enrchEmailData;
		/// <summary>
		/// Found in the e-mail data.
		/// </summary>
		public EnrchEmailData EnrchEmailData {
			get {
				return _enrchEmailData ??
					(_enrchEmailData = LookupColumnEntities.GetEntity("EnrchEmailData") as EnrchEmailData);
			}
		}

		/// <summary>
		/// Data type.
		/// </summary>
		public string Type {
			get {
				return GetTypedColumnValue<string>("Type");
			}
			set {
				SetColumnValue("Type", value);
			}
		}

		/// <summary>
		/// Relative part of enrichment service response.
		/// </summary>
		public string JsonData {
			get {
				return GetTypedColumnValue<string>("JsonData");
			}
			set {
				SetColumnValue("JsonData", value);
			}
		}

		/// <summary>
		/// Hash code of mined data item.
		/// </summary>
		public string Hash {
			get {
				return GetTypedColumnValue<string>("Hash");
			}
			set {
				SetColumnValue("Hash", value);
			}
		}

		/// <exclude/>
		public Guid ParentId {
			get {
				return GetTypedColumnValue<Guid>("ParentId");
			}
			set {
				SetColumnValue("ParentId", value);
				_parent = null;
			}
		}

		/// <exclude/>
		public string ParentHash {
			get {
				return GetTypedColumnValue<string>("ParentHash");
			}
			set {
				SetColumnValue("ParentHash", value);
				if (_parent != null) {
					_parent.Hash = value;
				}
			}
		}

		private EnrchTextEntity _parent;
		/// <summary>
		/// Parent entity.
		/// </summary>
		public EnrchTextEntity Parent {
			get {
				return _parent ??
					(_parent = LookupColumnEntities.GetEntity("Parent") as EnrchTextEntity);
			}
		}

		/// <summary>
		/// Dupication status.
		/// </summary>
		public string DuplicationStatus {
			get {
				return GetTypedColumnValue<string>("DuplicationStatus");
			}
			set {
				SetColumnValue("DuplicationStatus", value);
			}
		}

		/// <summary>
		/// Source.
		/// </summary>
		public string Source {
			get {
				return GetTypedColumnValue<string>("Source");
			}
			set {
				SetColumnValue("Source", value);
			}
		}

		/// <summary>
		/// Version of hash.
		/// </summary>
		public int HashVersion {
			get {
				return GetTypedColumnValue<int>("HashVersion");
			}
			set {
				SetColumnValue("HashVersion", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new EnrchTextEntity_EmailMiningEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("EnrchTextEntityDeleted", e);
			Validating += (s, e) => ThrowEvent("EnrchTextEntityValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new EnrchTextEntity(this);
		}

		#endregion

	}

	#endregion

	#region Class: EnrchTextEntity_EmailMiningEventsProcess

	/// <exclude/>
	public partial class EnrchTextEntity_EmailMiningEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : EnrchTextEntity
	{

		public EnrchTextEntity_EmailMiningEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "EnrchTextEntity_EmailMiningEventsProcess";
			SchemaUId = new Guid("e16b324c-1d23-46e5-878b-1591324f532f");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("e16b324c-1d23-46e5-878b-1591324f532f");
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

	#region Class: EnrchTextEntity_EmailMiningEventsProcess

	/// <exclude/>
	public class EnrchTextEntity_EmailMiningEventsProcess : EnrchTextEntity_EmailMiningEventsProcess<EnrchTextEntity>
	{

		public EnrchTextEntity_EmailMiningEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: EnrchTextEntity_EmailMiningEventsProcess

	public partial class EnrchTextEntity_EmailMiningEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: EnrchTextEntityEventsProcess

	/// <exclude/>
	public class EnrchTextEntityEventsProcess : EnrchTextEntity_EmailMiningEventsProcess
	{

		public EnrchTextEntityEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

