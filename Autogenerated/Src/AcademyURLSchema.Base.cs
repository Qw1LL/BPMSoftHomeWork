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

	#region Class: AcademyURLSchema

	/// <exclude/>
	public class AcademyURLSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public AcademyURLSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public AcademyURLSchema(AcademyURLSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public AcademyURLSchema(AcademyURLSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("2db09028-bfa5-4314-929d-0f149f348452");
			RealUId = new Guid("2db09028-bfa5-4314-929d-0f149f348452");
			Name = "AcademyURL";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2");
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
			return new AcademyURL(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new AcademyURL_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new AcademyURLSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new AcademyURLSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("2db09028-bfa5-4314-929d-0f149f348452"));
		}

		#endregion

	}

	#endregion

	#region Class: AcademyURL

	/// <summary>
	/// URL.
	/// </summary>
	public class AcademyURL : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public AcademyURL(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "AcademyURL";
		}

		public AcademyURL(AcademyURL source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new AcademyURL_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("AcademyURLDeleted", e);
			Validating += (s, e) => ThrowEvent("AcademyURLValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new AcademyURL(this);
		}

		#endregion

	}

	#endregion

	#region Class: AcademyURL_BaseEventsProcess

	/// <exclude/>
	public partial class AcademyURL_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : AcademyURL
	{

		public AcademyURL_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "AcademyURL_BaseEventsProcess";
			SchemaUId = new Guid("2db09028-bfa5-4314-929d-0f149f348452");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("2db09028-bfa5-4314-929d-0f149f348452");
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

	#region Class: AcademyURL_BaseEventsProcess

	/// <exclude/>
	public class AcademyURL_BaseEventsProcess : AcademyURL_BaseEventsProcess<AcademyURL>
	{

		public AcademyURL_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: AcademyURL_BaseEventsProcess

	public partial class AcademyURL_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: AcademyURLEventsProcess

	/// <exclude/>
	public class AcademyURLEventsProcess : AcademyURL_BaseEventsProcess
	{

		public AcademyURLEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

