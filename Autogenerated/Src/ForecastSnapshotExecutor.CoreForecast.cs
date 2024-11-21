 namespace BPMSoft.Configuration.ForecastV2
{
	using global::Common.Logging;
	using System;
	using System.Collections.Generic;
	using BPMSoft.Core;
	using BPMSoft.Core.Factories;

	#region Class: ForecastSnapshotExecutor

	/// <summary>
	/// Executes forecast snapshotting job.
	/// </summary>
	/// <seealso cref="BPMSoft.Core.IJobExecutor" />
	public class ForecastSnapshotExecutor : IJobExecutor
	{
		#region Fields: Private

		private static readonly ILog _log = LogManager.GetLogger<ForecastSnapshotExecutor>();
		private IForecastSnapshotManager _forecastSnapshotManager;

		#endregion

		protected UserConnection UserConnection { get; set; }

		protected IForecastSnapshotManager ForecastSnapshotManager {
			get {
				return _forecastSnapshotManager ??
					(_forecastSnapshotManager = ClassFactory.Get<IForecastSnapshotManager>(new ConstructorArgument("userConnection", UserConnection)));
			}
		}

		#region Methods: Public

		/// <summary>
		/// Executes job operation.
		/// </summary>
		/// <param name="userConnection">The user connection.</param>
		/// <param name="parameters">The parameters.</param>
		public void Execute(UserConnection userConnection, IDictionary<string, object> parameters) {
			var forecastId = (Guid)parameters["ForecastId"];
			UserConnection = userConnection;
			_log.Info($"Forecast snapshot started. ForecastId:{forecastId}");
			ForecastSnapshotManager.SaveSnapshot(forecastId, new FilterConfig())
;			_log.Info($"Forecast snapshot ended. ForecastId:{forecastId}");
		}

		#endregion

	}

	#endregion

}

