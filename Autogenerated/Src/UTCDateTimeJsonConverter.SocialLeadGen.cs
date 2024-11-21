namespace BPMSoft.Configuration.SocialLeadGen
{
	using Newtonsoft.Json;
	using System;
	using System.Globalization;

	#region Class: UTCDateTimeJsonConverter

	/// <summary>
	/// Custom Newtonsoft UTC Date time converter.
	/// </summary>
	public class UTCDateTimeJsonConverter : JsonConverter
	{

		#region Methods: Public

		/// <summary>
		/// Check if type of property is supported.
		/// </summary>
		/// <param name="objectType">Type of property which is need to be converted.</param>
		/// <returns>Is supperted type of property or not.</returns>
		public override bool CanConvert(Type objectType) {
			return objectType == typeof(DateTime);
		}

		/// <summary>
		/// Read property.
		/// </summary>
		/// <param name="reader">Json reader.</param>
		/// <param name="objectType">Type of property.</param>
		/// <param name="existingValue">Existing value.</param>
		/// <param name="serializer">Json serializer.</param>
		/// <returns>Parsed property value.</returns>
		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
			return DateTime.SpecifyKind((DateTime)reader.Value, DateTimeKind.Utc);
		}

		/// <summary>
		/// Write property.
		/// </summary>
		/// <param name="writer">Json writer.</param>
		/// <param name="value">Value of property.</param>
		/// <param name="serializer">Json serializer.</param>
		/// <returns>Parsed property value.</returns>
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
			writer.WriteValue(((DateTime)value).ToString("s", DateTimeFormatInfo.InvariantInfo));
		}

		#endregion

	}

	#endregion

}
