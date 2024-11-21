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
	using BPMSoft.Nui.ServiceModel.Extensions;
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

	#region Class: OpenEditPageUserTask

	[DesignModeGroup(Name = "Общие", Position = 1, UseSolutionStorage = true, ResourceManager = "b0d3ad9f7a2746a39483ed70c26872ae", CaptionResourceItem = "Parameters.Recommendation.Group", DescriptionResourceItem = "Parameters.Recommendation.Group")]
	[DesignModeGroup(Name = "Взаимосвязи", Position = 2, UseSolutionStorage = true, ResourceManager = "b0d3ad9f7a2746a39483ed70c26872ae", CaptionResourceItem = "Parameters.Lead.Group", DescriptionResourceItem = "Parameters.Lead.Group")]
	[DesignModeProperty(Name = "ObjectSchemaId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "b0d3ad9f7a2746a39483ed70c26872ae", CaptionResourceItem = "Parameters.ObjectSchemaId.Caption", DescriptionResourceItem = "Parameters.ObjectSchemaId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "PageSchemaId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "b0d3ad9f7a2746a39483ed70c26872ae", CaptionResourceItem = "Parameters.PageSchemaId.Caption", DescriptionResourceItem = "Parameters.PageSchemaId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "EditMode", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "b0d3ad9f7a2746a39483ed70c26872ae", CaptionResourceItem = "Parameters.EditMode.Caption", DescriptionResourceItem = "Parameters.EditMode.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "RecordColumnValues", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "b0d3ad9f7a2746a39483ed70c26872ae", CaptionResourceItem = "Parameters.RecordColumnValues.Caption", DescriptionResourceItem = "Parameters.RecordColumnValues.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "RecordId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "b0d3ad9f7a2746a39483ed70c26872ae", CaptionResourceItem = "Parameters.RecordId.Caption", DescriptionResourceItem = "Parameters.RecordId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ExecutedMode", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "b0d3ad9f7a2746a39483ed70c26872ae", CaptionResourceItem = "Parameters.ExecutedMode.Caption", DescriptionResourceItem = "Parameters.ExecutedMode.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "IsMatchConditions", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "b0d3ad9f7a2746a39483ed70c26872ae", CaptionResourceItem = "Parameters.IsMatchConditions.Caption", DescriptionResourceItem = "Parameters.IsMatchConditions.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "DataSourceFilters", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "b0d3ad9f7a2746a39483ed70c26872ae", CaptionResourceItem = "Parameters.DataSourceFilters.Caption", DescriptionResourceItem = "Parameters.DataSourceFilters.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "GenerateDecisionsFromColumn", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "b0d3ad9f7a2746a39483ed70c26872ae", CaptionResourceItem = "Parameters.GenerateDecisionsFromColumn.Caption", DescriptionResourceItem = "Parameters.GenerateDecisionsFromColumn.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "DecisionalColumnMetaPath", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "b0d3ad9f7a2746a39483ed70c26872ae", CaptionResourceItem = "Parameters.DecisionalColumnMetaPath.Caption", DescriptionResourceItem = "Parameters.DecisionalColumnMetaPath.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ResultParameter", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "b0d3ad9f7a2746a39483ed70c26872ae", CaptionResourceItem = "Parameters.ResultParameter.Caption", DescriptionResourceItem = "Parameters.ResultParameter.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "IsReexecution", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "b0d3ad9f7a2746a39483ed70c26872ae", CaptionResourceItem = "Parameters.IsReexecution.Caption", DescriptionResourceItem = "Parameters.IsReexecution.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Recommendation", Group = "Общие", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "b0d3ad9f7a2746a39483ed70c26872ae", CaptionResourceItem = "Parameters.Recommendation.Caption", DescriptionResourceItem = "Parameters.Recommendation.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ActivityCategory", Group = "Общие", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "b0d3ad9f7a2746a39483ed70c26872ae", CaptionResourceItem = "Parameters.ActivityCategory.Caption", DescriptionResourceItem = "Parameters.ActivityCategory.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "OwnerId", Group = "Общие", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "b0d3ad9f7a2746a39483ed70c26872ae", CaptionResourceItem = "Parameters.OwnerId.Caption", DescriptionResourceItem = "Parameters.OwnerId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Duration", Group = "Общие", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "b0d3ad9f7a2746a39483ed70c26872ae", CaptionResourceItem = "Parameters.Duration.Caption", DescriptionResourceItem = "Parameters.Duration.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "DurationPeriod", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "b0d3ad9f7a2746a39483ed70c26872ae", CaptionResourceItem = "Parameters.DurationPeriod.Caption", DescriptionResourceItem = "Parameters.DurationPeriod.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "StartIn", Group = "Общие", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "b0d3ad9f7a2746a39483ed70c26872ae", CaptionResourceItem = "Parameters.StartIn.Caption", DescriptionResourceItem = "Parameters.StartIn.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "StartInPeriod", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "b0d3ad9f7a2746a39483ed70c26872ae", CaptionResourceItem = "Parameters.StartInPeriod.Caption", DescriptionResourceItem = "Parameters.StartInPeriod.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "RemindBefore", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "b0d3ad9f7a2746a39483ed70c26872ae", CaptionResourceItem = "Parameters.RemindBefore.Caption", DescriptionResourceItem = "Parameters.RemindBefore.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "RemindBeforePeriod", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "b0d3ad9f7a2746a39483ed70c26872ae", CaptionResourceItem = "Parameters.RemindBeforePeriod.Caption", DescriptionResourceItem = "Parameters.RemindBeforePeriod.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ShowInScheduler", Group = "Общие", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "b0d3ad9f7a2746a39483ed70c26872ae", CaptionResourceItem = "Parameters.ShowInScheduler.Caption", DescriptionResourceItem = "Parameters.ShowInScheduler.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ShowExecutionPage", Group = "Общие", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "b0d3ad9f7a2746a39483ed70c26872ae", CaptionResourceItem = "Parameters.ShowExecutionPage.Caption", DescriptionResourceItem = "Parameters.ShowExecutionPage.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Lead", Group = "Взаимосвязи", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "b0d3ad9f7a2746a39483ed70c26872ae", CaptionResourceItem = "Parameters.Lead.Caption", DescriptionResourceItem = "Parameters.Lead.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Account", Group = "Взаимосвязи", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "b0d3ad9f7a2746a39483ed70c26872ae", CaptionResourceItem = "Parameters.Account.Caption", DescriptionResourceItem = "Parameters.Account.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Contact", Group = "Взаимосвязи", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "b0d3ad9f7a2746a39483ed70c26872ae", CaptionResourceItem = "Parameters.Contact.Caption", DescriptionResourceItem = "Parameters.Contact.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Opportunity", Group = "Взаимосвязи", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "b0d3ad9f7a2746a39483ed70c26872ae", CaptionResourceItem = "Parameters.Opportunity.Caption", DescriptionResourceItem = "Parameters.Opportunity.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Invoice", Group = "Взаимосвязи", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "b0d3ad9f7a2746a39483ed70c26872ae", CaptionResourceItem = "Parameters.Invoice.Caption", DescriptionResourceItem = "Parameters.Invoice.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Document", Group = "Взаимосвязи", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "b0d3ad9f7a2746a39483ed70c26872ae", CaptionResourceItem = "Parameters.Document.Caption", DescriptionResourceItem = "Parameters.Document.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Incident", Group = "Взаимосвязи", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "b0d3ad9f7a2746a39483ed70c26872ae", CaptionResourceItem = "Parameters.Incident.Caption", DescriptionResourceItem = "Parameters.Incident.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Case", Group = "Взаимосвязи", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "b0d3ad9f7a2746a39483ed70c26872ae", CaptionResourceItem = "Parameters.Case.Caption", DescriptionResourceItem = "Parameters.Case.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ActivityResult", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "b0d3ad9f7a2746a39483ed70c26872ae", CaptionResourceItem = "Parameters.ActivityResult.Caption", DescriptionResourceItem = "Parameters.ActivityResult.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "CurrentActivityId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "b0d3ad9f7a2746a39483ed70c26872ae", CaptionResourceItem = "Parameters.CurrentActivityId.Caption", DescriptionResourceItem = "Parameters.CurrentActivityId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "IsActivityCompleted", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "b0d3ad9f7a2746a39483ed70c26872ae", CaptionResourceItem = "Parameters.IsActivityCompleted.Caption", DescriptionResourceItem = "Parameters.IsActivityCompleted.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ExecutionContext", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "b0d3ad9f7a2746a39483ed70c26872ae", CaptionResourceItem = "Parameters.ExecutionContext.Caption", DescriptionResourceItem = "Parameters.ExecutionContext.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "PageTypeUId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "b0d3ad9f7a2746a39483ed70c26872ae", CaptionResourceItem = "Parameters.PageTypeUId.Caption", DescriptionResourceItem = "Parameters.PageTypeUId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ActivitySchemaUId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "b0d3ad9f7a2746a39483ed70c26872ae", CaptionResourceItem = "Parameters.ActivitySchemaUId.Caption", DescriptionResourceItem = "Parameters.ActivitySchemaUId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "InformationOnStep", Group = "Общие", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "b0d3ad9f7a2746a39483ed70c26872ae", CaptionResourceItem = "Parameters.InformationOnStep.Caption", DescriptionResourceItem = "Parameters.InformationOnStep.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Order", Group = "Взаимосвязи", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "b0d3ad9f7a2746a39483ed70c26872ae", CaptionResourceItem = "Parameters.Order.Caption", DescriptionResourceItem = "Parameters.Order.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Requests", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "b0d3ad9f7a2746a39483ed70c26872ae", CaptionResourceItem = "Parameters.Requests.Caption", DescriptionResourceItem = "Parameters.Requests.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Listing", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "b0d3ad9f7a2746a39483ed70c26872ae", CaptionResourceItem = "Parameters.Listing.Caption", DescriptionResourceItem = "Parameters.Listing.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Property", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "b0d3ad9f7a2746a39483ed70c26872ae", CaptionResourceItem = "Parameters.Property.Caption", DescriptionResourceItem = "Parameters.Property.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Contract", Group = "Взаимосвязи", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "b0d3ad9f7a2746a39483ed70c26872ae", CaptionResourceItem = "Parameters.Contract.Caption", DescriptionResourceItem = "Parameters.Contract.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Problem", Group = "Взаимосвязи", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "b0d3ad9f7a2746a39483ed70c26872ae", CaptionResourceItem = "Parameters.Problem.Caption", DescriptionResourceItem = "Parameters.Problem.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Change", Group = "Взаимосвязи", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "b0d3ad9f7a2746a39483ed70c26872ae", CaptionResourceItem = "Parameters.Change.Caption", DescriptionResourceItem = "Parameters.Change.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Release", Group = "Взаимосвязи", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "b0d3ad9f7a2746a39483ed70c26872ae", CaptionResourceItem = "Parameters.Release.Caption", DescriptionResourceItem = "Parameters.Release.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Project", Group = "Взаимосвязи", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "b0d3ad9f7a2746a39483ed70c26872ae", CaptionResourceItem = "Parameters.Project.Caption", DescriptionResourceItem = "Parameters.Project.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ActivityPriority", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "b0d3ad9f7a2746a39483ed70c26872ae", CaptionResourceItem = "Parameters.ActivityPriority.Caption", DescriptionResourceItem = "Parameters.ActivityPriority.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "CreateActivity", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "b0d3ad9f7a2746a39483ed70c26872ae", CaptionResourceItem = "Parameters.CreateActivity.Caption", DescriptionResourceItem = "Parameters.CreateActivity.Caption", UseSolutionStorage = true)]
	/// <exclude/>
	public partial class OpenEditPageUserTask : ProcessUserTask
	{

		#region Constructors: Public

		public OpenEditPageUserTask(UserConnection userConnection)
			: base(userConnection) {
			SchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae");
		}

		#endregion

		#region Properties: Public

		public virtual Guid ObjectSchemaId {
			get;
			set;
		}

		public virtual Guid PageSchemaId {
			get;
			set;
		}

		public virtual int EditMode {
			get;
			set;
		}

		private EntityColumnMappingValues _recordColumnValues;
		public virtual EntityColumnMappingValues RecordColumnValues {
			get {
				return _recordColumnValues ?? ( _recordColumnValues = new EntityColumnMappingValues (
					new Dictionary<string, object>(),
					new Dictionary<string, string>()));
			}
			set {
				_recordColumnValues = value;
			}
		}

		public virtual Guid RecordId {
			get;
			set;
		}

		public virtual int ExecutedMode {
			get;
			set;
		}

		public virtual bool IsMatchConditions {
			get;
			set;
		}

		public virtual string DataSourceFilters {
			get;
			set;
		}

		public virtual bool GenerateDecisionsFromColumn {
			get;
			set;
		}

		public virtual string DecisionalColumnMetaPath {
			get;
			set;
		}

		public virtual Guid ResultParameter {
			get;
			set;
		}

		public virtual bool IsReexecution {
			get;
			set;
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

		public virtual Guid PageTypeUId {
			get;
			set;
		}

		public virtual Guid ActivitySchemaUId {
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

		public virtual Guid Project {
			get;
			set;
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
			if (!HasMapping("ObjectSchemaId")) {
				writer.WriteValue("ObjectSchemaId", ObjectSchemaId, Guid.Empty);
			}
			if (!HasMapping("PageSchemaId")) {
				writer.WriteValue("PageSchemaId", PageSchemaId, Guid.Empty);
			}
			if (!HasMapping("EditMode")) {
				writer.WriteValue("EditMode", EditMode, 0);
			}
			if (!HasMapping("RecordId")) {
				writer.WriteValue("RecordId", RecordId, Guid.Empty);
			}
			if (!HasMapping("ExecutedMode")) {
				writer.WriteValue("ExecutedMode", ExecutedMode, 0);
			}
			if (!HasMapping("IsMatchConditions")) {
				writer.WriteValue("IsMatchConditions", IsMatchConditions, false);
			}
			if (!HasMapping("DataSourceFilters")) {
				writer.WriteValue("DataSourceFilters", DataSourceFilters, null);
			}
			if (!HasMapping("GenerateDecisionsFromColumn")) {
				writer.WriteValue("GenerateDecisionsFromColumn", GenerateDecisionsFromColumn, false);
			}
			if (!HasMapping("DecisionalColumnMetaPath")) {
				writer.WriteValue("DecisionalColumnMetaPath", DecisionalColumnMetaPath, null);
			}
			if (!HasMapping("ResultParameter")) {
				writer.WriteValue("ResultParameter", ResultParameter, Guid.Empty);
			}
			if (!HasMapping("IsReexecution")) {
				writer.WriteValue("IsReexecution", IsReexecution, false);
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
			if (!HasMapping("PageTypeUId")) {
				writer.WriteValue("PageTypeUId", PageTypeUId, Guid.Empty);
			}
			if (UseFlowEngineMode) {
				if (!HasMapping("ActivitySchemaUId")) {
					writer.WriteValue("ActivitySchemaUId", ActivitySchemaUId, Guid.Empty);
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
			if (!HasMapping("Problem")) {
				writer.WriteValue("Problem", Problem, Guid.Empty);
			}
			if (!HasMapping("Change")) {
				writer.WriteValue("Change", Change, Guid.Empty);
			}
			if (!HasMapping("Release")) {
				writer.WriteValue("Release", Release, Guid.Empty);
			}
			if (!HasMapping("Project")) {
				writer.WriteValue("Project", Project, Guid.Empty);
			}
			if (!HasMapping("ActivityPriority")) {
				writer.WriteValue("ActivityPriority", ActivityPriority, Guid.Empty);
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
				case "ObjectSchemaId":
					ObjectSchemaId = reader.GetGuidValue();
				break;
				case "PageSchemaId":
					PageSchemaId = reader.GetGuidValue();
				break;
				case "EditMode":
					EditMode = reader.GetIntValue();
				break;
				case "RecordColumnValues":
					if (UseFlowEngineMode) {
						RecordColumnValues = reader.GetValue<EntityColumnMappingValues>();
					}
				break;
				case "RecordId":
					RecordId = reader.GetGuidValue();
				break;
				case "ExecutedMode":
					ExecutedMode = reader.GetIntValue();
				break;
				case "IsMatchConditions":
					IsMatchConditions = reader.GetBoolValue();
				break;
				case "DataSourceFilters":
					DataSourceFilters = reader.GetStringValue();
				break;
				case "GenerateDecisionsFromColumn":
					GenerateDecisionsFromColumn = reader.GetBoolValue();
				break;
				case "DecisionalColumnMetaPath":
					DecisionalColumnMetaPath = reader.GetStringValue();
				break;
				case "ResultParameter":
					ResultParameter = reader.GetGuidValue();
				break;
				case "IsReexecution":
					IsReexecution = reader.GetBoolValue();
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
				case "PageTypeUId":
					PageTypeUId = reader.GetGuidValue();
				break;
				case "ActivitySchemaUId":
					if (!UseFlowEngineMode) {
						break;
					}
					ActivitySchemaUId = reader.GetGuidValue();
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
				case "Problem":
					Problem = reader.GetGuidValue();
				break;
				case "Change":
					Change = reader.GetGuidValue();
				break;
				case "Release":
					Release = reader.GetGuidValue();
				break;
				case "Project":
					Project = reader.GetGuidValue();
				break;
				case "ActivityPriority":
					ActivityPriority = reader.GetGuidValue();
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

