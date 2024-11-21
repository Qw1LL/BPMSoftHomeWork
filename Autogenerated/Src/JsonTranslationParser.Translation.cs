namespace BPMSoft.Configuration.Translation
{
	using System;
	using System.Collections.Generic;
	using Newtonsoft.Json.Linq;
	using BPMSoft.Common.Json;

	#region Class: JsonTranslationElement

	/// <summary>
	/// Contains json translation element properties.
	/// </summary>
	public class JsonTranslationElement
	{

		#region Constructors: Public

		public JsonTranslationElement(string name , string value, string path) {
			Name = name;
			Value = value;
			Path = path;
		}

		#endregion

		#region Properties: Public

			/// <summary>
			/// Name of json translation element.
			/// </summary>
			public string Name {
				get;
				set;
			}

			/// <summary>
			/// Value of json translation element.
			/// </summary>
			public string Value {
				get;
				set;
			}

			/// <summary>
			/// Path of json translation element.
			/// </summary>
			public string Path {
				get;
				set;
			}

		#endregion

	}

	#endregion

	#region Class: JsonTranslationParser

	/// <summary>
	/// Contains methods for parsing json text during translation.
	/// </summary>
	public class JsonTranslationParser
	{

		#region Constants: Public

		/// <summary>
		/// Translation json string delimiter.
		/// </summary>
		public const string JsonPathDelimiter = "@#json#@";

		#endregion

		#region Methods: Private

		/// <summary>
		/// Checks if input string has json format.
		/// </summary>
		/// <param name="input">Input string.</param>
		/// <param name="json">Output json object.</param>
		/// <returns><c>true</c>, if input string has json format, otherwise - <c>false</c>.</returns>
		private static bool TryParseJson(string input, out JToken json) {
			json = null;
			input = input.Trim();
			 try {
			 	json = JToken.Parse(input);
			 	return true;
			 } catch(Exception) {
				return false;
			}
		}

		/// <summary>
		/// Gets json element values from json object.
		/// </summary>
		/// <param name="token">Json object.</param>
		/// <param name="path">Json element path.</param>
		/// <returns>Json translation elements collection.</returns>
		private static List<JsonTranslationElement> GetJsonValues(JToken token, string path = "") {
			switch (token.Type) {
				case JTokenType.Array:
					return GetJsonValues((JArray)token, path);
				case JTokenType.Object:
					return GetJsonValues((JObject)token, path);
				case JTokenType.Property:
					return GetJsonValues((JProperty)token, path);
				case JTokenType.String:
					return GetJsonValues((JValue)token, path);
				default:
					return new List<JsonTranslationElement>();
			}
		}

		/// <summary>
		/// Gets json element values from json object.
		/// </summary>
		/// <param name="token">Json object.</param>
		/// <param name="path">Json element path.</param>
		/// <returns>Json translation elements collection.</returns>
		private static List<JsonTranslationElement> GetJsonValues(JArray token, string path = "") {
			var result = new List<JsonTranslationElement>();
			for (int i = 0; i < token.Count; i++) {
				string arrayPath = string.Format("{0}[{1}]", path, i);
				List<JsonTranslationElement> values = GetJsonValues(token[i], arrayPath);
				result.AddRange(values);
			}
			return result;
		}

		/// <summary>
		/// Gets json element values from json object.
		/// </summary>
		/// <param name="token">Json object.</param>
		/// <param name="path">Json element path.</param>
		/// <returns>Json translation elements collection.</returns>
		private static List<JsonTranslationElement> GetJsonValues(JObject token, string path = "") {
			var result = new List<JsonTranslationElement>();
			JToken currentItem = token.First;
			while (currentItem != null) {
				List<JsonTranslationElement> values = GetJsonValues(currentItem, path);
				result.AddRange(values);
				currentItem = currentItem.Next;
			}
			return result;
		}

		/// <summary>
		/// Gets json element values from json object.
		/// </summary>
		/// <param name="token">Json object.</param>
		/// <param name="path">Json element path.</param>
		/// <returns>Json translation elements collection.</returns>
		private static List<JsonTranslationElement> GetJsonValues(JProperty token, string path = "") {
			JToken value = token.Value;
			path = string.IsNullOrEmpty(path) || path.EndsWith(JsonPathDelimiter)
				? string.Concat(path, token.Name) : string.Concat(path, ".", token.Name);
			return GetJsonValues(value, path);
		}

		/// <summary>
		/// Gets json element values from json object.
		/// </summary>
		/// <param name="token">Json object.</param>
		/// <param name="path">Json element path.</param>
		/// <returns>Json translation elements collection.</returns>
		private static List<JsonTranslationElement> GetJsonValues(JValue token, string path = "") {
			var result = new List<JsonTranslationElement>();
			string value = token.ToString();
			if (string.IsNullOrEmpty(value)) {
				return result;
			}
			JToken innerJson;
			if (TryParseJson(value, out innerJson)) {
				path = string.Concat(path, JsonPathDelimiter);
				result = GetJsonValues(innerJson, path);
			} else {
				if (token.Parent.Type == JTokenType.Property) {
					string name = ((JProperty)token.Parent).Name;
					result.Add(new JsonTranslationElement(name, value, path));
				}
			}
			return result;
		}

		/// <summary>
		/// Gets json with replaced value.
		/// </summary>
		/// <param name="originalJson">Json string.</param>
		/// <param name="path">Json translation element path.</param>
		/// <param name="value">Json translation element value.</param>
		/// <returns>Actual json string.</returns>
		private static string GetJsonWithReplacedValue(string originalJson, string path, string value) {
			path = path.Replace(JsonPathDelimiter, ".");
			JToken json = Json.Deserialize<JToken>(originalJson);
			JToken valueToken = SelectJsonToken(json, path);
			valueToken.Replace(value);
			return json.ToString(Newtonsoft.Json.Formatting.None);
		}

		/// <summary>
		/// Gets child json object by path.
		/// </summary>
		/// <param name="json">Json object.</param>
		/// <param name="path">Json element path.</param>
		/// <returns>Json value.</returns>
		private static JToken SelectJsonToken(JToken json, string path) {
			JToken token = json.Type == JTokenType.Array
				? ((JArray)json).SelectToken(path) : ((JObject)json).SelectToken(path);
			return token;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Generates json translation elements collection from input json string.
		/// </summary>
		/// <param name="originalJson">Input json string.</param>
		/// <returns>Json translation elements collection.</returns>
		public static List<JsonTranslationElement> GetJsonTranslationElements(string originalJson) {
			JToken json;
			return !TryParseJson(originalJson, out json) ? new List<JsonTranslationElement>() : GetJsonValues(json);
		}

		/// <summary>
		/// Generates json translation string from original json string by new value.
		/// </summary>
		/// <param name="originalJson">Original json string.</param>
		/// <param name="path">Json translation element path.</param>
		/// <param name="value">Json translation element value.</param>
		public static string GetJsonTranslationText(string originalJson, string path, string value) {
			return string.IsNullOrEmpty(path) ? originalJson : GetJsonWithReplacedValue(originalJson, path, value);
		}

		#endregion

	}

	#endregion

}

