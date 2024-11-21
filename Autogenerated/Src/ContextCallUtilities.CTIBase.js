define("ContextCallUtilities", ["BPMSoft"],
	function(BPMSoft) {

		/**
		 * @class BPMSoft.configuration.mixins.ContextCallUtilities
		 * ###### ############ ######.
		 * @type {BPMSoft.BaseObject}
		 */
		Ext.define("BPMSoft.configuration.mixins.ContextCallUtilities", {
			extend: "BPMSoft.BaseObject",
			alternateClassName: "BPMSoft.ContextCallUtilities",

			//region Methods: Protected

			/**
			 * ########## ######## ###### ########.
			 * @protected
			 * @param {String} columnName ### #######.
			 * @param {String} entityId ############# ######.
			 * @returns {String} ######## ###### ########. ###### ########, #### ###### # ####### ## ##########.
			 */
			getCustomerNumber: function(columnName, entityId) {
				var gridData = this.getGridData();
				var entity = gridData.find(entityId);
				if (!entity) {
					return;
				}
				return entity.get(columnName);
			},

			/**
			 * ############ ####### ## ###### ## ######## ##### # ##### #######.
			 * @protected
			 * @param {String} rowId ############# ######.
			 * @param {String} columnName ### #######.
			 * @return {Boolean} ########## ####### ######## ## ######.
			 */
			phoneLinkClicked: function(rowId, columnName) {
				if (Ext.isEmpty(columnName)) {
					return false;
				}
				var schemaColumnName = columnName;
				if (columnName.indexOf("on") !== -1 && columnName.indexOf("LinkClick") !== -1) {
					schemaColumnName = columnName.slice("on".length, columnName.length - "LinkClick".length);
				}
				if (Ext.isEmpty(schemaColumnName)) {
					schemaColumnName = columnName;
				}
				var handled = this.callCustomer({
					entityColumnName: schemaColumnName,
					entitySchemaName: this.entitySchemaName,
					entityId: rowId,
					number: this.getCustomerNumber.bind(this, schemaColumnName)
				});
				return handled;
			},

			/**
			 * ######### ########### ######.
			 * @protected
			 * @param {Object} config ############ ########## ############ ######.
			 * @param {String} config.entityColumnName ### ####### #####, ####### ########## ########### ######.
			 * @param {String} config.entitySchemaName ### #####, ####### ########### #######.
			 * @param {String} config.entityId ############# ######.
			 * @param {BPMSoft.Collection} [config.callRelationFields] Collection of call relation fields.
			 * Key - name of the field.Items - objects with properties name, value, type of call relation field.
			 * @param {String|Function} config.number #####, ## ####### ########## ######### ######.
			 * @returns {Boolean} ####### ######### ##########.
			 */
			callCustomer: function(config) {
				var linkColumnUtilities = BPMSoft.LinkColumnUtilities || {};
				var telephonyUtility = linkColumnUtilities.Telephony;
				if (Ext.isEmpty(telephonyUtility)) {
					return false;
				}
				var entityColumnName = config.entityColumnName;
				var entityId = config.entityId;
				var entitySchemaName = config.entitySchemaName;
				var callRelationFields = config.callRelationFields;
				var isTelephonyColumn = telephonyUtility.getIsLinkColumn.call(telephonyUtility,
					entitySchemaName, entityColumnName);
				if (!isTelephonyColumn) {
					return false;
				}
				var number = Ext.isFunction(config.number) ? config.number.call(this, entityId) : config.number;
				if (!number) {
					return false;
				}
				this.sandbox.publish("CallCustomer", {
					number: number,
					customerId: entityId,
					entitySchemaName: entitySchemaName,
					callRelationFields: callRelationFields
				});
				return true;
			}

			//endregion

		});
	}
);
