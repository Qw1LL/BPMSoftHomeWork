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

	#region Class: KnowledgeBaseTagSchema

	/// <exclude/>
	public class KnowledgeBaseTagSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public KnowledgeBaseTagSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public KnowledgeBaseTagSchema(KnowledgeBaseTagSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public KnowledgeBaseTagSchema(KnowledgeBaseTagSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("48c6d215-5f38-4967-8482-6b04ba8c0ede");
			RealUId = new Guid("48c6d215-5f38-4967-8482-6b04ba8c0ede");
			Name = "KnowledgeBaseTag";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("eb96f059-97b4-4cc9-b308-10d25043227f");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("db4796f0-df36-4617-b0ee-528010b6d262")) == null) {
				Columns.Add(CreateNameENUColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("48c6d215-5f38-4967-8482-6b04ba8c0ede");
			column.CreatedInPackageId = new Guid("eb96f059-97b4-4cc9-b308-10d25043227f");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("48c6d215-5f38-4967-8482-6b04ba8c0ede");
			column.CreatedInPackageId = new Guid("eb96f059-97b4-4cc9-b308-10d25043227f");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("48c6d215-5f38-4967-8482-6b04ba8c0ede");
			column.CreatedInPackageId = new Guid("eb96f059-97b4-4cc9-b308-10d25043227f");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("48c6d215-5f38-4967-8482-6b04ba8c0ede");
			column.CreatedInPackageId = new Guid("eb96f059-97b4-4cc9-b308-10d25043227f");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("48c6d215-5f38-4967-8482-6b04ba8c0ede");
			column.CreatedInPackageId = new Guid("eb96f059-97b4-4cc9-b308-10d25043227f");
			return column;
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("48c6d215-5f38-4967-8482-6b04ba8c0ede");
			column.CreatedInPackageId = new Guid("eb96f059-97b4-4cc9-b308-10d25043227f");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("48c6d215-5f38-4967-8482-6b04ba8c0ede");
			column.CreatedInPackageId = new Guid("eb96f059-97b4-4cc9-b308-10d25043227f");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("48c6d215-5f38-4967-8482-6b04ba8c0ede");
			column.CreatedInPackageId = new Guid("eb96f059-97b4-4cc9-b308-10d25043227f");
			return column;
		}

		protected virtual EntitySchemaColumn CreateNameENUColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("db4796f0-df36-4617-b0ee-528010b6d262"),
				Name = @"NameENU",
				CreatedInSchemaUId = new Guid("48c6d215-5f38-4967-8482-6b04ba8c0ede"),
				ModifiedInSchemaUId = new Guid("48c6d215-5f38-4967-8482-6b04ba8c0ede"),
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
			return new KnowledgeBaseTag(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new KnowledgeBaseTag_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new KnowledgeBaseTagSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new KnowledgeBaseTagSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("48c6d215-5f38-4967-8482-6b04ba8c0ede"));
		}

		#endregion

	}

	#endregion

	#region Class: KnowledgeBaseTag

	/// <summary>
	/// Knowledge base article tag.
	/// </summary>
	public class KnowledgeBaseTag : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public KnowledgeBaseTag(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "KnowledgeBaseTag";
		}

		public KnowledgeBaseTag(KnowledgeBaseTag source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Name ENU.
		/// </summary>
		public string NameENU {
			get {
				return GetTypedColumnValue<string>("NameENU");
			}
			set {
				SetColumnValue("NameENU", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new KnowledgeBaseTag_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("KnowledgeBaseTagDeleted", e);
			Inserting += (s, e) => ThrowEvent("KnowledgeBaseTagInserting", e);
			Validating += (s, e) => ThrowEvent("KnowledgeBaseTagValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new KnowledgeBaseTag(this);
		}

		#endregion

	}

	#endregion

	#region Class: KnowledgeBaseTag_BaseEventsProcess

	/// <exclude/>
	public partial class KnowledgeBaseTag_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : KnowledgeBaseTag
	{

		public KnowledgeBaseTag_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "KnowledgeBaseTag_BaseEventsProcess";
			SchemaUId = new Guid("48c6d215-5f38-4967-8482-6b04ba8c0ede");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("48c6d215-5f38-4967-8482-6b04ba8c0ede");
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

	#region Class: KnowledgeBaseTag_BaseEventsProcess

	/// <exclude/>
	public class KnowledgeBaseTag_BaseEventsProcess : KnowledgeBaseTag_BaseEventsProcess<KnowledgeBaseTag>
	{

		public KnowledgeBaseTag_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: KnowledgeBaseTag_BaseEventsProcess

	public partial class KnowledgeBaseTag_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: KnowledgeBaseTagEventsProcess

	/// <exclude/>
	public class KnowledgeBaseTagEventsProcess : KnowledgeBaseTag_BaseEventsProcess
	{

		public KnowledgeBaseTagEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

