namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Process;
	using BPMSoft.Core.Process.Configuration;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Drawing;
	using System.Globalization;
	using System.IO;

	#region Class: UsrTransportRequestsSchema

	/// <exclude/>
	public class UsrTransportRequestsSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public UsrTransportRequestsSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public UsrTransportRequestsSchema(UsrTransportRequestsSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public UsrTransportRequestsSchema(UsrTransportRequestsSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("ce3557cf-4e38-45eb-aa71-502879d15cd5");
			RealUId = new Guid("ce3557cf-4e38-45eb-aa71-502879d15cd5");
			Name = "UsrTransportRequests";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("3c4d067d-156b-4f1a-95fd-baa9da73b631");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateUsrNameColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("1934cb81-fcf4-4601-a8aa-ddb0041e3a8e")) == null) {
				Columns.Add(CreateUsrNotesColumn());
			}
			if (Columns.FindByUId(new Guid("cfb58900-6201-811d-85a1-4e91fc7620ca")) == null) {
				Columns.Add(CreateUsrRequestNumberColumn());
			}
			if (Columns.FindByUId(new Guid("5b2acd06-7ed4-0247-a511-47e8542a2fec")) == null) {
				Columns.Add(CreateUsrDescriptionColumn());
			}
			if (Columns.FindByUId(new Guid("f1ddd3fd-cd65-4941-f0ff-a20d3550ef93")) == null) {
				Columns.Add(CreateUsrOwnerColumn());
			}
			if (Columns.FindByUId(new Guid("05e3f5d7-a7cd-f876-3159-ae33f6263658")) == null) {
				Columns.Add(CreateUsrDriverColumn());
			}
			if (Columns.FindByUId(new Guid("bffc7d81-f639-8b53-6445-82b6e54d7630")) == null) {
				Columns.Add(CreateUsrCompanyColumn());
			}
			if (Columns.FindByUId(new Guid("dfe4e7f2-a673-164a-1526-a20903b32133")) == null) {
				Columns.Add(CreateUsrDeliveryAddressColumn());
			}
			if (Columns.FindByUId(new Guid("bf80b7ca-758e-88c9-6d16-35af4e1063cb")) == null) {
				Columns.Add(CreateUsrCarColumn());
			}
			if (Columns.FindByUId(new Guid("2f0759aa-ec2a-d6a6-1a77-e3624fac513e")) == null) {
				Columns.Add(CreateUsrStatusColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateUsrNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("28c9528a-5207-47c9-8546-6e1503fcb076"),
				Name = @"UsrName",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("ce3557cf-4e38-45eb-aa71-502879d15cd5"),
				ModifiedInSchemaUId = new Guid("ce3557cf-4e38-45eb-aa71-502879d15cd5"),
				CreatedInPackageId = new Guid("3c4d067d-156b-4f1a-95fd-baa9da73b631")
			};
		}

		protected virtual EntitySchemaColumn CreateUsrNotesColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("1934cb81-fcf4-4601-a8aa-ddb0041e3a8e"),
				Name = @"UsrNotes",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("ce3557cf-4e38-45eb-aa71-502879d15cd5"),
				ModifiedInSchemaUId = new Guid("ce3557cf-4e38-45eb-aa71-502879d15cd5"),
				CreatedInPackageId = new Guid("3c4d067d-156b-4f1a-95fd-baa9da73b631")
			};
		}

		protected virtual EntitySchemaColumn CreateUsrRequestNumberColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("cfb58900-6201-811d-85a1-4e91fc7620ca"),
				Name = @"UsrRequestNumber",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("ce3557cf-4e38-45eb-aa71-502879d15cd5"),
				ModifiedInSchemaUId = new Guid("ce3557cf-4e38-45eb-aa71-502879d15cd5"),
				CreatedInPackageId = new Guid("3c4d067d-156b-4f1a-95fd-baa9da73b631")
			};
		}

		protected virtual EntitySchemaColumn CreateUsrDescriptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("5b2acd06-7ed4-0247-a511-47e8542a2fec"),
				Name = @"UsrDescription",
				CreatedInSchemaUId = new Guid("ce3557cf-4e38-45eb-aa71-502879d15cd5"),
				ModifiedInSchemaUId = new Guid("ce3557cf-4e38-45eb-aa71-502879d15cd5"),
				CreatedInPackageId = new Guid("3c4d067d-156b-4f1a-95fd-baa9da73b631")
			};
		}

		protected virtual EntitySchemaColumn CreateUsrOwnerColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("f1ddd3fd-cd65-4941-f0ff-a20d3550ef93"),
				Name = @"UsrOwner",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("ce3557cf-4e38-45eb-aa71-502879d15cd5"),
				ModifiedInSchemaUId = new Guid("ce3557cf-4e38-45eb-aa71-502879d15cd5"),
				CreatedInPackageId = new Guid("3c4d067d-156b-4f1a-95fd-baa9da73b631")
			};
		}

		protected virtual EntitySchemaColumn CreateUsrDriverColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("05e3f5d7-a7cd-f876-3159-ae33f6263658"),
				Name = @"UsrDriver",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("ce3557cf-4e38-45eb-aa71-502879d15cd5"),
				ModifiedInSchemaUId = new Guid("ce3557cf-4e38-45eb-aa71-502879d15cd5"),
				CreatedInPackageId = new Guid("3c4d067d-156b-4f1a-95fd-baa9da73b631")
			};
		}

		protected virtual EntitySchemaColumn CreateUsrCompanyColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("bffc7d81-f639-8b53-6445-82b6e54d7630"),
				Name = @"UsrCompany",
				ReferenceSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("ce3557cf-4e38-45eb-aa71-502879d15cd5"),
				ModifiedInSchemaUId = new Guid("ce3557cf-4e38-45eb-aa71-502879d15cd5"),
				CreatedInPackageId = new Guid("3c4d067d-156b-4f1a-95fd-baa9da73b631")
			};
		}

		protected virtual EntitySchemaColumn CreateUsrDeliveryAddressColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("dfe4e7f2-a673-164a-1526-a20903b32133"),
				Name = @"UsrDeliveryAddress",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("ce3557cf-4e38-45eb-aa71-502879d15cd5"),
				ModifiedInSchemaUId = new Guid("ce3557cf-4e38-45eb-aa71-502879d15cd5"),
				CreatedInPackageId = new Guid("3c4d067d-156b-4f1a-95fd-baa9da73b631")
			};
		}

		protected virtual EntitySchemaColumn CreateUsrCarColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("bf80b7ca-758e-88c9-6d16-35af4e1063cb"),
				Name = @"UsrCar",
				ReferenceSchemaUId = new Guid("026fea1d-5414-47eb-9982-b5f2fe275e16"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("ce3557cf-4e38-45eb-aa71-502879d15cd5"),
				ModifiedInSchemaUId = new Guid("ce3557cf-4e38-45eb-aa71-502879d15cd5"),
				CreatedInPackageId = new Guid("3c4d067d-156b-4f1a-95fd-baa9da73b631")
			};
		}

		protected virtual EntitySchemaColumn CreateUsrStatusColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("2f0759aa-ec2a-d6a6-1a77-e3624fac513e"),
				Name = @"UsrStatus",
				ReferenceSchemaUId = new Guid("5f85028b-5bd2-4b3a-95d5-1fdee3742944"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("ce3557cf-4e38-45eb-aa71-502879d15cd5"),
				ModifiedInSchemaUId = new Guid("ce3557cf-4e38-45eb-aa71-502879d15cd5"),
				CreatedInPackageId = new Guid("3c4d067d-156b-4f1a-95fd-baa9da73b631")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new UsrTransportRequests(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new UsrTransportRequests_UsrHomeWorkEventsProcess(userConnection);
		}

		public override object Clone() {
			return new UsrTransportRequestsSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new UsrTransportRequestsSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ce3557cf-4e38-45eb-aa71-502879d15cd5"));
		}

		#endregion

	}

	#endregion

	#region Class: UsrTransportRequests

	/// <summary>
	/// Заявки на транспорт.
	/// </summary>
	public class UsrTransportRequests : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public UsrTransportRequests(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "UsrTransportRequests";
		}

		public UsrTransportRequests(UsrTransportRequests source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Название.
		/// </summary>
		public string UsrName {
			get {
				return GetTypedColumnValue<string>("UsrName");
			}
			set {
				SetColumnValue("UsrName", value);
			}
		}

		/// <summary>
		/// Заметки.
		/// </summary>
		public string UsrNotes {
			get {
				return GetTypedColumnValue<string>("UsrNotes");
			}
			set {
				SetColumnValue("UsrNotes", value);
			}
		}

		/// <summary>
		/// Номер заявки.
		/// </summary>
		public string UsrRequestNumber {
			get {
				return GetTypedColumnValue<string>("UsrRequestNumber");
			}
			set {
				SetColumnValue("UsrRequestNumber", value);
			}
		}

		/// <summary>
		/// Описание.
		/// </summary>
		public string UsrDescription {
			get {
				return GetTypedColumnValue<string>("UsrDescription");
			}
			set {
				SetColumnValue("UsrDescription", value);
			}
		}

		/// <exclude/>
		public Guid UsrOwnerId {
			get {
				return GetTypedColumnValue<Guid>("UsrOwnerId");
			}
			set {
				SetColumnValue("UsrOwnerId", value);
				_usrOwner = null;
			}
		}

		/// <exclude/>
		public string UsrOwnerName {
			get {
				return GetTypedColumnValue<string>("UsrOwnerName");
			}
			set {
				SetColumnValue("UsrOwnerName", value);
				if (_usrOwner != null) {
					_usrOwner.Name = value;
				}
			}
		}

		private Contact _usrOwner;
		/// <summary>
		/// Ответственный.
		/// </summary>
		public Contact UsrOwner {
			get {
				return _usrOwner ??
					(_usrOwner = LookupColumnEntities.GetEntity("UsrOwner") as Contact);
			}
		}

		/// <exclude/>
		public Guid UsrDriverId {
			get {
				return GetTypedColumnValue<Guid>("UsrDriverId");
			}
			set {
				SetColumnValue("UsrDriverId", value);
				_usrDriver = null;
			}
		}

		/// <exclude/>
		public string UsrDriverName {
			get {
				return GetTypedColumnValue<string>("UsrDriverName");
			}
			set {
				SetColumnValue("UsrDriverName", value);
				if (_usrDriver != null) {
					_usrDriver.Name = value;
				}
			}
		}

		private Contact _usrDriver;
		/// <summary>
		/// Водитель.
		/// </summary>
		public Contact UsrDriver {
			get {
				return _usrDriver ??
					(_usrDriver = LookupColumnEntities.GetEntity("UsrDriver") as Contact);
			}
		}

		/// <exclude/>
		public Guid UsrCompanyId {
			get {
				return GetTypedColumnValue<Guid>("UsrCompanyId");
			}
			set {
				SetColumnValue("UsrCompanyId", value);
				_usrCompany = null;
			}
		}

		/// <exclude/>
		public string UsrCompanyName {
			get {
				return GetTypedColumnValue<string>("UsrCompanyName");
			}
			set {
				SetColumnValue("UsrCompanyName", value);
				if (_usrCompany != null) {
					_usrCompany.Name = value;
				}
			}
		}

		private Account _usrCompany;
		/// <summary>
		/// Компания.
		/// </summary>
		public Account UsrCompany {
			get {
				return _usrCompany ??
					(_usrCompany = LookupColumnEntities.GetEntity("UsrCompany") as Account);
			}
		}

		/// <summary>
		/// Адрес доставки.
		/// </summary>
		public string UsrDeliveryAddress {
			get {
				return GetTypedColumnValue<string>("UsrDeliveryAddress");
			}
			set {
				SetColumnValue("UsrDeliveryAddress", value);
			}
		}

		/// <exclude/>
		public Guid UsrCarId {
			get {
				return GetTypedColumnValue<Guid>("UsrCarId");
			}
			set {
				SetColumnValue("UsrCarId", value);
				_usrCar = null;
			}
		}

		private UsrCarPark _usrCar;
		/// <summary>
		/// Автомобиль.
		/// </summary>
		public UsrCarPark UsrCar {
			get {
				return _usrCar ??
					(_usrCar = LookupColumnEntities.GetEntity("UsrCar") as UsrCarPark);
			}
		}

		/// <exclude/>
		public Guid UsrStatusId {
			get {
				return GetTypedColumnValue<Guid>("UsrStatusId");
			}
			set {
				SetColumnValue("UsrStatusId", value);
				_usrStatus = null;
			}
		}

		private UsrTransportRequestsStatus _usrStatus;
		/// <summary>
		/// Статус.
		/// </summary>
		public UsrTransportRequestsStatus UsrStatus {
			get {
				return _usrStatus ??
					(_usrStatus = LookupColumnEntities.GetEntity("UsrStatus") as UsrTransportRequestsStatus);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new UsrTransportRequests_UsrHomeWorkEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new UsrTransportRequests(this);
		}

		#endregion

	}

	#endregion

	#region Class: UsrTransportRequests_UsrHomeWorkEventsProcess

	/// <exclude/>
	public partial class UsrTransportRequests_UsrHomeWorkEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : UsrTransportRequests
	{

		public UsrTransportRequests_UsrHomeWorkEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "UsrTransportRequests_UsrHomeWorkEventsProcess";
			SchemaUId = new Guid("ce3557cf-4e38-45eb-aa71-502879d15cd5");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("ce3557cf-4e38-45eb-aa71-502879d15cd5");
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

	#region Class: UsrTransportRequests_UsrHomeWorkEventsProcess

	/// <exclude/>
	public class UsrTransportRequests_UsrHomeWorkEventsProcess : UsrTransportRequests_UsrHomeWorkEventsProcess<UsrTransportRequests>
	{

		public UsrTransportRequests_UsrHomeWorkEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: UsrTransportRequests_UsrHomeWorkEventsProcess

	public partial class UsrTransportRequests_UsrHomeWorkEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: UsrTransportRequestsEventsProcess

	/// <exclude/>
	public class UsrTransportRequestsEventsProcess : UsrTransportRequests_UsrHomeWorkEventsProcess
	{

		public UsrTransportRequestsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

