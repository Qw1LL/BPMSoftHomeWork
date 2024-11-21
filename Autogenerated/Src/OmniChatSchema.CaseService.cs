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

	#region Class: OmniChat_CaseService_BPMSoftSchema

	/// <exclude/>
	public class OmniChat_CaseService_BPMSoftSchema : BPMSoft.Configuration.OmniChat_OmnichannelMessaging_BPMSoftSchema
	{

		#region Constructors: Public

		public OmniChat_CaseService_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public OmniChat_CaseService_BPMSoftSchema(OmniChat_CaseService_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public OmniChat_CaseService_BPMSoftSchema(OmniChat_CaseService_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("a84f47b6-cd3c-c88d-a912-836fcc39653a");
			Name = "OmniChat_CaseService_BPMSoft";
			ParentSchemaUId = new Guid("af1f685c-315b-4b44-a957-c5094417a57a");
			ExtendParent = true;
			CreatedInPackageId = new Guid("33bac096-c819-4c57-86af-fe71bbb0cb56");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("f0df491d-5d4d-a931-d796-8d95880c95c6")) == null) {
				Columns.Add(CreateCaseColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateCaseColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("f0df491d-5d4d-a931-d796-8d95880c95c6"),
				Name = @"Case",
				ReferenceSchemaUId = new Guid("117d32f9-8275-4534-8411-1c66115ce9cd"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("a84f47b6-cd3c-c88d-a912-836fcc39653a"),
				ModifiedInSchemaUId = new Guid("a84f47b6-cd3c-c88d-a912-836fcc39653a"),
				CreatedInPackageId = new Guid("33bac096-c819-4c57-86af-fe71bbb0cb56")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new OmniChat_CaseService_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new OmniChat_CaseServiceEventsProcess(userConnection);
		}

		public override object Clone() {
			return new OmniChat_CaseService_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new OmniChat_CaseService_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("a84f47b6-cd3c-c88d-a912-836fcc39653a"));
		}

		#endregion

	}

	#endregion

	#region Class: OmniChat_CaseService_BPMSoft

	/// <summary>
	/// Чат.
	/// </summary>
	public class OmniChat_CaseService_BPMSoft : BPMSoft.Configuration.OmniChat_OmnichannelMessaging_BPMSoft
	{

		#region Constructors: Public

		public OmniChat_CaseService_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "OmniChat_CaseService_BPMSoft";
		}

		public OmniChat_CaseService_BPMSoft(OmniChat_CaseService_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid CaseId {
			get {
				return GetTypedColumnValue<Guid>("CaseId");
			}
			set {
				SetColumnValue("CaseId", value);
				_case = null;
			}
		}

		/// <exclude/>
		public string CaseNumber {
			get {
				return GetTypedColumnValue<string>("CaseNumber");
			}
			set {
				SetColumnValue("CaseNumber", value);
				if (_case != null) {
					_case.Number = value;
				}
			}
		}

		private Case _case;
		/// <summary>
		/// Обращение.
		/// </summary>
		/// <remarks>
		/// Обращение связанное с чатом.
		/// </remarks>
		public Case Case {
			get {
				return _case ??
					(_case = LookupColumnEntities.GetEntity("Case") as Case);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new OmniChat_CaseServiceEventsProcess(UserConnection);
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
			return new OmniChat_CaseService_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: OmniChat_CaseServiceEventsProcess

	/// <exclude/>
	public partial class OmniChat_CaseServiceEventsProcess<TEntity> : BPMSoft.Configuration.OmniChat_OmnichannelMessagingEventsProcess<TEntity> where TEntity : OmniChat_CaseService_BPMSoft
	{

		public OmniChat_CaseServiceEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "OmniChat_CaseServiceEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("a84f47b6-cd3c-c88d-a912-836fcc39653a");
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

	#region Class: OmniChat_CaseServiceEventsProcess

	/// <exclude/>
	public class OmniChat_CaseServiceEventsProcess : OmniChat_CaseServiceEventsProcess<OmniChat_CaseService_BPMSoft>
	{

		public OmniChat_CaseServiceEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: OmniChat_CaseServiceEventsProcess

	public partial class OmniChat_CaseServiceEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

