namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: GeneratedWebForm

	/// <exclude/>
	public class GeneratedWebForm : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public GeneratedWebForm(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "GeneratedWebForm";
		}

		public GeneratedWebForm(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "GeneratedWebForm";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<EventTarget> EventTargetCollectionByGeneratedWebForm {
			get;
			set;
		}

		public IEnumerable<FormSubmit> FormSubmitCollectionByWebForm {
			get;
			set;
		}

		public IEnumerable<GeneratedWebFormFile> GeneratedWebFormFileCollectionByGeneratedWebForm {
			get;
			set;
		}

		public IEnumerable<GeneratedWebFormInFolder> GeneratedWebFormInFolderCollectionByGeneratedWebForm {
			get;
			set;
		}

		public IEnumerable<GeneratedWebFormInTag> GeneratedWebFormInTagCollectionByEntity {
			get;
			set;
		}

		public IEnumerable<LandingLeadDefaults> LandingLeadDefaultsCollectionByLanding {
			get;
			set;
		}

		public IEnumerable<LandingObjectDefaults> LandingObjectDefaultsCollectionByLanding {
			get;
			set;
		}

		public IEnumerable<Lead> LeadCollectionByWebForm {
			get;
			set;
		}

		public IEnumerable<VwLandingInCampaign> VwLandingInCampaignCollectionByLanding {
			get;
			set;
		}

		public IEnumerable<WebFormData> WebFormDataCollectionByWebForm {
			get;
			set;
		}

		/// <summary>
		/// Id.
		/// </summary>
		public Guid Id {
			get {
				return GetTypedColumnValue<Guid>("Id");
			}
			set {
				SetColumnValue("Id", value);
			}
		}

		/// <summary>
		/// Дата создания.
		/// </summary>
		public DateTime CreatedOn {
			get {
				return GetTypedColumnValue<DateTime>("CreatedOn");
			}
			set {
				SetColumnValue("CreatedOn", value);
			}
		}

		/// <exclude/>
		public Guid CreatedById {
			get {
				return GetTypedColumnValue<Guid>("CreatedById");
			}
			set {
				SetColumnValue("CreatedById", value);
				_createdBy = null;
			}
		}

		/// <exclude/>
		public string CreatedByName {
			get {
				return GetTypedColumnValue<string>("CreatedByName");
			}
			set {
				SetColumnValue("CreatedByName", value);
				if (_createdBy != null) {
					_createdBy.Name = value;
				}
			}
		}

		private Contact _createdBy;
		/// <summary>
		/// Создал.
		/// </summary>
		public Contact CreatedBy {
			get {
				return _createdBy ??
					(_createdBy = new Contact(LookupColumnEntities.GetEntity("CreatedBy")));
			}
		}

		/// <summary>
		/// Дата изменения.
		/// </summary>
		public DateTime ModifiedOn {
			get {
				return GetTypedColumnValue<DateTime>("ModifiedOn");
			}
			set {
				SetColumnValue("ModifiedOn", value);
			}
		}

		/// <exclude/>
		public Guid ModifiedById {
			get {
				return GetTypedColumnValue<Guid>("ModifiedById");
			}
			set {
				SetColumnValue("ModifiedById", value);
				_modifiedBy = null;
			}
		}

		/// <exclude/>
		public string ModifiedByName {
			get {
				return GetTypedColumnValue<string>("ModifiedByName");
			}
			set {
				SetColumnValue("ModifiedByName", value);
				if (_modifiedBy != null) {
					_modifiedBy.Name = value;
				}
			}
		}

		private Contact _modifiedBy;
		/// <summary>
		/// Изменил.
		/// </summary>
		public Contact ModifiedBy {
			get {
				return _modifiedBy ??
					(_modifiedBy = new Contact(LookupColumnEntities.GetEntity("ModifiedBy")));
			}
		}

		/// <summary>
		/// Активные процессы.
		/// </summary>
		public int ProcessListeners {
			get {
				return GetTypedColumnValue<int>("ProcessListeners");
			}
			set {
				SetColumnValue("ProcessListeners", value);
			}
		}

		/// <summary>
		/// Название.
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
		/// Описание.
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
		/// Домены сайта.
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
		/// Адрес перехода.
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
		/// Заполненные по умолчанию поля объекта.
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
		/// Поля формы.
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
		/// Сгенерированная форма.
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
		/// Состояние.
		/// </summary>
		public LendingState State {
			get {
				return _state ??
					(_state = new LendingState(LookupColumnEntities.GetEntity("State")));
			}
		}

		/// <summary>
		/// Заметки.
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
		/// Ответственный.
		/// </summary>
		public Contact Owner {
			get {
				return _owner ??
					(_owner = new Contact(LookupColumnEntities.GetEntity("Owner")));
			}
		}

		/// <summary>
		/// Создавать контакт.
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
		/// Тип.
		/// </summary>
		public LandingType Type {
			get {
				return _type ??
					(_type = new LandingType(LookupColumnEntities.GetEntity("Type")));
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
		/// Процесс поиска контакта.
		/// </summary>
		public WebFormContactIdentifier IdentificationProcess {
			get {
				return _identificationProcess ??
					(_identificationProcess = new WebFormContactIdentifier(LookupColumnEntities.GetEntity("IdentificationProcess")));
			}
		}

		#endregion

	}

	#endregion

}

