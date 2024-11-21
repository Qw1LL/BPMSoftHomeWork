namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Newtonsoft.Json;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Process;

	#region Class: EmailConditionalTransitionElement

	[DesignModeProperty(Name = "EmailResponseId",
		UsageType = DesignModeUsageType.NotVisible, MetaPropertyName = EmailResponseIdPropertyName)]
	[DesignModeProperty(Name = "IsResponseBasedStart",
		UsageType = DesignModeUsageType.Advanced, MetaPropertyName = IsResponseBasedStartPropertyName)]
	[DesignModeProperty(Name = "HyperlinkId",
		UsageType = DesignModeUsageType.NotVisible, MetaPropertyName = HyperlinkIdPropertyName)]
	[DesignModeProperty(Name = "HyperlinkTrackId",
		UsageType = DesignModeUsageType.NotVisible, MetaPropertyName = HyperlinkTrackIdPropertyName)]
	public class EmailConditionalTransitionElement : ConditionalSequenceFlowElement
	{

		#region Constants: Private

		private const string EmailResponseIdPropertyName = "EmailResponseId";
		private const string IsResponseBasedStartPropertyName = "IsResponseBasedStart";
		private const string HyperlinkIdPropertyName = "HyperlinkId";
		private const string HyperlinkTrackIdPropertyName = "HyperlinkTrackId";

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Default ctor
		/// </summary>
		public EmailConditionalTransitionElement() {

		}

		/// <summary>
		/// Constructor of the clone.
		/// </summary>
		/// <param name="source">Instance of <see cref="EmailConditionalTransitionElement"/>.</param>
		public EmailConditionalTransitionElement(EmailConditionalTransitionElement source)
			: this(source, null, null) {
		}

		/// <summary>
		/// Constructor of the copy.
		/// </summary>
		/// <param name="source">Instance of <see cref="EmailConditionalTransitionElement"/>.</param>
		/// <param name="dictToRebind">Dictionary to rebind schema elements' ids.</param>
		/// <param name="parentSchema">Parent campaign schema.</param>
		public EmailConditionalTransitionElement(EmailConditionalTransitionElement source,
				Dictionary<Guid, Guid> dictToRebind, Core.Campaign.CampaignSchema parentSchema)
					: base(source, dictToRebind, parentSchema) {
			IsResponseBasedStart = source.IsResponseBasedStart;
			_emailResponseIdJson = JsonConvert.SerializeObject(source.EmailResponseId);
			_hyperlinkIdJson = JsonConvert.SerializeObject(source.HyperlinkId);
			_hyperlinkTrackIdJson = JsonConvert.SerializeObject(source.HyperlinkTrackId);
		}

		#endregion

		#region Fields: Private

		/// <summary>
		/// String representation of selected hyperlink ids
		/// </summary>
		private string _hyperlinkIdJson;

		/// <summary>
		/// String representation of selected hyperlink track ids
		/// </summary>
		private string _hyperlinkTrackIdJson;

		/// <summary>
		/// String representation of response ids
		/// </summary>
		private string _emailResponseIdJson;

		#endregion

		#region Properties: Public

		/// <summary>
		/// Collection of selected email response ids
		/// </summary>
		[MetaTypeProperty("{DC597899-B831-458A-A58E-FB43B1E266AC}")]
		public IEnumerable<Guid> EmailResponseId {
			get => IsResponseBasedStart && !string.IsNullOrWhiteSpace(_emailResponseIdJson)
				? JsonConvert.DeserializeObject<IEnumerable<Guid>>(_emailResponseIdJson)
				: Enumerable.Empty<Guid>();
		}

		/// <summary>
		/// Is transition response based
		/// </summary>
		[MetaTypeProperty("{3FFA4EA0-62CC-49A8-91FF-4096AEC561F6}", IsExtraProperty = true,
			IsUserProperty = true)]
		public virtual bool IsResponseBasedStart { get; set; }

		/// <summary>
		/// Collection of selected hyperlink ids
		/// </summary>
		[MetaTypeProperty("{DC597899-B831-458A-A58E-FB43B1E266AC}")]
		public IEnumerable<Guid> HyperlinkId {
			get =>  IsResponseBasedStart && !string.IsNullOrWhiteSpace(_hyperlinkIdJson)
				? JsonConvert.DeserializeObject<IEnumerable<Guid>>(_hyperlinkIdJson)
				: Enumerable.Empty<Guid>();
			set => _hyperlinkIdJson = JsonConvert.SerializeObject(value);
		}

		/// <summary>
		/// Collection of selected hyperlink track ids
		/// </summary>
		[MetaTypeProperty("{3E0D3F32-3131-4E1C-A7AC-A037F6B5C136}")]
		public IEnumerable<int> HyperlinkTrackId {
			get =>  IsResponseBasedStart && !string.IsNullOrWhiteSpace(_hyperlinkTrackIdJson)
				? JsonConvert.DeserializeObject<IEnumerable<int>>(_hyperlinkTrackIdJson)
				: Enumerable.Empty<int>();
			set => _hyperlinkTrackIdJson = JsonConvert.SerializeObject(value);
		}

		/// <summary>
		/// Unique identifier of the bulk email.
		/// </summary>
		public Guid BulkEmailId {
			get {
				var marketingEmailElement = SourceRef as MarketingEmailElement;
				return marketingEmailElement != null ? marketingEmailElement.MarketingEmailId : default(Guid);
			}
		}

		/// <summary>
		/// Priority of the transition.
		/// </summary>
		public override int Priority {
			get => HyperlinkId.IsNotEmpty() || EmailResponseId.IsNotEmpty() || HyperlinkTrackId.IsNotEmpty()
				? ConditionalFlowPriority
				: base.Priority;
			set => base.Priority = value;
		}

		#endregion

		#region Methods: Private

		private bool HasResponseConditions() => EmailResponseId.Any() || HyperlinkId.Any() || HyperlinkTrackId.Any();

		#endregion

		#region Methods: Protected

		/// <summary>
		/// The overriden metadata reader.
		/// </summary>
		protected override void ApplyMetaDataValue(DataReader reader) {
			base.ApplyMetaDataValue(reader);
			switch (reader.CurrentName) {
				case EmailResponseIdPropertyName:
					_emailResponseIdJson = reader.GetValue<string>();
					break;
				case IsResponseBasedStartPropertyName:
					IsResponseBasedStart = reader.GetBoolValue();
					break;
				case HyperlinkIdPropertyName:
					_hyperlinkIdJson = reader.GetValue<string>();
					break;
				case HyperlinkTrackIdPropertyName:
					_hyperlinkTrackIdJson = reader.GetValue<string>();
					break;
				default:
					break;
			}
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Defines if transition can be processed at a specified time. 
		/// </summary>
		/// <param name="time"><see cref="TimeSpan"/> to check. Contains the whole date and time by UTC.</param>
		/// <returns>False if has any clicks or response conditions.</returns>
		public override bool CanProcessAt(TimeSpan time) {
			var isInFragment = SessionId != default(Guid);
			return (isInFragment && HasResponseConditions()) ? false : base.CanProcessAt(time);
		}

		/// <summary>
		/// Writes meta data values.
		/// </summary>
		/// <param name="writer">Instance of the <see cref="DataWriter"/> type.</param>
		public override void WriteMetaData(DataWriter writer) {
			base.WriteMetaData(writer);
			writer.WriteValue(IsResponseBasedStartPropertyName, IsResponseBasedStart, false);
			writer.WriteValue(HyperlinkIdPropertyName, _hyperlinkIdJson, null);
			writer.WriteValue(HyperlinkTrackIdPropertyName, _hyperlinkTrackIdJson, null);
			writer.WriteValue(EmailResponseIdPropertyName, _emailResponseIdJson, null);
		}

		/// <summary>
		/// Creates a new instance that is a clone of the current instance.
		/// </summary>
		/// <returns>Cloned instance of the EmailConditionalTransitionElement.</returns>
		public override object Clone() {
			return new EmailConditionalTransitionElement(this);
		}

		/// <summary>
		/// Creates a new instance that is a copy of the current instance.
		/// </summary>
		/// <param name="dictToRebind">Dictionary to rebind schema elements' ids.</param>
		/// <param name="parentSchema">Parent campaign schema.</param>
		/// <returns>Copied instance of the EmailConditionalTransitionElement.</returns>
		public override object Copy(Dictionary<Guid, Guid> dictToRebind, Core.Campaign.CampaignSchema parentSchema) {
			return new EmailConditionalTransitionElement(this, dictToRebind, parentSchema);
		}

		/// <summary>
		/// Creates executable instance of email conditional transition.
		/// </summary>
		public override ProcessFlowElement CreateProcessFlowElement(UserConnection userConnection) {
			var executableElement = new EmailConditionalTransitionFlowElement {
				UserConnection = userConnection,
				BulkEmailId = BulkEmailId,
				EmailResponses = EmailResponseId,
				Hyperlinks = HyperlinkId,
				BpmTrackIds = HyperlinkTrackId
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

