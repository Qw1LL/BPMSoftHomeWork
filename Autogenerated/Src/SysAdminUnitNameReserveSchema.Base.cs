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

	#region Class: SysAdminUnitNameReserveSchema

	/// <exclude/>
	public class SysAdminUnitNameReserveSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysAdminUnitNameReserveSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysAdminUnitNameReserveSchema(SysAdminUnitNameReserveSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysAdminUnitNameReserveSchema(SysAdminUnitNameReserveSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateUniqueLoginsIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = true
			};
			index.UId = new Guid("a28930f8-86d9-421a-9c85-459dd8f49430");
			index.Name = "UniqueLogins";
			index.CreatedInSchemaUId = new Guid("32d35a4e-8b01-425d-b6e6-7bb2256fc168");
			index.ModifiedInSchemaUId = new Guid("32d35a4e-8b01-425d-b6e6-7bb2256fc168");
			index.CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f");
			EntitySchemaIndexColumn loginIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("001b05cf-3e58-380e-b64e-0258edb6c727"),
				ColumnUId = new Guid("2289d968-fdce-2a03-502c-4d60df13be06"),
				CreatedInSchemaUId = new Guid("32d35a4e-8b01-425d-b6e6-7bb2256fc168"),
				ModifiedInSchemaUId = new Guid("32d35a4e-8b01-425d-b6e6-7bb2256fc168"),
				CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(loginIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("32d35a4e-8b01-425d-b6e6-7bb2256fc168");
			RealUId = new Guid("32d35a4e-8b01-425d-b6e6-7bb2256fc168");
			Name = "SysAdminUnitNameReserve";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateLoginColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected virtual EntitySchemaColumn CreateLoginColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("2289d968-fdce-2a03-502c-4d60df13be06"),
				Name = @"Login",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("32d35a4e-8b01-425d-b6e6-7bb2256fc168"),
				ModifiedInSchemaUId = new Guid("32d35a4e-8b01-425d-b6e6-7bb2256fc168"),
				CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateUniqueLoginsIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysAdminUnitNameReserve(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysAdminUnitNameReserve_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysAdminUnitNameReserveSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysAdminUnitNameReserveSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("32d35a4e-8b01-425d-b6e6-7bb2256fc168"));
		}

		#endregion

	}

	#endregion

	#region Class: SysAdminUnitNameReserve

	/// <summary>
	/// Зарезервированные логины удаленных пользователей.
	/// </summary>
	public class SysAdminUnitNameReserve : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysAdminUnitNameReserve(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysAdminUnitNameReserve";
		}

		public SysAdminUnitNameReserve(SysAdminUnitNameReserve source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Логин.
		/// </summary>
		/// <remarks>
		/// Имя пользователя или email.
		/// </remarks>
		public string Login {
			get {
				return GetTypedColumnValue<string>("Login");
			}
			set {
				SetColumnValue("Login", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysAdminUnitNameReserve_BaseEventsProcess(UserConnection);
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
			return new SysAdminUnitNameReserve(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysAdminUnitNameReserve_BaseEventsProcess

	/// <exclude/>
	public partial class SysAdminUnitNameReserve_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : SysAdminUnitNameReserve
	{

		public SysAdminUnitNameReserve_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysAdminUnitNameReserve_BaseEventsProcess";
			SchemaUId = new Guid("32d35a4e-8b01-425d-b6e6-7bb2256fc168");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("32d35a4e-8b01-425d-b6e6-7bb2256fc168");
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

	#region Class: SysAdminUnitNameReserve_BaseEventsProcess

	/// <exclude/>
	public class SysAdminUnitNameReserve_BaseEventsProcess : SysAdminUnitNameReserve_BaseEventsProcess<SysAdminUnitNameReserve>
	{

		public SysAdminUnitNameReserve_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysAdminUnitNameReserve_BaseEventsProcess

	public partial class SysAdminUnitNameReserve_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysAdminUnitNameReserveEventsProcess

	/// <exclude/>
	public class SysAdminUnitNameReserveEventsProcess : SysAdminUnitNameReserve_BaseEventsProcess
	{

		public SysAdminUnitNameReserveEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

