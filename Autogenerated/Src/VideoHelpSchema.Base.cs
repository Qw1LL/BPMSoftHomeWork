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

	#region Class: VideoHelpSchema

	/// <exclude/>
	public class VideoHelpSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public VideoHelpSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VideoHelpSchema(VideoHelpSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VideoHelpSchema(VideoHelpSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("66b8a34c-fc3d-4950-adcf-2a44cc8e455b");
			RealUId = new Guid("66b8a34c-fc3d-4950-adcf-2a44cc8e455b");
			Name = "VideoHelp";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("c12211f7-6342-4ca3-969a-908e3232a9cc")) == null) {
				Columns.Add(CreateHelpContextIdColumn());
			}
			if (Columns.FindByUId(new Guid("87009f4d-8af9-4813-8179-28b579187805")) == null) {
				Columns.Add(CreateVideoCodeColumn());
			}
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("66b8a34c-fc3d-4950-adcf-2a44cc8e455b");
			column.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("66b8a34c-fc3d-4950-adcf-2a44cc8e455b");
			column.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			return column;
		}

		protected virtual EntitySchemaColumn CreateHelpContextIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("c12211f7-6342-4ca3-969a-908e3232a9cc"),
				Name = @"HelpContextId",
				CreatedInSchemaUId = new Guid("66b8a34c-fc3d-4950-adcf-2a44cc8e455b"),
				ModifiedInSchemaUId = new Guid("66b8a34c-fc3d-4950-adcf-2a44cc8e455b"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateVideoCodeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("87009f4d-8af9-4813-8179-28b579187805"),
				Name = @"VideoCode",
				CreatedInSchemaUId = new Guid("66b8a34c-fc3d-4950-adcf-2a44cc8e455b"),
				ModifiedInSchemaUId = new Guid("66b8a34c-fc3d-4950-adcf-2a44cc8e455b"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new VideoHelp(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VideoHelp_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VideoHelpSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VideoHelpSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("66b8a34c-fc3d-4950-adcf-2a44cc8e455b"));
		}

		#endregion

	}

	#endregion

	#region Class: VideoHelp

	/// <summary>
	/// Video tutorial.
	/// </summary>
	public class VideoHelp : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public VideoHelp(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VideoHelp";
		}

		public VideoHelp(VideoHelp source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Contextual help Id.
		/// </summary>
		public string HelpContextId {
			get {
				return GetTypedColumnValue<string>("HelpContextId");
			}
			set {
				SetColumnValue("HelpContextId", value);
			}
		}

		/// <summary>
		/// Video tutorial code.
		/// </summary>
		public string VideoCode {
			get {
				return GetTypedColumnValue<string>("VideoCode");
			}
			set {
				SetColumnValue("VideoCode", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new VideoHelp_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("VideoHelpDeleted", e);
			Inserting += (s, e) => ThrowEvent("VideoHelpInserting", e);
			Validating += (s, e) => ThrowEvent("VideoHelpValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new VideoHelp(this);
		}

		#endregion

	}

	#endregion

	#region Class: VideoHelp_BaseEventsProcess

	/// <exclude/>
	public partial class VideoHelp_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : VideoHelp
	{

		public VideoHelp_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VideoHelp_BaseEventsProcess";
			SchemaUId = new Guid("66b8a34c-fc3d-4950-adcf-2a44cc8e455b");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("66b8a34c-fc3d-4950-adcf-2a44cc8e455b");
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

	#region Class: VideoHelp_BaseEventsProcess

	/// <exclude/>
	public class VideoHelp_BaseEventsProcess : VideoHelp_BaseEventsProcess<VideoHelp>
	{

		public VideoHelp_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VideoHelp_BaseEventsProcess

	public partial class VideoHelp_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: VideoHelpEventsProcess

	/// <exclude/>
	public class VideoHelpEventsProcess : VideoHelp_BaseEventsProcess
	{

		public VideoHelpEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

