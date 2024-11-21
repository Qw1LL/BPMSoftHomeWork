namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Configuration.RightsService;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.DcmProcess;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;
	using BPMSoft.Core.Process;
	using BPMSoft.Core.Process.Configuration;
	using BPMSoft.Mail;
	using BPMSoft.Messaging.Common;
	using BPMSoft.UI.WebControls.Controls;
	using BPMSoft.UI.WebControls.Utilities.Json.Converters;
	using DataContract = BPMSoft.Nui.ServiceModel.DataContract;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Data;
	using System.Drawing;
	using System.Globalization;
	using System.IO;
	using System.Linq;
	using System.Text;
	using System.Text.RegularExpressions;

	#region Class: VwVisaSchema

	/// <exclude/>
	public class VwVisaSchema : BPMSoft.Configuration.BaseVisaSchema
	{

		#region Constructors: Public

		public VwVisaSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwVisaSchema(VwVisaSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwVisaSchema(VwVisaSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("38d05501-e527-4220-b74d-68d71a2aa835");
			RealUId = new Guid("38d05501-e527-4220-b74d-68d71a2aa835");
			Name = "VwVisa";
			ParentSchemaUId = new Guid("5fa90d0d-64eb-4f52-8d3d-c51fa6443b66");
			ExtendParent = false;
			CreatedInPackageId = new Guid("f001c5cb-0040-4460-8f61-804897c60feb");
			IsDBView = true;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateTitleColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("a1efb5d2-50f1-440a-ad35-0ab5a8892a72")) == null) {
				Columns.Add(CreateVisaSchemaNameColumn());
			}
			if (Columns.FindByUId(new Guid("6835dd49-a180-4735-8b33-527842610bd2")) == null) {
				Columns.Add(CreateVisaObjectIdColumn());
			}
			if (Columns.FindByUId(new Guid("94fdf3b7-f403-42e2-8e07-f64175027223")) == null) {
				Columns.Add(CreateVisaSchemaTypeIdColumn());
			}
			if (Columns.FindByUId(new Guid("05e15d73-c1a8-4e0b-9164-91d78dd3e4d5")) == null) {
				Columns.Add(CreateVisaTypeNameColumn());
			}
			if (Columns.FindByUId(new Guid("5d865518-09a7-4e5e-8903-83f34255b02e")) == null) {
				Columns.Add(CreateVisaSchemaCaptionColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("38d05501-e527-4220-b74d-68d71a2aa835");
			column.CreatedInPackageId = new Guid("f001c5cb-0040-4460-8f61-804897c60feb");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("38d05501-e527-4220-b74d-68d71a2aa835");
			column.CreatedInPackageId = new Guid("f001c5cb-0040-4460-8f61-804897c60feb");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("38d05501-e527-4220-b74d-68d71a2aa835");
			column.CreatedInPackageId = new Guid("f001c5cb-0040-4460-8f61-804897c60feb");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("38d05501-e527-4220-b74d-68d71a2aa835");
			column.CreatedInPackageId = new Guid("f001c5cb-0040-4460-8f61-804897c60feb");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("38d05501-e527-4220-b74d-68d71a2aa835");
			column.CreatedInPackageId = new Guid("f001c5cb-0040-4460-8f61-804897c60feb");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("38d05501-e527-4220-b74d-68d71a2aa835");
			column.CreatedInPackageId = new Guid("f001c5cb-0040-4460-8f61-804897c60feb");
			return column;
		}

		protected override EntitySchemaColumn CreateObjectiveColumn() {
			EntitySchemaColumn column = base.CreateObjectiveColumn();
			column.ModifiedInSchemaUId = new Guid("38d05501-e527-4220-b74d-68d71a2aa835");
			column.CreatedInPackageId = new Guid("f001c5cb-0040-4460-8f61-804897c60feb");
			return column;
		}

		protected override EntitySchemaColumn CreateVisaOwnerColumn() {
			EntitySchemaColumn column = base.CreateVisaOwnerColumn();
			column.ModifiedInSchemaUId = new Guid("38d05501-e527-4220-b74d-68d71a2aa835");
			column.CreatedInPackageId = new Guid("f001c5cb-0040-4460-8f61-804897c60feb");
			return column;
		}

		protected override EntitySchemaColumn CreateIsAllowedToDelegateColumn() {
			EntitySchemaColumn column = base.CreateIsAllowedToDelegateColumn();
			column.ModifiedInSchemaUId = new Guid("38d05501-e527-4220-b74d-68d71a2aa835");
			column.CreatedInPackageId = new Guid("f001c5cb-0040-4460-8f61-804897c60feb");
			return column;
		}

		protected override EntitySchemaColumn CreateDelegatedFromColumn() {
			EntitySchemaColumn column = base.CreateDelegatedFromColumn();
			column.ModifiedInSchemaUId = new Guid("38d05501-e527-4220-b74d-68d71a2aa835");
			column.CreatedInPackageId = new Guid("f001c5cb-0040-4460-8f61-804897c60feb");
			return column;
		}

		protected override EntitySchemaColumn CreateStatusColumn() {
			EntitySchemaColumn column = base.CreateStatusColumn();
			column.ModifiedInSchemaUId = new Guid("38d05501-e527-4220-b74d-68d71a2aa835");
			column.CreatedInPackageId = new Guid("f001c5cb-0040-4460-8f61-804897c60feb");
			return column;
		}

		protected override EntitySchemaColumn CreateSetByColumn() {
			EntitySchemaColumn column = base.CreateSetByColumn();
			column.ModifiedInSchemaUId = new Guid("38d05501-e527-4220-b74d-68d71a2aa835");
			column.CreatedInPackageId = new Guid("f001c5cb-0040-4460-8f61-804897c60feb");
			return column;
		}

		protected override EntitySchemaColumn CreateSetDateColumn() {
			EntitySchemaColumn column = base.CreateSetDateColumn();
			column.ModifiedInSchemaUId = new Guid("38d05501-e527-4220-b74d-68d71a2aa835");
			column.CreatedInPackageId = new Guid("f001c5cb-0040-4460-8f61-804897c60feb");
			return column;
		}

		protected override EntitySchemaColumn CreateIsCanceledColumn() {
			EntitySchemaColumn column = base.CreateIsCanceledColumn();
			column.ModifiedInSchemaUId = new Guid("38d05501-e527-4220-b74d-68d71a2aa835");
			column.CreatedInPackageId = new Guid("f001c5cb-0040-4460-8f61-804897c60feb");
			return column;
		}

		protected override EntitySchemaColumn CreateCommentColumn() {
			EntitySchemaColumn column = base.CreateCommentColumn();
			column.ModifiedInSchemaUId = new Guid("38d05501-e527-4220-b74d-68d71a2aa835");
			column.CreatedInPackageId = new Guid("f001c5cb-0040-4460-8f61-804897c60feb");
			return column;
		}

		protected virtual EntitySchemaColumn CreateTitleColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("10e1449d-8e66-412c-8fc2-eeaae319bc17"),
				Name = @"Title",
				CreatedInSchemaUId = new Guid("38d05501-e527-4220-b74d-68d71a2aa835"),
				ModifiedInSchemaUId = new Guid("38d05501-e527-4220-b74d-68d71a2aa835"),
				CreatedInPackageId = new Guid("f001c5cb-0040-4460-8f61-804897c60feb")
			};
		}

		protected virtual EntitySchemaColumn CreateVisaSchemaNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("a1efb5d2-50f1-440a-ad35-0ab5a8892a72"),
				Name = @"VisaSchemaName",
				CreatedInSchemaUId = new Guid("38d05501-e527-4220-b74d-68d71a2aa835"),
				ModifiedInSchemaUId = new Guid("38d05501-e527-4220-b74d-68d71a2aa835"),
				CreatedInPackageId = new Guid("30bec7d4-5068-42a2-ab31-4d4a3fc4e524")
			};
		}

		protected virtual EntitySchemaColumn CreateVisaObjectIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("6835dd49-a180-4735-8b33-527842610bd2"),
				Name = @"VisaObjectId",
				CreatedInSchemaUId = new Guid("38d05501-e527-4220-b74d-68d71a2aa835"),
				ModifiedInSchemaUId = new Guid("38d05501-e527-4220-b74d-68d71a2aa835"),
				CreatedInPackageId = new Guid("5fe850f8-633f-4f49-b171-3760bb47e9da")
			};
		}

		protected virtual EntitySchemaColumn CreateVisaSchemaTypeIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("94fdf3b7-f403-42e2-8e07-f64175027223"),
				Name = @"VisaSchemaTypeId",
				CreatedInSchemaUId = new Guid("38d05501-e527-4220-b74d-68d71a2aa835"),
				ModifiedInSchemaUId = new Guid("38d05501-e527-4220-b74d-68d71a2aa835"),
				CreatedInPackageId = new Guid("5fe850f8-633f-4f49-b171-3760bb47e9da")
			};
		}

		protected virtual EntitySchemaColumn CreateVisaTypeNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("05e15d73-c1a8-4e0b-9164-91d78dd3e4d5"),
				Name = @"VisaTypeName",
				CreatedInSchemaUId = new Guid("38d05501-e527-4220-b74d-68d71a2aa835"),
				ModifiedInSchemaUId = new Guid("38d05501-e527-4220-b74d-68d71a2aa835"),
				CreatedInPackageId = new Guid("85a972d5-aaea-43a7-af9b-d75884bd785b")
			};
		}

		protected virtual EntitySchemaColumn CreateVisaSchemaCaptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("5d865518-09a7-4e5e-8903-83f34255b02e"),
				Name = @"VisaSchemaCaption",
				CreatedInSchemaUId = new Guid("38d05501-e527-4220-b74d-68d71a2aa835"),
				ModifiedInSchemaUId = new Guid("38d05501-e527-4220-b74d-68d71a2aa835"),
				CreatedInPackageId = new Guid("85a972d5-aaea-43a7-af9b-d75884bd785b")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new VwVisa(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwVisa_NUIEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwVisaSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwVisaSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("38d05501-e527-4220-b74d-68d71a2aa835"));
		}

		#endregion

	}

	#endregion

	#region Class: VwVisa

	/// <summary>
	/// Approval (view).
	/// </summary>
	public class VwVisa : BPMSoft.Configuration.BaseVisa
	{

		#region Constructors: Public

		public VwVisa(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwVisa";
		}

		public VwVisa(VwVisa source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Title.
		/// </summary>
		public string Title {
			get {
				return GetTypedColumnValue<string>("Title");
			}
			set {
				SetColumnValue("Title", value);
			}
		}

		/// <summary>
		/// Schema name.
		/// </summary>
		public string VisaSchemaName {
			get {
				return GetTypedColumnValue<string>("VisaSchemaName");
			}
			set {
				SetColumnValue("VisaSchemaName", value);
			}
		}

		/// <summary>
		/// Approval object Id.
		/// </summary>
		public Guid VisaObjectId {
			get {
				return GetTypedColumnValue<Guid>("VisaObjectId");
			}
			set {
				SetColumnValue("VisaObjectId", value);
			}
		}

		/// <summary>
		/// Approval object type Id.
		/// </summary>
		public Guid VisaSchemaTypeId {
			get {
				return GetTypedColumnValue<Guid>("VisaSchemaTypeId");
			}
			set {
				SetColumnValue("VisaSchemaTypeId", value);
			}
		}

		/// <summary>
		/// Approval object type name.
		/// </summary>
		public string VisaTypeName {
			get {
				return GetTypedColumnValue<string>("VisaTypeName");
			}
			set {
				SetColumnValue("VisaTypeName", value);
			}
		}

		/// <summary>
		/// Schema name.
		/// </summary>
		public string VisaSchemaCaption {
			get {
				return GetTypedColumnValue<string>("VisaSchemaCaption");
			}
			set {
				SetColumnValue("VisaSchemaCaption", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new VwVisa_NUIEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Inserted += (s, e) => ThrowEvent("VwVisaInserted", e);
			Inserting += (s, e) => ThrowEvent("VwVisaInserting", e);
			Saved += (s, e) => ThrowEvent("VwVisaSaved", e);
			Saving += (s, e) => ThrowEvent("VwVisaSaving", e);
			Validating += (s, e) => ThrowEvent("VwVisaValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new VwVisa(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwVisa_NUIEventsProcess

	/// <exclude/>
	public partial class VwVisa_NUIEventsProcess<TEntity> : BPMSoft.Configuration.BaseVisa_NUIEventsProcess<TEntity> where TEntity : VwVisa
	{

		public VwVisa_NUIEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwVisa_NUIEventsProcess";
			SchemaUId = new Guid("38d05501-e527-4220-b74d-68d71a2aa835");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("38d05501-e527-4220-b74d-68d71a2aa835");
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

	#region Class: VwVisa_NUIEventsProcess

	/// <exclude/>
	public class VwVisa_NUIEventsProcess : VwVisa_NUIEventsProcess<VwVisa>
	{

		public VwVisa_NUIEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VwVisa_NUIEventsProcess

	public partial class VwVisa_NUIEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: VwVisaEventsProcess

	/// <exclude/>
	public class VwVisaEventsProcess : VwVisa_NUIEventsProcess
	{

		public VwVisaEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

