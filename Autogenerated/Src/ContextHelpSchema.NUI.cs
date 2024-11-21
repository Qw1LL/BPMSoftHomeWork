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

	#region Class: ContextHelpSchema

	/// <exclude/>
	public class ContextHelpSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public ContextHelpSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ContextHelpSchema(ContextHelpSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ContextHelpSchema(ContextHelpSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("2f0eac0f-fb07-4efd-9134-b2c5f34a58de");
			RealUId = new Guid("2f0eac0f-fb07-4efd-9134-b2c5f34a58de");
			Name = "ContextHelp";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("528446ff-ac57-46fd-bae2-0e30010fbf6e");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("29ee081e-46ef-43ad-ba0a-26760cf80722")) == null) {
				Columns.Add(CreateContextHelpIdColumn());
			}
			if (Columns.FindByUId(new Guid("d03ca814-c928-480b-9a6b-35a36feec58c")) == null) {
				Columns.Add(CreateLMSUrlColumn());
			}
			if (Columns.FindByUId(new Guid("33c93463-a379-43a2-969e-6d2bafdf51e8")) == null) {
				Columns.Add(CreateProductEditionColumn());
			}
			if (Columns.FindByUId(new Guid("90640866-5a16-4f3b-b98a-f8e41345176b")) == null) {
				Columns.Add(CreateConfigurationVersionColumn());
			}
			if (Columns.FindByUId(new Guid("ab361a09-e74b-464e-b369-410f22e745d7")) == null) {
				Columns.Add(CreateCodeColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateContextHelpIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("29ee081e-46ef-43ad-ba0a-26760cf80722"),
				Name = @"ContextHelpId",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("2f0eac0f-fb07-4efd-9134-b2c5f34a58de"),
				ModifiedInSchemaUId = new Guid("2f0eac0f-fb07-4efd-9134-b2c5f34a58de"),
				CreatedInPackageId = new Guid("528446ff-ac57-46fd-bae2-0e30010fbf6e")
			};
		}

		protected virtual EntitySchemaColumn CreateLMSUrlColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("d03ca814-c928-480b-9a6b-35a36feec58c"),
				Name = @"LMSUrl",
				CreatedInSchemaUId = new Guid("2f0eac0f-fb07-4efd-9134-b2c5f34a58de"),
				ModifiedInSchemaUId = new Guid("2f0eac0f-fb07-4efd-9134-b2c5f34a58de"),
				CreatedInPackageId = new Guid("528446ff-ac57-46fd-bae2-0e30010fbf6e")
			};
		}

		protected virtual EntitySchemaColumn CreateProductEditionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("33c93463-a379-43a2-969e-6d2bafdf51e8"),
				Name = @"ProductEdition",
				CreatedInSchemaUId = new Guid("2f0eac0f-fb07-4efd-9134-b2c5f34a58de"),
				ModifiedInSchemaUId = new Guid("2f0eac0f-fb07-4efd-9134-b2c5f34a58de"),
				CreatedInPackageId = new Guid("528446ff-ac57-46fd-bae2-0e30010fbf6e")
			};
		}

		protected virtual EntitySchemaColumn CreateConfigurationVersionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("90640866-5a16-4f3b-b98a-f8e41345176b"),
				Name = @"ConfigurationVersion",
				CreatedInSchemaUId = new Guid("2f0eac0f-fb07-4efd-9134-b2c5f34a58de"),
				ModifiedInSchemaUId = new Guid("2f0eac0f-fb07-4efd-9134-b2c5f34a58de"),
				CreatedInPackageId = new Guid("528446ff-ac57-46fd-bae2-0e30010fbf6e")
			};
		}

		protected virtual EntitySchemaColumn CreateCodeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("ab361a09-e74b-464e-b369-410f22e745d7"),
				Name = @"Code",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("2f0eac0f-fb07-4efd-9134-b2c5f34a58de"),
				ModifiedInSchemaUId = new Guid("2f0eac0f-fb07-4efd-9134-b2c5f34a58de"),
				CreatedInPackageId = new Guid("528446ff-ac57-46fd-bae2-0e30010fbf6e")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ContextHelp(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ContextHelp_NUIEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ContextHelpSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ContextHelpSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("2f0eac0f-fb07-4efd-9134-b2c5f34a58de"));
		}

		#endregion

	}

	#endregion

	#region Class: ContextHelp

	/// <summary>
	/// Web help.
	/// </summary>
	public class ContextHelp : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public ContextHelp(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ContextHelp";
		}

		public ContextHelp(ContextHelp source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Id.
		/// </summary>
		public int ContextHelpId {
			get {
				return GetTypedColumnValue<int>("ContextHelpId");
			}
			set {
				SetColumnValue("ContextHelpId", value);
			}
		}

		/// <summary>
		/// LMS address.
		/// </summary>
		public string LMSUrl {
			get {
				return GetTypedColumnValue<string>("LMSUrl");
			}
			set {
				SetColumnValue("LMSUrl", value);
			}
		}

		/// <summary>
		/// Product version.
		/// </summary>
		public string ProductEdition {
			get {
				return GetTypedColumnValue<string>("ProductEdition");
			}
			set {
				SetColumnValue("ProductEdition", value);
			}
		}

		/// <summary>
		/// Configuration version.
		/// </summary>
		public string ConfigurationVersion {
			get {
				return GetTypedColumnValue<string>("ConfigurationVersion");
			}
			set {
				SetColumnValue("ConfigurationVersion", value);
			}
		}

		/// <summary>
		/// Code.
		/// </summary>
		public string Code {
			get {
				return GetTypedColumnValue<string>("Code");
			}
			set {
				SetColumnValue("Code", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ContextHelp_NUIEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ContextHelpDeleted", e);
			Validating += (s, e) => ThrowEvent("ContextHelpValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ContextHelp(this);
		}

		#endregion

	}

	#endregion

	#region Class: ContextHelp_NUIEventsProcess

	/// <exclude/>
	public partial class ContextHelp_NUIEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : ContextHelp
	{

		public ContextHelp_NUIEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ContextHelp_NUIEventsProcess";
			SchemaUId = new Guid("2f0eac0f-fb07-4efd-9134-b2c5f34a58de");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("2f0eac0f-fb07-4efd-9134-b2c5f34a58de");
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

	#region Class: ContextHelp_NUIEventsProcess

	/// <exclude/>
	public class ContextHelp_NUIEventsProcess : ContextHelp_NUIEventsProcess<ContextHelp>
	{

		public ContextHelp_NUIEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ContextHelp_NUIEventsProcess

	public partial class ContextHelp_NUIEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ContextHelpEventsProcess

	/// <exclude/>
	public class ContextHelpEventsProcess : ContextHelp_NUIEventsProcess
	{

		public ContextHelpEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

