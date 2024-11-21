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

	#region Class: SysStartTimerTypeSchema

	/// <exclude/>
	public class SysStartTimerTypeSchema : BPMSoft.Configuration.SysCodeLookupSchema
	{

		#region Constructors: Public

		public SysStartTimerTypeSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysStartTimerTypeSchema(SysStartTimerTypeSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysStartTimerTypeSchema(SysStartTimerTypeSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("e9e75b38-e75f-47a8-bf37-adc220014fb6");
			RealUId = new Guid("e9e75b38-e75f-47a8-bf37-adc220014fb6");
			Name = "SysStartTimerType";
			ParentSchemaUId = new Guid("28699730-9cf0-4702-87a9-c64d612e4b14");
			ExtendParent = false;
			CreatedInPackageId = new Guid("79d5e1e4-18af-4001-8dc1-26f09fca92c2");
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
			return new SysStartTimerType(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysStartTimerType_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysStartTimerTypeSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysStartTimerTypeSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("e9e75b38-e75f-47a8-bf37-adc220014fb6"));
		}

		#endregion

	}

	#endregion

	#region Class: SysStartTimerType

	/// <summary>
	/// SysStartTimerType.
	/// </summary>
	public class SysStartTimerType : BPMSoft.Configuration.SysCodeLookup
	{

		#region Constructors: Public

		public SysStartTimerType(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysStartTimerType";
		}

		public SysStartTimerType(SysStartTimerType source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysStartTimerType_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysStartTimerTypeDeleted", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysStartTimerType(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysStartTimerType_BaseEventsProcess

	/// <exclude/>
	public partial class SysStartTimerType_BaseEventsProcess<TEntity> : BPMSoft.Configuration.SysCodeLookup_BaseEventsProcess<TEntity> where TEntity : SysStartTimerType
	{

		public SysStartTimerType_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysStartTimerType_BaseEventsProcess";
			SchemaUId = new Guid("e9e75b38-e75f-47a8-bf37-adc220014fb6");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("e9e75b38-e75f-47a8-bf37-adc220014fb6");
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

	#region Class: SysStartTimerType_BaseEventsProcess

	/// <exclude/>
	public class SysStartTimerType_BaseEventsProcess : SysStartTimerType_BaseEventsProcess<SysStartTimerType>
	{

		public SysStartTimerType_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysStartTimerType_BaseEventsProcess

	public partial class SysStartTimerType_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysStartTimerTypeEventsProcess

	/// <exclude/>
	public class SysStartTimerTypeEventsProcess : SysStartTimerType_BaseEventsProcess
	{

		public SysStartTimerTypeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

