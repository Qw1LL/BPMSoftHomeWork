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

	#region Class: MLModelFileSchema

	/// <exclude/>
	public class MLModelFileSchema : BPMSoft.Configuration.FileSchema
	{

		#region Constructors: Public

		public MLModelFileSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public MLModelFileSchema(MLModelFileSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public MLModelFileSchema(MLModelFileSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("7643bb57-97db-4f29-bf80-179c5da1a3f1");
			RealUId = new Guid("7643bb57-97db-4f29-bf80-179c5da1a3f1");
			Name = "MLModelFile";
			ParentSchemaUId = new Guid("556c5867-60a7-4456-aae1-a57a122bef70");
			ExtendParent = false;
			CreatedInPackageId = new Guid("33c09d4f-db5e-4d77-bac6-f1fd801beedb");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("d88070fd-852f-4451-9d38-768f0f038867")) == null) {
				Columns.Add(CreateMLModelColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateMLModelColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("d88070fd-852f-4451-9d38-768f0f038867"),
				Name = @"MLModel",
				ReferenceSchemaUId = new Guid("f0d58f4a-303d-477c-8cf9-d00eaf04f32b"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("7643bb57-97db-4f29-bf80-179c5da1a3f1"),
				ModifiedInSchemaUId = new Guid("7643bb57-97db-4f29-bf80-179c5da1a3f1"),
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
			return new MLModelFile(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new MLModelFile_MLEventsProcess(userConnection);
		}

		public override object Clone() {
			return new MLModelFileSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new MLModelFileSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("7643bb57-97db-4f29-bf80-179c5da1a3f1"));
		}

		#endregion

	}

	#endregion

	#region Class: MLModelFile

	/// <summary>
	/// ML model attachment.
	/// </summary>
	public class MLModelFile : BPMSoft.Configuration.File
	{

		#region Constructors: Public

		public MLModelFile(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "MLModelFile";
		}

		public MLModelFile(MLModelFile source)
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
			var process = new MLModelFile_MLEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("MLModelFileDeleted", e);
			Updated += (s, e) => ThrowEvent("MLModelFileUpdated", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new MLModelFile(this);
		}

		#endregion

	}

	#endregion

	#region Class: MLModelFile_MLEventsProcess

	/// <exclude/>
	public partial class MLModelFile_MLEventsProcess<TEntity> : BPMSoft.Configuration.File_PRMPortalEventsProcess<TEntity> where TEntity : MLModelFile
	{

		public MLModelFile_MLEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "MLModelFile_MLEventsProcess";
			SchemaUId = new Guid("7643bb57-97db-4f29-bf80-179c5da1a3f1");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("7643bb57-97db-4f29-bf80-179c5da1a3f1");
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

	#region Class: MLModelFile_MLEventsProcess

	/// <exclude/>
	public class MLModelFile_MLEventsProcess : MLModelFile_MLEventsProcess<MLModelFile>
	{

		public MLModelFile_MLEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: MLModelFile_MLEventsProcess

	public partial class MLModelFile_MLEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: MLModelFileEventsProcess

	/// <exclude/>
	public class MLModelFileEventsProcess : MLModelFile_MLEventsProcess
	{

		public MLModelFileEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

