﻿namespace BPMSoft.Configuration
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

	#region Class: Lead_LeadManagement_BPMSoftSchema

	/// <exclude/>
	public class Lead_LeadManagement_BPMSoftSchema : BPMSoft.Configuration.Lead_CoreLead_BPMSoftSchema
	{

		#region Constructors: Public

		public Lead_LeadManagement_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public Lead_LeadManagement_BPMSoftSchema(Lead_LeadManagement_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public Lead_LeadManagement_BPMSoftSchema(Lead_LeadManagement_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateIDX_LeadNameIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = false
			};
			index.UId = new Guid("bf3f62f3-5d38-4031-a648-58b036f8f19d");
			index.Name = "IDX_LeadName";
			index.CreatedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec");
			index.ModifiedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec");
			index.CreatedInPackageId = new Guid("b424f2c1-869b-44e8-aaf1-c9a818421e06");
			EntitySchemaIndexColumn leadNameIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("2c3ed9bd-ff44-447d-b4af-c6a4e4090a5a"),
				ColumnUId = new Guid("d06ba9af-faf5-4741-a672-e154ae561a94"),
				CreatedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				ModifiedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				CreatedInPackageId = new Guid("b424f2c1-869b-44e8-aaf1-c9a818421e06"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(leadNameIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("ffd7fbbc-d24b-428b-aea8-e1eea47e3c12");
			Name = "Lead_LeadManagement_BPMSoft";
			ParentSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec");
			ExtendParent = true;
			CreatedInPackageId = new Guid("bd283c8c-8066-48d7-9adc-67bc26fc3b49");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override EntitySchemaColumn CreateLeadTypeStatusColumn() {
			EntitySchemaColumn column = base.CreateLeadTypeStatusColumn();
			column.DefValue = new EntitySchemaColumnDef() {
				Source = EntitySchemaColumnDefSource.Const,
				ValueSource = @"5b3d1046-fc16-45c8-a5a1-298dfc857546"
			};
			column.ModifiedInSchemaUId = new Guid("ffd7fbbc-d24b-428b-aea8-e1eea47e3c12");
			return column;
		}

		protected override EntitySchemaColumn CreateQualifyStatusColumn() {
			EntitySchemaColumn column = base.CreateQualifyStatusColumn();
			column.DefValue = new EntitySchemaColumnDef() {
				Source = EntitySchemaColumnDefSource.None,
				ValueSource = @""
			};
			column.ModifiedInSchemaUId = new Guid("ffd7fbbc-d24b-428b-aea8-e1eea47e3c12");
			return column;
		}

		protected override EntitySchemaColumn CreateRegisterMethodColumn() {
			EntitySchemaColumn column = base.CreateRegisterMethodColumn();
			column.DefValue = new EntitySchemaColumnDef() {
				Source = EntitySchemaColumnDefSource.Const,
				ValueSource = @"240ab9c6-4d7c-4688-b380-af44dd147d7a"
			};
			column.ModifiedInSchemaUId = new Guid("ffd7fbbc-d24b-428b-aea8-e1eea47e3c12");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateIDX_LeadNameIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new Lead_LeadManagement_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Lead_LeadManagementEventsProcess(userConnection);
		}

		public override object Clone() {
			return new Lead_LeadManagement_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new Lead_LeadManagement_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ffd7fbbc-d24b-428b-aea8-e1eea47e3c12"));
		}

		#endregion

	}

	#endregion

	#region Class: Lead_LeadManagement_BPMSoft

	/// <summary>
	/// Лид.
	/// </summary>
	public class Lead_LeadManagement_BPMSoft : BPMSoft.Configuration.Lead_CoreLead_BPMSoft
	{

		#region Constructors: Public

		public Lead_LeadManagement_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Lead_LeadManagement_BPMSoft";
		}

		public Lead_LeadManagement_BPMSoft(Lead_LeadManagement_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Lead_LeadManagementEventsProcess(UserConnection);
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
			return new Lead_LeadManagement_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: Lead_LeadManagementEventsProcess

	/// <exclude/>
	public partial class Lead_LeadManagementEventsProcess<TEntity> : BPMSoft.Configuration.Lead_CoreLeadEventsProcess<TEntity> where TEntity : Lead_LeadManagement_BPMSoft
	{

		public Lead_LeadManagementEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Lead_LeadManagementEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("ffd7fbbc-d24b-428b-aea8-e1eea47e3c12");
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

	#region Class: Lead_LeadManagementEventsProcess

	/// <exclude/>
	public class Lead_LeadManagementEventsProcess : Lead_LeadManagementEventsProcess<Lead_LeadManagement_BPMSoft>
	{

		public Lead_LeadManagementEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: Lead_LeadManagementEventsProcess

	public partial class Lead_LeadManagementEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

