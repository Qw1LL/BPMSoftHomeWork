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

	#region Class: EnrchFoundContactSchema

	/// <exclude/>
	public class EnrchFoundContactSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public EnrchFoundContactSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public EnrchFoundContactSchema(EnrchFoundContactSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public EnrchFoundContactSchema(EnrchFoundContactSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("9b9b47be-9284-46df-836e-bb0320184549");
			RealUId = new Guid("9b9b47be-9284-46df-836e-bb0320184549");
			Name = "EnrchFoundContact";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("c1529436-dee9-4290-84f1-87386440a2b1");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("c2f4994b-cdbe-4d53-9a47-baa313f402cf")) == null) {
				Columns.Add(CreateEnrchTextEntityColumn());
			}
			if (Columns.FindByUId(new Guid("499b1023-5d31-4a4a-8c16-900491876d14")) == null) {
				Columns.Add(CreateContactColumn());
			}
			if (Columns.FindByUId(new Guid("6af4b879-ed24-4cda-9e78-213caca2f6c1")) == null) {
				Columns.Add(CreateIdentificationTypeColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateEnrchTextEntityColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("c2f4994b-cdbe-4d53-9a47-baa313f402cf"),
				Name = @"EnrchTextEntity",
				ReferenceSchemaUId = new Guid("e16b324c-1d23-46e5-878b-1591324f532f"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("9b9b47be-9284-46df-836e-bb0320184549"),
				ModifiedInSchemaUId = new Guid("9b9b47be-9284-46df-836e-bb0320184549"),
				CreatedInPackageId = new Guid("c1529436-dee9-4290-84f1-87386440a2b1")
			};
		}

		protected virtual EntitySchemaColumn CreateContactColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("499b1023-5d31-4a4a-8c16-900491876d14"),
				Name = @"Contact",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("9b9b47be-9284-46df-836e-bb0320184549"),
				ModifiedInSchemaUId = new Guid("9b9b47be-9284-46df-836e-bb0320184549"),
				CreatedInPackageId = new Guid("c1529436-dee9-4290-84f1-87386440a2b1")
			};
		}

		protected virtual EntitySchemaColumn CreateIdentificationTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("6af4b879-ed24-4cda-9e78-213caca2f6c1"),
				Name = @"IdentificationType",
				CreatedInSchemaUId = new Guid("9b9b47be-9284-46df-836e-bb0320184549"),
				ModifiedInSchemaUId = new Guid("9b9b47be-9284-46df-836e-bb0320184549"),
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
			return new EnrchFoundContact(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new EnrchFoundContact_EmailMiningEventsProcess(userConnection);
		}

		public override object Clone() {
			return new EnrchFoundContactSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new EnrchFoundContactSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("9b9b47be-9284-46df-836e-bb0320184549"));
		}

		#endregion

	}

	#endregion

	#region Class: EnrchFoundContact

	/// <summary>
	/// Identified contact.
	/// </summary>
	public class EnrchFoundContact : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public EnrchFoundContact(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "EnrchFoundContact";
		}

		public EnrchFoundContact(EnrchFoundContact source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid EnrchTextEntityId {
			get {
				return GetTypedColumnValue<Guid>("EnrchTextEntityId");
			}
			set {
				SetColumnValue("EnrchTextEntityId", value);
				_enrchTextEntity = null;
			}
		}

		/// <exclude/>
		public string EnrchTextEntityHash {
			get {
				return GetTypedColumnValue<string>("EnrchTextEntityHash");
			}
			set {
				SetColumnValue("EnrchTextEntityHash", value);
				if (_enrchTextEntity != null) {
					_enrchTextEntity.Hash = value;
				}
			}
		}

		private EnrchTextEntity _enrchTextEntity;
		/// <summary>
		/// Mined entity.
		/// </summary>
		public EnrchTextEntity EnrchTextEntity {
			get {
				return _enrchTextEntity ??
					(_enrchTextEntity = LookupColumnEntities.GetEntity("EnrchTextEntity") as EnrchTextEntity);
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
		/// Identification type.
		/// </summary>
		public string IdentificationType {
			get {
				return GetTypedColumnValue<string>("IdentificationType");
			}
			set {
				SetColumnValue("IdentificationType", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new EnrchFoundContact_EmailMiningEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("EnrchFoundContactDeleted", e);
			Validating += (s, e) => ThrowEvent("EnrchFoundContactValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new EnrchFoundContact(this);
		}

		#endregion

	}

	#endregion

	#region Class: EnrchFoundContact_EmailMiningEventsProcess

	/// <exclude/>
	public partial class EnrchFoundContact_EmailMiningEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : EnrchFoundContact
	{

		public EnrchFoundContact_EmailMiningEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "EnrchFoundContact_EmailMiningEventsProcess";
			SchemaUId = new Guid("9b9b47be-9284-46df-836e-bb0320184549");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("9b9b47be-9284-46df-836e-bb0320184549");
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

	#region Class: EnrchFoundContact_EmailMiningEventsProcess

	/// <exclude/>
	public class EnrchFoundContact_EmailMiningEventsProcess : EnrchFoundContact_EmailMiningEventsProcess<EnrchFoundContact>
	{

		public EnrchFoundContact_EmailMiningEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: EnrchFoundContact_EmailMiningEventsProcess

	public partial class EnrchFoundContact_EmailMiningEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: EnrchFoundContactEventsProcess

	/// <exclude/>
	public class EnrchFoundContactEventsProcess : EnrchFoundContact_EmailMiningEventsProcess
	{

		public EnrchFoundContactEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

