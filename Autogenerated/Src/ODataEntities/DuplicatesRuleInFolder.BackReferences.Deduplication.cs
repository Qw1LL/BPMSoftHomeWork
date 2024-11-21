namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: DuplicatesRuleInFolder

	/// <exclude/>
	public class DuplicatesRuleInFolder : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public DuplicatesRuleInFolder(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "DuplicatesRuleInFolder";
		}

		public DuplicatesRuleInFolder(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "DuplicatesRuleInFolder";
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
		public Guid FolderId {
			get {
				return GetTypedColumnValue<Guid>("FolderId");
			}
			set {
				SetColumnValue("FolderId", value);
				_folder = null;
			}
		}

		/// <exclude/>
		public string FolderName {
			get {
				return GetTypedColumnValue<string>("FolderName");
			}
			set {
				SetColumnValue("FolderName", value);
				if (_folder != null) {
					_folder.Name = value;
				}
			}
		}

		private DuplicatesRuleFolder _folder;
		/// <summary>
		/// Folder.
		/// </summary>
		public DuplicatesRuleFolder Folder {
			get {
				return _folder ??
					(_folder = new DuplicatesRuleFolder(LookupColumnEntities.GetEntity("Folder")));
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
		public Guid DuplicatesRuleId {
			get {
				return GetTypedColumnValue<Guid>("DuplicatesRuleId");
			}
			set {
				SetColumnValue("DuplicatesRuleId", value);
				_duplicatesRule = null;
			}
		}

		/// <exclude/>
		public string DuplicatesRuleName {
			get {
				return GetTypedColumnValue<string>("DuplicatesRuleName");
			}
			set {
				SetColumnValue("DuplicatesRuleName", value);
				if (_duplicatesRule != null) {
					_duplicatesRule.Name = value;
				}
			}
		}

		private DuplicatesRule _duplicatesRule;
		/// <summary>
		/// Duplicate rule.
		/// </summary>
		public DuplicatesRule DuplicatesRule {
			get {
				return _duplicatesRule ??
					(_duplicatesRule = new DuplicatesRule(LookupColumnEntities.GetEntity("DuplicatesRule")));
			}
		}

		#endregion

	}

	#endregion

}

