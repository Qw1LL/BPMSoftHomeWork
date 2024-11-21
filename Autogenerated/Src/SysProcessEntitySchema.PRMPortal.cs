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

	#region Class: SysProcessEntitySchema

	/// <exclude/>
	public class SysProcessEntitySchema : BPMSoft.Configuration.SysProcessEntity_Base_BPMSoftSchema
	{

		#region Constructors: Public

		public SysProcessEntitySchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysProcessEntitySchema(SysProcessEntitySchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysProcessEntitySchema(SysProcessEntitySchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateIX_SysProcessEntity_EntityIdIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = false
			};
			index.UId = new Guid("d9d3d491-459e-4147-a675-d4bfcbff6acd");
			index.Name = "IX_SysProcessEntity_EntityId";
			index.CreatedInSchemaUId = new Guid("b01b6fea-b44a-4cf0-ae42-c74065cf2a8a");
			index.ModifiedInSchemaUId = new Guid("b01b6fea-b44a-4cf0-ae42-c74065cf2a8a");
			index.CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f");
			EntitySchemaIndexColumn entityIdIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("7c31ffa3-d76e-06f7-0987-765d0615fcfe"),
				ColumnUId = new Guid("2f6d04e2-dfa3-45ab-9a1f-e60c69b68736"),
				CreatedInSchemaUId = new Guid("b01b6fea-b44a-4cf0-ae42-c74065cf2a8a"),
				ModifiedInSchemaUId = new Guid("b01b6fea-b44a-4cf0-ae42-c74065cf2a8a"),
				CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(entityIdIndexColumn);
			return index;
		}

		private EntitySchemaIndex CreateIXSPE_EntitySchemaUIdEntityIdIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = false
			};
			index.UId = new Guid("b81c981e-76a1-4a35-87f9-75afc549af29");
			index.Name = "IXSPE_EntitySchemaUIdEntityId";
			index.CreatedInSchemaUId = new Guid("b01b6fea-b44a-4cf0-ae42-c74065cf2a8a");
			index.ModifiedInSchemaUId = new Guid("b01b6fea-b44a-4cf0-ae42-c74065cf2a8a");
			index.CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f");
			EntitySchemaIndexColumn entitySchemaUIdIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("621ef70c-7357-6560-463f-c66725c87d06"),
				ColumnUId = new Guid("36dc520e-160c-4d05-916b-2c4d4c0b0689"),
				CreatedInSchemaUId = new Guid("b01b6fea-b44a-4cf0-ae42-c74065cf2a8a"),
				ModifiedInSchemaUId = new Guid("b01b6fea-b44a-4cf0-ae42-c74065cf2a8a"),
				CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(entitySchemaUIdIndexColumn);
			EntitySchemaIndexColumn entityIdIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("df46e2d2-e70a-6f02-72a7-d6c3f839038d"),
				ColumnUId = new Guid("2f6d04e2-dfa3-45ab-9a1f-e60c69b68736"),
				CreatedInSchemaUId = new Guid("b01b6fea-b44a-4cf0-ae42-c74065cf2a8a"),
				ModifiedInSchemaUId = new Guid("b01b6fea-b44a-4cf0-ae42-c74065cf2a8a"),
				CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(entityIdIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("0b58887e-0550-460d-80c7-d0fd480e6a7d");
			Name = "SysProcessEntity";
			ParentSchemaUId = new Guid("b01b6fea-b44a-4cf0-ae42-c74065cf2a8a");
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
			Indexes.Add(CreateIX_SysProcessEntity_EntityIdIndex());
			Indexes.Add(CreateIXSPE_EntitySchemaUIdEntityIdIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysProcessEntity(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysProcessEntity_PRMPortalEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysProcessEntitySchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysProcessEntitySchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("0b58887e-0550-460d-80c7-d0fd480e6a7d"));
		}

		#endregion

	}

	#endregion

	#region Class: SysProcessEntity

	/// <summary>
	/// Процесс в объекте.
	/// </summary>
	public class SysProcessEntity : BPMSoft.Configuration.SysProcessEntity_Base_BPMSoft
	{

		#region Constructors: Public

		public SysProcessEntity(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysProcessEntity";
		}

		public SysProcessEntity(SysProcessEntity source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysProcessEntity_PRMPortalEventsProcess(UserConnection);
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
			return new SysProcessEntity(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysProcessEntity_PRMPortalEventsProcess

	/// <exclude/>
	public partial class SysProcessEntity_PRMPortalEventsProcess<TEntity> : BPMSoft.Configuration.SysProcessEntity_BaseEventsProcess<TEntity> where TEntity : SysProcessEntity
	{

		public SysProcessEntity_PRMPortalEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysProcessEntity_PRMPortalEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("0b58887e-0550-460d-80c7-d0fd480e6a7d");
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

	#region Class: SysProcessEntity_PRMPortalEventsProcess

	/// <exclude/>
	public class SysProcessEntity_PRMPortalEventsProcess : SysProcessEntity_PRMPortalEventsProcess<SysProcessEntity>
	{

		public SysProcessEntity_PRMPortalEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysProcessEntity_PRMPortalEventsProcess

	public partial class SysProcessEntity_PRMPortalEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysProcessEntityEventsProcess

	/// <exclude/>
	public class SysProcessEntityEventsProcess : SysProcessEntity_PRMPortalEventsProcess
	{

		public SysProcessEntityEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

