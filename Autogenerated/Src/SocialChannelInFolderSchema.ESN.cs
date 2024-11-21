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

	#region Class: SocialChannelInFolderSchema

	/// <exclude/>
	public class SocialChannelInFolderSchema : BPMSoft.Configuration.BaseItemInFolderSchema
	{

		#region Constructors: Public

		public SocialChannelInFolderSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SocialChannelInFolderSchema(SocialChannelInFolderSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SocialChannelInFolderSchema(SocialChannelInFolderSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("b58a1d68-e1b3-4f7e-9029-f5fca2952b3b");
			RealUId = new Guid("b58a1d68-e1b3-4f7e-9029-f5fca2952b3b");
			Name = "SocialChannelInFolder";
			ParentSchemaUId = new Guid("4f63bafb-e9e7-4082-b92e-66b97c14017c");
			ExtendParent = false;
			CreatedInPackageId = new Guid("201fea27-b50a-40ad-a9a0-a08e92938ca6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("0653058c-db18-465e-852c-ee89294c93f2")) == null) {
				Columns.Add(CreateSocialChannelColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("b58a1d68-e1b3-4f7e-9029-f5fca2952b3b");
			column.CreatedInPackageId = new Guid("201fea27-b50a-40ad-a9a0-a08e92938ca6");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("b58a1d68-e1b3-4f7e-9029-f5fca2952b3b");
			column.CreatedInPackageId = new Guid("201fea27-b50a-40ad-a9a0-a08e92938ca6");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("b58a1d68-e1b3-4f7e-9029-f5fca2952b3b");
			column.CreatedInPackageId = new Guid("201fea27-b50a-40ad-a9a0-a08e92938ca6");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("b58a1d68-e1b3-4f7e-9029-f5fca2952b3b");
			column.CreatedInPackageId = new Guid("201fea27-b50a-40ad-a9a0-a08e92938ca6");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("b58a1d68-e1b3-4f7e-9029-f5fca2952b3b");
			column.CreatedInPackageId = new Guid("201fea27-b50a-40ad-a9a0-a08e92938ca6");
			return column;
		}

		protected override EntitySchemaColumn CreateFolderColumn() {
			EntitySchemaColumn column = base.CreateFolderColumn();
			column.ReferenceSchemaUId = new Guid("115829a7-e661-4b10-ace7-2ae9be68d536");
			column.ColumnValueName = @"FolderId";
			column.DisplayColumnValueName = @"FolderName";
			column.ModifiedInSchemaUId = new Guid("b58a1d68-e1b3-4f7e-9029-f5fca2952b3b");
			column.CreatedInPackageId = new Guid("201fea27-b50a-40ad-a9a0-a08e92938ca6");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("b58a1d68-e1b3-4f7e-9029-f5fca2952b3b");
			column.CreatedInPackageId = new Guid("201fea27-b50a-40ad-a9a0-a08e92938ca6");
			return column;
		}

		protected virtual EntitySchemaColumn CreateSocialChannelColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("0653058c-db18-465e-852c-ee89294c93f2"),
				Name = @"SocialChannel",
				ReferenceSchemaUId = new Guid("dd74c060-eb4b-4f15-b381-db91ca5ac483"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("b58a1d68-e1b3-4f7e-9029-f5fca2952b3b"),
				ModifiedInSchemaUId = new Guid("b58a1d68-e1b3-4f7e-9029-f5fca2952b3b"),
				CreatedInPackageId = new Guid("201fea27-b50a-40ad-a9a0-a08e92938ca6")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SocialChannelInFolder(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SocialChannelInFolder_ESNEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SocialChannelInFolderSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SocialChannelInFolderSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("b58a1d68-e1b3-4f7e-9029-f5fca2952b3b"));
		}

		#endregion

	}

	#endregion

	#region Class: SocialChannelInFolder

	/// <summary>
	/// Channel in folder.
	/// </summary>
	public class SocialChannelInFolder : BPMSoft.Configuration.BaseItemInFolder
	{

		#region Constructors: Public

		public SocialChannelInFolder(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SocialChannelInFolder";
		}

		public SocialChannelInFolder(SocialChannelInFolder source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid SocialChannelId {
			get {
				return GetTypedColumnValue<Guid>("SocialChannelId");
			}
			set {
				SetColumnValue("SocialChannelId", value);
				_socialChannel = null;
			}
		}

		/// <exclude/>
		public string SocialChannelTitle {
			get {
				return GetTypedColumnValue<string>("SocialChannelTitle");
			}
			set {
				SetColumnValue("SocialChannelTitle", value);
				if (_socialChannel != null) {
					_socialChannel.Title = value;
				}
			}
		}

		private SocialChannel _socialChannel;
		/// <summary>
		/// Channel.
		/// </summary>
		public SocialChannel SocialChannel {
			get {
				return _socialChannel ??
					(_socialChannel = LookupColumnEntities.GetEntity("SocialChannel") as SocialChannel);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SocialChannelInFolder_ESNEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SocialChannelInFolderDeleted", e);
			Inserting += (s, e) => ThrowEvent("SocialChannelInFolderInserting", e);
			Validating += (s, e) => ThrowEvent("SocialChannelInFolderValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SocialChannelInFolder(this);
		}

		#endregion

	}

	#endregion

	#region Class: SocialChannelInFolder_ESNEventsProcess

	/// <exclude/>
	public partial class SocialChannelInFolder_ESNEventsProcess<TEntity> : BPMSoft.Configuration.BaseItemInFolder_BaseEventsProcess<TEntity> where TEntity : SocialChannelInFolder
	{

		public SocialChannelInFolder_ESNEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SocialChannelInFolder_ESNEventsProcess";
			SchemaUId = new Guid("b58a1d68-e1b3-4f7e-9029-f5fca2952b3b");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("b58a1d68-e1b3-4f7e-9029-f5fca2952b3b");
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

	#region Class: SocialChannelInFolder_ESNEventsProcess

	/// <exclude/>
	public class SocialChannelInFolder_ESNEventsProcess : SocialChannelInFolder_ESNEventsProcess<SocialChannelInFolder>
	{

		public SocialChannelInFolder_ESNEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SocialChannelInFolder_ESNEventsProcess

	public partial class SocialChannelInFolder_ESNEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SocialChannelInFolderEventsProcess

	/// <exclude/>
	public class SocialChannelInFolderEventsProcess : SocialChannelInFolder_ESNEventsProcess
	{

		public SocialChannelInFolderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

