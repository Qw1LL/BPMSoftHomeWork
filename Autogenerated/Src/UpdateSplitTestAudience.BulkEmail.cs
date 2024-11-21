namespace BPMSoft.Core.Process
{

	using BPMSoft.Common;
	using BPMSoft.Configuration;
	using BPMSoft.Configuration.MandrillService;
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

	#region Class: UpdateSplitTestAudienceMethodsWrapper

	/// <exclude/>
	public class UpdateSplitTestAudienceMethodsWrapper : ProcessModel
	{

		public UpdateSplitTestAudienceMethodsWrapper(Process process)
			: base(process) {
			AddScriptTaskMethod("MainScriptTaskExecute", MainScriptTaskExecute);
		}

		#region Methods: Private

		private bool MainScriptTaskExecute(ProcessExecutingContext context) {
			Main();
			return true;
		}

			
			private void Main() {
				var recordId = Get<Guid>("RecordId");
				var data = new UpdateTargetAudienceData(null, "BulkEmailSplit", recordId, false);
				Core.Tasks.Task.StartNewWithUserConnection<UpdateAudienceBackgroundTask, UpdateTargetAudienceData>(data);
			}
			

		#endregion

	}

	#endregion

}

