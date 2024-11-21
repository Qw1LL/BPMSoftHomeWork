namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Process;
	using BPMSoft.Core.Process.Configuration;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Drawing;
	using System.Globalization;
	using System.IO;

	#region Class: UsrTransportRequestsFileSchema

	/// <exclude/>
	public class UsrTransportRequestsFileSchema : BPMSoft.Configuration.FileSchema
	{

		#region Constructors: Public

		public UsrTransportRequestsFileSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public UsrTransportRequestsFileSchema(UsrTransportRequestsFileSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public UsrTransportRequestsFileSchema(UsrTransportRequestsFileSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("3b3a0505-70d0-4be1-96b8-0138b891f9d5");
			RealUId = new Guid("3b3a0505-70d0-4be1-96b8-0138b891f9d5");
			Name = "UsrTransportRequestsFile";
			ParentSchemaUId = new Guid("556c5867-60a7-4456-aae1-a57a122bef70");
			ExtendParent = false;
			CreatedInPackageId = new Guid("3c4d067d-156b-4f1a-95fd-baa9da73b631");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("9c77204e-90a3-4743-afa4-f65d4d601236")) == null) {
				Columns.Add(CreateUsrTransportRequestsColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateUsrTransportRequestsColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("9c77204e-90a3-4743-afa4-f65d4d601236"),
				Name = @"UsrTransportRequests",
				ReferenceSchemaUId = new Guid("ce3557cf-4e38-45eb-aa71-502879d15cd5"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsValueCloneable = false,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("3b3a0505-70d0-4be1-96b8-0138b891f9d5"),
				ModifiedInSchemaUId = new Guid("3b3a0505-70d0-4be1-96b8-0138b891f9d5"),
				CreatedInPackageId = new Guid("3c4d067d-156b-4f1a-95fd-baa9da73b631")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new UsrTransportRequestsFile(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new UsrTransportRequestsFile_UsrHomeWorkEventsProcess(userConnection);
		}

		public override object Clone() {
			return new UsrTransportRequestsFileSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new UsrTransportRequestsFileSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("3b3a0505-70d0-4be1-96b8-0138b891f9d5"));
		}

		#endregion

	}

	#endregion

	#region Class: UsrTransportRequestsFile

	/// <summary>
	/// Файл и ссылка объекта Заявки на транспорт.
	/// </summary>
	public class UsrTransportRequestsFile : BPMSoft.Configuration.File
	{

		#region Constructors: Public

		public UsrTransportRequestsFile(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "UsrTransportRequestsFile";
		}

		public UsrTransportRequestsFile(UsrTransportRequestsFile source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid UsrTransportRequestsId {
			get {
				return GetTypedColumnValue<Guid>("UsrTransportRequestsId");
			}
			set {
				SetColumnValue("UsrTransportRequestsId", value);
				_usrTransportRequests = null;
			}
		}

		/// <exclude/>
		public string UsrTransportRequestsUsrName {
			get {
				return GetTypedColumnValue<string>("UsrTransportRequestsUsrName");
			}
			set {
				SetColumnValue("UsrTransportRequestsUsrName", value);
				if (_usrTransportRequests != null) {
					_usrTransportRequests.UsrName = value;
				}
			}
		}

		private UsrTransportRequests _usrTransportRequests;
		/// <summary>
		/// Заявки на транспорт.
		/// </summary>
		public UsrTransportRequests UsrTransportRequests {
			get {
				return _usrTransportRequests ??
					(_usrTransportRequests = LookupColumnEntities.GetEntity("UsrTransportRequests") as UsrTransportRequests);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new UsrTransportRequestsFile_UsrHomeWorkEventsProcess(UserConnection);
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
			return new UsrTransportRequestsFile(this);
		}

		#endregion

	}

	#endregion

	#region Class: UsrTransportRequestsFile_UsrHomeWorkEventsProcess

	/// <exclude/>
	public partial class UsrTransportRequestsFile_UsrHomeWorkEventsProcess<TEntity> : BPMSoft.Configuration.File_PRMPortalEventsProcess<TEntity> where TEntity : UsrTransportRequestsFile
	{

		public UsrTransportRequestsFile_UsrHomeWorkEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "UsrTransportRequestsFile_UsrHomeWorkEventsProcess";
			SchemaUId = new Guid("3b3a0505-70d0-4be1-96b8-0138b891f9d5");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("3b3a0505-70d0-4be1-96b8-0138b891f9d5");
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

	#region Class: UsrTransportRequestsFile_UsrHomeWorkEventsProcess

	/// <exclude/>
	public class UsrTransportRequestsFile_UsrHomeWorkEventsProcess : UsrTransportRequestsFile_UsrHomeWorkEventsProcess<UsrTransportRequestsFile>
	{

		public UsrTransportRequestsFile_UsrHomeWorkEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: UsrTransportRequestsFile_UsrHomeWorkEventsProcess

	public partial class UsrTransportRequestsFile_UsrHomeWorkEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: UsrTransportRequestsFileEventsProcess

	/// <exclude/>
	public class UsrTransportRequestsFileEventsProcess : UsrTransportRequestsFile_UsrHomeWorkEventsProcess
	{

		public UsrTransportRequestsFileEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

