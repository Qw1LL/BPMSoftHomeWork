namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: DaDataSuggestionsSettings

	/// <exclude/>
	public class DaDataSuggestionsSettings : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public DaDataSuggestionsSettings(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "DaDataSuggestionsSettings";
		}

		public DaDataSuggestionsSettings(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "DaDataSuggestionsSettings";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

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

		/// <exclude/>
		public Guid DaDataSuggestionsEntityId {
			get {
				return GetTypedColumnValue<Guid>("DaDataSuggestionsEntityId");
			}
			set {
				SetColumnValue("DaDataSuggestionsEntityId", value);
				_daDataSuggestionsEntity = null;
			}
		}

		/// <exclude/>
		public string DaDataSuggestionsEntityEntitySchemaCaption {
			get {
				return GetTypedColumnValue<string>("DaDataSuggestionsEntityEntitySchemaCaption");
			}
			set {
				SetColumnValue("DaDataSuggestionsEntityEntitySchemaCaption", value);
				if (_daDataSuggestionsEntity != null) {
					_daDataSuggestionsEntity.EntitySchemaCaption = value;
				}
			}
		}

		private DaDataSuggestionsEntity _daDataSuggestionsEntity;
		/// <summary>
		/// Объект.
		/// </summary>
		public DaDataSuggestionsEntity DaDataSuggestionsEntity {
			get {
				return _daDataSuggestionsEntity ??
					(_daDataSuggestionsEntity = new DaDataSuggestionsEntity(LookupColumnEntities.GetEntity("DaDataSuggestionsEntity")));
			}
		}

		/// <exclude/>
		public Guid DaDataSuggestionsFieldId {
			get {
				return GetTypedColumnValue<Guid>("DaDataSuggestionsFieldId");
			}
			set {
				SetColumnValue("DaDataSuggestionsFieldId", value);
				_daDataSuggestionsField = null;
			}
		}

		/// <exclude/>
		public string DaDataSuggestionsFieldName {
			get {
				return GetTypedColumnValue<string>("DaDataSuggestionsFieldName");
			}
			set {
				SetColumnValue("DaDataSuggestionsFieldName", value);
				if (_daDataSuggestionsField != null) {
					_daDataSuggestionsField.Name = value;
				}
			}
		}

		private DaDataSuggestionsField _daDataSuggestionsField;
		/// <summary>
		/// Поле из DaData.
		/// </summary>
		public DaDataSuggestionsField DaDataSuggestionsField {
			get {
				return _daDataSuggestionsField ??
					(_daDataSuggestionsField = new DaDataSuggestionsField(LookupColumnEntities.GetEntity("DaDataSuggestionsField")));
			}
		}

		/// <summary>
		/// Имя колонки объекта.
		/// </summary>
		public string EntityColumnName {
			get {
				return GetTypedColumnValue<string>("EntityColumnName");
			}
			set {
				SetColumnValue("EntityColumnName", value);
			}
		}

		/// <summary>
		/// Используется.
		/// </summary>
		public bool IsActive {
			get {
				return GetTypedColumnValue<bool>("IsActive");
			}
			set {
				SetColumnValue("IsActive", value);
			}
		}

		#endregion

	}

	#endregion

}

