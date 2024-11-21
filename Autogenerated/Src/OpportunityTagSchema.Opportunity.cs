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

	#region Class: OpportunityTag_Opportunity_BPMSoftSchema

	/// <exclude/>
	public class OpportunityTag_Opportunity_BPMSoftSchema : BPMSoft.Configuration.BaseTagSchema
	{

		#region Constructors: Public

		public OpportunityTag_Opportunity_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public OpportunityTag_Opportunity_BPMSoftSchema(OpportunityTag_Opportunity_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public OpportunityTag_Opportunity_BPMSoftSchema(OpportunityTag_Opportunity_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("7e18476b-185f-406b-b415-b942b35b4c0b");
			RealUId = new Guid("7e18476b-185f-406b-b415-b942b35b4c0b");
			Name = "OpportunityTag_Opportunity_BPMSoft";
			ParentSchemaUId = new Guid("9e3f203c-e905-4de5-9468-335b193f2439");
			ExtendParent = false;
			CreatedInPackageId = new Guid("dfe2c6b5-61e8-4e57-95ae-a3c34fa0908f");
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
			column.ModifiedInSchemaUId = new Guid("7e18476b-185f-406b-b415-b942b35b4c0b");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new OpportunityTag_Opportunity_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new OpportunityTag_OpportunityEventsProcess(userConnection);
		}

		public override object Clone() {
			return new OpportunityTag_Opportunity_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new OpportunityTag_Opportunity_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("7e18476b-185f-406b-b415-b942b35b4c0b"));
		}

		#endregion

	}

	#endregion

	#region Class: OpportunityTag_Opportunity_BPMSoft

	/// <summary>
	/// Тег раздела продажи.
	/// </summary>
	public class OpportunityTag_Opportunity_BPMSoft : BPMSoft.Configuration.BaseTag
	{

		#region Constructors: Public

		public OpportunityTag_Opportunity_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "OpportunityTag_Opportunity_BPMSoft";
		}

		public OpportunityTag_Opportunity_BPMSoft(OpportunityTag_Opportunity_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new OpportunityTag_OpportunityEventsProcess(UserConnection);
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
			return new OpportunityTag_Opportunity_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: OpportunityTag_OpportunityEventsProcess

	/// <exclude/>
	public partial class OpportunityTag_OpportunityEventsProcess<TEntity> : BPMSoft.Configuration.BaseTag_SSPEventsProcess<TEntity> where TEntity : OpportunityTag_Opportunity_BPMSoft
	{

		public OpportunityTag_OpportunityEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "OpportunityTag_OpportunityEventsProcess";
			SchemaUId = new Guid("7e18476b-185f-406b-b415-b942b35b4c0b");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("7e18476b-185f-406b-b415-b942b35b4c0b");
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

	#region Class: OpportunityTag_OpportunityEventsProcess

	/// <exclude/>
	public class OpportunityTag_OpportunityEventsProcess : OpportunityTag_OpportunityEventsProcess<OpportunityTag_Opportunity_BPMSoft>
	{

		public OpportunityTag_OpportunityEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: OpportunityTag_OpportunityEventsProcess

	public partial class OpportunityTag_OpportunityEventsProcess<TEntity>
	{

		#region Methods: Public

		public override void CheckTagTypeAndGrantAdditionalRights() {
			base.CheckTagTypeAndGrantAdditionalRights();
			Guid typeId = Entity.GetTypedColumnValue<Guid>("TypeId");
			if (typeId == TSConfiguration.TagConsts.PublicTagTypeUId) {
				UserConnection.DBSecurityEngine.SetEntitySchemaRecordRightLevel(TSConfiguration.BaseConsts.PortalUsersSysAdminUnitUId, 
						Entity.Schema, Entity.PrimaryColumnValue, SchemaRecordRightLevels.All); 
			}
		}

		#endregion

	}

	#endregion

}

