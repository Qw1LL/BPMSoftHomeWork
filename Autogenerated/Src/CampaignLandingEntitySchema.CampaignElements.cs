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

	#region Class: CampaignLandingEntitySchema

	/// <exclude/>
	public class CampaignLandingEntitySchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public CampaignLandingEntitySchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public CampaignLandingEntitySchema(CampaignLandingEntitySchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public CampaignLandingEntitySchema(CampaignLandingEntitySchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("38b537ce-2312-839f-bed3-460a056f339c");
			RealUId = new Guid("38b537ce-2312-839f-bed3-460a056f339c");
			Name = "CampaignLandingEntity";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("6c038aa0-46cd-4697-bc93-5c682e364aef");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateCaptionColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("bff4ba5d-09eb-d205-e4af-cb20564f4427")) == null) {
				Columns.Add(CreateEntityObjectColumn());
			}
			if (Columns.FindByUId(new Guid("6ac9b3f5-faa1-45fa-d417-ffb300e459b3")) == null) {
				Columns.Add(CreateContactColumnColumn());
			}
			if (Columns.FindByUId(new Guid("161d26fc-da28-9d4e-b12d-752ac59acd8d")) == null) {
				Columns.Add(CreateWebFormColumnColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateCaptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("4ce58469-7e86-c07b-01e8-680628a18a38"),
				Name = @"Caption",
				CreatedInSchemaUId = new Guid("38b537ce-2312-839f-bed3-460a056f339c"),
				ModifiedInSchemaUId = new Guid("38b537ce-2312-839f-bed3-460a056f339c"),
				CreatedInPackageId = new Guid("6c038aa0-46cd-4697-bc93-5c682e364aef"),
				IsLocalizable = true
			};
		}

		protected virtual EntitySchemaColumn CreateEntityObjectColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("bff4ba5d-09eb-d205-e4af-cb20564f4427"),
				Name = @"EntityObject",
				ReferenceSchemaUId = new Guid("c82db13a-7f77-4085-b3ef-91c5420fd417"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsWeakReference = true,
				CreatedInSchemaUId = new Guid("38b537ce-2312-839f-bed3-460a056f339c"),
				ModifiedInSchemaUId = new Guid("38b537ce-2312-839f-bed3-460a056f339c"),
				CreatedInPackageId = new Guid("d0bba11f-3986-4819-81ab-1d3ddbfc1f48")
			};
		}

		protected virtual EntitySchemaColumn CreateContactColumnColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("6ac9b3f5-faa1-45fa-d417-ffb300e459b3"),
				Name = @"ContactColumn",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("38b537ce-2312-839f-bed3-460a056f339c"),
				ModifiedInSchemaUId = new Guid("38b537ce-2312-839f-bed3-460a056f339c"),
				CreatedInPackageId = new Guid("d0bba11f-3986-4819-81ab-1d3ddbfc1f48")
			};
		}

		protected virtual EntitySchemaColumn CreateWebFormColumnColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("161d26fc-da28-9d4e-b12d-752ac59acd8d"),
				Name = @"WebFormColumn",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("38b537ce-2312-839f-bed3-460a056f339c"),
				ModifiedInSchemaUId = new Guid("38b537ce-2312-839f-bed3-460a056f339c"),
				CreatedInPackageId = new Guid("d0bba11f-3986-4819-81ab-1d3ddbfc1f48")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new CampaignLandingEntity(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new CampaignLandingEntity_CampaignElementsEventsProcess(userConnection);
		}

		public override object Clone() {
			return new CampaignLandingEntitySchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new CampaignLandingEntitySchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("38b537ce-2312-839f-bed3-460a056f339c"));
		}

		#endregion

	}

	#endregion

	#region Class: CampaignLandingEntity

	/// <summary>
	/// Настройки объекта для элемента кампании Лендинг.
	/// </summary>
	public class CampaignLandingEntity : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public CampaignLandingEntity(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "CampaignLandingEntity";
		}

		public CampaignLandingEntity(CampaignLandingEntity source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Название.
		/// </summary>
		public string Caption {
			get {
				return GetTypedColumnValue<string>("Caption");
			}
			set {
				SetColumnValue("Caption", value);
			}
		}

		/// <exclude/>
		public Guid EntityObjectId {
			get {
				return GetTypedColumnValue<Guid>("EntityObjectId");
			}
			set {
				SetColumnValue("EntityObjectId", value);
				_entityObject = null;
			}
		}

		/// <exclude/>
		public string EntityObjectTitle {
			get {
				return GetTypedColumnValue<string>("EntityObjectTitle");
			}
			set {
				SetColumnValue("EntityObjectTitle", value);
				if (_entityObject != null) {
					_entityObject.Title = value;
				}
			}
		}

		private VwEntityObjects _entityObject;
		/// <summary>
		/// Объект.
		/// </summary>
		public VwEntityObjects EntityObject {
			get {
				return _entityObject ??
					(_entityObject = LookupColumnEntities.GetEntity("EntityObject") as VwEntityObjects);
			}
		}

		/// <summary>
		/// Путь к Контакту.
		/// </summary>
		public string ContactColumn {
			get {
				return GetTypedColumnValue<string>("ContactColumn");
			}
			set {
				SetColumnValue("ContactColumn", value);
			}
		}

		/// <summary>
		/// Путь к идентификатору веб-формы.
		/// </summary>
		public string WebFormColumn {
			get {
				return GetTypedColumnValue<string>("WebFormColumn");
			}
			set {
				SetColumnValue("WebFormColumn", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new CampaignLandingEntity_CampaignElementsEventsProcess(UserConnection);
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
			return new CampaignLandingEntity(this);
		}

		#endregion

	}

	#endregion

	#region Class: CampaignLandingEntity_CampaignElementsEventsProcess

	/// <exclude/>
	public partial class CampaignLandingEntity_CampaignElementsEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : CampaignLandingEntity
	{

		public CampaignLandingEntity_CampaignElementsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "CampaignLandingEntity_CampaignElementsEventsProcess";
			SchemaUId = new Guid("38b537ce-2312-839f-bed3-460a056f339c");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("38b537ce-2312-839f-bed3-460a056f339c");
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

	#region Class: CampaignLandingEntity_CampaignElementsEventsProcess

	/// <exclude/>
	public class CampaignLandingEntity_CampaignElementsEventsProcess : CampaignLandingEntity_CampaignElementsEventsProcess<CampaignLandingEntity>
	{

		public CampaignLandingEntity_CampaignElementsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: CampaignLandingEntity_CampaignElementsEventsProcess

	public partial class CampaignLandingEntity_CampaignElementsEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: CampaignLandingEntityEventsProcess

	/// <exclude/>
	public class CampaignLandingEntityEventsProcess : CampaignLandingEntity_CampaignElementsEventsProcess
	{

		public CampaignLandingEntityEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

