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

	#region Class: CaseInChatSchema

	/// <exclude/>
	public class CaseInChatSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public CaseInChatSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public CaseInChatSchema(CaseInChatSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public CaseInChatSchema(CaseInChatSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("be02586f-8054-41fd-ac2e-4dc8533a3428");
			RealUId = new Guid("be02586f-8054-41fd-ac2e-4dc8533a3428");
			Name = "CaseInChat";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("ff020f92-eb95-49ea-a251-6a0ed7e274a5");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("5c15fe84-5bf7-495f-bbd9-732983ff4947")) == null) {
				Columns.Add(CreateCaseColumn());
			}
			if (Columns.FindByUId(new Guid("91600a56-72e8-46c6-adef-5e76e616de34")) == null) {
				Columns.Add(CreateChatColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateCaseColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("5c15fe84-5bf7-495f-bbd9-732983ff4947"),
				Name = @"Case",
				ReferenceSchemaUId = new Guid("117d32f9-8275-4534-8411-1c66115ce9cd"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("be02586f-8054-41fd-ac2e-4dc8533a3428"),
				ModifiedInSchemaUId = new Guid("be02586f-8054-41fd-ac2e-4dc8533a3428"),
				CreatedInPackageId = new Guid("ff020f92-eb95-49ea-a251-6a0ed7e274a5")
			};
		}

		protected virtual EntitySchemaColumn CreateChatColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("91600a56-72e8-46c6-adef-5e76e616de34"),
				Name = @"Chat",
				ReferenceSchemaUId = new Guid("af1f685c-315b-4b44-a957-c5094417a57a"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("be02586f-8054-41fd-ac2e-4dc8533a3428"),
				ModifiedInSchemaUId = new Guid("be02586f-8054-41fd-ac2e-4dc8533a3428"),
				CreatedInPackageId = new Guid("ff020f92-eb95-49ea-a251-6a0ed7e274a5")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new CaseInChat(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new CaseInChat_CaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new CaseInChatSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new CaseInChatSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("be02586f-8054-41fd-ac2e-4dc8533a3428"));
		}

		#endregion

	}

	#endregion

	#region Class: CaseInChat

	/// <summary>
	/// Обращения в чате.
	/// </summary>
	public class CaseInChat : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public CaseInChat(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "CaseInChat";
		}

		public CaseInChat(CaseInChat source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid CaseId {
			get {
				return GetTypedColumnValue<Guid>("CaseId");
			}
			set {
				SetColumnValue("CaseId", value);
				_case = null;
			}
		}

		/// <exclude/>
		public string CaseNumber {
			get {
				return GetTypedColumnValue<string>("CaseNumber");
			}
			set {
				SetColumnValue("CaseNumber", value);
				if (_case != null) {
					_case.Number = value;
				}
			}
		}

		private Case _case;
		/// <summary>
		/// Обращение.
		/// </summary>
		public Case Case {
			get {
				return _case ??
					(_case = LookupColumnEntities.GetEntity("Case") as Case);
			}
		}

		/// <exclude/>
		public Guid ChatId {
			get {
				return GetTypedColumnValue<Guid>("ChatId");
			}
			set {
				SetColumnValue("ChatId", value);
				_chat = null;
			}
		}

		/// <exclude/>
		public string ChatName {
			get {
				return GetTypedColumnValue<string>("ChatName");
			}
			set {
				SetColumnValue("ChatName", value);
				if (_chat != null) {
					_chat.Name = value;
				}
			}
		}

		private OmniChat _chat;
		/// <summary>
		/// Чат.
		/// </summary>
		public OmniChat Chat {
			get {
				return _chat ??
					(_chat = LookupColumnEntities.GetEntity("Chat") as OmniChat);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new CaseInChat_CaseEventsProcess(UserConnection);
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
			return new CaseInChat(this);
		}

		#endregion

	}

	#endregion

	#region Class: CaseInChat_CaseEventsProcess

	/// <exclude/>
	public partial class CaseInChat_CaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : CaseInChat
	{

		public CaseInChat_CaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "CaseInChat_CaseEventsProcess";
			SchemaUId = new Guid("be02586f-8054-41fd-ac2e-4dc8533a3428");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("be02586f-8054-41fd-ac2e-4dc8533a3428");
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

	#region Class: CaseInChat_CaseEventsProcess

	/// <exclude/>
	public class CaseInChat_CaseEventsProcess : CaseInChat_CaseEventsProcess<CaseInChat>
	{

		public CaseInChat_CaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: CaseInChat_CaseEventsProcess

	public partial class CaseInChat_CaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: CaseInChatEventsProcess

	/// <exclude/>
	public class CaseInChatEventsProcess : CaseInChat_CaseEventsProcess
	{

		public CaseInChatEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

