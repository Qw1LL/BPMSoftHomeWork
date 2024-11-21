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

	#region Class: PartnershipInFolderSchema

	/// <exclude/>
	public class PartnershipInFolderSchema : BPMSoft.Configuration.PartnershipInFolder_PRMBase_BPMSoftSchema
	{

		#region Constructors: Public

		public PartnershipInFolderSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public PartnershipInFolderSchema(PartnershipInFolderSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public PartnershipInFolderSchema(PartnershipInFolderSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("af7a9c7b-e5d0-49f4-a8ad-b0de43660aa7");
			Name = "PartnershipInFolder";
			ParentSchemaUId = new Guid("2011fdb8-5e22-4693-8fd7-ac7ae635d19b");
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
			return new PartnershipInFolder(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new PartnershipInFolder_PRMPortalEventsProcess(userConnection);
		}

		public override object Clone() {
			return new PartnershipInFolderSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new PartnershipInFolderSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("af7a9c7b-e5d0-49f4-a8ad-b0de43660aa7"));
		}

		#endregion

	}

	#endregion

	#region Class: PartnershipInFolder

	/// <summary>
	/// Partnership in Folder.
	/// </summary>
	public class PartnershipInFolder : BPMSoft.Configuration.PartnershipInFolder_PRMBase_BPMSoft
	{

		#region Constructors: Public

		public PartnershipInFolder(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "PartnershipInFolder";
		}

		public PartnershipInFolder(PartnershipInFolder source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new PartnershipInFolder_PRMPortalEventsProcess(UserConnection);
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
			return new PartnershipInFolder(this);
		}

		#endregion

	}

	#endregion

	#region Class: PartnershipInFolder_PRMPortalEventsProcess

	/// <exclude/>
	public partial class PartnershipInFolder_PRMPortalEventsProcess<TEntity> : BPMSoft.Configuration.PartnershipInFolder_PRMBaseEventsProcess<TEntity> where TEntity : PartnershipInFolder
	{

		public PartnershipInFolder_PRMPortalEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "PartnershipInFolder_PRMPortalEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("af7a9c7b-e5d0-49f4-a8ad-b0de43660aa7");
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

	#region Class: PartnershipInFolder_PRMPortalEventsProcess

	/// <exclude/>
	public class PartnershipInFolder_PRMPortalEventsProcess : PartnershipInFolder_PRMPortalEventsProcess<PartnershipInFolder>
	{

		public PartnershipInFolder_PRMPortalEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: PartnershipInFolder_PRMPortalEventsProcess

	public partial class PartnershipInFolder_PRMPortalEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: PartnershipInFolderEventsProcess

	/// <exclude/>
	public class PartnershipInFolderEventsProcess : PartnershipInFolder_PRMPortalEventsProcess
	{

		public PartnershipInFolderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

