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

	#region Class: HTTPAuthTypeSchema

	/// <exclude/>
	public class HTTPAuthTypeSchema : BPMSoft.Configuration.BaseCodeLookupSchema
	{

		#region Constructors: Public

		public HTTPAuthTypeSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public HTTPAuthTypeSchema(HTTPAuthTypeSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public HTTPAuthTypeSchema(HTTPAuthTypeSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("31274c13-38d5-44bc-92fa-08050925366d");
			RealUId = new Guid("31274c13-38d5-44bc-92fa-08050925366d");
			Name = "HTTPAuthType";
			ParentSchemaUId = new Guid("2681062b-df59-4e52-89ed-f9b7dc909ab2");
			ExtendParent = false;
			CreatedInPackageId = new Guid("47c22e57-1b16-4004-8f6b-0f257046428b");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("31274c13-38d5-44bc-92fa-08050925366d");
			column.CreatedInPackageId = new Guid("47c22e57-1b16-4004-8f6b-0f257046428b");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("31274c13-38d5-44bc-92fa-08050925366d");
			column.CreatedInPackageId = new Guid("47c22e57-1b16-4004-8f6b-0f257046428b");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("31274c13-38d5-44bc-92fa-08050925366d");
			column.CreatedInPackageId = new Guid("47c22e57-1b16-4004-8f6b-0f257046428b");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("31274c13-38d5-44bc-92fa-08050925366d");
			column.CreatedInPackageId = new Guid("47c22e57-1b16-4004-8f6b-0f257046428b");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("31274c13-38d5-44bc-92fa-08050925366d");
			column.CreatedInPackageId = new Guid("47c22e57-1b16-4004-8f6b-0f257046428b");
			return column;
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("31274c13-38d5-44bc-92fa-08050925366d");
			column.CreatedInPackageId = new Guid("47c22e57-1b16-4004-8f6b-0f257046428b");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("31274c13-38d5-44bc-92fa-08050925366d");
			column.CreatedInPackageId = new Guid("47c22e57-1b16-4004-8f6b-0f257046428b");
			return column;
		}

		protected override EntitySchemaColumn CreateCodeColumn() {
			EntitySchemaColumn column = base.CreateCodeColumn();
			column.ModifiedInSchemaUId = new Guid("31274c13-38d5-44bc-92fa-08050925366d");
			column.CreatedInPackageId = new Guid("47c22e57-1b16-4004-8f6b-0f257046428b");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("31274c13-38d5-44bc-92fa-08050925366d");
			column.CreatedInPackageId = new Guid("47c22e57-1b16-4004-8f6b-0f257046428b");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new HTTPAuthType(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new HTTPAuthType_ProcessDesignerEventsProcess(userConnection);
		}

		public override object Clone() {
			return new HTTPAuthTypeSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new HTTPAuthTypeSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("31274c13-38d5-44bc-92fa-08050925366d"));
		}

		#endregion

	}

	#endregion

	#region Class: HTTPAuthType

	/// <summary>
	/// HTTP authentication type.
	/// </summary>
	public class HTTPAuthType : BPMSoft.Configuration.BaseCodeLookup
	{

		#region Constructors: Public

		public HTTPAuthType(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "HTTPAuthType";
		}

		public HTTPAuthType(HTTPAuthType source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new HTTPAuthType_ProcessDesignerEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("HTTPAuthTypeDeleted", e);
			Inserting += (s, e) => ThrowEvent("HTTPAuthTypeInserting", e);
			Validating += (s, e) => ThrowEvent("HTTPAuthTypeValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new HTTPAuthType(this);
		}

		#endregion

	}

	#endregion

	#region Class: HTTPAuthType_ProcessDesignerEventsProcess

	/// <exclude/>
	public partial class HTTPAuthType_ProcessDesignerEventsProcess<TEntity> : BPMSoft.Configuration.BaseCodeLookup_BaseEventsProcess<TEntity> where TEntity : HTTPAuthType
	{

		public HTTPAuthType_ProcessDesignerEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "HTTPAuthType_ProcessDesignerEventsProcess";
			SchemaUId = new Guid("31274c13-38d5-44bc-92fa-08050925366d");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("31274c13-38d5-44bc-92fa-08050925366d");
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

	#region Class: HTTPAuthType_ProcessDesignerEventsProcess

	/// <exclude/>
	public class HTTPAuthType_ProcessDesignerEventsProcess : HTTPAuthType_ProcessDesignerEventsProcess<HTTPAuthType>
	{

		public HTTPAuthType_ProcessDesignerEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: HTTPAuthType_ProcessDesignerEventsProcess

	public partial class HTTPAuthType_ProcessDesignerEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: HTTPAuthTypeEventsProcess

	/// <exclude/>
	public class HTTPAuthTypeEventsProcess : HTTPAuthType_ProcessDesignerEventsProcess
	{

		public HTTPAuthTypeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

