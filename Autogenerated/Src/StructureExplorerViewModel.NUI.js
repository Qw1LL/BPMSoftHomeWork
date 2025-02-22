﻿define("StructureExplorerViewModel", ["ext-base", "BPMSoft", "ModalBox", "StructureExplorerUtilities",
	"StructureExplorerUtilitiesV2"],
function(Ext, BPMSoft) {
	var viewModel;
	function requiredValidator(value) {
		var invalidMessage = "";
		var result = {
			invalidMessage: invalidMessage
		};
		if (value) {
			return result;
		}
		result.invalidMessage = BPMSoft.Resources.BaseViewModel.columnRequiredValidationMessage;
		return result;
	}

	function generateMainViewModel() {
		viewModel = Ext.create("BPMSoft.BaseViewModel", {
				columns: {
					EntitySchemaColumn: {
						columnType: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						isRequired: true
					}
				},
				values: {
					caption: "...",
					ExpandVisible: true,
					RemoveVisible: false,
					ComboBoxListEnabled: true,
					EntitySchemaColumnList: new BPMSoft.Collection(),
					EntitySchemaColumn: null,
					entitySchema: null
				},
				methods: {
					onCancelClick: function() {
						BPMSoft.StructureExplorerUtilities.closeModalBox();
					},
					getItems: function(filter, list) {
						var entitySchema = this.get("entitySchema");
						list.sortByFn(function(a, b) {
							var primaryColumnName = entitySchema && entitySchema.primaryColumnName;
							if (primaryColumnName) {
								if (a.columnName === primaryColumnName) {
									return 1;
								}
								if (b.columnName === primaryColumnName) {
									return -1;
								}
							}
							return a.order - b.order === 0
								? a.displayValue.localeCompare(b.displayValue)
								: a.order - b.order;
						});
						list.loadAll({});
					},
					onKeyDown: function(event) {
						if (event) {
							var key = event.getKey();
							if (key === event.ENTER && this.get("EntitySchemaColumn")) {
								this.select();
							}
						}
					},
					close: function() {}
				}
			}
		);
		return viewModel;
	}

	function generateItemViewModel() {
		return Ext.create("BPMSoft.BaseViewModel", {
				columns: {
					EntitySchemaColumn: {
						columnType: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						isRequired: true
					}
				},
				values: {
					EntitySchemaColumnList: new BPMSoft.Collection(),
					EntitySchemaColumn: null,
					ExpandVisible: true,
					ExpandEnable: false,
					RemoveVisible: false,
					CloseVisible: true,
					ComboBoxListEnabled: true,
					entitySchema: null
				},
				methods: {
					getItems:  function(filter, list) {
						list.sortByFn(function(a, b) { return a.displayValue.localeCompare(b.displayValue); });
						list.loadAll({});
					}
				},
				validationConfig: {
					EntitySchemaColumn: [requiredValidator]
				}
			}
		);
	}
	return {
		generate: generateMainViewModel,
		generateItem: generateItemViewModel
	};
});
