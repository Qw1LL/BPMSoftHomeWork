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

	#region Class: MessageListenerSchema

	/// <exclude/>
	public class MessageListenerSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public MessageListenerSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public MessageListenerSchema(MessageListenerSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public MessageListenerSchema(MessageListenerSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("34c308f0-dd59-4069-9613-4093b945b9be");
			RealUId = new Guid("34c308f0-dd59-4069-9613-4093b945b9be");
			Name = "MessageListener";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("b4ad7210-1e2c-4a25-8f9c-bff818d48783");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("02904636-7e42-41fd-b303-77f5cd34ba9a")) == null) {
				Columns.Add(CreateClassNameColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateClassNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("02904636-7e42-41fd-b303-77f5cd34ba9a"),
				Name = @"ClassName",
				CreatedInSchemaUId = new Guid("34c308f0-dd59-4069-9613-4093b945b9be"),
				ModifiedInSchemaUId = new Guid("34c308f0-dd59-4069-9613-4093b945b9be"),
				CreatedInPackageId = new Guid("b4ad7210-1e2c-4a25-8f9c-bff818d48783")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new MessageListener(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new MessageListener_MessageEventsProcess(userConnection);
		}

		public override object Clone() {
			return new MessageListenerSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new MessageListenerSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("34c308f0-dd59-4069-9613-4093b945b9be"));
		}

		#endregion

	}

	#endregion

	#region Class: MessageListener

	/// <summary>
	/// Message listener.
	/// </summary>
	public class MessageListener : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public MessageListener(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "MessageListener";
		}

		public MessageListener(MessageListener source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Class name.
		/// </summary>
		public string ClassName {
			get {
				return GetTypedColumnValue<string>("ClassName");
			}
			set {
				SetColumnValue("ClassName", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new MessageListener_MessageEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("MessageListenerDeleted", e);
			Validating += (s, e) => ThrowEvent("MessageListenerValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new MessageListener(this);
		}

		#endregion

	}

	#endregion

	#region Class: MessageListener_MessageEventsProcess

	/// <exclude/>
	public partial class MessageListener_MessageEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : MessageListener
	{

		public MessageListener_MessageEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "MessageListener_MessageEventsProcess";
			SchemaUId = new Guid("34c308f0-dd59-4069-9613-4093b945b9be");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("34c308f0-dd59-4069-9613-4093b945b9be");
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

	#region Class: MessageListener_MessageEventsProcess

	/// <exclude/>
	public class MessageListener_MessageEventsProcess : MessageListener_MessageEventsProcess<MessageListener>
	{

		public MessageListener_MessageEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: MessageListener_MessageEventsProcess

	public partial class MessageListener_MessageEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: MessageListenerEventsProcess

	/// <exclude/>
	public class MessageListenerEventsProcess : MessageListener_MessageEventsProcess
	{

		public MessageListenerEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

