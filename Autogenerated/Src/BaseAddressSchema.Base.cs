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

	#region Class: BaseAddressSchema

	/// <exclude/>
	[IsVirtual]
	public class BaseAddressSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public BaseAddressSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public BaseAddressSchema(BaseAddressSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public BaseAddressSchema(BaseAddressSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("400e8687-9616-480d-9d81-61de0235cc86");
			RealUId = new Guid("400e8687-9616-480d-9d81-61de0235cc86");
			Name = "BaseAddress";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("db905f37-5dcd-43e7-a4d6-d53683cb20db")) == null) {
				Columns.Add(CreateAddressTypeColumn());
			}
			if (Columns.FindByUId(new Guid("06b6aac2-bf8f-4159-9c31-ae7a8dc59d7a")) == null) {
				Columns.Add(CreateCountryColumn());
			}
			if (Columns.FindByUId(new Guid("c8419fd0-f489-4d84-8966-c3f74d40d954")) == null) {
				Columns.Add(CreateRegionColumn());
			}
			if (Columns.FindByUId(new Guid("1435cdfb-4112-4eb4-b069-8092de017667")) == null) {
				Columns.Add(CreateCityColumn());
			}
			if (Columns.FindByUId(new Guid("6e1859b8-5a53-4537-b1fe-f7ae8cb41564")) == null) {
				Columns.Add(CreateAddressColumn());
			}
			if (Columns.FindByUId(new Guid("7c61072c-ba24-4ab3-812a-63741a3eb046")) == null) {
				Columns.Add(CreateZipColumn());
			}
			if (Columns.FindByUId(new Guid("d11dacab-b03d-4a27-b6ab-904dcdb79cd9")) == null) {
				Columns.Add(CreatePrimaryColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateAddressTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("db905f37-5dcd-43e7-a4d6-d53683cb20db"),
				Name = @"AddressType",
				ReferenceSchemaUId = new Guid("50837bfc-43ff-466b-94bb-de0847eecd1b"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("400e8687-9616-480d-9d81-61de0235cc86"),
				ModifiedInSchemaUId = new Guid("400e8687-9616-480d-9d81-61de0235cc86"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				IsSimpleLookup = true
			};
		}

		protected virtual EntitySchemaColumn CreateCountryColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("06b6aac2-bf8f-4159-9c31-ae7a8dc59d7a"),
				Name = @"Country",
				ReferenceSchemaUId = new Guid("09fce1f8-515c-4296-95cd-8cd93f79a6cf"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("400e8687-9616-480d-9d81-61de0235cc86"),
				ModifiedInSchemaUId = new Guid("400e8687-9616-480d-9d81-61de0235cc86"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateRegionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("c8419fd0-f489-4d84-8966-c3f74d40d954"),
				Name = @"Region",
				ReferenceSchemaUId = new Guid("fa4eb497-e6a3-4f8c-8568-5df4bd2a8b91"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("400e8687-9616-480d-9d81-61de0235cc86"),
				ModifiedInSchemaUId = new Guid("400e8687-9616-480d-9d81-61de0235cc86"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateCityColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("1435cdfb-4112-4eb4-b069-8092de017667"),
				Name = @"City",
				ReferenceSchemaUId = new Guid("5ca90b6a-93e7-4448-befe-ab5166ec2cfe"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("400e8687-9616-480d-9d81-61de0235cc86"),
				ModifiedInSchemaUId = new Guid("400e8687-9616-480d-9d81-61de0235cc86"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateAddressColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("6e1859b8-5a53-4537-b1fe-f7ae8cb41564"),
				Name = @"Address",
				CreatedInSchemaUId = new Guid("400e8687-9616-480d-9d81-61de0235cc86"),
				ModifiedInSchemaUId = new Guid("400e8687-9616-480d-9d81-61de0235cc86"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateZipColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("7c61072c-ba24-4ab3-812a-63741a3eb046"),
				Name = @"Zip",
				CreatedInSchemaUId = new Guid("400e8687-9616-480d-9d81-61de0235cc86"),
				ModifiedInSchemaUId = new Guid("400e8687-9616-480d-9d81-61de0235cc86"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreatePrimaryColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("d11dacab-b03d-4a27-b6ab-904dcdb79cd9"),
				Name = @"Primary",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("400e8687-9616-480d-9d81-61de0235cc86"),
				ModifiedInSchemaUId = new Guid("400e8687-9616-480d-9d81-61de0235cc86"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new BaseAddress(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new BaseAddress_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new BaseAddressSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new BaseAddressSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("400e8687-9616-480d-9d81-61de0235cc86"));
		}

		#endregion

	}

	#endregion

	#region Class: BaseAddress

	/// <summary>
	/// Базовый адрес.
	/// </summary>
	public class BaseAddress : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public BaseAddress(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "BaseAddress";
		}

		public BaseAddress(BaseAddress source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid AddressTypeId {
			get {
				return GetTypedColumnValue<Guid>("AddressTypeId");
			}
			set {
				SetColumnValue("AddressTypeId", value);
				_addressType = null;
			}
		}

		/// <exclude/>
		public string AddressTypeName {
			get {
				return GetTypedColumnValue<string>("AddressTypeName");
			}
			set {
				SetColumnValue("AddressTypeName", value);
				if (_addressType != null) {
					_addressType.Name = value;
				}
			}
		}

		private AddressType _addressType;
		/// <summary>
		/// Тип адреса.
		/// </summary>
		public AddressType AddressType {
			get {
				return _addressType ??
					(_addressType = LookupColumnEntities.GetEntity("AddressType") as AddressType);
			}
		}

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
		/// Область.
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
		/// Индекс.
		/// </summary>
		public string Zip {
			get {
				return GetTypedColumnValue<string>("Zip");
			}
			set {
				SetColumnValue("Zip", value);
			}
		}

		/// <summary>
		/// Основной.
		/// </summary>
		public bool Primary {
			get {
				return GetTypedColumnValue<bool>("Primary");
			}
			set {
				SetColumnValue("Primary", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new BaseAddress_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("BaseAddressDeleted", e);
			Deleting += (s, e) => ThrowEvent("BaseAddressDeleting", e);
			Inserted += (s, e) => ThrowEvent("BaseAddressInserted", e);
			Inserting += (s, e) => ThrowEvent("BaseAddressInserting", e);
			Saved += (s, e) => ThrowEvent("BaseAddressSaved", e);
			Saving += (s, e) => ThrowEvent("BaseAddressSaving", e);
			Validating += (s, e) => ThrowEvent("BaseAddressValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new BaseAddress(this);
		}

		#endregion

	}

	#endregion

	#region Class: BaseAddress_BaseEventsProcess

	/// <exclude/>
	public partial class BaseAddress_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : BaseAddress
	{

		public BaseAddress_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "BaseAddress_BaseEventsProcess";
			SchemaUId = new Guid("400e8687-9616-480d-9d81-61de0235cc86");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("400e8687-9616-480d-9d81-61de0235cc86");
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

	#region Class: BaseAddress_BaseEventsProcess

	/// <exclude/>
	public class BaseAddress_BaseEventsProcess : BaseAddress_BaseEventsProcess<BaseAddress>
	{

		public BaseAddress_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: BaseAddress_BaseEventsProcess

	public partial class BaseAddress_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: BaseAddressEventsProcess

	/// <exclude/>
	public class BaseAddressEventsProcess : BaseAddress_BaseEventsProcess
	{

		public BaseAddressEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

