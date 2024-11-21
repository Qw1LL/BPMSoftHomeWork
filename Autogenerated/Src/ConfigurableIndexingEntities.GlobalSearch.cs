 namespace BPMSoft.Configuration.GlobalSearch
{
	using System;
	using System.Linq;
	using System.Text.RegularExpressions;
	using BPMSoft.Common.Json;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;

	#region Class: ConfigurableIndexingEntities
	
	public class ConfigurableIndexingEntities : IgnoredEntityList
	{

		#region Constants: Private

		private const string AllMacros = "*";

		#endregion
		
		#region Fields: Private

		private readonly UserConnection _userConnection;

		#endregion
		
		#region Properties: Protected
		
		private string _indexedDataConfigSysValue;
		protected string IndexedDataConfigSysValue {
			get {
				if (Core.Configuration.SysSettings.TryGetValue(_userConnection, "GlobalSearchIndexedDataConfig",
					out object value)) {
					_indexedDataConfigSysValue = (string)value;
				} else {
					_indexedDataConfigSysValue = null;
				}
				return _indexedDataConfigSysValue;
			}
		}

		private IndexedDataConfig _indexedDataConfig;
		protected IndexedDataConfig NotIndexedDataConfig {
			get {
				if (_indexedDataConfig != null) {
					return _indexedDataConfig;
				}
				try {
					_indexedDataConfig = Json.Deserialize<IndexedDataConfig>(IndexedDataConfigSysValue);
				} catch {
					return null;
				}
				return _indexedDataConfig;
			}
		}
		
		#endregion

		#region Constructors: Public
		
		public ConfigurableIndexingEntities(UserConnection userConnection) {
			_userConnection = userConnection;
		}
		
		#endregion

		#region Methods: Private
		
		private bool IsIgnoredColumnByMultipleSections(EntitySchema schema, EntitySchemaColumn column) {
			var allSectionsIgnoredColumnPatterns = GetAllSectionsIgnoredColumnPatterns();
			return allSectionsIgnoredColumnPatterns
				.Any(pattern => IsColumnMatchPattern(schema, column, pattern));
		}
		
		private string[] GetAllSectionsIgnoredColumnPatterns() {
			var defaultIgnoredColumns = new string[] { };
			if (NotIndexedDataConfig.TryGetValue(AllMacros, out var sectionConfig)) {
				return sectionConfig?.IgnoredColumns ?? defaultIgnoredColumns;
			}
			return defaultIgnoredColumns;
		}
		
		private bool IsColumnMatchPattern(EntitySchema schema, EntitySchemaColumn column, string pathOrAliasPattern) {
			var columnPath = $"{schema.Name}.{column.Name}";
			var columnAlias = GlobalSearchColumnUtils.GetAlias(column, schema);
			var isFindInPath = Regex.IsMatch(columnPath, pathOrAliasPattern, RegexOptions.IgnoreCase);
			var isFindInAlias = Regex.IsMatch(columnAlias, pathOrAliasPattern, RegexOptions.IgnoreCase);
			return isFindInPath || isFindInAlias;
		}

		private bool IsIgnored(string schemaName, string columnName) {
			if (NotIndexedDataConfig.TryGetValue(schemaName, out var sectionConfig)) {
				return sectionConfig?.IgnoredColumns.Contains(columnName, StringComparer.OrdinalIgnoreCase) ?? false;
			}
			return false;
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc cref="IgnoredEntityList.GetIsIgnoredColumn"/>
		public override bool GetIsIgnoredColumn(EntitySchema schema, EntitySchemaColumn column) {
			if (NotIndexedDataConfig == null) {
				return base.GetIsIgnoredColumn(schema, column);
			}
			var isIgnoredSection = GetIsIgnoredSection(schema);
			if (isIgnoredSection) {
				return true;
			}
			var isIgnoredByMultipleSections = IsIgnoredColumnByMultipleSections(schema, column);
			if (isIgnoredByMultipleSections) {
				return true;
			}
			return IsIgnored(schema.Name, column.Name);
		}
		
		/// <inheritdoc cref="IgnoredEntityList.GetIsIgnoredSection"/>
		public override bool GetIsIgnoredSection(EntitySchema schema) {
			if (NotIndexedDataConfig == null) {
				return base.GetIsIgnoredSection(schema);
			}
			if (schema?.IsDBView != false) {
				return true;
			}
			return IsIgnored(schema.Name, AllMacros);
		}

		#endregion
		
	}

	#endregion
	
}

