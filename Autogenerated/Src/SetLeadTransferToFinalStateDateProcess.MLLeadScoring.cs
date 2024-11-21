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

	#region Class: SetLeadTransferToFinalStateDateProcessMethodsWrapper

	/// <exclude/>
	public class SetLeadTransferToFinalStateDateProcessMethodsWrapper : ProcessModel
	{

		public SetLeadTransferToFinalStateDateProcessMethodsWrapper(Process process)
			: base(process) {
			AddScriptTaskMethod("ScriptTaskUpdateLeadDateExecute", ScriptTaskUpdateLeadDateExecute);
		}

		#region Methods: Private

		private bool ScriptTaskUpdateLeadDateExecute(ProcessExecutingContext context) {
			var userConnection = Get<UserConnection>("UserConnection");
			Guid entityId = Get<Guid>("LeadId");
			var update = new Update(userConnection, "Lead")
				.Set("MovedToFinalStateOn", Column.Parameter(DateTime.UtcNow))
				.Where("Id").IsEqual(Column.Parameter(entityId));
			update.Execute();
			return true;
		}

		#endregion

	}

	#endregion

}

