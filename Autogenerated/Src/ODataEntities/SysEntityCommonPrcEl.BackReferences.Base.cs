namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: SysEntityCommonPrcEl

	/// <exclude/>
	public class SysEntityCommonPrcEl : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public SysEntityCommonPrcEl(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysEntityCommonPrcEl";
		}

		public SysEntityCommonPrcEl(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "SysEntityCommonPrcEl";
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
		/// Object record.
		/// </summary>
		public Guid RecordId {
			get {
				return GetTypedColumnValue<Guid>("RecordId");
			}
			set {
				SetColumnValue("RecordId", value);
			}
		}

		/// <exclude/>
		public Guid ProcessElementId {
			get {
				return GetTypedColumnValue<Guid>("ProcessElementId");
			}
			set {
				SetColumnValue("ProcessElementId", value);
				_processElement = null;
			}
		}

		private SysProcessElementData _processElement;
		/// <summary>
		/// Process item.
		/// </summary>
		public SysProcessElementData ProcessElement {
			get {
				return _processElement ??
					(_processElement = new SysProcessElementData(LookupColumnEntities.GetEntity("ProcessElement")));
			}
		}

		/// <summary>
		/// Finishing conditions.
		/// </summary>
		public string ConditionData {
			get {
				return GetTypedColumnValue<string>("ConditionData");
			}
			set {
				SetColumnValue("ConditionData", value);
			}
		}

		/// <summary>
		/// Completing condition by modified column.
		/// </summary>
		public string ChangedColumns {
			get {
				return GetTypedColumnValue<string>("ChangedColumns");
			}
			set {
				SetColumnValue("ChangedColumns", value);
			}
		}

		/// <summary>
		/// Modification type.
		/// </summary>
		public int RecordChangeType {
			get {
				return GetTypedColumnValue<int>("RecordChangeType");
			}
			set {
				SetColumnValue("RecordChangeType", value);
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
		/// Object schema.
		/// </summary>
		public Guid EntitySchemaUId {
			get {
				return GetTypedColumnValue<Guid>("EntitySchemaUId");
			}
			set {
				SetColumnValue("EntitySchemaUId", value);
			}
		}

		#endregion

	}

	#endregion

}

