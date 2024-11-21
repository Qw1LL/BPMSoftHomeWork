namespace BPMSoft.Configuration
{

	using DataContract = BPMSoft.Nui.ServiceModel.DataContract;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Data;
	using System.Drawing;
	using System.Globalization;
	using System.IO;
	using System.Linq;
	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.DcmProcess;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;
	using BPMSoft.Core.Process;
	using BPMSoft.Core.Process.Configuration;
	using BPMSoft.GlobalSearch.Indexing;
	using BPMSoft.UI.WebControls.Controls;
	using BPMSoft.UI.WebControls.Utilities.Json.Converters;

	#region Class: AccountAddress_BaseEventsProcess

	public partial class AccountAddress_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		public virtual void ClearAccountAddress() {
			var synchronizer = GetAddressSynchronizer();
			synchronizer.ClearMasterEntityAddress();
		}

		public virtual BaseAddressSynchronizer GetAddressSynchronizer() {
			AddressSynchronizer = AddressSynchronizer ?? 
				ClassFactory.Get<AccountAddressSynchronizer>(
					new ConstructorArgument("userConnection", UserConnection), 
					new ConstructorArgument("addressEntity", Entity));
			return (BaseAddressSynchronizer) AddressSynchronizer;
		}

		#endregion

	}

	#endregion

}

