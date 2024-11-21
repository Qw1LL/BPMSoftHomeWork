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

	#region Class: ConfItemAddressSchema

	/// <exclude/>
	public class ConfItemAddressSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public ConfItemAddressSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ConfItemAddressSchema(ConfItemAddressSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ConfItemAddressSchema(ConfItemAddressSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("cb4d75fc-078b-42da-86cb-562d77cd766b");
			RealUId = new Guid("cb4d75fc-078b-42da-86cb-562d77cd766b");
			Name = "ConfItemAddress";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("0a82de9d-1b49-4c10-947c-0386e85def78");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("7a28b6d5-13e2-4d9d-a9a3-bcb9f3113f9f")) == null) {
				Columns.Add(CreateCountryColumn());
			}
			if (Columns.FindByUId(new Guid("3f48bdbd-887c-42ab-880d-0b1d4edb39df")) == null) {
				Columns.Add(CreateRegionColumn());
			}
			if (Columns.FindByUId(new Guid("6f64ca97-b442-400f-a9e4-c3a89ad07ea6")) == null) {
				Columns.Add(CreateCityColumn());
			}
			if (Columns.FindByUId(new Guid("368b36a3-89de-445d-958e-c82f7f127c2c")) == null) {
				Columns.Add(CreateStreetColumn());
			}
			if (Columns.FindByUId(new Guid("caa6a228-5ed7-4034-9c8f-7632fd974262")) == null) {
				Columns.Add(CreateAddressColumn());
			}
			if (Columns.FindByUId(new Guid("855d03b9-55e7-4f10-8cc6-2eaa9f734a3f")) == null) {
				Columns.Add(CreateStartDateColumn());
			}
			if (Columns.FindByUId(new Guid("7331dab4-e7c1-4b63-a32a-7841264b09dd")) == null) {
				Columns.Add(CreateEndDateColumn());
			}
			if (Columns.FindByUId(new Guid("46abb671-bb70-40f7-b9b6-ffea18332db4")) == null) {
				Columns.Add(CreateCurrentColumn());
			}
			if (Columns.FindByUId(new Guid("3aeac796-5d8f-4f3c-bbeb-3462de5fcd4a")) == null) {
				Columns.Add(CreateConfItemColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateCountryColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("7a28b6d5-13e2-4d9d-a9a3-bcb9f3113f9f"),
				Name = @"Country",
				ReferenceSchemaUId = new Guid("09fce1f8-515c-4296-95cd-8cd93f79a6cf"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("cb4d75fc-078b-42da-86cb-562d77cd766b"),
				ModifiedInSchemaUId = new Guid("cb4d75fc-078b-42da-86cb-562d77cd766b"),
				CreatedInPackageId = new Guid("0a82de9d-1b49-4c10-947c-0386e85def78")
			};
		}

		protected virtual EntitySchemaColumn CreateRegionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("3f48bdbd-887c-42ab-880d-0b1d4edb39df"),
				Name = @"Region",
				ReferenceSchemaUId = new Guid("fa4eb497-e6a3-4f8c-8568-5df4bd2a8b91"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("cb4d75fc-078b-42da-86cb-562d77cd766b"),
				ModifiedInSchemaUId = new Guid("cb4d75fc-078b-42da-86cb-562d77cd766b"),
				CreatedInPackageId = new Guid("0a82de9d-1b49-4c10-947c-0386e85def78")
			};
		}

		protected virtual EntitySchemaColumn CreateCityColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("6f64ca97-b442-400f-a9e4-c3a89ad07ea6"),
				Name = @"City",
				ReferenceSchemaUId = new Guid("5ca90b6a-93e7-4448-befe-ab5166ec2cfe"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("cb4d75fc-078b-42da-86cb-562d77cd766b"),
				ModifiedInSchemaUId = new Guid("cb4d75fc-078b-42da-86cb-562d77cd766b"),
				CreatedInPackageId = new Guid("0a82de9d-1b49-4c10-947c-0386e85def78")
			};
		}

		protected virtual EntitySchemaColumn CreateStreetColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("368b36a3-89de-445d-958e-c82f7f127c2c"),
				Name = @"Street",
				CreatedInSchemaUId = new Guid("cb4d75fc-078b-42da-86cb-562d77cd766b"),
				ModifiedInSchemaUId = new Guid("cb4d75fc-078b-42da-86cb-562d77cd766b"),
				CreatedInPackageId = new Guid("0a82de9d-1b49-4c10-947c-0386e85def78")
			};
		}

		protected virtual EntitySchemaColumn CreateAddressColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("caa6a228-5ed7-4034-9c8f-7632fd974262"),
				Name = @"Address",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("cb4d75fc-078b-42da-86cb-562d77cd766b"),
				ModifiedInSchemaUId = new Guid("cb4d75fc-078b-42da-86cb-562d77cd766b"),
				CreatedInPackageId = new Guid("0a82de9d-1b49-4c10-947c-0386e85def78")
			};
		}

		protected virtual EntitySchemaColumn CreateStartDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Date")) {
				UId = new Guid("855d03b9-55e7-4f10-8cc6-2eaa9f734a3f"),
				Name = @"StartDate",
				CreatedInSchemaUId = new Guid("cb4d75fc-078b-42da-86cb-562d77cd766b"),
				ModifiedInSchemaUId = new Guid("cb4d75fc-078b-42da-86cb-562d77cd766b"),
				CreatedInPackageId = new Guid("0a82de9d-1b49-4c10-947c-0386e85def78")
			};
		}

		protected virtual EntitySchemaColumn CreateEndDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Date")) {
				UId = new Guid("7331dab4-e7c1-4b63-a32a-7841264b09dd"),
				Name = @"EndDate",
				CreatedInSchemaUId = new Guid("cb4d75fc-078b-42da-86cb-562d77cd766b"),
				ModifiedInSchemaUId = new Guid("cb4d75fc-078b-42da-86cb-562d77cd766b"),
				CreatedInPackageId = new Guid("0a82de9d-1b49-4c10-947c-0386e85def78")
			};
		}

		protected virtual EntitySchemaColumn CreateCurrentColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("46abb671-bb70-40f7-b9b6-ffea18332db4"),
				Name = @"Current",
				CreatedInSchemaUId = new Guid("cb4d75fc-078b-42da-86cb-562d77cd766b"),
				ModifiedInSchemaUId = new Guid("cb4d75fc-078b-42da-86cb-562d77cd766b"),
				CreatedInPackageId = new Guid("0a82de9d-1b49-4c10-947c-0386e85def78")
			};
		}

		protected virtual EntitySchemaColumn CreateConfItemColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("3aeac796-5d8f-4f3c-bbeb-3462de5fcd4a"),
				Name = @"ConfItem",
				ReferenceSchemaUId = new Guid("ad707075-cf25-40bf-85c1-f5da38cf0d5d"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("cb4d75fc-078b-42da-86cb-562d77cd766b"),
				ModifiedInSchemaUId = new Guid("cb4d75fc-078b-42da-86cb-562d77cd766b"),
				CreatedInPackageId = new Guid("0a82de9d-1b49-4c10-947c-0386e85def78")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ConfItemAddress(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ConfItemAddress_CMDBEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ConfItemAddressSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ConfItemAddressSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("cb4d75fc-078b-42da-86cb-562d77cd766b"));
		}

		#endregion

	}

	#endregion

	#region Class: ConfItemAddress

	/// <summary>
	/// Местоположение конфигурационной единицы.
	/// </summary>
	public class ConfItemAddress : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public ConfItemAddress(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ConfItemAddress";
		}

		public ConfItemAddress(ConfItemAddress source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid CountryId {
			get {
				return GetTypedColumnValue<Guid>("CountryId");
			}
			set {
				SetColumnValue("CountryId", value);
				_country = null;
			}
		}

		/// <exclude/>
		public string CountryName {
			get {
				return GetTypedColumnValue<string>("CountryName");
			}
			set {
				SetColumnValue("CountryName", value);
				if (_country != null) {
					_country.Name = value;
				}
			}
		}

		private Country _country;
		/// <summary>
		/// Страна.
		/// </summary>
		public Country Country {
			get {
				return _country ??
					(_country = LookupColumnEntities.GetEntity("Country") as Country);
			}
		}

		/// <exclude/>
		public Guid RegionId {
			get {
				return GetTypedColumnValue<Guid>("RegionId");
			}
			set {
				SetColumnValue("RegionId", value);
				_region = null;
			}
		}

		/// <exclude/>
		public string RegionName {
			get {
				return GetTypedColumnValue<string>("RegionName");
			}
			set {
				SetColumnValue("RegionName", value);
				if (_region != null) {
					_region.Name = value;
				}
			}
		}

		private Region _region;
		/// <summary>
		/// Регион.
		/// </summary>
		public Region Region {
			get {
				return _region ??
					(_region = LookupColumnEntities.GetEntity("Region") as Region);
			}
		}

		/// <exclude/>
		public Guid CityId {
			get {
				return GetTypedColumnValue<Guid>("CityId");
			}
			set {
				SetColumnValue("CityId", value);
				_city = null;
			}
		}

		/// <exclude/>
		public string CityName {
			get {
				return GetTypedColumnValue<string>("CityName");
			}
			set {
				SetColumnValue("CityName", value);
				if (_city != null) {
					_city.Name = value;
				}
			}
		}

		private City _city;
		/// <summary>
		/// Город.
		/// </summary>
		public City City {
			get {
				return _city ??
					(_city = LookupColumnEntities.GetEntity("City") as City);
			}
		}

		/// <summary>
		/// Улица.
		/// </summary>
		public string Street {
			get {
				return GetTypedColumnValue<string>("Street");
			}
			set {
				SetColumnValue("Street", value);
			}
		}

		/// <summary>
		/// Адрес.
		/// </summary>
		public string Address {
			get {
				return GetTypedColumnValue<string>("Address");
			}
			set {
				SetColumnValue("Address", value);
			}
		}

		/// <summary>
		/// Начало.
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
		/// Окончание.
		/// </summary>
		public DateTime EndDate {
			get {
				return GetTypedColumnValue<DateTime>("EndDate");
			}
			set {
				SetColumnValue("EndDate", value);
			}
		}

		/// <summary>
		/// Текущее.
		/// </summary>
		public bool Current {
			get {
				return GetTypedColumnValue<bool>("Current");
			}
			set {
				SetColumnValue("Current", value);
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

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ConfItemAddress_CMDBEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ConfItemAddressDeleted", e);
			Validating += (s, e) => ThrowEvent("ConfItemAddressValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ConfItemAddress(this);
		}

		#endregion

	}

	#endregion

	#region Class: ConfItemAddress_CMDBEventsProcess

	/// <exclude/>
	public partial class ConfItemAddress_CMDBEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : ConfItemAddress
	{

		public ConfItemAddress_CMDBEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ConfItemAddress_CMDBEventsProcess";
			SchemaUId = new Guid("cb4d75fc-078b-42da-86cb-562d77cd766b");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("cb4d75fc-078b-42da-86cb-562d77cd766b");
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

	#region Class: ConfItemAddress_CMDBEventsProcess

	/// <exclude/>
	public class ConfItemAddress_CMDBEventsProcess : ConfItemAddress_CMDBEventsProcess<ConfItemAddress>
	{

		public ConfItemAddress_CMDBEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ConfItemAddress_CMDBEventsProcess

	public partial class ConfItemAddress_CMDBEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ConfItemAddressEventsProcess

	/// <exclude/>
	public class ConfItemAddressEventsProcess : ConfItemAddress_CMDBEventsProcess
	{

		public ConfItemAddressEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

