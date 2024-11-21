define("UserProfilePage", [],
	function() {
		return {
			methods: {
				//region Methods: Protected

				/**
				 * @inheritdoc BPMSoft.UserProfilePage#getSysCultureDisplayValue
				 * @overridden
				 */
				getSysCultureDisplayValue: function(item) {
					var language = item.get("Language");
					return language.displayValue;
				},

				/**
				 * @inheritdoc BPMSoft.UserProfilePage#initSysAdminUnitQueryColumns
				 * @overridden
				 */
				initSysAdminUnitQueryColumns: function(esq) {
					this.callParent(arguments);
					esq.addColumn("[SysCulture:Id:SysCulture].Language", "Language");
				},

				//endregion

				//region Methods: Public

				/**
				 * @inheritdoc BPMSoft.UserProfilePage#initSysCultureQueryFilters
				 * @overridden
				 */
				initSysCultureQueryFilters: function(esq) {
					this.callParent(arguments);
					esq.filters.add("ActiveLanguageFilter", this.BPMSoft.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.EQUAL, "Active", true));
				},

				/**
				 * @inheritdoc BPMSoft.UserProfilePage#initSysCultureQueryColumns
				 * @overridden
				 */
				initSysCultureQueryColumns: function(esq) {
					this.callParent(arguments);
					esq.addColumn("Language");
				}

				//endregion
			}
		};
	}
);
