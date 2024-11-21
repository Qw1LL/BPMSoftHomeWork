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

	#region Class: LMStartEventSchema

	/// <exclude/>
	public class LMStartEventSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public LMStartEventSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public LMStartEventSchema(LMStartEventSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public LMStartEventSchema(LMStartEventSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("a1490766-e92b-413f-96c8-49bdd8058628");
			RealUId = new Guid("a1490766-e92b-413f-96c8-49bdd8058628");
			Name = "LMStartEvent";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("ca4727b2-fc6c-4ae4-bb8b-429fb21e5974");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateMessageTemplateColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("9752e130-9a7d-458a-b3f4-7956151b83b9")) == null) {
				Columns.Add(CreateEntitySchemaUIdColumn());
			}
			if (Columns.FindByUId(new Guid("b535a968-f015-42b2-b3ae-99959a146032")) == null) {
				Columns.Add(CreateRecordChangeTypeColumn());
			}
			if (Columns.FindByUId(new Guid("891bcf17-9c1b-4f5b-b60d-b4947c294054")) == null) {
				Columns.Add(CreateConditionDataColumn());
			}
			if (Columns.FindByUId(new Guid("0c65e42f-3c79-45d9-9117-2f0b2a409019")) == null) {
				Columns.Add(CreateChangedColumnsColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateEntitySchemaUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("9752e130-9a7d-458a-b3f4-7956151b83b9"),
				Name = @"EntitySchemaUId",
				CreatedInSchemaUId = new Guid("a1490766-e92b-413f-96c8-49bdd8058628"),
				ModifiedInSchemaUId = new Guid("a1490766-e92b-413f-96c8-49bdd8058628"),
				CreatedInPackageId = new Guid("ca4727b2-fc6c-4ae4-bb8b-429fb21e5974")
			};
		}

		protected virtual EntitySchemaColumn CreateMessageTemplateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("0c61b48e-525b-422b-9f27-23bd201a1a88"),
				Name = @"MessageTemplate",
				CreatedInSchemaUId = new Guid("a1490766-e92b-413f-96c8-49bdd8058628"),
				ModifiedInSchemaUId = new Guid("a1490766-e92b-413f-96c8-49bdd8058628"),
				CreatedInPackageId = new Guid("ca4727b2-fc6c-4ae4-bb8b-429fb21e5974"),
				IsLocalizable = true
			};
		}

		protected virtual EntitySchemaColumn CreateRecordChangeTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("b535a968-f015-42b2-b3ae-99959a146032"),
				Name = @"RecordChangeType",
				CreatedInSchemaUId = new Guid("a1490766-e92b-413f-96c8-49bdd8058628"),
				ModifiedInSchemaUId = new Guid("a1490766-e92b-413f-96c8-49bdd8058628"),
				CreatedInPackageId = new Guid("ca4727b2-fc6c-4ae4-bb8b-429fb21e5974")
			};
		}

		protected virtual EntitySchemaColumn CreateConditionDataColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("891bcf17-9c1b-4f5b-b60d-b4947c294054"),
				Name = @"ConditionData",
				CreatedInSchemaUId = new Guid("a1490766-e92b-413f-96c8-49bdd8058628"),
				ModifiedInSchemaUId = new Guid("a1490766-e92b-413f-96c8-49bdd8058628"),
				CreatedInPackageId = new Guid("ca4727b2-fc6c-4ae4-bb8b-429fb21e5974")
			};
		}

		protected virtual EntitySchemaColumn CreateChangedColumnsColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("0c65e42f-3c79-45d9-9117-2f0b2a409019"),
				Name = @"ChangedColumns",
				CreatedInSchemaUId = new Guid("a1490766-e92b-413f-96c8-49bdd8058628"),
				ModifiedInSchemaUId = new Guid("a1490766-e92b-413f-96c8-49bdd8058628"),
				CreatedInPackageId = new Guid("ca4727b2-fc6c-4ae4-bb8b-429fb21e5974")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new LMStartEvent(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new LMStartEvent_LocalMessageEventsProcess(userConnection);
		}

		public override object Clone() {
			return new LMStartEventSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new LMStartEventSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("a1490766-e92b-413f-96c8-49bdd8058628"));
		}

		#endregion

	}

	#endregion

	#region Class: LMStartEvent

	/// <summary>
	/// Стартовые события системных сообщений.
	/// </summary>
	public class LMStartEvent : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public LMStartEvent(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "LMStartEvent";
		}

		public LMStartEvent(LMStartEvent source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Схема объекта.
		/// </summary>
		public Guid EntitySchemaUId {
			get {
				return GetTypedColumnValue<Guid>("EntitySchemaUId");
			}
			set {
				SetColumnValue("EntitySchemaUId", value);
			}
		}

		/// <summary>
		/// Шаблон сообщения.
		/// </summary>
		public string MessageTemplate {
			get {
				return GetTypedColumnValue<string>("MessageTemplate");
			}
			set {
				SetColumnValue("MessageTemplate", value);
			}
		}

		/// <summary>
		/// Тип изменения.
		/// </summary>
		public int RecordChangeType {
			get {
				return GetTypedColumnValue<int>("RecordChangeType");
			}
			set {
				SetColumnValue("RecordChangeType", value);
			}
		}

		/// <summary>
		/// Условия старта события.
		/// </summary>
		public string ConditionData {
			get {
				return GetTypedColumnValue<string>("ConditionData");
			}
			set {
				SetColumnValue("ConditionData", value);
			}
		}

		/// <summary>
		/// Условия старта события по измененным колонкам.
		/// </summary>
		public string ChangedColumns {
			get {
				return GetTypedColumnValue<string>("ChangedColumns");
			}
			set {
				SetColumnValue("ChangedColumns", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new LMStartEvent_LocalMessageEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("LMStartEventDeleted", e);
			Validating += (s, e) => ThrowEvent("LMStartEventValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new LMStartEvent(this);
		}

		#endregion

	}

	#endregion

	#region Class: LMStartEvent_LocalMessageEventsProcess

	/// <exclude/>
	public partial class LMStartEvent_LocalMessageEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : LMStartEvent
	{

		public LMStartEvent_LocalMessageEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "LMStartEvent_LocalMessageEventsProcess";
			SchemaUId = new Guid("a1490766-e92b-413f-96c8-49bdd8058628");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("a1490766-e92b-413f-96c8-49bdd8058628");
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

	#region Class: LMStartEvent_LocalMessageEventsProcess

	/// <exclude/>
	public class LMStartEvent_LocalMessageEventsProcess : LMStartEvent_LocalMessageEventsProcess<LMStartEvent>
	{

		public LMStartEvent_LocalMessageEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: LMStartEvent_LocalMessageEventsProcess

	public partial class LMStartEvent_LocalMessageEventsProcess<TEntity>
	{

		#region Methods: Public

		public override void LocalMessageExecuting(EntityChangeType changeType) {
			var lmHelper = new BPMSoft.Configuration.LocalMessageHelper(this.Entity, UserConnection, changeType);
			lmHelper.CreateLocalMessage();
		}

		#endregion

	}

	#endregion


	#region Class: LMStartEventEventsProcess

	/// <exclude/>
	public class LMStartEventEventsProcess : LMStartEvent_LocalMessageEventsProcess
	{

		public LMStartEventEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

