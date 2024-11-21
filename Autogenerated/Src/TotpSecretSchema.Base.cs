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

	#region Class: TotpSecretSchema

	/// <exclude/>
	public class TotpSecretSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public TotpSecretSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public TotpSecretSchema(TotpSecretSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public TotpSecretSchema(TotpSecretSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("df8cd7d9-40f5-41c4-928c-bd4504d7a332");
			RealUId = new Guid("df8cd7d9-40f5-41c4-928c-bd4504d7a332");
			Name = "TotpSecret";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("badccee3-5415-dd3b-0d8f-aa0c245dc3b3")) == null) {
				Columns.Add(CreateSecretValueColumn());
			}
			if (Columns.FindByUId(new Guid("cd8baceb-f8ba-c289-3de9-8d38d1892a14")) == null) {
				Columns.Add(CreateSysAdminUnitColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateSecretValueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("SecureText")) {
				UId = new Guid("badccee3-5415-dd3b-0d8f-aa0c245dc3b3"),
				Name = @"SecretValue",
				CreatedInSchemaUId = new Guid("df8cd7d9-40f5-41c4-928c-bd4504d7a332"),
				ModifiedInSchemaUId = new Guid("df8cd7d9-40f5-41c4-928c-bd4504d7a332"),
				CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f")
			};
		}

		protected virtual EntitySchemaColumn CreateSysAdminUnitColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("cd8baceb-f8ba-c289-3de9-8d38d1892a14"),
				Name = @"SysAdminUnit",
				ReferenceSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("df8cd7d9-40f5-41c4-928c-bd4504d7a332"),
				ModifiedInSchemaUId = new Guid("df8cd7d9-40f5-41c4-928c-bd4504d7a332"),
				CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new TotpSecret(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new TotpSecret_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new TotpSecretSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new TotpSecretSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("df8cd7d9-40f5-41c4-928c-bd4504d7a332"));
		}

		#endregion

	}

	#endregion

	#region Class: TotpSecret

	/// <summary>
	/// TotpSecret.
	/// </summary>
	public class TotpSecret : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public TotpSecret(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "TotpSecret";
		}

		public TotpSecret(TotpSecret source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// SecretValue.
		/// </summary>
		public string SecretValue {
			get {
				return GetTypedColumnValue<string>("SecretValue");
			}
			set {
				SetColumnValue("SecretValue", value);
			}
		}

		/// <exclude/>
		public Guid SysAdminUnitId {
			get {
				return GetTypedColumnValue<Guid>("SysAdminUnitId");
			}
			set {
				SetColumnValue("SysAdminUnitId", value);
				_sysAdminUnit = null;
			}
		}

		/// <exclude/>
		public string SysAdminUnitName {
			get {
				return GetTypedColumnValue<string>("SysAdminUnitName");
			}
			set {
				SetColumnValue("SysAdminUnitName", value);
				if (_sysAdminUnit != null) {
					_sysAdminUnit.Name = value;
				}
			}
		}

		private SysAdminUnit _sysAdminUnit;
		/// <summary>
		/// SysAdminUnit.
		/// </summary>
		public SysAdminUnit SysAdminUnit {
			get {
				return _sysAdminUnit ??
					(_sysAdminUnit = LookupColumnEntities.GetEntity("SysAdminUnit") as SysAdminUnit);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new TotpSecret_BaseEventsProcess(UserConnection);
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
			return new TotpSecret(this);
		}

		#endregion

	}

	#endregion

	#region Class: TotpSecret_BaseEventsProcess

	/// <exclude/>
	public partial class TotpSecret_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : TotpSecret
	{

		public TotpSecret_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "TotpSecret_BaseEventsProcess";
			SchemaUId = new Guid("df8cd7d9-40f5-41c4-928c-bd4504d7a332");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("df8cd7d9-40f5-41c4-928c-bd4504d7a332");
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

	#region Class: TotpSecret_BaseEventsProcess

	/// <exclude/>
	public class TotpSecret_BaseEventsProcess : TotpSecret_BaseEventsProcess<TotpSecret>
	{

		public TotpSecret_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: TotpSecret_BaseEventsProcess

	public partial class TotpSecret_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: TotpSecretEventsProcess

	/// <exclude/>
	public class TotpSecretEventsProcess : TotpSecret_BaseEventsProcess
	{

		public TotpSecretEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

