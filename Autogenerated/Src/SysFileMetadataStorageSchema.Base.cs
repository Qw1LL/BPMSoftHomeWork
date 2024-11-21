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

	#region Class: SysFileMetadataStorageSchema

	/// <exclude/>
	public class SysFileMetadataStorageSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public SysFileMetadataStorageSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysFileMetadataStorageSchema(SysFileMetadataStorageSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysFileMetadataStorageSchema(SysFileMetadataStorageSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("363593b9-cad6-c31b-4ef8-b4a0f9b604b7");
			RealUId = new Guid("363593b9-cad6-c31b-4ef8-b4a0f9b604b7");
			Name = "SysFileMetadataStorage";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("07376563-30e5-48fd-8d5f-c37f73bbc55d");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("f79ea995-a599-0d61-4309-56e02a7fc269")) == null) {
				Columns.Add(CreateTypeNameColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateTypeNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("f79ea995-a599-0d61-4309-56e02a7fc269"),
				Name = @"TypeName",
				CreatedInSchemaUId = new Guid("363593b9-cad6-c31b-4ef8-b4a0f9b604b7"),
				ModifiedInSchemaUId = new Guid("363593b9-cad6-c31b-4ef8-b4a0f9b604b7"),
				CreatedInPackageId = new Guid("07376563-30e5-48fd-8d5f-c37f73bbc55d")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysFileMetadataStorage(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysFileMetadataStorage_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysFileMetadataStorageSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysFileMetadataStorageSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("363593b9-cad6-c31b-4ef8-b4a0f9b604b7"));
		}

		#endregion

	}

	#endregion

	#region Class: SysFileMetadataStorage

	/// <summary>
	/// File metadata storages.
	/// </summary>
	public class SysFileMetadataStorage : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public SysFileMetadataStorage(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysFileMetadataStorage";
		}

		public SysFileMetadataStorage(SysFileMetadataStorage source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Storage type name.
		/// </summary>
		public string TypeName {
			get {
				return GetTypedColumnValue<string>("TypeName");
			}
			set {
				SetColumnValue("TypeName", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysFileMetadataStorage_BaseEventsProcess(UserConnection);
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
			return new SysFileMetadataStorage(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysFileMetadataStorage_BaseEventsProcess

	/// <exclude/>
	public partial class SysFileMetadataStorage_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : SysFileMetadataStorage
	{

		public SysFileMetadataStorage_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysFileMetadataStorage_BaseEventsProcess";
			SchemaUId = new Guid("363593b9-cad6-c31b-4ef8-b4a0f9b604b7");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("363593b9-cad6-c31b-4ef8-b4a0f9b604b7");
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

	#region Class: SysFileMetadataStorage_BaseEventsProcess

	/// <exclude/>
	public class SysFileMetadataStorage_BaseEventsProcess : SysFileMetadataStorage_BaseEventsProcess<SysFileMetadataStorage>
	{

		public SysFileMetadataStorage_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysFileMetadataStorage_BaseEventsProcess

	public partial class SysFileMetadataStorage_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysFileMetadataStorageEventsProcess

	/// <exclude/>
	public class SysFileMetadataStorageEventsProcess : SysFileMetadataStorage_BaseEventsProcess
	{

		public SysFileMetadataStorageEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

