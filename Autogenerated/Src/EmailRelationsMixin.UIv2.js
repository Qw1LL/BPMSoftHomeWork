define("EmailRelationsMixin", ["ConfigurationConstants", "EmailHelper"], function(ConfigurationConstants, EmailHelper) {
	/**
	 * @class BPMSoft.configuration.mixins.EmailRelationsMixin
	 * Email relations mixin.
	 */
	Ext.define("BPMSoft.configuration.mixins.EmailRelationsMixin", {
		alternateClassName: "BPMSoft.EmailRelationsMixin",

		// region Methods: Private

		/**
		 * Returns current item sender email.
		 * @private
		 * @return {String} #urrent item sender email.
		 */
		_getSenderEmail: function() {
			const email = this.$SenderEmail.replace(/^<|>$/g, '');
			return email || this.$SenderName;
		},

		// endregion

		// region Methods: Protected

		/**
		 * Returns insert query for sender participant.
		 * @protected
		 * @param {GUID} contactId Contact Id.
		 * @return {BPMSoft.InsertQuery} Insert query.
		 */
		getInsertSenderParticipantQuery: function(contactId) {
			var roleId = ConfigurationConstants.Activity.ParticipantRole.From;
			var activityId = this.get("Id");
			var insertQuery = Ext.create("BPMSoft.InsertQuery", {
				rootSchemaName: "ActivityParticipant"
			});
			insertQuery.setParameterValue("Activity", activityId, this.BPMSoft.DataValueType.GUID);
			insertQuery.setParameterValue("Participant", contactId, this.BPMSoft.DataValueType.GUID);
			insertQuery.setParameterValue("Role", roleId, this.BPMSoft.DataValueType.GUID);
			return insertQuery;
		},

		/**
		 * Inserts sender participant.
		 * @protected
		 * @param {GUID} contactId Contact Id.
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Callback scope.
		 */
		insertSenderParticipant: function(contactId, callback, scope) {
			this.set("SenderContact", {value: contactId});
			var insertQuery = this.getInsertSenderParticipantQuery(contactId);
			insertQuery.execute(callback, scope);
		},

		/**
		 * Returns update query for sender contact email.
		 * @protected
		 * @param {GUID} contactId Contact Id.
		 * @return {BPMSoft.UpdateQuery} Update query.
		 */
		getUpdateSenderContactEmailQuery: function(contactId) {
			var email = this._getSenderEmail();
			var updateQuery = this.Ext.create("BPMSoft.UpdateQuery", {
				rootSchemaName: "Contact"
			});
			updateQuery.filters.add("IdFilter", updateQuery.createColumnFilterWithParameter(
				this.BPMSoft.ComparisonType.EQUAL, "Id", contactId));
			updateQuery.setParameterValue("Email", email, this.BPMSoft.DataValueType.TEXT);
			return updateQuery;
		},

		/**
		 * Updates sender contact email.
		 * @protected
		 * @param {GUID} contactId Contact Id.
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Callback scope.
		 */
		updateSenderContactEmail: function(contactId, callback, scope) {
			var updateQuery = this.getUpdateSenderContactEmailQuery(contactId);
			updateQuery.execute(callback, scope);
		},

		//endregion

		// region Methods: Public

		/**
		 * Adds sender info to value pairs array.
		 * @param {Array} valuePairs Value pairs array.
		 */
		addSenderInfo: function(valuePairs) {
			var email = this.get("SenderEmail").replace(/^<|>$/g, '');
			var name = this.get("SenderName");
			if (!email && EmailHelper.isEmailAddress(name)) {
				email = name;
				name = email.split("@")[0];
			}
			valuePairs.push({name: "Email", value: email});
			valuePairs.push({name: "Name", value: name});
		},

		/**
		 * Returns is auto binding contact email needed.
		 * @return {Boolean} Is auto binding contact email needed.
		 */
		isAutoBindingContactEmailNeeded: function() {
			var statuses = ConfigurationConstants.Activity.EmailSendStatus;
			var emailStatus = this.get("EmailSendStatus");
			var senderContact = this.get("SenderContact");
			var featureState = this.getIsFeatureEnabled("EmailRelationAddingEnabled");
			return Boolean(emailStatus && emailStatus.value === statuses.Sended && !senderContact && featureState);
		},

		/**
		 * Actualizes sender contact relation with email.
		 * @param {GUID} contactId Contact Id.
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Callback scope.
		 */
		actualizeSenderRelation: function(contactId, callback, scope) {
			this.BPMSoft.chain(
				function(next) {
					this.updateSenderContactEmail(contactId, next, this);
				},
				function(next) {
					this.insertSenderParticipant(contactId, next, this);
				},
				function (next) {
					this.fireEvent("senderSet", {
						"ContactId": contactId,
						"Email" : this._getSenderEmail()
					});
					next();
				},
				function() {
					this.Ext.callback(callback, scope);
				}, this);
		}

		//endregion

	});

	return BPMSoft.EmailRelationsMixin;
});
