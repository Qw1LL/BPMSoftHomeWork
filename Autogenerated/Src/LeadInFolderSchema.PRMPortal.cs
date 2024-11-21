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

	#region Class: LeadInFolderSchema

	/// <exclude/>
	public class LeadInFolderSchema : BPMSoft.Configuration.LeadInFolder_Lead_BPMSoftSchema
	{

		#region Constructors: Public

		public LeadInFolderSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public LeadInFolderSchema(LeadInFolderSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public LeadInFolderSchema(LeadInFolderSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("2d5d7bb4-1588-41a9-9421-85ceac34e05c");
			Name = "LeadInFolder";
			ParentSchemaUId = new Guid("9fd3b56f-95f5-4bbd-adae-81a9a175940e");
			ExtendParent = true;
			CreatedInPackageId = new Guid("0fffc5a3-cd85-4e12-bfdb-f47322f14e3d");
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
			return new LeadInFolder(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new LeadInFolder_PRMPortalEventsProcess(userConnection);
		}

		public override object Clone() {
			return new LeadInFolderSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new LeadInFolderSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("2d5d7bb4-1588-41a9-9421-85ceac34e05c"));
		}

		#endregion

	}

	#endregion

	#region Class: LeadInFolder

	/// <summary>
	/// Лид в группе.
	/// </summary>
	public class LeadInFolder : BPMSoft.Configuration.LeadInFolder_Lead_BPMSoft
	{

		#region Constructors: Public

		public LeadInFolder(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "LeadInFolder";
		}

		public LeadInFolder(LeadInFolder source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new LeadInFolder_PRMPortalEventsProcess(UserConnection);
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
			return new LeadInFolder(this);
		}

		#endregion

	}

	#endregion

	#region Class: LeadInFolder_PRMPortalEventsProcess

	/// <exclude/>
	public partial class LeadInFolder_PRMPortalEventsProcess<TEntity> : BPMSoft.Configuration.LeadInFolder_LeadEventsProcess<TEntity> where TEntity : LeadInFolder
	{

		public LeadInFolder_PRMPortalEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "LeadInFolder_PRMPortalEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("2d5d7bb4-1588-41a9-9421-85ceac34e05c");
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

	#region Class: LeadInFolder_PRMPortalEventsProcess

	/// <exclude/>
	public class LeadInFolder_PRMPortalEventsProcess : LeadInFolder_PRMPortalEventsProcess<LeadInFolder>
	{

		public LeadInFolder_PRMPortalEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: LeadInFolder_PRMPortalEventsProcess

	public partial class LeadInFolder_PRMPortalEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: LeadInFolderEventsProcess

	/// <exclude/>
	public class LeadInFolderEventsProcess : LeadInFolder_PRMPortalEventsProcess
	{

		public LeadInFolderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

