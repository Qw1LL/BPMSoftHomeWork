define("BaseDashboardItemViewModel", ["BaseDashboardItemViewModelResources", "MaskHelper", "MiniPageUtilities"],
	function(resources, MaskHelper) {
		Ext.define("BPMSoft.configuration.BaseDashboardItemViewModel", {
			extend: "BPMSoft.BaseViewModel",
			alternateClassName: "BPMSoft.BaseDashboardItemViewModel",

			Ext: null,
			sandbox: null,
			BPMSoft: null,

			mixins: {

				/**
				 * @class MiniPageUtilities Mixin, used for open Mini Pages
				 */
				MiniPageUtilitiesMixin: "BPMSoft.MiniPageUtilities"
			},

			columns: {

				/**
				 * The text of the header caption.
				 */
				"Caption": {
					type: BPMSoft.ViewModelColumnType.ENTITY_COLUMN,
					dataValueType: BPMSoft.DataValueType.TEXT
				},

				/**
				 * The text of the "Execute" button caption.
				 */
				"ExecuteButtonCaption": {
					type: BPMSoft.ViewModelColumnType.ENTITY_COLUMN,
					dataValueType: BPMSoft.DataValueType.TEXT
				},

				/**
				 * The text of the "Cancel" button caption.
				 */
				"CancelButtonCaption": {
					type: BPMSoft.ViewModelColumnType.ENTITY_COLUMN,
					dataValueType: BPMSoft.DataValueType.TEXT
				},

				/**
				 * Indicates state of the Visible parameter of "ExecuteButton.
				 */
				"ExecuteButtonVisible": {
					type: BPMSoft.ViewModelColumnType.ENTITY_COLUMN,
					dataValueType: BPMSoft.DataValueType.BOOLEAN
				},

				/**
				 * Indicates state of the Visible parameter of "CancelButton.
				 */
				"CancelButtonVisible": {
					type: BPMSoft.ViewModelColumnType.ENTITY_COLUMN,
					dataValueType: BPMSoft.DataValueType.BOOLEAN
				},

				/**
				 * Date of the item.
				 */
				"Date": {
					type: BPMSoft.ViewModelColumnType.ENTITY_COLUMN,
					dataValueType: BPMSoft.DataValueType.DATE_TIME
				},

				/**
				 * Text representation of the Date.
				 */
				"DateText": {
					type: BPMSoft.ViewModelColumnType.ENTITY_COLUMN,
					dataValueType: BPMSoft.DataValueType.TEXT
				},

				/**
				 * Owner of the item.
				 */
				"Owner": {
					type: BPMSoft.ViewModelColumnType.ENTITY_COLUMN,
					dataValueType: BPMSoft.DataValueType.LOOKUP
				},

				/**
				 * Url on the icon.
				 */
				"IconSrc": {
					type: BPMSoft.ViewModelColumnType.ENTITY_COLUMN,
					dataValueType: BPMSoft.DataValueType.CUSTOM_OBJECT
				},

				/**
				 * Process element execution data.
				 */
				"ExecutionData": {
					type: BPMSoft.ViewModelColumnType.ENTITY_COLUMN,
					dataValueType: BPMSoft.DataValueType.CUSTOM_OBJECT
				},

				/**
				 * Process element required step flag.
				 */
				"IsRequired": {
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					dataValueType: BPMSoft.DataValueType.BOOLEAN,
					value: true
				},

				/**
				 * Name of the role.
				 */
				"RoleName": {
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					dataValueType: BPMSoft.DataValueType.TEXT
				}
			},

			/**
			 * Executes item.
			 */
			execute: Ext.emptyFn,

			/**
			 * Cancel item execution.
			 */
			cancel: Ext.emptyFn,

			/**
			 * On render handler.
			 */
			onRender: Ext.emptyFn,

			/**
			 * Caption click handler.
			 */
			onCaptionClick: function() {
				this.execute();
			},

			/**
			 * Execute button click handler.
			 */
			onExecuteButtonClick: function() {
				this.execute();
			},

			/**
			 * Returns name of the owner.
			 */
			getOwnerName: function() {
				const owner = this.get("Owner");
				const roleName = this.get("RoleName");
				return owner || roleName;
			},

			/**
			 * Shows MiniPage.
			 * @protected
			 * @param {Object} [config] Config for opening MiniPage.
			 * @return {Object} MiniPage config.
			 */
			showMiniPage: function(config) {
				const id = this.get("Id");
				const miniPageConfig = {
					recordId: id,
					columnName: "Id",
					isFixed: true,
					targetId: this.getContainerId(id),
					entitySchemaName: this.get("EntitySchemaName"),
					showDelay: 0
				};
				if (config) {
					this.Ext.apply(miniPageConfig, config);
				}
				this.openMiniPage(miniPageConfig);
				return miniPageConfig;
			},

			/**
			 * Returns container id.
			 * @private
			 * @param {String} id Entity id.
			 * @return {String} Container id.
			 */
			getContainerId: function(id) {
				return "ItemContainer-" + id + "-View";
			},

			/**
			 * Cancel button click handler.
			 */
			onCancelButtonClick: function() {
				this.cancel();
			},

			/**
			 * @inheritdoc BPMSoft.BaseObject#constructor
			 * @overridden
			 */
			constructor: function() {
				this.callParent(arguments);
				this.bindDependencies();
			},

			/**
			 * Initialize ViewModel.
			 */
			init: function() {
				this.initializeProperties();
			},

			/**
			 * Initialize ViewModel properties.
			 */
			initializeProperties: function() {
				this.initIconSrc();
				this.initCancelButtonCaption();
				this.initExecuteButtonCaption();
				this.initCancelButtonVisibility();
				this.initExecuteButtonVisibility();
			},

			/**
			 * Initializes "IconSrc" property.
			 */
			initIconSrc: Ext.emptyFn,

			/**
			 * Initializes "CancelButtonCaption" property.
			 */
			initCancelButtonCaption: function() {
				this.set("CancelButtonCaption", resources.localizableStrings.CancelButtonCaption);
			},

			/**
			 * Initializes "ExecuteButtonCaption" property.
			 */
			initExecuteButtonCaption: function() {
				this.set("ExecuteButtonCaption", resources.localizableStrings.ExecuteButtonCaption);
			},

			/**
			 * Initializes "CancelButtonVisible" property.
			 */
			initCancelButtonVisibility: function() {
				this.set("CancelButtonVisible", false);
			},

			/**
			 * Initializes "ExecuteButtonVisible" property.
			 */
			initExecuteButtonVisibility: function() {
				this.set("ExecuteButtonVisible", true);
			},

			/**
			 * Returns uri of the icon.
			 * @return {String}
			 */
			getIconSrc: function() {
				const src = this.get("IconSrc");
				if (!Ext.isEmpty(src)) {
					return BPMSoft.ImageUrlBuilder.getUrl(src);
				}
			},

			/**
			 * Returns config of the column dependencies.
			 * @return {Object} Config.
			 */
			getColumnsDependenciesConfig: function() {
				return {
					"DateText": [{
						columns: ["Date"],
						methodName: "onDateChanged"
					}]
				};
			},

			/**
			 * Bind column dependencies.
			 */
			bindDependencies: function() {
				const config = this.getColumnsDependenciesConfig();
				BPMSoft.each(config, function(dependencies) {
					BPMSoft.each(dependencies, function(dependency) {
						BPMSoft.each(dependency.columns, function(column) {
							const method = this[dependency.methodName];
							this.on("change:" + column, method.bind(this, column));
						}, this);
					}, this);
				}, this);
			},

			/**
			 * Handles "change" event of the "Date" column.
			 */
			onDateChanged: function() {
				const date = this.get("Date");
				if (date) {
					const dateText = Ext.Date.format(date, BPMSoft.Resources.CultureSettings.dateFormat);
					this.set("DateText", dateText);
				}
			},

			/**
			 * Displays the mask.
			 * @protected
			 * @param {Object} config Config of the mask.
			 */
			showBodyMask: function(config) {
				MaskHelper.ShowBodyMask(config);
			},

			/**
			 * Hides mask.
			 * protected
			 * @param {Object} config Config of the mask.
			 */
			hideBodyMask: function(config) {
				MaskHelper.HideBodyMask(config);
			},

			/**
			 * Returns value of the column.
			 * @param {String} columnName Name of the column.
			 * @return {*} Value.
			 */
			getLookupColumnValue: function(columnName) {
				var columnValue = this.get(columnName);
				return columnValue && columnValue.value;
			},

			/**
			 * Returns item process element identifier.
			 * @virtual
			 * @return {String}
			 */
			getProcessElementUId: BPMSoft.emptyFn,

			/**
			 * Set view model process execution data.
			 * @virtual
			 * @param {Object} data Process element execution data.
			 */
			setExecutionData: function(data) {
				this.set("ExecutionData", data);
			}
		});
	});
