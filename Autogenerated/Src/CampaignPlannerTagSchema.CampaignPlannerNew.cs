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
	using System.Security;
	using TSConfiguration = BPMSoft.Configuration;

	#region Class: CampaignPlannerTagSchema

	/// <exclude/>
	public class CampaignPlannerTagSchema : BPMSoft.Configuration.BaseTagSchema
	{

		#region Constructors: Public

		public CampaignPlannerTagSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public CampaignPlannerTagSchema(CampaignPlannerTagSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public CampaignPlannerTagSchema(CampaignPlannerTagSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("54772b4b-b72f-4e78-8a00-42ec28331158");
			RealUId = new Guid("54772b4b-b72f-4e78-8a00-42ec28331158");
			Name = "CampaignPlannerTag";
			ParentSchemaUId = new Guid("9e3f203c-e905-4de5-9468-335b193f2439");
			ExtendParent = false;
			CreatedInPackageId = new Guid("9e68a40f-2533-42d0-8fe0-88fdb6bf5704");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override EntitySchemaColumn CreateTypeColumn() {
			EntitySchemaColumn column = base.CreateTypeColumn();
			column.DefValue = new EntitySchemaColumnDef() {
				Source = EntitySchemaColumnDefSource.Const,
				ValueSource = @"8d7f6d6c-4ca5-4b43-bdd9-a5e01a582260"
			};
			column.ModifiedInSchemaUId = new Guid("54772b4b-b72f-4e78-8a00-42ec28331158");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new CampaignPlannerTag(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new CampaignPlannerTag_CampaignPlannerNewEventsProcess(userConnection);
		}

		public override object Clone() {
			return new CampaignPlannerTagSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new CampaignPlannerTagSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("54772b4b-b72f-4e78-8a00-42ec28331158"));
		}

		#endregion

	}

	#endregion

	#region Class: CampaignPlannerTag

	/// <summary>
	/// Тег раздела "Маркетинговые планы".
	/// </summary>
	public class CampaignPlannerTag : BPMSoft.Configuration.BaseTag
	{

		#region Constructors: Public

		public CampaignPlannerTag(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "CampaignPlannerTag";
		}

		public CampaignPlannerTag(CampaignPlannerTag source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new CampaignPlannerTag_CampaignPlannerNewEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("CampaignPlannerTagDeleted", e);
			Validating += (s, e) => ThrowEvent("CampaignPlannerTagValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new CampaignPlannerTag(this);
		}

		#endregion

	}

	#endregion

	#region Class: CampaignPlannerTag_CampaignPlannerNewEventsProcess

	/// <exclude/>
	public partial class CampaignPlannerTag_CampaignPlannerNewEventsProcess<TEntity> : BPMSoft.Configuration.BaseTag_SSPEventsProcess<TEntity> where TEntity : CampaignPlannerTag
	{

		public CampaignPlannerTag_CampaignPlannerNewEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "CampaignPlannerTag_CampaignPlannerNewEventsProcess";
			SchemaUId = new Guid("54772b4b-b72f-4e78-8a00-42ec28331158");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("54772b4b-b72f-4e78-8a00-42ec28331158");
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

	#region Class: CampaignPlannerTag_CampaignPlannerNewEventsProcess

	/// <exclude/>
	public class CampaignPlannerTag_CampaignPlannerNewEventsProcess : CampaignPlannerTag_CampaignPlannerNewEventsProcess<CampaignPlannerTag>
	{

		public CampaignPlannerTag_CampaignPlannerNewEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: CampaignPlannerTag_CampaignPlannerNewEventsProcess

	public partial class CampaignPlannerTag_CampaignPlannerNewEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: CampaignPlannerTagEventsProcess

	/// <exclude/>
	public class CampaignPlannerTagEventsProcess : CampaignPlannerTag_CampaignPlannerNewEventsProcess
	{

		public CampaignPlannerTagEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

