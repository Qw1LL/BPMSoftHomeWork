namespace BPMSoft.Configuration.Translation
{
	using System;
	using global::Common.Logging;
	using BPMSoft.Core;
	using BPMSoft.Core.Translation;

	#region Class: TranslationLogger

	public class TranslationLogger : ITranslationLogger
	{

		#region Constructors: Public

		public TranslationLogger(UserConnection userConnection) {
			UserConnection = userConnection;
		}

		#endregion

		#region Properties: Private

		private UserConnection UserConnection {
			get;
			set;
		}

		private ILog _logger;
		private ILog Logger {
			get {
				return _logger ?? (_logger = LogManager.GetLogger("TranslationLogger"));
			}
		}

		#endregion

		#region Methods: Public

		public void Error(Exception e) {
			Logger.Error(string.Empty, e);
		}

		public void Error(IActionResult result) {
			Logger.Error(result.Message);
		}

		public void Info(object message) {
			Logger.Info(message);
		}

		#endregion

	}

	#endregion

}

