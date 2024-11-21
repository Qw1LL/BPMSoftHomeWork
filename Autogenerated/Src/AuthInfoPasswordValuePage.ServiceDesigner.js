 define("AuthInfoPasswordValuePage", [], function() {
	return {
		attributes: {
			/**
			 * Name of property in auth info.
			 */
			AuthInfoPropertyName: {
				value: "password"
			}
		},
		methods: {

			/**
			 * @inheritdoc BPMSoft.BaseServiceParameterValuePage#getSysSettingsDataValueTypeFilter
			 * @protected
			 * @override
			 */
			getSysSettingsDataValueTypeFilter: function() {
				return BPMSoft.createColumnInFilterWithParameters("ValueTypeName", ["SecureText"]);
			}

		},
		diff: [
			{
				operation: "merge",
				name: "ValueCaption",
				values: {
					className: "BPMSoft.TipLabel",
					click: "$showTipOnLabelClick",
					tag: "PasswordHintVisible",
					tips: [{
						content: "$Resources.Strings.PasswordHint",
						visible: { bindTo: "PasswordHintVisible" }
					}]
				}
			},
			{
				operation: "merge",
				name: "SysSettingValue",
				"propertyName": "items",
				values: {
					"layout": {
						"column": 0,
						"row": 0,
						"colSpan": 11
					},
					placeholder: "$Resources.Strings.AuthPlaceholder"
				}
			},
			{
				operation: "merge",
				name: "TextValue",
				values: {controlConfig: {protect: true}}
			}
		]
	};
});
