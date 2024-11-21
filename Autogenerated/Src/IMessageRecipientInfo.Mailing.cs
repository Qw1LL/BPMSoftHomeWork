namespace BPMSoft.Configuration 
{
	using System;
	using System.Collections.Generic;

	#region Interface: IMessageRecipientInfo

	/// <summary>
	/// Provides methods and properties for work with recipient of mailing.
	/// </summary>
	public interface IMessageRecipientInfo
	{

		#region Properties: Public

		/// <summary>
		/// Unique identifier of recipient.
		/// </summary>
		Guid Id { 
			get;
			set; 
		}

		/// <summary>
		/// Recipient's email address.
		/// </summary>
		string EmailAddress { 
			get;
			set; 
		}

		/// <summary>
		/// Contact's idetifier (Contact.RId).
		/// </summary>
		int ContactRId { 
			get;
			set; 
		}

		/// <summary>
		/// Contact's idetifier (Contact.Id).
		/// </summary>
		Guid ContactId {
			get;
			set;
		}

		/// <summary>
		/// Default code of the response for the recipient.
		/// </summary>
		int InitialResponseCode {
			get;
			set;
		}

		#endregion

	}

	#endregion

	#region Interface: IExpirationInfo

	/// <summary>
	/// Provides properties to get expiration information for message.
	/// </summary>
	public interface IExpirationInfo
	{

		#region Properties: Public

		/// <summary>
		/// Message expiration date.
		/// </summary>
		DateTime? ExpirationDate {
			get;
			set;
		}

		#endregion

	}

	#endregion

	#region Interface: IDCRecipientInfo

	/// <summary>
	/// Provides properties for macro content
	/// </summary>
	public interface IDCRecipientInfo
	{

		/// <summary>
		/// Gets or sets the macro content.
		/// </summary>
		Dictionary<string, string> Macros { get; set; }

		/// <summary>
		/// Gets or sets the replica identifier.
		/// </summary>
		Guid ReplicaId { get; set; }

	} 

	#endregion

}

