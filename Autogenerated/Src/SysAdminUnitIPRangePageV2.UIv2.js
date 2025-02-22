﻿define("SysAdminUnitIPRangePageV2", ["SysAdminUnitIPRange"],
	function() {
		var IPV4_REGEX_PATTERN = "^(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.";
		IPV4_REGEX_PATTERN += "(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.";
		IPV4_REGEX_PATTERN += "(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.";
		IPV4_REGEX_PATTERN += "(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$";
		var IPV6_REGEX_PATTERN = "((^|:)([0-9a-fA-F]{0,4})){1,8}$";
		return {
			entitySchemaName: "SysAdminUnitIPRange",
			methods: {
				/**
				 * ######### ############ ###### ######### IPv4.
				 * @param {String} value
				 * @return {Boolean} ########## ########## ######### ######### ####.
				 */
				validateIPv4: function(value) {
					var expr = new RegExp(IPV4_REGEX_PATTERN);
					var isValid = expr.test(value);
					if (isValid) {
						this.set("IPVersion", 4);
					}
					return isValid;
				},

				/**
				 * ######### ############ ###### ######### IPv6.
				 * @param {String} value
				 * @return {Boolean} ########## ########## ######### ######### ####.
				 */
				validateIPv6: function(value) {
					var expr = new RegExp(IPV6_REGEX_PATTERN);
					var isValid = expr.test(value);
					if (isValid) {
						this.set("IPVersion", 6);
					}
					return isValid;
				},

				/**
				 * ######### ############ #### ### ##########.
				 * @param {String} value
				 * @return {Object} ########## ###### # ######## ###### ######### ####.
				 */
				validateIPField: function(value) {
					var message = "";
					if (!value) {
						message = this.get("Resources.Strings.RequiredFieldIsEmptyMessage");
					} else {
						switch (this.get("IPVersion")) {
							case 4:
								if (!this.validateIPv4(value)) {
									message = this.get("Resources.Strings.NotMatchIPv4StructureMessage");
								}
								break;
							case 6:
								if (!this.validateIPv6(value)) {
									message = this.get("Resources.Strings.NotMatchIPv6StructureMessage");
								}
								break;
							default:
								if (!this.validateIPv4(value) && !this.validateIPv6(value)) {
									message = this.get("Resources.Strings.NotMatchIPStructureMessage");
								}
								break;
						}
					}
					return {invalidMessage: message};
				},

				/**
				 * @protected
				 * @inheritdoc BasePageV2#setValidationConfig.
				 * @overridden
				 */
				setValidationConfig: function() {
					this.callParent(arguments);
					this.addColumnValidator("BeginIP", this.validateIPField);
					this.addColumnValidator("EndIP", this.validateIPField);
				},

				/**
				 * ######### ######### ##### ########## # ######### IP ###### # #########.
				 * @protected
				 * @inheritdoc BasePageV2#initEntity
				 * @overridden
				 */
				initEntity: function() {
					this.setValidationConfig();
					this.callParent(arguments);
				}
			},
			rules: {
			}
		};
	});
