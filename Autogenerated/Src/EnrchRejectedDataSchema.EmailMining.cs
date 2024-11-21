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

	#region Class: EnrchRejectedDataSchema

	/// <exclude/>
	public class EnrchRejectedDataSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public EnrchRejectedDataSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public EnrchRejectedDataSchema(EnrchRejectedDataSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public EnrchRejectedDataSchema(EnrchRejectedDataSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("b08aacf4-3e25-4d7e-a713-9a5add606381");
			RealUId = new Guid("b08aacf4-3e25-4d7e-a713-9a5add606381");
			Name = "EnrchRejectedData";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("c1529436-dee9-4290-84f1-87386440a2b1");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("35367ceb-b52b-4af3-9498-59534e4eed97")) == null) {
				Columns.Add(CreateContactColumn());
			}
			if (Columns.FindByUId(new Guid("aab2cbaf-66df-4bdf-b3cd-c237f222fbc7")) == null) {
				Columns.Add(CreateTextEntityHashColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateContactColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("35367ceb-b52b-4af3-9498-59534e4eed97"),
				Name = @"Contact",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("b08aacf4-3e25-4d7e-a713-9a5add606381"),
				ModifiedInSchemaUId = new Guid("b08aacf4-3e25-4d7e-a713-9a5add606381"),
				CreatedInPackageId = new Guid("c1529436-dee9-4290-84f1-87386440a2b1")
			};
		}

		protected virtual EntitySchemaColumn CreateTextEntityHashColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("aab2cbaf-66df-4bdf-b3cd-c237f222fbc7"),
				Name = @"TextEntityHash",
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("b08aacf4-3e25-4d7e-a713-9a5add606381"),
				ModifiedInSchemaUId = new Guid("b08aacf4-3e25-4d7e-a713-9a5add606381"),
				CreatedInPackageId = new Guid("c1529436-dee9-4290-84f1-87386440a2b1")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new EnrchRejectedData(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new EnrchRejectedData_EmailMiningEventsProcess(userConnection);
		}

		public override object Clone() {
			return new EnrchRejectedDataSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new EnrchRejectedDataSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("b08aacf4-3e25-4d7e-a713-9a5add606381"));
		}

		#endregion

	}

	#endregion

	#region Class: EnrchRejectedData

	/// <summary>
	/// Rejected data.
	/// </summary>
	public class EnrchRejectedData : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public EnrchRejectedData(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "EnrchRejectedData";
		}

		public EnrchRejectedData(EnrchRejectedData source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

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
			var process = new EnrchRejectedData_EmailMiningEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("EnrchRejectedDataDeleted", e);
			Validating += (s, e) => ThrowEvent("EnrchRejectedDataValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new EnrchRejectedData(this);
		}

		#endregion

	}

	#endregion

	#region Class: EnrchRejectedData_EmailMiningEventsProcess

	/// <exclude/>
	public partial class EnrchRejectedData_EmailMiningEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : EnrchRejectedData
	{

		public EnrchRejectedData_EmailMiningEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "EnrchRejectedData_EmailMiningEventsProcess";
			SchemaUId = new Guid("b08aacf4-3e25-4d7e-a713-9a5add606381");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("b08aacf4-3e25-4d7e-a713-9a5add606381");
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

	#region Class: EnrchRejectedData_EmailMiningEventsProcess

	/// <exclude/>
	public class EnrchRejectedData_EmailMiningEventsProcess : EnrchRejectedData_EmailMiningEventsProcess<EnrchRejectedData>
	{

		public EnrchRejectedData_EmailMiningEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: EnrchRejectedData_EmailMiningEventsProcess

	public partial class EnrchRejectedData_EmailMiningEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: EnrchRejectedDataEventsProcess

	/// <exclude/>
	public class EnrchRejectedDataEventsProcess : EnrchRejectedData_EmailMiningEventsProcess
	{

		public EnrchRejectedDataEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

