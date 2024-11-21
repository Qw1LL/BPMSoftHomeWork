define("EmailExtendedMenu", ["ConfigurationConstants", "ConfigurationEnums", "EmailConstants", "EmailHelper",
		"BaseExtendedMenu", "EmailLinksMixin"],
	function(ConfigurationConstants, ConfigurationEnums, EmailConstants, EmailHelper) {

		Ext.define("BPMSoft.configuration.mixins.EmailExtendedMenu", {
			extend: "BPMSoft.BaseExtendedMenu",
			alternateClassName: "BPMSoft.EmailExtendedMenu",
			mixins: {
				emailLinksMixin: "BPMSoft.EmailLinksMixin"
			},

			/**
			 * Initialize email extended menu collection.
			 * @protected
			 * @param {Array} recipientPropertyNames Extended menu name collection.
			 * @param {Function} afterEmailMenuItemClick Calls after menu item click.
			 */
			initEmailExtendedMenuButtonCollections: function(recipientPropertyNames, afterEmailMenuItemClick) {
				this.initExtendedMenuButtonCollections("Email", recipientPropertyNames, afterEmailMenuItemClick);
				this.initSyncMailboxCount();
			},

			/**
			 * Fill email extended menu.
			 * @protected
			 * @param {Array} recipientPropertyNames Extended menu name collection.
			 * @param {Function} [callback] Callback function.
			 * @param {Object} [scope] Execution context.
			 */
			fillEmailExtendedMenuButtonCollections: function(recipientPropertyNames, callback, scope) {
				recipientPropertyNames.forEach(function(item) {
					this.prepareEmailButtonMenu(item, callback, scope);
				}, this);
			},

			/**
			 * Prepare email extended menu item.
			 * @protected
			 * @param {String} item Extended menu name.
			 * @param {Function} [callback] Callback function.
			 * @param {Object} [scope] Execution context.
			 */
			prepareEmailButtonMenu: function(item, callback, scope) {
				var recipientInfo = this.fillExtendedMenuItems("Email", item);
				if (recipientInfo && !this.isAddMode()) {
					this.getEmailsData(recipientInfo, function(emailsData, recipientInfo) {
						this.fillEmailExtendedMenuData.apply(this, arguments);
						if (callback) {
							callback.call(scope || this, recipientInfo.MenuName, recipientInfo.PropertyName);
						}
					}, this);
				}
			},

			/**
			 * Get recipient email data.
			 * @protected
			 * @param {Object} recipientInfo Recepient information.
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Execution context.
			 */
			getEmailsData: function(recipientInfo, callback, scope) {
				var esq = this.getEmailsEntitySchemaQuery(recipientInfo.SchemaName);
				this.addEmailsQueryFilters(esq, recipientInfo);
				esq.getEntityCollection(function(response) {
					if (response.success && callback) {
						callback.call(scope || this, response, recipientInfo);
					}
				}, this);
			},

			/**
			 * Returns esq for getting emails communication.
			 * @protected
			 * @param  {String} schemaName Schema name.
			 * @return {BPMSoft.EntitySchemaQuery} Entity schema query for getting emails communication.
			 */
			getEmailsEntitySchemaQuery: function(schemaName) {
				var esq = this.Ext.create("BPMSoft.EntitySchemaQuery", {
					rootSchemaName: schemaName + "Communication"
				});
				esq.addColumn("Number");
				return esq;
			},

			/**
			 * Adds filters to entity schema query for getting emails communication.
			 * @protected
			 * @param {BPMSoft.EntitySchemaQuery} esq Entity schema query.
			 * @param {Object} recipientInfo Recipient information.
			 */
			addEmailsQueryFilters: function(esq, recipientInfo) {
				esq.filters.add(recipientInfo.SchemaName + "Filter", this.BPMSoft.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.EQUAL, recipientInfo.SchemaName, recipientInfo.Id));
				esq.filters.add("EmailCommunicationFilter", this.BPMSoft.createColumnInFilterWithParameters(
						"CommunicationType", [ConfigurationConstants.CommunicationTypes.Email]));
			},

			/**
			 * Fill the menu values.
			 * @protected
			 * @param {Object} emailsData Emails data.
			 * @param {Object} recipientInfo Recipient information.
			 */
			fillEmailExtendedMenuData: function(emailsData, recipientInfo) {
				if (emailsData) {
					var emailCollection = this.generateEmailCollection(emailsData, recipientInfo);
					this.fillExtendedMenuData(emailCollection, recipientInfo, this.extendedEmailMenuItemClick);
					this.addActivityPrimaryValueExtendedMenu(emailsData, recipientInfo);
				}
			},

			/**
			 * Adds activity primary value to extended menu items.
			 * @protected
			 * @param {Object} emailsData Emails data.
			 * @param {Object} recipientInfo Recipient information.
			 */
			addActivityPrimaryValueExtendedMenu: function(emailsData, recipientInfo) {
				if (emailsData) {
					let extendedMenuItems = this.get(recipientInfo.ExtendedMenuCollectionName);
					BPMSoft.each(extendedMenuItems, function(item) {
						let tag = item.$Tag;
						if (tag) {
							let itemTag = tag.itemTag;
							if (itemTag) {
								itemTag.activityId = this.$Id;
							}
						}
					}, this);
				}
			},

			/**
			 * Returns array of emails.
			 * @protected
			 * @param {Object} data Emails data.
			 * @param {Object} recipientInfo Recepient information.
			 * @return {Array} Array of emails.
			 */
			generateEmailCollection: function(data, recipientInfo) {
				var emailCollection = [];
				if (data.collection && data.collection.getCount() > 0) {
					data.collection.each(function(item) {
						var email = item.get("Number");
						var emailWithName = "";
						var detailName = "Current" + recipientInfo.SchemaName;
						var propertyName = recipientInfo.PropertyName === detailName ? this.primaryDisplayColumnName : recipientInfo.PropertyName;
						emailWithName = EmailHelper.getEmailWithName(email, this.get(propertyName));
						emailCollection.push({
							caption: email,
							tag: {
								schemaName: recipientInfo.SchemaName,
								recordId: recipientInfo.Id,
								email: email,
								emailWithName: emailWithName
							}
						});
					}, this);
				}
				return emailCollection;
			},

			/**
			 * Prepare card config.
			 * @protected
			 * @param {Object} emailConfig Email information.
			 * @param {Function} callback Callback function.
			 */
			extendedEmailMenuItemClick: function(emailConfig, callback) {
				this.emailLinkClicked(emailConfig, callback);
			},

			/**
			 * Returns recipient email esq.
			 * @protected
			 * @return {BPMSoft.EntitySchemaQuery} Entity schema query for getting recipient email.
			 */
			getRecipientEmailQuery: function() {
				var esq = this.Ext.create("BPMSoft.EntitySchemaQuery", {
					rootSchemaName: "VwRecepientEmail"
				});
				esq.addColumn("[Contact:Id:ContactId].Id", "ContactId");
				esq.addColumn("[Contact:Id:ContactId].Name", "ContactName");
				esq.addColumn("Email");
				return esq;
			},

			/**
			 * Adds filters to entity schema query for getting recipient email.
			 * @protected
			 * @param {BPMSoft.EntitySchemaQuery} esq Entity schema query.
			 * @param {String} email Email.
			 */
			addRecipientEmailFilters: function(esq, email) {
				esq.filters.add("RecepientEmailFilter", this.BPMSoft.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.EQUAL, "Number", email));
			},

			/**
			 * Open email activity page with filled default values.
			 * @protected
			 * @param {Object} emailConfig Email information.
			 * @param {Object} cardConfig Card information.
			 * @param {Function} callback Callback function.
			 */
			openEmailCardWithValues: function(emailConfig, cardConfig, callback) {
				var esq = this.getRecipientEmailQuery();
				this.addRecipientEmailFilters(esq, emailConfig.email);
				esq.getEntityCollection(function(response) {
					if (response.success && response.collection && response.collection.getCount() > 0) {
						var item = response.collection.getByIndex(0);
						var valuePairs = [{
							name: "Recepient",
							value: item.get("Email")
						}, {
							name: "Type",
							value: ConfigurationConstants.Activity.Type.Email
						}, {
							name: emailConfig.schemaName,
							value: emailConfig.recordId
						}];
						this.openCard(cardConfig, valuePairs);
						if (this.Ext.isFunction(callback)) {
							callback.call(this);
						}
					}
				}, this);
			}
		});
	});
