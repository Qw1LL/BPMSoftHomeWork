namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: LeadSourceUrl

	/// <exclude/>
	public class LeadSourceUrl : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public LeadSourceUrl(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "LeadSourceUrl";
		}

		public LeadSourceUrl(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "LeadSourceUrl";
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
		/// URL.
		/// </summary>
		public string URL {
			get {
				return GetTypedColumnValue<string>("URL");
			}
			set {
				SetColumnValue("URL", value);
			}
		}

		/// <exclude/>
		public Guid LeadSourceId {
			get {
				return GetTypedColumnValue<Guid>("LeadSourceId");
			}
			set {
				SetColumnValue("LeadSourceId", value);
				_leadSource = null;
			}
		}

		/// <exclude/>
		public string LeadSourceName {
			get {
				return GetTypedColumnValue<string>("LeadSourceName");
			}
			set {
				SetColumnValue("LeadSourceName", value);
				if (_leadSource != null) {
					_leadSource.Name = value;
				}
			}
		}

		private LeadSource _leadSource;
		/// <summary>
		/// Source.
		/// </summary>
		public LeadSource LeadSource {
			get {
				return _leadSource ??
					(_leadSource = new LeadSource(LookupColumnEntities.GetEntity("LeadSource")));
			}
		}

		#endregion

	}

	#endregion

}

