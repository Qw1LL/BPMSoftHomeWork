namespace BPMSoft.Configuration.OAuth20
{
	using System;
	using System.Runtime.Serialization;

	#region Class: AddClientRequest

	[DataContract]
	public class AddClientRequest
	{

		#region Properties: Public

		[DataMember(Name = "name", IsRequired = true)]
		public string Name { get; set; }

		[DataMember(Name = "redirectUrl")]
		public string RedirectUrl { get; set; }
		
		[DataMember(Name = "applicationUrl", IsRequired = true)]
		public string ApplicationUrl { get; set; }
		
		[DataMember(Name = "systemUserId", IsRequired = true)]
		public Guid SystemUserId { get; set; }

		#endregion

	}

	#endregion

	#region Class: AddClientResponse

	[DataContract]
	public class AddClientResponse : ConfigurationServiceResponse
	{

		#region Properties: Public

		[DataMember(Name = "clientId")]
		public string ClientId { get; set; }

		[DataMember(Name = "clientSecret")]
		public string ClientSecret { get; set; }

		#endregion

	}

	#endregion

	#region Class: UpdateClientRequest

	[DataContract]
	public class UpdateClientRequest
	{
		#region Properties: Public
		
		[DataMember(Name = "clientId", IsRequired = true)]
		public string ClientId { get; set; }

		[DataMember(Name = "name")]
		public string Name { get; set; }

		[DataMember(Name = "redirectUrl")]
		public string RedirectUrl { get; set; }

		[DataMember(Name = "applicationUrl")]
		public string ApplicationUrl { get; set; }

		[DataMember(Name = "systemUserId")]
		public Guid? SystemUserId { get; set; }

		[DataMember(Name = "isActive")]
		public bool? IsActive { get; set; }

		#endregion
	}

	#endregion

	#region Class: UpdateClientScopesRequest

	[DataContract]
	public class UpdateClientScopesRequest
	{
		#region Properties: Public
		
		[DataMember(Name = "clientId", IsRequired = true)]
		public string ClientId { get; set; }
		
		[DataMember(Name = "resourceName", IsRequired = true)]
		public string ResourceName { get; set; }

		#endregion
	}

	#endregion

	#region Class: DeleteClientRequest

	[DataContract]
	public class DeleteClientRequest
	{
		#region Properties: Public

		[DataMember(Name = "clientId", IsRequired = true)]
		public string ClientId { get; set; }

		#endregion
	}

	#endregion

	#region Class: OAuthSettingsRequest

	[DataContract]
	public class OAuthSettingsRequest
	{
		#region Properties: Public

		[DataMember(Name = "clientId", IsRequired = true)]
		public string ClientId { get; set; }


		[DataMember(Name = "clientSecret", IsRequired = true)]
		public string ClientSecret { get; set; }

		[DataMember(Name = "serverUrl", IsRequired = true)]
		public string ServerUrl { get; set; }

		#endregion
	}

	#endregion

	#region Class: AddResourceResponse

	[DataContract]
	public class AddResourceResponse : ConfigurationServiceResponse
	{

		#region Properties: Public

		[DataMember(Name = "scope")]
		public string Scope { get; set; }

		#endregion

	}

	#endregion

	#region Class: ClientSecretResponse

	[DataContract]
	public class ClientSecretResponse : ConfigurationServiceResponse
	{

		#region Properties: Public

		[DataMember(Name = "clientSecret")]
		public string ClientSecret { get; set; }

		#endregion

	}

	#endregion

}
