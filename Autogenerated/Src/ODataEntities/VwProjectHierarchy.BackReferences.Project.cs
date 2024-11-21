namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: VwProjectHierarchy

	/// <exclude/>
	public class VwProjectHierarchy : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public VwProjectHierarchy(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwProjectHierarchy";
		}

		public VwProjectHierarchy(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "VwProjectHierarchy";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid ProjectId {
			get {
				return GetTypedColumnValue<Guid>("ProjectId");
			}
			set {
				SetColumnValue("ProjectId", value);
				_project = null;
			}
		}

		/// <exclude/>
		public string ProjectName {
			get {
				return GetTypedColumnValue<string>("ProjectName");
			}
			set {
				SetColumnValue("ProjectName", value);
				if (_project != null) {
					_project.Name = value;
				}
			}
		}

		private Project _project;
		/// <summary>
		/// Проект.
		/// </summary>
		public Project Project {
			get {
				return _project ??
					(_project = new Project(LookupColumnEntities.GetEntity("Project")));
			}
		}

		/// <exclude/>
		public Guid BaseProjectId {
			get {
				return GetTypedColumnValue<Guid>("BaseProjectId");
			}
			set {
				SetColumnValue("BaseProjectId", value);
				_baseProject = null;
			}
		}

		/// <exclude/>
		public string BaseProjectName {
			get {
				return GetTypedColumnValue<string>("BaseProjectName");
			}
			set {
				SetColumnValue("BaseProjectName", value);
				if (_baseProject != null) {
					_baseProject.Name = value;
				}
			}
		}

		private Project _baseProject;
		/// <summary>
		/// Проект развертывания.
		/// </summary>
		public Project BaseProject {
			get {
				return _baseProject ??
					(_baseProject = new Project(LookupColumnEntities.GetEntity("BaseProject")));
			}
		}

		/// <summary>
		/// Первый элемент в развертывании.
		/// </summary>
		public bool IsFirst {
			get {
				return GetTypedColumnValue<bool>("IsFirst");
			}
			set {
				SetColumnValue("IsFirst", value);
			}
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

		/// <exclude/>
		public Guid AccountId {
			get {
				return GetTypedColumnValue<Guid>("AccountId");
			}
			set {
				SetColumnValue("AccountId", value);
				_account = null;
			}
		}

		/// <exclude/>
		public string AccountName {
			get {
				return GetTypedColumnValue<string>("AccountName");
			}
			set {
				SetColumnValue("AccountName", value);
				if (_account != null) {
					_account.Name = value;
				}
			}
		}

		private Account _account;
		/// <summary>
		/// Контрагент.
		/// </summary>
		public Account Account {
			get {
				return _account ??
					(_account = new Account(LookupColumnEntities.GetEntity("Account")));
			}
		}

		#endregion

	}

	#endregion

}

