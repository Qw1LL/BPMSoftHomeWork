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

	#region Class: LeadInTag_Lead_BPMSoftSchema

	/// <exclude/>
	public class LeadInTag_Lead_BPMSoftSchema : BPMSoft.Configuration.BaseEntityInTagSchema
	{

		#region Constructors: Public

		public LeadInTag_Lead_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public LeadInTag_Lead_BPMSoftSchema(LeadInTag_Lead_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public LeadInTag_Lead_BPMSoftSchema(LeadInTag_Lead_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("b82de9e2-1c9c-4da1-8c8e-69b279e74bc0");
			RealUId = new Guid("b82de9e2-1c9c-4da1-8c8e-69b279e74bc0");
			Name = "LeadInTag_Lead_BPMSoft";
			ParentSchemaUId = new Guid("5894a2b0-51d5-419a-82bb-238674634270");
			ExtendParent = false;
			CreatedInPackageId = new Guid("9e68a40f-2533-42d0-8fe0-88fdb6bf5704");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override EntitySchemaColumn CreateTagColumn() {
			EntitySchemaColumn column = base.CreateTagColumn();
			column.ReferenceSchemaUId = new Guid("be1059c6-63ff-4c7a-805a-697b2358b245");
			column.ColumnValueName = @"TagId";
			column.DisplayColumnValueName = @"TagName";
			column.ModifiedInSchemaUId = new Guid("b82de9e2-1c9c-4da1-8c8e-69b279e74bc0");
			return column;
		}

		protected override EntitySchemaColumn CreateEntityColumn() {
			EntitySchemaColumn column = base.CreateEntityColumn();
			column.ReferenceSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec");
			column.ColumnValueName = @"EntityId";
			column.DisplayColumnValueName = @"EntityLeadName";
			column.ModifiedInSchemaUId = new Guid("b82de9e2-1c9c-4da1-8c8e-69b279e74bc0");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new LeadInTag_Lead_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new LeadInTag_LeadEventsProcess(userConnection);
		}

		public override object Clone() {
			return new LeadInTag_Lead_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new LeadInTag_Lead_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("b82de9e2-1c9c-4da1-8c8e-69b279e74bc0"));
		}

		#endregion

	}

	#endregion

	#region Class: LeadInTag_Lead_BPMSoft

	/// <summary>
	/// Тег в записи раздела лиды.
	/// </summary>
	public class LeadInTag_Lead_BPMSoft : BPMSoft.Configuration.BaseEntityInTag
	{

		#region Constructors: Public

		public LeadInTag_Lead_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "LeadInTag_Lead_BPMSoft";
		}

		public LeadInTag_Lead_BPMSoft(LeadInTag_Lead_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new LeadInTag_LeadEventsProcess(UserConnection);
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
			return new LeadInTag_Lead_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: LeadInTag_LeadEventsProcess

	/// <exclude/>
	public partial class LeadInTag_LeadEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntityInTag_BaseEventsProcess<TEntity> where TEntity : LeadInTag_Lead_BPMSoft
	{

		public LeadInTag_LeadEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "LeadInTag_LeadEventsProcess";
			SchemaUId = new Guid("b82de9e2-1c9c-4da1-8c8e-69b279e74bc0");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("b82de9e2-1c9c-4da1-8c8e-69b279e74bc0");
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

	#region Class: LeadInTag_LeadEventsProcess

	/// <exclude/>
	public class LeadInTag_LeadEventsProcess : LeadInTag_LeadEventsProcess<LeadInTag_Lead_BPMSoft>
	{

		public LeadInTag_LeadEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: LeadInTag_LeadEventsProcess

	public partial class LeadInTag_LeadEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

