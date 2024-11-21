namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: BulkEmailSplitSegment

	/// <exclude/>
	public class BulkEmailSplitSegment : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public BulkEmailSplitSegment(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "BulkEmailSplitSegment";
		}

		public BulkEmailSplitSegment(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "BulkEmailSplitSegment";
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
		public Guid SegmentId {
			get {
				return GetTypedColumnValue<Guid>("SegmentId");
			}
			set {
				SetColumnValue("SegmentId", value);
				_segment = null;
			}
		}

		/// <exclude/>
		public string SegmentName {
			get {
				return GetTypedColumnValue<string>("SegmentName");
			}
			set {
				SetColumnValue("SegmentName", value);
				if (_segment != null) {
					_segment.Name = value;
				}
			}
		}

		private ContactFolder _segment;
		/// <summary>
		/// Сегмент.
		/// </summary>
		public ContactFolder Segment {
			get {
				return _segment ??
					(_segment = new ContactFolder(LookupColumnEntities.GetEntity("Segment")));
			}
		}

		/// <exclude/>
		public Guid BulkEmailSplitId {
			get {
				return GetTypedColumnValue<Guid>("BulkEmailSplitId");
			}
			set {
				SetColumnValue("BulkEmailSplitId", value);
				_bulkEmailSplit = null;
			}
		}

		/// <exclude/>
		public string BulkEmailSplitName {
			get {
				return GetTypedColumnValue<string>("BulkEmailSplitName");
			}
			set {
				SetColumnValue("BulkEmailSplitName", value);
				if (_bulkEmailSplit != null) {
					_bulkEmailSplit.Name = value;
				}
			}
		}

		private BulkEmailSplit _bulkEmailSplit;
		/// <summary>
		/// Email: Сплит-тест.
		/// </summary>
		public BulkEmailSplit BulkEmailSplit {
			get {
				return _bulkEmailSplit ??
					(_bulkEmailSplit = new BulkEmailSplit(LookupColumnEntities.GetEntity("BulkEmailSplit")));
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

		private SegmentStatus _state;
		/// <summary>
		/// Состояние.
		/// </summary>
		public SegmentStatus State {
			get {
				return _state ??
					(_state = new SegmentStatus(LookupColumnEntities.GetEntity("State")));
			}
		}

		#endregion

	}

	#endregion

}

