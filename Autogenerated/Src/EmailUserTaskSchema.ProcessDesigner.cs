namespace BPMSoft.Core.Process.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Configuration;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Process;
	using BPMSoft.UI.WebControls.Controls;
	using BPMSoft.UI.WebControls.Utilities;
	using BPMSoft.UI.WebControls.Utilities.Json.Converters;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Data;
	using System.Globalization;
	using System.Runtime.Serialization.Formatters;
	using System.Text;

	#region Class: EmailUserTaskSchemaExtension

	/// <exclude/>
	public class EmailUserTaskSchemaExtension : ProcessUserTaskSchemaExtension
	{

		#region Methods: Public

		public override Dictionary<Guid, string> GetResultParameterAllValues(UserConnection userConnection, ProcessSchemaUserTask schemaUserTask) {
			var results = new Dictionary<Guid, string>();
			Select select = 
				new Select(userConnection).Distinct()
					.Column("ActivityResult", "Id")
					.Column("ActivityResult", "Name")
					.From("ActivityResult")
					.Join(JoinType.Inner, "ActivityCategoryResultEntry")
						.On("ActivityResult", "Id").IsEqual("ActivityCategoryResultEntry", "ActivityResultId")
					.Join(JoinType.Inner, "ActivityCategory")
						.On("ActivityCategoryResultEntry", "ActivityCategoryId").IsEqual("ActivityCategory", "Id")
					.Join(JoinType.Inner, "ActivityType")
						.On("ActivityCategory", "ActivityTypeId").IsEqual("ActivityType", "Id")
						.Where("ActivityType", "Code").IsEqual(Column.Parameter("Email"))
					as Select;
			using (var dbExecutor = userConnection.EnsureDBConnection()) {
				using (IDataReader dr = select.ExecuteReader(dbExecutor)) {
					while (dr.Read()) {
						results.Add(userConnection.DBTypeConverter.DBValueToGuid(dr[0]), dr.GetString(1));
					}
				}
			}
			return results;
		}

		public override void SynchronizeDynamicParameters(UserConnection userConnection, ProcessUserTaskSchema target) {
			base.SynchronizeDynamicParameters(userConnection, target);
			ProcessUserTaskUtilities.SynchronizeActivityConnectionParameters(userConnection, target);
		}

		#endregion

	}

	#endregion

	#region Class: EmailUserTask

	[DesignModeGroup(Name = "General", Position = 1, UseSolutionStorage = true, ResourceManager = "97bb4a37a49d47b9b9e6b01ae7b5b9d0", CaptionResourceItem = "Parameters.Recommendation.Group", DescriptionResourceItem = "Parameters.Recommendation.Group")]
	[DesignModeGroup(Name = "Connected to", Position = 2, UseSolutionStorage = true, ResourceManager = "97bb4a37a49d47b9b9e6b01ae7b5b9d0", CaptionResourceItem = "Parameters.Lead.Group", DescriptionResourceItem = "Parameters.Lead.Group")]
	[DesignModeProperty(Name = "Recommendation", Group = "General", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "97bb4a37a49d47b9b9e6b01ae7b5b9d0", CaptionResourceItem = "Parameters.Recommendation.Caption", DescriptionResourceItem = "Parameters.Recommendation.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ActivityCategory", Group = "General", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "97bb4a37a49d47b9b9e6b01ae7b5b9d0", CaptionResourceItem = "Parameters.ActivityCategory.Caption", DescriptionResourceItem = "Parameters.ActivityCategory.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "OwnerId", Group = "General", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "97bb4a37a49d47b9b9e6b01ae7b5b9d0", CaptionResourceItem = "Parameters.OwnerId.Caption", DescriptionResourceItem = "Parameters.OwnerId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Duration", Group = "General", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "97bb4a37a49d47b9b9e6b01ae7b5b9d0", CaptionResourceItem = "Parameters.Duration.Caption", DescriptionResourceItem = "Parameters.Duration.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "DurationPeriod", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "97bb4a37a49d47b9b9e6b01ae7b5b9d0", CaptionResourceItem = "Parameters.DurationPeriod.Caption", DescriptionResourceItem = "Parameters.DurationPeriod.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "StartIn", Group = "General", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "97bb4a37a49d47b9b9e6b01ae7b5b9d0", CaptionResourceItem = "Parameters.StartIn.Caption", DescriptionResourceItem = "Parameters.StartIn.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "StartInPeriod", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "97bb4a37a49d47b9b9e6b01ae7b5b9d0", CaptionResourceItem = "Parameters.StartInPeriod.Caption", DescriptionResourceItem = "Parameters.StartInPeriod.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "RemindBefore", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "97bb4a37a49d47b9b9e6b01ae7b5b9d0", CaptionResourceItem = "Parameters.RemindBefore.Caption", DescriptionResourceItem = "Parameters.RemindBefore.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "RemindBeforePeriod", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "97bb4a37a49d47b9b9e6b01ae7b5b9d0", CaptionResourceItem = "Parameters.RemindBeforePeriod.Caption", DescriptionResourceItem = "Parameters.RemindBeforePeriod.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ShowInScheduler", Group = "General", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "97bb4a37a49d47b9b9e6b01ae7b5b9d0", CaptionResourceItem = "Parameters.ShowInScheduler.Caption", DescriptionResourceItem = "Parameters.ShowInScheduler.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ShowExecutionPage", Group = "General", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "97bb4a37a49d47b9b9e6b01ae7b5b9d0", CaptionResourceItem = "Parameters.ShowExecutionPage.Caption", DescriptionResourceItem = "Parameters.ShowExecutionPage.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Lead", Group = "Connected to", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "97bb4a37a49d47b9b9e6b01ae7b5b9d0", CaptionResourceItem = "Parameters.Lead.Caption", DescriptionResourceItem = "Parameters.Lead.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Account", Group = "Connected to", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "97bb4a37a49d47b9b9e6b01ae7b5b9d0", CaptionResourceItem = "Parameters.Account.Caption", DescriptionResourceItem = "Parameters.Account.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Contact", Group = "Connected to", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "97bb4a37a49d47b9b9e6b01ae7b5b9d0", CaptionResourceItem = "Parameters.Contact.Caption", DescriptionResourceItem = "Parameters.Contact.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Opportunity", Group = "Connected to", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "97bb4a37a49d47b9b9e6b01ae7b5b9d0", CaptionResourceItem = "Parameters.Opportunity.Caption", DescriptionResourceItem = "Parameters.Opportunity.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Invoice", Group = "Connected to", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "97bb4a37a49d47b9b9e6b01ae7b5b9d0", CaptionResourceItem = "Parameters.Invoice.Caption", DescriptionResourceItem = "Parameters.Invoice.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Document", Group = "Connected to", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "97bb4a37a49d47b9b9e6b01ae7b5b9d0", CaptionResourceItem = "Parameters.Document.Caption", DescriptionResourceItem = "Parameters.Document.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ActivityResult", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "97bb4a37a49d47b9b9e6b01ae7b5b9d0", CaptionResourceItem = "Parameters.ActivityResult.Caption", DescriptionResourceItem = "Parameters.ActivityResult.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Incident", Group = "Connected to", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "97bb4a37a49d47b9b9e6b01ae7b5b9d0", CaptionResourceItem = "Parameters.Incident.Caption", DescriptionResourceItem = "Parameters.Incident.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Case", Group = "Connected to", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "97bb4a37a49d47b9b9e6b01ae7b5b9d0", CaptionResourceItem = "Parameters.Case.Caption", DescriptionResourceItem = "Parameters.Case.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "CurrentActivityId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "97bb4a37a49d47b9b9e6b01ae7b5b9d0", CaptionResourceItem = "Parameters.CurrentActivityId.Caption", DescriptionResourceItem = "Parameters.CurrentActivityId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "IsActivityCompleted", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "97bb4a37a49d47b9b9e6b01ae7b5b9d0", CaptionResourceItem = "Parameters.IsActivityCompleted.Caption", DescriptionResourceItem = "Parameters.IsActivityCompleted.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ExecutionContext", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "97bb4a37a49d47b9b9e6b01ae7b5b9d0", CaptionResourceItem = "Parameters.ExecutionContext.Caption", DescriptionResourceItem = "Parameters.ExecutionContext.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Recepient", Group = "General", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "97bb4a37a49d47b9b9e6b01ae7b5b9d0", CaptionResourceItem = "Parameters.Recepient.Caption", DescriptionResourceItem = "Parameters.Recepient.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "CopyRecepient", Group = "General", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "97bb4a37a49d47b9b9e6b01ae7b5b9d0", CaptionResourceItem = "Parameters.CopyRecepient.Caption", DescriptionResourceItem = "Parameters.CopyRecepient.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "BlindCopyRecepient", Group = "General", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "97bb4a37a49d47b9b9e6b01ae7b5b9d0", CaptionResourceItem = "Parameters.BlindCopyRecepient.Caption", DescriptionResourceItem = "Parameters.BlindCopyRecepient.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Body", Group = "General", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "97bb4a37a49d47b9b9e6b01ae7b5b9d0", CaptionResourceItem = "Parameters.Body.Caption", DescriptionResourceItem = "Parameters.Body.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "InformationOnStep", Group = "General", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "97bb4a37a49d47b9b9e6b01ae7b5b9d0", CaptionResourceItem = "Parameters.InformationOnStep.Caption", DescriptionResourceItem = "Parameters.InformationOnStep.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Order", Group = "Connected to", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "97bb4a37a49d47b9b9e6b01ae7b5b9d0", CaptionResourceItem = "Parameters.Order.Caption", DescriptionResourceItem = "Parameters.Order.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Contract", Group = "Connected to", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "97bb4a37a49d47b9b9e6b01ae7b5b9d0", CaptionResourceItem = "Parameters.Contract.Caption", DescriptionResourceItem = "Parameters.Contract.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Property", Group = "Connected to", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "97bb4a37a49d47b9b9e6b01ae7b5b9d0", CaptionResourceItem = "Parameters.Property.Caption", DescriptionResourceItem = "Parameters.Property.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Listing", Group = "Connected to", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "97bb4a37a49d47b9b9e6b01ae7b5b9d0", CaptionResourceItem = "Parameters.Listing.Caption", DescriptionResourceItem = "Parameters.Listing.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Requests", Group = "Connected to", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "97bb4a37a49d47b9b9e6b01ae7b5b9d0", CaptionResourceItem = "Parameters.Requests.Caption", DescriptionResourceItem = "Parameters.Requests.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Project", Group = "Connected to", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "97bb4a37a49d47b9b9e6b01ae7b5b9d0", CaptionResourceItem = "Parameters.Project.Caption", DescriptionResourceItem = "Parameters.Project.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Problem", Group = "Connected to", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "97bb4a37a49d47b9b9e6b01ae7b5b9d0", CaptionResourceItem = "Parameters.Problem.Caption", DescriptionResourceItem = "Parameters.Problem.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Change", Group = "Connected to", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "97bb4a37a49d47b9b9e6b01ae7b5b9d0", CaptionResourceItem = "Parameters.Change.Caption", DescriptionResourceItem = "Parameters.Change.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Release", Group = "Connected to", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "97bb4a37a49d47b9b9e6b01ae7b5b9d0", CaptionResourceItem = "Parameters.Release.Caption", DescriptionResourceItem = "Parameters.Release.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "QueueItem", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "97bb4a37a49d47b9b9e6b01ae7b5b9d0", CaptionResourceItem = "Parameters.QueueItem.Caption", DescriptionResourceItem = "Parameters.QueueItem.Caption", UseSolutionStorage = true)]
	/// <exclude/>
	public class EmailUserTask : ProcessUserTask
	{

		#region Constructors: Public

		public EmailUserTask(UserConnection userConnection)
			: base(userConnection) {
			SchemaUId = new Guid("97bb4a37-a49d-47b9-b9e6-b01ae7b5b9d0");
			_activityCategory = () => { return new Guid("8038a396-7825-e011-8165-00155d043204"); };
		}

		#endregion

		#region Properties: Public

		private LocalizableString _recommendation;
		public virtual LocalizableString Recommendation {
			get {
				return _recommendation ?? (_recommendation = new LocalizableString());
			}
			set {
				_recommendation = value;
			}
		}

		private Func<Guid> _activityCategory;
		public virtual Guid ActivityCategory {
			get {
				return (_activityCategory ?? (_activityCategory = () => Guid.Empty)).Invoke();
			}
			set {
				_activityCategory = () => { return value; };
			}
		}

		public virtual Guid OwnerId {
			get;
			set;
		}

		private int _duration = 5;
		public virtual int Duration {
			get {
				return _duration;
			}
			set {
				_duration = value;
			}
		}

		private int _durationPeriod = 0;
		public virtual int DurationPeriod {
			get {
				return _durationPeriod;
			}
			set {
				_durationPeriod = value;
			}
		}

		private int _startIn = 0;
		public virtual int StartIn {
			get {
				return _startIn;
			}
			set {
				_startIn = value;
			}
		}

		private int _startInPeriod = 0;
		public virtual int StartInPeriod {
			get {
				return _startInPeriod;
			}
			set {
				_startInPeriod = value;
			}
		}

		private int _remindBefore = 0;
		public virtual int RemindBefore {
			get {
				return _remindBefore;
			}
			set {
				_remindBefore = value;
			}
		}

		private int _remindBeforePeriod = 0;
		public virtual int RemindBeforePeriod {
			get {
				return _remindBeforePeriod;
			}
			set {
				_remindBeforePeriod = value;
			}
		}

		private bool _showInScheduler = false;
		public virtual bool ShowInScheduler {
			get {
				return _showInScheduler;
			}
			set {
				_showInScheduler = value;
			}
		}

		private bool _showExecutionPage = true;
		public virtual bool ShowExecutionPage {
			get {
				return _showExecutionPage;
			}
			set {
				_showExecutionPage = value;
			}
		}

		public virtual Guid Lead {
			get;
			set;
		}

		public virtual Guid Account {
			get;
			set;
		}

		public virtual Guid Contact {
			get;
			set;
		}

		public virtual Guid Opportunity {
			get;
			set;
		}

		public virtual Guid Invoice {
			get;
			set;
		}

		public virtual Guid Document {
			get;
			set;
		}

		public virtual Guid ActivityResult {
			get;
			set;
		}

		public virtual Guid Incident {
			get;
			set;
		}

		public virtual Guid Case {
			get;
			set;
		}

		public virtual Guid CurrentActivityId {
			get;
			set;
		}

		public virtual bool IsActivityCompleted {
			get;
			set;
		}

		public virtual string ExecutionContext {
			get;
			set;
		}

		public virtual string Recepient {
			get;
			set;
		}

		public virtual string CopyRecepient {
			get;
			set;
		}

		public virtual string BlindCopyRecepient {
			get;
			set;
		}

		private LocalizableString _body;
		public virtual LocalizableString Body {
			get {
				return _body ?? (_body = new LocalizableString());
			}
			set {
				_body = value;
			}
		}

		private LocalizableString _informationOnStep;
		public virtual LocalizableString InformationOnStep {
			get {
				return _informationOnStep ?? (_informationOnStep = new LocalizableString());
			}
			set {
				_informationOnStep = value;
			}
		}

		public virtual Guid Order {
			get;
			set;
		}

		public virtual Guid Contract {
			get;
			set;
		}

		public virtual Guid Property {
			get;
			set;
		}

		public virtual Guid Listing {
			get;
			set;
		}

		public virtual Guid Requests {
			get;
			set;
		}

		public virtual Guid Project {
			get;
			set;
		}

		public virtual Guid Problem {
			get;
			set;
		}

		public virtual Guid Change {
			get;
			set;
		}

		public virtual Guid Release {
			get;
			set;
		}

		public virtual Guid QueueItem {
			get;
			set;
		}

		#endregion

		#region Methods: Protected

		protected override bool InternalExecute(ProcessExecutingContext context) {
			if (Status == ProcessStatus.Error) {
				if (CurrentActivityId == Guid.Empty && !ProcessUserTaskUtilities.GetIsActivityCreated(UserConnection, UId)) {
					BPMSoft.Configuration.Activity activity = CreateActivity();
					AfterActivitySaveScriptExecute(activity);
				}
			}
			bool isRunning = CurrentActivityId.IsNotEmpty() && !IsActivityCompleted;
			if (!isRunning) {
				BPMSoft.Configuration.Activity activity = CreateActivity();
				AfterActivitySaveScriptExecute(activity);
			}
			InteractWithUser(context, isRunning, ShowExecutionPage);
			return false;
		}

		#endregion

		#region Methods: Public

		public virtual Guid GetActivityType() {
			Select select = 
				new Select(UserConnection).
					Column("Id").
						From("ActivityType").
							Where("Code").IsEqual(Column.Parameter("Email"))
				as Select;
			using (var dbExecutor = UserConnection.EnsureDBConnection()) {
				using (IDataReader dr = select.ExecuteReader(dbExecutor)) {
					if (dr.Read()) {
						return UserConnection.DBTypeConverter.DBValueToGuid(dr[0]);
					}
				}
			}
			return Guid.Empty;
		}

		public virtual DateTime NewDate(DateTime oldDate, int offset, ProcessDurationPeriod offsetPeriod) {
			switch(offsetPeriod) {
				default:
				case ProcessDurationPeriod.Minutes:
					return oldDate.AddMinutes(offset);
				case ProcessDurationPeriod.Hours:
					return oldDate.AddHours(offset);
				case ProcessDurationPeriod.Days:
					return oldDate.AddDays(offset);
				case ProcessDurationPeriod.Weeks:
					return oldDate.AddDays(offset*7);
				case ProcessDurationPeriod.Months:
					return oldDate.AddMonths(offset);
			}
		}

		public override bool CompleteExecuting(params object[] parameters) {
			var activity = parameters[0] as BPMSoft.Configuration.Activity;
			if (activity == null) {
				return false;
			}
			OwnerId = activity.OwnerId;
			var columnLead = activity.Schema.Columns.FindByName("Lead");
			if (columnLead != null) {
				object lead = activity.GetColumnValue(columnLead);
				if (lead != null) {
					Lead = (Guid)lead;
				}
			}
			Account = activity.AccountId;
			Contact = activity.ContactId;
			var columnOpportunity = activity.Schema.Columns.FindByName("Opportunity");
			if (columnOpportunity != null) {
				object opportunity = activity.GetColumnValue(columnOpportunity);
				if (opportunity != null) {
					Opportunity = (Guid)opportunity;
				}
			}
			var columnInvoice = activity.Schema.Columns.FindByName("Invoice");
			if (columnInvoice != null) {
				object invoice = activity.GetColumnValue(columnInvoice);
				if (invoice != null) {
					Invoice = (Guid)invoice;
				}
			}
			var columnOrder = activity.Schema.Columns.FindByName("Order");
			if (columnOrder != null) {
				object order = activity.GetColumnValue(columnOrder);
				if (order != null) {
					Order = (Guid)order;
				}
			}
			var columnProject = activity.Schema.Columns.FindByName("Project");
			if (columnProject != null) {
				object project = activity.GetColumnValue(columnProject);
				if (project != null) {
					Project = (Guid)Project;
				}
			}
			var columnContract = activity.Schema.Columns.FindByName("Contract");
			if (columnContract != null) {
				object contract = activity.GetColumnValue(columnContract);
				if (contract != null) {
					Contract = (Guid)contract;
				}
			}
			var columnDocument = activity.Schema.Columns.FindByName("Document");
			if (columnDocument != null) {
				object document = activity.GetColumnValue(columnDocument);
				if (document != null) {
					Document = (Guid)document;
				}
			}
			var columnRequests = activity.Schema.Columns.FindByName("Requests");
			if (columnRequests != null) {
				object requests = activity.GetColumnValue(columnRequests);
				if (requests != null) {
					Requests = (Guid)requests;
				}
			}
			var columnListing = activity.Schema.Columns.FindByName("Listing");
			if (columnListing != null) {
				object listing = activity.GetColumnValue(columnListing);
				if (listing != null) {
					Listing = (Guid)listing;
				}
			}
			var columnProperty = activity.Schema.Columns.FindByName("Property");
			if (columnProperty != null) {
				object property = activity.GetColumnValue(columnProperty);
				if (property != null) {
					Property = (Guid)property;
				}
			}
			
			var columnChange = activity.Schema.Columns.FindByName("Change");
			if (columnChange != null) {
				object change = activity.GetColumnValue(columnChange);
				if (change != null) {
					Change = (Guid)change;
				}
			}
			var columnProblem = activity.Schema.Columns.FindByName("Problem");
			if (columnProblem != null) {
				object problem = activity.GetColumnValue(columnProblem);
				if (problem != null) {
					Problem = (Guid)problem;
				}
			}
			var columnRelease = activity.Schema.Columns.FindByName("Release");
			if (columnRelease != null) {
				object release = activity.GetColumnValue(columnRelease);
				if (release != null) {
					Release = (Guid)release;
				}
			}
			ProcessUserTaskUtilities.SetDynamicParameterValues(this, activity);
			ActivityResult = activity.ResultId;
			IsActivityCompleted = true;
			bool result = base.CompleteExecuting(parameters);
			activity.SetColumnValue("ProcessElementId", null);
			activity.UseAdminRights = false;
			activity.Save();
			return result;
		}

		public virtual string GetConditionData(Guid resultColumntUId, Entity activity) {
			return ProcessUserTaskUtilities.GetConditionData(UserConnection, resultColumntUId, activity);
		}

		public virtual string GetActivityTitle() {
			return ProcessUserTaskUtilities.GetActivityTitle(this, Recommendation, CurrentActivityId);
		}

		public override void CancelExecuting(params object[] parameters) {
			base.CancelExecuting(parameters);
			UserConnection.IProcessEngine.RemoveActivityProcessListener(CurrentActivityId, UId, ActivityConsts.CanceledStatusUId);
		}

		public override string GetExecutionData() {
			return SerializeToString(new {
				procElUId = UId,
				name = Name,
				processId = ProcessUserTaskUtilities.GetParentProcessId(Owner),
				isProcessExecutedBySignal = ProcessUserTaskUtilities.GetIsProcessExecutedBySignal(Owner),
				processName = Owner.Name,
				entitySchemaName = "Activity",
				recommendation = GetActivityTitle(),
				informationOnStep = LocalizableString.IsNullOrEmpty(InformationOnStep) ? null : InformationOnStep.Value,
				pageTypeId =  ActivityConsts.EmailTypeUId,
				activityRecordId = CurrentActivityId,
				executionContext = ExecutionContext,
				nextProcElUId = "nextProcElUIdValue",
				allowedResults = ProcessUserTaskUtilities.GetAllowedActivityResults(UserConnection, CurrentActivityId)
			});
		}

		public virtual Guid GetActivityEntitySchemaUId() {
			return ActivityConsts.ActivityEntitySchemaUId;
		}

		public virtual BPMSoft.Configuration.Activity CreateActivity() {
			var activity = new BPMSoft.Configuration.Activity(UserConnection);
			activity.SetDefColumnValues();
			activity.Id = Guid.NewGuid();
			activity.TypeId = ActivityConsts.EmailTypeUId;
			activity.MessageTypeId = ActivityConsts.OutgoingEmailTypeId;
			activity.Title = GetActivityTitle();
			activity.StartDate = NewDate(UserConnection.CurrentUser.GetCurrentDateTime(), StartIn, (ProcessDurationPeriod)StartInPeriod);
			activity.DueDate = NewDate(activity.StartDate, Duration, (ProcessDurationPeriod)DurationPeriod);
			if (ActivityCategory.Equals(Guid.Empty)){
				ActivityCategory = new Guid("8038A396-7825-E011-8165-00155D043204");
			}
			activity.ActivityCategoryId = ActivityCategory;
			activity.ShowInScheduler = ShowInScheduler;
			activity.Recepient = Recepient;
			activity.CopyRecepient = CopyRecepient;
			activity.BlindCopyRecepient = BlindCopyRecepient;
			activity.Body = Body.ToString();
			activity.IsHtmlBody = true;
			if (OwnerId != Guid.Empty) {
				activity.OwnerId = OwnerId;
				if (RemindBefore != 0) {
					activity.RemindToOwner = true;
					activity.RemindToOwnerDate = NewDate(activity.StartDate, -1 * RemindBefore, (ProcessDurationPeriod)RemindBeforePeriod);
				}
			}
			var columnLead = activity.Schema.Columns.FindByName("Lead");
			if (columnLead != null && Lead != Guid.Empty) {
				activity.SetColumnValue(columnLead, Lead);
			}
			if (Account != Guid.Empty) {
				activity.AccountId = Account;
			}
			if (Contact != Guid.Empty) {
				activity.ContactId = Contact;
			}
			var columnOpportunity = activity.Schema.Columns.FindByName("Opportunity");
			if (columnOpportunity != null && Opportunity != Guid.Empty) {
				activity.SetColumnValue(columnOpportunity, Opportunity);
			}
			var columnDocument = activity.Schema.Columns.FindByName("Document");
			if (columnDocument != null && Document != Guid.Empty) {
				activity.SetColumnValue(columnDocument, Document);
			}
			var columnInvoice = activity.Schema.Columns.FindByName("Invoice");
			if (columnInvoice != null && Invoice != Guid.Empty) {
				activity.SetColumnValue(columnInvoice, Invoice);
			}
			var columnCase = activity.Schema.Columns.FindByName("Case");
			if (columnCase != null && Case != Guid.Empty) {
				activity.SetColumnValue(columnCase, Case);
			}
			var columnOrder = activity.Schema.Columns.FindByName("Order");
			if (columnOrder != null && Order != Guid.Empty) {
				activity.SetColumnValue(columnOrder, Order);
			}
			var columnProject = activity.Schema.Columns.FindByName("Project");
			if (columnProject != null && Project != Guid.Empty) {
				activity.SetColumnValue(columnProject, Project);
			}
			var columnContract = activity.Schema.Columns.FindByName("Contract");
			if (columnContract != null && Contract != Guid.Empty) {
				activity.SetColumnValue(columnContract, Contract);
			}
			var columnRequests = activity.Schema.Columns.FindByName("Requests");
			if (columnRequests != null && Requests != Guid.Empty) {
				activity.SetColumnValue(columnRequests, Requests);
			}
			var columnListing = activity.Schema.Columns.FindByName("Listing");
			if (columnListing != null && Listing != Guid.Empty) {
				activity.SetColumnValue(columnListing, Listing);
			}
			var columnProperty = activity.Schema.Columns.FindByName("Property");
			if (columnProperty != null && Property != Guid.Empty) {
				activity.SetColumnValue(columnProperty, Property);
			}
			
			var columnChange = activity.Schema.Columns.FindByName("Change");
			if (columnChange != null && Change != Guid.Empty) {
				activity.SetColumnValue(columnChange, Change);
			}
			var columnRelease = activity.Schema.Columns.FindByName("Release");
			if (columnRelease != null && Release != Guid.Empty) {
				activity.SetColumnValue(columnRelease, Release);
			}
			var columnProblem = activity.Schema.Columns.FindByName("Problem");
			if (columnProblem != null && Problem != Guid.Empty) {
				activity.SetColumnValue(columnProblem, Problem);
			}
			ProcessUserTaskUtilities.SetEntityColumnValues(this, activity);
			activity.ProcessElementId = UId;
			activity.AllowedResult = GetResultAllowedValues();
			Guid resultColumntUId = activity.Schema.Columns.GetByName("Status").UId;
			UserConnection.IProcessEngine.AddProcessListener(activity, UId, GetConditionData(resultColumntUId, activity));
			UserConnection.IProcessEngine.LinkProcessToEntity(Owner, activity.Schema.UId, activity.Id);
			IsActivityCompleted = false;
			CurrentActivityId = activity.Id;
			return activity;
		}

		public virtual Guid GetParentProcessId() {
			Process parentProcess = Owner;
			Guid processId = parentProcess.UId;
			while(parentProcess != null){
				processId = parentProcess.UId;
				parentProcess = parentProcess.Owner;
			}
			return processId;
		}

		public override ProcessElementNotification GetNotificationData() {
			ProcessElementNotification notification = base.GetNotificationData();
			ProcessUserTaskUtilities.AssignNotificationData(notification, Recommendation, StartIn, StartInPeriod);
			return notification;
		}

		public override void WritePropertiesData(DataWriter writer) {
			writer.WriteStartObject(Name);
			base.WritePropertiesData(writer);
			if (Status == Core.Process.ProcessStatus.Inactive) {
				writer.WriteFinishObject();
				return;
			}
			if (!HasMapping("ActivityCategory")) {
				writer.WriteValue("ActivityCategory", ActivityCategory, Guid.Empty);
			}
			if (!HasMapping("OwnerId")) {
				writer.WriteValue("OwnerId", OwnerId, Guid.Empty);
			}
			if (!HasMapping("Duration")) {
				writer.WriteValue("Duration", Duration, 0);
			}
			if (!HasMapping("DurationPeriod")) {
				writer.WriteValue("DurationPeriod", DurationPeriod, 0);
			}
			if (!HasMapping("StartIn")) {
				writer.WriteValue("StartIn", StartIn, 0);
			}
			if (!HasMapping("StartInPeriod")) {
				writer.WriteValue("StartInPeriod", StartInPeriod, 0);
			}
			if (!HasMapping("RemindBefore")) {
				writer.WriteValue("RemindBefore", RemindBefore, 0);
			}
			if (!HasMapping("RemindBeforePeriod")) {
				writer.WriteValue("RemindBeforePeriod", RemindBeforePeriod, 0);
			}
			if (!HasMapping("ShowInScheduler")) {
				writer.WriteValue("ShowInScheduler", ShowInScheduler, false);
			}
			if (!HasMapping("ShowExecutionPage")) {
				writer.WriteValue("ShowExecutionPage", ShowExecutionPage, false);
			}
			if (!HasMapping("Lead")) {
				writer.WriteValue("Lead", Lead, Guid.Empty);
			}
			if (!HasMapping("Account")) {
				writer.WriteValue("Account", Account, Guid.Empty);
			}
			if (!HasMapping("Contact")) {
				writer.WriteValue("Contact", Contact, Guid.Empty);
			}
			if (!HasMapping("Opportunity")) {
				writer.WriteValue("Opportunity", Opportunity, Guid.Empty);
			}
			if (!HasMapping("Invoice")) {
				writer.WriteValue("Invoice", Invoice, Guid.Empty);
			}
			if (!HasMapping("Document")) {
				writer.WriteValue("Document", Document, Guid.Empty);
			}
			if (!HasMapping("ActivityResult")) {
				writer.WriteValue("ActivityResult", ActivityResult, Guid.Empty);
			}
			if (!HasMapping("Incident")) {
				writer.WriteValue("Incident", Incident, Guid.Empty);
			}
			if (!HasMapping("Case")) {
				writer.WriteValue("Case", Case, Guid.Empty);
			}
			if (!HasMapping("CurrentActivityId")) {
				writer.WriteValue("CurrentActivityId", CurrentActivityId, Guid.Empty);
			}
			if (!HasMapping("IsActivityCompleted")) {
				writer.WriteValue("IsActivityCompleted", IsActivityCompleted, false);
			}
			if (UseFlowEngineMode) {
				if (!HasMapping("ExecutionContext")) {
					writer.WriteValue("ExecutionContext", ExecutionContext, null);
				}
			}
			if (!HasMapping("Recepient")) {
				writer.WriteValue("Recepient", Recepient, null);
			}
			if (!HasMapping("CopyRecepient")) {
				writer.WriteValue("CopyRecepient", CopyRecepient, null);
			}
			if (!HasMapping("BlindCopyRecepient")) {
				writer.WriteValue("BlindCopyRecepient", BlindCopyRecepient, null);
			}
			if (!HasMapping("Order")) {
				writer.WriteValue("Order", Order, Guid.Empty);
			}
			if (!HasMapping("Contract")) {
				writer.WriteValue("Contract", Contract, Guid.Empty);
			}
			if (!HasMapping("Property")) {
				writer.WriteValue("Property", Property, Guid.Empty);
			}
			if (!HasMapping("Listing")) {
				writer.WriteValue("Listing", Listing, Guid.Empty);
			}
			if (!HasMapping("Requests")) {
				writer.WriteValue("Requests", Requests, Guid.Empty);
			}
			if (!HasMapping("Project")) {
				writer.WriteValue("Project", Project, Guid.Empty);
			}
			if (!HasMapping("Problem")) {
				writer.WriteValue("Problem", Problem, Guid.Empty);
			}
			if (!HasMapping("Change")) {
				writer.WriteValue("Change", Change, Guid.Empty);
			}
			if (!HasMapping("Release")) {
				writer.WriteValue("Release", Release, Guid.Empty);
			}
			if (!HasMapping("QueueItem")) {
				writer.WriteValue("QueueItem", QueueItem, Guid.Empty);
			}
			writer.WriteFinishObject();
		}

		public override bool TryGetPerformer(out Guid performerUId) {
			performerUId = OwnerId;
			return true;
		}

		#endregion

		#region Methods: Protected

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			switch (reader.CurrentName) {
				case "Recommendation":
					Recommendation = reader.GetLocalizableStringValue();
				break;
				case "ActivityCategory":
					ActivityCategory = reader.GetGuidValue();
				break;
				case "OwnerId":
					OwnerId = reader.GetGuidValue();
				break;
				case "Duration":
					Duration = reader.GetIntValue();
				break;
				case "DurationPeriod":
					DurationPeriod = reader.GetIntValue();
				break;
				case "StartIn":
					StartIn = reader.GetIntValue();
				break;
				case "StartInPeriod":
					StartInPeriod = reader.GetIntValue();
				break;
				case "RemindBefore":
					RemindBefore = reader.GetIntValue();
				break;
				case "RemindBeforePeriod":
					RemindBeforePeriod = reader.GetIntValue();
				break;
				case "ShowInScheduler":
					ShowInScheduler = reader.GetBoolValue();
				break;
				case "ShowExecutionPage":
					ShowExecutionPage = reader.GetBoolValue();
				break;
				case "Lead":
					Lead = reader.GetGuidValue();
				break;
				case "Account":
					Account = reader.GetGuidValue();
				break;
				case "Contact":
					Contact = reader.GetGuidValue();
				break;
				case "Opportunity":
					Opportunity = reader.GetGuidValue();
				break;
				case "Invoice":
					Invoice = reader.GetGuidValue();
				break;
				case "Document":
					Document = reader.GetGuidValue();
				break;
				case "ActivityResult":
					ActivityResult = reader.GetGuidValue();
				break;
				case "Incident":
					Incident = reader.GetGuidValue();
				break;
				case "Case":
					Case = reader.GetGuidValue();
				break;
				case "CurrentActivityId":
					CurrentActivityId = reader.GetGuidValue();
				break;
				case "IsActivityCompleted":
					IsActivityCompleted = reader.GetBoolValue();
				break;
				case "ExecutionContext":
					if (!UseFlowEngineMode) {
						break;
					}
					ExecutionContext = reader.GetStringValue();
				break;
				case "Recepient":
					Recepient = reader.GetStringValue();
				break;
				case "CopyRecepient":
					CopyRecepient = reader.GetStringValue();
				break;
				case "BlindCopyRecepient":
					BlindCopyRecepient = reader.GetStringValue();
				break;
				case "Body":
					Body = reader.GetLocalizableStringValue();
				break;
				case "InformationOnStep":
					InformationOnStep = reader.GetLocalizableStringValue();
				break;
				case "Order":
					Order = reader.GetGuidValue();
				break;
				case "Contract":
					Contract = reader.GetGuidValue();
				break;
				case "Property":
					Property = reader.GetGuidValue();
				break;
				case "Listing":
					Listing = reader.GetGuidValue();
				break;
				case "Requests":
					Requests = reader.GetGuidValue();
				break;
				case "Project":
					Project = reader.GetGuidValue();
				break;
				case "Problem":
					Problem = reader.GetGuidValue();
				break;
				case "Change":
					Change = reader.GetGuidValue();
				break;
				case "Release":
					Release = reader.GetGuidValue();
				break;
				case "QueueItem":
					QueueItem = reader.GetGuidValue();
				break;
			}
		}

		#endregion

	}

	#endregion

}

