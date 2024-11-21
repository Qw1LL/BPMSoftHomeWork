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
	using System.Security;
	using TSConfiguration = BPMSoft.Configuration;

	#region Class: OmniChatTagSchema

	/// <exclude/>
	public class OmniChatTagSchema : BPMSoft.Configuration.BaseTagSchema
	{

		#region Constructors: Public

		public OmniChatTagSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public OmniChatTagSchema(OmniChatTagSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public OmniChatTagSchema(OmniChatTagSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("9d4ea95b-004a-45c2-81a9-9706a7c94108");
			RealUId = new Guid("9d4ea95b-004a-45c2-81a9-9706a7c94108");
			Name = "OmniChatTag";
			ParentSchemaUId = new Guid("9e3f203c-e905-4de5-9468-335b193f2439");
			ExtendParent = false;
			CreatedInPackageId = new Guid("08afff10-3d0c-4f3d-b6a0-28a42952a988");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("9d4ea95b-004a-45c2-81a9-9706a7c94108");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("9d4ea95b-004a-45c2-81a9-9706a7c94108");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("9d4ea95b-004a-45c2-81a9-9706a7c94108");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("9d4ea95b-004a-45c2-81a9-9706a7c94108");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("9d4ea95b-004a-45c2-81a9-9706a7c94108");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("9d4ea95b-004a-45c2-81a9-9706a7c94108");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new OmniChatTag(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new OmniChatTag_OmnichannelMessagingEventsProcess(userConnection);
		}

		public override object Clone() {
			return new OmniChatTagSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new OmniChatTagSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("9d4ea95b-004a-45c2-81a9-9706a7c94108"));
		}

		#endregion

	}

	#endregion

	#region Class: OmniChatTag

	/// <summary>
	/// Chat section tag.
	/// </summary>
	public class OmniChatTag : BPMSoft.Configuration.BaseTag
	{

		#region Constructors: Public

		public OmniChatTag(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "OmniChatTag";
		}

		public OmniChatTag(OmniChatTag source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new OmniChatTag_OmnichannelMessagingEventsProcess(UserConnection);
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
			return new OmniChatTag(this);
		}

		#endregion

	}

	#endregion

	#region Class: OmniChatTag_OmnichannelMessagingEventsProcess

	/// <exclude/>
	public partial class OmniChatTag_OmnichannelMessagingEventsProcess<TEntity> : BPMSoft.Configuration.BaseTag_SSPEventsProcess<TEntity> where TEntity : OmniChatTag
	{

		public OmniChatTag_OmnichannelMessagingEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "OmniChatTag_OmnichannelMessagingEventsProcess";
			SchemaUId = new Guid("9d4ea95b-004a-45c2-81a9-9706a7c94108");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("9d4ea95b-004a-45c2-81a9-9706a7c94108");
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

	#region Class: OmniChatTag_OmnichannelMessagingEventsProcess

	/// <exclude/>
	public class OmniChatTag_OmnichannelMessagingEventsProcess : OmniChatTag_OmnichannelMessagingEventsProcess<OmniChatTag>
	{

		public OmniChatTag_OmnichannelMessagingEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: OmniChatTag_OmnichannelMessagingEventsProcess

	public partial class OmniChatTag_OmnichannelMessagingEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: OmniChatTagEventsProcess

	/// <exclude/>
	public class OmniChatTagEventsProcess : OmniChatTag_OmnichannelMessagingEventsProcess
	{

		public OmniChatTagEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

