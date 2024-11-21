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

	#region Class: TelephonyAuthTypeSchema

	/// <exclude/>
	public class TelephonyAuthTypeSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public TelephonyAuthTypeSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public TelephonyAuthTypeSchema(TelephonyAuthTypeSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public TelephonyAuthTypeSchema(TelephonyAuthTypeSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("7aecaccf-4d96-44e0-b1e2-4b6eeec9cee3");
			RealUId = new Guid("7aecaccf-4d96-44e0-b1e2-4b6eeec9cee3");
			Name = "TelephonyAuthType";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("56b4a2f3-f537-4916-9cef-ba7f631fd3cc");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateNameColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("68bb09bb-7fa7-cb3f-e353-c02a59ee827d")) == null) {
				Columns.Add(CreateCodeColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("53ac42ae-f297-36ff-33a9-c001e2d11926"),
				Name = @"Name",
				CreatedInSchemaUId = new Guid("7aecaccf-4d96-44e0-b1e2-4b6eeec9cee3"),
				ModifiedInSchemaUId = new Guid("7aecaccf-4d96-44e0-b1e2-4b6eeec9cee3"),
				CreatedInPackageId = new Guid("56b4a2f3-f537-4916-9cef-ba7f631fd3cc")
			};
		}

		protected virtual EntitySchemaColumn CreateCodeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("68bb09bb-7fa7-cb3f-e353-c02a59ee827d"),
				Name = @"Code",
				CreatedInSchemaUId = new Guid("7aecaccf-4d96-44e0-b1e2-4b6eeec9cee3"),
				ModifiedInSchemaUId = new Guid("7aecaccf-4d96-44e0-b1e2-4b6eeec9cee3"),
				CreatedInPackageId = new Guid("56b4a2f3-f537-4916-9cef-ba7f631fd3cc")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new TelephonyAuthType(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new TelephonyAuthType_WebRTCCoreEventsProcess(userConnection);
		}

		public override object Clone() {
			return new TelephonyAuthTypeSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new TelephonyAuthTypeSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("7aecaccf-4d96-44e0-b1e2-4b6eeec9cee3"));
		}

		#endregion

	}

	#endregion

	#region Class: TelephonyAuthType

	/// <summary>
	/// Тип аутентификации в службе телефонии.
	/// </summary>
	public class TelephonyAuthType : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public TelephonyAuthType(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "TelephonyAuthType";
		}

		public TelephonyAuthType(TelephonyAuthType source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Название.
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
		/// Код.
		/// </summary>
		public string Code {
			get {
				return GetTypedColumnValue<string>("Code");
			}
			set {
				SetColumnValue("Code", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new TelephonyAuthType_WebRTCCoreEventsProcess(UserConnection);
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
			return new TelephonyAuthType(this);
		}

		#endregion

	}

	#endregion

	#region Class: TelephonyAuthType_WebRTCCoreEventsProcess

	/// <exclude/>
	public partial class TelephonyAuthType_WebRTCCoreEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : TelephonyAuthType
	{

		public TelephonyAuthType_WebRTCCoreEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "TelephonyAuthType_WebRTCCoreEventsProcess";
			SchemaUId = new Guid("7aecaccf-4d96-44e0-b1e2-4b6eeec9cee3");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("7aecaccf-4d96-44e0-b1e2-4b6eeec9cee3");
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

	#region Class: TelephonyAuthType_WebRTCCoreEventsProcess

	/// <exclude/>
	public class TelephonyAuthType_WebRTCCoreEventsProcess : TelephonyAuthType_WebRTCCoreEventsProcess<TelephonyAuthType>
	{

		public TelephonyAuthType_WebRTCCoreEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: TelephonyAuthType_WebRTCCoreEventsProcess

	public partial class TelephonyAuthType_WebRTCCoreEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: TelephonyAuthTypeEventsProcess

	/// <exclude/>
	public class TelephonyAuthTypeEventsProcess : TelephonyAuthType_WebRTCCoreEventsProcess
	{

		public TelephonyAuthTypeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

