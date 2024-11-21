namespace BPMSoft.Configuration
{
	using System.Collections.Generic;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Converters;
	using RestSharp;
	using RestSharp.Deserializers;
	using RestSharp.Serializers;

	#region Class: RestSharpJsonConverter

	/// <summary>
	/// Serializer and deserializer for RestSharp client based on Newtonsoft library.
	/// Used for correct de-/serialization of DTO with DataMember attributes and proper handling of the date format.
	/// </summary>
	public class RestSharpJsonConverter : ISerializer, IDeserializer
	{

		#region Properties: Private

		private JsonSerializerSettings JsonSerializerSettings { get; } = new JsonSerializerSettings {
			DateFormatHandling = DateFormatHandling.IsoDateFormat,
			Converters = new List<JsonConverter> {
				new StringEnumConverter()
			},
			NullValueHandling = NullValueHandling.Ignore
		};

		#endregion

		#region Properties: Public

		///<inheritdoc />
		public string RootElement {
			get;
			set;
		}

		///<inheritdoc />
		public string Namespace {
			get;
			set;
		}

		///<inheritdoc />
		public string DateFormat {
			get;
			set;
		}

		///<inheritdoc />
		public string ContentType { get; set; } = "application/json";

		#endregion

		#region Methods: Public

		///<inheritdoc />
		public string Serialize(object obj) {
			return JsonConvert.SerializeObject(obj, JsonSerializerSettings);
		}

		///<inheritdoc />
		public T Deserialize<T>(IRestResponse response) {
			return JsonConvert.DeserializeObject<T>(response.Content, JsonSerializerSettings);
		}

		#endregion

	}

	#endregion

}

