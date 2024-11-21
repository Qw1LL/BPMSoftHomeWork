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

	#region Class: MessageNotifierBySectionSchema

	/// <exclude/>
	public class MessageNotifierBySectionSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public MessageNotifierBySectionSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public MessageNotifierBySectionSchema(MessageNotifierBySectionSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public MessageNotifierBySectionSchema(MessageNotifierBySectionSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("f646b374-bdfc-4813-b87f-8fd6fef57878");
			RealUId = new Guid("f646b374-bdfc-4813-b87f-8fd6fef57878");
			Name = "MessageNotifierBySection";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("881e90eb-5097-4ba6-a5ff-3f5da8533efc");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("9b552f69-9629-42bc-8cb0-0b1df737f7de")) == null) {
				Columns.Add(CreateSectionColumn());
			}
			if (Columns.FindByUId(new Guid("2916fa01-0be9-43dc-b583-4691eb997d09")) == null) {
				Columns.Add(CreateMessageNotifierColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateSectionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("9b552f69-9629-42bc-8cb0-0b1df737f7de"),
				Name = @"Section",
				ReferenceSchemaUId = new Guid("2b2ed767-0b4b-4a7b-9de2-d48e14a2c0c5"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("f646b374-bdfc-4813-b87f-8fd6fef57878"),
				ModifiedInSchemaUId = new Guid("f646b374-bdfc-4813-b87f-8fd6fef57878"),
				CreatedInPackageId = new Guid("881e90eb-5097-4ba6-a5ff-3f5da8533efc")
			};
		}

		protected virtual EntitySchemaColumn CreateMessageNotifierColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("2916fa01-0be9-43dc-b583-4691eb997d09"),
				Name = @"MessageNotifier",
				ReferenceSchemaUId = new Guid("eb2f5124-c41f-4166-9caf-7986912ddea1"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("f646b374-bdfc-4813-b87f-8fd6fef57878"),
				ModifiedInSchemaUId = new Guid("f646b374-bdfc-4813-b87f-8fd6fef57878"),
				CreatedInPackageId = new Guid("881e90eb-5097-4ba6-a5ff-3f5da8533efc")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new MessageNotifierBySection(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new MessageNotifierBySection_MessageEventsProcess(userConnection);
		}

		public override object Clone() {
			return new MessageNotifierBySectionSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new MessageNotifierBySectionSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("f646b374-bdfc-4813-b87f-8fd6fef57878"));
		}

		#endregion

	}

	#endregion

	#region Class: MessageNotifierBySection

	/// <summary>
	/// Message notifier by section.
	/// </summary>
	public class MessageNotifierBySection : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public MessageNotifierBySection(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "MessageNotifierBySection";
		}

		public MessageNotifierBySection(MessageNotifierBySection source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid SectionId {
			get {
				return GetTypedColumnValue<Guid>("SectionId");
			}
			set {
				SetColumnValue("SectionId", value);
				_section = null;
			}
		}

		/// <exclude/>
		public string SectionCaption {
			get {
				return GetTypedColumnValue<string>("SectionCaption");
			}
			set {
				SetColumnValue("SectionCaption", value);
				if (_section != null) {
					_section.Caption = value;
				}
			}
		}

		private SysModule _section;
		/// <summary>
		/// Section.
		/// </summary>
		public SysModule Section {
			get {
				return _section ??
					(_section = LookupColumnEntities.GetEntity("Section") as SysModule);
			}
		}

		/// <exclude/>
		public Guid MessageNotifierId {
			get {
				return GetTypedColumnValue<Guid>("MessageNotifierId");
			}
			set {
				SetColumnValue("MessageNotifierId", value);
				_messageNotifier = null;
			}
		}

		/// <exclude/>
		public string MessageNotifierName {
			get {
				return GetTypedColumnValue<string>("MessageNotifierName");
			}
			set {
				SetColumnValue("MessageNotifierName", value);
				if (_messageNotifier != null) {
					_messageNotifier.Name = value;
				}
			}
		}

		private MessageNotifier _messageNotifier;
		/// <summary>
		/// Message notifier.
		/// </summary>
		public MessageNotifier MessageNotifier {
			get {
				return _messageNotifier ??
					(_messageNotifier = LookupColumnEntities.GetEntity("MessageNotifier") as MessageNotifier);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new MessageNotifierBySection_MessageEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("MessageNotifierBySectionDeleted", e);
			Validating += (s, e) => ThrowEvent("MessageNotifierBySectionValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new MessageNotifierBySection(this);
		}

		#endregion

	}

	#endregion

	#region Class: MessageNotifierBySection_MessageEventsProcess

	/// <exclude/>
	public partial class MessageNotifierBySection_MessageEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : MessageNotifierBySection
	{

		public MessageNotifierBySection_MessageEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "MessageNotifierBySection_MessageEventsProcess";
			SchemaUId = new Guid("f646b374-bdfc-4813-b87f-8fd6fef57878");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("f646b374-bdfc-4813-b87f-8fd6fef57878");
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

	#region Class: MessageNotifierBySection_MessageEventsProcess

	/// <exclude/>
	public class MessageNotifierBySection_MessageEventsProcess : MessageNotifierBySection_MessageEventsProcess<MessageNotifierBySection>
	{

		public MessageNotifierBySection_MessageEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: MessageNotifierBySection_MessageEventsProcess

	public partial class MessageNotifierBySection_MessageEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: MessageNotifierBySectionEventsProcess

	/// <exclude/>
	public class MessageNotifierBySectionEventsProcess : MessageNotifierBySection_MessageEventsProcess
	{

		public MessageNotifierBySectionEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

