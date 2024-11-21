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

	#region Class: MessageNotifierSchema

	/// <exclude/>
	public class MessageNotifierSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public MessageNotifierSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public MessageNotifierSchema(MessageNotifierSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public MessageNotifierSchema(MessageNotifierSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("eb2f5124-c41f-4166-9caf-7986912ddea1");
			RealUId = new Guid("eb2f5124-c41f-4166-9caf-7986912ddea1");
			Name = "MessageNotifier";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("b4ad7210-1e2c-4a25-8f9c-bff818d48783");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("2a5346ce-f19d-422b-9d06-9a69306dd1e7")) == null) {
				Columns.Add(CreateSchemaUIdColumn());
			}
			if (Columns.FindByUId(new Guid("68ae74cb-f83c-4045-8c08-571a8cb14e3c")) == null) {
				Columns.Add(CreateClassNameColumn());
			}
			if (Columns.FindByUId(new Guid("9e57967a-c59f-44cf-9de7-e2a479b23b99")) == null) {
				Columns.Add(CreateAliasNotifierColumn());
			}
			if (Columns.FindByUId(new Guid("7394ca7d-c56a-4b06-89f4-528efb99bbaf")) == null) {
				Columns.Add(CreateHistoryV2ClassNameColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateSchemaUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("2a5346ce-f19d-422b-9d06-9a69306dd1e7"),
				Name = @"SchemaUId",
				CreatedInSchemaUId = new Guid("eb2f5124-c41f-4166-9caf-7986912ddea1"),
				ModifiedInSchemaUId = new Guid("eb2f5124-c41f-4166-9caf-7986912ddea1"),
				CreatedInPackageId = new Guid("4a46c73e-2533-4fb4-8b08-c16580add3d1")
			};
		}

		protected virtual EntitySchemaColumn CreateClassNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("68ae74cb-f83c-4045-8c08-571a8cb14e3c"),
				Name = @"ClassName",
				CreatedInSchemaUId = new Guid("eb2f5124-c41f-4166-9caf-7986912ddea1"),
				ModifiedInSchemaUId = new Guid("eb2f5124-c41f-4166-9caf-7986912ddea1"),
				CreatedInPackageId = new Guid("cf777bca-d84e-40ce-8c41-2703b994b306")
			};
		}

		protected virtual EntitySchemaColumn CreateAliasNotifierColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("9e57967a-c59f-44cf-9de7-e2a479b23b99"),
				Name = @"AliasNotifier",
				ReferenceSchemaUId = new Guid("eb2f5124-c41f-4166-9caf-7986912ddea1"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("eb2f5124-c41f-4166-9caf-7986912ddea1"),
				ModifiedInSchemaUId = new Guid("eb2f5124-c41f-4166-9caf-7986912ddea1"),
				CreatedInPackageId = new Guid("551ff8bf-18bd-4379-8fbe-82352d67eff4")
			};
		}

		protected virtual EntitySchemaColumn CreateHistoryV2ClassNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("7394ca7d-c56a-4b06-89f4-528efb99bbaf"),
				Name = @"HistoryV2ClassName",
				CreatedInSchemaUId = new Guid("eb2f5124-c41f-4166-9caf-7986912ddea1"),
				ModifiedInSchemaUId = new Guid("eb2f5124-c41f-4166-9caf-7986912ddea1"),
				CreatedInPackageId = new Guid("551ff8bf-18bd-4379-8fbe-82352d67eff4")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new MessageNotifier(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new MessageNotifier_MessageEventsProcess(userConnection);
		}

		public override object Clone() {
			return new MessageNotifierSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new MessageNotifierSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("eb2f5124-c41f-4166-9caf-7986912ddea1"));
		}

		#endregion

	}

	#endregion

	#region Class: MessageNotifier

	/// <summary>
	/// Message notifier.
	/// </summary>
	public class MessageNotifier : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public MessageNotifier(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "MessageNotifier";
		}

		public MessageNotifier(MessageNotifier source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Notifier schema.
		/// </summary>
		public Guid SchemaUId {
			get {
				return GetTypedColumnValue<Guid>("SchemaUId");
			}
			set {
				SetColumnValue("SchemaUId", value);
			}
		}

		/// <summary>
		/// Class name.
		/// </summary>
		public string ClassName {
			get {
				return GetTypedColumnValue<string>("ClassName");
			}
			set {
				SetColumnValue("ClassName", value);
			}
		}

		/// <exclude/>
		public Guid AliasNotifierId {
			get {
				return GetTypedColumnValue<Guid>("AliasNotifierId");
			}
			set {
				SetColumnValue("AliasNotifierId", value);
				_aliasNotifier = null;
			}
		}

		/// <exclude/>
		public string AliasNotifierName {
			get {
				return GetTypedColumnValue<string>("AliasNotifierName");
			}
			set {
				SetColumnValue("AliasNotifierName", value);
				if (_aliasNotifier != null) {
					_aliasNotifier.Name = value;
				}
			}
		}

		private MessageNotifier _aliasNotifier;
		/// <summary>
		/// AliasNotifier.
		/// </summary>
		public MessageNotifier AliasNotifier {
			get {
				return _aliasNotifier ??
					(_aliasNotifier = LookupColumnEntities.GetEntity("AliasNotifier") as MessageNotifier);
			}
		}

		/// <summary>
		/// Class name for MessageHistoryV2.
		/// </summary>
		public string HistoryV2ClassName {
			get {
				return GetTypedColumnValue<string>("HistoryV2ClassName");
			}
			set {
				SetColumnValue("HistoryV2ClassName", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new MessageNotifier_MessageEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("MessageNotifierDeleted", e);
			Validating += (s, e) => ThrowEvent("MessageNotifierValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new MessageNotifier(this);
		}

		#endregion

	}

	#endregion

	#region Class: MessageNotifier_MessageEventsProcess

	/// <exclude/>
	public partial class MessageNotifier_MessageEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : MessageNotifier
	{

		public MessageNotifier_MessageEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "MessageNotifier_MessageEventsProcess";
			SchemaUId = new Guid("eb2f5124-c41f-4166-9caf-7986912ddea1");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("eb2f5124-c41f-4166-9caf-7986912ddea1");
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

	#region Class: MessageNotifier_MessageEventsProcess

	/// <exclude/>
	public class MessageNotifier_MessageEventsProcess : MessageNotifier_MessageEventsProcess<MessageNotifier>
	{

		public MessageNotifier_MessageEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: MessageNotifier_MessageEventsProcess

	public partial class MessageNotifier_MessageEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: MessageNotifierEventsProcess

	/// <exclude/>
	public class MessageNotifierEventsProcess : MessageNotifier_MessageEventsProcess
	{

		public MessageNotifierEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

