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

	#region Class: FileImportParametersSchema

	/// <exclude/>
	public class FileImportParametersSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public FileImportParametersSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public FileImportParametersSchema(FileImportParametersSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public FileImportParametersSchema(FileImportParametersSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("5706d121-64c5-4c09-a4a3-ee6e82c47e1a");
			RealUId = new Guid("5706d121-64c5-4c09-a4a3-ee6e82c47e1a");
			Name = "FileImportParameters";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("a1dbb834-2aaa-477e-9c5c-90a41c321589")) == null) {
				Columns.Add(CreateImportParametersColumn());
			}
			if (Columns.FindByUId(new Guid("3e6cfbb3-6df0-435a-aa33-6ccde3ebaf21")) == null) {
				Columns.Add(CreateImportEntitiesColumn());
			}
			if (Columns.FindByUId(new Guid("f188489e-f20b-459f-9a3e-7a24f88889fc")) == null) {
				Columns.Add(CreateStageColumn());
			}
			if (Columns.FindByUId(new Guid("baff0d99-eaa1-432c-8e5f-309182d9df13")) == null) {
				Columns.Add(CreateFileDataColumn());
			}
			if (Columns.FindByUId(new Guid("bc6d22d5-2f36-43dd-8732-2d2b3844dfbb")) == null) {
				Columns.Add(CreateSizeColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateImportParametersColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Binary")) {
				UId = new Guid("a1dbb834-2aaa-477e-9c5c-90a41c321589"),
				Name = @"ImportParameters",
				CreatedInSchemaUId = new Guid("5706d121-64c5-4c09-a4a3-ee6e82c47e1a"),
				ModifiedInSchemaUId = new Guid("5706d121-64c5-4c09-a4a3-ee6e82c47e1a"),
				CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8")
			};
		}

		protected virtual EntitySchemaColumn CreateImportEntitiesColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Binary")) {
				UId = new Guid("3e6cfbb3-6df0-435a-aa33-6ccde3ebaf21"),
				Name = @"ImportEntities",
				CreatedInSchemaUId = new Guid("5706d121-64c5-4c09-a4a3-ee6e82c47e1a"),
				ModifiedInSchemaUId = new Guid("5706d121-64c5-4c09-a4a3-ee6e82c47e1a"),
				CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8")
			};
		}

		protected virtual EntitySchemaColumn CreateStageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("f188489e-f20b-459f-9a3e-7a24f88889fc"),
				Name = @"Stage",
				CreatedInSchemaUId = new Guid("5706d121-64c5-4c09-a4a3-ee6e82c47e1a"),
				ModifiedInSchemaUId = new Guid("5706d121-64c5-4c09-a4a3-ee6e82c47e1a"),
				CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8")
			};
		}

		protected virtual EntitySchemaColumn CreateFileDataColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Binary")) {
				UId = new Guid("baff0d99-eaa1-432c-8e5f-309182d9df13"),
				Name = @"FileData",
				CreatedInSchemaUId = new Guid("5706d121-64c5-4c09-a4a3-ee6e82c47e1a"),
				ModifiedInSchemaUId = new Guid("5706d121-64c5-4c09-a4a3-ee6e82c47e1a"),
				CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8")
			};
		}

		protected virtual EntitySchemaColumn CreateSizeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("bc6d22d5-2f36-43dd-8732-2d2b3844dfbb"),
				Name = @"Size",
				CreatedInSchemaUId = new Guid("5706d121-64c5-4c09-a4a3-ee6e82c47e1a"),
				ModifiedInSchemaUId = new Guid("5706d121-64c5-4c09-a4a3-ee6e82c47e1a"),
				CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new FileImportParameters(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new FileImportParameters_FileImportEventsProcess(userConnection);
		}

		public override object Clone() {
			return new FileImportParametersSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new FileImportParametersSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("5706d121-64c5-4c09-a4a3-ee6e82c47e1a"));
		}

		#endregion

	}

	#endregion

	#region Class: FileImportParameters

	/// <summary>
	/// FileImportParameters.
	/// </summary>
	public class FileImportParameters : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public FileImportParameters(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "FileImportParameters";
		}

		public FileImportParameters(FileImportParameters source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Stage.
		/// </summary>
		public int Stage {
			get {
				return GetTypedColumnValue<int>("Stage");
			}
			set {
				SetColumnValue("Stage", value);
			}
		}

		/// <summary>
		/// File size.
		/// </summary>
		public int Size {
			get {
				return GetTypedColumnValue<int>("Size");
			}
			set {
				SetColumnValue("Size", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new FileImportParameters_FileImportEventsProcess(UserConnection);
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
			return new FileImportParameters(this);
		}

		#endregion

	}

	#endregion

	#region Class: FileImportParameters_FileImportEventsProcess

	/// <exclude/>
	public partial class FileImportParameters_FileImportEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : FileImportParameters
	{

		public FileImportParameters_FileImportEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "FileImportParameters_FileImportEventsProcess";
			SchemaUId = new Guid("5706d121-64c5-4c09-a4a3-ee6e82c47e1a");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("5706d121-64c5-4c09-a4a3-ee6e82c47e1a");
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

	#region Class: FileImportParameters_FileImportEventsProcess

	/// <exclude/>
	public class FileImportParameters_FileImportEventsProcess : FileImportParameters_FileImportEventsProcess<FileImportParameters>
	{

		public FileImportParameters_FileImportEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: FileImportParameters_FileImportEventsProcess

	public partial class FileImportParameters_FileImportEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: FileImportParametersEventsProcess

	/// <exclude/>
	public class FileImportParametersEventsProcess : FileImportParameters_FileImportEventsProcess
	{

		public FileImportParametersEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

