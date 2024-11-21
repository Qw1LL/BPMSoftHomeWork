define("MultipleEmailInput", ["MultipleInput"], function() {
	Ext.define("BPMSoft.controls.MultipleEmailInput", {
		extend: "BPMSoft.MultipleInput",
		alternateClassName: "BPMSoft.MultipleEmailInput",

		/**
		 * @inheritdoc BPMSoft.MultipleInput#inputWrapElFocused.
		 * @override
		 */
		inputWrapElFocused: "base-edit-focus",

		/**
		 * @inheritdoc BPMSoft.Component#initDomEvents
		 * @override
		 */
		initDomEvents: function() {
			this.callParent(arguments);
			this.inputEl.on("keydown", this.onInputElKeyDown, this);
		},

		/**
		 * @inheritdoc BPMSoft.Component#clearDomListeners
		 * @override
		 */
		clearDomListeners: function() {
			this.inputEl.un("keydown", this.onInputElKeyDown, this);
			this.callParent(arguments);
		},

		/**
		 * The "key pressed" event handler in the input field of the control.
		 * @protected
		 */
		onInputElKeyDown: function(e) {
			var key = e.getKey();
			if (key === e.ESC) {
				e.preventDefault();
				e.stopPropagation();
				this.inputEl.dom.value = "";
				this.inputEl.dom.blur();
			}
		},

		/**
		 * @inheritdoc BPMSoft.MultipleInput#onInputElBlur.
		 * @override
		 */
		onInputElBlur: function(e) {
			e.preventDefault();
			e.stopPropagation();
			this.callParent(arguments);
		}
	});
});
