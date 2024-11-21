namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Configuration;
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

	#region Class: PartnershipParameterSchema

	/// <exclude/>
	public class PartnershipParameterSchema : BPMSoft.Configuration.PartnershipParameter_PRMBase_BPMSoftSchema
	{

		#region Constructors: Public

		public PartnershipParameterSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public PartnershipParameterSchema(PartnershipParameterSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public PartnershipParameterSchema(PartnershipParameterSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("c57527fd-e61f-4be7-a1ea-597100a577f5");
			Name = "PartnershipParameter";
			ParentSchemaUId = new Guid("7f8f62f1-29e5-4dd7-b206-f083a712f039");
			ExtendParent = true;
			CreatedInPackageId = new Guid("d0cf4ca6-907d-4eba-86db-4399f9ff6801");
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
			return new PartnershipParameter(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new PartnershipParameter_PRMOrderEventsProcess(userConnection);
		}

		public override object Clone() {
			return new PartnershipParameterSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new PartnershipParameterSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("c57527fd-e61f-4be7-a1ea-597100a577f5"));
		}

		#endregion

	}

	#endregion

	#region Class: PartnershipParameter

	/// <summary>
	/// PartnershipParameter.
	/// </summary>
	public class PartnershipParameter : BPMSoft.Configuration.PartnershipParameter_PRMBase_BPMSoft
	{

		#region Constructors: Public

		public PartnershipParameter(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "PartnershipParameter";
		}

		public PartnershipParameter(PartnershipParameter source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new PartnershipParameter_PRMOrderEventsProcess(UserConnection);
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
			return new PartnershipParameter(this);
		}

		#endregion

	}

	#endregion

	#region Class: PartnershipParameter_PRMOrderEventsProcess

	/// <exclude/>
	public partial class PartnershipParameter_PRMOrderEventsProcess<TEntity> : BPMSoft.Configuration.PartnershipParameter_PRMBaseEventsProcess<TEntity> where TEntity : PartnershipParameter
	{

		public PartnershipParameter_PRMOrderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "PartnershipParameter_PRMOrderEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("c57527fd-e61f-4be7-a1ea-597100a577f5");
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

	#region Class: PartnershipParameter_PRMOrderEventsProcess

	/// <exclude/>
	public class PartnershipParameter_PRMOrderEventsProcess : PartnershipParameter_PRMOrderEventsProcess<PartnershipParameter>
	{

		public PartnershipParameter_PRMOrderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion


	#region Class: PartnershipParameterEventsProcess

	/// <exclude/>
	public class PartnershipParameterEventsProcess : PartnershipParameter_PRMOrderEventsProcess
	{

		public PartnershipParameterEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

