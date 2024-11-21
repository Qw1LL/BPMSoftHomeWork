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

	#region Class: ActivityResultCategorySchema

	/// <exclude/>
	public class ActivityResultCategorySchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public ActivityResultCategorySchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ActivityResultCategorySchema(ActivityResultCategorySchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ActivityResultCategorySchema(ActivityResultCategorySchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("0b8e1c4e-71c0-4776-8b30-11f8689e6bac");
			RealUId = new Guid("0b8e1c4e-71c0-4776-8b30-11f8689e6bac");
			Name = "ActivityResultCategory";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("5f1bdcb0-8c10-43bc-aead-341648534099");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("0b8e1c4e-71c0-4776-8b30-11f8689e6bac");
			column.CreatedInPackageId = new Guid("5f1bdcb0-8c10-43bc-aead-341648534099");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("0b8e1c4e-71c0-4776-8b30-11f8689e6bac");
			column.CreatedInPackageId = new Guid("5f1bdcb0-8c10-43bc-aead-341648534099");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("0b8e1c4e-71c0-4776-8b30-11f8689e6bac");
			column.CreatedInPackageId = new Guid("5f1bdcb0-8c10-43bc-aead-341648534099");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("0b8e1c4e-71c0-4776-8b30-11f8689e6bac");
			column.CreatedInPackageId = new Guid("5f1bdcb0-8c10-43bc-aead-341648534099");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("0b8e1c4e-71c0-4776-8b30-11f8689e6bac");
			column.CreatedInPackageId = new Guid("5f1bdcb0-8c10-43bc-aead-341648534099");
			return column;
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("0b8e1c4e-71c0-4776-8b30-11f8689e6bac");
			column.CreatedInPackageId = new Guid("5f1bdcb0-8c10-43bc-aead-341648534099");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("0b8e1c4e-71c0-4776-8b30-11f8689e6bac");
			column.CreatedInPackageId = new Guid("5f1bdcb0-8c10-43bc-aead-341648534099");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("0b8e1c4e-71c0-4776-8b30-11f8689e6bac");
			column.CreatedInPackageId = new Guid("5f1bdcb0-8c10-43bc-aead-341648534099");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ActivityResultCategory(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ActivityResultCategory_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ActivityResultCategorySchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ActivityResultCategorySchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("0b8e1c4e-71c0-4776-8b30-11f8689e6bac"));
		}

		#endregion

	}

	#endregion

	#region Class: ActivityResultCategory

	/// <summary>
	/// Category of activity result.
	/// </summary>
	public class ActivityResultCategory : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public ActivityResultCategory(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ActivityResultCategory";
		}

		public ActivityResultCategory(ActivityResultCategory source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ActivityResultCategory_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ActivityResultCategoryDeleted", e);
			Inserting += (s, e) => ThrowEvent("ActivityResultCategoryInserting", e);
			Validating += (s, e) => ThrowEvent("ActivityResultCategoryValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ActivityResultCategory(this);
		}

		#endregion

	}

	#endregion

	#region Class: ActivityResultCategory_BaseEventsProcess

	/// <exclude/>
	public partial class ActivityResultCategory_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : ActivityResultCategory
	{

		public ActivityResultCategory_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ActivityResultCategory_BaseEventsProcess";
			SchemaUId = new Guid("0b8e1c4e-71c0-4776-8b30-11f8689e6bac");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("0b8e1c4e-71c0-4776-8b30-11f8689e6bac");
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

	#region Class: ActivityResultCategory_BaseEventsProcess

	/// <exclude/>
	public class ActivityResultCategory_BaseEventsProcess : ActivityResultCategory_BaseEventsProcess<ActivityResultCategory>
	{

		public ActivityResultCategory_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ActivityResultCategory_BaseEventsProcess

	public partial class ActivityResultCategory_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ActivityResultCategoryEventsProcess

	/// <exclude/>
	public class ActivityResultCategoryEventsProcess : ActivityResultCategory_BaseEventsProcess
	{

		public ActivityResultCategoryEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

