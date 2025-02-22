﻿define("FolderManagerViewModelConfigGenerator", [],
	function() {
		return Ext.define("BPMSoft.FolderManagerViewModelConfigGenerator", {
			extend: "BPMSoft.BaseObject",

			generate: function(parentSandbox, config) {
				var viewModelConfig = {
					entitySchema: config.entitySchema,
					columns: {
						enableMultiSelect: {
							type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
							name: "enableMultiSelect"
						},
						multiSelect: {
							type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
							name: "multiSelect"
						},
						actualFolderId: {
							type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
							name: "actualFolderId"
						}
					},
					values: {
						gridData: new BPMSoft.Collection(),
						multiSelect: config.multiSelect,
						currentFilter: config.currentFilter,
						enableMultiSelect: config.enableMultiSelect,
						selectedRows: config.selectedFolders,
						activeRow: config.currentFilter,
						favoriteGeneratedId: config.favoriteGeneratedId,
						canRename: !Ext.isEmpty(config.currentFilter),
						selectEnabled: config.currentFilter || config.multiSelect,
						expandHierarchyLevels: [],
						administratedButtonVisible: config.entitySchema.administratedByRecords && !config.multiSelect,
						sectionModule: config.sectionEntitySchema,
						isGridDoubleClickAllowed: true,
						isFavoriteSelected: false,
						useStaticFolders: config.useStaticFolders
					},
					_section: config.loadSection,
					_sectionEntitySchema: config.sectionEntitySchema,
					favoriteRootRecordItem: config.favoriteRootRecordItem,
					allFoldersRecordItem: config.allFoldersRecordItem,
					_modifyFolderFunc: config.modifyFolderFunc,
					_entityColumnNameInFolderEntity: config.entityColumnNameInFolderEntity,
					_inFolderEntitySchemaName: config.inFolderEntitySchemaName,
					_activeFolderId: config.activeFolderId,
					sandbox: parentSandbox
				};
				return viewModelConfig;
			}
		});
	}
);
