namespace BPMSoft.Configuration
{
	using Core;
	using Newtonsoft.Json.Linq;

	/// <summary>
	/// Interface for dashboard item data.
	/// </summary>
	public interface IDashboardItemData
	{

		/// <summary>
		/// User connection. 
		/// </summary>
		UserConnection UserConnection { get; }

		JObject Config  { get; }

		JToken Parameters  { get; }

		string Name { get; }

		string WidgetType { get; }

		/// <summary>
		/// Dashboard item caption.
		/// </summary>
		string Caption { get; }

		/// <summary>
		/// Time zone offset.
		/// </summary>
		int TimeZoneOffset{ get; }

		JObject GetJson();

	}

}
