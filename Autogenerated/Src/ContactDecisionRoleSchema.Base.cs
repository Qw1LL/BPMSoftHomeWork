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

	#region Class: ContactDecisionRoleSchema

	/// <exclude/>
	public class ContactDecisionRoleSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public ContactDecisionRoleSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ContactDecisionRoleSchema(ContactDecisionRoleSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ContactDecisionRoleSchema(ContactDecisionRoleSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("54aa771f-fba6-4d76-9239-bff3f00ee3e5");
			RealUId = new Guid("54aa771f-fba6-4d76-9239-bff3f00ee3e5");
			Name = "ContactDecisionRole";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("54aa771f-fba6-4d76-9239-bff3f00ee3e5");
			column.CreatedInPackageId = new Guid("c692daa9-de5e-4e96-afd3-e992ed86681c");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("54aa771f-fba6-4d76-9239-bff3f00ee3e5");
			column.CreatedInPackageId = new Guid("c692daa9-de5e-4e96-afd3-e992ed86681c");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ContactDecisionRole(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ContactDecisionRole_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ContactDecisionRoleSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ContactDecisionRoleSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("54aa771f-fba6-4d76-9239-bff3f00ee3e5"));
		}

		#endregion

	}

	#endregion

	#region Class: ContactDecisionRole

	/// <summary>
	/// Role in decision making.
	/// </summary>
	public class ContactDecisionRole : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public ContactDecisionRole(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ContactDecisionRole";
		}

		public ContactDecisionRole(ContactDecisionRole source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ContactDecisionRole_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ContactDecisionRoleDeleted", e);
			Deleting += (s, e) => ThrowEvent("ContactDecisionRoleDeleting", e);
			Inserted += (s, e) => ThrowEvent("ContactDecisionRoleInserted", e);
			Inserting += (s, e) => ThrowEvent("ContactDecisionRoleInserting", e);
			Saved += (s, e) => ThrowEvent("ContactDecisionRoleSaved", e);
			Saving += (s, e) => ThrowEvent("ContactDecisionRoleSaving", e);
			Validating += (s, e) => ThrowEvent("ContactDecisionRoleValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ContactDecisionRole(this);
		}

		#endregion

	}

	#endregion

	#region Class: ContactDecisionRole_BaseEventsProcess

	/// <exclude/>
	public partial class ContactDecisionRole_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : ContactDecisionRole
	{

		public ContactDecisionRole_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ContactDecisionRole_BaseEventsProcess";
			SchemaUId = new Guid("54aa771f-fba6-4d76-9239-bff3f00ee3e5");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("54aa771f-fba6-4d76-9239-bff3f00ee3e5");
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

	#region Class: ContactDecisionRole_BaseEventsProcess

	/// <exclude/>
	public class ContactDecisionRole_BaseEventsProcess : ContactDecisionRole_BaseEventsProcess<ContactDecisionRole>
	{

		public ContactDecisionRole_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ContactDecisionRole_BaseEventsProcess

	public partial class ContactDecisionRole_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ContactDecisionRoleEventsProcess

	/// <exclude/>
	public class ContactDecisionRoleEventsProcess : ContactDecisionRole_BaseEventsProcess
	{

		public ContactDecisionRoleEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

