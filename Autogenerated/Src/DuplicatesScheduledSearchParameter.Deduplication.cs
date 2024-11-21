namespace BPMSoft.Configuration.Deduplication
{
	using System;
	using BPMSoft.Core.Entities;

	/// <summary>
	/// Specifies the day of the week.
	/// </summary>
	public enum SearchDayOfWeek : ushort
	{
		/// <summary>
		/// Indicates nothing.
		/// </summary>
		None = 0,

		/// <summary>
		/// Indicates Monday.
		/// </summary>
		Monday = 2,

		/// <summary>
		/// Indicates Tuesday.
		/// </summary>
		Tuesday = 4,

		/// <summary>
		/// Indicates Wednesday.
		/// </summary>
		Wednesday = 8,

		/// <summary>
		/// Indicates Thursday.
		/// </summary>
		Thursday = 16,

		/// <summary>
		/// Indicates Friday.
		/// </summary>
		Friday = 32,

		/// <summary>
		/// Indicates Saturday.
		/// </summary>
		Saturday = 64,

		/// <summary>
		/// Indicates Sunday.
		/// </summary>
		Sunday = 128
	}

	#region Class: DuplicatesScheduledSearchParameter

	/// <summary>
	/// Represents a parameter for configuring duplicates scheduled search.
	/// </summary>
	public class DuplicatesScheduledSearchParameter
	{
		
		#region Properties: Public

		/// <summary>
		/// Gets or sets search days.
		/// </summary>
		public SearchDayOfWeek SearchDays { get; set; }

		/// <summary>
		/// Gets or sets a search time.
		/// </summary>
		public TimeSpan SearchTime { get; set; }

		/// <summary>
		/// Gets ort sets the name of a search schema.
		/// </summary>
		public string SearchSchemaName { get; set; }

		#endregion

		#region Methods: Public

		/// <summary>
		/// Creates a instance of the <see cref="DuplicatesScheduledSearchParameter"/> based on a specified entity.
		/// </summary>
		/// <param name="duplicatesSearchParameterEntity">The entity for duplicates search parameter creation.</param>
		/// <returns>A instance of the <see cref="DuplicatesScheduledSearchParameter"/> based on the <paramref name="duplicatesSearchParameterEntity"/>.</returns>
		public static DuplicatesScheduledSearchParameter CreateFromEntity(
				Entity duplicatesSearchParameterEntity) {
			if (duplicatesSearchParameterEntity == null) {
				return null;
			}
			var searchTime = duplicatesSearchParameterEntity.GetTypedColumnValue<DateTime>("SearchTime");
			return new DuplicatesScheduledSearchParameter {
				SearchTime = searchTime == DateTime.MinValue
					? TimeSpan.MinValue
					: new TimeSpan(searchTime.Hour, searchTime.Minute, searchTime.Second),
				SearchDays = (SearchDayOfWeek)duplicatesSearchParameterEntity.GetTypedColumnValue<ushort>("Days"),
				SearchSchemaName = duplicatesSearchParameterEntity.GetTypedColumnValue<string>("SchemaToSearchName")
			};
		}

		#endregion

	}

	#endregion
}
