define("OpportunitySearchRowSchema", ["MultiLookupUtilitiesMixin", "ImageListGenerator"], function() {
	return {
		attributes: {
			"Client": {
				"caption": {"bindTo": "Resources.Strings.ClientColumnCaption"},
				"dataValueType": this.BPMSoft.DataValueType.LOOKUP,
				"multiLookupColumns": ["Contact", "Account"]
			}
		},
		methods: {
			/**
			 * Returns mood image url.
			 * @return {String} Mood image url.
			 */
			getMoodImage: function() {
				var mood = this.get("Mood");
				var primaryImageValue = mood && mood.primaryImageValue;
				if (primaryImageValue) {
					return BPMSoft.ImageUrlBuilder.getUrl({
						source: BPMSoft.ImageSources.SYS_IMAGE,
						params: {primaryColumnValue: primaryImageValue}
					});
				}
				return this.BPMSoft.ImageUrlBuilder.getUrl(this.get("Resources.Images.DefaultMood"));
			}
		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "remove",
				"name": "EntitySchemaCaption"
			},
			{
				"operation": "merge",
				"name": "FoundColumnsContainerList",
				"values": {
					"layout": {
						"column": 0,
						"row": 2,
						"colSpan": 11
					}
				}
			},
			{
				"operation": "insert",
				"name": "MoodContainer",
				"parentName": "DataContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"classes": {
						"wrapClassName": ["mood-container", "control-width-15"]
					},
					"items": [],
					"layout": {
						"column": 13,
						"row": 0,
						"colSpan": 6
					}
				}
			},
			{
				"operation": "insert",
				"name": "Mood",
				"parentName": "MoodContainer",
				"propertyName": "items",
				"values": {
					"getSrcMethod": "getMoodImage",
					"readonly": true,
					"generator": "ImageCustomGeneratorV2.generateSimpleCustomImage"
				}
			},
			{
				"operation": "insert",
				"parentName": "MoodContainer",
				"propertyName": "items",
				"name": "Mood"
			},
			{
				"operation": "insert",
				"parentName": "DataContainer",
				"propertyName": "items",
				"name": "Owner",
				"values": {
					"layout": {
						"column": 18,
						"row": 0,
						"colSpan": 6
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "DataContainer",
				"propertyName": "items",
				"name": "Client",
				"values": {
					"layout": {
						"column": 0,
						"row": 1,
						"colSpan": 11
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "DataContainer",
				"propertyName": "items",
				"name": "Stage",
				"values": {
					"layout": {
						"column": 13,
						"row": 1,
						"colSpan": 6
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "DataContainer",
				"propertyName": "items",
				"name": "Budget",
				"values": {
					"layout": {
						"column": 18,
						"row": 1,
						"colSpan": 6
					}
				}
			}
		]/**SCHEMA_DIFF*/
	};
});
