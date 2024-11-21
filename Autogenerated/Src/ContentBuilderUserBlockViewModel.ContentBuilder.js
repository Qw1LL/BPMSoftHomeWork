define("ContentBuilderUserBlockViewModel", ["ContentBuilderUserBlockViewModelResources",
		"ContentBuilderElementViewModel"],
function(resources) {

	/**
	 * @class BPMSoft.controls.ContentBuilderUserBlockViewModel
	 */
	Ext.define("BPMSoft.controls.ContentBuilderUserBlockViewModel", {
		extend: "BPMSoft.ContentBuilderElementViewModel",
		alternateClassName: "BPMSoft.ContentBuilderUserBlockViewModel",

		columns: {
			"Id": {
				value: BPMSoft.emptyString
			},
			"ClassName": {
				value: "BPMSoft.ContentBuilderUserBlock"
			},
			"ItemType": {
				value: "userblock"
			},
			"Caption": {
				value: resources.localizableStrings.Caption
			},
			"Icon": {
				value: {
					source: BPMSoft.ImageSources.URL,
					url: null
				}
			},
			"BlockConfig": {
				value: BPMSoft.emptyFn
			},
			"GroupName": {
				value: ["ContentBlank"]
			}
		},

		/**
		 * @inheritdoc BPMSoft.BaseViewModel#constructor
		 * @override
		 */
		constructor: function() {
			this.callParent(arguments);
			this.addEvents(
				/**
				 * @event
				 * The event generated when you click on the content user block delete icon.
				 */
				"deleteiconclick"
			);
		},

		/**
		 * Handles on user block icon delete event.
		 * @protected
		 */
		onUserBlockDeleteIconClick: function() {
			this.fireEvent("deleteiconclick", this);
		}
	});
});
