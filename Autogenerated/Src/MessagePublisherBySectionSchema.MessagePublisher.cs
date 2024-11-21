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

	#region Class: MessagePublisherBySectionSchema

	/// <exclude/>
	public class MessagePublisherBySectionSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public MessagePublisherBySectionSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public MessagePublisherBySectionSchema(MessagePublisherBySectionSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public MessagePublisherBySectionSchema(MessagePublisherBySectionSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("1bd40929-9ab9-40ad-9af7-d6abcab85bf8");
			RealUId = new Guid("1bd40929-9ab9-40ad-9af7-d6abcab85bf8");
			Name = "MessagePublisherBySection";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("7c74fc90-4a57-4e68-9eda-fe0982d1250d");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("e182df32-2660-448d-b97e-ce6721de888c")) == null) {
				Columns.Add(CreateSectionColumn());
			}
			if (Columns.FindByUId(new Guid("fb377f13-6cad-4a71-9f5a-064d198cb667")) == null) {
				Columns.Add(CreateMessagePublisherColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateSectionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("e182df32-2660-448d-b97e-ce6721de888c"),
				Name = @"Section",
				ReferenceSchemaUId = new Guid("2b2ed767-0b4b-4a7b-9de2-d48e14a2c0c5"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("1bd40929-9ab9-40ad-9af7-d6abcab85bf8"),
				ModifiedInSchemaUId = new Guid("1bd40929-9ab9-40ad-9af7-d6abcab85bf8"),
				CreatedInPackageId = new Guid("7c74fc90-4a57-4e68-9eda-fe0982d1250d")
			};
		}

		protected virtual EntitySchemaColumn CreateMessagePublisherColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("fb377f13-6cad-4a71-9f5a-064d198cb667"),
				Name = @"MessagePublisher",
				ReferenceSchemaUId = new Guid("ab702f57-7428-4bae-8b60-25747782d3c3"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("1bd40929-9ab9-40ad-9af7-d6abcab85bf8"),
				ModifiedInSchemaUId = new Guid("1bd40929-9ab9-40ad-9af7-d6abcab85bf8"),
				CreatedInPackageId = new Guid("7c74fc90-4a57-4e68-9eda-fe0982d1250d")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new MessagePublisherBySection(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new MessagePublisherBySection_MessagePublisherEventsProcess(userConnection);
		}

		public override object Clone() {
			return new MessagePublisherBySectionSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new MessagePublisherBySectionSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("1bd40929-9ab9-40ad-9af7-d6abcab85bf8"));
		}

		#endregion

	}

	#endregion

	#region Class: MessagePublisherBySection

	/// <summary>
	/// Message publisher by section.
	/// </summary>
	public class MessagePublisherBySection : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public MessagePublisherBySection(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "MessagePublisherBySection";
		}

		public MessagePublisherBySection(MessagePublisherBySection source)
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
		public Guid MessagePublisherId {
			get {
				return GetTypedColumnValue<Guid>("MessagePublisherId");
			}
			set {
				SetColumnValue("MessagePublisherId", value);
				_messagePublisher = null;
			}
		}

		/// <exclude/>
		public string MessagePublisherName {
			get {
				return GetTypedColumnValue<string>("MessagePublisherName");
			}
			set {
				SetColumnValue("MessagePublisherName", value);
				if (_messagePublisher != null) {
					_messagePublisher.Name = value;
				}
			}
		}

		private MessagePublisher _messagePublisher;
		/// <summary>
		/// Message publisher.
		/// </summary>
		public MessagePublisher MessagePublisher {
			get {
				return _messagePublisher ??
					(_messagePublisher = LookupColumnEntities.GetEntity("MessagePublisher") as MessagePublisher);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new MessagePublisherBySection_MessagePublisherEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("MessagePublisherBySectionDeleted", e);
			Validating += (s, e) => ThrowEvent("MessagePublisherBySectionValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new MessagePublisherBySection(this);
		}

		#endregion

	}

	#endregion

	#region Class: MessagePublisherBySection_MessagePublisherEventsProcess

	/// <exclude/>
	public partial class MessagePublisherBySection_MessagePublisherEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : MessagePublisherBySection
	{

		public MessagePublisherBySection_MessagePublisherEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "MessagePublisherBySection_MessagePublisherEventsProcess";
			SchemaUId = new Guid("1bd40929-9ab9-40ad-9af7-d6abcab85bf8");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("1bd40929-9ab9-40ad-9af7-d6abcab85bf8");
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

	#region Class: MessagePublisherBySection_MessagePublisherEventsProcess

	/// <exclude/>
	public class MessagePublisherBySection_MessagePublisherEventsProcess : MessagePublisherBySection_MessagePublisherEventsProcess<MessagePublisherBySection>
	{

		public MessagePublisherBySection_MessagePublisherEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: MessagePublisherBySection_MessagePublisherEventsProcess

	public partial class MessagePublisherBySection_MessagePublisherEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: MessagePublisherBySectionEventsProcess

	/// <exclude/>
	public class MessagePublisherBySectionEventsProcess : MessagePublisherBySection_MessagePublisherEventsProcess
	{

		public MessagePublisherBySectionEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

