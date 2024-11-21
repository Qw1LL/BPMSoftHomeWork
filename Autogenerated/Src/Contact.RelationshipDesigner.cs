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
	using System.Threading.Tasks;
	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Configuration;
	using BPMSoft.Configuration.EntitySynchronization;
	using BPMSoft.Configuration.RelationshipDesigner;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.DcmProcess;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Entities.AsyncOperations;
	using BPMSoft.Core.Entities.AsyncOperations.Interfaces;
	using BPMSoft.Core.Factories;
	using BPMSoft.Core.ImageAPI;
	using BPMSoft.Core.Process;
	using BPMSoft.Core.Process.Configuration;
	using BPMSoft.GlobalSearch.Indexing;
	using BPMSoft.Messaging.Common;
	using BPMSoft.UI.WebControls.Controls;
	using BPMSoft.UI.WebControls.Utilities.Json.Converters;

	#region Class: Contact_RelationshipDesignerEventsProcess

	public partial class Contact_RelationshipDesignerEventsProcess<TEntity>
	{

		#region Methods: Public

		public virtual bool DeleteRelationshipEntity() {
			var asyncExecutor = ClassFactory.Get<IEntityEventAsyncExecutor>(
				new ConstructorArgument("userConnection", UserConnection));
			var operationArgs = new EntityEventAsyncOperationArgs(Entity, null);
			asyncExecutor.ExecuteAsync<DeleteRelationshipEntityAsyncOperation>(operationArgs);
			return true;
		}

		#endregion

	}

	#endregion

}

