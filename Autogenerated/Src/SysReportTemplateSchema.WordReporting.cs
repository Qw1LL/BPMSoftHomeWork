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

	#region Class: SysReportTemplateSchema

	/// <exclude/>
	public class SysReportTemplateSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysReportTemplateSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysReportTemplateSchema(SysReportTemplateSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysReportTemplateSchema(SysReportTemplateSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("44a0ae94-90a3-45b6-8bc7-2d16cf6434c1");
			RealUId = new Guid("44a0ae94-90a3-45b6-8bc7-2d16cf6434c1");
			Name = "SysReportTemplate";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("7609649d-94a6-447b-b054-9d91465ffa7b");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("354138b2-c693-41e9-89a2-4655bbe86b21")) == null) {
				Columns.Add(CreateFileColumn());
			}
			if (Columns.FindByUId(new Guid("473b458f-2ca7-4a01-8bd9-ec47f6074618")) == null) {
				Columns.Add(CreateSizeColumn());
			}
			if (Columns.FindByUId(new Guid("fbe70cde-8d7a-4401-b3fe-e765d813e199")) == null) {
				Columns.Add(CreateReportIdColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateFileColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("File")) {
				UId = new Guid("354138b2-c693-41e9-89a2-4655bbe86b21"),
				Name = @"File",
				CreatedInSchemaUId = new Guid("44a0ae94-90a3-45b6-8bc7-2d16cf6434c1"),
				ModifiedInSchemaUId = new Guid("44a0ae94-90a3-45b6-8bc7-2d16cf6434c1"),
				CreatedInPackageId = new Guid("7609649d-94a6-447b-b054-9d91465ffa7b")
			};
		}

		protected virtual EntitySchemaColumn CreateSizeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("473b458f-2ca7-4a01-8bd9-ec47f6074618"),
				Name = @"Size",
				CreatedInSchemaUId = new Guid("44a0ae94-90a3-45b6-8bc7-2d16cf6434c1"),
				ModifiedInSchemaUId = new Guid("44a0ae94-90a3-45b6-8bc7-2d16cf6434c1"),
				CreatedInPackageId = new Guid("7609649d-94a6-447b-b054-9d91465ffa7b")
			};
		}

		protected virtual EntitySchemaColumn CreateReportIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("fbe70cde-8d7a-4401-b3fe-e765d813e199"),
				Name = @"ReportId",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("44a0ae94-90a3-45b6-8bc7-2d16cf6434c1"),
				ModifiedInSchemaUId = new Guid("44a0ae94-90a3-45b6-8bc7-2d16cf6434c1"),
				CreatedInPackageId = new Guid("7609649d-94a6-447b-b054-9d91465ffa7b")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysReportTemplate(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysReportTemplate_WordReportingEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysReportTemplateSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysReportTemplateSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("44a0ae94-90a3-45b6-8bc7-2d16cf6434c1"));
		}

		#endregion

	}

	#endregion

	#region Class: SysReportTemplate

	/// <summary>
	/// SysReportTemplate.
	/// </summary>
	public class SysReportTemplate : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysReportTemplate(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysReportTemplate";
		}

		public SysReportTemplate(SysReportTemplate source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Size.
		/// </summary>
		public int Size {
			get {
				return GetTypedColumnValue<int>("Size");
			}
			set {
				SetColumnValue("Size", value);
			}
		}

		/// <summary>
		/// ReportId.
		/// </summary>
		public Guid ReportId {
			get {
				return GetTypedColumnValue<Guid>("ReportId");
			}
			set {
				SetColumnValue("ReportId", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysReportTemplate_WordReportingEventsProcess(UserConnection);
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
			return new SysReportTemplate(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysReportTemplate_WordReportingEventsProcess

	/// <exclude/>
	public partial class SysReportTemplate_WordReportingEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : SysReportTemplate
	{

		public SysReportTemplate_WordReportingEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysReportTemplate_WordReportingEventsProcess";
			SchemaUId = new Guid("44a0ae94-90a3-45b6-8bc7-2d16cf6434c1");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("44a0ae94-90a3-45b6-8bc7-2d16cf6434c1");
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

	#region Class: SysReportTemplate_WordReportingEventsProcess

	/// <exclude/>
	public class SysReportTemplate_WordReportingEventsProcess : SysReportTemplate_WordReportingEventsProcess<SysReportTemplate>
	{

		public SysReportTemplate_WordReportingEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysReportTemplate_WordReportingEventsProcess

	public partial class SysReportTemplate_WordReportingEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysReportTemplateEventsProcess

	/// <exclude/>
	public class SysReportTemplateEventsProcess : SysReportTemplate_WordReportingEventsProcess
	{

		public SysReportTemplateEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

