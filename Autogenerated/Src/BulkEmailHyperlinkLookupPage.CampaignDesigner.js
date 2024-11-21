 /**
 * Page to select DCAttribute item from available atribute variants.
 */
define("BulkEmailHyperlinkLookupPage", ["css!BulkEmailHyperlinkLookupPageCSS", "css!LookupPageCSS"],
	function() {
		return {
			messages: {
				/**
				 * @message HyperlinkSelected
				 * Sends selected lookup items.
				 */
				"HyperlinkSelected": {
					direction: BPMSoft.MessageDirectionType.PUBLISH,
					mode: BPMSoft.MessageMode.PTP
				},

				/**
				 * @message HyperlinkSelectCancel
				 * Cancelled lookup selection.
				 */
				"HyperlinkSelectCancel": {
					direction: BPMSoft.MessageDirectionType.PUBLISH,
					mode: BPMSoft.MessageMode.PTP
				}
			},
			attributes: {

				/**
				 * Unique identifier of bulk email
				 */
				"BulkEmailId": {
					dataValueType: this.BPMSoft.DataValueType.GUID,
					type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},

				/**
				 * Array of all bulk email hyperlinks
				 */
				"Hyperlinks": {
					type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: []
				},

				/**
				 * Columns of hyperlink data row
				 */
				"RowConfig": {
					type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: {}
				},

				/**
				 * Array of selected hyperlinks
				 */
				"SelectedItems": {
					dataValueType: this.BPMSoft.DataValueType.COLLECTION,
					type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},

				/**
				 * Collection of all bulk email hyperlinks
				 */
				"HyperlinkCollection": {
					dataValueType: this.BPMSoft.DataValueType.COLLECTION,
					type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: this.Ext.create("BPMSoft.BaseViewModelCollection")
				}
			},
			methods: {

				// #region Methods: Private

				/**
				 * Returns true when there are no hyperlinks to show.
				 * @private
				 * @return {Boolean} True when there are no hyperlinks.
				 */
				_isGridEmpty: function() {
					return !Boolean(this.$Hyperlinks.length);
				},

				// #endregion

				// #region Methods: Public

				/**
				 * @inheritdoc BPMSoft.BaseViewModel#init
				 * @override
				 */
				init: function(callback, module) {
					this.callParent(arguments);
					this.initHyperlinkCollection();
				},

				/**
				 * Initializes collection of hyperlinks for lookup.
				 * @protected
				 */
				initHyperlinkCollection: function() {
					var hyperlinks = Ext.create("BPMSoft.BaseViewModelCollection");
					BPMSoft.each(this.$Hyperlinks, function(hyperlink) {
						hyperlinks.add(hyperlink.Id, Ext.create("BPMSoft.BaseViewModel", {
							values: hyperlink,
							rowConfig: this.$RowConfig
						}));
					}, this);
					this.$HyperlinkCollection.clear();
					this.$HyperlinkCollection.loadAll(hyperlinks);
				},

				/**
				 * Returns number of selected records.
				 * @protected
				 * @return {String} Number of records.
				 */
				getSelectedItemsCount: function() {
					return this.$SelectedItems.length;
				},

				/**
				 * @inheritdoc BPMSoft.BaseViewModel#onRender
				 * @override
				 */
				onRender: function() {
					this.callParent(arguments);
					var selectedLinks = this.$SelectedItems;
					this.set("SelectedItems", []);
					this.set("SelectedItems", selectedLinks);
				},

				/**
				 * Handler on select button click.
				 * Sends current selected lookup items.
				 * @public
				 */
				onSelectButtonClick: function() {
					const selectedItems = this.$SelectedItems;
					var selectedLinks = this.$HyperlinkCollection.filterByFn(function(link) {
						return selectedItems.indexOf(link.$Id) !== -1;
					});
					this.sandbox.publish("HyperlinkSelected", selectedLinks, [this.sandbox.id]);
				},

				/**
				 * Handler on lookup page close.
				 * Sends message to unload lookup page module.
				 * @public
				 */
				onCloseButtonClick: function() {
					this.sandbox.publish("HyperlinkSelectCancel", null, [this.sandbox.id]);
				}

				// #endregion

			},
			diff: [
				{
					"operation": "insert",
					"name": "BulkEmailHyperlinkLookupContainer",
					"propertyName": "items",
					"values": {
						"wrapClass": ["bulkemail-hyperlink-lookup-container"],
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "HyperlinkLookupHeaderContainer",
					"parentName": "BulkEmailHyperlinkLookupContainer",
					"propertyName": "items",
					"values": {
						"wrapClass": ["hyperlink-lookup-header"],
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "HyperlinkHeaderLabel",
					"parentName": "HyperlinkLookupHeaderContainer",
					"propertyName": "items",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.LABEL,
						"caption": "$Resources.Strings.LookupCaptionText",
						"classes": {
							"labelClass": ["t-title-label"]
						}
					}
				},
				{
					"operation": "insert",
					"name": "CloseButton",
					"parentName": "HyperlinkLookupHeaderContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"classes": {"wrapperClass": ["close-btn-user-class"]},
						"imageConfig": "$Resources.Images.CloseIcon",
						"click": "$onCloseButtonClick",
						"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT
					}
				},
				{
					"operation": "insert",
					"name": "HyperlinkLookupButtonsContainer",
					"parentName": "BulkEmailHyperlinkLookupContainer",
					"propertyName": "items",
					"values": {
						"wrapClass": ["hyperlink-lookup-buttons-container"],
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "HyperlinkSelectedLabel",
					"parentName": "HyperlinkLookupButtonsContainer",
					"propertyName": "items",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.LABEL,
						"caption": "$Resources.Strings.SelectedRecordsCaption",
						"classes": {
							"labelClass": ["t-records-label"]
						}
					}
				},
				{
					"operation": "insert",
					"name": "HyperlinkCountLabel",
					"parentName": "HyperlinkLookupButtonsContainer",
					"propertyName": "items",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.LABEL,
						"caption": "$getSelectedItemsCount",
						"classes": {
							"labelClass": ["t-count-label"]
						}
					}
				},
				{
					"operation": "insert",
					"name": "SelectButton",
					"parentName": "HyperlinkLookupButtonsContainer",
					"propertyName": "items",
					"values": {
						"classes": {"textClass": ["actions-button-margin-right"]},
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"caption": "$Resources.Strings.SelectButtonCaption",
						"click": "$onSelectButtonClick",
						"style": BPMSoft.controls.ButtonEnums.style.ORANGE
					}
				},
				{
					"operation": "insert",
					"name": "CancelButton",
					"parentName": "HyperlinkLookupButtonsContainer",
					"propertyName": "items",
					"values": {
						"classes": {"textClass": ["actions-button-margin-right"]},
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"caption": "$Resources.Strings.CancelButtonCaption",
						"click": "$onCloseButtonClick",
						"style": BPMSoft.controls.ButtonEnums.style.DEFAULT
					}
				},
				{
					"operation": "insert",
					"name": "BulkEmailHyperlinkContainer",
					"parentName": "BulkEmailHyperlinkLookupContainer",
					"propertyName": "items",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["hyperlink-grid-container"],
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "BulkEmailHyperlinkDataGrid",
					"parentName": "BulkEmailHyperlinkContainer",
					"propertyName": "items",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.GRID,
						"type": this.BPMSoft.GridType.LISTED,
						"listedZebra": true,
						"multiSelect": true,
						"collection": "$HyperlinkCollection",
						"selectedRows": "$SelectedItems",
						"isEmpty": "$_isGridEmpty",
						"captionsConfig": [
							{
								cols: 10,
								name: "Title"
							},
							{
								cols: 14,
								name: "URL"
							}
						],
						"columnsConfig": [
							{
								"cols": 10,
								"key": [
									{
										"name": {"bindTo": "Caption"},
										"caption": "Caption"
									}
								]
							},
							{
								"cols": 14,
								"key": [
									{
										"name": {"bindTo": "Url"},
										"caption": "Url"
									}
								]
							}
						]
					}
				}
			]
		};
	});
