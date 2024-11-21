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

	#region Class: VwSysDcmLibSchema

	/// <exclude/>
	public class VwSysDcmLibSchema : BPMSoft.Configuration.VwSysDcmLib_DcmDesigner_BPMSoftSchema
	{

		#region Constructors: Public

		public VwSysDcmLibSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwSysDcmLibSchema(VwSysDcmLibSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwSysDcmLibSchema(VwSysDcmLibSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("fab81128-a5f7-4522-b60c-88fb44f9abe0");
			Name = "VwSysDcmLib";
			ParentSchemaUId = new Guid("ab972a77-ca14-4dd4-9d90-eaaae8b1197a");
			ExtendParent = true;
			CreatedInPackageId = new Guid("2b000645-6072-461d-8963-11edfee86881");
			IsDBView = true;
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
			return new VwSysDcmLib(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwSysDcmLib_PRMPortalEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwSysDcmLibSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwSysDcmLibSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("fab81128-a5f7-4522-b60c-88fb44f9abe0"));
		}

		#endregion

	}

	#endregion

	#region Class: VwSysDcmLib

	/// <summary>
	/// Библиотека кейсов (представление).
	/// </summary>
	public class VwSysDcmLib : BPMSoft.Configuration.VwSysDcmLib_DcmDesigner_BPMSoft
	{

		#region Constructors: Public

		public VwSysDcmLib(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwSysDcmLib";
		}

		public VwSysDcmLib(VwSysDcmLib source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new VwSysDcmLib_PRMPortalEventsProcess(UserConnection);
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
			return new VwSysDcmLib(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwSysDcmLib_PRMPortalEventsProcess

	/// <exclude/>
	public partial class VwSysDcmLib_PRMPortalEventsProcess<TEntity> : BPMSoft.Configuration.VwSysDcmLib_DcmDesignerEventsProcess<TEntity> where TEntity : VwSysDcmLib
	{

		public VwSysDcmLib_PRMPortalEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwSysDcmLib_PRMPortalEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("fab81128-a5f7-4522-b60c-88fb44f9abe0");
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

	#region Class: VwSysDcmLib_PRMPortalEventsProcess

	/// <exclude/>
	public class VwSysDcmLib_PRMPortalEventsProcess : VwSysDcmLib_PRMPortalEventsProcess<VwSysDcmLib>
	{

		public VwSysDcmLib_PRMPortalEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VwSysDcmLib_PRMPortalEventsProcess

	public partial class VwSysDcmLib_PRMPortalEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: VwSysDcmLibEventsProcess

	/// <exclude/>
	public class VwSysDcmLibEventsProcess : VwSysDcmLib_PRMPortalEventsProcess
	{

		public VwSysDcmLibEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

