namespace BPMSoft.Configuration {
	
	#region Class: SendMessageTaskData

	public class SendMessageTaskData {

		#region Constants: Private

		/// <summary>
		/// Retry limit for one group processing.
		/// </summary>
		private const int GroupProcessingAttemptsLimit = 10;

		/// <summary>
		/// Retry litimit for processing all groups
		/// </summary>
		private const int FailedGroupsLimit = 100;

		#endregion

		#region Contructors: Public

		public SendMessageTaskData() {
			FailedGroupsCounter = 0;
			FailedGroupAttemptsCounter = 0;
			LastFailedGroupId = 0;
			BatchId = 0;
			ProcessedGroupsCounter = 0;
			HasDataToProceed = true;
			IsBreaking = false;
		}

		#endregion

		#region Properties: Public

		public int LastFailedGroupId {
			get;
			set;
		}

		public int BatchId {
			get;
			set;
		}

		public bool HasDataToProceed {
			get;
			set;
		}

		public int FailedGroupAttemptsCounter {
			get;
			set;
		}

		public int FailedGroupsCounter {
			get;
			set;
		}

		public bool IsBreaking {
			get;
			set;
		}

		public int SentRecipientCounter {
			get;
			set;
		}

		public int ProcessedGroupsCounter {
			get;
			set;
		}

		#endregion

		#region Methods: Public

		public void RetryMessageProcessing() {
			if (LastFailedGroupId == BatchId) {
				FailedGroupAttemptsCounter++;
				if (FailedGroupAttemptsCounter == GroupProcessingAttemptsLimit) {
					FailedGroupAttemptsCounter = 0;
					LastFailedGroupId = 0;
				}
			} else {
				LastFailedGroupId = BatchId;
				FailedGroupAttemptsCounter = 0;
				FailedGroupsCounter++;
			}
			if (FailedGroupsCounter == FailedGroupsLimit) {
				HasDataToProceed = false;
			} else {
				HasDataToProceed = true;
			}
		}

		public void CheckMessageCanProceed(int nextBatchLength) {
			HasDataToProceed = (nextBatchLength > 0);
			if (HasDataToProceed) {
				ProcessedGroupsCounter++;
			}

		}

		#endregion
	}

	#endregion
}

