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
	using SystemSettings = BPMSoft.Core.Configuration.SysSettings;

	#region Class: Contact_MLangContent_BPMSoftSchema

	/// <exclude/>
	public class Contact_MLangContent_BPMSoftSchema : BPMSoft.Configuration.Contact_Mobile_BPMSoftSchema
	{

		#region Constructors: Public

		public Contact_MLangContent_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public Contact_MLangContent_BPMSoftSchema(Contact_MLangContent_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public Contact_MLangContent_BPMSoftSchema(Contact_MLangContent_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("d32f53dd-783a-4e71-b094-b84f4caf68fd");
			Name = "Contact_MLangContent_BPMSoft";
			ParentSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3");
			ExtendParent = true;
			CreatedInPackageId = new Guid("f767c979-312c-4d92-9d28-97b2835309c5");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override EntitySchemaColumn CreateLanguageColumn() {
			EntitySchemaColumn column = base.CreateLanguageColumn();
			column.DefValue = new EntitySchemaColumnDef() {
				Source = EntitySchemaColumnDefSource.Settings,
				ValueSource = @"DefaultMessageLanguage"
			};
			column.ModifiedInSchemaUId = new Guid("d32f53dd-783a-4e71-b094-b84f4caf68fd");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new Contact_MLangContent_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Contact_MLangContentEventsProcess(userConnection);
		}

		public override object Clone() {
			return new Contact_MLangContent_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new Contact_MLangContent_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("d32f53dd-783a-4e71-b094-b84f4caf68fd"));
		}

		#endregion

	}

	#endregion

	#region Class: Contact_MLangContent_BPMSoft

	/// <summary>
	/// Contact.
	/// </summary>
	public class Contact_MLangContent_BPMSoft : BPMSoft.Configuration.Contact_Mobile_BPMSoft
	{

		#region Constructors: Public

		public Contact_MLangContent_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Contact_MLangContent_BPMSoft";
		}

		public Contact_MLangContent_BPMSoft(Contact_MLangContent_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Contact_MLangContentEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Inserting += (s, e) => ThrowEvent("Contact_MLangContent_BPMSoftInserting", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new Contact_MLangContent_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: Contact_MLangContentEventsProcess

	/// <exclude/>
	public partial class Contact_MLangContentEventsProcess<TEntity> : BPMSoft.Configuration.Contact_MobileEventsProcess<TEntity> where TEntity : Contact_MLangContent_BPMSoft
	{

		public Contact_MLangContentEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Contact_MLangContentEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("d32f53dd-783a-4e71-b094-b84f4caf68fd");
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

	#region Class: Contact_MLangContentEventsProcess

	/// <exclude/>
	public class Contact_MLangContentEventsProcess : Contact_MLangContentEventsProcess<Contact_MLangContent_BPMSoft>
	{

		public Contact_MLangContentEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: Contact_MLangContentEventsProcess

	public partial class Contact_MLangContentEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

