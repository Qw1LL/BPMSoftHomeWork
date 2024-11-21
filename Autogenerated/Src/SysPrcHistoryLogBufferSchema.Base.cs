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

	#region Class: SysPrcHistoryLogBufferSchema

	/// <exclude/>
	public class SysPrcHistoryLogBufferSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysPrcHistoryLogBufferSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysPrcHistoryLogBufferSchema(SysPrcHistoryLogBufferSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysPrcHistoryLogBufferSchema(SysPrcHistoryLogBufferSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("65dafc94-5071-4869-bff3-d1e5ab46da9d");
			RealUId = new Guid("65dafc94-5071-4869-bff3-d1e5ab46da9d");
			Name = "SysPrcHistoryLogBuffer";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("920a417a-9c96-40b0-b7b5-e7da9902441a");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("0ae8de85-b07a-4f01-800f-8f629e3efeb8")) == null) {
				Columns.Add(CreateSessionIdColumn());
			}
			if (Columns.FindByUId(new Guid("3de5a168-ad2d-4185-8cb4-87b78b55e412")) == null) {
				Columns.Add(CreateSysProcessLogIdColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateSessionIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("0ae8de85-b07a-4f01-800f-8f629e3efeb8"),
				Name = @"SessionId",
				CreatedInSchemaUId = new Guid("65dafc94-5071-4869-bff3-d1e5ab46da9d"),
				ModifiedInSchemaUId = new Guid("65dafc94-5071-4869-bff3-d1e5ab46da9d"),
				CreatedInPackageId = new Guid("920a417a-9c96-40b0-b7b5-e7da9902441a")
			};
		}

		protected virtual EntitySchemaColumn CreateSysProcessLogIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("3de5a168-ad2d-4185-8cb4-87b78b55e412"),
				Name = @"SysProcessLogId",
				CreatedInSchemaUId = new Guid("65dafc94-5071-4869-bff3-d1e5ab46da9d"),
				ModifiedInSchemaUId = new Guid("65dafc94-5071-4869-bff3-d1e5ab46da9d"),
				CreatedInPackageId = new Guid("920a417a-9c96-40b0-b7b5-e7da9902441a")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysPrcHistoryLogBuffer(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysPrcHistoryLogBuffer_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysPrcHistoryLogBufferSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysPrcHistoryLogBufferSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("65dafc94-5071-4869-bff3-d1e5ab46da9d"));
		}

		#endregion

	}

	#endregion

	#region Class: SysPrcHistoryLogBuffer

	/// <summary>
	/// SysPrcHistoryLogBuffer.
	/// </summary>
	public class SysPrcHistoryLogBuffer : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysPrcHistoryLogBuffer(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysPrcHistoryLogBuffer";
		}

		public SysPrcHistoryLogBuffer(SysPrcHistoryLogBuffer source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// SessionId.
		/// </summary>
		public string SessionId {
			get {
				return GetTypedColumnValue<string>("SessionId");
			}
			set {
				SetColumnValue("SessionId", value);
			}
		}

		/// <summary>
		/// SysProcessLogId.
		/// </summary>
		public Guid SysProcessLogId {
			get {
				return GetTypedColumnValue<Guid>("SysProcessLogId");
			}
			set {
				SetColumnValue("SysProcessLogId", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysPrcHistoryLogBuffer_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysPrcHistoryLogBufferDeleted", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysPrcHistoryLogBuffer(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysPrcHistoryLogBuffer_BaseEventsProcess

	/// <exclude/>
	public partial class SysPrcHistoryLogBuffer_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : SysPrcHistoryLogBuffer
	{

		public SysPrcHistoryLogBuffer_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysPrcHistoryLogBuffer_BaseEventsProcess";
			SchemaUId = new Guid("65dafc94-5071-4869-bff3-d1e5ab46da9d");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("65dafc94-5071-4869-bff3-d1e5ab46da9d");
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

	#region Class: SysPrcHistoryLogBuffer_BaseEventsProcess

	/// <exclude/>
	public class SysPrcHistoryLogBuffer_BaseEventsProcess : SysPrcHistoryLogBuffer_BaseEventsProcess<SysPrcHistoryLogBuffer>
	{

		public SysPrcHistoryLogBuffer_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysPrcHistoryLogBuffer_BaseEventsProcess

	public partial class SysPrcHistoryLogBuffer_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysPrcHistoryLogBufferEventsProcess

	/// <exclude/>
	public class SysPrcHistoryLogBufferEventsProcess : SysPrcHistoryLogBuffer_BaseEventsProcess
	{

		public SysPrcHistoryLogBufferEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

