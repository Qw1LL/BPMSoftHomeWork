define("PreviewDynamicContentBuilder", ["PreviewDynamicContentBuilderResources",
		"DynamicContentReplicaBuilder", "ContainerListGenerator", "ContainerList",
		"MultilineLabel", "css!MultilineLabel"], function(resources, ReplicaBuilder) {
	return {
		messages: {
			/**
			 * @message GetContentBuilderConfig
			 * Gets content builder config.
			 */
			"GetContentBuilderConfig": {
				"mode": this.BPMSoft.MessageMode.PTP,
				"direction": this.BPMSoft.MessageDirectionType.PUBLISH
			},

			/**
			 * @message UpdatePreview
			 * Gets content builder config.
			 */
			"UpdatePreview": {
				"mode": this.BPMSoft.MessageMode.PTP,
				"direction": this.BPMSoft.MessageDirectionType.SUBSCRIBE
			},
		},
		attributes: {
			/**
			 * Collection of the replica models.
			 * @type {BPMSoft.BaseViewModelCollection}
			 */
			"ReplicaCollection": {
				"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"dataValueType": this.BPMSoft.DataValueType.COLLECTION,
				"isCollection": true
			},

			/**
			 * Mask of active replica.
			 * @type {Number}
			 */
			"ActiveReplicaMask": {
				dataValueType: this.BPMSoft.DataValueType.INTEGER,
				type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			/**
			 * Side bar visible value.
			 * @type {Boolean}
			 */
			"IsSideBarVisible": {
				"dataValueType": this.BPMSoft.DataValueType.BOOLEAN,
				"value": false
			},

			/**
			 * Flag to indicate replica mask 0.
			 * @type {Boolean}
			 */
			"IsReplicaMaskZero": {
				"dataValueType": this.BPMSoft.DataValueType.BOOLEAN,
				"value": false
			},

			/**
			 * Flag to indicate that there is no default content at the template.
			 * @type {Boolean}
			 */
			"NoDefaultContent": {
				"dataValueType": this.BPMSoft.DataValueType.BOOLEAN,
				"value": false
			}
		},
		methods: {

			// region Methods: Private

			_generateContentReplicas: function(contentBuilderConfig) {
				var replicas = ReplicaBuilder.generateReplicas(contentBuilderConfig);
				this.initReplicaCollection(replicas);
				this._initSideBarVisibility();
				this.$NoDefaultContent = this._checkNoDefaultContent(contentBuilderConfig);
			},

			_subscribeMessages: function() {
				this.sandbox.subscribe("UpdatePreview", this._generateContentReplicas, this);
			},

			/**
			 * Sets content value for replica view model by mask.
			 * @private
			 * @param {Number} mask Mask of current replica.
			 * @param {String} content Contant value to set.
			 */
			_setReplicaContent: function(mask, content) {
				var replicaModel = this._getReplicaByMask(mask);
				if (replicaModel && replicaModel.$Content !== content) {
					replicaModel.$Content = content;
				}
			},

			/**
			 * Returns replica view model by mask.
			 * @private
			 * @param {Number} mask Mask of current replica.
			 * @returns {BPMSoft.BaseModel} Replica view model.
			 */
			_getReplicaByMask: function(mask) {
				return this.$ReplicaCollection.findByFn(function(replica) {
					return replica.$Mask === mask;
				});
			},

			/**
			 * Checks when there is no default content in all dynamic blocks.
			 * @private
			 * @param {Object} config Template config.
			 */
			_checkNoDefaultContent: function(config) {
				var hasDefault = false;
				BPMSoft.each(config.Items, function(item) {
					if (item.ItemType === 'blockgroup') {
						var defaultBlock = Ext.Array.findBy(item.Items, function(block) {
							return block.IsDefault;
						});
						hasDefault = hasDefault || Boolean(defaultBlock);
						return !hasDefault;
					}
				}, this);
				return !hasDefault;
			},

			/**
			 * Initializes visibility of side bar control.
			 * @private
			 */
			_initSideBarVisibility: function() {
				var isStaticTemplate = this.$ReplicaCollection.getCount() === 1
					&& this.$ReplicaCollection.first().$Mask === 0;
				this.$IsSideBarVisible = !isStaticTemplate;
			},

			_switchReplicaContent: function(mask){
				this.$ActiveReplicaMask = mask;
				var content = this.getPreviewHtml();
				this.$PreviewHtml = content;
				this._setReplicaContent(mask, content);
			},

			// endregion

			// region Methods: Protected

			/**
			 * @inheritdoc BPMSoft.PreviewContentBuilder#getPreviewHtml
			 * @override
			 */
			getPreviewHtml: function(previewConfig) {
				if (BPMSoft.isEmpty(this.$ActiveReplicaMask) && !this.$ReplicaCollection.isEmpty()) {
					return this.get("Resources.Strings.SelectReplicaToPreviewContent");
				}
				if (this.$IsSideBarVisible) {
					var replica = this._getReplicaByMask(this.$ActiveReplicaMask);
					if (replica && replica.$Content) {
						return replica.$Content;
					}
					this.$IsReplicaMaskZero = this.$ActiveReplicaMask === 0;
					previewConfig = previewConfig || {};
					previewConfig.activeReplicaMask = this.$ActiveReplicaMask;
				}
				return this.callParent([previewConfig]);
			},

			/**
			 * Receives content builder config.
			 * @protected
			 * @return {BPMSoft.Collection}
			 */
			getContentBuilderConfig: function() {
				return this.sandbox.publish("GetContentBuilderConfig");
			},

			/**
			 * Creates block group item view model.
			 * @protected
			 * @param {Object} replica Replica item.
			 * @return {BPMSoft.BaseModel} Replica view model.
			 */
			createReplicaViewModel: function(replica) {
				return this.Ext.create("BPMSoft.BaseModel", {
					values: {
						Mask: replica.ReplicaMask,
						Content: null,
						Caption: replica.Caption
					}
				});
			},

			/**
			 * Returns preview visibility state.
			 * @protected
			 * @returns {Boolean} Preview visibility.
			 */
			getPreviewVisible: function() {
				return Boolean(this.$PreviewHtml && !this.$IsReplicaMaskZero);
			},

			/**
			 * Returns blank slate image url.
			 * @protected
			 * @returns {string} Blank slate image URL.
			 */
			getEmptyReplicaImageUrl: function() {
				var config = resources.localizableImages.EmptyReplicaIcon;
				return BPMSoft.ImageUrlBuilder.getUrl(config);
			},

			/**
			 * Sets first replica list item selected and draws replica content preview.
			 * @protected
			 */
			selectFirstItem: function() {
				var firstReplica = this.$ReplicaCollection.first();
				if (firstReplica) {
					this._switchReplicaContent(firstReplica.$Mask);
				}
			},

			// endregion

			// region Methods: Public

			/**
			 * @inheritdoc PreviewContentBuilder#init
			 * @override
			 */
			init: function() {
				this.$ReplicaCollection = Ext.create("BPMSoft.BaseViewModelCollection");
				this.$ActiveReplicaMask = null;
				var contentBuilderConfig = this.getContentBuilderConfig();
				this._generateContentReplicas(contentBuilderConfig);
				this._subscribeMessages();
				this.callParent(arguments);
			},

			/**
			 * @inheritdoc PreviewContentBuilder#onRender
			 * @override
			 */
			onRender: function() {
				this.selectFirstItem();
				this.callParent(arguments);
			},

			/**
			 * Inits collection of replicas view models.
			 * @protected
			 * @param {Array} replicaItems Array containing the data of each replica.
			 */
			initReplicaCollection: function(replicas) {
				var replicaCollection = this.Ext.create("BPMSoft.BaseViewModelCollection");
				this.BPMSoft.each(replicas, function(replica) {
					var replicaViewModel = this.createReplicaViewModel(replica);
					replicaCollection.add(replicaViewModel.$Mask, replicaViewModel);
				}, this);
				this.$ReplicaCollection.clear();
				this.$ReplicaCollection.loadAll(replicaCollection);
			},

			/**
			 * Handles current replica mask change.
			 * @public
			 * @param {Number} mask New selected replica mask value.
			 */
			onReplicaMaskChange: function(mask) {
				if (this.$ActiveReplicaMask === mask) {
					return;
				}
				this._switchReplicaContent(mask);
			}

			// endregion

		},
		diff: /**SCHEMA_DIFF*/ [{
			"operation": "insert",
			"name": "MainContainer",
			"propertyName": "items",
			"index": 1,
			"values": {
				"itemType": this.BPMSoft.ViewItemType.CONTAINER,
				"wrapClass": ["preview-main-container"],
				"items": []
			}
		}, {
			"operation": "move",
			"name": "Center",
			"parentName": "MainContainer",
			"propertyName": "items"
		}, {
			"operation": "insert",
			"name": "SideBar",
			"parentName": "MainContainer",
			"propertyName": "items",
			"values": {
				"itemType": this.BPMSoft.ViewItemType.CONTAINER,
				"wrapClass": ["preview-sidebar-container"],
				"visible": {
					"bindTo": "IsSideBarVisible"
				},
				"items": []
			}
		},
		{
			"operation": "insert",
			"name": "NoDefaultContentInfoButton",
			"parentName": "SideBar",
			"propertyName": "items",
			"values": {
				"itemType": BPMSoft.ViewItemType.INFORMATION_BUTTON,
				"content": "$Resources.Strings.NoDefaultContentHint",
				"controlConfig": {
					"visible": "$NoDefaultContent",
					"imageConfig": "$Resources.Images.DefaultBlockInfoButtonImage"
				},
				"style": BPMSoft.TipStyle.WHITE,
				"behaviour": {
					"displayEvent": BPMSoft.controls.TipEnums.displayEvent.HOVER
						| BPMSoft.controls.TipEnums.displayEvent.CLICK
				},
				"tools": []
			}
		}, {
			"operation": "insert",
			"name": "ReplicasContainerList",
			"parentName": "SideBar",
			"propertyName": "items",
			"values": {
				"idProperty": "Mask",
				"rowCssSelector": ".replica-item",
				"itemType": this.BPMSoft.ViewItemType.GRID,
				"collection": "$ReplicaCollection",
				"generator": "ContainerListGenerator.generatePartial",
				"selectableRowCss": "replica-item",
				"classes": {
					"wrapClassName": ["replica-container-list"]
				},
				"itemPrefix": "View",
				"dataItemIdPrefix": "replica-item",
				"activeItem": "$ActiveReplicaMask",
				"onItemClick": "$onReplicaMaskChange",
				"defaultItemConfig": {
					"className": "BPMSoft.Container",
					"id": "replica-item-view",
					"selectors": {
						"wrapEl": "#replica-item-view"
					},
					"classes": {
						"wrapClassName": ["replica-item-wrapper-container"]
					},
					"items": [{
						"className": "BPMSoft.Label",
						"classes": {
							"labelClass": ["label-wrap"]
						},
						"caption": "$Caption",
						"markerValue": "$Caption"
					}]
				}
			}
		}, {
			"operation": "merge",
			"name": "Outside",
			"values": {
				"visible": "$getPreviewVisible"
			}
		}, {
			"operation": "insert",
			"name": "EmptyReplicaContainer",
			"parentName": "Center",
			"propertyName": "items",
			"values": {
				"itemType": this.BPMSoft.ViewItemType.CONTAINER,
				"wrapClass": ["empty-replica-container"],
				"items": [],
				"visible": "$IsReplicaMaskZero"
			}
		}, {
			"operation": "insert",
			"name": "EmptyReplicaImage",
			"parentName": "EmptyReplicaContainer",
			"propertyName": "items",
			"values": {
				"generator": "ImageCustomGeneratorV2.generateSimpleCustomImage",
				"onPhotoChange": BPMSoft.emptyFn,
				"getSrcMethod": "getEmptyReplicaImageUrl",
				"classes": {
					"wrapClass": ["empty-replica-image"]
				},
				"items": []
			}
		}, {
			"operation": "insert",
			"name": "EmptyReplicaWarningLabel",
			"parentName": "EmptyReplicaContainer",
			"propertyName": "items",
			"values": {
				"className": "BPMSoft.MultilineLabel",
				"itemType": BPMSoft.ViewItemType.LABEL,
				"classes": {
					"labelClass": ["empty-replica-warning-label"]
				},
				"contentVisible": true,
				"caption": "$Resources.Strings.EmptyReplicaWarning"
			}
		}, {
			"operation": "merge",
			"name": "NewTabButton",
			"values": {
				"enabled": "$getPreviewVisible"
			}
		}] /**SCHEMA_DIFF*/
	};
});
