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

	#region Class: Document_DocumentInProject_BPMSoftSchema

	/// <exclude/>
	public class Document_DocumentInProject_BPMSoftSchema : BPMSoft.Configuration.Document_DocumentInOrder_BPMSoftSchema
	{

		#region Constructors: Public

		public Document_DocumentInProject_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public Document_DocumentInProject_BPMSoftSchema(Document_DocumentInProject_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public Document_DocumentInProject_BPMSoftSchema(Document_DocumentInProject_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("42a66bd2-2130-44b9-8bc9-07fd4ee03ae0");
			Name = "Document_DocumentInProject_BPMSoft";
			ParentSchemaUId = new Guid("8b33b6b2-19f7-4222-9161-b4054b3fbb09");
			ExtendParent = true;
			CreatedInPackageId = new Guid("fe2bb0e4-061e-41b1-be85-5078c802043f");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("5a0652dd-c65f-404e-9967-ba5f17cdaf67")) == null) {
				Columns.Add(CreateProjectColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateProjectColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("5a0652dd-c65f-404e-9967-ba5f17cdaf67"),
				Name = @"Project",
				ReferenceSchemaUId = new Guid("a11d7fa4-9946-494c-ae41-2169844d29be"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("42a66bd2-2130-44b9-8bc9-07fd4ee03ae0"),
				ModifiedInSchemaUId = new Guid("42a66bd2-2130-44b9-8bc9-07fd4ee03ae0"),
				CreatedInPackageId = new Guid("fe2bb0e4-061e-41b1-be85-5078c802043f")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new Document_DocumentInProject_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Document_DocumentInProjectEventsProcess(userConnection);
		}

		public override object Clone() {
			return new Document_DocumentInProject_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new Document_DocumentInProject_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("42a66bd2-2130-44b9-8bc9-07fd4ee03ae0"));
		}

		#endregion

	}

	#endregion

	#region Class: Document_DocumentInProject_BPMSoft

	/// <summary>
	/// Документ.
	/// </summary>
	public class Document_DocumentInProject_BPMSoft : BPMSoft.Configuration.Document_DocumentInOrder_BPMSoft
	{

		#region Constructors: Public

		public Document_DocumentInProject_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Document_DocumentInProject_BPMSoft";
		}

		public Document_DocumentInProject_BPMSoft(Document_DocumentInProject_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid ProjectId {
			get {
				return GetTypedColumnValue<Guid>("ProjectId");
			}
			set {
				SetColumnValue("ProjectId", value);
				_project = null;
			}
		}

		/// <exclude/>
		public string ProjectName {
			get {
				return GetTypedColumnValue<string>("ProjectName");
			}
			set {
				SetColumnValue("ProjectName", value);
				if (_project != null) {
					_project.Name = value;
				}
			}
		}

		private Project _project;
		/// <summary>
		/// Проект.
		/// </summary>
		public Project Project {
			get {
				return _project ??
					(_project = LookupColumnEntities.GetEntity("Project") as Project);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Document_DocumentInProjectEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("Document_DocumentInProject_BPMSoftDeleted", e);
			Deleting += (s, e) => ThrowEvent("Document_DocumentInProject_BPMSoftDeleting", e);
			Inserted += (s, e) => ThrowEvent("Document_DocumentInProject_BPMSoftInserted", e);
			Inserting += (s, e) => ThrowEvent("Document_DocumentInProject_BPMSoftInserting", e);
			Saved += (s, e) => ThrowEvent("Document_DocumentInProject_BPMSoftSaved", e);
			Saving += (s, e) => ThrowEvent("Document_DocumentInProject_BPMSoftSaving", e);
			Validating += (s, e) => ThrowEvent("Document_DocumentInProject_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new Document_DocumentInProject_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: Document_DocumentInProjectEventsProcess

	/// <exclude/>
	public partial class Document_DocumentInProjectEventsProcess<TEntity> : BPMSoft.Configuration.Document_DocumentInOrderEventsProcess<TEntity> where TEntity : Document_DocumentInProject_BPMSoft
	{

		public Document_DocumentInProjectEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Document_DocumentInProjectEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("42a66bd2-2130-44b9-8bc9-07fd4ee03ae0");
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

	#region Class: Document_DocumentInProjectEventsProcess

	/// <exclude/>
	public class Document_DocumentInProjectEventsProcess : Document_DocumentInProjectEventsProcess<Document_DocumentInProject_BPMSoft>
	{

		public Document_DocumentInProjectEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: Document_DocumentInProjectEventsProcess

	public partial class Document_DocumentInProjectEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

