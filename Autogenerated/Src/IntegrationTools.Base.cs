using System.Text;
using BPMSoft.Core;
using System.Collections.Generic;
using BPMSoft.Core.Entities;

public class IntegrationTools {
	private readonly UserConnection _userConnection;
	//private readonly ConfigurationTools _configurationTools;
	
	public UserConnection UserConnection {
		get {
			return _userConnection;
		}
	}
	
	public IntegrationTools(UserConnection userConnection) {
		_userConnection = userConnection;
		//_configurationTools = new ConfigurationTools(_userConnection);
	}
	
	public string GetHttpRequestParametersString(Dictionary<string, string> httpRequestParameters) {
		var result = string.Empty;
		if (httpRequestParameters != null) {
			var sb = new StringBuilder();
			bool isFirst = true;
			foreach (var parameter in httpRequestParameters) {
				if (isFirst) {
					isFirst = false;
				} else {
					sb.Append("&");
				}
				sb.Append(parameter.Key);
				sb.Append("=");
				sb.Append(parameter.Value);
			}
			result = sb.ToString();
		}
		return result;
	}
	
}
