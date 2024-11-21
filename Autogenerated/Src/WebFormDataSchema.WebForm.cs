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

	#region Class: WebFormDataSchema

	/// <exclude/>
	public class WebFormDataSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public WebFormDataSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public WebFormDataSchema(WebFormDataSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public WebFormDataSchema(WebFormDataSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("0abcc957-0829-4261-8dd0-a428d64fa80f");
			RealUId = new Guid("0abcc957-0829-4261-8dd0-a428d64fa80f");
			Name = "WebFormData";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("562f1acd-62c8-4466-b19f-73d792872a6e");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("bdec85df-94b9-b2e1-1092-4d702e183669")) == null) {
				Columns.Add(CreateContactColumn());
			}
			if (Columns.FindByUId(new Guid("6e4c046f-87c4-cf85-2a34-8634f1e3a536")) == null) {
				Columns.Add(CreatePhoneColumn());
			}
			if (Columns.FindByUId(new Guid("e0a2caaa-73fb-742a-13f6-8889459348d9")) == null) {
				Columns.Add(CreateEmailColumn());
			}
			if (Columns.FindByUId(new Guid("a12eefd0-0cab-2f14-3f47-ca142eb1dfdb")) == null) {
				Columns.Add(CreateMiddleNameColumn());
			}
			if (Columns.FindByUId(new Guid("072225ec-14f4-0349-bd68-3af084193f15")) == null) {
				Columns.Add(CreateLastNameColumn());
			}
			if (Columns.FindByUId(new Guid("d513718c-1965-6c50-2152-c11993d94b0c")) == null) {
				Columns.Add(CreateFirstNameColumn());
			}
			if (Columns.FindByUId(new Guid("a8e90ffc-6a82-61b5-e144-9141ad5be165")) == null) {
				Columns.Add(CreateDataColumn());
			}
			if (Columns.FindByUId(new Guid("1f7fb4d4-4d43-7b6a-65f6-42959967a787")) == null) {
				Columns.Add(CreateWebFormColumn());
			}
			if (Columns.FindByUId(new Guid("4923254d-f749-d985-6ffd-aabcb48cea4b")) == null) {
				Columns.Add(CreateIsObjectCreatedColumn());
			}
			if (Columns.FindByUId(new Guid("b36574af-f21f-1089-5427-e4aeac289963")) == null) {
				Columns.Add(CreateFullNameColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateContactColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("bdec85df-94b9-b2e1-1092-4d702e183669"),
				Name = @"Contact",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("0abcc957-0829-4261-8dd0-a428d64fa80f"),
				ModifiedInSchemaUId = new Guid("0abcc957-0829-4261-8dd0-a428d64fa80f"),
				CreatedInPackageId = new Guid("562f1acd-62c8-4466-b19f-73d792872a6e")
			};
		}

		protected virtual EntitySchemaColumn CreatePhoneColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("6e4c046f-87c4-cf85-2a34-8634f1e3a536"),
				Name = @"Phone",
				CreatedInSchemaUId = new Guid("0abcc957-0829-4261-8dd0-a428d64fa80f"),
				ModifiedInSchemaUId = new Guid("0abcc957-0829-4261-8dd0-a428d64fa80f"),
				CreatedInPackageId = new Guid("562f1acd-62c8-4466-b19f-73d792872a6e")
			};
		}

		protected virtual EntitySchemaColumn CreateEmailColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("e0a2caaa-73fb-742a-13f6-8889459348d9"),
				Name = @"Email",
				CreatedInSchemaUId = new Guid("0abcc957-0829-4261-8dd0-a428d64fa80f"),
				ModifiedInSchemaUId = new Guid("0abcc957-0829-4261-8dd0-a428d64fa80f"),
				CreatedInPackageId = new Guid("562f1acd-62c8-4466-b19f-73d792872a6e")
			};
		}

		protected virtual EntitySchemaColumn CreateMiddleNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("a12eefd0-0cab-2f14-3f47-ca142eb1dfdb"),
				Name = @"MiddleName",
				CreatedInSchemaUId = new Guid("0abcc957-0829-4261-8dd0-a428d64fa80f"),
				ModifiedInSchemaUId = new Guid("0abcc957-0829-4261-8dd0-a428d64fa80f"),
				CreatedInPackageId = new Guid("562f1acd-62c8-4466-b19f-73d792872a6e")
			};
		}

		protected virtual EntitySchemaColumn CreateLastNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("072225ec-14f4-0349-bd68-3af084193f15"),
				Name = @"LastName",
				CreatedInSchemaUId = new Guid("0abcc957-0829-4261-8dd0-a428d64fa80f"),
				ModifiedInSchemaUId = new Guid("0abcc957-0829-4261-8dd0-a428d64fa80f"),
				CreatedInPackageId = new Guid("562f1acd-62c8-4466-b19f-73d792872a6e")
			};
		}

		protected virtual EntitySchemaColumn CreateFirstNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("d513718c-1965-6c50-2152-c11993d94b0c"),
				Name = @"FirstName",
				CreatedInSchemaUId = new Guid("0abcc957-0829-4261-8dd0-a428d64fa80f"),
				ModifiedInSchemaUId = new Guid("0abcc957-0829-4261-8dd0-a428d64fa80f"),
				CreatedInPackageId = new Guid("562f1acd-62c8-4466-b19f-73d792872a6e")
			};
		}

		protected virtual EntitySchemaColumn CreateDataColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("a8e90ffc-6a82-61b5-e144-9141ad5be165"),
				Name = @"Data",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("0abcc957-0829-4261-8dd0-a428d64fa80f"),
				ModifiedInSchemaUId = new Guid("0abcc957-0829-4261-8dd0-a428d64fa80f"),
				CreatedInPackageId = new Guid("562f1acd-62c8-4466-b19f-73d792872a6e")
			};
		}

		protected virtual EntitySchemaColumn CreateWebFormColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("1f7fb4d4-4d43-7b6a-65f6-42959967a787"),
				Name = @"WebForm",
				ReferenceSchemaUId = new Guid("41ae7d8d-bec3-41df-a6f0-2ab0d08b3967"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("0abcc957-0829-4261-8dd0-a428d64fa80f"),
				ModifiedInSchemaUId = new Guid("0abcc957-0829-4261-8dd0-a428d64fa80f"),
				CreatedInPackageId = new Guid("562f1acd-62c8-4466-b19f-73d792872a6e")
			};
		}

		protected virtual EntitySchemaColumn CreateIsObjectCreatedColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("4923254d-f749-d985-6ffd-aabcb48cea4b"),
				Name = @"IsObjectCreated",
				CreatedInSchemaUId = new Guid("0abcc957-0829-4261-8dd0-a428d64fa80f"),
				ModifiedInSchemaUId = new Guid("0abcc957-0829-4261-8dd0-a428d64fa80f"),
				CreatedInPackageId = new Guid("562f1acd-62c8-4466-b19f-73d792872a6e"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"False"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateFullNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("b36574af-f21f-1089-5427-e4aeac289963"),
				Name = @"FullName",
				CreatedInSchemaUId = new Guid("0abcc957-0829-4261-8dd0-a428d64fa80f"),
				ModifiedInSchemaUId = new Guid("0abcc957-0829-4261-8dd0-a428d64fa80f"),
				CreatedInPackageId = new Guid("562f1acd-62c8-4466-b19f-73d792872a6e")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new WebFormData(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new WebFormData_WebFormEventsProcess(userConnection);
		}

		public override object Clone() {
			return new WebFormDataSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new WebFormDataSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("0abcc957-0829-4261-8dd0-a428d64fa80f"));
		}

		#endregion

	}

	#endregion

	#region Class: WebFormData

	/// <summary>
	/// Data from web form.
	/// </summary>
	public class WebFormData : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public WebFormData(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "WebFormData";
		}

		public WebFormData(WebFormData source)
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
		/// Contact.
		/// </summary>
		public Contact Contact {
			get {
				return _contact ??
					(_contact = LookupColumnEntities.GetEntity("Contact") as Contact);
			}
		}

		/// <summary>
		/// Phone number.
		/// </summary>
		public string Phone {
			get {
				return GetTypedColumnValue<string>("Phone");
			}
			set {
				SetColumnValue("Phone", value);
			}
		}

		/// <summary>
		/// Email.
		/// </summary>
		public string Email {
			get {
				return GetTypedColumnValue<string>("Email");
			}
			set {
				SetColumnValue("Email", value);
			}
		}

		/// <summary>
		/// Middle name.
		/// </summary>
		public string MiddleName {
			get {
				return GetTypedColumnValue<string>("MiddleName");
			}
			set {
				SetColumnValue("MiddleName", value);
			}
		}

		/// <summary>
		/// Last name.
		/// </summary>
		public string LastName {
			get {
				return GetTypedColumnValue<string>("LastName");
			}
			set {
				SetColumnValue("LastName", value);
			}
		}

		/// <summary>
		/// First name.
		/// </summary>
		public string FirstName {
			get {
				return GetTypedColumnValue<string>("FirstName");
			}
			set {
				SetColumnValue("FirstName", value);
			}
		}

		/// <summary>
		/// Form data.
		/// </summary>
		public string Data {
			get {
				return GetTypedColumnValue<string>("Data");
			}
			set {
				SetColumnValue("Data", value);
			}
		}

		/// <exclude/>
		public Guid WebFormId {
			get {
				return GetTypedColumnValue<Guid>("WebFormId");
			}
			set {
				SetColumnValue("WebFormId", value);
				_webForm = null;
			}
		}

		/// <exclude/>
		public string WebFormName {
			get {
				return GetTypedColumnValue<string>("WebFormName");
			}
			set {
				SetColumnValue("WebFormName", value);
				if (_webForm != null) {
					_webForm.Name = value;
				}
			}
		}

		private GeneratedWebForm _webForm;
		/// <summary>
		/// Web form.
		/// </summary>
		public GeneratedWebForm WebForm {
			get {
				return _webForm ??
					(_webForm = LookupColumnEntities.GetEntity("WebForm") as GeneratedWebForm);
			}
		}

		/// <summary>
		/// Object created.
		/// </summary>
		public bool IsObjectCreated {
			get {
				return GetTypedColumnValue<bool>("IsObjectCreated");
			}
			set {
				SetColumnValue("IsObjectCreated", value);
			}
		}

		/// <summary>
		/// Full name.
		/// </summary>
		public string FullName {
			get {
				return GetTypedColumnValue<string>("FullName");
			}
			set {
				SetColumnValue("FullName", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new WebFormData_WebFormEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new WebFormData(this);
		}

		#endregion

	}

	#endregion

	#region Class: WebFormData_WebFormEventsProcess

	/// <exclude/>
	public partial class WebFormData_WebFormEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : WebFormData
	{

		public WebFormData_WebFormEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "WebFormData_WebFormEventsProcess";
			SchemaUId = new Guid("0abcc957-0829-4261-8dd0-a428d64fa80f");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("0abcc957-0829-4261-8dd0-a428d64fa80f");
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

	#region Class: WebFormData_WebFormEventsProcess

	/// <exclude/>
	public class WebFormData_WebFormEventsProcess : WebFormData_WebFormEventsProcess<WebFormData>
	{

		public WebFormData_WebFormEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: WebFormData_WebFormEventsProcess

	public partial class WebFormData_WebFormEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: WebFormDataEventsProcess

	/// <exclude/>
	public class WebFormDataEventsProcess : WebFormData_WebFormEventsProcess
	{

		public WebFormDataEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

