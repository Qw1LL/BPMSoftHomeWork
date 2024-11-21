namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Configuration;
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

	#region Class: CertificateSchema

	/// <exclude/>
	public class CertificateSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public CertificateSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public CertificateSchema(CertificateSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public CertificateSchema(CertificateSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("36558ee5-03f9-4ffd-8272-c648af79e097");
			RealUId = new Guid("36558ee5-03f9-4ffd-8272-c648af79e097");
			Name = "Certificate";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("e6694e82-2be4-4388-8c1e-f340344f5039");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateCertificateNumberColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeMasterRecordColumn() {
			base.InitializeMasterRecordColumn();
			MasterRecordColumn = CreateContactColumn();
			if (Columns.FindByUId(MasterRecordColumn.UId) == null) {
				Columns.Add(MasterRecordColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("8e0dae65-fe30-4c60-b66c-26ecd6bb5ca1")) == null) {
				Columns.Add(CreateEducationActivityColumn());
			}
			if (Columns.FindByUId(new Guid("6e7732f6-6737-4771-b851-a89c614ccc04")) == null) {
				Columns.Add(CreateIssueDateColumn());
			}
			if (Columns.FindByUId(new Guid("8d14b73c-a593-4d44-9611-afac9ae65422")) == null) {
				Columns.Add(CreateExpireDateColumn());
			}
			if (Columns.FindByUId(new Guid("9c060e50-0cc7-4718-ad10-96f18625f3c4")) == null) {
				Columns.Add(CreateCompetenceLevelColumn());
			}
			if (Columns.FindByUId(new Guid("070a13af-37f3-465d-92cd-eae0f6ad659d")) == null) {
				Columns.Add(CreateResultScoreColumn());
			}
			if (Columns.FindByUId(new Guid("6ea2e256-0605-4c1d-b070-5b4356917abb")) == null) {
				Columns.Add(CreateCommentsColumn());
			}
			if (Columns.FindByUId(new Guid("45e54b8a-af02-42ea-a8b9-09f40f868885")) == null) {
				Columns.Add(CreateNotificationSentColumn());
			}
			if (Columns.FindByUId(new Guid("df63e6cc-2afa-46b5-aafc-07b48e9adb12")) == null) {
				Columns.Add(CreateDateOfNotificationColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateContactColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("0f4104c8-9581-4af6-901a-28bb15e5b42f"),
				Name = @"Contact",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("36558ee5-03f9-4ffd-8272-c648af79e097"),
				ModifiedInSchemaUId = new Guid("36558ee5-03f9-4ffd-8272-c648af79e097"),
				CreatedInPackageId = new Guid("e6694e82-2be4-4388-8c1e-f340344f5039")
			};
		}

		protected virtual EntitySchemaColumn CreateEducationActivityColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("8e0dae65-fe30-4c60-b66c-26ecd6bb5ca1"),
				Name = @"EducationActivity",
				ReferenceSchemaUId = new Guid("48a0ddfd-a99e-4bf5-8b5a-e56dfec31e0c"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("36558ee5-03f9-4ffd-8272-c648af79e097"),
				ModifiedInSchemaUId = new Guid("36558ee5-03f9-4ffd-8272-c648af79e097"),
				CreatedInPackageId = new Guid("e6694e82-2be4-4388-8c1e-f340344f5039")
			};
		}

		protected virtual EntitySchemaColumn CreateIssueDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Date")) {
				UId = new Guid("6e7732f6-6737-4771-b851-a89c614ccc04"),
				Name = @"IssueDate",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("36558ee5-03f9-4ffd-8272-c648af79e097"),
				ModifiedInSchemaUId = new Guid("36558ee5-03f9-4ffd-8272-c648af79e097"),
				CreatedInPackageId = new Guid("e6694e82-2be4-4388-8c1e-f340344f5039")
			};
		}

		protected virtual EntitySchemaColumn CreateExpireDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Date")) {
				UId = new Guid("8d14b73c-a593-4d44-9611-afac9ae65422"),
				Name = @"ExpireDate",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("36558ee5-03f9-4ffd-8272-c648af79e097"),
				ModifiedInSchemaUId = new Guid("36558ee5-03f9-4ffd-8272-c648af79e097"),
				CreatedInPackageId = new Guid("e6694e82-2be4-4388-8c1e-f340344f5039")
			};
		}

		protected virtual EntitySchemaColumn CreateCompetenceLevelColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("9c060e50-0cc7-4718-ad10-96f18625f3c4"),
				Name = @"CompetenceLevel",
				ReferenceSchemaUId = new Guid("54c499af-04aa-4eb5-9815-f23e12685d68"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("36558ee5-03f9-4ffd-8272-c648af79e097"),
				ModifiedInSchemaUId = new Guid("36558ee5-03f9-4ffd-8272-c648af79e097"),
				CreatedInPackageId = new Guid("e6694e82-2be4-4388-8c1e-f340344f5039")
			};
		}

		protected virtual EntitySchemaColumn CreateResultScoreColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float2")) {
				UId = new Guid("070a13af-37f3-465d-92cd-eae0f6ad659d"),
				Name = @"ResultScore",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("36558ee5-03f9-4ffd-8272-c648af79e097"),
				ModifiedInSchemaUId = new Guid("36558ee5-03f9-4ffd-8272-c648af79e097"),
				CreatedInPackageId = new Guid("e6694e82-2be4-4388-8c1e-f340344f5039")
			};
		}

		protected virtual EntitySchemaColumn CreateCertificateNumberColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("46f778b8-2e42-4f45-91c4-65a9c75d2e3d"),
				Name = @"CertificateNumber",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("36558ee5-03f9-4ffd-8272-c648af79e097"),
				ModifiedInSchemaUId = new Guid("36558ee5-03f9-4ffd-8272-c648af79e097"),
				CreatedInPackageId = new Guid("e6694e82-2be4-4388-8c1e-f340344f5039")
			};
		}

		protected virtual EntitySchemaColumn CreateCommentsColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("6ea2e256-0605-4c1d-b070-5b4356917abb"),
				Name = @"Comments",
				CreatedInSchemaUId = new Guid("36558ee5-03f9-4ffd-8272-c648af79e097"),
				ModifiedInSchemaUId = new Guid("36558ee5-03f9-4ffd-8272-c648af79e097"),
				CreatedInPackageId = new Guid("e6694e82-2be4-4388-8c1e-f340344f5039")
			};
		}

		protected virtual EntitySchemaColumn CreateNotificationSentColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("45e54b8a-af02-42ea-a8b9-09f40f868885"),
				Name = @"NotificationSent",
				CreatedInSchemaUId = new Guid("36558ee5-03f9-4ffd-8272-c648af79e097"),
				ModifiedInSchemaUId = new Guid("36558ee5-03f9-4ffd-8272-c648af79e097"),
				CreatedInPackageId = new Guid("c753c9c2-3fc1-46be-9c9c-b15f50a19487")
			};
		}

		protected virtual EntitySchemaColumn CreateDateOfNotificationColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Date")) {
				UId = new Guid("df63e6cc-2afa-46b5-aafc-07b48e9adb12"),
				Name = @"DateOfNotification",
				CreatedInSchemaUId = new Guid("36558ee5-03f9-4ffd-8272-c648af79e097"),
				ModifiedInSchemaUId = new Guid("36558ee5-03f9-4ffd-8272-c648af79e097"),
				CreatedInPackageId = new Guid("c753c9c2-3fc1-46be-9c9c-b15f50a19487")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new Certificate(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Certificate_PRMBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new CertificateSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new CertificateSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("36558ee5-03f9-4ffd-8272-c648af79e097"));
		}

		#endregion

	}

	#endregion

	#region Class: Certificate

	/// <summary>
	/// Сертификат.
	/// </summary>
	public class Certificate : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public Certificate(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Certificate";
		}

		public Certificate(Certificate source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid ContactId {
			get {
				return GetTypedColumnValue<Guid>("ContactId");
			}
			set {
				SetColumnValue("ContactId", value);
				_contact = null;
			}
		}

		/// <exclude/>
		public string ContactName {
			get {
				return GetTypedColumnValue<string>("ContactName");
			}
			set {
				SetColumnValue("ContactName", value);
				if (_contact != null) {
					_contact.Name = value;
				}
			}
		}

		private Contact _contact;
		/// <summary>
		/// Контакт.
		/// </summary>
		public Contact Contact {
			get {
				return _contact ??
					(_contact = LookupColumnEntities.GetEntity("Contact") as Contact);
			}
		}

		/// <exclude/>
		public Guid EducationActivityId {
			get {
				return GetTypedColumnValue<Guid>("EducationActivityId");
			}
			set {
				SetColumnValue("EducationActivityId", value);
				_educationActivity = null;
			}
		}

		/// <exclude/>
		public string EducationActivityName {
			get {
				return GetTypedColumnValue<string>("EducationActivityName");
			}
			set {
				SetColumnValue("EducationActivityName", value);
				if (_educationActivity != null) {
					_educationActivity.Name = value;
				}
			}
		}

		private EducationActivity _educationActivity;
		/// <summary>
		/// Образовательная активность.
		/// </summary>
		public EducationActivity EducationActivity {
			get {
				return _educationActivity ??
					(_educationActivity = LookupColumnEntities.GetEntity("EducationActivity") as EducationActivity);
			}
		}

		/// <summary>
		/// Дата выдачи.
		/// </summary>
		public DateTime IssueDate {
			get {
				return GetTypedColumnValue<DateTime>("IssueDate");
			}
			set {
				SetColumnValue("IssueDate", value);
			}
		}

		/// <summary>
		/// Действует до.
		/// </summary>
		public DateTime ExpireDate {
			get {
				return GetTypedColumnValue<DateTime>("ExpireDate");
			}
			set {
				SetColumnValue("ExpireDate", value);
			}
		}

		/// <exclude/>
		public Guid CompetenceLevelId {
			get {
				return GetTypedColumnValue<Guid>("CompetenceLevelId");
			}
			set {
				SetColumnValue("CompetenceLevelId", value);
				_competenceLevel = null;
			}
		}

		/// <exclude/>
		public string CompetenceLevelName {
			get {
				return GetTypedColumnValue<string>("CompetenceLevelName");
			}
			set {
				SetColumnValue("CompetenceLevelName", value);
				if (_competenceLevel != null) {
					_competenceLevel.Name = value;
				}
			}
		}

		private CompetenceLevel _competenceLevel;
		/// <summary>
		/// Уровень компетенций.
		/// </summary>
		public CompetenceLevel CompetenceLevel {
			get {
				return _competenceLevel ??
					(_competenceLevel = LookupColumnEntities.GetEntity("CompetenceLevel") as CompetenceLevel);
			}
		}

		/// <summary>
		/// Балл.
		/// </summary>
		public Decimal ResultScore {
			get {
				return GetTypedColumnValue<Decimal>("ResultScore");
			}
			set {
				SetColumnValue("ResultScore", value);
			}
		}

		/// <summary>
		/// Номер.
		/// </summary>
		public string CertificateNumber {
			get {
				return GetTypedColumnValue<string>("CertificateNumber");
			}
			set {
				SetColumnValue("CertificateNumber", value);
			}
		}

		/// <summary>
		/// Комментарий.
		/// </summary>
		public string Comments {
			get {
				return GetTypedColumnValue<string>("Comments");
			}
			set {
				SetColumnValue("Comments", value);
			}
		}

		/// <summary>
		/// Уведомление об окончании отправлено.
		/// </summary>
		public bool NotificationSent {
			get {
				return GetTypedColumnValue<bool>("NotificationSent");
			}
			set {
				SetColumnValue("NotificationSent", value);
			}
		}

		/// <summary>
		/// Дата отправки уведомления.
		/// </summary>
		public DateTime DateOfNotification {
			get {
				return GetTypedColumnValue<DateTime>("DateOfNotification");
			}
			set {
				SetColumnValue("DateOfNotification", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Certificate_PRMBaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("CertificateDeleted", e);
			Saved += (s, e) => ThrowEvent("CertificateSaved", e);
			Validating += (s, e) => ThrowEvent("CertificateValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new Certificate(this);
		}

		#endregion

	}

	#endregion

	#region Class: Certificate_PRMBaseEventsProcess

	/// <exclude/>
	public partial class Certificate_PRMBaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : Certificate
	{

		public Certificate_PRMBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Certificate_PRMBaseEventsProcess";
			SchemaUId = new Guid("36558ee5-03f9-4ffd-8272-c648af79e097");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("36558ee5-03f9-4ffd-8272-c648af79e097");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
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
					SchemaElementUId = new Guid("245b7732-2d0d-4792-b142-408984b3d8ab"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _actualizeCertificateOnSaved;
		public ProcessScriptTask ActualizeCertificateOnSaved {
			get {
				return _actualizeCertificateOnSaved ?? (_actualizeCertificateOnSaved = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ActualizeCertificateOnSaved",
					SchemaElementUId = new Guid("1ef5e2d2-87e3-458f-9996-e4c66ec75441"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ActualizeCertificateOnSavedExecute,
				});
			}
		}

		private ProcessFlowElement _onSaved;
		public ProcessFlowElement OnSaved {
			get {
				return _onSaved ?? (_onSaved = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "OnSaved",
					SchemaElementUId = new Guid("f4dc1393-7869-4849-a327-3624058e5369"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _actualizeCertificateOnDeleted;
		public ProcessScriptTask ActualizeCertificateOnDeleted {
			get {
				return _actualizeCertificateOnDeleted ?? (_actualizeCertificateOnDeleted = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ActualizeCertificateOnDeleted",
					SchemaElementUId = new Guid("00c82811-5ca1-415f-ac47-007ef7f86e99"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ActualizeCertificateOnDeletedExecute,
				});
			}
		}

		private ProcessFlowElement _onDeletedStartMessage;
		public ProcessFlowElement OnDeletedStartMessage {
			get {
				return _onDeletedStartMessage ?? (_onDeletedStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "OnDeletedStartMessage",
					SchemaElementUId = new Guid("16ad7ea8-dc80-48c8-a7e1-871f2106dd05"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessThrowMessageEvent _certificateDeletedIntermediateThrowMessage;
		public ProcessThrowMessageEvent CertificateDeletedIntermediateThrowMessage {
			get {
				return _certificateDeletedIntermediateThrowMessage ?? (_certificateDeletedIntermediateThrowMessage = new ProcessThrowMessageEvent() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaIntermediateThrowMessageEvent",
					Name = "CertificateDeletedIntermediateThrowMessage",
					SchemaElementUId = new Guid("dc297e47-c3cb-4aa9-80a5-d9889fa38706"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Message = "CertificateDeleted",
						ThrowToBase = true,
				});
			}
		}

		private ProcessThrowMessageEvent _onSavedIntermediateThrowMessage;
		public ProcessThrowMessageEvent OnSavedIntermediateThrowMessage {
			get {
				return _onSavedIntermediateThrowMessage ?? (_onSavedIntermediateThrowMessage = new ProcessThrowMessageEvent() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaIntermediateThrowMessageEvent",
					Name = "OnSavedIntermediateThrowMessage",
					SchemaElementUId = new Guid("1e9f0d78-96f3-4315-b353-8fc1adf1f9f2"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Message = "CertificateSaved",
						ThrowToBase = true,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[EventSubProcess1.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess1 };
			FlowElements[ActualizeCertificateOnSaved.SchemaElementUId] = new Collection<ProcessFlowElement> { ActualizeCertificateOnSaved };
			FlowElements[OnSaved.SchemaElementUId] = new Collection<ProcessFlowElement> { OnSaved };
			FlowElements[ActualizeCertificateOnDeleted.SchemaElementUId] = new Collection<ProcessFlowElement> { ActualizeCertificateOnDeleted };
			FlowElements[OnDeletedStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { OnDeletedStartMessage };
			FlowElements[CertificateDeletedIntermediateThrowMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { CertificateDeletedIntermediateThrowMessage };
			FlowElements[OnSavedIntermediateThrowMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { OnSavedIntermediateThrowMessage };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "EventSubProcess1":
						break;
					case "ActualizeCertificateOnSaved":
						e.Context.QueueTasks.Enqueue("OnSavedIntermediateThrowMessage");
						break;
					case "OnSaved":
						e.Context.QueueTasks.Enqueue("ActualizeCertificateOnSaved");
						break;
					case "ActualizeCertificateOnDeleted":
						e.Context.QueueTasks.Enqueue("CertificateDeletedIntermediateThrowMessage");
						break;
					case "OnDeletedStartMessage":
						e.Context.QueueTasks.Enqueue("ActualizeCertificateOnDeleted");
						break;
					case "CertificateDeletedIntermediateThrowMessage":
						break;
					case "OnSavedIntermediateThrowMessage":
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("OnSaved");
			ActivatedEventElements.Add("OnDeletedStartMessage");
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
				case "ActualizeCertificateOnSaved":
					context.QueueTasks.Dequeue();
					context.SenderName = "ActualizeCertificateOnSaved";
					result = ActualizeCertificateOnSaved.Execute(context, ActualizeCertificateOnSavedExecute);
					break;
				case "OnSaved":
					context.QueueTasks.Dequeue();
					context.SenderName = "OnSaved";
					result = OnSaved.Execute(context);
					break;
				case "ActualizeCertificateOnDeleted":
					context.QueueTasks.Dequeue();
					context.SenderName = "ActualizeCertificateOnDeleted";
					result = ActualizeCertificateOnDeleted.Execute(context, ActualizeCertificateOnDeletedExecute);
					break;
				case "OnDeletedStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "OnDeletedStartMessage";
					result = OnDeletedStartMessage.Execute(context);
					break;
				case "CertificateDeletedIntermediateThrowMessage":
					context.QueueTasks.Dequeue();
					base.ThrowEvent(context, "CertificateDeleted");
					result = CertificateDeletedIntermediateThrowMessage.Execute(context);
					break;
				case "OnSavedIntermediateThrowMessage":
					context.QueueTasks.Dequeue();
					base.ThrowEvent(context, "CertificateSaved");
					result = OnSavedIntermediateThrowMessage.Execute(context);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool ActualizeCertificateOnSavedExecute(ProcessExecutingContext context) {
			ActualizeCertificateCount(Entity.GetTypedColumnValue<Guid>("ContactId"));
			return true;
		}

		public virtual bool ActualizeCertificateOnDeletedExecute(ProcessExecutingContext context) {
			ActualizeCertificateCount(Entity.GetTypedOldColumnValue<Guid>("ContactId"));
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "CertificateSaved":
							if (ActivatedEventElements.Contains("OnSaved")) {
							context.QueueTasks.Enqueue("OnSaved");
						}
						break;
					case "CertificateDeleted":
							if (ActivatedEventElements.Contains("OnDeletedStartMessage")) {
							context.QueueTasks.Enqueue("OnDeletedStartMessage");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: Certificate_PRMBaseEventsProcess

	/// <exclude/>
	public class Certificate_PRMBaseEventsProcess : Certificate_PRMBaseEventsProcess<Certificate>
	{

		public Certificate_PRMBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: Certificate_PRMBaseEventsProcess

	public partial class Certificate_PRMBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		public virtual void ActualizeCertificateCount(Guid ContactId) {
			var select = new Select(UserConnection).Top(1)
				.Column("part", "Id")
				.From("Contact").As("cont")
				.Join(JoinType.Inner, "Account").As("acc")
					.On("cont", "AccountId").IsEqual("acc", "Id")
				.Join(JoinType.Inner, "Partnership").As("part")
					.On("part", "AccountId").IsEqual("acc", "Id")
				.Where("cont", "Id").IsEqual(Column.Parameter(ContactId))
					.And("part", "IsActive").IsEqual(Column.Parameter(true)) as Select;
			Guid partnershipId;
			using (var dbExecutor = UserConnection.EnsureDBConnection()) {
				partnershipId = select.ExecuteScalar<Guid>(dbExecutor);
			}
			if (partnershipId != Guid.Empty) {
				var columnsMapping = new Dictionary<string,string>();
				columnsMapping.Add("Id","Id");
				columnsMapping.Add("Count","IntValue");
				var actualizer = ConfigureEntityDataActualizer(partnershipId);
				actualizer.Actualize("Id", "PartnershipParameter", columnsMapping);
			}
		}

		public virtual EntityDataActualizer ConfigureEntityDataActualizer(Guid partnershipId) {
			var entityDataContext = new EntityActualizatorDataContext(UserConnection);
			var dataExtractor = new PartnershipCertifiedContactsDataExtractor(UserConnection);
			var partnershipFilter = GetFilterByPartnership(partnershipId);
			dataExtractor.AddFilter(partnershipFilter);
			var actualizer = new EntityDataActualizer(UserConnection, dataExtractor, entityDataContext);
			return actualizer;
		}

		public virtual QueryCondition GetFilterByPartnership(Guid partnershipId) {
			var partnershipFilter = new QueryCondition(QueryConditionType.Equal);
			partnershipFilter.ConditionType = QueryConditionType.Block;
			partnershipFilter.LeftExpression = new QueryColumnExpression("part", "Id");
			partnershipFilter.IsEqual(Column.Parameter(partnershipId));
			return partnershipFilter;
		}

		#endregion

	}

	#endregion


	#region Class: CertificateEventsProcess

	/// <exclude/>
	public class CertificateEventsProcess : Certificate_PRMBaseEventsProcess
	{

		public CertificateEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

