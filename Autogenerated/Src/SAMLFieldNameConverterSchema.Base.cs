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

	#region Class: SAMLFieldNameConverterSchema

	/// <exclude/>
	public class SAMLFieldNameConverterSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SAMLFieldNameConverterSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SAMLFieldNameConverterSchema(SAMLFieldNameConverterSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SAMLFieldNameConverterSchema(SAMLFieldNameConverterSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("50489d87-286f-420c-a306-ae2bdd7356fc");
			RealUId = new Guid("50489d87-286f-420c-a306-ae2bdd7356fc");
			Name = "SAMLFieldNameConverter";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("90e8157f-4651-4349-83a7-f0455fc70915");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("1cca6142-7ef1-4d7b-b068-9f180e6a3ce7")) == null) {
				Columns.Add(CreateSAMLFieldNameColumn());
			}
			if (Columns.FindByUId(new Guid("30e7fb61-c0a7-4f3a-9b56-4f3f980b7b05")) == null) {
				Columns.Add(CreateContactFieldNameColumn());
			}
			if (Columns.FindByUId(new Guid("f758a26f-dbaf-409f-a617-6a75e720fb27")) == null) {
				Columns.Add(CreateColumnDefaultValueColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateSAMLFieldNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("1cca6142-7ef1-4d7b-b068-9f180e6a3ce7"),
				Name = @"SAMLFieldName",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("50489d87-286f-420c-a306-ae2bdd7356fc"),
				ModifiedInSchemaUId = new Guid("50489d87-286f-420c-a306-ae2bdd7356fc"),
				CreatedInPackageId = new Guid("90e8157f-4651-4349-83a7-f0455fc70915")
			};
		}

		protected virtual EntitySchemaColumn CreateContactFieldNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("30e7fb61-c0a7-4f3a-9b56-4f3f980b7b05"),
				Name = @"ContactFieldName",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("50489d87-286f-420c-a306-ae2bdd7356fc"),
				ModifiedInSchemaUId = new Guid("50489d87-286f-420c-a306-ae2bdd7356fc"),
				CreatedInPackageId = new Guid("90e8157f-4651-4349-83a7-f0455fc70915")
			};
		}

		protected virtual EntitySchemaColumn CreateColumnDefaultValueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("f758a26f-dbaf-409f-a617-6a75e720fb27"),
				Name = @"ColumnDefaultValue",
				CreatedInSchemaUId = new Guid("50489d87-286f-420c-a306-ae2bdd7356fc"),
				ModifiedInSchemaUId = new Guid("50489d87-286f-420c-a306-ae2bdd7356fc"),
				CreatedInPackageId = new Guid("90e8157f-4651-4349-83a7-f0455fc70915")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SAMLFieldNameConverter(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SAMLFieldNameConverter_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SAMLFieldNameConverterSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SAMLFieldNameConverterSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("50489d87-286f-420c-a306-ae2bdd7356fc"));
		}

		#endregion

	}

	#endregion

	#region Class: SAMLFieldNameConverter

	/// <summary>
	/// SAML field name converter to contact field name.
	/// </summary>
	public class SAMLFieldNameConverter : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SAMLFieldNameConverter(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SAMLFieldNameConverter";
		}

		public SAMLFieldNameConverter(SAMLFieldNameConverter source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// SAML field attribute.
		/// </summary>
		public string SAMLFieldName {
			get {
				return GetTypedColumnValue<string>("SAMLFieldName");
			}
			set {
				SetColumnValue("SAMLFieldName", value);
			}
		}

		/// <summary>
		/// Contact field name.
		/// </summary>
		public string ContactFieldName {
			get {
				return GetTypedColumnValue<string>("ContactFieldName");
			}
			set {
				SetColumnValue("ContactFieldName", value);
			}
		}

		/// <summary>
		/// Column default value.
		/// </summary>
		public string ColumnDefaultValue {
			get {
				return GetTypedColumnValue<string>("ColumnDefaultValue");
			}
			set {
				SetColumnValue("ColumnDefaultValue", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SAMLFieldNameConverter_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SAMLFieldNameConverterDeleted", e);
			Validating += (s, e) => ThrowEvent("SAMLFieldNameConverterValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SAMLFieldNameConverter(this);
		}

		#endregion

	}

	#endregion

	#region Class: SAMLFieldNameConverter_BaseEventsProcess

	/// <exclude/>
	public partial class SAMLFieldNameConverter_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : SAMLFieldNameConverter
	{

		public SAMLFieldNameConverter_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SAMLFieldNameConverter_BaseEventsProcess";
			SchemaUId = new Guid("50489d87-286f-420c-a306-ae2bdd7356fc");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("50489d87-286f-420c-a306-ae2bdd7356fc");
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

	#region Class: SAMLFieldNameConverter_BaseEventsProcess

	/// <exclude/>
	public class SAMLFieldNameConverter_BaseEventsProcess : SAMLFieldNameConverter_BaseEventsProcess<SAMLFieldNameConverter>
	{

		public SAMLFieldNameConverter_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SAMLFieldNameConverter_BaseEventsProcess

	public partial class SAMLFieldNameConverter_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SAMLFieldNameConverterEventsProcess

	/// <exclude/>
	public class SAMLFieldNameConverterEventsProcess : SAMLFieldNameConverter_BaseEventsProcess
	{

		public SAMLFieldNameConverterEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

