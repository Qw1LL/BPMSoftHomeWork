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

	#region Class: LeadMediumCodeSchema

	/// <exclude/>
	public class LeadMediumCodeSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public LeadMediumCodeSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public LeadMediumCodeSchema(LeadMediumCodeSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public LeadMediumCodeSchema(LeadMediumCodeSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("0f4d70a7-b105-4ea6-a59f-4cae51d0e650");
			RealUId = new Guid("0f4d70a7-b105-4ea6-a59f-4cae51d0e650");
			Name = "LeadMediumCode";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("6cdbb516-9811-46ca-a4f8-441ae8e11086");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateCodeColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("23816c2e-6cc4-48c0-9f50-6b2f3da8d975")) == null) {
				Columns.Add(CreateLeadMediumColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateCodeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("866d31ee-6af9-4f46-94f1-a1996cb2b763"),
				Name = @"Code",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("0f4d70a7-b105-4ea6-a59f-4cae51d0e650"),
				ModifiedInSchemaUId = new Guid("0f4d70a7-b105-4ea6-a59f-4cae51d0e650"),
				CreatedInPackageId = new Guid("6cdbb516-9811-46ca-a4f8-441ae8e11086")
			};
		}

		protected virtual EntitySchemaColumn CreateLeadMediumColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("23816c2e-6cc4-48c0-9f50-6b2f3da8d975"),
				Name = @"LeadMedium",
				ReferenceSchemaUId = new Guid("308ef8cd-4f4f-4898-9b3d-36ab9af01f5c"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("0f4d70a7-b105-4ea6-a59f-4cae51d0e650"),
				ModifiedInSchemaUId = new Guid("0f4d70a7-b105-4ea6-a59f-4cae51d0e650"),
				CreatedInPackageId = new Guid("6cdbb516-9811-46ca-a4f8-441ae8e11086")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new LeadMediumCode(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new LeadMediumCode_TouchPointsEventsProcess(userConnection);
		}

		public override object Clone() {
			return new LeadMediumCodeSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new LeadMediumCodeSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("0f4d70a7-b105-4ea6-a59f-4cae51d0e650"));
		}

		#endregion

	}

	#endregion

	#region Class: LeadMediumCode

	/// <summary>
	/// Channel code.
	/// </summary>
	public class LeadMediumCode : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public LeadMediumCode(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "LeadMediumCode";
		}

		public LeadMediumCode(LeadMediumCode source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Channel code.
		/// </summary>
		public string Code {
			get {
				return GetTypedColumnValue<string>("Code");
			}
			set {
				SetColumnValue("Code", value);
			}
		}

		/// <exclude/>
		public Guid LeadMediumId {
			get {
				return GetTypedColumnValue<Guid>("LeadMediumId");
			}
			set {
				SetColumnValue("LeadMediumId", value);
				_leadMedium = null;
			}
		}

		/// <exclude/>
		public string LeadMediumName {
			get {
				return GetTypedColumnValue<string>("LeadMediumName");
			}
			set {
				SetColumnValue("LeadMediumName", value);
				if (_leadMedium != null) {
					_leadMedium.Name = value;
				}
			}
		}

		private LeadMedium _leadMedium;
		/// <summary>
		/// Lead channel.
		/// </summary>
		public LeadMedium LeadMedium {
			get {
				return _leadMedium ??
					(_leadMedium = LookupColumnEntities.GetEntity("LeadMedium") as LeadMedium);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new LeadMediumCode_TouchPointsEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("LeadMediumCodeDeleted", e);
			Validating += (s, e) => ThrowEvent("LeadMediumCodeValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new LeadMediumCode(this);
		}

		#endregion

	}

	#endregion

	#region Class: LeadMediumCode_TouchPointsEventsProcess

	/// <exclude/>
	public partial class LeadMediumCode_TouchPointsEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : LeadMediumCode
	{

		public LeadMediumCode_TouchPointsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "LeadMediumCode_TouchPointsEventsProcess";
			SchemaUId = new Guid("0f4d70a7-b105-4ea6-a59f-4cae51d0e650");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("0f4d70a7-b105-4ea6-a59f-4cae51d0e650");
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

	#region Class: LeadMediumCode_TouchPointsEventsProcess

	/// <exclude/>
	public class LeadMediumCode_TouchPointsEventsProcess : LeadMediumCode_TouchPointsEventsProcess<LeadMediumCode>
	{

		public LeadMediumCode_TouchPointsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: LeadMediumCode_TouchPointsEventsProcess

	public partial class LeadMediumCode_TouchPointsEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: LeadMediumCodeEventsProcess

	/// <exclude/>
	public class LeadMediumCodeEventsProcess : LeadMediumCode_TouchPointsEventsProcess
	{

		public LeadMediumCodeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

