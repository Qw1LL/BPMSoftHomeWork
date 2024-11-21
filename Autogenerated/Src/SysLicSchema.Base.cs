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

	#region Class: SysLicSchema

	/// <exclude/>
	public class SysLicSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysLicSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysLicSchema(SysLicSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysLicSchema(SysLicSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("304b4026-1343-4f34-b937-f65da9e50bfc");
			RealUId = new Guid("304b4026-1343-4f34-b937-f65da9e50bfc");
			Name = "SysLic";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("28ab3dc2-2cc8-446c-bc43-eb54f0fd3133")) == null) {
				Columns.Add(CreateSysLicPackageColumn());
			}
			if (Columns.FindByUId(new Guid("e2e9ee2a-d3f0-4110-95db-4d7c1054d399")) == null) {
				Columns.Add(CreateCountColumn());
			}
			if (Columns.FindByUId(new Guid("e628cf0e-5d33-448b-a265-3f2dc2cba5df")) == null) {
				Columns.Add(CreateDueDateColumn());
			}
			if (Columns.FindByUId(new Guid("976e9c4c-5234-431b-ac56-7dcbc721419d")) == null) {
				Columns.Add(CreateKeyColumn());
			}
			if (Columns.FindByUId(new Guid("48ba6657-4228-4807-b31b-fa7b3740ea43")) == null) {
				Columns.Add(CreateStartDateColumn());
			}
			if (Columns.FindByUId(new Guid("c4611de5-a997-4d9b-8a88-bb7a2ea1b423")) == null) {
				Columns.Add(CreateLicTypeColumn());
			}
			if (Columns.FindByUId(new Guid("0d58fe5f-422a-4ccf-a487-c97dcddbccff")) == null) {
				Columns.Add(CreateSSPSchemaCountColumn());
			}
			if (Columns.FindByUId(new Guid("ed42a6f3-55f2-4bb6-a57d-5040f0e66589")) == null) {
				Columns.Add(CreateSSPAdministratedSchemaCountColumn());
			}
			if (Columns.FindByUId(new Guid("3cebb19b-1519-4acb-bda2-15ae72db3d93")) == null) {
				Columns.Add(CreateSSPCustomEntityCountColumn());
			}
			if (Columns.FindByUId(new Guid("6a2e9edb-a411-e962-858b-f062d02b3350")) == null) {
				Columns.Add(CreateLicVersionColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateSysLicPackageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("28ab3dc2-2cc8-446c-bc43-eb54f0fd3133"),
				Name = @"SysLicPackage",
				ReferenceSchemaUId = new Guid("bba64ad2-ff65-46f4-911d-4068aa0af48a"),
				CreatedInSchemaUId = new Guid("304b4026-1343-4f34-b937-f65da9e50bfc"),
				ModifiedInSchemaUId = new Guid("304b4026-1343-4f34-b937-f65da9e50bfc"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateCountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("e2e9ee2a-d3f0-4110-95db-4d7c1054d399"),
				Name = @"Count",
				CreatedInSchemaUId = new Guid("304b4026-1343-4f34-b937-f65da9e50bfc"),
				ModifiedInSchemaUId = new Guid("304b4026-1343-4f34-b937-f65da9e50bfc"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateDueDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("e628cf0e-5d33-448b-a265-3f2dc2cba5df"),
				Name = @"DueDate",
				CreatedInSchemaUId = new Guid("304b4026-1343-4f34-b937-f65da9e50bfc"),
				ModifiedInSchemaUId = new Guid("304b4026-1343-4f34-b937-f65da9e50bfc"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateKeyColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("976e9c4c-5234-431b-ac56-7dcbc721419d"),
				Name = @"Key",
				CreatedInSchemaUId = new Guid("304b4026-1343-4f34-b937-f65da9e50bfc"),
				ModifiedInSchemaUId = new Guid("304b4026-1343-4f34-b937-f65da9e50bfc"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateStartDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Date")) {
				UId = new Guid("48ba6657-4228-4807-b31b-fa7b3740ea43"),
				Name = @"StartDate",
				CreatedInSchemaUId = new Guid("304b4026-1343-4f34-b937-f65da9e50bfc"),
				ModifiedInSchemaUId = new Guid("304b4026-1343-4f34-b937-f65da9e50bfc"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateLicTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ValueList")) {
				UId = new Guid("c4611de5-a997-4d9b-8a88-bb7a2ea1b423"),
				Name = @"LicType",
				ReferenceValueListSchemaUId = new Guid("fbf0632a-b7f3-43e7-b27d-682bbe8b93d7"),
				CreatedInSchemaUId = new Guid("304b4026-1343-4f34-b937-f65da9e50bfc"),
				ModifiedInSchemaUId = new Guid("304b4026-1343-4f34-b937-f65da9e50bfc"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateSSPSchemaCountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("0d58fe5f-422a-4ccf-a487-c97dcddbccff"),
				Name = @"SSPSchemaCount",
				CreatedInSchemaUId = new Guid("304b4026-1343-4f34-b937-f65da9e50bfc"),
				ModifiedInSchemaUId = new Guid("304b4026-1343-4f34-b937-f65da9e50bfc"),
				CreatedInPackageId = new Guid("0bea0088-e6a2-4f3a-b02e-e01a15923e73")
			};
		}

		protected virtual EntitySchemaColumn CreateSSPAdministratedSchemaCountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("ed42a6f3-55f2-4bb6-a57d-5040f0e66589"),
				Name = @"SSPAdministratedSchemaCount",
				CreatedInSchemaUId = new Guid("304b4026-1343-4f34-b937-f65da9e50bfc"),
				ModifiedInSchemaUId = new Guid("304b4026-1343-4f34-b937-f65da9e50bfc"),
				CreatedInPackageId = new Guid("0bea0088-e6a2-4f3a-b02e-e01a15923e73")
			};
		}

		protected virtual EntitySchemaColumn CreateSSPCustomEntityCountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("3cebb19b-1519-4acb-bda2-15ae72db3d93"),
				Name = @"SSPCustomEntityCount",
				CreatedInSchemaUId = new Guid("304b4026-1343-4f34-b937-f65da9e50bfc"),
				ModifiedInSchemaUId = new Guid("304b4026-1343-4f34-b937-f65da9e50bfc"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateLicVersionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("6a2e9edb-a411-e962-858b-f062d02b3350"),
				Name = @"LicVersion",
				CreatedInSchemaUId = new Guid("304b4026-1343-4f34-b937-f65da9e50bfc"),
				ModifiedInSchemaUId = new Guid("304b4026-1343-4f34-b937-f65da9e50bfc"),
				CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysLic(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysLic_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysLicSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysLicSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("304b4026-1343-4f34-b937-f65da9e50bfc"));
		}

		#endregion

	}

	#endregion

	#region Class: SysLic

	/// <summary>
	/// License.
	/// </summary>
	public class SysLic : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysLic(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysLic";
		}

		public SysLic(SysLic source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid SysLicPackageId {
			get {
				return GetTypedColumnValue<Guid>("SysLicPackageId");
			}
			set {
				SetColumnValue("SysLicPackageId", value);
				_sysLicPackage = null;
			}
		}

		/// <exclude/>
		public string SysLicPackageName {
			get {
				return GetTypedColumnValue<string>("SysLicPackageName");
			}
			set {
				SetColumnValue("SysLicPackageName", value);
				if (_sysLicPackage != null) {
					_sysLicPackage.Name = value;
				}
			}
		}

		private SysLicPackage _sysLicPackage;
		/// <summary>
		/// Licensed configuration.
		/// </summary>
		public SysLicPackage SysLicPackage {
			get {
				return _sysLicPackage ??
					(_sysLicPackage = LookupColumnEntities.GetEntity("SysLicPackage") as SysLicPackage);
			}
		}

		/// <summary>
		/// Quantity.
		/// </summary>
		public int Count {
			get {
				return GetTypedColumnValue<int>("Count");
			}
			set {
				SetColumnValue("Count", value);
			}
		}

		/// <summary>
		/// End date.
		/// </summary>
		public DateTime DueDate {
			get {
				return GetTypedColumnValue<DateTime>("DueDate");
			}
			set {
				SetColumnValue("DueDate", value);
			}
		}

		/// <summary>
		/// Key.
		/// </summary>
		public string Key {
			get {
				return GetTypedColumnValue<string>("Key");
			}
			set {
				SetColumnValue("Key", value);
			}
		}

		/// <summary>
		/// Start date.
		/// </summary>
		public DateTime StartDate {
			get {
				return GetTypedColumnValue<DateTime>("StartDate");
			}
			set {
				SetColumnValue("StartDate", value);
			}
		}

		/// <summary>
		/// License type.
		/// </summary>
		public SysLicType? LicType {
			get {
				return GetTypedColumnValue<SysLicType>("LicType");
			}
			set {
				SetColumnValue("LicType", value);
			}
		}

		/// <summary>
		/// Quantity of objects available for portal users.
		/// </summary>
		public int SSPSchemaCount {
			get {
				return GetTypedColumnValue<int>("SSPSchemaCount");
			}
			set {
				SetColumnValue("SSPSchemaCount", value);
			}
		}

		/// <summary>
		/// Quantity of managed objects available for portal users.
		/// </summary>
		public int SSPAdministratedSchemaCount {
			get {
				return GetTypedColumnValue<int>("SSPAdministratedSchemaCount");
			}
			set {
				SetColumnValue("SSPAdministratedSchemaCount", value);
			}
		}

		/// <summary>
		/// Quantity of custom objects available for portal users.
		/// </summary>
		public int SSPCustomEntityCount {
			get {
				return GetTypedColumnValue<int>("SSPCustomEntityCount");
			}
			set {
				SetColumnValue("SSPCustomEntityCount", value);
			}
		}

		/// <summary>
		/// License version.
		/// </summary>
		public string LicVersion {
			get {
				return GetTypedColumnValue<string>("LicVersion");
			}
			set {
				SetColumnValue("LicVersion", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysLic_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysLicDeleted", e);
			Deleting += (s, e) => ThrowEvent("SysLicDeleting", e);
			Inserted += (s, e) => ThrowEvent("SysLicInserted", e);
			Inserting += (s, e) => ThrowEvent("SysLicInserting", e);
			Saved += (s, e) => ThrowEvent("SysLicSaved", e);
			Saving += (s, e) => ThrowEvent("SysLicSaving", e);
			Validating += (s, e) => ThrowEvent("SysLicValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysLic(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysLic_BaseEventsProcess

	/// <exclude/>
	public partial class SysLic_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : SysLic
	{

		public SysLic_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysLic_BaseEventsProcess";
			SchemaUId = new Guid("304b4026-1343-4f34-b937-f65da9e50bfc");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("304b4026-1343-4f34-b937-f65da9e50bfc");
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

	#region Class: SysLic_BaseEventsProcess

	/// <exclude/>
	public class SysLic_BaseEventsProcess : SysLic_BaseEventsProcess<SysLic>
	{

		public SysLic_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysLic_BaseEventsProcess

	public partial class SysLic_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysLicEventsProcess

	/// <exclude/>
	public class SysLicEventsProcess : SysLic_BaseEventsProcess
	{

		public SysLicEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

