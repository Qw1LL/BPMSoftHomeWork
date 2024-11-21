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

	#region Class: VwDeclarerCommentsSchema

	/// <exclude/>
	public class VwDeclarerCommentsSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public VwDeclarerCommentsSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwDeclarerCommentsSchema(VwDeclarerCommentsSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwDeclarerCommentsSchema(VwDeclarerCommentsSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("e3fd1a49-0d7f-4ea9-bc1b-926034936078");
			RealUId = new Guid("e3fd1a49-0d7f-4ea9-bc1b-926034936078");
			Name = "VwDeclarerComments";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("526529f2-b020-48ad-83c6-024fb6de520e");
			IsDBView = true;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("8f9aa3c9-abac-42c1-98c4-e94b7d78086c")) == null) {
				Columns.Add(CreateTypeColumn());
			}
			if (Columns.FindByUId(new Guid("19fac79f-f72c-4721-88a4-985c089cecec")) == null) {
				Columns.Add(CreateMessageColumn());
			}
			if (Columns.FindByUId(new Guid("e921e822-17b0-42c4-b913-1b3719061089")) == null) {
				Columns.Add(CreateCaseColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("8f9aa3c9-abac-42c1-98c4-e94b7d78086c"),
				Name = @"Type",
				ReferenceSchemaUId = new Guid("ceb61101-7562-4107-bf84-9dfb310c1c1c"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("e3fd1a49-0d7f-4ea9-bc1b-926034936078"),
				ModifiedInSchemaUId = new Guid("e3fd1a49-0d7f-4ea9-bc1b-926034936078"),
				CreatedInPackageId = new Guid("526529f2-b020-48ad-83c6-024fb6de520e")
			};
		}

		protected virtual EntitySchemaColumn CreateMessageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("19fac79f-f72c-4721-88a4-985c089cecec"),
				Name = @"Message",
				CreatedInSchemaUId = new Guid("e3fd1a49-0d7f-4ea9-bc1b-926034936078"),
				ModifiedInSchemaUId = new Guid("e3fd1a49-0d7f-4ea9-bc1b-926034936078"),
				CreatedInPackageId = new Guid("526529f2-b020-48ad-83c6-024fb6de520e")
			};
		}

		protected virtual EntitySchemaColumn CreateCaseColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("e921e822-17b0-42c4-b913-1b3719061089"),
				Name = @"Case",
				ReferenceSchemaUId = new Guid("117d32f9-8275-4534-8411-1c66115ce9cd"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("e3fd1a49-0d7f-4ea9-bc1b-926034936078"),
				ModifiedInSchemaUId = new Guid("e3fd1a49-0d7f-4ea9-bc1b-926034936078"),
				CreatedInPackageId = new Guid("526529f2-b020-48ad-83c6-024fb6de520e")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new VwDeclarerComments(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwDeclarerComments_PortalEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwDeclarerCommentsSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwDeclarerCommentsSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("e3fd1a49-0d7f-4ea9-bc1b-926034936078"));
		}

		#endregion

	}

	#endregion

	#region Class: VwDeclarerComments

	/// <summary>
	/// Отзывы заявителя.
	/// </summary>
	public class VwDeclarerComments : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public VwDeclarerComments(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwDeclarerComments";
		}

		public VwDeclarerComments(VwDeclarerComments source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid TypeId {
			get {
				return GetTypedColumnValue<Guid>("TypeId");
			}
			set {
				SetColumnValue("TypeId", value);
				_type = null;
			}
		}

		/// <exclude/>
		public string TypeName {
			get {
				return GetTypedColumnValue<string>("TypeName");
			}
			set {
				SetColumnValue("TypeName", value);
				if (_type != null) {
					_type.Name = value;
				}
			}
		}

		private PortalMessageType _type;
		/// <summary>
		/// Тип сообщения.
		/// </summary>
		public PortalMessageType Type {
			get {
				return _type ??
					(_type = LookupColumnEntities.GetEntity("Type") as PortalMessageType);
			}
		}

		/// <summary>
		/// Сообщение.
		/// </summary>
		public string Message {
			get {
				return GetTypedColumnValue<string>("Message");
			}
			set {
				SetColumnValue("Message", value);
			}
		}

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

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new VwDeclarerComments_PortalEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("VwDeclarerCommentsDeleted", e);
			Validating += (s, e) => ThrowEvent("VwDeclarerCommentsValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new VwDeclarerComments(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwDeclarerComments_PortalEventsProcess

	/// <exclude/>
	public partial class VwDeclarerComments_PortalEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : VwDeclarerComments
	{

		public VwDeclarerComments_PortalEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwDeclarerComments_PortalEventsProcess";
			SchemaUId = new Guid("e3fd1a49-0d7f-4ea9-bc1b-926034936078");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("e3fd1a49-0d7f-4ea9-bc1b-926034936078");
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

	#region Class: VwDeclarerComments_PortalEventsProcess

	/// <exclude/>
	public class VwDeclarerComments_PortalEventsProcess : VwDeclarerComments_PortalEventsProcess<VwDeclarerComments>
	{

		public VwDeclarerComments_PortalEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VwDeclarerComments_PortalEventsProcess

	public partial class VwDeclarerComments_PortalEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: VwDeclarerCommentsEventsProcess

	/// <exclude/>
	public class VwDeclarerCommentsEventsProcess : VwDeclarerComments_PortalEventsProcess
	{

		public VwDeclarerCommentsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

