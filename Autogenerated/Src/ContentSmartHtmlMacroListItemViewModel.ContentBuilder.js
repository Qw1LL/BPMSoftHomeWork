define("ContentSmartHtmlMacroListItemViewModel", ["ContentSmartHtmlMacroListItemViewModelResources",
		"ImageView"], function(resources) {
	/**
	 * @class BPMSoft.configuration.ContentSmartHtmlMacroListItemViewModel
	 */
	Ext.define("BPMSoft.configuration.ContentSmartHtmlMacroListItemViewModel", {
		extend: "BPMSoft.BaseViewModel",
		alternateClassName: "BPMSoft.ContentSmartHtmlMacroListItemViewModel",
		properties: {
			/**
			 * Parent observable container list.
			 * @type {BPMSoft.ObservableContainerList}
			 */
			containerList: null
		},
		attributes: {
			/**
			 * Macro identifier.
			 * @type {Object}
			 */
			"Id": {
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			/**
			 * Macro value.
			 * @type {Object}
			 */
			"Value": {
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			/**
			 * Macro value type.
			 * @type {String}
			 */
			"DataValueType": {
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			/**
			 * Macro name.
			 * @type {String}
			 */
			"Name": {
				dataValueType: BPMSoft.DataValueType.TEXT,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			/**
			 * Macro description.
			 * @type {String}
			 */
			"Description": {
				dataValueType: BPMSoft.DataValueType.TEXT,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			/**
			 * Selected flag for observable collection.
			 */
			"Selected": {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			/**
			 * Macro type logo image config.
			 */
			"TypeLogo": {
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				dataValueType: BPMSoft.DataValueType.CUSTOM_OBJECT
			}
		},

		/**
		 * Prefix for control marker value.
		 * @type {String}
		 */
		markerValuePrefix: "macro-value",

		/**
		 * Pattern for macro.
		 * @type {String}
		 */
		macroPattern: "{{#{0}::{1}#}}",

		/**
		 * @private
		 */
		_getControlMarkerValue: function() {
			return this.markerValuePrefix + "-" + this.$Name;
		},

		/**
		 * @private
		 */
		_getWrapClassName: function() {
			var classes = ["macro-item-container"];
			if (this.$Selected) {
				classes.push("selected");
			}
			return classes;
		},

		/**
		 * @private
		 */
		_getImageUrl: function() {
			return BPMSoft.ImageUrlBuilder.getUrl(this.$TypeLogo);
		},

		/**
		 * @private
		 */
		_getMacroInputConfig: function() {
			return [
				{
					className: "BPMSoft.ImageView",
					imageSrc: "$_getImageUrl",
					canExecute: false,
					classes: {
						wrapClass: ["macro-type-image"]
					}
				},
				{
					className: "BPMSoft.Label",
					caption: "$Name"
				},
				{
					className: "BPMSoft.Button",
					imageConfig: resources.localizableImages.RemoveButtonImage,
					style: BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
					markerValue: this._getControlMarkerValue(),
					classes: {
						"imageClass": ["button-background-no-repeat"],
						"wrapperClass": ["remove-button-wrapClass"]
					},
					click: "$onRemoveButtonClick"
				}
			];
		},

		/**
		 * Handles remove button click. Removes item from container list.
		 * @protected
		 */
		onRemoveButtonClick: function() {
			this.containerList.removeItem(this);
		},

		/**
		 * @public
		 * @returns {String} Macro final string to use.
		 */
		getMacroText: function() {
			return Ext.String.format(this.macroPattern, this.Id || this.$Id, this.$Name || "");
		},

		/**
		 * Returns config of macro value.
		 * @public
		 * @returns {Object} Macro config.
		 */
		getMacroConfig: function() {
			return {
				Id: this.$Id,
				DataValueType: this.$DataValueType,
				Name: this.$Name,
				Value: this.$Value,
				Description: this.$Description
			};
		},

		/**
		 * Sets sandbox for current item and subscribes on its messages.
		 * @public
		 * @param {Object} sandbox Sandbox object.
		 */
		initSandbox: function(sandbox) {
			this.sandbox = sandbox;
		},

		/**
		 * Sets parent container list.
		 * @public
		 * @param {BPMSoft.EditableContainerList} containerList Parent container list.
		 */
		setContainerList: function(containerList) {
			this.containerList = containerList;
		},

		/**
		 * Returns config of current item view.
		 * @public
		 * @returns {Object} View config.
		 */
		getViewConfig: function() {
			return {
				id: this.$Id,
				className: "BPMSoft.Container",
				classes: {
					wrapClassName: this._getWrapClassName()
				},
				items: [
					{
						className: "BPMSoft.Container",
						classes: {
							wrapClassName: ["macro-input-container"]
						},
						items: this._getMacroInputConfig()
					}
				]
			};
		}
	});
	return BPMSoft.ContentSmartHtmlMacroListItemViewModel;
});
