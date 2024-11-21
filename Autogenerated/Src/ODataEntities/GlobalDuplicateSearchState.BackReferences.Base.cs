namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: GlobalDuplicateSearchState

	/// <exclude/>
	public class GlobalDuplicateSearchState : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public GlobalDuplicateSearchState(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "GlobalDuplicateSearchState";
		}

		public GlobalDuplicateSearchState(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "GlobalDuplicateSearchState";
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
		/// Created on.
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
		/// Created by.
		/// </summary>
		public Contact CreatedBy {
			get {
				return _createdBy ??
					(_createdBy = new Contact(LookupColumnEntities.GetEntity("CreatedBy")));
			}
		}

		/// <summary>
		/// Modified on.
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
		/// Modified by.
		/// </summary>
		public Contact ModifiedBy {
			get {
				return _modifiedBy ??
					(_modifiedBy = new Contact(LookupColumnEntities.GetEntity("ModifiedBy")));
			}
		}

		/// <summary>
		/// Number of record.
		/// </summary>
		public int EntityRowNumber {
			get {
				return GetTypedColumnValue<int>("EntityRowNumber");
			}
			set {
				SetColumnValue("EntityRowNumber", value);
			}
		}

		/// <summary>
		/// Schema.
		/// </summary>
		public Guid SchemaToSearchId {
			get {
				return GetTypedColumnValue<Guid>("SchemaToSearchId");
			}
			set {
				SetColumnValue("SchemaToSearchId", value);
			}
		}

		/// <summary>
		/// Number of processed records.
		/// </summary>
		public int ProcessedCount {
			get {
				return GetTypedColumnValue<int>("ProcessedCount");
			}
			set {
				SetColumnValue("ProcessedCount", value);
			}
		}

		/// <exclude/>
		public Guid SearchStatusId {
			get {
				return GetTypedColumnValue<Guid>("SearchStatusId");
			}
			set {
				SetColumnValue("SearchStatusId", value);
				_searchStatus = null;
			}
		}

		/// <exclude/>
		public string SearchStatusName {
			get {
				return GetTypedColumnValue<string>("SearchStatusName");
			}
			set {
				SetColumnValue("SearchStatusName", value);
				if (_searchStatus != null) {
					_searchStatus.Name = value;
				}
			}
		}

		private GlobalDuplicateSearchStatus _searchStatus;
		/// <summary>
		/// Status.
		/// </summary>
		public GlobalDuplicateSearchStatus SearchStatus {
			get {
				return _searchStatus ??
					(_searchStatus = new GlobalDuplicateSearchStatus(LookupColumnEntities.GetEntity("SearchStatus")));
			}
		}

		/// <summary>
		/// Time of status change.
		/// </summary>
		public DateTime SearchStatusChangedOn {
			get {
				return GetTypedColumnValue<DateTime>("SearchStatusChangedOn");
			}
			set {
				SetColumnValue("SearchStatusChangedOn", value);
			}
		}

		/// <summary>
		/// Number of records being processed.
		/// </summary>
		public int TotalCount {
			get {
				return GetTypedColumnValue<int>("TotalCount");
			}
			set {
				SetColumnValue("TotalCount", value);
			}
		}

		/// <summary>
		/// Run by user.
		/// </summary>
		public bool IsManuallyTriggered {
			get {
				return GetTypedColumnValue<bool>("IsManuallyTriggered");
			}
			set {
				SetColumnValue("IsManuallyTriggered", value);
			}
		}

		/// <summary>
		/// Active processes.
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
		/// Object name.
		/// </summary>
		public string SchemaToSearchName {
			get {
				return GetTypedColumnValue<string>("SchemaToSearchName");
			}
			set {
				SetColumnValue("SchemaToSearchName", value);
			}
		}

		#endregion

	}

	#endregion

}

