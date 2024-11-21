/**
 * Parent: ProcessElementParametersMappingPage
 */
define("DcmElementParametersMappingPage", ["DcmElementParametersMappingPageResources",
	"ProcessSchemaUserTaskUtilities"],
		function() {

		return {
			methods: {
				/**
				 * @inheritdoc BPMSoft.ProcessElementParametersMappingPage#addItemsToFlowElementsGridRowCollection
				 * @overridden
				 */
				addItemsToFlowElementsGridRowCollection: function(collection, flowElement, item) {
					collection[flowElement.uId] = item;
				},

				/**
				 * @inheritdoc BPMSoft.ProcessElementParametersMappingPage#setFirstCollectionRowActive
				 * @overridden
				 */
				setFirstCollectionRowActive: function(collection) {
					var keys = collection.getKeys();
					this.set("ElementsGridActiveRow", keys[0]);
				},

				/**
				 * @inheritdoc BPMSoft.ProcessElementParametersMappingPage#loadActiveRowParametersCollection
				 * @overridden
				 */
				loadActiveRowParametersCollection: function(elementRow) {
					var elementId = elementRow.get("Id");
					this.getParametersGridRowCollection(elementId, function(collection) {
						this.loadParametersGrid(collection);
					}, this);
				}
			},
			diff: [
				{
					"operation": "merge",
					"name": "ProcessElementsGrid",
					"values": {
						"primaryColumnName": "Id"
					}
				}
			]
		};
	});
