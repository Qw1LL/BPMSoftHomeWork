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

	#region Class: VisaStatusSchema

	/// <exclude/>
	public class VisaStatusSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public VisaStatusSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VisaStatusSchema(VisaStatusSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VisaStatusSchema(VisaStatusSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("66c8f5ac-57d2-4fe8-95a0-89a98e37f57f");
			RealUId = new Guid("66c8f5ac-57d2-4fe8-95a0-89a98e37f57f");
			Name = "VisaStatus";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("30bec7d4-5068-42a2-ab31-4d4a3fc4e524");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("777b5f83-cd2c-4aab-be5c-3e4310f1bf3c")) == null) {
				Columns.Add(CreateIsFinalColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("66c8f5ac-57d2-4fe8-95a0-89a98e37f57f");
			column.CreatedInPackageId = new Guid("30bec7d4-5068-42a2-ab31-4d4a3fc4e524");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("66c8f5ac-57d2-4fe8-95a0-89a98e37f57f");
			column.CreatedInPackageId = new Guid("30bec7d4-5068-42a2-ab31-4d4a3fc4e524");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("66c8f5ac-57d2-4fe8-95a0-89a98e37f57f");
			column.CreatedInPackageId = new Guid("30bec7d4-5068-42a2-ab31-4d4a3fc4e524");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("66c8f5ac-57d2-4fe8-95a0-89a98e37f57f");
			column.CreatedInPackageId = new Guid("30bec7d4-5068-42a2-ab31-4d4a3fc4e524");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("66c8f5ac-57d2-4fe8-95a0-89a98e37f57f");
			column.CreatedInPackageId = new Guid("30bec7d4-5068-42a2-ab31-4d4a3fc4e524");
			return column;
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("66c8f5ac-57d2-4fe8-95a0-89a98e37f57f");
			column.CreatedInPackageId = new Guid("30bec7d4-5068-42a2-ab31-4d4a3fc4e524");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("66c8f5ac-57d2-4fe8-95a0-89a98e37f57f");
			column.CreatedInPackageId = new Guid("30bec7d4-5068-42a2-ab31-4d4a3fc4e524");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("66c8f5ac-57d2-4fe8-95a0-89a98e37f57f");
			column.CreatedInPackageId = new Guid("30bec7d4-5068-42a2-ab31-4d4a3fc4e524");
			return column;
		}

		protected virtual EntitySchemaColumn CreateIsFinalColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("777b5f83-cd2c-4aab-be5c-3e4310f1bf3c"),
				Name = @"IsFinal",
				CreatedInSchemaUId = new Guid("66c8f5ac-57d2-4fe8-95a0-89a98e37f57f"),
				ModifiedInSchemaUId = new Guid("66c8f5ac-57d2-4fe8-95a0-89a98e37f57f"),
				CreatedInPackageId = new Guid("30bec7d4-5068-42a2-ab31-4d4a3fc4e524")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new VisaStatus(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VisaStatus_NUIEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VisaStatusSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VisaStatusSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("66c8f5ac-57d2-4fe8-95a0-89a98e37f57f"));
		}

		#endregion

	}

	#endregion

	#region Class: VisaStatus

	/// <summary>
	/// Approval status.
	/// </summary>
	public class VisaStatus : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public VisaStatus(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VisaStatus";
		}

		public VisaStatus(VisaStatus source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Status is final.
		/// </summary>
		public bool IsFinal {
			get {
				return GetTypedColumnValue<bool>("IsFinal");
			}
			set {
				SetColumnValue("IsFinal", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new VisaStatus_NUIEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("VisaStatusDeleted", e);
			Inserting += (s, e) => ThrowEvent("VisaStatusInserting", e);
			Validating += (s, e) => ThrowEvent("VisaStatusValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new VisaStatus(this);
		}

		#endregion

	}

	#endregion

	#region Class: VisaStatus_NUIEventsProcess

	/// <exclude/>
	public partial class VisaStatus_NUIEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : VisaStatus
	{

		public VisaStatus_NUIEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VisaStatus_NUIEventsProcess";
			SchemaUId = new Guid("66c8f5ac-57d2-4fe8-95a0-89a98e37f57f");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("66c8f5ac-57d2-4fe8-95a0-89a98e37f57f");
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

	#region Class: VisaStatus_NUIEventsProcess

	/// <exclude/>
	public class VisaStatus_NUIEventsProcess : VisaStatus_NUIEventsProcess<VisaStatus>
	{

		public VisaStatus_NUIEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VisaStatus_NUIEventsProcess

	public partial class VisaStatus_NUIEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: VisaStatusEventsProcess

	/// <exclude/>
	public class VisaStatusEventsProcess : VisaStatus_NUIEventsProcess
	{

		public VisaStatusEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

