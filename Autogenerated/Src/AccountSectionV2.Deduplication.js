define("AccountSectionV2", [], function() {
		return {
			methods: {
				/**
				 * @inheritdoc BaseDataView#setCanSearchDuplicatesAttributes
				 * @override
				 */
				setCanSearchDuplicatesAttributes: function(canSearchDuplicatesOperation) {
					this.callParent(arguments);
					this.set("DeduplicationEnabled", this.getIsDeduplicationEnable());
					const isEnabled = canSearchDuplicatesOperation && this.$DeduplicationEnabled;
					this.set("canSearchDuplicates", this.$canSearchDuplicates || isEnabled);
				}
			}
		};
	}
);
