namespace BPMSoft.Core.Process
{

	using BPMSoft.Common;
	using BPMSoft.Configuration;
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
	using System.Text;

	#region Class: MailingHandlersProcessMethodsWrapper

	/// <exclude/>
	public class MailingHandlersProcessMethodsWrapper : ProcessModel
	{

		public MailingHandlersProcessMethodsWrapper(Process process)
			: base(process) {
			AddScriptTaskMethod("MainScriptTaskExecute", MainScriptTaskExecute);
		}

		#region Methods: Private

		private bool MainScriptTaskExecute(ProcessExecutingContext context) {
			Main();
			return true;
		}

		private void Main() {
			var userConnection = Get<UserConnection>("UserConnection");
			string operation = Get<string>("Operation");
			switch (operation) {
				case "EnableActiveProviderHandlers":
					MailingHandlersUtilities.EnableActiveProviderHandlers(userConnection);
					break;
			}
		}

		#endregion

	}

	#endregion

}

