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

	#region Class: TouchPlatformSchema

	/// <exclude/>
	public class TouchPlatformSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public TouchPlatformSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public TouchPlatformSchema(TouchPlatformSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public TouchPlatformSchema(TouchPlatformSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("076b2d45-7daa-4e3a-a63a-7b95ab668afe");
			RealUId = new Guid("076b2d45-7daa-4e3a-a63a-7b95ab668afe");
			Name = "TouchPlatform";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("dac8d4c0-e3d8-417b-b0d8-e55cf21b295e");
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
			return new TouchPlatform(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new TouchPlatform_TouchPointsEventsProcess(userConnection);
		}

		public override object Clone() {
			return new TouchPlatformSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new TouchPlatformSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("076b2d45-7daa-4e3a-a63a-7b95ab668afe"));
		}

		#endregion

	}

	#endregion

	#region Class: TouchPlatform

	/// <summary>
	/// Platform.
	/// </summary>
	public class TouchPlatform : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public TouchPlatform(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "TouchPlatform";
		}

		public TouchPlatform(TouchPlatform source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new TouchPlatform_TouchPointsEventsProcess(UserConnection);
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
			return new TouchPlatform(this);
		}

		#endregion

	}

	#endregion

	#region Class: TouchPlatform_TouchPointsEventsProcess

	/// <exclude/>
	public partial class TouchPlatform_TouchPointsEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : TouchPlatform
	{

		public TouchPlatform_TouchPointsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "TouchPlatform_TouchPointsEventsProcess";
			SchemaUId = new Guid("076b2d45-7daa-4e3a-a63a-7b95ab668afe");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("076b2d45-7daa-4e3a-a63a-7b95ab668afe");
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

	#region Class: TouchPlatform_TouchPointsEventsProcess

	/// <exclude/>
	public class TouchPlatform_TouchPointsEventsProcess : TouchPlatform_TouchPointsEventsProcess<TouchPlatform>
	{

		public TouchPlatform_TouchPointsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: TouchPlatform_TouchPointsEventsProcess

	public partial class TouchPlatform_TouchPointsEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: TouchPlatformEventsProcess

	/// <exclude/>
	public class TouchPlatformEventsProcess : TouchPlatform_TouchPointsEventsProcess
	{

		public TouchPlatformEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

