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

	#region Class: ContentBlockFileSchema

	/// <exclude/>
	public class ContentBlockFileSchema : BPMSoft.Configuration.FileSchema
	{

		#region Constructors: Public

		public ContentBlockFileSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ContentBlockFileSchema(ContentBlockFileSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ContentBlockFileSchema(ContentBlockFileSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("a1a57c69-870e-4e7f-bd49-f7887574914f");
			RealUId = new Guid("a1a57c69-870e-4e7f-bd49-f7887574914f");
			Name = "ContentBlockFile";
			ParentSchemaUId = new Guid("556c5867-60a7-4456-aae1-a57a122bef70");
			ExtendParent = false;
			CreatedInPackageId = new Guid("e01e9805-f481-4ad1-b4a3-2fe9747fccf0");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("f9fa0a26-9dfb-4d20-a406-b3b7631ba41f")) == null) {
				Columns.Add(CreateContentBlockColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateContentBlockColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("f9fa0a26-9dfb-4d20-a406-b3b7631ba41f"),
				Name = @"ContentBlock",
				ReferenceSchemaUId = new Guid("49ba5c34-f914-4a37-9d9e-5cf648c9967e"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("a1a57c69-870e-4e7f-bd49-f7887574914f"),
				ModifiedInSchemaUId = new Guid("a1a57c69-870e-4e7f-bd49-f7887574914f"),
				CreatedInPackageId = new Guid("e01e9805-f481-4ad1-b4a3-2fe9747fccf0")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ContentBlockFile(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ContentBlockFile_ContentBuilderEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ContentBlockFileSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ContentBlockFileSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("a1a57c69-870e-4e7f-bd49-f7887574914f"));
		}

		#endregion

	}

	#endregion

	#region Class: ContentBlockFile

	/// <summary>
	/// File and link of content block.
	/// </summary>
	public class ContentBlockFile : BPMSoft.Configuration.File
	{

		#region Constructors: Public

		public ContentBlockFile(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ContentBlockFile";
		}

		public ContentBlockFile(ContentBlockFile source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid ContentBlockId {
			get {
				return GetTypedColumnValue<Guid>("ContentBlockId");
			}
			set {
				SetColumnValue("ContentBlockId", value);
				_contentBlock = null;
			}
		}

		/// <exclude/>
		public string ContentBlockName {
			get {
				return GetTypedColumnValue<string>("ContentBlockName");
			}
			set {
				SetColumnValue("ContentBlockName", value);
				if (_contentBlock != null) {
					_contentBlock.Name = value;
				}
			}
		}

		private ContentBlock _contentBlock;
		/// <summary>
		/// Content block.
		/// </summary>
		public ContentBlock ContentBlock {
			get {
				return _contentBlock ??
					(_contentBlock = LookupColumnEntities.GetEntity("ContentBlock") as ContentBlock);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ContentBlockFile_ContentBuilderEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ContentBlockFileDeleted", e);
			Updated += (s, e) => ThrowEvent("ContentBlockFileUpdated", e);
			Validating += (s, e) => ThrowEvent("ContentBlockFileValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ContentBlockFile(this);
		}

		#endregion

	}

	#endregion

	#region Class: ContentBlockFile_ContentBuilderEventsProcess

	/// <exclude/>
	public partial class ContentBlockFile_ContentBuilderEventsProcess<TEntity> : BPMSoft.Configuration.File_PRMPortalEventsProcess<TEntity> where TEntity : ContentBlockFile
	{

		public ContentBlockFile_ContentBuilderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ContentBlockFile_ContentBuilderEventsProcess";
			SchemaUId = new Guid("a1a57c69-870e-4e7f-bd49-f7887574914f");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("a1a57c69-870e-4e7f-bd49-f7887574914f");
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

	#region Class: ContentBlockFile_ContentBuilderEventsProcess

	/// <exclude/>
	public class ContentBlockFile_ContentBuilderEventsProcess : ContentBlockFile_ContentBuilderEventsProcess<ContentBlockFile>
	{

		public ContentBlockFile_ContentBuilderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ContentBlockFile_ContentBuilderEventsProcess

	public partial class ContentBlockFile_ContentBuilderEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ContentBlockFileEventsProcess

	/// <exclude/>
	public class ContentBlockFileEventsProcess : ContentBlockFile_ContentBuilderEventsProcess
	{

		public ContentBlockFileEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

