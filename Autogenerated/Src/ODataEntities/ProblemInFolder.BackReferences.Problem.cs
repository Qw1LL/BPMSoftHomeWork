namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: ProblemInFolder

	/// <exclude/>
	public class ProblemInFolder : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public ProblemInFolder(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ProblemInFolder";
		}

		public ProblemInFolder(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "ProblemInFolder";
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

		private ProblemFolder _folder;
		/// <summary>
		/// Группа.
		/// </summary>
		public ProblemFolder Folder {
			get {
				return _folder ??
					(_folder = new ProblemFolder(LookupColumnEntities.GetEntity("Folder")));
			}
		}

		/// <exclude/>
		public Guid ProblemId {
			get {
				return GetTypedColumnValue<Guid>("ProblemId");
			}
			set {
				SetColumnValue("ProblemId", value);
				_problem = null;
			}
		}

		/// <exclude/>
		public string ProblemNumber {
			get {
				return GetTypedColumnValue<string>("ProblemNumber");
			}
			set {
				SetColumnValue("ProblemNumber", value);
				if (_problem != null) {
					_problem.Number = value;
				}
			}
		}

		private Problem _problem;
		/// <summary>
		/// Проблема.
		/// </summary>
		public Problem Problem {
			get {
				return _problem ??
					(_problem = new Problem(LookupColumnEntities.GetEntity("Problem")));
			}
		}

		#endregion

	}

	#endregion

}

