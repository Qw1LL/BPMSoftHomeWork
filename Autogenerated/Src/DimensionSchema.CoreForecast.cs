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

	#region Class: DimensionSchema

	/// <exclude/>
	public class DimensionSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public DimensionSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public DimensionSchema(DimensionSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public DimensionSchema(DimensionSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("488f25fa-5d1c-49d4-b2f0-8d6c2a5eab19");
			RealUId = new Guid("488f25fa-5d1c-49d4-b2f0-8d6c2a5eab19");
			Name = "Dimension";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("7c408f6d-0911-41c7-b495-80ace275c6f2");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateNameColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializePrimaryOrderColumn() {
			base.InitializePrimaryOrderColumn();
			PrimaryOrderColumn = CreateNameColumn();
			if (Columns.FindByUId(PrimaryOrderColumn.UId) == null) {
				Columns.Add(PrimaryOrderColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("14055143-dfec-47d9-9acb-54dbf93106e9")) == null) {
				Columns.Add(CreatePathColumn());
			}
			if (Columns.FindByUId(new Guid("856dceda-bb97-4e4e-aa55-3dce60eebe67")) == null) {
				Columns.Add(CreateEntitySchemaUIdColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("fe4b0601-251d-4154-8e83-2c323fd6e46c"),
				Name = @"Name",
				CreatedInSchemaUId = new Guid("488f25fa-5d1c-49d4-b2f0-8d6c2a5eab19"),
				ModifiedInSchemaUId = new Guid("488f25fa-5d1c-49d4-b2f0-8d6c2a5eab19"),
				CreatedInPackageId = new Guid("7c408f6d-0911-41c7-b495-80ace275c6f2"),
				IsLocalizable = true
			};
		}

		protected virtual EntitySchemaColumn CreatePathColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("14055143-dfec-47d9-9acb-54dbf93106e9"),
				Name = @"Path",
				CreatedInSchemaUId = new Guid("488f25fa-5d1c-49d4-b2f0-8d6c2a5eab19"),
				ModifiedInSchemaUId = new Guid("488f25fa-5d1c-49d4-b2f0-8d6c2a5eab19"),
				CreatedInPackageId = new Guid("7c408f6d-0911-41c7-b495-80ace275c6f2")
			};
		}

		protected virtual EntitySchemaColumn CreateEntitySchemaUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("856dceda-bb97-4e4e-aa55-3dce60eebe67"),
				Name = @"EntitySchemaUId",
				CreatedInSchemaUId = new Guid("488f25fa-5d1c-49d4-b2f0-8d6c2a5eab19"),
				ModifiedInSchemaUId = new Guid("488f25fa-5d1c-49d4-b2f0-8d6c2a5eab19"),
				CreatedInPackageId = new Guid("7c408f6d-0911-41c7-b495-80ace275c6f2")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new Dimension(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Dimension_CoreForecastEventsProcess(userConnection);
		}

		public override object Clone() {
			return new DimensionSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new DimensionSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("488f25fa-5d1c-49d4-b2f0-8d6c2a5eab19"));
		}

		#endregion

	}

	#endregion

	#region Class: Dimension

	/// <summary>
	/// Измерение.
	/// </summary>
	public class Dimension : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public Dimension(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Dimension";
		}

		public Dimension(Dimension source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

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

		/// <summary>
		/// Путь.
		/// </summary>
		public string Path {
			get {
				return GetTypedColumnValue<string>("Path");
			}
			set {
				SetColumnValue("Path", value);
			}
		}

		/// <summary>
		/// Ссылка на страницу справочника измерения.
		/// </summary>
		public Guid EntitySchemaUId {
			get {
				return GetTypedColumnValue<Guid>("EntitySchemaUId");
			}
			set {
				SetColumnValue("EntitySchemaUId", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Dimension_CoreForecastEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("DimensionDeleted", e);
			Validating += (s, e) => ThrowEvent("DimensionValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new Dimension(this);
		}

		#endregion

	}

	#endregion

	#region Class: Dimension_CoreForecastEventsProcess

	/// <exclude/>
	public partial class Dimension_CoreForecastEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : Dimension
	{

		public Dimension_CoreForecastEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Dimension_CoreForecastEventsProcess";
			SchemaUId = new Guid("488f25fa-5d1c-49d4-b2f0-8d6c2a5eab19");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("488f25fa-5d1c-49d4-b2f0-8d6c2a5eab19");
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

	#region Class: Dimension_CoreForecastEventsProcess

	/// <exclude/>
	public class Dimension_CoreForecastEventsProcess : Dimension_CoreForecastEventsProcess<Dimension>
	{

		public Dimension_CoreForecastEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: Dimension_CoreForecastEventsProcess

	public partial class Dimension_CoreForecastEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: DimensionEventsProcess

	/// <exclude/>
	public class DimensionEventsProcess : Dimension_CoreForecastEventsProcess
	{

		public DimensionEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

