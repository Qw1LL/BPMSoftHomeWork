namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: IntroPageLookup

	/// <exclude/>
	public class IntroPageLookup : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public IntroPageLookup(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "IntroPageLookup";
		}

		public IntroPageLookup(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "IntroPageLookup";
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

		/// <summary>
		/// Page code.
		/// </summary>
		public string CodePage {
			get {
				return GetTypedColumnValue<string>("CodePage");
			}
			set {
				SetColumnValue("CodePage", value);
			}
		}

		/// <summary>
		/// Ссылка.
		/// </summary>
		public string AcademyUrl {
			get {
				return GetTypedColumnValue<string>("AcademyUrl");
			}
			set {
				SetColumnValue("AcademyUrl", value);
			}
		}

		/// <summary>
		/// Ссылка на видео.
		/// </summary>
		public string VideoUrl {
			get {
				return GetTypedColumnValue<string>("VideoUrl");
			}
			set {
				SetColumnValue("VideoUrl", value);
			}
		}

		/// <summary>
		/// Подпись видео.
		/// </summary>
		public string VideoCaption {
			get {
				return GetTypedColumnValue<string>("VideoCaption");
			}
			set {
				SetColumnValue("VideoCaption", value);
			}
		}

		#endregion

	}

	#endregion

}

