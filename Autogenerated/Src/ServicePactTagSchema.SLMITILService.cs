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

	#region Class: ServicePactTagSchema

	/// <exclude/>
	public class ServicePactTagSchema : BPMSoft.Configuration.BaseTagSchema
	{

		#region Constructors: Public

		public ServicePactTagSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ServicePactTagSchema(ServicePactTagSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ServicePactTagSchema(ServicePactTagSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("357ff3c9-7046-4998-ade5-2e85df51efe5");
			RealUId = new Guid("357ff3c9-7046-4998-ade5-2e85df51efe5");
			Name = "ServicePactTag";
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
			column.ModifiedInSchemaUId = new Guid("357ff3c9-7046-4998-ade5-2e85df51efe5");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ServicePactTag(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ServicePactTag_SLMITILServiceEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ServicePactTagSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ServicePactTagSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("357ff3c9-7046-4998-ade5-2e85df51efe5"));
		}

		#endregion

	}

	#endregion

	#region Class: ServicePactTag

	/// <summary>
	/// Тег раздела сервисные договоры.
	/// </summary>
	public class ServicePactTag : BPMSoft.Configuration.BaseTag
	{

		#region Constructors: Public

		public ServicePactTag(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ServicePactTag";
		}

		public ServicePactTag(ServicePactTag source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ServicePactTag_SLMITILServiceEventsProcess(UserConnection);
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
			return new ServicePactTag(this);
		}

		#endregion

	}

	#endregion

	#region Class: ServicePactTag_SLMITILServiceEventsProcess

	/// <exclude/>
	public partial class ServicePactTag_SLMITILServiceEventsProcess<TEntity> : BPMSoft.Configuration.BaseTag_SSPEventsProcess<TEntity> where TEntity : ServicePactTag
	{

		public ServicePactTag_SLMITILServiceEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ServicePactTag_SLMITILServiceEventsProcess";
			SchemaUId = new Guid("357ff3c9-7046-4998-ade5-2e85df51efe5");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("357ff3c9-7046-4998-ade5-2e85df51efe5");
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

	#region Class: ServicePactTag_SLMITILServiceEventsProcess

	/// <exclude/>
	public class ServicePactTag_SLMITILServiceEventsProcess : ServicePactTag_SLMITILServiceEventsProcess<ServicePactTag>
	{

		public ServicePactTag_SLMITILServiceEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ServicePactTag_SLMITILServiceEventsProcess

	public partial class ServicePactTag_SLMITILServiceEventsProcess<TEntity>
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

		public override void LocalMessageExecuting(EntityChangeType changeType) {
			var lmHelper = new BPMSoft.Configuration.LocalMessageHelper(this.Entity, UserConnection, changeType);
			lmHelper.CreateLocalMessage();
		}

		#endregion

	}

	#endregion


	#region Class: ServicePactTagEventsProcess

	/// <exclude/>
	public class ServicePactTagEventsProcess : ServicePactTag_SLMITILServiceEventsProcess
	{

		public ServicePactTagEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

