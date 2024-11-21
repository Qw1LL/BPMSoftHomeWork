namespace BPMSoft.Configuration.GlobalSearchColumnUtils {

	using System;
	using System.Collections.Generic;
	using System.Linq;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;
	using BPMSoft.GlobalSearch;

	#region Class: GlobalSearchColumnUtils

	public class GlobalSearchColumnUtils
	{

		#region Properties: Public

		/// <summary>
		/// List of entity phone columns.
		/// </summary>
		private readonly Dictionary<string, HashSet<string>> _numberColumns = new Dictionary<string, HashSet<string>> {
			{"Contact", new HashSet<string> {
				"Phone", "MobilePhone", "HomePhone"
			}},
			{"Account", new HashSet<string> {
				"Phone", "AdditionalPhone"
			}},
			{"Lead", new HashSet<string> {
				"MobilePhone", "BusinesPhone"
			}}
		};
		public virtual Dictionary<string, HashSet<string>> NumberColumns => _numberColumns;

		/// <summary>
		/// Signle instance of this class.
		/// </summary>
		private static GlobalSearchColumnUtils _instance;
		public static GlobalSearchColumnUtils Instance {
			get {
				if (_instance == null ) {
					_instance = ClassFactory.Get<GlobalSearchColumnUtils>();
				}
				return _instance;
			}
		}

		/// <summary>
		/// Pattern for relation columns field names.
		/// </summary>
		public virtual string RelationColumnsFieldPattern => "*_*_id";

		#endregion

		#region Methods: Private

		private bool IsNumberColumn(EntitySchemaColumn column, EntitySchema entitySchema) {
			return NumberColumns.Any(pc => pc.Key == entitySchema.Name && pc.Value.Contains(column.Name));
		}

		private string GetAliasFormat(EntitySchema entitySchema, EntitySchemaColumn entitySchemaColumn) {
			var entityColumnFormat = "{0}_{1}";
			if (entitySchema.PrimaryDisplayColumn?.UId == entitySchemaColumn.UId || entitySchemaColumn.IsLookupType) {
				if (GlobalAppSettings.FeatureIndexCommunicationOptionsAndLookupsBy2Symbols 
						&& !GetIsSysImageLookupColumn(entitySchemaColumn)) {
					return string.Format("{0}{1}", entityColumnFormat, ESConstants.PrimaryColumnsSuffix);
				} else {
					return entityColumnFormat;
				}
			} else {
				return IsNumberColumn(entitySchemaColumn, entitySchema) ?
					string.Format("{0}{1}", entityColumnFormat, ESConstants.NumberColumnSuffix) :
					entityColumnFormat;
			}
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Get primary lookup column name for indexable column.
		/// </summary>
		/// <param name="column"><see cref="EntitySchemaColumn"/> instance of indexable column.</param>
		/// <returns>Correct column name.</returns>
		public string GetPrimaryLookupColumn(EntitySchemaColumn column) {
			var columnRefSchema = column.ReferenceSchema;
			var primaryColumn = columnRefSchema.PrimaryColumn;
			if (primaryColumn == null) {
				return string.Empty;
			}
			return String.Format("{0}.{1}", column.Name, primaryColumn.Name);
		}

		/// <summary>
		/// Get image lookup column name for indexable column.
		/// </summary>
		/// <param name="column"><see cref="EntitySchemaColumn"/> instance of indexable column.</param>
		/// <returns>Correct column name.</returns>
		public string GetImageLookupColumn(EntitySchemaColumn column) {
			var columnRefSchema = column.ReferenceSchema;
			var primaryImageColumn = columnRefSchema.PrimaryImageColumn;
			if (primaryImageColumn == null || !primaryImageColumn.DataValueType.IsLookup) {
				return string.Empty;
			}
			return String.Format("{0}.{1}.Id", column.Name, primaryImageColumn.Name);
		}

		/// <summary>
		/// Get column name for indexable column.
		/// </summary>
		/// <param name="column"><see cref="EntitySchemaColumn"/> instance of indexable column.</param>
		/// <returns>Correct column name.</returns>
		public string GetColumnName(EntitySchemaColumn column) {
			string columnName = column.Name;
			if (column.DataValueType.IsLookup) {
				var columnRefSchema = column.ReferenceSchema;
				var primaryDisplayColumn = columnRefSchema.PrimaryDisplayColumn;
				columnName = primaryDisplayColumn != null ? 
					String.Format("{0}.{1}", columnName, primaryDisplayColumn.Name) : string.Empty;
			}
			return columnName;
		}

		/// <summary>
		/// Get alias of indexable column for logstash.
		/// </summary>
		/// <param name="column"><see cref="EntitySchemaColumn"/> column for what alias creates.</param>
		/// <param name="entitySchema"><see cref="EntitySchema"/> instance.</param>
		/// <returns>Alias for indexable column.</returns>
		public string GetAlias(EntitySchemaColumn column, EntitySchema entitySchema) {
			var schemaName = entitySchema.Name;
			var isPrimaryColumn = entitySchema.PrimaryColumn.Name == column.Name;
			if (isPrimaryColumn) {
				return column.Name;
			}
			string aliasFormat = GetAliasFormat(entitySchema, column);
			return string.Format(aliasFormat, schemaName, column.Name).ToLowerInvariant();
		}

		/// <summary>
		/// Get alias of indexable lookup primary column column for logstash.
		/// </summary>
		/// <param name="column"><see cref="EntitySchemaColumn"/> column for what alias creates.</param>
		/// <param name="schemaName">Column entitySchema name.</param>
		/// <returns>Alias for indexable column.</returns>
		public string GetPrimaryColumnAlias(EntitySchemaColumn column, string schemaName) {
			return string.Format("{0}_{1}_id", schemaName, column.Name).ToLowerInvariant();
		}

		/// <summary>
		/// Get alias of indexable lookup image column for logstash.
		/// </summary>
		/// <param name="column"><see cref="EntitySchemaColumn"/> column for what alias creates.</param>
		/// <param name="schemaName">Column entitySchema name.</param>
		/// <returns>Alias for indexable column.</returns>
		public string GetPrimaryImageColumnAlias(EntitySchemaColumn column, string schemaName) {
			return string.Format("{0}_{1}_image", schemaName, column.Name).ToLowerInvariant();
		}

		/// <summary>
		/// Returns true when column is sys image lookup.
		/// </summary>
		/// <param name="column"><see cref="EntitySchemaColumn"/> instance.</param>
		/// <returns>Sys image lookup column tag.</returns>
		public bool GetIsSysImageLookupColumn(EntitySchemaColumn column) {
			return column.DataValueType.IsLookup && column.ReferenceSchema != null && column.ReferenceSchema.Name == "SysImage";
		}

		/// <summary>
		/// Returns true when column is indexed data value type.
		/// </summary>
		/// <param name="column"><see cref="EntitySchemaColumn"/> instance.</param>
		/// <returns>Is indexed column data value type.</returns>
		public bool IsIndexedColumnType(EntitySchemaColumn column) {
			bool isText = column.DataValueType is TextDataValueType;
			bool isLookup = column.DataValueType.IsLookup;
			return isText || isLookup;
		}

		/// <summary>
		/// Gets column is primary.
		/// </summary>
		/// <param name="entitySchema"><see cref="EntitySchema"/> schema.</param>
		/// <param name="column"><see cref="EntitySchemaColumn"/> column.</param>
		/// <returns>True if column is primary.</returns>
		public bool IsPrimaryColumn(EntitySchema entitySchema, EntitySchemaColumn column) {
			return entitySchema.PrimaryColumn != null && entitySchema.PrimaryColumn.Name == column.Name;
		}

		#endregion

	}

	#endregion

}

