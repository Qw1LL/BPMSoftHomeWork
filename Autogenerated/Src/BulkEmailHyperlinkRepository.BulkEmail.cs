namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text.RegularExpressions;
	using MandrillService;
	using Core;
	using Core.DB;

	#region Class: BulkEmailHyperlinkRepository

	/// <summary>
	/// Provides methods to save hyperlinks from template.
	/// </summary>
	public class BulkEmailHyperlinkRepository
	{

		#region Constants: Private

		private const string _trackIdQueryParameterName = "bpmtrackid";
		private const string _replicaQueryParameterName = "bpmreplica";
		private const string _queryParametersRegexpPattern = @"[\?&](([^&=]+)=([^&=#]*))";
		private const string _bulkEmailHyperlinkTableName = nameof(BulkEmailHyperlink);

		#endregion

		#region Fields: Private

		private readonly UserConnection _userConnection;

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Initializes a new instance of the <see cref="BulkEmailHyperlinkRepository"/> class.
		/// </summary>
		/// <param name="userConnection">The user connection.</param>
		public BulkEmailHyperlinkRepository(UserConnection userConnection) {
			_userConnection = userConnection;
		}

		#endregion

		#region Methods: Private

		private void ClearBulkEmailHyperlinks(Guid bulkEmailId) {
			var delete = new Delete(_userConnection)
				.From(_bulkEmailHyperlinkTableName)
				.Where("BulkEmailId").IsEqual(Column.Parameter(bulkEmailId));
			delete.Execute();
		}

		private int GetIntParameterValue(Dictionary<string, string> query, string queryParameterName) {
			if (!query.ContainsKey(queryParameterName)) {
				return 0;
			}
			var stringValue = query[queryParameterName];
			int.TryParse(stringValue, out var intValue);
			return intValue;
		}

		private Dictionary<string, string> GetParams(string uri) {
			var matches = Regex.Matches(uri, _queryParametersRegexpPattern, RegexOptions.Compiled);
			var matchCollection = matches.Cast<Match>();
			var result = new Dictionary<string, string>();
			foreach (var match in matchCollection) {
				var parameterName = Uri.UnescapeDataString(match.Groups[2].Value).ToLowerInvariant();
				var parameterValue = Uri.UnescapeDataString(match.Groups[3].Value);
				result[parameterName] = parameterValue;
			}
			return result;
		}

		private void SaveHyperlink(Guid bulkEmailId, HyperlinkData hyperlink) {
			var url = UtmHelper.RemoveUtmFromUri(hyperlink.Url);
			var query = GetParams(url);
			var bpmTrackId = GetIntParameterValue(query, _trackIdQueryParameterName);
			var bpmReplicaMask = GetIntParameterValue(query, _replicaQueryParameterName);
			var caption = string.IsNullOrEmpty(hyperlink.Caption) ? url : hyperlink.Caption;
			var insert = new Insert(_userConnection)
				.Into(_bulkEmailHyperlinkTableName)
				.Set("BulkEmailId", Column.Parameter(bulkEmailId))
				.Set("Caption", Column.Parameter(caption))
				.Set("Url", Column.Parameter(url))
				.Set("BpmReplicaMask", Column.Parameter(bpmReplicaMask))
				.Set("BpmTrackId", Column.Parameter(bpmTrackId));
			SetAdditionalColumns(insert, hyperlink.AdditionalColumns);
			insert.Execute();
		}

		private Select GetSelectQueryForCopyHyperlinks(Guid sourceBulkEmailId, Guid targetBulkEmailId) {
			var select = new Select(_userConnection)
				.Column(Column.Parameter(targetBulkEmailId)).As("BulkEmailId")
				.Column("Caption")
				.Column("Url")
				.Column("BpmReplicaMask")
				.Column("BpmTrackId")
				.Column("Hash")
				.From(_bulkEmailHyperlinkTableName)
				.Where("BulkEmailId").IsEqual(Column.Parameter(sourceBulkEmailId)) as Select;
			select.SpecifyNoLockHints();
			return select;
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Sets the additional columns.
		/// </summary>
		/// <param name="insert">The insert.</param>
		/// <param name="hyperlinkColumns">The hyperlink columns dictionary.</param>
		protected virtual void SetAdditionalColumns(Insert insert, Dictionary<string, object> hyperlinkColumns) {
			if(hyperlinkColumns == null || !hyperlinkColumns.Any()) {
				return;
			}
			foreach(var hyperlinkParameter in hyperlinkColumns) {
				insert.Set(hyperlinkParameter.Key, Column.Parameter(hyperlinkParameter.Value));
			}
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Saves the bulk email hyperlinks to database.
		/// </summary>
		/// <param name="bulkEmailId">The bulk email identifier.</param>
		/// <param name="hyperLinks">The hyperlinks.</param>
		public virtual void SaveBulkEmailHyperlinks(Guid bulkEmailId, HyperlinkData[] hyperLinks) {
			ClearBulkEmailHyperlinks(bulkEmailId);
			if (hyperLinks == null || hyperLinks.Length == 0) {
				return;
			}
			foreach(var hyperlink in hyperLinks) {
				SaveHyperlink(bulkEmailId, hyperlink);
			}
		}

		/// <summary>
		/// Copies hyperlinks for new bulk email using source bulk email unique identifier.
		/// </summary>
		/// <param name="sourceBulkEmailId">Source bulk email unique identifier.</param>
		/// <param name="targetBulkEmailId">Unique identifier of target bulk email copy.</param>
		public virtual void CopyBulkEmailHyperlinks(Guid sourceBulkEmailId, Guid targetBulkEmailId) {
			var select = GetSelectQueryForCopyHyperlinks(sourceBulkEmailId, targetBulkEmailId);
			new InsertSelect(_userConnection)
				.Into(_bulkEmailHyperlinkTableName)
				.Set("BulkEmailId", "Caption", "Url", "BpmReplicaMask", "BpmTrackId", "Hash")
				.FromSelect(select)
				.Execute();
		}

		#endregion

	}

	#endregion

	#region Class: HyperlinkData

	/// <summary>
	/// Represents hyperlink data to save into database.
	/// </summary>
	public class HyperlinkData
	{

		#region Properties: Public

		/// <summary>
		/// Gets or sets the URL.
		/// </summary>
		public string Url { get; set; }

		/// <summary>
		/// Gets or sets the url caption.
		/// </summary>
		public string Caption { get; set; }

		/// <summary>
		/// Gets or sets the additional columns dictionary (column name, value).
		/// </summary>
		public Dictionary<string, object> AdditionalColumns { get; set; }

		#endregion

	}

	#endregion

}
