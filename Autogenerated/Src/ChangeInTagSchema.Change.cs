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

	#region Class: ChangeInTagSchema

	/// <exclude/>
	public class ChangeInTagSchema : BPMSoft.Configuration.BaseEntityInTagSchema
	{

		#region Constructors: Public

		public ChangeInTagSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ChangeInTagSchema(ChangeInTagSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ChangeInTagSchema(ChangeInTagSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("cea7f83a-4aab-46e6-a1ca-5cd579b4dfd9");
			RealUId = new Guid("cea7f83a-4aab-46e6-a1ca-5cd579b4dfd9");
			Name = "ChangeInTag";
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
			column.ReferenceSchemaUId = new Guid("d2157130-eaaa-40ef-b6f6-9ff602f25047");
			column.ColumnValueName = @"TagId";
			column.DisplayColumnValueName = @"TagName";
			column.ModifiedInSchemaUId = new Guid("cea7f83a-4aab-46e6-a1ca-5cd579b4dfd9");
			return column;
		}

		protected override EntitySchemaColumn CreateEntityColumn() {
			EntitySchemaColumn column = base.CreateEntityColumn();
			column.ReferenceSchemaUId = new Guid("de5c8d59-d372-407d-8c09-f0523e057e40");
			column.ColumnValueName = @"EntityId";
			column.DisplayColumnValueName = @"EntityNumber";
			column.ModifiedInSchemaUId = new Guid("cea7f83a-4aab-46e6-a1ca-5cd579b4dfd9");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ChangeInTag(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ChangeInTag_ChangeEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ChangeInTagSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ChangeInTagSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("cea7f83a-4aab-46e6-a1ca-5cd579b4dfd9"));
		}

		#endregion

	}

	#endregion

	#region Class: ChangeInTag

	/// <summary>
	/// Тег в записи раздела изменения.
	/// </summary>
	public class ChangeInTag : BPMSoft.Configuration.BaseEntityInTag
	{

		#region Constructors: Public

		public ChangeInTag(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ChangeInTag";
		}

		public ChangeInTag(ChangeInTag source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ChangeInTag_ChangeEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ChangeInTagDeleted", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ChangeInTag(this);
		}

		#endregion

	}

	#endregion

	#region Class: ChangeInTag_ChangeEventsProcess

	/// <exclude/>
	public partial class ChangeInTag_ChangeEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntityInTag_BaseEventsProcess<TEntity> where TEntity : ChangeInTag
	{

		public ChangeInTag_ChangeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ChangeInTag_ChangeEventsProcess";
			SchemaUId = new Guid("cea7f83a-4aab-46e6-a1ca-5cd579b4dfd9");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("cea7f83a-4aab-46e6-a1ca-5cd579b4dfd9");
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

	#region Class: ChangeInTag_ChangeEventsProcess

	/// <exclude/>
	public class ChangeInTag_ChangeEventsProcess : ChangeInTag_ChangeEventsProcess<ChangeInTag>
	{

		public ChangeInTag_ChangeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ChangeInTag_ChangeEventsProcess

	public partial class ChangeInTag_ChangeEventsProcess<TEntity>
	{

		#region Methods: Public

		public override void LocalMessageExecuting(EntityChangeType changeType) {
			var lmHelper = new BPMSoft.Configuration.LocalMessageHelper(this.Entity, UserConnection, changeType);
			lmHelper.CreateLocalMessage();
		}

		#endregion

	}

	#endregion


	#region Class: ChangeInTagEventsProcess

	/// <exclude/>
	public class ChangeInTagEventsProcess : ChangeInTag_ChangeEventsProcess
	{

		public ChangeInTagEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

