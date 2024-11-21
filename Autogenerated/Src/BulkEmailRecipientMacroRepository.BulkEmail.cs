namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Common;
	using Core;
	using Core.DB;
	using Newtonsoft.Json;

	#region Class: BulkEmailRecipientMacroRepository

	/// <summary>
	/// Provides methods to read and save data for BulkEmailRecipientMacro entity.
	/// </summary>
	public class BulkEmailRecipientMacroRepository
	{

		#region Constants: Private

		private const int _maxParametersCountPerQueryBatch = 1000;

		#endregion

		#region Fields: Private

		private readonly UserConnection _userConnection;

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Initializes a new instance of the <see cref="BulkEmailRecipientMacroRepository"/> class.
		/// </summary>
		/// <param name="userConnection">The user connection.</param>
		public BulkEmailRecipientMacroRepository(UserConnection userConnection) {
			_userConnection = userConnection;
		}

		#endregion

		#region Methods: Private

		private int CalculateChunks(int macrosCount, int columnsCount) {
			var maxParamsPerChunk = Math.Abs(_maxParametersCountPerQueryBatch / columnsCount);
			return (int)Math.Ceiling(macrosCount / (double)maxParamsPerChunk);
		}

		private void InsertMacrosBatches(Guid bulkEmailId,
				IEnumerable<IEnumerable<KeyValuePair<Guid, string>>> macrosBatches) {
			var currentDate = DateTime.UtcNow;
			foreach (var batch in macrosBatches) {
				var insertQuery = new Insert(_userConnection).Into("BulkEmailRecipientMacro");
				foreach (var macros in batch) {
					insertQuery.Values();
					insertQuery.Set("RecipientUId", Column.Parameter(macros.Key));
					insertQuery.Set("Macros", Column.Parameter(macros.Value));
					insertQuery.Set("BulkEmailId", Column.Parameter(bulkEmailId));
				}
				insertQuery.Execute();
			}
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Saves the specified recipient macros for the specified bulk email.
		/// </summary>
		/// <param name="bulkEmailId">The bulk email identifier.</param>
		/// <param name="recipientMacrosCollection">The recipient macros collection.</param>
		public virtual void Save(Guid bulkEmailId, Dictionary<Guid,
			IEnumerable<BulkEmailMacroInfo>> recipientMacrosCollection) {
			var parametersPerInsertRow = 3;
			var chunksCount = CalculateChunks(recipientMacrosCollection.Count, parametersPerInsertRow);
			var macrosBatches = recipientMacrosCollection
				.Select(x => new KeyValuePair<Guid, string>(x.Key, JsonConvert.SerializeObject(x.Value))).SplitOnParts(chunksCount);
			InsertMacrosBatches(bulkEmailId, macrosBatches);
		}

		/// <summary>
		/// Parse macros string to <see cref="IEnumerable<BulkEmailMacroInfo>"/>.
		/// </summary>
		/// <param name="value">Source macros string.</param>
		/// <returns><see cref="IEnumerable<BulkEmailMacroInfo>"/></returns>
		public IEnumerable<BulkEmailMacroInfo> ParseBulkEmailMacroInfo(string value) {
			return JsonConvert.DeserializeObject<IEnumerable<BulkEmailMacroInfo>>(value);
		}

		#endregion

	}

	#endregion
}
