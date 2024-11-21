namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: SysPrcActualVersion

	/// <exclude/>
	public class SysPrcActualVersion : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public SysPrcActualVersion(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysPrcActualVersion";
		}

		public SysPrcActualVersion(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "SysPrcActualVersion";
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
		public Guid RootVersionSchemaId {
			get {
				return GetTypedColumnValue<Guid>("RootVersionSchemaId");
			}
			set {
				SetColumnValue("RootVersionSchemaId", value);
				_rootVersionSchema = null;
			}
		}

		/// <exclude/>
		public string RootVersionSchemaCaption {
			get {
				return GetTypedColumnValue<string>("RootVersionSchemaCaption");
			}
			set {
				SetColumnValue("RootVersionSchemaCaption", value);
				if (_rootVersionSchema != null) {
					_rootVersionSchema.Caption = value;
				}
			}
		}

		private SysSchema _rootVersionSchema;
		/// <summary>
		/// Root version.
		/// </summary>
		public SysSchema RootVersionSchema {
			get {
				return _rootVersionSchema ??
					(_rootVersionSchema = new SysSchema(LookupColumnEntities.GetEntity("RootVersionSchema")));
			}
		}

		/// <exclude/>
		public Guid ActualVersionSchemaId {
			get {
				return GetTypedColumnValue<Guid>("ActualVersionSchemaId");
			}
			set {
				SetColumnValue("ActualVersionSchemaId", value);
				_actualVersionSchema = null;
			}
		}

		/// <exclude/>
		public string ActualVersionSchemaCaption {
			get {
				return GetTypedColumnValue<string>("ActualVersionSchemaCaption");
			}
			set {
				SetColumnValue("ActualVersionSchemaCaption", value);
				if (_actualVersionSchema != null) {
					_actualVersionSchema.Caption = value;
				}
			}
		}

		private SysSchema _actualVersionSchema;
		/// <summary>
		/// Actual version.
		/// </summary>
		public SysSchema ActualVersionSchema {
			get {
				return _actualVersionSchema ??
					(_actualVersionSchema = new SysSchema(LookupColumnEntities.GetEntity("ActualVersionSchema")));
			}
		}

		#endregion

	}

	#endregion

}

