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

	#region Class: GeneratedWebFormFileSchema

	/// <exclude/>
	public class GeneratedWebFormFileSchema : BPMSoft.Configuration.FileSchema
	{

		#region Constructors: Public

		public GeneratedWebFormFileSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public GeneratedWebFormFileSchema(GeneratedWebFormFileSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public GeneratedWebFormFileSchema(GeneratedWebFormFileSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("7335ec89-db7b-42a5-822e-15a23cf99db9");
			RealUId = new Guid("7335ec89-db7b-42a5-822e-15a23cf99db9");
			Name = "GeneratedWebFormFile";
			ParentSchemaUId = new Guid("556c5867-60a7-4456-aae1-a57a122bef70");
			ExtendParent = false;
			CreatedInPackageId = new Guid("2f566863-6a05-41ae-bb68-b647818b8f61");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("11c3799a-2b95-444e-8511-1ed0c598bfc1")) == null) {
				Columns.Add(CreateGeneratedWebFormColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateGeneratedWebFormColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("11c3799a-2b95-444e-8511-1ed0c598bfc1"),
				Name = @"GeneratedWebForm",
				ReferenceSchemaUId = new Guid("41ae7d8d-bec3-41df-a6f0-2ab0d08b3967"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("7335ec89-db7b-42a5-822e-15a23cf99db9"),
				ModifiedInSchemaUId = new Guid("7335ec89-db7b-42a5-822e-15a23cf99db9"),
				CreatedInPackageId = new Guid("e3031532-a059-4130-8d2e-6bdf35a52945")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new GeneratedWebFormFile(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new GeneratedWebFormFile_WebFormEventsProcess(userConnection);
		}

		public override object Clone() {
			return new GeneratedWebFormFileSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new GeneratedWebFormFileSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("7335ec89-db7b-42a5-822e-15a23cf99db9"));
		}

		#endregion

	}

	#endregion

	#region Class: GeneratedWebFormFile

	/// <summary>
	/// Landing attachment.
	/// </summary>
	public class GeneratedWebFormFile : BPMSoft.Configuration.File
	{

		#region Constructors: Public

		public GeneratedWebFormFile(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "GeneratedWebFormFile";
		}

		public GeneratedWebFormFile(GeneratedWebFormFile source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid GeneratedWebFormId {
			get {
				return GetTypedColumnValue<Guid>("GeneratedWebFormId");
			}
			set {
				SetColumnValue("GeneratedWebFormId", value);
				_generatedWebForm = null;
			}
		}

		/// <exclude/>
		public string GeneratedWebFormName {
			get {
				return GetTypedColumnValue<string>("GeneratedWebFormName");
			}
			set {
				SetColumnValue("GeneratedWebFormName", value);
				if (_generatedWebForm != null) {
					_generatedWebForm.Name = value;
				}
			}
		}

		private GeneratedWebForm _generatedWebForm;
		/// <summary>
		/// Landing page.
		/// </summary>
		public GeneratedWebForm GeneratedWebForm {
			get {
				return _generatedWebForm ??
					(_generatedWebForm = LookupColumnEntities.GetEntity("GeneratedWebForm") as GeneratedWebForm);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new GeneratedWebFormFile_WebFormEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("GeneratedWebFormFileDeleted", e);
			Updated += (s, e) => ThrowEvent("GeneratedWebFormFileUpdated", e);
			Validating += (s, e) => ThrowEvent("GeneratedWebFormFileValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new GeneratedWebFormFile(this);
		}

		#endregion

	}

	#endregion

	#region Class: GeneratedWebFormFile_WebFormEventsProcess

	/// <exclude/>
	public partial class GeneratedWebFormFile_WebFormEventsProcess<TEntity> : BPMSoft.Configuration.File_PRMPortalEventsProcess<TEntity> where TEntity : GeneratedWebFormFile
	{

		public GeneratedWebFormFile_WebFormEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "GeneratedWebFormFile_WebFormEventsProcess";
			SchemaUId = new Guid("7335ec89-db7b-42a5-822e-15a23cf99db9");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("7335ec89-db7b-42a5-822e-15a23cf99db9");
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

	#region Class: GeneratedWebFormFile_WebFormEventsProcess

	/// <exclude/>
	public class GeneratedWebFormFile_WebFormEventsProcess : GeneratedWebFormFile_WebFormEventsProcess<GeneratedWebFormFile>
	{

		public GeneratedWebFormFile_WebFormEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: GeneratedWebFormFile_WebFormEventsProcess

	public partial class GeneratedWebFormFile_WebFormEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: GeneratedWebFormFileEventsProcess

	/// <exclude/>
	public class GeneratedWebFormFileEventsProcess : GeneratedWebFormFile_WebFormEventsProcess
	{

		public GeneratedWebFormFileEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

