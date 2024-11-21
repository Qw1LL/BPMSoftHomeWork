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

	#region Class: KnowledgeBaseSchema

	/// <exclude/>
	public class KnowledgeBaseSchema : BPMSoft.Configuration.KnowledgeBase_Portal_BPMSoftSchema
	{

		#region Constructors: Public

		public KnowledgeBaseSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public KnowledgeBaseSchema(KnowledgeBaseSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public KnowledgeBaseSchema(KnowledgeBaseSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("418c3a66-8bd3-4484-96ea-cf5b8df52b27");
			Name = "KnowledgeBase";
			ParentSchemaUId = new Guid("0326868c-ce5e-4934-8f1f-178801bfe6c3");
			ExtendParent = true;
			CreatedInPackageId = new Guid("ba438a7b-1c87-4703-9a24-35e026996df4");
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
			return new KnowledgeBase(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new KnowledgeBase_PRMPortalEventsProcess(userConnection);
		}

		public override object Clone() {
			return new KnowledgeBaseSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new KnowledgeBaseSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("418c3a66-8bd3-4484-96ea-cf5b8df52b27"));
		}

		#endregion

	}

	#endregion

	#region Class: KnowledgeBase

	/// <summary>
	/// Статья базы знаний.
	/// </summary>
	public class KnowledgeBase : BPMSoft.Configuration.KnowledgeBase_Portal_BPMSoft
	{

		#region Constructors: Public

		public KnowledgeBase(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "KnowledgeBase";
		}

		public KnowledgeBase(KnowledgeBase source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new KnowledgeBase_PRMPortalEventsProcess(UserConnection);
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
			return new KnowledgeBase(this);
		}

		#endregion

	}

	#endregion

	#region Class: KnowledgeBase_PRMPortalEventsProcess

	/// <exclude/>
	public partial class KnowledgeBase_PRMPortalEventsProcess<TEntity> : BPMSoft.Configuration.KnowledgeBase_PortalEventsProcess<TEntity> where TEntity : KnowledgeBase
	{

		public KnowledgeBase_PRMPortalEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "KnowledgeBase_PRMPortalEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("418c3a66-8bd3-4484-96ea-cf5b8df52b27");
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

	#region Class: KnowledgeBase_PRMPortalEventsProcess

	/// <exclude/>
	public class KnowledgeBase_PRMPortalEventsProcess : KnowledgeBase_PRMPortalEventsProcess<KnowledgeBase>
	{

		public KnowledgeBase_PRMPortalEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: KnowledgeBase_PRMPortalEventsProcess

	public partial class KnowledgeBase_PRMPortalEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: KnowledgeBaseEventsProcess

	/// <exclude/>
	public class KnowledgeBaseEventsProcess : KnowledgeBase_PRMPortalEventsProcess
	{

		public KnowledgeBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

