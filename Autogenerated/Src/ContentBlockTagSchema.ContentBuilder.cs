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
	using System.Security;
	using TSConfiguration = BPMSoft.Configuration;

	#region Class: ContentBlockTagSchema

	/// <exclude/>
	public class ContentBlockTagSchema : BPMSoft.Configuration.BaseTagSchema
	{

		#region Constructors: Public

		public ContentBlockTagSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ContentBlockTagSchema(ContentBlockTagSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ContentBlockTagSchema(ContentBlockTagSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("1b538da4-d9da-4a42-a598-bedf6b404681");
			RealUId = new Guid("1b538da4-d9da-4a42-a598-bedf6b404681");
			Name = "ContentBlockTag";
			ParentSchemaUId = new Guid("9e3f203c-e905-4de5-9468-335b193f2439");
			ExtendParent = false;
			CreatedInPackageId = new Guid("9e68a40f-2533-42d0-8fe0-88fdb6bf5704");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override EntitySchemaColumn CreateTypeColumn() {
			EntitySchemaColumn column = base.CreateTypeColumn();
			column.DefValue = new EntitySchemaColumnDef() {
				Source = EntitySchemaColumnDefSource.Const,
				ValueSource = @"8d7f6d6c-4ca5-4b43-bdd9-a5e01a582260"
			};
			column.ModifiedInSchemaUId = new Guid("1b538da4-d9da-4a42-a598-bedf6b404681");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ContentBlockTag(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ContentBlockTag_ContentBuilderEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ContentBlockTagSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ContentBlockTagSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("1b538da4-d9da-4a42-a598-bedf6b404681"));
		}

		#endregion

	}

	#endregion

	#region Class: ContentBlockTag

	/// <summary>
	/// "Content block" section tag.
	/// </summary>
	public class ContentBlockTag : BPMSoft.Configuration.BaseTag
	{

		#region Constructors: Public

		public ContentBlockTag(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ContentBlockTag";
		}

		public ContentBlockTag(ContentBlockTag source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ContentBlockTag_ContentBuilderEventsProcess(UserConnection);
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
			return new ContentBlockTag(this);
		}

		#endregion

	}

	#endregion

	#region Class: ContentBlockTag_ContentBuilderEventsProcess

	/// <exclude/>
	public partial class ContentBlockTag_ContentBuilderEventsProcess<TEntity> : BPMSoft.Configuration.BaseTag_SSPEventsProcess<TEntity> where TEntity : ContentBlockTag
	{

		public ContentBlockTag_ContentBuilderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ContentBlockTag_ContentBuilderEventsProcess";
			SchemaUId = new Guid("1b538da4-d9da-4a42-a598-bedf6b404681");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("1b538da4-d9da-4a42-a598-bedf6b404681");
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

	#region Class: ContentBlockTag_ContentBuilderEventsProcess

	/// <exclude/>
	public class ContentBlockTag_ContentBuilderEventsProcess : ContentBlockTag_ContentBuilderEventsProcess<ContentBlockTag>
	{

		public ContentBlockTag_ContentBuilderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ContentBlockTag_ContentBuilderEventsProcess

	public partial class ContentBlockTag_ContentBuilderEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ContentBlockTagEventsProcess

	/// <exclude/>
	public class ContentBlockTagEventsProcess : ContentBlockTag_ContentBuilderEventsProcess
	{

		public ContentBlockTagEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

