namespace BPMSoft.Configuration.OAuth20
{
	using global::Common.Logging;
	using System;
	using System.Collections.Generic;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Entities.Events;
	using BPMSoft.Core.Factories;
	using BPMSoft.Messaging.Common;
    using BPMSoft.OAuthIntegration;
	using BPMSoft.OAuthIntegration.Exception;

	#region Class: BaseOAuthApiCaller

	public abstract class BaseOAuthApiCaller : BaseEntityEventListener
	{
		#region Fields: Private

		private static readonly ILog _log = LogManager.GetLogger("OAuth20");

		#endregion

		#region Fields: Protected

		protected Dictionary<Type, string> _exceptionMessageResourceKeys;

		#endregion

		#region Constructors: Public

		public BaseOAuthApiCaller(Dictionary<Type, string> exceptionMessageResourceKeys) {
			_exceptionMessageResourceKeys = exceptionMessageResourceKeys;
		}

		#endregion

		#region Properties: Protected

		protected IIdentityServiceWrapper IdentityServiceWrapper => GlobalAppSettings.FeatureUseSeparateSettingsForOAuth20
        	? ClassFactory.Get<IIdentityServiceWrapper>("OAuth20Integration")
            : ClassFactory.Get<IIdentityServiceWrapper>();

		#endregion

		#region Methods: Private

		private void NotifyUserAboutException(UserConnection userConnection, Exception exception) {
			if (!MsgChannelManager.IsRunning) {
				return;
			}
			var channel = MsgChannelManager.Instance.FindItemByUId(userConnection.CurrentUser.Id);
			if (channel == null) {
				return;
			}
			var simpleMessage = new SimpleMessage {
				Body = exception?.InnerException ?? exception,
				Id = Guid.NewGuid()
			};
			simpleMessage.Header.BodyTypeName = "ActingOnOAuthClientApplication";
			simpleMessage.Header.Sender = GetType().ToString();
			channel.PostMessage(simpleMessage);
		}

		#endregion

		#region Methods: Protected

		protected void CheckCanManageSolution(object sender) {
			var entity = (Entity)sender;
			var userConnection = entity.UserConnection;
			userConnection.DBSecurityEngine.CheckCanExecuteOperation("CanManageSolution");
		}

		protected virtual void ExecuteApiCall(Action apiCall, UserConnection userConnection, EntityBeforeEventArgs e) {
			string errorMessage = null;
			Exception oauthException = null;
			try {
				apiCall();
			}
			catch (ApiServerException ex) {
				errorMessage = new LocalizableString(userConnection.ResourceStorage, GetType().Name,
					_exceptionMessageResourceKeys[typeof(ApiServerException)]);
				oauthException = ex;
			}
			catch (ApiServerConnectivityException ex) {
				string serverUri = Core.Configuration.SysSettings.GetValue(userConnection, "OAuth20IdentityServerUrl", string.Empty);
				errorMessage = string.Format(new LocalizableString(userConnection.ResourceStorage, GetType().Name,
					_exceptionMessageResourceKeys[typeof(ApiServerConnectivityException)]), serverUri);
				oauthException = ex;
			}
			catch (Exception ex) {
				errorMessage = string.Format(new LocalizableString(userConnection.ResourceStorage, "BaseOAuthApiCaller",
					"LocalizableStrings.UnexpectedErrorMessage.Value"), ex.Message);
				oauthException = ex;
			}
			if (oauthException != null) {
				e.IsCanceled = true;
				_log.Error($"{errorMessage}: {oauthException}");
				NotifyUserAboutException(userConnection, oauthException);
			}
			if (errorMessage != null) {
				ThrowException(errorMessage);
			}
		}

		protected abstract void ThrowException(string errorMessage);

		#endregion
	}

	#endregion
}
