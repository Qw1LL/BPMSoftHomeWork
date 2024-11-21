namespace BPMSoft.Configuration.Tracking
{
	using System;
	using BPMSoft.Core;
	using CoreConfig = Core.Configuration;

	#region Class: TrackingDataProvider

	/// <summary>
	/// Provide information from report service.
	/// </summary>
	public class ReportServiceDataProvider : TrackingDataProvider
	{

		#region Properties: Private

		/// <summary>
		/// System settings name for base report service url.
		/// </summary>
		private string ReportAddressSettingsName => "TrackingReportUrl";

		#endregion

		#region Properties: Protected

		private string _reportUrl;
		/// <summary>
		/// Report service url value.
		/// </summary>
		protected string ReportUrl
		{
			get
			{
				if (string.IsNullOrEmpty(_reportUrl))
				{
					_reportUrl = CoreConfig.SysSettings.GetValue(UserConnection, ReportAddressSettingsName).ToString();
					return _reportUrl;
				}
				else
				{
					return _reportUrl;
				}
			}
		}

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Constructor of a class.
		/// </summary>
		/// <param name="userConnection">Instance of UserConnection.</param>
		public ReportServiceDataProvider(UserConnection userConnection) : base(userConnection) { }

		#endregion

	}

	#endregion

}

