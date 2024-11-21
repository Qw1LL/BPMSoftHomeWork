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

	#region Class: ReleaseInTagSchema

	/// <exclude/>
	public class ReleaseInTagSchema : BPMSoft.Configuration.BaseEntityInTagSchema
	{

		#region Constructors: Public

		public ReleaseInTagSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ReleaseInTagSchema(ReleaseInTagSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ReleaseInTagSchema(ReleaseInTagSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("d07cfc27-9532-4ca1-981c-11178467588c");
			RealUId = new Guid("d07cfc27-9532-4ca1-981c-11178467588c");
			Name = "ReleaseInTag";
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
			column.ReferenceSchemaUId = new Guid("a19489e8-4b93-426c-b59e-43f7f9a2be3e");
			column.ColumnValueName = @"TagId";
			column.DisplayColumnValueName = @"TagName";
			column.ModifiedInSchemaUId = new Guid("d07cfc27-9532-4ca1-981c-11178467588c");
			return column;
		}

		protected override EntitySchemaColumn CreateEntityColumn() {
			EntitySchemaColumn column = base.CreateEntityColumn();
			column.ReferenceSchemaUId = new Guid("0bf3a274-e5da-4fc7-94c4-3ae233598714");
			column.ColumnValueName = @"EntityId";
			column.DisplayColumnValueName = @"EntityNumber";
			column.ModifiedInSchemaUId = new Guid("d07cfc27-9532-4ca1-981c-11178467588c");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ReleaseInTag(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ReleaseInTag_ReleaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ReleaseInTagSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ReleaseInTagSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("d07cfc27-9532-4ca1-981c-11178467588c"));
		}

		#endregion

	}

	#endregion

	#region Class: ReleaseInTag

	/// <summary>
	/// Тег в записи раздела релизы.
	/// </summary>
	public class ReleaseInTag : BPMSoft.Configuration.BaseEntityInTag
	{

		#region Constructors: Public

		public ReleaseInTag(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ReleaseInTag";
		}

		public ReleaseInTag(ReleaseInTag source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ReleaseInTag_ReleaseEventsProcess(UserConnection);
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
			return new ReleaseInTag(this);
		}

		#endregion

	}

	#endregion

	#region Class: ReleaseInTag_ReleaseEventsProcess

	/// <exclude/>
	public partial class ReleaseInTag_ReleaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntityInTag_BaseEventsProcess<TEntity> where TEntity : ReleaseInTag
	{

		public ReleaseInTag_ReleaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ReleaseInTag_ReleaseEventsProcess";
			SchemaUId = new Guid("d07cfc27-9532-4ca1-981c-11178467588c");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("d07cfc27-9532-4ca1-981c-11178467588c");
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

	#region Class: ReleaseInTag_ReleaseEventsProcess

	/// <exclude/>
	public class ReleaseInTag_ReleaseEventsProcess : ReleaseInTag_ReleaseEventsProcess<ReleaseInTag>
	{

		public ReleaseInTag_ReleaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ReleaseInTag_ReleaseEventsProcess

	public partial class ReleaseInTag_ReleaseEventsProcess<TEntity>
	{

		#region Methods: Public

		public override void LocalMessageExecuting(EntityChangeType changeType) {
			var lmHelper = new BPMSoft.Configuration.LocalMessageHelper(this.Entity, UserConnection, changeType);
			lmHelper.CreateLocalMessage();
		}

		#endregion

	}

	#endregion


	#region Class: ReleaseInTagEventsProcess

	/// <exclude/>
	public class ReleaseInTagEventsProcess : ReleaseInTag_ReleaseEventsProcess
	{

		public ReleaseInTagEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

