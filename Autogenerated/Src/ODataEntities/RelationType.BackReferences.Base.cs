namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: RelationType

	/// <exclude/>
	public class RelationType : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public RelationType(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "RelationType";
		}

		public RelationType(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "RelationType";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<Relationship> RelationshipCollectionByRelationType {
			get;
			set;
		}

		public IEnumerable<Relationship> RelationshipCollectionByReverseRelationType {
			get;
			set;
		}

		public IEnumerable<RelationshipConnection> RelationshipConnectionCollectionByRelationType {
			get;
			set;
		}

		public IEnumerable<RelationType> RelationTypeCollectionByReverseRelationType {
			get;
			set;
		}

		public IEnumerable<VwAccountRelationship> VwAccountRelationshipCollectionByRelationType {
			get;
			set;
		}

		public IEnumerable<VwAccountRelationship> VwAccountRelationshipCollectionByReverseRelationType {
			get;
			set;
		}

		public IEnumerable<VwContactRelationship> VwContactRelationshipCollectionByRelationType {
			get;
			set;
		}

		public IEnumerable<VwContactRelationship> VwContactRelationshipCollectionByReverseRelationType {
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

		/// <summary>
		/// Название.
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
		/// Контакт-Контакт.
		/// </summary>
		public bool ForContactContact {
			get {
				return GetTypedColumnValue<bool>("ForContactContact");
			}
			set {
				SetColumnValue("ForContactContact", value);
			}
		}

		/// <summary>
		/// Контрагент-Контакт.
		/// </summary>
		public bool ForAccountContact {
			get {
				return GetTypedColumnValue<bool>("ForAccountContact");
			}
			set {
				SetColumnValue("ForAccountContact", value);
			}
		}

		/// <summary>
		/// Контакт-Контрагент.
		/// </summary>
		public bool ForContactAccount {
			get {
				return GetTypedColumnValue<bool>("ForContactAccount");
			}
			set {
				SetColumnValue("ForContactAccount", value);
			}
		}

		/// <summary>
		/// Контрагент-Контрагент.
		/// </summary>
		public bool ForAccountAccount {
			get {
				return GetTypedColumnValue<bool>("ForAccountAccount");
			}
			set {
				SetColumnValue("ForAccountAccount", value);
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
		/// Обратная взаимосвязь.
		/// </summary>
		public RelationType ReverseRelationType {
			get {
				return _reverseRelationType ??
					(_reverseRelationType = new RelationType(LookupColumnEntities.GetEntity("ReverseRelationType")));
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

		/// <summary>
		/// Включить в контейнер.
		/// </summary>
		public bool IncludeIntoContainer {
			get {
				return GetTypedColumnValue<bool>("IncludeIntoContainer");
			}
			set {
				SetColumnValue("IncludeIntoContainer", value);
			}
		}

		/// <exclude/>
		public Guid PositionId {
			get {
				return GetTypedColumnValue<Guid>("PositionId");
			}
			set {
				SetColumnValue("PositionId", value);
				_position = null;
			}
		}

		/// <exclude/>
		public string PositionName {
			get {
				return GetTypedColumnValue<string>("PositionName");
			}
			set {
				SetColumnValue("PositionName", value);
				if (_position != null) {
					_position.Name = value;
				}
			}
		}

		private RelationTypePosition _position;
		/// <summary>
		/// Позиция.
		/// </summary>
		public RelationTypePosition Position {
			get {
				return _position ??
					(_position = new RelationTypePosition(LookupColumnEntities.GetEntity("Position")));
			}
		}

		/// <exclude/>
		public Guid RelationConnectionTypeId {
			get {
				return GetTypedColumnValue<Guid>("RelationConnectionTypeId");
			}
			set {
				SetColumnValue("RelationConnectionTypeId", value);
				_relationConnectionType = null;
			}
		}

		/// <exclude/>
		public string RelationConnectionTypeName {
			get {
				return GetTypedColumnValue<string>("RelationConnectionTypeName");
			}
			set {
				SetColumnValue("RelationConnectionTypeName", value);
				if (_relationConnectionType != null) {
					_relationConnectionType.Name = value;
				}
			}
		}

		private RelationConnectionType _relationConnectionType;
		/// <summary>
		/// Тип связи.
		/// </summary>
		public RelationConnectionType RelationConnectionType {
			get {
				return _relationConnectionType ??
					(_relationConnectionType = new RelationConnectionType(LookupColumnEntities.GetEntity("RelationConnectionType")));
			}
		}

		#endregion

	}

	#endregion

}

