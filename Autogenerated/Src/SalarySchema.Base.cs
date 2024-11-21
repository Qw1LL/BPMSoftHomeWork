namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.DcmProcess;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;
	using BPMSoft.Core.Process;
	using BPMSoft.Core.Process.Configuration;
	using BPMSoft.GlobalSearch.Indexing;
	using BPMSoft.UI.WebControls.Controls;
	using BPMSoft.UI.WebControls.Utilities.Json.Converters;
	using DataContract = BPMSoft.Nui.ServiceModel.DataContract;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Data;
	using System.Drawing;
	using System.Globalization;
	using System.IO;
	using System.Linq;

	#region Class: SalarySchema

	/// <exclude/>
	public class SalarySchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SalarySchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SalarySchema(SalarySchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SalarySchema(SalarySchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("0dbe833e-3e62-4abe-a403-a5c649422e2d");
			RealUId = new Guid("0dbe833e-3e62-4abe-a403-a5c649422e2d");
			Name = "Salary";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("d4c9c615-b13d-4197-bfc6-4a583e7efd44")) == null) {
				Columns.Add(CreateEmployeeColumn());
			}
			if (Columns.FindByUId(new Guid("59340330-10c0-4b38-941f-e51ac7ee4524")) == null) {
				Columns.Add(CreateSalaryBaseValueColumn());
			}
			if (Columns.FindByUId(new Guid("71bf8253-500e-4034-b0f2-ec57b439171d")) == null) {
				Columns.Add(CreateStartDateColumn());
			}
			if (Columns.FindByUId(new Guid("6f919b70-762b-486c-b5cf-c636d72e123d")) == null) {
				Columns.Add(CreateDueDateColumn());
			}
			if (Columns.FindByUId(new Guid("74621c48-48e3-463b-8054-539e0dfa5737")) == null) {
				Columns.Add(CreateUnitForCalculationColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateEmployeeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("d4c9c615-b13d-4197-bfc6-4a583e7efd44"),
				Name = @"Employee",
				ReferenceSchemaUId = new Guid("fb1c2bed-91d4-4b06-a28c-621a3d187008"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("0dbe833e-3e62-4abe-a403-a5c649422e2d"),
				ModifiedInSchemaUId = new Guid("0dbe833e-3e62-4abe-a403-a5c649422e2d"),
				CreatedInPackageId = new Guid("c692daa9-de5e-4e96-afd3-e992ed86681c")
			};
		}

		protected virtual EntitySchemaColumn CreateSalaryBaseValueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float2")) {
				UId = new Guid("59340330-10c0-4b38-941f-e51ac7ee4524"),
				Name = @"SalaryBaseValue",
				CreatedInSchemaUId = new Guid("0dbe833e-3e62-4abe-a403-a5c649422e2d"),
				ModifiedInSchemaUId = new Guid("0dbe833e-3e62-4abe-a403-a5c649422e2d"),
				CreatedInPackageId = new Guid("c692daa9-de5e-4e96-afd3-e992ed86681c")
			};
		}

		protected virtual EntitySchemaColumn CreateStartDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Date")) {
				UId = new Guid("71bf8253-500e-4034-b0f2-ec57b439171d"),
				Name = @"StartDate",
				CreatedInSchemaUId = new Guid("0dbe833e-3e62-4abe-a403-a5c649422e2d"),
				ModifiedInSchemaUId = new Guid("0dbe833e-3e62-4abe-a403-a5c649422e2d"),
				CreatedInPackageId = new Guid("c692daa9-de5e-4e96-afd3-e992ed86681c")
			};
		}

		protected virtual EntitySchemaColumn CreateDueDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Date")) {
				UId = new Guid("6f919b70-762b-486c-b5cf-c636d72e123d"),
				Name = @"DueDate",
				CreatedInSchemaUId = new Guid("0dbe833e-3e62-4abe-a403-a5c649422e2d"),
				ModifiedInSchemaUId = new Guid("0dbe833e-3e62-4abe-a403-a5c649422e2d"),
				CreatedInPackageId = new Guid("c692daa9-de5e-4e96-afd3-e992ed86681c")
			};
		}

		protected virtual EntitySchemaColumn CreateUnitForCalculationColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("74621c48-48e3-463b-8054-539e0dfa5737"),
				Name = @"UnitForCalculation",
				ReferenceSchemaUId = new Guid("eecd2b4c-b41b-4da8-bcb7-5d793777d988"),
				CreatedInSchemaUId = new Guid("0dbe833e-3e62-4abe-a403-a5c649422e2d"),
				ModifiedInSchemaUId = new Guid("0dbe833e-3e62-4abe-a403-a5c649422e2d"),
				CreatedInPackageId = new Guid("c692daa9-de5e-4e96-afd3-e992ed86681c")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new Salary(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Salary_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SalarySchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SalarySchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("0dbe833e-3e62-4abe-a403-a5c649422e2d"));
		}

		#endregion

	}

	#endregion

	#region Class: Salary

	/// <summary>
	/// Rate.
	/// </summary>
	public class Salary : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public Salary(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Salary";
		}

		public Salary(Salary source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

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
					(_employee = LookupColumnEntities.GetEntity("Employee") as Employee);
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
					(_unitForCalculation = LookupColumnEntities.GetEntity("UnitForCalculation") as UnitForCalculation);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Salary_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SalaryDeleted", e);
			Deleting += (s, e) => ThrowEvent("SalaryDeleting", e);
			Inserted += (s, e) => ThrowEvent("SalaryInserted", e);
			Inserting += (s, e) => ThrowEvent("SalaryInserting", e);
			Saved += (s, e) => ThrowEvent("SalarySaved", e);
			Saving += (s, e) => ThrowEvent("SalarySaving", e);
			Validating += (s, e) => ThrowEvent("SalaryValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new Salary(this);
		}

		#endregion

	}

	#endregion

	#region Class: Salary_BaseEventsProcess

	/// <exclude/>
	public partial class Salary_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : Salary
	{

		public Salary_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Salary_BaseEventsProcess";
			SchemaUId = new Guid("0dbe833e-3e62-4abe-a403-a5c649422e2d");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("0dbe833e-3e62-4abe-a403-a5c649422e2d");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: Salary_BaseEventsProcess

	/// <exclude/>
	public class Salary_BaseEventsProcess : Salary_BaseEventsProcess<Salary>
	{

		public Salary_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: Salary_BaseEventsProcess

	public partial class Salary_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SalaryEventsProcess

	/// <exclude/>
	public class SalaryEventsProcess : Salary_BaseEventsProcess
	{

		public SalaryEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

