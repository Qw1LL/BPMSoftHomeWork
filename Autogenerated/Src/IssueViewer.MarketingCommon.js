define("IssueViewer", ["IssueViewerResources", "ContainerListGenerator",
		"ContainerList", "MultilineLabel", "css!MultilineLabel", "css!IssueViewerCSS", "TaggedTabPanel"],
	function(resources) {
		/** @enum
		 * Viewer tabs */
		var issueViewerTabs = {
			ERRORS: "ErrorsTab",
			WARNINGS: "WarningsTab"
		};

		/** @enum
		 * Issue levels */
		BPMSoft.IssueLevels = {
			ERROR: 0,
			WARNING: 1
		};
		return {
			messages: {

				/**
				 * @message SetIssuesDataCollection
				 * Gets validation massages.
				 */
				"SetIssuesDataCollection": {
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE,
					mode: BPMSoft.MessageMode.PTP
				},

			},
			attributes: {
				/**
				 * Issues configs collection.
				 */
				"ErrorsCollection": {
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"dataValueType": this.BPMSoft.DataValueType.COLLECTION,
					"value": Ext.create("BPMSoft.BaseViewModelCollection")
				},

				/**
				 * Issues configs collection.
				 */
				"WarningsCollection": {
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"dataValueType": this.BPMSoft.DataValueType.COLLECTION,
					"value": Ext.create("BPMSoft.BaseViewModelCollection")
				},

				/**
				 * Collection of tabs.
				 */
				"TabsCollection": {
					"dataValueType": BPMSoft.DataValueType.COLLECTION,
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				},

				/**
				 * Name of the active tab.
				 */
				"ActiveTabName": {
					"dataValueType": this.BPMSoft.DataValueType.TEXT,
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},

				/**
				 * Collapsed state of tabpanel.
				 */
				"TabPanelCollapsed": {
					"dataValueType": this.BPMSoft.DataValueType.BOOLEAN,
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"value": true
				}
			},
			methods: {

				// region Methods: Private

				/**
				 * Sets visibility of tab by name.
				 * @private
				 * @param {String} tabName Name of the tab.
				 * @param {Boolean} visible Value of visibility.
				 */
				_setTabVisible: function(tabName, visible) {
					this.set(tabName, visible);
				},

				/**
				 * Sets visibility of each tab to false.
				 * @private
				 */
				_hideTabs: function() {
					this.$TabsCollection.eachKey(function (tabName) {
						this._setTabVisible(tabName, false);
					}, this);
				},

				/**
				 * Chooses active tab based on issue collections.
				 * @private
				 */
				_chooseActiveTab: function() {
					if (!this.$ErrorsCollection.isEmpty()) {
						this.setActiveTab(issueViewerTabs.ERRORS);
					} else if (!this.$WarningsCollection.isEmpty()) {
						this.setActiveTab(issueViewerTabs.WARNINGS);
					}
				},

				/**
				 * Sets tab counters to all viewer tabs.
				 * @private
				 */
				_reloadTabCounters: function() {
					var errorCount = this.$ErrorsCollection.getCount();
					var warningsCont = this.$WarningsCollection.getCount();
					this._updateCounter(issueViewerTabs.ERRORS, errorCount);
					this._updateCounter(issueViewerTabs.WARNINGS, warningsCont);
				},

				/**
				 * Sets tab counter by key.
				 * @private
				 */
				_updateCounter: function(key, value) {
					var tab = this.$TabsCollection.get(key);
					tab.set("Count", value);
				},

				_createIssueViewModel: function(sourceItem) {
					return Ext.create("BPMSoft.BaseViewModel", {
						values: {
							Caption: sourceItem.Caption,
							Description: sourceItem.Description
						},
						columns: {
							Caption: {
								name: "Caption",
								dataValueType: BPMSoft.DataValueType.TEXT
							},
							Description: {
								name: "Description",
								dataValueType: BPMSoft.DataValueType.TEXT
							}
						}
					});
				},

				_getMainContainerDomAttributes: function() {
					return {
						"data-tab-panel-collapsed": this.$TabPanelCollapsed
					};
				},

				// endregion

				// region Methods: Protected

				/**
				 * Maps issue collection items from source issue messages array.
				 * @protected
				 * @param {Array} sourceCollection Represents array of validation message objects.
				 * @param {BPMSoft.BaseViewModelCollection} goalCollection Represents the destination collection for mapped messages.
				 */
				mapValidationMessages: function(source, target) {
					var tempItem;
					var tempCollection =  Ext.create("BPMSoft.BaseViewModelCollection");
					target.clear();
					this.BPMSoft.each(source, function (sourceItem) {
						tempItem = this._createIssueViewModel(sourceItem);
						tempCollection.add(sourceItem.Caption, tempItem);
					}, this);
					target.loadAll(tempCollection);
				},

				/**
				 * Fills issue collections from source issue messages array.
				 * @protected
				 * @param {Array} validationMessages Represents array of validation message objects.
				 */
				fillIssueCollections: function(validationMessages) {
					var errorMessages = validationMessages.filter(function (item) {
						return item.Level === BPMSoft.IssueLevels.ERROR
					});
					var warningMessages = validationMessages.filter(function (item) {
						return item.Level === BPMSoft.IssueLevels.WARNING
					});
					this.mapValidationMessages(errorMessages, this.$ErrorsCollection);
					this.mapValidationMessages(warningMessages, this.$WarningsCollection);
				},

				/**
				 * Handles event of changing validation state.
				 * @protected
				 * @param {Array} validationMessages Represents array of validation message objects.
				 * Example:
				 * 		validationMessages: [
				 * 			{
				 * 				Caption: "caption value 1",
				 * 				Description: "description value 1",
				 * 				Level: 	BPMSoft.IssueLevels.ERROR
				 * 			},
				 * 			{
				 * 				Caption: "caption value 2",
				 * 				Description: "description value 2",
				 * 				Level: 	BPMSoft.IssueLevels.WARNING
				 * 			}
				 * 		]
				 */
				setIssuesDataCollection: function(validationMessages) {
					this.$TabPanelCollapsed = Ext.isEmpty(validationMessages);
					this.fillIssueCollections(validationMessages);
					this._chooseActiveTab();
					this._reloadTabCounters();
				},

				/**
				 * Subscribes to events.
				 * @protected
				 */
				subscribeMessages: function() {
					this.sandbox.subscribe("SetIssuesDataCollection", this.setIssuesDataCollection, this);
				},

				/**
				 * Handles event of changing the collapsed state of tabpanel.
				 * @protected
				 * @param {Boolean} collapsed New collapsed state of tabpanel.
				 */
				onTabCollapsedChanged: function(collapsed) {
					if (collapsed === false) {
						var activeTabName = this.get("ActiveTabName");
						this.setActiveTab(activeTabName || issueViewerTabs.ERRORS);
					} else {
						this._hideTabs();
					}
				},

				/**
				 * Generates tab item html with counter.
				 * @protected
				 * @param {Object} tabPanelConfig Tab panel config.
				 * Example:
				 * 		tabPanelConfig: {
				 * 			html: "<li>Tab</li>",
				 *			tab: { Name: "Tab name" },
				 *			index: 0,
				 *			tabs: Ext.create("BPMSoft.BaseViewModelCollection")
				 * 		}
				 */
				onTabRender: function(tabPanelConfig) {
					var counterValue = tabPanelConfig.tab.$Count || 0;
					var el = document.createElement("html");
					el.innerHTML = tabPanelConfig.html;
					var tabEl = el.getElementsByTagName("li")[0];
					var counter = document.createElement("div");
					counter.className = "tab-counter";
					counter.textContent = counterValue;
					counter.setAttribute("data-item-marker", tabPanelConfig.tab.$Name + "-counter");
					counter.setAttribute("data-item-index", tabPanelConfig.index);
					tabEl.append(counter);
					tabPanelConfig.html =  tabEl.outerHTML;
				},

				/**
				 * Activates tab item by name.
				 * @protected
				 * @param {String} activeTabName Tab name to be activated.
				 */
				setActiveTab: function(activeTabName) {
					this.set("ActiveTabName", activeTabName);
					this.set(activeTabName, true);
				},

				/**
				 * Handles event of changing the active tab.
				 * @protected
				 * @param {BPMSoft.BaseViewModel} activeTab ViewModel of the active tab.
				 */
				onActiveTabChange: function(activeTab) {
					var activeTabName = activeTab.get("Name");
					this.set("ActiveTabName", activeTabName);
					this._hideTabs();
					this._setTabVisible(activeTabName, true);
					var collapsed = this.get("TabPanelCollapsed");
					if (collapsed) {
						this.set("TabPanelCollapsed", false);
					}
				},

				// endregion

				// region Methods: Public

				/**
				 * @inheritdoc BPMSoft.controls.TabPanel#init
				 * @override
				 */
				init: function(callback, scope) {
					this.callParent([function() {
						this._hideTabs();
						this.subscribeMessages();
						this._reloadTabCounters();
						callback.call(scope);
					}, this]);
				}

				// endregion

			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"name": "IssueMainContainer",
					"propertyName": "items",
					"index": 1,
					"values": {
						"itemType": this.BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["issue-main-container"],
						"items": [],
						"domAttributes":"$_getMainContainerDomAttributes"
					}
				},
				{
					"operation": "insert",
					"name": "TabsContainer",
					"parentName": "IssueMainContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "Tabs",
					"parentName": "TabsContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.TAB_PANEL,
						"className": "BPMSoft.TaggedTabPanel",
						"activeTabChange": "$onActiveTabChange",
						"collapsedchanged": "$onTabCollapsedChanged",
						"activeTabName": "$ActiveTabName",
						"collapsed": "$TabPanelCollapsed",
						"collection": {"bindTo": "TabsCollection"},
						"isScrollVisible": false,
						"isCollapseButtonVisible": true,
						"tabs": [],
						"tabRender": "$onTabRender",
						"defaultMarkerValueColumnName": "Name"
					}
				},
				{
					"operation": "insert",
					"name": issueViewerTabs.ERRORS,
					"parentName": "Tabs",
					"propertyName": "tabs",
					"values": {
						"generateId": false,
						"caption": resources.localizableStrings.ErrorsTabCaption,
						"wrapClass": ["tab-container"],
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "ErrorsList",
					"parentName": issueViewerTabs.ERRORS,
					"propertyName": "items",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.GRID,
						"type": this.BPMSoft.GridType.LISTED,
						"listedZebra": true,
						"collection": "$ErrorsCollection",
						"columnsConfig": [
							{
								"cols": 8,
								"key": [
									{
										"name": { "bindTo": "Caption"},
										"caption": "Caption"
									}
								]
							},
							{
								"cols": 16,
								"key": [
									{
										"name": { "bindTo": "Description"},
										"caption": "Description"
									}
								]
							}
						],

						"captionsConfig": [
							{
								"cols": 8,
								"name": resources.localizableStrings.NameGridCaption
							},
							{
								"cols": 16,
								"name": resources.localizableStrings.DescriptionGridLabel
							}
						]
					}
				},
				{
					"operation": "insert",
					"name": issueViewerTabs.WARNINGS,
					"parentName": "Tabs",
					"propertyName": "tabs",
					"values": {
						"generateId": false,
						"caption": resources.localizableStrings.WarningsTabCaption,
						"wrapClass": ["tab-container"],
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "WarningsList",
					"parentName": issueViewerTabs.WARNINGS,
					"propertyName": "items",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.GRID,
						"type": this.BPMSoft.GridType.LISTED,
						"listedZebra": true,
						"collection": "$WarningsCollection",
						"columnsConfig": [
							{
								"cols": 8,
								"key": [
									{
										"name": { "bindTo": "Caption"},
										"caption": "Caption"
									}
								]
							},
							{
								"cols": 16,
								"key": [
									{
										"name": { "bindTo": "Description"},
										"caption": "Description"
									}
								]
							}
						],
						"captionsConfig": [
							{
								"cols": 8,
								"name": resources.localizableStrings.NameGridCaption
							},
							{
								"cols": 16,
								"name": resources.localizableStrings.DescriptionGridLabel
							}
						]
					}
				}
			] /**SCHEMA_DIFF*/
		};
	});