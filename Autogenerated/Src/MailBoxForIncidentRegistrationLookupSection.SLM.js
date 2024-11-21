define("MailBoxForIncidentRegistrationLookupSection", [],
	function() {
		return {
			entitySchemaName: "MailboxForIncidentRegistration",
			diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/,
			methods: {
				/**
				 * @inheritdoc BPMSoft.BaseSectionV2#getProfileKey
				 * @overridden
				 */
				getProfileKey: function() {
					var currentTabName = this.getActiveViewName();
					var schemaName = this.name;
					return schemaName + this.entitySchemaName + "GridSettings" + currentTabName;
				},

				/**
				 * @inheritdoc BPMSoft.BaseSectionV2#getViewOptions
				 * @overridden
				 */
				getViewOptions: function() {
					var viewOptions = this.Ext.create("BPMSoft.BaseViewModelCollection");
					viewOptions.addItem(this.getButtonMenuItem({
						"Caption": {"bindTo": "Resources.Strings.SortMenuCaption"},
						"Items": {"bindTo": "SortColumns"},
						"Visible": {"bindTo": "IsSortMenuVisible"}
					}));
					viewOptions.addItem(this.getButtonMenuItem({
						"Caption": {"bindTo": "Resources.Strings.OpenGridSettingsCaption"},
						"Click": {"bindTo": "openGridSettings"},
						"Visible": {"bindTo": "IsGridSettingsMenuVisible"}
					}));
					return viewOptions;
				},

				/**
				 * Publish ChangeHeaderCaption message.
				 * @private
				 */
				_publishChangeHeaderCaption: function() {
					this.sandbox.publish("ChangeHeaderCaption", {
						"caption": this.get("Resources.Strings.HeaderCaption"),
						"dataViews": Ext.create("BPMSoft.Collection")
					});
				},

				/**
				 * @inheritdoc BPMSoft.BaseSectionV2#onCardAction
				 * @overridden
				 */
				onCardAction: function() {
					this.callParent(arguments);
					this._publishChangeHeaderCaption();
				},

				/**
				 * @inheritdoc BPMSoft.BaseSectionV2#onRender
				 * @overridden
				 */
				onRender: function() {
					this.callParent(arguments);
					this._publishChangeHeaderCaption();
				}
			}
		};
	});
