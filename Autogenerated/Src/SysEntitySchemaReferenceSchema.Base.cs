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

	#region Class: SysEntitySchemaReferenceSchema

	/// <exclude/>
	public class SysEntitySchemaReferenceSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysEntitySchemaReferenceSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysEntitySchemaReferenceSchema(SysEntitySchemaReferenceSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysEntitySchemaReferenceSchema(SysEntitySchemaReferenceSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("d1ce48da-3209-4661-b1d0-59361c1c6179");
			RealUId = new Guid("d1ce48da-3209-4661-b1d0-59361c1c6179");
			Name = "SysEntitySchemaReference";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("c5d1282b-7a3f-4441-aec0-d272080d37f8");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("cb9cc94a-b0cd-46ac-ab7f-aa1829a1cc41")) == null) {
				Columns.Add(CreateReferenceSchemaColumn());
			}
			if (Columns.FindByUId(new Guid("47bb4bdc-40a4-4a2f-8d53-17fcdad29c18")) == null) {
				Columns.Add(CreateUsageTypeColumn());
			}
			if (Columns.FindByUId(new Guid("00a3d3da-3d25-4c86-8d2f-14378963ee6a")) == null) {
				Columns.Add(CreateColumnUIdColumn());
			}
			if (Columns.FindByUId(new Guid("604a9879-fc76-4795-b38e-17ce8b687ace")) == null) {
				Columns.Add(CreateColumnNameColumn());
			}
			if (Columns.FindByUId(new Guid("76452fdc-5420-4f4d-9dcf-e50729adcf29")) == null) {
				Columns.Add(CreateSysSchemaColumn());
			}
			if (Columns.FindByUId(new Guid("8e821998-fd1d-4884-812e-a591e9cc2c18")) == null) {
				Columns.Add(CreateColumnCaptionColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateReferenceSchemaColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("cb9cc94a-b0cd-46ac-ab7f-aa1829a1cc41"),
				Name = @"ReferenceSchema",
				ReferenceSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("d1ce48da-3209-4661-b1d0-59361c1c6179"),
				ModifiedInSchemaUId = new Guid("d1ce48da-3209-4661-b1d0-59361c1c6179"),
				CreatedInPackageId = new Guid("c5d1282b-7a3f-4441-aec0-d272080d37f8")
			};
		}

		protected virtual EntitySchemaColumn CreateUsageTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("47bb4bdc-40a4-4a2f-8d53-17fcdad29c18"),
				Name = @"UsageType",
				CreatedInSchemaUId = new Guid("d1ce48da-3209-4661-b1d0-59361c1c6179"),
				ModifiedInSchemaUId = new Guid("d1ce48da-3209-4661-b1d0-59361c1c6179"),
				CreatedInPackageId = new Guid("c5d1282b-7a3f-4441-aec0-d272080d37f8")
			};
		}

		protected virtual EntitySchemaColumn CreateColumnUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("00a3d3da-3d25-4c86-8d2f-14378963ee6a"),
				Name = @"ColumnUId",
				CreatedInSchemaUId = new Guid("d1ce48da-3209-4661-b1d0-59361c1c6179"),
				ModifiedInSchemaUId = new Guid("d1ce48da-3209-4661-b1d0-59361c1c6179"),
				CreatedInPackageId = new Guid("c5d1282b-7a3f-4441-aec0-d272080d37f8")
			};
		}

		protected virtual EntitySchemaColumn CreateColumnNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("604a9879-fc76-4795-b38e-17ce8b687ace"),
				Name = @"ColumnName",
				CreatedInSchemaUId = new Guid("d1ce48da-3209-4661-b1d0-59361c1c6179"),
				ModifiedInSchemaUId = new Guid("d1ce48da-3209-4661-b1d0-59361c1c6179"),
				CreatedInPackageId = new Guid("c5d1282b-7a3f-4441-aec0-d272080d37f8")
			};
		}

		protected virtual EntitySchemaColumn CreateSysSchemaColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("76452fdc-5420-4f4d-9dcf-e50729adcf29"),
				Name = @"SysSchema",
				ReferenceSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("d1ce48da-3209-4661-b1d0-59361c1c6179"),
				ModifiedInSchemaUId = new Guid("d1ce48da-3209-4661-b1d0-59361c1c6179"),
				CreatedInPackageId = new Guid("c5d1282b-7a3f-4441-aec0-d272080d37f8")
			};
		}

		protected virtual EntitySchemaColumn CreateColumnCaptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("8e821998-fd1d-4884-812e-a591e9cc2c18"),
				Name = @"ColumnCaption",
				CreatedInSchemaUId = new Guid("d1ce48da-3209-4661-b1d0-59361c1c6179"),
				ModifiedInSchemaUId = new Guid("d1ce48da-3209-4661-b1d0-59361c1c6179"),
				CreatedInPackageId = new Guid("c5d1282b-7a3f-4441-aec0-d272080d37f8"),
				IsLocalizable = true
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysEntitySchemaReference(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysEntitySchemaReference_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysEntitySchemaReferenceSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysEntitySchemaReferenceSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("d1ce48da-3209-4661-b1d0-59361c1c6179"));
		}

		#endregion

	}

	#endregion

	#region Class: SysEntitySchemaReference

	/// <summary>
	/// Data schema reference.
	/// </summary>
	public class SysEntitySchemaReference : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysEntitySchemaReference(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysEntitySchemaReference";
		}

		public SysEntitySchemaReference(SysEntitySchemaReference source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid ReferenceSchemaId {
			get {
				return GetTypedColumnValue<Guid>("ReferenceSchemaId");
			}
			set {
				SetColumnValue("ReferenceSchemaId", value);
				_referenceSchema = null;
			}
		}

		/// <exclude/>
		public string ReferenceSchemaCaption {
			get {
				return GetTypedColumnValue<string>("ReferenceSchemaCaption");
			}
			set {
				SetColumnValue("ReferenceSchemaCaption", value);
				if (_referenceSchema != null) {
					_referenceSchema.Caption = value;
				}
			}
		}

		private SysSchema _referenceSchema;
		/// <summary>
		/// Reference schema.
		/// </summary>
		public SysSchema ReferenceSchema {
			get {
				return _referenceSchema ??
					(_referenceSchema = LookupColumnEntities.GetEntity("ReferenceSchema") as SysSchema);
			}
		}

		/// <summary>
		/// Usage mode.
		/// </summary>
		public int UsageType {
			get {
				return GetTypedColumnValue<int>("UsageType");
			}
			set {
				SetColumnValue("UsageType", value);
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

		/// <summary>
		/// Column name.
		/// </summary>
		public string ColumnName {
			get {
				return GetTypedColumnValue<string>("ColumnName");
			}
			set {
				SetColumnValue("ColumnName", value);
			}
		}

		/// <exclude/>
		public Guid SysSchemaId {
			get {
				return GetTypedColumnValue<Guid>("SysSchemaId");
			}
			set {
				SetColumnValue("SysSchemaId", value);
				_sysSchema = null;
			}
		}

		/// <exclude/>
		public string SysSchemaCaption {
			get {
				return GetTypedColumnValue<string>("SysSchemaCaption");
			}
			set {
				SetColumnValue("SysSchemaCaption", value);
				if (_sysSchema != null) {
					_sysSchema.Caption = value;
				}
			}
		}

		private SysSchema _sysSchema;
		/// <summary>
		/// Schema in solution.
		/// </summary>
		public SysSchema SysSchema {
			get {
				return _sysSchema ??
					(_sysSchema = LookupColumnEntities.GetEntity("SysSchema") as SysSchema);
			}
		}

		/// <summary>
		/// Column name.
		/// </summary>
		public string ColumnCaption {
			get {
				return GetTypedColumnValue<string>("ColumnCaption");
			}
			set {
				SetColumnValue("ColumnCaption", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysEntitySchemaReference_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysEntitySchemaReferenceDeleted", e);
			Validating += (s, e) => ThrowEvent("SysEntitySchemaReferenceValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysEntitySchemaReference(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysEntitySchemaReference_BaseEventsProcess

	/// <exclude/>
	public partial class SysEntitySchemaReference_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : SysEntitySchemaReference
	{

		public SysEntitySchemaReference_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysEntitySchemaReference_BaseEventsProcess";
			SchemaUId = new Guid("d1ce48da-3209-4661-b1d0-59361c1c6179");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("d1ce48da-3209-4661-b1d0-59361c1c6179");
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

	#region Class: SysEntitySchemaReference_BaseEventsProcess

	/// <exclude/>
	public class SysEntitySchemaReference_BaseEventsProcess : SysEntitySchemaReference_BaseEventsProcess<SysEntitySchemaReference>
	{

		public SysEntitySchemaReference_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysEntitySchemaReference_BaseEventsProcess

	public partial class SysEntitySchemaReference_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysEntitySchemaReferenceEventsProcess

	/// <exclude/>
	public class SysEntitySchemaReferenceEventsProcess : SysEntitySchemaReference_BaseEventsProcess
	{

		public SysEntitySchemaReferenceEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

