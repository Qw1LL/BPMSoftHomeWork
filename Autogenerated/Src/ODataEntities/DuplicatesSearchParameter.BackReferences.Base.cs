namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: DuplicatesSearchParameter

	/// <exclude/>
	public class DuplicatesSearchParameter : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public DuplicatesSearchParameter(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "DuplicatesSearchParameter";
		}

		public DuplicatesSearchParameter(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "DuplicatesSearchParameter";
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
		/// Search when saving record.
		/// </summary>
		public bool PerformSearchOnSave {
			get {
				return GetTypedColumnValue<bool>("PerformSearchOnSave");
			}
			set {
				SetColumnValue("PerformSearchOnSave", value);
			}
		}

		/// <summary>
		/// Scheduled search.
		/// </summary>
		public bool PerformSheduledSearch {
			get {
				return GetTypedColumnValue<bool>("PerformSheduledSearch");
			}
			set {
				SetColumnValue("PerformSheduledSearch", value);
			}
		}

		/// <summary>
		/// Search time.
		/// </summary>
		public DateTime SearchTime {
			get {
				return GetTypedColumnValue<DateTime>("SearchTime");
			}
			set {
				SetColumnValue("SearchTime", value);
			}
		}

		/// <summary>
		/// Search in modified objects only.
		/// </summary>
		public bool SearchByModifiedOnly {
			get {
				return GetTypedColumnValue<bool>("SearchByModifiedOnly");
			}
			set {
				SetColumnValue("SearchByModifiedOnly", value);
			}
		}

		/// <summary>
		/// Search in all objects.
		/// </summary>
		public bool SearchByAll {
			get {
				return GetTypedColumnValue<bool>("SearchByAll");
			}
			set {
				SetColumnValue("SearchByAll", value);
			}
		}

		/// <summary>
		/// Days.
		/// </summary>
		public int Days {
			get {
				return GetTypedColumnValue<int>("Days");
			}
			set {
				SetColumnValue("Days", value);
			}
		}

		/// <summary>
		/// Schema.
		/// </summary>
		public Guid SchemaToSearch {
			get {
				return GetTypedColumnValue<Guid>("SchemaToSearch");
			}
			set {
				SetColumnValue("SchemaToSearch", value);
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

