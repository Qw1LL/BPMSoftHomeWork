define("CampaignTemplateGalleryPage",  ["CampaignTemplateGalleryPageResources", "ModalBox",
	"css!CampaignTemplateGalleryPage", "CampaignDesignerComponent"],
	function(resources) {
		return {
			attributes: {
					/**
					 * Is should show blank slate.
					 */
					"IsBlankSlateVisible": {
						"dataValueType": BPMSoft.DataValueType.BOOLEAN,
						"value": false
					}
			},
			messages: {
					/**
					 * @message CampaignTemplateSelected
					 * Emits campaign template selected action.
					 */
					"CampaignTemplateSelected": {
						"mode": this.BPMSoft.MessageMode.PTP,
						"direction": this.BPMSoft.MessageDirectionType.PUBLISH
					},
					/**
					 * @message CampaignTemplateGalleryCanceled
					 * Emits cancel campaign template gallery action.
					 */
					"CampaignTemplateGalleryCanceled": {
						"mode": this.BPMSoft.MessageMode.PTP,
						"direction": this.BPMSoft.MessageDirectionType.PUBLISH
					}
			},
			methods: {
				/**
				* @private
				*/
				_addResources: function(element) {
					element.resources = resources;
				},

				/**
				* @private
				*/
				_addEventListeners: function(element) {
					element.addEventListener("Selected", this._onSelected.bind(this));
					element.addEventListener("Canceled", this._onCanceled.bind(this));
				},

				/**
				* @private
				*/
				_onSelected: function(value) {
					const templateId = value.detail.recordIds[0]
					this.sandbox.publish("CampaignTemplateSelected", templateId, [this.sandbox.id]);
				},

				/**
				* @private
				*/
				_onCanceled: function() {
					this.sandbox.publish("CampaignTemplateGalleryCanceled", null, [this.sandbox.id]);
				},

				/**
				 * @private
				 */
				_addAngularElementSelector: function() {
					const element = document.createElement("ts-campaign-template-gallery");
					this._addEventListeners(element)
					this._addResources(element);
					document.querySelector("#CampaignTemplateGallery-wrap").appendChild(element);
				},

				/**
				 * Returns blank slate icon url.
				 * @protected
				 * @virtual
				 * @return {String} Blank slate icon url.
				 */
				getBlankSlateIcon: function() {
					return this.BPMSoft.ImageUrlBuilder.getUrl(this.get("Resources.Images.BlankSlateIcon"));
				},

				/**
				 * @inheritdoc BPMSoft.BaseSchemaViewModel#onRender
				 * @overridden
				 */
				onRender: function() {
					if (!this.$IsBlankSlateVisible){
						this._addAngularElementSelector();
					}
				}
			},
			diff: [
				{
					"name": "TemplateGalleryContainer",
					"operation": "insert",
					"values": {
						"id": "CampaignTemplateGallery-wrap",
						"items": [],
						"itemType": this.BPMSoft.ViewItemType.CONTAINER,
						"styles": {
								"height": "100%",
								"width": "100%"
						},
						"visible": {
							"bindTo": "IsBlankSlateVisible",
							"bindConfig": {
								"converter": "invertBooleanValue"
							}
						},
					}
				},
				{
					"operation": "insert",
					"name": "BlankSlateContainer",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.GRID_LAYOUT,
						"classes": {
							"wrapClassName": ["blank-slate-wrap"]
						},
						"styles": {
							"height": "100%",
							"width": "100%"
						},
						"visible": "$IsBlankSlateVisible",
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "BlankSlateContainerHeader",
					"parentName": "BlankSlateContainer",
					"propertyName": "items",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.CONTAINER,
						"classes": {
							"wrapClassName": ["blank-slate-wrap-header"]
						},
						"visible": "$IsBlankSlateVisible",
						"items": [],
						"styles": {
							"height": "100%",
							"width": "100%"
						},
						"layout": {
							"column": 0,
							"row": 0,
							"colSpan": 24,
							"rowSpan": 0
						}
					}
				},
				{
					"operation": "insert",
					"name": "CloseButton",
					"parentName": "BlankSlateContainerHeader",
					"propertyName": "items",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.BUTTON,
						"imageConfig": "$Resources.Images.CloseIcon",
						"click": "$_onCanceled",
						"classes": {
							"wrapperClass": ["close-btn-user-class"]
						},
						"style": this.BPMSoft.controls.ButtonEnums.style.TRANSPARENT
					}
				},
				{
					"operation": "insert",
					"name": "BlankSlateDescription",
					"parentName": "BlankSlateContainer",
					"propertyName": "items",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.LABEL,
						"caption": "$Resources.Strings.BlankSlateDescription",
						"labelClass": ["blank-slate-description"],
						"layout": {
							"column": 3,
							"row": 6,
							"colSpan": 20,
							"rowSpan": 6
						}
					}
				}
			]
		};
});
