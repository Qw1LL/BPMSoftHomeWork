define("TrackingCodeViewModelV2", ["ModalBox"],
	function(ModalBox) {
		Ext.define("BPMSoft.configuration.TrackingCodeViewModel", {
			extend: "BPMSoft.BaseViewModel",
			alternateClassName: "BPMSoft.TrackingCodeViewModel",
			Ext: null,
			sandbox: null,
			BPMSoft: null,
			columns: {
				/**
				 * The text of website js script.
				 */
				"TrackingCode": {
					type: BPMSoft.ViewModelColumnType.ENTITY_COLUMN,
					value: ""
				}
			},

			/**
			 * On render handler.
			 */
			onRender: Ext.emptyFn,

			/**
			 * Close page.
			 */
			close: function() {
				if (ModalBox.getInnerBox()) {
					ModalBox.close(true);
				}
			},

			/**
			 * Cancel button click handler.
			 */
			onCancelButtonClick: function() {
				this.close();
			},

			/**
			 * Initialize text of website js script.
			 */
			initTrackingCodeText: function() {
				this.BPMSoft.SysSettings.querySysSettingsItem("EventTrackingApiKey", function(value) {
					var apiKey = value;
					this.BPMSoft.SysSettings.querySysSettingsItem("EventTrackingCodeTemplate", function(value) {
						this.set("TrackingCode", value.replace("{apiKey}", apiKey));
					}, this);
				}, this);

			},

			/**
			 * Initialize model.
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Execution context.
			 */
			init: function(callback, scope) {
				this.initTrackingCodeText();
				callback.call(scope || this);
			}
		});
	});
