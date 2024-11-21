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

	#region Class: SysModuleActionSchema

	/// <exclude/>
	public class SysModuleActionSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysModuleActionSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysModuleActionSchema(SysModuleActionSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysModuleActionSchema(SysModuleActionSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("37eaa24a-e8e3-4020-8a16-30569db5c926");
			RealUId = new Guid("37eaa24a-e8e3-4020-8a16-30569db5c926");
			Name = "SysModuleAction";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateCaptionColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializePrimaryImageColumn() {
			base.InitializePrimaryImageColumn();
			PrimaryImageColumn = CreateImageColumn();
			if (Columns.FindByUId(PrimaryImageColumn.UId) == null) {
				Columns.Add(PrimaryImageColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("6c0e0195-3608-4864-8908-918a89c893f6")) == null) {
				Columns.Add(CreateSysModuleColumn());
			}
			if (Columns.FindByUId(new Guid("4312f0a6-fc55-41ad-9812-356ebf877fd0")) == null) {
				Columns.Add(CreateHelpContextIdColumn());
			}
			if (Columns.FindByUId(new Guid("34d0bed6-4b14-4a75-9160-0437b8036b59")) == null) {
				Columns.Add(CreatePositionColumn());
			}
			if (Columns.FindByUId(new Guid("79b2b9c0-8dd9-4608-83a1-a6fd92d21d67")) == null) {
				Columns.Add(CreateTypeColumn());
			}
			if (Columns.FindByUId(new Guid("c635eb37-2cc2-420d-9b81-4f74eb0cd092")) == null) {
				Columns.Add(CreateSysProcessSchemaUIdColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateCaptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("5c30bd57-fb4b-4e85-b859-0a57be2e9ca2"),
				Name = @"Caption",
				CreatedInSchemaUId = new Guid("37eaa24a-e8e3-4020-8a16-30569db5c926"),
				ModifiedInSchemaUId = new Guid("37eaa24a-e8e3-4020-8a16-30569db5c926"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				IsLocalizable = true
			};
		}

		protected virtual EntitySchemaColumn CreateSysModuleColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("6c0e0195-3608-4864-8908-918a89c893f6"),
				Name = @"SysModule",
				ReferenceSchemaUId = new Guid("2b2ed767-0b4b-4a7b-9de2-d48e14a2c0c5"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("37eaa24a-e8e3-4020-8a16-30569db5c926"),
				ModifiedInSchemaUId = new Guid("37eaa24a-e8e3-4020-8a16-30569db5c926"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateHelpContextIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("4312f0a6-fc55-41ad-9812-356ebf877fd0"),
				Name = @"HelpContextId",
				CreatedInSchemaUId = new Guid("37eaa24a-e8e3-4020-8a16-30569db5c926"),
				ModifiedInSchemaUId = new Guid("37eaa24a-e8e3-4020-8a16-30569db5c926"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreatePositionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("34d0bed6-4b14-4a75-9160-0437b8036b59"),
				Name = @"Position",
				CreatedInSchemaUId = new Guid("37eaa24a-e8e3-4020-8a16-30569db5c926"),
				ModifiedInSchemaUId = new Guid("37eaa24a-e8e3-4020-8a16-30569db5c926"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("79b2b9c0-8dd9-4608-83a1-a6fd92d21d67"),
				Name = @"Type",
				ReferenceSchemaUId = new Guid("2286fa11-92f8-4c30-9aa7-0d9c20ddb599"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("37eaa24a-e8e3-4020-8a16-30569db5c926"),
				ModifiedInSchemaUId = new Guid("37eaa24a-e8e3-4020-8a16-30569db5c926"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateImageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Image")) {
				UId = new Guid("1f88615d-5709-4d4b-bad3-0e09bedd7170"),
				Name = @"Image",
				CreatedInSchemaUId = new Guid("37eaa24a-e8e3-4020-8a16-30569db5c926"),
				ModifiedInSchemaUId = new Guid("37eaa24a-e8e3-4020-8a16-30569db5c926"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateSysProcessSchemaUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("c635eb37-2cc2-420d-9b81-4f74eb0cd092"),
				Name = @"SysProcessSchemaUId",
				CreatedInSchemaUId = new Guid("37eaa24a-e8e3-4020-8a16-30569db5c926"),
				ModifiedInSchemaUId = new Guid("37eaa24a-e8e3-4020-8a16-30569db5c926"),
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
			return new SysModuleAction(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysModuleAction_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysModuleActionSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysModuleActionSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("37eaa24a-e8e3-4020-8a16-30569db5c926"));
		}

		#endregion

	}

	#endregion

	#region Class: SysModuleAction

	/// <summary>
	/// Action.
	/// </summary>
	public class SysModuleAction : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysModuleAction(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysModuleAction";
		}

		public SysModuleAction(SysModuleAction source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

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

		/// <exclude/>
		public Guid SysModuleId {
			get {
				return GetTypedColumnValue<Guid>("SysModuleId");
			}
			set {
				SetColumnValue("SysModuleId", value);
				_sysModule = null;
			}
		}

		/// <exclude/>
		public string SysModuleCaption {
			get {
				return GetTypedColumnValue<string>("SysModuleCaption");
			}
			set {
				SetColumnValue("SysModuleCaption", value);
				if (_sysModule != null) {
					_sysModule.Caption = value;
				}
			}
		}

		private SysModule _sysModule;
		/// <summary>
		/// Section.
		/// </summary>
		public SysModule SysModule {
			get {
				return _sysModule ??
					(_sysModule = LookupColumnEntities.GetEntity("SysModule") as SysModule);
			}
		}

		/// <summary>
		/// Contextual help Id.
		/// </summary>
		public string HelpContextId {
			get {
				return GetTypedColumnValue<string>("HelpContextId");
			}
			set {
				SetColumnValue("HelpContextId", value);
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

		/// <exclude/>
		public Guid TypeId {
			get {
				return GetTypedColumnValue<Guid>("TypeId");
			}
			set {
				SetColumnValue("TypeId", value);
				_type = null;
			}
		}

		/// <exclude/>
		public string TypeName {
			get {
				return GetTypedColumnValue<string>("TypeName");
			}
			set {
				SetColumnValue("TypeName", value);
				if (_type != null) {
					_type.Name = value;
				}
			}
		}

		private SysModuleActionType _type;
		/// <summary>
		/// Type.
		/// </summary>
		public SysModuleActionType Type {
			get {
				return _type ??
					(_type = LookupColumnEntities.GetEntity("Type") as SysModuleActionType);
			}
		}

		/// <summary>
		/// Unique identifier of process.
		/// </summary>
		public Guid SysProcessSchemaUId {
			get {
				return GetTypedColumnValue<Guid>("SysProcessSchemaUId");
			}
			set {
				SetColumnValue("SysProcessSchemaUId", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysModuleAction_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysModuleActionDeleted", e);
			Deleting += (s, e) => ThrowEvent("SysModuleActionDeleting", e);
			Inserted += (s, e) => ThrowEvent("SysModuleActionInserted", e);
			Inserting += (s, e) => ThrowEvent("SysModuleActionInserting", e);
			Saved += (s, e) => ThrowEvent("SysModuleActionSaved", e);
			Saving += (s, e) => ThrowEvent("SysModuleActionSaving", e);
			Validating += (s, e) => ThrowEvent("SysModuleActionValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysModuleAction(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysModuleAction_BaseEventsProcess

	/// <exclude/>
	public partial class SysModuleAction_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : SysModuleAction
	{

		public SysModuleAction_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysModuleAction_BaseEventsProcess";
			SchemaUId = new Guid("37eaa24a-e8e3-4020-8a16-30569db5c926");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("37eaa24a-e8e3-4020-8a16-30569db5c926");
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

	#region Class: SysModuleAction_BaseEventsProcess

	/// <exclude/>
	public class SysModuleAction_BaseEventsProcess : SysModuleAction_BaseEventsProcess<SysModuleAction>
	{

		public SysModuleAction_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysModuleAction_BaseEventsProcess

	public partial class SysModuleAction_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysModuleActionEventsProcess

	/// <exclude/>
	public class SysModuleActionEventsProcess : SysModuleAction_BaseEventsProcess
	{

		public SysModuleActionEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

