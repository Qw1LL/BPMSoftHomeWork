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

	#region Class: LMColumnTemplateSchema

	/// <exclude/>
	public class LMColumnTemplateSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public LMColumnTemplateSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public LMColumnTemplateSchema(LMColumnTemplateSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public LMColumnTemplateSchema(LMColumnTemplateSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("0efb7365-699f-4160-9fa0-95f45b0857b4");
			RealUId = new Guid("0efb7365-699f-4160-9fa0-95f45b0857b4");
			Name = "LMColumnTemplate";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("ca4727b2-fc6c-4ae4-bb8b-429fb21e5974");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateColumnNameColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("bbf9090d-6e34-45ed-b811-c99612da9498")) == null) {
				Columns.Add(CreateIsLinkColumn());
			}
			if (Columns.FindByUId(new Guid("5fef24e8-6ff2-48f3-9cf0-20a61d00d4b6")) == null) {
				Columns.Add(CreateIsOnChangeColumn());
			}
			if (Columns.FindByUId(new Guid("0ae60add-73fc-42d1-a404-579e204d0e76")) == null) {
				Columns.Add(CreateLMStartEventColumn());
			}
			if (Columns.FindByUId(new Guid("d06f139d-f520-4de7-80c3-f7e31de5e41b")) == null) {
				Columns.Add(CreatePositionColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateColumnNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("f56bbfb6-de33-4e51-a455-c8fe7bcbf28f"),
				Name = @"ColumnName",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("0efb7365-699f-4160-9fa0-95f45b0857b4"),
				ModifiedInSchemaUId = new Guid("0efb7365-699f-4160-9fa0-95f45b0857b4"),
				CreatedInPackageId = new Guid("ca4727b2-fc6c-4ae4-bb8b-429fb21e5974")
			};
		}

		protected virtual EntitySchemaColumn CreateIsLinkColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("bbf9090d-6e34-45ed-b811-c99612da9498"),
				Name = @"IsLink",
				CreatedInSchemaUId = new Guid("0efb7365-699f-4160-9fa0-95f45b0857b4"),
				ModifiedInSchemaUId = new Guid("0efb7365-699f-4160-9fa0-95f45b0857b4"),
				CreatedInPackageId = new Guid("ca4727b2-fc6c-4ae4-bb8b-429fb21e5974")
			};
		}

		protected virtual EntitySchemaColumn CreateIsOnChangeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("5fef24e8-6ff2-48f3-9cf0-20a61d00d4b6"),
				Name = @"IsOnChange",
				CreatedInSchemaUId = new Guid("0efb7365-699f-4160-9fa0-95f45b0857b4"),
				ModifiedInSchemaUId = new Guid("0efb7365-699f-4160-9fa0-95f45b0857b4"),
				CreatedInPackageId = new Guid("ca4727b2-fc6c-4ae4-bb8b-429fb21e5974")
			};
		}

		protected virtual EntitySchemaColumn CreateLMStartEventColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("0ae60add-73fc-42d1-a404-579e204d0e76"),
				Name = @"LMStartEvent",
				ReferenceSchemaUId = new Guid("a1490766-e92b-413f-96c8-49bdd8058628"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("0efb7365-699f-4160-9fa0-95f45b0857b4"),
				ModifiedInSchemaUId = new Guid("0efb7365-699f-4160-9fa0-95f45b0857b4"),
				CreatedInPackageId = new Guid("ca4727b2-fc6c-4ae4-bb8b-429fb21e5974")
			};
		}

		protected virtual EntitySchemaColumn CreatePositionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("d06f139d-f520-4de7-80c3-f7e31de5e41b"),
				Name = @"Position",
				CreatedInSchemaUId = new Guid("0efb7365-699f-4160-9fa0-95f45b0857b4"),
				ModifiedInSchemaUId = new Guid("0efb7365-699f-4160-9fa0-95f45b0857b4"),
				CreatedInPackageId = new Guid("3644c994-8f85-41ec-8125-47013bac161f")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new LMColumnTemplate(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new LMColumnTemplate_LocalMessageEventsProcess(userConnection);
		}

		public override object Clone() {
			return new LMColumnTemplateSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new LMColumnTemplateSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("0efb7365-699f-4160-9fa0-95f45b0857b4"));
		}

		#endregion

	}

	#endregion

	#region Class: LMColumnTemplate

	/// <summary>
	/// Шаблоны колонок системных сообщений.
	/// </summary>
	public class LMColumnTemplate : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public LMColumnTemplate(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "LMColumnTemplate";
		}

		public LMColumnTemplate(LMColumnTemplate source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Название колонки.
		/// </summary>
		public string ColumnName {
			get {
				return GetTypedColumnValue<string>("ColumnName");
			}
			set {
				SetColumnValue("ColumnName", value);
			}
		}

		/// <summary>
		/// Ссылка?.
		/// </summary>
		public bool IsLink {
			get {
				return GetTypedColumnValue<bool>("IsLink");
			}
			set {
				SetColumnValue("IsLink", value);
			}
		}

		/// <summary>
		/// На изменение?.
		/// </summary>
		public bool IsOnChange {
			get {
				return GetTypedColumnValue<bool>("IsOnChange");
			}
			set {
				SetColumnValue("IsOnChange", value);
			}
		}

		/// <exclude/>
		public Guid LMStartEventId {
			get {
				return GetTypedColumnValue<Guid>("LMStartEventId");
			}
			set {
				SetColumnValue("LMStartEventId", value);
				_lMStartEvent = null;
			}
		}

		/// <exclude/>
		public string LMStartEventMessageTemplate {
			get {
				return GetTypedColumnValue<string>("LMStartEventMessageTemplate");
			}
			set {
				SetColumnValue("LMStartEventMessageTemplate", value);
				if (_lMStartEvent != null) {
					_lMStartEvent.MessageTemplate = value;
				}
			}
		}

		private LMStartEvent _lMStartEvent;
		/// <summary>
		/// Стартовые события системных сообщений.
		/// </summary>
		public LMStartEvent LMStartEvent {
			get {
				return _lMStartEvent ??
					(_lMStartEvent = LookupColumnEntities.GetEntity("LMStartEvent") as LMStartEvent);
			}
		}

		/// <summary>
		/// Порядковый номер.
		/// </summary>
		public int Position {
			get {
				return GetTypedColumnValue<int>("Position");
			}
			set {
				SetColumnValue("Position", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new LMColumnTemplate_LocalMessageEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("LMColumnTemplateDeleted", e);
			Validating += (s, e) => ThrowEvent("LMColumnTemplateValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new LMColumnTemplate(this);
		}

		#endregion

	}

	#endregion

	#region Class: LMColumnTemplate_LocalMessageEventsProcess

	/// <exclude/>
	public partial class LMColumnTemplate_LocalMessageEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : LMColumnTemplate
	{

		public LMColumnTemplate_LocalMessageEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "LMColumnTemplate_LocalMessageEventsProcess";
			SchemaUId = new Guid("0efb7365-699f-4160-9fa0-95f45b0857b4");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("0efb7365-699f-4160-9fa0-95f45b0857b4");
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

	#region Class: LMColumnTemplate_LocalMessageEventsProcess

	/// <exclude/>
	public class LMColumnTemplate_LocalMessageEventsProcess : LMColumnTemplate_LocalMessageEventsProcess<LMColumnTemplate>
	{

		public LMColumnTemplate_LocalMessageEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: LMColumnTemplate_LocalMessageEventsProcess

	public partial class LMColumnTemplate_LocalMessageEventsProcess<TEntity>
	{

		#region Methods: Public

		public override void LocalMessageExecuting(EntityChangeType changeType) {
			var lmHelper = new BPMSoft.Configuration.LocalMessageHelper(this.Entity, UserConnection, changeType);
			lmHelper.CreateLocalMessage();
		}

		#endregion

	}

	#endregion


	#region Class: LMColumnTemplateEventsProcess

	/// <exclude/>
	public class LMColumnTemplateEventsProcess : LMColumnTemplate_LocalMessageEventsProcess
	{

		public LMColumnTemplateEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

