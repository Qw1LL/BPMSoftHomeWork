define("UsrRequestNumberEditControl", function (sandbox) {
    /*
     * @class BPMSoft.controls.UsrRequestNumberEditControl
     * Single-line control class based on text edit control.
     */
    Ext.define("BPMSoft.controls.UsrRequestNumberEditControl", {
        extend: "BPMSoft.TextEdit",
        alternateClassName: "BPMSoft.UsrRequestNumberEditControl",

        onKeyPress: function (e) {
            const fieldValue = this.getTypedValue();
            const regexStr = /^[0-9-]+$/;
            if (!regexStr.test(e.browserEvent.key)) {
                e.preventDefault();
                return;
            }
        },

        onKeyUp: function (e) {
            
        }
    });
});