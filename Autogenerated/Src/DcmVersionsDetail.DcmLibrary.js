/**
 * Page schema for dcm versions detail.
 * Parent: ProcessVersionsDetail.
 */
define("DcmVersionsDetail", ["DcmVersionsDetailResources"],
	function() {
		return {

			/**
			 * Entity schema name.
			 * @type {String}
			 */
			entitySchemaName: "VwSysDcmLib",
			methods: {

				/**
				 * @inheritdoc BPMSoft.GridUtilities#initQueryColumns
				 * @overridden
				 */
				initQueryColumns: function(esq) {
					this.callParent(arguments);
					esq.addColumn("Filters", "SerializedFilters");
					esq.addColumn("StageColumnUId", "SchemaStageColumnUId");
				},

				/**
				 * @inheritdoc ProcessVersionsDetail#setActiveVersion
				 * @override
				 */
				setActiveVersion: function() {
					this.showBodyMask();
					const activeRow = this.getActiveRow();
					const newVersionUId = activeRow.get("UId");
					const newVersionId = this.get("ActiveRow");
					const previousVersionId = this.get("MasterRecordId");
					const versionChangeInfo = {
						previousVersionId: previousVersionId,
						activeVersionId: newVersionId
					};
					const filters = activeRow.get("SerializedFilters");
					const stageColumnUId = activeRow.get("SchemaStageColumnUId");
					const callback = function(response, errorMessage) {
						if (errorMessage) {
							this.hideBodyMask();
							this.showInformationDialog(errorMessage);
						} else {
							this.onActiveVersionChanged(versionChangeInfo);
						}
					};
					const dcmSettingsId = this._findDcmSettingsId(newVersionUId);
					const config = {
						schemaUId: newVersionUId,
						filters: filters,
						stageColumnUId: stageColumnUId,
						dcmSettingsId: dcmSettingsId
					};
					BPMSoft.DcmSchemaManager.setIsActualVersion(config, callback, this);
				},

				/**
				 * @inheritdoc ProcessVersionsDetail#openProcessDesigner
				 * @override
				 */
				openProcessDesigner: function(processSchemaUId) {
					const schemaUId = processSchemaUId || this.get("ActiveRow");
					BPMSoft.ProcessModuleUtilities.showDcmSchemaDesignerById(schemaUId);
					this.set("ProcessActionTag", "OpenProcess");
					this.sendGoogleTagManagerData();
				},

				/**
				 * @inheritdoc BPMSoft.GridUtilitiesV2#getGridDataColumns
				 * @overridden
				 */
				getGridDataColumns: function() {
					const gridDataColumns = this.callParent(arguments);
					if (!gridDataColumns.UId) {
						gridDataColumns.UId = {
							path: "UId"
						}
					}
					return gridDataColumns;
				},

				/**
				 * @inheritdoc ProcessVersionsDetail#addExecutionTraceOptions
				 * @override
				 */
				addExecutionTraceOptions: BPMSoft.emptyFn,

				/**
				 * Returns DCM settings Id.
				 * @private
				 * @param {String} schemaUId Schema unique identifier.
				 * return {String|null}
				 */
				_findDcmSettingsId: function(schemaUId) {
					const manager = BPMSoft.SysDcmSchemaInSettingsManager;
					const dcmSchemaInSettingsItem = manager.findItemBySysDcmSchemaUId(schemaUId);
					return dcmSchemaInSettingsItem && dcmSchemaInSettingsItem.getSysDcmSettings();
				}
			}
		};
	}
);