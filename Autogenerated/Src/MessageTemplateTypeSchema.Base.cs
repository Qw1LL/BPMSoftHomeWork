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

	#region Class: MessageTemplateTypeSchema

	/// <exclude/>
	public class MessageTemplateTypeSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public MessageTemplateTypeSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public MessageTemplateTypeSchema(MessageTemplateTypeSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public MessageTemplateTypeSchema(MessageTemplateTypeSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("e7c7ec31-2e3f-4c8e-bcaa-b71e1989ba5c");
			RealUId = new Guid("e7c7ec31-2e3f-4c8e-bcaa-b71e1989ba5c");
			Name = "MessageTemplateType";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2");
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
			return new MessageTemplateType(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new MessageTemplateType_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new MessageTemplateTypeSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new MessageTemplateTypeSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("e7c7ec31-2e3f-4c8e-bcaa-b71e1989ba5c"));
		}

		#endregion

	}

	#endregion

	#region Class: MessageTemplateType

	/// <summary>
	/// Message template type.
	/// </summary>
	public class MessageTemplateType : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public MessageTemplateType(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "MessageTemplateType";
		}

		public MessageTemplateType(MessageTemplateType source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new MessageTemplateType_BaseEventsProcess(UserConnection);
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
			return new MessageTemplateType(this);
		}

		#endregion

	}

	#endregion

	#region Class: MessageTemplateType_BaseEventsProcess

	/// <exclude/>
	public partial class MessageTemplateType_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : MessageTemplateType
	{

		public MessageTemplateType_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "MessageTemplateType_BaseEventsProcess";
			SchemaUId = new Guid("e7c7ec31-2e3f-4c8e-bcaa-b71e1989ba5c");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("e7c7ec31-2e3f-4c8e-bcaa-b71e1989ba5c");
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

	#region Class: MessageTemplateType_BaseEventsProcess

	/// <exclude/>
	public class MessageTemplateType_BaseEventsProcess : MessageTemplateType_BaseEventsProcess<MessageTemplateType>
	{

		public MessageTemplateType_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: MessageTemplateType_BaseEventsProcess

	public partial class MessageTemplateType_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: MessageTemplateTypeEventsProcess

	/// <exclude/>
	public class MessageTemplateTypeEventsProcess : MessageTemplateType_BaseEventsProcess
	{

		public MessageTemplateTypeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

