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

	#region Class: ForecastIndicatorSchema

	/// <exclude/>
	public class ForecastIndicatorSchema : BPMSoft.Configuration.BaseCodeLookupSchema
	{

		#region Constructors: Public

		public ForecastIndicatorSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ForecastIndicatorSchema(ForecastIndicatorSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ForecastIndicatorSchema(ForecastIndicatorSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("e0b448d7-44a9-465c-8de0-2f79c3415fba");
			RealUId = new Guid("e0b448d7-44a9-465c-8de0-2f79c3415fba");
			Name = "ForecastIndicator";
			ParentSchemaUId = new Guid("2681062b-df59-4e52-89ed-f9b7dc909ab2");
			ExtendParent = false;
			CreatedInPackageId = new Guid("7c408f6d-0911-41c7-b495-80ace275c6f2");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("fe611cf6-f3d5-4ad3-8847-594c1c2dfa62")) == null) {
				Columns.Add(CreatePositionColumn());
			}
		}

		protected virtual EntitySchemaColumn CreatePositionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("fe611cf6-f3d5-4ad3-8847-594c1c2dfa62"),
				Name = @"Position",
				CreatedInSchemaUId = new Guid("e0b448d7-44a9-465c-8de0-2f79c3415fba"),
				ModifiedInSchemaUId = new Guid("e0b448d7-44a9-465c-8de0-2f79c3415fba"),
				CreatedInPackageId = new Guid("7c408f6d-0911-41c7-b495-80ace275c6f2")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ForecastIndicator(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ForecastIndicator_CoreForecastEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ForecastIndicatorSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ForecastIndicatorSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("e0b448d7-44a9-465c-8de0-2f79c3415fba"));
		}

		#endregion

	}

	#endregion

	#region Class: ForecastIndicator

	/// <summary>
	/// Показатель планирования.
	/// </summary>
	public class ForecastIndicator : BPMSoft.Configuration.BaseCodeLookup
	{

		#region Constructors: Public

		public ForecastIndicator(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ForecastIndicator";
		}

		public ForecastIndicator(ForecastIndicator source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Позиция.
		/// </summary>
		public int Position {
			get {
				return GetTypedColumnValue<int>("Position");
			}
			set {
				SetColumnValue("Position", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ForecastIndicator_CoreForecastEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ForecastIndicatorDeleted", e);
			Validating += (s, e) => ThrowEvent("ForecastIndicatorValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ForecastIndicator(this);
		}

		#endregion

	}

	#endregion

	#region Class: ForecastIndicator_CoreForecastEventsProcess

	/// <exclude/>
	public partial class ForecastIndicator_CoreForecastEventsProcess<TEntity> : BPMSoft.Configuration.BaseCodeLookup_BaseEventsProcess<TEntity> where TEntity : ForecastIndicator
	{

		public ForecastIndicator_CoreForecastEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ForecastIndicator_CoreForecastEventsProcess";
			SchemaUId = new Guid("e0b448d7-44a9-465c-8de0-2f79c3415fba");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("e0b448d7-44a9-465c-8de0-2f79c3415fba");
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

	#region Class: ForecastIndicator_CoreForecastEventsProcess

	/// <exclude/>
	public class ForecastIndicator_CoreForecastEventsProcess : ForecastIndicator_CoreForecastEventsProcess<ForecastIndicator>
	{

		public ForecastIndicator_CoreForecastEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ForecastIndicator_CoreForecastEventsProcess

	public partial class ForecastIndicator_CoreForecastEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ForecastIndicatorEventsProcess

	/// <exclude/>
	public class ForecastIndicatorEventsProcess : ForecastIndicator_CoreForecastEventsProcess
	{

		public ForecastIndicatorEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

