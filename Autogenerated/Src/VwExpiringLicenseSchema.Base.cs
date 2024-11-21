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

	#region Class: VwExpiringLicenseSchema

	/// <exclude/>
	public class VwExpiringLicenseSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public VwExpiringLicenseSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwExpiringLicenseSchema(VwExpiringLicenseSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwExpiringLicenseSchema(VwExpiringLicenseSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("5cfd66e4-985e-4c10-b255-49bfb2d8da7d");
			RealUId = new Guid("5cfd66e4-985e-4c10-b255-49bfb2d8da7d");
			Name = "VwExpiringLicense";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f");
			IsDBView = true;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("c02350bd-9248-5306-dc3c-448158194f9e")) == null) {
				Columns.Add(CreateLicUserCountColumn());
			}
			if (Columns.FindByUId(new Guid("d48ce87b-591f-086d-2daa-0ac607de666e")) == null) {
				Columns.Add(CreateDueDateColumn());
			}
			if (Columns.FindByUId(new Guid("c4dcf37c-fe29-1808-4872-b695d491935d")) == null) {
				Columns.Add(CreateStartDateColumn());
			}
			if (Columns.FindByUId(new Guid("8671987d-0a31-17f9-60e7-f183582d441d")) == null) {
				Columns.Add(CreateCountColumn());
			}
			if (Columns.FindByUId(new Guid("09943ffe-e5a9-8900-c3c0-462dbc04d5db")) == null) {
				Columns.Add(CreateLicPackageNameColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateLicUserCountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("c02350bd-9248-5306-dc3c-448158194f9e"),
				Name = @"LicUserCount",
				CreatedInSchemaUId = new Guid("5cfd66e4-985e-4c10-b255-49bfb2d8da7d"),
				ModifiedInSchemaUId = new Guid("5cfd66e4-985e-4c10-b255-49bfb2d8da7d"),
				CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f")
			};
		}

		protected virtual EntitySchemaColumn CreateDueDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("d48ce87b-591f-086d-2daa-0ac607de666e"),
				Name = @"DueDate",
				CreatedInSchemaUId = new Guid("5cfd66e4-985e-4c10-b255-49bfb2d8da7d"),
				ModifiedInSchemaUId = new Guid("5cfd66e4-985e-4c10-b255-49bfb2d8da7d"),
				CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f")
			};
		}

		protected virtual EntitySchemaColumn CreateStartDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Date")) {
				UId = new Guid("c4dcf37c-fe29-1808-4872-b695d491935d"),
				Name = @"StartDate",
				CreatedInSchemaUId = new Guid("5cfd66e4-985e-4c10-b255-49bfb2d8da7d"),
				ModifiedInSchemaUId = new Guid("5cfd66e4-985e-4c10-b255-49bfb2d8da7d"),
				CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f")
			};
		}

		protected virtual EntitySchemaColumn CreateCountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("8671987d-0a31-17f9-60e7-f183582d441d"),
				Name = @"Count",
				CreatedInSchemaUId = new Guid("5cfd66e4-985e-4c10-b255-49bfb2d8da7d"),
				ModifiedInSchemaUId = new Guid("5cfd66e4-985e-4c10-b255-49bfb2d8da7d"),
				CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f")
			};
		}

		protected virtual EntitySchemaColumn CreateLicPackageNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("09943ffe-e5a9-8900-c3c0-462dbc04d5db"),
				Name = @"LicPackageName",
				CreatedInSchemaUId = new Guid("5cfd66e4-985e-4c10-b255-49bfb2d8da7d"),
				ModifiedInSchemaUId = new Guid("5cfd66e4-985e-4c10-b255-49bfb2d8da7d"),
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
			return new VwExpiringLicense(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwExpiringLicense_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwExpiringLicenseSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwExpiringLicenseSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("5cfd66e4-985e-4c10-b255-49bfb2d8da7d"));
		}

		#endregion

	}

	#endregion

	#region Class: VwExpiringLicense

	/// <summary>
	/// Expiring license (view).
	/// </summary>
	/// <remarks>
	/// View that represents licenses those are expiring in the nearest future and those don't have continuation for the next period.
	/// </remarks>
	public class VwExpiringLicense : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public VwExpiringLicense(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwExpiringLicense";
		}

		public VwExpiringLicense(VwExpiringLicense source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Number of licensed users.
		/// </summary>
		public int LicUserCount {
			get {
				return GetTypedColumnValue<int>("LicUserCount");
			}
			set {
				SetColumnValue("LicUserCount", value);
			}
		}

		/// <summary>
		/// End date.
		/// </summary>
		public DateTime DueDate {
			get {
				return GetTypedColumnValue<DateTime>("DueDate");
			}
			set {
				SetColumnValue("DueDate", value);
			}
		}

		/// <summary>
		/// Start date.
		/// </summary>
		public DateTime StartDate {
			get {
				return GetTypedColumnValue<DateTime>("StartDate");
			}
			set {
				SetColumnValue("StartDate", value);
			}
		}

		/// <summary>
		/// Quantity.
		/// </summary>
		public int Count {
			get {
				return GetTypedColumnValue<int>("Count");
			}
			set {
				SetColumnValue("Count", value);
			}
		}

		/// <summary>
		/// Name of license package.
		/// </summary>
		public string LicPackageName {
			get {
				return GetTypedColumnValue<string>("LicPackageName");
			}
			set {
				SetColumnValue("LicPackageName", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new VwExpiringLicense_BaseEventsProcess(UserConnection);
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
			return new VwExpiringLicense(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwExpiringLicense_BaseEventsProcess

	/// <exclude/>
	public partial class VwExpiringLicense_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : VwExpiringLicense
	{

		public VwExpiringLicense_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwExpiringLicense_BaseEventsProcess";
			SchemaUId = new Guid("5cfd66e4-985e-4c10-b255-49bfb2d8da7d");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("5cfd66e4-985e-4c10-b255-49bfb2d8da7d");
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

	#region Class: VwExpiringLicense_BaseEventsProcess

	/// <exclude/>
	public class VwExpiringLicense_BaseEventsProcess : VwExpiringLicense_BaseEventsProcess<VwExpiringLicense>
	{

		public VwExpiringLicense_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VwExpiringLicense_BaseEventsProcess

	public partial class VwExpiringLicense_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: VwExpiringLicenseEventsProcess

	/// <exclude/>
	public class VwExpiringLicenseEventsProcess : VwExpiringLicense_BaseEventsProcess
	{

		public VwExpiringLicenseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

