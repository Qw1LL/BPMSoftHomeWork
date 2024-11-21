namespace BPMSoft.Configuration.GlobalSearch
{
	using System;
	using System.Collections.Generic;
	using GlobalSearchColumnUtils;
	using BPMSoft.Core;
	using BPMSoft.Core.Factories;
	using BPMSoft.GlobalSearch;

	#region Class: ESSearchColumnNameProvider

	/// <summary>
	/// Elastic search based implementation of <see cref="ISearchColumnNameProvider"/>
	/// </summary>
	[DefaultBinding(typeof(ISearchColumnNameProvider))]
	public class ESSearchColumnNameProvider : ISearchColumnNameProvider
	{

		#region Constants: Private

		private readonly HashSet<string> CommunicationDetails =
			new HashSet<string> {"ContactCommunication", "AccountCommunication"};
		private const string LookupColumnSuffix = "id";

		#endregion

		#region Fields: Private

		private readonly UserConnection _userConnection;
		private readonly GlobalSearchColumnUtils _globalSearchColumnUtils;

		#endregion

		#region Constructors: Public

		public ESSearchColumnNameProvider(UserConnection userConnection) {
			_userConnection = userConnection;
			_globalSearchColumnUtils = GlobalSearchColumnUtils.Instance;
		}

		#endregion

		#region Methods: Private

		private string BuildCommunicationDetailField(string filterType, string detailSchemaName) {
			var filterTypeGuid = Guid.Parse(filterType);
			var columnName = ESConstants.DetailsPrefix;
			if (filterTypeGuid == CommunicationConsts.PhoneTypeId
				|| filterTypeGuid == CommunicationConsts.SMSTypeId) {
				columnName += $".{detailSchemaName}_phone{ESConstants.NumberColumnSuffix}";
				columnName += $".phone{ESConstants.NumberColumnSuffix}";
			} else {
				columnName += $".{detailSchemaName}_text.text";
			}
			return columnName;
		}

		private string BuildDetailField(SearchColumn searchColumn) {
			var detailSchemaName = searchColumn.SchemaName;
			var detailSchema = _userConnection.EntitySchemaManager.GetInstanceByName(detailSchemaName);
			if (CommunicationDetails.Contains(detailSchemaName)) {
				return BuildCommunicationDetailField(searchColumn.Type, detailSchemaName);
			} else {
				var detailColumn = detailSchema.Columns.GetByName(searchColumn.ColumnName);
				var columnName = _globalSearchColumnUtils.GetAlias(detailColumn, detailSchema);
				columnName = $"{ESConstants.DetailsPrefix}.{detailSchemaName}.{columnName}";
				return columnName;
			}
		}

		private string BuildSchemaField(SearchColumn searchColumn) {
			var searchColumnEntitySchema = _userConnection.EntitySchemaManager.GetInstanceByName(searchColumn.ReferenceSchemaName);
			var filterColumn = searchColumnEntitySchema.Columns.GetByName(searchColumn.ColumnName);
			var columnName = filterColumn.IsLookupType
				? _globalSearchColumnUtils.GetPrimaryColumnAlias(filterColumn, searchColumn.SchemaName)
				: _globalSearchColumnUtils.GetAlias(filterColumn, searchColumnEntitySchema);
			return columnName.ToLowerInvariant();
		}

		private string BuildField(SearchColumn searchColumn) {
			if (searchColumn.SchemaName == searchColumn.ReferenceSchemaName) {
				return BuildSchemaField(searchColumn);
			} else {
				return BuildDetailField(searchColumn);
			}
		}

		#endregion

		#region Methods: Public

		public string GetSearchColumnName(SearchColumn searchColumn) {
			return BuildField(searchColumn);
		}

		#endregion
	}

	#endregion

}
