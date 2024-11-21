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

	#region Class: VwOAuthAppUserSchema

	/// <exclude/>
	public class VwOAuthAppUserSchema : BPMSoft.Configuration.OAuthTokenStorageSchema
	{

		#region Constructors: Public

		public VwOAuthAppUserSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwOAuthAppUserSchema(VwOAuthAppUserSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwOAuthAppUserSchema(VwOAuthAppUserSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("43235626-68ac-4e6e-ba08-8e1a34a37e63");
			RealUId = new Guid("43235626-68ac-4e6e-ba08-8e1a34a37e63");
			Name = "VwOAuthAppUser";
			ParentSchemaUId = new Guid("44bea56e-8a8f-4e29-9494-83253eff2594");
			ExtendParent = false;
			CreatedInPackageId = new Guid("69832cb9-4518-407d-8490-ad1baa6b0193");
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
			return new VwOAuthAppUser(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwOAuthAppUser_OAuth20IntegrationEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwOAuthAppUserSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwOAuthAppUserSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("43235626-68ac-4e6e-ba08-8e1a34a37e63"));
		}

		#endregion

	}

	#endregion

	#region Class: VwOAuthAppUser

	/// <summary>
	/// VwOAuthAppUser.
	/// </summary>
	public class VwOAuthAppUser : BPMSoft.Configuration.OAuthTokenStorage
	{

		#region Constructors: Public

		public VwOAuthAppUser(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwOAuthAppUser";
		}

		public VwOAuthAppUser(VwOAuthAppUser source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new VwOAuthAppUser_OAuth20IntegrationEventsProcess(UserConnection);
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
			return new VwOAuthAppUser(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwOAuthAppUser_OAuth20IntegrationEventsProcess

	/// <exclude/>
	public partial class VwOAuthAppUser_OAuth20IntegrationEventsProcess<TEntity> : BPMSoft.Configuration.OAuthTokenStorage_BaseEventsProcess<TEntity> where TEntity : VwOAuthAppUser
	{

		public VwOAuthAppUser_OAuth20IntegrationEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwOAuthAppUser_OAuth20IntegrationEventsProcess";
			SchemaUId = new Guid("43235626-68ac-4e6e-ba08-8e1a34a37e63");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("43235626-68ac-4e6e-ba08-8e1a34a37e63");
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

	#region Class: VwOAuthAppUser_OAuth20IntegrationEventsProcess

	/// <exclude/>
	public class VwOAuthAppUser_OAuth20IntegrationEventsProcess : VwOAuthAppUser_OAuth20IntegrationEventsProcess<VwOAuthAppUser>
	{

		public VwOAuthAppUser_OAuth20IntegrationEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VwOAuthAppUser_OAuth20IntegrationEventsProcess

	public partial class VwOAuthAppUser_OAuth20IntegrationEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: VwOAuthAppUserEventsProcess

	/// <exclude/>
	public class VwOAuthAppUserEventsProcess : VwOAuthAppUser_OAuth20IntegrationEventsProcess
	{

		public VwOAuthAppUserEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

