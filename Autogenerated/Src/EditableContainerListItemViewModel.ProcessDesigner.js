define("EditableContainerListItemViewModel", ["ext-base", "BPMSoft"],
	function(Ext, BPMSoft) {
		/**
		 * @class BPMSoft.Designers.EditableContainerListItemViewModel
		 */
		Ext.define("BPMSoft.configuration.EditableContainerListItemViewModel", {
			extend: "BPMSoft.BaseViewModel",
			alternateClassName: "BPMSoft.EditableContainerListItemViewModel",

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
				 * Container list item unique dom id.
				 * @type {String}
				 */
				"DomElementId": {
					dataValueType: BPMSoft.DataValueType.TEXT,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},

				/**
				 * Container list item visibility.
				 * @type {Boolean}
				 */
				"Visible": {
					dataValueType: BPMSoft.DataValueType.BOOLEAN,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},

				/**
				 * Data item marker.
				 * @type {String}
				 */
				"MarkerValue": {
					dataValueType: BPMSoft.DataValueType.TEXT,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				}
			},

			/**
			 * Item caption in modal box.
			 * @type {String}
			 */
			caption: "",

			/**
			 * Element id in modal box.
			 * @type {BPMSoft.DataValueType.GUID}
			 */
			id: null,

			/**
			 * Modal box flag for selection.
			 * @type {Boolean}
			 */
			selected: false,

			/**
			 * Custom user object with params.
			 * @type {Object}
			 */
			persistentObject: null,

			/**
			 * Parent editable container list.
			 * @type {BPMSoft.EditableContainerList}
			 */
			containerList: null,

			/**
			 * Hides or shows item both in modal box and container list.
			 * @param {Boolean} selected Visibility flag.
			 */
			setVisibility: function(selected) {
				this.selected = selected;
				this.set("Visible", selected);
			},

			/**
			 * Sets parent container list.
			 * @param {BPMSoft.EditableContainerList} containerList Parent container list.
			 */
			setContainerList: function(containerList) {
				this.containerList = containerList;
			},

			/**
			 * Sets container list item attributes.
			 * @param {BPMSoft.DataValueType.GUID} id Item id.
			 * @param {String} caption Item caption.
			 * @param {Boolean} selected Indicated is item selected.
			 * @param {Object} persistentObject Custom user object inside container list item. Store any extra needed
			 * info for item here.
			 * @param {String} moduleId Container list module id owner of the item.
			 * @param {BPMSoft.EditableContainerList} containerList Container list owner of the item.
			 */
			setAttributes: function(id, caption, selected, persistentObject, moduleId) {
				var dataItemMarker = caption + moduleId + "Item";
				this.id = id;
				this.caption = caption;
				this.persistentObject = persistentObject;
				var domElementId = id + "-" + moduleId;
				this.set("Caption", caption);
				this.set("DomElementId", domElementId);
				this.setVisibility(selected);
				this.set("MarkerValue", dataItemMarker);
			},

			/**
			 * Hides item from container list items and publish OnRightIconClick message.
			 */
			rightIconClick: function() {
				this.setVisibility(false);
				this.containerList.publishOnActionClick("ClearIcon", this);
				this.containerList.publishOnSelectedItemsChange();
			}
		});
		return BPMSoft.configuration.EditableContainerListItemViewModel;
	}
);
