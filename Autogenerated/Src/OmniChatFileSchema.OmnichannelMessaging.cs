namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Configuration;
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

	#region Class: OmniChatFileSchema

	/// <exclude/>
	public class OmniChatFileSchema : BPMSoft.Configuration.FileSchema
	{

		#region Constructors: Public

		public OmniChatFileSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public OmniChatFileSchema(OmniChatFileSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public OmniChatFileSchema(OmniChatFileSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("36e97a65-2788-4607-a05c-6c2568603007");
			RealUId = new Guid("36e97a65-2788-4607-a05c-6c2568603007");
			Name = "OmniChatFile";
			ParentSchemaUId = new Guid("556c5867-60a7-4456-aae1-a57a122bef70");
			ExtendParent = false;
			CreatedInPackageId = new Guid("08afff10-3d0c-4f3d-b6a0-28a42952a988");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("6c38fa4c-1c84-4ca1-80df-83c3c99d58d3")) == null) {
				Columns.Add(CreateOmniChatColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("36e97a65-2788-4607-a05c-6c2568603007");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("36e97a65-2788-4607-a05c-6c2568603007");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("36e97a65-2788-4607-a05c-6c2568603007");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("36e97a65-2788-4607-a05c-6c2568603007");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("36e97a65-2788-4607-a05c-6c2568603007");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("36e97a65-2788-4607-a05c-6c2568603007");
			return column;
		}

		protected override EntitySchemaColumn CreateTypeColumn() {
			EntitySchemaColumn column = base.CreateTypeColumn();
			column.IsIndexed = true;
			column.ModifiedInSchemaUId = new Guid("36e97a65-2788-4607-a05c-6c2568603007");
			return column;
		}

		protected virtual EntitySchemaColumn CreateOmniChatColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("6c38fa4c-1c84-4ca1-80df-83c3c99d58d3"),
				Name = @"OmniChat",
				ReferenceSchemaUId = new Guid("af1f685c-315b-4b44-a957-c5094417a57a"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsValueCloneable = false,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("36e97a65-2788-4607-a05c-6c2568603007"),
				ModifiedInSchemaUId = new Guid("36e97a65-2788-4607-a05c-6c2568603007"),
				CreatedInPackageId = new Guid("08afff10-3d0c-4f3d-b6a0-28a42952a988")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new OmniChatFile(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new OmniChatFile_OmnichannelMessagingEventsProcess(userConnection);
		}

		public override object Clone() {
			return new OmniChatFileSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new OmniChatFileSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("36e97a65-2788-4607-a05c-6c2568603007"));
		}

		#endregion

	}

	#endregion

	#region Class: OmniChatFile

	/// <summary>
	/// Chat attachment.
	/// </summary>
	public class OmniChatFile : BPMSoft.Configuration.File
	{

		#region Constructors: Public

		public OmniChatFile(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "OmniChatFile";
		}

		public OmniChatFile(OmniChatFile source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid OmniChatId {
			get {
				return GetTypedColumnValue<Guid>("OmniChatId");
			}
			set {
				SetColumnValue("OmniChatId", value);
				_omniChat = null;
			}
		}

		/// <exclude/>
		public string OmniChatName {
			get {
				return GetTypedColumnValue<string>("OmniChatName");
			}
			set {
				SetColumnValue("OmniChatName", value);
				if (_omniChat != null) {
					_omniChat.Name = value;
				}
			}
		}

		private OmniChat _omniChat;
		/// <summary>
		/// Chat.
		/// </summary>
		public OmniChat OmniChat {
			get {
				return _omniChat ??
					(_omniChat = LookupColumnEntities.GetEntity("OmniChat") as OmniChat);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new OmniChatFile_OmnichannelMessagingEventsProcess(UserConnection);
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
			return new OmniChatFile(this);
		}

		#endregion

	}

	#endregion

	#region Class: OmniChatFile_OmnichannelMessagingEventsProcess

	/// <exclude/>
	public partial class OmniChatFile_OmnichannelMessagingEventsProcess<TEntity> : BPMSoft.Configuration.File_PRMPortalEventsProcess<TEntity> where TEntity : OmniChatFile
	{

		public OmniChatFile_OmnichannelMessagingEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "OmniChatFile_OmnichannelMessagingEventsProcess";
			SchemaUId = new Guid("36e97a65-2788-4607-a05c-6c2568603007");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("36e97a65-2788-4607-a05c-6c2568603007");
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

	#region Class: OmniChatFile_OmnichannelMessagingEventsProcess

	/// <exclude/>
	public class OmniChatFile_OmnichannelMessagingEventsProcess : OmniChatFile_OmnichannelMessagingEventsProcess<OmniChatFile>
	{

		public OmniChatFile_OmnichannelMessagingEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: OmniChatFile_OmnichannelMessagingEventsProcess

	public partial class OmniChatFile_OmnichannelMessagingEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: OmniChatFileEventsProcess

	/// <exclude/>
	public class OmniChatFileEventsProcess : OmniChatFile_OmnichannelMessagingEventsProcess
	{

		public OmniChatFileEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

