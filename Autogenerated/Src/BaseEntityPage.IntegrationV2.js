define("BaseEntityPage", ["MeetingInvitationsMixin"], function() {
	return {
		details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
		mixins: {
			"MeetingInvitationsMixin": "BPMSoft.MeetingInvitationsMixin"
		},
		properties: {

			/**
			 * Calendar listen columns.
			 * @type {Array}
			 */
			_calendarListenColumns: [
				"Title",
				"Location",
				"StartDate",
				"DueDate",
				"Priority",
				"Notes",
				"ShowInScheduler",
				"Contact"
			]
	
		},
		methods: {

			//region Methods: Private

			_isActivityChanged: function() {
				for (let property in this.changedValues) {
					if (this._calendarListenColumns.includes(property)){
						return true;
					}
				}
				return  false;
			},

			//endregion

			//region Methods: Protected

			/**
			 * @inheritdoc BPMSoft.BaseEntityPage#getEntityInitializedSubscribers
			 * @overridden
			 */
			getEntityInitializedSubscribers: function() {
				if (this.entitySchemaName === "Activity") {
					this.$OldStartDate =  this.$StartDate;
				}
				return this.callParent(arguments);
			},

			//endregion

			//region Methods: Public

			/**
			 * @inheritdoc BPMSoft.BaseEntityPage#asyncValidate
			 * @overridden
			 */
			asyncValidate: function(callback, scope) {
				this.callParent([function(result) {
					if (this.entitySchemaName === "Activity" && this._isActivityChanged()) {
						this.canUserChangeMeeting(this.$Id, function () {
							Ext.callback(callback, scope, [result]);
						}, function () {
							this.cancelSave();
							this.hideBodyMask();
						});
					} else {
						Ext.callback(callback, scope, [result]);
					}

				}, this]);
			},

			/**
			 * Cancel save user action.
			 */
			cancelSave: function() {
				this.onCardAction("onDiscardChangesClick");
			},

			/**
			 * @inheritdoc BPMSoft.BaseEntityPage#saveEntity
			 * @overridden
			 */
			saveEntity: function(callback, scope) {
				this.callParent([function(response) {
					Ext.callback(callback, scope || this, [response]);
					this.confirmInvitationsSending(this.$Id);
				}, scope || this]);
			}

			//endregion

		},
		diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/
	};
});
