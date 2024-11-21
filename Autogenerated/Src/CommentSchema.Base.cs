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

	#region Class: CommentSchema

	/// <exclude/>
	public class CommentSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public CommentSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public CommentSchema(CommentSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public CommentSchema(CommentSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("f616b98d-3d29-4cdc-a649-302aa36c022a");
			RealUId = new Guid("f616b98d-3d29-4cdc-a649-302aa36c022a");
			Name = "Comment";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("eb96f059-97b4-4cc9-b308-10d25043227f");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateCommentKnowledgeBaseColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("a9ef221a-acab-4603-aaf4-65a6436ba8bf")) == null) {
				Columns.Add(CreateContactColumn());
			}
			if (Columns.FindByUId(new Guid("794f9e76-9723-47f3-a50a-19ad16bee599")) == null) {
				Columns.Add(CreateKnowledgeBaseColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("f616b98d-3d29-4cdc-a649-302aa36c022a");
			column.CreatedInPackageId = new Guid("eb96f059-97b4-4cc9-b308-10d25043227f");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("f616b98d-3d29-4cdc-a649-302aa36c022a");
			column.CreatedInPackageId = new Guid("eb96f059-97b4-4cc9-b308-10d25043227f");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("f616b98d-3d29-4cdc-a649-302aa36c022a");
			column.CreatedInPackageId = new Guid("eb96f059-97b4-4cc9-b308-10d25043227f");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("f616b98d-3d29-4cdc-a649-302aa36c022a");
			column.CreatedInPackageId = new Guid("eb96f059-97b4-4cc9-b308-10d25043227f");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("f616b98d-3d29-4cdc-a649-302aa36c022a");
			column.CreatedInPackageId = new Guid("eb96f059-97b4-4cc9-b308-10d25043227f");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("f616b98d-3d29-4cdc-a649-302aa36c022a");
			column.CreatedInPackageId = new Guid("eb96f059-97b4-4cc9-b308-10d25043227f");
			return column;
		}

		protected virtual EntitySchemaColumn CreateContactColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("a9ef221a-acab-4603-aaf4-65a6436ba8bf"),
				Name = @"Contact",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("f616b98d-3d29-4cdc-a649-302aa36c022a"),
				ModifiedInSchemaUId = new Guid("f616b98d-3d29-4cdc-a649-302aa36c022a"),
				CreatedInPackageId = new Guid("eb96f059-97b4-4cc9-b308-10d25043227f")
			};
		}

		protected virtual EntitySchemaColumn CreateKnowledgeBaseColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("794f9e76-9723-47f3-a50a-19ad16bee599"),
				Name = @"KnowledgeBase",
				ReferenceSchemaUId = new Guid("0326868c-ce5e-4934-8f1f-178801bfe6c3"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("f616b98d-3d29-4cdc-a649-302aa36c022a"),
				ModifiedInSchemaUId = new Guid("f616b98d-3d29-4cdc-a649-302aa36c022a"),
				CreatedInPackageId = new Guid("eb96f059-97b4-4cc9-b308-10d25043227f")
			};
		}

		protected virtual EntitySchemaColumn CreateCommentKnowledgeBaseColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("ca83fc6e-bdf1-437e-80a7-7eef3cd05edd"),
				Name = @"CommentKnowledgeBase",
				CreatedInSchemaUId = new Guid("f616b98d-3d29-4cdc-a649-302aa36c022a"),
				ModifiedInSchemaUId = new Guid("f616b98d-3d29-4cdc-a649-302aa36c022a"),
				CreatedInPackageId = new Guid("eb96f059-97b4-4cc9-b308-10d25043227f")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new Comment(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Comment_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new CommentSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new CommentSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("f616b98d-3d29-4cdc-a649-302aa36c022a"));
		}

		#endregion

	}

	#endregion

	#region Class: Comment

	/// <summary>
	/// Notes.
	/// </summary>
	public class Comment : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public Comment(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Comment";
		}

		public Comment(Comment source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid ContactId {
			get {
				return GetTypedColumnValue<Guid>("ContactId");
			}
			set {
				SetColumnValue("ContactId", value);
				_contact = null;
			}
		}

		/// <exclude/>
		public string ContactName {
			get {
				return GetTypedColumnValue<string>("ContactName");
			}
			set {
				SetColumnValue("ContactName", value);
				if (_contact != null) {
					_contact.Name = value;
				}
			}
		}

		private Contact _contact;
		/// <summary>
		/// Contact.
		/// </summary>
		public Contact Contact {
			get {
				return _contact ??
					(_contact = LookupColumnEntities.GetEntity("Contact") as Contact);
			}
		}

		/// <exclude/>
		public Guid KnowledgeBaseId {
			get {
				return GetTypedColumnValue<Guid>("KnowledgeBaseId");
			}
			set {
				SetColumnValue("KnowledgeBaseId", value);
				_knowledgeBase = null;
			}
		}

		/// <exclude/>
		public string KnowledgeBaseName {
			get {
				return GetTypedColumnValue<string>("KnowledgeBaseName");
			}
			set {
				SetColumnValue("KnowledgeBaseName", value);
				if (_knowledgeBase != null) {
					_knowledgeBase.Name = value;
				}
			}
		}

		private KnowledgeBase _knowledgeBase;
		/// <summary>
		/// Article.
		/// </summary>
		public KnowledgeBase KnowledgeBase {
			get {
				return _knowledgeBase ??
					(_knowledgeBase = LookupColumnEntities.GetEntity("KnowledgeBase") as KnowledgeBase);
			}
		}

		/// <summary>
		/// Comment.
		/// </summary>
		public string CommentKnowledgeBase {
			get {
				return GetTypedColumnValue<string>("CommentKnowledgeBase");
			}
			set {
				SetColumnValue("CommentKnowledgeBase", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Comment_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("CommentDeleted", e);
			Inserting += (s, e) => ThrowEvent("CommentInserting", e);
			Validating += (s, e) => ThrowEvent("CommentValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new Comment(this);
		}

		#endregion

	}

	#endregion

	#region Class: Comment_BaseEventsProcess

	/// <exclude/>
	public partial class Comment_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : Comment
	{

		public Comment_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Comment_BaseEventsProcess";
			SchemaUId = new Guid("f616b98d-3d29-4cdc-a649-302aa36c022a");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("f616b98d-3d29-4cdc-a649-302aa36c022a");
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

	#region Class: Comment_BaseEventsProcess

	/// <exclude/>
	public class Comment_BaseEventsProcess : Comment_BaseEventsProcess<Comment>
	{

		public Comment_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: Comment_BaseEventsProcess

	public partial class Comment_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: CommentEventsProcess

	/// <exclude/>
	public class CommentEventsProcess : Comment_BaseEventsProcess
	{

		public CommentEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

