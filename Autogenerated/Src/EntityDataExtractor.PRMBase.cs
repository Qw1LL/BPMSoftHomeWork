namespace BPMSoft.Configuration 
{

	using System;
	using System.Collections.Generic;
	using System.Data;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;

	#region Class: EntityDataExtractor

	/// <summary>
	/// Base Entity data extractor.
	/// Extract data based on Select query and convert it to specific format.
	/// </summary>
	public abstract class EntityDataExtractor 
	{

		#region Fields: Private

		/// <summary>
		/// Filters for extract Query.
		/// </summary>
		private List<QueryCondition> _filters;

		#endregion

		#region Properties: Private

		/// <summary>
		/// Filters for extract Query.
		/// </summary>
		private List<QueryCondition> Filters {
			get {
				if (_filters == null) {
					_filters = new List<QueryCondition>();
					return _filters;
				} else {
					return _filters;
				}
			}
		}

		#endregion

		#region Properties: Protected

		/// <summary>
		/// <see cref="UserConnection"/> instance.
		/// </summary>
		protected UserConnection UserConnection { get; private set; }

		/// <summary>
		/// Query for exctraction.
		/// </summary>
		protected virtual Select Query { get; set; }

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Initialize EntityDataExtractor.
		/// </summary>
		/// <param name="userConnection"><see cref="UserConnection"/> instance. </param>
		public EntityDataExtractor(UserConnection userConnection) {
			UserConnection = userConnection;
		}

		#endregion

		#region Methods: Private
		
		/// <summary>
		/// Add filter from filters collection to Extractor query.
		/// </summary>
		/// <param name="filter">Filter which added to query.</param>
		private void AddFilterFromFiltersCollection() {
			foreach (var filter in Filters) {
				if (Query.HasCondition) {
					Query.And(filter);
				} else {
					Query.Where(filter);
				}
			}

		}
		
		#endregion

		#region Methods: Protected

		/// <summary>
		/// Prepare extractor query by specific extraction rules.
		/// </summary>
		protected abstract void PrepareQuery();

		/// <summary>
		/// Convert query results to specific format.
		/// Format example: IEnumerable<Dictionary<string, object>>, where key - column name, value - column value. 
		/// </summary>
		/// <param name="dataReader">DataReader whith query results.</param>
		/// <returns>Query results in specific format.</returns>
		protected abstract IEnumerable<Dictionary<string, object>> ConvertQueryResult(IDataReader dataReader);

		#endregion

		#region Methods: Public

		/// <summary>
		/// Add filter to filters collection.
		/// </summary>
		/// <param name="filter">Filter which added to query.</param>
		public void AddFilter(QueryCondition filter) {
			Filters.Add(filter);
		}

		/// <summary>
		/// Template method for extracting data based on Extractor query and converting it to specific format.
		/// </summary>
		/// <returns>Data in specific format.</returns>
		public IEnumerable<Dictionary<string, object>> ExtractData() {
			PrepareQuery();
			AddFilterFromFiltersCollection();
			if (Query != null) {
				using (DBExecutor dbExecutor = UserConnection.EnsureDBConnection()) {
					using (IDataReader dataReader = Query.ExecuteReader(dbExecutor)) {
						IEnumerable<Dictionary<string, object>> dataSet = ConvertQueryResult(dataReader);
						return dataSet;
					}
				}
			}
			else {
				throw new NullReferenceException("Extract Query didn't set up in PrepareQuery method");
			}
		}

		#endregion

	}

	#endregion
}
