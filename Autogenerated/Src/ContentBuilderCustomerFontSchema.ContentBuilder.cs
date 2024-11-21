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

	#region Class: ContentBuilderCustomerFontSchema

	/// <exclude/>
	public class ContentBuilderCustomerFontSchema : BPMSoft.Configuration.LookupSchema
	{

		#region Constructors: Public

		public ContentBuilderCustomerFontSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ContentBuilderCustomerFontSchema(ContentBuilderCustomerFontSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ContentBuilderCustomerFontSchema(ContentBuilderCustomerFontSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("5fc6c3ee-939c-485a-a4ff-7374219712fc");
			RealUId = new Guid("5fc6c3ee-939c-485a-a4ff-7374219712fc");
			Name = "ContentBuilderCustomerFont";
			ParentSchemaUId = new Guid("2aecdb97-990e-4c17-96f4-240ca6531c84");
			ExtendParent = false;
			CreatedInPackageId = new Guid("9e185556-f0c6-4928-aead-bdfe387399b8");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("3f1999c5-e649-41b3-bcd4-385fdd50695e")) == null) {
				Columns.Add(CreateUrlColumn());
			}
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.IsLocalizable = false;
			column.ModifiedInSchemaUId = new Guid("5fc6c3ee-939c-485a-a4ff-7374219712fc");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.IsLocalizable = false;
			column.ModifiedInSchemaUId = new Guid("5fc6c3ee-939c-485a-a4ff-7374219712fc");
			return column;
		}

		protected virtual EntitySchemaColumn CreateUrlColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("3f1999c5-e649-41b3-bcd4-385fdd50695e"),
				Name = @"Url",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("5fc6c3ee-939c-485a-a4ff-7374219712fc"),
				ModifiedInSchemaUId = new Guid("5fc6c3ee-939c-485a-a4ff-7374219712fc"),
				CreatedInPackageId = new Guid("9e185556-f0c6-4928-aead-bdfe387399b8")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ContentBuilderCustomerFont(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ContentBuilderCustomerFont_ContentBuilderEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ContentBuilderCustomerFontSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ContentBuilderCustomerFontSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("5fc6c3ee-939c-485a-a4ff-7374219712fc"));
		}

		#endregion

	}

	#endregion

	#region Class: ContentBuilderCustomerFont

	/// <summary>
	/// Customer font.
	/// </summary>
	public class ContentBuilderCustomerFont : BPMSoft.Configuration.Lookup
	{

		#region Constructors: Public

		public ContentBuilderCustomerFont(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ContentBuilderCustomerFont";
		}

		public ContentBuilderCustomerFont(ContentBuilderCustomerFont source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Url.
		/// </summary>
		public string Url {
			get {
				return GetTypedColumnValue<string>("Url");
			}
			set {
				SetColumnValue("Url", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ContentBuilderCustomerFont_ContentBuilderEventsProcess(UserConnection);
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
			return new ContentBuilderCustomerFont(this);
		}

		#endregion

	}

	#endregion

	#region Class: ContentBuilderCustomerFont_ContentBuilderEventsProcess

	/// <exclude/>
	public partial class ContentBuilderCustomerFont_ContentBuilderEventsProcess<TEntity> : BPMSoft.Configuration.Lookup_BaseEventsProcess<TEntity> where TEntity : ContentBuilderCustomerFont
	{

		public ContentBuilderCustomerFont_ContentBuilderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ContentBuilderCustomerFont_ContentBuilderEventsProcess";
			SchemaUId = new Guid("5fc6c3ee-939c-485a-a4ff-7374219712fc");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("5fc6c3ee-939c-485a-a4ff-7374219712fc");
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

	#region Class: ContentBuilderCustomerFont_ContentBuilderEventsProcess

	/// <exclude/>
	public class ContentBuilderCustomerFont_ContentBuilderEventsProcess : ContentBuilderCustomerFont_ContentBuilderEventsProcess<ContentBuilderCustomerFont>
	{

		public ContentBuilderCustomerFont_ContentBuilderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ContentBuilderCustomerFont_ContentBuilderEventsProcess

	public partial class ContentBuilderCustomerFont_ContentBuilderEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ContentBuilderCustomerFontEventsProcess

	/// <exclude/>
	public class ContentBuilderCustomerFontEventsProcess : ContentBuilderCustomerFont_ContentBuilderEventsProcess
	{

		public ContentBuilderCustomerFontEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

