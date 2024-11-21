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
	using BPMSoft.Configuration.ForecastV2;
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

	#region Class: EntityInForecastCell_CoreForecastEventsProcess

	public partial class EntityInForecastCell_CoreForecastEventsProcess<TEntity>
	{

		#region Methods: Public

		public virtual Guid CreateForecastRow() {
			var repository = ClassFactory.Get<IForecastRowRepository>();
			repository.UserConnection = UserConnection;
			return repository.Create();
		}

		public virtual bool IsEmptyRow() {
			return Entity.GetTypedColumnValue<Guid>("RowId").IsEmpty();
		}

		public virtual void SetForecastRow() {
			if (Entity.StoringState == StoringObjectState.New && IsEmptyRow()) {
				var rowId = CreateForecastRow();
				Entity.SetColumnValue("RowId", rowId);
			}
		}

		#endregion

	}

	#endregion

}

