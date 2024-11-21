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

	#region Class: Account_EmailMining_BPMSoftSchema

	/// <exclude/>
	public class Account_EmailMining_BPMSoftSchema : BPMSoft.Configuration.Account_Completeness_BPMSoftSchema
	{

		#region Constructors: Public

		public Account_EmailMining_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public Account_EmailMining_BPMSoftSchema(Account_EmailMining_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public Account_EmailMining_BPMSoftSchema(Account_EmailMining_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateIAccountAlternativeNameIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = false
			};
			index.UId = new Guid("ebe37f22-d03b-4ff5-85ab-b19cfd41de7b");
			index.Name = "IAccountAlternativeName";
			index.CreatedInSchemaUId = new Guid("b9b0db9a-65de-4b97-aece-47ffe851884b");
			index.ModifiedInSchemaUId = new Guid("b9b0db9a-65de-4b97-aece-47ffe851884b");
			index.CreatedInPackageId = new Guid("b6327e89-1dee-4b6f-a695-226c016beae1");
			EntitySchemaIndexColumn alternativeNameIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("58081ad2-6e01-4b09-8a7f-d6e550fd4d71"),
				ColumnUId = new Guid("e36ae687-347d-4bf7-b260-90129862e357"),
				CreatedInSchemaUId = new Guid("b9b0db9a-65de-4b97-aece-47ffe851884b"),
				ModifiedInSchemaUId = new Guid("b9b0db9a-65de-4b97-aece-47ffe851884b"),
				CreatedInPackageId = new Guid("b6327e89-1dee-4b6f-a695-226c016beae1"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(alternativeNameIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("b9b0db9a-65de-4b97-aece-47ffe851884b");
			Name = "Account_EmailMining_BPMSoft";
			ParentSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e");
			ExtendParent = true;
			CreatedInPackageId = new Guid("b6327e89-1dee-4b6f-a695-226c016beae1");
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

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateIAccountAlternativeNameIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new Account_EmailMining_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Account_EmailMiningEventsProcess(userConnection);
		}

		public override object Clone() {
			return new Account_EmailMining_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new Account_EmailMining_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("b9b0db9a-65de-4b97-aece-47ffe851884b"));
		}

		#endregion

	}

	#endregion

	#region Class: Account_EmailMining_BPMSoft

	/// <summary>
	/// Account.
	/// </summary>
	public class Account_EmailMining_BPMSoft : BPMSoft.Configuration.Account_Completeness_BPMSoft
	{

		#region Constructors: Public

		public Account_EmailMining_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Account_EmailMining_BPMSoft";
		}

		public Account_EmailMining_BPMSoft(Account_EmailMining_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Account_EmailMiningEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Validating += (s, e) => ThrowEvent("Account_EmailMining_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new Account_EmailMining_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: Account_EmailMiningEventsProcess

	/// <exclude/>
	public partial class Account_EmailMiningEventsProcess<TEntity> : BPMSoft.Configuration.Account_CompletenessEventsProcess<TEntity> where TEntity : Account_EmailMining_BPMSoft
	{

		public Account_EmailMiningEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Account_EmailMiningEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("b9b0db9a-65de-4b97-aece-47ffe851884b");
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

	#region Class: Account_EmailMiningEventsProcess

	/// <exclude/>
	public class Account_EmailMiningEventsProcess : Account_EmailMiningEventsProcess<Account_EmailMining_BPMSoft>
	{

		public Account_EmailMiningEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: Account_EmailMiningEventsProcess

	public partial class Account_EmailMiningEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

