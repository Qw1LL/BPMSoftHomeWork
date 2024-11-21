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
	using System.Security;
	using TSConfiguration = BPMSoft.Configuration;

	#region Class: WSysAccountTagSchema

	/// <exclude/>
	public class WSysAccountTagSchema : BPMSoft.Configuration.BaseTagSchema
	{

		#region Constructors: Public

		public WSysAccountTagSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public WSysAccountTagSchema(WSysAccountTagSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public WSysAccountTagSchema(WSysAccountTagSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("e4114d94-41b5-4a58-957f-6b84a3304cca");
			RealUId = new Guid("e4114d94-41b5-4a58-957f-6b84a3304cca");
			Name = "WSysAccountTag";
			ParentSchemaUId = new Guid("9e3f203c-e905-4de5-9468-335b193f2439");
			ExtendParent = false;
			CreatedInPackageId = new Guid("9e68a40f-2533-42d0-8fe0-88fdb6bf5704");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override EntitySchemaColumn CreateTypeColumn() {
			EntitySchemaColumn column = base.CreateTypeColumn();
			column.DefValue = new EntitySchemaColumnDef() {
				Source = EntitySchemaColumnDefSource.Const,
				ValueSource = @"8d7f6d6c-4ca5-4b43-bdd9-a5e01a582260"
			};
			column.ModifiedInSchemaUId = new Guid("e4114d94-41b5-4a58-957f-6b84a3304cca");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new WSysAccountTag(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new WSysAccountTag_WbCollaborationsEventsProcess(userConnection);
		}

		public override object Clone() {
			return new WSysAccountTagSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new WSysAccountTagSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("e4114d94-41b5-4a58-957f-6b84a3304cca"));
		}

		#endregion

	}

	#endregion

	#region Class: WSysAccountTag

	/// <summary>
	/// "Wb users" section tag.
	/// </summary>
	public class WSysAccountTag : BPMSoft.Configuration.BaseTag
	{

		#region Constructors: Public

		public WSysAccountTag(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "WSysAccountTag";
		}

		public WSysAccountTag(WSysAccountTag source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new WSysAccountTag_WbCollaborationsEventsProcess(UserConnection);
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
			return new WSysAccountTag(this);
		}

		#endregion

	}

	#endregion

	#region Class: WSysAccountTag_WbCollaborationsEventsProcess

	/// <exclude/>
	public partial class WSysAccountTag_WbCollaborationsEventsProcess<TEntity> : BPMSoft.Configuration.BaseTag_SSPEventsProcess<TEntity> where TEntity : WSysAccountTag
	{

		public WSysAccountTag_WbCollaborationsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "WSysAccountTag_WbCollaborationsEventsProcess";
			SchemaUId = new Guid("e4114d94-41b5-4a58-957f-6b84a3304cca");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("e4114d94-41b5-4a58-957f-6b84a3304cca");
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

	#region Class: WSysAccountTag_WbCollaborationsEventsProcess

	/// <exclude/>
	public class WSysAccountTag_WbCollaborationsEventsProcess : WSysAccountTag_WbCollaborationsEventsProcess<WSysAccountTag>
	{

		public WSysAccountTag_WbCollaborationsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: WSysAccountTag_WbCollaborationsEventsProcess

	public partial class WSysAccountTag_WbCollaborationsEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: WSysAccountTagEventsProcess

	/// <exclude/>
	public class WSysAccountTagEventsProcess : WSysAccountTag_WbCollaborationsEventsProcess
	{

		public WSysAccountTagEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

