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

	#region Class: ConfItemUserSchema

	/// <exclude/>
	public class ConfItemUserSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public ConfItemUserSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ConfItemUserSchema(ConfItemUserSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ConfItemUserSchema(ConfItemUserSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("20c3c5b2-70d1-4c96-beec-2ee29fd4b283");
			RealUId = new Guid("20c3c5b2-70d1-4c96-beec-2ee29fd4b283");
			Name = "ConfItemUser";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("a9e9b695-9f79-45ac-96ca-2985cdc58f84");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("501d47c7-3afc-4770-b709-16973005b199")) == null) {
				Columns.Add(CreateAccountColumn());
			}
			if (Columns.FindByUId(new Guid("5084de84-c20b-4165-b78c-f1964645dc67")) == null) {
				Columns.Add(CreateContactColumn());
			}
			if (Columns.FindByUId(new Guid("3a8042d8-6d9d-481e-907d-7a21a9ca13fa")) == null) {
				Columns.Add(CreateDepartmentColumn());
			}
			if (Columns.FindByUId(new Guid("3243552d-a06a-49db-9971-4e799c8c9a2f")) == null) {
				Columns.Add(CreateConfItemColumn());
			}
			if (Columns.FindByUId(new Guid("583097d8-783b-40bb-9fd8-02b02334705b")) == null) {
				Columns.Add(CreateTypeColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("20c3c5b2-70d1-4c96-beec-2ee29fd4b283");
			column.CreatedInPackageId = new Guid("a9e9b695-9f79-45ac-96ca-2985cdc58f84");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("20c3c5b2-70d1-4c96-beec-2ee29fd4b283");
			column.CreatedInPackageId = new Guid("a9e9b695-9f79-45ac-96ca-2985cdc58f84");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("20c3c5b2-70d1-4c96-beec-2ee29fd4b283");
			column.CreatedInPackageId = new Guid("a9e9b695-9f79-45ac-96ca-2985cdc58f84");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("20c3c5b2-70d1-4c96-beec-2ee29fd4b283");
			column.CreatedInPackageId = new Guid("a9e9b695-9f79-45ac-96ca-2985cdc58f84");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("20c3c5b2-70d1-4c96-beec-2ee29fd4b283");
			column.CreatedInPackageId = new Guid("a9e9b695-9f79-45ac-96ca-2985cdc58f84");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("20c3c5b2-70d1-4c96-beec-2ee29fd4b283");
			column.CreatedInPackageId = new Guid("a9e9b695-9f79-45ac-96ca-2985cdc58f84");
			return column;
		}

		protected virtual EntitySchemaColumn CreateAccountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("501d47c7-3afc-4770-b709-16973005b199"),
				Name = @"Account",
				ReferenceSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("20c3c5b2-70d1-4c96-beec-2ee29fd4b283"),
				ModifiedInSchemaUId = new Guid("20c3c5b2-70d1-4c96-beec-2ee29fd4b283"),
				CreatedInPackageId = new Guid("a9e9b695-9f79-45ac-96ca-2985cdc58f84")
			};
		}

		protected virtual EntitySchemaColumn CreateContactColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("5084de84-c20b-4165-b78c-f1964645dc67"),
				Name = @"Contact",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("20c3c5b2-70d1-4c96-beec-2ee29fd4b283"),
				ModifiedInSchemaUId = new Guid("20c3c5b2-70d1-4c96-beec-2ee29fd4b283"),
				CreatedInPackageId = new Guid("a9e9b695-9f79-45ac-96ca-2985cdc58f84")
			};
		}

		protected virtual EntitySchemaColumn CreateDepartmentColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("3a8042d8-6d9d-481e-907d-7a21a9ca13fa"),
				Name = @"Department",
				ReferenceSchemaUId = new Guid("7a269220-a657-4b5f-bfb4-ebe596e419d8"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("20c3c5b2-70d1-4c96-beec-2ee29fd4b283"),
				ModifiedInSchemaUId = new Guid("20c3c5b2-70d1-4c96-beec-2ee29fd4b283"),
				CreatedInPackageId = new Guid("a9e9b695-9f79-45ac-96ca-2985cdc58f84")
			};
		}

		protected virtual EntitySchemaColumn CreateConfItemColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("3243552d-a06a-49db-9971-4e799c8c9a2f"),
				Name = @"ConfItem",
				ReferenceSchemaUId = new Guid("ad707075-cf25-40bf-85c1-f5da38cf0d5d"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("20c3c5b2-70d1-4c96-beec-2ee29fd4b283"),
				ModifiedInSchemaUId = new Guid("20c3c5b2-70d1-4c96-beec-2ee29fd4b283"),
				CreatedInPackageId = new Guid("a9e9b695-9f79-45ac-96ca-2985cdc58f84")
			};
		}

		protected virtual EntitySchemaColumn CreateTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("583097d8-783b-40bb-9fd8-02b02334705b"),
				Name = @"Type",
				ReferenceSchemaUId = new Guid("84de8928-d67f-4b9c-b224-62f16f7d2598"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("20c3c5b2-70d1-4c96-beec-2ee29fd4b283"),
				ModifiedInSchemaUId = new Guid("20c3c5b2-70d1-4c96-beec-2ee29fd4b283"),
				CreatedInPackageId = new Guid("a9e9b695-9f79-45ac-96ca-2985cdc58f84")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ConfItemUser(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ConfItemUser_CMDBEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ConfItemUserSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ConfItemUserSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("20c3c5b2-70d1-4c96-beec-2ee29fd4b283"));
		}

		#endregion

	}

	#endregion

	#region Class: ConfItemUser

	/// <summary>
	/// Пользователь конфигурационной единицы.
	/// </summary>
	public class ConfItemUser : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public ConfItemUser(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ConfItemUser";
		}

		public ConfItemUser(ConfItemUser source)
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
		public Guid ConfItemId {
			get {
				return GetTypedColumnValue<Guid>("ConfItemId");
			}
			set {
				SetColumnValue("ConfItemId", value);
				_confItem = null;
			}
		}

		/// <exclude/>
		public string ConfItemName {
			get {
				return GetTypedColumnValue<string>("ConfItemName");
			}
			set {
				SetColumnValue("ConfItemName", value);
				if (_confItem != null) {
					_confItem.Name = value;
				}
			}
		}

		private ConfItem _confItem;
		/// <summary>
		/// Конфигурационная единица.
		/// </summary>
		public ConfItem ConfItem {
			get {
				return _confItem ??
					(_confItem = LookupColumnEntities.GetEntity("ConfItem") as ConfItem);
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
			var process = new ConfItemUser_CMDBEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ConfItemUserDeleted", e);
			Inserting += (s, e) => ThrowEvent("ConfItemUserInserting", e);
			Validating += (s, e) => ThrowEvent("ConfItemUserValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ConfItemUser(this);
		}

		#endregion

	}

	#endregion

	#region Class: ConfItemUser_CMDBEventsProcess

	/// <exclude/>
	public partial class ConfItemUser_CMDBEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : ConfItemUser
	{

		public ConfItemUser_CMDBEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ConfItemUser_CMDBEventsProcess";
			SchemaUId = new Guid("20c3c5b2-70d1-4c96-beec-2ee29fd4b283");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("20c3c5b2-70d1-4c96-beec-2ee29fd4b283");
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

	#region Class: ConfItemUser_CMDBEventsProcess

	/// <exclude/>
	public class ConfItemUser_CMDBEventsProcess : ConfItemUser_CMDBEventsProcess<ConfItemUser>
	{

		public ConfItemUser_CMDBEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ConfItemUser_CMDBEventsProcess

	public partial class ConfItemUser_CMDBEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ConfItemUserEventsProcess

	/// <exclude/>
	public class ConfItemUserEventsProcess : ConfItemUser_CMDBEventsProcess
	{

		public ConfItemUserEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

