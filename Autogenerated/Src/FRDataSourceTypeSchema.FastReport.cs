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

	#region Class: FRDataSourceTypeSchema

	/// <exclude/>
	public class FRDataSourceTypeSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public FRDataSourceTypeSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public FRDataSourceTypeSchema(FRDataSourceTypeSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public FRDataSourceTypeSchema(FRDataSourceTypeSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("069482a1-db1d-4821-9780-d20d75a63af6");
			RealUId = new Guid("069482a1-db1d-4821-9780-d20d75a63af6");
			Name = "FRDataSourceType";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("0005402e-c4df-422a-beab-65ef1e6175ad");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("35543653-78e7-4ee4-9b85-88890804d95c")) == null) {
				Columns.Add(CreateNameColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("35543653-78e7-4ee4-9b85-88890804d95c"),
				Name = @"Name",
				CreatedInSchemaUId = new Guid("069482a1-db1d-4821-9780-d20d75a63af6"),
				ModifiedInSchemaUId = new Guid("069482a1-db1d-4821-9780-d20d75a63af6"),
				CreatedInPackageId = new Guid("0005402e-c4df-422a-beab-65ef1e6175ad")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new FRDataSourceType(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new FRDataSourceType_FastReportEventsProcess(userConnection);
		}

		public override object Clone() {
			return new FRDataSourceTypeSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new FRDataSourceTypeSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("069482a1-db1d-4821-9780-d20d75a63af6"));
		}

		#endregion

	}

	#endregion

	#region Class: FRDataSourceType

	/// <summary>
	/// FRDataSourceType.
	/// </summary>
	public class FRDataSourceType : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public FRDataSourceType(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "FRDataSourceType";
		}

		public FRDataSourceType(FRDataSourceType source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Name.
		/// </summary>
		public string Name {
			get {
				return GetTypedColumnValue<string>("Name");
			}
			set {
				SetColumnValue("Name", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new FRDataSourceType_FastReportEventsProcess(UserConnection);
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
			return new FRDataSourceType(this);
		}

		#endregion

	}

	#endregion

	#region Class: FRDataSourceType_FastReportEventsProcess

	/// <exclude/>
	public partial class FRDataSourceType_FastReportEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : FRDataSourceType
	{

		public FRDataSourceType_FastReportEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "FRDataSourceType_FastReportEventsProcess";
			SchemaUId = new Guid("069482a1-db1d-4821-9780-d20d75a63af6");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("069482a1-db1d-4821-9780-d20d75a63af6");
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

	#region Class: FRDataSourceType_FastReportEventsProcess

	/// <exclude/>
	public class FRDataSourceType_FastReportEventsProcess : FRDataSourceType_FastReportEventsProcess<FRDataSourceType>
	{

		public FRDataSourceType_FastReportEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: FRDataSourceType_FastReportEventsProcess

	public partial class FRDataSourceType_FastReportEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: FRDataSourceTypeEventsProcess

	/// <exclude/>
	public class FRDataSourceTypeEventsProcess : FRDataSourceType_FastReportEventsProcess
	{

		public FRDataSourceTypeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

