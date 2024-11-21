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

	#region Class: BaseItemInFolderSchema

	/// <exclude/>
	[IsVirtual]
	public class BaseItemInFolderSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public BaseItemInFolderSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public BaseItemInFolderSchema(BaseItemInFolderSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public BaseItemInFolderSchema(BaseItemInFolderSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("4f63bafb-e9e7-4082-b92e-66b97c14017c");
			RealUId = new Guid("4f63bafb-e9e7-4082-b92e-66b97c14017c");
			Name = "BaseItemInFolder";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("9e46bb69-9788-423c-b7cd-4c624081082d")) == null) {
				Columns.Add(CreateFolderColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateFolderColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("9e46bb69-9788-423c-b7cd-4c624081082d"),
				Name = @"Folder",
				ReferenceSchemaUId = new Guid("d602bf96-d029-4b07-9755-63c8f5cb5ed5"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("4f63bafb-e9e7-4082-b92e-66b97c14017c"),
				ModifiedInSchemaUId = new Guid("4f63bafb-e9e7-4082-b92e-66b97c14017c"),
				CreatedInPackageId = new Guid("773ffacd-4a58-4934-8cb2-5bf23386d08f")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new BaseItemInFolder(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new BaseItemInFolder_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new BaseItemInFolderSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new BaseItemInFolderSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("4f63bafb-e9e7-4082-b92e-66b97c14017c"));
		}

		#endregion

	}

	#endregion

	#region Class: BaseItemInFolder

	/// <summary>
	/// Base item in folder.
	/// </summary>
	public class BaseItemInFolder : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public BaseItemInFolder(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "BaseItemInFolder";
		}

		public BaseItemInFolder(BaseItemInFolder source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid FolderId {
			get {
				return GetTypedColumnValue<Guid>("FolderId");
			}
			set {
				SetColumnValue("FolderId", value);
				_folder = null;
			}
		}

		/// <exclude/>
		public string FolderName {
			get {
				return GetTypedColumnValue<string>("FolderName");
			}
			set {
				SetColumnValue("FolderName", value);
				if (_folder != null) {
					_folder.Name = value;
				}
			}
		}

		private BaseFolder _folder;
		/// <summary>
		/// Folder.
		/// </summary>
		public BaseFolder Folder {
			get {
				return _folder ??
					(_folder = LookupColumnEntities.GetEntity("Folder") as BaseFolder);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new BaseItemInFolder_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("BaseItemInFolderDeleted", e);
			Deleting += (s, e) => ThrowEvent("BaseItemInFolderDeleting", e);
			Inserted += (s, e) => ThrowEvent("BaseItemInFolderInserted", e);
			Inserting += (s, e) => ThrowEvent("BaseItemInFolderInserting", e);
			Saved += (s, e) => ThrowEvent("BaseItemInFolderSaved", e);
			Saving += (s, e) => ThrowEvent("BaseItemInFolderSaving", e);
			Validating += (s, e) => ThrowEvent("BaseItemInFolderValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new BaseItemInFolder(this);
		}

		#endregion

	}

	#endregion

	#region Class: BaseItemInFolder_BaseEventsProcess

	/// <exclude/>
	public partial class BaseItemInFolder_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : BaseItemInFolder
	{

		public BaseItemInFolder_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "BaseItemInFolder_BaseEventsProcess";
			SchemaUId = new Guid("4f63bafb-e9e7-4082-b92e-66b97c14017c");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("4f63bafb-e9e7-4082-b92e-66b97c14017c");
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

	#region Class: BaseItemInFolder_BaseEventsProcess

	/// <exclude/>
	public class BaseItemInFolder_BaseEventsProcess : BaseItemInFolder_BaseEventsProcess<BaseItemInFolder>
	{

		public BaseItemInFolder_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: BaseItemInFolder_BaseEventsProcess

	public partial class BaseItemInFolder_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: BaseItemInFolderEventsProcess

	/// <exclude/>
	public class BaseItemInFolderEventsProcess : BaseItemInFolder_BaseEventsProcess
	{

		public BaseItemInFolderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

