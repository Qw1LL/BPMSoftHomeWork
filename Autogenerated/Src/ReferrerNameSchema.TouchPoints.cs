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

	#region Class: ReferrerNameSchema

	/// <exclude/>
	public class ReferrerNameSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public ReferrerNameSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ReferrerNameSchema(ReferrerNameSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ReferrerNameSchema(ReferrerNameSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("8dabc088-2beb-4667-9d8e-cd4651bcdb5b");
			RealUId = new Guid("8dabc088-2beb-4667-9d8e-cd4651bcdb5b");
			Name = "ReferrerName";
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
			return new ReferrerName(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ReferrerName_TouchPointsEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ReferrerNameSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ReferrerNameSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("8dabc088-2beb-4667-9d8e-cd4651bcdb5b"));
		}

		#endregion

	}

	#endregion

	#region Class: ReferrerName

	/// <summary>
	/// Referrer name.
	/// </summary>
	public class ReferrerName : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public ReferrerName(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ReferrerName";
		}

		public ReferrerName(ReferrerName source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ReferrerName_TouchPointsEventsProcess(UserConnection);
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
			return new ReferrerName(this);
		}

		#endregion

	}

	#endregion

	#region Class: ReferrerName_TouchPointsEventsProcess

	/// <exclude/>
	public partial class ReferrerName_TouchPointsEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : ReferrerName
	{

		public ReferrerName_TouchPointsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ReferrerName_TouchPointsEventsProcess";
			SchemaUId = new Guid("8dabc088-2beb-4667-9d8e-cd4651bcdb5b");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("8dabc088-2beb-4667-9d8e-cd4651bcdb5b");
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

	#region Class: ReferrerName_TouchPointsEventsProcess

	/// <exclude/>
	public class ReferrerName_TouchPointsEventsProcess : ReferrerName_TouchPointsEventsProcess<ReferrerName>
	{

		public ReferrerName_TouchPointsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ReferrerName_TouchPointsEventsProcess

	public partial class ReferrerName_TouchPointsEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ReferrerNameEventsProcess

	/// <exclude/>
	public class ReferrerNameEventsProcess : ReferrerName_TouchPointsEventsProcess
	{

		public ReferrerNameEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

