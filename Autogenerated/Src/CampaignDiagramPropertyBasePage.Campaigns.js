define("CampaignDiagramPropertyBasePage", ["BPMSoft"],
		function(BPMSoft) {
			return {
				attributes: {
					/**
					* ########## ############# ######## ########.
					*/
					"DiagramElementId": {
						dataValueType: BPMSoft.DataValueType.GUID,
						type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
					},

					/**
					* ######### ######## ########.
					*/
					"DiagramElementCategory": {
						dataValueType: BPMSoft.DataValueType.TEXT,
						type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
					},

					/**
					* ######### ######## ########.
					*/
					"DiagramElementCaption": {
						dataValueType: BPMSoft.DataValueType.TEXT,
						type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
					},

					/**
					* ########## ############# #### ########.
					*/
					"DiagramElementTypeId": {
						dataValueType: BPMSoft.DataValueType.GUID,
						type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
					},

					/**
					* ### #### ########.
					*/
					"DiagramElementPageTypeCaption": {
						dataValueType: BPMSoft.DataValueType.TEXT,
						type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
					},

					/**
					 * Url ##### ###### ########.
					 */
					"DiagramElementPageIconUrl": {
						dataValueType: BPMSoft.DataValueType.TEXT,
						type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
					},

					/**
					* ########## ############# ###### ######### # ########.
					*/
					"DiagramElementRecordId": {
						dataValueType: BPMSoft.DataValueType.GUID,
						type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
					},

					/**
					* ### ##### ########## #######.
					*/
					"DiagramElementSchemaName": {
						dataValueType: BPMSoft.DataValueType.TEXT,
						type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
					},

					/**
					 * ################ ###### ######## #########.
					 */
					"DiagramElementAddInfo": {
						dataValueType: BPMSoft.DataValueType.CUSTOM_OBJECT,
						type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
					},
					/**
					 * ####### ############### ########
					 */
					"IsStatusEnabled": {
						type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						dataValueType: BPMSoft.DataValueType.BOOLEAN
					},
					/**
					 * Inforamtion button image config
					 */
					"InfoButtonImageConfig": {
						type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						name: "InfoButtonImageConfig"
					},
					/**
					 * Input connections of the chart element.
					 */
					"DiagramElementInEdges": {
						dataValueType: BPMSoft.DataValueType.CUSTOM_OBJECT,
						type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
					},
					/**
					 * Output connections of the chart element.
					 */
					"DiagramElementOutEdges": {
						dataValueType: BPMSoft.DataValueType.CUSTOM_OBJECT,
						type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
					}
				},
				methods: {
					/**
					* ######## URL ########### ## ########### ##############.
					* @param {Guid} sysImageId ########## ############# ###########.
					* @protected
					* @return {String} URL ###########.
					*/
					getSysImageUrl: function(sysImageId) {
						var imageConfig = {
							source: BPMSoft.ImageSources.SYS_IMAGE,
							params: {
								primaryColumnValue: sysImageId
							}
						};
						return BPMSoft.ImageUrlBuilder.getUrl(imageConfig);
					},

					/**
					 * Sets image config of information button
					 * @protected
					 */
					initInfoButtonImageConfig: function() {
						var informationButton = Ext.create("BPMSoft.InformationButton");
						var imageConfig = informationButton.getDefaultImageConfig();
						this.set("InfoButtonImageConfig", imageConfig);
					},

					/**
					 * ####### ############# ######.
					 * @protected
					 */
					init: function(callback, scope) {
						this.sandbox.subscribe("CardChanged", function(config) {
							this.set(config.key, config.value);
						}, this, [this.sandbox.id]);
						this.initInfoButtonImageConfig();
						if (callback) {
							callback.call(scope);
						}
					},

					getNotSelectImage: function() {
						var iconId = this.get("Resources.Strings.CatIconId");
						return this.getSysImageUrl(iconId);
					}
				},
				diff: /**SCHEMA_DIFF*/[
					{
						"operation": "insert",
						"name": "CampaignDiagramPropertyContainer",
						"values": {
							"id": "CampaignDiagramPropertyContainer",
							"selectors": {"wrapEl": "#CampaignDiagramPropertyContainer"},
							"itemType": BPMSoft.ViewItemType.CONTAINER,
							"wrapClass": ["campaign-diagram-property-container"],
							"items": []
						}
					},
					{
						"operation": "insert",
						"name": "NotSelectedImage",
						"parentName": "CampaignDiagramPropertyContainer",
						"propertyName": "items",
						"values": {
							"markerValue": "NotSelectedImage",
							"generator": "ImageCustomGeneratorV2.generateSimpleCustomImage",
							"onPhotoChange": BPMSoft.emptyFn,
							"getSrcMethod": "getNotSelectImage",
							"classes": {
								"wrapClass": ["not-selected-image"]
							},
							"items": []
						}
					},
					{
						"operation": "insert",
						"name": "NotSelectedLabel",
						"parentName": "CampaignDiagramPropertyContainer",
						"propertyName": "items",
						"values": {
							"markerValue": "NotSelectedLabel",
							"itemType": BPMSoft.ViewItemType.CONTAINER,
							"wrapClass": ["description-container"],
							"items": [
								{
									"itemType": BPMSoft.ViewItemType.LABEL,
									"classes": {
										"labelClass": [
											"description-label"
										],
										"wrapClass": [
											"description-wrap"
										]
									},
									"caption": {
										"bindTo": "Resources.Strings.EmptyPageCaption"
									}
								}
							]
						}
					}
				]/**SCHEMA_DIFF*/,
				messages:{
					/**
					 * @message CardChanged
					 * ######## ## ######### ######### ########
					 * @param {Object} config
					 * @param {String} config.key ######## ####### ###### #############
					 * @param {Object} config.value ########
					 */
					"CardChanged": {
						mode: this.BPMSoft.MessageMode.PTP,
						direction: this.BPMSoft.MessageDirectionType.SUBSCRIBE
					}
				}
			};
		});
