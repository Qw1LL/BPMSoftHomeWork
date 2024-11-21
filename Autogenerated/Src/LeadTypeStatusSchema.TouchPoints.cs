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

	#region Class: LeadTypeStatus_TouchPoints_BPMSoftSchema

	/// <exclude/>
	public class LeadTypeStatus_TouchPoints_BPMSoftSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public LeadTypeStatus_TouchPoints_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public LeadTypeStatus_TouchPoints_BPMSoftSchema(LeadTypeStatus_TouchPoints_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public LeadTypeStatus_TouchPoints_BPMSoftSchema(LeadTypeStatus_TouchPoints_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("2df1cc86-627c-4d7c-ad1f-0de8eebab40c");
			RealUId = new Guid("2df1cc86-627c-4d7c-ad1f-0de8eebab40c");
			Name = "LeadTypeStatus_TouchPoints_BPMSoft";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("65fa192b-1ddc-4120-9cd7-c89cc2cad577");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryOrderColumn() {
			base.InitializePrimaryOrderColumn();
			PrimaryOrderColumn = CreateValueColumn();
			if (Columns.FindByUId(PrimaryOrderColumn.UId) == null) {
				Columns.Add(PrimaryOrderColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("2df1cc86-627c-4d7c-ad1f-0de8eebab40c");
			column.CreatedInPackageId = new Guid("65fa192b-1ddc-4120-9cd7-c89cc2cad577");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("2df1cc86-627c-4d7c-ad1f-0de8eebab40c");
			column.CreatedInPackageId = new Guid("65fa192b-1ddc-4120-9cd7-c89cc2cad577");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("2df1cc86-627c-4d7c-ad1f-0de8eebab40c");
			column.CreatedInPackageId = new Guid("65fa192b-1ddc-4120-9cd7-c89cc2cad577");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("2df1cc86-627c-4d7c-ad1f-0de8eebab40c");
			column.CreatedInPackageId = new Guid("65fa192b-1ddc-4120-9cd7-c89cc2cad577");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("2df1cc86-627c-4d7c-ad1f-0de8eebab40c");
			column.CreatedInPackageId = new Guid("65fa192b-1ddc-4120-9cd7-c89cc2cad577");
			return column;
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("2df1cc86-627c-4d7c-ad1f-0de8eebab40c");
			column.CreatedInPackageId = new Guid("65fa192b-1ddc-4120-9cd7-c89cc2cad577");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("2df1cc86-627c-4d7c-ad1f-0de8eebab40c");
			column.CreatedInPackageId = new Guid("65fa192b-1ddc-4120-9cd7-c89cc2cad577");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("2df1cc86-627c-4d7c-ad1f-0de8eebab40c");
			column.CreatedInPackageId = new Guid("65fa192b-1ddc-4120-9cd7-c89cc2cad577");
			return column;
		}

		protected virtual EntitySchemaColumn CreateValueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("126a038f-417c-480b-a5c9-cc980f846fe3"),
				Name = @"Value",
				CreatedInSchemaUId = new Guid("2df1cc86-627c-4d7c-ad1f-0de8eebab40c"),
				ModifiedInSchemaUId = new Guid("2df1cc86-627c-4d7c-ad1f-0de8eebab40c"),
				CreatedInPackageId = new Guid("4261e5b6-ac7c-4768-a57f-7066cca089f2")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new LeadTypeStatus_TouchPoints_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new LeadTypeStatus_TouchPointsEventsProcess(userConnection);
		}

		public override object Clone() {
			return new LeadTypeStatus_TouchPoints_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new LeadTypeStatus_TouchPoints_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("2df1cc86-627c-4d7c-ad1f-0de8eebab40c"));
		}

		#endregion

	}

	#endregion

	#region Class: LeadTypeStatus_TouchPoints_BPMSoft

	/// <summary>
	/// Need maturity.
	/// </summary>
	public class LeadTypeStatus_TouchPoints_BPMSoft : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public LeadTypeStatus_TouchPoints_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "LeadTypeStatus_TouchPoints_BPMSoft";
		}

		public LeadTypeStatus_TouchPoints_BPMSoft(LeadTypeStatus_TouchPoints_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Value.
		/// </summary>
		public int Value {
			get {
				return GetTypedColumnValue<int>("Value");
			}
			set {
				SetColumnValue("Value", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new LeadTypeStatus_TouchPointsEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("LeadTypeStatus_TouchPoints_BPMSoftDeleted", e);
			Inserting += (s, e) => ThrowEvent("LeadTypeStatus_TouchPoints_BPMSoftInserting", e);
			Validating += (s, e) => ThrowEvent("LeadTypeStatus_TouchPoints_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new LeadTypeStatus_TouchPoints_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: LeadTypeStatus_TouchPointsEventsProcess

	/// <exclude/>
	public partial class LeadTypeStatus_TouchPointsEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : LeadTypeStatus_TouchPoints_BPMSoft
	{

		public LeadTypeStatus_TouchPointsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "LeadTypeStatus_TouchPointsEventsProcess";
			SchemaUId = new Guid("2df1cc86-627c-4d7c-ad1f-0de8eebab40c");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("2df1cc86-627c-4d7c-ad1f-0de8eebab40c");
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

	#region Class: LeadTypeStatus_TouchPointsEventsProcess

	/// <exclude/>
	public class LeadTypeStatus_TouchPointsEventsProcess : LeadTypeStatus_TouchPointsEventsProcess<LeadTypeStatus_TouchPoints_BPMSoft>
	{

		public LeadTypeStatus_TouchPointsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: LeadTypeStatus_TouchPointsEventsProcess

	public partial class LeadTypeStatus_TouchPointsEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

