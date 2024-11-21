namespace BPMSoft.Configuration
{
	using System;
	using System.Configuration;
	using System.ServiceModel;
	using System.ServiceModel.Web;
	using System.ServiceModel.Activation;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Web.Common;

	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class CryptographicService : BaseService {
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]

		/// <summary>
		/// ############# ######## ###### ## ######### DES.
		/// </summary>
		/// <param name="password">###### ### ##########.</param>
		/// <returns>######, ############## ############### ######.</returns>
		public string GetConvertedPasswordValue(string password) {
			if (string.IsNullOrEmpty(password)) {
				return string.Empty;
			}
			var cryptoServiceKey = ConfigurationManager.AppSettings["MsgUserPasswordDESCryptoServiceKey"];
			if (string.IsNullOrEmpty(cryptoServiceKey)) {
				var resourceStorage = UserConnection.Workspace.ResourceStorage;
				var errorMessage = new LocalizableString(resourceStorage,
					"CryptographicService", "LocalizableStrings.CryptoServiceKeyExceptionMessage.Value");
				throw new NullReferenceException(errorMessage);
			}
			string msgUserPasswordKey = cryptoServiceKey.ToString();
			using (var cryptoServiceProvider = new DESCryptoServiceProvider(msgUserPasswordKey)) {
				return cryptoServiceProvider.Encrypt(password);
			}
		}
	}
}

