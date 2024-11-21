define("EmailHelperModule",
	function() {
		var SegmentsStatusUtilsClass = Ext.define("BPMSoft.configuration.EmailHelperModule", {

			alternateClassName: "BPMSoft.EmailHelperModule",

			/*
			 * Validates email address.
			 * @param email (String) email Email address to validate.
			 * @return (Boolean) Returns true, if email address is valid, otherwise false.
			 */
			isEmailValid: function(email) {
				var emailRE = /(^(([^<>()\[\]\.,;:\s@\"]+(\.[^<>()\[\]\.,;:\s@\"]+)*)|(\".+\"))@(([^#<>()[\]\.,;:\s@\"]+\.)+[^-#<>()[\]\.,;:\s@\"]+)$)/;
				return (Ext.isEmpty(email) || emailRE.test(email));
			}
		});

		return Ext.create(SegmentsStatusUtilsClass);
	});
