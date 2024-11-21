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

	#region Class: LoginPageLinkSchema

	/// <exclude/>
	public class LoginPageLinkSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public LoginPageLinkSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public LoginPageLinkSchema(LoginPageLinkSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public LoginPageLinkSchema(LoginPageLinkSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("9f146202-c40f-4a14-ab9d-b543ae801ffb");
			RealUId = new Guid("9f146202-c40f-4a14-ab9d-b543ae801ffb");
			Name = "LoginPageLink";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("f795d9c2-dc6a-438b-8300-714f6c49b4e7");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("24df4754-c006-4741-b19e-848c5f118b1f")) == null) {
				Columns.Add(CreateLinkColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("9f146202-c40f-4a14-ab9d-b543ae801ffb");
			column.CreatedInPackageId = new Guid("f795d9c2-dc6a-438b-8300-714f6c49b4e7");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("9f146202-c40f-4a14-ab9d-b543ae801ffb");
			column.CreatedInPackageId = new Guid("f795d9c2-dc6a-438b-8300-714f6c49b4e7");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("9f146202-c40f-4a14-ab9d-b543ae801ffb");
			column.CreatedInPackageId = new Guid("f795d9c2-dc6a-438b-8300-714f6c49b4e7");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("9f146202-c40f-4a14-ab9d-b543ae801ffb");
			column.CreatedInPackageId = new Guid("f795d9c2-dc6a-438b-8300-714f6c49b4e7");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("9f146202-c40f-4a14-ab9d-b543ae801ffb");
			column.CreatedInPackageId = new Guid("f795d9c2-dc6a-438b-8300-714f6c49b4e7");
			return column;
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("9f146202-c40f-4a14-ab9d-b543ae801ffb");
			column.CreatedInPackageId = new Guid("f795d9c2-dc6a-438b-8300-714f6c49b4e7");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("9f146202-c40f-4a14-ab9d-b543ae801ffb");
			column.CreatedInPackageId = new Guid("f795d9c2-dc6a-438b-8300-714f6c49b4e7");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("9f146202-c40f-4a14-ab9d-b543ae801ffb");
			column.CreatedInPackageId = new Guid("f795d9c2-dc6a-438b-8300-714f6c49b4e7");
			return column;
		}

		protected virtual EntitySchemaColumn CreateLinkColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("24df4754-c006-4741-b19e-848c5f118b1f"),
				Name = @"Link",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("9f146202-c40f-4a14-ab9d-b543ae801ffb"),
				ModifiedInSchemaUId = new Guid("9f146202-c40f-4a14-ab9d-b543ae801ffb"),
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
			return new LoginPageLink(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new LoginPageLink_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new LoginPageLinkSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new LoginPageLinkSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("9f146202-c40f-4a14-ab9d-b543ae801ffb"));
		}

		#endregion

	}

	#endregion

	#region Class: LoginPageLink

	/// <summary>
	/// Useful links for login page.
	/// </summary>
	public class LoginPageLink : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public LoginPageLink(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "LoginPageLink";
		}

		public LoginPageLink(LoginPageLink source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Link.
		/// </summary>
		public string Link {
			get {
				return GetTypedColumnValue<string>("Link");
			}
			set {
				SetColumnValue("Link", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new LoginPageLink_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("LoginPageLinkDeleted", e);
			Inserting += (s, e) => ThrowEvent("LoginPageLinkInserting", e);
			Validating += (s, e) => ThrowEvent("LoginPageLinkValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new LoginPageLink(this);
		}

		#endregion

	}

	#endregion

	#region Class: LoginPageLink_BaseEventsProcess

	/// <exclude/>
	public partial class LoginPageLink_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : LoginPageLink
	{

		public LoginPageLink_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "LoginPageLink_BaseEventsProcess";
			SchemaUId = new Guid("9f146202-c40f-4a14-ab9d-b543ae801ffb");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("9f146202-c40f-4a14-ab9d-b543ae801ffb");
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

	#region Class: LoginPageLink_BaseEventsProcess

	/// <exclude/>
	public class LoginPageLink_BaseEventsProcess : LoginPageLink_BaseEventsProcess<LoginPageLink>
	{

		public LoginPageLink_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: LoginPageLink_BaseEventsProcess

	public partial class LoginPageLink_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: LoginPageLinkEventsProcess

	/// <exclude/>
	public class LoginPageLinkEventsProcess : LoginPageLink_BaseEventsProcess
	{

		public LoginPageLinkEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

