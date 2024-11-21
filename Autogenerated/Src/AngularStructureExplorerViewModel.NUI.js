define("AngularStructureExplorerViewModel", [], function() {
	Ext.define("BPMSoft.configuration.AngularStructureExplorerViewModel", {
		alternateClassName: "BPMSoft.AngularStructureExplorerViewModel",
		extend: "BPMSoft.BaseViewModel",

		callback: null,
		scope: null,

		columns: {
			config: {dataValueType: BPMSoft.DataValueType.OBJECT}
		},

		_getGeneralizedDataValueType: function(type) {
			switch (type) {
				case BPMSoft.DataValueType.SHORT_TEXT:
				case BPMSoft.DataValueType.MEDIUM_TEXT:
				case BPMSoft.DataValueType.LONG_TEXT:
				case BPMSoft.DataValueType.MAXSIZE_TEXT:
				case BPMSoft.DataValueType.TEXT:
				case BPMSoft.DataValueType.SECURE_TEXT:
				case BPMSoft.DataValueType.HASH_TEXT:
					return BPMSoft.DataValueType.TEXT;
				case BPMSoft.DataValueType.FLOAT:
				case BPMSoft.DataValueType.FLOAT1:
				case BPMSoft.DataValueType.FLOAT2:
				case BPMSoft.DataValueType.FLOAT3:
				case BPMSoft.DataValueType.FLOAT4:
				case BPMSoft.DataValueType.FLOAT8:
					return BPMSoft.DataValueType.FLOAT;
				default:
					return type;
			}
		},

		_convertItemsDataValueTypeToGeneralized: function(items) {
			if (!Ext.isArray(items)) {
				return;
			}
			items.forEach(function(item) {
				if (item.data && item.data.dataValueType) {
					item.data.dataValueType = this._getGeneralizedDataValueType(item.data.dataValueType);
				}
			}, this);
		},

		_getArguments: function(result) {
			const value = Ext.isArray(result) ? result[0] : null;
			if (!value) {
				return;
			}
			return {
				caption: value.metaPathCaption.split('.'),
				dataValueType: value.data.dataValueType,
				isBackward: false,
				isLookup: value.data.isLookupType,
				leftExpressionCaption: value.metaPathCaption,
				leftExpressionColumnPath: value.columnPath,
				metaPath: value.metaPath.split('.'),
				path: value.columnPath.split('.'),
				referenceSchemaName: value.data.referenceSchemaName
			}
		},

		/**
		 * Handle selected.
		 * @param {Object} result Selected result.
		 */
		handleSelected: function(result) {
			this._convertItemsDataValueTypeToGeneralized(result);
			const args = this._getArguments(result);
			if (args) {
				this.callback.call(this.scope, args);
			}
		},
	});
	return BPMSoft.AngularStructureExplorerViewModel;
});
