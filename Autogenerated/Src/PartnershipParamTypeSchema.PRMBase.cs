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

	#region Class: PartnershipParamTypeSchema

	/// <exclude/>
	public class PartnershipParamTypeSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public PartnershipParamTypeSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public PartnershipParamTypeSchema(PartnershipParamTypeSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public PartnershipParamTypeSchema(PartnershipParamTypeSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("dc90b3b7-0cd1-41a3-a9f0-24322ece222a");
			RealUId = new Guid("dc90b3b7-0cd1-41a3-a9f0-24322ece222a");
			Name = "PartnershipParamType";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("867b9a25-86bf-4a3e-8ecd-b6e40f57be82");
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
			return new PartnershipParamType(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new PartnershipParamType_PRMBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new PartnershipParamTypeSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new PartnershipParamTypeSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("dc90b3b7-0cd1-41a3-a9f0-24322ece222a"));
		}

		#endregion

	}

	#endregion

	#region Class: PartnershipParamType

	/// <summary>
	/// Тип параматетра партнерства.
	/// </summary>
	public class PartnershipParamType : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public PartnershipParamType(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "PartnershipParamType";
		}

		public PartnershipParamType(PartnershipParamType source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new PartnershipParamType_PRMBaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("PartnershipParamTypeDeleted", e);
			Validating += (s, e) => ThrowEvent("PartnershipParamTypeValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new PartnershipParamType(this);
		}

		#endregion

	}

	#endregion

	#region Class: PartnershipParamType_PRMBaseEventsProcess

	/// <exclude/>
	public partial class PartnershipParamType_PRMBaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : PartnershipParamType
	{

		public PartnershipParamType_PRMBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "PartnershipParamType_PRMBaseEventsProcess";
			SchemaUId = new Guid("dc90b3b7-0cd1-41a3-a9f0-24322ece222a");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("dc90b3b7-0cd1-41a3-a9f0-24322ece222a");
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

	#region Class: PartnershipParamType_PRMBaseEventsProcess

	/// <exclude/>
	public class PartnershipParamType_PRMBaseEventsProcess : PartnershipParamType_PRMBaseEventsProcess<PartnershipParamType>
	{

		public PartnershipParamType_PRMBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: PartnershipParamType_PRMBaseEventsProcess

	public partial class PartnershipParamType_PRMBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: PartnershipParamTypeEventsProcess

	/// <exclude/>
	public class PartnershipParamTypeEventsProcess : PartnershipParamType_PRMBaseEventsProcess
	{

		public PartnershipParamTypeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

