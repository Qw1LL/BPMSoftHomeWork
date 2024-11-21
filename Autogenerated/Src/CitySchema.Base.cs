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

	#region Class: City_Base_BPMSoftSchema

	/// <exclude/>
	public class City_Base_BPMSoftSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public City_Base_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public City_Base_BPMSoftSchema(City_Base_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public City_Base_BPMSoftSchema(City_Base_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("5ca90b6a-93e7-4448-befe-ab5166ec2cfe");
			RealUId = new Guid("5ca90b6a-93e7-4448-befe-ab5166ec2cfe");
			Name = "City_Base_BPMSoft";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("8fb75ea2-14b8-4bb1-8420-f3a650b11962")) == null) {
				Columns.Add(CreateCountryColumn());
			}
			if (Columns.FindByUId(new Guid("b9be9a1a-dc05-4574-b391-b8377b8f82f8")) == null) {
				Columns.Add(CreateRegionColumn());
			}
			if (Columns.FindByUId(new Guid("8ff41b5d-ef8e-4f95-bc96-07b5d595a3eb")) == null) {
				Columns.Add(CreateTimeZoneColumn());
			}
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("5ca90b6a-93e7-4448-befe-ab5166ec2cfe");
			column.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("5ca90b6a-93e7-4448-befe-ab5166ec2cfe");
			column.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			return column;
		}

		protected virtual EntitySchemaColumn CreateCountryColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("8fb75ea2-14b8-4bb1-8420-f3a650b11962"),
				Name = @"Country",
				ReferenceSchemaUId = new Guid("09fce1f8-515c-4296-95cd-8cd93f79a6cf"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("5ca90b6a-93e7-4448-befe-ab5166ec2cfe"),
				ModifiedInSchemaUId = new Guid("5ca90b6a-93e7-4448-befe-ab5166ec2cfe"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateRegionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("b9be9a1a-dc05-4574-b391-b8377b8f82f8"),
				Name = @"Region",
				ReferenceSchemaUId = new Guid("fa4eb497-e6a3-4f8c-8568-5df4bd2a8b91"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("5ca90b6a-93e7-4448-befe-ab5166ec2cfe"),
				ModifiedInSchemaUId = new Guid("5ca90b6a-93e7-4448-befe-ab5166ec2cfe"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateTimeZoneColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("8ff41b5d-ef8e-4f95-bc96-07b5d595a3eb"),
				Name = @"TimeZone",
				ReferenceSchemaUId = new Guid("a394a569-92d6-44d0-bdda-fa0578373b4f"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("5ca90b6a-93e7-4448-befe-ab5166ec2cfe"),
				ModifiedInSchemaUId = new Guid("5ca90b6a-93e7-4448-befe-ab5166ec2cfe"),
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
			return new City_Base_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new City_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new City_Base_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new City_Base_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("5ca90b6a-93e7-4448-befe-ab5166ec2cfe"));
		}

		#endregion

	}

	#endregion

	#region Class: City_Base_BPMSoft

	/// <summary>
	/// Город.
	/// </summary>
	public class City_Base_BPMSoft : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public City_Base_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "City_Base_BPMSoft";
		}

		public City_Base_BPMSoft(City_Base_BPMSoft source)
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
		/// Область.
		/// </summary>
		public Region Region {
			get {
				return _region ??
					(_region = LookupColumnEntities.GetEntity("Region") as Region);
			}
		}

		/// <exclude/>
		public Guid TimeZoneId {
			get {
				return GetTypedColumnValue<Guid>("TimeZoneId");
			}
			set {
				SetColumnValue("TimeZoneId", value);
				_timeZone = null;
			}
		}

		/// <exclude/>
		public string TimeZoneName {
			get {
				return GetTypedColumnValue<string>("TimeZoneName");
			}
			set {
				SetColumnValue("TimeZoneName", value);
				if (_timeZone != null) {
					_timeZone.Name = value;
				}
			}
		}

		private TimeZone _timeZone;
		/// <summary>
		/// Часовой пояс.
		/// </summary>
		public TimeZone TimeZone {
			get {
				return _timeZone ??
					(_timeZone = LookupColumnEntities.GetEntity("TimeZone") as TimeZone);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new City_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("City_Base_BPMSoftDeleted", e);
			Deleting += (s, e) => ThrowEvent("City_Base_BPMSoftDeleting", e);
			Inserted += (s, e) => ThrowEvent("City_Base_BPMSoftInserted", e);
			Inserting += (s, e) => ThrowEvent("City_Base_BPMSoftInserting", e);
			Saved += (s, e) => ThrowEvent("City_Base_BPMSoftSaved", e);
			Saving += (s, e) => ThrowEvent("City_Base_BPMSoftSaving", e);
			Validating += (s, e) => ThrowEvent("City_Base_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new City_Base_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: City_BaseEventsProcess

	/// <exclude/>
	public partial class City_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : City_Base_BPMSoft
	{

		public City_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "City_BaseEventsProcess";
			SchemaUId = new Guid("5ca90b6a-93e7-4448-befe-ab5166ec2cfe");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("5ca90b6a-93e7-4448-befe-ab5166ec2cfe");
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

	#region Class: City_BaseEventsProcess

	/// <exclude/>
	public class City_BaseEventsProcess : City_BaseEventsProcess<City_Base_BPMSoft>
	{

		public City_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: City_BaseEventsProcess

	public partial class City_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		public override void CheckCanManageLookups() {
		}

		#endregion

	}

	#endregion

}

