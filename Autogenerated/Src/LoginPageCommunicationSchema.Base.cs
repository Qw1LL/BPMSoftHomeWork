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

	#region Class: LoginPageCommunicationSchema

	/// <exclude/>
	public class LoginPageCommunicationSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public LoginPageCommunicationSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public LoginPageCommunicationSchema(LoginPageCommunicationSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public LoginPageCommunicationSchema(LoginPageCommunicationSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("7af64378-e2d0-4549-929a-92545d835dda");
			RealUId = new Guid("7af64378-e2d0-4549-929a-92545d835dda");
			Name = "LoginPageCommunication";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("f795d9c2-dc6a-438b-8300-714f6c49b4e7");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("70e277a1-3dd5-46d0-8333-5584aea82c54")) == null) {
				Columns.Add(CreatePhoneColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("7af64378-e2d0-4549-929a-92545d835dda");
			column.CreatedInPackageId = new Guid("f795d9c2-dc6a-438b-8300-714f6c49b4e7");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("7af64378-e2d0-4549-929a-92545d835dda");
			column.CreatedInPackageId = new Guid("f795d9c2-dc6a-438b-8300-714f6c49b4e7");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("7af64378-e2d0-4549-929a-92545d835dda");
			column.CreatedInPackageId = new Guid("f795d9c2-dc6a-438b-8300-714f6c49b4e7");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("7af64378-e2d0-4549-929a-92545d835dda");
			column.CreatedInPackageId = new Guid("f795d9c2-dc6a-438b-8300-714f6c49b4e7");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("7af64378-e2d0-4549-929a-92545d835dda");
			column.CreatedInPackageId = new Guid("f795d9c2-dc6a-438b-8300-714f6c49b4e7");
			return column;
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("7af64378-e2d0-4549-929a-92545d835dda");
			column.CreatedInPackageId = new Guid("f795d9c2-dc6a-438b-8300-714f6c49b4e7");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("7af64378-e2d0-4549-929a-92545d835dda");
			column.CreatedInPackageId = new Guid("f795d9c2-dc6a-438b-8300-714f6c49b4e7");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("7af64378-e2d0-4549-929a-92545d835dda");
			column.CreatedInPackageId = new Guid("f795d9c2-dc6a-438b-8300-714f6c49b4e7");
			return column;
		}

		protected virtual EntitySchemaColumn CreatePhoneColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("70e277a1-3dd5-46d0-8333-5584aea82c54"),
				Name = @"Phone",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("7af64378-e2d0-4549-929a-92545d835dda"),
				ModifiedInSchemaUId = new Guid("7af64378-e2d0-4549-929a-92545d835dda"),
				CreatedInPackageId = new Guid("f795d9c2-dc6a-438b-8300-714f6c49b4e7")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new LoginPageCommunication(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new LoginPageCommunication_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new LoginPageCommunicationSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new LoginPageCommunicationSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("7af64378-e2d0-4549-929a-92545d835dda"));
		}

		#endregion

	}

	#endregion

	#region Class: LoginPageCommunication

	/// <summary>
	/// Communication options for login page.
	/// </summary>
	public class LoginPageCommunication : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public LoginPageCommunication(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "LoginPageCommunication";
		}

		public LoginPageCommunication(LoginPageCommunication source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Phone number.
		/// </summary>
		public string Phone {
			get {
				return GetTypedColumnValue<string>("Phone");
			}
			set {
				SetColumnValue("Phone", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new LoginPageCommunication_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("LoginPageCommunicationDeleted", e);
			Inserting += (s, e) => ThrowEvent("LoginPageCommunicationInserting", e);
			Validating += (s, e) => ThrowEvent("LoginPageCommunicationValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new LoginPageCommunication(this);
		}

		#endregion

	}

	#endregion

	#region Class: LoginPageCommunication_BaseEventsProcess

	/// <exclude/>
	public partial class LoginPageCommunication_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : LoginPageCommunication
	{

		public LoginPageCommunication_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "LoginPageCommunication_BaseEventsProcess";
			SchemaUId = new Guid("7af64378-e2d0-4549-929a-92545d835dda");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("7af64378-e2d0-4549-929a-92545d835dda");
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

	#region Class: LoginPageCommunication_BaseEventsProcess

	/// <exclude/>
	public class LoginPageCommunication_BaseEventsProcess : LoginPageCommunication_BaseEventsProcess<LoginPageCommunication>
	{

		public LoginPageCommunication_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: LoginPageCommunication_BaseEventsProcess

	public partial class LoginPageCommunication_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: LoginPageCommunicationEventsProcess

	/// <exclude/>
	public class LoginPageCommunicationEventsProcess : LoginPageCommunication_BaseEventsProcess
	{

		public LoginPageCommunicationEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

