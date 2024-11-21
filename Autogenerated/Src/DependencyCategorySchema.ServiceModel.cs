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

	#region Class: DependencyCategorySchema

	/// <exclude/>
	public class DependencyCategorySchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public DependencyCategorySchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public DependencyCategorySchema(DependencyCategorySchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public DependencyCategorySchema(DependencyCategorySchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("5624aa9d-ec9a-4ea9-bf68-1059ef974609");
			RealUId = new Guid("5624aa9d-ec9a-4ea9-bf68-1059ef974609");
			Name = "DependencyCategory";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("4516643a-023b-4e8c-93a2-5f32ae9ffe7d");
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

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new DependencyCategory(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new DependencyCategory_ServiceModelEventsProcess(userConnection);
		}

		public override object Clone() {
			return new DependencyCategorySchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new DependencyCategorySchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("5624aa9d-ec9a-4ea9-bf68-1059ef974609"));
		}

		#endregion

	}

	#endregion

	#region Class: DependencyCategory

	/// <summary>
	/// Категория зависимостей объектов.
	/// </summary>
	public class DependencyCategory : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public DependencyCategory(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "DependencyCategory";
		}

		public DependencyCategory(DependencyCategory source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new DependencyCategory_ServiceModelEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("DependencyCategoryDeleted", e);
			Validating += (s, e) => ThrowEvent("DependencyCategoryValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new DependencyCategory(this);
		}

		#endregion

	}

	#endregion

	#region Class: DependencyCategory_ServiceModelEventsProcess

	/// <exclude/>
	public partial class DependencyCategory_ServiceModelEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : DependencyCategory
	{

		public DependencyCategory_ServiceModelEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "DependencyCategory_ServiceModelEventsProcess";
			SchemaUId = new Guid("5624aa9d-ec9a-4ea9-bf68-1059ef974609");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("5624aa9d-ec9a-4ea9-bf68-1059ef974609");
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

	#region Class: DependencyCategory_ServiceModelEventsProcess

	/// <exclude/>
	public class DependencyCategory_ServiceModelEventsProcess : DependencyCategory_ServiceModelEventsProcess<DependencyCategory>
	{

		public DependencyCategory_ServiceModelEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: DependencyCategory_ServiceModelEventsProcess

	public partial class DependencyCategory_ServiceModelEventsProcess<TEntity>
	{

		#region Methods: Public

		public override void LocalMessageExecuting(EntityChangeType changeType) {
			var lmHelper = new BPMSoft.Configuration.LocalMessageHelper(this.Entity, UserConnection, changeType);
			lmHelper.CreateLocalMessage();
		}

		#endregion

	}

	#endregion


	#region Class: DependencyCategoryEventsProcess

	/// <exclude/>
	public class DependencyCategoryEventsProcess : DependencyCategory_ServiceModelEventsProcess
	{

		public DependencyCategoryEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

