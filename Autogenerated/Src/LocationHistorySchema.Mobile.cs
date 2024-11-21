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

	#region Class: LocationHistorySchema

	/// <exclude/>
	public class LocationHistorySchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public LocationHistorySchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public LocationHistorySchema(LocationHistorySchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public LocationHistorySchema(LocationHistorySchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("bba63d30-4b4c-4ea9-ba86-9471539c412e");
			RealUId = new Guid("bba63d30-4b4c-4ea9-ba86-9471539c412e");
			Name = "LocationHistory";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("8392ee26-2372-47a0-881e-d5bd71fa247e");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateLongitudeColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("0bdd32ce-2a40-4d1b-b550-961462870281")) == null) {
				Columns.Add(CreateDateColumn());
			}
			if (Columns.FindByUId(new Guid("c4e708df-a366-4c33-b4f9-7a6e48721271")) == null) {
				Columns.Add(CreateLatitudeColumn());
			}
			if (Columns.FindByUId(new Guid("c48b7efc-759a-4c02-a096-5c21b2f9149a")) == null) {
				Columns.Add(CreateIsApproximateColumn());
			}
			if (Columns.FindByUId(new Guid("2b96bf18-ea4a-4a0d-bbdd-230d4b2b334d")) == null) {
				Columns.Add(CreateContactColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("0bdd32ce-2a40-4d1b-b550-961462870281"),
				Name = @"Date",
				CreatedInSchemaUId = new Guid("bba63d30-4b4c-4ea9-ba86-9471539c412e"),
				ModifiedInSchemaUId = new Guid("bba63d30-4b4c-4ea9-ba86-9471539c412e"),
				CreatedInPackageId = new Guid("8392ee26-2372-47a0-881e-d5bd71fa247e")
			};
		}

		protected virtual EntitySchemaColumn CreateLongitudeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("b5387ae7-874c-418a-9758-e7de5036e228"),
				Name = @"Longitude",
				CreatedInSchemaUId = new Guid("bba63d30-4b4c-4ea9-ba86-9471539c412e"),
				ModifiedInSchemaUId = new Guid("bba63d30-4b4c-4ea9-ba86-9471539c412e"),
				CreatedInPackageId = new Guid("8392ee26-2372-47a0-881e-d5bd71fa247e")
			};
		}

		protected virtual EntitySchemaColumn CreateLatitudeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("c4e708df-a366-4c33-b4f9-7a6e48721271"),
				Name = @"Latitude",
				CreatedInSchemaUId = new Guid("bba63d30-4b4c-4ea9-ba86-9471539c412e"),
				ModifiedInSchemaUId = new Guid("bba63d30-4b4c-4ea9-ba86-9471539c412e"),
				CreatedInPackageId = new Guid("8392ee26-2372-47a0-881e-d5bd71fa247e")
			};
		}

		protected virtual EntitySchemaColumn CreateIsApproximateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("c48b7efc-759a-4c02-a096-5c21b2f9149a"),
				Name = @"IsApproximate",
				CreatedInSchemaUId = new Guid("bba63d30-4b4c-4ea9-ba86-9471539c412e"),
				ModifiedInSchemaUId = new Guid("bba63d30-4b4c-4ea9-ba86-9471539c412e"),
				CreatedInPackageId = new Guid("8392ee26-2372-47a0-881e-d5bd71fa247e")
			};
		}

		protected virtual EntitySchemaColumn CreateContactColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("2b96bf18-ea4a-4a0d-bbdd-230d4b2b334d"),
				Name = @"Contact",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("bba63d30-4b4c-4ea9-ba86-9471539c412e"),
				ModifiedInSchemaUId = new Guid("bba63d30-4b4c-4ea9-ba86-9471539c412e"),
				CreatedInPackageId = new Guid("8392ee26-2372-47a0-881e-d5bd71fa247e"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.SystemValue,
					ValueSource = SystemValueManager.GetInstanceByName(@"CurrentUserContact")
				}
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new LocationHistory(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new LocationHistory_MobileEventsProcess(userConnection);
		}

		public override object Clone() {
			return new LocationHistorySchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new LocationHistorySchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("bba63d30-4b4c-4ea9-ba86-9471539c412e"));
		}

		#endregion

	}

	#endregion

	#region Class: LocationHistory

	/// <summary>
	/// История местоположения пользователей.
	/// </summary>
	public class LocationHistory : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public LocationHistory(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "LocationHistory";
		}

		public LocationHistory(LocationHistory source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Дата.
		/// </summary>
		public DateTime Date {
			get {
				return GetTypedColumnValue<DateTime>("Date");
			}
			set {
				SetColumnValue("Date", value);
			}
		}

		/// <summary>
		/// Долгота.
		/// </summary>
		public string Longitude {
			get {
				return GetTypedColumnValue<string>("Longitude");
			}
			set {
				SetColumnValue("Longitude", value);
			}
		}

		/// <summary>
		/// Широта.
		/// </summary>
		public string Latitude {
			get {
				return GetTypedColumnValue<string>("Latitude");
			}
			set {
				SetColumnValue("Latitude", value);
			}
		}

		/// <summary>
		/// Приблизительные координаты.
		/// </summary>
		public bool IsApproximate {
			get {
				return GetTypedColumnValue<bool>("IsApproximate");
			}
			set {
				SetColumnValue("IsApproximate", value);
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

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new LocationHistory_MobileEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("LocationHistoryDeleted", e);
			Validating += (s, e) => ThrowEvent("LocationHistoryValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new LocationHistory(this);
		}

		#endregion

	}

	#endregion

	#region Class: LocationHistory_MobileEventsProcess

	/// <exclude/>
	public partial class LocationHistory_MobileEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : LocationHistory
	{

		public LocationHistory_MobileEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "LocationHistory_MobileEventsProcess";
			SchemaUId = new Guid("bba63d30-4b4c-4ea9-ba86-9471539c412e");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("bba63d30-4b4c-4ea9-ba86-9471539c412e");
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

	#region Class: LocationHistory_MobileEventsProcess

	/// <exclude/>
	public class LocationHistory_MobileEventsProcess : LocationHistory_MobileEventsProcess<LocationHistory>
	{

		public LocationHistory_MobileEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: LocationHistory_MobileEventsProcess

	public partial class LocationHistory_MobileEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: LocationHistoryEventsProcess

	/// <exclude/>
	public class LocationHistoryEventsProcess : LocationHistory_MobileEventsProcess
	{

		public LocationHistoryEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

