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

	#region Class: SysWorkplaceSchema

	/// <exclude/>
	public class SysWorkplaceSchema : BPMSoft.Configuration.SysWorkplace_NUI_BPMSoftSchema
	{

		#region Constructors: Public

		public SysWorkplaceSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysWorkplaceSchema(SysWorkplaceSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysWorkplaceSchema(SysWorkplaceSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("008aec22-5e64-45aa-a333-88a586ab0216");
			Name = "SysWorkplace";
			ParentSchemaUId = new Guid("f54121e1-d75d-42e0-b790-bc8aa0bb216c");
			ExtendParent = true;
			CreatedInPackageId = new Guid("25822d5f-097b-4b24-b0f2-6524204c151c");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("d3a42fb5-39c6-09fc-54d1-5071e61f145e")) == null) {
				Columns.Add(CreateHomePageUIdColumn());
			}
		}

		protected override EntitySchemaColumn CreateSysApplicationClientTypeColumn() {
			EntitySchemaColumn column = base.CreateSysApplicationClientTypeColumn();
			column.DefValue = new EntitySchemaColumnDef() {
				Source = EntitySchemaColumnDefSource.Const,
				ValueSource = @"195785b4-f55a-4e72-ace3-6480b54c8fa5"
			};
			column.ModifiedInSchemaUId = new Guid("008aec22-5e64-45aa-a333-88a586ab0216");
			return column;
		}

		protected override EntitySchemaColumn CreateTypeColumn() {
			EntitySchemaColumn column = base.CreateTypeColumn();
			column.DefValue = new EntitySchemaColumnDef() {
				Source = EntitySchemaColumnDefSource.Const,
				ValueSource = @"000a9225-728b-4778-a951-c42439ffe024"
			};
			column.ModifiedInSchemaUId = new Guid("008aec22-5e64-45aa-a333-88a586ab0216");
			return column;
		}

		protected virtual EntitySchemaColumn CreateHomePageUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("d3a42fb5-39c6-09fc-54d1-5071e61f145e"),
				Name = @"HomePageUId",
				CreatedInSchemaUId = new Guid("008aec22-5e64-45aa-a333-88a586ab0216"),
				ModifiedInSchemaUId = new Guid("008aec22-5e64-45aa-a333-88a586ab0216"),
				CreatedInPackageId = new Guid("25822d5f-097b-4b24-b0f2-6524204c151c")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysWorkplace(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysWorkplace_HomePageEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysWorkplaceSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysWorkplaceSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("008aec22-5e64-45aa-a333-88a586ab0216"));
		}

		#endregion

	}

	#endregion

	#region Class: SysWorkplace

	/// <summary>
	/// Рабочее место пользователя.
	/// </summary>
	public class SysWorkplace : BPMSoft.Configuration.SysWorkplace_NUI_BPMSoft
	{

		#region Constructors: Public

		public SysWorkplace(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysWorkplace";
		}

		public SysWorkplace(SysWorkplace source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Идентификатор схема домашней страницы рабочего места.
		/// </summary>
		public Guid HomePageUId {
			get {
				return GetTypedColumnValue<Guid>("HomePageUId");
			}
			set {
				SetColumnValue("HomePageUId", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysWorkplace_HomePageEventsProcess(UserConnection);
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
			return new SysWorkplace(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysWorkplace_HomePageEventsProcess

	/// <exclude/>
	public partial class SysWorkplace_HomePageEventsProcess<TEntity> : BPMSoft.Configuration.SysWorkplace_NUIEventsProcess<TEntity> where TEntity : SysWorkplace
	{

		public SysWorkplace_HomePageEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysWorkplace_HomePageEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("008aec22-5e64-45aa-a333-88a586ab0216");
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

	#region Class: SysWorkplace_HomePageEventsProcess

	/// <exclude/>
	public class SysWorkplace_HomePageEventsProcess : SysWorkplace_HomePageEventsProcess<SysWorkplace>
	{

		public SysWorkplace_HomePageEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysWorkplace_HomePageEventsProcess

	public partial class SysWorkplace_HomePageEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysWorkplaceEventsProcess

	/// <exclude/>
	public class SysWorkplaceEventsProcess : SysWorkplace_HomePageEventsProcess
	{

		public SysWorkplaceEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

