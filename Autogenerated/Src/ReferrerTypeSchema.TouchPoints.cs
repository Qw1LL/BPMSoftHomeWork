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

	#region Class: ReferrerTypeSchema

	/// <exclude/>
	public class ReferrerTypeSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public ReferrerTypeSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ReferrerTypeSchema(ReferrerTypeSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ReferrerTypeSchema(ReferrerTypeSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("0aa9fb42-d3d0-4981-841f-eed551db7db5");
			RealUId = new Guid("0aa9fb42-d3d0-4981-841f-eed551db7db5");
			Name = "ReferrerType";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("d23d224d-d671-416d-91d0-80132a374d7a");
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
			return new ReferrerType(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ReferrerType_TouchPointsEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ReferrerTypeSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ReferrerTypeSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("0aa9fb42-d3d0-4981-841f-eed551db7db5"));
		}

		#endregion

	}

	#endregion

	#region Class: ReferrerType

	/// <summary>
	/// Referrer type.
	/// </summary>
	public class ReferrerType : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public ReferrerType(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ReferrerType";
		}

		public ReferrerType(ReferrerType source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ReferrerType_TouchPointsEventsProcess(UserConnection);
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
			return new ReferrerType(this);
		}

		#endregion

	}

	#endregion

	#region Class: ReferrerType_TouchPointsEventsProcess

	/// <exclude/>
	public partial class ReferrerType_TouchPointsEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : ReferrerType
	{

		public ReferrerType_TouchPointsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ReferrerType_TouchPointsEventsProcess";
			SchemaUId = new Guid("0aa9fb42-d3d0-4981-841f-eed551db7db5");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("0aa9fb42-d3d0-4981-841f-eed551db7db5");
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

	#region Class: ReferrerType_TouchPointsEventsProcess

	/// <exclude/>
	public class ReferrerType_TouchPointsEventsProcess : ReferrerType_TouchPointsEventsProcess<ReferrerType>
	{

		public ReferrerType_TouchPointsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ReferrerType_TouchPointsEventsProcess

	public partial class ReferrerType_TouchPointsEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ReferrerTypeEventsProcess

	/// <exclude/>
	public class ReferrerTypeEventsProcess : ReferrerType_TouchPointsEventsProcess
	{

		public ReferrerTypeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

