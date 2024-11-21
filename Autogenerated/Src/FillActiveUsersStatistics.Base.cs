namespace BPMSoft.Core.Process
{

	using BPMSoft.Common;
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

	#region Class: FillActiveUsersStatisticsMethodsWrapper

	/// <exclude/>
	public class FillActiveUsersStatisticsMethodsWrapper : ProcessModel
	{

		public FillActiveUsersStatisticsMethodsWrapper(Process process)
			: base(process) {
			AddScriptTaskMethod("ScriptTask1Execute", ScriptTask1Execute);
		}

		#region Methods: Private

		private bool ScriptTask1Execute(ProcessExecutingContext context) {
			var storedProcedure = new StoredProcedure(UserConnection, "tsp_FillActiveUsersStatistics");
			storedProcedure.Execute();
			return true;
		}

		#endregion

	}

	#endregion

}

