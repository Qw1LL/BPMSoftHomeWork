define("ContactOpenCasesDetail", [],
	function() {
		return {
			entitySchemaName: "Case",
			messages: {
				/**
				 * @message UpdateOpenCaseDetail
				 * Open case detail event message handler.
				 */
				"UpdateOpenCaseDetail": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				},

				/**
				 * @message GetCaseIdOpenCaseDetail
				 * Gets the identifier of current case.
				 */
				"GetCaseIdOpenCaseDetail": {
					mode: this.BPMSoft.MessageMode.PTP,
					direction: this.BPMSoft.MessageDirectionType.PUBLISH
				}
			},
			attributes: {
				/**
				 * Stores an identifier of current case.
				 */
				"CaseId": {
					dataValueType: this.BPMSoft.DataValueType.GUID
				}
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "merge",
					"name": "DataGrid",
					"values": {
						"activeRowAction": {"bindTo": "onActiveRowAction"},
						"activeRowActions": []
					}
				},
				{
					"operation": "insert",
					"name": "OpenRecordButton",
					"parentName": "DataGrid",
					"propertyName": "activeRowActions",
					"values": {
						"className": "BPMSoft.Button",
						"style": BPMSoft.controls.ButtonEnums.style.ORANGE,
						//TODO localizablestring
						"caption": "Open",//{ "bindTo": "Resources.Strings.OpenButtonCaption"},
						"tag": "open"
					}
				},
				{
					"operation": "insert",
					"name": "MergeRecordButton",
					"parentName": "DataGrid",
					"propertyName": "activeRowActions",
					"values": {
						"className": "BPMSoft.Button",
						"style": BPMSoft.controls.ButtonEnums.style.DEFAULT,
						//TODO localizablestring
						"caption": "Merge doubles",//{ "bindTo": "Resources.Strings.MergeCaption"},
						"tag": "merge"
					}
				}
			]/**SCHEMA_DIFF*/,
			methods: {

				/**
				 * Initializes initial data.
				 * @overridden
				 */
				init: function(callback, scope) {
					this.callParent([function() {
						this.initData(function() {
							this.subscribeDetailSandboxEvents();
							callback.call(scope);
						}, this);
					}, this]);
				},

				/**
				 * Subscribes to the messages  necessary for detail.
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
				 * Gets the collection of filters.
				 * @overridden
				 * @returns {BPMSoft.FilterGroup} Detail filter group.
				 */
				getFilters: function() {
					var detailFilters = this.get("DetailFilters");
					var serializationDetailInfo = detailFilters.getDefSerializationInfo();
					serializationDetailInfo.serializeFilterManagerInfo = true;
					var deserializedDetailFilters = BPMSoft.deserialize(detailFilters.serialize(serializationDetailInfo));
					var contactCaseFilterGroup = this.getContactCaseFilters();
					deserializedDetailFilters.add("masterRecordFilter", contactCaseFilterGroup);
					return deserializedDetailFilters;
				},

				/**
				 * Returns filter for cases over contacts.
				 * @protected
				 * @return {BPMSoft.FilterGroup} Filter over contacts.
				 */
				getContactCaseFilters: function() {
					var contactCaseFilterGroup = this.Ext.create("BPMSoft.FilterGroup");
					var masterRecordId = this.get("MasterRecordId") ? this.get("MasterRecordId") : BPMSoft.GUID_EMPTY;
					var caseId = this.sandbox.publish("GetCaseIdOpenCaseDetail", null, [this.sandbox.id]);
					this.set("CaseId", caseId);
					contactCaseFilterGroup.add("ContactCaseFilter", this.BPMSoft.createColumnFilterWithParameter(
							this.BPMSoft.ComparisonType.EQUAL, "Contact", masterRecordId)
					);
					contactCaseFilterGroup.add("CaseIdFilter", this.BPMSoft.createColumnFilterWithParameter(
							this.BPMSoft.ComparisonType.NOT_EQUAL, "Id", caseId)
					);
					contactCaseFilterGroup.add("IsFinaleStatusFilter", this.BPMSoft.createColumnFilterWithParameter(
							this.BPMSoft.ComparisonType.EQUAL, "Status.IsFinal", false)
					);
					return contactCaseFilterGroup;
				},

				/**
				 *
				 * @protected
				 * @param buttonTag
				 * @param primaryColumnValue
				 */
				onActiveRowAction: function(buttonTag, primaryColumnValue) {
					switch (buttonTag) {
						case "open":
							this.editRecord();
							break;
						case "merge":
							this.mergeDuplicates();
							break;
						default:
							break;
					}
				},
				mergeDuplicates: function() {
					//TODO
				}
			}
		};
	});
