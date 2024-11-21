namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Linq;
	using Common;
	using Core;
	using Core.DB;
	using Core.Factories;

	#region Class: FullPipelineQueryConsts

	/// <summary>
	/// Provides constants for full pipeline queries.
	/// </summary>
	public static class FullPipelineQueryConsts
	{

		/// <summary>
		/// The stage identifier column name.
		/// </summary>
		public static readonly string StageIdColumnName = "StageId";

		/// <summary>
		/// The current in stage count column name.
		/// </summary>
		public static readonly string CurrentInStageCountColumnName = "CurrentStageCount";

		/// <summary>
		/// The overall stage count column name.
		/// </summary>
		public static readonly string OverallStageCountColumnName = "OverallCount";
	}

	#endregion

	#region Class: FullPipelineRow

	/// <summary>
	/// Provides properties for full pipeline row.
	/// </summary>
	public class FullPipelineRow
	{
		/// <summary>
		/// Gets or sets the stage identifier.
		/// </summary>
		/// <value>
		/// The stage identifier.
		/// </value>
		public Guid StageId {
			get; set;
		}

		/// <summary>
		/// Gets or sets the count in stage.
		/// </summary>
		/// <value>
		/// The count in stage.
		/// </value>
		public decimal CountInStage {
			get; set;
		}
		/// <summary>
		/// Gets or sets the overall count.
		/// </summary>
		/// <value>
		/// The overall count.
		/// </value>
		public decimal OverallCount {
			get; set;
		}

		/// <summary>
		/// Gets or sets the calculated properties.
		/// </summary>
		/// <value>
		/// The calculated properties.
		/// </value>
		public Dictionary<string, decimal> CalculatedProperties {
			get; set;
		}

		/// <summary>
		/// Gets the number.
		/// </summary>
		/// <value>
		/// The number.
		/// </value>
		public int Number {
			get;
			internal set;
		}
	}

	#endregion

	#region Class: FullPipelineDataRetriever

	/// <summary>
	/// Provides methods of retrieval full pipeline data.
	/// </summary>
	/// <seealso cref="BPMSoft.Configuration.IFullPipelineDataRetriever" />
	[DefaultBinding(typeof(IFullPipelineDataRetriever))]
	public class FullPipelineDataRetriever : IFullPipelineDataRetriever
	{

		#region Fields: Private

		private readonly UserConnection _userConnection;

		private readonly IFullPipelineQueryBuilder _builder;

		#endregion

		#region Constructors: Public

		public FullPipelineDataRetriever(UserConnection userConnection,
				IFullPipelineQueryBuilder builder) {
			userConnection.CheckArgumentNull(nameof(userConnection));
			builder.CheckArgumentNull(nameof(builder));
			_userConnection = userConnection;
			_builder = builder;
		}

		#endregion

		#region Methods: Private

		private FullPipelineRow GetFullPipelineRow(IDataReader reader, FullPipelineEntityConfig config) {
			var pipelineRow = new FullPipelineRow {
				StageId = reader.GetColumnValue<Guid>("StageId"),
				CountInStage = reader.GetColumnValue<decimal>(FullPipelineQueryConsts.CurrentInStageCountColumnName),
				OverallCount = reader.GetColumnValue<decimal>(FullPipelineQueryConsts.OverallStageCountColumnName)
			};
			var calcProperties = GetCalculatedProperties(reader, config);
			pipelineRow.CalculatedProperties = calcProperties;
			return pipelineRow;
		}

		private Dictionary<string, decimal> GetCalculatedProperties(IDataReader reader, FullPipelineEntityConfig config) {
			if (config.CalculatedOperations.IsEmpty()) {
				return null;
			}
			return config.CalculatedOperations
				.ToDictionary(operation => operation.Operation, 
					operation => reader.GetColumnValue<decimal>(operation.Operation));
		}

		private IEnumerable<FullPipelineRow> ExecuteQuery(Select query, FullPipelineEntityConfig config) {
			var result = new List<FullPipelineRow>();
			using (var dbExecutor = _userConnection.EnsureDBConnection(QueryKind.Limited)) {
				using (var reader = query.ExecuteReader(dbExecutor)) {
					while (reader.Read()) {
						var pipelineRow = GetFullPipelineRow(reader, config);
						result.Add(pipelineRow);
					}
				}
			}
			return result;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Retrieve data.
		/// </summary>
		/// <param name="pipelineEntityConfigs">The pipeline entity configurations.</param>
		/// <returns>
		/// Collection of <see cref="FullPipelineRow" />
		/// </returns>
		public IEnumerable<FullPipelineRow> DataRetrieve(IEnumerable<FullPipelineEntityConfig> pipelineEntityConfigs) {
			pipelineEntityConfigs.CheckArgumentNull(nameof(pipelineEntityConfigs));
			var result = new List<FullPipelineRow>();
			foreach (var config in pipelineEntityConfigs) {
				var query = _builder.BuildQuery(pipelineEntityConfigs, config.SchemaName);
				if (query == null) {
					continue;
				}
				var queryResult = ExecuteQuery(query, config);
				result.AddRange(queryResult);
			}
			return result;
		}

		#endregion

	}

	#endregion

}

