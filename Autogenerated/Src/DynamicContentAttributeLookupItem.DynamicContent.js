/**
 * View model for DCAttribute lookup item.
 */
define("DynamicContentAttributeLookupItem", ["DynamicContentAttributeLookupItemResources"],
	function() {
		/**
		 * @class BPMSoft.configuration.DynamicContentAttributeLookupItem
		 */
		Ext.define("BPMSoft.configuration.DynamicContentAttributeLookupItem", {
			extend: "BPMSoft.BaseViewModel",
			alternateClassName: "BPMSoft.DynamicContentAttributeLookupItem",

			attributes: {
				/**
				 * Container list item caption.
				 * @type {String}
				 */
				"Caption": {
					dataValueType: BPMSoft.DataValueType.TEXT,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},

				/**
				 * Index of binded DCAttribute model.
				 * @type {Number}
				 */
				"Index": {
					dataValueType: BPMSoft.DataValueType.INTEGER,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},

				/**
				 * State of current attribute lookup item.
				 * @type {Boolean}
				 */
				"Selected": {
					dataValueType: BPMSoft.DataValueType.BOOLEAN,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				}
			},

			/**
			 * Parent observable container list.
			 * @type {BPMSoft.ObservableContainerList}
			 */
			containerList: null,

			// #region Methods: Public

			/**
			 * Sets parent container list.
			 * @public
			 * @param {BPMSoft.EditableContainerList} containerList Parent container list.
			 */
			setContainerList: function(containerList) {
				this.containerList = containerList;
			},

			/**
			 * Sets property values by source DCAttribute item object.
			 * @public
			 * @param {Object} item DCAttribute object.
			 */
			init: function(item) {
				this.set("Caption", item.Caption);
				this.set("Index", item.Index);
				this.set("Selected", false);
			},

			/**
			 * Sets current selected state for item.
			 * @public
			 * @param {Boolean} selected Selected state.
			 */
			setSelected: function(selected) {
				this.$Selected = selected;
			},

			/**
			 * Returns class names of wrap container.
			 * @protected
			 * @returns {Array} Class names of wrap container.
			 */
			getWrapClassNames: function() {
				var classes = ["attribute-lookup-item-container"];
				if (this.$Selected) {
					classes.push("selected");
				}
				return classes;
			},

			/**
			 * Returns config of current item view.
			 * @public
			 * @returns {Object} View config.
			 */
			getViewConfig: function() {
				var id = BPMSoft.Component.generateId();
				return {
					className: "BPMSoft.Container",
					classes: {
						wrapClassName: this.getWrapClassNames()
					},
					items: [
						{
							inputId: id,
							className: "BPMSoft.Label",
							caption: "$Caption"
						}
					]
				};
			}

			// #endregion

		});
		return BPMSoft.configuration.DynamicContentAttributeLookupItem;
	}
);
