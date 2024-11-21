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

	#region Class: MLErrorSchema

	/// <exclude/>
	public class MLErrorSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public MLErrorSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public MLErrorSchema(MLErrorSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public MLErrorSchema(MLErrorSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("5a70e822-669a-47a7-b8a5-83191cf3b03d");
			RealUId = new Guid("5a70e822-669a-47a7-b8a5-83191cf3b03d");
			Name = "MLError";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("af6855a9-540e-4dfd-8027-5020b1fe29bd");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreatePatternColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("71fe1436-7f1a-ff7b-f3c9-3f9357a93d18")) == null) {
				Columns.Add(CreateTextColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateTextColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("71fe1436-7f1a-ff7b-f3c9-3f9357a93d18"),
				Name = @"Text",
				CreatedInSchemaUId = new Guid("5a70e822-669a-47a7-b8a5-83191cf3b03d"),
				ModifiedInSchemaUId = new Guid("5a70e822-669a-47a7-b8a5-83191cf3b03d"),
				CreatedInPackageId = new Guid("af6855a9-540e-4dfd-8027-5020b1fe29bd"),
				IsMultiLineText = true,
				IsLocalizable = true
			};
		}

		protected virtual EntitySchemaColumn CreatePatternColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("9e930f8d-a510-b829-eae6-a64b81e9e203"),
				Name = @"Pattern",
				CreatedInSchemaUId = new Guid("5a70e822-669a-47a7-b8a5-83191cf3b03d"),
				ModifiedInSchemaUId = new Guid("5a70e822-669a-47a7-b8a5-83191cf3b03d"),
				CreatedInPackageId = new Guid("af6855a9-540e-4dfd-8027-5020b1fe29bd")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new MLError(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new MLError_MLBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new MLErrorSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new MLErrorSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("5a70e822-669a-47a7-b8a5-83191cf3b03d"));
		}

		#endregion

	}

	#endregion

	#region Class: MLError

	/// <summary>
	/// MLError.
	/// </summary>
	public class MLError : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public MLError(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "MLError";
		}

		public MLError(MLError source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Text.
		/// </summary>
		public string Text {
			get {
				return GetTypedColumnValue<string>("Text");
			}
			set {
				SetColumnValue("Text", value);
			}
		}

		/// <summary>
		/// Pattern.
		/// </summary>
		public string Pattern {
			get {
				return GetTypedColumnValue<string>("Pattern");
			}
			set {
				SetColumnValue("Pattern", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new MLError_MLBaseEventsProcess(UserConnection);
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
			return new MLError(this);
		}

		#endregion

	}

	#endregion

	#region Class: MLError_MLBaseEventsProcess

	/// <exclude/>
	public partial class MLError_MLBaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : MLError
	{

		public MLError_MLBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "MLError_MLBaseEventsProcess";
			SchemaUId = new Guid("5a70e822-669a-47a7-b8a5-83191cf3b03d");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("5a70e822-669a-47a7-b8a5-83191cf3b03d");
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

	#region Class: MLError_MLBaseEventsProcess

	/// <exclude/>
	public class MLError_MLBaseEventsProcess : MLError_MLBaseEventsProcess<MLError>
	{

		public MLError_MLBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: MLError_MLBaseEventsProcess

	public partial class MLError_MLBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: MLErrorEventsProcess

	/// <exclude/>
	public class MLErrorEventsProcess : MLError_MLBaseEventsProcess
	{

		public MLErrorEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

