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

	#region Class: WebFormProcessHandlersSchema

	/// <exclude/>
	public class WebFormProcessHandlersSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public WebFormProcessHandlersSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public WebFormProcessHandlersSchema(WebFormProcessHandlersSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public WebFormProcessHandlersSchema(WebFormProcessHandlersSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("cc25c4c5-999d-4d8e-b2c6-3fc62a76be01");
			RealUId = new Guid("cc25c4c5-999d-4d8e-b2c6-3fc62a76be01");
			Name = "WebFormProcessHandlers";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("9d05c8ee-17e3-41aa-adfe-7e36f0a4c27c");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("3a5e7096-b81f-49be-95a5-1ad4806bc9e0")) == null) {
				Columns.Add(CreateEntityNameColumn());
			}
			if (Columns.FindByUId(new Guid("664b287e-0af3-4b74-904c-8a7bf7a492fc")) == null) {
				Columns.Add(CreateFullClassNameColumn());
			}
			if (Columns.FindByUId(new Guid("15f9ee15-d4c4-4f69-b9fc-e261048d91fb")) == null) {
				Columns.Add(CreateIsActiveColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateEntityNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("3a5e7096-b81f-49be-95a5-1ad4806bc9e0"),
				Name = @"EntityName",
				CreatedInSchemaUId = new Guid("cc25c4c5-999d-4d8e-b2c6-3fc62a76be01"),
				ModifiedInSchemaUId = new Guid("cc25c4c5-999d-4d8e-b2c6-3fc62a76be01"),
				CreatedInPackageId = new Guid("9d05c8ee-17e3-41aa-adfe-7e36f0a4c27c")
			};
		}

		protected virtual EntitySchemaColumn CreateFullClassNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("664b287e-0af3-4b74-904c-8a7bf7a492fc"),
				Name = @"FullClassName",
				CreatedInSchemaUId = new Guid("cc25c4c5-999d-4d8e-b2c6-3fc62a76be01"),
				ModifiedInSchemaUId = new Guid("cc25c4c5-999d-4d8e-b2c6-3fc62a76be01"),
				CreatedInPackageId = new Guid("9d05c8ee-17e3-41aa-adfe-7e36f0a4c27c")
			};
		}

		protected virtual EntitySchemaColumn CreateIsActiveColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("15f9ee15-d4c4-4f69-b9fc-e261048d91fb"),
				Name = @"IsActive",
				CreatedInSchemaUId = new Guid("cc25c4c5-999d-4d8e-b2c6-3fc62a76be01"),
				ModifiedInSchemaUId = new Guid("cc25c4c5-999d-4d8e-b2c6-3fc62a76be01"),
				CreatedInPackageId = new Guid("9d05c8ee-17e3-41aa-adfe-7e36f0a4c27c")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new WebFormProcessHandlers(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new WebFormProcessHandlers_WebFormEventsProcess(userConnection);
		}

		public override object Clone() {
			return new WebFormProcessHandlersSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new WebFormProcessHandlersSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("cc25c4c5-999d-4d8e-b2c6-3fc62a76be01"));
		}

		#endregion

	}

	#endregion

	#region Class: WebFormProcessHandlers

	/// <summary>
	/// Web form process handlers.
	/// </summary>
	public class WebFormProcessHandlers : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public WebFormProcessHandlers(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "WebFormProcessHandlers";
		}

		public WebFormProcessHandlers(WebFormProcessHandlers source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Entity name.
		/// </summary>
		public string EntityName {
			get {
				return GetTypedColumnValue<string>("EntityName");
			}
			set {
				SetColumnValue("EntityName", value);
			}
		}

		/// <summary>
		/// FullClassName.
		/// </summary>
		public string FullClassName {
			get {
				return GetTypedColumnValue<string>("FullClassName");
			}
			set {
				SetColumnValue("FullClassName", value);
			}
		}

		/// <summary>
		/// Is active.
		/// </summary>
		public bool IsActive {
			get {
				return GetTypedColumnValue<bool>("IsActive");
			}
			set {
				SetColumnValue("IsActive", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new WebFormProcessHandlers_WebFormEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("WebFormProcessHandlersDeleted", e);
			Validating += (s, e) => ThrowEvent("WebFormProcessHandlersValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new WebFormProcessHandlers(this);
		}

		#endregion

	}

	#endregion

	#region Class: WebFormProcessHandlers_WebFormEventsProcess

	/// <exclude/>
	public partial class WebFormProcessHandlers_WebFormEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : WebFormProcessHandlers
	{

		public WebFormProcessHandlers_WebFormEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "WebFormProcessHandlers_WebFormEventsProcess";
			SchemaUId = new Guid("cc25c4c5-999d-4d8e-b2c6-3fc62a76be01");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("cc25c4c5-999d-4d8e-b2c6-3fc62a76be01");
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

	#region Class: WebFormProcessHandlers_WebFormEventsProcess

	/// <exclude/>
	public class WebFormProcessHandlers_WebFormEventsProcess : WebFormProcessHandlers_WebFormEventsProcess<WebFormProcessHandlers>
	{

		public WebFormProcessHandlers_WebFormEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: WebFormProcessHandlers_WebFormEventsProcess

	public partial class WebFormProcessHandlers_WebFormEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: WebFormProcessHandlersEventsProcess

	/// <exclude/>
	public class WebFormProcessHandlersEventsProcess : WebFormProcessHandlers_WebFormEventsProcess
	{

		public WebFormProcessHandlersEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

