namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: CaseStatus

	/// <exclude/>
	public class CaseStatus : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public CaseStatus(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "CaseStatus";
		}

		public CaseStatus(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "CaseStatus";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<Case> CaseCollectionByStatus {
			get;
			set;
		}

		public IEnumerable<CaseLifecycle> CaseLifecycleCollectionByStatus {
			get;
			set;
		}

		public IEnumerable<CaseNextStatus> CaseNextStatusCollectionByNextStatus {
			get;
			set;
		}

		public IEnumerable<CaseNextStatus> CaseNextStatusCollectionByStatus {
			get;
			set;
		}

		public IEnumerable<CaseNotificationRule> CaseNotificationRuleCollectionByCaseStatus {
			get;
			set;
		}

		public IEnumerable<SatisfactionLevel> SatisfactionLevelCollectionByStatus {
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
		/// Конечное состояние.
		/// </summary>
		public bool IsFinal {
			get {
				return GetTypedColumnValue<bool>("IsFinal");
			}
			set {
				SetColumnValue("IsFinal", value);
			}
		}

		/// <summary>
		/// Состояние разрешения.
		/// </summary>
		public bool IsResolved {
			get {
				return GetTypedColumnValue<bool>("IsResolved");
			}
			set {
				SetColumnValue("IsResolved", value);
			}
		}

		/// <summary>
		/// Состояние паузы.
		/// </summary>
		public bool IsPaused {
			get {
				return GetTypedColumnValue<bool>("IsPaused");
			}
			set {
				SetColumnValue("IsPaused", value);
			}
		}

		/// <summary>
		/// Заголовок кнопки.
		/// </summary>
		public string ButtonCaption {
			get {
				return GetTypedColumnValue<string>("ButtonCaption");
			}
			set {
				SetColumnValue("ButtonCaption", value);
			}
		}

		/// <exclude/>
		public Guid ClosureCodeId {
			get {
				return GetTypedColumnValue<Guid>("ClosureCodeId");
			}
			set {
				SetColumnValue("ClosureCodeId", value);
				_closureCode = null;
			}
		}

		/// <exclude/>
		public string ClosureCodeName {
			get {
				return GetTypedColumnValue<string>("ClosureCodeName");
			}
			set {
				SetColumnValue("ClosureCodeName", value);
				if (_closureCode != null) {
					_closureCode.Name = value;
				}
			}
		}

		private ClosureCode _closureCode;
		/// <summary>
		/// Причина закрытия.
		/// </summary>
		public ClosureCode ClosureCode {
			get {
				return _closureCode ??
					(_closureCode = new ClosureCode(LookupColumnEntities.GetEntity("ClosureCode")));
			}
		}

		/// <summary>
		/// Закрывать при сохранении.
		/// </summary>
		public bool IsCloseOnSave {
			get {
				return GetTypedColumnValue<bool>("IsCloseOnSave");
			}
			set {
				SetColumnValue("IsCloseOnSave", value);
			}
		}

		/// <exclude/>
		public Guid ImageId {
			get {
				return GetTypedColumnValue<Guid>("ImageId");
			}
			set {
				SetColumnValue("ImageId", value);
				_image = null;
			}
		}

		/// <exclude/>
		public string ImageName {
			get {
				return GetTypedColumnValue<string>("ImageName");
			}
			set {
				SetColumnValue("ImageName", value);
				if (_image != null) {
					_image.Name = value;
				}
			}
		}

		private SysImage _image;
		/// <summary>
		/// Изображение.
		/// </summary>
		public SysImage Image {
			get {
				return _image ??
					(_image = new SysImage(LookupColumnEntities.GetEntity("Image")));
			}
		}

		/// <summary>
		/// Цвет.
		/// </summary>
		public string Color {
			get {
				return GetTypedColumnValue<string>("Color");
			}
			set {
				SetColumnValue("Color", value);
			}
		}

		/// <summary>
		/// Отображать.
		/// </summary>
		public bool IsDisplayed {
			get {
				return GetTypedColumnValue<bool>("IsDisplayed");
			}
			set {
				SetColumnValue("IsDisplayed", value);
			}
		}

		/// <summary>
		/// Номер.
		/// </summary>
		public int StageNumber {
			get {
				return GetTypedColumnValue<int>("StageNumber");
			}
			set {
				SetColumnValue("StageNumber", value);
			}
		}

		#endregion

	}

	#endregion

}

