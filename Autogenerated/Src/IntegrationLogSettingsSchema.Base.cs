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

	#region Class: IntegrationLogSettingsSchema

	/// <exclude/>
	public class IntegrationLogSettingsSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public IntegrationLogSettingsSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public IntegrationLogSettingsSchema(IntegrationLogSettingsSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public IntegrationLogSettingsSchema(IntegrationLogSettingsSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("d41b758f-ec04-4be1-acac-57aefc390e1c");
			RealUId = new Guid("d41b758f-ec04-4be1-acac-57aefc390e1c");
			Name = "IntegrationLogSettings";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("ef60919a-1688-4087-afbe-36938255a73f")) == null) {
				Columns.Add(CreateIntegrationSystemColumn());
			}
			if (Columns.FindByUId(new Guid("a006163f-036e-4b0b-850f-c18d0c23f722")) == null) {
				Columns.Add(CreateDoLogColumn());
			}
			if (Columns.FindByUId(new Guid("c66c13ba-3337-4379-babb-2f3b42786bcc")) == null) {
				Columns.Add(CreateLogOnlyErrorsColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateIntegrationSystemColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("ef60919a-1688-4087-afbe-36938255a73f"),
				Name = @"IntegrationSystem",
				ReferenceSchemaUId = new Guid("673fd68f-fe84-465a-a2d3-ff7bd824b22f"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("d41b758f-ec04-4be1-acac-57aefc390e1c"),
				ModifiedInSchemaUId = new Guid("d41b758f-ec04-4be1-acac-57aefc390e1c"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateDoLogColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("a006163f-036e-4b0b-850f-c18d0c23f722"),
				Name = @"DoLog",
				CreatedInSchemaUId = new Guid("d41b758f-ec04-4be1-acac-57aefc390e1c"),
				ModifiedInSchemaUId = new Guid("d41b758f-ec04-4be1-acac-57aefc390e1c"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateLogOnlyErrorsColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("c66c13ba-3337-4379-babb-2f3b42786bcc"),
				Name = @"LogOnlyErrors",
				CreatedInSchemaUId = new Guid("d41b758f-ec04-4be1-acac-57aefc390e1c"),
				ModifiedInSchemaUId = new Guid("d41b758f-ec04-4be1-acac-57aefc390e1c"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new IntegrationLogSettings(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new IntegrationLogSettings_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new IntegrationLogSettingsSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new IntegrationLogSettingsSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("d41b758f-ec04-4be1-acac-57aefc390e1c"));
		}

		#endregion

	}

	#endregion

	#region Class: IntegrationLogSettings

	/// <summary>
	/// Integration log settings.
	/// </summary>
	public class IntegrationLogSettings : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public IntegrationLogSettings(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "IntegrationLogSettings";
		}

		public IntegrationLogSettings(IntegrationLogSettings source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid IntegrationSystemId {
			get {
				return GetTypedColumnValue<Guid>("IntegrationSystemId");
			}
			set {
				SetColumnValue("IntegrationSystemId", value);
				_integrationSystem = null;
			}
		}

		/// <exclude/>
		public string IntegrationSystemName {
			get {
				return GetTypedColumnValue<string>("IntegrationSystemName");
			}
			set {
				SetColumnValue("IntegrationSystemName", value);
				if (_integrationSystem != null) {
					_integrationSystem.Name = value;
				}
			}
		}

		private IntegrationSystem _integrationSystem;
		/// <summary>
		/// Integration system.
		/// </summary>
		public IntegrationSystem IntegrationSystem {
			get {
				return _integrationSystem ??
					(_integrationSystem = LookupColumnEntities.GetEntity("IntegrationSystem") as IntegrationSystem);
			}
		}

		/// <summary>
		/// Enable logging.
		/// </summary>
		public bool DoLog {
			get {
				return GetTypedColumnValue<bool>("DoLog");
			}
			set {
				SetColumnValue("DoLog", value);
			}
		}

		/// <summary>
		/// Log only errors.
		/// </summary>
		public bool LogOnlyErrors {
			get {
				return GetTypedColumnValue<bool>("LogOnlyErrors");
			}
			set {
				SetColumnValue("LogOnlyErrors", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new IntegrationLogSettings_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("IntegrationLogSettingsDeleted", e);
			Inserting += (s, e) => ThrowEvent("IntegrationLogSettingsInserting", e);
			Validating += (s, e) => ThrowEvent("IntegrationLogSettingsValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new IntegrationLogSettings(this);
		}

		#endregion

	}

	#endregion

	#region Class: IntegrationLogSettings_BaseEventsProcess

	/// <exclude/>
	public partial class IntegrationLogSettings_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : IntegrationLogSettings
	{

		public IntegrationLogSettings_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "IntegrationLogSettings_BaseEventsProcess";
			SchemaUId = new Guid("d41b758f-ec04-4be1-acac-57aefc390e1c");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("d41b758f-ec04-4be1-acac-57aefc390e1c");
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

	#region Class: IntegrationLogSettings_BaseEventsProcess

	/// <exclude/>
	public class IntegrationLogSettings_BaseEventsProcess : IntegrationLogSettings_BaseEventsProcess<IntegrationLogSettings>
	{

		public IntegrationLogSettings_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: IntegrationLogSettings_BaseEventsProcess

	public partial class IntegrationLogSettings_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: IntegrationLogSettingsEventsProcess

	/// <exclude/>
	public class IntegrationLogSettingsEventsProcess : IntegrationLogSettings_BaseEventsProcess
	{

		public IntegrationLogSettingsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

