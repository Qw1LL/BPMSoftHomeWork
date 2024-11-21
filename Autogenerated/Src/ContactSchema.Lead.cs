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

	#region Class: Contact_Lead_BPMSoftSchema

	/// <exclude/>
	public class Contact_Lead_BPMSoftSchema : BPMSoft.Configuration.Contact_RelationshipDesigner_BPMSoftSchema
	{

		#region Constructors: Public

		public Contact_Lead_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public Contact_Lead_BPMSoftSchema(Contact_Lead_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public Contact_Lead_BPMSoftSchema(Contact_Lead_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("5b07e28c-394d-465a-87c0-1e303692c055");
			Name = "Contact_Lead_BPMSoft";
			ParentSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3");
			ExtendParent = true;
			CreatedInPackageId = new Guid("f56ba749-b4df-4ded-b740-db30fa3555ae");
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

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new Contact_Lead_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Contact_LeadEventsProcess(userConnection);
		}

		public override object Clone() {
			return new Contact_Lead_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new Contact_Lead_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("5b07e28c-394d-465a-87c0-1e303692c055"));
		}

		#endregion

	}

	#endregion

	#region Class: Contact_Lead_BPMSoft

	/// <summary>
	/// Контакт.
	/// </summary>
	public class Contact_Lead_BPMSoft : BPMSoft.Configuration.Contact_RelationshipDesigner_BPMSoft
	{

		#region Constructors: Public

		public Contact_Lead_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Contact_Lead_BPMSoft";
		}

		public Contact_Lead_BPMSoft(Contact_Lead_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Contact_LeadEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("Contact_Lead_BPMSoftDeleted", e);
			Deleting += (s, e) => ThrowEvent("Contact_Lead_BPMSoftDeleting", e);
			Inserting += (s, e) => ThrowEvent("Contact_Lead_BPMSoftInserting", e);
			Validating += (s, e) => ThrowEvent("Contact_Lead_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new Contact_Lead_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: Contact_LeadEventsProcess

	/// <exclude/>
	public partial class Contact_LeadEventsProcess<TEntity> : BPMSoft.Configuration.Contact_RelationshipDesignerEventsProcess<TEntity> where TEntity : Contact_Lead_BPMSoft
	{

		public Contact_LeadEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Contact_LeadEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("5b07e28c-394d-465a-87c0-1e303692c055");
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

	#region Class: Contact_LeadEventsProcess

	/// <exclude/>
	public class Contact_LeadEventsProcess : Contact_LeadEventsProcess<Contact_Lead_BPMSoft>
	{

		public Contact_LeadEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: Contact_LeadEventsProcess

	public partial class Contact_LeadEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

