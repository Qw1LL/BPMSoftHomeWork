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

	#region Class: KnowledgeBase_Portal_BPMSoftSchema

	/// <exclude/>
	public class KnowledgeBase_Portal_BPMSoftSchema : BPMSoft.Configuration.KnowledgeBase_SspKnowledgeBase_BPMSoftSchema
	{

		#region Constructors: Public

		public KnowledgeBase_Portal_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public KnowledgeBase_Portal_BPMSoftSchema(KnowledgeBase_Portal_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public KnowledgeBase_Portal_BPMSoftSchema(KnowledgeBase_Portal_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("3f4b5a7e-3599-46f8-b426-2ef29e7fe38f");
			Name = "KnowledgeBase_Portal_BPMSoft";
			ParentSchemaUId = new Guid("0326868c-ce5e-4934-8f1f-178801bfe6c3");
			ExtendParent = true;
			CreatedInPackageId = new Guid("929a7200-398f-4e6f-a56d-d74f21f8bfe0");
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
			return new KnowledgeBase_Portal_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new KnowledgeBase_PortalEventsProcess(userConnection);
		}

		public override object Clone() {
			return new KnowledgeBase_Portal_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new KnowledgeBase_Portal_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("3f4b5a7e-3599-46f8-b426-2ef29e7fe38f"));
		}

		#endregion

	}

	#endregion

	#region Class: KnowledgeBase_Portal_BPMSoft

	/// <summary>
	/// Статья базы знаний.
	/// </summary>
	public class KnowledgeBase_Portal_BPMSoft : BPMSoft.Configuration.KnowledgeBase_SspKnowledgeBase_BPMSoft
	{

		#region Constructors: Public

		public KnowledgeBase_Portal_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "KnowledgeBase_Portal_BPMSoft";
		}

		public KnowledgeBase_Portal_BPMSoft(KnowledgeBase_Portal_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new KnowledgeBase_PortalEventsProcess(UserConnection);
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
			return new KnowledgeBase_Portal_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: KnowledgeBase_PortalEventsProcess

	/// <exclude/>
	public partial class KnowledgeBase_PortalEventsProcess<TEntity> : BPMSoft.Configuration.KnowledgeBase_SspKnowledgeBaseEventsProcess<TEntity> where TEntity : KnowledgeBase_Portal_BPMSoft
	{

		public KnowledgeBase_PortalEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "KnowledgeBase_PortalEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("3f4b5a7e-3599-46f8-b426-2ef29e7fe38f");
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

	#region Class: KnowledgeBase_PortalEventsProcess

	/// <exclude/>
	public class KnowledgeBase_PortalEventsProcess : KnowledgeBase_PortalEventsProcess<KnowledgeBase_Portal_BPMSoft>
	{

		public KnowledgeBase_PortalEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: KnowledgeBase_PortalEventsProcess

	public partial class KnowledgeBase_PortalEventsProcess<TEntity>
	{

		#region Methods: Public

		public override void LocalMessageExecuting(EntityChangeType changeType) {
			var lmHelper = new BPMSoft.Configuration.LocalMessageHelper(this.Entity, UserConnection, changeType);
			lmHelper.CreateLocalMessage();
		}

		#endregion

	}

	#endregion

}

