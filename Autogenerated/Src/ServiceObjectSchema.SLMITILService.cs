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

	#region Class: ServiceObjectSchema

	/// <exclude/>
	public class ServiceObjectSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public ServiceObjectSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ServiceObjectSchema(ServiceObjectSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ServiceObjectSchema(ServiceObjectSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("56985638-ca77-406e-8877-8bb6e1915c3d");
			RealUId = new Guid("56985638-ca77-406e-8877-8bb6e1915c3d");
			Name = "ServiceObject";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("9ff10791-c751-4145-a905-8eedd68967d7")) == null) {
				Columns.Add(CreateAccountColumn());
			}
			if (Columns.FindByUId(new Guid("76a59a85-24a6-4cbf-babb-e0301f99b01f")) == null) {
				Columns.Add(CreateContactColumn());
			}
			if (Columns.FindByUId(new Guid("93a4f86a-f526-4371-9a6c-58c529cf7881")) == null) {
				Columns.Add(CreateDepartmentColumn());
			}
			if (Columns.FindByUId(new Guid("7683f033-443b-4f9c-aa92-a386fbcbdffb")) == null) {
				Columns.Add(CreateServicePactColumn());
			}
			if (Columns.FindByUId(new Guid("905c7bbd-1c6d-4a29-9029-1697d26cf559")) == null) {
				Columns.Add(CreateTypeColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("56985638-ca77-406e-8877-8bb6e1915c3d");
			column.CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("56985638-ca77-406e-8877-8bb6e1915c3d");
			column.CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("56985638-ca77-406e-8877-8bb6e1915c3d");
			column.CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("56985638-ca77-406e-8877-8bb6e1915c3d");
			column.CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("56985638-ca77-406e-8877-8bb6e1915c3d");
			column.CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("56985638-ca77-406e-8877-8bb6e1915c3d");
			column.CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485");
			return column;
		}

		protected virtual EntitySchemaColumn CreateAccountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("9ff10791-c751-4145-a905-8eedd68967d7"),
				Name = @"Account",
				ReferenceSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("56985638-ca77-406e-8877-8bb6e1915c3d"),
				ModifiedInSchemaUId = new Guid("56985638-ca77-406e-8877-8bb6e1915c3d"),
				CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485")
			};
		}

		protected virtual EntitySchemaColumn CreateContactColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("76a59a85-24a6-4cbf-babb-e0301f99b01f"),
				Name = @"Contact",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("56985638-ca77-406e-8877-8bb6e1915c3d"),
				ModifiedInSchemaUId = new Guid("56985638-ca77-406e-8877-8bb6e1915c3d"),
				CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485")
			};
		}

		protected virtual EntitySchemaColumn CreateDepartmentColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("93a4f86a-f526-4371-9a6c-58c529cf7881"),
				Name = @"Department",
				ReferenceSchemaUId = new Guid("7a269220-a657-4b5f-bfb4-ebe596e419d8"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("56985638-ca77-406e-8877-8bb6e1915c3d"),
				ModifiedInSchemaUId = new Guid("56985638-ca77-406e-8877-8bb6e1915c3d"),
				CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485")
			};
		}

		protected virtual EntitySchemaColumn CreateServicePactColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("7683f033-443b-4f9c-aa92-a386fbcbdffb"),
				Name = @"ServicePact",
				ReferenceSchemaUId = new Guid("595ddbda-31ce-4cca-9bdd-862257ceaf23"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("56985638-ca77-406e-8877-8bb6e1915c3d"),
				ModifiedInSchemaUId = new Guid("56985638-ca77-406e-8877-8bb6e1915c3d"),
				CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485")
			};
		}

		protected virtual EntitySchemaColumn CreateTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("905c7bbd-1c6d-4a29-9029-1697d26cf559"),
				Name = @"Type",
				ReferenceSchemaUId = new Guid("84de8928-d67f-4b9c-b224-62f16f7d2598"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("56985638-ca77-406e-8877-8bb6e1915c3d"),
				ModifiedInSchemaUId = new Guid("56985638-ca77-406e-8877-8bb6e1915c3d"),
				CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485"),
				IsSimpleLookup = true
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ServiceObject(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ServiceObject_SLMITILServiceEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ServiceObjectSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ServiceObjectSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("56985638-ca77-406e-8877-8bb6e1915c3d"));
		}

		#endregion

	}

	#endregion

	#region Class: ServiceObject

	/// <summary>
	/// Объект обслуживания.
	/// </summary>
	public class ServiceObject : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public ServiceObject(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ServiceObject";
		}

		public ServiceObject(ServiceObject source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

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
					(_account = LookupColumnEntities.GetEntity("Account") as Account);
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
		/// Контакт.
		/// </summary>
		public Contact Contact {
			get {
				return _contact ??
					(_contact = LookupColumnEntities.GetEntity("Contact") as Contact);
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

		/// <exclude/>
		public Guid TypeId {
			get {
				return GetTypedColumnValue<Guid>("TypeId");
			}
			set {
				SetColumnValue("TypeId", value);
				_type = null;
			}
		}

		/// <exclude/>
		public string TypeName {
			get {
				return GetTypedColumnValue<string>("TypeName");
			}
			set {
				SetColumnValue("TypeName", value);
				if (_type != null) {
					_type.Name = value;
				}
			}
		}

		private ServiceObjectType _type;
		/// <summary>
		/// Тип.
		/// </summary>
		public ServiceObjectType Type {
			get {
				return _type ??
					(_type = LookupColumnEntities.GetEntity("Type") as ServiceObjectType);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ServiceObject_SLMITILServiceEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ServiceObjectDeleted", e);
			Validating += (s, e) => ThrowEvent("ServiceObjectValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ServiceObject(this);
		}

		#endregion

	}

	#endregion

	#region Class: ServiceObject_SLMITILServiceEventsProcess

	/// <exclude/>
	public partial class ServiceObject_SLMITILServiceEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : ServiceObject
	{

		public ServiceObject_SLMITILServiceEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ServiceObject_SLMITILServiceEventsProcess";
			SchemaUId = new Guid("56985638-ca77-406e-8877-8bb6e1915c3d");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("56985638-ca77-406e-8877-8bb6e1915c3d");
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

	#region Class: ServiceObject_SLMITILServiceEventsProcess

	/// <exclude/>
	public class ServiceObject_SLMITILServiceEventsProcess : ServiceObject_SLMITILServiceEventsProcess<ServiceObject>
	{

		public ServiceObject_SLMITILServiceEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ServiceObject_SLMITILServiceEventsProcess

	public partial class ServiceObject_SLMITILServiceEventsProcess<TEntity>
	{

		#region Methods: Public

		public override void LocalMessageExecuting(EntityChangeType changeType) {
			var lmHelper = new BPMSoft.Configuration.LocalMessageHelper(this.Entity, UserConnection, changeType);
			lmHelper.CreateLocalMessage();
		}

		#endregion

	}

	#endregion


	#region Class: ServiceObjectEventsProcess

	/// <exclude/>
	public class ServiceObjectEventsProcess : ServiceObject_SLMITILServiceEventsProcess
	{

		public ServiceObjectEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

