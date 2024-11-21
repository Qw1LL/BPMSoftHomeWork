namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: Attribute

	/// <exclude/>
	public class Attribute : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public Attribute(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Attribute";
		}

		public Attribute(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "Attribute";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<AttributeReferenceSchema> AttributeReferenceSchemaCollectionByAttribute {
			get;
			set;
		}

		public IEnumerable<AttributeValue> AttributeValueCollectionByAttribute {
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
		/// Name.
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
		/// Description.
		/// </summary>
		public string Description {
			get {
				return GetTypedColumnValue<string>("Description");
			}
			set {
				SetColumnValue("Description", value);
			}
		}

		/// <exclude/>
		public Guid OwnerSchemaId {
			get {
				return GetTypedColumnValue<Guid>("OwnerSchemaId");
			}
			set {
				SetColumnValue("OwnerSchemaId", value);
				_ownerSchema = null;
			}
		}

		/// <exclude/>
		public string OwnerSchemaCaption {
			get {
				return GetTypedColumnValue<string>("OwnerSchemaCaption");
			}
			set {
				SetColumnValue("OwnerSchemaCaption", value);
				if (_ownerSchema != null) {
					_ownerSchema.Caption = value;
				}
			}
		}

		private SysSchema _ownerSchema;
		/// <summary>
		/// Schema.
		/// </summary>
		public SysSchema OwnerSchema {
			get {
				return _ownerSchema ??
					(_ownerSchema = new SysSchema(LookupColumnEntities.GetEntity("OwnerSchema")));
			}
		}

		/// <summary>
		/// Title.
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
		/// Data type.
		/// </summary>
		public Guid ValueType {
			get {
				return GetTypedColumnValue<Guid>("ValueType");
			}
			set {
				SetColumnValue("ValueType", value);
			}
		}

		/// <exclude/>
		public Guid ReferenceSchemaId {
			get {
				return GetTypedColumnValue<Guid>("ReferenceSchemaId");
			}
			set {
				SetColumnValue("ReferenceSchemaId", value);
				_referenceSchema = null;
			}
		}

		/// <exclude/>
		public string ReferenceSchemaCaption {
			get {
				return GetTypedColumnValue<string>("ReferenceSchemaCaption");
			}
			set {
				SetColumnValue("ReferenceSchemaCaption", value);
				if (_referenceSchema != null) {
					_referenceSchema.Caption = value;
				}
			}
		}

		private SysSchema _referenceSchema;
		/// <summary>
		/// Lookup.
		/// </summary>
		public SysSchema ReferenceSchema {
			get {
				return _referenceSchema ??
					(_referenceSchema = new SysSchema(LookupColumnEntities.GetEntity("ReferenceSchema")));
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

		#endregion

	}

	#endregion

}

