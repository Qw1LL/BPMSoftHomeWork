define("Mood", [], function() {
	Ext.define("BPMSoft.controls.Mood", {
		extend: "BPMSoft.Container",
		alternateClassName: "BPMSoft.Mood",

		init: function() {
			this.callParent(arguments);
			this.addEvents(
				/**
				 * @event
				 * ####### ####### ## ####### ########### ########.
				 */
				'click'
			);
		},
		onClick: function(e) {
			e.stopEvent();
			this.fireEvent("click", this, null);
		},
		render: function() {

		}
	});
	return BPMSoft.Mood;
});
