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
	using BPMSoft.Messaging.Common;
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

	#region Class: SysProcessElementToDoSchema

	/// <exclude/>
	public class SysProcessElementToDoSchema : BPMSoft.Configuration.SysProcessElementToDo_Base_BPMSoftSchema
	{

		#region Constructors: Public

		public SysProcessElementToDoSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysProcessElementToDoSchema(SysProcessElementToDoSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysProcessElementToDoSchema(SysProcessElementToDoSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("9b610777-83fe-4297-94a8-ed43463638cf");
			Name = "SysProcessElementToDo";
			ParentSchemaUId = new Guid("f5db809d-0f72-40a7-8da9-be06543b7f7f");
			ExtendParent = true;
			CreatedInPackageId = new Guid("667fe825-207f-46da-8fb7-a082f81fd079");
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
			return new SysProcessElementToDo(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysProcessElementToDo_PRMPortalEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysProcessElementToDoSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysProcessElementToDoSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("9b610777-83fe-4297-94a8-ed43463638cf"));
		}

		#endregion

	}

	#endregion

	#region Class: SysProcessElementToDo

	/// <summary>
	/// Список заданий по элементам процесса.
	/// </summary>
	public class SysProcessElementToDo : BPMSoft.Configuration.SysProcessElementToDo_Base_BPMSoft
	{

		#region Constructors: Public

		public SysProcessElementToDo(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysProcessElementToDo";
		}

		public SysProcessElementToDo(SysProcessElementToDo source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysProcessElementToDo_PRMPortalEventsProcess(UserConnection);
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
			return new SysProcessElementToDo(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysProcessElementToDo_PRMPortalEventsProcess

	/// <exclude/>
	public partial class SysProcessElementToDo_PRMPortalEventsProcess<TEntity> : BPMSoft.Configuration.SysProcessElementToDo_BaseEventsProcess<TEntity> where TEntity : SysProcessElementToDo
	{

		public SysProcessElementToDo_PRMPortalEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysProcessElementToDo_PRMPortalEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("9b610777-83fe-4297-94a8-ed43463638cf");
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

	#region Class: SysProcessElementToDo_PRMPortalEventsProcess

	/// <exclude/>
	public class SysProcessElementToDo_PRMPortalEventsProcess : SysProcessElementToDo_PRMPortalEventsProcess<SysProcessElementToDo>
	{

		public SysProcessElementToDo_PRMPortalEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysProcessElementToDo_PRMPortalEventsProcess

	public partial class SysProcessElementToDo_PRMPortalEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysProcessElementToDoEventsProcess

	/// <exclude/>
	public class SysProcessElementToDoEventsProcess : SysProcessElementToDo_PRMPortalEventsProcess
	{

		public SysProcessElementToDoEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

