namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: ResolvedLookupConflict

	/// <exclude/>
	public class ResolvedLookupConflict : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public ResolvedLookupConflict(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ResolvedLookupConflict";
		}

		public ResolvedLookupConflict(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "ResolvedLookupConflict";
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
		/// Lookup name.
		/// </summary>
		public string LookupSchemaName {
			get {
				return GetTypedColumnValue<string>("LookupSchemaName");
			}
			set {
				SetColumnValue("LookupSchemaName", value);
			}
		}

		/// <summary>
		/// Displayed lookup value column.
		/// </summary>
		public string LookupSchemaDisplayColumnName {
			get {
				return GetTypedColumnValue<string>("LookupSchemaDisplayColumnName");
			}
			set {
				SetColumnValue("LookupSchemaDisplayColumnName", value);
			}
		}

		/// <summary>
		/// Estimated value of lookup displayed column.
		/// </summary>
		public string LookupSchemaDisplayColumnValue {
			get {
				return GetTypedColumnValue<string>("LookupSchemaDisplayColumnValue");
			}
			set {
				SetColumnValue("LookupSchemaDisplayColumnValue", value);
			}
		}

		/// <summary>
		/// Lookup value Id.
		/// </summary>
		public Guid LookupRecordId {
			get {
				return GetTypedColumnValue<Guid>("LookupRecordId");
			}
			set {
				SetColumnValue("LookupRecordId", value);
			}
		}

		#endregion

	}

	#endregion

}

