define("AddressSelectionResultDetailV2", [],
	function() {
		return {
			entitySchemaName: "VwClientAddress",
			methods: {
				/**
				 * @inheritdoc BPMSoft.AddressSelectionDetailV2#getContainerListEl
				 * @overridden
				 */
				getContainerListEl: function() {
					return this.Ext.get("ResultsAddressContainerContainerList");
				}
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "merge",
					"name": "AddressContainer",
					"values": {"id": "ResultsAddressContainerContainerList"}
				}
			]/**SCHEMA_DIFF*/
		};
	});
