namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: CompletenessParameter

	/// <exclude/>
	public class CompletenessParameter : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public CompletenessParameter(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "CompletenessParameter";
		}

		public CompletenessParameter(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "CompletenessParameter";
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

		/// <exclude/>
		public Guid CompletenessId {
			get {
				return GetTypedColumnValue<Guid>("CompletenessId");
			}
			set {
				SetColumnValue("CompletenessId", value);
				_completeness = null;
			}
		}

		/// <exclude/>
		public string CompletenessName {
			get {
				return GetTypedColumnValue<string>("CompletenessName");
			}
			set {
				SetColumnValue("CompletenessName", value);
				if (_completeness != null) {
					_completeness.Name = value;
				}
			}
		}

		private Completeness _completeness;
		/// <summary>
		/// Data entry compliance.
		/// </summary>
		public Completeness Completeness {
			get {
				return _completeness ??
					(_completeness = new Completeness(LookupColumnEntities.GetEntity("Completeness")));
			}
		}

		/// <summary>
		/// Attribute name.
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
		/// Attribute Id.
		/// </summary>
		public Guid AttributeId {
			get {
				return GetTypedColumnValue<Guid>("AttributeId");
			}
			set {
				SetColumnValue("AttributeId", value);
			}
		}

		/// <summary>
		/// Data population percentage, %.
		/// </summary>
		public int Percentage {
			get {
				return GetTypedColumnValue<int>("Percentage");
			}
			set {
				SetColumnValue("Percentage", value);
			}
		}

		/// <summary>
		/// Column usage option.
		/// </summary>
		public bool IsColumn {
			get {
				return GetTypedColumnValue<bool>("IsColumn");
			}
			set {
				SetColumnValue("IsColumn", value);
			}
		}

		/// <summary>
		/// Detail usage option.
		/// </summary>
		public bool IsDetail {
			get {
				return GetTypedColumnValue<bool>("IsDetail");
			}
			set {
				SetColumnValue("IsDetail", value);
			}
		}

		/// <summary>
		/// Column name.
		/// </summary>
		public string ColumnName {
			get {
				return GetTypedColumnValue<string>("ColumnName");
			}
			set {
				SetColumnValue("ColumnName", value);
			}
		}

		/// <summary>
		/// Object column name.
		/// </summary>
		public string DetailEntityName {
			get {
				return GetTypedColumnValue<string>("DetailEntityName");
			}
			set {
				SetColumnValue("DetailEntityName", value);
			}
		}

		/// <summary>
		/// Detail column name.
		/// </summary>
		public string DetailColumn {
			get {
				return GetTypedColumnValue<string>("DetailColumn");
			}
			set {
				SetColumnValue("DetailColumn", value);
			}
		}

		/// <summary>
		/// Detail column wizard.
		/// </summary>
		public string MasterColumn {
			get {
				return GetTypedColumnValue<string>("MasterColumn");
			}
			set {
				SetColumnValue("MasterColumn", value);
			}
		}

		/// <summary>
		/// Column name with detail type.
		/// </summary>
		public string TypeColumn {
			get {
				return GetTypedColumnValue<string>("TypeColumn");
			}
			set {
				SetColumnValue("TypeColumn", value);
			}
		}

		/// <summary>
		/// Type column value.
		/// </summary>
		public Guid TypeValue {
			get {
				return GetTypedColumnValue<Guid>("TypeValue");
			}
			set {
				SetColumnValue("TypeValue", value);
			}
		}

		#endregion

	}

	#endregion

}

