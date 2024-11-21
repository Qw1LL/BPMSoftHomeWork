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

	#region Class: DaDataSuggestionsFieldSchema

	/// <exclude/>
	public class DaDataSuggestionsFieldSchema : BPMSoft.Configuration.BaseCodeLookupSchema
	{

		#region Constructors: Public

		public DaDataSuggestionsFieldSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public DaDataSuggestionsFieldSchema(DaDataSuggestionsFieldSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public DaDataSuggestionsFieldSchema(DaDataSuggestionsFieldSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("1fc1a03b-2bef-47ed-89e0-6a41665871e9");
			RealUId = new Guid("1fc1a03b-2bef-47ed-89e0-6a41665871e9");
			Name = "DaDataSuggestionsField";
			ParentSchemaUId = new Guid("2681062b-df59-4e52-89ed-f9b7dc909ab2");
			ExtendParent = false;
			CreatedInPackageId = new Guid("3003ba4f-492e-4787-9e54-367e73442d72");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("b764a991-eecd-41da-bf0d-aca9ab1c8e47")) == null) {
				Columns.Add(CreateTypeColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("b764a991-eecd-41da-bf0d-aca9ab1c8e47"),
				Name = @"Type",
				ReferenceSchemaUId = new Guid("f2d46613-3181-46dd-bacf-c10ef438c6b7"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("1fc1a03b-2bef-47ed-89e0-6a41665871e9"),
				ModifiedInSchemaUId = new Guid("1fc1a03b-2bef-47ed-89e0-6a41665871e9"),
				CreatedInPackageId = new Guid("3003ba4f-492e-4787-9e54-367e73442d72"),
				IsSimpleLookup = true
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new DaDataSuggestionsField(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new DaDataSuggestionsField_DaDataSuggestionsEventsProcess(userConnection);
		}

		public override object Clone() {
			return new DaDataSuggestionsFieldSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new DaDataSuggestionsFieldSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("1fc1a03b-2bef-47ed-89e0-6a41665871e9"));
		}

		#endregion

	}

	#endregion

	#region Class: DaDataSuggestionsField

	/// <summary>
	/// Поле из DaData.
	/// </summary>
	public class DaDataSuggestionsField : BPMSoft.Configuration.BaseCodeLookup
	{

		#region Constructors: Public

		public DaDataSuggestionsField(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "DaDataSuggestionsField";
		}

		public DaDataSuggestionsField(DaDataSuggestionsField source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid TypeId {
			get {
				return GetTypedColumnValue<Guid>("TypeId");
			}
			set {
				SetColumnValue("TypeId", value);
				_type = null;
			}
		}

		/// <exclude/>
		public string TypeName {
			get {
				return GetTypedColumnValue<string>("TypeName");
			}
			set {
				SetColumnValue("TypeName", value);
				if (_type != null) {
					_type.Name = value;
				}
			}
		}

		private DaDataSuggestionsType _type;
		/// <summary>
		/// Тип.
		/// </summary>
		public DaDataSuggestionsType Type {
			get {
				return _type ??
					(_type = LookupColumnEntities.GetEntity("Type") as DaDataSuggestionsType);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new DaDataSuggestionsField_DaDataSuggestionsEventsProcess(UserConnection);
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
			return new DaDataSuggestionsField(this);
		}

		#endregion

	}

	#endregion

	#region Class: DaDataSuggestionsField_DaDataSuggestionsEventsProcess

	/// <exclude/>
	public partial class DaDataSuggestionsField_DaDataSuggestionsEventsProcess<TEntity> : BPMSoft.Configuration.BaseCodeLookup_BaseEventsProcess<TEntity> where TEntity : DaDataSuggestionsField
	{

		public DaDataSuggestionsField_DaDataSuggestionsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "DaDataSuggestionsField_DaDataSuggestionsEventsProcess";
			SchemaUId = new Guid("1fc1a03b-2bef-47ed-89e0-6a41665871e9");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("1fc1a03b-2bef-47ed-89e0-6a41665871e9");
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

	#region Class: DaDataSuggestionsField_DaDataSuggestionsEventsProcess

	/// <exclude/>
	public class DaDataSuggestionsField_DaDataSuggestionsEventsProcess : DaDataSuggestionsField_DaDataSuggestionsEventsProcess<DaDataSuggestionsField>
	{

		public DaDataSuggestionsField_DaDataSuggestionsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: DaDataSuggestionsField_DaDataSuggestionsEventsProcess

	public partial class DaDataSuggestionsField_DaDataSuggestionsEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: DaDataSuggestionsFieldEventsProcess

	/// <exclude/>
	public class DaDataSuggestionsFieldEventsProcess : DaDataSuggestionsField_DaDataSuggestionsEventsProcess
	{

		public DaDataSuggestionsFieldEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

