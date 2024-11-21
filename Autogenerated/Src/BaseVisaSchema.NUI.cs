namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Configuration.RightsService;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.DcmProcess;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;
	using BPMSoft.Core.Process;
	using BPMSoft.Core.Process.Configuration;
	using BPMSoft.Mail;
	using BPMSoft.Messaging.Common;
	using BPMSoft.UI.WebControls.Controls;
	using BPMSoft.UI.WebControls.Utilities.Json.Converters;
	using DataContract = BPMSoft.Nui.ServiceModel.DataContract;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Data;
	using System.Drawing;
	using System.Globalization;
	using System.IO;
	using System.Linq;
	using System.Text;
	using System.Text.RegularExpressions;

	#region Class: BaseVisaSchema

	/// <exclude/>
	[IsVirtual]
	public class BaseVisaSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public BaseVisaSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public BaseVisaSchema(BaseVisaSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public BaseVisaSchema(BaseVisaSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("5fa90d0d-64eb-4f52-8d3d-c51fa6443b66");
			RealUId = new Guid("5fa90d0d-64eb-4f52-8d3d-c51fa6443b66");
			Name = "BaseVisa";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("30bec7d4-5068-42a2-ab31-4d4a3fc4e524");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateObjectiveColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("f33a75e0-7ed4-4b06-a410-b9e9323645b1")) == null) {
				Columns.Add(CreateVisaOwnerColumn());
			}
			if (Columns.FindByUId(new Guid("7d4534be-4800-4793-b848-6771da492076")) == null) {
				Columns.Add(CreateIsAllowedToDelegateColumn());
			}
			if (Columns.FindByUId(new Guid("2800e792-e676-4b25-b8a0-aa7f0e714056")) == null) {
				Columns.Add(CreateDelegatedFromColumn());
			}
			if (Columns.FindByUId(new Guid("58ebe36e-7384-4abd-b09c-407c6f508a4d")) == null) {
				Columns.Add(CreateStatusColumn());
			}
			if (Columns.FindByUId(new Guid("1a4e2821-3b74-460c-8877-c06f743702c5")) == null) {
				Columns.Add(CreateSetByColumn());
			}
			if (Columns.FindByUId(new Guid("b4fedd4a-ca45-4ade-960a-c0f4417fe442")) == null) {
				Columns.Add(CreateSetDateColumn());
			}
			if (Columns.FindByUId(new Guid("c7d206aa-401c-4095-ba43-757c8f1914e9")) == null) {
				Columns.Add(CreateIsCanceledColumn());
			}
			if (Columns.FindByUId(new Guid("9b44ad39-b9e1-489e-a2c5-6090c3522434")) == null) {
				Columns.Add(CreateCommentColumn());
			}
			if (Columns.FindByUId(new Guid("453a7c65-0418-4684-be8f-641427eb6837")) == null) {
				Columns.Add(CreateIsRequiredDigitalSignatureColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("5fa90d0d-64eb-4f52-8d3d-c51fa6443b66");
			column.CreatedInPackageId = new Guid("30bec7d4-5068-42a2-ab31-4d4a3fc4e524");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("5fa90d0d-64eb-4f52-8d3d-c51fa6443b66");
			column.CreatedInPackageId = new Guid("30bec7d4-5068-42a2-ab31-4d4a3fc4e524");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("5fa90d0d-64eb-4f52-8d3d-c51fa6443b66");
			column.CreatedInPackageId = new Guid("30bec7d4-5068-42a2-ab31-4d4a3fc4e524");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("5fa90d0d-64eb-4f52-8d3d-c51fa6443b66");
			column.CreatedInPackageId = new Guid("30bec7d4-5068-42a2-ab31-4d4a3fc4e524");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("5fa90d0d-64eb-4f52-8d3d-c51fa6443b66");
			column.CreatedInPackageId = new Guid("30bec7d4-5068-42a2-ab31-4d4a3fc4e524");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("5fa90d0d-64eb-4f52-8d3d-c51fa6443b66");
			column.CreatedInPackageId = new Guid("30bec7d4-5068-42a2-ab31-4d4a3fc4e524");
			return column;
		}

		protected virtual EntitySchemaColumn CreateObjectiveColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("c282c824-7aa1-44b4-b8f0-dca0fe3d8b4b"),
				Name = @"Objective",
				CreatedInSchemaUId = new Guid("5fa90d0d-64eb-4f52-8d3d-c51fa6443b66"),
				ModifiedInSchemaUId = new Guid("5fa90d0d-64eb-4f52-8d3d-c51fa6443b66"),
				CreatedInPackageId = new Guid("30bec7d4-5068-42a2-ab31-4d4a3fc4e524")
			};
		}

		protected virtual EntitySchemaColumn CreateVisaOwnerColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("f33a75e0-7ed4-4b06-a410-b9e9323645b1"),
				Name = @"VisaOwner",
				ReferenceSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("5fa90d0d-64eb-4f52-8d3d-c51fa6443b66"),
				ModifiedInSchemaUId = new Guid("5fa90d0d-64eb-4f52-8d3d-c51fa6443b66"),
				CreatedInPackageId = new Guid("30bec7d4-5068-42a2-ab31-4d4a3fc4e524")
			};
		}

		protected virtual EntitySchemaColumn CreateIsAllowedToDelegateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("7d4534be-4800-4793-b848-6771da492076"),
				Name = @"IsAllowedToDelegate",
				CreatedInSchemaUId = new Guid("5fa90d0d-64eb-4f52-8d3d-c51fa6443b66"),
				ModifiedInSchemaUId = new Guid("5fa90d0d-64eb-4f52-8d3d-c51fa6443b66"),
				CreatedInPackageId = new Guid("30bec7d4-5068-42a2-ab31-4d4a3fc4e524")
			};
		}

		protected virtual EntitySchemaColumn CreateDelegatedFromColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("2800e792-e676-4b25-b8a0-aa7f0e714056"),
				Name = @"DelegatedFrom",
				ReferenceSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("5fa90d0d-64eb-4f52-8d3d-c51fa6443b66"),
				ModifiedInSchemaUId = new Guid("5fa90d0d-64eb-4f52-8d3d-c51fa6443b66"),
				CreatedInPackageId = new Guid("30bec7d4-5068-42a2-ab31-4d4a3fc4e524")
			};
		}

		protected virtual EntitySchemaColumn CreateStatusColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("58ebe36e-7384-4abd-b09c-407c6f508a4d"),
				Name = @"Status",
				ReferenceSchemaUId = new Guid("66c8f5ac-57d2-4fe8-95a0-89a98e37f57f"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("5fa90d0d-64eb-4f52-8d3d-c51fa6443b66"),
				ModifiedInSchemaUId = new Guid("5fa90d0d-64eb-4f52-8d3d-c51fa6443b66"),
				CreatedInPackageId = new Guid("30bec7d4-5068-42a2-ab31-4d4a3fc4e524"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"3462594d-77a7-4b0a-874a-6d8b54b293bc"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateSetByColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("1a4e2821-3b74-460c-8877-c06f743702c5"),
				Name = @"SetBy",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("5fa90d0d-64eb-4f52-8d3d-c51fa6443b66"),
				ModifiedInSchemaUId = new Guid("5fa90d0d-64eb-4f52-8d3d-c51fa6443b66"),
				CreatedInPackageId = new Guid("30bec7d4-5068-42a2-ab31-4d4a3fc4e524")
			};
		}

		protected virtual EntitySchemaColumn CreateSetDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("b4fedd4a-ca45-4ade-960a-c0f4417fe442"),
				Name = @"SetDate",
				CreatedInSchemaUId = new Guid("5fa90d0d-64eb-4f52-8d3d-c51fa6443b66"),
				ModifiedInSchemaUId = new Guid("5fa90d0d-64eb-4f52-8d3d-c51fa6443b66"),
				CreatedInPackageId = new Guid("30bec7d4-5068-42a2-ab31-4d4a3fc4e524")
			};
		}

		protected virtual EntitySchemaColumn CreateIsCanceledColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("c7d206aa-401c-4095-ba43-757c8f1914e9"),
				Name = @"IsCanceled",
				CreatedInSchemaUId = new Guid("5fa90d0d-64eb-4f52-8d3d-c51fa6443b66"),
				ModifiedInSchemaUId = new Guid("5fa90d0d-64eb-4f52-8d3d-c51fa6443b66"),
				CreatedInPackageId = new Guid("30bec7d4-5068-42a2-ab31-4d4a3fc4e524")
			};
		}

		protected virtual EntitySchemaColumn CreateCommentColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("9b44ad39-b9e1-489e-a2c5-6090c3522434"),
				Name = @"Comment",
				CreatedInSchemaUId = new Guid("5fa90d0d-64eb-4f52-8d3d-c51fa6443b66"),
				ModifiedInSchemaUId = new Guid("5fa90d0d-64eb-4f52-8d3d-c51fa6443b66"),
				CreatedInPackageId = new Guid("30bec7d4-5068-42a2-ab31-4d4a3fc4e524")
			};
		}

		protected virtual EntitySchemaColumn CreateIsRequiredDigitalSignatureColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("453a7c65-0418-4684-be8f-641427eb6837"),
				Name = @"IsRequiredDigitalSignature",
				CreatedInSchemaUId = new Guid("5fa90d0d-64eb-4f52-8d3d-c51fa6443b66"),
				ModifiedInSchemaUId = new Guid("5fa90d0d-64eb-4f52-8d3d-c51fa6443b66"),
				CreatedInPackageId = new Guid("6ba26f98-9709-4408-98d0-761f0c4bf2aa")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new BaseVisa(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new BaseVisa_NUIEventsProcess(userConnection);
		}

		public override object Clone() {
			return new BaseVisaSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new BaseVisaSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("5fa90d0d-64eb-4f52-8d3d-c51fa6443b66"));
		}

		#endregion

	}

	#endregion

	#region Class: BaseVisa

	/// <summary>
	/// Базовая виза.
	/// </summary>
	public class BaseVisa : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public BaseVisa(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "BaseVisa";
		}

		public BaseVisa(BaseVisa source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Цель визы.
		/// </summary>
		public string Objective {
			get {
				return GetTypedColumnValue<string>("Objective");
			}
			set {
				SetColumnValue("Objective", value);
			}
		}

		/// <exclude/>
		public Guid VisaOwnerId {
			get {
				return GetTypedColumnValue<Guid>("VisaOwnerId");
			}
			set {
				SetColumnValue("VisaOwnerId", value);
				_visaOwner = null;
			}
		}

		/// <exclude/>
		public string VisaOwnerName {
			get {
				return GetTypedColumnValue<string>("VisaOwnerName");
			}
			set {
				SetColumnValue("VisaOwnerName", value);
				if (_visaOwner != null) {
					_visaOwner.Name = value;
				}
			}
		}

		private SysAdminUnit _visaOwner;
		/// <summary>
		/// Визирующий.
		/// </summary>
		public SysAdminUnit VisaOwner {
			get {
				return _visaOwner ??
					(_visaOwner = LookupColumnEntities.GetEntity("VisaOwner") as SysAdminUnit);
			}
		}

		/// <summary>
		/// Разрешено делегирование.
		/// </summary>
		public bool IsAllowedToDelegate {
			get {
				return GetTypedColumnValue<bool>("IsAllowedToDelegate");
			}
			set {
				SetColumnValue("IsAllowedToDelegate", value);
			}
		}

		/// <exclude/>
		public Guid DelegatedFromId {
			get {
				return GetTypedColumnValue<Guid>("DelegatedFromId");
			}
			set {
				SetColumnValue("DelegatedFromId", value);
				_delegatedFrom = null;
			}
		}

		/// <exclude/>
		public string DelegatedFromName {
			get {
				return GetTypedColumnValue<string>("DelegatedFromName");
			}
			set {
				SetColumnValue("DelegatedFromName", value);
				if (_delegatedFrom != null) {
					_delegatedFrom.Name = value;
				}
			}
		}

		private SysAdminUnit _delegatedFrom;
		/// <summary>
		/// Делегирована от.
		/// </summary>
		public SysAdminUnit DelegatedFrom {
			get {
				return _delegatedFrom ??
					(_delegatedFrom = LookupColumnEntities.GetEntity("DelegatedFrom") as SysAdminUnit);
			}
		}

		/// <exclude/>
		public Guid StatusId {
			get {
				return GetTypedColumnValue<Guid>("StatusId");
			}
			set {
				SetColumnValue("StatusId", value);
				_status = null;
			}
		}

		/// <exclude/>
		public string StatusName {
			get {
				return GetTypedColumnValue<string>("StatusName");
			}
			set {
				SetColumnValue("StatusName", value);
				if (_status != null) {
					_status.Name = value;
				}
			}
		}

		private VisaStatus _status;
		/// <summary>
		/// Состояние.
		/// </summary>
		public VisaStatus Status {
			get {
				return _status ??
					(_status = LookupColumnEntities.GetEntity("Status") as VisaStatus);
			}
		}

		/// <exclude/>
		public Guid SetById {
			get {
				return GetTypedColumnValue<Guid>("SetById");
			}
			set {
				SetColumnValue("SetById", value);
				_setBy = null;
			}
		}

		/// <exclude/>
		public string SetByName {
			get {
				return GetTypedColumnValue<string>("SetByName");
			}
			set {
				SetColumnValue("SetByName", value);
				if (_setBy != null) {
					_setBy.Name = value;
				}
			}
		}

		private Contact _setBy;
		/// <summary>
		/// Установил.
		/// </summary>
		public Contact SetBy {
			get {
				return _setBy ??
					(_setBy = LookupColumnEntities.GetEntity("SetBy") as Contact);
			}
		}

		/// <summary>
		/// Дата установки.
		/// </summary>
		public DateTime SetDate {
			get {
				return GetTypedColumnValue<DateTime>("SetDate");
			}
			set {
				SetColumnValue("SetDate", value);
			}
		}

		/// <summary>
		/// Отменена.
		/// </summary>
		public bool IsCanceled {
			get {
				return GetTypedColumnValue<bool>("IsCanceled");
			}
			set {
				SetColumnValue("IsCanceled", value);
			}
		}

		/// <summary>
		/// Комментарий.
		/// </summary>
		public string Comment {
			get {
				return GetTypedColumnValue<string>("Comment");
			}
			set {
				SetColumnValue("Comment", value);
			}
		}

		/// <summary>
		/// Требует ЭЦП.
		/// </summary>
		public bool IsRequiredDigitalSignature {
			get {
				return GetTypedColumnValue<bool>("IsRequiredDigitalSignature");
			}
			set {
				SetColumnValue("IsRequiredDigitalSignature", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new BaseVisa_NUIEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Inserted += (s, e) => ThrowEvent("BaseVisaInserted", e);
			Inserting += (s, e) => ThrowEvent("BaseVisaInserting", e);
			Saved += (s, e) => ThrowEvent("BaseVisaSaved", e);
			Saving += (s, e) => ThrowEvent("BaseVisaSaving", e);
			Validating += (s, e) => ThrowEvent("BaseVisaValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new BaseVisa(this);
		}

		#endregion

	}

	#endregion

	#region Class: BaseVisa_NUIEventsProcess

	/// <exclude/>
	public partial class BaseVisa_NUIEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : BaseVisa
	{

		public BaseVisa_NUIEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "BaseVisa_NUIEventsProcess";
			SchemaUId = new Guid("5fa90d0d-64eb-4f52-8d3d-c51fa6443b66");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			_isNew = () => {{ return false; }};
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("5fa90d0d-64eb-4f52-8d3d-c51fa6443b66");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		public virtual bool NeedSendEmail {
			get;
			set;
		}

		public virtual Guid SysModuleEntityId {
			get;
			set;
		}

		public virtual Guid oldVisaOwnerId {
			get;
			set;
		}

		public virtual Guid oldDelegatedFromId {
			get;
			set;
		}

		public virtual Object AddedTemplateColumns {
			get;
			set;
		}

		private Func<bool> _isNew;
		public virtual bool IsNew {
			get {
				return (_isNew ?? (_isNew = () => false)).Invoke();
			}
			set {
				_isNew = () => { return value; };
			}
		}

		private ProcessFlowElement _eventSubProcess1;
		public ProcessFlowElement EventSubProcess1 {
			get {
				return _eventSubProcess1 ?? (_eventSubProcess1 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventSubProcess1",
					SchemaElementUId = new Guid("83b1242b-739d-4352-9e6b-80b3f5c26dd8"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _baseVisaSavingStartMessage;
		public ProcessFlowElement BaseVisaSavingStartMessage {
			get {
				return _baseVisaSavingStartMessage ?? (_baseVisaSavingStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "BaseVisaSavingStartMessage",
					SchemaElementUId = new Guid("7a568490-371a-4edc-bfd4-ff9f3f2948bc"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _baseVisaInsertedStartMessage;
		public ProcessFlowElement BaseVisaInsertedStartMessage {
			get {
				return _baseVisaInsertedStartMessage ?? (_baseVisaInsertedStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "BaseVisaInsertedStartMessage",
					SchemaElementUId = new Guid("cd9d5068-1d66-4ac4-bc08-e823a6c71e72"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _baseVisaInsertedScriptTask;
		public ProcessScriptTask BaseVisaInsertedScriptTask {
			get {
				return _baseVisaInsertedScriptTask ?? (_baseVisaInsertedScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "BaseVisaInsertedScriptTask",
					SchemaElementUId = new Guid("aa346743-5d89-469e-a9a6-c0e32ebe5532"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = BaseVisaInsertedScriptTaskExecute,
				});
			}
		}

		private ProcessFlowElement _baseVisaSavedStartMessage;
		public ProcessFlowElement BaseVisaSavedStartMessage {
			get {
				return _baseVisaSavedStartMessage ?? (_baseVisaSavedStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "BaseVisaSavedStartMessage",
					SchemaElementUId = new Guid("6dec2d63-206a-456c-b12e-977dfab8fd3b"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _baseVisaSavedScriptTask;
		public ProcessScriptTask BaseVisaSavedScriptTask {
			get {
				return _baseVisaSavedScriptTask ?? (_baseVisaSavedScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "BaseVisaSavedScriptTask",
					SchemaElementUId = new Guid("111279fd-e865-4b9a-acbc-aef0ab315916"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = BaseVisaSavedScriptTaskExecute,
				});
			}
		}

		private ProcessThrowMessageEvent _intermediateThrowMessageEvent1BaseVisaSaving;
		public ProcessThrowMessageEvent IntermediateThrowMessageEvent1BaseVisaSaving {
			get {
				return _intermediateThrowMessageEvent1BaseVisaSaving ?? (_intermediateThrowMessageEvent1BaseVisaSaving = new ProcessThrowMessageEvent() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaIntermediateThrowMessageEvent",
					Name = "IntermediateThrowMessageEvent1BaseVisaSaving",
					SchemaElementUId = new Guid("ccc3e746-0a9a-45f8-9293-4a34d26a8948"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Message = "BaseVisaSaving",
						ThrowToBase = true,
				});
			}
		}

		private ProcessThrowMessageEvent _intermediateThrowMessageEvent2BaseVisaSaved;
		public ProcessThrowMessageEvent IntermediateThrowMessageEvent2BaseVisaSaved {
			get {
				return _intermediateThrowMessageEvent2BaseVisaSaved ?? (_intermediateThrowMessageEvent2BaseVisaSaved = new ProcessThrowMessageEvent() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaIntermediateThrowMessageEvent",
					Name = "IntermediateThrowMessageEvent2BaseVisaSaved",
					SchemaElementUId = new Guid("4bea3148-3b2a-4e3f-a71d-82e77a3072bc"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Message = "BaseVisaSaved",
						ThrowToBase = true,
				});
			}
		}

		private ProcessThrowMessageEvent _intermediateThrowMessageEvent3BaseVisaInserted;
		public ProcessThrowMessageEvent IntermediateThrowMessageEvent3BaseVisaInserted {
			get {
				return _intermediateThrowMessageEvent3BaseVisaInserted ?? (_intermediateThrowMessageEvent3BaseVisaInserted = new ProcessThrowMessageEvent() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaIntermediateThrowMessageEvent",
					Name = "IntermediateThrowMessageEvent3BaseVisaInserted",
					SchemaElementUId = new Guid("33896526-da17-42d4-b819-5aeb2e10ad7c"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Message = "BaseVisaInserted",
						ThrowToBase = true,
				});
			}
		}

		private ProcessScriptTask _baseVisaSavingScriptTask;
		public ProcessScriptTask BaseVisaSavingScriptTask {
			get {
				return _baseVisaSavingScriptTask ?? (_baseVisaSavingScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "BaseVisaSavingScriptTask",
					SchemaElementUId = new Guid("01fe088d-9a82-46d9-9c30-693c6cec6768"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = BaseVisaSavingScriptTaskExecute,
				});
			}
		}

		private LocalizableString _bodyMessage;
		public LocalizableString BodyMessage {
			get {
				return _bodyMessage ?? (_bodyMessage = new LocalizableString(Storage, Schema.GetResourceManagerName(), "EventsProcessSchema.LocalizableStrings.BodyMessage.Value"));
			}
		}

		private LocalizableString _subjectString;
		public LocalizableString SubjectString {
			get {
				return _subjectString ?? (_subjectString = new LocalizableString(Storage, Schema.GetResourceManagerName(), "EventsProcessSchema.LocalizableStrings.SubjectString.Value"));
			}
		}

		private LocalizableString _popupTitleTemplate;
		public LocalizableString PopupTitleTemplate {
			get {
				return _popupTitleTemplate ?? (_popupTitleTemplate = new LocalizableString(Storage, Schema.GetResourceManagerName(), "EventsProcessSchema.LocalizableStrings.PopupTitleTemplate.Value"));
			}
		}

		private LocalizableString _popupBodyTemplate;
		public LocalizableString PopupBodyTemplate {
			get {
				return _popupBodyTemplate ?? (_popupBodyTemplate = new LocalizableString(Storage, Schema.GetResourceManagerName(), "EventsProcessSchema.LocalizableStrings.PopupBodyTemplate.Value"));
			}
		}

		private LocalizableString _popupBodyDateFormat;
		public LocalizableString PopupBodyDateFormat {
			get {
				return _popupBodyDateFormat ?? (_popupBodyDateFormat = new LocalizableString(Storage, Schema.GetResourceManagerName(), "EventsProcessSchema.LocalizableStrings.PopupBodyDateFormat.Value"));
			}
		}

		private LocalizableString _popupBodyDefaultTemplate;
		public LocalizableString PopupBodyDefaultTemplate {
			get {
				return _popupBodyDefaultTemplate ?? (_popupBodyDefaultTemplate = new LocalizableString(Storage, Schema.GetResourceManagerName(), "EventsProcessSchema.LocalizableStrings.PopupBodyDefaultTemplate.Value"));
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[EventSubProcess1.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess1 };
			FlowElements[BaseVisaSavingStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { BaseVisaSavingStartMessage };
			FlowElements[BaseVisaInsertedStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { BaseVisaInsertedStartMessage };
			FlowElements[BaseVisaInsertedScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { BaseVisaInsertedScriptTask };
			FlowElements[BaseVisaSavedStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { BaseVisaSavedStartMessage };
			FlowElements[BaseVisaSavedScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { BaseVisaSavedScriptTask };
			FlowElements[IntermediateThrowMessageEvent1BaseVisaSaving.SchemaElementUId] = new Collection<ProcessFlowElement> { IntermediateThrowMessageEvent1BaseVisaSaving };
			FlowElements[IntermediateThrowMessageEvent2BaseVisaSaved.SchemaElementUId] = new Collection<ProcessFlowElement> { IntermediateThrowMessageEvent2BaseVisaSaved };
			FlowElements[IntermediateThrowMessageEvent3BaseVisaInserted.SchemaElementUId] = new Collection<ProcessFlowElement> { IntermediateThrowMessageEvent3BaseVisaInserted };
			FlowElements[BaseVisaSavingScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { BaseVisaSavingScriptTask };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "EventSubProcess1":
						break;
					case "BaseVisaSavingStartMessage":
						e.Context.QueueTasks.Enqueue("BaseVisaSavingScriptTask");
						break;
					case "BaseVisaInsertedStartMessage":
						e.Context.QueueTasks.Enqueue("BaseVisaInsertedScriptTask");
						break;
					case "BaseVisaInsertedScriptTask":
						e.Context.QueueTasks.Enqueue("IntermediateThrowMessageEvent3BaseVisaInserted");
						break;
					case "BaseVisaSavedStartMessage":
						e.Context.QueueTasks.Enqueue("BaseVisaSavedScriptTask");
						break;
					case "BaseVisaSavedScriptTask":
						e.Context.QueueTasks.Enqueue("IntermediateThrowMessageEvent2BaseVisaSaved");
						break;
					case "IntermediateThrowMessageEvent1BaseVisaSaving":
						break;
					case "IntermediateThrowMessageEvent2BaseVisaSaved":
						break;
					case "IntermediateThrowMessageEvent3BaseVisaInserted":
						break;
					case "BaseVisaSavingScriptTask":
						e.Context.QueueTasks.Enqueue("IntermediateThrowMessageEvent1BaseVisaSaving");
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("BaseVisaSavingStartMessage");
			ActivatedEventElements.Add("BaseVisaInsertedStartMessage");
			ActivatedEventElements.Add("BaseVisaSavedStartMessage");
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			switch (context.QueueTasks.Peek()) {
				case "EventSubProcess1":
					context.QueueTasks.Dequeue();
					break;
				case "BaseVisaSavingStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "BaseVisaSavingStartMessage";
					result = BaseVisaSavingStartMessage.Execute(context);
					break;
				case "BaseVisaInsertedStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "BaseVisaInsertedStartMessage";
					result = BaseVisaInsertedStartMessage.Execute(context);
					break;
				case "BaseVisaInsertedScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "BaseVisaInsertedScriptTask";
					result = BaseVisaInsertedScriptTask.Execute(context, BaseVisaInsertedScriptTaskExecute);
					break;
				case "BaseVisaSavedStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "BaseVisaSavedStartMessage";
					result = BaseVisaSavedStartMessage.Execute(context);
					break;
				case "BaseVisaSavedScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "BaseVisaSavedScriptTask";
					result = BaseVisaSavedScriptTask.Execute(context, BaseVisaSavedScriptTaskExecute);
					break;
				case "IntermediateThrowMessageEvent1BaseVisaSaving":
					context.QueueTasks.Dequeue();
					base.ThrowEvent(context, "BaseVisaSaving");
					result = IntermediateThrowMessageEvent1BaseVisaSaving.Execute(context);
					break;
				case "IntermediateThrowMessageEvent2BaseVisaSaved":
					context.QueueTasks.Dequeue();
					base.ThrowEvent(context, "BaseVisaSaved");
					result = IntermediateThrowMessageEvent2BaseVisaSaved.Execute(context);
					break;
				case "IntermediateThrowMessageEvent3BaseVisaInserted":
					context.QueueTasks.Dequeue();
					base.ThrowEvent(context, "BaseVisaInserted");
					result = IntermediateThrowMessageEvent3BaseVisaInserted.Execute(context);
					break;
				case "BaseVisaSavingScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "BaseVisaSavingScriptTask";
					result = BaseVisaSavingScriptTask.Execute(context, BaseVisaSavingScriptTaskExecute);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool BaseVisaInsertedScriptTaskExecute(ProcessExecutingContext context) {
			return BaseVisaInserted(context);
		}

		public virtual bool BaseVisaSavedScriptTaskExecute(ProcessExecutingContext context) {
			return BaseVisaSaved(context);
		}

		public virtual bool BaseVisaSavingScriptTaskExecute(ProcessExecutingContext context) {
			return BaseVisaSaving(context);
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "BaseVisaSaving":
							if (ActivatedEventElements.Contains("BaseVisaSavingStartMessage")) {
							context.QueueTasks.Enqueue("BaseVisaSavingStartMessage");
						}
						break;
					case "BaseVisaInserted":
							if (ActivatedEventElements.Contains("BaseVisaInsertedStartMessage")) {
							context.QueueTasks.Enqueue("BaseVisaInsertedStartMessage");
						}
						break;
					case "BaseVisaSaved":
							if (ActivatedEventElements.Contains("BaseVisaSavedStartMessage")) {
							context.QueueTasks.Enqueue("BaseVisaSavedStartMessage");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: BaseVisa_NUIEventsProcess

	/// <exclude/>
	public class BaseVisa_NUIEventsProcess : BaseVisa_NUIEventsProcess<BaseVisa>
	{

		public BaseVisa_NUIEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion


	#region Class: BaseVisaEventsProcess

	/// <exclude/>
	public class BaseVisaEventsProcess : BaseVisa_NUIEventsProcess
	{

		public BaseVisaEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

