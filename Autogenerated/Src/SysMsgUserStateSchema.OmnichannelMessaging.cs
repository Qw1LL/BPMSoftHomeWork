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

	#region Class: SysMsgUserStateSchema

	/// <exclude/>
	public class SysMsgUserStateSchema : BPMSoft.Configuration.SysMsgUserState_Base_BPMSoftSchema
	{

		#region Constructors: Public

		public SysMsgUserStateSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysMsgUserStateSchema(SysMsgUserStateSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysMsgUserStateSchema(SysMsgUserStateSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("7a7f3473-cb9f-4121-a5b1-098d94f05e0f");
			Name = "SysMsgUserState";
			ParentSchemaUId = new Guid("bb85a556-c9b9-41ee-acfa-eabc9bfb84ac");
			ExtendParent = true;
			CreatedInPackageId = new Guid("4258022a-9be7-42dd-a719-8d41ed9a8c3f");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("f5195af0-99b7-0925-862d-7e25c3457b66")) == null) {
				Columns.Add(CreateIsAvailableStatusColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateIsAvailableStatusColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("f5195af0-99b7-0925-862d-7e25c3457b66"),
				Name = @"IsAvailableStatus",
				CreatedInSchemaUId = new Guid("7a7f3473-cb9f-4121-a5b1-098d94f05e0f"),
				ModifiedInSchemaUId = new Guid("7a7f3473-cb9f-4121-a5b1-098d94f05e0f"),
				CreatedInPackageId = new Guid("4258022a-9be7-42dd-a719-8d41ed9a8c3f")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysMsgUserState(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysMsgUserState_OmnichannelMessagingEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysMsgUserStateSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysMsgUserStateSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("7a7f3473-cb9f-4121-a5b1-098d94f05e0f"));
		}

		#endregion

	}

	#endregion

	#region Class: SysMsgUserState

	/// <summary>
	/// Состояние пользователя при обмене сообщениями.
	/// </summary>
	public class SysMsgUserState : BPMSoft.Configuration.SysMsgUserState_Base_BPMSoft
	{

		#region Constructors: Public

		public SysMsgUserState(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysMsgUserState";
		}

		public SysMsgUserState(SysMsgUserState source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Доступность оператора.
		/// </summary>
		public bool IsAvailableStatus {
			get {
				return GetTypedColumnValue<bool>("IsAvailableStatus");
			}
			set {
				SetColumnValue("IsAvailableStatus", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysMsgUserState_OmnichannelMessagingEventsProcess(UserConnection);
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
			return new SysMsgUserState(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysMsgUserState_OmnichannelMessagingEventsProcess

	/// <exclude/>
	public partial class SysMsgUserState_OmnichannelMessagingEventsProcess<TEntity> : BPMSoft.Configuration.SysMsgUserState_BaseEventsProcess<TEntity> where TEntity : SysMsgUserState
	{

		public SysMsgUserState_OmnichannelMessagingEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysMsgUserState_OmnichannelMessagingEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("7a7f3473-cb9f-4121-a5b1-098d94f05e0f");
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

	#region Class: SysMsgUserState_OmnichannelMessagingEventsProcess

	/// <exclude/>
	public class SysMsgUserState_OmnichannelMessagingEventsProcess : SysMsgUserState_OmnichannelMessagingEventsProcess<SysMsgUserState>
	{

		public SysMsgUserState_OmnichannelMessagingEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysMsgUserState_OmnichannelMessagingEventsProcess

	public partial class SysMsgUserState_OmnichannelMessagingEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysMsgUserStateEventsProcess

	/// <exclude/>
	public class SysMsgUserStateEventsProcess : SysMsgUserState_OmnichannelMessagingEventsProcess
	{

		public SysMsgUserStateEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

