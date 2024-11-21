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

	#region Class: PartnershipTagSchema

	/// <exclude/>
	public class PartnershipTagSchema : BPMSoft.Configuration.PartnershipTag_PRMBase_BPMSoftSchema
	{

		#region Constructors: Public

		public PartnershipTagSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public PartnershipTagSchema(PartnershipTagSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public PartnershipTagSchema(PartnershipTagSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("bd69dff8-01df-4f88-bdb9-50878665ebff");
			Name = "PartnershipTag";
			ParentSchemaUId = new Guid("dac0dc5a-7f11-41a2-b6c3-2962ba0a70d8");
			ExtendParent = true;
			CreatedInPackageId = new Guid("0fffc5a3-cd85-4e12-bfdb-f47322f14e3d");
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
			return new PartnershipTag(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new PartnershipTag_PRMPortalEventsProcess(userConnection);
		}

		public override object Clone() {
			return new PartnershipTagSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new PartnershipTagSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("bd69dff8-01df-4f88-bdb9-50878665ebff"));
		}

		#endregion

	}

	#endregion

	#region Class: PartnershipTag

	/// <summary>
	/// Partnership section tag.
	/// </summary>
	public class PartnershipTag : BPMSoft.Configuration.PartnershipTag_PRMBase_BPMSoft
	{

		#region Constructors: Public

		public PartnershipTag(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "PartnershipTag";
		}

		public PartnershipTag(PartnershipTag source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new PartnershipTag_PRMPortalEventsProcess(UserConnection);
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
			return new PartnershipTag(this);
		}

		#endregion

	}

	#endregion

	#region Class: PartnershipTag_PRMPortalEventsProcess

	/// <exclude/>
	public partial class PartnershipTag_PRMPortalEventsProcess<TEntity> : BPMSoft.Configuration.PartnershipTag_PRMBaseEventsProcess<TEntity> where TEntity : PartnershipTag
	{

		public PartnershipTag_PRMPortalEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "PartnershipTag_PRMPortalEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("bd69dff8-01df-4f88-bdb9-50878665ebff");
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

	#region Class: PartnershipTag_PRMPortalEventsProcess

	/// <exclude/>
	public class PartnershipTag_PRMPortalEventsProcess : PartnershipTag_PRMPortalEventsProcess<PartnershipTag>
	{

		public PartnershipTag_PRMPortalEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: PartnershipTag_PRMPortalEventsProcess

	public partial class PartnershipTag_PRMPortalEventsProcess<TEntity>
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


	#region Class: PartnershipTagEventsProcess

	/// <exclude/>
	public class PartnershipTagEventsProcess : PartnershipTag_PRMPortalEventsProcess
	{

		public PartnershipTagEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

