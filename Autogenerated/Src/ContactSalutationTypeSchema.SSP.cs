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

	#region Class: ContactSalutationTypeSchema

	/// <exclude/>
	public class ContactSalutationTypeSchema : BPMSoft.Configuration.ContactSalutationType_Base_BPMSoftSchema
	{

		#region Constructors: Public

		public ContactSalutationTypeSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ContactSalutationTypeSchema(ContactSalutationTypeSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ContactSalutationTypeSchema(ContactSalutationTypeSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("76ac3af6-10b8-4339-aa4d-70db3617ed22");
			Name = "ContactSalutationType";
			ParentSchemaUId = new Guid("e3c92284-1491-4438-986f-4bf5dbe4b847");
			ExtendParent = true;
			CreatedInPackageId = new Guid("d7352345-17a4-46e8-b32e-306ac0453d7a");
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
			return new ContactSalutationType(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ContactSalutationType_SSPEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ContactSalutationTypeSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ContactSalutationTypeSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("76ac3af6-10b8-4339-aa4d-70db3617ed22"));
		}

		#endregion

	}

	#endregion

	#region Class: ContactSalutationType

	/// <summary>
	/// Contact title.
	/// </summary>
	public class ContactSalutationType : BPMSoft.Configuration.ContactSalutationType_Base_BPMSoft
	{

		#region Constructors: Public

		public ContactSalutationType(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ContactSalutationType";
		}

		public ContactSalutationType(ContactSalutationType source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ContactSalutationType_SSPEventsProcess(UserConnection);
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
			return new ContactSalutationType(this);
		}

		#endregion

	}

	#endregion

	#region Class: ContactSalutationType_SSPEventsProcess

	/// <exclude/>
	public partial class ContactSalutationType_SSPEventsProcess<TEntity> : BPMSoft.Configuration.ContactSalutationType_BaseEventsProcess<TEntity> where TEntity : ContactSalutationType
	{

		public ContactSalutationType_SSPEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ContactSalutationType_SSPEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("76ac3af6-10b8-4339-aa4d-70db3617ed22");
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

	#region Class: ContactSalutationType_SSPEventsProcess

	/// <exclude/>
	public class ContactSalutationType_SSPEventsProcess : ContactSalutationType_SSPEventsProcess<ContactSalutationType>
	{

		public ContactSalutationType_SSPEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ContactSalutationType_SSPEventsProcess

	public partial class ContactSalutationType_SSPEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ContactSalutationTypeEventsProcess

	/// <exclude/>
	public class ContactSalutationTypeEventsProcess : ContactSalutationType_SSPEventsProcess
	{

		public ContactSalutationTypeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

