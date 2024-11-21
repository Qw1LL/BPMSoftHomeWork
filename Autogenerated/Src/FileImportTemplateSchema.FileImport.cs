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

	#region Class: FileImportTemplateSchema

	/// <exclude/>
	public class FileImportTemplateSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public FileImportTemplateSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public FileImportTemplateSchema(FileImportTemplateSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public FileImportTemplateSchema(FileImportTemplateSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("f807e5f5-f397-ab2b-7864-078e402c2924");
			RealUId = new Guid("f807e5f5-f397-ab2b-7864-078e402c2924");
			Name = "FileImportTemplate";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("880ca501-7d05-46f9-a004-d532a5d06272");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = true;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("f64adffc-fee0-174e-1f4d-babae0876288")) == null) {
				Columns.Add(CreateEntitySchemaUIdColumn());
			}
			if (Columns.FindByUId(new Guid("5c002e16-f451-fd93-abce-74adccb3f114")) == null) {
				Columns.Add(CreateTemplateDataColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateEntitySchemaUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("f64adffc-fee0-174e-1f4d-babae0876288"),
				Name = @"EntitySchemaUId",
				CreatedInSchemaUId = new Guid("f807e5f5-f397-ab2b-7864-078e402c2924"),
				ModifiedInSchemaUId = new Guid("f807e5f5-f397-ab2b-7864-078e402c2924"),
				CreatedInPackageId = new Guid("880ca501-7d05-46f9-a004-d532a5d06272")
			};
		}

		protected virtual EntitySchemaColumn CreateTemplateDataColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Binary")) {
				UId = new Guid("5c002e16-f451-fd93-abce-74adccb3f114"),
				Name = @"TemplateData",
				CreatedInSchemaUId = new Guid("f807e5f5-f397-ab2b-7864-078e402c2924"),
				ModifiedInSchemaUId = new Guid("f807e5f5-f397-ab2b-7864-078e402c2924"),
				CreatedInPackageId = new Guid("28117f91-27b8-43f6-8b95-0e32534298ab")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new FileImportTemplate(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new FileImportTemplate_FileImportEventsProcess(userConnection);
		}

		public override object Clone() {
			return new FileImportTemplateSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new FileImportTemplateSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("f807e5f5-f397-ab2b-7864-078e402c2924"));
		}

		#endregion

	}

	#endregion

	#region Class: FileImportTemplate

	/// <summary>
	/// File import template.
	/// </summary>
	public class FileImportTemplate : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public FileImportTemplate(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "FileImportTemplate";
		}

		public FileImportTemplate(FileImportTemplate source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Object schema.
		/// </summary>
		public Guid EntitySchemaUId {
			get {
				return GetTypedColumnValue<Guid>("EntitySchemaUId");
			}
			set {
				SetColumnValue("EntitySchemaUId", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new FileImportTemplate_FileImportEventsProcess(UserConnection);
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
			return new FileImportTemplate(this);
		}

		#endregion

	}

	#endregion

	#region Class: FileImportTemplate_FileImportEventsProcess

	/// <exclude/>
	public partial class FileImportTemplate_FileImportEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : FileImportTemplate
	{

		public FileImportTemplate_FileImportEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "FileImportTemplate_FileImportEventsProcess";
			SchemaUId = new Guid("f807e5f5-f397-ab2b-7864-078e402c2924");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("f807e5f5-f397-ab2b-7864-078e402c2924");
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

	#region Class: FileImportTemplate_FileImportEventsProcess

	/// <exclude/>
	public class FileImportTemplate_FileImportEventsProcess : FileImportTemplate_FileImportEventsProcess<FileImportTemplate>
	{

		public FileImportTemplate_FileImportEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: FileImportTemplate_FileImportEventsProcess

	public partial class FileImportTemplate_FileImportEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: FileImportTemplateEventsProcess

	/// <exclude/>
	public class FileImportTemplateEventsProcess : FileImportTemplate_FileImportEventsProcess
	{

		public FileImportTemplateEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

