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

	#region Class: PartnershipInTagSchema

	/// <exclude/>
	public class PartnershipInTagSchema : BPMSoft.Configuration.PartnershipInTag_PRMBase_BPMSoftSchema
	{

		#region Constructors: Public

		public PartnershipInTagSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public PartnershipInTagSchema(PartnershipInTagSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public PartnershipInTagSchema(PartnershipInTagSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("ad4a5cf8-f452-4ba6-8992-1ac54110a900");
			Name = "PartnershipInTag";
			ParentSchemaUId = new Guid("316899fa-2937-49df-89bf-d68fa0bc3a24");
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
			return new PartnershipInTag(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new PartnershipInTag_PRMPortalEventsProcess(userConnection);
		}

		public override object Clone() {
			return new PartnershipInTagSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new PartnershipInTagSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ad4a5cf8-f452-4ba6-8992-1ac54110a900"));
		}

		#endregion

	}

	#endregion

	#region Class: PartnershipInTag

	/// <summary>
	/// Partnership section record tag.
	/// </summary>
	public class PartnershipInTag : BPMSoft.Configuration.PartnershipInTag_PRMBase_BPMSoft
	{

		#region Constructors: Public

		public PartnershipInTag(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "PartnershipInTag";
		}

		public PartnershipInTag(PartnershipInTag source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new PartnershipInTag_PRMPortalEventsProcess(UserConnection);
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
			return new PartnershipInTag(this);
		}

		#endregion

	}

	#endregion

	#region Class: PartnershipInTag_PRMPortalEventsProcess

	/// <exclude/>
	public partial class PartnershipInTag_PRMPortalEventsProcess<TEntity> : BPMSoft.Configuration.PartnershipInTag_PRMBaseEventsProcess<TEntity> where TEntity : PartnershipInTag
	{

		public PartnershipInTag_PRMPortalEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "PartnershipInTag_PRMPortalEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("ad4a5cf8-f452-4ba6-8992-1ac54110a900");
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

	#region Class: PartnershipInTag_PRMPortalEventsProcess

	/// <exclude/>
	public class PartnershipInTag_PRMPortalEventsProcess : PartnershipInTag_PRMPortalEventsProcess<PartnershipInTag>
	{

		public PartnershipInTag_PRMPortalEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: PartnershipInTag_PRMPortalEventsProcess

	public partial class PartnershipInTag_PRMPortalEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: PartnershipInTagEventsProcess

	/// <exclude/>
	public class PartnershipInTagEventsProcess : PartnershipInTag_PRMPortalEventsProcess
	{

		public PartnershipInTagEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

