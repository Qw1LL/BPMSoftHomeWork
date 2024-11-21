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

	#region Class: VwServiceRecepients_SLMITILService_BPMSoftSchema

	/// <exclude/>
	public class VwServiceRecepients_SLMITILService_BPMSoftSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public VwServiceRecepients_SLMITILService_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwServiceRecepients_SLMITILService_BPMSoftSchema(VwServiceRecepients_SLMITILService_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwServiceRecepients_SLMITILService_BPMSoftSchema(VwServiceRecepients_SLMITILService_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("bef8b415-16ee-4d17-8691-458a112c3d17");
			RealUId = new Guid("bef8b415-16ee-4d17-8691-458a112c3d17");
			Name = "VwServiceRecepients_SLMITILService_BPMSoft";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("914c52f8-7161-4b32-82f6-d4cef8b3a889");
			IsDBView = true;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("d983295a-031a-4779-8c69-a89274336045")) == null) {
				Columns.Add(CreateContactColumn());
			}
			if (Columns.FindByUId(new Guid("92715f73-81e7-48cd-940c-9f30cedc1180")) == null) {
				Columns.Add(CreateAccountColumn());
			}
			if (Columns.FindByUId(new Guid("cceffae8-345a-4ad3-a67f-adf8d7866262")) == null) {
				Columns.Add(CreateServiceColumn());
			}
			if (Columns.FindByUId(new Guid("abd4d179-4518-43c1-a6bf-bc0e888ae04b")) == null) {
				Columns.Add(CreateDepartmentColumn());
			}
			if (Columns.FindByUId(new Guid("b0aee64f-9372-487a-b477-f387acea59e2")) == null) {
				Columns.Add(CreateServicePactColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateContactColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("d983295a-031a-4779-8c69-a89274336045"),
				Name = @"Contact",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("bef8b415-16ee-4d17-8691-458a112c3d17"),
				ModifiedInSchemaUId = new Guid("bef8b415-16ee-4d17-8691-458a112c3d17"),
				CreatedInPackageId = new Guid("914c52f8-7161-4b32-82f6-d4cef8b3a889")
			};
		}

		protected virtual EntitySchemaColumn CreateAccountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("92715f73-81e7-48cd-940c-9f30cedc1180"),
				Name = @"Account",
				ReferenceSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("bef8b415-16ee-4d17-8691-458a112c3d17"),
				ModifiedInSchemaUId = new Guid("bef8b415-16ee-4d17-8691-458a112c3d17"),
				CreatedInPackageId = new Guid("914c52f8-7161-4b32-82f6-d4cef8b3a889")
			};
		}

		protected virtual EntitySchemaColumn CreateServiceColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("cceffae8-345a-4ad3-a67f-adf8d7866262"),
				Name = @"Service",
				ReferenceSchemaUId = new Guid("c6c44f0a-193e-4b5c-b35e-220a60c06898"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("bef8b415-16ee-4d17-8691-458a112c3d17"),
				ModifiedInSchemaUId = new Guid("bef8b415-16ee-4d17-8691-458a112c3d17"),
				CreatedInPackageId = new Guid("914c52f8-7161-4b32-82f6-d4cef8b3a889")
			};
		}

		protected virtual EntitySchemaColumn CreateDepartmentColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("abd4d179-4518-43c1-a6bf-bc0e888ae04b"),
				Name = @"Department",
				ReferenceSchemaUId = new Guid("7a269220-a657-4b5f-bfb4-ebe596e419d8"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("bef8b415-16ee-4d17-8691-458a112c3d17"),
				ModifiedInSchemaUId = new Guid("bef8b415-16ee-4d17-8691-458a112c3d17"),
				CreatedInPackageId = new Guid("914c52f8-7161-4b32-82f6-d4cef8b3a889")
			};
		}

		protected virtual EntitySchemaColumn CreateServicePactColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("b0aee64f-9372-487a-b477-f387acea59e2"),
				Name = @"ServicePact",
				ReferenceSchemaUId = new Guid("595ddbda-31ce-4cca-9bdd-862257ceaf23"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("bef8b415-16ee-4d17-8691-458a112c3d17"),
				ModifiedInSchemaUId = new Guid("bef8b415-16ee-4d17-8691-458a112c3d17"),
				CreatedInPackageId = new Guid("2ae03e06-9f1c-4d5c-b222-14d44604b4b1")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new VwServiceRecepients_SLMITILService_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwServiceRecepients_SLMITILServiceEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwServiceRecepients_SLMITILService_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwServiceRecepients_SLMITILService_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("bef8b415-16ee-4d17-8691-458a112c3d17"));
		}

		#endregion

	}

	#endregion

	#region Class: VwServiceRecepients_SLMITILService_BPMSoft

	/// <summary>
	/// Пользователи сервисов.
	/// </summary>
	public class VwServiceRecepients_SLMITILService_BPMSoft : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public VwServiceRecepients_SLMITILService_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwServiceRecepients_SLMITILService_BPMSoft";
		}

		public VwServiceRecepients_SLMITILService_BPMSoft(VwServiceRecepients_SLMITILService_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

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
					(_contact = LookupColumnEntities.GetEntity("Contact") as Contact);
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
					(_account = LookupColumnEntities.GetEntity("Account") as Account);
			}
		}

		/// <exclude/>
		public Guid ServiceId {
			get {
				return GetTypedColumnValue<Guid>("ServiceId");
			}
			set {
				SetColumnValue("ServiceId", value);
				_service = null;
			}
		}

		/// <exclude/>
		public string ServiceName {
			get {
				return GetTypedColumnValue<string>("ServiceName");
			}
			set {
				SetColumnValue("ServiceName", value);
				if (_service != null) {
					_service.Name = value;
				}
			}
		}

		private ServiceItem _service;
		/// <summary>
		/// Service.
		/// </summary>
		public ServiceItem Service {
			get {
				return _service ??
					(_service = LookupColumnEntities.GetEntity("Service") as ServiceItem);
			}
		}

		/// <exclude/>
		public Guid DepartmentId {
			get {
				return GetTypedColumnValue<Guid>("DepartmentId");
			}
			set {
				SetColumnValue("DepartmentId", value);
				_department = null;
			}
		}

		/// <exclude/>
		public string DepartmentName {
			get {
				return GetTypedColumnValue<string>("DepartmentName");
			}
			set {
				SetColumnValue("DepartmentName", value);
				if (_department != null) {
					_department.Name = value;
				}
			}
		}

		private Department _department;
		/// <summary>
		/// Департамент.
		/// </summary>
		public Department Department {
			get {
				return _department ??
					(_department = LookupColumnEntities.GetEntity("Department") as Department);
			}
		}

		/// <exclude/>
		public Guid ServicePactId {
			get {
				return GetTypedColumnValue<Guid>("ServicePactId");
			}
			set {
				SetColumnValue("ServicePactId", value);
				_servicePact = null;
			}
		}

		/// <exclude/>
		public string ServicePactName {
			get {
				return GetTypedColumnValue<string>("ServicePactName");
			}
			set {
				SetColumnValue("ServicePactName", value);
				if (_servicePact != null) {
					_servicePact.Name = value;
				}
			}
		}

		private ServicePact _servicePact;
		/// <summary>
		/// Сервисный договор.
		/// </summary>
		public ServicePact ServicePact {
			get {
				return _servicePact ??
					(_servicePact = LookupColumnEntities.GetEntity("ServicePact") as ServicePact);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new VwServiceRecepients_SLMITILServiceEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("VwServiceRecepients_SLMITILService_BPMSoftDeleted", e);
			Validating += (s, e) => ThrowEvent("VwServiceRecepients_SLMITILService_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new VwServiceRecepients_SLMITILService_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwServiceRecepients_SLMITILServiceEventsProcess

	/// <exclude/>
	public partial class VwServiceRecepients_SLMITILServiceEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : VwServiceRecepients_SLMITILService_BPMSoft
	{

		public VwServiceRecepients_SLMITILServiceEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwServiceRecepients_SLMITILServiceEventsProcess";
			SchemaUId = new Guid("bef8b415-16ee-4d17-8691-458a112c3d17");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("bef8b415-16ee-4d17-8691-458a112c3d17");
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

	#region Class: VwServiceRecepients_SLMITILServiceEventsProcess

	/// <exclude/>
	public class VwServiceRecepients_SLMITILServiceEventsProcess : VwServiceRecepients_SLMITILServiceEventsProcess<VwServiceRecepients_SLMITILService_BPMSoft>
	{

		public VwServiceRecepients_SLMITILServiceEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VwServiceRecepients_SLMITILServiceEventsProcess

	public partial class VwServiceRecepients_SLMITILServiceEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

