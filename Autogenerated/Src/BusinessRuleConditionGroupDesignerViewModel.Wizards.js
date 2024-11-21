define("BusinessRuleConditionGroupDesignerViewModel", ["BusinessRuleElementDesignerViewModel",
	"BusinessRuleConditionDesignerViewModel"], function() {

		/**
		 * @class BPMSoft.Designers.BusinessRuleConditionGroupDesignerViewModel
		 */
		Ext.define("BPMSoft.Designers.BusinessRuleConditionGroupDesignerViewModel", {
			extend: "BPMSoft.BusinessRuleElementDesignerViewModel",
			alternateClassName: "BPMSoft.BusinessRuleConditionGroupDesignerViewModel",

			columns: {
				/**
				 * Operation type.
				 * @type {BPMSoft.LogicalOperatorType}
				 */
				"OperationType": {
					"dataValueType": this.BPMSoft.DataValueType.INTEGER,
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"value": this.BPMSoft.LogicalOperatorType.AND
				},
				/**
				 * Condition items.
				 * @type {BPMSoft.BaseViewModelCollection}
				 */
				"Items": {
					"dataValueType": this.BPMSoft.DataValueType.COLLECTION,
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"value": null
				},
				/**
				 * Condition group container visibility.
				 * @type {Boolean}
				 */
				"Visible": {
					"dataValueType": this.BPMSoft.DataValueType.BOOLEAN,
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"value": true
				}
			},

			// region Methods: Private

			/**
			 * Creates condition view model.
			 * @private
			 * @param {BPMSoft.MetaItem} metaItem Meta item.
			 */
			createConditionViewModel: function(metaItem) {
				const conditionViewModel = this.createItemViewModel("BPMSoft.BusinessRuleConditionDesignerViewModel", {
					MetaItemType: "ComparisonBusinessRuleCondition",
					MetaItem: metaItem
				});
				conditionViewModel.on("pullChanges", this.onPullChanges, this);
				return conditionViewModel;
			},

			/**
			 * Prepares operation.
			 * @private
			 */
			prepareOperationType: function() {
				var metaItem = this.getMetaItem();
				this.set("OperationType", metaItem.getPropertyValue("operationType"));
			},

			/**
			 * Prepares conditions.
			 * @private
			 */
			prepareConditions: function() {
				var metaItem = this.getMetaItem();
				var conditionViewModels = this.Ext.create("BPMSoft.BaseViewModelCollection");
				BPMSoft.each(metaItem.getPropertyValue("items"), function(item) {
					var viewModel = this.createConditionViewModel(item);
					conditionViewModels.add(viewModel.get("Id"), viewModel);
				}, this);
				conditionViewModels.on("dataLoaded", this.onItemCollectionChanged, this);
				conditionViewModels.on("add", this.onItemCollectionChanged, this);
				conditionViewModels.on("remove", this.onItemCollectionChanged, this);
				conditionViewModels.on("clear", this.onItemCollectionChanged, this);
				this.set("Items", conditionViewModels);
				this.onItemCollectionChanged();
			},

			/**
			 * Updates operation type.
			 * @private
			 * @param {String} callback Callback function.
			 * @param {BPMSoft.MetaItem} metaItem Meta item.
			 */
			updateOperationType: function(callback, metaItem) {
				metaItem.setPropertyValue("operationType", this.get("OperationType"));
				callback();
			},

			/**
			 * Updates conditions.
			 * @private
			 * @param {String} callback Callback function.
			 * @param {BPMSoft.MetaItem} metaItem Meta item.
			 */
			updateConditions: function(callback, metaItem) {
				var conditionViewModels = this.get("Items");
				this.updateMetaItems(conditionViewModels.getItems(), function() {
					var items = [];
					conditionViewModels.each(function(conditionViewModel) {
						items.push(conditionViewModel.getMetaItem());
					}, this);
					metaItem.setPropertyValue("items", items);
					callback();
				}, this);
			},

			/**
			 * Item action click event handler.
			 * @private
			 * @param {String} actionName Action name.
			 * @param {String} itemId Item id.
			 */
			onItemActionClick: function(actionName, itemId) {
				if (actionName === "remove") {
					const conditionViewModel = this.$Items.get(itemId);
					conditionViewModel.un("pullChanges", this.onPullChanges, this);
					this.$Items.removeByKey(itemId);
				}
			},

			/**
			 * Validates condition group properties.
			 * @private
			 * @param {Function} callback Callback function.
			 * @param {Object} validationInfo Validation info.
			 */
			validateGroup: function(callback, validationInfo) {
				var operationType = this.get("OperationType");
				if (Ext.isEmpty(operationType)) {
					validationInfo.isValid = false;
					validationInfo.messageList.push("");
				}
				callback(validationInfo);
			},

			/**
			 * Validates conditions.
			 * @private
			 * @param {Function} callback Callback function.
			 * @param {Object} validationInfo Validation info.
			 */
			validateItems: function(callback, validationInfo) {
				var conditionCollection = this.get("Items");
				this.asyncValidateItems(conditionCollection.getItems(), validationInfo, function() {
					callback(validationInfo);
				}, this);
			},

			/**
			 * Condition item collection change event handler.
			 * @private
			 */
			onItemCollectionChanged: function() {
				this.fireEvent("itemCollectionChanged");
			},

			// endregion

			// region Methods: Protected

			/**
			 * @inheritdoc BPMSoft.BusinessRuleElementDesignerViewModel#getAsyncValidateList
			 * @overridden
			 */
			getAsyncValidators: function() {
				var validationMethods = this.callParent();
				validationMethods.push(this.validateGroup, this.validateItems);
				return validationMethods;
			},

			/**
			 * @inheritdoc BPMSoft.BusinessRuleElementDesignerViewModel#getMetaItemUpdaters
			 * @overridden
			 */
			getMetaItemUpdaters: function() {
				var updaters = this.callParent(arguments);
				updaters.push(this.updateOperationType);
				updaters.push(this.updateConditions);
				return updaters;
			},

			/**
			 * @inheritdoc BPMSoft.BusinessRuleElementDesignerViewModel#unsubscribePullChangesEvent
			 * @overridden
			 */
			unsubscribePullChangesEvent: function() {
				this.$Items.each(function(conditionItem) {
					conditionItem.un("pullChanges", this.onPullChanges, this);
				}, this);
				this.callParent(arguments);
			},

			/**
			 * @inheritdoc BPMSoft.BaseObject#onDestroy
			 * @overridden
			 */
			onDestroy: function() {
				var conditionViewModels = this.get("Items");
				conditionViewModels.un("dataLoaded", this.onItemCollectionChanged, this);
				conditionViewModels.un("add", this.onItemCollectionChanged, this);
				conditionViewModels.un("remove", this.onItemCollectionChanged, this);
				conditionViewModels.un("clear", this.onItemCollectionChanged, this);
				this.callParent(arguments);
			},

			// endregion

			// region Methods: Public

			/**
			 * @inheritdoc BPMSoft.BaseObject#constructor
			 * @overridden
			 */
			constructor: function() {
				this.callParent(arguments);
				this.addEvents(
					/**
					 * @event itemCollectionChanged
					 * Fires when condition item collection is changed.
					 */
					"itemCollectionChanged"
				);
				this.prepareOperationType();
				this.prepareConditions();
			},

			/**
			 * Adds empty condition.
			 */
			addEmptyCondition: function() {
				var conditionViewModel = this.createConditionViewModel();
				var conditionViewModels = this.get("Items");
				conditionViewModels.add(conditionViewModel.get("Id"), conditionViewModel);
			},

			/**
			 * Clears conditions.
			 */
			clearConditions: function() {
				var conditionViewModels = this.get("Items");
				conditionViewModels.clear();
			}

			// endregion

		});
		return BPMSoft.BusinessRuleConditionGroupDesignerViewModel;
	});
