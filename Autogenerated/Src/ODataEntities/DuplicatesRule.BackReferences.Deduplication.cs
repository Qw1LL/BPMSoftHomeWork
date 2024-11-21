namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: DuplicatesRule

	/// <exclude/>
	public class DuplicatesRule : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public DuplicatesRule(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "DuplicatesRule";
		}

		public DuplicatesRule(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "DuplicatesRule";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<DuplicatesRuleInFolder> DuplicatesRuleInFolderCollectionByDuplicatesRule {
			get;
			set;
		}

		public IEnumerable<DuplicatesRuleInTag> DuplicatesRuleInTagCollectionByEntity {
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
		/// Active.
		/// </summary>
		public bool IsActive {
			get {
				return GetTypedColumnValue<bool>("IsActive");
			}
			set {
				SetColumnValue("IsActive", value);
			}
		}

		/// <exclude/>
		public Guid ObjectId {
			get {
				return GetTypedColumnValue<Guid>("ObjectId");
			}
			set {
				SetColumnValue("ObjectId", value);
				_object = null;
			}
		}

		/// <exclude/>
		public string ObjectCaption {
			get {
				return GetTypedColumnValue<string>("ObjectCaption");
			}
			set {
				SetColumnValue("ObjectCaption", value);
				if (_object != null) {
					_object.Caption = value;
				}
			}
		}

		private VwDuplicatesRuleType _object;
		/// <summary>
		/// Rule type.
		/// </summary>
		public VwDuplicatesRuleType Object {
			get {
				return _object ??
					(_object = new VwDuplicatesRuleType(LookupColumnEntities.GetEntity("Object")));
			}
		}

		/// <summary>
		/// Rule body.
		/// </summary>
		public string RuleBody {
			get {
				return GetTypedColumnValue<string>("RuleBody");
			}
			set {
				SetColumnValue("RuleBody", value);
			}
		}

		/// <summary>
		/// Procedure name.
		/// </summary>
		public string ProcedureName {
			get {
				return GetTypedColumnValue<string>("ProcedureName");
			}
			set {
				SetColumnValue("ProcedureName", value);
			}
		}

		/// <summary>
		/// Use this rule on save.
		/// </summary>
		public bool UseAtSave {
			get {
				return GetTypedColumnValue<bool>("UseAtSave");
			}
			set {
				SetColumnValue("UseAtSave", value);
			}
		}

		/// <exclude/>
		public Guid SearchObjectId {
			get {
				return GetTypedColumnValue<Guid>("SearchObjectId");
			}
			set {
				SetColumnValue("SearchObjectId", value);
				_searchObject = null;
			}
		}

		/// <exclude/>
		public string SearchObjectCaption {
			get {
				return GetTypedColumnValue<string>("SearchObjectCaption");
			}
			set {
				SetColumnValue("SearchObjectCaption", value);
				if (_searchObject != null) {
					_searchObject.Caption = value;
				}
			}
		}

		private VwDuplicatesRuleType _searchObject;
		/// <summary>
		/// Search object.
		/// </summary>
		public VwDuplicatesRuleType SearchObject {
			get {
				return _searchObject ??
					(_searchObject = new VwDuplicatesRuleType(LookupColumnEntities.GetEntity("SearchObject")));
			}
		}

		#endregion

	}

	#endregion

}

