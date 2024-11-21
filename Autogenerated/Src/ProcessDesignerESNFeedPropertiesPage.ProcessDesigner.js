define("ProcessDesignerESNFeedPropertiesPage", ["ext-base", "BPMSoft",
		"ProcessDesignerESNFeedPropertiesPageResources", "ImageView"
	], function(Ext, BPMSoft) {
		return {
			mixins: {
				editable: "BPMSoft.ProcessSchemaElementEditable"
			},
			messages: {

				/**
				 * @message RerenderModule
				 * Rerender ESNFeed module message.
				 */
				"RerenderModule": {
					direction: BPMSoft.MessageDirectionType.PUBLISH,
					mode: BPMSoft.MessageMode.PTP
				},

				/**
				 * @message GetRecordInfo
				 * Get information about source record message.
				 */
				"GetRecordInfo": {
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE,
					mode: BPMSoft.MessageMode.PTP
				}
			},
			attributes: {
				"Schema": {
					dataValueType: BPMSoft.DataValueType.OBJECT,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				}
			},
			methods: {

				//region Methods: Private

				/**
				 * Returns sandbox identifier for ESNFeed module.
				 * @private
				 * @return {String}
				 */
				_getSocialFeedSandboxId: function() {
					return this.sandbox.id + "_ESNFeed";
				},

				/**
				 * Returns information about current record and entity schema.
				 * @private
				 * @return {Object} Information about current record and entity schema.
				 */
				_getRecordInfo: function() {
					var schema = this.get("Schema");
					var sysSchemaEntityUId = "e6e68ac1-495d-4727-a7a7-9b531ab9f849";
					return {
						channelId: schema.uId,
						channelName: schema.getCaption(),
						entitySchemaUId: sysSchemaEntityUId,
						entitySchemaName: "VwProcessLib"
					};
				},

				//endregion

				//region Methods: Protected

				/**
				 * @inheritdoc BPMSoft.BaseSchemaViewModel#init
				 * @overridden
				 */
				init: function(callback, scope) {
					this.mixins.editable.init.call(this);
					var tag = this._getSocialFeedSandboxId();
					this.sandbox.subscribe("GetRecordInfo", this._getRecordInfo, this, [tag]);
					this.sandbox.loadModule("MiniPageListener");
					var schema = this.sandbox.publish("GetProcessSchema");
					this.set("Schema", schema);
					callback.call(scope);
				},

				/**
				 * @inheritdoc BPMSoft.BaseObject#onDestroy
				 * @overridden
				 */
				onDestroy: function() {
					this.mixins.editable.onDestroy.call(this);
					this.callParent(arguments);
				},

				/**
				 * Loads ESNFeed module to ESNFeed container.
				 * @protected
				 */
				loadESNFeed: function() {
					var tag = this._getSocialFeedSandboxId();
					var rendered = this.sandbox.publish("RerenderModule", {renderTo: "ESNFeed"}, [tag]);
					if (!rendered) {
						var esnFeedModuleConfig = {
							renderTo: "ESNFeed",
							id: tag
						};
						var activeSocialMessageId = this.get("ActiveSocialMessageId");
						if (activeSocialMessageId) {
							esnFeedModuleConfig.parameters = {
								activeSocialMessageId: activeSocialMessageId
							};
						}
						this.sandbox.loadModule("ESNFeedModule", esnFeedModuleConfig);
					}
				}

				//endregion

			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"name": "ESNFeedPropertiesContainer",
					"values": {
						"id": "ESNFeedPropertiesContainer",
						"selectors": {"wrapEl": "#ESNFeedPropertiesContainer"},
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["feed-properties-container"],
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "ESNFeedPropertiesContainer",
					"name": "ESNFeedContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "ESNFeedContainer",
					"propertyName": "items",
					"name": "ESNFeed",
					"values": {
						"itemType": BPMSoft.ViewItemType.MODULE,
						"moduleName": "ESNFeedModule",
						"afterrender": {
							"bindTo": "loadESNFeed"
						},
						"afterrerender": {
							"bindTo": "loadESNFeed"
						}
					}
				}
			]/**SCHEMA_DIFF*/
		};
	}
);
