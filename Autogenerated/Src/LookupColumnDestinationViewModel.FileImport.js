define("LookupColumnDestinationViewModel", ["ColumnDestinationViewModel"], function() {
	/**
	 * @class BPMSoft.configuration.LookupColumnDestinationViewModel
	 * Class is responsible to view lookup destination column path.
	 */
	Ext.define("BPMSoft.configuration.LookupColumnDestinationViewModel", {
		alternateClassName: "BPMSoft.LookupColumnDestinationViewModel",
		extend: "BPMSoft.ColumnDestinationViewModel",

		//region Properties: Private

		/**
		 * Delimiter for schema name and column name.
		 * @private
		 * @type {String}
		 */
		separator: "\u2192",

		//endregion

		//region Properties: Public

		/**
		 * @inheritdoc BPMSoft.ColumnDestinationViewModel#columns
		 * @overridden
		 */
		columns: {
			"Id": {
				dataValueType: BPMSoft.DataValueType.GUID
			},
			"IsKey": {
				dataValueType: BPMSoft.DataValueType.BOOLEAN
			},
			"ColumnName": {
				dataValueType: BPMSoft.DataValueType.TEXT
			},
			"ColumnValueName": {
				dataValueType: BPMSoft.DataValueType.TEXT
			},
			"ImportColumnName": {
				dataValueType: BPMSoft.DataValueType.TEXT
			},
			"ImportColumnCaption": {
				dataValueType: BPMSoft.DataValueType.TEXT
			},
			"Schema": {
				dataValueType: BPMSoft.DataValueType.CUSTOM_OBJECT
			}
		},

		//endregion

		//region Methods: Private

		/**
		 * Initializes import column caption.
		 * @private
		 */
		initImportColumnCaption: function() {
			var property = BPMSoft.findWhere(this.get("Properties"), {Key: "ImportColumnCaption"});
			var importColumnCaption = property.Value;
			this.set("ImportColumnCaption", importColumnCaption);
		},

		//endregion

		//region Methods: Public

		/**
		 * @inheritdoc BPMSoft.ColumnDestinationViewModel#constructor
		 * @overridden
		 */
		constructor: function() {
			this.callParent(arguments);
			this.initImportColumnCaption();
		},

		/**
		 * @inheritdoc BPMSoft.ColumnDestinationViewModel#getPath
		 * @overridden
		 */
		getPath: function() {
			var columnCaption = this.getColumnCaption();
			return Ext.String.format("{0} {1} {2}", columnCaption, this.separator, this.get("ImportColumnCaption"));
		}

		//endregion

	});
});
