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

	#region Class: EnrchProcessedDataSchema

	/// <exclude/>
	public class EnrchProcessedDataSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public EnrchProcessedDataSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public EnrchProcessedDataSchema(EnrchProcessedDataSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public EnrchProcessedDataSchema(EnrchProcessedDataSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("290d6b2b-0c1d-44cc-9738-9d943f61386c");
			RealUId = new Guid("290d6b2b-0c1d-44cc-9738-9d943f61386c");
			Name = "EnrchProcessedData";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("c9ff5cbb-cb0e-4041-b483-395260757ab0");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("a428382c-67ec-4c8c-8403-c8ac441c0417")) == null) {
				Columns.Add(CreateStatusColumn());
			}
			if (Columns.FindByUId(new Guid("30e1053d-d579-4c8c-99e0-7e550c854337")) == null) {
				Columns.Add(CreateContactColumn());
			}
			if (Columns.FindByUId(new Guid("4dc09aef-6f2b-4b4c-b7cf-72323b40bac7")) == null) {
				Columns.Add(CreateTextEntityHashColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateStatusColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("a428382c-67ec-4c8c-8403-c8ac441c0417"),
				Name = @"Status",
				CreatedInSchemaUId = new Guid("290d6b2b-0c1d-44cc-9738-9d943f61386c"),
				ModifiedInSchemaUId = new Guid("290d6b2b-0c1d-44cc-9738-9d943f61386c"),
				CreatedInPackageId = new Guid("c9ff5cbb-cb0e-4041-b483-395260757ab0")
			};
		}

		protected virtual EntitySchemaColumn CreateContactColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("30e1053d-d579-4c8c-99e0-7e550c854337"),
				Name = @"Contact",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("290d6b2b-0c1d-44cc-9738-9d943f61386c"),
				ModifiedInSchemaUId = new Guid("290d6b2b-0c1d-44cc-9738-9d943f61386c"),
				CreatedInPackageId = new Guid("c9ff5cbb-cb0e-4041-b483-395260757ab0")
			};
		}

		protected virtual EntitySchemaColumn CreateTextEntityHashColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("4dc09aef-6f2b-4b4c-b7cf-72323b40bac7"),
				Name = @"TextEntityHash",
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("290d6b2b-0c1d-44cc-9738-9d943f61386c"),
				ModifiedInSchemaUId = new Guid("290d6b2b-0c1d-44cc-9738-9d943f61386c"),
				CreatedInPackageId = new Guid("c9ff5cbb-cb0e-4041-b483-395260757ab0")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new EnrchProcessedData(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new EnrchProcessedData_EmailMiningEventsProcess(userConnection);
		}

		public override object Clone() {
			return new EnrchProcessedDataSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new EnrchProcessedDataSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("290d6b2b-0c1d-44cc-9738-9d943f61386c"));
		}

		#endregion

	}

	#endregion

	#region Class: EnrchProcessedData

	/// <summary>
	/// EnrchProcessedData.
	/// </summary>
	public class EnrchProcessedData : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public EnrchProcessedData(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "EnrchProcessedData";
		}

		public EnrchProcessedData(EnrchProcessedData source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Status.
		/// </summary>
		public string Status {
			get {
				return GetTypedColumnValue<string>("Status");
			}
			set {
				SetColumnValue("Status", value);
			}
		}

		/// <exclude/>
		public Guid ContactId {
			get {
				return GetTypedColumnValue<Guid>("ContactId");
			}
			set {
				SetColumnValue("ContactId", value);
				_contact = null;
			}
		}

		/// <exclude/>
		public string ContactName {
			get {
				return GetTypedColumnValue<string>("ContactName");
			}
			set {
				SetColumnValue("ContactName", value);
				if (_contact != null) {
					_contact.Name = value;
				}
			}
		}

		private Contact _contact;
		/// <summary>
		/// Contact.
		/// </summary>
		public Contact Contact {
			get {
				return _contact ??
					(_contact = LookupColumnEntities.GetEntity("Contact") as Contact);
			}
		}

		/// <summary>
		/// Hash code of mined data.
		/// </summary>
		public string TextEntityHash {
			get {
				return GetTypedColumnValue<string>("TextEntityHash");
			}
			set {
				SetColumnValue("TextEntityHash", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new EnrchProcessedData_EmailMiningEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("EnrchProcessedDataDeleted", e);
			Validating += (s, e) => ThrowEvent("EnrchProcessedDataValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new EnrchProcessedData(this);
		}

		#endregion

	}

	#endregion

	#region Class: EnrchProcessedData_EmailMiningEventsProcess

	/// <exclude/>
	public partial class EnrchProcessedData_EmailMiningEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : EnrchProcessedData
	{

		public EnrchProcessedData_EmailMiningEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "EnrchProcessedData_EmailMiningEventsProcess";
			SchemaUId = new Guid("290d6b2b-0c1d-44cc-9738-9d943f61386c");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("290d6b2b-0c1d-44cc-9738-9d943f61386c");
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

	#region Class: EnrchProcessedData_EmailMiningEventsProcess

	/// <exclude/>
	public class EnrchProcessedData_EmailMiningEventsProcess : EnrchProcessedData_EmailMiningEventsProcess<EnrchProcessedData>
	{

		public EnrchProcessedData_EmailMiningEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: EnrchProcessedData_EmailMiningEventsProcess

	public partial class EnrchProcessedData_EmailMiningEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: EnrchProcessedDataEventsProcess

	/// <exclude/>
	public class EnrchProcessedDataEventsProcess : EnrchProcessedData_EmailMiningEventsProcess
	{

		public EnrchProcessedDataEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

