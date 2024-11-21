namespace BPMSoft.Core.Process
{

	using BPMSoft.Common;
	using BPMSoft.Configuration.EmailMining;
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

	#region Class: EmailMiningJobProcessMethodsWrapper

	/// <exclude/>
	public class EmailMiningJobProcessMethodsWrapper : ProcessModel
	{

		public EmailMiningJobProcessMethodsWrapper(Process process)
			: base(process) {
			AddScriptTaskMethod("ExecEmailMiningJobScriptTaskExecute", ExecEmailMiningJobScriptTaskExecute);
		}

		#region Methods: Private

		private bool ExecEmailMiningJobScriptTaskExecute(ProcessExecutingContext context) {
			EmailMiningJob job = new EmailMiningJob();
			UserConnection userConnection = Get<UserConnection>("UserConnection");
			job.Execute(userConnection, null);
			return true;
		}

		#endregion

	}

	#endregion

}

