namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: RelationshipConnection

	/// <exclude/>
	public class RelationshipConnection : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public RelationshipConnection(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "RelationshipConnection";
		}

		public RelationshipConnection(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "RelationshipConnection";
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
		public Guid RelationshipEntityAId {
			get {
				return GetTypedColumnValue<Guid>("RelationshipEntityAId");
			}
			set {
				SetColumnValue("RelationshipEntityAId", value);
				_relationshipEntityA = null;
			}
		}

		private RelationshipEntity _relationshipEntityA;
		/// <summary>
		/// Entity A.
		/// </summary>
		public RelationshipEntity RelationshipEntityA {
			get {
				return _relationshipEntityA ??
					(_relationshipEntityA = new RelationshipEntity(LookupColumnEntities.GetEntity("RelationshipEntityA")));
			}
		}

		/// <exclude/>
		public Guid RelationshipEntityBId {
			get {
				return GetTypedColumnValue<Guid>("RelationshipEntityBId");
			}
			set {
				SetColumnValue("RelationshipEntityBId", value);
				_relationshipEntityB = null;
			}
		}

		private RelationshipEntity _relationshipEntityB;
		/// <summary>
		/// Entity B.
		/// </summary>
		public RelationshipEntity RelationshipEntityB {
			get {
				return _relationshipEntityB ??
					(_relationshipEntityB = new RelationshipEntity(LookupColumnEntities.GetEntity("RelationshipEntityB")));
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

		/// <summary>
		/// Comment.
		/// </summary>
		public string Comment {
			get {
				return GetTypedColumnValue<string>("Comment");
			}
			set {
				SetColumnValue("Comment", value);
			}
		}

		#endregion

	}

	#endregion

}

