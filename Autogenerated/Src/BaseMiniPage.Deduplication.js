/**
 * Parent: BaseMiniPage
 */
define("BaseMiniPage", [],
	function() {
		return {
			mixins: {},
			messages: {
				/**
				 * @message SetMiniPageVisible
				 * Change mini page visibility.
				 */
				"SetMiniPageVisible": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				}
			},
			attributes: {},
			methods: {

				/**
				 * Returns mini page entity columns filled values.
				 * @protected
				 * @returns {Object[]}
				 */
				getMiniPageColumnValues: function() {
					var values = [];
					this.BPMSoft.each(this.getEntityColumns(), function(item, key) {
						var modelValue = this.get(key);
						if (!this.Ext.isEmpty(modelValue)) {
							values.push({
								name: key, value: modelValue.value || modelValue
							});
						}
					}, this);
					return values;
				},

				/**
				 * @inheritdoc BPMSoft.DuplicatesSearchUtilitiesV2#getDuplicateSearchPageConfig
				 * @overridden
				 */
				getDuplicateSearchPageConfig: function() {
					var config = this.callParent(arguments);
					config.stateObj = config.stateObj || {};
					config.stateObj.openMiniPageConfig = {
						entitySchemaName: this.entitySchemaName,
						valuePairs: this.getMiniPageColumnValues()
					};
					return config;
				},

				/**
				 * @inheritdoc BPMSoft.DuplicatesSearchUtilitiesV2#loadLocalDuplicateSearchPage
				 * @overridden
				 */
				loadLocalDuplicateSearchPage: function() {
					this.callParent(arguments);
					this.sandbox.publish("SetMiniPageVisible", false, [this.sandbox.id]);
				},

				/**
				 * @inheritdoc BPMSoft.BaseMiniPage#onSaved
				 * @overridden
				 */
				onSaved: function() {
					this.setDuplicates(this.BPMSoft.emptyFn);
					this.callParent(arguments);
				},

				/**
				 * @inheritdoc BPMSoft.BaseEntityPage#isNewMode
				 * @overridden
				 */
				isNewMode: function() {
					return this.isAddMode();
				},

				/**
				 * @inheritdoc BPMSoft.DuplicatesSearchUtilitiesV2#getCommunications
				 * @overridden
				 */
				getCommunications: BPMSoft.emptyFn
			},
			diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/
		};
	});
