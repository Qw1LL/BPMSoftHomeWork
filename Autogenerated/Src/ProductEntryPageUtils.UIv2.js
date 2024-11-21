define("ProductEntryPageUtils", ["BPMSoft", "ProductEntryPageUtilsResources"],
		function() {
			var productEntryPageUtilsClass = Ext.define("BPMSoft.configuration.mixins.ProductEntryPageUtils", {
				alternateClassName: "BPMSoft.ProductEntryPageUtils",

				/**
				 * ######### ####### # ###### # ######.
				 * @protected
				 * @virtual
				 * @param {BPMSoft.EntitySchemaQuery} esq ###### # ####### ####### entity #####.
				 */
				modifyAmountESQ: function(esq) {
					esq.addColumn("Amount");
					esq.addColumn("PrimaryAmount");
				},

				/**
				 * ######## ######## ##### # ###### ## ##.
				 * @protected
				 * @virtual
				 * @param {BPMSoft.BaseModel} entity ###### # ########### ########## ####.
				 */
				updateAmountColumnValues: function(entity) {
					var updatedAmount = entity.get("Amount");
					var updatedPrimaryAmount = entity.get("PrimaryAmount");
					if (updatedAmount !== this.get("Amount") ||
							updatedPrimaryAmount !== this.get("PrimaryAmount")) {
						this.set("Amount", updatedAmount);
						this.set("PrimaryAmount", updatedPrimaryAmount);
					}
				},

				/**
				 * ######### ####### ###### ## ##.
				 * @protected
				 * @param {Function} [callback] ####### ######### ######.
				 * @param {Object} [scope] ######## ##########.
				 */
				updateAmountFromDB: function(callback, scope) {
					var select = this.Ext.create("BPMSoft.EntitySchemaQuery", {
						rootSchemaName: this.entitySchemaName
					});
					select.addColumn("Id");
					this.modifyAmountESQ(select);
					select.getEntity(this.get("Id"), function(result) {
						var entity = result.entity;
						if (result.success && entity) {
							this.updateAmountColumnValues(entity);
							if (callback) {
								callback.call(scope || this);
							}
						} else {
							var errorInfo = result.errorInfo;
							throw new BPMSoft.UnknownException({
								message: errorInfo.message
							});
						}
					}, this);
				},

				/**
				 * ######### ##### ##### ## ## ##### ###. ##########,
				 * @protected
				 * @param {Function} [callback] ####### ######### ######.
				 * @param {Object} [scope] ######## ##########.
				 */
				updateAmount: function(callback, scope) {
					if (this.get("ShowSaveButton")) {
						this.updateAmountFromDB(callback, scope);
					} else {
						if (!this.isNewMode()) {
							this.set("IsEntityInitialized", false);
							this.loadEntity(this.get("Id"), function() {
								this.set("IsEntityInitialized", true);
								this.sendSaveCardModuleResponse(true);
								if (callback) {
									callback.call(scope || this);
								}
							}, this);
						}
					}
				},

				/**
				 * ######### ############# ########## ######
				 * @protected
				 * @virtual
				 * @param {String} detailName ######## ######.
				 * @param {Function} [callback] ####### ######### ######.
				 * @param {Object} [scope] ######## ##########.
				 */
				updateAmountAfterSave: function(detailName, callback, scope) {
					this.updateDetail({ detail: detailName });
					this.updateAmount(callback, scope);
				}
			});
			return Ext.create(productEntryPageUtilsClass);
		});
