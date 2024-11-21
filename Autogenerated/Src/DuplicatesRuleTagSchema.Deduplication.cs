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

	#region Class: DuplicatesRuleTagSchema

	/// <exclude/>
	public class DuplicatesRuleTagSchema : BPMSoft.Configuration.BaseTagSchema
	{

		#region Constructors: Public

		public DuplicatesRuleTagSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public DuplicatesRuleTagSchema(DuplicatesRuleTagSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public DuplicatesRuleTagSchema(DuplicatesRuleTagSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("655501e6-0dd8-48a2-91ad-1d67671dfc00");
			RealUId = new Guid("655501e6-0dd8-48a2-91ad-1d67671dfc00");
			Name = "DuplicatesRuleTag";
			ParentSchemaUId = new Guid("9e3f203c-e905-4de5-9468-335b193f2439");
			ExtendParent = false;
			CreatedInPackageId = new Guid("cddb02cf-8a8b-4af9-b5f2-4f81a4f916c1");
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
			column.ModifiedInSchemaUId = new Guid("655501e6-0dd8-48a2-91ad-1d67671dfc00");
			return column;
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.IsLocalizable = true;
			column.ModifiedInSchemaUId = new Guid("655501e6-0dd8-48a2-91ad-1d67671dfc00");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new DuplicatesRuleTag(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new DuplicatesRuleTag_DeduplicationEventsProcess(userConnection);
		}

		public override object Clone() {
			return new DuplicatesRuleTagSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new DuplicatesRuleTagSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("655501e6-0dd8-48a2-91ad-1d67671dfc00"));
		}

		#endregion

	}

	#endregion

	#region Class: DuplicatesRuleTag

	/// <summary>
	/// Тег раздела "Правила поиска дублей".
	/// </summary>
	public class DuplicatesRuleTag : BPMSoft.Configuration.BaseTag
	{

		#region Constructors: Public

		public DuplicatesRuleTag(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "DuplicatesRuleTag";
		}

		public DuplicatesRuleTag(DuplicatesRuleTag source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new DuplicatesRuleTag_DeduplicationEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("DuplicatesRuleTagDeleted", e);
			Validating += (s, e) => ThrowEvent("DuplicatesRuleTagValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new DuplicatesRuleTag(this);
		}

		#endregion

	}

	#endregion

	#region Class: DuplicatesRuleTag_DeduplicationEventsProcess

	/// <exclude/>
	public partial class DuplicatesRuleTag_DeduplicationEventsProcess<TEntity> : BPMSoft.Configuration.BaseTag_SSPEventsProcess<TEntity> where TEntity : DuplicatesRuleTag
	{

		public DuplicatesRuleTag_DeduplicationEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "DuplicatesRuleTag_DeduplicationEventsProcess";
			SchemaUId = new Guid("655501e6-0dd8-48a2-91ad-1d67671dfc00");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("655501e6-0dd8-48a2-91ad-1d67671dfc00");
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

	#region Class: DuplicatesRuleTag_DeduplicationEventsProcess

	/// <exclude/>
	public class DuplicatesRuleTag_DeduplicationEventsProcess : DuplicatesRuleTag_DeduplicationEventsProcess<DuplicatesRuleTag>
	{

		public DuplicatesRuleTag_DeduplicationEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: DuplicatesRuleTag_DeduplicationEventsProcess

	public partial class DuplicatesRuleTag_DeduplicationEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: DuplicatesRuleTagEventsProcess

	/// <exclude/>
	public class DuplicatesRuleTagEventsProcess : DuplicatesRuleTag_DeduplicationEventsProcess
	{

		public DuplicatesRuleTagEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

