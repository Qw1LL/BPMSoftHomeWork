define("RelatedEmailsDetail", ["RelatedEmailsMixin"],
	function() {
		return {
			entitySchemaName: "Activity",
			attributes: {
				/**
				 * Master record conversation identifier.
				 * @type {String}
				 */
				"ConversationId": {
					dataValueType: BPMSoft.DataValueType.GUID
				}
			},
			mixins: {
				/**
				 * Related emails search mixin.
				 */
				RelatedEmailsMixin: "BPMSoft.RelatedEmailsMixin",

			},
			methods: {

				//region Methods: Private

				/**
				 * Creates detail filters collection.
				 * @private
				 * @return {BPMSoft.FilterGroup} Detail filters collection.
				 */
				_getDetailFilters: function() {
					var detailFilters = this.$DetailFilters;
					var serializationDetailInfo = detailFilters.getDefSerializationInfo();
					serializationDetailInfo.serializeFilterManagerInfo = true;
					return BPMSoft.deserialize(detailFilters.serialize(serializationDetailInfo));
				},

				//endregion

				//region Methods: Protected

				/**
				 * @inheritdoc BPMSoft.BaseGridDetailV2#init
				 * @overridden
				 */
				init: function(callback, scope) {
					this.callParent([function() {
						BPMSoft.chain(
							this.initConversationId,
							function() {
								this.Ext.callback(callback, scope || this);
							},
							this
						);
					}, this]);
				},

				/**
				 * Initializes email conversation identifier.
				 * @protected
				 * @param {Function} callback Callback function.
				 * @param {Object} scope Callback function scope.
				 */
				initConversationId: function(callback, scope) {
					this.getConversationId(this.$MasterRecordId, function(conversationId) {
						this.$ConversationId = conversationId;
						this.reloadGridData();
						this.Ext.callback(callback, scope || this);
					}, this);
				},

				/**
				 * @inheritdoc BPMSoft.BaseGridDetailV2#loadGridData
				 * @overridden
				 */
				loadGridData: function() {
					if (this.isEmpty(this.$ConversationId)) {
						return;
					}
					this.callParent(arguments);
				},

				/**
				 * @inheritdoc BPMSoft.BaseGridDetailV2#getFilters
				 * @overridden
				 */
				getFilters: function() {
					var filters = this._getDetailFilters();
					this.setEmailsByConversationFilters(filters, this.$ConversationId);
					return filters;
				}

				//endregion
			},
			diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/
		};
	}
);
