define("AuthInfoUsernameValuePage", [], function() {
	return {
			attributes: {

				/**
				 * Name of property in auth info.
				 */
				AuthInfoPropertyName: {
					value: "username"
				}
			},
			diff: [{
				operation: "merge",
				name: "SysSettingValue",
				"propertyName": "items",
				values: {
					"layout": {
						"column": 0,
						"row": 0,
						"colSpan": 11
					},
					placeholder: "$Resources.Strings.AuthUsernamePlaceholder"
				}
		}]
	};
});
