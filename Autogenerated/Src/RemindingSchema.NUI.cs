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
	using BPMSoft.Core.Store;
	using BPMSoft.GlobalSearch.Indexing;
	using BPMSoft.Messaging.Common;
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

	#region Class: RemindingSchema

	/// <exclude/>
	public class RemindingSchema : BPMSoft.Configuration.Reminding_Base_BPMSoftSchema
	{

		#region Constructors: Public

		public RemindingSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public RemindingSchema(RemindingSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public RemindingSchema(RemindingSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("45b30a59-08c8-4185-af46-59e3503bda37");
			Name = "Reminding";
			ParentSchemaUId = new Guid("ae7a5bc6-115f-4ed2-97c5-13f5c5142c37");
			ExtendParent = true;
			CreatedInPackageId = new Guid("6ba26f98-9709-4408-98d0-761f0c4bf2aa");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new Reminding(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Reminding_NUIEventsProcess(userConnection);
		}

		public override object Clone() {
			return new RemindingSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new RemindingSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("45b30a59-08c8-4185-af46-59e3503bda37"));
		}

		#endregion

	}

	#endregion

	#region Class: Reminding

	/// <summary>
	/// Notification.
	/// </summary>
	public class Reminding : BPMSoft.Configuration.Reminding_Base_BPMSoft
	{

		#region Constructors: Public

		public Reminding(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Reminding";
		}

		public Reminding(Reminding source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Reminding_NUIEventsProcess(UserConnection);
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
			return new Reminding(this);
		}

		#endregion

	}

	#endregion

	#region Class: Reminding_NUIEventsProcess

	/// <exclude/>
	public partial class Reminding_NUIEventsProcess<TEntity> : BPMSoft.Configuration.Reminding_BaseEventsProcess<TEntity> where TEntity : Reminding
	{

		public Reminding_NUIEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Reminding_NUIEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("45b30a59-08c8-4185-af46-59e3503bda37");
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

	#region Class: Reminding_NUIEventsProcess

	/// <exclude/>
	public class Reminding_NUIEventsProcess : Reminding_NUIEventsProcess<Reminding>
	{

		public Reminding_NUIEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: Reminding_NUIEventsProcess

	public partial class Reminding_NUIEventsProcess<TEntity>
	{

		#region Methods: Public

		public virtual INotificationInfo GetNotificationInfo() {
			var notificationTypeName = TryGeNotificationTypeName();
			string loaderName = GetSchemaName(UserConnection.ClientUnitSchemaManager, Entity.LoaderId);
			string schemaName = GetSchemaName(UserConnection.EntitySchemaManager, Entity.SysEntitySchemaId);
			INotificationSettingsRepository notificationSettingsRepository = ClassFactory.Get<NotificationSettingsRepository>(
				new ConstructorArgument("userConnection", UserConnection));
			Guid notificationTypeId = Entity.NotificationTypeId;
			Guid imageId = notificationSettingsRepository.GetNotificationImage(Entity.SysEntitySchemaId, notificationTypeId);
			Guid sysAdminUnitId = NotificationUtilities.GetSysAdminUnitId(UserConnection, Entity.ContactId);
			var title = Entity.PopupTitle.IsNullOrWhiteSpace() ? Entity.Description : Entity.PopupTitle;
			return new NotificationInfo {
				Title = title,
				Body = Entity.SubjectCaption,
				ImageId = imageId,
				EntityId = Entity.SubjectId,
				EntitySchemaName = schemaName,
				MessageId = Entity.Id,
				LoaderName = loaderName,
				SysAdminUnit = sysAdminUnitId,
				GroupName = notificationTypeName,
				RemindTime = Entity.RemindTime
			};
		}

		public override void SendNotification() {
			base.SendNotification();
			if (UserConnection.GetIsFeatureEnabled("NotificationV2")) {
				var notificationInfo = GetNotificationInfo();
				var notificationSender = ClassFactory.Get<INotificationSender>(
					new ConstructorArgument("userConnection", UserConnection));
				notificationSender.Send(new[] {notificationInfo});
			}
		}

		#endregion

	}

	#endregion


	#region Class: RemindingEventsProcess

	/// <exclude/>
	public class RemindingEventsProcess : Reminding_NUIEventsProcess
	{

		public RemindingEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

