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

	#region Class: ExternalAccessClientSchema

	/// <exclude/>
	public class ExternalAccessClientSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public ExternalAccessClientSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ExternalAccessClientSchema(ExternalAccessClientSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ExternalAccessClientSchema(ExternalAccessClientSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("1d2bb308-dffb-4dd5-8518-f94ff54ea7cf");
			RealUId = new Guid("1d2bb308-dffb-4dd5-8518-f94ff54ea7cf");
			Name = "ExternalAccessClient";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("c3c7809d-fee0-4b66-8bb6-9b3983c2cffd");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateClientIdColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializePrimaryOrderColumn() {
			base.InitializePrimaryOrderColumn();
			PrimaryOrderColumn = CreateClientIdColumn();
			if (Columns.FindByUId(PrimaryOrderColumn.UId) == null) {
				Columns.Add(PrimaryOrderColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected virtual EntitySchemaColumn CreateClientIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("445514b2-7265-4b3c-8622-11287c879e29"),
				Name = @"ClientId",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("1d2bb308-dffb-4dd5-8518-f94ff54ea7cf"),
				ModifiedInSchemaUId = new Guid("1d2bb308-dffb-4dd5-8518-f94ff54ea7cf"),
				CreatedInPackageId = new Guid("c3c7809d-fee0-4b66-8bb6-9b3983c2cffd")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ExternalAccessClient(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ExternalAccessClient_ExternalAccessEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ExternalAccessClientSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ExternalAccessClientSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("1d2bb308-dffb-4dd5-8518-f94ff54ea7cf"));
		}

		#endregion

	}

	#endregion

	#region Class: ExternalAccessClient

	/// <summary>
	/// External access client.
	/// </summary>
	public class ExternalAccessClient : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public ExternalAccessClient(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ExternalAccessClient";
		}

		public ExternalAccessClient(ExternalAccessClient source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Client ID.
		/// </summary>
		public string ClientId {
			get {
				return GetTypedColumnValue<string>("ClientId");
			}
			set {
				SetColumnValue("ClientId", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ExternalAccessClient_ExternalAccessEventsProcess(UserConnection);
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
			return new ExternalAccessClient(this);
		}

		#endregion

	}

	#endregion

	#region Class: ExternalAccessClient_ExternalAccessEventsProcess

	/// <exclude/>
	public partial class ExternalAccessClient_ExternalAccessEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : ExternalAccessClient
	{

		public ExternalAccessClient_ExternalAccessEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ExternalAccessClient_ExternalAccessEventsProcess";
			SchemaUId = new Guid("1d2bb308-dffb-4dd5-8518-f94ff54ea7cf");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("1d2bb308-dffb-4dd5-8518-f94ff54ea7cf");
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

	#region Class: ExternalAccessClient_ExternalAccessEventsProcess

	/// <exclude/>
	public class ExternalAccessClient_ExternalAccessEventsProcess : ExternalAccessClient_ExternalAccessEventsProcess<ExternalAccessClient>
	{

		public ExternalAccessClient_ExternalAccessEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ExternalAccessClient_ExternalAccessEventsProcess

	public partial class ExternalAccessClient_ExternalAccessEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ExternalAccessClientEventsProcess

	/// <exclude/>
	public class ExternalAccessClientEventsProcess : ExternalAccessClient_ExternalAccessEventsProcess
	{

		public ExternalAccessClientEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

