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

	#region Class: Country_Base_BPMSoftSchema

	/// <exclude/>
	public class Country_Base_BPMSoftSchema : BPMSoft.Configuration.BaseImageLookupSchema
	{

		#region Constructors: Public

		public Country_Base_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public Country_Base_BPMSoftSchema(Country_Base_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public Country_Base_BPMSoftSchema(Country_Base_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("09fce1f8-515c-4296-95cd-8cd93f79a6cf");
			RealUId = new Guid("09fce1f8-515c-4296-95cd-8cd93f79a6cf");
			Name = "Country_Base_BPMSoft";
			ParentSchemaUId = new Guid("b4a781bd-bacd-4ba1-a16b-48c09a21f087");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("6c43eac6-1530-4d3a-8839-89cb19d5484a")) == null) {
				Columns.Add(CreateBillingInfoColumn());
			}
			if (Columns.FindByUId(new Guid("e16e6308-60ea-41af-b4d4-f4ada1bebd65")) == null) {
				Columns.Add(CreateTimeZoneColumn());
			}
			if (Columns.FindByUId(new Guid("054bc9b2-8fd8-4ef0-a40b-822d2fb6397c")) == null) {
				Columns.Add(CreateCodeColumn());
			}
			if (Columns.FindByUId(new Guid("362cada0-5f1a-ac1b-f69e-94551ead4b37")) == null) {
				Columns.Add(CreateAlpha2CodeColumn());
			}
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("09fce1f8-515c-4296-95cd-8cd93f79a6cf");
			column.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("09fce1f8-515c-4296-95cd-8cd93f79a6cf");
			column.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			return column;
		}

		protected override EntitySchemaColumn CreateImageColumn() {
			EntitySchemaColumn column = base.CreateImageColumn();
			column.ModifiedInSchemaUId = new Guid("09fce1f8-515c-4296-95cd-8cd93f79a6cf");
			column.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			return column;
		}

		protected virtual EntitySchemaColumn CreateBillingInfoColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("6c43eac6-1530-4d3a-8839-89cb19d5484a"),
				Name = @"BillingInfo",
				CreatedInSchemaUId = new Guid("09fce1f8-515c-4296-95cd-8cd93f79a6cf"),
				ModifiedInSchemaUId = new Guid("09fce1f8-515c-4296-95cd-8cd93f79a6cf"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateTimeZoneColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("e16e6308-60ea-41af-b4d4-f4ada1bebd65"),
				Name = @"TimeZone",
				ReferenceSchemaUId = new Guid("a394a569-92d6-44d0-bdda-fa0578373b4f"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("09fce1f8-515c-4296-95cd-8cd93f79a6cf"),
				ModifiedInSchemaUId = new Guid("09fce1f8-515c-4296-95cd-8cd93f79a6cf"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateCodeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("054bc9b2-8fd8-4ef0-a40b-822d2fb6397c"),
				Name = @"Code",
				CreatedInSchemaUId = new Guid("09fce1f8-515c-4296-95cd-8cd93f79a6cf"),
				ModifiedInSchemaUId = new Guid("09fce1f8-515c-4296-95cd-8cd93f79a6cf"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateAlpha2CodeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("362cada0-5f1a-ac1b-f69e-94551ead4b37"),
				Name = @"Alpha2Code",
				CreatedInSchemaUId = new Guid("09fce1f8-515c-4296-95cd-8cd93f79a6cf"),
				ModifiedInSchemaUId = new Guid("09fce1f8-515c-4296-95cd-8cd93f79a6cf"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new Country_Base_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Country_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new Country_Base_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new Country_Base_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("09fce1f8-515c-4296-95cd-8cd93f79a6cf"));
		}

		#endregion

	}

	#endregion

	#region Class: Country_Base_BPMSoft

	/// <summary>
	/// Country.
	/// </summary>
	public class Country_Base_BPMSoft : BPMSoft.Configuration.BaseImageLookup
	{

		#region Constructors: Public

		public Country_Base_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Country_Base_BPMSoft";
		}

		public Country_Base_BPMSoft(Country_Base_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Banking details.
		/// </summary>
		public string BillingInfo {
			get {
				return GetTypedColumnValue<string>("BillingInfo");
			}
			set {
				SetColumnValue("BillingInfo", value);
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
		/// Time zone.
		/// </summary>
		public TimeZone TimeZone {
			get {
				return _timeZone ??
					(_timeZone = LookupColumnEntities.GetEntity("TimeZone") as TimeZone);
			}
		}

		/// <summary>
		/// Country code.
		/// </summary>
		public string Code {
			get {
				return GetTypedColumnValue<string>("Code");
			}
			set {
				SetColumnValue("Code", value);
			}
		}

		/// <summary>
		/// Two-letter country code.
		/// </summary>
		/// <remarks>
		/// ISO 3166-1 alpha-2.
		/// </remarks>
		public string Alpha2Code {
			get {
				return GetTypedColumnValue<string>("Alpha2Code");
			}
			set {
				SetColumnValue("Alpha2Code", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Country_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("Country_Base_BPMSoftDeleted", e);
			Deleting += (s, e) => ThrowEvent("Country_Base_BPMSoftDeleting", e);
			Inserted += (s, e) => ThrowEvent("Country_Base_BPMSoftInserted", e);
			Inserting += (s, e) => ThrowEvent("Country_Base_BPMSoftInserting", e);
			Saved += (s, e) => ThrowEvent("Country_Base_BPMSoftSaved", e);
			Saving += (s, e) => ThrowEvent("Country_Base_BPMSoftSaving", e);
			Validating += (s, e) => ThrowEvent("Country_Base_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new Country_Base_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: Country_BaseEventsProcess

	/// <exclude/>
	public partial class Country_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseImageLookup_BaseEventsProcess<TEntity> where TEntity : Country_Base_BPMSoft
	{

		public Country_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Country_BaseEventsProcess";
			SchemaUId = new Guid("09fce1f8-515c-4296-95cd-8cd93f79a6cf");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("09fce1f8-515c-4296-95cd-8cd93f79a6cf");
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

	#region Class: Country_BaseEventsProcess

	/// <exclude/>
	public class Country_BaseEventsProcess : Country_BaseEventsProcess<Country_Base_BPMSoft>
	{

		public Country_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: Country_BaseEventsProcess

	public partial class Country_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

