define("ContactAnniversaryDetailV2", ["ConfigurationConstants"], function(ConfigurationConstants) {
	return {
		entitySchemaName: "ContactAnniversary",
		messages: {
			/**
			 * @message BirthdateChanged
			 * Notify that BirthDate was changed.
			 */
			"BirthdateChanged": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			}
		},
		attributes: {
			/**
			 * Determine whether record with type "Birthdate" can be added.
			 * @type {Boolean}
			 */
			"IsBirthdayEnabled": {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				value: true
			}
		},
		methods: {

			//region Methods: protected

			/**
			 * Returns default name of the filtration column.
			 * @override
			 * @return {String} Column name.
			 */
			getFilterDefaultColumnName: function() {
				return "AnniversaryType";
			},

			/**
			 * Check if GridData has records.
			 * @protected
			 * @param {BPMSoft.Collection} gridData Grid data.
			 * @return {Boolean} true if GridData has records.
			 */
			isGridPopulatedWithData: function(gridData) {
				return gridData && gridData.getCount() > 0;
			},

			/**
			 * Get GridData row with type "Birthdate".
			 * @protected
			 * @param {BPMSoft.Collection} gridData Grid data.
			 * @return {Object} birthdateRow.
			 */
			getBirthdateRow: function(gridData) {
				var birthdateRow = {};
				gridData.each(function(item) {
					if (this.isBirthdayAnniversaryType(item)) {
						birthdateRow = item;
						return false;
					}
				}, this);
				return birthdateRow;
			},

			/**
			 * Check whether anniversary row from GridData has values.
			 * @protected
			 * @param {BPMSoft.BaseModel} birthdateRow Row.
			 * @return {Object} true if a row has values.
			 */
			hasBirthdateRowData: function(birthdateRow) {
				return !Ext.Object.isEmpty(birthdateRow);
			},

			/**
			 * Get birthday date.
			 * @protected
			 * @return {Date} if GridData has birthday rows otherwise empty string.
			 */
			getBirthdate: function() {
				var gridData = this.getGridData();
				if (!this.isGridPopulatedWithData(gridData)) {
					return;
				}
				var birthdateRow = this.getBirthdateRow(gridData);
				var birthdateValue = this.hasBirthdateRowData(birthdateRow) ? birthdateRow.get("Date") : "";
				return birthdateValue;
			},

			/**
			 * Publish the BirthdateChanged message with birthdate.
			 * @protected
			 * @param {Date} newBirthdate New birthdate.
			 */
			publishBirthdateChangeMessage: function(newBirthdate) {
				this.sandbox.publish("BirthdateChanged", newBirthdate, [this.sandbox.id]);
				this.set("BirthDate", newBirthdate);
			},

			/**
			 * Check whether exists new correct birthdate that can be published.
			 * @protected
			 * @param {Date} newBirthdate New birthdate.
			 * @return {Boolean} true if new birthdate exists otherwise false.
			 */
			hasNewBirthdate: function(newBirthdate) {
				var oldBirthdate = this.get("BirthDate");

				if (!oldBirthdate && !newBirthdate) {
					return false;
				}

				if (oldBirthdate !== newBirthdate) {
					return true;
				}
			},

			/**
			 * Publish birthday date if it exists.
			 * @protected
			 */
			publishBirthdate: function() {
				var newBirthdate = this.getBirthdate();
				var emptyGrid = this.get("IsGridEmpty");
				if (emptyGrid) {
					this.publishBirthdateChangeMessage(newBirthdate);
				}

				if (!Ext.isDefined(newBirthdate)) {
					return;
				}
				if (this.hasNewBirthdate(newBirthdate)) {
					this.publishBirthdateChangeMessage(newBirthdate);
				}
			},

			/**
			 * Check if contact anniversary record type is "Birthdate".
			 * @protected
			 * @param {BPMSoft.BaseModel} record Record.
			 * @return {Boolean} true if record`s type is "Birthdate" otherwise false.
			 */
			isBirthdayAnniversaryType: function(record) {
				var type = record.get("AnniversaryType");
				var birthdayType = ConfigurationConstants.AnniversaryType.Birthday;
				return type && type.value === birthdayType;
			},

			/**
			 * Check if GridData has rows with type "Birthdate".
			 * @protected
			 * @return {Boolean} true if GridData has rows with type "Birthdate" otherwise false.
			 */
			hasRowsWithBirthdateType: function() {
				var hasBirthdateRows = false;
				var gridData = this.getGridData();
				if (this.isGridPopulatedWithData(gridData)) {
					var birthdateRow = this.getBirthdateRow(gridData);
					hasBirthdateRows = this.hasBirthdateRowData(birthdateRow);
				}
				return hasBirthdateRows;
			},

			/**
			 * Check if detail add button menu item with name "Birthdate" is enabled.
			 * @protected
			 */
			checkIsBirthdayEnabled: function() {
				var hasBirthdateRows = this.hasRowsWithBirthdateType();
				var isBirthdayEnabled = hasBirthdateRows ? false : true;
				this.set("IsBirthdayEnabled", isBirthdayEnabled);
			},

			/**
			 * @inheritdoc BPMSoft.BaseAnniversaryDetailV2#getEditPages
			 * @override
			 */
			getEditPages: function() {
				var editPages = this.callParent(arguments);
				var birthdayPage = editPages.get(ConfigurationConstants.AnniversaryType.Birthday);
				if (birthdayPage) {
					birthdayPage.set("Enabled", {"bindTo": "IsBirthdayEnabled"});
				}
				return editPages;
			},

			/**
			 * @inheritdoc BPMSoft.BaseGridDetailV2#onDataChanged
			 * @override
			 */
			onDataChanged: function() {
				this.callParent(arguments);
				this.checkIsBirthdayEnabled();
				this.publishBirthdate();
			},

			//endregion

		},
		diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/
	};
});
