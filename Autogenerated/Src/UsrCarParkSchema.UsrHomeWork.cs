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

	#region Class: UsrCarParkSchema

	/// <exclude/>
	public class UsrCarParkSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public UsrCarParkSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public UsrCarParkSchema(UsrCarParkSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public UsrCarParkSchema(UsrCarParkSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("026fea1d-5414-47eb-9982-b5f2fe275e16");
			RealUId = new Guid("026fea1d-5414-47eb-9982-b5f2fe275e16");
			Name = "UsrCarPark";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("3c4d067d-156b-4f1a-95fd-baa9da73b631");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateUsrCarBrandColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("ef706645-b06c-4b10-9707-47d1387ec83d")) == null) {
				Columns.Add(CreateUsrCarNumberColumn());
			}
			if (Columns.FindByUId(new Guid("10322267-38b4-b358-7a2f-a5a498fe3555")) == null) {
				Columns.Add(CreateUsrCompanyColumn());
			}
			if (Columns.FindByUId(new Guid("5d8dfb97-edf4-f14b-00ed-d4ee70d421d9")) == null) {
				Columns.Add(CreateUsrIsActualColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateUsrCarNumberColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("ef706645-b06c-4b10-9707-47d1387ec83d"),
				Name = @"UsrCarNumber",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("026fea1d-5414-47eb-9982-b5f2fe275e16"),
				ModifiedInSchemaUId = new Guid("026fea1d-5414-47eb-9982-b5f2fe275e16"),
				CreatedInPackageId = new Guid("3c4d067d-156b-4f1a-95fd-baa9da73b631")
			};
		}

		protected virtual EntitySchemaColumn CreateUsrCarBrandColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("64910084-a9be-6a2e-ec50-6fbdef7eae82"),
				Name = @"UsrCarBrand",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("026fea1d-5414-47eb-9982-b5f2fe275e16"),
				ModifiedInSchemaUId = new Guid("026fea1d-5414-47eb-9982-b5f2fe275e16"),
				CreatedInPackageId = new Guid("3c4d067d-156b-4f1a-95fd-baa9da73b631")
			};
		}

		protected virtual EntitySchemaColumn CreateUsrCompanyColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("10322267-38b4-b358-7a2f-a5a498fe3555"),
				Name = @"UsrCompany",
				ReferenceSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("026fea1d-5414-47eb-9982-b5f2fe275e16"),
				ModifiedInSchemaUId = new Guid("026fea1d-5414-47eb-9982-b5f2fe275e16"),
				CreatedInPackageId = new Guid("3c4d067d-156b-4f1a-95fd-baa9da73b631")
			};
		}

		protected virtual EntitySchemaColumn CreateUsrIsActualColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("5d8dfb97-edf4-f14b-00ed-d4ee70d421d9"),
				Name = @"UsrIsActual",
				CreatedInSchemaUId = new Guid("026fea1d-5414-47eb-9982-b5f2fe275e16"),
				ModifiedInSchemaUId = new Guid("026fea1d-5414-47eb-9982-b5f2fe275e16"),
				CreatedInPackageId = new Guid("3c4d067d-156b-4f1a-95fd-baa9da73b631")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new UsrCarPark(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new UsrCarPark_UsrHomeWorkEventsProcess(userConnection);
		}

		public override object Clone() {
			return new UsrCarParkSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new UsrCarParkSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("026fea1d-5414-47eb-9982-b5f2fe275e16"));
		}

		#endregion

	}

	#endregion

	#region Class: UsrCarPark

	/// <summary>
	/// Автопарк.
	/// </summary>
	public class UsrCarPark : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public UsrCarPark(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "UsrCarPark";
		}

		public UsrCarPark(UsrCarPark source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Номер машины.
		/// </summary>
		public string UsrCarNumber {
			get {
				return GetTypedColumnValue<string>("UsrCarNumber");
			}
			set {
				SetColumnValue("UsrCarNumber", value);
			}
		}

		/// <summary>
		/// Марка.
		/// </summary>
		public string UsrCarBrand {
			get {
				return GetTypedColumnValue<string>("UsrCarBrand");
			}
			set {
				SetColumnValue("UsrCarBrand", value);
			}
		}

		/// <exclude/>
		public Guid UsrCompanyId {
			get {
				return GetTypedColumnValue<Guid>("UsrCompanyId");
			}
			set {
				SetColumnValue("UsrCompanyId", value);
				_usrCompany = null;
			}
		}

		/// <exclude/>
		public string UsrCompanyName {
			get {
				return GetTypedColumnValue<string>("UsrCompanyName");
			}
			set {
				SetColumnValue("UsrCompanyName", value);
				if (_usrCompany != null) {
					_usrCompany.Name = value;
				}
			}
		}

		private Account _usrCompany;
		/// <summary>
		/// Компания.
		/// </summary>
		public Account UsrCompany {
			get {
				return _usrCompany ??
					(_usrCompany = LookupColumnEntities.GetEntity("UsrCompany") as Account);
			}
		}

		/// <summary>
		/// Актуальный.
		/// </summary>
		public bool UsrIsActual {
			get {
				return GetTypedColumnValue<bool>("UsrIsActual");
			}
			set {
				SetColumnValue("UsrIsActual", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new UsrCarPark_UsrHomeWorkEventsProcess(UserConnection);
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
			return new UsrCarPark(this);
		}

		#endregion

	}

	#endregion

	#region Class: UsrCarPark_UsrHomeWorkEventsProcess

	/// <exclude/>
	public partial class UsrCarPark_UsrHomeWorkEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : UsrCarPark
	{

		public UsrCarPark_UsrHomeWorkEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "UsrCarPark_UsrHomeWorkEventsProcess";
			SchemaUId = new Guid("026fea1d-5414-47eb-9982-b5f2fe275e16");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("026fea1d-5414-47eb-9982-b5f2fe275e16");
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

	#region Class: UsrCarPark_UsrHomeWorkEventsProcess

	/// <exclude/>
	public class UsrCarPark_UsrHomeWorkEventsProcess : UsrCarPark_UsrHomeWorkEventsProcess<UsrCarPark>
	{

		public UsrCarPark_UsrHomeWorkEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: UsrCarPark_UsrHomeWorkEventsProcess

	public partial class UsrCarPark_UsrHomeWorkEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: UsrCarParkEventsProcess

	/// <exclude/>
	public class UsrCarParkEventsProcess : UsrCarPark_UsrHomeWorkEventsProcess
	{

		public UsrCarParkEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

