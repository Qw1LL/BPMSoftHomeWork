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

	#region Class: AdditionalParamSchema

	/// <exclude/>
	public class AdditionalParamSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public AdditionalParamSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public AdditionalParamSchema(AdditionalParamSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public AdditionalParamSchema(AdditionalParamSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("d066f42d-ebdf-4672-b739-e506edba751b");
			RealUId = new Guid("d066f42d-ebdf-4672-b739-e506edba751b");
			Name = "AdditionalParam";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("f40d6a1a-215d-4fa4-bb06-ad44d6a4b01f");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateColumnCaptionColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("fcf623a4-5a83-4315-82f5-c4a69e0846af")) == null) {
				Columns.Add(CreateSubjectColumnUIdColumn());
			}
			if (Columns.FindByUId(new Guid("d46b7714-0da0-4977-9f70-84c67f8793dc")) == null) {
				Columns.Add(CreateSubjectSchemaUIdColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("d066f42d-ebdf-4672-b739-e506edba751b");
			column.CreatedInPackageId = new Guid("f40d6a1a-215d-4fa4-bb06-ad44d6a4b01f");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("d066f42d-ebdf-4672-b739-e506edba751b");
			column.CreatedInPackageId = new Guid("f40d6a1a-215d-4fa4-bb06-ad44d6a4b01f");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("d066f42d-ebdf-4672-b739-e506edba751b");
			column.CreatedInPackageId = new Guid("f40d6a1a-215d-4fa4-bb06-ad44d6a4b01f");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("d066f42d-ebdf-4672-b739-e506edba751b");
			column.CreatedInPackageId = new Guid("f40d6a1a-215d-4fa4-bb06-ad44d6a4b01f");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("d066f42d-ebdf-4672-b739-e506edba751b");
			column.CreatedInPackageId = new Guid("f40d6a1a-215d-4fa4-bb06-ad44d6a4b01f");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("d066f42d-ebdf-4672-b739-e506edba751b");
			column.CreatedInPackageId = new Guid("f40d6a1a-215d-4fa4-bb06-ad44d6a4b01f");
			return column;
		}

		protected virtual EntitySchemaColumn CreateSubjectColumnUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("fcf623a4-5a83-4315-82f5-c4a69e0846af"),
				Name = @"SubjectColumnUId",
				CreatedInSchemaUId = new Guid("d066f42d-ebdf-4672-b739-e506edba751b"),
				ModifiedInSchemaUId = new Guid("d066f42d-ebdf-4672-b739-e506edba751b"),
				CreatedInPackageId = new Guid("f40d6a1a-215d-4fa4-bb06-ad44d6a4b01f")
			};
		}

		protected virtual EntitySchemaColumn CreateColumnCaptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("eebe8b0c-7eb9-4fa0-97dc-03f64aa07e7e"),
				Name = @"ColumnCaption",
				CreatedInSchemaUId = new Guid("d066f42d-ebdf-4672-b739-e506edba751b"),
				ModifiedInSchemaUId = new Guid("d066f42d-ebdf-4672-b739-e506edba751b"),
				CreatedInPackageId = new Guid("f40d6a1a-215d-4fa4-bb06-ad44d6a4b01f"),
				IsLocalizable = true
			};
		}

		protected virtual EntitySchemaColumn CreateSubjectSchemaUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("d46b7714-0da0-4977-9f70-84c67f8793dc"),
				Name = @"SubjectSchemaUId",
				CreatedInSchemaUId = new Guid("d066f42d-ebdf-4672-b739-e506edba751b"),
				ModifiedInSchemaUId = new Guid("d066f42d-ebdf-4672-b739-e506edba751b"),
				CreatedInPackageId = new Guid("f40d6a1a-215d-4fa4-bb06-ad44d6a4b01f")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new AdditionalParam(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new AdditionalParam_NUIEventsProcess(userConnection);
		}

		public override object Clone() {
			return new AdditionalParamSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new AdditionalParamSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("d066f42d-ebdf-4672-b739-e506edba751b"));
		}

		#endregion

	}

	#endregion

	#region Class: AdditionalParam

	/// <summary>
	/// Additional parameter of control string.
	/// </summary>
	public class AdditionalParam : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public AdditionalParam(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "AdditionalParam";
		}

		public AdditionalParam(AdditionalParam source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Unique identifier of schema column in workspace.
		/// </summary>
		public Guid SubjectColumnUId {
			get {
				return GetTypedColumnValue<Guid>("SubjectColumnUId");
			}
			set {
				SetColumnValue("SubjectColumnUId", value);
			}
		}

		/// <summary>
		/// Column caption.
		/// </summary>
		public string ColumnCaption {
			get {
				return GetTypedColumnValue<string>("ColumnCaption");
			}
			set {
				SetColumnValue("ColumnCaption", value);
			}
		}

		/// <summary>
		/// Unique identifier of schema in workspace.
		/// </summary>
		public Guid SubjectSchemaUId {
			get {
				return GetTypedColumnValue<Guid>("SubjectSchemaUId");
			}
			set {
				SetColumnValue("SubjectSchemaUId", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new AdditionalParam_NUIEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("AdditionalParamDeleted", e);
			Inserting += (s, e) => ThrowEvent("AdditionalParamInserting", e);
			Validating += (s, e) => ThrowEvent("AdditionalParamValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new AdditionalParam(this);
		}

		#endregion

	}

	#endregion

	#region Class: AdditionalParam_NUIEventsProcess

	/// <exclude/>
	public partial class AdditionalParam_NUIEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : AdditionalParam
	{

		public AdditionalParam_NUIEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "AdditionalParam_NUIEventsProcess";
			SchemaUId = new Guid("d066f42d-ebdf-4672-b739-e506edba751b");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("d066f42d-ebdf-4672-b739-e506edba751b");
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

	#region Class: AdditionalParam_NUIEventsProcess

	/// <exclude/>
	public class AdditionalParam_NUIEventsProcess : AdditionalParam_NUIEventsProcess<AdditionalParam>
	{

		public AdditionalParam_NUIEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: AdditionalParam_NUIEventsProcess

	public partial class AdditionalParam_NUIEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: AdditionalParamEventsProcess

	/// <exclude/>
	public class AdditionalParamEventsProcess : AdditionalParam_NUIEventsProcess
	{

		public AdditionalParamEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

