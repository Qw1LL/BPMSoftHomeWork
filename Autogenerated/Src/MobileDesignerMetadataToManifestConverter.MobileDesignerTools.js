define("MobileDesignerMetadataToManifestConverter", [],
	function() {

		/**
		 * @class BPMSoft.MobileDesignerMetadataToManifestConverter
		 * @public
		 * #####, ############# ########## ########## # ########## #########.
		 */
		Ext.define("BPMSoft.MobileDesignerMetadataToManifestConverter", {

			//region Properties: Private

			metadata: null,

			designerConfig: null,

			entitySchemaName: null,

			settingsSchemaName: null,

			//endregion

			//region Methods: Private

			/**
			 * @private
			 */
			isInsertOperation: function(metadataItem) {
				return metadataItem.operation === "insert";
			},

			/**
			 * @private
			 */
			isEmbeddedDetailColumn: function(metadataItem) {
				var designerConfig = this.designerConfig;
				var columnSets = designerConfig.columnSets;
				for (var i = 0, ln = columnSets.length; i < ln; i++) {
					var columnSetConfig = columnSets[i];
					if (columnSetConfig.isDetail && metadataItem.parentName === columnSetConfig.name) {
						return true;
					}
				}
				return false;
			},

			/**
			 * @private
			 */
			processGridPageMetadata: function() {
				var gridColumnNames = [];
				var items = this.metadata;
				for (var i = 0, ln = items.length; i < ln; i++) {
					var gridMetadataItem = items[i];
					if (gridMetadataItem.operation === "remove" || gridMetadataItem.operation === "move") {
						continue;
					}
					var metadataItemValues = gridMetadataItem.values;
					var columnName = metadataItemValues.columnName;
					if (this.isInsertOperation(gridMetadataItem) && !Ext.isEmpty(columnName)) {
						gridColumnNames.push(columnName);
					}
				}
				this.manifest.setGridPageColumns(this.entitySchemaName, gridColumnNames);
			},

			/**
			 * @private
			 */
			processRecordPageEmbeddedDetails: function() {
				var designerConfig = this.designerConfig;
				var columnSets = designerConfig.columnSets;
				if (!columnSets) {
					return;
				}
				var embeddedDetails = {};
				for (var i = 0, ln = columnSets.length; i < ln; i++) {
					var columnSet = columnSets[i];
					if (columnSet.isDetail) {
						var columns = [columnSet.filter.detailColumn];
						for (var j = 0, lnj = columnSet.items.length; j < lnj; j++) {
							var columnSetColumn = columnSet.items[j];
							columns.push(columnSetColumn.columnName);
						}
						var config = {
							SyncColumns: columns
						};
						if (columnSet.detailType === BPMSoft.MobileDesignerEnums.EmbeddedDetailType.Visa) {
							this.applyVisaImportConfig(config);
						}
						embeddedDetails[columnSet.entitySchemaName] = config;
					}
				}
				this.manifest.setEmbeddedDetails(this.entitySchemaName, embeddedDetails);
			},

			/**
			 * @private
			 */
			applyVisaImportConfig: function(config) {
				config.SyncColumns = Ext.Array.merge(config.SyncColumns, ["Status", "VisaOwner", "IsCanceled"]);
				config.QueryFilter = {
					"filterType": 6,
					"isEnabled": true,
					"logicalOperation": 0,
					"items": {
						"CurrentUser": {
							"comparisonType": 15,
							"filterType": 5,
							"isEnabled": true,
							"leftExpression": {
								"columnPath": "[SysAdminUnitInRole:SysAdminUnitRoleId:VisaOwner].Id",
								"expressionType": 0
							},
							"subFilters": {
								"filterType": 6,
								"isEnabled": true,
								"items": {
									"detailedFilter": {
										"comparisonType": 3,
										"filterType": 1,
										"isEnabled": true,
										"leftExpression": {
											"columnPath": "SysAdminUnit",
											"expressionType": 0
										},
										"rightExpression": {
											"expressionType": 1,
											"functionType": 1,
											"macrosType": 1
										},
										"trimDateTimeParameterToDate": false
									}
								},
								"logicalOperation": 0,
								"rootSchemaName": "SysAdminUnitInRole"
							},
							"trimDateTimeParameterToDate": false
						},
						"StatusNotFinal": {
							"filterType": 6,
							"isEnabled": true,
							"items": {
								"item0": {
									"comparisonType": 1,
									"filterType": 2,
									"isEnabled": true,
									"isNull": true,
									"leftExpression": {
										"columnPath": "Status",
										"expressionType": 0
									},
									"trimDateTimeParameterToDate": false
								},
								"item1": {
									"comparisonType": 3,
									"filterType": 1,
									"isEnabled": true,
									"leftExpression": {
										"columnPath": "Status.IsFinal",
										"expressionType": 0
									},
									"rightExpression": {
										"expressionType": 2,
										"parameter": {
											"dataValueType": 12,
											"value": false
										}
									},
									"trimDateTimeParameterToDate": false
								}
							},
							"logicalOperation": 1
						},
						"IsNotCanceled": {
							"comparisonType": 3,
							"filterType": 1,
							"isEnabled": true,
							"leftExpression": {
								"columnPath": "IsCanceled",
								"expressionType": 0
							},
							"rightExpression": {
								"expressionType": 2,
								"parameter": {
									"dataValueType": 12,
									"value": false
								}
							},
							"trimDateTimeParameterToDate": false
						}
					}
				};
			},

			/**
			 * @private
			 */
			processRecordPageMetadata: function() {
				var items = this.metadata;
				var recordPageColumnNames = [];
				var detailNames = [];
				var details = {};
				for (var i = 0, ln = items.length; i < ln; i++) {
					var metadataItem = items[i];
					if (metadataItem.operation === "remove" || this.isEmbeddedDetailColumn(metadataItem)) {
						continue;
					}
					var metadataItemValues = metadataItem.values;
					var columnName = metadataItemValues.columnName;
					if (metadataItem.propertyName === "details") {
						details[metadataItemValues.entitySchemaName] = [metadataItemValues.filter.detailColumn];
						continue;
					}
					if (metadataItemValues.isDetail) {
						detailNames.push(metadataItem.name);
						continue;
					}
					if (this.isInsertOperation(metadataItem) && !Ext.isEmpty(columnName) &&
						detailNames.indexOf(metadataItem.parentName) === -1) {
						recordPageColumnNames.push(columnName);
					}
				}
				this.manifest.setRecordPageColumns(this.entitySchemaName, recordPageColumnNames);
				this.manifest.setStandartDetails(this.entitySchemaName, details);
				this.processRecordPageEmbeddedDetails();

			},

			//endregion

			//region Methods: Public

			/**
			 * ##### ############# ########## ########## # ########## #########.
			 * @param {Object} config ################ ###### # ########### ###### ######:
			 * @param {Object} config.manifest ###### #########.
			 * @param {String} config.entitySchemaName ### #######.
			 * @param {String} config.settingsType ### #########.
			 * @param {String} config.settingsSchemaName ### ##### ########### # ########.
			 */
			applyMetadataToManifest: function(config) {
				var manifest = this.manifest = config.manifest;
				this.metadata = config.metadata;
				this.designerConfig = config.designerConfig;
				var entitySchemaName = this.entitySchemaName = config.entitySchemaName;
				var settingsType = config.settingsType;
				manifest.addSettingsPage(entitySchemaName, config.settingsSchemaName);
				if (settingsType === BPMSoft.MobileDesignerEnums.SettingsType.GridPage) {
					this.processGridPageMetadata();
				} else if (settingsType === BPMSoft.MobileDesignerEnums.SettingsType.RecordPage) {
					this.processRecordPageMetadata();
				}
			}

			//endregion

		});

		return BPMSoft.MobileDesignerMetadataToManifestConverter;

	}
);
