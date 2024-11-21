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

	#region Class: LeadSourceUrlSchema

	/// <exclude/>
	public class LeadSourceUrlSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public LeadSourceUrlSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public LeadSourceUrlSchema(LeadSourceUrlSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public LeadSourceUrlSchema(LeadSourceUrlSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("fcc57494-3b7f-4e80-98a9-27d2ce300e54");
			RealUId = new Guid("fcc57494-3b7f-4e80-98a9-27d2ce300e54");
			Name = "LeadSourceUrl";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("6cdbb516-9811-46ca-a4f8-441ae8e11086");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateURLColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("43d62c25-f556-408a-a317-1d66c32ec121")) == null) {
				Columns.Add(CreateLeadSourceColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateURLColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("4e5c6756-0f12-4176-b5d4-3c0d631db963"),
				Name = @"URL",
				CreatedInSchemaUId = new Guid("fcc57494-3b7f-4e80-98a9-27d2ce300e54"),
				ModifiedInSchemaUId = new Guid("fcc57494-3b7f-4e80-98a9-27d2ce300e54"),
				CreatedInPackageId = new Guid("6cdbb516-9811-46ca-a4f8-441ae8e11086")
			};
		}

		protected virtual EntitySchemaColumn CreateLeadSourceColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("43d62c25-f556-408a-a317-1d66c32ec121"),
				Name = @"LeadSource",
				ReferenceSchemaUId = new Guid("533025a5-cb29-46d5-935a-7e12616d69b6"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("fcc57494-3b7f-4e80-98a9-27d2ce300e54"),
				ModifiedInSchemaUId = new Guid("fcc57494-3b7f-4e80-98a9-27d2ce300e54"),
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
			return new LeadSourceUrl(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new LeadSourceUrl_TouchPointsEventsProcess(userConnection);
		}

		public override object Clone() {
			return new LeadSourceUrlSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new LeadSourceUrlSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("fcc57494-3b7f-4e80-98a9-27d2ce300e54"));
		}

		#endregion

	}

	#endregion

	#region Class: LeadSourceUrl

	/// <summary>
	/// Source URL.
	/// </summary>
	public class LeadSourceUrl : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public LeadSourceUrl(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "LeadSourceUrl";
		}

		public LeadSourceUrl(LeadSourceUrl source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// URL.
		/// </summary>
		public string URL {
			get {
				return GetTypedColumnValue<string>("URL");
			}
			set {
				SetColumnValue("URL", value);
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
		/// Source.
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
			var process = new LeadSourceUrl_TouchPointsEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("LeadSourceUrlDeleted", e);
			Validating += (s, e) => ThrowEvent("LeadSourceUrlValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new LeadSourceUrl(this);
		}

		#endregion

	}

	#endregion

	#region Class: LeadSourceUrl_TouchPointsEventsProcess

	/// <exclude/>
	public partial class LeadSourceUrl_TouchPointsEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : LeadSourceUrl
	{

		public LeadSourceUrl_TouchPointsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "LeadSourceUrl_TouchPointsEventsProcess";
			SchemaUId = new Guid("fcc57494-3b7f-4e80-98a9-27d2ce300e54");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("fcc57494-3b7f-4e80-98a9-27d2ce300e54");
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

	#region Class: LeadSourceUrl_TouchPointsEventsProcess

	/// <exclude/>
	public class LeadSourceUrl_TouchPointsEventsProcess : LeadSourceUrl_TouchPointsEventsProcess<LeadSourceUrl>
	{

		public LeadSourceUrl_TouchPointsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: LeadSourceUrl_TouchPointsEventsProcess

	public partial class LeadSourceUrl_TouchPointsEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: LeadSourceUrlEventsProcess

	/// <exclude/>
	public class LeadSourceUrlEventsProcess : LeadSourceUrl_TouchPointsEventsProcess
	{

		public LeadSourceUrlEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

