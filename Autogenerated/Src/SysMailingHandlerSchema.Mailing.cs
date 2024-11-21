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

	#region Class: SysMailingHandlerSchema

	/// <exclude/>
	public class SysMailingHandlerSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysMailingHandlerSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysMailingHandlerSchema(SysMailingHandlerSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysMailingHandlerSchema(SysMailingHandlerSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("1d5a3605-19a8-41f1-816f-274d1fc85810");
			RealUId = new Guid("1d5a3605-19a8-41f1-816f-274d1fc85810");
			Name = "SysMailingHandler";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("0a66fb70-43c4-43cd-a81c-f036ca2264c0");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateNameColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("22f6954c-894d-4cd2-90ec-c6daf8741dc1")) == null) {
				Columns.Add(CreateClassNameColumn());
			}
			if (Columns.FindByUId(new Guid("34900cd7-9ad9-4d8b-85a2-2cfb0737e9ab")) == null) {
				Columns.Add(CreateProviderColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("24d948e8-b33f-4289-9854-3d48f47a3db1"),
				Name = @"Name",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("1d5a3605-19a8-41f1-816f-274d1fc85810"),
				ModifiedInSchemaUId = new Guid("1d5a3605-19a8-41f1-816f-274d1fc85810"),
				CreatedInPackageId = new Guid("0a66fb70-43c4-43cd-a81c-f036ca2264c0")
			};
		}

		protected virtual EntitySchemaColumn CreateClassNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("22f6954c-894d-4cd2-90ec-c6daf8741dc1"),
				Name = @"ClassName",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("1d5a3605-19a8-41f1-816f-274d1fc85810"),
				ModifiedInSchemaUId = new Guid("1d5a3605-19a8-41f1-816f-274d1fc85810"),
				CreatedInPackageId = new Guid("0a66fb70-43c4-43cd-a81c-f036ca2264c0")
			};
		}

		protected virtual EntitySchemaColumn CreateProviderColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("34900cd7-9ad9-4d8b-85a2-2cfb0737e9ab"),
				Name = @"Provider",
				ReferenceSchemaUId = new Guid("c650470d-0201-49dc-bcfb-c9744d7de1f2"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("1d5a3605-19a8-41f1-816f-274d1fc85810"),
				ModifiedInSchemaUId = new Guid("1d5a3605-19a8-41f1-816f-274d1fc85810"),
				CreatedInPackageId = new Guid("0a66fb70-43c4-43cd-a81c-f036ca2264c0")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysMailingHandler(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysMailingHandler_MailingEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysMailingHandlerSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysMailingHandlerSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("1d5a3605-19a8-41f1-816f-274d1fc85810"));
		}

		#endregion

	}

	#endregion

	#region Class: SysMailingHandler

	/// <summary>
	/// Обработчик рассылки.
	/// </summary>
	public class SysMailingHandler : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysMailingHandler(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysMailingHandler";
		}

		public SysMailingHandler(SysMailingHandler source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Название.
		/// </summary>
		public string Name {
			get {
				return GetTypedColumnValue<string>("Name");
			}
			set {
				SetColumnValue("Name", value);
			}
		}

		/// <summary>
		/// Имя класса.
		/// </summary>
		public string ClassName {
			get {
				return GetTypedColumnValue<string>("ClassName");
			}
			set {
				SetColumnValue("ClassName", value);
			}
		}

		/// <exclude/>
		public Guid ProviderId {
			get {
				return GetTypedColumnValue<Guid>("ProviderId");
			}
			set {
				SetColumnValue("ProviderId", value);
				_provider = null;
			}
		}

		/// <exclude/>
		public string ProviderName {
			get {
				return GetTypedColumnValue<string>("ProviderName");
			}
			set {
				SetColumnValue("ProviderName", value);
				if (_provider != null) {
					_provider.Name = value;
				}
			}
		}

		private SysMailingProvider _provider;
		/// <summary>
		/// Провайдер рассылок.
		/// </summary>
		public SysMailingProvider Provider {
			get {
				return _provider ??
					(_provider = LookupColumnEntities.GetEntity("Provider") as SysMailingProvider);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysMailingHandler_MailingEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysMailingHandlerDeleted", e);
			Validating += (s, e) => ThrowEvent("SysMailingHandlerValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysMailingHandler(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysMailingHandler_MailingEventsProcess

	/// <exclude/>
	public partial class SysMailingHandler_MailingEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : SysMailingHandler
	{

		public SysMailingHandler_MailingEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysMailingHandler_MailingEventsProcess";
			SchemaUId = new Guid("1d5a3605-19a8-41f1-816f-274d1fc85810");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("1d5a3605-19a8-41f1-816f-274d1fc85810");
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

	#region Class: SysMailingHandler_MailingEventsProcess

	/// <exclude/>
	public class SysMailingHandler_MailingEventsProcess : SysMailingHandler_MailingEventsProcess<SysMailingHandler>
	{

		public SysMailingHandler_MailingEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysMailingHandler_MailingEventsProcess

	public partial class SysMailingHandler_MailingEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysMailingHandlerEventsProcess

	/// <exclude/>
	public class SysMailingHandlerEventsProcess : SysMailingHandler_MailingEventsProcess
	{

		public SysMailingHandlerEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

