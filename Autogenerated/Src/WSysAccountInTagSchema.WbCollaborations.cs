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

	#region Class: WSysAccountInTagSchema

	/// <exclude/>
	public class WSysAccountInTagSchema : BPMSoft.Configuration.BaseEntityInTagSchema
	{

		#region Constructors: Public

		public WSysAccountInTagSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public WSysAccountInTagSchema(WSysAccountInTagSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public WSysAccountInTagSchema(WSysAccountInTagSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("ed2dce34-f10b-42b9-9004-df6655c0f530");
			RealUId = new Guid("ed2dce34-f10b-42b9-9004-df6655c0f530");
			Name = "WSysAccountInTag";
			ParentSchemaUId = new Guid("5894a2b0-51d5-419a-82bb-238674634270");
			ExtendParent = false;
			CreatedInPackageId = new Guid("9e68a40f-2533-42d0-8fe0-88fdb6bf5704");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override EntitySchemaColumn CreateTagColumn() {
			EntitySchemaColumn column = base.CreateTagColumn();
			column.ReferenceSchemaUId = new Guid("e4114d94-41b5-4a58-957f-6b84a3304cca");
			column.ColumnValueName = @"TagId";
			column.DisplayColumnValueName = @"TagName";
			column.ModifiedInSchemaUId = new Guid("ed2dce34-f10b-42b9-9004-df6655c0f530");
			return column;
		}

		protected override EntitySchemaColumn CreateEntityColumn() {
			EntitySchemaColumn column = base.CreateEntityColumn();
			column.ReferenceSchemaUId = new Guid("38dbbdd4-9ab4-473a-bb99-9ca8f830163f");
			column.ColumnValueName = @"EntityId";
			column.DisplayColumnValueName = @"EntityLogin";
			column.ModifiedInSchemaUId = new Guid("ed2dce34-f10b-42b9-9004-df6655c0f530");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new WSysAccountInTag(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new WSysAccountInTag_WbCollaborationsEventsProcess(userConnection);
		}

		public override object Clone() {
			return new WSysAccountInTagSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new WSysAccountInTagSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ed2dce34-f10b-42b9-9004-df6655c0f530"));
		}

		#endregion

	}

	#endregion

	#region Class: WSysAccountInTag

	/// <summary>
	/// "Wb users" section record tag.
	/// </summary>
	public class WSysAccountInTag : BPMSoft.Configuration.BaseEntityInTag
	{

		#region Constructors: Public

		public WSysAccountInTag(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "WSysAccountInTag";
		}

		public WSysAccountInTag(WSysAccountInTag source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new WSysAccountInTag_WbCollaborationsEventsProcess(UserConnection);
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
			return new WSysAccountInTag(this);
		}

		#endregion

	}

	#endregion

	#region Class: WSysAccountInTag_WbCollaborationsEventsProcess

	/// <exclude/>
	public partial class WSysAccountInTag_WbCollaborationsEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntityInTag_BaseEventsProcess<TEntity> where TEntity : WSysAccountInTag
	{

		public WSysAccountInTag_WbCollaborationsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "WSysAccountInTag_WbCollaborationsEventsProcess";
			SchemaUId = new Guid("ed2dce34-f10b-42b9-9004-df6655c0f530");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("ed2dce34-f10b-42b9-9004-df6655c0f530");
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

	#region Class: WSysAccountInTag_WbCollaborationsEventsProcess

	/// <exclude/>
	public class WSysAccountInTag_WbCollaborationsEventsProcess : WSysAccountInTag_WbCollaborationsEventsProcess<WSysAccountInTag>
	{

		public WSysAccountInTag_WbCollaborationsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: WSysAccountInTag_WbCollaborationsEventsProcess

	public partial class WSysAccountInTag_WbCollaborationsEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: WSysAccountInTagEventsProcess

	/// <exclude/>
	public class WSysAccountInTagEventsProcess : WSysAccountInTag_WbCollaborationsEventsProcess
	{

		public WSysAccountInTagEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

