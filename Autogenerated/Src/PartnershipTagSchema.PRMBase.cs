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

	#region Class: PartnershipTag_PRMBase_BPMSoftSchema

	/// <exclude/>
	public class PartnershipTag_PRMBase_BPMSoftSchema : BPMSoft.Configuration.BaseTagSchema
	{

		#region Constructors: Public

		public PartnershipTag_PRMBase_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public PartnershipTag_PRMBase_BPMSoftSchema(PartnershipTag_PRMBase_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public PartnershipTag_PRMBase_BPMSoftSchema(PartnershipTag_PRMBase_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("dac0dc5a-7f11-41a2-b6c3-2962ba0a70d8");
			RealUId = new Guid("dac0dc5a-7f11-41a2-b6c3-2962ba0a70d8");
			Name = "PartnershipTag_PRMBase_BPMSoft";
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

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("dac0dc5a-7f11-41a2-b6c3-2962ba0a70d8");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("dac0dc5a-7f11-41a2-b6c3-2962ba0a70d8");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("dac0dc5a-7f11-41a2-b6c3-2962ba0a70d8");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("dac0dc5a-7f11-41a2-b6c3-2962ba0a70d8");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("dac0dc5a-7f11-41a2-b6c3-2962ba0a70d8");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("dac0dc5a-7f11-41a2-b6c3-2962ba0a70d8");
			return column;
		}

		protected override EntitySchemaColumn CreateTypeColumn() {
			EntitySchemaColumn column = base.CreateTypeColumn();
			column.DefValue = new EntitySchemaColumnDef() {
				Source = EntitySchemaColumnDefSource.Const,
				ValueSource = @"8d7f6d6c-4ca5-4b43-bdd9-a5e01a582260"
			};
			column.ModifiedInSchemaUId = new Guid("dac0dc5a-7f11-41a2-b6c3-2962ba0a70d8");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new PartnershipTag_PRMBase_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new PartnershipTag_PRMBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new PartnershipTag_PRMBase_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new PartnershipTag_PRMBase_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("dac0dc5a-7f11-41a2-b6c3-2962ba0a70d8"));
		}

		#endregion

	}

	#endregion

	#region Class: PartnershipTag_PRMBase_BPMSoft

	/// <summary>
	/// Partnership section tag.
	/// </summary>
	public class PartnershipTag_PRMBase_BPMSoft : BPMSoft.Configuration.BaseTag
	{

		#region Constructors: Public

		public PartnershipTag_PRMBase_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "PartnershipTag_PRMBase_BPMSoft";
		}

		public PartnershipTag_PRMBase_BPMSoft(PartnershipTag_PRMBase_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new PartnershipTag_PRMBaseEventsProcess(UserConnection);
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
			return new PartnershipTag_PRMBase_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: PartnershipTag_PRMBaseEventsProcess

	/// <exclude/>
	public partial class PartnershipTag_PRMBaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseTag_SSPEventsProcess<TEntity> where TEntity : PartnershipTag_PRMBase_BPMSoft
	{

		public PartnershipTag_PRMBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "PartnershipTag_PRMBaseEventsProcess";
			SchemaUId = new Guid("dac0dc5a-7f11-41a2-b6c3-2962ba0a70d8");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("dac0dc5a-7f11-41a2-b6c3-2962ba0a70d8");
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

	#region Class: PartnershipTag_PRMBaseEventsProcess

	/// <exclude/>
	public class PartnershipTag_PRMBaseEventsProcess : PartnershipTag_PRMBaseEventsProcess<PartnershipTag_PRMBase_BPMSoft>
	{

		public PartnershipTag_PRMBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: PartnershipTag_PRMBaseEventsProcess

	public partial class PartnershipTag_PRMBaseEventsProcess<TEntity>
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

