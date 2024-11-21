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

	#region Class: VwServiceRecepientsSchema

	/// <exclude/>
	public class VwServiceRecepientsSchema : BPMSoft.Configuration.VwServiceRecepients_SLMITILService_BPMSoftSchema
	{

		#region Constructors: Public

		public VwServiceRecepientsSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwServiceRecepientsSchema(VwServiceRecepientsSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwServiceRecepientsSchema(VwServiceRecepientsSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("36fe8d73-6077-42e4-b22f-704d61d188fa");
			Name = "VwServiceRecepients";
			ParentSchemaUId = new Guid("bef8b415-16ee-4d17-8691-458a112c3d17");
			ExtendParent = true;
			CreatedInPackageId = new Guid("f86380cb-7b6d-4263-829e-bbe3aca599d6");
			IsDBView = true;
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
			return new VwServiceRecepients(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwServiceRecepients_PortalITILServiceEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwServiceRecepientsSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwServiceRecepientsSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("36fe8d73-6077-42e4-b22f-704d61d188fa"));
		}

		#endregion

	}

	#endregion

	#region Class: VwServiceRecepients

	/// <summary>
	/// Пользователи сервисов.
	/// </summary>
	public class VwServiceRecepients : BPMSoft.Configuration.VwServiceRecepients_SLMITILService_BPMSoft
	{

		#region Constructors: Public

		public VwServiceRecepients(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwServiceRecepients";
		}

		public VwServiceRecepients(VwServiceRecepients source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new VwServiceRecepients_PortalITILServiceEventsProcess(UserConnection);
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
			return new VwServiceRecepients(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwServiceRecepients_PortalITILServiceEventsProcess

	/// <exclude/>
	public partial class VwServiceRecepients_PortalITILServiceEventsProcess<TEntity> : BPMSoft.Configuration.VwServiceRecepients_SLMITILServiceEventsProcess<TEntity> where TEntity : VwServiceRecepients
	{

		public VwServiceRecepients_PortalITILServiceEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwServiceRecepients_PortalITILServiceEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("36fe8d73-6077-42e4-b22f-704d61d188fa");
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

	#region Class: VwServiceRecepients_PortalITILServiceEventsProcess

	/// <exclude/>
	public class VwServiceRecepients_PortalITILServiceEventsProcess : VwServiceRecepients_PortalITILServiceEventsProcess<VwServiceRecepients>
	{

		public VwServiceRecepients_PortalITILServiceEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VwServiceRecepients_PortalITILServiceEventsProcess

	public partial class VwServiceRecepients_PortalITILServiceEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: VwServiceRecepientsEventsProcess

	/// <exclude/>
	public class VwServiceRecepientsEventsProcess : VwServiceRecepients_PortalITILServiceEventsProcess
	{

		public VwServiceRecepientsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

