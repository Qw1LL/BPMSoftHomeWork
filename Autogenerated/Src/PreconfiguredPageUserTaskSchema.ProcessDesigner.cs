namespace BPMSoft.Core.Process.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Configuration;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Process;
	using BPMSoft.Nui.ServiceModel.DataContract;
	using BPMSoft.Nui.ServiceModel.Extensions;
	using BPMSoft.UI.WebControls.Controls;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using System.Runtime.Serialization.Formatters;
	using System.Text;

	#region Class: PreconfiguredPageUserTask

	[DesignModeGroup(Name = "Общие", Position = 1, UseSolutionStorage = true, ResourceManager = "ac2ef13c30dd40239c0458f580743b48", CaptionResourceItem = "Parameters.Recommendation.Group", DescriptionResourceItem = "Parameters.Recommendation.Group")]
	[DesignModeProperty(Name = "Title", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "ac2ef13c30dd40239c0458f580743b48", CaptionResourceItem = "Parameters.Title.Caption", DescriptionResourceItem = "Parameters.Title.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Recommendation", Group = "Общие", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "ac2ef13c30dd40239c0458f580743b48", CaptionResourceItem = "Parameters.Recommendation.Caption", DescriptionResourceItem = "Parameters.Recommendation.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ClientUnitSchemaUId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "ac2ef13c30dd40239c0458f580743b48", CaptionResourceItem = "Parameters.ClientUnitSchemaUId.Caption", DescriptionResourceItem = "Parameters.ClientUnitSchemaUId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "EntityId", Group = "Общие", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "ac2ef13c30dd40239c0458f580743b48", CaptionResourceItem = "Parameters.EntityId.Caption", DescriptionResourceItem = "Parameters.EntityId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "EntryPointId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "ac2ef13c30dd40239c0458f580743b48", CaptionResourceItem = "Parameters.EntryPointId.Caption", DescriptionResourceItem = "Parameters.EntryPointId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "EntitySchemaUId", Group = "Общие", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "ac2ef13c30dd40239c0458f580743b48", CaptionResourceItem = "Parameters.EntitySchemaUId.Caption", DescriptionResourceItem = "Parameters.EntitySchemaUId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "UseCardProcessModule", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "ac2ef13c30dd40239c0458f580743b48", CaptionResourceItem = "Parameters.UseCardProcessModule.Caption", DescriptionResourceItem = "Parameters.UseCardProcessModule.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "OwnerId", Group = "Общие", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "ac2ef13c30dd40239c0458f580743b48", CaptionResourceItem = "Parameters.OwnerId.Caption", DescriptionResourceItem = "Parameters.OwnerId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ShowExecutionPage", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "ac2ef13c30dd40239c0458f580743b48", CaptionResourceItem = "Parameters.ShowExecutionPage.Caption", DescriptionResourceItem = "Parameters.ShowExecutionPage.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "InformationOnStep", Group = "Общие", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "ac2ef13c30dd40239c0458f580743b48", CaptionResourceItem = "Parameters.InformationOnStep.Caption", DescriptionResourceItem = "Parameters.InformationOnStep.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "IsRunning", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "ac2ef13c30dd40239c0458f580743b48", CaptionResourceItem = "Parameters.IsRunning.Caption", DescriptionResourceItem = "Parameters.IsRunning.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Template", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "ac2ef13c30dd40239c0458f580743b48", CaptionResourceItem = "Parameters.Template.Caption", DescriptionResourceItem = "Parameters.Template.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Module", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "ac2ef13c30dd40239c0458f580743b48", CaptionResourceItem = "Parameters.Module.Caption", DescriptionResourceItem = "Parameters.Module.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "PressedButtonCode", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "ac2ef13c30dd40239c0458f580743b48", CaptionResourceItem = "Parameters.PressedButtonCode.Caption", DescriptionResourceItem = "Parameters.PressedButtonCode.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Url", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "ac2ef13c30dd40239c0458f580743b48", CaptionResourceItem = "Parameters.Url.Caption", DescriptionResourceItem = "Parameters.Url.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "CurrentActivityId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "ac2ef13c30dd40239c0458f580743b48", CaptionResourceItem = "Parameters.CurrentActivityId.Caption", DescriptionResourceItem = "Parameters.CurrentActivityId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "CreateActivity", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "ac2ef13c30dd40239c0458f580743b48", CaptionResourceItem = "Parameters.CreateActivity.Caption", DescriptionResourceItem = "Parameters.CreateActivity.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ActivityPriority", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "ac2ef13c30dd40239c0458f580743b48", CaptionResourceItem = "Parameters.ActivityPriority.Caption", DescriptionResourceItem = "Parameters.ActivityPriority.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "StartIn", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "ac2ef13c30dd40239c0458f580743b48", CaptionResourceItem = "Parameters.StartIn.Caption", DescriptionResourceItem = "Parameters.StartIn.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "StartInPeriod", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "ac2ef13c30dd40239c0458f580743b48", CaptionResourceItem = "Parameters.StartInPeriod.Caption", DescriptionResourceItem = "Parameters.StartInPeriod.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Duration", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "ac2ef13c30dd40239c0458f580743b48", CaptionResourceItem = "Parameters.Duration.Caption", DescriptionResourceItem = "Parameters.Duration.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "DurationPeriod", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "ac2ef13c30dd40239c0458f580743b48", CaptionResourceItem = "Parameters.DurationPeriod.Caption", DescriptionResourceItem = "Parameters.DurationPeriod.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ShowInScheduler", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "ac2ef13c30dd40239c0458f580743b48", CaptionResourceItem = "Parameters.ShowInScheduler.Caption", DescriptionResourceItem = "Parameters.ShowInScheduler.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "RemindBefore", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "ac2ef13c30dd40239c0458f580743b48", CaptionResourceItem = "Parameters.RemindBefore.Caption", DescriptionResourceItem = "Parameters.RemindBefore.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "RemindBeforePeriod", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "ac2ef13c30dd40239c0458f580743b48", CaptionResourceItem = "Parameters.RemindBeforePeriod.Caption", DescriptionResourceItem = "Parameters.RemindBeforePeriod.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ActivityResult", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "ac2ef13c30dd40239c0458f580743b48", CaptionResourceItem = "Parameters.ActivityResult.Caption", DescriptionResourceItem = "Parameters.ActivityResult.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "IsActivityCompleted", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "ac2ef13c30dd40239c0458f580743b48", CaptionResourceItem = "Parameters.IsActivityCompleted.Caption", DescriptionResourceItem = "Parameters.IsActivityCompleted.Caption", UseSolutionStorage = true)]
	/// <exclude/>
	public partial class PreconfiguredPageUserTask : ProcessUserTask
	{

		#region Constructors: Public

		public PreconfiguredPageUserTask(UserConnection userConnection)
			: base(userConnection) {
			SchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48");
			_template = () => { return new Guid("21620f25-166f-42f1-8b4d-224a959040a3"); };
			_module = () => { return new Guid("eb89c336-08b9-4951-bffd-3f5abc433174"); };
			_url = () => { return "[Module]/[Page]/add"; };
		}

		#endregion

		#region Properties: Public

		private LocalizableString _title;
		public virtual LocalizableString Title {
			get {
				return _title ?? (_title = new LocalizableString());
			}
			set {
				_title = value;
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

		public virtual Guid ClientUnitSchemaUId {
			get;
			set;
		}

		public virtual Guid EntityId {
			get;
			set;
		}

		public virtual Guid EntryPointId {
			get;
			set;
		}

		public virtual Guid EntitySchemaUId {
			get;
			set;
		}

		private bool _useCardProcessModule = false;
		public virtual bool UseCardProcessModule {
			get {
				return _useCardProcessModule;
			}
			set {
				_useCardProcessModule = value;
			}
		}

		public virtual Guid OwnerId {
			get;
			set;
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

		private LocalizableString _informationOnStep;
		public virtual LocalizableString InformationOnStep {
			get {
				return _informationOnStep ?? (_informationOnStep = new LocalizableString());
			}
			set {
				_informationOnStep = value;
			}
		}

		public virtual bool IsRunning {
			get;
			set;
		}

		private Func<Guid> _template;
		public virtual Guid Template {
			get {
				return (_template ?? (_template = () => Guid.Empty)).Invoke();
			}
			set {
				_template = () => { return value; };
			}
		}

		private Func<Guid> _module;
		public virtual Guid Module {
			get {
				return (_module ?? (_module = () => Guid.Empty)).Invoke();
			}
			set {
				_module = () => { return value; };
			}
		}

		public virtual string PressedButtonCode {
			get;
			set;
		}

		private Func<string> _url;
		public virtual string Url {
			get {
				return (_url ?? (_url = () => null)).Invoke();
			}
			set {
				_url = () => { return value; };
			}
		}

		public virtual Guid CurrentActivityId {
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

		private bool _showInScheduler = false;
		public virtual bool ShowInScheduler {
			get {
				return _showInScheduler;
			}
			set {
				_showInScheduler = value;
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

		public virtual Guid ActivityResult {
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

		#endregion

		#region Methods: Public

		public override void WritePropertiesData(DataWriter writer) {
			writer.WriteStartObject(Name);
			base.WritePropertiesData(writer);
			if (Status == Core.Process.ProcessStatus.Inactive) {
				writer.WriteFinishObject();
				return;
			}
			if (!HasMapping("ClientUnitSchemaUId")) {
				writer.WriteValue("ClientUnitSchemaUId", ClientUnitSchemaUId, Guid.Empty);
			}
			if (!HasMapping("EntityId")) {
				writer.WriteValue("EntityId", EntityId, Guid.Empty);
			}
			if (!HasMapping("EntryPointId")) {
				writer.WriteValue("EntryPointId", EntryPointId, Guid.Empty);
			}
			if (!HasMapping("EntitySchemaUId")) {
				writer.WriteValue("EntitySchemaUId", EntitySchemaUId, Guid.Empty);
			}
			if (!HasMapping("UseCardProcessModule")) {
				writer.WriteValue("UseCardProcessModule", UseCardProcessModule, false);
			}
			if (!HasMapping("OwnerId")) {
				writer.WriteValue("OwnerId", OwnerId, Guid.Empty);
			}
			if (!HasMapping("ShowExecutionPage")) {
				writer.WriteValue("ShowExecutionPage", ShowExecutionPage, false);
			}
			if (!HasMapping("IsRunning")) {
				writer.WriteValue("IsRunning", IsRunning, false);
			}
			if (!HasMapping("Template")) {
				writer.WriteValue("Template", Template, Guid.Empty);
			}
			if (!HasMapping("Module")) {
				writer.WriteValue("Module", Module, Guid.Empty);
			}
			if (!HasMapping("PressedButtonCode")) {
				writer.WriteValue("PressedButtonCode", PressedButtonCode, null);
			}
			if (!HasMapping("Url")) {
				writer.WriteValue("Url", Url, null);
			}
			if (!HasMapping("CurrentActivityId")) {
				writer.WriteValue("CurrentActivityId", CurrentActivityId, Guid.Empty);
			}
			if (!HasMapping("CreateActivity")) {
				writer.WriteValue("CreateActivity", CreateActivity, false);
			}
			if (!HasMapping("ActivityPriority")) {
				writer.WriteValue("ActivityPriority", ActivityPriority, Guid.Empty);
			}
			if (!HasMapping("StartIn")) {
				writer.WriteValue("StartIn", StartIn, 0);
			}
			if (!HasMapping("StartInPeriod")) {
				writer.WriteValue("StartInPeriod", StartInPeriod, 0);
			}
			if (!HasMapping("Duration")) {
				writer.WriteValue("Duration", Duration, 0);
			}
			if (!HasMapping("DurationPeriod")) {
				writer.WriteValue("DurationPeriod", DurationPeriod, 0);
			}
			if (!HasMapping("ShowInScheduler")) {
				writer.WriteValue("ShowInScheduler", ShowInScheduler, false);
			}
			if (!HasMapping("RemindBefore")) {
				writer.WriteValue("RemindBefore", RemindBefore, 0);
			}
			if (!HasMapping("RemindBeforePeriod")) {
				writer.WriteValue("RemindBeforePeriod", RemindBeforePeriod, 0);
			}
			if (!HasMapping("ActivityResult")) {
				writer.WriteValue("ActivityResult", ActivityResult, Guid.Empty);
			}
			if (!HasMapping("IsActivityCompleted")) {
				writer.WriteValue("IsActivityCompleted", IsActivityCompleted, false);
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
				case "Title":
					Title = reader.GetLocalizableStringValue();
				break;
				case "Recommendation":
					Recommendation = reader.GetLocalizableStringValue();
				break;
				case "ClientUnitSchemaUId":
					ClientUnitSchemaUId = reader.GetGuidValue();
				break;
				case "EntityId":
					EntityId = reader.GetGuidValue();
				break;
				case "EntryPointId":
					EntryPointId = reader.GetGuidValue();
				break;
				case "EntitySchemaUId":
					EntitySchemaUId = reader.GetGuidValue();
				break;
				case "UseCardProcessModule":
					UseCardProcessModule = reader.GetBoolValue();
				break;
				case "OwnerId":
					OwnerId = reader.GetGuidValue();
				break;
				case "ShowExecutionPage":
					ShowExecutionPage = reader.GetBoolValue();
				break;
				case "InformationOnStep":
					InformationOnStep = reader.GetLocalizableStringValue();
				break;
				case "IsRunning":
					IsRunning = reader.GetBoolValue();
				break;
				case "Template":
					Template = reader.GetGuidValue();
				break;
				case "Module":
					Module = reader.GetGuidValue();
				break;
				case "PressedButtonCode":
					PressedButtonCode = reader.GetStringValue();
				break;
				case "Url":
					Url = reader.GetStringValue();
				break;
				case "CurrentActivityId":
					CurrentActivityId = reader.GetGuidValue();
				break;
				case "CreateActivity":
					CreateActivity = reader.GetBoolValue();
				break;
				case "ActivityPriority":
					ActivityPriority = reader.GetGuidValue();
				break;
				case "StartIn":
					StartIn = reader.GetIntValue();
				break;
				case "StartInPeriod":
					StartInPeriod = reader.GetIntValue();
				break;
				case "Duration":
					Duration = reader.GetIntValue();
				break;
				case "DurationPeriod":
					DurationPeriod = reader.GetIntValue();
				break;
				case "ShowInScheduler":
					ShowInScheduler = reader.GetBoolValue();
				break;
				case "RemindBefore":
					RemindBefore = reader.GetIntValue();
				break;
				case "RemindBeforePeriod":
					RemindBeforePeriod = reader.GetIntValue();
				break;
				case "ActivityResult":
					ActivityResult = reader.GetGuidValue();
				break;
				case "IsActivityCompleted":
					IsActivityCompleted = reader.GetBoolValue();
				break;
			}
		}

		#endregion

	}

	#endregion

}

