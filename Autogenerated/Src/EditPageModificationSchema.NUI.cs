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

	#region Class: EditPageModificationSchema

	/// <exclude/>
	public class EditPageModificationSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public EditPageModificationSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public EditPageModificationSchema(EditPageModificationSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public EditPageModificationSchema(EditPageModificationSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("af25bf86-7f6d-44cc-a9ee-085e1bb737d3");
			RealUId = new Guid("af25bf86-7f6d-44cc-a9ee-085e1bb737d3");
			Name = "EditPageModification";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("5fe850f8-633f-4f49-b171-3760bb47e9da");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("d2208f83-bdfd-4190-b89d-739eaee71a53")) == null) {
				Columns.Add(CreateSerializedDataColumn());
			}
			if (Columns.FindByUId(new Guid("faa9faa7-0529-4e95-88f7-3137e89d229e")) == null) {
				Columns.Add(CreateEditPageNameColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("af25bf86-7f6d-44cc-a9ee-085e1bb737d3");
			column.CreatedInPackageId = new Guid("5fe850f8-633f-4f49-b171-3760bb47e9da");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("af25bf86-7f6d-44cc-a9ee-085e1bb737d3");
			column.CreatedInPackageId = new Guid("5fe850f8-633f-4f49-b171-3760bb47e9da");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("af25bf86-7f6d-44cc-a9ee-085e1bb737d3");
			column.CreatedInPackageId = new Guid("5fe850f8-633f-4f49-b171-3760bb47e9da");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("af25bf86-7f6d-44cc-a9ee-085e1bb737d3");
			column.CreatedInPackageId = new Guid("5fe850f8-633f-4f49-b171-3760bb47e9da");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("af25bf86-7f6d-44cc-a9ee-085e1bb737d3");
			column.CreatedInPackageId = new Guid("5fe850f8-633f-4f49-b171-3760bb47e9da");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("af25bf86-7f6d-44cc-a9ee-085e1bb737d3");
			column.CreatedInPackageId = new Guid("5fe850f8-633f-4f49-b171-3760bb47e9da");
			return column;
		}

		protected virtual EntitySchemaColumn CreateSerializedDataColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("d2208f83-bdfd-4190-b89d-739eaee71a53"),
				Name = @"SerializedData",
				CreatedInSchemaUId = new Guid("af25bf86-7f6d-44cc-a9ee-085e1bb737d3"),
				ModifiedInSchemaUId = new Guid("af25bf86-7f6d-44cc-a9ee-085e1bb737d3"),
				CreatedInPackageId = new Guid("5fe850f8-633f-4f49-b171-3760bb47e9da")
			};
		}

		protected virtual EntitySchemaColumn CreateEditPageNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("faa9faa7-0529-4e95-88f7-3137e89d229e"),
				Name = @"EditPageName",
				CreatedInSchemaUId = new Guid("af25bf86-7f6d-44cc-a9ee-085e1bb737d3"),
				ModifiedInSchemaUId = new Guid("af25bf86-7f6d-44cc-a9ee-085e1bb737d3"),
				CreatedInPackageId = new Guid("5fe850f8-633f-4f49-b171-3760bb47e9da")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new EditPageModification(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new EditPageModification_NUIEventsProcess(userConnection);
		}

		public override object Clone() {
			return new EditPageModificationSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new EditPageModificationSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("af25bf86-7f6d-44cc-a9ee-085e1bb737d3"));
		}

		#endregion

	}

	#endregion

	#region Class: EditPageModification

	/// <summary>
	/// Edit card modification object.
	/// </summary>
	public class EditPageModification : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public EditPageModification(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "EditPageModification";
		}

		public EditPageModification(EditPageModification source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Serialize data.
		/// </summary>
		public string SerializedData {
			get {
				return GetTypedColumnValue<string>("SerializedData");
			}
			set {
				SetColumnValue("SerializedData", value);
			}
		}

		/// <summary>
		/// Edit page name.
		/// </summary>
		public string EditPageName {
			get {
				return GetTypedColumnValue<string>("EditPageName");
			}
			set {
				SetColumnValue("EditPageName", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new EditPageModification_NUIEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("EditPageModificationDeleted", e);
			Inserting += (s, e) => ThrowEvent("EditPageModificationInserting", e);
			Validating += (s, e) => ThrowEvent("EditPageModificationValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new EditPageModification(this);
		}

		#endregion

	}

	#endregion

	#region Class: EditPageModification_NUIEventsProcess

	/// <exclude/>
	public partial class EditPageModification_NUIEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : EditPageModification
	{

		public EditPageModification_NUIEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "EditPageModification_NUIEventsProcess";
			SchemaUId = new Guid("af25bf86-7f6d-44cc-a9ee-085e1bb737d3");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("af25bf86-7f6d-44cc-a9ee-085e1bb737d3");
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

	#region Class: EditPageModification_NUIEventsProcess

	/// <exclude/>
	public class EditPageModification_NUIEventsProcess : EditPageModification_NUIEventsProcess<EditPageModification>
	{

		public EditPageModification_NUIEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: EditPageModification_NUIEventsProcess

	public partial class EditPageModification_NUIEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: EditPageModificationEventsProcess

	/// <exclude/>
	public class EditPageModificationEventsProcess : EditPageModification_NUIEventsProcess
	{

		public EditPageModificationEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

