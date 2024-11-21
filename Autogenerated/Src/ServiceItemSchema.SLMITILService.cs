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

	#region Class: ServiceItemSchema

	/// <exclude/>
	public class ServiceItemSchema : BPMSoft.Configuration.ServiceItem_SLM_BPMSoftSchema
	{

		#region Constructors: Public

		public ServiceItemSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ServiceItemSchema(ServiceItemSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ServiceItemSchema(ServiceItemSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("82dc1018-0fe3-474a-abd1-92dc3f410dc3");
			Name = "ServiceItem";
			ParentSchemaUId = new Guid("c6c44f0a-193e-4b5c-b35e-220a60c06898");
			ExtendParent = true;
			CreatedInPackageId = new Guid("914c52f8-7161-4b32-82f6-d4cef8b3a889");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("8a7c51f0-42ba-4901-9847-2e58d5a0233d")) == null) {
				Columns.Add(CreateCategoryColumn());
			}
		}

		protected override EntitySchemaColumn CreateCalendarColumn() {
			EntitySchemaColumn column = base.CreateCalendarColumn();
			column.RequirementType = EntitySchemaColumnRequirementType.None;
			column.ModifiedInSchemaUId = new Guid("82dc1018-0fe3-474a-abd1-92dc3f410dc3");
			return column;
		}

		protected virtual EntitySchemaColumn CreateCategoryColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("8a7c51f0-42ba-4901-9847-2e58d5a0233d"),
				Name = @"Category",
				ReferenceSchemaUId = new Guid("d76eaeaf-9ffc-4556-b8ad-87e2823e1e84"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("82dc1018-0fe3-474a-abd1-92dc3f410dc3"),
				ModifiedInSchemaUId = new Guid("82dc1018-0fe3-474a-abd1-92dc3f410dc3"),
				CreatedInPackageId = new Guid("914c52f8-7161-4b32-82f6-d4cef8b3a889")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ServiceItem(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ServiceItem_SLMITILServiceEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ServiceItemSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ServiceItemSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("82dc1018-0fe3-474a-abd1-92dc3f410dc3"));
		}

		#endregion

	}

	#endregion

	#region Class: ServiceItem

	/// <summary>
	/// Сервис.
	/// </summary>
	public class ServiceItem : BPMSoft.Configuration.ServiceItem_SLM_BPMSoft
	{

		#region Constructors: Public

		public ServiceItem(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ServiceItem";
		}

		public ServiceItem(ServiceItem source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid CategoryId {
			get {
				return GetTypedColumnValue<Guid>("CategoryId");
			}
			set {
				SetColumnValue("CategoryId", value);
				_category = null;
			}
		}

		/// <exclude/>
		public string CategoryName {
			get {
				return GetTypedColumnValue<string>("CategoryName");
			}
			set {
				SetColumnValue("CategoryName", value);
				if (_category != null) {
					_category.Name = value;
				}
			}
		}

		private ServiceCategory _category;
		/// <summary>
		/// Категория.
		/// </summary>
		public ServiceCategory Category {
			get {
				return _category ??
					(_category = LookupColumnEntities.GetEntity("Category") as ServiceCategory);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ServiceItem_SLMITILServiceEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ServiceItemDeleted", e);
			Saving += (s, e) => ThrowEvent("ServiceItemSaving", e);
			Validating += (s, e) => ThrowEvent("ServiceItemValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ServiceItem(this);
		}

		#endregion

	}

	#endregion

	#region Class: ServiceItem_SLMITILServiceEventsProcess

	/// <exclude/>
	public partial class ServiceItem_SLMITILServiceEventsProcess<TEntity> : BPMSoft.Configuration.ServiceItem_SLMEventsProcess<TEntity> where TEntity : ServiceItem
	{

		public ServiceItem_SLMITILServiceEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ServiceItem_SLMITILServiceEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("82dc1018-0fe3-474a-abd1-92dc3f410dc3");
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

	#region Class: ServiceItem_SLMITILServiceEventsProcess

	/// <exclude/>
	public class ServiceItem_SLMITILServiceEventsProcess : ServiceItem_SLMITILServiceEventsProcess<ServiceItem>
	{

		public ServiceItem_SLMITILServiceEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ServiceItem_SLMITILServiceEventsProcess

	public partial class ServiceItem_SLMITILServiceEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ServiceItemEventsProcess

	/// <exclude/>
	public class ServiceItemEventsProcess : ServiceItem_SLMITILServiceEventsProcess
	{

		public ServiceItemEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

