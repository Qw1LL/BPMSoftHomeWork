namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: BulkEmailSplit

	/// <exclude/>
	public class BulkEmailSplit : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public BulkEmailSplit(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "BulkEmailSplit";
		}

		public BulkEmailSplit(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "BulkEmailSplit";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<BulkEmail> BulkEmailCollectionBySplitTest {
			get;
			set;
		}

		public IEnumerable<BulkEmailInBulkEmailSplit> BulkEmailInBulkEmailSplitCollectionByBulkEmailSplit {
			get;
			set;
		}

		public IEnumerable<BulkEmailSplitFile> BulkEmailSplitFileCollectionByBulkEmailSplit {
			get;
			set;
		}

		public IEnumerable<BulkEmailSplitInFolder> BulkEmailSplitInFolderCollectionByBulkEmailSplit {
			get;
			set;
		}

		public IEnumerable<BulkEmailSplitSegment> BulkEmailSplitSegmentCollectionByBulkEmailSplit {
			get;
			set;
		}

		public IEnumerable<BulkEmailSplitTarget> BulkEmailSplitTargetCollectionByBulkEmailSplit {
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

		/// <exclude/>
		public Guid StatusId {
			get {
				return GetTypedColumnValue<Guid>("StatusId");
			}
			set {
				SetColumnValue("StatusId", value);
				_status = null;
			}
		}

		/// <exclude/>
		public string StatusName {
			get {
				return GetTypedColumnValue<string>("StatusName");
			}
			set {
				SetColumnValue("StatusName", value);
				if (_status != null) {
					_status.Name = value;
				}
			}
		}

		private BulkEmailSplitStatus _status;
		/// <summary>
		/// Состояние.
		/// </summary>
		public BulkEmailSplitStatus Status {
			get {
				return _status ??
					(_status = new BulkEmailSplitStatus(LookupColumnEntities.GetEntity("Status")));
			}
		}

		/// <summary>
		/// % получателей.
		/// </summary>
		public Decimal RecipientPercent {
			get {
				return GetTypedColumnValue<Decimal>("RecipientPercent");
			}
			set {
				SetColumnValue("RecipientPercent", value);
			}
		}

		/// <summary>
		/// Начало.
		/// </summary>
		public DateTime StartDate {
			get {
				return GetTypedColumnValue<DateTime>("StartDate");
			}
			set {
				SetColumnValue("StartDate", value);
			}
		}

		/// <summary>
		/// Запустить тест вручную.
		/// </summary>
		public bool StartManual {
			get {
				return GetTypedColumnValue<bool>("StartManual");
			}
			set {
				SetColumnValue("StartManual", value);
			}
		}

		/// <summary>
		/// RecipientCount.
		/// </summary>
		public int RecipientCount {
			get {
				return GetTypedColumnValue<int>("RecipientCount");
			}
			set {
				SetColumnValue("RecipientCount", value);
			}
		}

		/// <exclude/>
		public Guid SegmentsStatusId {
			get {
				return GetTypedColumnValue<Guid>("SegmentsStatusId");
			}
			set {
				SetColumnValue("SegmentsStatusId", value);
				_segmentsStatus = null;
			}
		}

		/// <exclude/>
		public string SegmentsStatusName {
			get {
				return GetTypedColumnValue<string>("SegmentsStatusName");
			}
			set {
				SetColumnValue("SegmentsStatusName", value);
				if (_segmentsStatus != null) {
					_segmentsStatus.Name = value;
				}
			}
		}

		private SegmentStatus _segmentsStatus;
		/// <summary>
		/// Состояние актуализации сегментов.
		/// </summary>
		public SegmentStatus SegmentsStatus {
			get {
				return _segmentsStatus ??
					(_segmentsStatus = new SegmentStatus(LookupColumnEntities.GetEntity("SegmentsStatus")));
			}
		}

		/// <summary>
		/// Описание.
		/// </summary>
		public string Notes {
			get {
				return GetTypedColumnValue<string>("Notes");
			}
			set {
				SetColumnValue("Notes", value);
			}
		}

		/// <summary>
		/// TransferTableName.
		/// </summary>
		public string TransferTableName {
			get {
				return GetTypedColumnValue<string>("TransferTableName");
			}
			set {
				SetColumnValue("TransferTableName", value);
			}
		}

		/// <summary>
		/// Получателей.
		/// </summary>
		public int TestRecipientCount {
			get {
				return GetTypedColumnValue<int>("TestRecipientCount");
			}
			set {
				SetColumnValue("TestRecipientCount", value);
			}
		}

		#endregion

	}

	#endregion

}

