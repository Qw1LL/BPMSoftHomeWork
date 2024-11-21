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

	#region Class: LeadType_TouchPoints_BPMSoftSchema

	/// <exclude/>
	public class LeadType_TouchPoints_BPMSoftSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public LeadType_TouchPoints_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public LeadType_TouchPoints_BPMSoftSchema(LeadType_TouchPoints_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public LeadType_TouchPoints_BPMSoftSchema(LeadType_TouchPoints_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("e0dbeb22-4932-4eee-a8f2-a247a5fce888");
			RealUId = new Guid("e0dbeb22-4932-4eee-a8f2-a247a5fce888");
			Name = "LeadType_TouchPoints_BPMSoft";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("f56ba749-b4df-4ded-b740-db30fa3555ae");
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

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("e0dbeb22-4932-4eee-a8f2-a247a5fce888");
			column.CreatedInPackageId = new Guid("f56ba749-b4df-4ded-b740-db30fa3555ae");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("e0dbeb22-4932-4eee-a8f2-a247a5fce888");
			column.CreatedInPackageId = new Guid("f56ba749-b4df-4ded-b740-db30fa3555ae");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("e0dbeb22-4932-4eee-a8f2-a247a5fce888");
			column.CreatedInPackageId = new Guid("f56ba749-b4df-4ded-b740-db30fa3555ae");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("e0dbeb22-4932-4eee-a8f2-a247a5fce888");
			column.CreatedInPackageId = new Guid("f56ba749-b4df-4ded-b740-db30fa3555ae");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("e0dbeb22-4932-4eee-a8f2-a247a5fce888");
			column.CreatedInPackageId = new Guid("f56ba749-b4df-4ded-b740-db30fa3555ae");
			return column;
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("e0dbeb22-4932-4eee-a8f2-a247a5fce888");
			column.CreatedInPackageId = new Guid("f56ba749-b4df-4ded-b740-db30fa3555ae");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("e0dbeb22-4932-4eee-a8f2-a247a5fce888");
			column.CreatedInPackageId = new Guid("f56ba749-b4df-4ded-b740-db30fa3555ae");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("e0dbeb22-4932-4eee-a8f2-a247a5fce888");
			column.CreatedInPackageId = new Guid("f56ba749-b4df-4ded-b740-db30fa3555ae");
			return column;
		}

		protected virtual EntitySchemaColumn CreateImageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ImageLookup")) {
				UId = new Guid("39539b29-f4b5-4d7a-9a08-dc5978876705"),
				Name = @"Image",
				ReferenceSchemaUId = new Guid("93986bfe-2dbd-46bc-9bf9-d03dfefbf3b8"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("e0dbeb22-4932-4eee-a8f2-a247a5fce888"),
				ModifiedInSchemaUId = new Guid("e0dbeb22-4932-4eee-a8f2-a247a5fce888"),
				CreatedInPackageId = new Guid("f56ba749-b4df-4ded-b740-db30fa3555ae")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new LeadType_TouchPoints_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new LeadType_TouchPointsEventsProcess(userConnection);
		}

		public override object Clone() {
			return new LeadType_TouchPoints_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new LeadType_TouchPoints_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("e0dbeb22-4932-4eee-a8f2-a247a5fce888"));
		}

		#endregion

	}

	#endregion

	#region Class: LeadType_TouchPoints_BPMSoft

	/// <summary>
	/// Customer need.
	/// </summary>
	public class LeadType_TouchPoints_BPMSoft : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public LeadType_TouchPoints_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "LeadType_TouchPoints_BPMSoft";
		}

		public LeadType_TouchPoints_BPMSoft(LeadType_TouchPoints_BPMSoft source)
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
			var process = new LeadType_TouchPointsEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("LeadType_TouchPoints_BPMSoftDeleted", e);
			Inserting += (s, e) => ThrowEvent("LeadType_TouchPoints_BPMSoftInserting", e);
			Validating += (s, e) => ThrowEvent("LeadType_TouchPoints_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new LeadType_TouchPoints_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: LeadType_TouchPointsEventsProcess

	/// <exclude/>
	public partial class LeadType_TouchPointsEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : LeadType_TouchPoints_BPMSoft
	{

		public LeadType_TouchPointsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "LeadType_TouchPointsEventsProcess";
			SchemaUId = new Guid("e0dbeb22-4932-4eee-a8f2-a247a5fce888");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("e0dbeb22-4932-4eee-a8f2-a247a5fce888");
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

	#region Class: LeadType_TouchPointsEventsProcess

	/// <exclude/>
	public class LeadType_TouchPointsEventsProcess : LeadType_TouchPointsEventsProcess<LeadType_TouchPoints_BPMSoft>
	{

		public LeadType_TouchPointsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: LeadType_TouchPointsEventsProcess

	public partial class LeadType_TouchPointsEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

