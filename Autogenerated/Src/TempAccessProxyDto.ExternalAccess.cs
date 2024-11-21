namespace BPMSoft.Configuration.ExternalAccessPackage
{
	using System;
	using System.Collections.Generic;

	#region Class: ClientResources

	[Obsolete("Use BPMSoft.OAuthIntegration.DTO.ClientResources")]
	/// <summary>
	/// Client resources description.
	/// </summary>
	public class ClientResources
	{

		#region Properties: Public

		/// <summary>
		/// Gets or sets the client id.
		/// </summary>
		/// <value>
		/// The client id.
		/// </value>
		public string ClientId { get; set; }

		/// <summary>
		/// Gets or sets the name of the client.
		/// </summary>
		/// <value>
		/// The name of the client.
		/// </value>
		public string ClientName { get; set; }

		/// <summary>
		/// Gets or sets the client URI.
		/// </summary>
		/// <value>
		/// The client URI.
		/// </value>
		public string ClientUri { get; set; }

		/// <summary>
		/// Gets or sets the customer identifier (CID).
		/// </summary>
		/// <value>
		/// The customer identifier (CID).
		/// </value>
		public string CustomerId { get; set; }

		/// <summary>
		/// Gets or sets the resources.
		/// </summary>
		/// <value>
		/// The resources.
		/// </value>
		public List<ExpirableResourceInfo> Resources { get; set; }

		#endregion

	}

	#endregion

	#region Class: ExpirableResourceInfo

	[Obsolete("Use BPMSoft.OAuthIntegration.DTO.ExpirableResourceInfo")]
	/// <summary>
	/// Expirable resource item essential info.
	/// </summary>
	public class ExpirableResourceInfo
	{

		#region Properties: Public

		/// <summary>
		/// Gets or sets the resource unique name.
		/// </summary>
		/// <value>
		/// The name.
		/// </value>
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets the display name.
		/// </summary>
		/// <value>
		/// The display name.
		/// </value>
		public string DisplayName { get; set; }

		/// <summary>
		/// Gets or sets the resource expiration UTC date (if any determined).
		/// </summary>
		/// <value>
		/// The expiration date.
		/// </value>
		public DateTime ExpirationDate { get; set; }

		#endregion

	}

	#endregion

	#region Class: ShortIdentityClientInfo

	/// <summary>
	/// Descriptional identity client info."/>
	/// </summary>
	public class ShortIdentityClientInfo
	{

		#region Properties: Public

		/// <summary>
		/// Client identifier.
		/// </summary>
		public string ClientId { get; set; }

		/// <summary>
		/// Client display name.
		/// </summary>
		public string ClientName { get; set; }

		/// <summary>
		/// Client description.
		/// </summary>
		public string Description { get; set; }

		/// <summary>
		/// Client's identifier as customer.
		/// </summary>
		public string CustomerId { get; set; }

		#endregion

	}

	#endregion

	#region Class:

	/// <summary>
	/// Filter to find clients through Identity service.
	/// </summary>
	public class FindIdentityClientsFilter
	{

		#region Properties: Public

		/// <summary>
		/// Gets or sets the customer id list.
		/// </summary>
		/// <value>
		/// The customer ids.
		/// </value>
		public List<string> CustomerIds { get; set; }

		/// <summary>
		/// Gets or sets the client identifier.
		/// </summary>
		public string ClientId { get; set; }

		#endregion

	}

	#endregion

}

