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

	#region Class: Region_Base_BPMSoftSchema

	/// <exclude/>
	public class Region_Base_BPMSoftSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public Region_Base_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public Region_Base_BPMSoftSchema(Region_Base_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public Region_Base_BPMSoftSchema(Region_Base_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("fa4eb497-e6a3-4f8c-8568-5df4bd2a8b91");
			RealUId = new Guid("fa4eb497-e6a3-4f8c-8568-5df4bd2a8b91");
			Name = "Region_Base_BPMSoft";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("8469bcc6-3a77-4706-85a9-72a2ec3aa2f5")) == null) {
				Columns.Add(CreateCountryColumn());
			}
			if (Columns.FindByUId(new Guid("5975a90a-0b6c-4216-b195-a02208e83b3c")) == null) {
				Columns.Add(CreateTimeZoneColumn());
			}
			if (Columns.FindByUId(new Guid("dbf90876-69ce-f0a1-9d8d-f1cdfcd6d71a")) == null) {
				Columns.Add(CreateCodeColumn());
			}
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("fa4eb497-e6a3-4f8c-8568-5df4bd2a8b91");
			column.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("fa4eb497-e6a3-4f8c-8568-5df4bd2a8b91");
			column.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			return column;
		}

		protected virtual EntitySchemaColumn CreateCountryColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("8469bcc6-3a77-4706-85a9-72a2ec3aa2f5"),
				Name = @"Country",
				ReferenceSchemaUId = new Guid("09fce1f8-515c-4296-95cd-8cd93f79a6cf"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("fa4eb497-e6a3-4f8c-8568-5df4bd2a8b91"),
				ModifiedInSchemaUId = new Guid("fa4eb497-e6a3-4f8c-8568-5df4bd2a8b91"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateTimeZoneColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("5975a90a-0b6c-4216-b195-a02208e83b3c"),
				Name = @"TimeZone",
				ReferenceSchemaUId = new Guid("a394a569-92d6-44d0-bdda-fa0578373b4f"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("fa4eb497-e6a3-4f8c-8568-5df4bd2a8b91"),
				ModifiedInSchemaUId = new Guid("fa4eb497-e6a3-4f8c-8568-5df4bd2a8b91"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateCodeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("dbf90876-69ce-f0a1-9d8d-f1cdfcd6d71a"),
				Name = @"Code",
				CreatedInSchemaUId = new Guid("fa4eb497-e6a3-4f8c-8568-5df4bd2a8b91"),
				ModifiedInSchemaUId = new Guid("fa4eb497-e6a3-4f8c-8568-5df4bd2a8b91"),
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
			return new Region_Base_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Region_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new Region_Base_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new Region_Base_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("fa4eb497-e6a3-4f8c-8568-5df4bd2a8b91"));
		}

		#endregion

	}

	#endregion

	#region Class: Region_Base_BPMSoft

	/// <summary>
	/// Области.
	/// </summary>
	public class Region_Base_BPMSoft : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public Region_Base_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Region_Base_BPMSoft";
		}

		public Region_Base_BPMSoft(Region_Base_BPMSoft source)
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

		/// <summary>
		/// Код региона.
		/// </summary>
		public string Code {
			get {
				return GetTypedColumnValue<string>("Code");
			}
			set {
				SetColumnValue("Code", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Region_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("Region_Base_BPMSoftDeleted", e);
			Deleting += (s, e) => ThrowEvent("Region_Base_BPMSoftDeleting", e);
			Inserted += (s, e) => ThrowEvent("Region_Base_BPMSoftInserted", e);
			Inserting += (s, e) => ThrowEvent("Region_Base_BPMSoftInserting", e);
			Saved += (s, e) => ThrowEvent("Region_Base_BPMSoftSaved", e);
			Saving += (s, e) => ThrowEvent("Region_Base_BPMSoftSaving", e);
			Validating += (s, e) => ThrowEvent("Region_Base_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new Region_Base_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: Region_BaseEventsProcess

	/// <exclude/>
	public partial class Region_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : Region_Base_BPMSoft
	{

		public Region_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Region_BaseEventsProcess";
			SchemaUId = new Guid("fa4eb497-e6a3-4f8c-8568-5df4bd2a8b91");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("fa4eb497-e6a3-4f8c-8568-5df4bd2a8b91");
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

	#region Class: Region_BaseEventsProcess

	/// <exclude/>
	public class Region_BaseEventsProcess : Region_BaseEventsProcess<Region_Base_BPMSoft>
	{

		public Region_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: Region_BaseEventsProcess

	public partial class Region_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

