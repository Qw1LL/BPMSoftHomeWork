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

	#region Class: VwMobileCaseMessageHistorySchema

	/// <exclude/>
	public class VwMobileCaseMessageHistorySchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public VwMobileCaseMessageHistorySchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwMobileCaseMessageHistorySchema(VwMobileCaseMessageHistorySchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwMobileCaseMessageHistorySchema(VwMobileCaseMessageHistorySchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("9f851290-67ae-4e38-ac05-3bd7ffe86821");
			RealUId = new Guid("9f851290-67ae-4e38-ac05-3bd7ffe86821");
			Name = "VwMobileCaseMessageHistory";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("3f69995c-5fbf-4c7e-92b9-3e2fdd7f757f");
			IsDBView = true;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("c5f64e2d-8e8b-4f52-973b-ddb7e9a11e5b")) == null) {
				Columns.Add(CreateOwnerNameColumn());
			}
			if (Columns.FindByUId(new Guid("a03c3851-f65a-463d-a793-cb6d2e609c24")) == null) {
				Columns.Add(CreateOwnerPhotoColumn());
			}
			if (Columns.FindByUId(new Guid("db4ab965-c6bf-4477-93df-914b95ef81b7")) == null) {
				Columns.Add(CreateMessageColumn());
			}
			if (Columns.FindByUId(new Guid("93a4d10d-b00c-4476-9612-6a64fc8742b4")) == null) {
				Columns.Add(CreateMessageNotifierColumn());
			}
			if (Columns.FindByUId(new Guid("016dd985-12b9-4baf-9ec4-4582d87afa5d")) == null) {
				Columns.Add(CreateRecordIdColumn());
			}
			if (Columns.FindByUId(new Guid("56c45e1f-5f3e-4e95-a3b7-55aea79e6726")) == null) {
				Columns.Add(CreateCaseColumn());
			}
			if (Columns.FindByUId(new Guid("48deec8d-f2f4-4edf-ac78-f0c22088d1a7")) == null) {
				Columns.Add(CreateRecepientColumn());
			}
			if (Columns.FindByUId(new Guid("54b06fa9-e4fd-4351-93ef-991cf2ba37cb")) == null) {
				Columns.Add(CreateHasAttachmentColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateOwnerNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("c5f64e2d-8e8b-4f52-973b-ddb7e9a11e5b"),
				Name = @"OwnerName",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("9f851290-67ae-4e38-ac05-3bd7ffe86821"),
				ModifiedInSchemaUId = new Guid("9f851290-67ae-4e38-ac05-3bd7ffe86821"),
				CreatedInPackageId = new Guid("7ef4f785-e6f9-4eab-84fd-127908d9cff8")
			};
		}

		protected virtual EntitySchemaColumn CreateOwnerPhotoColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ImageLookup")) {
				UId = new Guid("a03c3851-f65a-463d-a793-cb6d2e609c24"),
				Name = @"OwnerPhoto",
				ReferenceSchemaUId = new Guid("93986bfe-2dbd-46bc-9bf9-d03dfefbf3b8"),
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("9f851290-67ae-4e38-ac05-3bd7ffe86821"),
				ModifiedInSchemaUId = new Guid("9f851290-67ae-4e38-ac05-3bd7ffe86821"),
				CreatedInPackageId = new Guid("7ef4f785-e6f9-4eab-84fd-127908d9cff8")
			};
		}

		protected virtual EntitySchemaColumn CreateMessageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("db4ab965-c6bf-4477-93df-914b95ef81b7"),
				Name = @"Message",
				CreatedInSchemaUId = new Guid("9f851290-67ae-4e38-ac05-3bd7ffe86821"),
				ModifiedInSchemaUId = new Guid("9f851290-67ae-4e38-ac05-3bd7ffe86821"),
				CreatedInPackageId = new Guid("3f69995c-5fbf-4c7e-92b9-3e2fdd7f757f")
			};
		}

		protected virtual EntitySchemaColumn CreateMessageNotifierColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("93a4d10d-b00c-4476-9612-6a64fc8742b4"),
				Name = @"MessageNotifier",
				ReferenceSchemaUId = new Guid("eb2f5124-c41f-4166-9caf-7986912ddea1"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("9f851290-67ae-4e38-ac05-3bd7ffe86821"),
				ModifiedInSchemaUId = new Guid("9f851290-67ae-4e38-ac05-3bd7ffe86821"),
				CreatedInPackageId = new Guid("3f69995c-5fbf-4c7e-92b9-3e2fdd7f757f")
			};
		}

		protected virtual EntitySchemaColumn CreateRecordIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("016dd985-12b9-4baf-9ec4-4582d87afa5d"),
				Name = @"RecordId",
				CreatedInSchemaUId = new Guid("9f851290-67ae-4e38-ac05-3bd7ffe86821"),
				ModifiedInSchemaUId = new Guid("9f851290-67ae-4e38-ac05-3bd7ffe86821"),
				CreatedInPackageId = new Guid("3f69995c-5fbf-4c7e-92b9-3e2fdd7f757f")
			};
		}

		protected virtual EntitySchemaColumn CreateCaseColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("56c45e1f-5f3e-4e95-a3b7-55aea79e6726"),
				Name = @"Case",
				ReferenceSchemaUId = new Guid("117d32f9-8275-4534-8411-1c66115ce9cd"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("9f851290-67ae-4e38-ac05-3bd7ffe86821"),
				ModifiedInSchemaUId = new Guid("9f851290-67ae-4e38-ac05-3bd7ffe86821"),
				CreatedInPackageId = new Guid("3f69995c-5fbf-4c7e-92b9-3e2fdd7f757f")
			};
		}

		protected virtual EntitySchemaColumn CreateRecepientColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("48deec8d-f2f4-4edf-ac78-f0c22088d1a7"),
				Name = @"Recepient",
				CreatedInSchemaUId = new Guid("9f851290-67ae-4e38-ac05-3bd7ffe86821"),
				ModifiedInSchemaUId = new Guid("9f851290-67ae-4e38-ac05-3bd7ffe86821"),
				CreatedInPackageId = new Guid("3f69995c-5fbf-4c7e-92b9-3e2fdd7f757f")
			};
		}

		protected virtual EntitySchemaColumn CreateHasAttachmentColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("54b06fa9-e4fd-4351-93ef-991cf2ba37cb"),
				Name = @"HasAttachment",
				CreatedInSchemaUId = new Guid("9f851290-67ae-4e38-ac05-3bd7ffe86821"),
				ModifiedInSchemaUId = new Guid("9f851290-67ae-4e38-ac05-3bd7ffe86821"),
				CreatedInPackageId = new Guid("3f69995c-5fbf-4c7e-92b9-3e2fdd7f757f")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new VwMobileCaseMessageHistory(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwMobileCaseMessageHistory_CaseMobileEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwMobileCaseMessageHistorySchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwMobileCaseMessageHistorySchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("9f851290-67ae-4e38-ac05-3bd7ffe86821"));
		}

		#endregion

	}

	#endregion

	#region Class: VwMobileCaseMessageHistory

	/// <summary>
	/// История обработки.
	/// </summary>
	public class VwMobileCaseMessageHistory : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public VwMobileCaseMessageHistory(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwMobileCaseMessageHistory";
		}

		public VwMobileCaseMessageHistory(VwMobileCaseMessageHistory source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Имя.
		/// </summary>
		public string OwnerName {
			get {
				return GetTypedColumnValue<string>("OwnerName");
			}
			set {
				SetColumnValue("OwnerName", value);
			}
		}

		/// <exclude/>
		public Guid OwnerPhotoId {
			get {
				return GetTypedColumnValue<Guid>("OwnerPhotoId");
			}
			set {
				SetColumnValue("OwnerPhotoId", value);
				_ownerPhoto = null;
			}
		}

		/// <exclude/>
		public string OwnerPhotoName {
			get {
				return GetTypedColumnValue<string>("OwnerPhotoName");
			}
			set {
				SetColumnValue("OwnerPhotoName", value);
				if (_ownerPhoto != null) {
					_ownerPhoto.Name = value;
				}
			}
		}

		private SysImage _ownerPhoto;
		/// <summary>
		/// Фото.
		/// </summary>
		public SysImage OwnerPhoto {
			get {
				return _ownerPhoto ??
					(_ownerPhoto = LookupColumnEntities.GetEntity("OwnerPhoto") as SysImage);
			}
		}

		/// <summary>
		/// Message.
		/// </summary>
		public string Message {
			get {
				return GetTypedColumnValue<string>("Message");
			}
			set {
				SetColumnValue("Message", value);
			}
		}

		/// <exclude/>
		public Guid MessageNotifierId {
			get {
				return GetTypedColumnValue<Guid>("MessageNotifierId");
			}
			set {
				SetColumnValue("MessageNotifierId", value);
				_messageNotifier = null;
			}
		}

		/// <exclude/>
		public string MessageNotifierName {
			get {
				return GetTypedColumnValue<string>("MessageNotifierName");
			}
			set {
				SetColumnValue("MessageNotifierName", value);
				if (_messageNotifier != null) {
					_messageNotifier.Name = value;
				}
			}
		}

		private MessageNotifier _messageNotifier;
		/// <summary>
		/// Notifier.
		/// </summary>
		public MessageNotifier MessageNotifier {
			get {
				return _messageNotifier ??
					(_messageNotifier = LookupColumnEntities.GetEntity("MessageNotifier") as MessageNotifier);
			}
		}

		/// <summary>
		/// RecordId.
		/// </summary>
		public Guid RecordId {
			get {
				return GetTypedColumnValue<Guid>("RecordId");
			}
			set {
				SetColumnValue("RecordId", value);
			}
		}

		/// <exclude/>
		public Guid CaseId {
			get {
				return GetTypedColumnValue<Guid>("CaseId");
			}
			set {
				SetColumnValue("CaseId", value);
				_case = null;
			}
		}

		/// <exclude/>
		public string CaseNumber {
			get {
				return GetTypedColumnValue<string>("CaseNumber");
			}
			set {
				SetColumnValue("CaseNumber", value);
				if (_case != null) {
					_case.Number = value;
				}
			}
		}

		private Case _case;
		/// <summary>
		/// Case.
		/// </summary>
		public Case Case {
			get {
				return _case ??
					(_case = LookupColumnEntities.GetEntity("Case") as Case);
			}
		}

		/// <summary>
		/// Recepient.
		/// </summary>
		public string Recepient {
			get {
				return GetTypedColumnValue<string>("Recepient");
			}
			set {
				SetColumnValue("Recepient", value);
			}
		}

		/// <summary>
		/// Has Attachment.
		/// </summary>
		public bool HasAttachment {
			get {
				return GetTypedColumnValue<bool>("HasAttachment");
			}
			set {
				SetColumnValue("HasAttachment", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new VwMobileCaseMessageHistory_CaseMobileEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("VwMobileCaseMessageHistoryDeleted", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new VwMobileCaseMessageHistory(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwMobileCaseMessageHistory_CaseMobileEventsProcess

	/// <exclude/>
	public partial class VwMobileCaseMessageHistory_CaseMobileEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : VwMobileCaseMessageHistory
	{

		public VwMobileCaseMessageHistory_CaseMobileEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwMobileCaseMessageHistory_CaseMobileEventsProcess";
			SchemaUId = new Guid("9f851290-67ae-4e38-ac05-3bd7ffe86821");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("9f851290-67ae-4e38-ac05-3bd7ffe86821");
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

	#region Class: VwMobileCaseMessageHistory_CaseMobileEventsProcess

	/// <exclude/>
	public class VwMobileCaseMessageHistory_CaseMobileEventsProcess : VwMobileCaseMessageHistory_CaseMobileEventsProcess<VwMobileCaseMessageHistory>
	{

		public VwMobileCaseMessageHistory_CaseMobileEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VwMobileCaseMessageHistory_CaseMobileEventsProcess

	public partial class VwMobileCaseMessageHistory_CaseMobileEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: VwMobileCaseMessageHistoryEventsProcess

	/// <exclude/>
	public class VwMobileCaseMessageHistoryEventsProcess : VwMobileCaseMessageHistory_CaseMobileEventsProcess
	{

		public VwMobileCaseMessageHistoryEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

