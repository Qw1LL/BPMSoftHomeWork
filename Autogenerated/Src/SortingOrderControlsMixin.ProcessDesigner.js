define("SortingOrderControlsMixin", ["SortingOrderControlsMixinResources"], function(resources) {
	/**
	 * @class BPMSoft.configuration.mixins.SortingOrderControlsMixin
	 * Implements work with sorting columns.
	 */
	Ext.define("BPMSoft.configuration.mixins.SortingOrderControlsMixin", {
		alternateClassName: "BPMSoft.SortingOrderControlsMixin",

		//region Properties: Private

		_orderDirectionEnum: {
			None: BPMSoft.OrderDirection.NONE.toString(),
			Ascending: BPMSoft.OrderDirection.ASC.toString(),
			Descending: BPMSoft.OrderDirection.DESC.toString()
		},

		//endregion

		//region Methods: Private

		/**
		 * Returns sorting order.
		 * @private
		 * @return {Object}
		 */
		getSortingOrderDirections: function() {
			let sortingOrders = this.get("SortingOrderDirections");
			if (!sortingOrders) {
				const orderDirectionEnum = this._orderDirectionEnum;
				const localizableStrings = resources.localizableStrings;
				sortingOrders = this.Ext.create("BPMSoft.Collection");
				this.BPMSoft.each(orderDirectionEnum, function(sortingOrder) {
					const sortingOrderCaption = "SortingOrder" + sortingOrder + "Caption";
					sortingOrders.add(sortingOrder, {
						value: sortingOrder,
						displayValue: localizableStrings[sortingOrderCaption]
					});
				}, this);
				this.set("SortingOrderDirections", sortingOrders);
			}
			return sortingOrders;
		},

		/**
		 * AddSortingOrderButton button click handler.
		 * @private
		 */
		onAddSortingOrderButtonClick: function() {
			const config = this.getNewSortingOrderConfig();
			this.addSortingOrderControl(config);
		},

		/**
		 * Adds sorting order control.
		 * @private
		 * @param {Object} config Settings.
		 */
		addSortingOrderControl: function(config) {
			const controls = this.get("SortingOrderControls");
			config.position = controls.getCount() + 1;
			const viewModel = this.getSortingOrderViewModelConfig(config);
			controls.add(config.id, viewModel);
		},

		/**
		 * Returns config of the sorting order control for existing statement.
		 * @private
		 * @param {BPMSoft.Collection} entitySchemaColumns A list of the entity schema columns.
		 * @param {Object} sortingByColumn Entity schema column.
		 * @param {String} sortingOrder Sorting order.
		 * @return {Object} Settings for the sorting order.
		 */
		getExistingSortingOrderConfig: function(entitySchemaColumns, sortingByColumn, sortingOrder) {
			const orderDirections = this.getSortingOrderDirections();
			return {
				propertiesPageViewModel: this,
				orderDirection: orderDirections.get(sortingOrder),
				orderDirections: orderDirections,
				entitySchemaColumns: entitySchemaColumns,
				id: sortingByColumn.id,
				entitySchemaColumn: {
					id: sortingByColumn.id,
					name: sortingByColumn.name,
					displayValue: sortingByColumn.caption
				}
			};
		},

		/**
		 * Returns config of the sorting order control for a new statement.
		 * @private
		 */
		getNewSortingOrderConfig: function() {
			const orderDirections = this.getSortingOrderDirections();
			const orderDirectionEnum = this._orderDirectionEnum;
			const orderDirection = orderDirections.get(orderDirectionEnum.Ascending);
			const config = {
				id: BPMSoft.generateGUID(),
				propertiesPageViewModel: this,
				orderDirection: orderDirection,
				entitySchemaColumns: this.get("EntitySchemaColumnsSelect")
			};
			const controls = this.get("SortingOrderControls");
			const entitySchemaColumn = this.get("PrimaryDisplayEntitySchemaColumn");
			if (controls.getCount() === 0 && entitySchemaColumn) {
				config.entitySchemaColumn = entitySchemaColumn;
			}
			return config;
		},

		/**
		 * Generates configuration view of the sorting order element.
		 * @private
		 * @param {Object} itemConfig Link to configuration of element in ContainerList.
		 */
		getSelectedSortingOrderViewConfig: function(itemConfig) {
			const defaultViewConfig = this.get("SortingOrderViewConfig");
			if (defaultViewConfig) {
				itemConfig.config = defaultViewConfig;
				return;
			}
			const sortingOrderItemsConfig = this.getSortingOrderViewConfig();
			const item = this.getContainerConfig("default-value-container", ["sorting-order-container"],
				sortingOrderItemsConfig);
			const wrapClassNames = ["top-caption-control", "control-width-15"];
			itemConfig.config = this.getContainerConfig("item-view", wrapClassNames, [item]);
			this.set("SortingOrderViewConfig", itemConfig.config);
		},

		/**
		 * Returns view settings of the sorting order element.
		 * @private
		 * @return {Object}.
		 */
		getSortingOrderViewConfig: function() {
			return [{
				id: "EntitySchemaColumns",
				className: "BPMSoft.ComboBoxEdit",
				value: {
					bindTo: "EntitySchemaColumn"
				},
				list: {
					bindTo: "EntitySchemaColumns"
				},
				prepareList: {
					bindTo: "onPrepareEntitySchemaColumns"
				},
				classes: {
					wrapClass: ["sorting-order-item-container"]
				},
				"markerValue": {
					bindTo: "Position",
					bindConfig: {
						converter: function(position) {
							let markerValue = "SortByColumn";
							if (position) {
								markerValue = markerValue + "_" + position;
							}
							return markerValue;
						}
					}
				}
			},
				{
					id: "OrderDirections",
					className: "BPMSoft.ComboBoxEdit",
					value: {
						bindTo: "OrderDirection"
					},
					list: {
						bindTo: "OrderDirections"
					},
					prepareList: {
						bindTo: "onPrepareOrderDirections"
					},
					classes: {
						wrapClass: ["sorting-order-item-container"]
					},
					"markerValue": {
						bindTo: "Position",
						bindConfig: {
							converter: function(position) {
								let markerValue = "SortingOrderDirection";
								if (position) {
									markerValue = markerValue + "_" + position;
								}
								return markerValue;
							}
						}
					}
				},
				{
					className: "BPMSoft.Container",
					id: "DeleteSortingOrderButtonContainer",
					selectors: {
						wrapEl: "#DeleteSortingOrderButtonContainer"
					},
					classes: {
						wrapClassName: ["sorting-order-edit-button-container"]
					},
					items: [{
						className: "BPMSoft.Button",
						imageConfig: resources.localizableImages.CloseButton,
						style: this.BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
						classes: {
							wrapperClass: [".sorting-order-edit-button"]
						},
						markerValue: "DeleteSortingOrder",
						click: {
							bindTo: "onDeleteSortingOrderButtonClick"
						}
					}]
				}];
		},

		/**
		 * Returns view model settings of the element.
		 * @private
		 * @param {Object} config Settings.
		 * @return {Object}.
		 */
		getSortingOrderViewModelConfig: function(config) {
			const viewModel = this.Ext.create("BPMSoft.BaseModel", {
				columns: {
					Id: {dataValueType: this.BPMSoft.DataValueType.TEXT},
					EntitySchemaColumn: {
						type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						dataValueType: this.BPMSoft.DataValueType.ENUM,
						isLookup: true,
						isRequired: true
					},
					OrderDirection: {
						type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						dataValueType: this.BPMSoft.DataValueType.ENUM,
						isLookup: true,
						isRequired: true
					},
					EntitySchemaColumns: {
						dataValueType: this.BPMSoft.DataValueType.COLLECTION,
						type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						isCollection: true
					},
					OrderDirections: {
						dataValueType: this.BPMSoft.DataValueType.COLLECTION,
						type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						isCollection: true
					},
					Position: {
						type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						dataValueType: this.BPMSoft.DataValueType.INTEGER
					},
					PropertiesPageViewModel: {
						dataValueType: this.BPMSoft.DataValueType.CUSTOM_OBJECT,
						type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
					}
				},
				values: {
					Id: config.id,
					PropertiesPageViewModel: config.propertiesPageViewModel,
					EntitySchemaColumn: config.entitySchemaColumn,
					EntitySchemaColumns: config.entitySchemaColumns
						? config.entitySchemaColumns
						: this.Ext.create("BPMSoft.Collection"),
					OrderDirection: config.orderDirection,
					OrderDirections: this.Ext.create("BPMSoft.Collection"),
					Position: config.position
				},
				methods: {
					onPrepareEntitySchemaColumns: function (filter, list) {
						const entitySchemaColumns = this.get("EntitySchemaColumnsSelect");
						list.loadAll(entitySchemaColumns);
					},
					onPrepareOrderDirections: function (filter, list) {
						const propertiesPageViewModel = this.get("PropertiesPageViewModel");
						const orderDirections = propertiesPageViewModel
							.getSortingOrderDirections(propertiesPageViewModel);
						list.clear();
						list.loadAll(orderDirections);
					},
					onDeleteSortingOrderButtonClick: function () {
						const propertiesPageViewModel = this.get("PropertiesPageViewModel");
						const sortingOrderControls = propertiesPageViewModel.get("SortingOrderControls");
						const id = this.get("Id");
						sortingOrderControls.removeByKey(id);
					}
				}
			});
			viewModel.sandbox = this.sandbox;
			return viewModel;
		},

		/**
		 * Returns a list of the entity schema columns.
		 * @private
		 * @param {BPMSoft.Collection} entitySchemaColumns Process element.
		 * @param {String} columnName Name of the column.
		 * @return {Object} Found column.
		 */
		findEntitySchemaColumnByName: function(entitySchemaColumns, columnName) {
			let column = null;
			entitySchemaColumns.each(function(schemaColumn) {
				if (schemaColumn.name === columnName) {
					column = schemaColumn;
					return false;
				}
			}, this);
			return column;
		},

		//endregion

		//region Methods: Protected

		/**
		 * Initializes collection of the sorting order control with values from the OrderInfo parameter.
		 * @protected
		 * @param {BPMSoft.ProcessUserTaskSchema} element Process element.
		 */
		initSortingOrderControlsMixin: function(element) {
			const controls = this.get("SortingOrderControls");
			if (controls) {
				controls.clear();
			}
			const sortingOrderStatements = this.Ext.create("BPMSoft.Collection");
			const parameterName = this.getOrderInfoParameterName();
			const parameter = element.findParameterByName(parameterName);
			const sortingOrder = parameter.getValue();
			if (!sortingOrder) {
				return;
			}
			const columns = this.get("EntitySchemaColumnsSelect");
			let firstSortingOrderStatement = null;
			const sortingOrderColumns = sortingOrder.split(",");
			this.BPMSoft.each(sortingOrderColumns, function(sortingOrderColumn) {
				const sortingOrderColumnParts = sortingOrderColumn.split(":");
				if (this.Ext.isEmpty(sortingOrderColumnParts) || sortingOrderColumnParts.length < 3) {
					return true;
				}
				const columnName = sortingOrderColumnParts[0];
				if (this.Ext.Array.contains(sortingOrderStatements, columnName)) {
					return true;
				}
				const column = this.findEntitySchemaColumnByName(columns, columnName);
				if (!column) {
					return true;
				}
				const orderDirection = sortingOrderColumnParts[1];
				const orderPosition = sortingOrderColumnParts[2];
				const config = this.getExistingSortingOrderConfig(columns, column, orderDirection);
				if (orderPosition === "1") {
					firstSortingOrderStatement = config;
					return true;
				}
				sortingOrderStatements.add(columnName, config);
			}, this);
			if (firstSortingOrderStatement) {
				this.addSortingOrderControl(firstSortingOrderStatement);
			}
			sortingOrderStatements.each(function(sortingOrderStatement) {
				this.addSortingOrderControl(sortingOrderStatement);
			}, this);
		},

		/**
		 * Saves sorting order info.
		 * @param {BPMSoft.ProcessBaseElementSchema} element Process element.
		 * @protected
		 */
		saveSortingOrderInfo: function(element) {
			let sortingOrderInfo = null;
			const sortingOrderControls = this.get("SortingOrderControls");
			if (sortingOrderControls && !sortingOrderControls.isEmpty()) {
				sortingOrderControls.each(function(sortingOrderControl) {
					const entitySchemaColumn = sortingOrderControl.get("EntitySchemaColumn");
					if (!entitySchemaColumn) {
						return true;
					}
					const orderDirection = sortingOrderControl.get("OrderDirection");
					if (!orderDirection) {
						return true;
					}
					const sortingOrder = entitySchemaColumn.name + ":" + orderDirection.value + ":";
					sortingOrderInfo = !sortingOrderInfo
						? sortingOrder + "1"
						: sortingOrderInfo + "," + sortingOrder + "0";
				}, this);
			}
			const parameterName = this.getOrderInfoParameterName();
			const parameter = element.findParameterByName(parameterName);
			const parameterValue = {
				source: !sortingOrderInfo
					? this.BPMSoft.ProcessSchemaParameterValueSource.None
					: this.BPMSoft.ProcessSchemaParameterValueSource.ConstValue,
				value: sortingOrderInfo
			};
			parameter.setMappingValue(parameterValue);
		},

		/**
		 * Adds sorting order statement.
		 * @protected
		 */
		addSortingOrderStatement: function() {
			if (!this.get("PrimaryDisplayEntitySchemaColumn")) {
				return;
			}
			const config = this.getNewSortingOrderConfig();
			this.addSortingOrderControl(config);
		},

		/**
		 * Returns parameter name to which save order information.
		 * @protected
		 */
		getOrderInfoParameterName: function() {
			return "OrderInfo";
		}

		//endregion

	});

	return BPMSoft.SortingOrderControlsMixin;
});
