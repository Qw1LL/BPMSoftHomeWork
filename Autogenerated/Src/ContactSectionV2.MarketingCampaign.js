define("ContactSectionV2", ["ContactSectionV2Resources"],
	function(resources) {
		return {
			entitySchemaName: "Contact",
			diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/,
			methods: {
				/**
				 * @inheritdoc BPMSoft.BaseSectionV2#init
				 * @overridden
				 */
				init: function() {
					this.callParent(arguments);
					this.set("UseStaticFolders", true);
				},

				/**
				 * @inheritDoc BPMSoft.Configuration.ContactSectionV2#getSectionActions
				 * @overridden
				 */
				getSectionActions: function() {
					var actionMenuItems = this.callParent(arguments);
					actionMenuItems.addItem(this.getButtonMenuItem({
						Type: "BPMSoft.MenuSeparator"
					}));
					actionMenuItems.addItem(this.getButtonMenuItem({
						"Click": {"bindTo": "setActualEmails"},
						"Caption": {"bindTo": "Resources.Strings.ActualizeActionCaption"},
						"Enabled": {
							"bindTo": "IsGridEmpty",
							"bindConfig": {"converter": function(value) {
								return !value;
							}}
						}
					}));
					return actionMenuItems;
				},

				/**
				 * ##### ######## "##### ####### ############## # Email".
				 */
				setActualEmails: function() {
					var cfg = {
						style: BPMSoft.MessageBoxStyles.ORANGE
					};
					this.BPMSoft.showConfirmation(resources.localizableStrings.ActualizeActionMessageCaption,
							function getSelectedButton(returnCode) {
								if (returnCode === BPMSoft.MessageBoxButtons.YES.returnCode) {
									var webServiceConfig = {
										serviceName: "ContactService",
										methodName: "SetActualEmails",
										data: {
											filters: this.getSerializedFilters(),
											entitySchemaUId: this.entitySchema.uId
										}
									};
									this.callService(webServiceConfig, BPMSoft.emptyFn);
								}
							}, ["yes", "no"], this, cfg);
				},

				/**
				 * ########## ################# #######, ########### # #######.
				 * @return {String} ################ #######.
				 */
				getSerializedFilters: function() {
					var sectionFilters = this.get("SectionFilters");
					var serializationInfo = sectionFilters.getDefSerializationInfo();
					serializationInfo.serializeFilterManagerInfo = true;
					return sectionFilters.serialize(serializationInfo);
				}
			}
		};
	});
