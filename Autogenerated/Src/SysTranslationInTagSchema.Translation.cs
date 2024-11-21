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

	#region Class: SysTranslationInTagSchema

	/// <exclude/>
	public class SysTranslationInTagSchema : BPMSoft.Configuration.BaseEntityInTagSchema
	{

		#region Constructors: Public

		public SysTranslationInTagSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysTranslationInTagSchema(SysTranslationInTagSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysTranslationInTagSchema(SysTranslationInTagSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("c055827d-515f-4bd4-999c-a8e66d99ea4d");
			RealUId = new Guid("c055827d-515f-4bd4-999c-a8e66d99ea4d");
			Name = "SysTranslationInTag";
			ParentSchemaUId = new Guid("5894a2b0-51d5-419a-82bb-238674634270");
			ExtendParent = false;
			CreatedInPackageId = new Guid("79d5e1e4-18af-4001-8dc1-26f09fca92c2");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override EntitySchemaColumn CreateTagColumn() {
			EntitySchemaColumn column = base.CreateTagColumn();
			column.ReferenceSchemaUId = new Guid("d4ceb66b-09bd-4285-b77f-a0461ad7c2c1");
			column.ColumnValueName = @"TagId";
			column.DisplayColumnValueName = @"TagName";
			column.ModifiedInSchemaUId = new Guid("c055827d-515f-4bd4-999c-a8e66d99ea4d");
			return column;
		}

		protected override EntitySchemaColumn CreateEntityColumn() {
			EntitySchemaColumn column = base.CreateEntityColumn();
			column.ReferenceSchemaUId = new Guid("4a564759-cf96-48d9-ae57-97bbb9c0b951");
			column.ColumnValueName = @"EntityId";
			column.DisplayColumnValueName = @"EntityKey";
			column.ModifiedInSchemaUId = new Guid("c055827d-515f-4bd4-999c-a8e66d99ea4d");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysTranslationInTag(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysTranslationInTag_TranslationEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysTranslationInTagSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysTranslationInTagSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("c055827d-515f-4bd4-999c-a8e66d99ea4d"));
		}

		#endregion

	}

	#endregion

	#region Class: SysTranslationInTag

	/// <summary>
	/// Translation section record tag.
	/// </summary>
	public class SysTranslationInTag : BPMSoft.Configuration.BaseEntityInTag
	{

		#region Constructors: Public

		public SysTranslationInTag(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysTranslationInTag";
		}

		public SysTranslationInTag(SysTranslationInTag source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysTranslationInTag_TranslationEventsProcess(UserConnection);
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
			return new SysTranslationInTag(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysTranslationInTag_TranslationEventsProcess

	/// <exclude/>
	public partial class SysTranslationInTag_TranslationEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntityInTag_BaseEventsProcess<TEntity> where TEntity : SysTranslationInTag
	{

		public SysTranslationInTag_TranslationEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysTranslationInTag_TranslationEventsProcess";
			SchemaUId = new Guid("c055827d-515f-4bd4-999c-a8e66d99ea4d");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("c055827d-515f-4bd4-999c-a8e66d99ea4d");
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

	#region Class: SysTranslationInTag_TranslationEventsProcess

	/// <exclude/>
	public class SysTranslationInTag_TranslationEventsProcess : SysTranslationInTag_TranslationEventsProcess<SysTranslationInTag>
	{

		public SysTranslationInTag_TranslationEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysTranslationInTag_TranslationEventsProcess

	public partial class SysTranslationInTag_TranslationEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysTranslationInTagEventsProcess

	/// <exclude/>
	public class SysTranslationInTagEventsProcess : SysTranslationInTag_TranslationEventsProcess
	{

		public SysTranslationInTagEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

