define("AccountContactsDetailV2", ["MaskHelper", "PortalUserInvitationMixin"],
	function(MaskHelper) {
		return {
			entitySchemaName: "Contact",
			mixins: {
				PortalUserInvitationMixin: "BPMSoft.PortalUserInvitationMixin"
			},
			attributes: {

				"IsOrganizationExists": {
					"dataValueType": this.BPMSoft.DataValueType.BOOLEAN,
					"value": false
				}
			},
			methods: {

				/**
				 * @inheritDoc BPMSoft.BaseGridDetailV2#addRecordOperationsMenuItems
				 * @overridden
				 */
				addRecordOperationsMenuItems: function(toolsButtonMenu) {
					this.callParent(arguments);
					toolsButtonMenu.addItem(this.getButtonMenuSeparator());
					toolsButtonMenu.addItem(this.getAddPortalUserButtonMenuItem());
				},

				/**
				 * Returns an element of combobox list of functional button which is responsible for inviting
				 * contacts on portal.
				 * @protected
				 * @virtual
				 * @return {BPMSoft.BaseViewModel} An element of combobox list of functional button.
				 */
				getAddPortalUserButtonMenuItem: function() {
					return this.getButtonMenuItem({
						Caption: {"bindTo": "Resources.Strings.AddPortalUser"},
						Click: {"bindTo": "createUsers"},
						Visible: {"bindTo": "getIsAddPortalUserButtonVisible"},
						Enabled: {"bindTo": "isAnySelected"}
					});
				},

				/**
				 * Gets is add contact on portal button visible.
				 * @returns {boolean} Returns true if PortalUserManagementV2 feature enable.
				 */
				getIsAddPortalUserButtonVisible: function() {
					return this.getIsFeatureEnabled("PortalUserManagementV2");
				},

				/**
				 * @inheritDoc BaseDetailV2#init
				 * @override
				 */
				onRender: function() {
					this.callParent(arguments);
					this.initializeIsOrganizationExists();
				},

				/**
				 * Initializes existence of Organization by Account.
				 * @protected
				 */
				initializeIsOrganizationExists: function() {
					const accountId = this.get("MasterRecordId");
					this.checkOrganization(accountId, function(response) {
						const result = response && response.isPortalAccountExists;
						this.set("IsOrganizationExists", result);
					}, this);
				},

				/**
				 * Creates portal users by contacts and connects them to the organization.
				 */
				createUsers: function () {
					if (this.$IsOrganizationExists) {
						this.createUsersByContactsIds();
					} else {
						this.showOrganizationInformationDialog(this.getAccountInfo());
					}
				},

				/**
				 * Returns account columns values.
				 * @return {Object} Columns values.
				 */
				getAccountInfo: function() {
					return this.sandbox.publish("GetColumnsValues", ["Id", "Name"], [this.sandbox.id]);
				},

				/**
				 * Calls service by invitation contact on portal.
				 */
				createUsersByContactsIds: function() {
					const selectedContactsId = this.getSelectedItems();
					if (this.Ext.isEmpty(selectedContactsId)) {
						return;
					}
					this._showBodyMask();
					this.createUsersByContacts(selectedContactsId, function() {
						this._hideBodyMask();
						this.updatePortalUserInOrganizationDetail();
					}, this);
				},

				/**
				 * Updates PortalUserInOrganization detail after inviting contacts.
				 * @protected
				 */
				updatePortalUserInOrganizationDetail: function () {
					this.sandbox.publish("DetailChanged", null, [this.sandbox.id]);
				},

				/**
				 * Shows a mask on the tag content container.
				 * @private
				 */
				_showBodyMask: function() {
					this._maskId = MaskHelper.showBodyMask();
				},

				/**
				 * Hides a mask on the tag content container.
				 * @private
				 */
				_hideBodyMask: function() {
					MaskHelper.hideBodyMask({ maskId: this._maskId});
				}
			},
			diff: /**SCHEMA_DIFF*/[
			]/**SCHEMA_DIFF*/
		};
	}
);
