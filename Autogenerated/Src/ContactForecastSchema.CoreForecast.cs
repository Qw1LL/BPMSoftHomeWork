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

	#region Class: ContactForecastSchema

	/// <exclude/>
	public class ContactForecastSchema : BPMSoft.Configuration.EntityInForecastCellSchema
	{

		#region Constructors: Public

		public ContactForecastSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ContactForecastSchema(ContactForecastSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ContactForecastSchema(ContactForecastSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("367c714a-8bb9-4a02-b357-03c87fe7076c");
			RealUId = new Guid("367c714a-8bb9-4a02-b357-03c87fe7076c");
			Name = "ContactForecast";
			ParentSchemaUId = new Guid("3a622ca4-e1ea-4273-8b41-c20129310fd7");
			ExtendParent = false;
			CreatedInPackageId = new Guid("e0b9d996-6f7e-4520-a678-da960c79be39");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("ba8b2d0e-fa17-4688-b0b2-c020d7b1ff8a")) == null) {
				Columns.Add(CreateContactColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateContactColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("ba8b2d0e-fa17-4688-b0b2-c020d7b1ff8a"),
				Name = @"Contact",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("367c714a-8bb9-4a02-b357-03c87fe7076c"),
				ModifiedInSchemaUId = new Guid("367c714a-8bb9-4a02-b357-03c87fe7076c"),
				CreatedInPackageId = new Guid("e0b9d996-6f7e-4520-a678-da960c79be39")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ContactForecast(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ContactForecast_CoreForecastEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ContactForecastSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ContactForecastSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("367c714a-8bb9-4a02-b357-03c87fe7076c"));
		}

		#endregion

	}

	#endregion

	#region Class: ContactForecast

	/// <summary>
	/// Планирование по ответственному.
	/// </summary>
	public class ContactForecast : BPMSoft.Configuration.EntityInForecastCell
	{

		#region Constructors: Public

		public ContactForecast(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ContactForecast";
		}

		public ContactForecast(ContactForecast source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid ContactId {
			get {
				return GetTypedColumnValue<Guid>("ContactId");
			}
			set {
				SetColumnValue("ContactId", value);
				_contact = null;
			}
		}

		/// <exclude/>
		public string ContactName {
			get {
				return GetTypedColumnValue<string>("ContactName");
			}
			set {
				SetColumnValue("ContactName", value);
				if (_contact != null) {
					_contact.Name = value;
				}
			}
		}

		private Contact _contact;
		/// <summary>
		/// Контакт.
		/// </summary>
		public Contact Contact {
			get {
				return _contact ??
					(_contact = LookupColumnEntities.GetEntity("Contact") as Contact);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ContactForecast_CoreForecastEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Inserting += (s, e) => ThrowEvent("ContactForecastInserting", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ContactForecast(this);
		}

		#endregion

	}

	#endregion

	#region Class: ContactForecast_CoreForecastEventsProcess

	/// <exclude/>
	public partial class ContactForecast_CoreForecastEventsProcess<TEntity> : BPMSoft.Configuration.EntityInForecastCell_CoreForecastEventsProcess<TEntity> where TEntity : ContactForecast
	{

		public ContactForecast_CoreForecastEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ContactForecast_CoreForecastEventsProcess";
			SchemaUId = new Guid("367c714a-8bb9-4a02-b357-03c87fe7076c");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("367c714a-8bb9-4a02-b357-03c87fe7076c");
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

	#region Class: ContactForecast_CoreForecastEventsProcess

	/// <exclude/>
	public class ContactForecast_CoreForecastEventsProcess : ContactForecast_CoreForecastEventsProcess<ContactForecast>
	{

		public ContactForecast_CoreForecastEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ContactForecast_CoreForecastEventsProcess

	public partial class ContactForecast_CoreForecastEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ContactForecastEventsProcess

	/// <exclude/>
	public class ContactForecastEventsProcess : ContactForecast_CoreForecastEventsProcess
	{

		public ContactForecastEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

