define("AdditionalDiffUtilities", function() {
	Ext.define("BPMSoft.configuration.mixins.AdditionalDiffUtilities", {
		alternateClassName: "BPMSoft.AdditionalDiffUtilities",

		/**
		 * Returns additional diff for ESNtab.
		 * @private
		 * @return {Object} Returns additional diff for ESNtab.
		 */
		_getESNTabMoveDiff: function() {
			return {
				"operation": "move",
				"name": "ESNTab",
				"parentName": "Tabs",
				"propertyName": "tabs"
			};
		},

		/**
		 * Returns additional diff for TimelineTab.
		 * @private
		 * @return {Object} Returns additional diff for TimelineTab.
		 */
		_getTimelineTabMoveDiff: function() {
			return {
				"operation": "move",
				"name": "TimelineTab",
				"parentName": "Tabs",
				"propertyName": "tabs",
				"index": 3
			};
		},

		/**
		 * Returns additional diff with merge or move for tab based on tab move.
		 * @param {Array} schemaDiff Diff of schema to analyze.
		 * @param {Object} tabMoveDiff predefined additional diff with move for tab.
		 * @return {Object[]} Returns additional diff with merges or move for tab based on tab moves.
		 */
		_generateDiffForTab: function(schemaDiff, tabMoveDiff) {
			const tabDiffItemFromSchema = schemaDiff.find(function(item) {
				return item.operation === "move" &&
					item.parentName === "Tabs" &&
					item.name === tabMoveDiff.name;
			});
			if (!BPMSoft.isEmpty(tabDiffItemFromSchema)) {
				return {
					"operation": "merge",
					"name": tabDiffItemFromSchema.name,
					"values": {
						"order": tabDiffItemFromSchema.index
					}
				};
			} else {
				return tabMoveDiff;
			}
		},

		/**
		 * Returns additional diff.
		 * @return {Object[]} Returns diff.
		 */
		getAdditionalDiff: function() {
			const diff = BPMSoft.Features.getIsEnabled("UseTabOrderProperty")
				? [] : [this._getESNTabMoveDiff(), this._getTimelineTabMoveDiff()];
			return diff;
		},

		/**
		 * Returns additional diff with merges based on ESNTab and TimelineTab moves.
		 * @param {Array} schemaDiff Diff of schema to analyze.
		 * @return {Object[]} Returns diff with merges based on ESNTab and TimelineTab moves.
		 */
		getAdditionalDiffWithTabOrderPosition: function(schemaDiff) {
			const resultDiff = [];
			if (!BPMSoft.Features.getIsEnabled("UseTabOrderProperty") || BPMSoft.isEmpty(schemaDiff)) {
				return resultDiff;
			}
			resultDiff.push(this._generateDiffForTab(schemaDiff, this._getESNTabMoveDiff()));
			resultDiff.push(this._generateDiffForTab(schemaDiff, this._getTimelineTabMoveDiff()));
			return resultDiff;
		}
	});

	return Ext.create("BPMSoft.AdditionalDiffUtilities");
});
