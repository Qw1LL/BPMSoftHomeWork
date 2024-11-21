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

	#region Class: BaseCodeImageLookupSchema

	/// <exclude/>
	[IsVirtual]
	public class BaseCodeImageLookupSchema : BPMSoft.Configuration.BaseCodeLookupSchema
	{

		#region Constructors: Public

		public BaseCodeImageLookupSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public BaseCodeImageLookupSchema(BaseCodeImageLookupSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public BaseCodeImageLookupSchema(BaseCodeImageLookupSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("c21771d2-01fa-4646-96b0-e4b69e582b44");
			RealUId = new Guid("c21771d2-01fa-4646-96b0-e4b69e582b44");
			Name = "BaseCodeImageLookup";
			ParentSchemaUId = new Guid("2681062b-df59-4e52-89ed-f9b7dc909ab2");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("59993ff0-1373-4acf-9eff-e2cec861f065")) == null) {
				Columns.Add(CreateImageColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateImageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ImageLookup")) {
				UId = new Guid("59993ff0-1373-4acf-9eff-e2cec861f065"),
				Name = @"Image",
				ReferenceSchemaUId = new Guid("93986bfe-2dbd-46bc-9bf9-d03dfefbf3b8"),
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("c21771d2-01fa-4646-96b0-e4b69e582b44"),
				ModifiedInSchemaUId = new Guid("c21771d2-01fa-4646-96b0-e4b69e582b44"),
				CreatedInPackageId = new Guid("abc2d3f4-826b-4178-b0c1-b277e94aed5f")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new BaseCodeImageLookup(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new BaseCodeImageLookup_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new BaseCodeImageLookupSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new BaseCodeImageLookupSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("c21771d2-01fa-4646-96b0-e4b69e582b44"));
		}

		#endregion

	}

	#endregion

	#region Class: BaseCodeImageLookup

	/// <summary>
	/// Base lookup with image and code.
	/// </summary>
	public class BaseCodeImageLookup : BPMSoft.Configuration.BaseCodeLookup
	{

		#region Constructors: Public

		public BaseCodeImageLookup(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "BaseCodeImageLookup";
		}

		public BaseCodeImageLookup(BaseCodeImageLookup source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid ImageId {
			get {
				return GetTypedColumnValue<Guid>("ImageId");
			}
			set {
				SetColumnValue("ImageId", value);
				_image = null;
			}
		}

		/// <exclude/>
		public string ImageName {
			get {
				return GetTypedColumnValue<string>("ImageName");
			}
			set {
				SetColumnValue("ImageName", value);
				if (_image != null) {
					_image.Name = value;
				}
			}
		}

		private SysImage _image;
		/// <summary>
		/// Image.
		/// </summary>
		public SysImage Image {
			get {
				return _image ??
					(_image = LookupColumnEntities.GetEntity("Image") as SysImage);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new BaseCodeImageLookup_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("BaseCodeImageLookupDeleted", e);
			Deleting += (s, e) => ThrowEvent("BaseCodeImageLookupDeleting", e);
			Inserted += (s, e) => ThrowEvent("BaseCodeImageLookupInserted", e);
			Inserting += (s, e) => ThrowEvent("BaseCodeImageLookupInserting", e);
			Saved += (s, e) => ThrowEvent("BaseCodeImageLookupSaved", e);
			Saving += (s, e) => ThrowEvent("BaseCodeImageLookupSaving", e);
			Validating += (s, e) => ThrowEvent("BaseCodeImageLookupValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new BaseCodeImageLookup(this);
		}

		#endregion

	}

	#endregion

	#region Class: BaseCodeImageLookup_BaseEventsProcess

	/// <exclude/>
	public partial class BaseCodeImageLookup_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseCodeLookup_BaseEventsProcess<TEntity> where TEntity : BaseCodeImageLookup
	{

		public BaseCodeImageLookup_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "BaseCodeImageLookup_BaseEventsProcess";
			SchemaUId = new Guid("c21771d2-01fa-4646-96b0-e4b69e582b44");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("c21771d2-01fa-4646-96b0-e4b69e582b44");
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

	#region Class: BaseCodeImageLookup_BaseEventsProcess

	/// <exclude/>
	public class BaseCodeImageLookup_BaseEventsProcess : BaseCodeImageLookup_BaseEventsProcess<BaseCodeImageLookup>
	{

		public BaseCodeImageLookup_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: BaseCodeImageLookup_BaseEventsProcess

	public partial class BaseCodeImageLookup_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: BaseCodeImageLookupEventsProcess

	/// <exclude/>
	public class BaseCodeImageLookupEventsProcess : BaseCodeImageLookup_BaseEventsProcess
	{

		public BaseCodeImageLookupEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

