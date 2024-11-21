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

	#region Class: KnowledgeBase_SspKnowledgeBase_BPMSoftSchema

	/// <exclude/>
	public class KnowledgeBase_SspKnowledgeBase_BPMSoftSchema : BPMSoft.Configuration.KnowledgeBase_Base_BPMSoftSchema
	{

		#region Constructors: Public

		public KnowledgeBase_SspKnowledgeBase_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public KnowledgeBase_SspKnowledgeBase_BPMSoftSchema(KnowledgeBase_SspKnowledgeBase_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public KnowledgeBase_SspKnowledgeBase_BPMSoftSchema(KnowledgeBase_SspKnowledgeBase_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("d0bc7526-d14f-4a67-bcd1-eef32ea7d71d");
			Name = "KnowledgeBase_SspKnowledgeBase_BPMSoft";
			ParentSchemaUId = new Guid("0326868c-ce5e-4934-8f1f-178801bfe6c3");
			ExtendParent = true;
			CreatedInPackageId = new Guid("5a28efb4-0330-4d41-a77d-4203b6bbc0a9");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new KnowledgeBase_SspKnowledgeBase_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new KnowledgeBase_SspKnowledgeBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new KnowledgeBase_SspKnowledgeBase_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new KnowledgeBase_SspKnowledgeBase_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("d0bc7526-d14f-4a67-bcd1-eef32ea7d71d"));
		}

		#endregion

	}

	#endregion

	#region Class: KnowledgeBase_SspKnowledgeBase_BPMSoft

	/// <summary>
	/// Knowledge base article.
	/// </summary>
	public class KnowledgeBase_SspKnowledgeBase_BPMSoft : BPMSoft.Configuration.KnowledgeBase_Base_BPMSoft
	{

		#region Constructors: Public

		public KnowledgeBase_SspKnowledgeBase_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "KnowledgeBase_SspKnowledgeBase_BPMSoft";
		}

		public KnowledgeBase_SspKnowledgeBase_BPMSoft(KnowledgeBase_SspKnowledgeBase_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new KnowledgeBase_SspKnowledgeBaseEventsProcess(UserConnection);
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
			return new KnowledgeBase_SspKnowledgeBase_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: KnowledgeBase_SspKnowledgeBaseEventsProcess

	/// <exclude/>
	public partial class KnowledgeBase_SspKnowledgeBaseEventsProcess<TEntity> : BPMSoft.Configuration.KnowledgeBase_BaseEventsProcess<TEntity> where TEntity : KnowledgeBase_SspKnowledgeBase_BPMSoft
	{

		public KnowledgeBase_SspKnowledgeBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "KnowledgeBase_SspKnowledgeBaseEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("d0bc7526-d14f-4a67-bcd1-eef32ea7d71d");
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

	#region Class: KnowledgeBase_SspKnowledgeBaseEventsProcess

	/// <exclude/>
	public class KnowledgeBase_SspKnowledgeBaseEventsProcess : KnowledgeBase_SspKnowledgeBaseEventsProcess<KnowledgeBase_SspKnowledgeBase_BPMSoft>
	{

		public KnowledgeBase_SspKnowledgeBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: KnowledgeBase_SspKnowledgeBaseEventsProcess

	public partial class KnowledgeBase_SspKnowledgeBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

