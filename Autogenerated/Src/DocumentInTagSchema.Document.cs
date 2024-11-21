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

	#region Class: DocumentInTagSchema

	/// <exclude/>
	public class DocumentInTagSchema : BPMSoft.Configuration.BaseEntityInTagSchema
	{

		#region Constructors: Public

		public DocumentInTagSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public DocumentInTagSchema(DocumentInTagSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public DocumentInTagSchema(DocumentInTagSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("a16ecd76-4ed7-4371-8c11-97638808f248");
			RealUId = new Guid("a16ecd76-4ed7-4371-8c11-97638808f248");
			Name = "DocumentInTag";
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
			column.ReferenceSchemaUId = new Guid("3f61d911-7421-4e27-9dea-180c32603205");
			column.ColumnValueName = @"TagId";
			column.DisplayColumnValueName = @"TagName";
			column.ModifiedInSchemaUId = new Guid("a16ecd76-4ed7-4371-8c11-97638808f248");
			return column;
		}

		protected override EntitySchemaColumn CreateEntityColumn() {
			EntitySchemaColumn column = base.CreateEntityColumn();
			column.ReferenceSchemaUId = new Guid("8b33b6b2-19f7-4222-9161-b4054b3fbb09");
			column.ColumnValueName = @"EntityId";
			column.DisplayColumnValueName = @"EntityNumber";
			column.ModifiedInSchemaUId = new Guid("a16ecd76-4ed7-4371-8c11-97638808f248");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new DocumentInTag(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new DocumentInTag_DocumentEventsProcess(userConnection);
		}

		public override object Clone() {
			return new DocumentInTagSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new DocumentInTagSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("a16ecd76-4ed7-4371-8c11-97638808f248"));
		}

		#endregion

	}

	#endregion

	#region Class: DocumentInTag

	/// <summary>
	/// Тег в записи раздела документы.
	/// </summary>
	public class DocumentInTag : BPMSoft.Configuration.BaseEntityInTag
	{

		#region Constructors: Public

		public DocumentInTag(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "DocumentInTag";
		}

		public DocumentInTag(DocumentInTag source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new DocumentInTag_DocumentEventsProcess(UserConnection);
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
			return new DocumentInTag(this);
		}

		#endregion

	}

	#endregion

	#region Class: DocumentInTag_DocumentEventsProcess

	/// <exclude/>
	public partial class DocumentInTag_DocumentEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntityInTag_BaseEventsProcess<TEntity> where TEntity : DocumentInTag
	{

		public DocumentInTag_DocumentEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "DocumentInTag_DocumentEventsProcess";
			SchemaUId = new Guid("a16ecd76-4ed7-4371-8c11-97638808f248");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("a16ecd76-4ed7-4371-8c11-97638808f248");
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

	#region Class: DocumentInTag_DocumentEventsProcess

	/// <exclude/>
	public class DocumentInTag_DocumentEventsProcess : DocumentInTag_DocumentEventsProcess<DocumentInTag>
	{

		public DocumentInTag_DocumentEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: DocumentInTag_DocumentEventsProcess

	public partial class DocumentInTag_DocumentEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: DocumentInTagEventsProcess

	/// <exclude/>
	public class DocumentInTagEventsProcess : DocumentInTag_DocumentEventsProcess
	{

		public DocumentInTagEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

