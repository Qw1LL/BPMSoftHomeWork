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

	#region Class: ActivitySynchronizerSchema

	/// <exclude/>
	public class ActivitySynchronizerSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public ActivitySynchronizerSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ActivitySynchronizerSchema(ActivitySynchronizerSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ActivitySynchronizerSchema(ActivitySynchronizerSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateIaElblbnPOxb5ngQCIlfFqI0r4Index() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = true,
				IsClustered = false,
				IsUnique = true
			};
			index.UId = new Guid("eccdad90-206e-4be6-8796-8013e7f1dc39");
			index.Name = "IaElblbnPOxb5ngQCIlfFqI0r4";
			index.CreatedInSchemaUId = new Guid("21d4fdb0-73be-4b9c-9e4d-0346bcc03350");
			index.ModifiedInSchemaUId = new Guid("21d4fdb0-73be-4b9c-9e4d-0346bcc03350");
			index.CreatedInPackageId = new Guid("405cd56e-8293-41da-83e9-a9cf9867a065");
			EntitySchemaIndexColumn remoteUIdIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("f3144e77-c433-4b82-be09-8118b9f8f2e3"),
				ColumnUId = new Guid("74ac343b-6329-49fc-8fa0-50fac3d30eb9"),
				CreatedInSchemaUId = new Guid("21d4fdb0-73be-4b9c-9e4d-0346bcc03350"),
				ModifiedInSchemaUId = new Guid("21d4fdb0-73be-4b9c-9e4d-0346bcc03350"),
				CreatedInPackageId = new Guid("405cd56e-8293-41da-83e9-a9cf9867a065"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(remoteUIdIndexColumn);
			return index;
		}

		private EntitySchemaIndex CreateIb02z7oc9BCVYIL05HSShF5cxAj8Index() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = true,
				IsClustered = false,
				IsUnique = true
			};
			index.UId = new Guid("f3a67eb0-8a3a-426f-9b8a-5ff7019d09bb");
			index.Name = "Ib02z7oc9BCVYIL05HSShF5cxAj8";
			index.CreatedInSchemaUId = new Guid("21d4fdb0-73be-4b9c-9e4d-0346bcc03350");
			index.ModifiedInSchemaUId = new Guid("21d4fdb0-73be-4b9c-9e4d-0346bcc03350");
			index.CreatedInPackageId = new Guid("405cd56e-8293-41da-83e9-a9cf9867a065");
			EntitySchemaIndexColumn activityIdIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("543e1db3-ef3a-4fcd-928b-0d7aff4c9fd1"),
				ColumnUId = new Guid("ac997a7f-8f71-4623-97f3-e5ec80d0d086"),
				CreatedInSchemaUId = new Guid("21d4fdb0-73be-4b9c-9e4d-0346bcc03350"),
				ModifiedInSchemaUId = new Guid("21d4fdb0-73be-4b9c-9e4d-0346bcc03350"),
				CreatedInPackageId = new Guid("405cd56e-8293-41da-83e9-a9cf9867a065"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(activityIdIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("21d4fdb0-73be-4b9c-9e4d-0346bcc03350");
			RealUId = new Guid("21d4fdb0-73be-4b9c-9e4d-0346bcc03350");
			Name = "ActivitySynchronizer";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("6023cd5f-07e6-4da1-8a0a-c8af04ad316d");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("74ac343b-6329-49fc-8fa0-50fac3d30eb9")) == null) {
				Columns.Add(CreateRemoteUIdColumn());
			}
			if (Columns.FindByUId(new Guid("ac997a7f-8f71-4623-97f3-e5ec80d0d086")) == null) {
				Columns.Add(CreateActivityIdColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateRemoteUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("74ac343b-6329-49fc-8fa0-50fac3d30eb9"),
				Name = @"RemoteUId",
				CreatedInSchemaUId = new Guid("21d4fdb0-73be-4b9c-9e4d-0346bcc03350"),
				ModifiedInSchemaUId = new Guid("21d4fdb0-73be-4b9c-9e4d-0346bcc03350"),
				CreatedInPackageId = new Guid("405cd56e-8293-41da-83e9-a9cf9867a065")
			};
		}

		protected virtual EntitySchemaColumn CreateActivityIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("ac997a7f-8f71-4623-97f3-e5ec80d0d086"),
				Name = @"ActivityId",
				CreatedInSchemaUId = new Guid("21d4fdb0-73be-4b9c-9e4d-0346bcc03350"),
				ModifiedInSchemaUId = new Guid("21d4fdb0-73be-4b9c-9e4d-0346bcc03350"),
				CreatedInPackageId = new Guid("405cd56e-8293-41da-83e9-a9cf9867a065")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateIaElblbnPOxb5ngQCIlfFqI0r4Index());
			Indexes.Add(CreateIb02z7oc9BCVYIL05HSShF5cxAj8Index());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ActivitySynchronizer(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ActivitySynchronizer_ExchangeEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ActivitySynchronizerSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ActivitySynchronizerSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("21d4fdb0-73be-4b9c-9e4d-0346bcc03350"));
		}

		#endregion

	}

	#endregion

	#region Class: ActivitySynchronizer

	/// <summary>
	/// Activity synchronizer.
	/// </summary>
	public class ActivitySynchronizer : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public ActivitySynchronizer(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ActivitySynchronizer";
		}

		public ActivitySynchronizer(ActivitySynchronizer source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// RemoteUId.
		/// </summary>
		public string RemoteUId {
			get {
				return GetTypedColumnValue<string>("RemoteUId");
			}
			set {
				SetColumnValue("RemoteUId", value);
			}
		}

		/// <summary>
		/// ActivityID.
		/// </summary>
		public Guid ActivityId {
			get {
				return GetTypedColumnValue<Guid>("ActivityId");
			}
			set {
				SetColumnValue("ActivityId", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ActivitySynchronizer_ExchangeEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ActivitySynchronizerDeleted", e);
			Validating += (s, e) => ThrowEvent("ActivitySynchronizerValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ActivitySynchronizer(this);
		}

		#endregion

	}

	#endregion

	#region Class: ActivitySynchronizer_ExchangeEventsProcess

	/// <exclude/>
	public partial class ActivitySynchronizer_ExchangeEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : ActivitySynchronizer
	{

		public ActivitySynchronizer_ExchangeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ActivitySynchronizer_ExchangeEventsProcess";
			SchemaUId = new Guid("21d4fdb0-73be-4b9c-9e4d-0346bcc03350");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("21d4fdb0-73be-4b9c-9e4d-0346bcc03350");
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

	#region Class: ActivitySynchronizer_ExchangeEventsProcess

	/// <exclude/>
	public class ActivitySynchronizer_ExchangeEventsProcess : ActivitySynchronizer_ExchangeEventsProcess<ActivitySynchronizer>
	{

		public ActivitySynchronizer_ExchangeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ActivitySynchronizer_ExchangeEventsProcess

	public partial class ActivitySynchronizer_ExchangeEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ActivitySynchronizerEventsProcess

	/// <exclude/>
	public class ActivitySynchronizerEventsProcess : ActivitySynchronizer_ExchangeEventsProcess
	{

		public ActivitySynchronizerEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

