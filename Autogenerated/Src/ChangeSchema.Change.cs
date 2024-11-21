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

	#region Class: Change_Change_BPMSoftSchema

	/// <exclude/>
	public class Change_Change_BPMSoftSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public Change_Change_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public Change_Change_BPMSoftSchema(Change_Change_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public Change_Change_BPMSoftSchema(Change_Change_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("de5c8d59-d372-407d-8c09-f0523e057e40");
			RealUId = new Guid("de5c8d59-d372-407d-8c09-f0523e057e40");
			Name = "Change_Change_BPMSoft";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("2496861e-1f72-4434-ab9e-c42503decf6d");
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
			if (Columns.FindByUId(new Guid("20cd633d-64eb-4601-b7a6-53f651059309")) == null) {
				Columns.Add(CreateNameColumn());
			}
			if (Columns.FindByUId(new Guid("ef960d0b-4d06-4f20-9dff-dc2494121c2e")) == null) {
				Columns.Add(CreateAuthorColumn());
			}
			if (Columns.FindByUId(new Guid("c9d91891-c5d8-4e0f-a78c-51fcbaafe8d5")) == null) {
				Columns.Add(CreateDescriptionColumn());
			}
			if (Columns.FindByUId(new Guid("91f5897c-b39a-453f-b75f-6002116cad3f")) == null) {
				Columns.Add(CreateRegisteredOnColumn());
			}
			if (Columns.FindByUId(new Guid("2e6ab622-3100-4d6e-878f-d1aa54279702")) == null) {
				Columns.Add(CreateOwnerColumn());
			}
			if (Columns.FindByUId(new Guid("1a911a7c-231e-4c7d-a59d-0111fbc2e57d")) == null) {
				Columns.Add(CreateGroupColumn());
			}
			if (Columns.FindByUId(new Guid("a05f4191-fd34-49fc-ac89-e13f303c41d1")) == null) {
				Columns.Add(CreateScheduledClosureDateColumn());
			}
			if (Columns.FindByUId(new Guid("5061c568-6d7d-4275-9235-0bc62d5f55c5")) == null) {
				Columns.Add(CreateClosureDateColumn());
			}
			if (Columns.FindByUId(new Guid("327d72b2-50bc-40bd-815b-0b4eef89b11d")) == null) {
				Columns.Add(CreatePlannedLaborColumn());
			}
			if (Columns.FindByUId(new Guid("fb43c344-1d88-447e-8ff8-1606c143ba5b")) == null) {
				Columns.Add(CreateActualLaborColumn());
			}
			if (Columns.FindByUId(new Guid("6b9409b1-ff82-4671-be4b-a14c83b09398")) == null) {
				Columns.Add(CreateParentChangeColumn());
			}
			if (Columns.FindByUId(new Guid("cf1bf1bd-8bf3-4483-9b7e-acbee1773425")) == null) {
				Columns.Add(CreateSourceColumn());
			}
			if (Columns.FindByUId(new Guid("db525523-5d83-4761-98d2-7171d07c3ff8")) == null) {
				Columns.Add(CreatePurposeColumn());
			}
			if (Columns.FindByUId(new Guid("5ebb6f9b-6894-4b79-aa90-18de7205f6d5")) == null) {
				Columns.Add(CreateCategoryColumn());
			}
			if (Columns.FindByUId(new Guid("748cb602-de66-4356-a843-1dd836cb375b")) == null) {
				Columns.Add(CreatePriorityColumn());
			}
			if (Columns.FindByUId(new Guid("1404f6e2-7804-4618-b7a7-99dffa95c0ce")) == null) {
				Columns.Add(CreateStatusColumn());
			}
			if (Columns.FindByUId(new Guid("4df0636c-31b0-4256-ae5b-c2fe616604af")) == null) {
				Columns.Add(CreateNotesColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("de5c8d59-d372-407d-8c09-f0523e057e40");
			column.CreatedInPackageId = new Guid("2496861e-1f72-4434-ab9e-c42503decf6d");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("de5c8d59-d372-407d-8c09-f0523e057e40");
			column.CreatedInPackageId = new Guid("2496861e-1f72-4434-ab9e-c42503decf6d");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("de5c8d59-d372-407d-8c09-f0523e057e40");
			column.CreatedInPackageId = new Guid("2496861e-1f72-4434-ab9e-c42503decf6d");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("de5c8d59-d372-407d-8c09-f0523e057e40");
			column.CreatedInPackageId = new Guid("2496861e-1f72-4434-ab9e-c42503decf6d");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("de5c8d59-d372-407d-8c09-f0523e057e40");
			column.CreatedInPackageId = new Guid("2496861e-1f72-4434-ab9e-c42503decf6d");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("de5c8d59-d372-407d-8c09-f0523e057e40");
			column.CreatedInPackageId = new Guid("2496861e-1f72-4434-ab9e-c42503decf6d");
			return column;
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("20cd633d-64eb-4601-b7a6-53f651059309"),
				Name = @"Name",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("de5c8d59-d372-407d-8c09-f0523e057e40"),
				ModifiedInSchemaUId = new Guid("de5c8d59-d372-407d-8c09-f0523e057e40"),
				CreatedInPackageId = new Guid("2496861e-1f72-4434-ab9e-c42503decf6d")
			};
		}

		protected virtual EntitySchemaColumn CreateNumberColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("a195834a-3714-46a4-9169-3bb7ae806722"),
				Name = @"Number",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("de5c8d59-d372-407d-8c09-f0523e057e40"),
				ModifiedInSchemaUId = new Guid("de5c8d59-d372-407d-8c09-f0523e057e40"),
				CreatedInPackageId = new Guid("2496861e-1f72-4434-ab9e-c42503decf6d")
			};
		}

		protected virtual EntitySchemaColumn CreateAuthorColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("ef960d0b-4d06-4f20-9dff-dc2494121c2e"),
				Name = @"Author",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("de5c8d59-d372-407d-8c09-f0523e057e40"),
				ModifiedInSchemaUId = new Guid("de5c8d59-d372-407d-8c09-f0523e057e40"),
				CreatedInPackageId = new Guid("2496861e-1f72-4434-ab9e-c42503decf6d"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.SystemValue,
					ValueSource = SystemValueManager.GetInstanceByName(@"CurrentUserContact")
				}
			};
		}

		protected virtual EntitySchemaColumn CreateDescriptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("c9d91891-c5d8-4e0f-a78c-51fcbaafe8d5"),
				Name = @"Description",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("de5c8d59-d372-407d-8c09-f0523e057e40"),
				ModifiedInSchemaUId = new Guid("de5c8d59-d372-407d-8c09-f0523e057e40"),
				CreatedInPackageId = new Guid("2496861e-1f72-4434-ab9e-c42503decf6d")
			};
		}

		protected virtual EntitySchemaColumn CreateRegisteredOnColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("91f5897c-b39a-453f-b75f-6002116cad3f"),
				Name = @"RegisteredOn",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("de5c8d59-d372-407d-8c09-f0523e057e40"),
				ModifiedInSchemaUId = new Guid("de5c8d59-d372-407d-8c09-f0523e057e40"),
				CreatedInPackageId = new Guid("2496861e-1f72-4434-ab9e-c42503decf6d"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.SystemValue,
					ValueSource = SystemValueManager.GetInstanceByName(@"CurrentDateTime")
				}
			};
		}

		protected virtual EntitySchemaColumn CreateOwnerColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("2e6ab622-3100-4d6e-878f-d1aa54279702"),
				Name = @"Owner",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("de5c8d59-d372-407d-8c09-f0523e057e40"),
				ModifiedInSchemaUId = new Guid("de5c8d59-d372-407d-8c09-f0523e057e40"),
				CreatedInPackageId = new Guid("2496861e-1f72-4434-ab9e-c42503decf6d"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.SystemValue,
					ValueSource = SystemValueManager.GetInstanceByName(@"CurrentUserContact")
				}
			};
		}

		protected virtual EntitySchemaColumn CreateGroupColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("1a911a7c-231e-4c7d-a59d-0111fbc2e57d"),
				Name = @"Group",
				ReferenceSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("de5c8d59-d372-407d-8c09-f0523e057e40"),
				ModifiedInSchemaUId = new Guid("de5c8d59-d372-407d-8c09-f0523e057e40"),
				CreatedInPackageId = new Guid("2496861e-1f72-4434-ab9e-c42503decf6d")
			};
		}

		protected virtual EntitySchemaColumn CreateScheduledClosureDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("a05f4191-fd34-49fc-ac89-e13f303c41d1"),
				Name = @"ScheduledClosureDate",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("de5c8d59-d372-407d-8c09-f0523e057e40"),
				ModifiedInSchemaUId = new Guid("de5c8d59-d372-407d-8c09-f0523e057e40"),
				CreatedInPackageId = new Guid("2496861e-1f72-4434-ab9e-c42503decf6d")
			};
		}

		protected virtual EntitySchemaColumn CreateClosureDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("5061c568-6d7d-4275-9235-0bc62d5f55c5"),
				Name = @"ClosureDate",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("de5c8d59-d372-407d-8c09-f0523e057e40"),
				ModifiedInSchemaUId = new Guid("de5c8d59-d372-407d-8c09-f0523e057e40"),
				CreatedInPackageId = new Guid("2496861e-1f72-4434-ab9e-c42503decf6d")
			};
		}

		protected virtual EntitySchemaColumn CreatePlannedLaborColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("327d72b2-50bc-40bd-815b-0b4eef89b11d"),
				Name = @"PlannedLabor",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("de5c8d59-d372-407d-8c09-f0523e057e40"),
				ModifiedInSchemaUId = new Guid("de5c8d59-d372-407d-8c09-f0523e057e40"),
				CreatedInPackageId = new Guid("2496861e-1f72-4434-ab9e-c42503decf6d")
			};
		}

		protected virtual EntitySchemaColumn CreateActualLaborColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("fb43c344-1d88-447e-8ff8-1606c143ba5b"),
				Name = @"ActualLabor",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("de5c8d59-d372-407d-8c09-f0523e057e40"),
				ModifiedInSchemaUId = new Guid("de5c8d59-d372-407d-8c09-f0523e057e40"),
				CreatedInPackageId = new Guid("2496861e-1f72-4434-ab9e-c42503decf6d")
			};
		}

		protected virtual EntitySchemaColumn CreateParentChangeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("6b9409b1-ff82-4671-be4b-a14c83b09398"),
				Name = @"ParentChange",
				ReferenceSchemaUId = new Guid("de5c8d59-d372-407d-8c09-f0523e057e40"),
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("de5c8d59-d372-407d-8c09-f0523e057e40"),
				ModifiedInSchemaUId = new Guid("de5c8d59-d372-407d-8c09-f0523e057e40"),
				CreatedInPackageId = new Guid("2496861e-1f72-4434-ab9e-c42503decf6d")
			};
		}

		protected virtual EntitySchemaColumn CreateSourceColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("cf1bf1bd-8bf3-4483-9b7e-acbee1773425"),
				Name = @"Source",
				ReferenceSchemaUId = new Guid("8e7dbfee-4575-4f1f-ad08-e77dea794a42"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("de5c8d59-d372-407d-8c09-f0523e057e40"),
				ModifiedInSchemaUId = new Guid("de5c8d59-d372-407d-8c09-f0523e057e40"),
				CreatedInPackageId = new Guid("2496861e-1f72-4434-ab9e-c42503decf6d"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Settings,
					ValueSource = @"ChangeSourceDef"
				}
			};
		}

		protected virtual EntitySchemaColumn CreatePurposeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("db525523-5d83-4761-98d2-7171d07c3ff8"),
				Name = @"Purpose",
				ReferenceSchemaUId = new Guid("9877f383-7ab3-4fd9-b0d1-30e0480fae61"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("de5c8d59-d372-407d-8c09-f0523e057e40"),
				ModifiedInSchemaUId = new Guid("de5c8d59-d372-407d-8c09-f0523e057e40"),
				CreatedInPackageId = new Guid("2496861e-1f72-4434-ab9e-c42503decf6d"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Settings,
					ValueSource = @"ChangePurposeDef"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateCategoryColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("5ebb6f9b-6894-4b79-aa90-18de7205f6d5"),
				Name = @"Category",
				ReferenceSchemaUId = new Guid("55a53753-0a2b-47ea-aa8f-b644a77cd17f"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("de5c8d59-d372-407d-8c09-f0523e057e40"),
				ModifiedInSchemaUId = new Guid("de5c8d59-d372-407d-8c09-f0523e057e40"),
				CreatedInPackageId = new Guid("2496861e-1f72-4434-ab9e-c42503decf6d"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Settings,
					ValueSource = @"ChangeCategoryDef"
				}
			};
		}

		protected virtual EntitySchemaColumn CreatePriorityColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("748cb602-de66-4356-a843-1dd836cb375b"),
				Name = @"Priority",
				ReferenceSchemaUId = new Guid("6138a110-3724-4428-9c3c-cb1930f0811a"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("de5c8d59-d372-407d-8c09-f0523e057e40"),
				ModifiedInSchemaUId = new Guid("de5c8d59-d372-407d-8c09-f0523e057e40"),
				CreatedInPackageId = new Guid("2496861e-1f72-4434-ab9e-c42503decf6d"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Settings,
					ValueSource = @"ChangePriorityDef"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateStatusColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("1404f6e2-7804-4618-b7a7-99dffa95c0ce"),
				Name = @"Status",
				ReferenceSchemaUId = new Guid("0b56d699-50cc-4420-9c3b-08a9cbde21c7"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("de5c8d59-d372-407d-8c09-f0523e057e40"),
				ModifiedInSchemaUId = new Guid("de5c8d59-d372-407d-8c09-f0523e057e40"),
				CreatedInPackageId = new Guid("2496861e-1f72-4434-ab9e-c42503decf6d"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Settings,
					ValueSource = @"ChangeStatusDef"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateNotesColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("4df0636c-31b0-4256-ae5b-c2fe616604af"),
				Name = @"Notes",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("de5c8d59-d372-407d-8c09-f0523e057e40"),
				ModifiedInSchemaUId = new Guid("de5c8d59-d372-407d-8c09-f0523e057e40"),
				CreatedInPackageId = new Guid("2496861e-1f72-4434-ab9e-c42503decf6d")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new Change_Change_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Change_ChangeEventsProcess(userConnection);
		}

		public override object Clone() {
			return new Change_Change_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new Change_Change_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("de5c8d59-d372-407d-8c09-f0523e057e40"));
		}

		#endregion

	}

	#endregion

	#region Class: Change_Change_BPMSoft

	/// <summary>
	/// Изменение.
	/// </summary>
	public class Change_Change_BPMSoft : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public Change_Change_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Change_Change_BPMSoft";
		}

		public Change_Change_BPMSoft(Change_Change_BPMSoft source)
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

		/// <summary>
		/// Описание.
		/// </summary>
		public string Description {
			get {
				return GetTypedColumnValue<string>("Description");
			}
			set {
				SetColumnValue("Description", value);
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

		/// <summary>
		/// План. завершение.
		/// </summary>
		public DateTime ScheduledClosureDate {
			get {
				return GetTypedColumnValue<DateTime>("ScheduledClosureDate");
			}
			set {
				SetColumnValue("ScheduledClosureDate", value);
			}
		}

		/// <summary>
		/// Факт. завершение.
		/// </summary>
		public DateTime ClosureDate {
			get {
				return GetTypedColumnValue<DateTime>("ClosureDate");
			}
			set {
				SetColumnValue("ClosureDate", value);
			}
		}

		/// <summary>
		/// План. трудозатраты (часов).
		/// </summary>
		public int PlannedLabor {
			get {
				return GetTypedColumnValue<int>("PlannedLabor");
			}
			set {
				SetColumnValue("PlannedLabor", value);
			}
		}

		/// <summary>
		/// Факт. трудозатраты (часов).
		/// </summary>
		public int ActualLabor {
			get {
				return GetTypedColumnValue<int>("ActualLabor");
			}
			set {
				SetColumnValue("ActualLabor", value);
			}
		}

		/// <exclude/>
		public Guid ParentChangeId {
			get {
				return GetTypedColumnValue<Guid>("ParentChangeId");
			}
			set {
				SetColumnValue("ParentChangeId", value);
				_parentChange = null;
			}
		}

		/// <exclude/>
		public string ParentChangeNumber {
			get {
				return GetTypedColumnValue<string>("ParentChangeNumber");
			}
			set {
				SetColumnValue("ParentChangeNumber", value);
				if (_parentChange != null) {
					_parentChange.Number = value;
				}
			}
		}

		private Change _parentChange;
		/// <summary>
		/// Родительское изменение.
		/// </summary>
		public Change ParentChange {
			get {
				return _parentChange ??
					(_parentChange = LookupColumnEntities.GetEntity("ParentChange") as Change);
			}
		}

		/// <exclude/>
		public Guid SourceId {
			get {
				return GetTypedColumnValue<Guid>("SourceId");
			}
			set {
				SetColumnValue("SourceId", value);
				_source = null;
			}
		}

		/// <exclude/>
		public string SourceName {
			get {
				return GetTypedColumnValue<string>("SourceName");
			}
			set {
				SetColumnValue("SourceName", value);
				if (_source != null) {
					_source.Name = value;
				}
			}
		}

		private ChangeSource _source;
		/// <summary>
		/// Источник.
		/// </summary>
		public ChangeSource Source {
			get {
				return _source ??
					(_source = LookupColumnEntities.GetEntity("Source") as ChangeSource);
			}
		}

		/// <exclude/>
		public Guid PurposeId {
			get {
				return GetTypedColumnValue<Guid>("PurposeId");
			}
			set {
				SetColumnValue("PurposeId", value);
				_purpose = null;
			}
		}

		/// <exclude/>
		public string PurposeName {
			get {
				return GetTypedColumnValue<string>("PurposeName");
			}
			set {
				SetColumnValue("PurposeName", value);
				if (_purpose != null) {
					_purpose.Name = value;
				}
			}
		}

		private ChangePurpose _purpose;
		/// <summary>
		/// Цель.
		/// </summary>
		public ChangePurpose Purpose {
			get {
				return _purpose ??
					(_purpose = LookupColumnEntities.GetEntity("Purpose") as ChangePurpose);
			}
		}

		/// <exclude/>
		public Guid CategoryId {
			get {
				return GetTypedColumnValue<Guid>("CategoryId");
			}
			set {
				SetColumnValue("CategoryId", value);
				_category = null;
			}
		}

		/// <exclude/>
		public string CategoryName {
			get {
				return GetTypedColumnValue<string>("CategoryName");
			}
			set {
				SetColumnValue("CategoryName", value);
				if (_category != null) {
					_category.Name = value;
				}
			}
		}

		private ChangeCategory _category;
		/// <summary>
		/// Категория.
		/// </summary>
		public ChangeCategory Category {
			get {
				return _category ??
					(_category = LookupColumnEntities.GetEntity("Category") as ChangeCategory);
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

		private ChangePriority _priority;
		/// <summary>
		/// Приоритет.
		/// </summary>
		public ChangePriority Priority {
			get {
				return _priority ??
					(_priority = LookupColumnEntities.GetEntity("Priority") as ChangePriority);
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

		private ChangeStatus _status;
		/// <summary>
		/// Состояние.
		/// </summary>
		public ChangeStatus Status {
			get {
				return _status ??
					(_status = LookupColumnEntities.GetEntity("Status") as ChangeStatus);
			}
		}

		/// <summary>
		/// Примечание.
		/// </summary>
		public string Notes {
			get {
				return GetTypedColumnValue<string>("Notes");
			}
			set {
				SetColumnValue("Notes", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Change_ChangeEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("Change_Change_BPMSoftDeleted", e);
			Inserting += (s, e) => ThrowEvent("Change_Change_BPMSoftInserting", e);
			Validating += (s, e) => ThrowEvent("Change_Change_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new Change_Change_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: Change_ChangeEventsProcess

	/// <exclude/>
	public partial class Change_ChangeEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : Change_Change_BPMSoft
	{

		#region Class: GenerateNumberUserTaskFlowElement

		/// <exclude/>
		public class GenerateNumberUserTaskFlowElement : GenerateSequenseNumberUserTask
		{

			public GenerateNumberUserTaskFlowElement(UserConnection userConnection, Change_ChangeEventsProcess<TEntity> process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "GenerateNumberUserTask";
				IsLogging = false;
				SchemaElementUId = new Guid("5c3a7a2a-267d-4097-88c4-054feb90895f");
				CreatedInSchemaUId = process.InternalSchemaUId;
			}

		}

		#endregion

		public Change_ChangeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Change_ChangeEventsProcess";
			SchemaUId = new Guid("de5c8d59-d372-407d-8c09-f0523e057e40");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("de5c8d59-d372-407d-8c09-f0523e057e40");
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
					SchemaElementUId = new Guid("3447ea85-6d77-48d2-a9be-dbfe3c155bf1"),
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
					SchemaElementUId = new Guid("4cd410bd-c1ec-4cd5-89e6-ce32eb6b0306"),
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
					SchemaElementUId = new Guid("651f98bb-2779-42be-bac8-dbc86b79bb53"),
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
					SchemaElementUId = new Guid("a7003b2b-3485-46c9-8f4a-6b93088e1fca"),
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
					SchemaElementUId = new Guid("ecf02f4a-138b-4146-a354-e6861f8d0b27"),
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
					SchemaElementUId = new Guid("80695205-a998-47e7-b8ef-90657b9063bf"),
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
					SchemaElementUId = new Guid("ecc056dd-6efb-4be2-9d39-b8d9ef6aa075"),
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
					case "Change_Change_BPMSoftInserting":
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

	#region Class: Change_ChangeEventsProcess

	/// <exclude/>
	public class Change_ChangeEventsProcess : Change_ChangeEventsProcess<Change_Change_BPMSoft>
	{

		public Change_ChangeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: Change_ChangeEventsProcess

	public partial class Change_ChangeEventsProcess<TEntity>
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

