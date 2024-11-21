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

	#region Class: BaseEnrichedDataSchema

	/// <exclude/>
	[IsVirtual]
	public class BaseEnrichedDataSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public BaseEnrichedDataSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public BaseEnrichedDataSchema(BaseEnrichedDataSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public BaseEnrichedDataSchema(BaseEnrichedDataSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("a06e4cd4-ea74-48da-9c77-b37d20d162db");
			RealUId = new Guid("a06e4cd4-ea74-48da-9c77-b37d20d162db");
			Name = "BaseEnrichedData";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("8f65d303-02ac-4efc-966c-086ff392449b");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("8c36bc65-9bce-4d31-84e6-eb38d8126487")) == null) {
				Columns.Add(CreateSearchDateColumn());
			}
			if (Columns.FindByUId(new Guid("9f0edf01-a026-429c-b26b-3f0db9279106")) == null) {
				Columns.Add(CreateCategoryTagColumn());
			}
			if (Columns.FindByUId(new Guid("8ea74488-8ee4-43d3-81f6-edbd8f4f70a5")) == null) {
				Columns.Add(CreateValueColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateSearchDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("8c36bc65-9bce-4d31-84e6-eb38d8126487"),
				Name = @"SearchDate",
				CreatedInSchemaUId = new Guid("a06e4cd4-ea74-48da-9c77-b37d20d162db"),
				ModifiedInSchemaUId = new Guid("a06e4cd4-ea74-48da-9c77-b37d20d162db"),
				CreatedInPackageId = new Guid("8f65d303-02ac-4efc-966c-086ff392449b")
			};
		}

		protected virtual EntitySchemaColumn CreateCategoryTagColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("9f0edf01-a026-429c-b26b-3f0db9279106"),
				Name = @"CategoryTag",
				CreatedInSchemaUId = new Guid("a06e4cd4-ea74-48da-9c77-b37d20d162db"),
				ModifiedInSchemaUId = new Guid("a06e4cd4-ea74-48da-9c77-b37d20d162db"),
				CreatedInPackageId = new Guid("8f65d303-02ac-4efc-966c-086ff392449b")
			};
		}

		protected virtual EntitySchemaColumn CreateValueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("8ea74488-8ee4-43d3-81f6-edbd8f4f70a5"),
				Name = @"Value",
				CreatedInSchemaUId = new Guid("a06e4cd4-ea74-48da-9c77-b37d20d162db"),
				ModifiedInSchemaUId = new Guid("a06e4cd4-ea74-48da-9c77-b37d20d162db"),
				CreatedInPackageId = new Guid("8f65d303-02ac-4efc-966c-086ff392449b")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new BaseEnrichedData(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new BaseEnrichedData_EnrichmentEventsProcess(userConnection);
		}

		public override object Clone() {
			return new BaseEnrichedDataSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new BaseEnrichedDataSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("a06e4cd4-ea74-48da-9c77-b37d20d162db"));
		}

		#endregion

	}

	#endregion

	#region Class: BaseEnrichedData

	/// <summary>
	/// Base object for unprocessed enriched data.
	/// </summary>
	public class BaseEnrichedData : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public BaseEnrichedData(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "BaseEnrichedData";
		}

		public BaseEnrichedData(BaseEnrichedData source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Search date.
		/// </summary>
		public DateTime SearchDate {
			get {
				return GetTypedColumnValue<DateTime>("SearchDate");
			}
			set {
				SetColumnValue("SearchDate", value);
			}
		}

		/// <summary>
		/// Information category tag.
		/// </summary>
		public string CategoryTag {
			get {
				return GetTypedColumnValue<string>("CategoryTag");
			}
			set {
				SetColumnValue("CategoryTag", value);
			}
		}

		/// <summary>
		/// Value.
		/// </summary>
		public string Value {
			get {
				return GetTypedColumnValue<string>("Value");
			}
			set {
				SetColumnValue("Value", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new BaseEnrichedData_EnrichmentEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("BaseEnrichedDataDeleted", e);
			Validating += (s, e) => ThrowEvent("BaseEnrichedDataValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new BaseEnrichedData(this);
		}

		#endregion

	}

	#endregion

	#region Class: BaseEnrichedData_EnrichmentEventsProcess

	/// <exclude/>
	public partial class BaseEnrichedData_EnrichmentEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : BaseEnrichedData
	{

		public BaseEnrichedData_EnrichmentEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "BaseEnrichedData_EnrichmentEventsProcess";
			SchemaUId = new Guid("a06e4cd4-ea74-48da-9c77-b37d20d162db");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("a06e4cd4-ea74-48da-9c77-b37d20d162db");
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

	#region Class: BaseEnrichedData_EnrichmentEventsProcess

	/// <exclude/>
	public class BaseEnrichedData_EnrichmentEventsProcess : BaseEnrichedData_EnrichmentEventsProcess<BaseEnrichedData>
	{

		public BaseEnrichedData_EnrichmentEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: BaseEnrichedData_EnrichmentEventsProcess

	public partial class BaseEnrichedData_EnrichmentEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: BaseEnrichedDataEventsProcess

	/// <exclude/>
	public class BaseEnrichedDataEventsProcess : BaseEnrichedData_EnrichmentEventsProcess
	{

		public BaseEnrichedDataEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

