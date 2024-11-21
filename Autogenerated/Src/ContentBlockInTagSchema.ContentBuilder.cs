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

	#region Class: ContentBlockInTagSchema

	/// <exclude/>
	public class ContentBlockInTagSchema : BPMSoft.Configuration.BaseEntityInTagSchema
	{

		#region Constructors: Public

		public ContentBlockInTagSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ContentBlockInTagSchema(ContentBlockInTagSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ContentBlockInTagSchema(ContentBlockInTagSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("4c868ba7-5920-49d6-add7-5692a6706797");
			RealUId = new Guid("4c868ba7-5920-49d6-add7-5692a6706797");
			Name = "ContentBlockInTag";
			ParentSchemaUId = new Guid("5894a2b0-51d5-419a-82bb-238674634270");
			ExtendParent = false;
			CreatedInPackageId = new Guid("9e68a40f-2533-42d0-8fe0-88fdb6bf5704");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override EntitySchemaColumn CreateTagColumn() {
			EntitySchemaColumn column = base.CreateTagColumn();
			column.ReferenceSchemaUId = new Guid("1b538da4-d9da-4a42-a598-bedf6b404681");
			column.ColumnValueName = @"TagId";
			column.DisplayColumnValueName = @"TagName";
			column.ModifiedInSchemaUId = new Guid("4c868ba7-5920-49d6-add7-5692a6706797");
			return column;
		}

		protected override EntitySchemaColumn CreateEntityColumn() {
			EntitySchemaColumn column = base.CreateEntityColumn();
			column.ReferenceSchemaUId = new Guid("49ba5c34-f914-4a37-9d9e-5cf648c9967e");
			column.ColumnValueName = @"EntityId";
			column.DisplayColumnValueName = @"EntityName";
			column.ModifiedInSchemaUId = new Guid("4c868ba7-5920-49d6-add7-5692a6706797");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ContentBlockInTag(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ContentBlockInTag_ContentBuilderEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ContentBlockInTagSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ContentBlockInTagSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("4c868ba7-5920-49d6-add7-5692a6706797"));
		}

		#endregion

	}

	#endregion

	#region Class: ContentBlockInTag

	/// <summary>
	/// "Content block" object tag.
	/// </summary>
	public class ContentBlockInTag : BPMSoft.Configuration.BaseEntityInTag
	{

		#region Constructors: Public

		public ContentBlockInTag(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ContentBlockInTag";
		}

		public ContentBlockInTag(ContentBlockInTag source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ContentBlockInTag_ContentBuilderEventsProcess(UserConnection);
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
			return new ContentBlockInTag(this);
		}

		#endregion

	}

	#endregion

	#region Class: ContentBlockInTag_ContentBuilderEventsProcess

	/// <exclude/>
	public partial class ContentBlockInTag_ContentBuilderEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntityInTag_BaseEventsProcess<TEntity> where TEntity : ContentBlockInTag
	{

		public ContentBlockInTag_ContentBuilderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ContentBlockInTag_ContentBuilderEventsProcess";
			SchemaUId = new Guid("4c868ba7-5920-49d6-add7-5692a6706797");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("4c868ba7-5920-49d6-add7-5692a6706797");
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

	#region Class: ContentBlockInTag_ContentBuilderEventsProcess

	/// <exclude/>
	public class ContentBlockInTag_ContentBuilderEventsProcess : ContentBlockInTag_ContentBuilderEventsProcess<ContentBlockInTag>
	{

		public ContentBlockInTag_ContentBuilderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ContentBlockInTag_ContentBuilderEventsProcess

	public partial class ContentBlockInTag_ContentBuilderEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ContentBlockInTagEventsProcess

	/// <exclude/>
	public class ContentBlockInTagEventsProcess : ContentBlockInTag_ContentBuilderEventsProcess
	{

		public ContentBlockInTagEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

