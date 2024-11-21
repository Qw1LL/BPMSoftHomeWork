namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: Salary

	/// <exclude/>
	public class Salary : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public Salary(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Salary";
		}

		public Salary(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "Salary";
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

		/// <summary>
		/// Rate (base currency).
		/// </summary>
		public Decimal SalaryBaseValue {
			get {
				return GetTypedColumnValue<Decimal>("SalaryBaseValue");
			}
			set {
				SetColumnValue("SalaryBaseValue", value);
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
		/// End date.
		/// </summary>
		public DateTime DueDate {
			get {
				return GetTypedColumnValue<DateTime>("DueDate");
			}
			set {
				SetColumnValue("DueDate", value);
			}
		}

		/// <exclude/>
		public Guid UnitForCalculationId {
			get {
				return GetTypedColumnValue<Guid>("UnitForCalculationId");
			}
			set {
				SetColumnValue("UnitForCalculationId", value);
				_unitForCalculation = null;
			}
		}

		/// <exclude/>
		public string UnitForCalculationName {
			get {
				return GetTypedColumnValue<string>("UnitForCalculationName");
			}
			set {
				SetColumnValue("UnitForCalculationName", value);
				if (_unitForCalculation != null) {
					_unitForCalculation.Name = value;
				}
			}
		}

		private UnitForCalculation _unitForCalculation;
		/// <summary>
		/// Unit of measure.
		/// </summary>
		public UnitForCalculation UnitForCalculation {
			get {
				return _unitForCalculation ??
					(_unitForCalculation = new UnitForCalculation(LookupColumnEntities.GetEntity("UnitForCalculation")));
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

		#endregion

	}

	#endregion

}

