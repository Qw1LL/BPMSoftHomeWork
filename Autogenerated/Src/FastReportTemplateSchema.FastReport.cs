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

	#region Class: FastReportTemplateSchema

	/// <exclude/>
	public class FastReportTemplateSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public FastReportTemplateSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public FastReportTemplateSchema(FastReportTemplateSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public FastReportTemplateSchema(FastReportTemplateSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("05ba10ee-d7af-4596-b947-87d2dcf5f820");
			RealUId = new Guid("05ba10ee-d7af-4596-b947-87d2dcf5f820");
			Name = "FastReportTemplate";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("a4b49bea-882f-4e7d-ae8d-44e3ec2194f3");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("12ab8df2-78ec-4bff-9b1d-3a8d451dd5e7")) == null) {
				Columns.Add(CreateDataColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateDataColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("12ab8df2-78ec-4bff-9b1d-3a8d451dd5e7"),
				Name = @"Data",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("05ba10ee-d7af-4596-b947-87d2dcf5f820"),
				ModifiedInSchemaUId = new Guid("05ba10ee-d7af-4596-b947-87d2dcf5f820"),
				CreatedInPackageId = new Guid("a4b49bea-882f-4e7d-ae8d-44e3ec2194f3")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new FastReportTemplate(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new FastReportTemplate_FastReportEventsProcess(userConnection);
		}

		public override object Clone() {
			return new FastReportTemplateSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new FastReportTemplateSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("05ba10ee-d7af-4596-b947-87d2dcf5f820"));
		}

		#endregion

	}

	#endregion

	#region Class: FastReportTemplate

	/// <summary>
	/// FastReportTemplate.
	/// </summary>
	public class FastReportTemplate : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public FastReportTemplate(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "FastReportTemplate";
		}

		public FastReportTemplate(FastReportTemplate source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Data.
		/// </summary>
		public string Data {
			get {
				return GetTypedColumnValue<string>("Data");
			}
			set {
				SetColumnValue("Data", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new FastReportTemplate_FastReportEventsProcess(UserConnection);
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
			return new FastReportTemplate(this);
		}

		#endregion

	}

	#endregion

	#region Class: FastReportTemplate_FastReportEventsProcess

	/// <exclude/>
	public partial class FastReportTemplate_FastReportEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : FastReportTemplate
	{

		public FastReportTemplate_FastReportEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "FastReportTemplate_FastReportEventsProcess";
			SchemaUId = new Guid("05ba10ee-d7af-4596-b947-87d2dcf5f820");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("05ba10ee-d7af-4596-b947-87d2dcf5f820");
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

	#region Class: FastReportTemplate_FastReportEventsProcess

	/// <exclude/>
	public class FastReportTemplate_FastReportEventsProcess : FastReportTemplate_FastReportEventsProcess<FastReportTemplate>
	{

		public FastReportTemplate_FastReportEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: FastReportTemplate_FastReportEventsProcess

	public partial class FastReportTemplate_FastReportEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: FastReportTemplateEventsProcess

	/// <exclude/>
	public class FastReportTemplateEventsProcess : FastReportTemplate_FastReportEventsProcess
	{

		public FastReportTemplateEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

