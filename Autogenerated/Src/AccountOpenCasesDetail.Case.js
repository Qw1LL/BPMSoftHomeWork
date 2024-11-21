define("AccountOpenCasesDetail",
	function() {
		return {
			entitySchemaName: "Case",
			attributes: {
				/**
				 * Stores an identifier of case.
				 */
				"CaseId": {
					dataValueType: this.BPMSoft.DataValueType.GUID
				}
			},
			diff:/**SCHEMA_DIFF*/[
			]/**SCHEMA_DIFF*/,
			methods: {
				init: function(callback, scope) {
					this.callParent([function() {
						this.initData(function() {
							this.subscribeDetailSandboxEvents();
							callback.call(scope);
						}, this);
					}, this]);
				},

				/**
				 * Subscribes to messages necessary for detail.
				 * @protected
				 * @virtual
				 */
				subscribeDetailSandboxEvents: function() {
					this.sandbox.subscribe("UpdateOpenCaseDetail", function(config) {
						if (this.destroyed) {
							return;
						}
						this.updateDetail(config);
					}, this, [this.sandbox.id]);
				},

				/**
				 * Gets filter collection.
				 * @overridden
				 * @returns {BPMSoft.FilterGroup} detail filter group.
				 */
				getFilters: function() {
					var detailFilters = this.get("DetailFilters");
					var serializationDetailInfo = detailFilters.getDefSerializationInfo();
					serializationDetailInfo.serializeFilterManagerInfo = true;
					var deserializedDetailFilters = BPMSoft.deserialize(detailFilters.serialize(serializationDetailInfo));
					var accountCaseFilterGroup = this.getAccountCaseFilters();
					deserializedDetailFilters.add("masterRecordFilter", accountCaseFilterGroup);
					return deserializedDetailFilters;
				},

				/**
				 * Returns relationship filter.
				 * @protected
				 * @return {BPMSoft.FilterGroup} Relationship filter.
				 */
				getAccountCaseFilters: function() {
					var accountCaseFilterGroup = this.Ext.create("BPMSoft.FilterGroup");
					var masterRecordId = this.get("MasterRecordId") ? this.get("MasterRecordId") : BPMSoft.GUID_EMPTY;
					var caseId = this.sandbox.publish("GetCaseIdOpenCaseDetail", null, [this.sandbox.id]);
					this.set("CaseId", caseId);
					accountCaseFilterGroup.add("AccountCaseFilter", this.BPMSoft.createColumnFilterWithParameter(
							this.BPMSoft.ComparisonType.EQUAL, "Account", masterRecordId)
					);
					accountCaseFilterGroup.add("CaseIdFilter", this.BPMSoft.createColumnFilterWithParameter(
							this.BPMSoft.ComparisonType.NOT_EQUAL, "Id", caseId)
					);
					accountCaseFilterGroup.add("IsFinaleStatusFilter", this.BPMSoft.createColumnFilterWithParameter(
							this.BPMSoft.ComparisonType.EQUAL, "Status.IsFinal", false)
					);
					return accountCaseFilterGroup;
				}
			},
			messages: {
				/**
				 * @message UpdateDetail
				 * Page change message handler
				*/
				"UpdateOpenCaseDetail": {
					mode: this.BPMSoft.MessageMode.PTP,
					direction: this.BPMSoft.MessageDirectionType.SUBSCRIBE
				},
				/**
				 * @message GetCaseIdOpenCaseDetail
				 * Gets the identifier of current case.
				 */
				"GetCaseIdOpenCaseDetail": {
					mode: this.BPMSoft.MessageMode.PTP,
					direction: this.BPMSoft.MessageDirectionType.PUBLISH
				}
			}
		};
	});
