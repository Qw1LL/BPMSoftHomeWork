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

	#region Class: SelectorTypeSchema

	/// <exclude/>
	public class SelectorTypeSchema : BPMSoft.Configuration.BaseCodeLookupSchema
	{

		#region Constructors: Public

		public SelectorTypeSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SelectorTypeSchema(SelectorTypeSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SelectorTypeSchema(SelectorTypeSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("a68f8a18-acad-491f-90fe-af5cd59191cc");
			RealUId = new Guid("a68f8a18-acad-491f-90fe-af5cd59191cc");
			Name = "SelectorType";
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
			return new SelectorType(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SelectorType_EventTrackingEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SelectorTypeSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SelectorTypeSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("a68f8a18-acad-491f-90fe-af5cd59191cc"));
		}

		#endregion

	}

	#endregion

	#region Class: SelectorType

	/// <summary>
	/// Как идентифицировать элемент.
	/// </summary>
	public class SelectorType : BPMSoft.Configuration.BaseCodeLookup
	{

		#region Constructors: Public

		public SelectorType(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SelectorType";
		}

		public SelectorType(SelectorType source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SelectorType_EventTrackingEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SelectorTypeDeleted", e);
			Validating += (s, e) => ThrowEvent("SelectorTypeValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SelectorType(this);
		}

		#endregion

	}

	#endregion

	#region Class: SelectorType_EventTrackingEventsProcess

	/// <exclude/>
	public partial class SelectorType_EventTrackingEventsProcess<TEntity> : BPMSoft.Configuration.BaseCodeLookup_BaseEventsProcess<TEntity> where TEntity : SelectorType
	{

		public SelectorType_EventTrackingEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SelectorType_EventTrackingEventsProcess";
			SchemaUId = new Guid("a68f8a18-acad-491f-90fe-af5cd59191cc");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("a68f8a18-acad-491f-90fe-af5cd59191cc");
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

	#region Class: SelectorType_EventTrackingEventsProcess

	/// <exclude/>
	public class SelectorType_EventTrackingEventsProcess : SelectorType_EventTrackingEventsProcess<SelectorType>
	{

		public SelectorType_EventTrackingEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SelectorType_EventTrackingEventsProcess

	public partial class SelectorType_EventTrackingEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SelectorTypeEventsProcess

	/// <exclude/>
	public class SelectorTypeEventsProcess : SelectorType_EventTrackingEventsProcess
	{

		public SelectorTypeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

