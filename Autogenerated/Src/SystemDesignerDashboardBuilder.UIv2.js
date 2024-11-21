define("SystemDesignerDashboardBuilder", ["ext-base", "SystemDesignerDashboardBuilderResources", "DashboardBuilder"],
	function(Ext) {
		/**
		 * @class BPMSoft.configuration.SystemDesignerDashboardViewsConfig
		 * ##### ############ ############ ############# ###### ###### ### ####### ######### #######.
		 */
		Ext.define("BPMSoft.configuration.SystemDesignerDashboardsViewConfig", {
			extend: "BPMSoft.BaseObject",
			alternateClassName: "BPMSoft.SystemDesignerDashboardsViewConfig",

			/**
			 * ########## ############ ############# ###### ###### ### ####### ######### #######.
			 * @return {Object[]} ########## ############ ############# ###### ######.
			 */
			generate: function() {
				return [{
					"name": "SettingsButton",
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"style": BPMSoft.controls.ButtonEnums.style.DEFAULT,
					"caption": { "bindTo": "Resources.Strings.ActionsButtonCaption" },
					"markerValue": "SettingsButton",
					"visible": { "bindTo": "EditMode" },
					"menu": {
						items: [{
							"caption": { "bindTo": "Resources.Strings.EditButtonCaption" },
							"click": { "bindTo": "editCurrentDashboard" },
							"markerValue": "SettingsButtonEdit",
							"enabled": { "bindTo": "canEdit" }
						}, {
							"caption": { "bindTo": "Resources.Strings.RightsButtonCaption" },
							"click": { "bindTo": "manageCurrentDashboardRights" },
							"markerValue": "ManageRights",
							"enabled": { "bindTo": "canManageRights" }
						}]
					}
				}, {
					"name": "DashboardModule",
					"itemType": BPMSoft.ViewItemType.CONTAINER
				}];
			}
		});

		/**
		 * @class BPMSoft.configuration.SystemDesignerDashboardBuilder
		 * ##### ###### ############# ###### ###### ### ####### ######### #######.
		 */
		return Ext.define("BPMSoft.configuration.SystemDesignerDashboardBuilder", {
			extend: "BPMSoft.DashboardBuilder",
			alternateClassName: "BPMSoft.SystemDesignerDashboardBuilder",

			Ext: null,
			sandbox: null,
			BPMSoft: null,

			/**
			 * ### ####### ###### ############# ### ###### ###### ### ####### ######### #######.
			 * @type {String}
			 */
			viewModelClass: "BPMSoft.SystemDesignerDashboardsViewModel",

			/**
			 * ### ######## ##### ########## ############ ############# ###### ### ####### ######### #######.
			 * @type {String}
			 */
			viewConfigClass: "BPMSoft.SystemDesignerDashboardsViewConfig"
		});
	});
