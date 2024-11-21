define("StructureExplorerViewModelItem", [], function() {
	/**
	 * @class BPMSoft.StructureExplorerViewModelItem
	 */
	Ext.define("BPMSoft.StructureExplorerViewModelItem", {
		extend: "BPMSoft.BaseViewModel",

		sandbox: null,

		columns: {
			EntitySchemaColumn: {
				columnType: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				isRequired: true,
				value: null
			},
			EntitySchemaColumnList: {
				columnType: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			},
			ExpandVisible: {
				columnType: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				value: true
			},
			RemoveVisible: {
				columnType: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				value: false
			},
			ComboBoxListEnabled: {
				columnType: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				value: true
			},
			entitySchema: {
				columnType: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				value: null
			},
			ExpandEnable: {
				columnType: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				value: false
			},
			CloseVisible: {
				columnType: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				value: true
			}
		},

		/**
		 * @inheritdoc BPMSoft.BaseViewModel#constructor
		 * @override
		 */
		constructor: function() {
			this.columns.EntitySchemaColumnList.value = new BPMSoft.Collection();
			this.callParent(arguments);
			this.addEvents(
				"expandItem",
				"entityColumnItemChange",
				"removeItem",
				"closeItem"
			);
		},

		getItems: function(filter, list) {
			list.sortByFn(function(a, b) { return a.displayValue.localeCompare(b.displayValue); });
			list.loadAll({});
		},

		ComboBoxListChange: function(comboBoxValue) {
			this.set("ExpandEnable", true);
			this.set("EntitySchemaColumn", BPMSoft.deepClone(comboBoxValue));
			this.fireEvent("entityColumnItemChange", this, comboBoxValue);
		},

		remove: function() {
			this.fireEvent("removeItem", this);
		},

		close: function() {
			this.fireEvent("closeItem", this);
		},

		expand: function() {
			this.set("ExpandVisible", false);
			this.set("RemoveVisible", true);
			this.set("ComboBoxListEnabled", false);
			this.fireEvent("expandItem", this);
		},

		/**
		 * Returns marker.
		 * @return {String}
		 */
		getMarkerValue: function() {
			return "EntitySchema Level" + this.parentCollection.getCount();
		}
	});

	return BPMSoft.StructureExplorerViewModelItem;
});
