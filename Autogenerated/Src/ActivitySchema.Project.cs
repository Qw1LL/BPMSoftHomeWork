namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Configuration.ProjectService;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.DcmProcess;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;
	using BPMSoft.Core.Process;
	using BPMSoft.Core.Process.Configuration;
	using BPMSoft.Core.Store;
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
	using System.Text;
	using System.Text.RegularExpressions;
	using System.Web;

	#region Class: Activity_Project_BPMSoftSchema

	/// <exclude/>
	public class Activity_Project_BPMSoftSchema : BPMSoft.Configuration.Activity_Portal_BPMSoftSchema
	{

		#region Constructors: Public

		public Activity_Project_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public Activity_Project_BPMSoftSchema(Activity_Project_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public Activity_Project_BPMSoftSchema(Activity_Project_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateIX_Activity_SendDateIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = true,
				IsClustered = false,
				IsUnique = false
			};
			index.UId = new Guid("1e60c588-1264-4219-9f83-2a3e68bc54b6");
			index.Name = "IX_Activity_SendDate";
			index.CreatedInSchemaUId = new Guid("8a8f2187-7621-4d4b-904d-af660770442d");
			index.ModifiedInSchemaUId = new Guid("8a8f2187-7621-4d4b-904d-af660770442d");
			index.CreatedInPackageId = new Guid("d931fb95-07c0-4237-ab9a-64ecf34e5aed");
			EntitySchemaIndexColumn sendDateIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("b8f4292f-5ae6-43ca-9685-1301b31eba68"),
				ColumnUId = new Guid("6689a019-c904-4b25-a89d-d17f3f3767cc"),
				CreatedInSchemaUId = new Guid("8a8f2187-7621-4d4b-904d-af660770442d"),
				ModifiedInSchemaUId = new Guid("8a8f2187-7621-4d4b-904d-af660770442d"),
				CreatedInPackageId = new Guid("d931fb95-07c0-4237-ab9a-64ecf34e5aed"),
				OrderDirection = OrderDirectionStrict.Descending
			};
			index.Columns.Add(sendDateIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("5d2e238c-305a-4610-927c-ede2a53ca517");
			Name = "Activity_Project_BPMSoft";
			ParentSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89");
			ExtendParent = true;
			CreatedInPackageId = new Guid("fe2bb0e4-061e-41b1-be85-5078c802043f");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("e2d77c79-645a-450c-b4bd-0bbf55588489")) == null) {
				Columns.Add(CreateProjectColumn());
			}
			if (Columns.FindByUId(new Guid("a07b44ec-9d82-4c14-a5a6-a7bc4a1c9354")) == null) {
				Columns.Add(CreateFullProjectNameColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("5d2e238c-305a-4610-927c-ede2a53ca517");
			column.CreatedInPackageId = new Guid("fe2bb0e4-061e-41b1-be85-5078c802043f");
			return column;
		}

		protected override EntitySchemaColumn CreateTitleColumn() {
			EntitySchemaColumn column = base.CreateTitleColumn();
			column.ModifiedInSchemaUId = new Guid("5d2e238c-305a-4610-927c-ede2a53ca517");
			column.CreatedInPackageId = new Guid("fe2bb0e4-061e-41b1-be85-5078c802043f");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("5d2e238c-305a-4610-927c-ede2a53ca517");
			column.CreatedInPackageId = new Guid("fe2bb0e4-061e-41b1-be85-5078c802043f");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("5d2e238c-305a-4610-927c-ede2a53ca517");
			column.CreatedInPackageId = new Guid("fe2bb0e4-061e-41b1-be85-5078c802043f");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("5d2e238c-305a-4610-927c-ede2a53ca517");
			column.CreatedInPackageId = new Guid("fe2bb0e4-061e-41b1-be85-5078c802043f");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("5d2e238c-305a-4610-927c-ede2a53ca517");
			column.CreatedInPackageId = new Guid("fe2bb0e4-061e-41b1-be85-5078c802043f");
			return column;
		}

		protected override EntitySchemaColumn CreateStartDateColumn() {
			EntitySchemaColumn column = base.CreateStartDateColumn();
			column.ModifiedInSchemaUId = new Guid("5d2e238c-305a-4610-927c-ede2a53ca517");
			column.CreatedInPackageId = new Guid("fe2bb0e4-061e-41b1-be85-5078c802043f");
			return column;
		}

		protected override EntitySchemaColumn CreateDueDateColumn() {
			EntitySchemaColumn column = base.CreateDueDateColumn();
			column.ModifiedInSchemaUId = new Guid("5d2e238c-305a-4610-927c-ede2a53ca517");
			column.CreatedInPackageId = new Guid("fe2bb0e4-061e-41b1-be85-5078c802043f");
			return column;
		}

		protected override EntitySchemaColumn CreatePriorityColumn() {
			EntitySchemaColumn column = base.CreatePriorityColumn();
			column.ModifiedInSchemaUId = new Guid("5d2e238c-305a-4610-927c-ede2a53ca517");
			column.CreatedInPackageId = new Guid("fe2bb0e4-061e-41b1-be85-5078c802043f");
			return column;
		}

		protected override EntitySchemaColumn CreateAuthorColumn() {
			EntitySchemaColumn column = base.CreateAuthorColumn();
			column.ModifiedInSchemaUId = new Guid("5d2e238c-305a-4610-927c-ede2a53ca517");
			column.CreatedInPackageId = new Guid("fe2bb0e4-061e-41b1-be85-5078c802043f");
			return column;
		}

		protected override EntitySchemaColumn CreateRemindToAuthorColumn() {
			EntitySchemaColumn column = base.CreateRemindToAuthorColumn();
			column.ModifiedInSchemaUId = new Guid("5d2e238c-305a-4610-927c-ede2a53ca517");
			column.CreatedInPackageId = new Guid("fe2bb0e4-061e-41b1-be85-5078c802043f");
			return column;
		}

		protected override EntitySchemaColumn CreateRemindToAuthorDateColumn() {
			EntitySchemaColumn column = base.CreateRemindToAuthorDateColumn();
			column.ModifiedInSchemaUId = new Guid("5d2e238c-305a-4610-927c-ede2a53ca517");
			column.CreatedInPackageId = new Guid("fe2bb0e4-061e-41b1-be85-5078c802043f");
			return column;
		}

		protected override EntitySchemaColumn CreateOwnerColumn() {
			EntitySchemaColumn column = base.CreateOwnerColumn();
			column.ModifiedInSchemaUId = new Guid("5d2e238c-305a-4610-927c-ede2a53ca517");
			column.CreatedInPackageId = new Guid("fe2bb0e4-061e-41b1-be85-5078c802043f");
			return column;
		}

		protected override EntitySchemaColumn CreateRemindToOwnerColumn() {
			EntitySchemaColumn column = base.CreateRemindToOwnerColumn();
			column.ModifiedInSchemaUId = new Guid("5d2e238c-305a-4610-927c-ede2a53ca517");
			column.CreatedInPackageId = new Guid("fe2bb0e4-061e-41b1-be85-5078c802043f");
			return column;
		}

		protected override EntitySchemaColumn CreateRemindToOwnerDateColumn() {
			EntitySchemaColumn column = base.CreateRemindToOwnerDateColumn();
			column.ModifiedInSchemaUId = new Guid("5d2e238c-305a-4610-927c-ede2a53ca517");
			column.CreatedInPackageId = new Guid("fe2bb0e4-061e-41b1-be85-5078c802043f");
			return column;
		}

		protected override EntitySchemaColumn CreateTypeColumn() {
			EntitySchemaColumn column = base.CreateTypeColumn();
			column.ModifiedInSchemaUId = new Guid("5d2e238c-305a-4610-927c-ede2a53ca517");
			column.CreatedInPackageId = new Guid("fe2bb0e4-061e-41b1-be85-5078c802043f");
			return column;
		}

		protected override EntitySchemaColumn CreateActivityCategoryColumn() {
			EntitySchemaColumn column = base.CreateActivityCategoryColumn();
			column.ModifiedInSchemaUId = new Guid("5d2e238c-305a-4610-927c-ede2a53ca517");
			column.CreatedInPackageId = new Guid("fe2bb0e4-061e-41b1-be85-5078c802043f");
			return column;
		}

		protected override EntitySchemaColumn CreateShowInSchedulerColumn() {
			EntitySchemaColumn column = base.CreateShowInSchedulerColumn();
			column.ModifiedInSchemaUId = new Guid("5d2e238c-305a-4610-927c-ede2a53ca517");
			column.CreatedInPackageId = new Guid("fe2bb0e4-061e-41b1-be85-5078c802043f");
			return column;
		}

		protected override EntitySchemaColumn CreateStatusColumn() {
			EntitySchemaColumn column = base.CreateStatusColumn();
			column.ModifiedInSchemaUId = new Guid("5d2e238c-305a-4610-927c-ede2a53ca517");
			column.CreatedInPackageId = new Guid("fe2bb0e4-061e-41b1-be85-5078c802043f");
			return column;
		}

		protected override EntitySchemaColumn CreateResultColumn() {
			EntitySchemaColumn column = base.CreateResultColumn();
			column.ModifiedInSchemaUId = new Guid("5d2e238c-305a-4610-927c-ede2a53ca517");
			column.CreatedInPackageId = new Guid("fe2bb0e4-061e-41b1-be85-5078c802043f");
			return column;
		}

		protected override EntitySchemaColumn CreateDetailedResultColumn() {
			EntitySchemaColumn column = base.CreateDetailedResultColumn();
			column.ModifiedInSchemaUId = new Guid("5d2e238c-305a-4610-927c-ede2a53ca517");
			column.CreatedInPackageId = new Guid("fe2bb0e4-061e-41b1-be85-5078c802043f");
			return column;
		}

		protected override EntitySchemaColumn CreateTimeZoneColumn() {
			EntitySchemaColumn column = base.CreateTimeZoneColumn();
			column.ModifiedInSchemaUId = new Guid("5d2e238c-305a-4610-927c-ede2a53ca517");
			column.CreatedInPackageId = new Guid("fe2bb0e4-061e-41b1-be85-5078c802043f");
			return column;
		}

		protected override EntitySchemaColumn CreateAccountColumn() {
			EntitySchemaColumn column = base.CreateAccountColumn();
			column.ModifiedInSchemaUId = new Guid("5d2e238c-305a-4610-927c-ede2a53ca517");
			column.CreatedInPackageId = new Guid("fe2bb0e4-061e-41b1-be85-5078c802043f");
			return column;
		}

		protected override EntitySchemaColumn CreateContactColumn() {
			EntitySchemaColumn column = base.CreateContactColumn();
			column.ModifiedInSchemaUId = new Guid("5d2e238c-305a-4610-927c-ede2a53ca517");
			column.CreatedInPackageId = new Guid("fe2bb0e4-061e-41b1-be85-5078c802043f");
			return column;
		}

		protected override EntitySchemaColumn CreateSenderColumn() {
			EntitySchemaColumn column = base.CreateSenderColumn();
			column.ModifiedInSchemaUId = new Guid("5d2e238c-305a-4610-927c-ede2a53ca517");
			column.CreatedInPackageId = new Guid("fe2bb0e4-061e-41b1-be85-5078c802043f");
			return column;
		}

		protected override EntitySchemaColumn CreateRecepientColumn() {
			EntitySchemaColumn column = base.CreateRecepientColumn();
			column.ModifiedInSchemaUId = new Guid("5d2e238c-305a-4610-927c-ede2a53ca517");
			column.CreatedInPackageId = new Guid("fe2bb0e4-061e-41b1-be85-5078c802043f");
			return column;
		}

		protected override EntitySchemaColumn CreateCopyRecepientColumn() {
			EntitySchemaColumn column = base.CreateCopyRecepientColumn();
			column.ModifiedInSchemaUId = new Guid("5d2e238c-305a-4610-927c-ede2a53ca517");
			column.CreatedInPackageId = new Guid("fe2bb0e4-061e-41b1-be85-5078c802043f");
			return column;
		}

		protected override EntitySchemaColumn CreateBlindCopyRecepientColumn() {
			EntitySchemaColumn column = base.CreateBlindCopyRecepientColumn();
			column.ModifiedInSchemaUId = new Guid("5d2e238c-305a-4610-927c-ede2a53ca517");
			column.CreatedInPackageId = new Guid("fe2bb0e4-061e-41b1-be85-5078c802043f");
			return column;
		}

		protected override EntitySchemaColumn CreateBodyColumn() {
			EntitySchemaColumn column = base.CreateBodyColumn();
			column.ModifiedInSchemaUId = new Guid("5d2e238c-305a-4610-927c-ede2a53ca517");
			column.CreatedInPackageId = new Guid("fe2bb0e4-061e-41b1-be85-5078c802043f");
			return column;
		}

		protected override EntitySchemaColumn CreateNotesColumn() {
			EntitySchemaColumn column = base.CreateNotesColumn();
			column.ModifiedInSchemaUId = new Guid("5d2e238c-305a-4610-927c-ede2a53ca517");
			column.CreatedInPackageId = new Guid("fe2bb0e4-061e-41b1-be85-5078c802043f");
			return column;
		}

		protected override EntitySchemaColumn CreateColorColumn() {
			EntitySchemaColumn column = base.CreateColorColumn();
			column.ModifiedInSchemaUId = new Guid("5d2e238c-305a-4610-927c-ede2a53ca517");
			column.CreatedInPackageId = new Guid("fe2bb0e4-061e-41b1-be85-5078c802043f");
			return column;
		}

		protected override EntitySchemaColumn CreateSendDateColumn() {
			EntitySchemaColumn column = base.CreateSendDateColumn();
			column.ModifiedInSchemaUId = new Guid("5d2e238c-305a-4610-927c-ede2a53ca517");
			column.CreatedInPackageId = new Guid("fe2bb0e4-061e-41b1-be85-5078c802043f");
			return column;
		}

		protected override EntitySchemaColumn CreateEmailSendStatusColumn() {
			EntitySchemaColumn column = base.CreateEmailSendStatusColumn();
			column.ModifiedInSchemaUId = new Guid("5d2e238c-305a-4610-927c-ede2a53ca517");
			column.CreatedInPackageId = new Guid("fe2bb0e4-061e-41b1-be85-5078c802043f");
			return column;
		}

		protected override EntitySchemaColumn CreateDurationInMinutesColumn() {
			EntitySchemaColumn column = base.CreateDurationInMinutesColumn();
			column.ModifiedInSchemaUId = new Guid("5d2e238c-305a-4610-927c-ede2a53ca517");
			column.CreatedInPackageId = new Guid("fe2bb0e4-061e-41b1-be85-5078c802043f");
			return column;
		}

		protected override EntitySchemaColumn CreateErrorOnSendColumn() {
			EntitySchemaColumn column = base.CreateErrorOnSendColumn();
			column.ModifiedInSchemaUId = new Guid("5d2e238c-305a-4610-927c-ede2a53ca517");
			column.CreatedInPackageId = new Guid("fe2bb0e4-061e-41b1-be85-5078c802043f");
			return column;
		}

		protected override EntitySchemaColumn CreateDurationInMnutesAndHoursColumn() {
			EntitySchemaColumn column = base.CreateDurationInMnutesAndHoursColumn();
			column.ModifiedInSchemaUId = new Guid("5d2e238c-305a-4610-927c-ede2a53ca517");
			column.CreatedInPackageId = new Guid("fe2bb0e4-061e-41b1-be85-5078c802043f");
			return column;
		}

		protected override EntitySchemaColumn CreateAllowedResultColumn() {
			EntitySchemaColumn column = base.CreateAllowedResultColumn();
			column.ModifiedInSchemaUId = new Guid("5d2e238c-305a-4610-927c-ede2a53ca517");
			column.CreatedInPackageId = new Guid("fe2bb0e4-061e-41b1-be85-5078c802043f");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByInvCRMColumn() {
			EntitySchemaColumn column = base.CreateCreatedByInvCRMColumn();
			column.ModifiedInSchemaUId = new Guid("5d2e238c-305a-4610-927c-ede2a53ca517");
			column.CreatedInPackageId = new Guid("fe2bb0e4-061e-41b1-be85-5078c802043f");
			return column;
		}

		protected override EntitySchemaColumn CreateMessageTypeColumn() {
			EntitySchemaColumn column = base.CreateMessageTypeColumn();
			column.ModifiedInSchemaUId = new Guid("5d2e238c-305a-4610-927c-ede2a53ca517");
			column.CreatedInPackageId = new Guid("fe2bb0e4-061e-41b1-be85-5078c802043f");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("5d2e238c-305a-4610-927c-ede2a53ca517");
			column.CreatedInPackageId = new Guid("fe2bb0e4-061e-41b1-be85-5078c802043f");
			return column;
		}

		protected override EntitySchemaColumn CreateIsHtmlBodyColumn() {
			EntitySchemaColumn column = base.CreateIsHtmlBodyColumn();
			column.ModifiedInSchemaUId = new Guid("5d2e238c-305a-4610-927c-ede2a53ca517");
			column.CreatedInPackageId = new Guid("fe2bb0e4-061e-41b1-be85-5078c802043f");
			return column;
		}

		protected override EntitySchemaColumn CreateMailHashColumn() {
			EntitySchemaColumn column = base.CreateMailHashColumn();
			column.ModifiedInSchemaUId = new Guid("5d2e238c-305a-4610-927c-ede2a53ca517");
			column.CreatedInPackageId = new Guid("fe2bb0e4-061e-41b1-be85-5078c802043f");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessElementIdColumn() {
			EntitySchemaColumn column = base.CreateProcessElementIdColumn();
			column.ModifiedInSchemaUId = new Guid("5d2e238c-305a-4610-927c-ede2a53ca517");
			column.CreatedInPackageId = new Guid("fe2bb0e4-061e-41b1-be85-5078c802043f");
			return column;
		}

		protected override EntitySchemaColumn CreateOpportunityColumn() {
			EntitySchemaColumn column = base.CreateOpportunityColumn();
			column.IsTrackChangesInDB = true;
			column.ModifiedInSchemaUId = new Guid("5d2e238c-305a-4610-927c-ede2a53ca517");
			column.CreatedInPackageId = new Guid("fe2bb0e4-061e-41b1-be85-5078c802043f");
			return column;
		}

		protected override EntitySchemaColumn CreateLeadColumn() {
			EntitySchemaColumn column = base.CreateLeadColumn();
			column.ModifiedInSchemaUId = new Guid("5d2e238c-305a-4610-927c-ede2a53ca517");
			column.CreatedInPackageId = new Guid("fe2bb0e4-061e-41b1-be85-5078c802043f");
			return column;
		}

		protected virtual EntitySchemaColumn CreateProjectColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("e2d77c79-645a-450c-b4bd-0bbf55588489"),
				Name = @"Project",
				ReferenceSchemaUId = new Guid("a11d7fa4-9946-494c-ae41-2169844d29be"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("5d2e238c-305a-4610-927c-ede2a53ca517"),
				ModifiedInSchemaUId = new Guid("5d2e238c-305a-4610-927c-ede2a53ca517"),
				CreatedInPackageId = new Guid("fe2bb0e4-061e-41b1-be85-5078c802043f")
			};
		}

		protected virtual EntitySchemaColumn CreateFullProjectNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("a07b44ec-9d82-4c14-a5a6-a7bc4a1c9354"),
				Name = @"FullProjectName",
				CreatedInSchemaUId = new Guid("5d2e238c-305a-4610-927c-ede2a53ca517"),
				ModifiedInSchemaUId = new Guid("5d2e238c-305a-4610-927c-ede2a53ca517"),
				CreatedInPackageId = new Guid("61c8641f-c044-4b81-ab30-bcda839818c3")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateIX_Activity_SendDateIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new Activity_Project_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Activity_ProjectEventsProcess(userConnection);
		}

		public override object Clone() {
			return new Activity_Project_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new Activity_Project_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("5d2e238c-305a-4610-927c-ede2a53ca517"));
		}

		#endregion

	}

	#endregion

	#region Class: Activity_Project_BPMSoft

	/// <summary>
	/// Активность.
	/// </summary>
	public class Activity_Project_BPMSoft : BPMSoft.Configuration.Activity_Portal_BPMSoft
	{

		#region Constructors: Public

		public Activity_Project_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Activity_Project_BPMSoft";
		}

		public Activity_Project_BPMSoft(Activity_Project_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid ProjectId {
			get {
				return GetTypedColumnValue<Guid>("ProjectId");
			}
			set {
				SetColumnValue("ProjectId", value);
				_project = null;
			}
		}

		/// <exclude/>
		public string ProjectName {
			get {
				return GetTypedColumnValue<string>("ProjectName");
			}
			set {
				SetColumnValue("ProjectName", value);
				if (_project != null) {
					_project.Name = value;
				}
			}
		}

		private Project _project;
		/// <summary>
		/// Проект.
		/// </summary>
		public Project Project {
			get {
				return _project ??
					(_project = LookupColumnEntities.GetEntity("Project") as Project);
			}
		}

		/// <summary>
		/// Проект.
		/// </summary>
		public string FullProjectName {
			get {
				return GetTypedColumnValue<string>("FullProjectName");
			}
			set {
				SetColumnValue("FullProjectName", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Activity_ProjectEventsProcess(UserConnection);
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
			return new Activity_Project_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: Activity_ProjectEventsProcess

	/// <exclude/>
	public partial class Activity_ProjectEventsProcess<TEntity> : BPMSoft.Configuration.Activity_PortalEventsProcess<TEntity> where TEntity : Activity_Project_BPMSoft
	{

		public Activity_ProjectEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Activity_ProjectEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("5d2e238c-305a-4610-927c-ede2a53ca517");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		private ProcessFlowElement _eventSubProcess4Project;
		public ProcessFlowElement EventSubProcess4Project {
			get {
				return _eventSubProcess4Project ?? (_eventSubProcess4Project = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventSubProcess4Project",
					SchemaElementUId = new Guid("82cdad80-8535-4329-a833-0697751e3687"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _activitySaved;
		public ProcessFlowElement ActivitySaved {
			get {
				return _activitySaved ?? (_activitySaved = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "ActivitySaved",
					SchemaElementUId = new Guid("c02c283a-75c5-4338-95f2-3aad5f4db826"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _syncronizeProjectActualStartDate;
		public ProcessScriptTask SyncronizeProjectActualStartDate {
			get {
				return _syncronizeProjectActualStartDate ?? (_syncronizeProjectActualStartDate = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "SyncronizeProjectActualStartDate",
					SchemaElementUId = new Guid("a140d34e-d55f-4487-a475-cbc23937c1f8"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = SyncronizeProjectActualStartDateExecute,
				});
			}
		}

		private ProcessFlowElement _activityDeleted;
		public ProcessFlowElement ActivityDeleted {
			get {
				return _activityDeleted ?? (_activityDeleted = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "ActivityDeleted",
					SchemaElementUId = new Guid("fc2b261a-02a4-435a-8513-a2582a1123d4"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[EventSubProcess4Project.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess4Project };
			FlowElements[ActivitySaved.SchemaElementUId] = new Collection<ProcessFlowElement> { ActivitySaved };
			FlowElements[SyncronizeProjectActualStartDate.SchemaElementUId] = new Collection<ProcessFlowElement> { SyncronizeProjectActualStartDate };
			FlowElements[ActivityDeleted.SchemaElementUId] = new Collection<ProcessFlowElement> { ActivityDeleted };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "EventSubProcess4Project":
						break;
					case "ActivitySaved":
						e.Context.QueueTasks.Enqueue("SyncronizeProjectActualStartDate");
						break;
					case "SyncronizeProjectActualStartDate":
						break;
					case "ActivityDeleted":
						e.Context.QueueTasks.Enqueue("SyncronizeProjectActualStartDate");
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("ActivitySaved");
			ActivatedEventElements.Add("ActivityDeleted");
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			switch (context.QueueTasks.Peek()) {
				case "EventSubProcess4Project":
					context.QueueTasks.Dequeue();
					break;
				case "ActivitySaved":
					context.QueueTasks.Dequeue();
					context.SenderName = "ActivitySaved";
					result = ActivitySaved.Execute(context);
					break;
				case "SyncronizeProjectActualStartDate":
					context.QueueTasks.Dequeue();
					context.SenderName = "SyncronizeProjectActualStartDate";
					result = SyncronizeProjectActualStartDate.Execute(context, SyncronizeProjectActualStartDateExecute);
					break;
				case "ActivityDeleted":
					context.QueueTasks.Dequeue();
					context.SenderName = "ActivityDeleted";
					result = ActivityDeleted.Execute(context);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool SyncronizeProjectActualStartDateExecute(ProcessExecutingContext context) {
			var projectId = Entity.GetTypedColumnValue<Guid>("ProjectId");
			if (projectId.Equals(Guid.Empty)) {
				return true;
			}
			/*var projectService = new ProjectService.ProjectService();
			projectService.SyncronizeProjectActualStartDate(projectId);
			projectService.SyncronizeProjectActualEndDate(projectId);*/
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "ActivitySaved":
							if (ActivatedEventElements.Contains("ActivitySaved")) {
							context.QueueTasks.Enqueue("ActivitySaved");
							ProcessQueue(context);
							return;
						}
						break;
					case "ActivityDeleted":
							if (ActivatedEventElements.Contains("ActivityDeleted")) {
							context.QueueTasks.Enqueue("ActivityDeleted");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: Activity_ProjectEventsProcess

	/// <exclude/>
	public class Activity_ProjectEventsProcess : Activity_ProjectEventsProcess<Activity_Project_BPMSoft>
	{

		public Activity_ProjectEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: Activity_ProjectEventsProcess

	public partial class Activity_ProjectEventsProcess<TEntity>
	{

		#region Methods: Public

		public override bool DoCollectEmailParticipants() {
			return Entity.GetTypedColumnValue<Guid>("TypeId") == BPMSoft.Configuration.ActivityConsts.EmailTypeUId
			|| Entity.GetTypedColumnValue<Guid>("ActivityCategoryId") == ExchangeConsts.ActivityMeetingCategoryId;
		}

		public override bool OnActivitySaved(ProcessExecutingContext context) {
			SynchronizeParticipants();
			return base.OnActivitySaved(context);
		}

		#endregion

	}

	#endregion

}

