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

	#region Class: MailboxFoldersCorrespondenceSchema

	/// <exclude/>
	public class MailboxFoldersCorrespondenceSchema : BPMSoft.Configuration.MailboxFoldersCorrespondence_Base_BPMSoftSchema
	{

		#region Constructors: Public

		public MailboxFoldersCorrespondenceSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public MailboxFoldersCorrespondenceSchema(MailboxFoldersCorrespondenceSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public MailboxFoldersCorrespondenceSchema(MailboxFoldersCorrespondenceSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("c148c614-e335-42a2-9247-19d48c6a13ae");
			Name = "MailboxFoldersCorrespondence";
			ParentSchemaUId = new Guid("ae770c57-1b04-46ac-85cc-2bc38008a9fc");
			ExtendParent = true;
			CreatedInPackageId = new Guid("43a72267-b2f6-464f-af52-bc7506959e73");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override EntitySchemaColumn CreateFolderPathColumn() {
			EntitySchemaColumn column = base.CreateFolderPathColumn();
			column.DataValueType = DataValueTypeManager.GetInstanceByName("LongText");
			column.ModifiedInSchemaUId = new Guid("c148c614-e335-42a2-9247-19d48c6a13ae");
			column.CreatedInPackageId = new Guid("43a72267-b2f6-464f-af52-bc7506959e73");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new MailboxFoldersCorrespondence(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new MailboxFoldersCorrespondence_ExchangeEventsProcess(userConnection);
		}

		public override object Clone() {
			return new MailboxFoldersCorrespondenceSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new MailboxFoldersCorrespondenceSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("c148c614-e335-42a2-9247-19d48c6a13ae"));
		}

		#endregion

	}

	#endregion

	#region Class: MailboxFoldersCorrespondence

	/// <summary>
	/// Correlation between Activity folders and Mailbox folders.
	/// </summary>
	public class MailboxFoldersCorrespondence : BPMSoft.Configuration.MailboxFoldersCorrespondence_Base_BPMSoft
	{

		#region Constructors: Public

		public MailboxFoldersCorrespondence(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "MailboxFoldersCorrespondence";
		}

		public MailboxFoldersCorrespondence(MailboxFoldersCorrespondence source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new MailboxFoldersCorrespondence_ExchangeEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Inserting += (s, e) => ThrowEvent("MailboxFoldersCorrespondenceInserting", e);
			Validating += (s, e) => ThrowEvent("MailboxFoldersCorrespondenceValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new MailboxFoldersCorrespondence(this);
		}

		#endregion

	}

	#endregion

	#region Class: MailboxFoldersCorrespondence_ExchangeEventsProcess

	/// <exclude/>
	public partial class MailboxFoldersCorrespondence_ExchangeEventsProcess<TEntity> : BPMSoft.Configuration.MailboxFoldersCorrespondence_BaseEventsProcess<TEntity> where TEntity : MailboxFoldersCorrespondence
	{

		public MailboxFoldersCorrespondence_ExchangeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "MailboxFoldersCorrespondence_ExchangeEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("c148c614-e335-42a2-9247-19d48c6a13ae");
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

	#region Class: MailboxFoldersCorrespondence_ExchangeEventsProcess

	/// <exclude/>
	public class MailboxFoldersCorrespondence_ExchangeEventsProcess : MailboxFoldersCorrespondence_ExchangeEventsProcess<MailboxFoldersCorrespondence>
	{

		public MailboxFoldersCorrespondence_ExchangeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: MailboxFoldersCorrespondence_ExchangeEventsProcess

	public partial class MailboxFoldersCorrespondence_ExchangeEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: MailboxFoldersCorrespondenceEventsProcess

	/// <exclude/>
	public class MailboxFoldersCorrespondenceEventsProcess : MailboxFoldersCorrespondence_ExchangeEventsProcess
	{

		public MailboxFoldersCorrespondenceEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

