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

	#region Class: VwSysFunctionalRoleSchema

	/// <exclude/>
	public class VwSysFunctionalRoleSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public VwSysFunctionalRoleSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwSysFunctionalRoleSchema(VwSysFunctionalRoleSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwSysFunctionalRoleSchema(VwSysFunctionalRoleSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("8153ea60-e515-48e8-8ba4-83c5e36c2bb1");
			RealUId = new Guid("8153ea60-e515-48e8-8ba4-83c5e36c2bb1");
			Name = "VwSysFunctionalRole";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f");
			IsDBView = true;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.IsLocalizable = false;
			column.ModifiedInSchemaUId = new Guid("8153ea60-e515-48e8-8ba4-83c5e36c2bb1");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.IsLocalizable = false;
			column.ModifiedInSchemaUId = new Guid("8153ea60-e515-48e8-8ba4-83c5e36c2bb1");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new VwSysFunctionalRole(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwSysFunctionalRole_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwSysFunctionalRoleSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwSysFunctionalRoleSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("8153ea60-e515-48e8-8ba4-83c5e36c2bb1"));
		}

		#endregion

	}

	#endregion

	#region Class: VwSysFunctionalRole

	/// <summary>
	/// Functional roles.
	/// </summary>
	public class VwSysFunctionalRole : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public VwSysFunctionalRole(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwSysFunctionalRole";
		}

		public VwSysFunctionalRole(VwSysFunctionalRole source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new VwSysFunctionalRole_BaseEventsProcess(UserConnection);
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
			return new VwSysFunctionalRole(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwSysFunctionalRole_BaseEventsProcess

	/// <exclude/>
	public partial class VwSysFunctionalRole_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : VwSysFunctionalRole
	{

		public VwSysFunctionalRole_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwSysFunctionalRole_BaseEventsProcess";
			SchemaUId = new Guid("8153ea60-e515-48e8-8ba4-83c5e36c2bb1");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("8153ea60-e515-48e8-8ba4-83c5e36c2bb1");
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

	#region Class: VwSysFunctionalRole_BaseEventsProcess

	/// <exclude/>
	public class VwSysFunctionalRole_BaseEventsProcess : VwSysFunctionalRole_BaseEventsProcess<VwSysFunctionalRole>
	{

		public VwSysFunctionalRole_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VwSysFunctionalRole_BaseEventsProcess

	public partial class VwSysFunctionalRole_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: VwSysFunctionalRoleEventsProcess

	/// <exclude/>
	public class VwSysFunctionalRoleEventsProcess : VwSysFunctionalRole_BaseEventsProcess
	{

		public VwSysFunctionalRoleEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

