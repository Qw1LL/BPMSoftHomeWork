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

	#region Class: MLModelInFolderSchema

	/// <exclude/>
	public class MLModelInFolderSchema : BPMSoft.Configuration.BaseItemInFolderSchema
	{

		#region Constructors: Public

		public MLModelInFolderSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public MLModelInFolderSchema(MLModelInFolderSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public MLModelInFolderSchema(MLModelInFolderSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("c86aaf44-c80b-49fc-9470-78d94f26bbe6");
			RealUId = new Guid("c86aaf44-c80b-49fc-9470-78d94f26bbe6");
			Name = "MLModelInFolder";
			ParentSchemaUId = new Guid("4f63bafb-e9e7-4082-b92e-66b97c14017c");
			ExtendParent = false;
			CreatedInPackageId = new Guid("33c09d4f-db5e-4d77-bac6-f1fd801beedb");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("90fe80a4-4e17-4f58-9a1c-e7fc3e0ba339")) == null) {
				Columns.Add(CreateMLModelColumn());
			}
		}

		protected override EntitySchemaColumn CreateFolderColumn() {
			EntitySchemaColumn column = base.CreateFolderColumn();
			column.ReferenceSchemaUId = new Guid("1501a9bd-5820-480d-9869-5bd630310744");
			column.ColumnValueName = @"FolderId";
			column.DisplayColumnValueName = @"FolderName";
			column.ModifiedInSchemaUId = new Guid("c86aaf44-c80b-49fc-9470-78d94f26bbe6");
			return column;
		}

		protected virtual EntitySchemaColumn CreateMLModelColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("90fe80a4-4e17-4f58-9a1c-e7fc3e0ba339"),
				Name = @"MLModel",
				ReferenceSchemaUId = new Guid("f0d58f4a-303d-477c-8cf9-d00eaf04f32b"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("c86aaf44-c80b-49fc-9470-78d94f26bbe6"),
				ModifiedInSchemaUId = new Guid("c86aaf44-c80b-49fc-9470-78d94f26bbe6"),
				CreatedInPackageId = new Guid("33c09d4f-db5e-4d77-bac6-f1fd801beedb")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new MLModelInFolder(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new MLModelInFolder_MLEventsProcess(userConnection);
		}

		public override object Clone() {
			return new MLModelInFolderSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new MLModelInFolderSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("c86aaf44-c80b-49fc-9470-78d94f26bbe6"));
		}

		#endregion

	}

	#endregion

	#region Class: MLModelInFolder

	/// <summary>
	/// ML model in folder.
	/// </summary>
	public class MLModelInFolder : BPMSoft.Configuration.BaseItemInFolder
	{

		#region Constructors: Public

		public MLModelInFolder(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "MLModelInFolder";
		}

		public MLModelInFolder(MLModelInFolder source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid MLModelId {
			get {
				return GetTypedColumnValue<Guid>("MLModelId");
			}
			set {
				SetColumnValue("MLModelId", value);
				_mLModel = null;
			}
		}

		/// <exclude/>
		public string MLModelName {
			get {
				return GetTypedColumnValue<string>("MLModelName");
			}
			set {
				SetColumnValue("MLModelName", value);
				if (_mLModel != null) {
					_mLModel.Name = value;
				}
			}
		}

		private MLModel _mLModel;
		/// <summary>
		/// ML model.
		/// </summary>
		public MLModel MLModel {
			get {
				return _mLModel ??
					(_mLModel = LookupColumnEntities.GetEntity("MLModel") as MLModel);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new MLModelInFolder_MLEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("MLModelInFolderDeleted", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new MLModelInFolder(this);
		}

		#endregion

	}

	#endregion

	#region Class: MLModelInFolder_MLEventsProcess

	/// <exclude/>
	public partial class MLModelInFolder_MLEventsProcess<TEntity> : BPMSoft.Configuration.BaseItemInFolder_BaseEventsProcess<TEntity> where TEntity : MLModelInFolder
	{

		public MLModelInFolder_MLEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "MLModelInFolder_MLEventsProcess";
			SchemaUId = new Guid("c86aaf44-c80b-49fc-9470-78d94f26bbe6");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("c86aaf44-c80b-49fc-9470-78d94f26bbe6");
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

	#region Class: MLModelInFolder_MLEventsProcess

	/// <exclude/>
	public class MLModelInFolder_MLEventsProcess : MLModelInFolder_MLEventsProcess<MLModelInFolder>
	{

		public MLModelInFolder_MLEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: MLModelInFolder_MLEventsProcess

	public partial class MLModelInFolder_MLEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: MLModelInFolderEventsProcess

	/// <exclude/>
	public class MLModelInFolderEventsProcess : MLModelInFolder_MLEventsProcess
	{

		public MLModelInFolderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

