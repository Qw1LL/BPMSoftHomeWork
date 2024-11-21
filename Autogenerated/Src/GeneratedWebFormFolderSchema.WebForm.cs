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

	#region Class: GeneratedWebFormFolderSchema

	/// <exclude/>
	public class GeneratedWebFormFolderSchema : BPMSoft.Configuration.BaseFolderSchema
	{

		#region Constructors: Public

		public GeneratedWebFormFolderSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public GeneratedWebFormFolderSchema(GeneratedWebFormFolderSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public GeneratedWebFormFolderSchema(GeneratedWebFormFolderSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("07ae8a65-3f23-4bb6-b302-73c557beb518");
			RealUId = new Guid("07ae8a65-3f23-4bb6-b302-73c557beb518");
			Name = "GeneratedWebFormFolder";
			ParentSchemaUId = new Guid("d602bf96-d029-4b07-9755-63c8f5cb5ed5");
			ExtendParent = false;
			CreatedInPackageId = new Guid("e3031532-a059-4130-8d2e-6bdf35a52945");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override EntitySchemaColumn CreateParentColumn() {
			EntitySchemaColumn column = base.CreateParentColumn();
			column.ReferenceSchemaUId = new Guid("07ae8a65-3f23-4bb6-b302-73c557beb518");
			column.ColumnValueName = @"ParentId";
			column.DisplayColumnValueName = @"ParentName";
			column.ModifiedInSchemaUId = new Guid("07ae8a65-3f23-4bb6-b302-73c557beb518");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new GeneratedWebFormFolder(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new GeneratedWebFormFolder_WebFormEventsProcess(userConnection);
		}

		public override object Clone() {
			return new GeneratedWebFormFolderSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new GeneratedWebFormFolderSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("07ae8a65-3f23-4bb6-b302-73c557beb518"));
		}

		#endregion

	}

	#endregion

	#region Class: GeneratedWebFormFolder

	/// <summary>
	/// Section folder - "Landing pages".
	/// </summary>
	public class GeneratedWebFormFolder : BPMSoft.Configuration.BaseFolder
	{

		#region Constructors: Public

		public GeneratedWebFormFolder(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "GeneratedWebFormFolder";
		}

		public GeneratedWebFormFolder(GeneratedWebFormFolder source)
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

		private GeneratedWebFormFolder _parent;
		/// <summary>
		/// Parent.
		/// </summary>
		public GeneratedWebFormFolder Parent {
			get {
				return _parent ??
					(_parent = LookupColumnEntities.GetEntity("Parent") as GeneratedWebFormFolder);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new GeneratedWebFormFolder_WebFormEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("GeneratedWebFormFolderDeleted", e);
			Validating += (s, e) => ThrowEvent("GeneratedWebFormFolderValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new GeneratedWebFormFolder(this);
		}

		#endregion

	}

	#endregion

	#region Class: GeneratedWebFormFolder_WebFormEventsProcess

	/// <exclude/>
	public partial class GeneratedWebFormFolder_WebFormEventsProcess<TEntity> : BPMSoft.Configuration.BaseFolder_BaseEventsProcess<TEntity> where TEntity : GeneratedWebFormFolder
	{

		public GeneratedWebFormFolder_WebFormEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "GeneratedWebFormFolder_WebFormEventsProcess";
			SchemaUId = new Guid("07ae8a65-3f23-4bb6-b302-73c557beb518");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("07ae8a65-3f23-4bb6-b302-73c557beb518");
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

	#region Class: GeneratedWebFormFolder_WebFormEventsProcess

	/// <exclude/>
	public class GeneratedWebFormFolder_WebFormEventsProcess : GeneratedWebFormFolder_WebFormEventsProcess<GeneratedWebFormFolder>
	{

		public GeneratedWebFormFolder_WebFormEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: GeneratedWebFormFolder_WebFormEventsProcess

	public partial class GeneratedWebFormFolder_WebFormEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: GeneratedWebFormFolderEventsProcess

	/// <exclude/>
	public class GeneratedWebFormFolderEventsProcess : GeneratedWebFormFolder_WebFormEventsProcess
	{

		public GeneratedWebFormFolderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

