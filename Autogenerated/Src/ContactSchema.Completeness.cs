namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Configuration;
	using BPMSoft.Configuration.EntitySynchronization;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.DcmProcess;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;
	using BPMSoft.Core.ImageAPI;
	using BPMSoft.Core.Process;
	using BPMSoft.Core.Process.Configuration;
	using BPMSoft.GlobalSearch.Indexing;
	using BPMSoft.Messaging.Common;
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

	#region Class: Contact_Completeness_BPMSoftSchema

	/// <exclude/>
	public class Contact_Completeness_BPMSoftSchema : BPMSoft.Configuration.Contact_MLangContent_BPMSoftSchema
	{

		#region Constructors: Public

		public Contact_Completeness_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public Contact_Completeness_BPMSoftSchema(Contact_Completeness_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public Contact_Completeness_BPMSoftSchema(Contact_Completeness_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("611e0fa6-06d8-4c81-ad2a-3516e0910aa1");
			Name = "Contact_Completeness_BPMSoft";
			ParentSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3");
			ExtendParent = true;
			CreatedInPackageId = new Guid("c7634d9a-901d-4a66-9f11-34c80c5250ce");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("60367403-6019-4d03-971d-169a5ec27542")) == null) {
				Columns.Add(CreateCompletenessColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateCompletenessColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("60367403-6019-4d03-971d-169a5ec27542"),
				Name = @"Completeness",
				CreatedInSchemaUId = new Guid("611e0fa6-06d8-4c81-ad2a-3516e0910aa1"),
				ModifiedInSchemaUId = new Guid("611e0fa6-06d8-4c81-ad2a-3516e0910aa1"),
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
			return new Contact_Completeness_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Contact_CompletenessEventsProcess(userConnection);
		}

		public override object Clone() {
			return new Contact_Completeness_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new Contact_Completeness_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("611e0fa6-06d8-4c81-ad2a-3516e0910aa1"));
		}

		#endregion

	}

	#endregion

	#region Class: Contact_Completeness_BPMSoft

	/// <summary>
	/// Contact.
	/// </summary>
	public class Contact_Completeness_BPMSoft : BPMSoft.Configuration.Contact_MLangContent_BPMSoft
	{

		#region Constructors: Public

		public Contact_Completeness_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Contact_Completeness_BPMSoft";
		}

		public Contact_Completeness_BPMSoft(Contact_Completeness_BPMSoft source)
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
			var process = new Contact_CompletenessEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("Contact_Completeness_BPMSoftDeleted", e);
			Deleting += (s, e) => ThrowEvent("Contact_Completeness_BPMSoftDeleting", e);
			Validating += (s, e) => ThrowEvent("Contact_Completeness_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new Contact_Completeness_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: Contact_CompletenessEventsProcess

	/// <exclude/>
	public partial class Contact_CompletenessEventsProcess<TEntity> : BPMSoft.Configuration.Contact_MLangContentEventsProcess<TEntity> where TEntity : Contact_Completeness_BPMSoft
	{

		public Contact_CompletenessEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Contact_CompletenessEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("611e0fa6-06d8-4c81-ad2a-3516e0910aa1");
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

	#region Class: Contact_CompletenessEventsProcess

	/// <exclude/>
	public class Contact_CompletenessEventsProcess : Contact_CompletenessEventsProcess<Contact_Completeness_BPMSoft>
	{

		public Contact_CompletenessEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: Contact_CompletenessEventsProcess

	public partial class Contact_CompletenessEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

