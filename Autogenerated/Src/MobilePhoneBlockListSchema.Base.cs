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

	#region Class: MobilePhoneBlockListSchema

	/// <exclude/>
	public class MobilePhoneBlockListSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public MobilePhoneBlockListSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public MobilePhoneBlockListSchema(MobilePhoneBlockListSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public MobilePhoneBlockListSchema(MobilePhoneBlockListSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("c83f17aa-dfa8-4805-9905-e07e2884ad01");
			RealUId = new Guid("c83f17aa-dfa8-4805-9905-e07e2884ad01");
			Name = "MobilePhoneBlockList";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("467e8661-453f-46e6-ab9a-2749b5699bb7");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("94e982b3-cf08-4489-924e-e7fda13fd117")) == null) {
				Columns.Add(CreateMobilePhoneColumn());
			}
			if (Columns.FindByUId(new Guid("cf64a527-c1e1-4c54-bb90-8c4f49984ea5")) == null) {
				Columns.Add(CreateBlockedOnColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("c83f17aa-dfa8-4805-9905-e07e2884ad01");
			column.CreatedInPackageId = new Guid("467e8661-453f-46e6-ab9a-2749b5699bb7");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("c83f17aa-dfa8-4805-9905-e07e2884ad01");
			column.CreatedInPackageId = new Guid("467e8661-453f-46e6-ab9a-2749b5699bb7");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("c83f17aa-dfa8-4805-9905-e07e2884ad01");
			column.CreatedInPackageId = new Guid("467e8661-453f-46e6-ab9a-2749b5699bb7");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("c83f17aa-dfa8-4805-9905-e07e2884ad01");
			column.CreatedInPackageId = new Guid("467e8661-453f-46e6-ab9a-2749b5699bb7");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("c83f17aa-dfa8-4805-9905-e07e2884ad01");
			column.CreatedInPackageId = new Guid("467e8661-453f-46e6-ab9a-2749b5699bb7");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("c83f17aa-dfa8-4805-9905-e07e2884ad01");
			column.CreatedInPackageId = new Guid("467e8661-453f-46e6-ab9a-2749b5699bb7");
			return column;
		}

		protected virtual EntitySchemaColumn CreateMobilePhoneColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("94e982b3-cf08-4489-924e-e7fda13fd117"),
				Name = @"MobilePhone",
				CreatedInSchemaUId = new Guid("c83f17aa-dfa8-4805-9905-e07e2884ad01"),
				ModifiedInSchemaUId = new Guid("c83f17aa-dfa8-4805-9905-e07e2884ad01"),
				CreatedInPackageId = new Guid("467e8661-453f-46e6-ab9a-2749b5699bb7")
			};
		}

		protected virtual EntitySchemaColumn CreateBlockedOnColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("cf64a527-c1e1-4c54-bb90-8c4f49984ea5"),
				Name = @"BlockedOn",
				CreatedInSchemaUId = new Guid("c83f17aa-dfa8-4805-9905-e07e2884ad01"),
				ModifiedInSchemaUId = new Guid("c83f17aa-dfa8-4805-9905-e07e2884ad01"),
				CreatedInPackageId = new Guid("467e8661-453f-46e6-ab9a-2749b5699bb7")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new MobilePhoneBlockList(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new MobilePhoneBlockList_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new MobilePhoneBlockListSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new MobilePhoneBlockListSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("c83f17aa-dfa8-4805-9905-e07e2884ad01"));
		}

		#endregion

	}

	#endregion

	#region Class: MobilePhoneBlockList

	/// <summary>
	/// List of blocked numbers.
	/// </summary>
	public class MobilePhoneBlockList : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public MobilePhoneBlockList(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "MobilePhoneBlockList";
		}

		public MobilePhoneBlockList(MobilePhoneBlockList source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Mobile phone.
		/// </summary>
		public string MobilePhone {
			get {
				return GetTypedColumnValue<string>("MobilePhone");
			}
			set {
				SetColumnValue("MobilePhone", value);
			}
		}

		/// <summary>
		/// Locked on.
		/// </summary>
		public DateTime BlockedOn {
			get {
				return GetTypedColumnValue<DateTime>("BlockedOn");
			}
			set {
				SetColumnValue("BlockedOn", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new MobilePhoneBlockList_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("MobilePhoneBlockListDeleted", e);
			Inserting += (s, e) => ThrowEvent("MobilePhoneBlockListInserting", e);
			Validating += (s, e) => ThrowEvent("MobilePhoneBlockListValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new MobilePhoneBlockList(this);
		}

		#endregion

	}

	#endregion

	#region Class: MobilePhoneBlockList_BaseEventsProcess

	/// <exclude/>
	public partial class MobilePhoneBlockList_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : MobilePhoneBlockList
	{

		public MobilePhoneBlockList_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "MobilePhoneBlockList_BaseEventsProcess";
			SchemaUId = new Guid("c83f17aa-dfa8-4805-9905-e07e2884ad01");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("c83f17aa-dfa8-4805-9905-e07e2884ad01");
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

	#region Class: MobilePhoneBlockList_BaseEventsProcess

	/// <exclude/>
	public class MobilePhoneBlockList_BaseEventsProcess : MobilePhoneBlockList_BaseEventsProcess<MobilePhoneBlockList>
	{

		public MobilePhoneBlockList_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: MobilePhoneBlockList_BaseEventsProcess

	public partial class MobilePhoneBlockList_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: MobilePhoneBlockListEventsProcess

	/// <exclude/>
	public class MobilePhoneBlockListEventsProcess : MobilePhoneBlockList_BaseEventsProcess
	{

		public MobilePhoneBlockListEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

