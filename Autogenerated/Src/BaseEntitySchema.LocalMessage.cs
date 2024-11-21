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

	#region Class: BaseEntitySchema

	/// <exclude/>
	[IsVirtual]
	public class BaseEntitySchema : BPMSoft.Configuration.BaseEntity_Base_BPMSoftSchema
	{

		#region Constructors: Public

		public BaseEntitySchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public BaseEntitySchema(BaseEntitySchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public BaseEntitySchema(BaseEntitySchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("9c45d7dc-ce98-489a-85cd-3b4023f89a0b");
			Name = "BaseEntity";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = true;
			CreatedInPackageId = new Guid("3644c994-8f85-41ec-8125-47013bac161f");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new BaseEntity(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new BaseEntity_LocalMessageEventsProcess(userConnection);
		}

		public override object Clone() {
			return new BaseEntitySchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new BaseEntitySchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("9c45d7dc-ce98-489a-85cd-3b4023f89a0b"));
		}

		#endregion

	}

	#endregion

	#region Class: BaseEntity

	/// <summary>
	/// Базовый объект.
	/// </summary>
	public class BaseEntity : BPMSoft.Configuration.BaseEntity_Base_BPMSoft
	{

		#region Constructors: Public

		public BaseEntity(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "BaseEntity";
		}

		public BaseEntity(BaseEntity source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new BaseEntity_LocalMessageEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("BaseEntityDeleted", e);
			Validating += (s, e) => ThrowEvent("BaseEntityValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new BaseEntity(this);
		}

		#endregion

	}

	#endregion

	#region Class: BaseEntity_LocalMessageEventsProcess

	/// <exclude/>
	public partial class BaseEntity_LocalMessageEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_BaseEventsProcess<TEntity> where TEntity : BaseEntity
	{

		public BaseEntity_LocalMessageEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "BaseEntity_LocalMessageEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("9c45d7dc-ce98-489a-85cd-3b4023f89a0b");
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

	#region Class: BaseEntity_LocalMessageEventsProcess

	/// <exclude/>
	public class BaseEntity_LocalMessageEventsProcess : BaseEntity_LocalMessageEventsProcess<BaseEntity>
	{

		public BaseEntity_LocalMessageEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: BaseEntity_LocalMessageEventsProcess

	public partial class BaseEntity_LocalMessageEventsProcess<TEntity>
	{

		#region Methods: Public

		public override void LocalMessageExecuting(EntityChangeType changeType) {
			var lmHelper = new BPMSoft.Configuration.LocalMessageHelper(this.Entity, UserConnection, changeType);
			lmHelper.CreateLocalMessage();
		}

		#endregion

	}

	#endregion


	#region Class: BaseEntityEventsProcess

	/// <exclude/>
	public class BaseEntityEventsProcess : BaseEntity_LocalMessageEventsProcess
	{

		public BaseEntityEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

