namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Process;
	using BPMSoft.Core.Process.Configuration;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Drawing;
	using System.Globalization;
	using System.IO;

	#region Class: UsrTransportRequestsTagSchema

	/// <exclude/>
	public class UsrTransportRequestsTagSchema : BPMSoft.Configuration.BaseTagSchema
	{

		#region Constructors: Public

		public UsrTransportRequestsTagSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public UsrTransportRequestsTagSchema(UsrTransportRequestsTagSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public UsrTransportRequestsTagSchema(UsrTransportRequestsTagSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("9205a892-332f-4ba9-9834-51eb8acd4ea8");
			RealUId = new Guid("9205a892-332f-4ba9-9834-51eb8acd4ea8");
			Name = "UsrTransportRequestsTag";
			ParentSchemaUId = new Guid("9e3f203c-e905-4de5-9468-335b193f2439");
			ExtendParent = false;
			CreatedInPackageId = new Guid("3c4d067d-156b-4f1a-95fd-baa9da73b631");
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
			return new UsrTransportRequestsTag(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new UsrTransportRequestsTag_UsrHomeWorkEventsProcess(userConnection);
		}

		public override object Clone() {
			return new UsrTransportRequestsTagSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new UsrTransportRequestsTagSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("9205a892-332f-4ba9-9834-51eb8acd4ea8"));
		}

		#endregion

	}

	#endregion

	#region Class: UsrTransportRequestsTag

	/// <summary>
	/// Тег раздела Заявки на транспорт.
	/// </summary>
	public class UsrTransportRequestsTag : BPMSoft.Configuration.BaseTag
	{

		#region Constructors: Public

		public UsrTransportRequestsTag(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "UsrTransportRequestsTag";
		}

		public UsrTransportRequestsTag(UsrTransportRequestsTag source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new UsrTransportRequestsTag_UsrHomeWorkEventsProcess(UserConnection);
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
			return new UsrTransportRequestsTag(this);
		}

		#endregion

	}

	#endregion

	#region Class: UsrTransportRequestsTag_UsrHomeWorkEventsProcess

	/// <exclude/>
	public partial class UsrTransportRequestsTag_UsrHomeWorkEventsProcess<TEntity> : BPMSoft.Configuration.BaseTag_SSPEventsProcess<TEntity> where TEntity : UsrTransportRequestsTag
	{

		public UsrTransportRequestsTag_UsrHomeWorkEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "UsrTransportRequestsTag_UsrHomeWorkEventsProcess";
			SchemaUId = new Guid("9205a892-332f-4ba9-9834-51eb8acd4ea8");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("9205a892-332f-4ba9-9834-51eb8acd4ea8");
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

	#region Class: UsrTransportRequestsTag_UsrHomeWorkEventsProcess

	/// <exclude/>
	public class UsrTransportRequestsTag_UsrHomeWorkEventsProcess : UsrTransportRequestsTag_UsrHomeWorkEventsProcess<UsrTransportRequestsTag>
	{

		public UsrTransportRequestsTag_UsrHomeWorkEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: UsrTransportRequestsTag_UsrHomeWorkEventsProcess

	public partial class UsrTransportRequestsTag_UsrHomeWorkEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: UsrTransportRequestsTagEventsProcess

	/// <exclude/>
	public class UsrTransportRequestsTagEventsProcess : UsrTransportRequestsTag_UsrHomeWorkEventsProcess
	{

		public UsrTransportRequestsTagEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

