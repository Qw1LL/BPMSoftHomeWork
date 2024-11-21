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

	#region Class: Problem_Problem_BPMSoftSchema

	/// <exclude/>
	public class Problem_Problem_BPMSoftSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public Problem_Problem_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public Problem_Problem_BPMSoftSchema(Problem_Problem_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public Problem_Problem_BPMSoftSchema(Problem_Problem_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("7ec5366d-8edf-4b7d-b94b-2bc2655cf230");
			RealUId = new Guid("7ec5366d-8edf-4b7d-b94b-2bc2655cf230");
			Name = "Problem_Problem_BPMSoft";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("305fcfca-4160-4398-90a9-d5e84be0ae12");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateNumberColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("f96d7882-6059-4f58-8e6a-c9a7e614023c")) == null) {
				Columns.Add(CreateNameColumn());
			}
			if (Columns.FindByUId(new Guid("67655160-1c27-4456-b640-4bb6dc555258")) == null) {
				Columns.Add(CreateAuthorColumn());
			}
			if (Columns.FindByUId(new Guid("99123097-7f1e-4325-8e72-bc5e8d8234d6")) == null) {
				Columns.Add(CreateTypeColumn());
			}
			if (Columns.FindByUId(new Guid("f980bbae-7e0c-41fd-95b0-5022a732930a")) == null) {
				Columns.Add(CreateRegisteredOnColumn());
			}
			if (Columns.FindByUId(new Guid("7029e40a-1b15-40d4-9769-a79009536522")) == null) {
				Columns.Add(CreateSymptomsColumn());
			}
			if (Columns.FindByUId(new Guid("2adca2da-1a99-483a-9728-edad77793cf9")) == null) {
				Columns.Add(CreatePriorityColumn());
			}
			if (Columns.FindByUId(new Guid("76e8a108-58ed-4727-868a-2d0511faef1f")) == null) {
				Columns.Add(CreateStatusColumn());
			}
			if (Columns.FindByUId(new Guid("3caee6bf-941e-46ca-8724-a06dca363fa2")) == null) {
				Columns.Add(CreateOwnerColumn());
			}
			if (Columns.FindByUId(new Guid("3caba9d5-6aee-496c-983f-a15353486ba5")) == null) {
				Columns.Add(CreateGroupColumn());
			}
			if (Columns.FindByUId(new Guid("1342beaa-1f8a-4c7e-9775-a484773bb210")) == null) {
				Columns.Add(CreateConfItemColumn());
			}
			if (Columns.FindByUId(new Guid("8e542091-eec4-441a-86d4-1c2ad8ad6857")) == null) {
				Columns.Add(CreateSolutionColumn());
			}
			if (Columns.FindByUId(new Guid("7204fbfe-4186-4833-8b81-e959648b0f51")) == null) {
				Columns.Add(CreateServiceItemColumn());
			}
			if (Columns.FindByUId(new Guid("ab13bde7-59e9-46a2-88b3-f72f9a549536")) == null) {
				Columns.Add(CreateSolutionPlanedOnColumn());
			}
			if (Columns.FindByUId(new Guid("4ed67c7c-6634-441d-9021-3f96887aa80b")) == null) {
				Columns.Add(CreateSolutionProvidedOnColumn());
			}
			if (Columns.FindByUId(new Guid("dbc268c1-d869-449e-bf55-37a876d49f5b")) == null) {
				Columns.Add(CreateClosureDateColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("7ec5366d-8edf-4b7d-b94b-2bc2655cf230");
			column.CreatedInPackageId = new Guid("305fcfca-4160-4398-90a9-d5e84be0ae12");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("7ec5366d-8edf-4b7d-b94b-2bc2655cf230");
			column.CreatedInPackageId = new Guid("305fcfca-4160-4398-90a9-d5e84be0ae12");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("7ec5366d-8edf-4b7d-b94b-2bc2655cf230");
			column.CreatedInPackageId = new Guid("305fcfca-4160-4398-90a9-d5e84be0ae12");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("7ec5366d-8edf-4b7d-b94b-2bc2655cf230");
			column.CreatedInPackageId = new Guid("305fcfca-4160-4398-90a9-d5e84be0ae12");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("7ec5366d-8edf-4b7d-b94b-2bc2655cf230");
			column.CreatedInPackageId = new Guid("305fcfca-4160-4398-90a9-d5e84be0ae12");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("7ec5366d-8edf-4b7d-b94b-2bc2655cf230");
			column.CreatedInPackageId = new Guid("305fcfca-4160-4398-90a9-d5e84be0ae12");
			return column;
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("f96d7882-6059-4f58-8e6a-c9a7e614023c"),
				Name = @"Name",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("7ec5366d-8edf-4b7d-b94b-2bc2655cf230"),
				ModifiedInSchemaUId = new Guid("7ec5366d-8edf-4b7d-b94b-2bc2655cf230"),
				CreatedInPackageId = new Guid("305fcfca-4160-4398-90a9-d5e84be0ae12")
			};
		}

		protected virtual EntitySchemaColumn CreateNumberColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("574a4f31-52cd-4a5c-b8a1-2da99b212660"),
				Name = @"Number",
				CreatedInSchemaUId = new Guid("7ec5366d-8edf-4b7d-b94b-2bc2655cf230"),
				ModifiedInSchemaUId = new Guid("7ec5366d-8edf-4b7d-b94b-2bc2655cf230"),
				CreatedInPackageId = new Guid("305fcfca-4160-4398-90a9-d5e84be0ae12")
			};
		}

		protected virtual EntitySchemaColumn CreateAuthorColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("67655160-1c27-4456-b640-4bb6dc555258"),
				Name = @"Author",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("7ec5366d-8edf-4b7d-b94b-2bc2655cf230"),
				ModifiedInSchemaUId = new Guid("7ec5366d-8edf-4b7d-b94b-2bc2655cf230"),
				CreatedInPackageId = new Guid("305fcfca-4160-4398-90a9-d5e84be0ae12"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.SystemValue,
					ValueSource = SystemValueManager.GetInstanceByName(@"CurrentUserContact")
				}
			};
		}

		protected virtual EntitySchemaColumn CreateTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("99123097-7f1e-4325-8e72-bc5e8d8234d6"),
				Name = @"Type",
				ReferenceSchemaUId = new Guid("1279b552-fb9d-4d39-a68d-f6a811492eee"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("7ec5366d-8edf-4b7d-b94b-2bc2655cf230"),
				ModifiedInSchemaUId = new Guid("7ec5366d-8edf-4b7d-b94b-2bc2655cf230"),
				CreatedInPackageId = new Guid("305fcfca-4160-4398-90a9-d5e84be0ae12")
			};
		}

		protected virtual EntitySchemaColumn CreateRegisteredOnColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Date")) {
				UId = new Guid("f980bbae-7e0c-41fd-95b0-5022a732930a"),
				Name = @"RegisteredOn",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("7ec5366d-8edf-4b7d-b94b-2bc2655cf230"),
				ModifiedInSchemaUId = new Guid("7ec5366d-8edf-4b7d-b94b-2bc2655cf230"),
				CreatedInPackageId = new Guid("305fcfca-4160-4398-90a9-d5e84be0ae12"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.SystemValue,
					ValueSource = SystemValueManager.GetInstanceByName(@"CurrentDate")
				}
			};
		}

		protected virtual EntitySchemaColumn CreateSymptomsColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("7029e40a-1b15-40d4-9769-a79009536522"),
				Name = @"Symptoms",
				CreatedInSchemaUId = new Guid("7ec5366d-8edf-4b7d-b94b-2bc2655cf230"),
				ModifiedInSchemaUId = new Guid("7ec5366d-8edf-4b7d-b94b-2bc2655cf230"),
				CreatedInPackageId = new Guid("305fcfca-4160-4398-90a9-d5e84be0ae12")
			};
		}

		protected virtual EntitySchemaColumn CreatePriorityColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("2adca2da-1a99-483a-9728-edad77793cf9"),
				Name = @"Priority",
				ReferenceSchemaUId = new Guid("e76599de-e5ae-418a-b0a2-c1c5134e2ec8"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("7ec5366d-8edf-4b7d-b94b-2bc2655cf230"),
				ModifiedInSchemaUId = new Guid("7ec5366d-8edf-4b7d-b94b-2bc2655cf230"),
				CreatedInPackageId = new Guid("305fcfca-4160-4398-90a9-d5e84be0ae12"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Settings,
					ValueSource = @"ProblemPriorityDef"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateStatusColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("76e8a108-58ed-4727-868a-2d0511faef1f"),
				Name = @"Status",
				ReferenceSchemaUId = new Guid("221b40be-b93d-4ad7-be6f-f4c7b24552eb"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("7ec5366d-8edf-4b7d-b94b-2bc2655cf230"),
				ModifiedInSchemaUId = new Guid("7ec5366d-8edf-4b7d-b94b-2bc2655cf230"),
				CreatedInPackageId = new Guid("305fcfca-4160-4398-90a9-d5e84be0ae12"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Settings,
					ValueSource = @"ProblemStatusDef"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateOwnerColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("3caee6bf-941e-46ca-8724-a06dca363fa2"),
				Name = @"Owner",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("7ec5366d-8edf-4b7d-b94b-2bc2655cf230"),
				ModifiedInSchemaUId = new Guid("7ec5366d-8edf-4b7d-b94b-2bc2655cf230"),
				CreatedInPackageId = new Guid("305fcfca-4160-4398-90a9-d5e84be0ae12")
			};
		}

		protected virtual EntitySchemaColumn CreateGroupColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("3caba9d5-6aee-496c-983f-a15353486ba5"),
				Name = @"Group",
				ReferenceSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("7ec5366d-8edf-4b7d-b94b-2bc2655cf230"),
				ModifiedInSchemaUId = new Guid("7ec5366d-8edf-4b7d-b94b-2bc2655cf230"),
				CreatedInPackageId = new Guid("305fcfca-4160-4398-90a9-d5e84be0ae12")
			};
		}

		protected virtual EntitySchemaColumn CreateConfItemColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("1342beaa-1f8a-4c7e-9775-a484773bb210"),
				Name = @"ConfItem",
				ReferenceSchemaUId = new Guid("ad707075-cf25-40bf-85c1-f5da38cf0d5d"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("7ec5366d-8edf-4b7d-b94b-2bc2655cf230"),
				ModifiedInSchemaUId = new Guid("7ec5366d-8edf-4b7d-b94b-2bc2655cf230"),
				CreatedInPackageId = new Guid("305fcfca-4160-4398-90a9-d5e84be0ae12")
			};
		}

		protected virtual EntitySchemaColumn CreateSolutionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("8e542091-eec4-441a-86d4-1c2ad8ad6857"),
				Name = @"Solution",
				CreatedInSchemaUId = new Guid("7ec5366d-8edf-4b7d-b94b-2bc2655cf230"),
				ModifiedInSchemaUId = new Guid("7ec5366d-8edf-4b7d-b94b-2bc2655cf230"),
				CreatedInPackageId = new Guid("305fcfca-4160-4398-90a9-d5e84be0ae12")
			};
		}

		protected virtual EntitySchemaColumn CreateServiceItemColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("7204fbfe-4186-4833-8b81-e959648b0f51"),
				Name = @"ServiceItem",
				ReferenceSchemaUId = new Guid("c6c44f0a-193e-4b5c-b35e-220a60c06898"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("7ec5366d-8edf-4b7d-b94b-2bc2655cf230"),
				ModifiedInSchemaUId = new Guid("7ec5366d-8edf-4b7d-b94b-2bc2655cf230"),
				CreatedInPackageId = new Guid("ffa69c6a-c8bb-4a61-bc00-b0bcd40a9862")
			};
		}

		protected virtual EntitySchemaColumn CreateSolutionPlanedOnColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Date")) {
				UId = new Guid("ab13bde7-59e9-46a2-88b3-f72f9a549536"),
				Name = @"SolutionPlanedOn",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("7ec5366d-8edf-4b7d-b94b-2bc2655cf230"),
				ModifiedInSchemaUId = new Guid("7ec5366d-8edf-4b7d-b94b-2bc2655cf230"),
				CreatedInPackageId = new Guid("af2f4ac9-4bf5-4cc5-9c73-7ee909501027")
			};
		}

		protected virtual EntitySchemaColumn CreateSolutionProvidedOnColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Date")) {
				UId = new Guid("4ed67c7c-6634-441d-9021-3f96887aa80b"),
				Name = @"SolutionProvidedOn",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("7ec5366d-8edf-4b7d-b94b-2bc2655cf230"),
				ModifiedInSchemaUId = new Guid("7ec5366d-8edf-4b7d-b94b-2bc2655cf230"),
				CreatedInPackageId = new Guid("af2f4ac9-4bf5-4cc5-9c73-7ee909501027")
			};
		}

		protected virtual EntitySchemaColumn CreateClosureDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Date")) {
				UId = new Guid("dbc268c1-d869-449e-bf55-37a876d49f5b"),
				Name = @"ClosureDate",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("7ec5366d-8edf-4b7d-b94b-2bc2655cf230"),
				ModifiedInSchemaUId = new Guid("7ec5366d-8edf-4b7d-b94b-2bc2655cf230"),
				CreatedInPackageId = new Guid("af2f4ac9-4bf5-4cc5-9c73-7ee909501027")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new Problem_Problem_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Problem_ProblemEventsProcess(userConnection);
		}

		public override object Clone() {
			return new Problem_Problem_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new Problem_Problem_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("7ec5366d-8edf-4b7d-b94b-2bc2655cf230"));
		}

		#endregion

	}

	#endregion

	#region Class: Problem_Problem_BPMSoft

	/// <summary>
	/// Проблема.
	/// </summary>
	public class Problem_Problem_BPMSoft : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public Problem_Problem_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Problem_Problem_BPMSoft";
		}

		public Problem_Problem_BPMSoft(Problem_Problem_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Тема.
		/// </summary>
		public string Name {
			get {
				return GetTypedColumnValue<string>("Name");
			}
			set {
				SetColumnValue("Name", value);
			}
		}

		/// <summary>
		/// Номер.
		/// </summary>
		public string Number {
			get {
				return GetTypedColumnValue<string>("Number");
			}
			set {
				SetColumnValue("Number", value);
			}
		}

		/// <exclude/>
		public Guid AuthorId {
			get {
				return GetTypedColumnValue<Guid>("AuthorId");
			}
			set {
				SetColumnValue("AuthorId", value);
				_author = null;
			}
		}

		/// <exclude/>
		public string AuthorName {
			get {
				return GetTypedColumnValue<string>("AuthorName");
			}
			set {
				SetColumnValue("AuthorName", value);
				if (_author != null) {
					_author.Name = value;
				}
			}
		}

		private Contact _author;
		/// <summary>
		/// Автор.
		/// </summary>
		public Contact Author {
			get {
				return _author ??
					(_author = LookupColumnEntities.GetEntity("Author") as Contact);
			}
		}

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

		private ProblemType _type;
		/// <summary>
		/// Тип.
		/// </summary>
		public ProblemType Type {
			get {
				return _type ??
					(_type = LookupColumnEntities.GetEntity("Type") as ProblemType);
			}
		}

		/// <summary>
		/// Дата регистрации.
		/// </summary>
		public DateTime RegisteredOn {
			get {
				return GetTypedColumnValue<DateTime>("RegisteredOn");
			}
			set {
				SetColumnValue("RegisteredOn", value);
			}
		}

		/// <summary>
		/// Признаки (Симптомы).
		/// </summary>
		public string Symptoms {
			get {
				return GetTypedColumnValue<string>("Symptoms");
			}
			set {
				SetColumnValue("Symptoms", value);
			}
		}

		/// <exclude/>
		public Guid PriorityId {
			get {
				return GetTypedColumnValue<Guid>("PriorityId");
			}
			set {
				SetColumnValue("PriorityId", value);
				_priority = null;
			}
		}

		/// <exclude/>
		public string PriorityName {
			get {
				return GetTypedColumnValue<string>("PriorityName");
			}
			set {
				SetColumnValue("PriorityName", value);
				if (_priority != null) {
					_priority.Name = value;
				}
			}
		}

		private ProblemPriority _priority;
		/// <summary>
		/// Приоритет.
		/// </summary>
		public ProblemPriority Priority {
			get {
				return _priority ??
					(_priority = LookupColumnEntities.GetEntity("Priority") as ProblemPriority);
			}
		}

		/// <exclude/>
		public Guid StatusId {
			get {
				return GetTypedColumnValue<Guid>("StatusId");
			}
			set {
				SetColumnValue("StatusId", value);
				_status = null;
			}
		}

		/// <exclude/>
		public string StatusName {
			get {
				return GetTypedColumnValue<string>("StatusName");
			}
			set {
				SetColumnValue("StatusName", value);
				if (_status != null) {
					_status.Name = value;
				}
			}
		}

		private ProblemStatus _status;
		/// <summary>
		/// Состояние.
		/// </summary>
		public ProblemStatus Status {
			get {
				return _status ??
					(_status = LookupColumnEntities.GetEntity("Status") as ProblemStatus);
			}
		}

		/// <exclude/>
		public Guid OwnerId {
			get {
				return GetTypedColumnValue<Guid>("OwnerId");
			}
			set {
				SetColumnValue("OwnerId", value);
				_owner = null;
			}
		}

		/// <exclude/>
		public string OwnerName {
			get {
				return GetTypedColumnValue<string>("OwnerName");
			}
			set {
				SetColumnValue("OwnerName", value);
				if (_owner != null) {
					_owner.Name = value;
				}
			}
		}

		private Contact _owner;
		/// <summary>
		/// Ответственный.
		/// </summary>
		public Contact Owner {
			get {
				return _owner ??
					(_owner = LookupColumnEntities.GetEntity("Owner") as Contact);
			}
		}

		/// <exclude/>
		public Guid GroupId {
			get {
				return GetTypedColumnValue<Guid>("GroupId");
			}
			set {
				SetColumnValue("GroupId", value);
				_group = null;
			}
		}

		/// <exclude/>
		public string GroupName {
			get {
				return GetTypedColumnValue<string>("GroupName");
			}
			set {
				SetColumnValue("GroupName", value);
				if (_group != null) {
					_group.Name = value;
				}
			}
		}

		private SysAdminUnit _group;
		/// <summary>
		/// Группа ответственных.
		/// </summary>
		public SysAdminUnit Group {
			get {
				return _group ??
					(_group = LookupColumnEntities.GetEntity("Group") as SysAdminUnit);
			}
		}

		/// <exclude/>
		public Guid ConfItemId {
			get {
				return GetTypedColumnValue<Guid>("ConfItemId");
			}
			set {
				SetColumnValue("ConfItemId", value);
				_confItem = null;
			}
		}

		/// <exclude/>
		public string ConfItemName {
			get {
				return GetTypedColumnValue<string>("ConfItemName");
			}
			set {
				SetColumnValue("ConfItemName", value);
				if (_confItem != null) {
					_confItem.Name = value;
				}
			}
		}

		private ConfItem _confItem;
		/// <summary>
		/// Конфигурационная единица.
		/// </summary>
		public ConfItem ConfItem {
			get {
				return _confItem ??
					(_confItem = LookupColumnEntities.GetEntity("ConfItem") as ConfItem);
			}
		}

		/// <summary>
		/// Решение.
		/// </summary>
		public string Solution {
			get {
				return GetTypedColumnValue<string>("Solution");
			}
			set {
				SetColumnValue("Solution", value);
			}
		}

		/// <exclude/>
		public Guid ServiceItemId {
			get {
				return GetTypedColumnValue<Guid>("ServiceItemId");
			}
			set {
				SetColumnValue("ServiceItemId", value);
				_serviceItem = null;
			}
		}

		/// <exclude/>
		public string ServiceItemName {
			get {
				return GetTypedColumnValue<string>("ServiceItemName");
			}
			set {
				SetColumnValue("ServiceItemName", value);
				if (_serviceItem != null) {
					_serviceItem.Name = value;
				}
			}
		}

		private ServiceItem _serviceItem;
		/// <summary>
		/// Сервис.
		/// </summary>
		public ServiceItem ServiceItem {
			get {
				return _serviceItem ??
					(_serviceItem = LookupColumnEntities.GetEntity("ServiceItem") as ServiceItem);
			}
		}

		/// <summary>
		/// План. разрешение.
		/// </summary>
		public DateTime SolutionPlanedOn {
			get {
				return GetTypedColumnValue<DateTime>("SolutionPlanedOn");
			}
			set {
				SetColumnValue("SolutionPlanedOn", value);
			}
		}

		/// <summary>
		/// Факт. разрешение.
		/// </summary>
		public DateTime SolutionProvidedOn {
			get {
				return GetTypedColumnValue<DateTime>("SolutionProvidedOn");
			}
			set {
				SetColumnValue("SolutionProvidedOn", value);
			}
		}

		/// <summary>
		/// Дата закрытия.
		/// </summary>
		public DateTime ClosureDate {
			get {
				return GetTypedColumnValue<DateTime>("ClosureDate");
			}
			set {
				SetColumnValue("ClosureDate", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Problem_ProblemEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("Problem_Problem_BPMSoftDeleted", e);
			Inserting += (s, e) => ThrowEvent("Problem_Problem_BPMSoftInserting", e);
			Validating += (s, e) => ThrowEvent("Problem_Problem_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new Problem_Problem_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: Problem_ProblemEventsProcess

	/// <exclude/>
	public partial class Problem_ProblemEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : Problem_Problem_BPMSoft
	{

		#region Class: GenerateNumberUserTaskFlowElement

		/// <exclude/>
		public class GenerateNumberUserTaskFlowElement : GenerateSequenseNumberUserTask
		{

			public GenerateNumberUserTaskFlowElement(UserConnection userConnection, Problem_ProblemEventsProcess<TEntity> process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "GenerateNumberUserTask";
				IsLogging = false;
				SchemaElementUId = new Guid("c1eacc8d-c3ac-480c-b4a3-0c3c8a515faa");
				CreatedInSchemaUId = process.InternalSchemaUId;
			}

		}

		#endregion

		public Problem_ProblemEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Problem_ProblemEventsProcess";
			SchemaUId = new Guid("7ec5366d-8edf-4b7d-b94b-2bc2655cf230");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("7ec5366d-8edf-4b7d-b94b-2bc2655cf230");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		private ProcessFlowElement _eventSubProcess1;
		public ProcessFlowElement EventSubProcess1 {
			get {
				return _eventSubProcess1 ?? (_eventSubProcess1 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventSubProcess1",
					SchemaElementUId = new Guid("ee281598-4d83-428f-9f61-f6b767db40b7"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _startMessage1;
		public ProcessFlowElement StartMessage1 {
			get {
				return _startMessage1 ?? (_startMessage1 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "StartMessage1",
					SchemaElementUId = new Guid("d3bbae1b-5cf7-4d40-a19a-01dbfaeb6be5"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _scriptTask1;
		public ProcessScriptTask ScriptTask1 {
			get {
				return _scriptTask1 ?? (_scriptTask1 = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptTask1",
					SchemaElementUId = new Guid("984b8d8d-2676-46fd-87cd-15ac9909f379"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ScriptTask1Execute,
				});
			}
		}

		private ProcessExclusiveGateway _exclusiveGateway1;
		public ProcessExclusiveGateway ExclusiveGateway1 {
			get {
				return _exclusiveGateway1 ?? (_exclusiveGateway1 = new ProcessExclusiveGateway() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaExclusiveGateway",
					Name = "ExclusiveGateway1",
					SchemaElementUId = new Guid("5133593d-b0eb-4d09-a083-75c9fa6bcda5"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Question = new LocalizableString(Storage, Schema.GetResourceManagerName(),
					"EventsProcessSchema.BaseElements.ExclusiveGateway1.Question"),
						IsDecisionRequired = false,
						BranchingMode = GatewayBranchingMode.Auto,
						DecisionMode = GetewayDecisionSelectionMode.Single,
						ShowUserDecisionDialog = (processId, gatewayName) => {},
				});
			}
		}

		private GenerateNumberUserTaskFlowElement _generateNumberUserTask;
		public GenerateNumberUserTaskFlowElement GenerateNumberUserTask {
			get {
				return _generateNumberUserTask ?? (_generateNumberUserTask = new GenerateNumberUserTaskFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ProcessScriptTask _scriptTask2;
		public ProcessScriptTask ScriptTask2 {
			get {
				return _scriptTask2 ?? (_scriptTask2 = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptTask2",
					SchemaElementUId = new Guid("d7bd67aa-a8c1-461f-800a-bcd07d6d2f3b"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ScriptTask2Execute,
				});
			}
		}

		private ProcessTerminateEvent _terminate1;
		public ProcessTerminateEvent Terminate1 {
			get {
				return _terminate1 ?? (_terminate1 = new ProcessTerminateEvent() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaTerminateEvent",
					Name = "Terminate1",
					SchemaElementUId = new Guid("3d94476c-7cfc-4192-8f33-584688639af0"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessConditionalFlow _conditionalFlow1;
		public ProcessConditionalFlow ConditionalFlow1 {
			get {
				return _conditionalFlow1 ?? (_conditionalFlow1 = new ProcessConditionalFlow() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaConditionalFlow",
					Name = "ConditionalFlow1",
					SchemaElementUId = new Guid("163e97b3-75aa-4e80-a257-42fa7a33526d"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						MatchBranchingDecisions = new BranchingDecisionCollection() {
				},
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[EventSubProcess1.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess1 };
			FlowElements[StartMessage1.SchemaElementUId] = new Collection<ProcessFlowElement> { StartMessage1 };
			FlowElements[ScriptTask1.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptTask1 };
			FlowElements[ExclusiveGateway1.SchemaElementUId] = new Collection<ProcessFlowElement> { ExclusiveGateway1 };
			FlowElements[GenerateNumberUserTask.SchemaElementUId] = new Collection<ProcessFlowElement> { GenerateNumberUserTask };
			FlowElements[ScriptTask2.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptTask2 };
			FlowElements[Terminate1.SchemaElementUId] = new Collection<ProcessFlowElement> { Terminate1 };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "EventSubProcess1":
						break;
					case "StartMessage1":
						e.Context.QueueTasks.Enqueue("ExclusiveGateway1");
						break;
					case "ScriptTask1":
						e.Context.QueueTasks.Enqueue("GenerateNumberUserTask");
						break;
					case "ExclusiveGateway1":
						if (ConditionalFlow1ExpressionExecute()) {
							e.Context.QueueTasks.Enqueue("ScriptTask1");
							break;
						}
						e.Context.QueueTasks.Enqueue("Terminate1");
						break;
					case "GenerateNumberUserTask":
							e.Context.QueueTasks.Enqueue("ScriptTask2");
						break;
					case "ScriptTask2":
						e.Context.QueueTasks.Enqueue("Terminate1");
						break;
					case "Terminate1":
						break;
			}
			ProcessQueue(e.Context);
		}

		private bool ConditionalFlow1ExpressionExecute() {
			return Convert.ToBoolean(string.IsNullOrEmpty(Entity.GetTypedColumnValue<string>("Number")));
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("StartMessage1");
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			switch (context.QueueTasks.Peek()) {
				case "EventSubProcess1":
					context.QueueTasks.Dequeue();
					break;
				case "StartMessage1":
					context.QueueTasks.Dequeue();
					context.SenderName = "StartMessage1";
					result = StartMessage1.Execute(context);
					break;
				case "ScriptTask1":
					context.QueueTasks.Dequeue();
					context.SenderName = "ScriptTask1";
					result = ScriptTask1.Execute(context, ScriptTask1Execute);
					break;
				case "ExclusiveGateway1":
					context.QueueTasks.Dequeue();
					context.SenderName = "ExclusiveGateway1";
					result = ExclusiveGateway1.Execute(context);
					break;
				case "GenerateNumberUserTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "GenerateNumberUserTask";
					result = GenerateNumberUserTask.Execute(context);
					break;
				case "ScriptTask2":
					context.QueueTasks.Dequeue();
					context.SenderName = "ScriptTask2";
					result = ScriptTask2.Execute(context, ScriptTask2Execute);
					break;
				case "Terminate1":
					context.QueueTasks.Dequeue();
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool ScriptTask1Execute(ProcessExecutingContext context) {
			GenerateNumberUserTask.EntitySchema = Entity.Schema;
			return true;
		}

		public virtual bool ScriptTask2Execute(ProcessExecutingContext context) {
			string code = GenerateNumberUserTask.ResultCode;
			if(!string.IsNullOrEmpty(code)) {
				Entity.SetColumnValue("Number", code);
			}
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "Problem_Problem_BPMSoftInserting":
							if (ActivatedEventElements.Contains("StartMessage1")) {
							context.QueueTasks.Enqueue("StartMessage1");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: Problem_ProblemEventsProcess

	/// <exclude/>
	public class Problem_ProblemEventsProcess : Problem_ProblemEventsProcess<Problem_Problem_BPMSoft>
	{

		public Problem_ProblemEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: Problem_ProblemEventsProcess

	public partial class Problem_ProblemEventsProcess<TEntity>
	{

		#region Methods: Public

		public override void LocalMessageExecuting(EntityChangeType changeType) {
			var lmHelper = new BPMSoft.Configuration.LocalMessageHelper(this.Entity, UserConnection, changeType);
			lmHelper.CreateLocalMessage();
		}

		#endregion

	}

	#endregion

}

