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

	#region Class: SysTranslationFolderSchema

	/// <exclude/>
	public class SysTranslationFolderSchema : BPMSoft.Configuration.BaseFolderSchema
	{

		#region Constructors: Public

		public SysTranslationFolderSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysTranslationFolderSchema(SysTranslationFolderSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysTranslationFolderSchema(SysTranslationFolderSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("d42038d3-367c-4023-80c1-d4305157b5ae");
			RealUId = new Guid("d42038d3-367c-4023-80c1-d4305157b5ae");
			Name = "SysTranslationFolder";
			ParentSchemaUId = new Guid("d602bf96-d029-4b07-9755-63c8f5cb5ed5");
			ExtendParent = false;
			CreatedInPackageId = new Guid("9a2dd422-afdd-47c6-b4b8-0841efbfcb9a");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override EntitySchemaColumn CreateParentColumn() {
			EntitySchemaColumn column = base.CreateParentColumn();
			column.ReferenceSchemaUId = new Guid("d42038d3-367c-4023-80c1-d4305157b5ae");
			column.ColumnValueName = @"ParentId";
			column.DisplayColumnValueName = @"ParentName";
			column.ModifiedInSchemaUId = new Guid("d42038d3-367c-4023-80c1-d4305157b5ae");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysTranslationFolder(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysTranslationFolder_TranslationEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysTranslationFolderSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysTranslationFolderSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("d42038d3-367c-4023-80c1-d4305157b5ae"));
		}

		#endregion

	}

	#endregion

	#region Class: SysTranslationFolder

	/// <summary>
	/// Translation folder.
	/// </summary>
	public class SysTranslationFolder : BPMSoft.Configuration.BaseFolder
	{

		#region Constructors: Public

		public SysTranslationFolder(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysTranslationFolder";
		}

		public SysTranslationFolder(SysTranslationFolder source)
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

		private SysTranslationFolder _parent;
		/// <summary>
		/// Parent.
		/// </summary>
		public SysTranslationFolder Parent {
			get {
				return _parent ??
					(_parent = LookupColumnEntities.GetEntity("Parent") as SysTranslationFolder);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysTranslationFolder_TranslationEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysTranslationFolderDeleted", e);
			Validating += (s, e) => ThrowEvent("SysTranslationFolderValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysTranslationFolder(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysTranslationFolder_TranslationEventsProcess

	/// <exclude/>
	public partial class SysTranslationFolder_TranslationEventsProcess<TEntity> : BPMSoft.Configuration.BaseFolder_BaseEventsProcess<TEntity> where TEntity : SysTranslationFolder
	{

		public SysTranslationFolder_TranslationEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysTranslationFolder_TranslationEventsProcess";
			SchemaUId = new Guid("d42038d3-367c-4023-80c1-d4305157b5ae");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("d42038d3-367c-4023-80c1-d4305157b5ae");
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

	#region Class: SysTranslationFolder_TranslationEventsProcess

	/// <exclude/>
	public class SysTranslationFolder_TranslationEventsProcess : SysTranslationFolder_TranslationEventsProcess<SysTranslationFolder>
	{

		public SysTranslationFolder_TranslationEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysTranslationFolder_TranslationEventsProcess

	public partial class SysTranslationFolder_TranslationEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysTranslationFolderEventsProcess

	/// <exclude/>
	public class SysTranslationFolderEventsProcess : SysTranslationFolder_TranslationEventsProcess
	{

		public SysTranslationFolderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

