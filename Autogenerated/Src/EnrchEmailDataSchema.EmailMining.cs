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

	#region Class: EnrchEmailDataSchema

	/// <exclude/>
	public class EnrchEmailDataSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public EnrchEmailDataSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public EnrchEmailDataSchema(EnrchEmailDataSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public EnrchEmailDataSchema(EnrchEmailDataSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("26d5f6ad-8525-4ceb-b3e5-af8fdf2964f6");
			RealUId = new Guid("26d5f6ad-8525-4ceb-b3e5-af8fdf2964f6");
			Name = "EnrchEmailData";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("c1529436-dee9-4290-84f1-87386440a2b1");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateHashColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("d3e7b106-93c1-4839-a65d-08fc2214d124")) == null) {
				Columns.Add(CreateJsonDataColumn());
			}
			if (Columns.FindByUId(new Guid("5d8d8d2f-75f5-4946-81f7-ce2ffa5d5627")) == null) {
				Columns.Add(CreateStatusColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateJsonDataColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("d3e7b106-93c1-4839-a65d-08fc2214d124"),
				Name = @"JsonData",
				CreatedInSchemaUId = new Guid("26d5f6ad-8525-4ceb-b3e5-af8fdf2964f6"),
				ModifiedInSchemaUId = new Guid("26d5f6ad-8525-4ceb-b3e5-af8fdf2964f6"),
				CreatedInPackageId = new Guid("c1529436-dee9-4290-84f1-87386440a2b1")
			};
		}

		protected virtual EntitySchemaColumn CreateHashColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("34387eb9-749e-42f1-bcff-f9514f3af668"),
				Name = @"Hash",
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("26d5f6ad-8525-4ceb-b3e5-af8fdf2964f6"),
				ModifiedInSchemaUId = new Guid("26d5f6ad-8525-4ceb-b3e5-af8fdf2964f6"),
				CreatedInPackageId = new Guid("c1529436-dee9-4290-84f1-87386440a2b1")
			};
		}

		protected virtual EntitySchemaColumn CreateStatusColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("5d8d8d2f-75f5-4946-81f7-ce2ffa5d5627"),
				Name = @"Status",
				CreatedInSchemaUId = new Guid("26d5f6ad-8525-4ceb-b3e5-af8fdf2964f6"),
				ModifiedInSchemaUId = new Guid("26d5f6ad-8525-4ceb-b3e5-af8fdf2964f6"),
				CreatedInPackageId = new Guid("bae6174e-6d8e-4782-b180-300a95031ded"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"Mined"
				}
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new EnrchEmailData(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new EnrchEmailData_EmailMiningEventsProcess(userConnection);
		}

		public override object Clone() {
			return new EnrchEmailDataSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new EnrchEmailDataSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("26d5f6ad-8525-4ceb-b3e5-af8fdf2964f6"));
		}

		#endregion

	}

	#endregion

	#region Class: EnrchEmailData

	/// <summary>
	/// Found in the e-mail data.
	/// </summary>
	public class EnrchEmailData : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public EnrchEmailData(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "EnrchEmailData";
		}

		public EnrchEmailData(EnrchEmailData source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Enrichment service response.
		/// </summary>
		public string JsonData {
			get {
				return GetTypedColumnValue<string>("JsonData");
			}
			set {
				SetColumnValue("JsonData", value);
			}
		}

		/// <summary>
		/// Hash code of mined data.
		/// </summary>
		public string Hash {
			get {
				return GetTypedColumnValue<string>("Hash");
			}
			set {
				SetColumnValue("Hash", value);
			}
		}

		/// <summary>
		/// Processing status.
		/// </summary>
		public string Status {
			get {
				return GetTypedColumnValue<string>("Status");
			}
			set {
				SetColumnValue("Status", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new EnrchEmailData_EmailMiningEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("EnrchEmailDataDeleted", e);
			Validating += (s, e) => ThrowEvent("EnrchEmailDataValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new EnrchEmailData(this);
		}

		#endregion

	}

	#endregion

	#region Class: EnrchEmailData_EmailMiningEventsProcess

	/// <exclude/>
	public partial class EnrchEmailData_EmailMiningEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : EnrchEmailData
	{

		public EnrchEmailData_EmailMiningEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "EnrchEmailData_EmailMiningEventsProcess";
			SchemaUId = new Guid("26d5f6ad-8525-4ceb-b3e5-af8fdf2964f6");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("26d5f6ad-8525-4ceb-b3e5-af8fdf2964f6");
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

	#region Class: EnrchEmailData_EmailMiningEventsProcess

	/// <exclude/>
	public class EnrchEmailData_EmailMiningEventsProcess : EnrchEmailData_EmailMiningEventsProcess<EnrchEmailData>
	{

		public EnrchEmailData_EmailMiningEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: EnrchEmailData_EmailMiningEventsProcess

	public partial class EnrchEmailData_EmailMiningEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: EnrchEmailDataEventsProcess

	/// <exclude/>
	public class EnrchEmailDataEventsProcess : EnrchEmailData_EmailMiningEventsProcess
	{

		public EnrchEmailDataEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

