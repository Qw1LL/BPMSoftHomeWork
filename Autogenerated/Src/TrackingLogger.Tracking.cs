namespace BPMSoft.Configuration.Tracking
{
	using System;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;

	#region Class: TrackingLogger

	public class TrackingLogger
	{
		#region Fields: Private

		private readonly UserConnection _userConnection;

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Initialize <see cref="TrackingLogger"/> instance.
		/// </summary>
		/// <param name="userConnection">Instance of <see cref="UserConnection"/>.</param>
		public TrackingLogger(UserConnection userConnection) {
			_userConnection = userConnection;
		}

		#endregion

		#region Methods: Public

		public void Log(string moduleName, string message) {
			Insert insert = new Insert(_userConnection).Into("TrackingLog");
			insert.Set("ModuleName", Column.Parameter(moduleName));
			insert.Set("Message", Column.Parameter(message));
			insert.Execute();
		}

		public void Log(string moduleName, Exception exception) {
			Log(moduleName, exception.ToString());
		}

		#endregion

	}

	#endregion

}
