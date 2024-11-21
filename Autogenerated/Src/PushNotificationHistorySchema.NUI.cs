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

	#region Class: PushNotificationHistorySchema

	/// <exclude/>
	public class PushNotificationHistorySchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public PushNotificationHistorySchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public PushNotificationHistorySchema(PushNotificationHistorySchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public PushNotificationHistorySchema(PushNotificationHistorySchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateIiCTh7tPwzoqw1CzkEjt5W7sO3bEIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = true,
				IsClustered = false,
				IsUnique = false
			};
			index.UId = new Guid("277c1ae8-3bad-4fd5-90da-9b544cc932bf");
			index.Name = "IiCTh7tPwzoqw1CzkEjt5W7sO3bE";
			index.CreatedInSchemaUId = new Guid("c8961918-65b6-427a-af9f-a979d47fc37d");
			index.ModifiedInSchemaUId = new Guid("c8961918-65b6-427a-af9f-a979d47fc37d");
			index.CreatedInPackageId = new Guid("6ba26f98-9709-4408-98d0-761f0c4bf2aa");
			EntitySchemaIndexColumn messageIdIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("830095b4-5c61-4c0f-ad9d-5327b57271f3"),
				ColumnUId = new Guid("d38f5bbd-445b-4e2f-aa9a-725b17654c7a"),
				CreatedInSchemaUId = new Guid("c8961918-65b6-427a-af9f-a979d47fc37d"),
				ModifiedInSchemaUId = new Guid("c8961918-65b6-427a-af9f-a979d47fc37d"),
				CreatedInPackageId = new Guid("6ba26f98-9709-4408-98d0-761f0c4bf2aa"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(messageIdIndexColumn);
			EntitySchemaIndexColumn sysAdminUnitIdIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("64d6856a-0d05-4e3f-b49c-2c4fd9b06596"),
				ColumnUId = new Guid("6fb7dd90-3573-4c09-bb48-f47beda695ee"),
				CreatedInSchemaUId = new Guid("c8961918-65b6-427a-af9f-a979d47fc37d"),
				ModifiedInSchemaUId = new Guid("c8961918-65b6-427a-af9f-a979d47fc37d"),
				CreatedInPackageId = new Guid("6ba26f98-9709-4408-98d0-761f0c4bf2aa"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(sysAdminUnitIdIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("c8961918-65b6-427a-af9f-a979d47fc37d");
			RealUId = new Guid("c8961918-65b6-427a-af9f-a979d47fc37d");
			Name = "PushNotificationHistory";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("6ba26f98-9709-4408-98d0-761f0c4bf2aa");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("d38f5bbd-445b-4e2f-aa9a-725b17654c7a")) == null) {
				Columns.Add(CreateMessageIdColumn());
			}
			if (Columns.FindByUId(new Guid("6fb7dd90-3573-4c09-bb48-f47beda695ee")) == null) {
				Columns.Add(CreateSysAdminUnitIdColumn());
			}
			if (Columns.FindByUId(new Guid("12123e79-fe8e-437d-9d74-74dab195613e")) == null) {
				Columns.Add(CreateRemindTimeColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateMessageIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("d38f5bbd-445b-4e2f-aa9a-725b17654c7a"),
				Name = @"MessageId",
				CreatedInSchemaUId = new Guid("c8961918-65b6-427a-af9f-a979d47fc37d"),
				ModifiedInSchemaUId = new Guid("c8961918-65b6-427a-af9f-a979d47fc37d"),
				CreatedInPackageId = new Guid("6ba26f98-9709-4408-98d0-761f0c4bf2aa")
			};
		}

		protected virtual EntitySchemaColumn CreateSysAdminUnitIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("6fb7dd90-3573-4c09-bb48-f47beda695ee"),
				Name = @"SysAdminUnitId",
				CreatedInSchemaUId = new Guid("c8961918-65b6-427a-af9f-a979d47fc37d"),
				ModifiedInSchemaUId = new Guid("c8961918-65b6-427a-af9f-a979d47fc37d"),
				CreatedInPackageId = new Guid("6ba26f98-9709-4408-98d0-761f0c4bf2aa")
			};
		}

		protected virtual EntitySchemaColumn CreateRemindTimeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("12123e79-fe8e-437d-9d74-74dab195613e"),
				Name = @"RemindTime",
				CreatedInSchemaUId = new Guid("c8961918-65b6-427a-af9f-a979d47fc37d"),
				ModifiedInSchemaUId = new Guid("c8961918-65b6-427a-af9f-a979d47fc37d"),
				CreatedInPackageId = new Guid("6ba26f98-9709-4408-98d0-761f0c4bf2aa")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateIiCTh7tPwzoqw1CzkEjt5W7sO3bEIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new PushNotificationHistory(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new PushNotificationHistory_NUIEventsProcess(userConnection);
		}

		public override object Clone() {
			return new PushNotificationHistorySchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new PushNotificationHistorySchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("c8961918-65b6-427a-af9f-a979d47fc37d"));
		}

		#endregion

	}

	#endregion

	#region Class: PushNotificationHistory

	/// <summary>
	/// Push notification history.
	/// </summary>
	public class PushNotificationHistory : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public PushNotificationHistory(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "PushNotificationHistory";
		}

		public PushNotificationHistory(PushNotificationHistory source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		public Guid MessageId {
			get {
				return GetTypedColumnValue<Guid>("MessageId");
			}
			set {
				SetColumnValue("MessageId", value);
			}
		}

		public Guid SysAdminUnitId {
			get {
				return GetTypedColumnValue<Guid>("SysAdminUnitId");
			}
			set {
				SetColumnValue("SysAdminUnitId", value);
			}
		}

		public DateTime RemindTime {
			get {
				return GetTypedColumnValue<DateTime>("RemindTime");
			}
			set {
				SetColumnValue("RemindTime", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new PushNotificationHistory_NUIEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("PushNotificationHistoryDeleted", e);
			Validating += (s, e) => ThrowEvent("PushNotificationHistoryValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new PushNotificationHistory(this);
		}

		#endregion

	}

	#endregion

	#region Class: PushNotificationHistory_NUIEventsProcess

	/// <exclude/>
	public partial class PushNotificationHistory_NUIEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : PushNotificationHistory
	{

		public PushNotificationHistory_NUIEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "PushNotificationHistory_NUIEventsProcess";
			SchemaUId = new Guid("c8961918-65b6-427a-af9f-a979d47fc37d");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("c8961918-65b6-427a-af9f-a979d47fc37d");
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

	#region Class: PushNotificationHistory_NUIEventsProcess

	/// <exclude/>
	public class PushNotificationHistory_NUIEventsProcess : PushNotificationHistory_NUIEventsProcess<PushNotificationHistory>
	{

		public PushNotificationHistory_NUIEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: PushNotificationHistory_NUIEventsProcess

	public partial class PushNotificationHistory_NUIEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: PushNotificationHistoryEventsProcess

	/// <exclude/>
	public class PushNotificationHistoryEventsProcess : PushNotificationHistory_NUIEventsProcess
	{

		public PushNotificationHistoryEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

