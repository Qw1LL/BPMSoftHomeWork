namespace BPMSoft.Core.Process.Configuration
{
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Data;
	using System.Globalization;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Process;
	using BPMSoft.UI.WebControls.Controls;

	#region Class: LinkEntityToProcessUserTask

	/// <exclude/>
	public partial class LinkEntityToProcessUserTask
	{

		#region Methods: Protected

		protected override bool InternalExecute(ProcessExecutingContext context) {
			if (EntitySchemaId == Guid.Empty || EntityId == Guid.Empty) {
				Log.Warn($"Entity {EntityId} (EntitySchemaId: {EntitySchemaId}) is not linked to process {Owner}" +
					$" by {this}");
				return true;
			}
			var entitySchemaManagerItem = UserConnection.EntitySchemaManager.FindItem(item =>
				item.Id == EntitySchemaId || item.UId == EntitySchemaId);
			if (entitySchemaManagerItem != null) {
				UserConnection.IProcessEngine.LinkProcessToEntity(Owner, entitySchemaManagerItem.UId, EntityId);
			} else {
				Log.Warn($"EntitySchema {EntitySchemaId} not found. Entity {EntityId} is not linked to process" +
					$" {Owner} by {this}");
			}
			return true;
		}

		#endregion

	}

	#endregion

}

