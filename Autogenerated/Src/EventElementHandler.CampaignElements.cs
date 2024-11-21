namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Linq;
	using BPMSoft.Common;
	using BPMSoft.Core.Attributes;
	using BPMSoft.Core.Campaign;
	using BPMSoft.Core.Campaign.EventHandler;
	using CoreCampaignSchema = Core.Campaign.CampaignSchema;

	#region Class: EventElementHandler

	/// <summary>
	/// Contains methods for maintaining event elements in campaign.
	/// </summary>
	public sealed class EventElementHandler : EventElementHandlerBase, IOnCampaignCopy, IOnCampaignAfterSave
	{

		#region Properties: Protected

		protected override string ElementHandlerName => nameof(EventElementHandler);

		#endregion

		#region Methods: Protected

		protected override IEnumerable<CampaignSchemaElement> GetEventElements(CoreCampaignSchema schema) {
			return schema.FlowElements.OfType<CampaignBaseEventElement>();
		}

		/// <summary>
		/// Retrieves event identifier from the campaign element.
		/// </summary>
		protected override Guid GetEventId(CampaignSchemaElement element) {
			var eventElement = element as CampaignBaseEventElement;
			return eventElement == null
				? Guid.Empty
				: eventElement.EventId;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Updates connected records info (RecordId and SchemaUId fields) after campaign has been copied.
		/// </summary>
		[Order(2)]
		public void OnCopy() {
			HandleCopy();
		}

		/// <summary>
		/// Updates connected records info (RecordId and SchemaUId fields) after campaign has been saved.
		/// </summary>
		public void OnAfterSave() {
			HandleAfterSave();
		}

		#endregion

	}

	#endregion

	#region Class: StartEventElementHandler

	/// <summary>
	/// Contains methods for maintaining start event elements in campaign.
	/// </summary>
	public sealed class StartEventElementHandler : EventElementHandlerBase, IOnCampaignCopy, IOnCampaignAfterSave
	{

		#region Properties: Protected

		/// <summary>
		/// Handler's name for logging.
		/// </summary>
		protected override string ElementHandlerName => nameof(StartEventElementHandler);

		#endregion

		#region Methods: Protected

		protected override IEnumerable<CampaignSchemaElement> GetEventElements(CoreCampaignSchema schema) {
			return schema.FlowElements.OfType<CampaignStartEventElement>();
		}

		/// <summary>
		/// Retrieves event identifier from the campaign element.
		/// </summary>
		protected override Guid GetEventId(CampaignSchemaElement element) {
			var eventElement = element as CampaignStartEventElement;
			return eventElement == null
				? Guid.Empty
				: eventElement.EventId;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Updates connected records info (RecordId and SchemaUId fields) after campaign has been copied.
		/// </summary>
		[Order(1)]
		public void OnCopy() {
			HandleCopy();
		}

		/// <summary>
		/// Updates connected records info (RecordId and SchemaUId fields) after campaign has been saved.
		/// </summary>
		[Order(-3)]
		public void OnAfterSave() {
			HandleAfterSave();
		}

		#endregion

	}

	#endregion

	#region Class: EventElementHandlerBase

	/// <summary>
	/// Contains base methods for maintaining event and start event elements in campaign.
	/// </summary>
	public abstract class EventElementHandlerBase : CampaignEventHandlerBase
	{

		#region Fields: Private

		private Guid _eventSchemaUId = new Guid("5B4FDFC7-12B6-4B4F-A9BD-B6F1B6E4447F");

		#endregion

		#region Properties: Protected

		/// <summary>
		/// Handler's name for logging.
		/// </summary>
		protected abstract string ElementHandlerName { get; }

		#endregion

		#region Methods: Private

		private IEnumerable<CampaignSchemaElement> GetModifiedEventElements() {
			var currentElements = GetEventElements(CampaignSchema);
			if (CampaignSchema.InitialSchema == null) {
				return currentElements;
			}
			var initialElements = GetEventElements(CampaignSchema.InitialSchema);
			var sameElements = initialElements.Join(currentElements,
					initial => initial.UId,
					current => current.UId,
					(initial, current) => (GetEventId(initial) == GetEventId(current), current))
				.Where(x => x.Item1)
				.Select(x => x.Item2);
			return currentElements.Except(sameElements);
		}

		private void UpdateConnectedEventInfo(IEnumerable<CampaignSchemaElement> elements) {
			foreach (var element in elements) {
				var id = GetEventId(element);
				var eventId = id.IsEmpty() ? null as Guid? : id;
				UpdateCampaignItemConnectedRecordInfo(element.UId, _eventSchemaUId, eventId);
			}
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Filters all flow elements and returns the list of event elements.
		/// </summary>
		/// <param name="schema">Campaign schema with flow elements.</param>
		/// <returns>List of event campaign elements.</returns>
		protected abstract IEnumerable<CampaignSchemaElement> GetEventElements(CoreCampaignSchema schema);

		/// <summary>
		/// Retrieves event identifier from the campaign element.
		/// </summary>
		protected abstract Guid GetEventId(CampaignSchemaElement eventElement);

		/// <summary>
		/// Updates connected records info (RecordId and SchemaUId fields) after campaign has been copied.
		/// </summary>
		protected void HandleCopy() {
			try {
				var allElements = GetEventElements(CampaignSchema);
				UpdateConnectedEventInfo(allElements);
			} catch (Exception ex) {
				CampaignLogger.ErrorFormat(ElementHandlerName, ex, CampaignSchema.EntityId);
				throw;
			}
		}

		/// <summary>
		/// Updates connected records info (RecordId and SchemaUId fields) after campaign has been saved.
		/// </summary>
		protected void HandleAfterSave() {
			try {
				var modifiedElements = GetModifiedEventElements();
				UpdateConnectedEventInfo(modifiedElements);
			} catch (Exception ex) {
				CampaignLogger.ErrorFormat(ElementHandlerName, ex, CampaignSchema.EntityId);
				throw;
			}
		}

		#endregion

	}

	#endregion

}
