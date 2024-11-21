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

	#region Class: GeneratedWebFormInFolderSchema

	/// <exclude/>
	public class GeneratedWebFormInFolderSchema : BPMSoft.Configuration.BaseItemInFolderSchema
	{

		#region Constructors: Public

		public GeneratedWebFormInFolderSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public GeneratedWebFormInFolderSchema(GeneratedWebFormInFolderSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public GeneratedWebFormInFolderSchema(GeneratedWebFormInFolderSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("6ff3e9df-8834-473e-9822-379cc0fc2cd5");
			RealUId = new Guid("6ff3e9df-8834-473e-9822-379cc0fc2cd5");
			Name = "GeneratedWebFormInFolder";
			ParentSchemaUId = new Guid("4f63bafb-e9e7-4082-b92e-66b97c14017c");
			ExtendParent = false;
			CreatedInPackageId = new Guid("e3031532-a059-4130-8d2e-6bdf35a52945");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("e5ffe46a-abb9-4af5-82ca-39ae8ab007dc")) == null) {
				Columns.Add(CreateGeneratedWebFormColumn());
			}
		}

		protected override EntitySchemaColumn CreateFolderColumn() {
			EntitySchemaColumn column = base.CreateFolderColumn();
			column.ReferenceSchemaUId = new Guid("07ae8a65-3f23-4bb6-b302-73c557beb518");
			column.ColumnValueName = @"FolderId";
			column.DisplayColumnValueName = @"FolderName";
			column.ModifiedInSchemaUId = new Guid("6ff3e9df-8834-473e-9822-379cc0fc2cd5");
			return column;
		}

		protected virtual EntitySchemaColumn CreateGeneratedWebFormColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("e5ffe46a-abb9-4af5-82ca-39ae8ab007dc"),
				Name = @"GeneratedWebForm",
				ReferenceSchemaUId = new Guid("41ae7d8d-bec3-41df-a6f0-2ab0d08b3967"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("6ff3e9df-8834-473e-9822-379cc0fc2cd5"),
				ModifiedInSchemaUId = new Guid("6ff3e9df-8834-473e-9822-379cc0fc2cd5"),
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
			return new GeneratedWebFormInFolder(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new GeneratedWebFormInFolder_WebFormEventsProcess(userConnection);
		}

		public override object Clone() {
			return new GeneratedWebFormInFolderSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new GeneratedWebFormInFolderSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("6ff3e9df-8834-473e-9822-379cc0fc2cd5"));
		}

		#endregion

	}

	#endregion

	#region Class: GeneratedWebFormInFolder

	/// <summary>
	/// Object "Landing pages" in folder.
	/// </summary>
	public class GeneratedWebFormInFolder : BPMSoft.Configuration.BaseItemInFolder
	{

		#region Constructors: Public

		public GeneratedWebFormInFolder(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "GeneratedWebFormInFolder";
		}

		public GeneratedWebFormInFolder(GeneratedWebFormInFolder source)
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
			var process = new GeneratedWebFormInFolder_WebFormEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("GeneratedWebFormInFolderDeleted", e);
			Validating += (s, e) => ThrowEvent("GeneratedWebFormInFolderValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new GeneratedWebFormInFolder(this);
		}

		#endregion

	}

	#endregion

	#region Class: GeneratedWebFormInFolder_WebFormEventsProcess

	/// <exclude/>
	public partial class GeneratedWebFormInFolder_WebFormEventsProcess<TEntity> : BPMSoft.Configuration.BaseItemInFolder_BaseEventsProcess<TEntity> where TEntity : GeneratedWebFormInFolder
	{

		public GeneratedWebFormInFolder_WebFormEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "GeneratedWebFormInFolder_WebFormEventsProcess";
			SchemaUId = new Guid("6ff3e9df-8834-473e-9822-379cc0fc2cd5");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("6ff3e9df-8834-473e-9822-379cc0fc2cd5");
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

	#region Class: GeneratedWebFormInFolder_WebFormEventsProcess

	/// <exclude/>
	public class GeneratedWebFormInFolder_WebFormEventsProcess : GeneratedWebFormInFolder_WebFormEventsProcess<GeneratedWebFormInFolder>
	{

		public GeneratedWebFormInFolder_WebFormEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: GeneratedWebFormInFolder_WebFormEventsProcess

	public partial class GeneratedWebFormInFolder_WebFormEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: GeneratedWebFormInFolderEventsProcess

	/// <exclude/>
	public class GeneratedWebFormInFolderEventsProcess : GeneratedWebFormInFolder_WebFormEventsProcess
	{

		public GeneratedWebFormInFolderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

