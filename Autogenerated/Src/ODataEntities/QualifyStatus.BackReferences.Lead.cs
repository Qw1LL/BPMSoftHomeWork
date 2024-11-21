namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: QualifyStatus

	/// <exclude/>
	public class QualifyStatus : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public QualifyStatus(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "QualifyStatus";
		}

		public QualifyStatus(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "QualifyStatus";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<Lead> LeadCollectionByQualifyStatus {
			get;
			set;
		}

		public IEnumerable<LeadInQualifyStatus> LeadInQualifyStatusCollectionByQualifyStatus {
			get;
			set;
		}

		public IEnumerable<QualifyStatusDecoupling> QualifyStatusDecouplingCollectionByAvailableStatus {
			get;
			set;
		}

		public IEnumerable<QualifyStatusDecoupling> QualifyStatusDecouplingCollectionByCurrentStatus {
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
		/// Номер стадии.
		/// </summary>
		public int StageNumber {
			get {
				return GetTypedColumnValue<int>("StageNumber");
			}
			set {
				SetColumnValue("StageNumber", value);
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
		/// Отображать в Workflow Bar.
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
		/// Первичная сортировка в Workflow Bar.
		/// </summary>
		public int StageOrder {
			get {
				return GetTypedColumnValue<int>("StageOrder");
			}
			set {
				SetColumnValue("StageOrder", value);
			}
		}

		/// <summary>
		/// Вторичная сортировка в Workflow Bar.
		/// </summary>
		public int StageInnerOrder {
			get {
				return GetTypedColumnValue<int>("StageInnerOrder");
			}
			set {
				SetColumnValue("StageInnerOrder", value);
			}
		}

		/// <summary>
		/// Завершающая.
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
		/// Успешный.
		/// </summary>
		public bool Successful {
			get {
				return GetTypedColumnValue<bool>("Successful");
			}
			set {
				SetColumnValue("Successful", value);
			}
		}

		#endregion

	}

	#endregion

}

