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

	#region Class: SysWorkplaceTypeSchema

	/// <exclude/>
	public class SysWorkplaceTypeSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public SysWorkplaceTypeSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysWorkplaceTypeSchema(SysWorkplaceTypeSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysWorkplaceTypeSchema(SysWorkplaceTypeSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("fa47b7e0-90e2-4763-93c7-ca0b6ea935c5");
			RealUId = new Guid("fa47b7e0-90e2-4763-93c7-ca0b6ea935c5");
			Name = "SysWorkplaceType";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("d9c4378b-4458-41ff-9d84-e4b071fcce18");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("da4fe6c7-4217-4104-8613-3f77ef74f93e")) == null) {
				Columns.Add(CreateCodeColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateCodeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("da4fe6c7-4217-4104-8613-3f77ef74f93e"),
				Name = @"Code",
				CreatedInSchemaUId = new Guid("fa47b7e0-90e2-4763-93c7-ca0b6ea935c5"),
				ModifiedInSchemaUId = new Guid("fa47b7e0-90e2-4763-93c7-ca0b6ea935c5"),
				CreatedInPackageId = new Guid("d9c4378b-4458-41ff-9d84-e4b071fcce18")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysWorkplaceType(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysWorkplaceType_NUIEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysWorkplaceTypeSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysWorkplaceTypeSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("fa47b7e0-90e2-4763-93c7-ca0b6ea935c5"));
		}

		#endregion

	}

	#endregion

	#region Class: SysWorkplaceType

	/// <summary>
	/// Workplace type.
	/// </summary>
	public class SysWorkplaceType : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public SysWorkplaceType(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysWorkplaceType";
		}

		public SysWorkplaceType(SysWorkplaceType source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Code.
		/// </summary>
		public int Code {
			get {
				return GetTypedColumnValue<int>("Code");
			}
			set {
				SetColumnValue("Code", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysWorkplaceType_NUIEventsProcess(UserConnection);
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
			return new SysWorkplaceType(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysWorkplaceType_NUIEventsProcess

	/// <exclude/>
	public partial class SysWorkplaceType_NUIEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : SysWorkplaceType
	{

		public SysWorkplaceType_NUIEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysWorkplaceType_NUIEventsProcess";
			SchemaUId = new Guid("fa47b7e0-90e2-4763-93c7-ca0b6ea935c5");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("fa47b7e0-90e2-4763-93c7-ca0b6ea935c5");
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

	#region Class: SysWorkplaceType_NUIEventsProcess

	/// <exclude/>
	public class SysWorkplaceType_NUIEventsProcess : SysWorkplaceType_NUIEventsProcess<SysWorkplaceType>
	{

		public SysWorkplaceType_NUIEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysWorkplaceType_NUIEventsProcess

	public partial class SysWorkplaceType_NUIEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysWorkplaceTypeEventsProcess

	/// <exclude/>
	public class SysWorkplaceTypeEventsProcess : SysWorkplaceType_NUIEventsProcess
	{

		public SysWorkplaceTypeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

