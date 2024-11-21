namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: MLModelColumn

	/// <exclude/>
	public class MLModelColumn : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public MLModelColumn(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "MLModelColumn";
		}

		public MLModelColumn(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "MLModelColumn";
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
		public Guid MLModelId {
			get {
				return GetTypedColumnValue<Guid>("MLModelId");
			}
			set {
				SetColumnValue("MLModelId", value);
				_mLModel = null;
			}
		}

		/// <exclude/>
		public string MLModelName {
			get {
				return GetTypedColumnValue<string>("MLModelName");
			}
			set {
				SetColumnValue("MLModelName", value);
				if (_mLModel != null) {
					_mLModel.Name = value;
				}
			}
		}

		private MLModel _mLModel;
		/// <summary>
		/// Model.
		/// </summary>
		public MLModel MLModel {
			get {
				return _mLModel ??
					(_mLModel = new MLModel(LookupColumnEntities.GetEntity("MLModel")));
			}
		}

		/// <summary>
		/// Column identifier.
		/// </summary>
		public Guid ColumnUId {
			get {
				return GetTypedColumnValue<Guid>("ColumnUId");
			}
			set {
				SetColumnValue("ColumnUId", value);
			}
		}

		/// <summary>
		/// Caption.
		/// </summary>
		public string Caption {
			get {
				return GetTypedColumnValue<string>("Caption");
			}
			set {
				SetColumnValue("Caption", value);
			}
		}

		/// <summary>
		/// Column path.
		/// </summary>
		public string ColumnPath {
			get {
				return GetTypedColumnValue<string>("ColumnPath");
			}
			set {
				SetColumnValue("ColumnPath", value);
			}
		}

		/// <summary>
		/// AggregationType.
		/// </summary>
		public int AggregationType {
			get {
				return GetTypedColumnValue<int>("AggregationType");
			}
			set {
				SetColumnValue("AggregationType", value);
			}
		}

		/// <summary>
		/// Sub-filters.
		/// </summary>
		public string SubFilters {
			get {
				return GetTypedColumnValue<string>("SubFilters");
			}
			set {
				SetColumnValue("SubFilters", value);
			}
		}

		/// <exclude/>
		public Guid ColumnTypeId {
			get {
				return GetTypedColumnValue<Guid>("ColumnTypeId");
			}
			set {
				SetColumnValue("ColumnTypeId", value);
				_columnType = null;
			}
		}

		/// <exclude/>
		public string ColumnTypeName {
			get {
				return GetTypedColumnValue<string>("ColumnTypeName");
			}
			set {
				SetColumnValue("ColumnTypeName", value);
				if (_columnType != null) {
					_columnType.Name = value;
				}
			}
		}

		private MLModelColumnType _columnType;
		/// <summary>
		/// Column type.
		/// </summary>
		public MLModelColumnType ColumnType {
			get {
				return _columnType ??
					(_columnType = new MLModelColumnType(LookupColumnEntities.GetEntity("ColumnType")));
			}
		}

		#endregion

	}

	#endregion

}

