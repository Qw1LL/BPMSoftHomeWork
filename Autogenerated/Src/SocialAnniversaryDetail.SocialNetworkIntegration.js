define("SocialAnniversaryDetail", ["ConfigurationGrid", "ConfigurationGridGenerator", "ConfigurationGridUtilities",
		"SocialGridDetailUtilities"], function() {
	return {
		messages: {
			/**
			 * ######### # ############# ######### ###### ## ########## #####.
			 */
			"GetSocialNetworkData": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			},

			/**
			 * ########## ## ######### ######## ###### ## ########## #####.
			 */
			"SocialNetworkDataLoaded": {
				mode: BPMSoft.MessageMode.BROADCAST,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			},

			/**
			 * @message SaveDetail
			 * ########## ########## ######.
			 */
			"SaveDetail": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			},

			/**
			 * @message DetailValidated
			 * ########## ######### ##########.
			 */
			"DetailSaved": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			},

			/**
			 * @message ValidateDetail
			 * ########## ############# ############### ######## ######.
			 */
			"ValidateDetail": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			},

			/**
			 * @message DetailValidated
			 * ########## ######### ######### ######.
			 */
			"DetailValidated": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			}
		},
		/**
		 * ######-####### (#######), ########### ################ ####### #####.
		 */
		mixins: {
			/**
			 * @class ConfigurationGridUtilities ########### ####### ###### ############## #######.
			 */
			ConfigurationGridUtilities: "BPMSoft.ConfigurationGridUtilities",

			/**
			 * @class SocialGridDetailUtilities ########### ####### ###### ###### ########## ## ###. ####.
			 * # ############# ########.
			 */
			SocialGridDetailUtilities: "BPMSoft.SocialGridDetailUtilities"
		},
		attributes: {
			/*
			 * ####### ######### ############## #######.
			 */
			IsEditable: {
				dataValueType: this.BPMSoft.DataValueType.BOOLEAN,
				type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				value: true
			},

			/*
			 * ####### ######### ############## ######.
			 */
			MultiSelect: {
				dataValueType: this.BPMSoft.DataValueType.BOOLEAN,
				type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				value: true
			},
			UseGeneratedProfile: {
				value: false
			}
		},
		methods: {

			/**
			 * @inheritdoc BPMSoft.BaseDetailV2#subscribeSandboxEvents
			 * @override
			 */
			subscribeSandboxEvents: function() {
				this.callParent(arguments);
				this.sandbox.subscribe("SaveDetail", this.save, this, [this.sandbox.id]);
				this.sandbox.subscribe("ValidateDetail", this.validateDetail, this, [this.sandbox.id]);
			},

			/**
			 * @inheritdoc BPMSoft.BaseAnniversaryDetailV2#init
			 * @overridden
			 */
			init: function() {
				this.callParent(arguments);
				this.initSocialDetail();
			},

			/**
			 * @inheritdoc BPMSoft.BaseDetailV2#getToolsVisible
			 * @overridden
			 */
			getToolsVisible: function() {
				return false;
			},

			/**
			 * @inheritdoc BPMSoft.ConfigurationGridUtilities#getIsRowChanged
			 * @overridden
			 */
			getIsRowChanged: function() {
				return false;
			},

			/**
			 * @inheritdoc BPMSoft.GridUtilities#onGridDataLoaded
			 * @overridden
			 */
			onGridDataLoaded: function() {
				this.callParent(arguments);
				var socialNetworkData = this.sandbox.publish("GetSocialNetworkData");
				if (!socialNetworkData) {
					this.sandbox.subscribe("SocialNetworkDataLoaded", this.onSocialNetworkDataLoaded, this);
				} else {
					this.onSocialNetworkDataLoaded(socialNetworkData);
				}
			},

			/**
			 * @inheritdoc BPMSoft.BaseDetailV2#initData
			 * @override
			 */
			initData: function(callback, scope) {
				this.callParent([function() {
					Ext.callback(callback, scope || this);
					this.setSelectedRows();
				}, this]);
			},

			/**
			 * @inheritdoc BPMSoft.GridUtilities#onAfterRender
			 * @override
			 */
			onAfterReRender: function() {
				this.callParent(arguments);
				this.setSelectedRows();
			},

			/**
			 * Selects all loaded rows when MultiSelect is true and grid rendered.
			 * @protected
			 */
			setSelectedRows: function() {
				if (this.get("MultiSelect") && this.getIsCurrentGridRendered()) {
					var items = this.getGridData();
					this.selectRows(items);
				}
			},

			/**
			 * @inheritdoc BPMSoft.BaseGridDetailV2#initDetailOptions
			 * @overridden
			 */
			initDetailOptions: function() {
				this.callParent(arguments);
				this.set("IsDetailCollapsed", false);
			},

			/**
			 * @inheritdoc BPMSoft.ConfigurationGridUtilities#initActiveRowKeyMap
			 * @overridden
			 */
			initActiveRowKeyMap: BPMSoft.emptyFn

		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "merge",
				"name": "DataGrid",
				"values": {
					"className": "BPMSoft.ConfigurationGrid",
					"generator": "ConfigurationGridGenerator.generatePartial",
					"generateControlsConfig": {bindTo: "generateActiveRowControlsConfig"},
					"changeRow": {bindTo: "changeRow"},
					"unSelectRow": {bindTo: "unSelectRow"},
					"onGridClick": {bindTo: "onGridClick"},
					"initActiveRowKeyMap": {bindTo: "initActiveRowKeyMap"},
					"activeRowAction": {bindTo: "onActiveRowAction"},
					"activeRowActions": [],
					"rowDataItemMarkerColumnName": "Date"
				}
			},
			{
				"operation": "insert",
				"name": "DataGridActiveRowSaveAction",
				"parentName": "DataGrid",
				"propertyName": "activeRowActions",
				"values": {
					"className": "BPMSoft.Button",
					"tag": "save",
					"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
					"markerValue": "save",
					"imageConfig": {"bindTo": "Resources.Images.SaveIcon"}
				}
			}
		]/**SCHEMA_DIFF*/
	};
});
