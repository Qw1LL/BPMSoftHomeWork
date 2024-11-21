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

	#region Class: GeneratedWebFormInTagSchema

	/// <exclude/>
	public class GeneratedWebFormInTagSchema : BPMSoft.Configuration.BaseEntityInTagSchema
	{

		#region Constructors: Public

		public GeneratedWebFormInTagSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public GeneratedWebFormInTagSchema(GeneratedWebFormInTagSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public GeneratedWebFormInTagSchema(GeneratedWebFormInTagSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("10ecc6c1-36c7-48b2-a1aa-ff8b95a8140d");
			RealUId = new Guid("10ecc6c1-36c7-48b2-a1aa-ff8b95a8140d");
			Name = "GeneratedWebFormInTag";
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
			column.ReferenceSchemaUId = new Guid("905e1ada-1a66-4f65-8950-78cf26fbb800");
			column.ColumnValueName = @"TagId";
			column.DisplayColumnValueName = @"TagName";
			column.ModifiedInSchemaUId = new Guid("10ecc6c1-36c7-48b2-a1aa-ff8b95a8140d");
			return column;
		}

		protected override EntitySchemaColumn CreateEntityColumn() {
			EntitySchemaColumn column = base.CreateEntityColumn();
			column.ReferenceSchemaUId = new Guid("41ae7d8d-bec3-41df-a6f0-2ab0d08b3967");
			column.ColumnValueName = @"EntityId";
			column.DisplayColumnValueName = @"EntityName";
			column.ModifiedInSchemaUId = new Guid("10ecc6c1-36c7-48b2-a1aa-ff8b95a8140d");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new GeneratedWebFormInTag(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new GeneratedWebFormInTag_WebFormEventsProcess(userConnection);
		}

		public override object Clone() {
			return new GeneratedWebFormInTagSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new GeneratedWebFormInTagSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("10ecc6c1-36c7-48b2-a1aa-ff8b95a8140d"));
		}

		#endregion

	}

	#endregion

	#region Class: GeneratedWebFormInTag

	/// <summary>
	/// Landing pages section record tag.
	/// </summary>
	public class GeneratedWebFormInTag : BPMSoft.Configuration.BaseEntityInTag
	{

		#region Constructors: Public

		public GeneratedWebFormInTag(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "GeneratedWebFormInTag";
		}

		public GeneratedWebFormInTag(GeneratedWebFormInTag source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new GeneratedWebFormInTag_WebFormEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("GeneratedWebFormInTagDeleted", e);
			Validating += (s, e) => ThrowEvent("GeneratedWebFormInTagValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new GeneratedWebFormInTag(this);
		}

		#endregion

	}

	#endregion

	#region Class: GeneratedWebFormInTag_WebFormEventsProcess

	/// <exclude/>
	public partial class GeneratedWebFormInTag_WebFormEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntityInTag_BaseEventsProcess<TEntity> where TEntity : GeneratedWebFormInTag
	{

		public GeneratedWebFormInTag_WebFormEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "GeneratedWebFormInTag_WebFormEventsProcess";
			SchemaUId = new Guid("10ecc6c1-36c7-48b2-a1aa-ff8b95a8140d");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("10ecc6c1-36c7-48b2-a1aa-ff8b95a8140d");
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

	#region Class: GeneratedWebFormInTag_WebFormEventsProcess

	/// <exclude/>
	public class GeneratedWebFormInTag_WebFormEventsProcess : GeneratedWebFormInTag_WebFormEventsProcess<GeneratedWebFormInTag>
	{

		public GeneratedWebFormInTag_WebFormEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: GeneratedWebFormInTag_WebFormEventsProcess

	public partial class GeneratedWebFormInTag_WebFormEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: GeneratedWebFormInTagEventsProcess

	/// <exclude/>
	public class GeneratedWebFormInTagEventsProcess : GeneratedWebFormInTag_WebFormEventsProcess
	{

		public GeneratedWebFormInTagEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

