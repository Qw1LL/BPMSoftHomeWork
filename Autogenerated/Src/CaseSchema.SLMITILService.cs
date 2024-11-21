namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Configuration;
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
	using CoreSysSettings = BPMSoft.Core.Configuration.SysSettings;
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
	using System.Text;

	#region Class: Case_SLMITILService_BPMSoftSchema

	/// <exclude/>
	public class Case_SLMITILService_BPMSoftSchema : BPMSoft.Configuration.Case_SLM_BPMSoftSchema
	{

		#region Constructors: Public

		public Case_SLMITILService_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public Case_SLMITILService_BPMSoftSchema(Case_SLMITILService_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public Case_SLMITILService_BPMSoftSchema(Case_SLMITILService_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateIX_RegisteredOn_DescIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = false
			};
			index.UId = new Guid("9ed6688c-3e02-47af-9124-e38e20904716");
			index.Name = "IX_RegisteredOn_Desc";
			index.CreatedInSchemaUId = new Guid("117d32f9-8275-4534-8411-1c66115ce9cd");
			index.ModifiedInSchemaUId = new Guid("117d32f9-8275-4534-8411-1c66115ce9cd");
			index.CreatedInPackageId = new Guid("a7919973-994c-4956-b846-530c9ef3b289");
			EntitySchemaIndexColumn registeredOnIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("aa03e37c-3527-4b5c-a16c-53fbc178b41e"),
				ColumnUId = new Guid("c91a9a6f-008d-4b2e-83d5-03868ad68c99"),
				CreatedInSchemaUId = new Guid("117d32f9-8275-4534-8411-1c66115ce9cd"),
				ModifiedInSchemaUId = new Guid("117d32f9-8275-4534-8411-1c66115ce9cd"),
				CreatedInPackageId = new Guid("a7919973-994c-4956-b846-530c9ef3b289"),
				OrderDirection = OrderDirectionStrict.Descending
			};
			index.Columns.Add(registeredOnIndexColumn);
			return index;
		}

		private EntitySchemaIndex CreateIX_SolutionOverdue_AttributesIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = false
			};
			index.UId = new Guid("9ad0ba05-3b32-4561-8bfc-870aee9c951c");
			index.Name = "IX_SolutionOverdue_Attributes";
			index.CreatedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c");
			index.ModifiedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c");
			index.CreatedInPackageId = new Guid("c3c90037-274c-4793-841e-197eb228d3cd");
			EntitySchemaIndexColumn solutionProvidedOnIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("4f3631c8-b14e-4591-a25a-b9207401cfa2"),
				ColumnUId = new Guid("81552f0a-fd92-4865-9533-f4c3ab2861a7"),
				CreatedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c"),
				ModifiedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c"),
				CreatedInPackageId = new Guid("c3c90037-274c-4793-841e-197eb228d3cd"),
				OrderDirection = OrderDirectionStrict.Descending
			};
			index.Columns.Add(solutionProvidedOnIndexColumn);
			EntitySchemaIndexColumn solutionDateIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("5de35510-255d-4f3f-8119-9a3f9b8082f5"),
				ColumnUId = new Guid("624839d1-3bd0-45e0-95d1-28326703f19c"),
				CreatedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c"),
				ModifiedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c"),
				CreatedInPackageId = new Guid("c3c90037-274c-4793-841e-197eb228d3cd"),
				OrderDirection = OrderDirectionStrict.Descending
			};
			index.Columns.Add(solutionDateIndexColumn);
			EntitySchemaIndexColumn solutionOverdueIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("8dab4368-f988-43de-a48e-bbf238fc3237"),
				ColumnUId = new Guid("0fa66efc-d2d0-47b9-abab-9e3ad2ea82d3"),
				CreatedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c"),
				ModifiedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c"),
				CreatedInPackageId = new Guid("c3c90037-274c-4793-841e-197eb228d3cd"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(solutionOverdueIndexColumn);
			return index;
		}

		private EntitySchemaIndex CreateIX_ResponseOverdue_AttributesIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = false
			};
			index.UId = new Guid("8d002ad1-0715-4bdc-aa5e-8be1a5e39381");
			index.Name = "IX_ResponseOverdue_Attributes";
			index.CreatedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c");
			index.ModifiedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c");
			index.CreatedInPackageId = new Guid("c3c90037-274c-4793-841e-197eb228d3cd");
			EntitySchemaIndexColumn respondedOnIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("14abc9af-1b98-4ee2-b236-3a9576b1770f"),
				ColumnUId = new Guid("02612dc8-7243-4acb-b0bd-abbd19e24136"),
				CreatedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c"),
				ModifiedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c"),
				CreatedInPackageId = new Guid("c3c90037-274c-4793-841e-197eb228d3cd"),
				OrderDirection = OrderDirectionStrict.Descending
			};
			index.Columns.Add(respondedOnIndexColumn);
			EntitySchemaIndexColumn responseDateIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("c3226bd5-beb9-48ea-9383-30fb120d4f4d"),
				ColumnUId = new Guid("25280121-c075-441f-b4f8-feeb6cc7ca38"),
				CreatedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c"),
				ModifiedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c"),
				CreatedInPackageId = new Guid("c3c90037-274c-4793-841e-197eb228d3cd"),
				OrderDirection = OrderDirectionStrict.Descending
			};
			index.Columns.Add(responseDateIndexColumn);
			EntitySchemaIndexColumn responseOverdueIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("a4aaaa1e-d84e-48a2-84ac-04c35a6fad1e"),
				ColumnUId = new Guid("1ed4e080-0bf8-4f4f-97e8-b3e22f3240a0"),
				CreatedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c"),
				ModifiedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c"),
				CreatedInPackageId = new Guid("c3c90037-274c-4793-841e-197eb228d3cd"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(responseOverdueIndexColumn);
			return index;
		}

		private EntitySchemaIndex CreateIDX_SubjectIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = false
			};
			index.UId = new Guid("e675ceca-ff2f-44c2-bd1a-f2c1af261cba");
			index.Name = "IDX_Subject";
			index.CreatedInSchemaUId = new Guid("117d32f9-8275-4534-8411-1c66115ce9cd");
			index.ModifiedInSchemaUId = new Guid("117d32f9-8275-4534-8411-1c66115ce9cd");
			index.CreatedInPackageId = new Guid("ff020f92-eb95-49ea-a251-6a0ed7e274a5");
			EntitySchemaIndexColumn subjectIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("5f164afe-e5a5-40a6-9e32-b7f83656bba8"),
				ColumnUId = new Guid("ffe8526d-044f-4222-a1ef-fca83a0772d8"),
				CreatedInSchemaUId = new Guid("117d32f9-8275-4534-8411-1c66115ce9cd"),
				ModifiedInSchemaUId = new Guid("117d32f9-8275-4534-8411-1c66115ce9cd"),
				CreatedInPackageId = new Guid("ff020f92-eb95-49ea-a251-6a0ed7e274a5"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(subjectIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("8568d092-83e6-4a24-8ab8-391fca7f750d");
			Name = "Case_SLMITILService_BPMSoft";
			ParentSchemaUId = new Guid("117d32f9-8275-4534-8411-1c66115ce9cd");
			ExtendParent = true;
			CreatedInPackageId = new Guid("20093be1-4c70-48d8-849b-123fc8391b10");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("6ab42472-7828-4d51-a3e6-c38b485f3252")) == null) {
				Columns.Add(CreateServicePactColumn());
			}
			if (Columns.FindByUId(new Guid("86567001-01f1-403b-8b2e-34ee5d17c811")) == null) {
				Columns.Add(CreateServiceCategoryColumn());
			}
			if (Columns.FindByUId(new Guid("6bc89a93-6a89-4d71-ad7c-df9d81c15978")) == null) {
				Columns.Add(CreateSolvedOnSupportLevelColumn());
			}
			if (Columns.FindByUId(new Guid("869fd0ea-052e-4107-b426-ea8176e370dc")) == null) {
				Columns.Add(CreateSupportLevelColumn());
			}
			if (Columns.FindByUId(new Guid("2042c68f-9121-4974-87fd-d7d8c8b596f0")) == null) {
				Columns.Add(CreateHolderColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateServicePactColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("6ab42472-7828-4d51-a3e6-c38b485f3252"),
				Name = @"ServicePact",
				ReferenceSchemaUId = new Guid("595ddbda-31ce-4cca-9bdd-862257ceaf23"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("8568d092-83e6-4a24-8ab8-391fca7f750d"),
				ModifiedInSchemaUId = new Guid("8568d092-83e6-4a24-8ab8-391fca7f750d"),
				CreatedInPackageId = new Guid("20093be1-4c70-48d8-849b-123fc8391b10")
			};
		}

		protected virtual EntitySchemaColumn CreateServiceCategoryColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("86567001-01f1-403b-8b2e-34ee5d17c811"),
				Name = @"ServiceCategory",
				ReferenceSchemaUId = new Guid("d76eaeaf-9ffc-4556-b8ad-87e2823e1e84"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("8568d092-83e6-4a24-8ab8-391fca7f750d"),
				ModifiedInSchemaUId = new Guid("8568d092-83e6-4a24-8ab8-391fca7f750d"),
				CreatedInPackageId = new Guid("8802bbbd-af3c-4897-a646-e8600063382a")
			};
		}

		protected virtual EntitySchemaColumn CreateSolvedOnSupportLevelColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("6bc89a93-6a89-4d71-ad7c-df9d81c15978"),
				Name = @"SolvedOnSupportLevel",
				ReferenceSchemaUId = new Guid("4c2e1b60-ee12-4846-a38e-04204de6fb14"),
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("8568d092-83e6-4a24-8ab8-391fca7f750d"),
				ModifiedInSchemaUId = new Guid("8568d092-83e6-4a24-8ab8-391fca7f750d"),
				CreatedInPackageId = new Guid("2ae03e06-9f1c-4d5c-b222-14d44604b4b1")
			};
		}

		protected virtual EntitySchemaColumn CreateSupportLevelColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("869fd0ea-052e-4107-b426-ea8176e370dc"),
				Name = @"SupportLevel",
				ReferenceSchemaUId = new Guid("4c2e1b60-ee12-4846-a38e-04204de6fb14"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("8568d092-83e6-4a24-8ab8-391fca7f750d"),
				ModifiedInSchemaUId = new Guid("8568d092-83e6-4a24-8ab8-391fca7f750d"),
				CreatedInPackageId = new Guid("2ae03e06-9f1c-4d5c-b222-14d44604b4b1"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Settings,
					ValueSource = @"CaseServiceLevelDef"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateHolderColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("2042c68f-9121-4974-87fd-d7d8c8b596f0"),
				Name = @"Holder",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("8568d092-83e6-4a24-8ab8-391fca7f750d"),
				ModifiedInSchemaUId = new Guid("8568d092-83e6-4a24-8ab8-391fca7f750d"),
				CreatedInPackageId = new Guid("2ae03e06-9f1c-4d5c-b222-14d44604b4b1")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateIX_RegisteredOn_DescIndex());
			Indexes.Add(CreateIX_SolutionOverdue_AttributesIndex());
			Indexes.Add(CreateIX_ResponseOverdue_AttributesIndex());
			Indexes.Add(CreateIDX_SubjectIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new Case_SLMITILService_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Case_SLMITILServiceEventsProcess(userConnection);
		}

		public override object Clone() {
			return new Case_SLMITILService_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new Case_SLMITILService_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("8568d092-83e6-4a24-8ab8-391fca7f750d"));
		}

		#endregion

	}

	#endregion

	#region Class: Case_SLMITILService_BPMSoft

	/// <summary>
	/// Обращение.
	/// </summary>
	public class Case_SLMITILService_BPMSoft : BPMSoft.Configuration.Case_SLM_BPMSoft
	{

		#region Constructors: Public

		public Case_SLMITILService_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Case_SLMITILService_BPMSoft";
		}

		public Case_SLMITILService_BPMSoft(Case_SLMITILService_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid ServicePactId {
			get {
				return GetTypedColumnValue<Guid>("ServicePactId");
			}
			set {
				SetColumnValue("ServicePactId", value);
				_servicePact = null;
			}
		}

		/// <exclude/>
		public string ServicePactName {
			get {
				return GetTypedColumnValue<string>("ServicePactName");
			}
			set {
				SetColumnValue("ServicePactName", value);
				if (_servicePact != null) {
					_servicePact.Name = value;
				}
			}
		}

		private ServicePact _servicePact;
		/// <summary>
		/// Сервисный договор.
		/// </summary>
		public ServicePact ServicePact {
			get {
				return _servicePact ??
					(_servicePact = LookupColumnEntities.GetEntity("ServicePact") as ServicePact);
			}
		}

		/// <exclude/>
		public Guid ServiceCategoryId {
			get {
				return GetTypedColumnValue<Guid>("ServiceCategoryId");
			}
			set {
				SetColumnValue("ServiceCategoryId", value);
				_serviceCategory = null;
			}
		}

		/// <exclude/>
		public string ServiceCategoryName {
			get {
				return GetTypedColumnValue<string>("ServiceCategoryName");
			}
			set {
				SetColumnValue("ServiceCategoryName", value);
				if (_serviceCategory != null) {
					_serviceCategory.Name = value;
				}
			}
		}

		private ServiceCategory _serviceCategory;
		/// <summary>
		/// Категория сервиса.
		/// </summary>
		public ServiceCategory ServiceCategory {
			get {
				return _serviceCategory ??
					(_serviceCategory = LookupColumnEntities.GetEntity("ServiceCategory") as ServiceCategory);
			}
		}

		/// <exclude/>
		public Guid SolvedOnSupportLevelId {
			get {
				return GetTypedColumnValue<Guid>("SolvedOnSupportLevelId");
			}
			set {
				SetColumnValue("SolvedOnSupportLevelId", value);
				_solvedOnSupportLevel = null;
			}
		}

		/// <exclude/>
		public string SolvedOnSupportLevelName {
			get {
				return GetTypedColumnValue<string>("SolvedOnSupportLevelName");
			}
			set {
				SetColumnValue("SolvedOnSupportLevelName", value);
				if (_solvedOnSupportLevel != null) {
					_solvedOnSupportLevel.Name = value;
				}
			}
		}

		private RoleInServiceTeam _solvedOnSupportLevel;
		/// <summary>
		/// Решено на уровне.
		/// </summary>
		public RoleInServiceTeam SolvedOnSupportLevel {
			get {
				return _solvedOnSupportLevel ??
					(_solvedOnSupportLevel = LookupColumnEntities.GetEntity("SolvedOnSupportLevel") as RoleInServiceTeam);
			}
		}

		/// <exclude/>
		public Guid SupportLevelId {
			get {
				return GetTypedColumnValue<Guid>("SupportLevelId");
			}
			set {
				SetColumnValue("SupportLevelId", value);
				_supportLevel = null;
			}
		}

		/// <exclude/>
		public string SupportLevelName {
			get {
				return GetTypedColumnValue<string>("SupportLevelName");
			}
			set {
				SetColumnValue("SupportLevelName", value);
				if (_supportLevel != null) {
					_supportLevel.Name = value;
				}
			}
		}

		private RoleInServiceTeam _supportLevel;
		/// <summary>
		/// Уровень поддержки.
		/// </summary>
		public RoleInServiceTeam SupportLevel {
			get {
				return _supportLevel ??
					(_supportLevel = LookupColumnEntities.GetEntity("SupportLevel") as RoleInServiceTeam);
			}
		}

		/// <exclude/>
		public Guid HolderId {
			get {
				return GetTypedColumnValue<Guid>("HolderId");
			}
			set {
				SetColumnValue("HolderId", value);
				_holder = null;
			}
		}

		/// <exclude/>
		public string HolderName {
			get {
				return GetTypedColumnValue<string>("HolderName");
			}
			set {
				SetColumnValue("HolderName", value);
				if (_holder != null) {
					_holder.Name = value;
				}
			}
		}

		private Contact _holder;
		/// <summary>
		/// Владелец.
		/// </summary>
		public Contact Holder {
			get {
				return _holder ??
					(_holder = LookupColumnEntities.GetEntity("Holder") as Contact);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Case_SLMITILServiceEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("Case_SLMITILService_BPMSoftDeleted", e);
			Saved += (s, e) => ThrowEvent("Case_SLMITILService_BPMSoftSaved", e);
			Saving += (s, e) => ThrowEvent("Case_SLMITILService_BPMSoftSaving", e);
			SaveError += (s, e) => ThrowEvent("Case_SLMITILService_BPMSoftSaveError", e);
			Validating += (s, e) => ThrowEvent("Case_SLMITILService_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new Case_SLMITILService_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: Case_SLMITILServiceEventsProcess

	/// <exclude/>
	public partial class Case_SLMITILServiceEventsProcess<TEntity> : BPMSoft.Configuration.Case_SLMEventsProcess<TEntity> where TEntity : Case_SLMITILService_BPMSoft
	{

		public Case_SLMITILServiceEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Case_SLMITILServiceEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("8568d092-83e6-4a24-8ab8-391fca7f750d");
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

	#region Class: Case_SLMITILServiceEventsProcess

	/// <exclude/>
	public class Case_SLMITILServiceEventsProcess : Case_SLMITILServiceEventsProcess<Case_SLMITILService_BPMSoft>
	{

		public Case_SLMITILServiceEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: Case_SLMITILServiceEventsProcess

	public partial class Case_SLMITILServiceEventsProcess<TEntity>
	{

		#region Methods: Public

		public override void LocalMessageExecuting(EntityChangeType changeType) {
			var lmHelper = new BPMSoft.Configuration.LocalMessageHelper(this.Entity, UserConnection, changeType);
			lmHelper.CreateLocalMessage();
		}

		public override string GetServiceCaption() {
			var serviceItemId = Entity.GetTypedColumnValue<Guid>("ServiceItemId");
			var serviceQuery = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "ServiceItem");
			serviceQuery.AddColumn("Name"); 
			var service = serviceQuery .GetEntity(UserConnection, serviceItemId);
			if(service == null) {
				return string.Empty;
			} 
			return service.GetTypedColumnValue<string>("Name"); 
		}

		public override List<string> GetLoggingColumns() {
			var columns = base.GetLoggingColumns();
			columns.Add("SupportLevelId");
			return columns;
		}

		#endregion

	}

	#endregion

}

