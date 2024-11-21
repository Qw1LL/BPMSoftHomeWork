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

	#region Class: DaDataSuggestionsEntitySchema

	/// <exclude/>
	public class DaDataSuggestionsEntitySchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public DaDataSuggestionsEntitySchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public DaDataSuggestionsEntitySchema(DaDataSuggestionsEntitySchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public DaDataSuggestionsEntitySchema(DaDataSuggestionsEntitySchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("a61a128c-9043-4b03-8274-3f718070e794");
			RealUId = new Guid("a61a128c-9043-4b03-8274-3f718070e794");
			Name = "DaDataSuggestionsEntity";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("3003ba4f-492e-4787-9e54-367e73442d72");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateEntitySchemaCaptionColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("d471fdc4-3f48-49c0-9d38-b2dcc967dffc")) == null) {
				Columns.Add(CreateEntitySchemaNameColumn());
			}
			if (Columns.FindByUId(new Guid("faa7a9e9-826d-4049-8b29-78d2386b56b7")) == null) {
				Columns.Add(CreateIsActiveColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateEntitySchemaCaptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("5ebbdd30-30bc-4112-bc1a-e4778a4ef300"),
				Name = @"EntitySchemaCaption",
				CreatedInSchemaUId = new Guid("a61a128c-9043-4b03-8274-3f718070e794"),
				ModifiedInSchemaUId = new Guid("a61a128c-9043-4b03-8274-3f718070e794"),
				CreatedInPackageId = new Guid("3003ba4f-492e-4787-9e54-367e73442d72")
			};
		}

		protected virtual EntitySchemaColumn CreateEntitySchemaNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("d471fdc4-3f48-49c0-9d38-b2dcc967dffc"),
				Name = @"EntitySchemaName",
				CreatedInSchemaUId = new Guid("a61a128c-9043-4b03-8274-3f718070e794"),
				ModifiedInSchemaUId = new Guid("a61a128c-9043-4b03-8274-3f718070e794"),
				CreatedInPackageId = new Guid("3003ba4f-492e-4787-9e54-367e73442d72")
			};
		}

		protected virtual EntitySchemaColumn CreateIsActiveColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("faa7a9e9-826d-4049-8b29-78d2386b56b7"),
				Name = @"IsActive",
				CreatedInSchemaUId = new Guid("a61a128c-9043-4b03-8274-3f718070e794"),
				ModifiedInSchemaUId = new Guid("a61a128c-9043-4b03-8274-3f718070e794"),
				CreatedInPackageId = new Guid("3003ba4f-492e-4787-9e54-367e73442d72")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new DaDataSuggestionsEntity(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new DaDataSuggestionsEntity_DaDataSuggestionsEventsProcess(userConnection);
		}

		public override object Clone() {
			return new DaDataSuggestionsEntitySchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new DaDataSuggestionsEntitySchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("a61a128c-9043-4b03-8274-3f718070e794"));
		}

		#endregion

	}

	#endregion

	#region Class: DaDataSuggestionsEntity

	/// <summary>
	/// Объект с подсказками DaData.
	/// </summary>
	public class DaDataSuggestionsEntity : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public DaDataSuggestionsEntity(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "DaDataSuggestionsEntity";
		}

		public DaDataSuggestionsEntity(DaDataSuggestionsEntity source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Заголовок.
		/// </summary>
		public string EntitySchemaCaption {
			get {
				return GetTypedColumnValue<string>("EntitySchemaCaption");
			}
			set {
				SetColumnValue("EntitySchemaCaption", value);
			}
		}

		/// <summary>
		/// Имя схемы объекта.
		/// </summary>
		public string EntitySchemaName {
			get {
				return GetTypedColumnValue<string>("EntitySchemaName");
			}
			set {
				SetColumnValue("EntitySchemaName", value);
			}
		}

		/// <summary>
		/// Используется.
		/// </summary>
		public bool IsActive {
			get {
				return GetTypedColumnValue<bool>("IsActive");
			}
			set {
				SetColumnValue("IsActive", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new DaDataSuggestionsEntity_DaDataSuggestionsEventsProcess(UserConnection);
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
			return new DaDataSuggestionsEntity(this);
		}

		#endregion

	}

	#endregion

	#region Class: DaDataSuggestionsEntity_DaDataSuggestionsEventsProcess

	/// <exclude/>
	public partial class DaDataSuggestionsEntity_DaDataSuggestionsEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : DaDataSuggestionsEntity
	{

		public DaDataSuggestionsEntity_DaDataSuggestionsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "DaDataSuggestionsEntity_DaDataSuggestionsEventsProcess";
			SchemaUId = new Guid("a61a128c-9043-4b03-8274-3f718070e794");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("a61a128c-9043-4b03-8274-3f718070e794");
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

	#region Class: DaDataSuggestionsEntity_DaDataSuggestionsEventsProcess

	/// <exclude/>
	public class DaDataSuggestionsEntity_DaDataSuggestionsEventsProcess : DaDataSuggestionsEntity_DaDataSuggestionsEventsProcess<DaDataSuggestionsEntity>
	{

		public DaDataSuggestionsEntity_DaDataSuggestionsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: DaDataSuggestionsEntity_DaDataSuggestionsEventsProcess

	public partial class DaDataSuggestionsEntity_DaDataSuggestionsEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: DaDataSuggestionsEntityEventsProcess

	/// <exclude/>
	public class DaDataSuggestionsEntityEventsProcess : DaDataSuggestionsEntity_DaDataSuggestionsEventsProcess
	{

		public DaDataSuggestionsEntityEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

