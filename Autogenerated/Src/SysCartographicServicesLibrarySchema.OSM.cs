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

	#region Class: SysCartographicServicesLibrarySchema

	/// <exclude/>
	public class SysCartographicServicesLibrarySchema : BPMSoft.Configuration.BaseCodeLookupSchema
	{

		#region Constructors: Public

		public SysCartographicServicesLibrarySchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysCartographicServicesLibrarySchema(SysCartographicServicesLibrarySchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysCartographicServicesLibrarySchema(SysCartographicServicesLibrarySchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("4eef52aa-eb06-4688-bd26-6d3fc6c983bf");
			RealUId = new Guid("4eef52aa-eb06-4688-bd26-6d3fc6c983bf");
			Name = "SysCartographicServicesLibrary";
			ParentSchemaUId = new Guid("2681062b-df59-4e52-89ed-f9b7dc909ab2");
			ExtendParent = false;
			CreatedInPackageId = new Guid("5faea1d8-f502-4db2-9809-ba3c1115396f");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("0e1fcca3-0118-12d2-3ca4-f91489341153")) == null) {
				Columns.Add(CreateUrlGetTilesColumn());
			}
			if (Columns.FindByUId(new Guid("00f0eccd-d3aa-51c4-7dac-939cf547ea9f")) == null) {
				Columns.Add(CreateUrlGetAddressColumn());
			}
			if (Columns.FindByUId(new Guid("a31710b1-bc44-0afb-a00a-eeb601ebf8e9")) == null) {
				Columns.Add(CreateApiKeyColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateUrlGetTilesColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("0e1fcca3-0118-12d2-3ca4-f91489341153"),
				Name = @"UrlGetTiles",
				CreatedInSchemaUId = new Guid("4eef52aa-eb06-4688-bd26-6d3fc6c983bf"),
				ModifiedInSchemaUId = new Guid("4eef52aa-eb06-4688-bd26-6d3fc6c983bf"),
				CreatedInPackageId = new Guid("5faea1d8-f502-4db2-9809-ba3c1115396f")
			};
		}

		protected virtual EntitySchemaColumn CreateUrlGetAddressColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("00f0eccd-d3aa-51c4-7dac-939cf547ea9f"),
				Name = @"UrlGetAddress",
				CreatedInSchemaUId = new Guid("4eef52aa-eb06-4688-bd26-6d3fc6c983bf"),
				ModifiedInSchemaUId = new Guid("4eef52aa-eb06-4688-bd26-6d3fc6c983bf"),
				CreatedInPackageId = new Guid("5faea1d8-f502-4db2-9809-ba3c1115396f")
			};
		}

		protected virtual EntitySchemaColumn CreateApiKeyColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("a31710b1-bc44-0afb-a00a-eeb601ebf8e9"),
				Name = @"ApiKey",
				CreatedInSchemaUId = new Guid("4eef52aa-eb06-4688-bd26-6d3fc6c983bf"),
				ModifiedInSchemaUId = new Guid("4eef52aa-eb06-4688-bd26-6d3fc6c983bf"),
				CreatedInPackageId = new Guid("5faea1d8-f502-4db2-9809-ba3c1115396f")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysCartographicServicesLibrary(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysCartographicServicesLibrary_OSMEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysCartographicServicesLibrarySchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysCartographicServicesLibrarySchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("4eef52aa-eb06-4688-bd26-6d3fc6c983bf"));
		}

		#endregion

	}

	#endregion

	#region Class: SysCartographicServicesLibrary

	/// <summary>
	/// Библиотеки картографических сервисов.
	/// </summary>
	public class SysCartographicServicesLibrary : BPMSoft.Configuration.BaseCodeLookup
	{

		#region Constructors: Public

		public SysCartographicServicesLibrary(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysCartographicServicesLibrary";
		}

		public SysCartographicServicesLibrary(SysCartographicServicesLibrary source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// URL для получения тайлов.
		/// </summary>
		public string UrlGetTiles {
			get {
				return GetTypedColumnValue<string>("UrlGetTiles");
			}
			set {
				SetColumnValue("UrlGetTiles", value);
			}
		}

		/// <summary>
		/// URL для получения адресов.
		/// </summary>
		public string UrlGetAddress {
			get {
				return GetTypedColumnValue<string>("UrlGetAddress");
			}
			set {
				SetColumnValue("UrlGetAddress", value);
			}
		}

		/// <summary>
		/// Ключ API (да/нет).
		/// </summary>
		public bool ApiKey {
			get {
				return GetTypedColumnValue<bool>("ApiKey");
			}
			set {
				SetColumnValue("ApiKey", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysCartographicServicesLibrary_OSMEventsProcess(UserConnection);
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
			return new SysCartographicServicesLibrary(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysCartographicServicesLibrary_OSMEventsProcess

	/// <exclude/>
	public partial class SysCartographicServicesLibrary_OSMEventsProcess<TEntity> : BPMSoft.Configuration.BaseCodeLookup_BaseEventsProcess<TEntity> where TEntity : SysCartographicServicesLibrary
	{

		public SysCartographicServicesLibrary_OSMEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysCartographicServicesLibrary_OSMEventsProcess";
			SchemaUId = new Guid("4eef52aa-eb06-4688-bd26-6d3fc6c983bf");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("4eef52aa-eb06-4688-bd26-6d3fc6c983bf");
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

	#region Class: SysCartographicServicesLibrary_OSMEventsProcess

	/// <exclude/>
	public class SysCartographicServicesLibrary_OSMEventsProcess : SysCartographicServicesLibrary_OSMEventsProcess<SysCartographicServicesLibrary>
	{

		public SysCartographicServicesLibrary_OSMEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysCartographicServicesLibrary_OSMEventsProcess

	public partial class SysCartographicServicesLibrary_OSMEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysCartographicServicesLibraryEventsProcess

	/// <exclude/>
	public class SysCartographicServicesLibraryEventsProcess : SysCartographicServicesLibrary_OSMEventsProcess
	{

		public SysCartographicServicesLibraryEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

