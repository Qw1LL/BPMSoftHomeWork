namespace BPMSoft.Configuration.ForecastV2
{
	using System;
	using System.Collections.Generic;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;

	#region Interface: IForecastSnapshotRepository

	/// <summary>
	/// Provides access to snapshot data storage.
	/// </summary>
	public interface IForecastSnapshotRepository
	{

		#region Methods: Private

		/// <summary>
		/// Adds new snapshot to data store.
		/// </summary>
		/// <param name="snapshot">Snapshot data.</param>
		void Add(ForecastSnapshotData snapshot);

		/// <summary>
		/// Gets all snapshot of forecast.
		/// </summary>
		/// <param name="forecastId">Forecast sheet identifier.</param>
		/// <param name="filterConfig">Filter configuration.</param>
		/// <returns></returns>
		IEnumerable<ForecastSnapshotData> GetAll(Guid forecastId, FilterConfig filterConfig);

		/// <summary>
		/// Gets snapshot data by snapshot identifier. 
		/// </summary>
		/// <param name="snapshotId">Snapshot identifier</param>
		/// <returns></returns>
		ForecastSnapshotData Get(Guid snapshotId);

		#endregion

	}

	#endregion

	#region Class: ForecastSnapshotRepository

	/// <inheritdoc cref="IForecastSnapshotRepository" />
	[DefaultBinding(typeof(IForecastSnapshotRepository))]
	public class ForecastSnapshotRepository : IForecastSnapshotRepository
	{

		#region Constructors: Public

		public ForecastSnapshotRepository(UserConnection userConnection) {
			UserConnection = userConnection;
		}

		#endregion

		#region Properties: Protected

		protected UserConnection UserConnection { get; set; }

		#endregion

		#region Methods: Private

		private void SaveEntity(ForecastSnapshotData snapshot) {
			var entity = UserConnection.EntitySchemaManager.GetInstanceByName("ForecastSnapshot").CreateEntity(UserConnection);
			entity.SetColumnValue("Id", snapshot.SnapshotId);
			entity.SetColumnValue("SheetId", snapshot.SheetId);
			entity.SetColumnValue("Date", snapshot.Date);
			entity.Save(false);
		}

		#endregion

		#region Methods: Public


		/// <inheritdoc cref="IForecastSnapshotRepository.Add"/>
		public void Add(ForecastSnapshotData snapshot) {
			snapshot.CheckArgumentNull(nameof(snapshot));
			snapshot.SheetId.CheckArgumentEmpty(nameof(snapshot.SheetId));
			snapshot.SnapshotId = snapshot.SnapshotId.IsEmpty() ? Guid.NewGuid() : snapshot.SnapshotId;
			snapshot.Date = snapshot.Date == default ? DateTime.UtcNow : snapshot.Date;
			SaveEntity(snapshot);
		}

		/// <inheritdoc cref="IForecastSnapshotRepository.GetAll"/>
		public IEnumerable<ForecastSnapshotData> GetAll(Guid forecastId, FilterConfig filterConfig) {
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "ForecastSnapshot");
			esq.PrimaryQueryColumn.IsAlwaysSelect = true;
			esq.AddColumn("Date").OrderByAsc();
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Sheet", forecastId));
			var collection = esq.GetEntityCollection(UserConnection);
			var snapshots = new List<ForecastSnapshotData>();
			collection.ForEach(item => {
				snapshots.Add(new ForecastSnapshotData {
					SheetId = forecastId,
					SnapshotId = item.GetTypedColumnValue<Guid>("Id"),
					Date = item.GetTypedColumnValue<DateTime>("Date")
				});
			});
			return snapshots;
		}

		/// <inheritdoc cref="IForecastSnapshotRepository.Get"/>
		public ForecastSnapshotData Get(Guid snapshotId) {
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "ForecastSnapshot");
			esq.AddAllSchemaColumns();
			var entity = esq.GetEntity(UserConnection, snapshotId);
			return new ForecastSnapshotData {
				SheetId = entity.GetTypedColumnValue<Guid>("SheetId"),
				SnapshotId = entity.GetTypedColumnValue<Guid>("Id"),
				Date = entity.GetTypedColumnValue<DateTime>("Date")
			};
		}

		#endregion

	}

	#endregion

}

