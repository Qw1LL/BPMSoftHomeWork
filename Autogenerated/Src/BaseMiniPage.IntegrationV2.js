define("BaseMiniPage", [],
	function() {
		return {
			methods: {

				
				//region Methods: Protected

				/**
				 * @inheritdoc BaseMiniPage#onEntityInitialized
				 * @protected
				 * @overridden
				 */
				onEntityInitialized: function(callback, scope) {
					this.callParent([function() {
						if (this.entitySchemaName === "Activity") {
							this.$OldStartDate =  this.$StartDate;
						}
						Ext.callback(callback, scope);
					}, this]);
				},

				//endregion
				
				//region Methods: Public

				/**
				 * Cancel save user action.
				 */
				cancelSave: function () {
					this.close();
				}

				//endregion

			},
			diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/
		};
	});
