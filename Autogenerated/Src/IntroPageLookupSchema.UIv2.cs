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

	#region Class: IntroPageLookupSchema

	/// <exclude/>
	public class IntroPageLookupSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public IntroPageLookupSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public IntroPageLookupSchema(IntroPageLookupSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public IntroPageLookupSchema(IntroPageLookupSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("5bf5c87a-6fe3-4d5e-9432-14f7fcc7b1c8");
			RealUId = new Guid("5bf5c87a-6fe3-4d5e-9432-14f7fcc7b1c8");
			Name = "IntroPageLookup";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("d717c1d0-1754-415d-a9f4-50065152a939");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateCodePageColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("63367d45-a96a-40b5-9d3d-3acbbedeff62")) == null) {
				Columns.Add(CreateAcademyUrlColumn());
			}
			if (Columns.FindByUId(new Guid("9001f045-69f7-482c-8e32-a9737674f261")) == null) {
				Columns.Add(CreateVideoUrlColumn());
			}
			if (Columns.FindByUId(new Guid("0cf82306-7f75-4096-965d-9f7cf3e55b19")) == null) {
				Columns.Add(CreateVideoCaptionColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateCodePageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("e616bf14-23f4-4f6f-bff6-08540d790290"),
				Name = @"CodePage",
				CreatedInSchemaUId = new Guid("5bf5c87a-6fe3-4d5e-9432-14f7fcc7b1c8"),
				ModifiedInSchemaUId = new Guid("5bf5c87a-6fe3-4d5e-9432-14f7fcc7b1c8"),
				CreatedInPackageId = new Guid("d717c1d0-1754-415d-a9f4-50065152a939")
			};
		}

		protected virtual EntitySchemaColumn CreateAcademyUrlColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("63367d45-a96a-40b5-9d3d-3acbbedeff62"),
				Name = @"AcademyUrl",
				CreatedInSchemaUId = new Guid("5bf5c87a-6fe3-4d5e-9432-14f7fcc7b1c8"),
				ModifiedInSchemaUId = new Guid("5bf5c87a-6fe3-4d5e-9432-14f7fcc7b1c8"),
				CreatedInPackageId = new Guid("d717c1d0-1754-415d-a9f4-50065152a939"),
				IsLocalizable = true
			};
		}

		protected virtual EntitySchemaColumn CreateVideoUrlColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("9001f045-69f7-482c-8e32-a9737674f261"),
				Name = @"VideoUrl",
				CreatedInSchemaUId = new Guid("5bf5c87a-6fe3-4d5e-9432-14f7fcc7b1c8"),
				ModifiedInSchemaUId = new Guid("5bf5c87a-6fe3-4d5e-9432-14f7fcc7b1c8"),
				CreatedInPackageId = new Guid("d717c1d0-1754-415d-a9f4-50065152a939"),
				IsLocalizable = true
			};
		}

		protected virtual EntitySchemaColumn CreateVideoCaptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("0cf82306-7f75-4096-965d-9f7cf3e55b19"),
				Name = @"VideoCaption",
				CreatedInSchemaUId = new Guid("5bf5c87a-6fe3-4d5e-9432-14f7fcc7b1c8"),
				ModifiedInSchemaUId = new Guid("5bf5c87a-6fe3-4d5e-9432-14f7fcc7b1c8"),
				CreatedInPackageId = new Guid("d717c1d0-1754-415d-a9f4-50065152a939"),
				IsLocalizable = true
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new IntroPageLookup(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new IntroPageLookup_UIv2EventsProcess(userConnection);
		}

		public override object Clone() {
			return new IntroPageLookupSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new IntroPageLookupSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("5bf5c87a-6fe3-4d5e-9432-14f7fcc7b1c8"));
		}

		#endregion

	}

	#endregion

	#region Class: IntroPageLookup

	/// <summary>
	/// Справочник для главной страницы.
	/// </summary>
	public class IntroPageLookup : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public IntroPageLookup(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "IntroPageLookup";
		}

		public IntroPageLookup(IntroPageLookup source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Page code.
		/// </summary>
		public string CodePage {
			get {
				return GetTypedColumnValue<string>("CodePage");
			}
			set {
				SetColumnValue("CodePage", value);
			}
		}

		/// <summary>
		/// Ссылка.
		/// </summary>
		public string AcademyUrl {
			get {
				return GetTypedColumnValue<string>("AcademyUrl");
			}
			set {
				SetColumnValue("AcademyUrl", value);
			}
		}

		/// <summary>
		/// Ссылка на видео.
		/// </summary>
		public string VideoUrl {
			get {
				return GetTypedColumnValue<string>("VideoUrl");
			}
			set {
				SetColumnValue("VideoUrl", value);
			}
		}

		/// <summary>
		/// Подпись видео.
		/// </summary>
		public string VideoCaption {
			get {
				return GetTypedColumnValue<string>("VideoCaption");
			}
			set {
				SetColumnValue("VideoCaption", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new IntroPageLookup_UIv2EventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("IntroPageLookupDeleted", e);
			Validating += (s, e) => ThrowEvent("IntroPageLookupValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new IntroPageLookup(this);
		}

		#endregion

	}

	#endregion

	#region Class: IntroPageLookup_UIv2EventsProcess

	/// <exclude/>
	public partial class IntroPageLookup_UIv2EventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : IntroPageLookup
	{

		public IntroPageLookup_UIv2EventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "IntroPageLookup_UIv2EventsProcess";
			SchemaUId = new Guid("5bf5c87a-6fe3-4d5e-9432-14f7fcc7b1c8");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("5bf5c87a-6fe3-4d5e-9432-14f7fcc7b1c8");
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

	#region Class: IntroPageLookup_UIv2EventsProcess

	/// <exclude/>
	public class IntroPageLookup_UIv2EventsProcess : IntroPageLookup_UIv2EventsProcess<IntroPageLookup>
	{

		public IntroPageLookup_UIv2EventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: IntroPageLookup_UIv2EventsProcess

	public partial class IntroPageLookup_UIv2EventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: IntroPageLookupEventsProcess

	/// <exclude/>
	public class IntroPageLookupEventsProcess : IntroPageLookup_UIv2EventsProcess
	{

		public IntroPageLookupEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

