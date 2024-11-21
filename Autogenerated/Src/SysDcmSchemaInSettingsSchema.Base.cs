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

	#region Class: SysDcmSchemaInSettings_Base_BPMSoftSchema

	/// <exclude/>
	public class SysDcmSchemaInSettings_Base_BPMSoftSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysDcmSchemaInSettings_Base_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysDcmSchemaInSettings_Base_BPMSoftSchema(SysDcmSchemaInSettings_Base_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysDcmSchemaInSettings_Base_BPMSoftSchema(SysDcmSchemaInSettings_Base_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("91b4bc57-8490-442f-9036-62eaefe28ef0");
			RealUId = new Guid("91b4bc57-8490-442f-9036-62eaefe28ef0");
			Name = "SysDcmSchemaInSettings_Base_BPMSoft";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("60220118-8883-44e1-afa4-8845f944d697");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("a18861e7-c840-4cae-9dd6-30277b513dc9")) == null) {
				Columns.Add(CreateSysDcmSettingsColumn());
			}
			if (Columns.FindByUId(new Guid("cec2ae4b-d2de-4c80-99a0-a59dc2a154cd")) == null) {
				Columns.Add(CreateSysDcmSchemaUIdColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateSysDcmSettingsColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("a18861e7-c840-4cae-9dd6-30277b513dc9"),
				Name = @"SysDcmSettings",
				ReferenceSchemaUId = new Guid("ee9f7e0e-eab3-45ba-ae0d-67ab41858d5c"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("91b4bc57-8490-442f-9036-62eaefe28ef0"),
				ModifiedInSchemaUId = new Guid("91b4bc57-8490-442f-9036-62eaefe28ef0"),
				CreatedInPackageId = new Guid("60220118-8883-44e1-afa4-8845f944d697")
			};
		}

		protected virtual EntitySchemaColumn CreateSysDcmSchemaUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("cec2ae4b-d2de-4c80-99a0-a59dc2a154cd"),
				Name = @"SysDcmSchemaUId",
				CreatedInSchemaUId = new Guid("91b4bc57-8490-442f-9036-62eaefe28ef0"),
				ModifiedInSchemaUId = new Guid("91b4bc57-8490-442f-9036-62eaefe28ef0"),
				CreatedInPackageId = new Guid("60220118-8883-44e1-afa4-8845f944d697")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysDcmSchemaInSettings_Base_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysDcmSchemaInSettings_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysDcmSchemaInSettings_Base_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysDcmSchemaInSettings_Base_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("91b4bc57-8490-442f-9036-62eaefe28ef0"));
		}

		#endregion

	}

	#endregion

	#region Class: SysDcmSchemaInSettings_Base_BPMSoft

	/// <summary>
	/// SysDcmSchemaInSettings.
	/// </summary>
	public class SysDcmSchemaInSettings_Base_BPMSoft : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysDcmSchemaInSettings_Base_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysDcmSchemaInSettings_Base_BPMSoft";
		}

		public SysDcmSchemaInSettings_Base_BPMSoft(SysDcmSchemaInSettings_Base_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid SysDcmSettingsId {
			get {
				return GetTypedColumnValue<Guid>("SysDcmSettingsId");
			}
			set {
				SetColumnValue("SysDcmSettingsId", value);
				_sysDcmSettings = null;
			}
		}

		private SysDcmSettings _sysDcmSettings;
		/// <summary>
		/// Case schema settings.
		/// </summary>
		public SysDcmSettings SysDcmSettings {
			get {
				return _sysDcmSettings ??
					(_sysDcmSettings = LookupColumnEntities.GetEntity("SysDcmSettings") as SysDcmSettings);
			}
		}

		/// <summary>
		/// Case schema identifier.
		/// </summary>
		public Guid SysDcmSchemaUId {
			get {
				return GetTypedColumnValue<Guid>("SysDcmSchemaUId");
			}
			set {
				SetColumnValue("SysDcmSchemaUId", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysDcmSchemaInSettings_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysDcmSchemaInSettings_Base_BPMSoftDeleted", e);
			Validating += (s, e) => ThrowEvent("SysDcmSchemaInSettings_Base_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysDcmSchemaInSettings_Base_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysDcmSchemaInSettings_BaseEventsProcess

	/// <exclude/>
	public partial class SysDcmSchemaInSettings_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : SysDcmSchemaInSettings_Base_BPMSoft
	{

		public SysDcmSchemaInSettings_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysDcmSchemaInSettings_BaseEventsProcess";
			SchemaUId = new Guid("91b4bc57-8490-442f-9036-62eaefe28ef0");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("91b4bc57-8490-442f-9036-62eaefe28ef0");
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

	#region Class: SysDcmSchemaInSettings_BaseEventsProcess

	/// <exclude/>
	public class SysDcmSchemaInSettings_BaseEventsProcess : SysDcmSchemaInSettings_BaseEventsProcess<SysDcmSchemaInSettings_Base_BPMSoft>
	{

		public SysDcmSchemaInSettings_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysDcmSchemaInSettings_BaseEventsProcess

	public partial class SysDcmSchemaInSettings_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

