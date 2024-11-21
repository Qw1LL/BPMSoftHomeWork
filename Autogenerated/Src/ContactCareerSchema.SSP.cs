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

	#region Class: ContactCareerSchema

	/// <exclude/>
	public class ContactCareerSchema : BPMSoft.Configuration.ContactCareer_Base_BPMSoftSchema
	{

		#region Constructors: Public

		public ContactCareerSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ContactCareerSchema(ContactCareerSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ContactCareerSchema(ContactCareerSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateI74adXnmFiCFKGusIbN0Dbj6qLecIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = true,
				IsClustered = false,
				IsUnique = false
			};
			index.UId = new Guid("17cb5432-9f78-4115-a8c8-643ca03dac9c");
			index.Name = "I74adXnmFiCFKGusIbN0Dbj6qLec";
			index.CreatedInSchemaUId = new Guid("a0a1d0c3-6267-4584-acbd-fd53660798ce");
			index.ModifiedInSchemaUId = new Guid("a0a1d0c3-6267-4584-acbd-fd53660798ce");
			index.CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2");
			EntitySchemaIndexColumn contactIdIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("05f34390-f7ed-41ff-87b8-8ebf2e779d42"),
				ColumnUId = new Guid("d6628cf3-ba29-472e-b0f2-9b51f693ef2a"),
				CreatedInSchemaUId = new Guid("a0a1d0c3-6267-4584-acbd-fd53660798ce"),
				ModifiedInSchemaUId = new Guid("a0a1d0c3-6267-4584-acbd-fd53660798ce"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(contactIdIndexColumn);
			EntitySchemaIndexColumn accountIdIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("a9d46f67-ad38-46bc-b369-368490bc8e24"),
				ColumnUId = new Guid("8996b0d8-c0d9-4da7-b130-7917fa48b854"),
				CreatedInSchemaUId = new Guid("a0a1d0c3-6267-4584-acbd-fd53660798ce"),
				ModifiedInSchemaUId = new Guid("a0a1d0c3-6267-4584-acbd-fd53660798ce"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(accountIdIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("d0285434-a920-404c-9296-d9a47e1d6269");
			Name = "ContactCareer";
			ParentSchemaUId = new Guid("a0a1d0c3-6267-4584-acbd-fd53660798ce");
			ExtendParent = true;
			CreatedInPackageId = new Guid("d7352345-17a4-46e8-b32e-306ac0453d7a");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeMasterRecordColumn() {
			base.InitializeMasterRecordColumn();
			MasterRecordColumn = CreateContactColumn();
			if (Columns.FindByUId(MasterRecordColumn.UId) == null) {
				Columns.Add(MasterRecordColumn);
			}
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
			Indexes.Add(CreateI74adXnmFiCFKGusIbN0Dbj6qLecIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ContactCareer(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ContactCareer_SSPEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ContactCareerSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ContactCareerSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("d0285434-a920-404c-9296-d9a47e1d6269"));
		}

		#endregion

	}

	#endregion

	#region Class: ContactCareer

	/// <summary>
	/// Job experience of contact.
	/// </summary>
	public class ContactCareer : BPMSoft.Configuration.ContactCareer_Base_BPMSoft
	{

		#region Constructors: Public

		public ContactCareer(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ContactCareer";
		}

		public ContactCareer(ContactCareer source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ContactCareer_SSPEventsProcess(UserConnection);
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
			return new ContactCareer(this);
		}

		#endregion

	}

	#endregion

	#region Class: ContactCareer_SSPEventsProcess

	/// <exclude/>
	public partial class ContactCareer_SSPEventsProcess<TEntity> : BPMSoft.Configuration.ContactCareer_BaseEventsProcess<TEntity> where TEntity : ContactCareer
	{

		public ContactCareer_SSPEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ContactCareer_SSPEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("d0285434-a920-404c-9296-d9a47e1d6269");
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

	#region Class: ContactCareer_SSPEventsProcess

	/// <exclude/>
	public class ContactCareer_SSPEventsProcess : ContactCareer_SSPEventsProcess<ContactCareer>
	{

		public ContactCareer_SSPEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ContactCareer_SSPEventsProcess

	public partial class ContactCareer_SSPEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ContactCareerEventsProcess

	/// <exclude/>
	public class ContactCareerEventsProcess : ContactCareer_SSPEventsProcess
	{

		public ContactCareerEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

