namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: VwRelationship

	/// <exclude/>
	public class VwRelationship : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public VwRelationship(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwRelationship";
		}

		public VwRelationship(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "VwRelationship";
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
		/// Our.
		/// </summary>
		public string Our {
			get {
				return GetTypedColumnValue<string>("Our");
			}
			set {
				SetColumnValue("Our", value);
			}
		}

		/// <summary>
		/// Connected.
		/// </summary>
		public string Related {
			get {
				return GetTypedColumnValue<string>("Related");
			}
			set {
				SetColumnValue("Related", value);
			}
		}

		/// <summary>
		/// Relationship type.
		/// </summary>
		public string OutputRelationType {
			get {
				return GetTypedColumnValue<string>("OutputRelationType");
			}
			set {
				SetColumnValue("OutputRelationType", value);
			}
		}

		/// <summary>
		/// Inverse relationship type.
		/// </summary>
		public string OutputReverseRelationType {
			get {
				return GetTypedColumnValue<string>("OutputReverseRelationType");
			}
			set {
				SetColumnValue("OutputReverseRelationType", value);
			}
		}

		/// <exclude/>
		public Guid ContactAId {
			get {
				return GetTypedColumnValue<Guid>("ContactAId");
			}
			set {
				SetColumnValue("ContactAId", value);
				_contactA = null;
			}
		}

		/// <exclude/>
		public string ContactAName {
			get {
				return GetTypedColumnValue<string>("ContactAName");
			}
			set {
				SetColumnValue("ContactAName", value);
				if (_contactA != null) {
					_contactA.Name = value;
				}
			}
		}

		private Contact _contactA;
		/// <summary>
		/// Contact A.
		/// </summary>
		public Contact ContactA {
			get {
				return _contactA ??
					(_contactA = new Contact(LookupColumnEntities.GetEntity("ContactA")));
			}
		}

		/// <exclude/>
		public Guid AccountAId {
			get {
				return GetTypedColumnValue<Guid>("AccountAId");
			}
			set {
				SetColumnValue("AccountAId", value);
				_accountA = null;
			}
		}

		/// <exclude/>
		public string AccountAName {
			get {
				return GetTypedColumnValue<string>("AccountAName");
			}
			set {
				SetColumnValue("AccountAName", value);
				if (_accountA != null) {
					_accountA.Name = value;
				}
			}
		}

		private Account _accountA;
		/// <summary>
		/// Account A.
		/// </summary>
		public Account AccountA {
			get {
				return _accountA ??
					(_accountA = new Account(LookupColumnEntities.GetEntity("AccountA")));
			}
		}

		/// <exclude/>
		public Guid ContactBId {
			get {
				return GetTypedColumnValue<Guid>("ContactBId");
			}
			set {
				SetColumnValue("ContactBId", value);
				_contactB = null;
			}
		}

		/// <exclude/>
		public string ContactBName {
			get {
				return GetTypedColumnValue<string>("ContactBName");
			}
			set {
				SetColumnValue("ContactBName", value);
				if (_contactB != null) {
					_contactB.Name = value;
				}
			}
		}

		private Contact _contactB;
		/// <summary>
		/// Contact B.
		/// </summary>
		public Contact ContactB {
			get {
				return _contactB ??
					(_contactB = new Contact(LookupColumnEntities.GetEntity("ContactB")));
			}
		}

		/// <exclude/>
		public Guid AccountBId {
			get {
				return GetTypedColumnValue<Guid>("AccountBId");
			}
			set {
				SetColumnValue("AccountBId", value);
				_accountB = null;
			}
		}

		/// <exclude/>
		public string AccountBName {
			get {
				return GetTypedColumnValue<string>("AccountBName");
			}
			set {
				SetColumnValue("AccountBName", value);
				if (_accountB != null) {
					_accountB.Name = value;
				}
			}
		}

		private Account _accountB;
		/// <summary>
		/// Account B.
		/// </summary>
		public Account AccountB {
			get {
				return _accountB ??
					(_accountB = new Account(LookupColumnEntities.GetEntity("AccountB")));
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

		#endregion

	}

	#endregion

}

