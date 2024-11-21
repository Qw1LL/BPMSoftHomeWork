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

	#region Class: LeadSourceCodeSchema

	/// <exclude/>
	public class LeadSourceCodeSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public LeadSourceCodeSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public LeadSourceCodeSchema(LeadSourceCodeSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public LeadSourceCodeSchema(LeadSourceCodeSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("5bd98435-c110-445f-bbe0-5c82ff33ecf0");
			RealUId = new Guid("5bd98435-c110-445f-bbe0-5c82ff33ecf0");
			Name = "LeadSourceCode";
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
			if (Columns.FindByUId(new Guid("eaff5350-2082-4b05-b974-91565632fd19")) == null) {
				Columns.Add(CreateLeadSourceColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateCodeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("15bca0e1-acbe-4520-a72c-63433a560d45"),
				Name = @"Code",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("5bd98435-c110-445f-bbe0-5c82ff33ecf0"),
				ModifiedInSchemaUId = new Guid("5bd98435-c110-445f-bbe0-5c82ff33ecf0"),
				CreatedInPackageId = new Guid("6cdbb516-9811-46ca-a4f8-441ae8e11086")
			};
		}

		protected virtual EntitySchemaColumn CreateLeadSourceColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("eaff5350-2082-4b05-b974-91565632fd19"),
				Name = @"LeadSource",
				ReferenceSchemaUId = new Guid("533025a5-cb29-46d5-935a-7e12616d69b6"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("5bd98435-c110-445f-bbe0-5c82ff33ecf0"),
				ModifiedInSchemaUId = new Guid("5bd98435-c110-445f-bbe0-5c82ff33ecf0"),
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
			return new LeadSourceCode(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new LeadSourceCode_TouchPointsEventsProcess(userConnection);
		}

		public override object Clone() {
			return new LeadSourceCodeSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new LeadSourceCodeSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("5bd98435-c110-445f-bbe0-5c82ff33ecf0"));
		}

		#endregion

	}

	#endregion

	#region Class: LeadSourceCode

	/// <summary>
	/// Source code.
	/// </summary>
	public class LeadSourceCode : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public LeadSourceCode(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "LeadSourceCode";
		}

		public LeadSourceCode(LeadSourceCode source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Source code.
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
		public Guid LeadSourceId {
			get {
				return GetTypedColumnValue<Guid>("LeadSourceId");
			}
			set {
				SetColumnValue("LeadSourceId", value);
				_leadSource = null;
			}
		}

		/// <exclude/>
		public string LeadSourceName {
			get {
				return GetTypedColumnValue<string>("LeadSourceName");
			}
			set {
				SetColumnValue("LeadSourceName", value);
				if (_leadSource != null) {
					_leadSource.Name = value;
				}
			}
		}

		private LeadSource _leadSource;
		/// <summary>
		/// Lead source.
		/// </summary>
		public LeadSource LeadSource {
			get {
				return _leadSource ??
					(_leadSource = LookupColumnEntities.GetEntity("LeadSource") as LeadSource);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new LeadSourceCode_TouchPointsEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("LeadSourceCodeDeleted", e);
			Validating += (s, e) => ThrowEvent("LeadSourceCodeValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new LeadSourceCode(this);
		}

		#endregion

	}

	#endregion

	#region Class: LeadSourceCode_TouchPointsEventsProcess

	/// <exclude/>
	public partial class LeadSourceCode_TouchPointsEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : LeadSourceCode
	{

		public LeadSourceCode_TouchPointsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "LeadSourceCode_TouchPointsEventsProcess";
			SchemaUId = new Guid("5bd98435-c110-445f-bbe0-5c82ff33ecf0");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("5bd98435-c110-445f-bbe0-5c82ff33ecf0");
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

	#region Class: LeadSourceCode_TouchPointsEventsProcess

	/// <exclude/>
	public class LeadSourceCode_TouchPointsEventsProcess : LeadSourceCode_TouchPointsEventsProcess<LeadSourceCode>
	{

		public LeadSourceCode_TouchPointsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: LeadSourceCode_TouchPointsEventsProcess

	public partial class LeadSourceCode_TouchPointsEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: LeadSourceCodeEventsProcess

	/// <exclude/>
	public class LeadSourceCodeEventsProcess : LeadSourceCode_TouchPointsEventsProcess
	{

		public LeadSourceCodeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

