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

	#region Class: CampaignPlannerInTagSchema

	/// <exclude/>
	public class CampaignPlannerInTagSchema : BPMSoft.Configuration.BaseEntityInTagSchema
	{

		#region Constructors: Public

		public CampaignPlannerInTagSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public CampaignPlannerInTagSchema(CampaignPlannerInTagSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public CampaignPlannerInTagSchema(CampaignPlannerInTagSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("e4d41a91-d7e2-45a9-b746-386c6e94de56");
			RealUId = new Guid("e4d41a91-d7e2-45a9-b746-386c6e94de56");
			Name = "CampaignPlannerInTag";
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
			column.ReferenceSchemaUId = new Guid("54772b4b-b72f-4e78-8a00-42ec28331158");
			column.ColumnValueName = @"TagId";
			column.DisplayColumnValueName = @"TagName";
			column.ModifiedInSchemaUId = new Guid("e4d41a91-d7e2-45a9-b746-386c6e94de56");
			return column;
		}

		protected override EntitySchemaColumn CreateEntityColumn() {
			EntitySchemaColumn column = base.CreateEntityColumn();
			column.ReferenceSchemaUId = new Guid("f193aa9c-3e39-442f-8028-f666a64b262a");
			column.ColumnValueName = @"EntityId";
			column.DisplayColumnValueName = @"EntityName";
			column.ModifiedInSchemaUId = new Guid("e4d41a91-d7e2-45a9-b746-386c6e94de56");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new CampaignPlannerInTag(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new CampaignPlannerInTag_CampaignPlannerNewEventsProcess(userConnection);
		}

		public override object Clone() {
			return new CampaignPlannerInTagSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new CampaignPlannerInTagSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("e4d41a91-d7e2-45a9-b746-386c6e94de56"));
		}

		#endregion

	}

	#endregion

	#region Class: CampaignPlannerInTag

	/// <summary>
	/// Тег в записи раздела "Маркетинговые планы".
	/// </summary>
	public class CampaignPlannerInTag : BPMSoft.Configuration.BaseEntityInTag
	{

		#region Constructors: Public

		public CampaignPlannerInTag(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "CampaignPlannerInTag";
		}

		public CampaignPlannerInTag(CampaignPlannerInTag source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new CampaignPlannerInTag_CampaignPlannerNewEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("CampaignPlannerInTagDeleted", e);
			Validating += (s, e) => ThrowEvent("CampaignPlannerInTagValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new CampaignPlannerInTag(this);
		}

		#endregion

	}

	#endregion

	#region Class: CampaignPlannerInTag_CampaignPlannerNewEventsProcess

	/// <exclude/>
	public partial class CampaignPlannerInTag_CampaignPlannerNewEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntityInTag_BaseEventsProcess<TEntity> where TEntity : CampaignPlannerInTag
	{

		public CampaignPlannerInTag_CampaignPlannerNewEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "CampaignPlannerInTag_CampaignPlannerNewEventsProcess";
			SchemaUId = new Guid("e4d41a91-d7e2-45a9-b746-386c6e94de56");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("e4d41a91-d7e2-45a9-b746-386c6e94de56");
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

	#region Class: CampaignPlannerInTag_CampaignPlannerNewEventsProcess

	/// <exclude/>
	public class CampaignPlannerInTag_CampaignPlannerNewEventsProcess : CampaignPlannerInTag_CampaignPlannerNewEventsProcess<CampaignPlannerInTag>
	{

		public CampaignPlannerInTag_CampaignPlannerNewEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: CampaignPlannerInTag_CampaignPlannerNewEventsProcess

	public partial class CampaignPlannerInTag_CampaignPlannerNewEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: CampaignPlannerInTagEventsProcess

	/// <exclude/>
	public class CampaignPlannerInTagEventsProcess : CampaignPlannerInTag_CampaignPlannerNewEventsProcess
	{

		public CampaignPlannerInTagEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

