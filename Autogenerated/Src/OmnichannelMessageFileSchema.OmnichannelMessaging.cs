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

	#region Class: OmnichannelMessageFileSchema

	/// <exclude/>
	public class OmnichannelMessageFileSchema : BPMSoft.Configuration.FileSchema
	{

		#region Constructors: Public

		public OmnichannelMessageFileSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public OmnichannelMessageFileSchema(OmnichannelMessageFileSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public OmnichannelMessageFileSchema(OmnichannelMessageFileSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("e6b4c4d4-0a51-4a6d-a8c5-18b63faddad4");
			RealUId = new Guid("e6b4c4d4-0a51-4a6d-a8c5-18b63faddad4");
			Name = "OmnichannelMessageFile";
			ParentSchemaUId = new Guid("556c5867-60a7-4456-aae1-a57a122bef70");
			ExtendParent = false;
			CreatedInPackageId = new Guid("aa784342-25af-480c-b5d1-88617bf6f672");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("92c2d485-230a-4174-8651-a96936fc47cc")) == null) {
				Columns.Add(CreateMessageIdColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateMessageIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("92c2d485-230a-4174-8651-a96936fc47cc"),
				Name = @"MessageId",
				CreatedInSchemaUId = new Guid("e6b4c4d4-0a51-4a6d-a8c5-18b63faddad4"),
				ModifiedInSchemaUId = new Guid("e6b4c4d4-0a51-4a6d-a8c5-18b63faddad4"),
				CreatedInPackageId = new Guid("aa784342-25af-480c-b5d1-88617bf6f672")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new OmnichannelMessageFile(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new OmnichannelMessageFile_OmnichannelMessagingEventsProcess(userConnection);
		}

		public override object Clone() {
			return new OmnichannelMessageFileSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new OmnichannelMessageFileSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("e6b4c4d4-0a51-4a6d-a8c5-18b63faddad4"));
		}

		#endregion

	}

	#endregion

	#region Class: OmnichannelMessageFile

	/// <summary>
	/// Message file.
	/// </summary>
	public class OmnichannelMessageFile : BPMSoft.Configuration.File
	{

		#region Constructors: Public

		public OmnichannelMessageFile(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "OmnichannelMessageFile";
		}

		public OmnichannelMessageFile(OmnichannelMessageFile source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Message identifier.
		/// </summary>
		public Guid MessageId {
			get {
				return GetTypedColumnValue<Guid>("MessageId");
			}
			set {
				SetColumnValue("MessageId", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new OmnichannelMessageFile_OmnichannelMessagingEventsProcess(UserConnection);
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
			return new OmnichannelMessageFile(this);
		}

		#endregion

	}

	#endregion

	#region Class: OmnichannelMessageFile_OmnichannelMessagingEventsProcess

	/// <exclude/>
	public partial class OmnichannelMessageFile_OmnichannelMessagingEventsProcess<TEntity> : BPMSoft.Configuration.File_PRMPortalEventsProcess<TEntity> where TEntity : OmnichannelMessageFile
	{

		public OmnichannelMessageFile_OmnichannelMessagingEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "OmnichannelMessageFile_OmnichannelMessagingEventsProcess";
			SchemaUId = new Guid("e6b4c4d4-0a51-4a6d-a8c5-18b63faddad4");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("e6b4c4d4-0a51-4a6d-a8c5-18b63faddad4");
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

	#region Class: OmnichannelMessageFile_OmnichannelMessagingEventsProcess

	/// <exclude/>
	public class OmnichannelMessageFile_OmnichannelMessagingEventsProcess : OmnichannelMessageFile_OmnichannelMessagingEventsProcess<OmnichannelMessageFile>
	{

		public OmnichannelMessageFile_OmnichannelMessagingEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: OmnichannelMessageFile_OmnichannelMessagingEventsProcess

	public partial class OmnichannelMessageFile_OmnichannelMessagingEventsProcess<TEntity>
	{

		#region Methods: Public

		public override void OnFileSaved() {
			base.OnFileSaved();
			
			if (!UserConnection.GetIsFeatureEnabled("LinkPreview")) {
				return;
			}
			
			var fileType = Entity.GetTypedColumnValue<Guid>("TypeId");
			if (fileType == BPMSoft.WebApp.FileConsts.LinkTypeUId) {
				var url = Entity.GetTypedColumnValue<string>("Name").Trim();
				if (IsURLValid(url)) {
					LinkPreview linkPreview = new LinkPreview();
					LinkPreviewInfo linkPreviewInfo = linkPreview.GetWebPageLinkPreview(url);
					if (linkPreviewInfo != null) {
						LinkPreviewProvider linkPreviewProvider = new LinkPreviewProvider(UserConnection);
						linkPreviewProvider.SaveLinkPreviewInfo(linkPreviewInfo, Entity.PrimaryColumnValue);
					}
				}
			}
		}

		public override void OnFileDeleted() {
			base.OnFileDeleted();
			
			if (!UserConnection.GetIsFeatureEnabled("LinkPreview")) {
				return;
			}
			
			var fileType = Entity.GetTypedColumnValue<Guid>("TypeId");
			if (fileType == BPMSoft.WebApp.FileConsts.LinkTypeUId) {
				LinkPreviewProvider linkPreviewProvider = new LinkPreviewProvider(UserConnection);
				linkPreviewProvider.DeleteLinkPreviewInfo(Entity.PrimaryColumnValue);
			}
		}

		public override void OnFileUpdated() {
			base.OnFileUpdated();
			
			if (!UserConnection.GetIsFeatureEnabled("LinkPreview")) {
				return;
			}
			
			var fileType = Entity.GetTypedColumnValue<Guid>("TypeId");
			string oldUrl = (string)Entity.GetColumnOldValue("Name");
			if (fileType == BPMSoft.WebApp.FileConsts.LinkTypeUId && IsURLValid(oldUrl)) {
				LinkPreviewProvider linkPreviewProvider = new LinkPreviewProvider(UserConnection);
				linkPreviewProvider.DeleteLinkPreviewInfo(Entity.PrimaryColumnValue);
			}
		}

		#endregion

	}

	#endregion


	#region Class: OmnichannelMessageFileEventsProcess

	/// <exclude/>
	public class OmnichannelMessageFileEventsProcess : OmnichannelMessageFile_OmnichannelMessagingEventsProcess
	{

		public OmnichannelMessageFileEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

