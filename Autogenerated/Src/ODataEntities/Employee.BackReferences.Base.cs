namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: Employee

	/// <exclude/>
	public class Employee : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public Employee(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Employee";
		}

		public Employee(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "Employee";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<Employee> EmployeeCollectionByManager {
			get;
			set;
		}

		public IEnumerable<EmployeeCareer> EmployeeCareerCollectionByEmployee {
			get;
			set;
		}

		public IEnumerable<EmployeeFile> EmployeeFileCollectionByEmployee {
			get;
			set;
		}

		public IEnumerable<EmployeeInFolder> EmployeeInFolderCollectionByEmployee {
			get;
			set;
		}

		public IEnumerable<EmployeeInTag> EmployeeInTagCollectionByEntity {
			get;
			set;
		}

		public IEnumerable<OrgStructureUnit> OrgStructureUnitCollectionByHead {
			get;
			set;
		}

		public IEnumerable<Salary> SalaryCollectionByEmployee {
			get;
			set;
		}

		public IEnumerable<VwEmployeesHierarchy> VwEmployeesHierarchyCollectionByEmployee {
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
		public Guid OrgStructureUnitId {
			get {
				return GetTypedColumnValue<Guid>("OrgStructureUnitId");
			}
			set {
				SetColumnValue("OrgStructureUnitId", value);
				_orgStructureUnit = null;
			}
		}

		/// <exclude/>
		public string OrgStructureUnitName {
			get {
				return GetTypedColumnValue<string>("OrgStructureUnitName");
			}
			set {
				SetColumnValue("OrgStructureUnitName", value);
				if (_orgStructureUnit != null) {
					_orgStructureUnit.Name = value;
				}
			}
		}

		private OrgStructureUnit _orgStructureUnit;
		/// <summary>
		/// Organizational unit.
		/// </summary>
		public OrgStructureUnit OrgStructureUnit {
			get {
				return _orgStructureUnit ??
					(_orgStructureUnit = new OrgStructureUnit(LookupColumnEntities.GetEntity("OrgStructureUnit")));
			}
		}

		/// <summary>
		/// Notes.
		/// </summary>
		public string Notes {
			get {
				return GetTypedColumnValue<string>("Notes");
			}
			set {
				SetColumnValue("Notes", value);
			}
		}

		/// <exclude/>
		public Guid JobId {
			get {
				return GetTypedColumnValue<Guid>("JobId");
			}
			set {
				SetColumnValue("JobId", value);
				_job = null;
			}
		}

		/// <exclude/>
		public string JobName {
			get {
				return GetTypedColumnValue<string>("JobName");
			}
			set {
				SetColumnValue("JobName", value);
				if (_job != null) {
					_job.Name = value;
				}
			}
		}

		private EmployeeJob _job;
		/// <summary>
		/// Job.
		/// </summary>
		public EmployeeJob Job {
			get {
				return _job ??
					(_job = new EmployeeJob(LookupColumnEntities.GetEntity("Job")));
			}
		}

		/// <summary>
		/// Full job title.
		/// </summary>
		public string FullJobTitle {
			get {
				return GetTypedColumnValue<string>("FullJobTitle");
			}
			set {
				SetColumnValue("FullJobTitle", value);
			}
		}

		/// <exclude/>
		public Guid OwnerId {
			get {
				return GetTypedColumnValue<Guid>("OwnerId");
			}
			set {
				SetColumnValue("OwnerId", value);
				_owner = null;
			}
		}

		/// <exclude/>
		public string OwnerName {
			get {
				return GetTypedColumnValue<string>("OwnerName");
			}
			set {
				SetColumnValue("OwnerName", value);
				if (_owner != null) {
					_owner.Name = value;
				}
			}
		}

		private Contact _owner;
		/// <summary>
		/// Owner.
		/// </summary>
		public Contact Owner {
			get {
				return _owner ??
					(_owner = new Contact(LookupColumnEntities.GetEntity("Owner")));
			}
		}

		/// <summary>
		/// Start date.
		/// </summary>
		public DateTime CareerStartDate {
			get {
				return GetTypedColumnValue<DateTime>("CareerStartDate");
			}
			set {
				SetColumnValue("CareerStartDate", value);
			}
		}

		/// <summary>
		/// Due date.
		/// </summary>
		public DateTime CareerDueDate {
			get {
				return GetTypedColumnValue<DateTime>("CareerDueDate");
			}
			set {
				SetColumnValue("CareerDueDate", value);
			}
		}

		/// <summary>
		/// Probation ends.
		/// </summary>
		public DateTime ProbationDueDate {
			get {
				return GetTypedColumnValue<DateTime>("ProbationDueDate");
			}
			set {
				SetColumnValue("ProbationDueDate", value);
			}
		}

		/// <exclude/>
		public Guid ReasonForDismissalId {
			get {
				return GetTypedColumnValue<Guid>("ReasonForDismissalId");
			}
			set {
				SetColumnValue("ReasonForDismissalId", value);
				_reasonForDismissal = null;
			}
		}

		/// <exclude/>
		public string ReasonForDismissalName {
			get {
				return GetTypedColumnValue<string>("ReasonForDismissalName");
			}
			set {
				SetColumnValue("ReasonForDismissalName", value);
				if (_reasonForDismissal != null) {
					_reasonForDismissal.Name = value;
				}
			}
		}

		private ReasonForLeaving _reasonForDismissal;
		/// <summary>
		/// Reason for job change.
		/// </summary>
		public ReasonForLeaving ReasonForDismissal {
			get {
				return _reasonForDismissal ??
					(_reasonForDismissal = new ReasonForLeaving(LookupColumnEntities.GetEntity("ReasonForDismissal")));
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
		/// Account.
		/// </summary>
		public Account Account {
			get {
				return _account ??
					(_account = new Account(LookupColumnEntities.GetEntity("Account")));
			}
		}

		/// <exclude/>
		public Guid ManagerId {
			get {
				return GetTypedColumnValue<Guid>("ManagerId");
			}
			set {
				SetColumnValue("ManagerId", value);
				_manager = null;
			}
		}

		/// <exclude/>
		public string ManagerName {
			get {
				return GetTypedColumnValue<string>("ManagerName");
			}
			set {
				SetColumnValue("ManagerName", value);
				if (_manager != null) {
					_manager.Name = value;
				}
			}
		}

		private Employee _manager;
		/// <summary>
		/// Manager.
		/// </summary>
		public Employee Manager {
			get {
				return _manager ??
					(_manager = new Employee(LookupColumnEntities.GetEntity("Manager")));
			}
		}

		#endregion

	}

	#endregion

}

