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

	#region Class: MultiLookupImageSchema

	/// <exclude/>
	public class MultiLookupImageSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public MultiLookupImageSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public MultiLookupImageSchema(MultiLookupImageSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public MultiLookupImageSchema(MultiLookupImageSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("1d678b87-fc77-4218-91af-9aa8fd8fc943");
			RealUId = new Guid("1d678b87-fc77-4218-91af-9aa8fd8fc943");
			Name = "MultiLookupImage";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("f9b20943-08ce-493b-8317-f8df2c35f81f");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("3deb26ba-c2c1-4b2d-a8c1-be665c523372")) == null) {
				Columns.Add(CreateCodeColumn());
			}
			if (Columns.FindByUId(new Guid("62037abd-6b76-46c3-8645-13839e7bca9f")) == null) {
				Columns.Add(CreateLookupImageColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateCodeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("3deb26ba-c2c1-4b2d-a8c1-be665c523372"),
				Name = @"Code",
				CreatedInSchemaUId = new Guid("1d678b87-fc77-4218-91af-9aa8fd8fc943"),
				ModifiedInSchemaUId = new Guid("1d678b87-fc77-4218-91af-9aa8fd8fc943"),
				CreatedInPackageId = new Guid("f9b20943-08ce-493b-8317-f8df2c35f81f")
			};
		}

		protected virtual EntitySchemaColumn CreateLookupImageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ImageLookup")) {
				UId = new Guid("62037abd-6b76-46c3-8645-13839e7bca9f"),
				Name = @"LookupImage",
				ReferenceSchemaUId = new Guid("93986bfe-2dbd-46bc-9bf9-d03dfefbf3b8"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("1d678b87-fc77-4218-91af-9aa8fd8fc943"),
				ModifiedInSchemaUId = new Guid("1d678b87-fc77-4218-91af-9aa8fd8fc943"),
				CreatedInPackageId = new Guid("f9b20943-08ce-493b-8317-f8df2c35f81f")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new MultiLookupImage(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new MultiLookupImage_NUIEventsProcess(userConnection);
		}

		public override object Clone() {
			return new MultiLookupImageSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new MultiLookupImageSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("1d678b87-fc77-4218-91af-9aa8fd8fc943"));
		}

		#endregion

	}

	#endregion

	#region Class: MultiLookupImage

	/// <summary>
	/// Images for MultiLookup.
	/// </summary>
	public class MultiLookupImage : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public MultiLookupImage(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "MultiLookupImage";
		}

		public MultiLookupImage(MultiLookupImage source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Code.
		/// </summary>
		public string Code {
			get {
				return GetTypedColumnValue<string>("Code");
			}
			set {
				SetColumnValue("Code", value);
			}
		}

		/// <exclude/>
		public Guid LookupImageId {
			get {
				return GetTypedColumnValue<Guid>("LookupImageId");
			}
			set {
				SetColumnValue("LookupImageId", value);
				_lookupImage = null;
			}
		}

		/// <exclude/>
		public string LookupImageName {
			get {
				return GetTypedColumnValue<string>("LookupImageName");
			}
			set {
				SetColumnValue("LookupImageName", value);
				if (_lookupImage != null) {
					_lookupImage.Name = value;
				}
			}
		}

		private SysImage _lookupImage;
		/// <summary>
		/// Lookup image.
		/// </summary>
		public SysImage LookupImage {
			get {
				return _lookupImage ??
					(_lookupImage = LookupColumnEntities.GetEntity("LookupImage") as SysImage);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new MultiLookupImage_NUIEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("MultiLookupImageDeleted", e);
			Validating += (s, e) => ThrowEvent("MultiLookupImageValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new MultiLookupImage(this);
		}

		#endregion

	}

	#endregion

	#region Class: MultiLookupImage_NUIEventsProcess

	/// <exclude/>
	public partial class MultiLookupImage_NUIEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : MultiLookupImage
	{

		public MultiLookupImage_NUIEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "MultiLookupImage_NUIEventsProcess";
			SchemaUId = new Guid("1d678b87-fc77-4218-91af-9aa8fd8fc943");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("1d678b87-fc77-4218-91af-9aa8fd8fc943");
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

	#region Class: MultiLookupImage_NUIEventsProcess

	/// <exclude/>
	public class MultiLookupImage_NUIEventsProcess : MultiLookupImage_NUIEventsProcess<MultiLookupImage>
	{

		public MultiLookupImage_NUIEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: MultiLookupImage_NUIEventsProcess

	public partial class MultiLookupImage_NUIEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: MultiLookupImageEventsProcess

	/// <exclude/>
	public class MultiLookupImageEventsProcess : MultiLookupImage_NUIEventsProcess
	{

		public MultiLookupImageEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

