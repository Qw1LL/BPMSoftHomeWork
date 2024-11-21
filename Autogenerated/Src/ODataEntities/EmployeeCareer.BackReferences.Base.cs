namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: EmployeeCareer

	/// <exclude/>
	public class EmployeeCareer : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public EmployeeCareer(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "EmployeeCareer";
		}

		public EmployeeCareer(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "EmployeeCareer";
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
		public Guid EmployeeId {
			get {
				return GetTypedColumnValue<Guid>("EmployeeId");
			}
			set {
				SetColumnValue("EmployeeId", value);
				_employee = null;
			}
		}

		/// <exclude/>
		public string EmployeeName {
			get {
				return GetTypedColumnValue<string>("EmployeeName");
			}
			set {
				SetColumnValue("EmployeeName", value);
				if (_employee != null) {
					_employee.Name = value;
				}
			}
		}

		private Employee _employee;
		/// <summary>
		/// Employee.
		/// </summary>
		public Employee Employee {
			get {
				return _employee ??
					(_employee = new Employee(LookupColumnEntities.GetEntity("Employee")));
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
		/// Organization structure item.
		/// </summary>
		public OrgStructureUnit OrgStructureUnit {
			get {
				return _orgStructureUnit ??
					(_orgStructureUnit = new OrgStructureUnit(LookupColumnEntities.GetEntity("OrgStructureUnit")));
			}
		}

		/// <exclude/>
		public Guid EmployeeJobId {
			get {
				return GetTypedColumnValue<Guid>("EmployeeJobId");
			}
			set {
				SetColumnValue("EmployeeJobId", value);
				_employeeJob = null;
			}
		}

		/// <exclude/>
		public string EmployeeJobName {
			get {
				return GetTypedColumnValue<string>("EmployeeJobName");
			}
			set {
				SetColumnValue("EmployeeJobName", value);
				if (_employeeJob != null) {
					_employeeJob.Name = value;
				}
			}
		}

		private EmployeeJob _employeeJob;
		/// <summary>
		/// Job title.
		/// </summary>
		public EmployeeJob EmployeeJob {
			get {
				return _employeeJob ??
					(_employeeJob = new EmployeeJob(LookupColumnEntities.GetEntity("EmployeeJob")));
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

		/// <summary>
		/// Start date.
		/// </summary>
		public DateTime StartDate {
			get {
				return GetTypedColumnValue<DateTime>("StartDate");
			}
			set {
				SetColumnValue("StartDate", value);
			}
		}

		/// <summary>
		/// Due date.
		/// </summary>
		public DateTime DueDate {
			get {
				return GetTypedColumnValue<DateTime>("DueDate");
			}
			set {
				SetColumnValue("DueDate", value);
			}
		}

		/// <summary>
		/// Current.
		/// </summary>
		public bool IsCurrent {
			get {
				return GetTypedColumnValue<bool>("IsCurrent");
			}
			set {
				SetColumnValue("IsCurrent", value);
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

		#endregion

	}

	#endregion

}

