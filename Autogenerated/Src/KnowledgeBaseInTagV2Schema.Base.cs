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

	#region Class: KnowledgeBaseInTagV2Schema

	/// <exclude/>
	public class KnowledgeBaseInTagV2Schema : BPMSoft.Configuration.BaseEntityInTagSchema
	{

		#region Constructors: Public

		public KnowledgeBaseInTagV2Schema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public KnowledgeBaseInTagV2Schema(KnowledgeBaseInTagV2Schema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public KnowledgeBaseInTagV2Schema(KnowledgeBaseInTagV2Schema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("568fa191-f2ba-4c31-8632-a79e89fed891");
			RealUId = new Guid("568fa191-f2ba-4c31-8632-a79e89fed891");
			Name = "KnowledgeBaseInTagV2";
			ParentSchemaUId = new Guid("5894a2b0-51d5-419a-82bb-238674634270");
			ExtendParent = false;
			CreatedInPackageId = new Guid("7ef175d1-30fa-42f5-9f26-d5b1d45b0001");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override EntitySchemaColumn CreateTagColumn() {
			EntitySchemaColumn column = base.CreateTagColumn();
			column.ReferenceSchemaUId = new Guid("e79650e0-3a80-465e-ba8c-9b0372cb04b1");
			column.ColumnValueName = @"TagId";
			column.DisplayColumnValueName = @"TagName";
			column.ModifiedInSchemaUId = new Guid("568fa191-f2ba-4c31-8632-a79e89fed891");
			return column;
		}

		protected override EntitySchemaColumn CreateEntityColumn() {
			EntitySchemaColumn column = base.CreateEntityColumn();
			column.ReferenceSchemaUId = new Guid("0326868c-ce5e-4934-8f1f-178801bfe6c3");
			column.ColumnValueName = @"EntityId";
			column.DisplayColumnValueName = @"EntityName";
			column.ModifiedInSchemaUId = new Guid("568fa191-f2ba-4c31-8632-a79e89fed891");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new KnowledgeBaseInTagV2(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new KnowledgeBaseInTagV2_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new KnowledgeBaseInTagV2Schema(this);
		}

		public override EntitySchema CloneShallow() {
			return new KnowledgeBaseInTagV2Schema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("568fa191-f2ba-4c31-8632-a79e89fed891"));
		}

		#endregion

	}

	#endregion

	#region Class: KnowledgeBaseInTagV2

	/// <summary>
	/// Knowledge base record tag.
	/// </summary>
	public class KnowledgeBaseInTagV2 : BPMSoft.Configuration.BaseEntityInTag
	{

		#region Constructors: Public

		public KnowledgeBaseInTagV2(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "KnowledgeBaseInTagV2";
		}

		public KnowledgeBaseInTagV2(KnowledgeBaseInTagV2 source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new KnowledgeBaseInTagV2_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("KnowledgeBaseInTagV2Deleted", e);
			Validating += (s, e) => ThrowEvent("KnowledgeBaseInTagV2Validating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new KnowledgeBaseInTagV2(this);
		}

		#endregion

	}

	#endregion

	#region Class: KnowledgeBaseInTagV2_BaseEventsProcess

	/// <exclude/>
	public partial class KnowledgeBaseInTagV2_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntityInTag_BaseEventsProcess<TEntity> where TEntity : KnowledgeBaseInTagV2
	{

		public KnowledgeBaseInTagV2_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "KnowledgeBaseInTagV2_BaseEventsProcess";
			SchemaUId = new Guid("568fa191-f2ba-4c31-8632-a79e89fed891");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("568fa191-f2ba-4c31-8632-a79e89fed891");
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

	#region Class: KnowledgeBaseInTagV2_BaseEventsProcess

	/// <exclude/>
	public class KnowledgeBaseInTagV2_BaseEventsProcess : KnowledgeBaseInTagV2_BaseEventsProcess<KnowledgeBaseInTagV2>
	{

		public KnowledgeBaseInTagV2_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: KnowledgeBaseInTagV2_BaseEventsProcess

	public partial class KnowledgeBaseInTagV2_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: KnowledgeBaseInTagV2EventsProcess

	/// <exclude/>
	public class KnowledgeBaseInTagV2EventsProcess : KnowledgeBaseInTagV2_BaseEventsProcess
	{

		public KnowledgeBaseInTagV2EventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

