namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: BulkEmailResponse

	/// <exclude/>
	public class BulkEmailResponse : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public BulkEmailResponse(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "BulkEmailResponse";
		}

		public BulkEmailResponse(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "BulkEmailResponse";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<BETArchiveFirstGeneration> BETArchiveFirstGenerationCollectionByBulkEmailResponse {
			get;
			set;
		}

		public IEnumerable<BETArchiveSecondGeneration> BETArchiveSecondGenerationCollectionByBulkEmailResponse {
			get;
			set;
		}

		public IEnumerable<BulkEmailCountLimit> BulkEmailCountLimitCollectionByOverlimitResponse {
			get;
			set;
		}

		public IEnumerable<BulkEmailTarget> BulkEmailTargetCollectionByBulkEmailResponse {
			get;
			set;
		}

		public IEnumerable<VwBulkEmailAudience> VwBulkEmailAudienceCollectionByBulkEmailResponse {
			get;
			set;
		}

		public IEnumerable<VwBulkEmailTarget> VwBulkEmailTargetCollectionByBulkEmailResponse {
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
		public bool IsFinalState {
			get {
				return GetTypedColumnValue<bool>("IsFinalState");
			}
			set {
				SetColumnValue("IsFinalState", value);
			}
		}

		/// <summary>
		/// Категория.
		/// </summary>
		public int Category {
			get {
				return GetTypedColumnValue<int>("Category");
			}
			set {
				SetColumnValue("Category", value);
			}
		}

		/// <summary>
		/// Code.
		/// </summary>
		public int Code {
			get {
				return GetTypedColumnValue<int>("Code");
			}
			set {
				SetColumnValue("Code", value);
			}
		}

		/// <summary>
		/// Приоритет.
		/// </summary>
		public int Priority {
			get {
				return GetTypedColumnValue<int>("Priority");
			}
			set {
				SetColumnValue("Priority", value);
			}
		}

		#endregion

	}

	#endregion

}

