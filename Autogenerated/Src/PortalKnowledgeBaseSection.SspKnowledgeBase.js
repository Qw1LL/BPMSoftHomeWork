define("PortalKnowledgeBaseSection", [],
		function() {
			return {
				entitySchemaName: "KnowledgeBase",
				details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
				diff: /**SCHEMA_DIFF*/[
					{
						"operation": "remove",
						"name": "DataGridActiveRowDeleteAction"
					},
					{
						"operation": "remove",
						"name": "DataGridActiveRowCopyAction"
					},
					{
						"operation": "remove",
						"name": "CombinedModeActionButtonsCardRightContainer"
					}
				]/**SCHEMA_DIFF*/,
				methods: {
					/**
					 * ############# ############# ########### #######.
					 * @overridden
					 * @protected
					 */
					initContextHelp: function() {
						this.enableContextHelp = false;
					},

					/**
					 * ############## ########## ###### ###### "########".
					 * @overridden
					 * @protected
					 * @param {String} modeType ######## #### ########### #######
					 * @param {BPMSoft.BaseViewModelCollection} actionMenuItems
					 */
					initActionButtonMenu: function(modeType, actionMenuItems) {
						var collectionName = modeType + "ModeActionsButtonMenuItems";
						var collection = this.get(collectionName);
						if (actionMenuItems.getCount()) {
							this.set(modeType + "ModeActionsButtonVisible", true);
							var newCollection = this.Ext.create("BPMSoft.BaseViewModelCollection");
							actionMenuItems.each(function(item) {
								if (item.values.Caption.bindTo !== "Resources.Strings.ExportListToFileButtonCaption" &&
										item.values.Caption.bindTo !== "Resources.Strings.DeleteRecordButtonCaption") {
									var newItem = this.cloneBaseViewModel(item);
									newCollection.addItem(newItem);
								}
							}, this);
							if (collection) {
								collection.clear();
								collection.loadAll(newCollection);
							} else {
								this.set(collectionName, newCollection);
							}
						} else {
							this.set(modeType + "ModeActionsButtonVisible", false);
						}
					},

					/**
					 * ####### ######### ###### ########.
					 * @overridden
					 * @protected
					 */
					initAddRecordButtonParameters: function() {
						this.set("AddRecordButtonEnabled", false);
					},

					/**
					 * ######## ############# ## #########.
					 * @overridden
					 * @protected
					 * @return {Object}
					 */
					getDefaultDataViews: function() {
						var gridDataView = {
							name: this.get("GridDataViewName"),
							caption: this.getDefaultGridDataViewCaption(),
							icon: this.getDefaultGridDataViewIcon()
						};
						return {
							"GridDataView": gridDataView
						};
					}
				}
			};
		});
