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

	#region Class: VwProjectProductSchema

	/// <exclude/>
	public class VwProjectProductSchema : BPMSoft.Configuration.ProjectProductSchema
	{

		#region Constructors: Public

		public VwProjectProductSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwProjectProductSchema(VwProjectProductSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwProjectProductSchema(VwProjectProductSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("857c076a-b605-4dd7-84f1-24508628d756");
			RealUId = new Guid("857c076a-b605-4dd7-84f1-24508628d756");
			Name = "VwProjectProduct";
			ParentSchemaUId = new Guid("4d57a5cd-c540-4eb1-b90e-db10a046c336");
			ExtendParent = false;
			CreatedInPackageId = new Guid("d770fc62-0459-4fe8-8528-e32423c8d6cb");
			IsDBView = true;
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

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new VwProjectProduct(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwProjectProduct_ProjectEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwProjectProductSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwProjectProductSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("857c076a-b605-4dd7-84f1-24508628d756"));
		}

		#endregion

	}

	#endregion

	#region Class: VwProjectProduct

	/// <summary>
	/// Продукт в проекте (представление).
	/// </summary>
	public class VwProjectProduct : BPMSoft.Configuration.ProjectProduct
	{

		#region Constructors: Public

		public VwProjectProduct(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwProjectProduct";
		}

		public VwProjectProduct(VwProjectProduct source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new VwProjectProduct_ProjectEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("VwProjectProductDeleted", e);
			Inserting += (s, e) => ThrowEvent("VwProjectProductInserting", e);
			Validating += (s, e) => ThrowEvent("VwProjectProductValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new VwProjectProduct(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwProjectProduct_ProjectEventsProcess

	/// <exclude/>
	public partial class VwProjectProduct_ProjectEventsProcess<TEntity> : BPMSoft.Configuration.ProjectProduct_ProjectEventsProcess<TEntity> where TEntity : VwProjectProduct
	{

		public VwProjectProduct_ProjectEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwProjectProduct_ProjectEventsProcess";
			SchemaUId = new Guid("857c076a-b605-4dd7-84f1-24508628d756");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("857c076a-b605-4dd7-84f1-24508628d756");
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

	#region Class: VwProjectProduct_ProjectEventsProcess

	/// <exclude/>
	public class VwProjectProduct_ProjectEventsProcess : VwProjectProduct_ProjectEventsProcess<VwProjectProduct>
	{

		public VwProjectProduct_ProjectEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VwProjectProduct_ProjectEventsProcess

	public partial class VwProjectProduct_ProjectEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: VwProjectProductEventsProcess

	/// <exclude/>
	public class VwProjectProductEventsProcess : VwProjectProduct_ProjectEventsProcess
	{

		public VwProjectProductEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

