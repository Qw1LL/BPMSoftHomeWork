define("CaseMessageHistoryUtility", ["EmailMessageConstants", "BaseMessageHistoryUtility"],
	function(EmailMessageConstants) {
		/**
		 * @class BPMSoft.configuration.mixins.CaseMessageHistoryUtility
		 * Mixin, that implements work case message history.
		 */
		Ext.define("BPMSoft.configuration.mixins.CaseMessageHistoryUtility", {
			extend: "BPMSoft.BaseMessageHistoryUtility",
			alternateClassName: "BPMSoft.CaseMessageHistoryUtility",

			/**
			 * @inheritdoc BPMSoft.BaseMessageHistoryUtility#addFiltersToMessageHistoryExistsEsq
			 * @overridden
			 */
			addFiltersToMessageHistoryExistsEsq: function(esq) {
				this.callParent(arguments);
				var filterGroup = esq.createFilterGroup();
				filterGroup.name = "EmailSystemMessages";
				filterGroup.logicalOperation = this.BPMSoft.LogicalOperatorType.OR;
				filterGroup.add("IsAutoSubmitted", esq.createColumnFilterWithParameter(
					this.BPMSoft.ComparisonType.EQUAL, "[Activity:Id:RecordId].IsAutoSubmitted",
					true));
				filterGroup.add("NotEmailNotifier", esq.createColumnFilterWithParameter(
					this.BPMSoft.ComparisonType.NOT_EQUAL, "MessageNotifier",
					EmailMessageConstants.MessageNotifier.Email));
				esq.filters.addItem(filterGroup);
			}
		});
	});
