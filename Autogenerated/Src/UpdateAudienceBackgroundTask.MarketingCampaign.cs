namespace BPMSoft.Configuration {
	using BPMSoft.Configuration.MandrillService;
	using BPMSoft.Core;
	using BPMSoft.Core.Factories;
	using BPMSoft.Core.Tasks;

	public class UpdateAudienceBackgroundTask : IBackgroundTask<UpdateTargetAudienceData>, IUserConnectionRequired
	{
		private UserConnection _userConnection;

		public void Run(UpdateTargetAudienceData parameters) {
			parameters.UserConnection = _userConnection;
			var bulkEmailAudienceHelper = ClassFactory.Get<BulkEmailAudienceHelper>();
			switch (parameters.SchemaName) {
				case nameof(Event):
				case nameof(BulkEmail):
					bulkEmailAudienceHelper.UpdateTargetAudience(parameters);
					break;
				case nameof(BulkEmailSplit):
					bulkEmailAudienceHelper.UpdateSplitTestAudience(parameters);
					break;
			}
		}

		public void SetUserConnection(UserConnection userConnection) {
			_userConnection = userConnection;
		}
	}
}

