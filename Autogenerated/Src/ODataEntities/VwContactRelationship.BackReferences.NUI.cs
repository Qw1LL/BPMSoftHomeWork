namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: VwContactRelationship

	/// <exclude/>
	public class VwContactRelationship : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public VwContactRelationship(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwContactRelationship";
		}

		public VwContactRelationship(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "VwContactRelationship";
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
		public Guid ContactId {
			get {
				return GetTypedColumnValue<Guid>("ContactId");
			}
			set {
				SetColumnValue("ContactId", value);
				_contact = null;
			}
		}

		/// <exclude/>
		public string ContactName {
			get {
				return GetTypedColumnValue<string>("ContactName");
			}
			set {
				SetColumnValue("ContactName", value);
				if (_contact != null) {
					_contact.Name = value;
				}
			}
		}

		private Contact _contact;
		/// <summary>
		/// Contact.
		/// </summary>
		public Contact Contact {
			get {
				return _contact ??
					(_contact = new Contact(LookupColumnEntities.GetEntity("Contact")));
			}
		}

		/// <exclude/>
		public Guid RelatedAccountId {
			get {
				return GetTypedColumnValue<Guid>("RelatedAccountId");
			}
			set {
				SetColumnValue("RelatedAccountId", value);
				_relatedAccount = null;
			}
		}

		/// <exclude/>
		public string RelatedAccountName {
			get {
				return GetTypedColumnValue<string>("RelatedAccountName");
			}
			set {
				SetColumnValue("RelatedAccountName", value);
				if (_relatedAccount != null) {
					_relatedAccount.Name = value;
				}
			}
		}

		private Account _relatedAccount;
		/// <summary>
		/// Connected account.
		/// </summary>
		public Account RelatedAccount {
			get {
				return _relatedAccount ??
					(_relatedAccount = new Account(LookupColumnEntities.GetEntity("RelatedAccount")));
			}
		}

		/// <exclude/>
		public Guid RelatedContactId {
			get {
				return GetTypedColumnValue<Guid>("RelatedContactId");
			}
			set {
				SetColumnValue("RelatedContactId", value);
				_relatedContact = null;
			}
		}

		/// <exclude/>
		public string RelatedContactName {
			get {
				return GetTypedColumnValue<string>("RelatedContactName");
			}
			set {
				SetColumnValue("RelatedContactName", value);
				if (_relatedContact != null) {
					_relatedContact.Name = value;
				}
			}
		}

		private Contact _relatedContact;
		/// <summary>
		/// Connected contact.
		/// </summary>
		public Contact RelatedContact {
			get {
				return _relatedContact ??
					(_relatedContact = new Contact(LookupColumnEntities.GetEntity("RelatedContact")));
			}
		}

		/// <exclude/>
		public Guid RelationTypeId {
			get {
				return GetTypedColumnValue<Guid>("RelationTypeId");
			}
			set {
				SetColumnValue("RelationTypeId", value);
				_relationType = null;
			}
		}

		/// <exclude/>
		public string RelationTypeName {
			get {
				return GetTypedColumnValue<string>("RelationTypeName");
			}
			set {
				SetColumnValue("RelationTypeName", value);
				if (_relationType != null) {
					_relationType.Name = value;
				}
			}
		}

		private RelationType _relationType;
		/// <summary>
		/// Relationship type.
		/// </summary>
		public RelationType RelationType {
			get {
				return _relationType ??
					(_relationType = new RelationType(LookupColumnEntities.GetEntity("RelationType")));
			}
		}

		/// <exclude/>
		public Guid ReverseRelationTypeId {
			get {
				return GetTypedColumnValue<Guid>("ReverseRelationTypeId");
			}
			set {
				SetColumnValue("ReverseRelationTypeId", value);
				_reverseRelationType = null;
			}
		}

		/// <exclude/>
		public string ReverseRelationTypeName {
			get {
				return GetTypedColumnValue<string>("ReverseRelationTypeName");
			}
			set {
				SetColumnValue("ReverseRelationTypeName", value);
				if (_reverseRelationType != null) {
					_reverseRelationType.Name = value;
				}
			}
		}

		private RelationType _reverseRelationType;
		/// <summary>
		/// Inverse relationship type.
		/// </summary>
		public RelationType ReverseRelationType {
			get {
				return _reverseRelationType ??
					(_reverseRelationType = new RelationType(LookupColumnEntities.GetEntity("ReverseRelationType")));
			}
		}

		/// <summary>
		/// Actual.
		/// </summary>
		public bool Active {
			get {
				return GetTypedColumnValue<bool>("Active");
			}
			set {
				SetColumnValue("Active", value);
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

		/// <summary>
		/// Connected object.
		/// </summary>
		public string RelatedObjectName {
			get {
				return GetTypedColumnValue<string>("RelatedObjectName");
			}
			set {
				SetColumnValue("RelatedObjectName", value);
			}
		}

		#endregion

	}

	#endregion

}

