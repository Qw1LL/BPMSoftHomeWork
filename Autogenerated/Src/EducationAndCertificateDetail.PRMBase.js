define("EducationAndCertificateDetail", [], function() {
	return {
		entitySchemaName: "EducationActivity",
		attributes: {
			/**
			 * Flag pressing buttons filtration.
			 */
			IsFiltrationButtonPressed: {dataValueType: BPMSoft.DataValueType.BOOLEAN}
		},
		diff: /**SCHEMA_DIFF*/[
			// Add filter button FiltrationButton for filtration by EducationAndCertificate
			{
				"operation": "insert",
				"name": "FiltrationButton",
				"parentName": "Detail",
				"propertyName": "tools",
				"values": {
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
					"caption": {"bindTo": "Resources.Strings.FiltrationButtonCaption"},
					"pressed": {"bindTo": "IsFiltrationButtonPressed"},
					"click": {"bindTo": "onFiltrationButtonClick"},
					"hint": {"bindTo": "getFiltrationButtonHint"}
				}
			}
		]/**SCHEMA_DIFF*/,
		methods: {
			/**
			 * Returns filtration button hint text.
			 * @protected
			 * @return {String} Hint text.
			 */
			getFiltrationButtonHint: function() {
				return this.get("Resources.Strings.FiltrationButtonHint");
			},

			/**
			 * Handler on click filtration button.
			 * Sets attribute that filtration button pressed, save current value to the profile
			 * and reload detail data.
			 * @protected
			 */
			onFiltrationButtonClick: function() {
				var isFiltrationButtonPressed = !this.get("IsFiltrationButtonPressed");
				var profile = this.getProfile();
				var key = this.getProfileKey();
				if (this.isNotEmpty(profile) && this.isNotEmpty(key)) {
					profile.IsFiltrationButtonPressed = isFiltrationButtonPressed;
					this.set(this.getProfileColumnName(), profile);
					this.BPMSoft.utils.saveUserProfile(key, profile, false);
				}
				this.set("IsFiltrationButtonPressed", isFiltrationButtonPressed);
				this.reloadGridData();
			},

			/**
			 * @inheritdoc BPMSoft.GridUtilitiesV2#getFilters
			 * @overridden
			 */
			getFilters: function() {
				var filterGroup = this.callParent(arguments);
				filterGroup.logicalOperation = this.BPMSoft.LogicalOperatorType.AND;
				var isFiltrationButtonPressed = this.get("IsFiltrationButtonPressed");
				if (isFiltrationButtonPressed) {
					filterGroup.add("IssueDateFilter",
						BPMSoft.createColumnFilterWithParameter(
							BPMSoft.ComparisonType.LESS_OR_EQUAL, "=[Certificate:EducationActivity:Id].IssueDate",
							new Date()));
					filterGroup.add("ExpireDateFilter",
						BPMSoft.createColumnFilterWithParameter(
							BPMSoft.ComparisonType.GREATER_OR_EQUAL, "=[Certificate:EducationActivity:Id].ExpireDate",
							new Date()));
				}
				return filterGroup;
			}
		}
	};
});
