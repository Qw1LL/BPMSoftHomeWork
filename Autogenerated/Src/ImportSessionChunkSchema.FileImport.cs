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

	#region Class: ImportSessionChunkSchema

	/// <exclude/>
	public class ImportSessionChunkSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public ImportSessionChunkSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ImportSessionChunkSchema(ImportSessionChunkSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ImportSessionChunkSchema(ImportSessionChunkSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("573c37a8-74f2-4cba-b256-3a4b87b625e7");
			RealUId = new Guid("573c37a8-74f2-4cba-b256-3a4b87b625e7");
			Name = "ImportSessionChunk";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("26a2a19e-2d5f-44fb-bbfa-6a5fa78e9942")) == null) {
				Columns.Add(CreateTypeColumn());
			}
			if (Columns.FindByUId(new Guid("1c68b0b3-1bea-4817-af7c-5d19e0a7910d")) == null) {
				Columns.Add(CreateStateColumn());
			}
			if (Columns.FindByUId(new Guid("b7b5f0b3-b065-47c2-9c36-059090ecc7f7")) == null) {
				Columns.Add(CreateDataColumn());
			}
			if (Columns.FindByUId(new Guid("33f2cc01-d286-48a9-b262-b721333fbec6")) == null) {
				Columns.Add(CreateImportParametersColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("26a2a19e-2d5f-44fb-bbfa-6a5fa78e9942"),
				Name = @"Type",
				CreatedInSchemaUId = new Guid("573c37a8-74f2-4cba-b256-3a4b87b625e7"),
				ModifiedInSchemaUId = new Guid("573c37a8-74f2-4cba-b256-3a4b87b625e7"),
				CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8")
			};
		}

		protected virtual EntitySchemaColumn CreateStateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("1c68b0b3-1bea-4817-af7c-5d19e0a7910d"),
				Name = @"State",
				CreatedInSchemaUId = new Guid("573c37a8-74f2-4cba-b256-3a4b87b625e7"),
				ModifiedInSchemaUId = new Guid("573c37a8-74f2-4cba-b256-3a4b87b625e7"),
				CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8")
			};
		}

		protected virtual EntitySchemaColumn CreateDataColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Binary")) {
				UId = new Guid("b7b5f0b3-b065-47c2-9c36-059090ecc7f7"),
				Name = @"Data",
				CreatedInSchemaUId = new Guid("573c37a8-74f2-4cba-b256-3a4b87b625e7"),
				ModifiedInSchemaUId = new Guid("573c37a8-74f2-4cba-b256-3a4b87b625e7"),
				CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8")
			};
		}

		protected virtual EntitySchemaColumn CreateImportParametersColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("33f2cc01-d286-48a9-b262-b721333fbec6"),
				Name = @"ImportParameters",
				ReferenceSchemaUId = new Guid("5706d121-64c5-4c09-a4a3-ee6e82c47e1a"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("573c37a8-74f2-4cba-b256-3a4b87b625e7"),
				ModifiedInSchemaUId = new Guid("573c37a8-74f2-4cba-b256-3a4b87b625e7"),
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
			return new ImportSessionChunk(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ImportSessionChunk_FileImportEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ImportSessionChunkSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ImportSessionChunkSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("573c37a8-74f2-4cba-b256-3a4b87b625e7"));
		}

		#endregion

	}

	#endregion

	#region Class: ImportSessionChunk

	/// <summary>
	/// ImportSessionChunk.
	/// </summary>
	/// <remarks>
	/// Import session chunks.
	/// </remarks>
	public class ImportSessionChunk : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public ImportSessionChunk(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ImportSessionChunk";
		}

		public ImportSessionChunk(ImportSessionChunk source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Type.
		/// </summary>
		/// <remarks>
		/// Chunk data type.
		/// </remarks>
		public int Type {
			get {
				return GetTypedColumnValue<int>("Type");
			}
			set {
				SetColumnValue("Type", value);
			}
		}

		/// <summary>
		/// State.
		/// </summary>
		/// <remarks>
		/// Chunk state.
		/// </remarks>
		public int State {
			get {
				return GetTypedColumnValue<int>("State");
			}
			set {
				SetColumnValue("State", value);
			}
		}

		/// <exclude/>
		public Guid ImportParametersId {
			get {
				return GetTypedColumnValue<Guid>("ImportParametersId");
			}
			set {
				SetColumnValue("ImportParametersId", value);
				_importParameters = null;
			}
		}

		private FileImportParameters _importParameters;
		/// <summary>
		/// ImportParameters.
		/// </summary>
		public FileImportParameters ImportParameters {
			get {
				return _importParameters ??
					(_importParameters = LookupColumnEntities.GetEntity("ImportParameters") as FileImportParameters);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ImportSessionChunk_FileImportEventsProcess(UserConnection);
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
			return new ImportSessionChunk(this);
		}

		#endregion

	}

	#endregion

	#region Class: ImportSessionChunk_FileImportEventsProcess

	/// <exclude/>
	public partial class ImportSessionChunk_FileImportEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : ImportSessionChunk
	{

		public ImportSessionChunk_FileImportEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ImportSessionChunk_FileImportEventsProcess";
			SchemaUId = new Guid("573c37a8-74f2-4cba-b256-3a4b87b625e7");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("573c37a8-74f2-4cba-b256-3a4b87b625e7");
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

	#region Class: ImportSessionChunk_FileImportEventsProcess

	/// <exclude/>
	public class ImportSessionChunk_FileImportEventsProcess : ImportSessionChunk_FileImportEventsProcess<ImportSessionChunk>
	{

		public ImportSessionChunk_FileImportEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ImportSessionChunk_FileImportEventsProcess

	public partial class ImportSessionChunk_FileImportEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ImportSessionChunkEventsProcess

	/// <exclude/>
	public class ImportSessionChunkEventsProcess : ImportSessionChunk_FileImportEventsProcess
	{

		public ImportSessionChunkEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

