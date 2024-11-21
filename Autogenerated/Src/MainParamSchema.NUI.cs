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

	#region Class: MainParamSchema

	/// <exclude/>
	public class MainParamSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public MainParamSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public MainParamSchema(MainParamSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public MainParamSchema(MainParamSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("28f7da1a-3f4d-4f2d-9d25-75c965cded5d");
			RealUId = new Guid("28f7da1a-3f4d-4f2d-9d25-75c965cded5d");
			Name = "MainParam";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("f40d6a1a-215d-4fa4-bb06-ad44d6a4b01f");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateNameColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("32e111d0-a592-4525-9b44-d4620e2c9587")) == null) {
				Columns.Add(CreateSubjectSchemaUIdColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("28f7da1a-3f4d-4f2d-9d25-75c965cded5d");
			column.CreatedInPackageId = new Guid("f40d6a1a-215d-4fa4-bb06-ad44d6a4b01f");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("28f7da1a-3f4d-4f2d-9d25-75c965cded5d");
			column.CreatedInPackageId = new Guid("f40d6a1a-215d-4fa4-bb06-ad44d6a4b01f");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("28f7da1a-3f4d-4f2d-9d25-75c965cded5d");
			column.CreatedInPackageId = new Guid("f40d6a1a-215d-4fa4-bb06-ad44d6a4b01f");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("28f7da1a-3f4d-4f2d-9d25-75c965cded5d");
			column.CreatedInPackageId = new Guid("f40d6a1a-215d-4fa4-bb06-ad44d6a4b01f");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("28f7da1a-3f4d-4f2d-9d25-75c965cded5d");
			column.CreatedInPackageId = new Guid("f40d6a1a-215d-4fa4-bb06-ad44d6a4b01f");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("28f7da1a-3f4d-4f2d-9d25-75c965cded5d");
			column.CreatedInPackageId = new Guid("f40d6a1a-215d-4fa4-bb06-ad44d6a4b01f");
			return column;
		}

		protected virtual EntitySchemaColumn CreateSubjectSchemaUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("32e111d0-a592-4525-9b44-d4620e2c9587"),
				Name = @"SubjectSchemaUId",
				CreatedInSchemaUId = new Guid("28f7da1a-3f4d-4f2d-9d25-75c965cded5d"),
				ModifiedInSchemaUId = new Guid("28f7da1a-3f4d-4f2d-9d25-75c965cded5d"),
				CreatedInPackageId = new Guid("f40d6a1a-215d-4fa4-bb06-ad44d6a4b01f")
			};
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("b712ca3e-9821-4e10-91d1-0e3544d5b749"),
				Name = @"Name",
				CreatedInSchemaUId = new Guid("28f7da1a-3f4d-4f2d-9d25-75c965cded5d"),
				ModifiedInSchemaUId = new Guid("28f7da1a-3f4d-4f2d-9d25-75c965cded5d"),
				CreatedInPackageId = new Guid("f40d6a1a-215d-4fa4-bb06-ad44d6a4b01f"),
				IsLocalizable = true
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new MainParam(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new MainParam_NUIEventsProcess(userConnection);
		}

		public override object Clone() {
			return new MainParamSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new MainParamSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("28f7da1a-3f4d-4f2d-9d25-75c965cded5d"));
		}

		#endregion

	}

	#endregion

	#region Class: MainParam

	/// <summary>
	/// Primary parameter of command line.
	/// </summary>
	public class MainParam : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public MainParam(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "MainParam";
		}

		public MainParam(MainParam source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

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

		/// <summary>
		/// Primary parameter.
		/// </summary>
		public string Name {
			get {
				return GetTypedColumnValue<string>("Name");
			}
			set {
				SetColumnValue("Name", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new MainParam_NUIEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("MainParamDeleted", e);
			Inserting += (s, e) => ThrowEvent("MainParamInserting", e);
			Validating += (s, e) => ThrowEvent("MainParamValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new MainParam(this);
		}

		#endregion

	}

	#endregion

	#region Class: MainParam_NUIEventsProcess

	/// <exclude/>
	public partial class MainParam_NUIEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : MainParam
	{

		public MainParam_NUIEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "MainParam_NUIEventsProcess";
			SchemaUId = new Guid("28f7da1a-3f4d-4f2d-9d25-75c965cded5d");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("28f7da1a-3f4d-4f2d-9d25-75c965cded5d");
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

	#region Class: MainParam_NUIEventsProcess

	/// <exclude/>
	public class MainParam_NUIEventsProcess : MainParam_NUIEventsProcess<MainParam>
	{

		public MainParam_NUIEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: MainParam_NUIEventsProcess

	public partial class MainParam_NUIEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: MainParamEventsProcess

	/// <exclude/>
	public class MainParamEventsProcess : MainParam_NUIEventsProcess
	{

		public MainParamEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

