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

	#region Class: NotificationRuleUsageSchema

	/// <exclude/>
	public class NotificationRuleUsageSchema : BPMSoft.Configuration.BaseCodeLookupSchema
	{

		#region Constructors: Public

		public NotificationRuleUsageSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public NotificationRuleUsageSchema(NotificationRuleUsageSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public NotificationRuleUsageSchema(NotificationRuleUsageSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("f175dd0b-0652-48ef-a515-c8608452ed40");
			RealUId = new Guid("f175dd0b-0652-48ef-a515-c8608452ed40");
			Name = "NotificationRuleUsage";
			ParentSchemaUId = new Guid("2681062b-df59-4e52-89ed-f9b7dc909ab2");
			ExtendParent = false;
			CreatedInPackageId = new Guid("c3c90037-274c-4793-841e-197eb228d3cd");
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
			return new NotificationRuleUsage(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new NotificationRuleUsage_CaseServiceEventsProcess(userConnection);
		}

		public override object Clone() {
			return new NotificationRuleUsageSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new NotificationRuleUsageSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("f175dd0b-0652-48ef-a515-c8608452ed40"));
		}

		#endregion

	}

	#endregion

	#region Class: NotificationRuleUsage

	/// <summary>
	/// Тип отправки правила уведомления.
	/// </summary>
	public class NotificationRuleUsage : BPMSoft.Configuration.BaseCodeLookup
	{

		#region Constructors: Public

		public NotificationRuleUsage(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "NotificationRuleUsage";
		}

		public NotificationRuleUsage(NotificationRuleUsage source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new NotificationRuleUsage_CaseServiceEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("NotificationRuleUsageDeleted", e);
			Validating += (s, e) => ThrowEvent("NotificationRuleUsageValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new NotificationRuleUsage(this);
		}

		#endregion

	}

	#endregion

	#region Class: NotificationRuleUsage_CaseServiceEventsProcess

	/// <exclude/>
	public partial class NotificationRuleUsage_CaseServiceEventsProcess<TEntity> : BPMSoft.Configuration.BaseCodeLookup_BaseEventsProcess<TEntity> where TEntity : NotificationRuleUsage
	{

		public NotificationRuleUsage_CaseServiceEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "NotificationRuleUsage_CaseServiceEventsProcess";
			SchemaUId = new Guid("f175dd0b-0652-48ef-a515-c8608452ed40");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("f175dd0b-0652-48ef-a515-c8608452ed40");
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

	#region Class: NotificationRuleUsage_CaseServiceEventsProcess

	/// <exclude/>
	public class NotificationRuleUsage_CaseServiceEventsProcess : NotificationRuleUsage_CaseServiceEventsProcess<NotificationRuleUsage>
	{

		public NotificationRuleUsage_CaseServiceEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: NotificationRuleUsage_CaseServiceEventsProcess

	public partial class NotificationRuleUsage_CaseServiceEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: NotificationRuleUsageEventsProcess

	/// <exclude/>
	public class NotificationRuleUsageEventsProcess : NotificationRuleUsage_CaseServiceEventsProcess
	{

		public NotificationRuleUsageEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

