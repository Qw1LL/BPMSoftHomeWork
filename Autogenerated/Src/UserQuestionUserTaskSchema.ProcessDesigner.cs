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
	using RecordEditMode = BPMSoft.Configuration.RecordEditMode;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Data;
	using System.Globalization;
	using System.Runtime.Serialization.Formatters;
	using System.Text;
	using UserTaskExecutedMode = BPMSoft.Configuration.UserTaskExecutedMode;

	#region Class: UserQuestionUserTask

	[DesignModeGroup(Name = "Общие", Position = 1, UseSolutionStorage = true, ResourceManager = "fe10dd952d614aa181119fb23b032603", CaptionResourceItem = "Parameters.Recommendation.Group", DescriptionResourceItem = "Parameters.Recommendation.Group")]
	[DesignModeGroup(Name = "Взаимосвязи", Position = 2, UseSolutionStorage = true, ResourceManager = "fe10dd952d614aa181119fb23b032603", CaptionResourceItem = "Parameters.Lead.Group", DescriptionResourceItem = "Parameters.Lead.Group")]
	[DesignModeProperty(Name = "BranchingDecisions", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "fe10dd952d614aa181119fb23b032603", CaptionResourceItem = "Parameters.BranchingDecisions.Caption", DescriptionResourceItem = "Parameters.BranchingDecisions.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ResultDecisions", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "fe10dd952d614aa181119fb23b032603", CaptionResourceItem = "Parameters.ResultDecisions.Caption", DescriptionResourceItem = "Parameters.ResultDecisions.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "DecisionMode", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "fe10dd952d614aa181119fb23b032603", CaptionResourceItem = "Parameters.DecisionMode.Caption", DescriptionResourceItem = "Parameters.DecisionMode.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "IsDecisionRequired", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "fe10dd952d614aa181119fb23b032603", CaptionResourceItem = "Parameters.IsDecisionRequired.Caption", DescriptionResourceItem = "Parameters.IsDecisionRequired.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Question", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "fe10dd952d614aa181119fb23b032603", CaptionResourceItem = "Parameters.Question.Caption", DescriptionResourceItem = "Parameters.Question.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "WindowCaption", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "fe10dd952d614aa181119fb23b032603", CaptionResourceItem = "Parameters.WindowCaption.Caption", DescriptionResourceItem = "Parameters.WindowCaption.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Recommendation", Group = "Общие", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "fe10dd952d614aa181119fb23b032603", CaptionResourceItem = "Parameters.Recommendation.Caption", DescriptionResourceItem = "Parameters.Recommendation.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ActivityCategory", Group = "Общие", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "fe10dd952d614aa181119fb23b032603", CaptionResourceItem = "Parameters.ActivityCategory.Caption", DescriptionResourceItem = "Parameters.ActivityCategory.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "OwnerId", Group = "Общие", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "fe10dd952d614aa181119fb23b032603", CaptionResourceItem = "Parameters.OwnerId.Caption", DescriptionResourceItem = "Parameters.OwnerId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Duration", Group = "Общие", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "fe10dd952d614aa181119fb23b032603", CaptionResourceItem = "Parameters.Duration.Caption", DescriptionResourceItem = "Parameters.Duration.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "DurationPeriod", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "fe10dd952d614aa181119fb23b032603", CaptionResourceItem = "Parameters.DurationPeriod.Caption", DescriptionResourceItem = "Parameters.DurationPeriod.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "StartIn", Group = "Общие", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "fe10dd952d614aa181119fb23b032603", CaptionResourceItem = "Parameters.StartIn.Caption", DescriptionResourceItem = "Parameters.StartIn.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "StartInPeriod", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "fe10dd952d614aa181119fb23b032603", CaptionResourceItem = "Parameters.StartInPeriod.Caption", DescriptionResourceItem = "Parameters.StartInPeriod.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "RemindBefore", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "fe10dd952d614aa181119fb23b032603", CaptionResourceItem = "Parameters.RemindBefore.Caption", DescriptionResourceItem = "Parameters.RemindBefore.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "RemindBeforePeriod", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "fe10dd952d614aa181119fb23b032603", CaptionResourceItem = "Parameters.RemindBeforePeriod.Caption", DescriptionResourceItem = "Parameters.RemindBeforePeriod.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ShowInScheduler", Group = "Общие", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "fe10dd952d614aa181119fb23b032603", CaptionResourceItem = "Parameters.ShowInScheduler.Caption", DescriptionResourceItem = "Parameters.ShowInScheduler.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ShowExecutionPage", Group = "Общие", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "fe10dd952d614aa181119fb23b032603", CaptionResourceItem = "Parameters.ShowExecutionPage.Caption", DescriptionResourceItem = "Parameters.ShowExecutionPage.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Lead", Group = "Взаимосвязи", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "fe10dd952d614aa181119fb23b032603", CaptionResourceItem = "Parameters.Lead.Caption", DescriptionResourceItem = "Parameters.Lead.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Account", Group = "Взаимосвязи", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "fe10dd952d614aa181119fb23b032603", CaptionResourceItem = "Parameters.Account.Caption", DescriptionResourceItem = "Parameters.Account.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Contact", Group = "Взаимосвязи", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "fe10dd952d614aa181119fb23b032603", CaptionResourceItem = "Parameters.Contact.Caption", DescriptionResourceItem = "Parameters.Contact.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Opportunity", Group = "Взаимосвязи", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "fe10dd952d614aa181119fb23b032603", CaptionResourceItem = "Parameters.Opportunity.Caption", DescriptionResourceItem = "Parameters.Opportunity.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Invoice", Group = "Взаимосвязи", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "fe10dd952d614aa181119fb23b032603", CaptionResourceItem = "Parameters.Invoice.Caption", DescriptionResourceItem = "Parameters.Invoice.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Document", Group = "Взаимосвязи", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "fe10dd952d614aa181119fb23b032603", CaptionResourceItem = "Parameters.Document.Caption", DescriptionResourceItem = "Parameters.Document.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Incident", Group = "Взаимосвязи", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "fe10dd952d614aa181119fb23b032603", CaptionResourceItem = "Parameters.Incident.Caption", DescriptionResourceItem = "Parameters.Incident.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Case", Group = "Взаимосвязи", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "fe10dd952d614aa181119fb23b032603", CaptionResourceItem = "Parameters.Case.Caption", DescriptionResourceItem = "Parameters.Case.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ActivityResult", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "fe10dd952d614aa181119fb23b032603", CaptionResourceItem = "Parameters.ActivityResult.Caption", DescriptionResourceItem = "Parameters.ActivityResult.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "CurrentActivityId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "fe10dd952d614aa181119fb23b032603", CaptionResourceItem = "Parameters.CurrentActivityId.Caption", DescriptionResourceItem = "Parameters.CurrentActivityId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "IsActivityCompleted", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "fe10dd952d614aa181119fb23b032603", CaptionResourceItem = "Parameters.IsActivityCompleted.Caption", DescriptionResourceItem = "Parameters.IsActivityCompleted.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ExecutionContext", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "fe10dd952d614aa181119fb23b032603", CaptionResourceItem = "Parameters.ExecutionContext.Caption", DescriptionResourceItem = "Parameters.ExecutionContext.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "InformationOnStep", Group = "Общие", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "fe10dd952d614aa181119fb23b032603", CaptionResourceItem = "Parameters.InformationOnStep.Caption", DescriptionResourceItem = "Parameters.InformationOnStep.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Order", Group = "Взаимосвязи", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "fe10dd952d614aa181119fb23b032603", CaptionResourceItem = "Parameters.Order.Caption", DescriptionResourceItem = "Parameters.Order.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Requests", Group = "Взаимосвязи", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "fe10dd952d614aa181119fb23b032603", CaptionResourceItem = "Parameters.Requests.Caption", DescriptionResourceItem = "Parameters.Requests.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Listing", Group = "Взаимосвязи", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "fe10dd952d614aa181119fb23b032603", CaptionResourceItem = "Parameters.Listing.Caption", DescriptionResourceItem = "Parameters.Listing.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Property", Group = "Взаимосвязи", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "fe10dd952d614aa181119fb23b032603", CaptionResourceItem = "Parameters.Property.Caption", DescriptionResourceItem = "Parameters.Property.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Contract", Group = "Взаимосвязи", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "fe10dd952d614aa181119fb23b032603", CaptionResourceItem = "Parameters.Contract.Caption", DescriptionResourceItem = "Parameters.Contract.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Project", Group = "Взаимосвязи", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "fe10dd952d614aa181119fb23b032603", CaptionResourceItem = "Parameters.Project.Caption", DescriptionResourceItem = "Parameters.Project.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Problem", Group = "Взаимосвязи", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "fe10dd952d614aa181119fb23b032603", CaptionResourceItem = "Parameters.Problem.Caption", DescriptionResourceItem = "Parameters.Problem.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Change", Group = "Взаимосвязи", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "fe10dd952d614aa181119fb23b032603", CaptionResourceItem = "Parameters.Change.Caption", DescriptionResourceItem = "Parameters.Change.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Release", Group = "Взаимосвязи", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "fe10dd952d614aa181119fb23b032603", CaptionResourceItem = "Parameters.Release.Caption", DescriptionResourceItem = "Parameters.Release.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "CreateActivity", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "fe10dd952d614aa181119fb23b032603", CaptionResourceItem = "Parameters.CreateActivity.Caption", DescriptionResourceItem = "Parameters.CreateActivity.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ActivityPriority", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "fe10dd952d614aa181119fb23b032603", CaptionResourceItem = "Parameters.ActivityPriority.Caption", DescriptionResourceItem = "Parameters.ActivityPriority.Caption", UseSolutionStorage = true)]
	/// <exclude/>
	public partial class UserQuestionUserTask : ProcessUserTask
	{

		#region Constructors: Public

		public UserQuestionUserTask(UserConnection userConnection)
			: base(userConnection) {
			SchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603");
			_decisionMode = () => { return 0; };
			_isDecisionRequired = () => { return true; };
		}

		#endregion

		#region Properties: Public

		private LocalizableString _branchingDecisions;
		public virtual LocalizableString BranchingDecisions {
			get {
				return _branchingDecisions ?? (_branchingDecisions = new LocalizableString());
			}
			set {
				_branchingDecisions = value;
			}
		}

		public virtual string ResultDecisions {
			get;
			set;
		}

		private Func<int> _decisionMode;
		public virtual int DecisionMode {
			get {
				return (_decisionMode ?? (_decisionMode = () => 0)).Invoke();
			}
			set {
				_decisionMode = () => { return value; };
			}
		}

		private Func<bool> _isDecisionRequired;
		public virtual bool IsDecisionRequired {
			get {
				return (_isDecisionRequired ?? (_isDecisionRequired = () => false)).Invoke();
			}
			set {
				_isDecisionRequired = () => { return value; };
			}
		}

		private LocalizableString _question;
		public virtual LocalizableString Question {
			get {
				return _question ?? (_question = new LocalizableString());
			}
			set {
				_question = value;
			}
		}

		private LocalizableString _windowCaption;
		public virtual LocalizableString WindowCaption {
			get {
				return _windowCaption ?? (_windowCaption = new LocalizableString());
			}
			set {
				_windowCaption = value;
			}
		}

		private LocalizableString _recommendation;
		public virtual LocalizableString Recommendation {
			get {
				return _recommendation ?? (_recommendation = new LocalizableString());
			}
			set {
				_recommendation = value;
			}
		}

		private Guid _activityCategory = new Guid("f51c4643-58e6-df11-971b-001d60e938c6");
		public virtual Guid ActivityCategory {
			get {
				return _activityCategory;
			}
			set {
				_activityCategory = value;
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

		public virtual Guid Incident {
			get;
			set;
		}

		public virtual Guid Case {
			get;
			set;
		}

		public virtual Guid ActivityResult {
			get;
			set;
		}

		public virtual Guid CurrentActivityId {
			get;
			set;
		}

		private bool _isActivityCompleted = false;
		public virtual bool IsActivityCompleted {
			get {
				return _isActivityCompleted;
			}
			set {
				_isActivityCompleted = value;
			}
		}

		public virtual string ExecutionContext {
			get;
			set;
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

		public virtual Guid Requests {
			get;
			set;
		}

		public virtual Guid Listing {
			get;
			set;
		}

		public virtual Guid Property {
			get;
			set;
		}

		public virtual Guid Contract {
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

		private bool _createActivity = false;
		public virtual bool CreateActivity {
			get {
				return _createActivity;
			}
			set {
				_createActivity = value;
			}
		}

		private Guid _activityPriority = new Guid("ab96fa02-7fe6-df11-971b-001d60e938c6");
		public virtual Guid ActivityPriority {
			get {
				return _activityPriority;
			}
			set {
				_activityPriority = value;
			}
		}

		private LocalizableString _noCaptionLocalizableString;
		public LocalizableString NoCaptionLocalizableString {
			get {
				return _noCaptionLocalizableString ?? (_noCaptionLocalizableString = new LocalizableString(Storage, Schema.GetResourceManagerName(), "LocalizableStrings.NoCaptionLocalizableString.Value"));
			}
		}

		#endregion

		#region Methods: Public

		public override void WritePropertiesData(DataWriter writer) {
			writer.WriteStartObject(Name);
			base.WritePropertiesData(writer);
			if (Status == Core.Process.ProcessStatus.Inactive) {
				writer.WriteFinishObject();
				return;
			}
			if (!HasMapping("ResultDecisions")) {
				writer.WriteValue("ResultDecisions", ResultDecisions, null);
			}
			if (!HasMapping("DecisionMode")) {
				writer.WriteValue("DecisionMode", DecisionMode, 0);
			}
			if (!HasMapping("IsDecisionRequired")) {
				writer.WriteValue("IsDecisionRequired", IsDecisionRequired, false);
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
			if (!HasMapping("Incident")) {
				writer.WriteValue("Incident", Incident, Guid.Empty);
			}
			if (!HasMapping("Case")) {
				writer.WriteValue("Case", Case, Guid.Empty);
			}
			if (!HasMapping("ActivityResult")) {
				writer.WriteValue("ActivityResult", ActivityResult, Guid.Empty);
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
			if (!HasMapping("Order")) {
				writer.WriteValue("Order", Order, Guid.Empty);
			}
			if (!HasMapping("Requests")) {
				writer.WriteValue("Requests", Requests, Guid.Empty);
			}
			if (!HasMapping("Listing")) {
				writer.WriteValue("Listing", Listing, Guid.Empty);
			}
			if (!HasMapping("Property")) {
				writer.WriteValue("Property", Property, Guid.Empty);
			}
			if (!HasMapping("Contract")) {
				writer.WriteValue("Contract", Contract, Guid.Empty);
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
			if (!HasMapping("CreateActivity")) {
				writer.WriteValue("CreateActivity", CreateActivity, false);
			}
			if (!HasMapping("ActivityPriority")) {
				writer.WriteValue("ActivityPriority", ActivityPriority, Guid.Empty);
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
				case "BranchingDecisions":
					BranchingDecisions = reader.GetLocalizableStringValue();
				break;
				case "ResultDecisions":
					ResultDecisions = reader.GetStringValue();
				break;
				case "DecisionMode":
					DecisionMode = reader.GetIntValue();
				break;
				case "IsDecisionRequired":
					IsDecisionRequired = reader.GetBoolValue();
				break;
				case "Question":
					Question = reader.GetLocalizableStringValue();
				break;
				case "WindowCaption":
					WindowCaption = reader.GetLocalizableStringValue();
				break;
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
				case "Incident":
					Incident = reader.GetGuidValue();
				break;
				case "Case":
					Case = reader.GetGuidValue();
				break;
				case "ActivityResult":
					ActivityResult = reader.GetGuidValue();
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
				case "InformationOnStep":
					InformationOnStep = reader.GetLocalizableStringValue();
				break;
				case "Order":
					Order = reader.GetGuidValue();
				break;
				case "Requests":
					Requests = reader.GetGuidValue();
				break;
				case "Listing":
					Listing = reader.GetGuidValue();
				break;
				case "Property":
					Property = reader.GetGuidValue();
				break;
				case "Contract":
					Contract = reader.GetGuidValue();
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
				case "CreateActivity":
					CreateActivity = reader.GetBoolValue();
				break;
				case "ActivityPriority":
					ActivityPriority = reader.GetGuidValue();
				break;
			}
		}

		#endregion

	}

	#endregion

}

