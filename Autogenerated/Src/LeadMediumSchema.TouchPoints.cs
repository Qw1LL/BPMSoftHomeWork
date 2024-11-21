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

	#region Class: LeadMedium_TouchPoints_BPMSoftSchema

	/// <exclude/>
	public class LeadMedium_TouchPoints_BPMSoftSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public LeadMedium_TouchPoints_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public LeadMedium_TouchPoints_BPMSoftSchema(LeadMedium_TouchPoints_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public LeadMedium_TouchPoints_BPMSoftSchema(LeadMedium_TouchPoints_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("308ef8cd-4f4f-4898-9b3d-36ab9af01f5c");
			RealUId = new Guid("308ef8cd-4f4f-4898-9b3d-36ab9af01f5c");
			Name = "LeadMedium_TouchPoints_BPMSoft";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("6cdbb516-9811-46ca-a4f8-441ae8e11086");
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
			return new LeadMedium_TouchPoints_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new LeadMedium_TouchPointsEventsProcess(userConnection);
		}

		public override object Clone() {
			return new LeadMedium_TouchPoints_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new LeadMedium_TouchPoints_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("308ef8cd-4f4f-4898-9b3d-36ab9af01f5c"));
		}

		#endregion

	}

	#endregion

	#region Class: LeadMedium_TouchPoints_BPMSoft

	/// <summary>
	/// Channel.
	/// </summary>
	public class LeadMedium_TouchPoints_BPMSoft : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public LeadMedium_TouchPoints_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "LeadMedium_TouchPoints_BPMSoft";
		}

		public LeadMedium_TouchPoints_BPMSoft(LeadMedium_TouchPoints_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new LeadMedium_TouchPointsEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("LeadMedium_TouchPoints_BPMSoftDeleted", e);
			Validating += (s, e) => ThrowEvent("LeadMedium_TouchPoints_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new LeadMedium_TouchPoints_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: LeadMedium_TouchPointsEventsProcess

	/// <exclude/>
	public partial class LeadMedium_TouchPointsEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : LeadMedium_TouchPoints_BPMSoft
	{

		public LeadMedium_TouchPointsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "LeadMedium_TouchPointsEventsProcess";
			SchemaUId = new Guid("308ef8cd-4f4f-4898-9b3d-36ab9af01f5c");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("308ef8cd-4f4f-4898-9b3d-36ab9af01f5c");
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

	#region Class: LeadMedium_TouchPointsEventsProcess

	/// <exclude/>
	public class LeadMedium_TouchPointsEventsProcess : LeadMedium_TouchPointsEventsProcess<LeadMedium_TouchPoints_BPMSoft>
	{

		public LeadMedium_TouchPointsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: LeadMedium_TouchPointsEventsProcess

	public partial class LeadMedium_TouchPointsEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

