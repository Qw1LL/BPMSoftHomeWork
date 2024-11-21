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

	#region Class: OmnichannelChatStatusSchema

	/// <exclude/>
	public class OmnichannelChatStatusSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public OmnichannelChatStatusSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public OmnichannelChatStatusSchema(OmnichannelChatStatusSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public OmnichannelChatStatusSchema(OmnichannelChatStatusSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("34e3f9b5-a909-48d8-a169-b766c4a77221");
			RealUId = new Guid("34e3f9b5-a909-48d8-a169-b766c4a77221");
			Name = "OmnichannelChatStatus";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("92ff52b6-dfba-4556-90d8-6f4c37f69c5d");
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
			return new OmnichannelChatStatus(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new OmnichannelChatStatus_OmnichannelMessagingEventsProcess(userConnection);
		}

		public override object Clone() {
			return new OmnichannelChatStatusSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new OmnichannelChatStatusSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("34e3f9b5-a909-48d8-a169-b766c4a77221"));
		}

		#endregion

	}

	#endregion

	#region Class: OmnichannelChatStatus

	/// <summary>
	/// Chat status.
	/// </summary>
	public class OmnichannelChatStatus : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public OmnichannelChatStatus(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "OmnichannelChatStatus";
		}

		public OmnichannelChatStatus(OmnichannelChatStatus source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new OmnichannelChatStatus_OmnichannelMessagingEventsProcess(UserConnection);
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
			return new OmnichannelChatStatus(this);
		}

		#endregion

	}

	#endregion

	#region Class: OmnichannelChatStatus_OmnichannelMessagingEventsProcess

	/// <exclude/>
	public partial class OmnichannelChatStatus_OmnichannelMessagingEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : OmnichannelChatStatus
	{

		public OmnichannelChatStatus_OmnichannelMessagingEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "OmnichannelChatStatus_OmnichannelMessagingEventsProcess";
			SchemaUId = new Guid("34e3f9b5-a909-48d8-a169-b766c4a77221");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("34e3f9b5-a909-48d8-a169-b766c4a77221");
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

	#region Class: OmnichannelChatStatus_OmnichannelMessagingEventsProcess

	/// <exclude/>
	public class OmnichannelChatStatus_OmnichannelMessagingEventsProcess : OmnichannelChatStatus_OmnichannelMessagingEventsProcess<OmnichannelChatStatus>
	{

		public OmnichannelChatStatus_OmnichannelMessagingEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: OmnichannelChatStatus_OmnichannelMessagingEventsProcess

	public partial class OmnichannelChatStatus_OmnichannelMessagingEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: OmnichannelChatStatusEventsProcess

	/// <exclude/>
	public class OmnichannelChatStatusEventsProcess : OmnichannelChatStatus_OmnichannelMessagingEventsProcess
	{

		public OmnichannelChatStatusEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

