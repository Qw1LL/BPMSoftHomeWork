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

	#region Class: SysActiveCallSchema

	/// <exclude/>
	public class SysActiveCallSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysActiveCallSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysActiveCallSchema(SysActiveCallSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysActiveCallSchema(SysActiveCallSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("c159d7d4-8f45-4116-bb83-25f24f4fbb2a");
			RealUId = new Guid("c159d7d4-8f45-4116-bb83-25f24f4fbb2a");
			Name = "SysActiveCall";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("a423b8c9-c10c-4e3e-825a-00ccf98bcc31")) == null) {
				Columns.Add(CreateIntegrationIdColumn());
			}
			if (Columns.FindByUId(new Guid("2426cbfb-68c3-496f-9c10-763f4249a259")) == null) {
				Columns.Add(CreateCallColumn());
			}
			if (Columns.FindByUId(new Guid("885f2572-4898-48f3-80c8-6e192bc2fc19")) == null) {
				Columns.Add(CreateParentCallColumn());
			}
			if (Columns.FindByUId(new Guid("497b7659-e70d-43fc-871d-300057fdbd17")) == null) {
				Columns.Add(CreateCallerIdColumn());
			}
			if (Columns.FindByUId(new Guid("63f19db3-e06e-4d91-9e83-0e7f6c09ba2e")) == null) {
				Columns.Add(CreateCalledIdColumn());
			}
			if (Columns.FindByUId(new Guid("b05760c8-8467-47d6-a265-43995be8fa11")) == null) {
				Columns.Add(CreateRedirectingIdColumn());
			}
			if (Columns.FindByUId(new Guid("c5256457-b82d-467c-a9ab-0369a236c72b")) == null) {
				Columns.Add(CreateRedirectionIdColumn());
			}
			if (Columns.FindByUId(new Guid("4977b159-fd09-497d-9513-12670ad5820c")) == null) {
				Columns.Add(CreateStartDateColumn());
			}
			if (Columns.FindByUId(new Guid("3d8b7a37-0e83-4c48-aabf-7a46b679251f")) == null) {
				Columns.Add(CreateEndDateColumn());
			}
			if (Columns.FindByUId(new Guid("640f3ac3-f11d-4841-8b28-46410c40fff0")) == null) {
				Columns.Add(CreateCurrentHoldStartTimeColumn());
			}
			if (Columns.FindByUId(new Guid("9b7a9f11-4a3a-4286-a1bd-5e0fa3954800")) == null) {
				Columns.Add(CreateCurrentTalkStartTimeColumn());
			}
			if (Columns.FindByUId(new Guid("5ab982e0-1acc-4a4b-8082-adc2f3121994")) == null) {
				Columns.Add(CreateConnectionStartTimeColumn());
			}
			if (Columns.FindByUId(new Guid("9e076a05-1c8c-4ed1-803a-b08521fe10e1")) == null) {
				Columns.Add(CreateDurationColumn());
			}
			if (Columns.FindByUId(new Guid("419ae3a0-cd3e-4295-afd5-a45a4c2c2667")) == null) {
				Columns.Add(CreateBeforeConnectionTimeColumn());
			}
			if (Columns.FindByUId(new Guid("34a835ab-97f4-42f9-8679-e232478df68f")) == null) {
				Columns.Add(CreateTalkTimeColumn());
			}
			if (Columns.FindByUId(new Guid("21a54ee9-9c4e-45fb-b04b-357a187df9ac")) == null) {
				Columns.Add(CreateHoldTimeColumn());
			}
			if (Columns.FindByUId(new Guid("82791c92-19ce-4e92-9f02-1a4c746c05fb")) == null) {
				Columns.Add(CreateStateColumn());
			}
			if (Columns.FindByUId(new Guid("48d4c410-1517-4fa9-8aee-0095e9f529a3")) == null) {
				Columns.Add(CreateCallContextColumn());
			}
			if (Columns.FindByUId(new Guid("b7afaf05-3349-4ff0-b816-929b28262dd8")) == null) {
				Columns.Add(CreateCallContextTypeColumn());
			}
			if (Columns.FindByUId(new Guid("159acd33-055d-404d-992b-9cdfba6ac86d")) == null) {
				Columns.Add(CreateDirectionColumn());
			}
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("c159d7d4-8f45-4116-bb83-25f24f4fbb2a");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("c159d7d4-8f45-4116-bb83-25f24f4fbb2a");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("c159d7d4-8f45-4116-bb83-25f24f4fbb2a");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("c159d7d4-8f45-4116-bb83-25f24f4fbb2a");
			return column;
		}

		protected virtual EntitySchemaColumn CreateIntegrationIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("a423b8c9-c10c-4e3e-825a-00ccf98bcc31"),
				Name = @"IntegrationId",
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("c159d7d4-8f45-4116-bb83-25f24f4fbb2a"),
				ModifiedInSchemaUId = new Guid("c159d7d4-8f45-4116-bb83-25f24f4fbb2a"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateCallColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("2426cbfb-68c3-496f-9c10-763f4249a259"),
				Name = @"Call",
				ReferenceSchemaUId = new Guid("2f81fa05-11ae-400d-8e07-5ef6a620d1ad"),
				IsValueCloneable = false,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("c159d7d4-8f45-4116-bb83-25f24f4fbb2a"),
				ModifiedInSchemaUId = new Guid("c159d7d4-8f45-4116-bb83-25f24f4fbb2a"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateParentCallColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("885f2572-4898-48f3-80c8-6e192bc2fc19"),
				Name = @"ParentCall",
				ReferenceSchemaUId = new Guid("2f81fa05-11ae-400d-8e07-5ef6a620d1ad"),
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("c159d7d4-8f45-4116-bb83-25f24f4fbb2a"),
				ModifiedInSchemaUId = new Guid("c159d7d4-8f45-4116-bb83-25f24f4fbb2a"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateCallerIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("497b7659-e70d-43fc-871d-300057fdbd17"),
				Name = @"CallerId",
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("c159d7d4-8f45-4116-bb83-25f24f4fbb2a"),
				ModifiedInSchemaUId = new Guid("c159d7d4-8f45-4116-bb83-25f24f4fbb2a"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateCalledIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("63f19db3-e06e-4d91-9e83-0e7f6c09ba2e"),
				Name = @"CalledId",
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("c159d7d4-8f45-4116-bb83-25f24f4fbb2a"),
				ModifiedInSchemaUId = new Guid("c159d7d4-8f45-4116-bb83-25f24f4fbb2a"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateRedirectingIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("b05760c8-8467-47d6-a265-43995be8fa11"),
				Name = @"RedirectingId",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("c159d7d4-8f45-4116-bb83-25f24f4fbb2a"),
				ModifiedInSchemaUId = new Guid("c159d7d4-8f45-4116-bb83-25f24f4fbb2a"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateRedirectionIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("c5256457-b82d-467c-a9ab-0369a236c72b"),
				Name = @"RedirectionId",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("c159d7d4-8f45-4116-bb83-25f24f4fbb2a"),
				ModifiedInSchemaUId = new Guid("c159d7d4-8f45-4116-bb83-25f24f4fbb2a"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateStartDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("4977b159-fd09-497d-9513-12670ad5820c"),
				Name = @"StartDate",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("c159d7d4-8f45-4116-bb83-25f24f4fbb2a"),
				ModifiedInSchemaUId = new Guid("c159d7d4-8f45-4116-bb83-25f24f4fbb2a"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateEndDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("3d8b7a37-0e83-4c48-aabf-7a46b679251f"),
				Name = @"EndDate",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("c159d7d4-8f45-4116-bb83-25f24f4fbb2a"),
				ModifiedInSchemaUId = new Guid("c159d7d4-8f45-4116-bb83-25f24f4fbb2a"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateCurrentHoldStartTimeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("640f3ac3-f11d-4841-8b28-46410c40fff0"),
				Name = @"CurrentHoldStartTime",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("c159d7d4-8f45-4116-bb83-25f24f4fbb2a"),
				ModifiedInSchemaUId = new Guid("c159d7d4-8f45-4116-bb83-25f24f4fbb2a"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateCurrentTalkStartTimeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("9b7a9f11-4a3a-4286-a1bd-5e0fa3954800"),
				Name = @"CurrentTalkStartTime",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("c159d7d4-8f45-4116-bb83-25f24f4fbb2a"),
				ModifiedInSchemaUId = new Guid("c159d7d4-8f45-4116-bb83-25f24f4fbb2a"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateConnectionStartTimeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("5ab982e0-1acc-4a4b-8082-adc2f3121994"),
				Name = @"ConnectionStartTime",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("c159d7d4-8f45-4116-bb83-25f24f4fbb2a"),
				ModifiedInSchemaUId = new Guid("c159d7d4-8f45-4116-bb83-25f24f4fbb2a"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateDurationColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("9e076a05-1c8c-4ed1-803a-b08521fe10e1"),
				Name = @"Duration",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("c159d7d4-8f45-4116-bb83-25f24f4fbb2a"),
				ModifiedInSchemaUId = new Guid("c159d7d4-8f45-4116-bb83-25f24f4fbb2a"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateBeforeConnectionTimeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("419ae3a0-cd3e-4295-afd5-a45a4c2c2667"),
				Name = @"BeforeConnectionTime",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("c159d7d4-8f45-4116-bb83-25f24f4fbb2a"),
				ModifiedInSchemaUId = new Guid("c159d7d4-8f45-4116-bb83-25f24f4fbb2a"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateTalkTimeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("34a835ab-97f4-42f9-8679-e232478df68f"),
				Name = @"TalkTime",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("c159d7d4-8f45-4116-bb83-25f24f4fbb2a"),
				ModifiedInSchemaUId = new Guid("c159d7d4-8f45-4116-bb83-25f24f4fbb2a"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateHoldTimeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("21a54ee9-9c4e-45fb-b04b-357a187df9ac"),
				Name = @"HoldTime",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("c159d7d4-8f45-4116-bb83-25f24f4fbb2a"),
				ModifiedInSchemaUId = new Guid("c159d7d4-8f45-4116-bb83-25f24f4fbb2a"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateStateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("82791c92-19ce-4e92-9f02-1a4c746c05fb"),
				Name = @"State",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("c159d7d4-8f45-4116-bb83-25f24f4fbb2a"),
				ModifiedInSchemaUId = new Guid("c159d7d4-8f45-4116-bb83-25f24f4fbb2a"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateCallContextColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("48d4c410-1517-4fa9-8aee-0095e9f529a3"),
				Name = @"CallContext",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("c159d7d4-8f45-4116-bb83-25f24f4fbb2a"),
				ModifiedInSchemaUId = new Guid("c159d7d4-8f45-4116-bb83-25f24f4fbb2a"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateCallContextTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("b7afaf05-3349-4ff0-b816-929b28262dd8"),
				Name = @"CallContextType",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("c159d7d4-8f45-4116-bb83-25f24f4fbb2a"),
				ModifiedInSchemaUId = new Guid("c159d7d4-8f45-4116-bb83-25f24f4fbb2a"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateDirectionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("159acd33-055d-404d-992b-9cdfba6ac86d"),
				Name = @"Direction",
				ReferenceSchemaUId = new Guid("c58a425d-5e45-49ed-bfbe-bd15a9340b7e"),
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("c159d7d4-8f45-4116-bb83-25f24f4fbb2a"),
				ModifiedInSchemaUId = new Guid("c159d7d4-8f45-4116-bb83-25f24f4fbb2a"),
				CreatedInPackageId = new Guid("d96ae870-4bfc-40ec-921c-ada84236f3fa")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysActiveCall(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysActiveCall_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysActiveCallSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysActiveCallSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("c159d7d4-8f45-4116-bb83-25f24f4fbb2a"));
		}

		#endregion

	}

	#endregion

	#region Class: SysActiveCall

	/// <summary>
	/// Active calls.
	/// </summary>
	public class SysActiveCall : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysActiveCall(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysActiveCall";
		}

		public SysActiveCall(SysActiveCall source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Call Id in ASC.
		/// </summary>
		public string IntegrationId {
			get {
				return GetTypedColumnValue<string>("IntegrationId");
			}
			set {
				SetColumnValue("IntegrationId", value);
			}
		}

		/// <exclude/>
		public Guid CallId {
			get {
				return GetTypedColumnValue<Guid>("CallId");
			}
			set {
				SetColumnValue("CallId", value);
				_call = null;
			}
		}

		/// <exclude/>
		public string CallCaption {
			get {
				return GetTypedColumnValue<string>("CallCaption");
			}
			set {
				SetColumnValue("CallCaption", value);
				if (_call != null) {
					_call.Caption = value;
				}
			}
		}

		private Call _call;
		/// <summary>
		/// Call Id in DB.
		/// </summary>
		public Call Call {
			get {
				return _call ??
					(_call = LookupColumnEntities.GetEntity("Call") as Call);
			}
		}

		/// <exclude/>
		public Guid ParentCallId {
			get {
				return GetTypedColumnValue<Guid>("ParentCallId");
			}
			set {
				SetColumnValue("ParentCallId", value);
				_parentCall = null;
			}
		}

		/// <exclude/>
		public string ParentCallCaption {
			get {
				return GetTypedColumnValue<string>("ParentCallCaption");
			}
			set {
				SetColumnValue("ParentCallCaption", value);
				if (_parentCall != null) {
					_parentCall.Caption = value;
				}
			}
		}

		private Call _parentCall;
		/// <summary>
		/// Outgoing call Id in DB.
		/// </summary>
		public Call ParentCall {
			get {
				return _parentCall ??
					(_parentCall = LookupColumnEntities.GetEntity("ParentCall") as Call);
			}
		}

		/// <summary>
		/// From.
		/// </summary>
		public string CallerId {
			get {
				return GetTypedColumnValue<string>("CallerId");
			}
			set {
				SetColumnValue("CallerId", value);
			}
		}

		/// <summary>
		/// To.
		/// </summary>
		public string CalledId {
			get {
				return GetTypedColumnValue<string>("CalledId");
			}
			set {
				SetColumnValue("CalledId", value);
			}
		}

		/// <summary>
		/// Transferring number.
		/// </summary>
		public string RedirectingId {
			get {
				return GetTypedColumnValue<string>("RedirectingId");
			}
			set {
				SetColumnValue("RedirectingId", value);
			}
		}

		/// <summary>
		/// Number being transferred.
		/// </summary>
		public string RedirectionId {
			get {
				return GetTypedColumnValue<string>("RedirectionId");
			}
			set {
				SetColumnValue("RedirectionId", value);
			}
		}

		/// <summary>
		/// Start date.
		/// </summary>
		public DateTime StartDate {
			get {
				return GetTypedColumnValue<DateTime>("StartDate");
			}
			set {
				SetColumnValue("StartDate", value);
			}
		}

		/// <summary>
		/// End date.
		/// </summary>
		public DateTime EndDate {
			get {
				return GetTypedColumnValue<DateTime>("EndDate");
			}
			set {
				SetColumnValue("EndDate", value);
			}
		}

		/// <summary>
		/// Current on hold placing moment.
		/// </summary>
		public DateTime CurrentHoldStartTime {
			get {
				return GetTypedColumnValue<DateTime>("CurrentHoldStartTime");
			}
			set {
				SetColumnValue("CurrentHoldStartTime", value);
			}
		}

		/// <summary>
		/// Current call start moment.
		/// </summary>
		public DateTime CurrentTalkStartTime {
			get {
				return GetTypedColumnValue<DateTime>("CurrentTalkStartTime");
			}
			set {
				SetColumnValue("CurrentTalkStartTime", value);
			}
		}

		/// <summary>
		/// Date of call.
		/// </summary>
		public DateTime ConnectionStartTime {
			get {
				return GetTypedColumnValue<DateTime>("ConnectionStartTime");
			}
			set {
				SetColumnValue("ConnectionStartTime", value);
			}
		}

		/// <summary>
		/// Duration.
		/// </summary>
		public int Duration {
			get {
				return GetTypedColumnValue<int>("Duration");
			}
			set {
				SetColumnValue("Duration", value);
			}
		}

		/// <summary>
		/// Time to connect.
		/// </summary>
		public int BeforeConnectionTime {
			get {
				return GetTypedColumnValue<int>("BeforeConnectionTime");
			}
			set {
				SetColumnValue("BeforeConnectionTime", value);
			}
		}

		/// <summary>
		/// Conversation time.
		/// </summary>
		public int TalkTime {
			get {
				return GetTypedColumnValue<int>("TalkTime");
			}
			set {
				SetColumnValue("TalkTime", value);
			}
		}

		/// <summary>
		/// On hold time.
		/// </summary>
		public int HoldTime {
			get {
				return GetTypedColumnValue<int>("HoldTime");
			}
			set {
				SetColumnValue("HoldTime", value);
			}
		}

		/// <summary>
		/// Status.
		/// </summary>
		public string State {
			get {
				return GetTypedColumnValue<string>("State");
			}
			set {
				SetColumnValue("State", value);
			}
		}

		/// <summary>
		/// Context of call.
		/// </summary>
		public string CallContext {
			get {
				return GetTypedColumnValue<string>("CallContext");
			}
			set {
				SetColumnValue("CallContext", value);
			}
		}

		/// <summary>
		/// Context type.
		/// </summary>
		public string CallContextType {
			get {
				return GetTypedColumnValue<string>("CallContextType");
			}
			set {
				SetColumnValue("CallContextType", value);
			}
		}

		/// <exclude/>
		public Guid DirectionId {
			get {
				return GetTypedColumnValue<Guid>("DirectionId");
			}
			set {
				SetColumnValue("DirectionId", value);
				_direction = null;
			}
		}

		/// <exclude/>
		public string DirectionName {
			get {
				return GetTypedColumnValue<string>("DirectionName");
			}
			set {
				SetColumnValue("DirectionName", value);
				if (_direction != null) {
					_direction.Name = value;
				}
			}
		}

		private CallDirection _direction;
		/// <summary>
		/// Direction.
		/// </summary>
		public CallDirection Direction {
			get {
				return _direction ??
					(_direction = LookupColumnEntities.GetEntity("Direction") as CallDirection);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysActiveCall_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysActiveCallDeleted", e);
			Deleting += (s, e) => ThrowEvent("SysActiveCallDeleting", e);
			Inserted += (s, e) => ThrowEvent("SysActiveCallInserted", e);
			Inserting += (s, e) => ThrowEvent("SysActiveCallInserting", e);
			Saved += (s, e) => ThrowEvent("SysActiveCallSaved", e);
			Saving += (s, e) => ThrowEvent("SysActiveCallSaving", e);
			Validating += (s, e) => ThrowEvent("SysActiveCallValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysActiveCall(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysActiveCall_BaseEventsProcess

	/// <exclude/>
	public partial class SysActiveCall_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : SysActiveCall
	{

		public SysActiveCall_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysActiveCall_BaseEventsProcess";
			SchemaUId = new Guid("c159d7d4-8f45-4116-bb83-25f24f4fbb2a");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("c159d7d4-8f45-4116-bb83-25f24f4fbb2a");
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

	#region Class: SysActiveCall_BaseEventsProcess

	/// <exclude/>
	public class SysActiveCall_BaseEventsProcess : SysActiveCall_BaseEventsProcess<SysActiveCall>
	{

		public SysActiveCall_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysActiveCall_BaseEventsProcess

	public partial class SysActiveCall_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysActiveCallEventsProcess

	/// <exclude/>
	public class SysActiveCallEventsProcess : SysActiveCall_BaseEventsProcess
	{

		public SysActiveCallEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

