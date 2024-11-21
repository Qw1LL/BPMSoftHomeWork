define("ContactAnniversaryPageV2", ["ContactAnniversaryPageV2Resources", "ConfigurationConstants"],
	function(resources, ConfigurationConstants) {
		return {
			entitySchemaName: "ContactAnniversary",
			details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
			methods: {
				/**
				 * ########## ######## ###### #############.
				 * #### ############ ############ ########, ####### ######### # ############# ########## #######.
				 * ##### ########## callback-#######.
				 * @protected
				 * @overridden
				 * @param {Function} callback callback-#######
				 * @param {BPMSoft.BaseSchemaViewModel} scope ######## ########## callback-#######
				 */
				asyncValidate: function(callback, scope) {
					this.callParent([function(response) {
						if (!this.validateResponse(response)) {
							return;
						}
						this.BPMSoft.chain(
							function(next) {
								this.validateAnniversaryType(function(response) {
									if (this.validateResponse(response)) {
										next();
									}
								}, this);
							},
							function(next) {
								callback.call(scope, response);
								next();
							}, this);
					}, this]);
				},

				/**
				 * ########## ### ############### #######.
				 * # ######## ## ##### ############ ### #### ########.
				 * @protected
				 * @param {Function} callback callback-#######
				 * @param {BPMSoft.BaseSchemaViewModel} scope ######## ########## callback-#######
				 */
				validateAnniversaryType: function(callback, scope) {
					var anniversaryType = this.get("AnniversaryType");
					var contact = this.get("Contact");
					var result;
					
					if (anniversaryType.value !== ConfigurationConstants.AnniversaryType.Birthday) {
						result = this.getValidateBirthDateResult(this.get("Resources.Strings.ValidateCompanyBirthDateMessage"));
						callback.call(scope || this, result);
					} else {
						var esq = this.Ext.create("BPMSoft.EntitySchemaQuery", {
							rootSchemaName: this.entitySchemaName
						});
						esq.addColumn("Contact");
						esq.filters.addItem(esq.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL,
							"AnniversaryType", ConfigurationConstants.AnniversaryType.Birthday));
						esq.filters.addItem(esq.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL,
							"Contact", contact.value));
						if (this.isEditMode()) {
							esq.filters.addItem(esq.createColumnFilterWithParameter(BPMSoft.ComparisonType.NOT_EQUAL,
								"Id", this.get("Id")));
						}
						result = this.getValidateBirthDateResult(this.get("Resources.Strings.ValidateBirthDateMessage"));
						esq.getEntityCollection(function(response) {
							if (response.success) {
								if (response.collection.getCount() >= 1) {
									result.message = this.get("Resources.Strings.ValidateAnniversaryTypeMessage");
									result.success = false;
								}
							} else {
								return;
							}
							callback.call(scope || this, result);
						}, this);
					}
				},
				getValidateBirthDateResult: function(errorMessage) {
					const isInvalid = this.get("Date") > new Date(); 
					return {
						success: !isInvalid,
						message: isInvalid ? errorMessage : ""
					};
				},
			},
			diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/
		};
	});
