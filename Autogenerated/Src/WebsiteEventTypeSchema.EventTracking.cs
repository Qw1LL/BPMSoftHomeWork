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

	#region Class: WebsiteEventTypeSchema

	/// <exclude/>
	public class WebsiteEventTypeSchema : BPMSoft.Configuration.BaseCodeLookupSchema
	{

		#region Constructors: Public

		public WebsiteEventTypeSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public WebsiteEventTypeSchema(WebsiteEventTypeSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public WebsiteEventTypeSchema(WebsiteEventTypeSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("b7962cd4-c1b4-4937-846a-0e54fe403d84");
			RealUId = new Guid("b7962cd4-c1b4-4937-846a-0e54fe403d84");
			Name = "WebsiteEventType";
			ParentSchemaUId = new Guid("2681062b-df59-4e52-89ed-f9b7dc909ab2");
			ExtendParent = false;
			CreatedInPackageId = new Guid("2a529963-f0d0-492d-98de-b7a4c61033e2");
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
			return new WebsiteEventType(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new WebsiteEventType_EventTrackingEventsProcess(userConnection);
		}

		public override object Clone() {
			return new WebsiteEventTypeSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new WebsiteEventTypeSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("b7962cd4-c1b4-4937-846a-0e54fe403d84"));
		}

		#endregion

	}

	#endregion

	#region Class: WebsiteEventType

	/// <summary>
	/// Тип события сайта.
	/// </summary>
	public class WebsiteEventType : BPMSoft.Configuration.BaseCodeLookup
	{

		#region Constructors: Public

		public WebsiteEventType(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "WebsiteEventType";
		}

		public WebsiteEventType(WebsiteEventType source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new WebsiteEventType_EventTrackingEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("WebsiteEventTypeDeleted", e);
			Validating += (s, e) => ThrowEvent("WebsiteEventTypeValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new WebsiteEventType(this);
		}

		#endregion

	}

	#endregion

	#region Class: WebsiteEventType_EventTrackingEventsProcess

	/// <exclude/>
	public partial class WebsiteEventType_EventTrackingEventsProcess<TEntity> : BPMSoft.Configuration.BaseCodeLookup_BaseEventsProcess<TEntity> where TEntity : WebsiteEventType
	{

		public WebsiteEventType_EventTrackingEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "WebsiteEventType_EventTrackingEventsProcess";
			SchemaUId = new Guid("b7962cd4-c1b4-4937-846a-0e54fe403d84");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("b7962cd4-c1b4-4937-846a-0e54fe403d84");
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

	#region Class: WebsiteEventType_EventTrackingEventsProcess

	/// <exclude/>
	public class WebsiteEventType_EventTrackingEventsProcess : WebsiteEventType_EventTrackingEventsProcess<WebsiteEventType>
	{

		public WebsiteEventType_EventTrackingEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: WebsiteEventType_EventTrackingEventsProcess

	public partial class WebsiteEventType_EventTrackingEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: WebsiteEventTypeEventsProcess

	/// <exclude/>
	public class WebsiteEventTypeEventsProcess : WebsiteEventType_EventTrackingEventsProcess
	{

		public WebsiteEventTypeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

