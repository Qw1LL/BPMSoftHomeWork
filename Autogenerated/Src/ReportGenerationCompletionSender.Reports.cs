namespace BPMSoft.Configuration
{
	using global::Common.Logging;
	using FileConverter.Client.Task;

	#region Class ReportGenerationCompletionSender

	/// <summary>
	/// Represents a base abstraction of sender of report generation completion.
	/// </summary>
	public abstract class ReportGenerationCompletionSender
	{
		#region Fields: Private

		private ReportGenerationCompletionSender _successor;

		#endregion

		#region Constructors: Protected

		/// <summary>
		/// Initializes a new instance of the <see cref="ReportGenerationCompletionSender"/> class.
		/// </summary>
		protected ReportGenerationCompletionSender() {
			Log = LogManager.GetLogger("ReportGeneration");
		}

		#endregion

		#region Properties: Protected

		/// <summary>
		/// Gets the logger of report generation.
		/// </summary>
		protected virtual ILog Log { get; }

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Sends a message about completion of report generation.
		/// </summary>
		/// <param name="fileConversionTask">The remote task of file conversion.</param>
		/// <param name="reportGenerationTask">The local task of a report generation.</param>
		/// <returns>True if message about completion of report generation sent; otherwise false.</returns>
		protected abstract bool SendMessageInternal(FileConversionTask fileConversionTask, UserReportGenerationTask reportGenerationTask);

		#endregion

		#region Methods: Public

		/// <summary>
		/// Sets the next report generation completion sender which is set after the current.
		/// </summary>
		/// <param name="successor">The next report generation completion sender.</param>
		/// <returns>The <paramref name="successor"/> report generation completion sender.</returns>
		public ReportGenerationCompletionSender SetSuccessor(ReportGenerationCompletionSender successor) {
			_successor = successor;
			return successor;
		}

		/// <summary>
		/// Sends a message about completion of report generation. Sends the message to the next sender if can’t send it yourself.
		/// </summary>
		/// <param name="fileConversionTask">The remote task of file conversion.</param>
		/// <param name="reportGenerationTask">The local task of a report generation.</param>
		/// <returns>True if message about completion of report generation sent; otherwise false.</returns>
		public bool SendMessage(FileConversionTask fileConversionTask, UserReportGenerationTask reportGenerationTask) {
			if (SendMessageInternal(fileConversionTask, reportGenerationTask)) {
				return true;
			}
			return _successor != null && _successor.SendMessage(fileConversionTask, reportGenerationTask);
		}

		#endregion
	}

	#endregion

}
