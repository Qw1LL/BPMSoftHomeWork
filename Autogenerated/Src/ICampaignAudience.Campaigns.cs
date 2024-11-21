namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using BPMSoft.Core.DB;

	#region Interface: ICampaignAudience

	/// <summary>
	/// Interface for campaign audience store
	/// </summary>
	public interface ICampaignAudience
	{

		#region Methods: Public

		/// <summary>
		/// Adding audience to campaign from query.
		/// Select should contains Id column.
		/// </summary>
		/// <param name="select">Query for gets insertion audience.</param>
		/// <param name="campaignItemId">Unique identifier of the campaign step item.</param>
		/// <param name="contactIdColumn">Name of column with identifier of the contact.</param>
		/// <returns>Inserted rows count.</returns>
		int Add(Select select, Guid campaignItemId, string contactIdColumn);

		/// <summary>
		/// Adding audience to campaign from list.
		/// </summary>
		/// <param name="contacts">List of contacts which need to add to the participant table.</param>
		/// <param name="campaignItemId">Unique identifier of the campaign step item.</param>
		void Add(IEnumerable<Guid> contacts, Guid campaignItemId);

		/// <summary>
		/// Excluding audience from campaign.
		/// Select should contains Id column.
		/// </summary>
		/// <param name="select">Query for gets updating audience.</param>
		/// <param name="campaignItemId">Unique identifier of the campaign step item.</param>
		int Exclude(Select select, Guid campaignItemId);

		/// <summary>
		/// Processes campaign audience with update of participants' status to specified.
		/// Select should contains Id column.
		/// </summary>
		/// <param name="select">Query for gets updating audience.</param>
		/// <param name="campaignItemId">Unique identifier of the campaign step item.</param>
		/// <param name="participantStatusId">Unique identifier of the campaign participant status to set.</param>
		int Exclude(Select select, Guid campaignItemId, Guid participantStatusId);

		/// <summary>
		/// Gets campaign audience with not completed sign filtered by campaign step.
		/// </summary>
		/// <param name="itemId">Unique identifier of the campaign step.</param>
		/// <returns>Instance of <see cref="Select"/>.</returns>
		Select GetAudienceByItemSelect(Guid itemId);

		/// <summary>
		/// Gets campaign audience filter by campaign step.
		/// </summary>
		/// <param name="itemId">Unique identifier of the campaign step.</param>
		/// <returns>Instance of <see cref="Select"/>.</returns>
		Select GetItemAudienceSelect(Guid itemId);

		/// <summary>
		/// Sets StepCompleted flag true for audience on campaign step.
		/// </summary>
		/// <param name="itemId">Unique identifier of the campaign step.</param>
		int SetItemCompleted(Guid itemId);

		/// <summary>
		/// Sets StepCompleted flag true and specified participants' status for audience on campaign step.
		/// </summary>
		/// <param name="itemId">Unique identifier of the campaign step.</param>
		/// <param name="participantStatusId">Unique identifier of the campaign participant status to set.</param>
		int SetItemCompleted(Guid itemId, Guid participantStatusId);

		/// <summary>
		/// Sets the flag StepCompleted to true for a specified participants at the campaign step.
		/// </summary>
		/// <param name="itemId">Unique identifier of the campaign step.</param>
		/// <param name="contactSelect">Query that returns an audience for update.</param>
		int SetItemCompleted(Guid itemId, Select contactSelect);

		/// <summary>
		/// Increases total participants count of campaign by adding new participants' count
		/// to current value of campaign's TargetTotal column.
		/// </summary>
		/// <param name="addedParticipantsCount">Count of new campaign participants which were added to campaign.</param>
		void IncreaseCampaignParticipantsCount(int addedParticipantsCount);

		/// <summary>
		/// Actualizes status for participants on current campaign step.
		/// </summary>
		/// <param name="itemId">Unique identifier of the campaign step.</param>
		/// <param name="participantStatusId">Unique identifier of the campaign participant status to set.</param>
		/// <returns>Count of updated participants.</returns>
		int UpdateStatusForItem(Guid itemId, Guid participantStatusId);

		/// <summary>
		/// Returns base query for <see cref="SequenceFlowElement"/>
		/// </summary>
		/// <param name="sourceRefUId">Unique identifier of the sequence's source element.</param>
		/// <param name="targetRefUId">Unique identifier of the sequence's target element.</param>
		/// <returns>Query with base logic of <see cref="SequenceFlowElement"/></returns>
		Update GetSequenceFlowBaseUpdate(Guid sourceRefUId, Guid targetRefUId);

		#endregion

	}

	#endregion
}


