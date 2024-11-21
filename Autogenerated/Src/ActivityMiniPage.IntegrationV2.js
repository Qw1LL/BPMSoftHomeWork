 define("ActivityMiniPage", [], function() {
	return {
		entitySchemaName: "Activity",
		attributes: {

			/**
			 * Link to the meeting service to connect.
			 */
			"MeetingServiceLink": {
				"dataValueType": BPMSoft.DataValueType.TEXT,
				"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"value": ""
			}

		},
		details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
		methods: {

			// region Methods: Private

			/**
			 * Get a list of meeting service link masks.
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Execution context.
			 * @private
			 */
			_getMeetingServicesLinkMasks: function(callback, scope) {
				const linkMasks = [];
				const esq = this.Ext.create("BPMSoft.EntitySchemaQuery", {
					rootSchemaName: "MeetingServiceLink",
					clientESQCacheParameters: {
						cacheLevel: BPMSoft.ESQServerCacheLevels.SESSION,
						cacheGroup: "MeetingServiceLink" + BPMSoft.SysValue.CURRENT_USER.value,
						cacheItemName: "MeetingServiceLink"
					}
				});
				esq.addColumn("LinkMask");
				esq.getEntityCollection(function(response) {
					if (response.success && response.collection) {
						BPMSoft.each(response.collection.getItems(), function(item) {
							linkMasks.push(item.get("LinkMask"));
						}, this);
					}
					Ext.callback(callback, scope || this, [linkMasks]);
				}, this);
			},

			/**
			 * Get regexp for meeting services links.
			 * @private
			 * @param {Array} links List of meeting services links.
			 * @returns {Object} Regexp. 
			 */
			_getMeetingLinksRegex: function(links) {
				let expression = Ext.String.format("({0})", links.join('|'));
				return new RegExp(expression, 'g');
			},

			// endregion

			// region Methods: Protected

			/**
			 * @inheritdoc BaseMiniPage#onEntityInitialized.
			 * @override
			 */
			onEntityInitialized: function() { 
				this.callParent(arguments);
				if (this.getIsFeatureEnabled("NewMeetingIntegration")) {
					this.initMeetingServicesJoinLink();
				}
			},

			/**
			 * Generating a link to connect to the meeting service.
			 * @protected
			 */
			initMeetingServicesJoinLink: function() {
				const urls = this.getUrlsFromNotes();
				if (!urls.length) {
					return;
				}
				BPMSoft.chain(
					function(next) {
						this._getMeetingServicesLinkMasks(next, this);
					},
					function(next, linkMasks) {
						let joinLink = "";
						if (linkMasks.length) {
							const linksRegex = this._getMeetingLinksRegex(linkMasks);
							for (const url of urls) {
								if (linksRegex.test(url)) {
									joinLink = url;
									break;
								}
							}
						}
						this.set("MeetingServiceLink", joinLink);
					}, this
				);
			},

			/**
			 * Open the link to the meeting service.
			 * @protected
			 */
			openMeetingServiceLink: function() {
				const href = this.get("MeetingServiceLink");
				window.open(href, "_blank");
			},

			/**
			 * Get all links from activity notes.
			 * @protected 
			 */
			getUrlsFromNotes: function() {
				const notes = this.get("Notes");
				return notes ? BPMSoft.getUrls(notes) : [];
			},

			// endregion
			
		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "insert",
				"name": "JoinMeetingServiceButton",
				"parentName": "HeaderContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"style": BPMSoft.controls.ButtonEnums.style.ORANGE,
					"caption": {
						"bindTo": "Resources.Strings.JoinMeetingServiceButtonCaption"
					},
					"hint": {
						"bindTo": "Resources.Strings.JoinMeetingServiceButtonHint"
					},
					"click": {
						"bindTo": "openMeetingServiceLink"
					},
					"styles": {
						"textStyle": {
							"margin-top": "15px",
							"width": "max-content",
							"font-size": "small"
						}
					},
					"visible": {
						"bindTo": "MeetingServiceLink",
						"bindConfig": {
							"converter": function(value) {
								return this.isNotEmpty(value);
							}
						}
					}
				},
				"index": 3
			}
		]/**SCHEMA_DIFF*/
	};
});
