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

	#region Class: LeadFolderSchema

	/// <exclude/>
	public class LeadFolderSchema : BPMSoft.Configuration.LeadFolder_Lead_BPMSoftSchema
	{

		#region Constructors: Public

		public LeadFolderSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public LeadFolderSchema(LeadFolderSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public LeadFolderSchema(LeadFolderSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("dfb4f8a6-bd9c-41b7-aafc-d9a777150370");
			Name = "LeadFolder";
			ParentSchemaUId = new Guid("48847f5c-6429-400f-abb8-0a753473b5d8");
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
			return new LeadFolder(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new LeadFolder_PRMPortalEventsProcess(userConnection);
		}

		public override object Clone() {
			return new LeadFolderSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new LeadFolderSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("dfb4f8a6-bd9c-41b7-aafc-d9a777150370"));
		}

		#endregion

	}

	#endregion

	#region Class: LeadFolder

	/// <summary>
	/// Группа лида.
	/// </summary>
	public class LeadFolder : BPMSoft.Configuration.LeadFolder_Lead_BPMSoft
	{

		#region Constructors: Public

		public LeadFolder(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "LeadFolder";
		}

		public LeadFolder(LeadFolder source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new LeadFolder_PRMPortalEventsProcess(UserConnection);
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
			return new LeadFolder(this);
		}

		#endregion

	}

	#endregion

	#region Class: LeadFolder_PRMPortalEventsProcess

	/// <exclude/>
	public partial class LeadFolder_PRMPortalEventsProcess<TEntity> : BPMSoft.Configuration.LeadFolder_LeadEventsProcess<TEntity> where TEntity : LeadFolder
	{

		public LeadFolder_PRMPortalEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "LeadFolder_PRMPortalEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("dfb4f8a6-bd9c-41b7-aafc-d9a777150370");
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

	#region Class: LeadFolder_PRMPortalEventsProcess

	/// <exclude/>
	public class LeadFolder_PRMPortalEventsProcess : LeadFolder_PRMPortalEventsProcess<LeadFolder>
	{

		public LeadFolder_PRMPortalEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: LeadFolder_PRMPortalEventsProcess

	public partial class LeadFolder_PRMPortalEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: LeadFolderEventsProcess

	/// <exclude/>
	public class LeadFolderEventsProcess : LeadFolder_PRMPortalEventsProcess
	{

		public LeadFolderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

