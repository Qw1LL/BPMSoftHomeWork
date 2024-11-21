namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: Relationship

	/// <exclude/>
	public class Relationship : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public Relationship(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Relationship";
		}

		public Relationship(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "Relationship";
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
		/// Дата создания.
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
		/// Создал.
		/// </summary>
		public Contact CreatedBy {
			get {
				return _createdBy ??
					(_createdBy = new Contact(LookupColumnEntities.GetEntity("CreatedBy")));
			}
		}

		/// <summary>
		/// Дата изменения.
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
		/// Изменил.
		/// </summary>
		public Contact ModifiedBy {
			get {
				return _modifiedBy ??
					(_modifiedBy = new Contact(LookupColumnEntities.GetEntity("ModifiedBy")));
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
		/// Тип взаимосвязи.
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
		/// Обратный тип взаимосвязи.
		/// </summary>
		public RelationType ReverseRelationType {
			get {
				return _reverseRelationType ??
					(_reverseRelationType = new RelationType(LookupColumnEntities.GetEntity("ReverseRelationType")));
			}
		}

		/// <summary>
		/// Актуальна.
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
		/// Описание.
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
		/// Активные процессы.
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
		/// Контрагент А.
		/// </summary>
		public Account AccountA {
			get {
				return _accountA ??
					(_accountA = new Account(LookupColumnEntities.GetEntity("AccountA")));
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
		/// Контакт А.
		/// </summary>
		public Contact ContactA {
			get {
				return _contactA ??
					(_contactA = new Contact(LookupColumnEntities.GetEntity("ContactA")));
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
		/// Контрагент Б.
		/// </summary>
		public Account AccountB {
			get {
				return _accountB ??
					(_accountB = new Account(LookupColumnEntities.GetEntity("AccountB")));
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
		/// Контакт Б.
		/// </summary>
		public Contact ContactB {
			get {
				return _contactB ??
					(_contactB = new Contact(LookupColumnEntities.GetEntity("ContactB")));
			}
		}

		#endregion

	}

	#endregion

}

