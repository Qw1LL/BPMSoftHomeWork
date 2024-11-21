namespace BPMSoft.Core.Process
{

	using BPMSoft.Common;
	using BPMSoft.Configuration.Omnichannel.Messaging;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Process;
	using BPMSoft.Core.Process.Configuration;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Drawing;
	using System.Globalization;
	using System.Linq;
	using System.Text;

	#region Class: CreateCaseFromChatMethodsWrapper

	/// <exclude/>
	public class CreateCaseFromChatMethodsWrapper : ProcessModel
	{

		public CreateCaseFromChatMethodsWrapper(Process process)
			: base(process) {
			AddScriptTaskMethod("ScriptTask1Execute", ScriptTask1Execute);
		}

		#region Methods: Private

		private bool ScriptTask1Execute(ProcessExecutingContext context) {
			UserConnection userConnection = Get<UserConnection>("UserConnection");
			Guid chatId = Get<Guid>("ChatId");
			var chatProvider = new OmnichannelChatProvider(userConnection);
			var messages = chatProvider.GetChatMessages(chatId).ToList();
			var firstMessage = messages.First();
			var messagesBeforeAnswer = messages.TakeWhile((m) => m.Direction == firstMessage.Direction);
			Set("CaseSubject", firstMessage.Text);
			Set("CaseDescription", string.Join("\n", messagesBeforeAnswer.Select((m) => m.Text)));
			return true;
		}

		#endregion

	}

	#endregion

}

