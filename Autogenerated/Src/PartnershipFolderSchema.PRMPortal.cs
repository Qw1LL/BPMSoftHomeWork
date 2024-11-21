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

	#region Class: PartnershipFolderSchema

	/// <exclude/>
	public class PartnershipFolderSchema : BPMSoft.Configuration.PartnershipFolder_PRMBase_BPMSoftSchema
	{

		#region Constructors: Public

		public PartnershipFolderSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public PartnershipFolderSchema(PartnershipFolderSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public PartnershipFolderSchema(PartnershipFolderSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("64459f99-79ae-4114-bf84-33fbd1f2a9ee");
			Name = "PartnershipFolder";
			ParentSchemaUId = new Guid("11d0998f-b8a2-4777-95eb-66043ddea0cd");
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
			return new PartnershipFolder(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new PartnershipFolder_PRMPortalEventsProcess(userConnection);
		}

		public override object Clone() {
			return new PartnershipFolderSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new PartnershipFolderSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("64459f99-79ae-4114-bf84-33fbd1f2a9ee"));
		}

		#endregion

	}

	#endregion

	#region Class: PartnershipFolder

	/// <summary>
	/// Partnership folder.
	/// </summary>
	public class PartnershipFolder : BPMSoft.Configuration.PartnershipFolder_PRMBase_BPMSoft
	{

		#region Constructors: Public

		public PartnershipFolder(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "PartnershipFolder";
		}

		public PartnershipFolder(PartnershipFolder source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new PartnershipFolder_PRMPortalEventsProcess(UserConnection);
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
			return new PartnershipFolder(this);
		}

		#endregion

	}

	#endregion

	#region Class: PartnershipFolder_PRMPortalEventsProcess

	/// <exclude/>
	public partial class PartnershipFolder_PRMPortalEventsProcess<TEntity> : BPMSoft.Configuration.PartnershipFolder_PRMBaseEventsProcess<TEntity> where TEntity : PartnershipFolder
	{

		public PartnershipFolder_PRMPortalEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "PartnershipFolder_PRMPortalEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("64459f99-79ae-4114-bf84-33fbd1f2a9ee");
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

	#region Class: PartnershipFolder_PRMPortalEventsProcess

	/// <exclude/>
	public class PartnershipFolder_PRMPortalEventsProcess : PartnershipFolder_PRMPortalEventsProcess<PartnershipFolder>
	{

		public PartnershipFolder_PRMPortalEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: PartnershipFolder_PRMPortalEventsProcess

	public partial class PartnershipFolder_PRMPortalEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: PartnershipFolderEventsProcess

	/// <exclude/>
	public class PartnershipFolderEventsProcess : PartnershipFolder_PRMPortalEventsProcess
	{

		public PartnershipFolderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

