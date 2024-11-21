define("ContentElementBaseViewModel", ["ContentElementBaseViewModelResources", "ContentBuilderConstants",
		"BaseContentItemViewModel"],
	function(resources) {

	Ext.define("BPMSoft.ContentBuilder.ContentElementBaseViewModel", {
		extend: "BPMSoft.BaseContentItemViewModel",
		alternateClassName: "BPMSoft.ContentElementBaseViewModel",

		/**
		 * Array of property names to sanitize.
		 * @protected
		 * @type {String[]}
		 */
		 sanitizedProperties: [],

		/**
		 * @inheritdoc BPMSoft.BaseViewModel#constructor
		 * @overridden
		 */
		constructor: function() {
			this.callParent(arguments);
			this.set("ClassName", this.className);
			this.set("Movable", true);
			this.set("Removable", true);
			this.set("Clonable", true);
			this.initResourcesValues(resources);
		},

		/**
		 * ############## ###### ########## ######## ## ####### ########.
		 * @protected
		 * @virtual
		 * @param {Object} resourcesObj ###### ########.
		 */
		initResourcesValues: function(resourcesObj) {
			var resourcesSuffix = "Resources";
			BPMSoft.each(resourcesObj, function(resourceGroup, resourceGroupName) {
				resourceGroupName = resourceGroupName.replace("localizable", "");
				BPMSoft.each(resourceGroup, function(resourceValue, resourceName) {
					var viewModelResourceName = [resourcesSuffix, resourceGroupName, resourceName].join(".");
					this.set(viewModelResourceName, resourceValue);
				}, this);
			}, this);
		},

		/**
		 * Inits styles with default values.
		 * @protected
		 */
		initDefaultStyles: function() {
			this.$Styles = this.$Styles || {};
			if (_.isUndefined(this.$Styles["padding-left"])) {
				this.$Styles["padding-left"] = "5px";
			}
			if (_.isUndefined(this.$Styles["padding-right"])) {
				this.$Styles["padding-right"] = "5px";
			}
			if (_.isUndefined(this.$Styles["padding-top"])) {
				this.$Styles["padding-top"] = "5px";
			}
			if (_.isUndefined(this.$Styles["padding-bottom"])) {
				this.$Styles["padding-bottom"] = "5px";
			}
		},
		/**
		 * Sanitizes properties.
		 * @protected
		 * @virtual
		 */
		 sanitizeProperties: function() {
			var sanitizedProperties = this.sanitizedProperties;
			sanitizedProperties.forEach(function(property) {
				var propertyValue = this.get(property || "");
				var sanitizedPropertyValue = BPMSoft.utils.html.sanitizeHTML(propertyValue);
				this.set(property, sanitizedPropertyValue)
			}, this);
		},

		/**
		 * ########## ###### ############ ############# ########.
		 * @return {Object} ###### ############ #############.
		 */
		getViewConfig: function() {
			this.initDefaultStyles();
			this.sanitizeProperties();
			return {
				"className": this.className,
				"tag": this.$Id,
				"id": this.$Id,
				"wrapStyle": "$Styles",
				"selected": "$Selected",
				"groupName": [BPMSoft.ContentBuilder.constants.ElementDropGroup]
			};
		},

		/**
		 * Generates configuration object of element tools.
		 * @protected
		 * @return {Array} Configuration object of element tools.
		 */
		getToolsConfig: function() {
			var id = this.$Id;
			return [
				{
					className: "BPMSoft.Button",
					id: id + "-dragg-el",
					style: BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
					markerValue: "move-button",
					imageConfig: "$Resources.Images.ContentMove",
					classes: {wrapperClass: "content-block-move-button"},
					visible: "$Movable"
				}, {
					className: "BPMSoft.Button",
					style: BPMSoft.controls.ButtonEnums.style.ORANGE,
					markerValue: "copy-button",
					imageConfig: "$Resources.Images.ContentCopy",
					classes: {wrapperClass: "content-block-copy-button"},
					click: "$onCopyButtonClick",
					visible: "$Clonable"
				}, {
					className: "BPMSoft.Button",
					style: BPMSoft.controls.ButtonEnums.style.ORANGE,
					markerValue: "remove-button",
					imageConfig: "$Resources.Images.ContentRemove",
					classes: {wrapperClass: "content-block-remove-button"},
					click: "$onRemoveButtonClick",
					visible: "$Removable"
				}
			];
		},

		/**
		 * Handles click of Remove button.
		 * @protected
		 */
		onRemoveButtonClick: function() {
			this.fireEvent("change", this, {
				event: "onremove",
				arguments: {Id: this.$Id}
			});
		},

		/**
		 * Handles click of Copy button.
		 * @protected
		 */
		onCopyButtonClick: function() {
			this.fireEvent("change", this, {
				event: "oncopy",
				arguments: {Id: this.$Id}
			});
		},

		/**
		 * Handler for macrobuttonclicked event.
		 * @protected
		 */
		onMacroButtonClicked: function() {
			this.fireEvent("change", this, {
				event: "macrobuttonclicked",
				arguments: arguments
			});
		},

		/**
		 * Handler for SelectedText change event.
		 * @protected
		 * @virtual
		 */
		onSelectedTextChanged: function() {
			this.fireEvent("change", this, {
				event: "selectedtextchanged",
				deprecatedEvent: "selectedtextсhanged",
				arguments: arguments
			});
		},

	});

});
