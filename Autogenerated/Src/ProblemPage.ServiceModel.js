define("ProblemPage", ["ProblemPageResources"],
	function(resourses) {
		return {
			entitySchemaName: "Problem",
			details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
			diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/,
			attributes: {},
			methods: {
				/**
				 * ######### ########-######### ######.
				 * @param {Object} item ####### ###
				 * @param {String} schemaName ######## ##### ######## ###
				 * @paran {String} errorMessage ######### ## ######
				 */
				openServiceModelModule: function(item, schemaName, errorMessage) {
					if (!item) {
						this.showInformationDialog(errorMessage);
						return;
					}
					var defaultValues = [{
						"id": item.value,
						"schemaName": schemaName,
						"name": item.displayValue
					}];
					this.openCardInChain({
						"schemaName": "ServiceModelPage",
						"moduleId": this.sandbox.id + "_ServiceModelPage",
						"isSeparateMode": false,
						"defaultValues": defaultValues
					});
				},
				/**
				 * ########## ####### ## ######## "########## ########### ## #######".
				 * ### ####### ## ###### "########## ########### ## #######" ########### ######## ########### ###.
				 */
				openServiceModelModuleByServiceItem: function() {
					var serviceItem = this.get("ServiceItem");
					this.openServiceModelModule(serviceItem, "ServiceItem",
						resourses.localizableStrings.ServiceItemErrorMessage);
				},
				/**
				 * ########## ####### ## ######## "########## ########### ## ##".
				 * ### ####### ## ###### "########## ########### ## ##" ########### ######## ########### ###.
				 */
				openServiceModelModuleByConfItem: function() {
					var confItem = this.get("ConfItem");
					this.openServiceModelModule(confItem, "ConfItem",
						resourses.localizableStrings.ConfItemErrorMessage);
				},
				/**
				 * ######### ######## # ###### ######## ## ######## ############## ########.
				 * @overridden
				 */
				getActions: function() {
					var actionMenuItems = this.callParent(arguments);
					actionMenuItems.addItem(this.getButtonMenuItem({
						"Tag": "openServiceModelModuleByServiceItem",
						"Caption": resourses.localizableStrings.OpenServiceModelModuleByServiceItemCaption,
						"Enabled": !this.isNewMode()
					}));
					actionMenuItems.addItem(this.getButtonMenuItem({
						"Tag": "openServiceModelModuleByConfItem",
						"Caption": resourses.localizableStrings.OpenServiceModelModuleByConfItemCaption,
						"Enabled": !this.isNewMode()
					}));
					return actionMenuItems;
				}
			},
			rules: {},
			userCode: {}
		};
	});
