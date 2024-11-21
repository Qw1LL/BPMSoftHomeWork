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

	#region Class: LeadAddressSchema

	/// <exclude/>
	public class LeadAddressSchema : BPMSoft.Configuration.BaseAddressSchema
	{

		#region Constructors: Public

		public LeadAddressSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public LeadAddressSchema(LeadAddressSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public LeadAddressSchema(LeadAddressSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("ea2ad15f-82cc-418c-a5dd-0c554e6ec419");
			RealUId = new Guid("ea2ad15f-82cc-418c-a5dd-0c554e6ec419");
			Name = "LeadAddress";
			ParentSchemaUId = new Guid("400e8687-9616-480d-9d81-61de0235cc86");
			ExtendParent = false;
			CreatedInPackageId = new Guid("b85710ff-ea7b-435e-8c26-df40c9e1a6fd");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("a0361711-6e10-4202-b9d8-1a4d54d702ec")) == null) {
				Columns.Add(CreateLeadColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("ea2ad15f-82cc-418c-a5dd-0c554e6ec419");
			column.CreatedInPackageId = new Guid("b85710ff-ea7b-435e-8c26-df40c9e1a6fd");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("ea2ad15f-82cc-418c-a5dd-0c554e6ec419");
			column.CreatedInPackageId = new Guid("b85710ff-ea7b-435e-8c26-df40c9e1a6fd");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("ea2ad15f-82cc-418c-a5dd-0c554e6ec419");
			column.CreatedInPackageId = new Guid("b85710ff-ea7b-435e-8c26-df40c9e1a6fd");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("ea2ad15f-82cc-418c-a5dd-0c554e6ec419");
			column.CreatedInPackageId = new Guid("b85710ff-ea7b-435e-8c26-df40c9e1a6fd");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("ea2ad15f-82cc-418c-a5dd-0c554e6ec419");
			column.CreatedInPackageId = new Guid("b85710ff-ea7b-435e-8c26-df40c9e1a6fd");
			return column;
		}

		protected override EntitySchemaColumn CreateAddressTypeColumn() {
			EntitySchemaColumn column = base.CreateAddressTypeColumn();
			column.ModifiedInSchemaUId = new Guid("ea2ad15f-82cc-418c-a5dd-0c554e6ec419");
			column.CreatedInPackageId = new Guid("b85710ff-ea7b-435e-8c26-df40c9e1a6fd");
			return column;
		}

		protected override EntitySchemaColumn CreateCountryColumn() {
			EntitySchemaColumn column = base.CreateCountryColumn();
			column.ModifiedInSchemaUId = new Guid("ea2ad15f-82cc-418c-a5dd-0c554e6ec419");
			column.CreatedInPackageId = new Guid("b85710ff-ea7b-435e-8c26-df40c9e1a6fd");
			return column;
		}

		protected override EntitySchemaColumn CreateRegionColumn() {
			EntitySchemaColumn column = base.CreateRegionColumn();
			column.ModifiedInSchemaUId = new Guid("ea2ad15f-82cc-418c-a5dd-0c554e6ec419");
			column.CreatedInPackageId = new Guid("b85710ff-ea7b-435e-8c26-df40c9e1a6fd");
			return column;
		}

		protected override EntitySchemaColumn CreateCityColumn() {
			EntitySchemaColumn column = base.CreateCityColumn();
			column.ModifiedInSchemaUId = new Guid("ea2ad15f-82cc-418c-a5dd-0c554e6ec419");
			column.CreatedInPackageId = new Guid("b85710ff-ea7b-435e-8c26-df40c9e1a6fd");
			return column;
		}

		protected override EntitySchemaColumn CreateAddressColumn() {
			EntitySchemaColumn column = base.CreateAddressColumn();
			column.ModifiedInSchemaUId = new Guid("ea2ad15f-82cc-418c-a5dd-0c554e6ec419");
			column.CreatedInPackageId = new Guid("b85710ff-ea7b-435e-8c26-df40c9e1a6fd");
			return column;
		}

		protected override EntitySchemaColumn CreateZipColumn() {
			EntitySchemaColumn column = base.CreateZipColumn();
			column.ModifiedInSchemaUId = new Guid("ea2ad15f-82cc-418c-a5dd-0c554e6ec419");
			column.CreatedInPackageId = new Guid("b85710ff-ea7b-435e-8c26-df40c9e1a6fd");
			return column;
		}

		protected override EntitySchemaColumn CreatePrimaryColumn() {
			EntitySchemaColumn column = base.CreatePrimaryColumn();
			column.ModifiedInSchemaUId = new Guid("ea2ad15f-82cc-418c-a5dd-0c554e6ec419");
			column.CreatedInPackageId = new Guid("b85710ff-ea7b-435e-8c26-df40c9e1a6fd");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("ea2ad15f-82cc-418c-a5dd-0c554e6ec419");
			column.CreatedInPackageId = new Guid("b85710ff-ea7b-435e-8c26-df40c9e1a6fd");
			return column;
		}

		protected virtual EntitySchemaColumn CreateLeadColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("a0361711-6e10-4202-b9d8-1a4d54d702ec"),
				Name = @"Lead",
				ReferenceSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("ea2ad15f-82cc-418c-a5dd-0c554e6ec419"),
				ModifiedInSchemaUId = new Guid("ea2ad15f-82cc-418c-a5dd-0c554e6ec419"),
				CreatedInPackageId = new Guid("b85710ff-ea7b-435e-8c26-df40c9e1a6fd")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new LeadAddress(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new LeadAddress_LeadEventsProcess(userConnection);
		}

		public override object Clone() {
			return new LeadAddressSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new LeadAddressSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ea2ad15f-82cc-418c-a5dd-0c554e6ec419"));
		}

		#endregion

	}

	#endregion

	#region Class: LeadAddress

	/// <summary>
	/// Адрес лида.
	/// </summary>
	public class LeadAddress : BPMSoft.Configuration.BaseAddress
	{

		#region Constructors: Public

		public LeadAddress(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "LeadAddress";
		}

		public LeadAddress(LeadAddress source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid LeadId {
			get {
				return GetTypedColumnValue<Guid>("LeadId");
			}
			set {
				SetColumnValue("LeadId", value);
				_lead = null;
			}
		}

		/// <exclude/>
		public string LeadLeadName {
			get {
				return GetTypedColumnValue<string>("LeadLeadName");
			}
			set {
				SetColumnValue("LeadLeadName", value);
				if (_lead != null) {
					_lead.LeadName = value;
				}
			}
		}

		private Lead _lead;
		/// <summary>
		/// Лид.
		/// </summary>
		public Lead Lead {
			get {
				return _lead ??
					(_lead = LookupColumnEntities.GetEntity("Lead") as Lead);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new LeadAddress_LeadEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("LeadAddressDeleted", e);
			Inserting += (s, e) => ThrowEvent("LeadAddressInserting", e);
			Validating += (s, e) => ThrowEvent("LeadAddressValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new LeadAddress(this);
		}

		#endregion

	}

	#endregion

	#region Class: LeadAddress_LeadEventsProcess

	/// <exclude/>
	public partial class LeadAddress_LeadEventsProcess<TEntity> : BPMSoft.Configuration.BaseAddress_BaseEventsProcess<TEntity> where TEntity : LeadAddress
	{

		public LeadAddress_LeadEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "LeadAddress_LeadEventsProcess";
			SchemaUId = new Guid("ea2ad15f-82cc-418c-a5dd-0c554e6ec419");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("ea2ad15f-82cc-418c-a5dd-0c554e6ec419");
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

	#region Class: LeadAddress_LeadEventsProcess

	/// <exclude/>
	public class LeadAddress_LeadEventsProcess : LeadAddress_LeadEventsProcess<LeadAddress>
	{

		public LeadAddress_LeadEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: LeadAddress_LeadEventsProcess

	public partial class LeadAddress_LeadEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: LeadAddressEventsProcess

	/// <exclude/>
	public class LeadAddressEventsProcess : LeadAddress_LeadEventsProcess
	{

		public LeadAddressEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

