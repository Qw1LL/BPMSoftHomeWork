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

	#region Class: GeneratedWebFormSchema

	/// <exclude/>
	public class GeneratedWebFormSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public GeneratedWebFormSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public GeneratedWebFormSchema(GeneratedWebFormSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public GeneratedWebFormSchema(GeneratedWebFormSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("41ae7d8d-bec3-41df-a6f0-2ab0d08b3967");
			RealUId = new Guid("41ae7d8d-bec3-41df-a6f0-2ab0d08b3967");
			Name = "GeneratedWebForm";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("a350b119-a1d4-416a-b96f-a65dc67beca4");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateNameColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("c2f51aee-fcce-491f-827a-90101aa815b2")) == null) {
				Columns.Add(CreateDescriptionColumn());
			}
			if (Columns.FindByUId(new Guid("7781e6f4-cd30-46ca-9199-b6d6fae3886b")) == null) {
				Columns.Add(CreateExternalURLColumn());
			}
			if (Columns.FindByUId(new Guid("f39715d3-cbc0-4fc0-a5d9-1305719d7e59")) == null) {
				Columns.Add(CreateReturnURLColumn());
			}
			if (Columns.FindByUId(new Guid("f24dec83-eb51-4395-bb46-30380e9d6609")) == null) {
				Columns.Add(CreateEntityDefaultValuesColumn());
			}
			if (Columns.FindByUId(new Guid("b53809c7-42c6-48c3-b7ec-4f8e0025ffff")) == null) {
				Columns.Add(CreateFormFieldsColumn());
			}
			if (Columns.FindByUId(new Guid("4597b1a9-d992-4597-892c-288ef312926b")) == null) {
				Columns.Add(CreateBodyColumn());
			}
			if (Columns.FindByUId(new Guid("33f532bf-f3fb-4a77-91fa-3f4344f9acaa")) == null) {
				Columns.Add(CreateStateColumn());
			}
			if (Columns.FindByUId(new Guid("4e096ebc-393f-4a7d-912c-2b16a1e5ec14")) == null) {
				Columns.Add(CreateNotesColumn());
			}
			if (Columns.FindByUId(new Guid("43318ca1-634d-45f5-a920-430a5fa7934b")) == null) {
				Columns.Add(CreateOwnerColumn());
			}
			if (Columns.FindByUId(new Guid("7e336bc1-838f-48c6-a4d7-6f5bb3930bb2")) == null) {
				Columns.Add(CreateCreateContactColumn());
			}
			if (Columns.FindByUId(new Guid("15b7cd72-ce3b-4134-b1cd-4c86b295231b")) == null) {
				Columns.Add(CreateTypeColumn());
			}
			if (Columns.FindByUId(new Guid("6f1758be-c74b-cab4-ce22-9d8f53d607cc")) == null) {
				Columns.Add(CreateIdentificationProcessColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("41ae7d8d-bec3-41df-a6f0-2ab0d08b3967");
			column.CreatedInPackageId = new Guid("a350b119-a1d4-416a-b96f-a65dc67beca4");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("41ae7d8d-bec3-41df-a6f0-2ab0d08b3967");
			column.CreatedInPackageId = new Guid("a350b119-a1d4-416a-b96f-a65dc67beca4");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("41ae7d8d-bec3-41df-a6f0-2ab0d08b3967");
			column.CreatedInPackageId = new Guid("a350b119-a1d4-416a-b96f-a65dc67beca4");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("41ae7d8d-bec3-41df-a6f0-2ab0d08b3967");
			column.CreatedInPackageId = new Guid("a350b119-a1d4-416a-b96f-a65dc67beca4");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("41ae7d8d-bec3-41df-a6f0-2ab0d08b3967");
			column.CreatedInPackageId = new Guid("a350b119-a1d4-416a-b96f-a65dc67beca4");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("41ae7d8d-bec3-41df-a6f0-2ab0d08b3967");
			column.CreatedInPackageId = new Guid("a350b119-a1d4-416a-b96f-a65dc67beca4");
			return column;
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("f6b61426-02b5-47a0-a0e7-8432909f6d40"),
				Name = @"Name",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("41ae7d8d-bec3-41df-a6f0-2ab0d08b3967"),
				ModifiedInSchemaUId = new Guid("41ae7d8d-bec3-41df-a6f0-2ab0d08b3967"),
				CreatedInPackageId = new Guid("a350b119-a1d4-416a-b96f-a65dc67beca4")
			};
		}

		protected virtual EntitySchemaColumn CreateDescriptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("c2f51aee-fcce-491f-827a-90101aa815b2"),
				Name = @"Description",
				CreatedInSchemaUId = new Guid("41ae7d8d-bec3-41df-a6f0-2ab0d08b3967"),
				ModifiedInSchemaUId = new Guid("41ae7d8d-bec3-41df-a6f0-2ab0d08b3967"),
				CreatedInPackageId = new Guid("a350b119-a1d4-416a-b96f-a65dc67beca4"),
				IsMultiLineText = true
			};
		}

		protected virtual EntitySchemaColumn CreateExternalURLColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("7781e6f4-cd30-46ca-9199-b6d6fae3886b"),
				Name = @"ExternalURL",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("41ae7d8d-bec3-41df-a6f0-2ab0d08b3967"),
				ModifiedInSchemaUId = new Guid("41ae7d8d-bec3-41df-a6f0-2ab0d08b3967"),
				CreatedInPackageId = new Guid("a350b119-a1d4-416a-b96f-a65dc67beca4")
			};
		}

		protected virtual EntitySchemaColumn CreateReturnURLColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("f39715d3-cbc0-4fc0-a5d9-1305719d7e59"),
				Name = @"ReturnURL",
				CreatedInSchemaUId = new Guid("41ae7d8d-bec3-41df-a6f0-2ab0d08b3967"),
				ModifiedInSchemaUId = new Guid("41ae7d8d-bec3-41df-a6f0-2ab0d08b3967"),
				CreatedInPackageId = new Guid("a350b119-a1d4-416a-b96f-a65dc67beca4")
			};
		}

		protected virtual EntitySchemaColumn CreateEntityDefaultValuesColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("f24dec83-eb51-4395-bb46-30380e9d6609"),
				Name = @"EntityDefaultValues",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("41ae7d8d-bec3-41df-a6f0-2ab0d08b3967"),
				ModifiedInSchemaUId = new Guid("41ae7d8d-bec3-41df-a6f0-2ab0d08b3967"),
				CreatedInPackageId = new Guid("a350b119-a1d4-416a-b96f-a65dc67beca4")
			};
		}

		protected virtual EntitySchemaColumn CreateFormFieldsColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("b53809c7-42c6-48c3-b7ec-4f8e0025ffff"),
				Name = @"FormFields",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("41ae7d8d-bec3-41df-a6f0-2ab0d08b3967"),
				ModifiedInSchemaUId = new Guid("41ae7d8d-bec3-41df-a6f0-2ab0d08b3967"),
				CreatedInPackageId = new Guid("a350b119-a1d4-416a-b96f-a65dc67beca4")
			};
		}

		protected virtual EntitySchemaColumn CreateBodyColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("4597b1a9-d992-4597-892c-288ef312926b"),
				Name = @"Body",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("41ae7d8d-bec3-41df-a6f0-2ab0d08b3967"),
				ModifiedInSchemaUId = new Guid("41ae7d8d-bec3-41df-a6f0-2ab0d08b3967"),
				CreatedInPackageId = new Guid("a350b119-a1d4-416a-b96f-a65dc67beca4")
			};
		}

		protected virtual EntitySchemaColumn CreateStateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("33f532bf-f3fb-4a77-91fa-3f4344f9acaa"),
				Name = @"State",
				ReferenceSchemaUId = new Guid("967d4133-7d63-492f-a8f3-e406d06c6bbd"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("41ae7d8d-bec3-41df-a6f0-2ab0d08b3967"),
				ModifiedInSchemaUId = new Guid("41ae7d8d-bec3-41df-a6f0-2ab0d08b3967"),
				CreatedInPackageId = new Guid("2f566863-6a05-41ae-bb68-b647818b8f61"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"fbe29614-c02c-446e-ac8c-e7f62c4899ec"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateNotesColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("4e096ebc-393f-4a7d-912c-2b16a1e5ec14"),
				Name = @"Notes",
				CreatedInSchemaUId = new Guid("41ae7d8d-bec3-41df-a6f0-2ab0d08b3967"),
				ModifiedInSchemaUId = new Guid("41ae7d8d-bec3-41df-a6f0-2ab0d08b3967"),
				CreatedInPackageId = new Guid("e3031532-a059-4130-8d2e-6bdf35a52945")
			};
		}

		protected virtual EntitySchemaColumn CreateOwnerColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("43318ca1-634d-45f5-a920-430a5fa7934b"),
				Name = @"Owner",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("41ae7d8d-bec3-41df-a6f0-2ab0d08b3967"),
				ModifiedInSchemaUId = new Guid("41ae7d8d-bec3-41df-a6f0-2ab0d08b3967"),
				CreatedInPackageId = new Guid("e3031532-a059-4130-8d2e-6bdf35a52945"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.SystemValue,
					ValueSource = SystemValueManager.GetInstanceByName(@"CurrentUserContact")
				}
			};
		}

		protected virtual EntitySchemaColumn CreateCreateContactColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("7e336bc1-838f-48c6-a4d7-6f5bb3930bb2"),
				Name = @"CreateContact",
				CreatedInSchemaUId = new Guid("41ae7d8d-bec3-41df-a6f0-2ab0d08b3967"),
				ModifiedInSchemaUId = new Guid("41ae7d8d-bec3-41df-a6f0-2ab0d08b3967"),
				CreatedInPackageId = new Guid("70885459-eb74-4f01-8b36-f019cf6455dd")
			};
		}

		protected virtual EntitySchemaColumn CreateTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("15b7cd72-ce3b-4134-b1cd-4c86b295231b"),
				Name = @"Type",
				ReferenceSchemaUId = new Guid("e14fd334-ae5c-4fa5-970c-56c2f8ef33c2"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("41ae7d8d-bec3-41df-a6f0-2ab0d08b3967"),
				ModifiedInSchemaUId = new Guid("41ae7d8d-bec3-41df-a6f0-2ab0d08b3967"),
				CreatedInPackageId = new Guid("fc0e3e3b-059a-41c0-ac9d-be82e0250c11")
			};
		}

		protected virtual EntitySchemaColumn CreateIdentificationProcessColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("6f1758be-c74b-cab4-ce22-9d8f53d607cc"),
				Name = @"IdentificationProcess",
				ReferenceSchemaUId = new Guid("8f731e95-b20d-4f60-95ae-f86d44191558"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("41ae7d8d-bec3-41df-a6f0-2ab0d08b3967"),
				ModifiedInSchemaUId = new Guid("41ae7d8d-bec3-41df-a6f0-2ab0d08b3967"),
				CreatedInPackageId = new Guid("562f1acd-62c8-4466-b19f-73d792872a6e"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"43438c8c-e55c-46af-a63e-c963cc391349"
				}
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new GeneratedWebForm(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new GeneratedWebForm_WebFormEventsProcess(userConnection);
		}

		public override object Clone() {
			return new GeneratedWebFormSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new GeneratedWebFormSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("41ae7d8d-bec3-41df-a6f0-2ab0d08b3967"));
		}

		#endregion

	}

	#endregion

	#region Class: GeneratedWebForm

	/// <summary>
	/// Landing page (web form).
	/// </summary>
	public class GeneratedWebForm : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public GeneratedWebForm(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "GeneratedWebForm";
		}

		public GeneratedWebForm(GeneratedWebForm source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Name.
		/// </summary>
		public string Name {
			get {
				return GetTypedColumnValue<string>("Name");
			}
			set {
				SetColumnValue("Name", value);
			}
		}

		/// <summary>
		/// Description.
		/// </summary>
		public string Description {
			get {
				return GetTypedColumnValue<string>("Description");
			}
			set {
				SetColumnValue("Description", value);
			}
		}

		/// <summary>
		/// Website domains.
		/// </summary>
		public string ExternalURL {
			get {
				return GetTypedColumnValue<string>("ExternalURL");
			}
			set {
				SetColumnValue("ExternalURL", value);
			}
		}

		/// <summary>
		/// Redirection URL.
		/// </summary>
		public string ReturnURL {
			get {
				return GetTypedColumnValue<string>("ReturnURL");
			}
			set {
				SetColumnValue("ReturnURL", value);
			}
		}

		/// <summary>
		/// Object fields filled in by default.
		/// </summary>
		public string EntityDefaultValues {
			get {
				return GetTypedColumnValue<string>("EntityDefaultValues");
			}
			set {
				SetColumnValue("EntityDefaultValues", value);
			}
		}

		/// <summary>
		/// Landing page fields.
		/// </summary>
		public string FormFields {
			get {
				return GetTypedColumnValue<string>("FormFields");
			}
			set {
				SetColumnValue("FormFields", value);
			}
		}

		/// <summary>
		/// Generated landing page.
		/// </summary>
		public string Body {
			get {
				return GetTypedColumnValue<string>("Body");
			}
			set {
				SetColumnValue("Body", value);
			}
		}

		/// <exclude/>
		public Guid StateId {
			get {
				return GetTypedColumnValue<Guid>("StateId");
			}
			set {
				SetColumnValue("StateId", value);
				_state = null;
			}
		}

		/// <exclude/>
		public string StateName {
			get {
				return GetTypedColumnValue<string>("StateName");
			}
			set {
				SetColumnValue("StateName", value);
				if (_state != null) {
					_state.Name = value;
				}
			}
		}

		private LendingState _state;
		/// <summary>
		/// Status.
		/// </summary>
		public LendingState State {
			get {
				return _state ??
					(_state = LookupColumnEntities.GetEntity("State") as LendingState);
			}
		}

		/// <summary>
		/// Notes.
		/// </summary>
		public string Notes {
			get {
				return GetTypedColumnValue<string>("Notes");
			}
			set {
				SetColumnValue("Notes", value);
			}
		}

		/// <exclude/>
		public Guid OwnerId {
			get {
				return GetTypedColumnValue<Guid>("OwnerId");
			}
			set {
				SetColumnValue("OwnerId", value);
				_owner = null;
			}
		}

		/// <exclude/>
		public string OwnerName {
			get {
				return GetTypedColumnValue<string>("OwnerName");
			}
			set {
				SetColumnValue("OwnerName", value);
				if (_owner != null) {
					_owner.Name = value;
				}
			}
		}

		private Contact _owner;
		/// <summary>
		/// Owner.
		/// </summary>
		public Contact Owner {
			get {
				return _owner ??
					(_owner = LookupColumnEntities.GetEntity("Owner") as Contact);
			}
		}

		/// <summary>
		/// Create contact.
		/// </summary>
		public bool CreateContact {
			get {
				return GetTypedColumnValue<bool>("CreateContact");
			}
			set {
				SetColumnValue("CreateContact", value);
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

		private LandingType _type;
		/// <summary>
		/// Type.
		/// </summary>
		public LandingType Type {
			get {
				return _type ??
					(_type = LookupColumnEntities.GetEntity("Type") as LandingType);
			}
		}

		/// <exclude/>
		public Guid IdentificationProcessId {
			get {
				return GetTypedColumnValue<Guid>("IdentificationProcessId");
			}
			set {
				SetColumnValue("IdentificationProcessId", value);
				_identificationProcess = null;
			}
		}

		/// <exclude/>
		public string IdentificationProcessName {
			get {
				return GetTypedColumnValue<string>("IdentificationProcessName");
			}
			set {
				SetColumnValue("IdentificationProcessName", value);
				if (_identificationProcess != null) {
					_identificationProcess.Name = value;
				}
			}
		}

		private WebFormContactIdentifier _identificationProcess;
		/// <summary>
		/// Contact search process.
		/// </summary>
		public WebFormContactIdentifier IdentificationProcess {
			get {
				return _identificationProcess ??
					(_identificationProcess = LookupColumnEntities.GetEntity("IdentificationProcess") as WebFormContactIdentifier);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new GeneratedWebForm_WebFormEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("GeneratedWebFormDeleted", e);
			Inserting += (s, e) => ThrowEvent("GeneratedWebFormInserting", e);
			Validating += (s, e) => ThrowEvent("GeneratedWebFormValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new GeneratedWebForm(this);
		}

		#endregion

	}

	#endregion

	#region Class: GeneratedWebForm_WebFormEventsProcess

	/// <exclude/>
	public partial class GeneratedWebForm_WebFormEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : GeneratedWebForm
	{

		public GeneratedWebForm_WebFormEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "GeneratedWebForm_WebFormEventsProcess";
			SchemaUId = new Guid("41ae7d8d-bec3-41df-a6f0-2ab0d08b3967");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("41ae7d8d-bec3-41df-a6f0-2ab0d08b3967");
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

	#region Class: GeneratedWebForm_WebFormEventsProcess

	/// <exclude/>
	public class GeneratedWebForm_WebFormEventsProcess : GeneratedWebForm_WebFormEventsProcess<GeneratedWebForm>
	{

		public GeneratedWebForm_WebFormEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: GeneratedWebForm_WebFormEventsProcess

	public partial class GeneratedWebForm_WebFormEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: GeneratedWebFormEventsProcess

	/// <exclude/>
	public class GeneratedWebFormEventsProcess : GeneratedWebForm_WebFormEventsProcess
	{

		public GeneratedWebFormEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

