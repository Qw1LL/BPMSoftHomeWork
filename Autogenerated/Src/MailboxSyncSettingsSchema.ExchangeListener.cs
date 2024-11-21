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

	#region Class: MailboxSyncSettings_ExchangeListener_BPMSoftSchema

	/// <exclude/>
	public class MailboxSyncSettings_ExchangeListener_BPMSoftSchema : BPMSoft.Configuration.MailboxSyncSettings_Exchange_BPMSoftSchema
	{

		#region Constructors: Public

		public MailboxSyncSettings_ExchangeListener_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public MailboxSyncSettings_ExchangeListener_BPMSoftSchema(MailboxSyncSettings_ExchangeListener_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public MailboxSyncSettings_ExchangeListener_BPMSoftSchema(MailboxSyncSettings_ExchangeListener_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("6b3862cd-127b-446a-a829-d027ada6df3d");
			Name = "MailboxSyncSettings_ExchangeListener_BPMSoft";
			ParentSchemaUId = new Guid("5e487721-02e2-48ee-b755-dfa5160f5315");
			ExtendParent = true;
			CreatedInPackageId = new Guid("312571d2-5e4d-43a6-b9ab-0f4de364b033");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("fe0b3b4a-7029-4031-b6a8-1718944fc658")) == null) {
				Columns.Add(CreatePersonalMetricsColumn());
			}
			if (Columns.FindByUId(new Guid("427e10cf-20ea-f378-9adb-4b75170f8c18")) == null) {
				Columns.Add(CreateMarkEmailsAsSynchronizedColumn());
			}
		}

		protected override EntitySchemaColumn CreateSysAdminUnitColumn() {
			EntitySchemaColumn column = base.CreateSysAdminUnitColumn();
			column.DefValue = new EntitySchemaColumnDef() {
				Source = EntitySchemaColumnDefSource.SystemValue,
				ValueSource = SystemValueManager.GetInstanceByName(@"CurrentUser")
			};
			column.ModifiedInSchemaUId = new Guid("6b3862cd-127b-446a-a829-d027ada6df3d");
			return column;
		}

		protected override EntitySchemaColumn CreateMailSyncPeriodColumn() {
			EntitySchemaColumn column = base.CreateMailSyncPeriodColumn();
			column.DefValue = new EntitySchemaColumnDef() {
				Source = EntitySchemaColumnDefSource.Const,
				ValueSource = @"2d480351-94b7-4cad-b02f-885730c7eb3e"
			};
			column.ModifiedInSchemaUId = new Guid("6b3862cd-127b-446a-a829-d027ada6df3d");
			return column;
		}

		protected virtual EntitySchemaColumn CreatePersonalMetricsColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("fe0b3b4a-7029-4031-b6a8-1718944fc658"),
				Name = @"PersonalMetrics",
				CreatedInSchemaUId = new Guid("6b3862cd-127b-446a-a829-d027ada6df3d"),
				ModifiedInSchemaUId = new Guid("6b3862cd-127b-446a-a829-d027ada6df3d"),
				CreatedInPackageId = new Guid("312571d2-5e4d-43a6-b9ab-0f4de364b033")
			};
		}

		protected virtual EntitySchemaColumn CreateMarkEmailsAsSynchronizedColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("427e10cf-20ea-f378-9adb-4b75170f8c18"),
				Name = @"MarkEmailsAsSynchronized",
				CreatedInSchemaUId = new Guid("6b3862cd-127b-446a-a829-d027ada6df3d"),
				ModifiedInSchemaUId = new Guid("6b3862cd-127b-446a-a829-d027ada6df3d"),
				CreatedInPackageId = new Guid("61638c45-5fa1-40b1-a87c-a48a656445c6"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"True"
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
			return new MailboxSyncSettings_ExchangeListener_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new MailboxSyncSettings_ExchangeListenerEventsProcess(userConnection);
		}

		public override object Clone() {
			return new MailboxSyncSettings_ExchangeListener_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new MailboxSyncSettings_ExchangeListener_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("6b3862cd-127b-446a-a829-d027ada6df3d"));
		}

		#endregion

	}

	#endregion

	#region Class: MailboxSyncSettings_ExchangeListener_BPMSoft

	/// <summary>
	/// Mailbox synchronization settings.
	/// </summary>
	public class MailboxSyncSettings_ExchangeListener_BPMSoft : BPMSoft.Configuration.MailboxSyncSettings_Exchange_BPMSoft
	{

		#region Constructors: Public

		public MailboxSyncSettings_ExchangeListener_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "MailboxSyncSettings_ExchangeListener_BPMSoft";
		}

		public MailboxSyncSettings_ExchangeListener_BPMSoft(MailboxSyncSettings_ExchangeListener_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// PersonalMetrics.
		/// </summary>
		public bool PersonalMetrics {
			get {
				return GetTypedColumnValue<bool>("PersonalMetrics");
			}
			set {
				SetColumnValue("PersonalMetrics", value);
			}
		}

		/// <summary>
		/// Mark emails as synchronized.
		/// </summary>
		public bool MarkEmailsAsSynchronized {
			get {
				return GetTypedColumnValue<bool>("MarkEmailsAsSynchronized");
			}
			set {
				SetColumnValue("MarkEmailsAsSynchronized", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new MailboxSyncSettings_ExchangeListenerEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("MailboxSyncSettings_ExchangeListener_BPMSoftDeleted", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new MailboxSyncSettings_ExchangeListener_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: MailboxSyncSettings_ExchangeListenerEventsProcess

	/// <exclude/>
	public partial class MailboxSyncSettings_ExchangeListenerEventsProcess<TEntity> : BPMSoft.Configuration.MailboxSyncSettings_ExchangeEventsProcess<TEntity> where TEntity : MailboxSyncSettings_ExchangeListener_BPMSoft
	{

		public MailboxSyncSettings_ExchangeListenerEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "MailboxSyncSettings_ExchangeListenerEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("6b3862cd-127b-446a-a829-d027ada6df3d");
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

	#region Class: MailboxSyncSettings_ExchangeListenerEventsProcess

	/// <exclude/>
	public class MailboxSyncSettings_ExchangeListenerEventsProcess : MailboxSyncSettings_ExchangeListenerEventsProcess<MailboxSyncSettings_ExchangeListener_BPMSoft>
	{

		public MailboxSyncSettings_ExchangeListenerEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: MailboxSyncSettings_ExchangeListenerEventsProcess

	public partial class MailboxSyncSettings_ExchangeListenerEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

