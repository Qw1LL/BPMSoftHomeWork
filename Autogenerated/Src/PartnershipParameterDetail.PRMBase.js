define("PartnershipParameterDetail", [], function() {
	return {
		entitySchemaName: "PartnershipParameter",
		attributes: {
			/**
			 * Flag pressing buttons filtration.
			 */
			IsFiltrationButtonPressed: {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				value: true
			}
		},
		properties: {

			/**
			 * Property key for filtration button.
			 */
			_filtrationButtonPressedProfileKey: "IsFiltrationButtonPressed"
		},
		diff: /**SCHEMA_DIFF*/[
			// Add filter button FiltrationButton for filtration by PartnershipParameterType
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
			 * @inheritdoc BPMSoft.GridUtilitiesV2#getAddRecordButtonVisible
			 * @overridden
			 */
			getAddRecordButtonVisible: function() {
				return false;
			},

			getEditRecordMenuItem: BPMSoft.emptyFn,

			getCopyRecordMenuItem: BPMSoft.emptyFn,

			getDeleteRecordMenuItem: BPMSoft.emptyFn,

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
				var isFiltrationButtonPressed = this.get("IsFiltrationButtonPressed");
				if (isFiltrationButtonPressed) {
					filterGroup.add("PartnershipParameterTypeFilter",
						BPMSoft.createColumnFilterWithParameter(
							BPMSoft.ComparisonType.EQUAL, "PartnershipParameterType",
							this.BPMSoft.PRMEnums.PartnershipParamType.Target, BPMSoft.DataValueType.GUID));
				}
				return filterGroup;
			},

			/**
			 * @inheritdoc BPMSoft.BaseSchemaViewModel#initializeProfile
			 * @overridden
			 */
			initializeProfile: function(callback, scope) {
				this.callParent([function() {
					this.requireFiltrationButtonProfile(callback, scope);
				}, scope || this]);
			},

			/**
			 * Loads profile of filtration button.
			 * @param callback
			 * @param scope
			 */
			requireFiltrationButtonProfile: function(callback, scope) {
				const key = this.getProfileKey();
				this.requireProfile(function(profile) {
					this.setIsFiltrationButtonPressed(profile);
					this.Ext.callback(callback, scope);
				}, scope || this, key);
			},

			/**
			 * Sets IsFiltrationButtonPressed attribute from profile.
			 * @param {Object} profile Current user profile.
			 */
			setIsFiltrationButtonPressed: function (profile) {
				const isPressed = profile[this._filtrationButtonPressedProfileKey];
				if (!this.Ext.isEmpty(isPressed)) {
					this.set("IsFiltrationButtonPressed", isPressed);
				}
			}
		}
	};
});
