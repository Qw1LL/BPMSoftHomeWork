namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Configuration;
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

	#region Class: Account_Completeness_BPMSoftSchema

	/// <exclude/>
	public class Account_Completeness_BPMSoftSchema : BPMSoft.Configuration.Account_Base_BPMSoftSchema
	{

		#region Constructors: Public

		public Account_Completeness_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public Account_Completeness_BPMSoftSchema(Account_Completeness_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public Account_Completeness_BPMSoftSchema(Account_Completeness_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("cc642965-191f-4b55-b1ea-fb8336e623b9");
			Name = "Account_Completeness_BPMSoft";
			ParentSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e");
			ExtendParent = true;
			CreatedInPackageId = new Guid("c7634d9a-901d-4a66-9f11-34c80c5250ce");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("58210e36-46cd-4a12-934c-c97e96ed4160")) == null) {
				Columns.Add(CreateCompletenessColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateCompletenessColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("58210e36-46cd-4a12-934c-c97e96ed4160"),
				Name = @"Completeness",
				CreatedInSchemaUId = new Guid("cc642965-191f-4b55-b1ea-fb8336e623b9"),
				ModifiedInSchemaUId = new Guid("cc642965-191f-4b55-b1ea-fb8336e623b9"),
				CreatedInPackageId = new Guid("c7634d9a-901d-4a66-9f11-34c80c5250ce"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"0"
				}
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new Account_Completeness_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Account_CompletenessEventsProcess(userConnection);
		}

		public override object Clone() {
			return new Account_Completeness_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new Account_Completeness_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("cc642965-191f-4b55-b1ea-fb8336e623b9"));
		}

		#endregion

	}

	#endregion

	#region Class: Account_Completeness_BPMSoft

	/// <summary>
	/// Account.
	/// </summary>
	public class Account_Completeness_BPMSoft : BPMSoft.Configuration.Account_Base_BPMSoft
	{

		#region Constructors: Public

		public Account_Completeness_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Account_Completeness_BPMSoft";
		}

		public Account_Completeness_BPMSoft(Account_Completeness_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Data entry compliance.
		/// </summary>
		public int Completeness {
			get {
				return GetTypedColumnValue<int>("Completeness");
			}
			set {
				SetColumnValue("Completeness", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Account_CompletenessEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("Account_Completeness_BPMSoftDeleted", e);
			Validating += (s, e) => ThrowEvent("Account_Completeness_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new Account_Completeness_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: Account_CompletenessEventsProcess

	/// <exclude/>
	public partial class Account_CompletenessEventsProcess<TEntity> : BPMSoft.Configuration.Account_BaseEventsProcess<TEntity> where TEntity : Account_Completeness_BPMSoft
	{

		public Account_CompletenessEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Account_CompletenessEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("cc642965-191f-4b55-b1ea-fb8336e623b9");
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

	#region Class: Account_CompletenessEventsProcess

	/// <exclude/>
	public class Account_CompletenessEventsProcess : Account_CompletenessEventsProcess<Account_Completeness_BPMSoft>
	{

		public Account_CompletenessEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: Account_CompletenessEventsProcess

	public partial class Account_CompletenessEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

