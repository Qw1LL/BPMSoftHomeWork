namespace BPMSoft.Configuration.Social
{
	using BPMSoft.GoogleServerConnector;

	#region class: GoogleSharedApplicationConnector

	public class GoogleSharedApplicationConnector : BaseServerConnector
	{

		#region Methods: Public

		/// <summary>
		/// Returns consumer information about google shared application.
		/// </summary>
		/// <returns>Consumer information.</returns>
		public GoogleConsumerInfo GetConsumerInfo() {
			var googleServerConnector = new GoogleServerConnector();
			return googleServerConnector.GetConsumerInfo();
		}

		#endregion

	}

	#endregion

}
