namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: SysEntitySchemaRecordDefRight

	/// <exclude/>
	public class SysEntitySchemaRecordDefRight : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public SysEntitySchemaRecordDefRight(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysEntitySchemaRecordDefRight";
		}

		public SysEntitySchemaRecordDefRight(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "SysEntitySchemaRecordDefRight";
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

		/// <exclude/>
		public Guid AuthorId {
			get {
				return GetTypedColumnValue<Guid>("AuthorId");
			}
			set {
				SetColumnValue("AuthorId", value);
				_author = null;
			}
		}

		/// <exclude/>
		public string AuthorName {
			get {
				return GetTypedColumnValue<string>("AuthorName");
			}
			set {
				SetColumnValue("AuthorName", value);
				if (_author != null) {
					_author.Name = value;
				}
			}
		}

		private VwSysAdminUnit _author;
		/// <summary>
		/// Created by.
		/// </summary>
		public VwSysAdminUnit Author {
			get {
				return _author ??
					(_author = new VwSysAdminUnit(LookupColumnEntities.GetEntity("Author")));
			}
		}

		/// <exclude/>
		public Guid GranteeId {
			get {
				return GetTypedColumnValue<Guid>("GranteeId");
			}
			set {
				SetColumnValue("GranteeId", value);
				_grantee = null;
			}
		}

		/// <exclude/>
		public string GranteeName {
			get {
				return GetTypedColumnValue<string>("GranteeName");
			}
			set {
				SetColumnValue("GranteeName", value);
				if (_grantee != null) {
					_grantee.Name = value;
				}
			}
		}

		private VwSysAdminUnit _grantee;
		/// <summary>
		/// User/role.
		/// </summary>
		public VwSysAdminUnit Grantee {
			get {
				return _grantee ??
					(_grantee = new VwSysAdminUnit(LookupColumnEntities.GetEntity("Grantee")));
			}
		}

		/// <exclude/>
		public Guid OperationId {
			get {
				return GetTypedColumnValue<Guid>("OperationId");
			}
			set {
				SetColumnValue("OperationId", value);
				_operation = null;
			}
		}

		/// <exclude/>
		public string OperationName {
			get {
				return GetTypedColumnValue<string>("OperationName");
			}
			set {
				SetColumnValue("OperationName", value);
				if (_operation != null) {
					_operation.Name = value;
				}
			}
		}

		private EntitySchemaRecRightOperation _operation;
		/// <summary>
		/// Operation.
		/// </summary>
		public EntitySchemaRecRightOperation Operation {
			get {
				return _operation ??
					(_operation = new EntitySchemaRecRightOperation(LookupColumnEntities.GetEntity("Operation")));
			}
		}

		/// <exclude/>
		public Guid RightLevelId {
			get {
				return GetTypedColumnValue<Guid>("RightLevelId");
			}
			set {
				SetColumnValue("RightLevelId", value);
				_rightLevel = null;
			}
		}

		/// <exclude/>
		public string RightLevelName {
			get {
				return GetTypedColumnValue<string>("RightLevelName");
			}
			set {
				SetColumnValue("RightLevelName", value);
				if (_rightLevel != null) {
					_rightLevel.Name = value;
				}
			}
		}

		private SysEntitySchemaRecOprRightLvl _rightLevel;
		/// <summary>
		/// Access level.
		/// </summary>
		public SysEntitySchemaRecOprRightLvl RightLevel {
			get {
				return _rightLevel ??
					(_rightLevel = new SysEntitySchemaRecOprRightLvl(LookupColumnEntities.GetEntity("RightLevel")));
			}
		}

		/// <summary>
		/// Position.
		/// </summary>
		public int Position {
			get {
				return GetTypedColumnValue<int>("Position");
			}
			set {
				SetColumnValue("Position", value);
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
		/// Unique identifier of schema in workspace.
		/// </summary>
		public Guid SubjectSchemaUId {
			get {
				return GetTypedColumnValue<Guid>("SubjectSchemaUId");
			}
			set {
				SetColumnValue("SubjectSchemaUId", value);
			}
		}

		#endregion

	}

	#endregion

}

