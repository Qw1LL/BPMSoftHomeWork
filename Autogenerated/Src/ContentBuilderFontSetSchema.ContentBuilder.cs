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

	#region Class: ContentBuilderFontSetSchema

	/// <exclude/>
	public class ContentBuilderFontSetSchema : BPMSoft.Configuration.LookupSchema
	{

		#region Constructors: Public

		public ContentBuilderFontSetSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ContentBuilderFontSetSchema(ContentBuilderFontSetSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ContentBuilderFontSetSchema(ContentBuilderFontSetSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("fe4d115e-315d-4a23-b7f0-8737a3d057e6");
			RealUId = new Guid("fe4d115e-315d-4a23-b7f0-8737a3d057e6");
			Name = "ContentBuilderFontSet";
			ParentSchemaUId = new Guid("2aecdb97-990e-4c17-96f4-240ca6531c84");
			ExtendParent = false;
			CreatedInPackageId = new Guid("9e185556-f0c6-4928-aead-bdfe387399b8");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("91390ba7-365b-4dc9-ae47-bfd376c1558e")) == null) {
				Columns.Add(CreateFontsColumn());
			}
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.IsLocalizable = false;
			column.ModifiedInSchemaUId = new Guid("fe4d115e-315d-4a23-b7f0-8737a3d057e6");
			return column;
		}

		protected virtual EntitySchemaColumn CreateFontsColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("91390ba7-365b-4dc9-ae47-bfd376c1558e"),
				Name = @"Fonts",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("fe4d115e-315d-4a23-b7f0-8737a3d057e6"),
				ModifiedInSchemaUId = new Guid("fe4d115e-315d-4a23-b7f0-8737a3d057e6"),
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
			return new ContentBuilderFontSet(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ContentBuilderFontSet_ContentBuilderEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ContentBuilderFontSetSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ContentBuilderFontSetSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("fe4d115e-315d-4a23-b7f0-8737a3d057e6"));
		}

		#endregion

	}

	#endregion

	#region Class: ContentBuilderFontSet

	/// <summary>
	/// Font set.
	/// </summary>
	public class ContentBuilderFontSet : BPMSoft.Configuration.Lookup
	{

		#region Constructors: Public

		public ContentBuilderFontSet(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ContentBuilderFontSet";
		}

		public ContentBuilderFontSet(ContentBuilderFontSet source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Fonts.
		/// </summary>
		public string Fonts {
			get {
				return GetTypedColumnValue<string>("Fonts");
			}
			set {
				SetColumnValue("Fonts", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ContentBuilderFontSet_ContentBuilderEventsProcess(UserConnection);
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
			return new ContentBuilderFontSet(this);
		}

		#endregion

	}

	#endregion

	#region Class: ContentBuilderFontSet_ContentBuilderEventsProcess

	/// <exclude/>
	public partial class ContentBuilderFontSet_ContentBuilderEventsProcess<TEntity> : BPMSoft.Configuration.Lookup_BaseEventsProcess<TEntity> where TEntity : ContentBuilderFontSet
	{

		public ContentBuilderFontSet_ContentBuilderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ContentBuilderFontSet_ContentBuilderEventsProcess";
			SchemaUId = new Guid("fe4d115e-315d-4a23-b7f0-8737a3d057e6");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("fe4d115e-315d-4a23-b7f0-8737a3d057e6");
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

	#region Class: ContentBuilderFontSet_ContentBuilderEventsProcess

	/// <exclude/>
	public class ContentBuilderFontSet_ContentBuilderEventsProcess : ContentBuilderFontSet_ContentBuilderEventsProcess<ContentBuilderFontSet>
	{

		public ContentBuilderFontSet_ContentBuilderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ContentBuilderFontSet_ContentBuilderEventsProcess

	public partial class ContentBuilderFontSet_ContentBuilderEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ContentBuilderFontSetEventsProcess

	/// <exclude/>
	public class ContentBuilderFontSetEventsProcess : ContentBuilderFontSet_ContentBuilderEventsProcess
	{

		public ContentBuilderFontSetEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

