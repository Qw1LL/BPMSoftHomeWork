define("CaseTermCalculationDescribeUtilities", ["BPMSoft", "NetworkUtilities",
		"CaseTermCalculationDescribeUtilitiesResources"],
	function(BPMSoft, NetworkUtilities, resources) {
		/**
		 * @class BPMSoft.configuration.mixins.CaseTermCalculationDescribeUtilities
		 * Mixin for case terms calculation explanation.
		 */
		Ext.define("BPMSoft.configuration.mixins.CaseTermCalculationDescribeUtilities", {
			alternateClassName: "BPMSoft.CaseTermCalculationDescribeUtilities",
			/**
			 * Return list of fields to explain terms calculation.
			 * @returns {Array} Array of columns config.
			 * @protected
			 * @virtual
			 */
			getCaseTermCalculationColumnsList: function() {
				return [{
						name: "ServiceItem",
						isLink: true
					}, {
						name: "ServicePact",
						isLink: true
					}, {
						name: "Priority"
					}, {
						name: "Id"
					}
				];
			},

			/**
			 * Get calculation data for case term explanation.
			 * @returns {Array} data for case term calculation.
			 */
			getCaseTermCalculationParameters: function() {
				const fieldsList = this.getCaseTermCalculationColumnsList();
				const data = [];
				fieldsList.forEach(function(item) {
					const value = this._getColumnObjectValue(item);
					if (value) {
						data.push(value);
					}
				}, this);
				return data;
			},

			/**
			 * @private
			 */
			_getColumnObjectValue: function(columnConfig) {
				const column = this.getColumnByName(columnConfig.name);
				if (!Ext.isDefined(column) || !this.get(columnConfig.name)) {
					return null;
				}
				if (column.dataValueType === BPMSoft.DataValueType.LOOKUP) {
					return this.getColumnObjectLookupValue(column, columnConfig);
				} else {
					return this.getColumnObjectSimpleValue(column);
				}
			},

			/**
			 * Get lookup value term calculation parameter.
			 * @param {Object} column Schema source column.
			 * @param {Object} columnConfig Column config to build output object.
			 * @returns {Object} Lookup column term calculation parameter.
			 * @protected
			 */
			getColumnObjectLookupValue: function(column, columnConfig) {
				const value = {
					"column": column.name + "Id",
					"value": this.get(column.name).value,
					"displayValue": this.get(column.name).displayValue,
					"link": ""
				};
				if (columnConfig.isLink) {
					value.link = this.getEntityEditUrl(column, value.value);
				}

				return value;
			},

			/**
			 * Get simple type value term calculation parameter.
			 * @param {Object} column Schema source column.
			 * @returns {Object} Simple column term calculation parameter.
			 * @protected
			 */
			getColumnObjectSimpleValue: function(column) {
				let value;
				if (column.columnPath === this.primaryColumnName) {
					value = {
						"column": this.entitySchemaName + "Id",
						"value": this.getPrimaryColumnValue(),
						"displayValue": this.getPrimaryDisplayColumnValue(),
						"link": ""
					};
				} else {
					value = {
						"column": column.name,
						"value": this.get(column.name)
					};
				}
				return value;
			},

			/**
			 * Get edit page url for lookup column entity.
			 * @param {Object} column Source lookup column.
			 * @param {Guid} recordId Entity record id.
			 * @returns {String} Entity edit page url.
			 */
			getEntityEditUrl: function(column, recordId) {
				const config = {
					entitySchema: column.referenceSchemaName,
					primaryColumnValue: recordId,
					operation: BPMSoft.ConfigurationEnums.CardOperation.EDIT
				};
				return BPMSoft.combinePath(this.BPMSoft.workspaceBaseUrl, "Nui", "ViewModule.aspx#",
					NetworkUtilities.getEntityUrl(config));
			},

			/**
			 * Get additional data for terms description.
			 * @param {Number} termKind Kind of term for terms calculation.
			 * @return {Object} Object contains additional data.
			 */
			getAdditionalData: function(termKind) {
				return {
					termKind: termKind,
					termsCalculationAcademyUrl: this.getTermsAcademyUrl(),
					caseDeadlineCalcSchemasLookupUrl: this.getCaseDeadlineCalcSchemasLookupUrl(),
					registrationDate: BPMSoft.toLocalISOString(this.get("RegisteredOn")),
					termCalculationErrorImageUrl: this.getTermCalculationErrorImageUrl(),
					termCalculationErrorMessage: this.getTermCalculationErrorMessage(),
					closeButtonCaption: this.getCloseButtonCaption()
				};
			},

			/**
			 * Get url to open Case deadline calculation schemas lookup content.
			 * @returns {String} Built url.
			 */
			getCaseDeadlineCalcSchemasLookupUrl: function() {
				return this.BPMSoft.combinePath(this.BPMSoft.workspaceBaseUrl, "Nui", "ViewModule.aspx#",
					"LookupSectionModule", "CaseDeadlineCalcSchemasLookupSection");
			},

			/**
			 * Gets url for Academy terms article for current product version.
			 * @return {String} Built url.
			 */
			getTermsAcademyUrl: function() {
				const urlTemplate = resources.localizableStrings.TermsAcademyUrlTemplate;
				const version = BPMSoft.coreVersion;
				const versionParts = (/(\d+)\.(\d+)/).exec(version);
				let formattedVersion;
				if (versionParts.length === 3) {
					formattedVersion = versionParts[1] + "-" + versionParts[2];
				} else {
					formattedVersion = resources.localizableStrings.DefaultProductVersion;
				}
				return this.Ext.String.format(urlTemplate, formattedVersion);
			},

			/**
			 * Retunrs url of terms calculation error image.
			 * @returns {String} Error image url.
			 */
			getTermCalculationErrorImageUrl: function() {
				return this.BPMSoft.ImageUrlBuilder.getUrl(resources.localizableImages.TermCalculationErrorImage);
			},

			/**
			 * Returns message of terms caculation error.
			 * @returns {String} Terms caltulation error message.
			 */
			getTermCalculationErrorMessage: function() {
				return resources.localizableStrings.TermCalculationErrorMessage;
			},

			/**
			 * Returns caption of close button.
			 * @returns {String} Close button caption.
			 */
			getCloseButtonCaption: function() {
				return resources.localizableStrings.CloseButtonCaption;
			},

			/**
			 * Returns header caption for term calculation container.
			 * @returns {String} Header caption.
			 */
			getTermContainerHeader: function(tag) {
				const columnName = _.invert(BPMSoft.configuration.TermCalculationInformationEnums.TermKind)[tag];
				const column = this.getColumnByName(columnName);
				return column ? column.caption : null;
			}
		});
	});
