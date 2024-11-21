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

	#region Class: OmniChatInFolderSchema

	/// <exclude/>
	public class OmniChatInFolderSchema : BPMSoft.Configuration.BaseItemInFolderSchema
	{

		#region Constructors: Public

		public OmniChatInFolderSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public OmniChatInFolderSchema(OmniChatInFolderSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public OmniChatInFolderSchema(OmniChatInFolderSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("d6ae6ea9-5bbe-4d16-a7ec-f2bb708cacf7");
			RealUId = new Guid("d6ae6ea9-5bbe-4d16-a7ec-f2bb708cacf7");
			Name = "OmniChatInFolder";
			ParentSchemaUId = new Guid("4f63bafb-e9e7-4082-b92e-66b97c14017c");
			ExtendParent = false;
			CreatedInPackageId = new Guid("08afff10-3d0c-4f3d-b6a0-28a42952a988");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("53980863-3a2a-46c4-9a2c-6ca50e9a9d57")) == null) {
				Columns.Add(CreateOmniChatColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("d6ae6ea9-5bbe-4d16-a7ec-f2bb708cacf7");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("d6ae6ea9-5bbe-4d16-a7ec-f2bb708cacf7");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("d6ae6ea9-5bbe-4d16-a7ec-f2bb708cacf7");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("d6ae6ea9-5bbe-4d16-a7ec-f2bb708cacf7");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("d6ae6ea9-5bbe-4d16-a7ec-f2bb708cacf7");
			return column;
		}

		protected override EntitySchemaColumn CreateFolderColumn() {
			EntitySchemaColumn column = base.CreateFolderColumn();
			column.ReferenceSchemaUId = new Guid("a9435ec9-3ec5-4251-9687-a24d6f871e13");
			column.ColumnValueName = @"FolderId";
			column.DisplayColumnValueName = @"FolderName";
			column.ModifiedInSchemaUId = new Guid("d6ae6ea9-5bbe-4d16-a7ec-f2bb708cacf7");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("d6ae6ea9-5bbe-4d16-a7ec-f2bb708cacf7");
			return column;
		}

		protected virtual EntitySchemaColumn CreateOmniChatColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("53980863-3a2a-46c4-9a2c-6ca50e9a9d57"),
				Name = @"OmniChat",
				ReferenceSchemaUId = new Guid("af1f685c-315b-4b44-a957-c5094417a57a"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsValueCloneable = false,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("d6ae6ea9-5bbe-4d16-a7ec-f2bb708cacf7"),
				ModifiedInSchemaUId = new Guid("d6ae6ea9-5bbe-4d16-a7ec-f2bb708cacf7"),
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
			return new OmniChatInFolder(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new OmniChatInFolder_OmnichannelMessagingEventsProcess(userConnection);
		}

		public override object Clone() {
			return new OmniChatInFolderSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new OmniChatInFolderSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("d6ae6ea9-5bbe-4d16-a7ec-f2bb708cacf7"));
		}

		#endregion

	}

	#endregion

	#region Class: OmniChatInFolder

	/// <summary>
	/// Chat in Folder.
	/// </summary>
	public class OmniChatInFolder : BPMSoft.Configuration.BaseItemInFolder
	{

		#region Constructors: Public

		public OmniChatInFolder(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "OmniChatInFolder";
		}

		public OmniChatInFolder(OmniChatInFolder source)
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
			var process = new OmniChatInFolder_OmnichannelMessagingEventsProcess(UserConnection);
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
			return new OmniChatInFolder(this);
		}

		#endregion

	}

	#endregion

	#region Class: OmniChatInFolder_OmnichannelMessagingEventsProcess

	/// <exclude/>
	public partial class OmniChatInFolder_OmnichannelMessagingEventsProcess<TEntity> : BPMSoft.Configuration.BaseItemInFolder_BaseEventsProcess<TEntity> where TEntity : OmniChatInFolder
	{

		public OmniChatInFolder_OmnichannelMessagingEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "OmniChatInFolder_OmnichannelMessagingEventsProcess";
			SchemaUId = new Guid("d6ae6ea9-5bbe-4d16-a7ec-f2bb708cacf7");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("d6ae6ea9-5bbe-4d16-a7ec-f2bb708cacf7");
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

	#region Class: OmniChatInFolder_OmnichannelMessagingEventsProcess

	/// <exclude/>
	public class OmniChatInFolder_OmnichannelMessagingEventsProcess : OmniChatInFolder_OmnichannelMessagingEventsProcess<OmniChatInFolder>
	{

		public OmniChatInFolder_OmnichannelMessagingEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: OmniChatInFolder_OmnichannelMessagingEventsProcess

	public partial class OmniChatInFolder_OmnichannelMessagingEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: OmniChatInFolderEventsProcess

	/// <exclude/>
	public class OmniChatInFolderEventsProcess : OmniChatInFolder_OmnichannelMessagingEventsProcess
	{

		public OmniChatInFolderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

