define("ServiceRecepientsDetail", [],
	function() {
		return {
			entitySchemaName: "VwServiceRecepients",
			methods: {

				/**
				 * @inheritdoc BPMSoft.BaseGridDetailV2#getDeleteRecordMenuItem
				 * @overridden
				 */
				getDeleteRecordMenuItem: this.BPMSoft.emptyFn,

				/**
				 * @inheritdoc BPMSoft.BaseGridDetailV2#getCopyRecordMenuItem
				 * @overridden
				 */
				getCopyRecordMenuItem: this.BPMSoft.emptyFn,

				/**
				 * @inheritdoc BPMSoft.BaseGridDetailV2#getEditRecordMenuItem
				 * @overridden
				 */
				getEditRecordMenuItem: this.BPMSoft.emptyFn,

				/**
				 * @inheritDoc BPMSoft.BaseGridDetailV2#initDefaultCaption
				 * @override
				 */
				initDefaultCaption: function() {
					if (this.BPMSoft.isCurrentUserSsp()) {
						this.set("Caption", this.get("Resources.Strings.ActiveServices"));
					} else {
						this.callParent(arguments);
					}
				},

				/**
				 * @inheritDoc BPMSoft.BaseGridDetailV2#getFilters
				 * @override
				 */
				getFilters: function() {
					const filters = this.callParent(arguments);
					if (this.BPMSoft.isCurrentUserSsp()) {
						const filterGroup = new BPMSoft.createFilterGroup();
						filterGroup.add("Active", this.BPMSoft.createColumnFilterWithParameter(
							this.BPMSoft.ComparisonType.EQUAL, "Service.Status.Active", true)
						);
						filterGroup.add("ActiveServicePact", this.BPMSoft.createColumnFilterWithParameter(
							this.BPMSoft.ComparisonType.EQUAL, "ServicePact.Status.IsActive", true)
						);
						filterGroup.add("EndDateServicePact", this.BPMSoft.createColumnFilterWithParameter(
							this.BPMSoft.ComparisonType.GREATER_OR_EQUAL,
							"ServicePact.EndDate", this.BPMSoft.endOfDay(new Date()))
						);
						filters.add(filterGroup);
					}
					return filters;
				}
			},
			diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/
		};
	});
