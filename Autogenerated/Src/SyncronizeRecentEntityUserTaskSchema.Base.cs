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

	#region Class: SyncronizeRecentEntityUserTask

	[DesignModeProperty(Name = "SysEntitySchemaId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "788daa7e2cdc4ddfb73a7b2f38c98ba6", CaptionResourceItem = "Parameters.SysEntitySchemaId.Caption", DescriptionResourceItem = "Parameters.SysEntitySchemaId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "EntityId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "788daa7e2cdc4ddfb73a7b2f38c98ba6", CaptionResourceItem = "Parameters.EntityId.Caption", DescriptionResourceItem = "Parameters.EntityId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "EntityDisplayName", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "788daa7e2cdc4ddfb73a7b2f38c98ba6", CaptionResourceItem = "Parameters.EntityDisplayName.Caption", DescriptionResourceItem = "Parameters.EntityDisplayName.Caption", UseSolutionStorage = true)]
	/// <exclude/>
	public class SyncronizeRecentEntityUserTask : ProcessUserTask
	{

		#region Constructors: Public

		public SyncronizeRecentEntityUserTask(UserConnection userConnection)
			: base(userConnection) {
			SchemaUId = new Guid("788daa7e-2cdc-4ddf-b73a-7b2f38c98ba6");
		}

		#endregion

		#region Properties: Public

		public virtual Guid SysEntitySchemaId {
			get;
			set;
		}

		public virtual Guid EntityId {
			get;
			set;
		}

		public virtual string EntityDisplayName {
			get;
			set;
		}

		#endregion

		#region Methods: Protected

		protected override bool InternalExecute(ProcessExecutingContext context) {
			if (EntityId == Guid.Empty || SysEntitySchemaId == Guid.Empty) {
				return true;
			}
			
			var sysUserId = UserConnection.CurrentUser.Id;
			
			using (var executor = UserConnection.EnsureDBConnection())
			{
				var select = new Select(UserConnection).Top(1)
							    .Column("Id")
							    .From("SysRecentEntity")
							    .Where("EntityId").IsEqual(Column.Parameter(EntityId))
							    .And("SysUserId").IsEqual(Column.Parameter(sysUserId))
							as Select;
			
				var id = default(Guid);
				
				var isNew = true;
				using (var rd = select.ExecuteReader(executor))
				{
					if (rd.Read())
					{
						id = new Guid(rd["Id"].ToString());
						isNew = false;
					}
				}
			
				if(isNew)
				{
					Insert insert = new Insert(UserConnection).Into("SysRecentEntity")
										.Set("EntityId", Column.Parameter(EntityId))
										.Set("EntityCaption", Column.Parameter(EntityDisplayName))
										.Set("SysEntitySchemaUId", Column.Parameter(SysEntitySchemaId))
										.Set("SysUserId", Column.Parameter(sysUserId))
										.Set("UsedOn", Column.Parameter(System.DateTime.Now));
					insert.Execute(executor);
				}
				else
				{
					Update update = new Update(UserConnection, "SysRecentEntity")
								        .Set("UsedOn", Column.Parameter(System.DateTime.Now))
								        .Where("Id").IsEqual(Column.Parameter(id)) as Update;
					update.Execute(executor);
				}
			}
			
			ClearExcessItems(sysUserId);
			
			return true;
		}

		#endregion

		#region Methods: Public

		public virtual void ClearExcessItems(Guid SysUserId) {
			var recentEntityCount = Convert.ToInt32(BPMSoft.Core.Configuration.SysSettings.GetValue(UserConnection, "RecentEntityCount"));
			if (recentEntityCount == 0) {
				return;
			}
			using (var executor = UserConnection.EnsureDBConnection()) {
				var delete = new Delete(UserConnection).From("SysRecentEntity")
					.Where(Column.SourceColumn("Id")).Not().In(
						new Select(UserConnection).Top(recentEntityCount)
							.Column("Id")
							.From("SysRecentEntity")
							.Where("SysUserId").IsEqual(Column.Parameter(SysUserId))
							.And("SysEntitySchemaUId").IsEqual(Column.Parameter(SysEntitySchemaId))
							.OrderByDesc("UsedOn"))
					.And("SysUserId").IsEqual(Column.Parameter(SysUserId))
					.And("SysEntitySchemaUId").IsEqual(Column.Parameter(SysEntitySchemaId));
			
				delete.Execute(executor);
			}
		}

		public virtual void UpdateFiltersRightExprMetaDataByParameterValue(Process process, DataSourceFilterCollection filters) {
			foreach (var filter in filters) {
				if (filter is DataSourceFilterCollection) {
					UpdateFiltersRightExprMetaDataByParameterValue(process, (DataSourceFilterCollection)filter);
					continue;
				}	
				var dataSourcefilter = (DataSourceFilter)filter;
				if (dataSourcefilter.RightExpression == null) {
					continue;
				}
				if (dataSourcefilter.RightExpression.Type == DataSourceFilterExpressionType.Custom) {
					dataSourcefilter.RightExpression.Type = DataSourceFilterExpressionType.Parameter;
					if (dataSourcefilter.RightExpression.Parameters.Count == 2) {
						var parameters = dataSourcefilter.RightExpression.Parameters;
						var metaPath = parameters[1].Value;
						parameters[1].Value = process.GetParameterValueByMetaPath((string)metaPath);
						parameters.RemoveAt(0);
					}
					if (dataSourcefilter.SubFilters != null && dataSourcefilter.SubFilters.Count > 0) {
						UpdateFiltersRightExprMetaDataByParameterValue(process, dataSourcefilter.SubFilters);
					}
				}
			}
		}

		public override void WritePropertiesData(DataWriter writer) {
			writer.WriteStartObject(Name);
			base.WritePropertiesData(writer);
			if (Status == Core.Process.ProcessStatus.Inactive) {
				writer.WriteFinishObject();
				return;
			}
			if (!HasMapping("SysEntitySchemaId")) {
				writer.WriteValue("SysEntitySchemaId", SysEntitySchemaId, Guid.Empty);
			}
			if (!HasMapping("EntityId")) {
				writer.WriteValue("EntityId", EntityId, Guid.Empty);
			}
			if (!HasMapping("EntityDisplayName")) {
				writer.WriteValue("EntityDisplayName", EntityDisplayName, null);
			}
			writer.WriteFinishObject();
		}

		#endregion

		#region Methods: Protected

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			switch (reader.CurrentName) {
				case "SysEntitySchemaId":
					SysEntitySchemaId = reader.GetGuidValue();
				break;
				case "EntityId":
					EntityId = reader.GetGuidValue();
				break;
				case "EntityDisplayName":
					EntityDisplayName = reader.GetStringValue();
				break;
			}
		}

		#endregion

	}

	#endregion

}

