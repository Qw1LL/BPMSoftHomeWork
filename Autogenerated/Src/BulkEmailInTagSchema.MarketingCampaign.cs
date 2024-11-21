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

	#region Class: BulkEmailInTagSchema

	/// <exclude/>
	public class BulkEmailInTagSchema : BPMSoft.Configuration.BaseEntityInTagSchema
	{

		#region Constructors: Public

		public BulkEmailInTagSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public BulkEmailInTagSchema(BulkEmailInTagSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public BulkEmailInTagSchema(BulkEmailInTagSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("f5b48e52-6286-4c23-b4c4-ec719ef62dd6");
			RealUId = new Guid("f5b48e52-6286-4c23-b4c4-ec719ef62dd6");
			Name = "BulkEmailInTag";
			ParentSchemaUId = new Guid("5894a2b0-51d5-419a-82bb-238674634270");
			ExtendParent = false;
			CreatedInPackageId = new Guid("b7874c9a-6e65-41ca-b21f-5fb1f6a22855");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override EntitySchemaColumn CreateTagColumn() {
			EntitySchemaColumn column = base.CreateTagColumn();
			column.ReferenceSchemaUId = new Guid("4d2bfa15-fdd6-4749-8f7c-ecf89f21af3a");
			column.ColumnValueName = @"TagId";
			column.DisplayColumnValueName = @"TagName";
			column.ModifiedInSchemaUId = new Guid("f5b48e52-6286-4c23-b4c4-ec719ef62dd6");
			return column;
		}

		protected override EntitySchemaColumn CreateEntityColumn() {
			EntitySchemaColumn column = base.CreateEntityColumn();
			column.ReferenceSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8");
			column.ColumnValueName = @"EntityId";
			column.DisplayColumnValueName = @"EntityName";
			column.ModifiedInSchemaUId = new Guid("f5b48e52-6286-4c23-b4c4-ec719ef62dd6");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new BulkEmailInTag(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new BulkEmailInTag_MarketingCampaignEventsProcess(userConnection);
		}

		public override object Clone() {
			return new BulkEmailInTagSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new BulkEmailInTagSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("f5b48e52-6286-4c23-b4c4-ec719ef62dd6"));
		}

		#endregion

	}

	#endregion

	#region Class: BulkEmailInTag

	/// <summary>
	/// Тег в записи раздела email.
	/// </summary>
	public class BulkEmailInTag : BPMSoft.Configuration.BaseEntityInTag
	{

		#region Constructors: Public

		public BulkEmailInTag(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "BulkEmailInTag";
		}

		public BulkEmailInTag(BulkEmailInTag source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new BulkEmailInTag_MarketingCampaignEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("BulkEmailInTagDeleted", e);
			Validating += (s, e) => ThrowEvent("BulkEmailInTagValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new BulkEmailInTag(this);
		}

		#endregion

	}

	#endregion

	#region Class: BulkEmailInTag_MarketingCampaignEventsProcess

	/// <exclude/>
	public partial class BulkEmailInTag_MarketingCampaignEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntityInTag_BaseEventsProcess<TEntity> where TEntity : BulkEmailInTag
	{

		public BulkEmailInTag_MarketingCampaignEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "BulkEmailInTag_MarketingCampaignEventsProcess";
			SchemaUId = new Guid("f5b48e52-6286-4c23-b4c4-ec719ef62dd6");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("f5b48e52-6286-4c23-b4c4-ec719ef62dd6");
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

	#region Class: BulkEmailInTag_MarketingCampaignEventsProcess

	/// <exclude/>
	public class BulkEmailInTag_MarketingCampaignEventsProcess : BulkEmailInTag_MarketingCampaignEventsProcess<BulkEmailInTag>
	{

		public BulkEmailInTag_MarketingCampaignEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: BulkEmailInTag_MarketingCampaignEventsProcess

	public partial class BulkEmailInTag_MarketingCampaignEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: BulkEmailInTagEventsProcess

	/// <exclude/>
	public class BulkEmailInTagEventsProcess : BulkEmailInTag_MarketingCampaignEventsProcess
	{

		public BulkEmailInTagEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

