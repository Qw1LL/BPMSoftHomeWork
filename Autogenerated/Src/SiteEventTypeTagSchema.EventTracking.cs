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
	using System.Security;
	using TSConfiguration = BPMSoft.Configuration;

	#region Class: SiteEventTypeTagSchema

	/// <exclude/>
	public class SiteEventTypeTagSchema : BPMSoft.Configuration.BaseTagSchema
	{

		#region Constructors: Public

		public SiteEventTypeTagSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SiteEventTypeTagSchema(SiteEventTypeTagSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SiteEventTypeTagSchema(SiteEventTypeTagSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("3e628a72-8770-4b42-841a-5eadf01323ce");
			RealUId = new Guid("3e628a72-8770-4b42-841a-5eadf01323ce");
			Name = "SiteEventTypeTag";
			ParentSchemaUId = new Guid("9e3f203c-e905-4de5-9468-335b193f2439");
			ExtendParent = false;
			CreatedInPackageId = new Guid("dfe2c6b5-61e8-4e57-95ae-a3c34fa0908f");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override EntitySchemaColumn CreateTypeColumn() {
			EntitySchemaColumn column = base.CreateTypeColumn();
			column.DefValue = new EntitySchemaColumnDef() {
				Source = EntitySchemaColumnDefSource.Const,
				ValueSource = @"8d7f6d6c-4ca5-4b43-bdd9-a5e01a582260"
			};
			column.ModifiedInSchemaUId = new Guid("3e628a72-8770-4b42-841a-5eadf01323ce");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SiteEventTypeTag(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SiteEventTypeTag_EventTrackingEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SiteEventTypeTagSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SiteEventTypeTagSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("3e628a72-8770-4b42-841a-5eadf01323ce"));
		}

		#endregion

	}

	#endregion

	#region Class: SiteEventTypeTag

	/// <summary>
	/// Тег события сайта.
	/// </summary>
	public class SiteEventTypeTag : BPMSoft.Configuration.BaseTag
	{

		#region Constructors: Public

		public SiteEventTypeTag(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SiteEventTypeTag";
		}

		public SiteEventTypeTag(SiteEventTypeTag source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SiteEventTypeTag_EventTrackingEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SiteEventTypeTagDeleted", e);
			Validating += (s, e) => ThrowEvent("SiteEventTypeTagValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SiteEventTypeTag(this);
		}

		#endregion

	}

	#endregion

	#region Class: SiteEventTypeTag_EventTrackingEventsProcess

	/// <exclude/>
	public partial class SiteEventTypeTag_EventTrackingEventsProcess<TEntity> : BPMSoft.Configuration.BaseTag_SSPEventsProcess<TEntity> where TEntity : SiteEventTypeTag
	{

		public SiteEventTypeTag_EventTrackingEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SiteEventTypeTag_EventTrackingEventsProcess";
			SchemaUId = new Guid("3e628a72-8770-4b42-841a-5eadf01323ce");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("3e628a72-8770-4b42-841a-5eadf01323ce");
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

	#region Class: SiteEventTypeTag_EventTrackingEventsProcess

	/// <exclude/>
	public class SiteEventTypeTag_EventTrackingEventsProcess : SiteEventTypeTag_EventTrackingEventsProcess<SiteEventTypeTag>
	{

		public SiteEventTypeTag_EventTrackingEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SiteEventTypeTag_EventTrackingEventsProcess

	public partial class SiteEventTypeTag_EventTrackingEventsProcess<TEntity>
	{

		#region Methods: Public

		public override void CheckTagTypeAndGrantAdditionalRights() {
			base.CheckTagTypeAndGrantAdditionalRights();
			Guid typeId = Entity.GetTypedColumnValue<Guid>("TypeId");
			if (typeId == TSConfiguration.TagConsts.PublicTagTypeUId) {
				UserConnection.DBSecurityEngine.SetEntitySchemaRecordRightLevel(TSConfiguration.BaseConsts.PortalUsersSysAdminUnitUId, 
						Entity.Schema, Entity.PrimaryColumnValue, SchemaRecordRightLevels.All); 
			}
		}

		#endregion

	}

	#endregion


	#region Class: SiteEventTypeTagEventsProcess

	/// <exclude/>
	public class SiteEventTypeTagEventsProcess : SiteEventTypeTag_EventTrackingEventsProcess
	{

		public SiteEventTypeTagEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

