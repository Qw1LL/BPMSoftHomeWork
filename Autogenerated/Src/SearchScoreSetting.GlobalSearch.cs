namespace BPMSoft.Configuration {

	using System.Collections.Generic;
	using Newtonsoft.Json;

	/// <summary>
	/// Represents elastic search score settings.
	/// </summary>
	public class SearchScoreSetting
	{
		/// <summary>
		/// Entity weight.
		/// </summary>
		[JsonProperty(PropertyName = "weight")]
		public int Weight;
		
		/// <summary>
		/// Fields settings.
		/// </summary>
		[JsonProperty(PropertyName = "fields")]
		public Dictionary<string, string> Fields;
	}
	
}
