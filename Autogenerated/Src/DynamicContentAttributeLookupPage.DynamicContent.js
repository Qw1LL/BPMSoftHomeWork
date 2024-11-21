/**
 * Page to select DCAttribute item from available atribute variants.
 */
define("DynamicContentAttributeLookupPage", ["DynamicContentAttributeLookupPageResources",
		"DynamicContentAttributeLookupItem"],
	function() {
		return {
			messages: {

				/**
				 * @message GetAvailableDcAttributes
				 * Gets DCAttribute models that are available for current lookup.
				 */
				"GetAvailableDcAttributes": {
					direction: BPMSoft.MessageDirectionType.PUBLISH,
					mode: BPMSoft.MessageMode.PTP
				},

				/**
				 * @message DCAttributeSelected
				 * Sends selected lookup item.
				 */
				"DCAttributeSelected": {
					direction: BPMSoft.MessageDirectionType.PUBLISH,
					mode: BPMSoft.MessageMode.PTP
				},

				/**
				 * @message SelectRuleCancel
				 * Cancelled lookup selection.
				 */
				"SelectRuleCancel": {
					direction: BPMSoft.MessageDirectionType.PUBLISH,
					mode: BPMSoft.MessageMode.PTP
				}
			},
			attributes: {

				/**
				 * Available DCAttribute lookup viewmodel items collection.
				 * @type {BPMSoft.BaseViewModelCollection}
				 */
				"DCAttributes": {
					"dataValueType": BPMSoft.core.enums.DataValueType.COLLECTION,
					"type": BPMSoft.core.enums.ViewModelColumnType.VIRTUAL_COLUMN
				},

				/**
				 * Selected DCAttribute lookup item.
				 * @type {Object}
				 */
				"SelectedItem": {
					dataValueType: BPMSoft.DataValueType.CUSTOM_OBJECT,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				}
			},
			methods: {

				// #region Methods: Private

				/**
				 * Creates view model item for container list based on attribute model.
				 * @private
				 * @param {Object} item DCAttribute model.
				 * @returns {BPMSoft.DynamicContentAttributeLookupItem} Item view model.
				 */
				_createLookupItemViewModel: function(item) {
					var vm = Ext.create("BPMSoft.DynamicContentAttributeLookupItem", {
						values: {
							Caption: item.Caption,
							Index: item.Index,
							Selected: this.$SelectedItem && item.Index === this.$SelectedItem.Index
						}
					});
					vm.sandbox = this.sandbox;
					return vm;
				},

				/**
				 * Inits DCAttribute collection with available attribute models.
				 * @private
				 */
				_loadAvailableAttributes: function() {
					var index =  this.$SelectedItem ? this.$SelectedItem.Index : null;
					var collection = Ext.create("BPMSoft.BaseViewModelCollection");
					var availableAttributes = this.sandbox.publish("GetAvailableDcAttributes", index);
					BPMSoft.each(availableAttributes, function(item) {
						var vm = this._createLookupItemViewModel(item);
						collection.add(item.Index, vm);
					}, this);
					collection.sort("$Caption", BPMSoft.OrderDirection.ASC);
					this.$DCAttributes = collection;
				},

				/**
				 * Flag to indicate lookup item selected or not.
				 * @private
				 * @returns {Boolean}
				 */
				_isItemSelected: function() {
					return Boolean(this.$SelectedItem);
				},

				// #endregion

				// #region Methods: Public

				/**
				 * @inheritdoc BPMSoft.BaseViewModel#init
				 * @override
				 */
				init: function() {
					this.callParent(arguments);
					this._loadAvailableAttributes();
				},

				/**
				 * Handler on select button click.
				 * Sends current selected lookup item.
				 * @public
				 */
				onOkButtonClick: function() {
					this.sandbox.publish("DCAttributeSelected", this.$SelectedItem, [this.sandbox.id]);
				},

				/**
				 * Handler on lookup page close.
				 * Sends message to unload lookup page module.
				 * @public
				 */
				onCloseButtonClick: function() {
					this.sandbox.publish("SelectRuleCancel", null, [this.sandbox.id]);
				},

				/**
				 * Handler on selected item in container list changed.
				 * Sets new selected lookup item on list selected item.
				 * @public
				 * @param {Object} item New selected lookup item.
				 */
				onSelectedItemChanged: function(item) {
					this.$SelectedItem = {
						Index: item.$Index,
						Caption: item.$Caption
					};
				}

				// #endregion

			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"name": "AttributeLookupContainer",
					"propertyName": "items",
					"values": {
						"wrapClass": ["attribute-lookup-container"],
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "AttributeLookupGrid",
					"parentName": "AttributeLookupContainer",
					"propertyName": "items",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.GRID_LAYOUT,
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "AttributeLookupHeaderContainer",
					"parentName": "AttributeLookupGrid",
					"propertyName": "items",
					"values": {
						"layout": {
							"column": 0,
							"row": 0,
							"colSpan": 24
						},
						"wrapClass": ["attribute-lookup-header"],
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "AttributesLabel",
					"parentName": "AttributeLookupHeaderContainer",
					"propertyName": "items",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.LABEL,
						"caption": "$Resources.Strings.SelectDCAttributeCaption",
						"classes": {
							"labelClass": ["t-title-label-dc"]
						}
					}
				},
				{
					"operation": "insert",
					"name": "CloseButton",
					"parentName": "AttributeLookupHeaderContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"imageConfig": "$Resources.Images.CloseIcon",
						"click": "$onCloseButtonClick",
						"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT
					}
				},
				{
					"operation": "insert",
					"name": "AttributeLookupButtonsContainer",
					"parentName": "AttributeLookupGrid",
					"propertyName": "items",
					"values": {
						"layout": {
							"column": 0,
							"row": 2,
							"colSpan": 24
						},
						"wrapClass": ["attribute-lookup-buttons-container"],
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "AttributesContainerList",
					"parentName": "AttributeLookupGrid",
					"propertyName": "items",
					"values": {
						"layout": {
							"column": 0,
							"row": 1,
							"colSpan": 24
						},
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"className": "BPMSoft.ObservableContainerList",
						"collection": "$DCAttributes",
						"classes": {"wrapClassName": ["attribute-lookup-list-container"]},
						"idProperty": "Index",
						"onSelectedItemChanged" : "$onSelectedItemChanged",
						"itemSelectedAlways": true,
						"rowCssSelector": ".attribute-lookup-item-container.selectable",
						"defaultItemConfig": {
							className: "BPMSoft.Container",
							classes: {
								wrapClassName: ["attribute-lookup-item-container"]
							},
							items: [{
								className: "BPMSoft.Label",
								caption: "$Caption"
							}]
						}
					}
				},
				{
					"operation": "insert",
					"name": "OkButton",
					"parentName": "AttributeLookupButtonsContainer",
					"propertyName": "items",
					"values": {
						"enabled": "$_isItemSelected",
						"classes": {"textClass": ["actions-button-margin-right"]},
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"caption": "$Resources.Strings.OkCaption",
						"click": "$onOkButtonClick",
						"style": BPMSoft.controls.ButtonEnums.style.ORANGE
					}
				},
				{
					"operation": "insert",
					"name": "CancelButton",
					"parentName": "AttributeLookupButtonsContainer",
					"propertyName": "items",
					"values": {
						"classes": {"textClass": ["actions-button-margin-right"]},
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"caption": "$Resources.Strings.CancelCaption",
						"click": "$onCloseButtonClick",
						"style": BPMSoft.controls.ButtonEnums.style.DEFAULT
					}
				}
			]
		};
	});
