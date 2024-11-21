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

	#region Class: CommunicationTypeSchema

	/// <exclude/>
	public class CommunicationTypeSchema : BPMSoft.Configuration.CommunicationType_Base_BPMSoftSchema
	{

		#region Constructors: Public

		public CommunicationTypeSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public CommunicationTypeSchema(CommunicationTypeSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public CommunicationTypeSchema(CommunicationTypeSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("f72b5dab-734c-4f33-9adc-aec8210db2d6");
			Name = "CommunicationType";
			ParentSchemaUId = new Guid("d846cb4f-f18d-469e-83ff-e961f3fba873");
			ExtendParent = true;
			CreatedInPackageId = new Guid("d7352345-17a4-46e8-b32e-306ac0453d7a");
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
			return new CommunicationType(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new CommunicationType_SSPEventsProcess(userConnection);
		}

		public override object Clone() {
			return new CommunicationTypeSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new CommunicationTypeSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("f72b5dab-734c-4f33-9adc-aec8210db2d6"));
		}

		#endregion

	}

	#endregion

	#region Class: CommunicationType

	/// <summary>
	/// Communication option type.
	/// </summary>
	public class CommunicationType : BPMSoft.Configuration.CommunicationType_Base_BPMSoft
	{

		#region Constructors: Public

		public CommunicationType(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "CommunicationType";
		}

		public CommunicationType(CommunicationType source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new CommunicationType_SSPEventsProcess(UserConnection);
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
			return new CommunicationType(this);
		}

		#endregion

	}

	#endregion

	#region Class: CommunicationType_SSPEventsProcess

	/// <exclude/>
	public partial class CommunicationType_SSPEventsProcess<TEntity> : BPMSoft.Configuration.CommunicationType_BaseEventsProcess<TEntity> where TEntity : CommunicationType
	{

		public CommunicationType_SSPEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "CommunicationType_SSPEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("f72b5dab-734c-4f33-9adc-aec8210db2d6");
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

	#region Class: CommunicationType_SSPEventsProcess

	/// <exclude/>
	public class CommunicationType_SSPEventsProcess : CommunicationType_SSPEventsProcess<CommunicationType>
	{

		public CommunicationType_SSPEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: CommunicationType_SSPEventsProcess

	public partial class CommunicationType_SSPEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: CommunicationTypeEventsProcess

	/// <exclude/>
	public class CommunicationTypeEventsProcess : CommunicationType_SSPEventsProcess
	{

		public CommunicationTypeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

