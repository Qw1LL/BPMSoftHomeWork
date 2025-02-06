namespace BPMSoft.Core.Process.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Process;
	using BPMSoft.UI.WebControls.Controls;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using BPMSoft.Configuration;

	#region Class: UsrCreateTransportRequestUserTask

	/// <exclude/>
	public partial class UsrCreateTransportRequestUserTask
	{

		#region Methods: Protected

		protected override bool InternalExecute(ProcessExecutingContext context) { 
			var helper = new UsrTransortRequestsHelper(UserConnection);
		
			var data = new UsrTransportRequestData() {
				UsrName = UsrName,
				UsrRequestNumber = UsrRequestNumber,
				UsrDeliveryAddress = UsrDeliveryAddress,
				UsrDescription = UsrDescription
			};

			Result = helper.CreateUsrTransportRequests(data).ToString();
			
			
			return true;
		}

		#endregion

		#region Methods: Public

		public override bool CompleteExecuting(params object[] parameters) {
			return base.CompleteExecuting(parameters);
		}

		public override void CancelExecuting(params object[] parameters) {
			base.CancelExecuting(parameters);
		}

		public override string GetExecutionData() {
			return string.Empty;
		}

		public override ProcessElementNotification GetNotificationData() {
			return base.GetNotificationData();
		}

		#endregion

	}

	#endregion

}

