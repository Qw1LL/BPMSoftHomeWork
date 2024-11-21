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

	#region Class: ComTypebyCommunicationSchema

	/// <exclude/>
	public class ComTypebyCommunicationSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public ComTypebyCommunicationSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ComTypebyCommunicationSchema(ComTypebyCommunicationSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ComTypebyCommunicationSchema(ComTypebyCommunicationSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("2d85be2c-eb94-4486-bddd-c6b8d1f3c5d2");
			RealUId = new Guid("2d85be2c-eb94-4486-bddd-c6b8d1f3c5d2");
			Name = "ComTypebyCommunication";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("34b83991-65a0-4978-ac5e-73cd4e167a4a")) == null) {
				Columns.Add(CreateCommunicationTypeColumn());
			}
			if (Columns.FindByUId(new Guid("dfa76dad-9bb7-4c53-9a63-e4f6482776b9")) == null) {
				Columns.Add(CreateCommunicationColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateCommunicationTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("34b83991-65a0-4978-ac5e-73cd4e167a4a"),
				Name = @"CommunicationType",
				ReferenceSchemaUId = new Guid("d846cb4f-f18d-469e-83ff-e961f3fba873"),
				IsCascade = true,
				CreatedInSchemaUId = new Guid("2d85be2c-eb94-4486-bddd-c6b8d1f3c5d2"),
				ModifiedInSchemaUId = new Guid("2d85be2c-eb94-4486-bddd-c6b8d1f3c5d2"),
				CreatedInPackageId = new Guid("c692daa9-de5e-4e96-afd3-e992ed86681c")
			};
		}

		protected virtual EntitySchemaColumn CreateCommunicationColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("dfa76dad-9bb7-4c53-9a63-e4f6482776b9"),
				Name = @"Communication",
				ReferenceSchemaUId = new Guid("2875aefb-92b6-4b17-9ef6-22fa306f4c3f"),
				CreatedInSchemaUId = new Guid("2d85be2c-eb94-4486-bddd-c6b8d1f3c5d2"),
				ModifiedInSchemaUId = new Guid("2d85be2c-eb94-4486-bddd-c6b8d1f3c5d2"),
				CreatedInPackageId = new Guid("c692daa9-de5e-4e96-afd3-e992ed86681c")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ComTypebyCommunication(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ComTypebyCommunication_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ComTypebyCommunicationSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ComTypebyCommunicationSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("2d85be2c-eb94-4486-bddd-c6b8d1f3c5d2"));
		}

		#endregion

	}

	#endregion

	#region Class: ComTypebyCommunication

	/// <summary>
	/// Communication option types by communication type.
	/// </summary>
	public class ComTypebyCommunication : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public ComTypebyCommunication(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ComTypebyCommunication";
		}

		public ComTypebyCommunication(ComTypebyCommunication source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid CommunicationTypeId {
			get {
				return GetTypedColumnValue<Guid>("CommunicationTypeId");
			}
			set {
				SetColumnValue("CommunicationTypeId", value);
				_communicationType = null;
			}
		}

		/// <exclude/>
		public string CommunicationTypeName {
			get {
				return GetTypedColumnValue<string>("CommunicationTypeName");
			}
			set {
				SetColumnValue("CommunicationTypeName", value);
				if (_communicationType != null) {
					_communicationType.Name = value;
				}
			}
		}

		private CommunicationType _communicationType;
		/// <summary>
		/// Communication option type.
		/// </summary>
		public CommunicationType CommunicationType {
			get {
				return _communicationType ??
					(_communicationType = LookupColumnEntities.GetEntity("CommunicationType") as CommunicationType);
			}
		}

		/// <exclude/>
		public Guid CommunicationId {
			get {
				return GetTypedColumnValue<Guid>("CommunicationId");
			}
			set {
				SetColumnValue("CommunicationId", value);
				_communication = null;
			}
		}

		/// <exclude/>
		public string CommunicationName {
			get {
				return GetTypedColumnValue<string>("CommunicationName");
			}
			set {
				SetColumnValue("CommunicationName", value);
				if (_communication != null) {
					_communication.Name = value;
				}
			}
		}

		private Communication _communication;
		/// <summary>
		/// Communication type.
		/// </summary>
		public Communication Communication {
			get {
				return _communication ??
					(_communication = LookupColumnEntities.GetEntity("Communication") as Communication);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ComTypebyCommunication_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ComTypebyCommunicationDeleted", e);
			Deleting += (s, e) => ThrowEvent("ComTypebyCommunicationDeleting", e);
			Inserted += (s, e) => ThrowEvent("ComTypebyCommunicationInserted", e);
			Inserting += (s, e) => ThrowEvent("ComTypebyCommunicationInserting", e);
			Saved += (s, e) => ThrowEvent("ComTypebyCommunicationSaved", e);
			Saving += (s, e) => ThrowEvent("ComTypebyCommunicationSaving", e);
			Validating += (s, e) => ThrowEvent("ComTypebyCommunicationValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ComTypebyCommunication(this);
		}

		#endregion

	}

	#endregion

	#region Class: ComTypebyCommunication_BaseEventsProcess

	/// <exclude/>
	public partial class ComTypebyCommunication_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : ComTypebyCommunication
	{

		public ComTypebyCommunication_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ComTypebyCommunication_BaseEventsProcess";
			SchemaUId = new Guid("2d85be2c-eb94-4486-bddd-c6b8d1f3c5d2");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("2d85be2c-eb94-4486-bddd-c6b8d1f3c5d2");
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

	#region Class: ComTypebyCommunication_BaseEventsProcess

	/// <exclude/>
	public class ComTypebyCommunication_BaseEventsProcess : ComTypebyCommunication_BaseEventsProcess<ComTypebyCommunication>
	{

		public ComTypebyCommunication_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ComTypebyCommunication_BaseEventsProcess

	public partial class ComTypebyCommunication_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ComTypebyCommunicationEventsProcess

	/// <exclude/>
	public class ComTypebyCommunicationEventsProcess : ComTypebyCommunication_BaseEventsProcess
	{

		public ComTypebyCommunicationEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

