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

	#region Class: SysLookupColumnSchema

	/// <exclude/>
	public class SysLookupColumnSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysLookupColumnSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysLookupColumnSchema(SysLookupColumnSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysLookupColumnSchema(SysLookupColumnSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("6c654cdc-23c2-49ea-b957-8b5252bea05e");
			RealUId = new Guid("6c654cdc-23c2-49ea-b957-8b5252bea05e");
			Name = "SysLookupColumn";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("c8c10f8f-cfb2-454d-89f6-1fa2b845c0ea")) == null) {
				Columns.Add(CreateSysLookupColumn());
			}
			if (Columns.FindByUId(new Guid("219ff834-643d-4ad3-b154-48f81c3a9c07")) == null) {
				Columns.Add(CreateMetaPathColumn());
			}
			if (Columns.FindByUId(new Guid("d4305e9c-d71c-4b59-8e1c-8309d2970c2f")) == null) {
				Columns.Add(CreatePositionColumn());
			}
			if (Columns.FindByUId(new Guid("dbae20af-93a5-4df8-a239-7cc89873a61e")) == null) {
				Columns.Add(CreateCaptionColumn());
			}
			if (Columns.FindByUId(new Guid("be9f648c-cc8e-4e88-8adb-e9b852486155")) == null) {
				Columns.Add(CreateWidthColumn());
			}
			if (Columns.FindByUId(new Guid("e6806a6c-6698-4696-8e66-df3cfd9eb580")) == null) {
				Columns.Add(CreateSysOrderDirectionColumn());
			}
			if (Columns.FindByUId(new Guid("b72ca89d-b132-4b40-a26e-9d6d34d0ddaf")) == null) {
				Columns.Add(CreateMetaCaptionColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateSysLookupColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("c8c10f8f-cfb2-454d-89f6-1fa2b845c0ea"),
				Name = @"SysLookup",
				ReferenceSchemaUId = new Guid("aa3cc352-3095-43c9-ace8-6301f50a0a80"),
				IsCascade = true,
				CreatedInSchemaUId = new Guid("6c654cdc-23c2-49ea-b957-8b5252bea05e"),
				ModifiedInSchemaUId = new Guid("6c654cdc-23c2-49ea-b957-8b5252bea05e"),
				CreatedInPackageId = new Guid("773ffacd-4a58-4934-8cb2-5bf23386d08f")
			};
		}

		protected virtual EntitySchemaColumn CreateMetaPathColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("219ff834-643d-4ad3-b154-48f81c3a9c07"),
				Name = @"MetaPath",
				CreatedInSchemaUId = new Guid("6c654cdc-23c2-49ea-b957-8b5252bea05e"),
				ModifiedInSchemaUId = new Guid("6c654cdc-23c2-49ea-b957-8b5252bea05e"),
				CreatedInPackageId = new Guid("773ffacd-4a58-4934-8cb2-5bf23386d08f")
			};
		}

		protected virtual EntitySchemaColumn CreatePositionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("d4305e9c-d71c-4b59-8e1c-8309d2970c2f"),
				Name = @"Position",
				CreatedInSchemaUId = new Guid("6c654cdc-23c2-49ea-b957-8b5252bea05e"),
				ModifiedInSchemaUId = new Guid("6c654cdc-23c2-49ea-b957-8b5252bea05e"),
				CreatedInPackageId = new Guid("773ffacd-4a58-4934-8cb2-5bf23386d08f")
			};
		}

		protected virtual EntitySchemaColumn CreateCaptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("dbae20af-93a5-4df8-a239-7cc89873a61e"),
				Name = @"Caption",
				CreatedInSchemaUId = new Guid("6c654cdc-23c2-49ea-b957-8b5252bea05e"),
				ModifiedInSchemaUId = new Guid("6c654cdc-23c2-49ea-b957-8b5252bea05e"),
				CreatedInPackageId = new Guid("773ffacd-4a58-4934-8cb2-5bf23386d08f")
			};
		}

		protected virtual EntitySchemaColumn CreateWidthColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("be9f648c-cc8e-4e88-8adb-e9b852486155"),
				Name = @"Width",
				CreatedInSchemaUId = new Guid("6c654cdc-23c2-49ea-b957-8b5252bea05e"),
				ModifiedInSchemaUId = new Guid("6c654cdc-23c2-49ea-b957-8b5252bea05e"),
				CreatedInPackageId = new Guid("773ffacd-4a58-4934-8cb2-5bf23386d08f")
			};
		}

		protected virtual EntitySchemaColumn CreateSysOrderDirectionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("e6806a6c-6698-4696-8e66-df3cfd9eb580"),
				Name = @"SysOrderDirection",
				ReferenceSchemaUId = new Guid("a1198732-ee72-49a0-b9e7-2b61461f6122"),
				CreatedInSchemaUId = new Guid("6c654cdc-23c2-49ea-b957-8b5252bea05e"),
				ModifiedInSchemaUId = new Guid("6c654cdc-23c2-49ea-b957-8b5252bea05e"),
				CreatedInPackageId = new Guid("773ffacd-4a58-4934-8cb2-5bf23386d08f")
			};
		}

		protected virtual EntitySchemaColumn CreateMetaCaptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("b72ca89d-b132-4b40-a26e-9d6d34d0ddaf"),
				Name = @"MetaCaption",
				CreatedInSchemaUId = new Guid("6c654cdc-23c2-49ea-b957-8b5252bea05e"),
				ModifiedInSchemaUId = new Guid("6c654cdc-23c2-49ea-b957-8b5252bea05e"),
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
			return new SysLookupColumn(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysLookupColumn_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysLookupColumnSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysLookupColumnSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("6c654cdc-23c2-49ea-b957-8b5252bea05e"));
		}

		#endregion

	}

	#endregion

	#region Class: SysLookupColumn

	/// <summary>
	/// Lookup column.
	/// </summary>
	public class SysLookupColumn : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysLookupColumn(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysLookupColumn";
		}

		public SysLookupColumn(SysLookupColumn source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid SysLookupId {
			get {
				return GetTypedColumnValue<Guid>("SysLookupId");
			}
			set {
				SetColumnValue("SysLookupId", value);
				_sysLookup = null;
			}
		}

		/// <exclude/>
		public string SysLookupName {
			get {
				return GetTypedColumnValue<string>("SysLookupName");
			}
			set {
				SetColumnValue("SysLookupName", value);
				if (_sysLookup != null) {
					_sysLookup.Name = value;
				}
			}
		}

		private SysLookup _sysLookup;
		/// <summary>
		/// Lookup.
		/// </summary>
		public SysLookup SysLookup {
			get {
				return _sysLookup ??
					(_sysLookup = LookupColumnEntities.GetEntity("SysLookup") as SysLookup);
			}
		}

		/// <summary>
		/// Column Id.
		/// </summary>
		public string MetaPath {
			get {
				return GetTypedColumnValue<string>("MetaPath");
			}
			set {
				SetColumnValue("MetaPath", value);
			}
		}

		/// <summary>
		/// Position.
		/// </summary>
		public int Position {
			get {
				return GetTypedColumnValue<int>("Position");
			}
			set {
				SetColumnValue("Position", value);
			}
		}

		/// <summary>
		/// Title.
		/// </summary>
		public string Caption {
			get {
				return GetTypedColumnValue<string>("Caption");
			}
			set {
				SetColumnValue("Caption", value);
			}
		}

		/// <summary>
		/// Width.
		/// </summary>
		public int Width {
			get {
				return GetTypedColumnValue<int>("Width");
			}
			set {
				SetColumnValue("Width", value);
			}
		}

		/// <exclude/>
		public Guid SysOrderDirectionId {
			get {
				return GetTypedColumnValue<Guid>("SysOrderDirectionId");
			}
			set {
				SetColumnValue("SysOrderDirectionId", value);
				_sysOrderDirection = null;
			}
		}

		/// <exclude/>
		public string SysOrderDirectionName {
			get {
				return GetTypedColumnValue<string>("SysOrderDirectionName");
			}
			set {
				SetColumnValue("SysOrderDirectionName", value);
				if (_sysOrderDirection != null) {
					_sysOrderDirection.Name = value;
				}
			}
		}

		private SysOrderDirection _sysOrderDirection;
		/// <summary>
		/// Sort by.
		/// </summary>
		public SysOrderDirection SysOrderDirection {
			get {
				return _sysOrderDirection ??
					(_sysOrderDirection = LookupColumnEntities.GetEntity("SysOrderDirection") as SysOrderDirection);
			}
		}

		/// <summary>
		/// Column.
		/// </summary>
		public string MetaCaption {
			get {
				return GetTypedColumnValue<string>("MetaCaption");
			}
			set {
				SetColumnValue("MetaCaption", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysLookupColumn_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysLookupColumnDeleted", e);
			Deleting += (s, e) => ThrowEvent("SysLookupColumnDeleting", e);
			Inserted += (s, e) => ThrowEvent("SysLookupColumnInserted", e);
			Inserting += (s, e) => ThrowEvent("SysLookupColumnInserting", e);
			Saved += (s, e) => ThrowEvent("SysLookupColumnSaved", e);
			Saving += (s, e) => ThrowEvent("SysLookupColumnSaving", e);
			Validating += (s, e) => ThrowEvent("SysLookupColumnValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysLookupColumn(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysLookupColumn_BaseEventsProcess

	/// <exclude/>
	public partial class SysLookupColumn_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : SysLookupColumn
	{

		public SysLookupColumn_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysLookupColumn_BaseEventsProcess";
			SchemaUId = new Guid("6c654cdc-23c2-49ea-b957-8b5252bea05e");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("6c654cdc-23c2-49ea-b957-8b5252bea05e");
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

	#region Class: SysLookupColumn_BaseEventsProcess

	/// <exclude/>
	public class SysLookupColumn_BaseEventsProcess : SysLookupColumn_BaseEventsProcess<SysLookupColumn>
	{

		public SysLookupColumn_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysLookupColumn_BaseEventsProcess

	public partial class SysLookupColumn_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysLookupColumnEventsProcess

	/// <exclude/>
	public class SysLookupColumnEventsProcess : SysLookupColumn_BaseEventsProcess
	{

		public SysLookupColumnEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

