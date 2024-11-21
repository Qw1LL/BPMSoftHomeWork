define("ControlGridLayoutEditItemModel", ["GridLayoutEditItemModel"], function() {

	/**
	 * Class of ControlGridLayoutEditItemModel
	 */
	Ext.define("BPMSoft.configuration.ControlGridLayoutEditItemModel", {
		extend: "BPMSoft.configuration.GridLayoutEditItemModel",
		alternateClassName: "BPMSoft.ControlGridLayoutEditItemModel",

		/**
		 * The code for the available drag and drop operations.
		 * @type {Number}
		 */
		dragActionsCode: 511,

		/**
		 * Flag than indicates whether can remove item or not.
		 * @type {Boolean}
		 */
		canRemove: true,

		/**
		 * Flag than indicates whether can edit item or not.
		 * @type {Boolean}
		 */
		canEdit: false,

		// region Methods: Protected

		/**
		 * @inheritdoc BPMSoft.GridLayoutEditItemModel#getImageConfig
		 * @override
		 */
		getImageConfig: function() {
			if (this.itemConfig?.markerValue === 'AngularModule') {
				return this.get("Resources.Images.AngularImage");
			} else {
				return this.get("Resources.Images.ControlImage");
			}
			
		},

		/**
		 * @inheritdoc BPMSoft.GridLayoutEditItemModel#getDragActionCode
		 * @override
		 */
		getDragActionCode: function() {
			return this.dragActionsCode;
		},

		/**
		 * @inheritdoc BPMSoft.GridLayoutEditItemModel#getCaption
		 * @override
		 */
		getCaption: function() {
			return this.itemConfig.name;
		},

		/**
		 * @inheritdoc BPMSoft.GridLayoutEditItemModel#getConfigurationButtonVisible
		 * @override
		 */
		getConfigurationButtonVisible: function() {
			if (this.itemConfig.markerValue === 'AngularModule') {
				return true;
			} else {
				return this.canEdit;
			}
		},

		/**
		 * @inheritdoc BPMSoft.GridLayoutEditItemModel#getConfigurationButtonVisible
		 * @override
		 */
		getRemoveButtonVisible: function() {
			return this.canRemove;
		}

		// endregion

	});

	return BPMSoft.ControlGridLayoutEditItemModel;
});
