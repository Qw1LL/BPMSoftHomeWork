define("ViewModelSchemaDesignerDetailModalBox", ["css!ViewModelSchemaDesignerDetailModalBoxCss"],
	function() {
		return {
			messages: {

				/**
				 * @message SaveDetailConfig
				 */
				"SaveDetailConfig": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				}
			},
			attributes: {

				/**
				 * Detail name.
				 */
				Detail: {
					dataValueType: BPMSoft.DataValueType.LOOKUP,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: null
				},

				/**
				 * Detail column.
				 */
				DetailEntitySchemaColumn: {
					dataValueType: BPMSoft.DataValueType.LOOKUP,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					size: 250
				},

				/**
				 * Object column.
				 */
				MasterEntitySchemaColumn: {
					dataValueType: BPMSoft.DataValueType.LOOKUP,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					size: 250
				},

				/**
				 * Detail entity schema object.
				 */
				DetailEntitySchema: {
					dataValueType: BPMSoft.DataValueType.CUSTOM_OBJECT,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},

				/**
				 * Master entity schema object.
				 */
				MasterEntitySchema: {
					dataValueType: BPMSoft.DataValueType.CUSTOM_OBJECT,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},

				/**
				 * Localizable detail caption.
				 */
				LocalizableDetailCaption: {
					dataValueType: BPMSoft.DataValueType.LOCALIZABLE_STRING,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},

				/**
				 * Detail caption.
				 */
				DetailCaption: {
					dataValueType: BPMSoft.DataValueType.TEXT,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					size: 250,
					isRequired: true
				},

				/**
				 * Current package UId.
				 */
				PackageUId: {
					dataValueType: BPMSoft.DataValueType.GUID,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: null
				},

				/**
				 * Detail column editing availability.
				 */
				CanEditDetailColumn: {
					dataValueType: BPMSoft.DataValueType.BOOLEAN,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: true
				},

				/**
				 * Connection columns editing availability.
				 */
				CanEditConnectionColumns: {
					dataValueType: BPMSoft.DataValueType.BOOLEAN,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: true
				}
			},
			methods: {

				//region Methods: Private

				/**
				 * @private
				 */
				_lookupSortFn: function(item1, item2) {
					return item1.displayValue.localeCompare(item2.displayValue);
				},

				/**
				 * @private
				 */
				_convertDetailManagerItemToLookupEntity: function(detailManagerItem) {
					return {
						displayValue: detailManagerItem.getCaption(),
						value: detailManagerItem.getId(),
						detailSchemaName: detailManagerItem.getDetailSchemaName(),
						detailSchemaUId: detailManagerItem.getDetailSchemaUId(),
						entitySchemaName: detailManagerItem.getEntitySchemaName(),
						entitySchemaUId: detailManagerItem.getEntitySchemaUId()
					};
				},

				/**
				 * @private
				 */
				_convertEntitySchemaColumnToLookupEntity: function(entitySchemaColumn) {
					return {
						displayValue: entitySchemaColumn.caption.getValue(),
						value: entitySchemaColumn.name
					};
				},

				/**
				 * @private
				 */
				_setDetail: function(detailSchemaName, detailEntitySchemaName) {
					var items = BPMSoft.DetailManager.getItems();
					var detailManagerItem = items.firstOrDefault(function(item) {
						return item.getDetailSchemaName() === detailSchemaName
							&& (!detailEntitySchemaName || item.getEntitySchemaName() === detailEntitySchemaName);
					}, this);
					this.$Detail = this._convertDetailManagerItemToLookupEntity(detailManagerItem);
				},

				/**
				 * @private
				 */
				_setDetailEntitySchema: function(callback, scope) {
					var config = {
						schemaUId: this.$Detail.entitySchemaUId,
						packageUId: this.$PackageUId
					};
					BPMSoft.EntitySchemaManager.findBundleSchemaInstance(config, function(entitySchema) {
						this.$DetailEntitySchema = entitySchema;
						callback.call(scope);
					}, this);
				},

				/**
				 * @private
				 */
				_setDetailCaption: function(localizableDetailCaption, callback, scope) {
					if (localizableDetailCaption) {
						this.$LocalizableDetailCaption = localizableDetailCaption.clone();
						this.$DetailCaption = localizableDetailCaption.getValue();
						callback.call(scope);
					} else {
						const detailSchemaUId = this.$Detail.detailSchemaUId;
						const currentPackageUId = this.$PackageUId;
						const config = {schemaUId: detailSchemaUId, packageUId: currentPackageUId};
						BPMSoft.ClientUnitSchemaManager.findBundleSchemaInstance(config, function(instance) {
							localizableDetailCaption = instance.localizableStrings.get("Caption");
							this.$LocalizableDetailCaption = localizableDetailCaption.clone();
							this.$DetailCaption = localizableDetailCaption.getValue();
							callback.call(scope);
						}, this);
					}
				},

				/**
				 * @private
				 */
				_setDetailEntitySchemaColumn: function(detailEntitySchemaColumnName) {
					var detailEntitySchemaColumn = this.$DetailEntitySchema.columns.firstOrDefault(function(column) {
						return column.name === detailEntitySchemaColumnName;
					}, this);
					if (detailEntitySchemaColumn) {
						this.$DetailEntitySchemaColumn = this._convertEntitySchemaColumnToLookupEntity(detailEntitySchemaColumn);
					}
				},

				/**
				 * @private
				 */
				_setMasterEntitySchemaColumn: function(masterEntitySchemaColumnName) {
					var masterEntitySchemaColumn = this.$MasterEntitySchema.columns.firstOrDefault(function(column) {
						return column.name === masterEntitySchemaColumnName;
					}, this);
					if (masterEntitySchemaColumn) {
						this.$MasterEntitySchemaColumn = this._convertEntitySchemaColumnToLookupEntity(masterEntitySchemaColumn);
					}
				},

				/**
				 * @private
				 */
				_initDetailAttributes: function(detailConfig, callback, scope) {
					this._setDetail(detailConfig.detailSchemaName, detailConfig.detailEntitySchemaName);
					BPMSoft.chain(
						function(next) {
							this._setDetailEntitySchema(next, this);
						},
						function(next) {
							this._setDetailCaption(detailConfig.localizableDetailCaption, next, this);
						},
						function() {
							this._setDetailEntitySchemaColumn(detailConfig.detailEntitySchemaColumn);
							this._setMasterEntitySchemaColumn(detailConfig.masterEntitySchemaColumn);
							callback.call(scope);
						},
						this
					);
				},

				/**
				 * @private
				 */
				_onDetailChanged: function() {
					this.$DetailEntitySchemaColumn = null;
					if (this.$Detail) {
						this.showBodyMask();
						BPMSoft.chain(
							function(next) {
								this._setDetailEntitySchema(next, this);
							},
							function(next) {
								this._setDetailCaption(null, next, this);
							},
							function() {
								this.hideBodyMask();
							},
							this
						);
					} else {
						this.$DetailEntitySchema = null;
						this.$LocalizableDetailCaption = null;
						this.$DetailCaption = null;
					}
				},

				/**
				 * @private
				 */
				_getDetailConfig: function() {
					var isDetailCaptionChanged = this.$LocalizableDetailCaption.getValue() !== this.$DetailCaption;
					if (isDetailCaptionChanged) {
						this.$LocalizableDetailCaption.setValue(this.$DetailCaption);
					}
					return {
						detailSchemaName: this.$Detail.detailSchemaName,
						detailEntitySchemaName: this.$Detail.entitySchemaName,
						detailEntitySchemaColumn: this.$DetailEntitySchemaColumn.value,
						masterEntitySchemaColumn: this.$MasterEntitySchemaColumn.value,
						localizableDetailCaption: this.$LocalizableDetailCaption,
						isDetailCaptionChanged: isDetailCaptionChanged
					};
				},

				/**
				 * @private
				 */
				_prepareEntitySchemaColumnList: function(entitySchema, list) {
					if (list === null) {
						return;
					}
					list.clear();
					if (entitySchema) {
						var columns = entitySchema.columns.select(function(column) {
							return this._convertEntitySchemaColumnToLookupEntity(column);
						}, this);
						columns.sortByFn(this._lookupSortFn);
						list.loadAll(columns);
					}
				},

				//endregion

				//region Methods: Protected

				/**
				 * @inheritDoc BPMSoft.ModalBoxSchemaModule#onRender.
				 * @overridden
				 */
				onRender: function() {
					this.callParent(arguments);
					var boxSize = this.$moduleInfo.modalBoxSize;
					this.updateSize(boxSize.width, boxSize.height);
				},

				/**
				 * @inheritDoc BPMSoft.BaseModalBoxPage#getHeader.
				 * @overridden
				 */
				getHeader: function() {
					return this.get("Resources.Strings.DetailModalBoxHeader");
				},

				/**
				 * @inheritDoc BPMSoft.BaseObject#onDestroy.
				 * @overridden
				 */
				onDestroy: function() {
					this.un("change:Detail", this._onDetailChanged, this);
					this.callParent(arguments);
				},

				//endregion

				//region Methods: Public

				/**
				 * @inheritDoc BPMSoft.ModalBoxSchemaModule#init.
				 * @overridden
				 */
				init: function(callback, scope) {
					this.callParent([function() {
						BPMSoft.chain(
							function(next) {
								this.showBodyMask();
								var moduleInfo = this.$moduleInfo;
								this.$MasterEntitySchema = moduleInfo.masterEntitySchema;
								this.$PackageUId = moduleInfo.packageUId;
								this.$CanEditDetailColumn = moduleInfo.canEditDetailColumn;
								this.$CanEditConnectionColumns = moduleInfo.canEditConnectionColumns;
								if (!Ext.isEmpty(moduleInfo.detailConfig)) {
									this._initDetailAttributes(moduleInfo.detailConfig, next, this);
								} else {
									next();
								}
							},
							function() {
								this.on("change:Detail", this._onDetailChanged, this);
								this.hideBodyMask();
								callback.call(scope);
							},
							this
						);
					}, this]);
				},

				/**
				 * Prepares detail list.
				 * @param {String} filter Filter value.
				 * @param {Object} list Current drop down list.
				 */
				prepareDetailList: function(filter, list) {
					if (list === null) {
						return;
					}
					list.clear();
					var detailCollection = BPMSoft.DetailManager.getItems();
					var columns = detailCollection
						.filterByFn(function(detailManagerItem) {
							return detailManagerItem.getDetailSchemaName() && detailManagerItem.getEntitySchemaName();
						}, this)
						.select(function(detailManagerItem) {
							return this._convertDetailManagerItemToLookupEntity(detailManagerItem);
						}, this);
					columns.sortByFn(this._lookupSortFn);
					list.loadAll(columns);
				},

				/**
				 * Prepares list of detail entity schema columns.
				 * @param {String} filter Filter value.
				 * @param {Object} list Current drop down list.
				 */
				prepareDetailEntitySchemaColumnList: function(filter, list) {
					this._prepareEntitySchemaColumnList(this.$DetailEntitySchema, list);
				},

				/**
				 * Prepares list of master entity schema columns.
				 * @param {String} filter Filter value.
				 * @param {Object} list Current drop down list.
				 */
				prepareMasterEntitySchemaColumnList: function(filter, list) {
					this._prepareEntitySchemaColumnList(this.$MasterEntitySchema, list);
				},

				/**
				 * Publishes save message and closes modal box if entity has valid state.
				 */
				save: function() {
					if (this.validate()) {
						this.sandbox.publish("SaveDetailConfig", this._getDetailConfig(), [this.sandbox.id]);
						this.close();
					}
				}

				//endregion

			},
			businessRules: /**SCHEMA_BUSINESS_RULES*/{
				"Detail": {
					"DetailRequired": {
						"ruleType": 0,
						"property": 2,
						"logical": 0,
						"conditions": [{
							"comparisonType": 3,
							"leftExpression": {
								"type": 1,
								"attribute": "CanEditDetailColumn"
							},
							"rightExpression": {
								"type": 0,
								"value": true
							}
						}]
					}
				},
				"DetailEntitySchemaColumn": {
					"DetailEntitySchemaColumnRequired": {
						"ruleType": 0,
						"property": 2,
						"logical": 0,
						"conditions": [{
							"comparisonType": 3,
							"leftExpression": {
								"type": 1,
								"attribute": "CanEditConnectionColumns"
							},
							"rightExpression": {
								"type": 0,
								"value": true
							}
						}]
					}
				},
				"MasterEntitySchemaColumn": {
					"MasterEntitySchemaColumnRequired": {
						"ruleType": 0,
						"property": 2,
						"logical": 0,
						"conditions": [{
							"comparisonType": 3,
							"leftExpression": {
								"type": 1,
								"attribute": "CanEditConnectionColumns"
							},
							"rightExpression": {
								"type": 0,
								"value": true
							}
						}]
					}
				}
			}/**SCHEMA_BUSINESS_RULES*/,
			details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
			diff: /**SCHEMA_DIFF*/[{
				"operation": "merge",
				"name": "CardContentWrapper",
				"values": {
					"classes": {
						"wrapClassName": ["detail-modal-box"]
					}
				}
			}, {
				"operation": "insert",
				"name": "DetailName",
				"parentName": "CardContentWrapper",
				"propertyName": "items",
				"values": {
					"dataValueType": BPMSoft.DataValueType.ENUM,
					"labelConfig": {
						"caption": {"bindTo": "Resources.Strings.DetailNameCaption"}
					},
					"bindTo": "Detail",
					"controlConfig": {
						"className": "BPMSoft.ComboBoxEdit",
						"prepareList": {"bindTo": "prepareDetailList"},
						"list": {"bindTo": "DetailList"}
					},
					"enabled": {"bindTo": "CanEditDetailColumn"}
				}
			}, {
				"operation": "insert",
				"name": "DetailCaption",
				"parentName": "CardContentWrapper",
				"propertyName": "items",
				"values": {
					"labelConfig": {
						"caption": {"bindTo": "Resources.Strings.DetailCaptionOnThePage"}
					},
					"bindTo": "DetailCaption"
				}
			}, {
				"operation": "insert",
				"name": "DetailEntitySchemaColumn",
				"parentName": "CardContentWrapper",
				"propertyName": "items",
				"values": {
					"dataValueType": BPMSoft.DataValueType.ENUM,
					"bindTo": "DetailEntitySchemaColumn",
					"labelConfig": {
						"caption": {"bindTo": "Resources.Strings.DetailEntitySchemaColumnCaption"}
					},
					"controlConfig": {
						"className": "BPMSoft.ComboBoxEdit",
						"prepareList": {"bindTo": "prepareDetailEntitySchemaColumnList"},
						"list": {"bindTo": "DetailEntitySchemaColumnList"}
					},
					"enabled": {"bindTo": "CanEditConnectionColumns"}
				}
			}, {
				"operation": "insert",
				"name": "MasterEntitySchemaColumn",
				"parentName": "CardContentWrapper",
				"propertyName": "items",
				"values": {
					"bindTo": "MasterEntitySchemaColumn",
					"dataValueType": BPMSoft.DataValueType.ENUM,
					"labelConfig": {
						"caption": {"bindTo": "Resources.Strings.MasterEntitySchemaTitle"}
					},
					"controlConfig": {
						"className": "BPMSoft.ComboBoxEdit",
						"prepareList": {"bindTo": "prepareMasterEntitySchemaColumnList"},
						"list": {"bindTo": "MasterEntitySchemaColumnList"}
					},
					"enabled": {"bindTo": "CanEditConnectionColumns"}
				}
			}, {
				"operation": "insert",
				"name": "OkButton",
				"parentName": "CardContentWrapper",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"style": BPMSoft.controls.ButtonEnums.style.ORANGE,
					"click": {"bindTo": "save"},
					"caption": {"bindTo": "Resources.Strings.DetailModalBoxSaveButtonCaption"},
					"classes": {"textClass": ["tap-panel-box"]}
				}
			}, {
				"operation": "insert",
				"name": "CancelButton",
				"parentName": "CardContentWrapper",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"style": BPMSoft.controls.ButtonEnums.style.DEFAULT,
					"click": {"bindTo": "close"},
					"caption": {"bindTo": "Resources.Strings.DetailModalBoxCancelButtonCaption"},
					"classes": {"textClass": ["tap-panel-box"]}
				}
			}]/**SCHEMA_DIFF*/
		};
	});
