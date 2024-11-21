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

	#region Class: SysTranslationTagSchema

	/// <exclude/>
	public class SysTranslationTagSchema : BPMSoft.Configuration.BaseTagSchema
	{

		#region Constructors: Public

		public SysTranslationTagSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysTranslationTagSchema(SysTranslationTagSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysTranslationTagSchema(SysTranslationTagSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("d4ceb66b-09bd-4285-b77f-a0461ad7c2c1");
			RealUId = new Guid("d4ceb66b-09bd-4285-b77f-a0461ad7c2c1");
			Name = "SysTranslationTag";
			ParentSchemaUId = new Guid("9e3f203c-e905-4de5-9468-335b193f2439");
			ExtendParent = false;
			CreatedInPackageId = new Guid("79d5e1e4-18af-4001-8dc1-26f09fca92c2");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysTranslationTag(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysTranslationTag_TranslationEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysTranslationTagSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysTranslationTagSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("d4ceb66b-09bd-4285-b77f-a0461ad7c2c1"));
		}

		#endregion

	}

	#endregion

	#region Class: SysTranslationTag

	/// <summary>
	/// Translation section tag.
	/// </summary>
	public class SysTranslationTag : BPMSoft.Configuration.BaseTag
	{

		#region Constructors: Public

		public SysTranslationTag(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysTranslationTag";
		}

		public SysTranslationTag(SysTranslationTag source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysTranslationTag_TranslationEventsProcess(UserConnection);
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
			return new SysTranslationTag(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysTranslationTag_TranslationEventsProcess

	/// <exclude/>
	public partial class SysTranslationTag_TranslationEventsProcess<TEntity> : BPMSoft.Configuration.BaseTag_SSPEventsProcess<TEntity> where TEntity : SysTranslationTag
	{

		public SysTranslationTag_TranslationEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysTranslationTag_TranslationEventsProcess";
			SchemaUId = new Guid("d4ceb66b-09bd-4285-b77f-a0461ad7c2c1");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("d4ceb66b-09bd-4285-b77f-a0461ad7c2c1");
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

	#region Class: SysTranslationTag_TranslationEventsProcess

	/// <exclude/>
	public class SysTranslationTag_TranslationEventsProcess : SysTranslationTag_TranslationEventsProcess<SysTranslationTag>
	{

		public SysTranslationTag_TranslationEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysTranslationTag_TranslationEventsProcess

	public partial class SysTranslationTag_TranslationEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysTranslationTagEventsProcess

	/// <exclude/>
	public class SysTranslationTagEventsProcess : SysTranslationTag_TranslationEventsProcess
	{

		public SysTranslationTagEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

