namespace BPMSoft.Core.Process.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Configuration;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;
	using BPMSoft.Core.Process;
	using BPMSoft.Mail.Sender;
	using BPMSoft.UI.WebControls.Controls;
	using BPMSoft.UI.WebControls.Utilities;
	using BPMSoft.UI.WebControls.Utilities.Json.Converters;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using ProcessDesigner = BPMSoft.Configuration.ProcessDesigner;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Data;
	using System.Globalization;
	using System.Linq;
	using System.Runtime.Serialization.Formatters;
	using System.Text;

	#region Class: EmailTemplateUserTaskSchemaExtension

	/// <exclude/>
	public class EmailTemplateUserTaskSchemaExtension : ProcessUserTaskSchemaExtension
	{

		#region Methods: Public

		public override Dictionary<Guid, string> GetResultParameterAllValues(UserConnection userConnection, ProcessSchemaUserTask schemaUserTask) {
			var result = new Dictionary<Guid, string>();
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
			using (DBExecutor dbExecutor = userConnection.EnsureDBConnection()) {
				using (IDataReader dataReader = select.ExecuteReader(dbExecutor)) {
					while (dataReader.Read()) {
						result.Add(userConnection.DBTypeConverter.DBValueToGuid(dataReader[0]), dataReader.GetString(1));
					}
				}
			}
			return result;
		}

		public override void SynchronizeDynamicParameters(UserConnection userConnection, ProcessUserTaskSchema target) {
			base.SynchronizeDynamicParameters(userConnection, target);
			ProcessUserTaskUtilities.SynchronizeActivityConnectionParameters(userConnection, target);
		}

		#endregion

	}

	#endregion

	#region Class: EmailTemplateUserTask

	[DesignModeGroup(Name = "Общие", Position = 1, UseSolutionStorage = true, ResourceManager = "184dbb27ce134d378dffc2ff1df9cf19", CaptionResourceItem = "Parameters.Recommendation.Group", DescriptionResourceItem = "Parameters.Recommendation.Group")]
	[DesignModeGroup(Name = "Взаимосвязи", Position = 2, UseSolutionStorage = true, ResourceManager = "184dbb27ce134d378dffc2ff1df9cf19", CaptionResourceItem = "Parameters.Lead.Group", DescriptionResourceItem = "Parameters.Lead.Group")]
	[DesignModeGroup(Name = "General", Position = 3, UseSolutionStorage = true, ResourceManager = "184dbb27ce134d378dffc2ff1df9cf19", CaptionResourceItem = "Parameters.Sender.Group", DescriptionResourceItem = "Parameters.Sender.Group")]
	[DesignModeProperty(Name = "Recommendation", Group = "Общие", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "184dbb27ce134d378dffc2ff1df9cf19", CaptionResourceItem = "Parameters.Recommendation.Caption", DescriptionResourceItem = "Parameters.Recommendation.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ActivityCategory", Group = "Общие", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "184dbb27ce134d378dffc2ff1df9cf19", CaptionResourceItem = "Parameters.ActivityCategory.Caption", DescriptionResourceItem = "Parameters.ActivityCategory.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "OwnerId", Group = "Общие", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "184dbb27ce134d378dffc2ff1df9cf19", CaptionResourceItem = "Parameters.OwnerId.Caption", DescriptionResourceItem = "Parameters.OwnerId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Duration", Group = "Общие", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "184dbb27ce134d378dffc2ff1df9cf19", CaptionResourceItem = "Parameters.Duration.Caption", DescriptionResourceItem = "Parameters.Duration.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "DurationPeriod", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "184dbb27ce134d378dffc2ff1df9cf19", CaptionResourceItem = "Parameters.DurationPeriod.Caption", DescriptionResourceItem = "Parameters.DurationPeriod.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "StartIn", Group = "Общие", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "184dbb27ce134d378dffc2ff1df9cf19", CaptionResourceItem = "Parameters.StartIn.Caption", DescriptionResourceItem = "Parameters.StartIn.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "StartInPeriod", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "184dbb27ce134d378dffc2ff1df9cf19", CaptionResourceItem = "Parameters.StartInPeriod.Caption", DescriptionResourceItem = "Parameters.StartInPeriod.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "RemindBefore", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "184dbb27ce134d378dffc2ff1df9cf19", CaptionResourceItem = "Parameters.RemindBefore.Caption", DescriptionResourceItem = "Parameters.RemindBefore.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "RemindBeforePeriod", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "184dbb27ce134d378dffc2ff1df9cf19", CaptionResourceItem = "Parameters.RemindBeforePeriod.Caption", DescriptionResourceItem = "Parameters.RemindBeforePeriod.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ShowInScheduler", Group = "Общие", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "184dbb27ce134d378dffc2ff1df9cf19", CaptionResourceItem = "Parameters.ShowInScheduler.Caption", DescriptionResourceItem = "Parameters.ShowInScheduler.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ShowExecutionPage", Group = "Общие", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "184dbb27ce134d378dffc2ff1df9cf19", CaptionResourceItem = "Parameters.ShowExecutionPage.Caption", DescriptionResourceItem = "Parameters.ShowExecutionPage.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Lead", Group = "Взаимосвязи", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "184dbb27ce134d378dffc2ff1df9cf19", CaptionResourceItem = "Parameters.Lead.Caption", DescriptionResourceItem = "Parameters.Lead.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Account", Group = "Взаимосвязи", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "184dbb27ce134d378dffc2ff1df9cf19", CaptionResourceItem = "Parameters.Account.Caption", DescriptionResourceItem = "Parameters.Account.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Contact", Group = "Взаимосвязи", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "184dbb27ce134d378dffc2ff1df9cf19", CaptionResourceItem = "Parameters.Contact.Caption", DescriptionResourceItem = "Parameters.Contact.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Opportunity", Group = "Взаимосвязи", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "184dbb27ce134d378dffc2ff1df9cf19", CaptionResourceItem = "Parameters.Opportunity.Caption", DescriptionResourceItem = "Parameters.Opportunity.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Invoice", Group = "Взаимосвязи", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "184dbb27ce134d378dffc2ff1df9cf19", CaptionResourceItem = "Parameters.Invoice.Caption", DescriptionResourceItem = "Parameters.Invoice.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Document", Group = "Взаимосвязи", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "184dbb27ce134d378dffc2ff1df9cf19", CaptionResourceItem = "Parameters.Document.Caption", DescriptionResourceItem = "Parameters.Document.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ActivityResult", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "184dbb27ce134d378dffc2ff1df9cf19", CaptionResourceItem = "Parameters.ActivityResult.Caption", DescriptionResourceItem = "Parameters.ActivityResult.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Incident", Group = "Взаимосвязи", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "184dbb27ce134d378dffc2ff1df9cf19", CaptionResourceItem = "Parameters.Incident.Caption", DescriptionResourceItem = "Parameters.Incident.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Case", Group = "Взаимосвязи", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "184dbb27ce134d378dffc2ff1df9cf19", CaptionResourceItem = "Parameters.Case.Caption", DescriptionResourceItem = "Parameters.Case.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ActivityId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "184dbb27ce134d378dffc2ff1df9cf19", CaptionResourceItem = "Parameters.ActivityId.Caption", DescriptionResourceItem = "Parameters.ActivityId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "IsActivityCompleted", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "184dbb27ce134d378dffc2ff1df9cf19", CaptionResourceItem = "Parameters.IsActivityCompleted.Caption", DescriptionResourceItem = "Parameters.IsActivityCompleted.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ExecutionContext", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "184dbb27ce134d378dffc2ff1df9cf19", CaptionResourceItem = "Parameters.ExecutionContext.Caption", DescriptionResourceItem = "Parameters.ExecutionContext.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "InformationOnStep", Group = "Общие", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "184dbb27ce134d378dffc2ff1df9cf19", CaptionResourceItem = "Parameters.InformationOnStep.Caption", DescriptionResourceItem = "Parameters.InformationOnStep.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Order", Group = "Взаимосвязи", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "184dbb27ce134d378dffc2ff1df9cf19", CaptionResourceItem = "Parameters.Order.Caption", DescriptionResourceItem = "Parameters.Order.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Contract", Group = "Взаимосвязи", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "184dbb27ce134d378dffc2ff1df9cf19", CaptionResourceItem = "Parameters.Contract.Caption", DescriptionResourceItem = "Parameters.Contract.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Property", Group = "Взаимосвязи", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "184dbb27ce134d378dffc2ff1df9cf19", CaptionResourceItem = "Parameters.Property.Caption", DescriptionResourceItem = "Parameters.Property.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Listing", Group = "Взаимосвязи", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "184dbb27ce134d378dffc2ff1df9cf19", CaptionResourceItem = "Parameters.Listing.Caption", DescriptionResourceItem = "Parameters.Listing.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Requests", Group = "Взаимосвязи", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "184dbb27ce134d378dffc2ff1df9cf19", CaptionResourceItem = "Parameters.Requests.Caption", DescriptionResourceItem = "Parameters.Requests.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Project", Group = "Взаимосвязи", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "184dbb27ce134d378dffc2ff1df9cf19", CaptionResourceItem = "Parameters.Project.Caption", DescriptionResourceItem = "Parameters.Project.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Problem", Group = "Взаимосвязи", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "184dbb27ce134d378dffc2ff1df9cf19", CaptionResourceItem = "Parameters.Problem.Caption", DescriptionResourceItem = "Parameters.Problem.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Change", Group = "Взаимосвязи", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "184dbb27ce134d378dffc2ff1df9cf19", CaptionResourceItem = "Parameters.Change.Caption", DescriptionResourceItem = "Parameters.Change.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Release", Group = "Взаимосвязи", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "184dbb27ce134d378dffc2ff1df9cf19", CaptionResourceItem = "Parameters.Release.Caption", DescriptionResourceItem = "Parameters.Release.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "QueueItem", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "184dbb27ce134d378dffc2ff1df9cf19", CaptionResourceItem = "Parameters.QueueItem.Caption", DescriptionResourceItem = "Parameters.QueueItem.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Sender", Group = "General", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "184dbb27ce134d378dffc2ff1df9cf19", CaptionResourceItem = "Parameters.Sender.Caption", DescriptionResourceItem = "Parameters.Sender.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Importance", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "184dbb27ce134d378dffc2ff1df9cf19", CaptionResourceItem = "Parameters.Importance.Caption", DescriptionResourceItem = "Parameters.Importance.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Subject", Group = "Общие", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "184dbb27ce134d378dffc2ff1df9cf19", CaptionResourceItem = "Parameters.Subject.Caption", DescriptionResourceItem = "Parameters.Subject.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "IgnoreErrors", Group = "Общие", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "184dbb27ce134d378dffc2ff1df9cf19", CaptionResourceItem = "Parameters.IgnoreErrors.Caption", DescriptionResourceItem = "Parameters.IgnoreErrors.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "SendEmailType", Group = "Общие", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "184dbb27ce134d378dffc2ff1df9cf19", CaptionResourceItem = "Parameters.SendEmailType.Caption", DescriptionResourceItem = "Parameters.SendEmailType.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "BodyTemplateType", Group = "Общие", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "184dbb27ce134d378dffc2ff1df9cf19", CaptionResourceItem = "Parameters.BodyTemplateType.Caption", DescriptionResourceItem = "Parameters.BodyTemplateType.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "EmailTemplateId", Group = "Общие", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "184dbb27ce134d378dffc2ff1df9cf19", CaptionResourceItem = "Parameters.EmailTemplateId.Caption", DescriptionResourceItem = "Parameters.EmailTemplateId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "EmailTemplateEntityId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "184dbb27ce134d378dffc2ff1df9cf19", CaptionResourceItem = "Parameters.EmailTemplateEntityId.Caption", DescriptionResourceItem = "Parameters.EmailTemplateEntityId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Body", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "184dbb27ce134d378dffc2ff1df9cf19", CaptionResourceItem = "Parameters.Body.Caption", DescriptionResourceItem = "Parameters.Body.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "BodyConfig", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "184dbb27ce134d378dffc2ff1df9cf19", CaptionResourceItem = "Parameters.BodyConfig.Caption", DescriptionResourceItem = "Parameters.BodyConfig.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "CreateActivity", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "184dbb27ce134d378dffc2ff1df9cf19", CaptionResourceItem = "Parameters.CreateActivity.Caption", DescriptionResourceItem = "Parameters.CreateActivity.Caption", UseSolutionStorage = true)]
	/// <exclude/>
	public partial class EmailTemplateUserTask : ProcessUserTask
	{

		#region Constructors: Public

		public EmailTemplateUserTask(UserConnection userConnection)
			: base(userConnection) {
			SchemaUId = new Guid("184dbb27-ce13-4d37-8dff-c2ff1df9cf19");
			_activityCategory = () => { return new Guid("8038a396-7825-e011-8165-00155d043204"); };
			_importance = () => { return 1; };
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

		public virtual Guid ActivityId {
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

		public virtual Guid Sender {
			get;
			set;
		}

		private Func<int> _importance;
		public virtual int Importance {
			get {
				return (_importance ?? (_importance = () => 0)).Invoke();
			}
			set {
				_importance = () => { return value; };
			}
		}

		private LocalizableString _subject;
		public virtual LocalizableString Subject {
			get {
				return _subject ?? (_subject = new LocalizableString());
			}
			set {
				_subject = value;
			}
		}

		private bool _ignoreErrors = true;
		public virtual bool IgnoreErrors {
			get {
				return _ignoreErrors;
			}
			set {
				_ignoreErrors = value;
			}
		}

		public virtual int SendEmailType {
			get;
			set;
		}

		public virtual int BodyTemplateType {
			get;
			set;
		}

		public virtual Guid EmailTemplateId {
			get;
			set;
		}

		public virtual Guid EmailTemplateEntityId {
			get;
			set;
		}

		public virtual string Body {
			get;
			set;
		}

		public virtual string BodyConfig {
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

		#endregion

		#region Methods: Public

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
			if (!HasMapping("ActivityId")) {
				writer.WriteValue("ActivityId", ActivityId, Guid.Empty);
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
			if (!HasMapping("Sender")) {
				writer.WriteValue("Sender", Sender, Guid.Empty);
			}
			if (!HasMapping("Importance")) {
				writer.WriteValue("Importance", Importance, 0);
			}
			if (!HasMapping("IgnoreErrors")) {
				writer.WriteValue("IgnoreErrors", IgnoreErrors, false);
			}
			if (!HasMapping("SendEmailType")) {
				writer.WriteValue("SendEmailType", SendEmailType, 0);
			}
			if (!HasMapping("BodyTemplateType")) {
				writer.WriteValue("BodyTemplateType", BodyTemplateType, 0);
			}
			if (!HasMapping("EmailTemplateId")) {
				writer.WriteValue("EmailTemplateId", EmailTemplateId, Guid.Empty);
			}
			if (!HasMapping("EmailTemplateEntityId")) {
				writer.WriteValue("EmailTemplateEntityId", EmailTemplateEntityId, Guid.Empty);
			}
			if (!HasMapping("Body")) {
				writer.WriteValue("Body", Body, null);
			}
			if (!HasMapping("BodyConfig")) {
				writer.WriteValue("BodyConfig", BodyConfig, null);
			}
			if (!HasMapping("CreateActivity")) {
				writer.WriteValue("CreateActivity", CreateActivity, false);
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
				case "ActivityId":
					ActivityId = reader.GetGuidValue();
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
				case "Sender":
					Sender = reader.GetGuidValue();
				break;
				case "Importance":
					Importance = reader.GetIntValue();
				break;
				case "Subject":
					Subject = reader.GetLocalizableStringValue();
				break;
				case "IgnoreErrors":
					IgnoreErrors = reader.GetBoolValue();
				break;
				case "SendEmailType":
					SendEmailType = reader.GetIntValue();
				break;
				case "BodyTemplateType":
					BodyTemplateType = reader.GetIntValue();
				break;
				case "EmailTemplateId":
					EmailTemplateId = reader.GetGuidValue();
				break;
				case "EmailTemplateEntityId":
					EmailTemplateEntityId = reader.GetGuidValue();
				break;
				case "Body":
					Body = reader.GetStringValue();
				break;
				case "BodyConfig":
					BodyConfig = reader.GetStringValue();
				break;
				case "CreateActivity":
					CreateActivity = reader.GetBoolValue();
				break;
			}
		}

		#endregion

	}

	#endregion

}

