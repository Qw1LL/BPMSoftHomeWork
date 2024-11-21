define("SspReadOnlyModeModule", ["SspReadOnlyModeModuleResources", "BaseViewModule", "css!SspReadOnlyModeModuleCSS"],
	function(resources) {
		Ext.define("BPMSoft.configuration.SspReadOnlyModeModule", {

			extend: "BPMSoft.BaseViewModule",
			alternateClassName: "BPMSoft.SspReadOnlyModeModule",

			/**
			 * Handler for read only button click.
			 * @public
			 */
			onReadOnlyButtonClick: BPMSoft.emptyFn,

			/**
			 * Provides configuration object for read only button and it's container.
			 * @private
			 * @return {Object} Configuration object for read only button container.
			 */
			_getReadOnlyButtonView: function() {
				var sspReadOnlyButton = Ext.create("BPMSoft.Button", {
					"caption": resources.localizableStrings.ReadOnlyButtonCaption,
					"style": BPMSoft.controls.ButtonEnums.style.ORANGE,
					"classes": {
						"textClass": ["read-only-button"]
					},
					"click": {"bindTo": "onReadOnlyButtonClick"},
					"markerValue": "readOnlyButton"
				});
				var sspReadOnlyButtonContainer = Ext.create("BPMSoft.Container", {
					"items": [sspReadOnlyButton],
					"classes": {
						"wrapClassName": ["read-only-button-container"]
					}
				});
				return sspReadOnlyButtonContainer;
			},

			/**
			 * @inheritDoc BPMSoft.configuration.BaseViewModule#init
			 * @override
			 */
			init: function() {
				var sspReadOnlyButtonContainer = this._getReadOnlyButtonView();
				sspReadOnlyButtonContainer.bind(this);
				var container = Ext.get(this.renderToId);
				sspReadOnlyButtonContainer.render(container);
			}

		});
		return BPMSoft.SspReadOnlyModeModule;
	});
