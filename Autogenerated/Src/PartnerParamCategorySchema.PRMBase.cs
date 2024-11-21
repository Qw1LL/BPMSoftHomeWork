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

	#region Class: PartnerParamCategorySchema

	/// <exclude/>
	public class PartnerParamCategorySchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public PartnerParamCategorySchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public PartnerParamCategorySchema(PartnerParamCategorySchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public PartnerParamCategorySchema(PartnerParamCategorySchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("7a91ebee-2015-4ee4-bc69-12fb6a22ad6e");
			RealUId = new Guid("7a91ebee-2015-4ee4-bc69-12fb6a22ad6e");
			Name = "PartnerParamCategory";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("867b9a25-86bf-4a3e-8ecd-b6e40f57be82");
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
			return new PartnerParamCategory(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new PartnerParamCategory_PRMBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new PartnerParamCategorySchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new PartnerParamCategorySchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("7a91ebee-2015-4ee4-bc69-12fb6a22ad6e"));
		}

		#endregion

	}

	#endregion

	#region Class: PartnerParamCategory

	/// <summary>
	/// Категория параметра партнерства.
	/// </summary>
	public class PartnerParamCategory : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public PartnerParamCategory(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "PartnerParamCategory";
		}

		public PartnerParamCategory(PartnerParamCategory source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new PartnerParamCategory_PRMBaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("PartnerParamCategoryDeleted", e);
			Validating += (s, e) => ThrowEvent("PartnerParamCategoryValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new PartnerParamCategory(this);
		}

		#endregion

	}

	#endregion

	#region Class: PartnerParamCategory_PRMBaseEventsProcess

	/// <exclude/>
	public partial class PartnerParamCategory_PRMBaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : PartnerParamCategory
	{

		public PartnerParamCategory_PRMBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "PartnerParamCategory_PRMBaseEventsProcess";
			SchemaUId = new Guid("7a91ebee-2015-4ee4-bc69-12fb6a22ad6e");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("7a91ebee-2015-4ee4-bc69-12fb6a22ad6e");
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

	#region Class: PartnerParamCategory_PRMBaseEventsProcess

	/// <exclude/>
	public class PartnerParamCategory_PRMBaseEventsProcess : PartnerParamCategory_PRMBaseEventsProcess<PartnerParamCategory>
	{

		public PartnerParamCategory_PRMBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: PartnerParamCategory_PRMBaseEventsProcess

	public partial class PartnerParamCategory_PRMBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: PartnerParamCategoryEventsProcess

	/// <exclude/>
	public class PartnerParamCategoryEventsProcess : PartnerParamCategory_PRMBaseEventsProcess
	{

		public PartnerParamCategoryEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

