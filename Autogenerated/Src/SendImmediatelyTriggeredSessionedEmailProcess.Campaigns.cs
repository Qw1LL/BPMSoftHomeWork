namespace BPMSoft.Core.Process
{

	using BPMSoft.Common;
	using BPMSoft.Configuration;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;
	using BPMSoft.Core.Process;
	using BPMSoft.Core.Process.Configuration;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Drawing;
	using System.Globalization;
	using System.Text;
	using System.Web;

	#region Class: SendImmediatelyTriggeredSessionedEmailProcessMethodsWrapper

	/// <exclude/>
	public class SendImmediatelyTriggeredSessionedEmailProcessMethodsWrapper : ProcessModel
	{

		public SendImmediatelyTriggeredSessionedEmailProcessMethodsWrapper(Process process)
			: base(process) {
			AddScriptTaskMethod("ScriptTask1Execute", ScriptTask1Execute);
		}

		#region Methods: Private

		private bool ScriptTask1Execute(ProcessExecutingContext context) {
			SendMailing();
			return true;
		}

			public virtual void SendMailing() {
			
				var userConnection = this.Get<UserConnection>("UserConnection");
				var bulkEmailId = this.Get<Guid>("BulkEmailId");
				var applicationUrl = this.Get<string>("ApplicationUrl");
				var sessionId = this.Get<Guid>("SessionUId");
				
				try {
					var mailingService = ClassFactory.Get<MailingService>(new ConstructorArgument("userConnection", userConnection));
					var isDelayedStart = true;
					mailingService.SendSessionedMessage(bulkEmailId, sessionId, isDelayedStart, applicationUrl);
				} catch (Exception e) {
					MailingUtilities.Log.ErrorFormat(
						"[SendImmediatelyTriggeredSessionedEmailProcess]: "
						+ "Failed to trigger. Params bulkEmailId: {0} sessionId: {1} applicationUrl: {2}.",
							e, bulkEmailId, sessionId, applicationUrl);
					throw e;
				}
					
			}

		#endregion

	}

	#endregion

}

