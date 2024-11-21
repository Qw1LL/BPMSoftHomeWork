namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Newtonsoft.Json;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Process;
	using CoreCampaignSchema = BPMSoft.Core.Campaign.CampaignSchema;

	#region Class: EventConditionalTransitionElement

	[DesignModeProperty(Name = "EventResponseCollection",
		UsageType = DesignModeUsageType.NotVisible, MetaPropertyName = EventResponseCollectionPropertyName)]
	[DesignModeProperty(Name = "HasResponseCondition",
		UsageType = DesignModeUsageType.Advanced, MetaPropertyName = HasResponseConditionPropertyName)]
	public class EventConditionalTransitionElement : ConditionalSequenceFlowElement
	{

		#region Constants: Private

		private const string EventResponseCollectionPropertyName = "EventResponseCollection";
		private const string HasResponseConditionPropertyName = "HasResponseCondition";

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Default consructor.
		/// </summary>
		public EventConditionalTransitionElement() {
		}

		/// <summary>
		/// Constructor of the clone.
		/// </summary>
		/// <param name="source">Instance of <see cref="EventConditionalTransitionElement"/>.</param>
		public EventConditionalTransitionElement(EventConditionalTransitionElement source)
			: this(source, null, null) {
		}

		/// <summary>
		/// Constructor of the copy.
		/// </summary>
		/// <param name="source">Instance of <see cref="EventConditionalTransitionElement"/>.</param>
		/// <param name="dictToRebind">Dictionary to rebind schema elements' ids.</param>
		/// <param name="parentSchema">Parent campaign schema.</param>
		public EventConditionalTransitionElement(EventConditionalTransitionElement source,
				Dictionary<Guid, Guid> dictToRebind, CoreCampaignSchema parentSchema)
					: base(source, dictToRebind, parentSchema) {
			HasResponseCondition = source.HasResponseCondition;
			_eventResponseCollectionJson = JsonConvert.SerializeObject(source.EventResponseCollection);
		}

		#endregion

		#region Fields: Private

		/// <summary>
		/// String representation of selected response ids.
		/// </summary>
		private string _eventResponseCollectionJson;

		#endregion

		#region Properties: Public

		/// <summary>
		/// Collection of selected event response ids.
		/// </summary>
		[MetaTypeProperty("{60FAC265-3832-42A9-A224-366B6344B8BA}")]
		public IEnumerable<Guid> EventResponseCollection {
			get => HasResponseCondition && !string.IsNullOrWhiteSpace(_eventResponseCollectionJson)
				? JsonConvert.DeserializeObject<IEnumerable<Guid>>(_eventResponseCollectionJson)
				: Enumerable.Empty<Guid>();
		}

		/// <summary>
		/// Indicates that transition has collection of selected response ids.
		/// </summary>
		[MetaTypeProperty("{168E233B-745C-4D1D-AE72-BD6C39CF3B13}", IsExtraProperty = true,
			IsUserProperty = true)]
		public virtual bool HasResponseCondition { get; set; }

		/// <summary>
		/// Unique identifier of the event.
		/// </summary>
		public Guid EventId {
			get {
				var campaignEventElement = SourceRef as ICampaignEventElement;
				return campaignEventElement != null ? campaignEventElement.EventId : default(Guid);
			}
		}

		/// <summary>
		/// Priority of the transition.
		/// </summary>
		public override int Priority {
			get => HasResponseCondition && EventResponseCollection.IsNotEmpty()
				? ConditionalFlowPriority
				: base.Priority;
			set => base.Priority = value;
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// The overriden metadata reader.
		/// </summary>
		protected override void ApplyMetaDataValue(DataReader reader) {
			base.ApplyMetaDataValue(reader);
			switch (reader.CurrentName) {
				case EventResponseCollectionPropertyName:
					_eventResponseCollectionJson = reader.GetValue<string>();
					break;
				case HasResponseConditionPropertyName:
					HasResponseCondition = reader.GetBoolValue();
					break;
				default:
					break;
			}
		}

		#endregion

		#region Methods: Private

		#endregion

		#region Methods: Public

		/// <summary>
		/// Writes meta data values.
		/// </summary>
		/// <param name="writer">Instance of the <see cref="DataWriter"/> type.</param>
		public override void WriteMetaData(DataWriter writer) {
			base.WriteMetaData(writer);
			writer.WriteValue(HasResponseConditionPropertyName, HasResponseCondition, false);
			writer.WriteValue(EventResponseCollectionPropertyName, _eventResponseCollectionJson, null);
		}

		/// <summary>
		/// Creates a new instance that is a clone of the current instance.
		/// </summary>
		/// <returns>Cloned instance of the EventConditionalTransitionElement.</returns>
		public override object Clone() {
			return new EventConditionalTransitionElement(this);
		}

		/// <summary>
		/// Creates a new instance that is a copy of the current instance.
		/// </summary>
		/// <param name="dictToRebind">Dictionary to rebind schema elements' ids.</param>
		/// <param name="parentSchema">Parent campaign schema.</param>
		/// <returns>Copied instance of the EventConditionalTransitionElement.</returns>
		public override object Copy(Dictionary<Guid, Guid> dictToRebind, CoreCampaignSchema parentSchema) {
			return new EventConditionalTransitionElement(this, dictToRebind, parentSchema);
		}

		/// <summary>
		/// Creates executable instance of event conditional transition.
		/// </summary>
		public override ProcessFlowElement CreateProcessFlowElement(UserConnection userConnection) {
			var executableElement = new EventConditionalTransitionFlowElement {
				UserConnection = userConnection,
				EventId = EventId,
				EventResponses = EventResponseCollection
			};
			InitializeCampaignProcessFlowElement(executableElement);
			InitializeCampaignTransitionFlowElement(executableElement);
			InitializeConditionalTransitionFlowElement(executableElement);
			InitializeAudienceSchemaInfo(executableElement, userConnection);
			return executableElement;
		}

		#endregion

	}

	#endregion

}

