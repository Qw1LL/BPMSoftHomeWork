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

	#region Class: MessagePublisherSchema

	/// <exclude/>
	public class MessagePublisherSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public MessagePublisherSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public MessagePublisherSchema(MessagePublisherSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public MessagePublisherSchema(MessagePublisherSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("ab702f57-7428-4bae-8b60-25747782d3c3");
			RealUId = new Guid("ab702f57-7428-4bae-8b60-25747782d3c3");
			Name = "MessagePublisher";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("7c74fc90-4a57-4e68-9eda-fe0982d1250d");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("137f41d7-dc81-4ca2-9903-60aa4a3f5d17")) == null) {
				Columns.Add(CreateClassNameColumn());
			}
			if (Columns.FindByUId(new Guid("d31ebb3a-ebda-4066-a2fa-dd1148354378")) == null) {
				Columns.Add(CreateImageColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateClassNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("137f41d7-dc81-4ca2-9903-60aa4a3f5d17"),
				Name = @"ClassName",
				CreatedInSchemaUId = new Guid("ab702f57-7428-4bae-8b60-25747782d3c3"),
				ModifiedInSchemaUId = new Guid("ab702f57-7428-4bae-8b60-25747782d3c3"),
				CreatedInPackageId = new Guid("7c74fc90-4a57-4e68-9eda-fe0982d1250d")
			};
		}

		protected virtual EntitySchemaColumn CreateImageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ImageLookup")) {
				UId = new Guid("d31ebb3a-ebda-4066-a2fa-dd1148354378"),
				Name = @"Image",
				ReferenceSchemaUId = new Guid("93986bfe-2dbd-46bc-9bf9-d03dfefbf3b8"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("ab702f57-7428-4bae-8b60-25747782d3c3"),
				ModifiedInSchemaUId = new Guid("ab702f57-7428-4bae-8b60-25747782d3c3"),
				CreatedInPackageId = new Guid("bb2c42c0-e64b-4a5a-977f-d65a958d0d94")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new MessagePublisher(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new MessagePublisher_MessagePublisherEventsProcess(userConnection);
		}

		public override object Clone() {
			return new MessagePublisherSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new MessagePublisherSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ab702f57-7428-4bae-8b60-25747782d3c3"));
		}

		#endregion

	}

	#endregion

	#region Class: MessagePublisher

	/// <summary>
	/// Message publisher.
	/// </summary>
	public class MessagePublisher : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public MessagePublisher(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "MessagePublisher";
		}

		public MessagePublisher(MessagePublisher source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

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
		public Guid ImageId {
			get {
				return GetTypedColumnValue<Guid>("ImageId");
			}
			set {
				SetColumnValue("ImageId", value);
				_image = null;
			}
		}

		/// <exclude/>
		public string ImageName {
			get {
				return GetTypedColumnValue<string>("ImageName");
			}
			set {
				SetColumnValue("ImageName", value);
				if (_image != null) {
					_image.Name = value;
				}
			}
		}

		private SysImage _image;
		/// <summary>
		/// Pictogram.
		/// </summary>
		public SysImage Image {
			get {
				return _image ??
					(_image = LookupColumnEntities.GetEntity("Image") as SysImage);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new MessagePublisher_MessagePublisherEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("MessagePublisherDeleted", e);
			Validating += (s, e) => ThrowEvent("MessagePublisherValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new MessagePublisher(this);
		}

		#endregion

	}

	#endregion

	#region Class: MessagePublisher_MessagePublisherEventsProcess

	/// <exclude/>
	public partial class MessagePublisher_MessagePublisherEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : MessagePublisher
	{

		public MessagePublisher_MessagePublisherEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "MessagePublisher_MessagePublisherEventsProcess";
			SchemaUId = new Guid("ab702f57-7428-4bae-8b60-25747782d3c3");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("ab702f57-7428-4bae-8b60-25747782d3c3");
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

	#region Class: MessagePublisher_MessagePublisherEventsProcess

	/// <exclude/>
	public class MessagePublisher_MessagePublisherEventsProcess : MessagePublisher_MessagePublisherEventsProcess<MessagePublisher>
	{

		public MessagePublisher_MessagePublisherEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: MessagePublisher_MessagePublisherEventsProcess

	public partial class MessagePublisher_MessagePublisherEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: MessagePublisherEventsProcess

	/// <exclude/>
	public class MessagePublisherEventsProcess : MessagePublisher_MessagePublisherEventsProcess
	{

		public MessagePublisherEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

