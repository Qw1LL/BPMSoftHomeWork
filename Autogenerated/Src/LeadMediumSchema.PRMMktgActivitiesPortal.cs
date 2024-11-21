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

	#region Class: LeadMediumSchema

	/// <exclude/>
	public class LeadMediumSchema : BPMSoft.Configuration.LeadMedium_TouchPoints_BPMSoftSchema
	{

		#region Constructors: Public

		public LeadMediumSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public LeadMediumSchema(LeadMediumSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public LeadMediumSchema(LeadMediumSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("ef1d88de-d0b2-4fe3-9e57-981e35e8e370");
			Name = "LeadMedium";
			ParentSchemaUId = new Guid("308ef8cd-4f4f-4898-9b3d-36ab9af01f5c");
			ExtendParent = true;
			CreatedInPackageId = new Guid("be128478-78b2-4e0c-970c-9dfa8eab194e");
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
			return new LeadMedium(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new LeadMedium_PRMMktgActivitiesPortalEventsProcess(userConnection);
		}

		public override object Clone() {
			return new LeadMediumSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new LeadMediumSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ef1d88de-d0b2-4fe3-9e57-981e35e8e370"));
		}

		#endregion

	}

	#endregion

	#region Class: LeadMedium

	/// <summary>
	/// Канал.
	/// </summary>
	public class LeadMedium : BPMSoft.Configuration.LeadMedium_TouchPoints_BPMSoft
	{

		#region Constructors: Public

		public LeadMedium(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "LeadMedium";
		}

		public LeadMedium(LeadMedium source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new LeadMedium_PRMMktgActivitiesPortalEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("LeadMediumDeleted", e);
			Validating += (s, e) => ThrowEvent("LeadMediumValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new LeadMedium(this);
		}

		#endregion

	}

	#endregion

	#region Class: LeadMedium_PRMMktgActivitiesPortalEventsProcess

	/// <exclude/>
	public partial class LeadMedium_PRMMktgActivitiesPortalEventsProcess<TEntity> : BPMSoft.Configuration.LeadMedium_TouchPointsEventsProcess<TEntity> where TEntity : LeadMedium
	{

		public LeadMedium_PRMMktgActivitiesPortalEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "LeadMedium_PRMMktgActivitiesPortalEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("ef1d88de-d0b2-4fe3-9e57-981e35e8e370");
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

	#region Class: LeadMedium_PRMMktgActivitiesPortalEventsProcess

	/// <exclude/>
	public class LeadMedium_PRMMktgActivitiesPortalEventsProcess : LeadMedium_PRMMktgActivitiesPortalEventsProcess<LeadMedium>
	{

		public LeadMedium_PRMMktgActivitiesPortalEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: LeadMedium_PRMMktgActivitiesPortalEventsProcess

	public partial class LeadMedium_PRMMktgActivitiesPortalEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: LeadMediumEventsProcess

	/// <exclude/>
	public class LeadMediumEventsProcess : LeadMedium_PRMMktgActivitiesPortalEventsProcess
	{

		public LeadMediumEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

