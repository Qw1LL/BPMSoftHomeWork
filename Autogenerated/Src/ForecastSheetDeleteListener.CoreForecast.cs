namespace BPMSoft.Configuration
{
	using System;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Entities.Events;

	#region Class: ForecastSheetDeleteListener

	[EntityEventListener(SchemaName = "ForecastSheet")]
	public class ForecastSheetDeleteListener : BaseEntityEventListener
	{

		#region Methods: Private

		private void DeleteForecastRow(Entity entity, Guid forecastSheetId) {
			var referenceSchema =
				entity.UserConnection.EntitySchemaManager.FindInstanceByUId(
					entity.GetTypedColumnValue<Guid>("ForecastEntityInCellUId"));
			if (referenceSchema == null) {
				return;
			}
			Delete delete = new Delete(entity.UserConnection).From("ForecastRow").Where().Exists(
				new Select(entity.UserConnection).Column("Id").As("Id").From(referenceSchema.Name).Where("RowId")
					.IsEqual("ForecastRow", "Id").And("SheetId").IsEqual(Column.Parameter(forecastSheetId))) as Delete;
			delete.Execute();
		}

		private void DeleteHistoryCells(Entity entity, Guid forecastSheetId) {
			Delete delete = new Delete(entity.UserConnection)
				.From("ForecastHistoryCell")
				.Where("SheetId")
					.IsEqual(Column.Parameter(forecastSheetId)) as Delete;
			delete.Execute();
		}
		
		private void DeleteHistoryRows(Entity entity, Guid forecastSheetId) {
			Delete delete = new Delete(entity.UserConnection)
				.From("ForecastHistoryRow")
				.Where("SheetId")
				.IsEqual(Column.Parameter(forecastSheetId)) as Delete;
			delete.Execute();
		}

		#endregion

		#region Methods: Public

		///<inheritdoc/>
		public override void OnDeleting(object sender, EntityBeforeEventArgs e) {
			base.OnDeleting(sender, e);
			Entity entity = (Entity)sender;
			var forecastSheetId = entity.GetTypedColumnValue<Guid>("Id");
			using (DBExecutor dbExecutor = entity.UserConnection.EnsureDBConnection()) {
				dbExecutor.StartTransaction();
				DeleteHistoryCells(entity, forecastSheetId);
				DeleteHistoryRows(entity, forecastSheetId);
				DeleteForecastRow(entity, forecastSheetId);
				dbExecutor.CommitTransaction();
			}
		}

		#endregion

	}

	#endregion

}

