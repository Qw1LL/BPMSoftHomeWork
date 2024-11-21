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

	#region Class: SysSchemaSchema

	/// <exclude/>
	public class SysSchemaSchema : BPMSoft.Configuration.SysSchema_Base_BPMSoftSchema
	{

		#region Constructors: Public

		public SysSchemaSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysSchemaSchema(SysSchemaSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysSchemaSchema(SysSchemaSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateISysSchemaManagerPackageIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = false
			};
			index.UId = new Guid("5b31c27f-b99e-4fae-8520-333e0b3dbd58");
			index.Name = "ISysSchemaManagerPackage";
			index.CreatedInSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15");
			index.ModifiedInSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15");
			index.CreatedInPackageId = new Guid("6ff020f5-e34d-4da9-8c0d-3678e6f20dbf");
			EntitySchemaIndexColumn managerNameIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("1a65e761-41f2-4800-8609-2d3ce058fbd5"),
				ColumnUId = new Guid("b16558a9-019e-4fc5-b341-2f17fffcfa1e"),
				CreatedInSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				ModifiedInSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				CreatedInPackageId = new Guid("6ff020f5-e34d-4da9-8c0d-3678e6f20dbf"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(managerNameIndexColumn);
			EntitySchemaIndexColumn sysPackageIdIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("5d07ff36-556e-4ff9-ab61-eee7d7897e46"),
				ColumnUId = new Guid("dd68d792-9b3e-40f0-98b8-74b536fa3767"),
				CreatedInSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				ModifiedInSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				CreatedInPackageId = new Guid("6ff020f5-e34d-4da9-8c0d-3678e6f20dbf"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(sysPackageIdIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("1b348c64-ea9a-4b30-9359-37cb5419517a");
			Name = "SysSchema";
			ParentSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15");
			ExtendParent = true;
			CreatedInPackageId = new Guid("667fe825-207f-46da-8fb7-a082f81fd079");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateISysSchemaManagerPackageIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysSchema(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysSchema_PRMPortalEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysSchemaSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysSchemaSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("1b348c64-ea9a-4b30-9359-37cb5419517a"));
		}

		#endregion

	}

	#endregion

	#region Class: SysSchema

	/// <summary>
	/// Схема.
	/// </summary>
	public class SysSchema : BPMSoft.Configuration.SysSchema_Base_BPMSoft
	{

		#region Constructors: Public

		public SysSchema(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysSchema";
		}

		public SysSchema(SysSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysSchema_PRMPortalEventsProcess(UserConnection);
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
			return new SysSchema(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysSchema_PRMPortalEventsProcess

	/// <exclude/>
	public partial class SysSchema_PRMPortalEventsProcess<TEntity> : BPMSoft.Configuration.SysSchema_BaseEventsProcess<TEntity> where TEntity : SysSchema
	{

		public SysSchema_PRMPortalEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysSchema_PRMPortalEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("1b348c64-ea9a-4b30-9359-37cb5419517a");
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

	#region Class: SysSchema_PRMPortalEventsProcess

	/// <exclude/>
	public class SysSchema_PRMPortalEventsProcess : SysSchema_PRMPortalEventsProcess<SysSchema>
	{

		public SysSchema_PRMPortalEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysSchema_PRMPortalEventsProcess

	public partial class SysSchema_PRMPortalEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysSchemaEventsProcess

	/// <exclude/>
	public class SysSchemaEventsProcess : SysSchema_PRMPortalEventsProcess
	{

		public SysSchemaEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

