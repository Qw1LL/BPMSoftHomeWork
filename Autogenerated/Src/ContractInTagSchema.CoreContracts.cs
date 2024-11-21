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

	#region Class: ContractInTagSchema

	/// <exclude/>
	public class ContractInTagSchema : BPMSoft.Configuration.BaseEntityInTagSchema
	{

		#region Constructors: Public

		public ContractInTagSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ContractInTagSchema(ContractInTagSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ContractInTagSchema(ContractInTagSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("caee908c-f5b5-41d0-8ac4-2166678dd4ae");
			RealUId = new Guid("caee908c-f5b5-41d0-8ac4-2166678dd4ae");
			Name = "ContractInTag";
			ParentSchemaUId = new Guid("5894a2b0-51d5-419a-82bb-238674634270");
			ExtendParent = false;
			CreatedInPackageId = new Guid("9e68a40f-2533-42d0-8fe0-88fdb6bf5704");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override EntitySchemaColumn CreateTagColumn() {
			EntitySchemaColumn column = base.CreateTagColumn();
			column.ReferenceSchemaUId = new Guid("ed9a4f11-04ff-4492-82f8-6f3dd5997104");
			column.ColumnValueName = @"TagId";
			column.DisplayColumnValueName = @"TagName";
			column.ModifiedInSchemaUId = new Guid("caee908c-f5b5-41d0-8ac4-2166678dd4ae");
			return column;
		}

		protected override EntitySchemaColumn CreateEntityColumn() {
			EntitySchemaColumn column = base.CreateEntityColumn();
			column.ReferenceSchemaUId = new Guid("897be3e4-0333-467d-88e2-b7a945c0d810");
			column.ColumnValueName = @"EntityId";
			column.DisplayColumnValueName = @"EntityNumber";
			column.ModifiedInSchemaUId = new Guid("caee908c-f5b5-41d0-8ac4-2166678dd4ae");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ContractInTag(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ContractInTag_CoreContractsEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ContractInTagSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ContractInTagSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("caee908c-f5b5-41d0-8ac4-2166678dd4ae"));
		}

		#endregion

	}

	#endregion

	#region Class: ContractInTag

	/// <summary>
	/// Тег в записи раздела договоры.
	/// </summary>
	public class ContractInTag : BPMSoft.Configuration.BaseEntityInTag
	{

		#region Constructors: Public

		public ContractInTag(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ContractInTag";
		}

		public ContractInTag(ContractInTag source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ContractInTag_CoreContractsEventsProcess(UserConnection);
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
			return new ContractInTag(this);
		}

		#endregion

	}

	#endregion

	#region Class: ContractInTag_CoreContractsEventsProcess

	/// <exclude/>
	public partial class ContractInTag_CoreContractsEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntityInTag_BaseEventsProcess<TEntity> where TEntity : ContractInTag
	{

		public ContractInTag_CoreContractsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ContractInTag_CoreContractsEventsProcess";
			SchemaUId = new Guid("caee908c-f5b5-41d0-8ac4-2166678dd4ae");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("caee908c-f5b5-41d0-8ac4-2166678dd4ae");
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

	#region Class: ContractInTag_CoreContractsEventsProcess

	/// <exclude/>
	public class ContractInTag_CoreContractsEventsProcess : ContractInTag_CoreContractsEventsProcess<ContractInTag>
	{

		public ContractInTag_CoreContractsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ContractInTag_CoreContractsEventsProcess

	public partial class ContractInTag_CoreContractsEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ContractInTagEventsProcess

	/// <exclude/>
	public class ContractInTagEventsProcess : ContractInTag_CoreContractsEventsProcess
	{

		public ContractInTagEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

