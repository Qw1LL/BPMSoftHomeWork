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

	#region Class: UsrTransportRequestsInTagSchema

	/// <exclude/>
	public class UsrTransportRequestsInTagSchema : BPMSoft.Configuration.BaseEntityInTagSchema
	{

		#region Constructors: Public

		public UsrTransportRequestsInTagSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public UsrTransportRequestsInTagSchema(UsrTransportRequestsInTagSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public UsrTransportRequestsInTagSchema(UsrTransportRequestsInTagSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("60375376-abcd-4650-a625-6a02b1402042");
			RealUId = new Guid("60375376-abcd-4650-a625-6a02b1402042");
			Name = "UsrTransportRequestsInTag";
			ParentSchemaUId = new Guid("5894a2b0-51d5-419a-82bb-238674634270");
			ExtendParent = false;
			CreatedInPackageId = new Guid("3c4d067d-156b-4f1a-95fd-baa9da73b631");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override EntitySchemaColumn CreateTagColumn() {
			EntitySchemaColumn column = base.CreateTagColumn();
			column.ReferenceSchemaUId = new Guid("9205a892-332f-4ba9-9834-51eb8acd4ea8");
			column.ColumnValueName = @"TagId";
			column.DisplayColumnValueName = @"TagName";
			column.ModifiedInSchemaUId = new Guid("60375376-abcd-4650-a625-6a02b1402042");
			return column;
		}

		protected override EntitySchemaColumn CreateEntityColumn() {
			EntitySchemaColumn column = base.CreateEntityColumn();
			column.ReferenceSchemaUId = new Guid("ce3557cf-4e38-45eb-aa71-502879d15cd5");
			column.ColumnValueName = @"EntityId";
			column.DisplayColumnValueName = @"EntityUsrName";
			column.ModifiedInSchemaUId = new Guid("60375376-abcd-4650-a625-6a02b1402042");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new UsrTransportRequestsInTag(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new UsrTransportRequestsInTag_UsrHomeWorkEventsProcess(userConnection);
		}

		public override object Clone() {
			return new UsrTransportRequestsInTagSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new UsrTransportRequestsInTagSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("60375376-abcd-4650-a625-6a02b1402042"));
		}

		#endregion

	}

	#endregion

	#region Class: UsrTransportRequestsInTag

	/// <summary>
	/// Тег в записи раздела Заявки на транспорт.
	/// </summary>
	public class UsrTransportRequestsInTag : BPMSoft.Configuration.BaseEntityInTag
	{

		#region Constructors: Public

		public UsrTransportRequestsInTag(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "UsrTransportRequestsInTag";
		}

		public UsrTransportRequestsInTag(UsrTransportRequestsInTag source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new UsrTransportRequestsInTag_UsrHomeWorkEventsProcess(UserConnection);
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
			return new UsrTransportRequestsInTag(this);
		}

		#endregion

	}

	#endregion

	#region Class: UsrTransportRequestsInTag_UsrHomeWorkEventsProcess

	/// <exclude/>
	public partial class UsrTransportRequestsInTag_UsrHomeWorkEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntityInTag_BaseEventsProcess<TEntity> where TEntity : UsrTransportRequestsInTag
	{

		public UsrTransportRequestsInTag_UsrHomeWorkEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "UsrTransportRequestsInTag_UsrHomeWorkEventsProcess";
			SchemaUId = new Guid("60375376-abcd-4650-a625-6a02b1402042");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("60375376-abcd-4650-a625-6a02b1402042");
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

	#region Class: UsrTransportRequestsInTag_UsrHomeWorkEventsProcess

	/// <exclude/>
	public class UsrTransportRequestsInTag_UsrHomeWorkEventsProcess : UsrTransportRequestsInTag_UsrHomeWorkEventsProcess<UsrTransportRequestsInTag>
	{

		public UsrTransportRequestsInTag_UsrHomeWorkEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: UsrTransportRequestsInTag_UsrHomeWorkEventsProcess

	public partial class UsrTransportRequestsInTag_UsrHomeWorkEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: UsrTransportRequestsInTagEventsProcess

	/// <exclude/>
	public class UsrTransportRequestsInTagEventsProcess : UsrTransportRequestsInTag_UsrHomeWorkEventsProcess
	{

		public UsrTransportRequestsInTagEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

