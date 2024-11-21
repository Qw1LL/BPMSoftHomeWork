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

	#region Class: UserAttributesSchema

	/// <exclude/>
	public class UserAttributesSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public UserAttributesSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public UserAttributesSchema(UserAttributesSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public UserAttributesSchema(UserAttributesSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("8c843255-8f10-4737-a6f4-392762f6b682");
			RealUId = new Guid("8c843255-8f10-4737-a6f4-392762f6b682");
			Name = "UserAttributes";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("f397f2af-3c2b-4e84-b720-c5ecf5003a68");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("caf44c9c-7c66-45a6-a760-238780b7f174")) == null) {
				Columns.Add(CreateBPMColumnColumn());
			}
			if (Columns.FindByUId(new Guid("5324c52a-6c90-4598-ad52-e1579600e340")) == null) {
				Columns.Add(CreateADColumnColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateBPMColumnColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("caf44c9c-7c66-45a6-a760-238780b7f174"),
				Name = @"BPMColumn",
				CreatedInSchemaUId = new Guid("8c843255-8f10-4737-a6f4-392762f6b682"),
				ModifiedInSchemaUId = new Guid("8c843255-8f10-4737-a6f4-392762f6b682"),
				CreatedInPackageId = new Guid("f397f2af-3c2b-4e84-b720-c5ecf5003a68")
			};
		}

		protected virtual EntitySchemaColumn CreateADColumnColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("5324c52a-6c90-4598-ad52-e1579600e340"),
				Name = @"ADColumn",
				CreatedInSchemaUId = new Guid("8c843255-8f10-4737-a6f4-392762f6b682"),
				ModifiedInSchemaUId = new Guid("8c843255-8f10-4737-a6f4-392762f6b682"),
				CreatedInPackageId = new Guid("f397f2af-3c2b-4e84-b720-c5ecf5003a68")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new UserAttributes(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new UserAttributes_LDAPEventsProcess(userConnection);
		}

		public override object Clone() {
			return new UserAttributesSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new UserAttributesSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("8c843255-8f10-4737-a6f4-392762f6b682"));
		}

		#endregion

	}

	#endregion

	#region Class: UserAttributes

	/// <summary>
	/// Атрибуты пользователей.
	/// </summary>
	public class UserAttributes : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public UserAttributes(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "UserAttributes";
		}

		public UserAttributes(UserAttributes source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Колонка BPMConstructor.
		/// </summary>
		public string BPMColumn {
			get {
				return GetTypedColumnValue<string>("BPMColumn");
			}
			set {
				SetColumnValue("BPMColumn", value);
			}
		}

		/// <summary>
		/// Колонка в Active Directory.
		/// </summary>
		public string ADColumn {
			get {
				return GetTypedColumnValue<string>("ADColumn");
			}
			set {
				SetColumnValue("ADColumn", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new UserAttributes_LDAPEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("UserAttributesDeleted", e);
			Validating += (s, e) => ThrowEvent("UserAttributesValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new UserAttributes(this);
		}

		#endregion

	}

	#endregion

	#region Class: UserAttributes_LDAPEventsProcess

	/// <exclude/>
	public partial class UserAttributes_LDAPEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : UserAttributes
	{

		public UserAttributes_LDAPEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "UserAttributes_LDAPEventsProcess";
			SchemaUId = new Guid("8c843255-8f10-4737-a6f4-392762f6b682");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("8c843255-8f10-4737-a6f4-392762f6b682");
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

	#region Class: UserAttributes_LDAPEventsProcess

	/// <exclude/>
	public class UserAttributes_LDAPEventsProcess : UserAttributes_LDAPEventsProcess<UserAttributes>
	{

		public UserAttributes_LDAPEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: UserAttributes_LDAPEventsProcess

	public partial class UserAttributes_LDAPEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: UserAttributesEventsProcess

	/// <exclude/>
	public class UserAttributesEventsProcess : UserAttributes_LDAPEventsProcess
	{

		public UserAttributesEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

