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

	#region Class: InvoiceInTagSchema

	/// <exclude/>
	public class InvoiceInTagSchema : BPMSoft.Configuration.BaseEntityInTagSchema
	{

		#region Constructors: Public

		public InvoiceInTagSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public InvoiceInTagSchema(InvoiceInTagSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public InvoiceInTagSchema(InvoiceInTagSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("9b006991-b6c8-4a28-90dd-22986a2d77d4");
			RealUId = new Guid("9b006991-b6c8-4a28-90dd-22986a2d77d4");
			Name = "InvoiceInTag";
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
			column.ReferenceSchemaUId = new Guid("4c2a46d4-de12-457a-a09b-c8fe04d5d7e4");
			column.ColumnValueName = @"TagId";
			column.DisplayColumnValueName = @"TagName";
			column.ModifiedInSchemaUId = new Guid("9b006991-b6c8-4a28-90dd-22986a2d77d4");
			return column;
		}

		protected override EntitySchemaColumn CreateEntityColumn() {
			EntitySchemaColumn column = base.CreateEntityColumn();
			column.ReferenceSchemaUId = new Guid("bfb313dd-bb55-4e1b-8e42-3d346e0da7c5");
			column.ColumnValueName = @"EntityId";
			column.DisplayColumnValueName = @"EntityNumber";
			column.ModifiedInSchemaUId = new Guid("9b006991-b6c8-4a28-90dd-22986a2d77d4");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new InvoiceInTag(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new InvoiceInTag_InvoiceEventsProcess(userConnection);
		}

		public override object Clone() {
			return new InvoiceInTagSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new InvoiceInTagSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("9b006991-b6c8-4a28-90dd-22986a2d77d4"));
		}

		#endregion

	}

	#endregion

	#region Class: InvoiceInTag

	/// <summary>
	/// Тег в записи раздела счета.
	/// </summary>
	public class InvoiceInTag : BPMSoft.Configuration.BaseEntityInTag
	{

		#region Constructors: Public

		public InvoiceInTag(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "InvoiceInTag";
		}

		public InvoiceInTag(InvoiceInTag source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new InvoiceInTag_InvoiceEventsProcess(UserConnection);
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
			return new InvoiceInTag(this);
		}

		#endregion

	}

	#endregion

	#region Class: InvoiceInTag_InvoiceEventsProcess

	/// <exclude/>
	public partial class InvoiceInTag_InvoiceEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntityInTag_BaseEventsProcess<TEntity> where TEntity : InvoiceInTag
	{

		public InvoiceInTag_InvoiceEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "InvoiceInTag_InvoiceEventsProcess";
			SchemaUId = new Guid("9b006991-b6c8-4a28-90dd-22986a2d77d4");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("9b006991-b6c8-4a28-90dd-22986a2d77d4");
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

	#region Class: InvoiceInTag_InvoiceEventsProcess

	/// <exclude/>
	public class InvoiceInTag_InvoiceEventsProcess : InvoiceInTag_InvoiceEventsProcess<InvoiceInTag>
	{

		public InvoiceInTag_InvoiceEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: InvoiceInTag_InvoiceEventsProcess

	public partial class InvoiceInTag_InvoiceEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: InvoiceInTagEventsProcess

	/// <exclude/>
	public class InvoiceInTagEventsProcess : InvoiceInTag_InvoiceEventsProcess
	{

		public InvoiceInTagEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

