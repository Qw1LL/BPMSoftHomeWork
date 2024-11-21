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

	#region Class: BulkEmailThrottlingModeSchema

	/// <exclude/>
	public class BulkEmailThrottlingModeSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public BulkEmailThrottlingModeSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public BulkEmailThrottlingModeSchema(BulkEmailThrottlingModeSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public BulkEmailThrottlingModeSchema(BulkEmailThrottlingModeSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("ee04bdfb-780d-af4b-f39f-89695d16d0cc");
			RealUId = new Guid("ee04bdfb-780d-af4b-f39f-89695d16d0cc");
			Name = "BulkEmailThrottlingMode";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("7b5cce97-2e1e-4b17-90ca-f9813022e3eb");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("c22cf63b-7d44-c8fc-b03b-59678240d3ec")) == null) {
				Columns.Add(CreateCodeColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateCodeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("c22cf63b-7d44-c8fc-b03b-59678240d3ec"),
				Name = @"Code",
				CreatedInSchemaUId = new Guid("ee04bdfb-780d-af4b-f39f-89695d16d0cc"),
				ModifiedInSchemaUId = new Guid("ee04bdfb-780d-af4b-f39f-89695d16d0cc"),
				CreatedInPackageId = new Guid("7b5cce97-2e1e-4b17-90ca-f9813022e3eb")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new BulkEmailThrottlingMode(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new BulkEmailThrottlingMode_BulkEmailEventsProcess(userConnection);
		}

		public override object Clone() {
			return new BulkEmailThrottlingModeSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new BulkEmailThrottlingModeSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ee04bdfb-780d-af4b-f39f-89695d16d0cc"));
		}

		#endregion

	}

	#endregion

	#region Class: BulkEmailThrottlingMode

	/// <summary>
	/// Режим  распределения рассылки.
	/// </summary>
	public class BulkEmailThrottlingMode : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public BulkEmailThrottlingMode(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "BulkEmailThrottlingMode";
		}

		public BulkEmailThrottlingMode(BulkEmailThrottlingMode source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Код.
		/// </summary>
		public int Code {
			get {
				return GetTypedColumnValue<int>("Code");
			}
			set {
				SetColumnValue("Code", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new BulkEmailThrottlingMode_BulkEmailEventsProcess(UserConnection);
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
			return new BulkEmailThrottlingMode(this);
		}

		#endregion

	}

	#endregion

	#region Class: BulkEmailThrottlingMode_BulkEmailEventsProcess

	/// <exclude/>
	public partial class BulkEmailThrottlingMode_BulkEmailEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : BulkEmailThrottlingMode
	{

		public BulkEmailThrottlingMode_BulkEmailEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "BulkEmailThrottlingMode_BulkEmailEventsProcess";
			SchemaUId = new Guid("ee04bdfb-780d-af4b-f39f-89695d16d0cc");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("ee04bdfb-780d-af4b-f39f-89695d16d0cc");
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

	#region Class: BulkEmailThrottlingMode_BulkEmailEventsProcess

	/// <exclude/>
	public class BulkEmailThrottlingMode_BulkEmailEventsProcess : BulkEmailThrottlingMode_BulkEmailEventsProcess<BulkEmailThrottlingMode>
	{

		public BulkEmailThrottlingMode_BulkEmailEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: BulkEmailThrottlingMode_BulkEmailEventsProcess

	public partial class BulkEmailThrottlingMode_BulkEmailEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: BulkEmailThrottlingModeEventsProcess

	/// <exclude/>
	public class BulkEmailThrottlingModeEventsProcess : BulkEmailThrottlingMode_BulkEmailEventsProcess
	{

		public BulkEmailThrottlingModeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

