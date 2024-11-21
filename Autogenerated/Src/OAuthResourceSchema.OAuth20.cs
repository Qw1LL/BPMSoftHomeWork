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

	#region Class: OAuthResourceSchema

	/// <exclude/>
	public class OAuthResourceSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public OAuthResourceSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public OAuthResourceSchema(OAuthResourceSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public OAuthResourceSchema(OAuthResourceSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("5b8a8436-01e6-4fa2-b52c-3d5868ba6c5e");
			RealUId = new Guid("5b8a8436-01e6-4fa2-b52c-3d5868ba6c5e");
			Name = "OAuthResource";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("2e618fe0-496b-4dc6-9b5c-1f29508fde14");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateDisplayNameColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("501bef06-a65e-440f-a761-ac1e6694e7d8")) == null) {
				Columns.Add(CreateNameColumn());
			}
			if (Columns.FindByUId(new Guid("10ca8682-ebfd-47c8-9f83-b74afc13fc74")) == null) {
				Columns.Add(CreateIsDefaultColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("501bef06-a65e-440f-a761-ac1e6694e7d8"),
				Name = @"Name",
				CreatedInSchemaUId = new Guid("5b8a8436-01e6-4fa2-b52c-3d5868ba6c5e"),
				ModifiedInSchemaUId = new Guid("5b8a8436-01e6-4fa2-b52c-3d5868ba6c5e"),
				CreatedInPackageId = new Guid("2e618fe0-496b-4dc6-9b5c-1f29508fde14")
			};
		}

		protected virtual EntitySchemaColumn CreateDisplayNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("453797b0-3b1d-4c2e-8982-fe410089680b"),
				Name = @"DisplayName",
				CreatedInSchemaUId = new Guid("5b8a8436-01e6-4fa2-b52c-3d5868ba6c5e"),
				ModifiedInSchemaUId = new Guid("5b8a8436-01e6-4fa2-b52c-3d5868ba6c5e"),
				CreatedInPackageId = new Guid("2e618fe0-496b-4dc6-9b5c-1f29508fde14")
			};
		}

		protected virtual EntitySchemaColumn CreateIsDefaultColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("10ca8682-ebfd-47c8-9f83-b74afc13fc74"),
				Name = @"IsDefault",
				CreatedInSchemaUId = new Guid("5b8a8436-01e6-4fa2-b52c-3d5868ba6c5e"),
				ModifiedInSchemaUId = new Guid("5b8a8436-01e6-4fa2-b52c-3d5868ba6c5e"),
				CreatedInPackageId = new Guid("2e618fe0-496b-4dc6-9b5c-1f29508fde14")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new OAuthResource(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new OAuthResource_OAuth20EventsProcess(userConnection);
		}

		public override object Clone() {
			return new OAuthResourceSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new OAuthResourceSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("5b8a8436-01e6-4fa2-b52c-3d5868ba6c5e"));
		}

		#endregion

	}

	#endregion

	#region Class: OAuthResource

	/// <summary>
	/// OAuth resource.
	/// </summary>
	public class OAuthResource : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public OAuthResource(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "OAuthResource";
		}

		public OAuthResource(OAuthResource source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Name.
		/// </summary>
		public string Name {
			get {
				return GetTypedColumnValue<string>("Name");
			}
			set {
				SetColumnValue("Name", value);
			}
		}

		/// <summary>
		/// Display name.
		/// </summary>
		public string DisplayName {
			get {
				return GetTypedColumnValue<string>("DisplayName");
			}
			set {
				SetColumnValue("DisplayName", value);
			}
		}

		/// <summary>
		/// Default resource.
		/// </summary>
		public bool IsDefault {
			get {
				return GetTypedColumnValue<bool>("IsDefault");
			}
			set {
				SetColumnValue("IsDefault", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new OAuthResource_OAuth20EventsProcess(UserConnection);
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
			return new OAuthResource(this);
		}

		#endregion

	}

	#endregion

	#region Class: OAuthResource_OAuth20EventsProcess

	/// <exclude/>
	public partial class OAuthResource_OAuth20EventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : OAuthResource
	{

		public OAuthResource_OAuth20EventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "OAuthResource_OAuth20EventsProcess";
			SchemaUId = new Guid("5b8a8436-01e6-4fa2-b52c-3d5868ba6c5e");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("5b8a8436-01e6-4fa2-b52c-3d5868ba6c5e");
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

	#region Class: OAuthResource_OAuth20EventsProcess

	/// <exclude/>
	public class OAuthResource_OAuth20EventsProcess : OAuthResource_OAuth20EventsProcess<OAuthResource>
	{

		public OAuthResource_OAuth20EventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: OAuthResource_OAuth20EventsProcess

	public partial class OAuthResource_OAuth20EventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: OAuthResourceEventsProcess

	/// <exclude/>
	public class OAuthResourceEventsProcess : OAuthResource_OAuth20EventsProcess
	{

		public OAuthResourceEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

