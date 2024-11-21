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

	#region Class: WSColorRuleTypeSchema

	/// <exclude/>
	public class WSColorRuleTypeSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public WSColorRuleTypeSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public WSColorRuleTypeSchema(WSColorRuleTypeSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public WSColorRuleTypeSchema(WSColorRuleTypeSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("4eab961e-5f91-4f66-8e91-95a653fd8371");
			RealUId = new Guid("4eab961e-5f91-4f66-8e91-95a653fd8371");
			Name = "WSColorRuleType";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("0b5cfdfd-ab13-4d8b-93a0-61a7172b646d");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateWSNameColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected virtual EntitySchemaColumn CreateWSNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("008f5462-51aa-4371-9433-7657a4b3dc4c"),
				Name = @"WSName",
				CreatedInSchemaUId = new Guid("4eab961e-5f91-4f66-8e91-95a653fd8371"),
				ModifiedInSchemaUId = new Guid("4eab961e-5f91-4f66-8e91-95a653fd8371"),
				CreatedInPackageId = new Guid("0b5cfdfd-ab13-4d8b-93a0-61a7172b646d"),
				IsLocalizable = true
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new WSColorRuleType(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new WSColorRuleType_WSFieldsmanagementEventsProcess(userConnection);
		}

		public override object Clone() {
			return new WSColorRuleTypeSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new WSColorRuleTypeSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("4eab961e-5f91-4f66-8e91-95a653fd8371"));
		}

		#endregion

	}

	#endregion

	#region Class: WSColorRuleType

	/// <summary>
	/// Область применения окраски.
	/// </summary>
	public class WSColorRuleType : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public WSColorRuleType(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "WSColorRuleType";
		}

		public WSColorRuleType(WSColorRuleType source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Название.
		/// </summary>
		public string WSName {
			get {
				return GetTypedColumnValue<string>("WSName");
			}
			set {
				SetColumnValue("WSName", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new WSColorRuleType_WSFieldsmanagementEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("WSColorRuleTypeDeleted", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new WSColorRuleType(this);
		}

		#endregion

	}

	#endregion

	#region Class: WSColorRuleType_WSFieldsmanagementEventsProcess

	/// <exclude/>
	public partial class WSColorRuleType_WSFieldsmanagementEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : WSColorRuleType
	{

		public WSColorRuleType_WSFieldsmanagementEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "WSColorRuleType_WSFieldsmanagementEventsProcess";
			SchemaUId = new Guid("4eab961e-5f91-4f66-8e91-95a653fd8371");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("4eab961e-5f91-4f66-8e91-95a653fd8371");
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

	#region Class: WSColorRuleType_WSFieldsmanagementEventsProcess

	/// <exclude/>
	public class WSColorRuleType_WSFieldsmanagementEventsProcess : WSColorRuleType_WSFieldsmanagementEventsProcess<WSColorRuleType>
	{

		public WSColorRuleType_WSFieldsmanagementEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: WSColorRuleType_WSFieldsmanagementEventsProcess

	public partial class WSColorRuleType_WSFieldsmanagementEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: WSColorRuleTypeEventsProcess

	/// <exclude/>
	public class WSColorRuleTypeEventsProcess : WSColorRuleType_WSFieldsmanagementEventsProcess
	{

		public WSColorRuleTypeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

