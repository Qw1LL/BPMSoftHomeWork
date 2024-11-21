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

	#region Class: ConfItemFolderSchema

	/// <exclude/>
	public class ConfItemFolderSchema : BPMSoft.Configuration.BaseFolderSchema
	{

		#region Constructors: Public

		public ConfItemFolderSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ConfItemFolderSchema(ConfItemFolderSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ConfItemFolderSchema(ConfItemFolderSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("38db9272-ab0b-449c-9a06-067d57d7bc78");
			RealUId = new Guid("38db9272-ab0b-449c-9a06-067d57d7bc78");
			Name = "ConfItemFolder";
			ParentSchemaUId = new Guid("d602bf96-d029-4b07-9755-63c8f5cb5ed5");
			ExtendParent = false;
			CreatedInPackageId = new Guid("305fcfca-4160-4398-90a9-d5e84be0ae12");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("38db9272-ab0b-449c-9a06-067d57d7bc78");
			column.CreatedInPackageId = new Guid("305fcfca-4160-4398-90a9-d5e84be0ae12");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("38db9272-ab0b-449c-9a06-067d57d7bc78");
			column.CreatedInPackageId = new Guid("305fcfca-4160-4398-90a9-d5e84be0ae12");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("38db9272-ab0b-449c-9a06-067d57d7bc78");
			column.CreatedInPackageId = new Guid("305fcfca-4160-4398-90a9-d5e84be0ae12");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("38db9272-ab0b-449c-9a06-067d57d7bc78");
			column.CreatedInPackageId = new Guid("305fcfca-4160-4398-90a9-d5e84be0ae12");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("38db9272-ab0b-449c-9a06-067d57d7bc78");
			column.CreatedInPackageId = new Guid("305fcfca-4160-4398-90a9-d5e84be0ae12");
			return column;
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("38db9272-ab0b-449c-9a06-067d57d7bc78");
			column.CreatedInPackageId = new Guid("305fcfca-4160-4398-90a9-d5e84be0ae12");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("38db9272-ab0b-449c-9a06-067d57d7bc78");
			column.CreatedInPackageId = new Guid("305fcfca-4160-4398-90a9-d5e84be0ae12");
			return column;
		}

		protected override EntitySchemaColumn CreateParentColumn() {
			EntitySchemaColumn column = base.CreateParentColumn();
			column.ReferenceSchemaUId = new Guid("38db9272-ab0b-449c-9a06-067d57d7bc78");
			column.ColumnValueName = @"ParentId";
			column.DisplayColumnValueName = @"ParentName";
			column.ModifiedInSchemaUId = new Guid("38db9272-ab0b-449c-9a06-067d57d7bc78");
			column.CreatedInPackageId = new Guid("305fcfca-4160-4398-90a9-d5e84be0ae12");
			return column;
		}

		protected override EntitySchemaColumn CreateFolderTypeColumn() {
			EntitySchemaColumn column = base.CreateFolderTypeColumn();
			column.DefValue = new EntitySchemaColumnDef() {
				Source = EntitySchemaColumnDefSource.Const,
				ValueSource = @"9dc5f6e6-2a61-4de8-a059-de30f4e74f24"
			};
			column.ModifiedInSchemaUId = new Guid("38db9272-ab0b-449c-9a06-067d57d7bc78");
			column.CreatedInPackageId = new Guid("305fcfca-4160-4398-90a9-d5e84be0ae12");
			return column;
		}

		protected override EntitySchemaColumn CreateSearchDataColumn() {
			EntitySchemaColumn column = base.CreateSearchDataColumn();
			column.ModifiedInSchemaUId = new Guid("38db9272-ab0b-449c-9a06-067d57d7bc78");
			column.CreatedInPackageId = new Guid("305fcfca-4160-4398-90a9-d5e84be0ae12");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("38db9272-ab0b-449c-9a06-067d57d7bc78");
			column.CreatedInPackageId = new Guid("305fcfca-4160-4398-90a9-d5e84be0ae12");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ConfItemFolder(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ConfItemFolder_CMDBEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ConfItemFolderSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ConfItemFolderSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("38db9272-ab0b-449c-9a06-067d57d7bc78"));
		}

		#endregion

	}

	#endregion

	#region Class: ConfItemFolder

	/// <summary>
	/// Группа раздела "Конфигурационные единицы".
	/// </summary>
	public class ConfItemFolder : BPMSoft.Configuration.BaseFolder
	{

		#region Constructors: Public

		public ConfItemFolder(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ConfItemFolder";
		}

		public ConfItemFolder(ConfItemFolder source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid ParentId {
			get {
				return GetTypedColumnValue<Guid>("ParentId");
			}
			set {
				SetColumnValue("ParentId", value);
				_parent = null;
			}
		}

		/// <exclude/>
		public string ParentName {
			get {
				return GetTypedColumnValue<string>("ParentName");
			}
			set {
				SetColumnValue("ParentName", value);
				if (_parent != null) {
					_parent.Name = value;
				}
			}
		}

		private ConfItemFolder _parent;
		/// <summary>
		/// Родитель.
		/// </summary>
		public ConfItemFolder Parent {
			get {
				return _parent ??
					(_parent = LookupColumnEntities.GetEntity("Parent") as ConfItemFolder);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ConfItemFolder_CMDBEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ConfItemFolderDeleted", e);
			Inserting += (s, e) => ThrowEvent("ConfItemFolderInserting", e);
			Validating += (s, e) => ThrowEvent("ConfItemFolderValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ConfItemFolder(this);
		}

		#endregion

	}

	#endregion

	#region Class: ConfItemFolder_CMDBEventsProcess

	/// <exclude/>
	public partial class ConfItemFolder_CMDBEventsProcess<TEntity> : BPMSoft.Configuration.BaseFolder_BaseEventsProcess<TEntity> where TEntity : ConfItemFolder
	{

		public ConfItemFolder_CMDBEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ConfItemFolder_CMDBEventsProcess";
			SchemaUId = new Guid("38db9272-ab0b-449c-9a06-067d57d7bc78");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("38db9272-ab0b-449c-9a06-067d57d7bc78");
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

	#region Class: ConfItemFolder_CMDBEventsProcess

	/// <exclude/>
	public class ConfItemFolder_CMDBEventsProcess : ConfItemFolder_CMDBEventsProcess<ConfItemFolder>
	{

		public ConfItemFolder_CMDBEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ConfItemFolder_CMDBEventsProcess

	public partial class ConfItemFolder_CMDBEventsProcess<TEntity>
	{

		#region Methods: Public

		public override void CheckCanManageLookups() {
			return;
		}

		#endregion

	}

	#endregion


	#region Class: ConfItemFolderEventsProcess

	/// <exclude/>
	public class ConfItemFolderEventsProcess : ConfItemFolder_CMDBEventsProcess
	{

		public ConfItemFolderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

