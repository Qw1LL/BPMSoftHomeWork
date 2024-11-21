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

	#region Class: OpportunityMood_Opportunity_BPMSoftSchema

	/// <exclude/>
	public class OpportunityMood_Opportunity_BPMSoftSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public OpportunityMood_Opportunity_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public OpportunityMood_Opportunity_BPMSoftSchema(OpportunityMood_Opportunity_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public OpportunityMood_Opportunity_BPMSoftSchema(OpportunityMood_Opportunity_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("c8b8800f-c6ca-4b8b-962b-e79307b5d95e");
			RealUId = new Guid("c8b8800f-c6ca-4b8b-962b-e79307b5d95e");
			Name = "OpportunityMood_Opportunity_BPMSoft";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("5d4440f3-755f-4128-9701-bb9585b17c33");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryImageColumn() {
			base.InitializePrimaryImageColumn();
			PrimaryImageColumn = CreateImageColumn();
			if (Columns.FindByUId(PrimaryImageColumn.UId) == null) {
				Columns.Add(PrimaryImageColumn);
			}
		}

		protected override void InitializePrimaryOrderColumn() {
			base.InitializePrimaryOrderColumn();
			PrimaryOrderColumn = CreatePositionColumn();
			if (Columns.FindByUId(PrimaryOrderColumn.UId) == null) {
				Columns.Add(PrimaryOrderColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("c8b8800f-c6ca-4b8b-962b-e79307b5d95e");
			column.CreatedInPackageId = new Guid("3d93940c-f8db-4ebc-8bac-f38ad5201620");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("c8b8800f-c6ca-4b8b-962b-e79307b5d95e");
			column.CreatedInPackageId = new Guid("3d93940c-f8db-4ebc-8bac-f38ad5201620");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("c8b8800f-c6ca-4b8b-962b-e79307b5d95e");
			column.CreatedInPackageId = new Guid("3d93940c-f8db-4ebc-8bac-f38ad5201620");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("c8b8800f-c6ca-4b8b-962b-e79307b5d95e");
			column.CreatedInPackageId = new Guid("3d93940c-f8db-4ebc-8bac-f38ad5201620");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("c8b8800f-c6ca-4b8b-962b-e79307b5d95e");
			column.CreatedInPackageId = new Guid("3d93940c-f8db-4ebc-8bac-f38ad5201620");
			return column;
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("c8b8800f-c6ca-4b8b-962b-e79307b5d95e");
			column.CreatedInPackageId = new Guid("3d93940c-f8db-4ebc-8bac-f38ad5201620");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("c8b8800f-c6ca-4b8b-962b-e79307b5d95e");
			column.CreatedInPackageId = new Guid("3d93940c-f8db-4ebc-8bac-f38ad5201620");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("c8b8800f-c6ca-4b8b-962b-e79307b5d95e");
			column.CreatedInPackageId = new Guid("3d93940c-f8db-4ebc-8bac-f38ad5201620");
			return column;
		}

		protected virtual EntitySchemaColumn CreateImageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ImageLookup")) {
				UId = new Guid("28626f38-2b77-47b0-a829-d3901a340645"),
				Name = @"Image",
				ReferenceSchemaUId = new Guid("93986bfe-2dbd-46bc-9bf9-d03dfefbf3b8"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("c8b8800f-c6ca-4b8b-962b-e79307b5d95e"),
				ModifiedInSchemaUId = new Guid("c8b8800f-c6ca-4b8b-962b-e79307b5d95e"),
				CreatedInPackageId = new Guid("3d93940c-f8db-4ebc-8bac-f38ad5201620")
			};
		}

		protected virtual EntitySchemaColumn CreatePositionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("6303fd54-dd11-4bd4-9e15-73f492ee4d5a"),
				Name = @"Position",
				CreatedInSchemaUId = new Guid("c8b8800f-c6ca-4b8b-962b-e79307b5d95e"),
				ModifiedInSchemaUId = new Guid("c8b8800f-c6ca-4b8b-962b-e79307b5d95e"),
				CreatedInPackageId = new Guid("3d93940c-f8db-4ebc-8bac-f38ad5201620")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new OpportunityMood_Opportunity_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new OpportunityMood_OpportunityEventsProcess(userConnection);
		}

		public override object Clone() {
			return new OpportunityMood_Opportunity_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new OpportunityMood_Opportunity_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("c8b8800f-c6ca-4b8b-962b-e79307b5d95e"));
		}

		#endregion

	}

	#endregion

	#region Class: OpportunityMood_Opportunity_BPMSoft

	/// <summary>
	/// Настроение менеджера в продаже.
	/// </summary>
	public class OpportunityMood_Opportunity_BPMSoft : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public OpportunityMood_Opportunity_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "OpportunityMood_Opportunity_BPMSoft";
		}

		public OpportunityMood_Opportunity_BPMSoft(OpportunityMood_Opportunity_BPMSoft source)
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
		/// Изображение.
		/// </summary>
		public SysImage Image {
			get {
				return _image ??
					(_image = LookupColumnEntities.GetEntity("Image") as SysImage);
			}
		}

		/// <summary>
		/// Позиция.
		/// </summary>
		public int Position {
			get {
				return GetTypedColumnValue<int>("Position");
			}
			set {
				SetColumnValue("Position", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new OpportunityMood_OpportunityEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("OpportunityMood_Opportunity_BPMSoftDeleted", e);
			Inserting += (s, e) => ThrowEvent("OpportunityMood_Opportunity_BPMSoftInserting", e);
			Validating += (s, e) => ThrowEvent("OpportunityMood_Opportunity_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new OpportunityMood_Opportunity_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: OpportunityMood_OpportunityEventsProcess

	/// <exclude/>
	public partial class OpportunityMood_OpportunityEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : OpportunityMood_Opportunity_BPMSoft
	{

		public OpportunityMood_OpportunityEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "OpportunityMood_OpportunityEventsProcess";
			SchemaUId = new Guid("c8b8800f-c6ca-4b8b-962b-e79307b5d95e");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("c8b8800f-c6ca-4b8b-962b-e79307b5d95e");
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

	#region Class: OpportunityMood_OpportunityEventsProcess

	/// <exclude/>
	public class OpportunityMood_OpportunityEventsProcess : OpportunityMood_OpportunityEventsProcess<OpportunityMood_Opportunity_BPMSoft>
	{

		public OpportunityMood_OpportunityEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: OpportunityMood_OpportunityEventsProcess

	public partial class OpportunityMood_OpportunityEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

