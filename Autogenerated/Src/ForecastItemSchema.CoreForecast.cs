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

	#region Class: ForecastItemSchema

	/// <exclude/>
	public class ForecastItemSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public ForecastItemSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ForecastItemSchema(ForecastItemSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ForecastItemSchema(ForecastItemSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("03d3b337-cda2-4993-ab53-d0bdf2c4bd43");
			RealUId = new Guid("03d3b337-cda2-4993-ab53-d0bdf2c4bd43");
			Name = "ForecastItem";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("7c408f6d-0911-41c7-b495-80ace275c6f2");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeHierarchyColumn() {
			base.InitializeHierarchyColumn();
			HierarchyColumn = CreateParentColumn();
			if (Columns.FindByUId(HierarchyColumn.UId) == null) {
				Columns.Add(HierarchyColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("0c62cbfb-4c07-460c-ba26-67ea6a41f63f")) == null) {
				Columns.Add(CreateForecastColumn());
			}
			if (Columns.FindByUId(new Guid("c26ea7e2-0bdc-4886-b935-dc2082ddda7b")) == null) {
				Columns.Add(CreateForecastDimensionColumn());
			}
			if (Columns.FindByUId(new Guid("47ecc95a-0f87-4f4d-a872-22bd71593fa2")) == null) {
				Columns.Add(CreateDimensionValueIdColumn());
			}
			if (Columns.FindByUId(new Guid("2e7ac2a0-e614-4bef-a4ba-0254a3399dc4")) == null) {
				Columns.Add(CreateIsDeletedColumn());
			}
			if (Columns.FindByUId(new Guid("dfc4f2d2-ee03-479e-85ad-a86b5c67078e")) == null) {
				Columns.Add(CreateNameColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateForecastColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("0c62cbfb-4c07-460c-ba26-67ea6a41f63f"),
				Name = @"Forecast",
				ReferenceSchemaUId = new Guid("ba399098-a520-4a1b-9ab2-2ec7ea8d97c9"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("03d3b337-cda2-4993-ab53-d0bdf2c4bd43"),
				ModifiedInSchemaUId = new Guid("03d3b337-cda2-4993-ab53-d0bdf2c4bd43"),
				CreatedInPackageId = new Guid("7c408f6d-0911-41c7-b495-80ace275c6f2")
			};
		}

		protected virtual EntitySchemaColumn CreateForecastDimensionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("c26ea7e2-0bdc-4886-b935-dc2082ddda7b"),
				Name = @"ForecastDimension",
				ReferenceSchemaUId = new Guid("c83de6c5-e072-4faf-9401-3092055fe96d"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("03d3b337-cda2-4993-ab53-d0bdf2c4bd43"),
				ModifiedInSchemaUId = new Guid("03d3b337-cda2-4993-ab53-d0bdf2c4bd43"),
				CreatedInPackageId = new Guid("7c408f6d-0911-41c7-b495-80ace275c6f2")
			};
		}

		protected virtual EntitySchemaColumn CreateDimensionValueIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("47ecc95a-0f87-4f4d-a872-22bd71593fa2"),
				Name = @"DimensionValueId",
				CreatedInSchemaUId = new Guid("03d3b337-cda2-4993-ab53-d0bdf2c4bd43"),
				ModifiedInSchemaUId = new Guid("03d3b337-cda2-4993-ab53-d0bdf2c4bd43"),
				CreatedInPackageId = new Guid("7c408f6d-0911-41c7-b495-80ace275c6f2")
			};
		}

		protected virtual EntitySchemaColumn CreateIsDeletedColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("2e7ac2a0-e614-4bef-a4ba-0254a3399dc4"),
				Name = @"IsDeleted",
				CreatedInSchemaUId = new Guid("03d3b337-cda2-4993-ab53-d0bdf2c4bd43"),
				ModifiedInSchemaUId = new Guid("03d3b337-cda2-4993-ab53-d0bdf2c4bd43"),
				CreatedInPackageId = new Guid("7c408f6d-0911-41c7-b495-80ace275c6f2")
			};
		}

		protected virtual EntitySchemaColumn CreateParentColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("56da6b7d-f028-4107-ba85-7c60db4f85ec"),
				Name = @"Parent",
				ReferenceSchemaUId = new Guid("03d3b337-cda2-4993-ab53-d0bdf2c4bd43"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("03d3b337-cda2-4993-ab53-d0bdf2c4bd43"),
				ModifiedInSchemaUId = new Guid("03d3b337-cda2-4993-ab53-d0bdf2c4bd43"),
				CreatedInPackageId = new Guid("7c408f6d-0911-41c7-b495-80ace275c6f2")
			};
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("dfc4f2d2-ee03-479e-85ad-a86b5c67078e"),
				Name = @"Name",
				CreatedInSchemaUId = new Guid("03d3b337-cda2-4993-ab53-d0bdf2c4bd43"),
				ModifiedInSchemaUId = new Guid("03d3b337-cda2-4993-ab53-d0bdf2c4bd43"),
				CreatedInPackageId = new Guid("e361335e-8405-403c-ae87-309c09fd3acb"),
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
			return new ForecastItem(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ForecastItem_CoreForecastEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ForecastItemSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ForecastItemSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("03d3b337-cda2-4993-ab53-d0bdf2c4bd43"));
		}

		#endregion

	}

	#endregion

	#region Class: ForecastItem

	/// <summary>
	/// Элемент планирования (не используется).
	/// </summary>
	public class ForecastItem : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public ForecastItem(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ForecastItem";
		}

		public ForecastItem(ForecastItem source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid ForecastId {
			get {
				return GetTypedColumnValue<Guid>("ForecastId");
			}
			set {
				SetColumnValue("ForecastId", value);
				_forecast = null;
			}
		}

		/// <exclude/>
		public string ForecastName {
			get {
				return GetTypedColumnValue<string>("ForecastName");
			}
			set {
				SetColumnValue("ForecastName", value);
				if (_forecast != null) {
					_forecast.Name = value;
				}
			}
		}

		private Forecast _forecast;
		/// <summary>
		/// Планирование.
		/// </summary>
		public Forecast Forecast {
			get {
				return _forecast ??
					(_forecast = LookupColumnEntities.GetEntity("Forecast") as Forecast);
			}
		}

		/// <exclude/>
		public Guid ForecastDimensionId {
			get {
				return GetTypedColumnValue<Guid>("ForecastDimensionId");
			}
			set {
				SetColumnValue("ForecastDimensionId", value);
				_forecastDimension = null;
			}
		}

		private ForecastDimension _forecastDimension;
		/// <summary>
		/// Срез планирования.
		/// </summary>
		public ForecastDimension ForecastDimension {
			get {
				return _forecastDimension ??
					(_forecastDimension = LookupColumnEntities.GetEntity("ForecastDimension") as ForecastDimension);
			}
		}

		/// <summary>
		/// Значение элемента планирования.
		/// </summary>
		public Guid DimensionValueId {
			get {
				return GetTypedColumnValue<Guid>("DimensionValueId");
			}
			set {
				SetColumnValue("DimensionValueId", value);
			}
		}

		/// <summary>
		/// Удален.
		/// </summary>
		public bool IsDeleted {
			get {
				return GetTypedColumnValue<bool>("IsDeleted");
			}
			set {
				SetColumnValue("IsDeleted", value);
			}
		}

		/// <exclude/>
		public Guid ParentId {
			get {
				return GetTypedColumnValue<Guid>("ParentId");
			}
			set {
				SetColumnValue("ParentId", value);
				_parent = null;
			}
		}

		private ForecastItem _parent;
		/// <summary>
		/// Родительский элемент планирования.
		/// </summary>
		public ForecastItem Parent {
			get {
				return _parent ??
					(_parent = LookupColumnEntities.GetEntity("Parent") as ForecastItem);
			}
		}

		/// <summary>
		/// Название.
		/// </summary>
		public string Name {
			get {
				return GetTypedColumnValue<string>("Name");
			}
			set {
				SetColumnValue("Name", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ForecastItem_CoreForecastEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ForecastItemDeleted", e);
			Validating += (s, e) => ThrowEvent("ForecastItemValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ForecastItem(this);
		}

		#endregion

	}

	#endregion

	#region Class: ForecastItem_CoreForecastEventsProcess

	/// <exclude/>
	public partial class ForecastItem_CoreForecastEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : ForecastItem
	{

		public ForecastItem_CoreForecastEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ForecastItem_CoreForecastEventsProcess";
			SchemaUId = new Guid("03d3b337-cda2-4993-ab53-d0bdf2c4bd43");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("03d3b337-cda2-4993-ab53-d0bdf2c4bd43");
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

	#region Class: ForecastItem_CoreForecastEventsProcess

	/// <exclude/>
	public class ForecastItem_CoreForecastEventsProcess : ForecastItem_CoreForecastEventsProcess<ForecastItem>
	{

		public ForecastItem_CoreForecastEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ForecastItem_CoreForecastEventsProcess

	public partial class ForecastItem_CoreForecastEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ForecastItemEventsProcess

	/// <exclude/>
	public class ForecastItemEventsProcess : ForecastItem_CoreForecastEventsProcess
	{

		public ForecastItemEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

