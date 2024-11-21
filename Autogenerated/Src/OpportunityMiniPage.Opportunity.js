define("OpportunityMiniPage", ["MiniPageResourceUtilities", "OpportunityMiniPageResources",
		"MiniPageDatePeriodGenerator", "css!OpportunityMiniPageCSS"],
	function(miniPageResources, resources) {
		return {
			entitySchemaName: "Opportunity",
			attributes: {
				/**
				 * @inheritdoc BaseMiniPage#MiniPageModes
				 * @overridden
				 */
				"MiniPageModes": {
					"value": [BPMSoft.ConfigurationEnums.CardOperation.VIEW,
						BPMSoft.ConfigurationEnums.CardOperation.ADD
					]
				},

				/**
				 * Last activity in opportunity.
				 * @type {Object}
				 */
				"LastActivity": {
					"dataValueType": BPMSoft.DataValueType.LOOKUP,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"referenceSchemaName": "Activity"
				},

				/**
				 * Last activity result caption in opportunity.
				 * @type {String}
				 */
				"LastActivityCaption": {
					"dataValueType": BPMSoft.DataValueType.TEXT,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"value": ""
				},

				/**
				 * Client multi lookup field.
				 * @type {Object}
				 */
				"Client": {
					"caption": {"bindTo": "Resources.Strings.Client"},
					"dataValueType": BPMSoft.DataValueType.LOOKUP,
					"multiLookupColumns": ["Contact", "Account"],
					"isRequired": true
				},

				/**
				 * Current opportunity
				 * @type {Object}
				 */
				"CurrentOpportunity": {
					"dataValueType": BPMSoft.DataValueType.LOOKUP,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"referenceSchemaName": "Opportunity"
				},

				/**
				 * Primary contact
				 * @type {Object}
				 */
				"PrimaryContact": {
					"dataValueType": BPMSoft.DataValueType.LOOKUP,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"referenceSchemaName": "Contact"
				}
			},
			methods: {
				/**
				 * @inheritDoc BaseMiniPage#init
				 * @overridden
				 */
				init: function() {
					this.callParent(arguments);
					this.initEmailExtendedMenuButtonCollections(["Owner", "Account", "Contact", "PrimaryContact"],
							this.close);
					this.initCallExtendedMenuButtonCollections(["Owner", "Account", "Contact", "PrimaryContact"],
							this.close);
					this.initLinkedEntitiesMenuButtonCollections(["CurrentOpportunity"], this.close);
				},

				/**
				 * @inheritDoc BaseMiniPage#onEntityInitialized
				 * @overridden
				 */
				onEntityInitialized: function() {
					this.set("CurrentOpportunity", {
						value: this.get("Id"),
						displayValue: this.get("Title")
					});
					this.getLastActivity();
					this.getPrimaryContact();
					this.fillEmailExtendedMenuButtonCollections(["Owner", "Account", "Contact"]);
					this.fillCallExtendedMenuButtonCollections(["Owner", "Account", "Contact"]);
					this.fillLinkedEntitiesMenuButtonCollections(["CurrentOpportunity"]);
					this.callParent(arguments);
				},

				/**
				 * Gets opportunity primary contact.
				 * @protected
				 */
				getPrimaryContact: function() {
					var esq = this.getPrimaryContactSelect();
					esq.getEntityCollection(function(response) {
						if (response && response.success) {
							var collection = response.collection;
							if (collection.getCount() > 0) {
								var firstItem = collection.getByIndex(0);
								this.setPrimaryContact(firstItem);
							}
						}
					}, this);
				},

				/**
				 * Gets opportunity primary contact select.
				 * @protected
				 * @return {BPMSoft.EntitySchemaQuery} Primary contact select query.
				 */
				getPrimaryContactSelect: function() {
					var esq = Ext.create("BPMSoft.EntitySchemaQuery", {
						rootSchemaName: "OpportunityContact"
					});
					esq.addColumn("Contact");
					esq.addColumn("Contact.Name", "ContactName");
					esq.filters.add("OpportunityFilter", BPMSoft.createColumnFilterWithParameter(
							BPMSoft.ComparisonType.EQUAL, "Opportunity", this.get("Id")));
					esq.filters.add("IsMainContactFilter", BPMSoft.createColumnFilterWithParameter(
							BPMSoft.ComparisonType.EQUAL, "IsMainContact", 1));
					esq.rowCount = 1;
					return esq;
				},

				/**
				 * Sets primary contact and fill extended menu buttons.
				 * @protected
				 * @param {Object} contact Activity object from response.
				 */
				setPrimaryContact: function(contact) {
					this.set("PrimaryContact", {
						value: contact.get("Contact").value,
						displayValue: contact.get("ContactName")
					});
					this.fillEmailExtendedMenuButtonCollections(["PrimaryContact"]);
					this.fillCallExtendedMenuButtonCollections(["PrimaryContact"]);
				},

				/**
				 * Generates short date.
				 * @protected
				 * @param {DateTime} dateTime Date for convert.
				 * @return {Date} Short date in current culture.
				 */
				getShortDate: function(dateTime) {
					var date = Ext.emptyString;
					if (!Ext.isEmpty(dateTime)) {
						var timeFormat = BPMSoft.Resources.CultureSettings.timeFormat;
						var cultureName = BPMSoft.Resources.CultureSettings.currentCultureName;
						var dueDate = BPMSoft.toLocaleDate(dateTime, cultureName);
						var dueTime = Ext.Date.format(dateTime, timeFormat);
						date = Ext.String.format("{0} {1}", dueDate, dueTime);
					}
					return date;
				},

				/**
				 * Gets last activity from opportunity.
				 * @protected
				 */
				getLastActivity: function() {
					var esq = this.getLastActivitySelect();
					esq.getEntityCollection(function(response) {
						if (response && response.success) {
							var collection = response.collection;
							if (collection.getCount() > 0) {
								var firstItem = collection.getByIndex(0);
								this.setLastActivityAttributes(firstItem);
							}
						}
					}, this);
				},

				/**
				 * Sets last activity attributes.
				 * @protected
				 * @param {Object} activity Activity object from response.
				 */
				setLastActivityAttributes: function(activity) {
					var date = this.getShortDate(activity.get("DueDate"));
					this.set("LastActivityCaption", Ext.String.format(
							this.get("Resources.Strings.LastActivityCaption"), date));
					this.set("LastActivity", {
						value: activity.get("Id"),
						displayValue: Ext.String.format("{0} / {1}", activity.get("CategoryName"),
								activity.get("StatusName"))
					});
				},

				/**
				 * Gets last activity select.
				 * @protected
				 * @return {BPMSoft.EntitySchemaQuery} Last activity select query.
				 */
				getLastActivitySelect: function() {
					var esq = Ext.create("BPMSoft.EntitySchemaQuery", {
						rootSchemaName: "Activity"
					});
					esq.rowCount = 1;
					esq.addColumn("Status.Name", "StatusName");
					esq.addColumn("ActivityCategory.Name", "CategoryName");
					var dueDate = esq.addColumn("DueDate");
					dueDate.orderPosition = 0;
					dueDate.orderDirection = BPMSoft.OrderDirection.DESC;
					this.setLastActivityRequestFilters(esq);
					return esq;
				},

				/**
				 * Sets last activity filters.
				 * @protected
				 * @param {BPMSoft.EntitySchemaQuery} esq Activity select query.
				 * @return {BPMSoft.EntitySchemaQuery} Activity select query with filter.
				 */
				setLastActivityRequestFilters: function(esq) {
					var id = this.get("Id");
					if (!Ext.isEmpty(id)) {
						esq.filters.add("opportunityFilter", BPMSoft.createColumnFilterWithParameter(
							BPMSoft.ComparisonType.EQUAL, "Opportunity", id));
					}
					return esq;
				},

				/**
				 * Returns opportunity mood image url.
				 * @protected
				 * @return {String} Photo image url.
				 */
				getOpportunityMoodImage: function() {
					return (this.get("IsEntityInitialized") && this.isViewMode())
						? this.getLookupImageUrl("Mood")
						: this.getOpportunityMoodDefaultImage();
				},

				/**
				 * Returns opportunity default mood image url.
				 * @private
				 * @return {String} Photo image url.
				 */
				getOpportunityMoodDefaultImage: function() {
					return BPMSoft.ImageUrlBuilder.getUrl(this.get("Resources.Images.DefaultOpportunityMood"));
				},

				/**
				 * Sets column visible if value is not empty and mini page is in view mode.
				 * @param {Object} value Column value.
				 * @private
				 * @return {Boolean} Column visibility.
				 */
				isNotEmptyColumnVisibleInViewMode: function(value) {
					return !Ext.isEmpty(value) && this.isViewMode();
				},

				/**
				 * Sets column visible if value is empty and mini page is in view mode.
				 * @param {Object} value Column value.
				 * @private
				 * @return {Boolean} Column visibility.
				 */
				isEmptyColumnVisibleInViewMode: function(value) {
					return Ext.isEmpty(value) && this.isViewMode();
				}
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"parentName": "HeaderContainer",
					"propertyName": "items",
					"name": "HeaderColumnContainer",
					"values": {
						"itemType": BPMSoft.ViewItemType.LABEL,
						"caption": {"bindTo": "getPrimaryDisplayColumnValue"},
						"labelClass": ["label-in-header-container"],
						"visible": {"bindTo": "isEditMode"}
					},
					"index": 0
				},
				{
					"operation": "merge",
					"name": "MiniPage",
					"values": {
						"classes": {
							"wrapClassName": ["opportunity-mini-page-container"]
						}
					}
				},
				{
					"operation": "merge",
					"name": "RequiredColumnsContainer",
					"values": {
						"classes": {
							"wrapClassName": ["required-columns-container", "grid-layout",
								"opportunity-mini-page-container"]
						}
					}
				},
				{
					"operation": "merge",
					"name": "CloseMiniPageButton",
					"values": {
						"visible": {"bindTo": "isNotViewMode"}
					}
				},
				{
					"operation": "insert",
					"parentName": "HeaderContainer",
					"propertyName": "items",
					"name": "OpportunityMoodContainer",
					"values": {
						"visible": {"bindTo": "isViewMode"},
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["opportunity-photo-container"],
						"items": []
					},
					"index": 0
				},
				{
					"operation": "insert",
					"parentName": "OpportunityMoodContainer",
					"propertyName": "items",
					"name": "MiniPhoto",
					"values": {
						"getSrcMethod": "getOpportunityMoodImage",
						"visible": {"bindTo": "isViewMode"},
						"readonly": true,
						"defaultImage": {"bindTo": "getOpportunityMoodDefaultImage"},
						"generator": "MiniPageViewGenerator.generateRoundImageControl"
					}
				},
				{
					"operation": "insert",
					"name": "ViewTitle",
					"parentName": "HeaderContainer",
					"propertyName": "items",
					"values": {
						"visible": {"bindTo": "isViewMode"},
						"labelConfig": {
							"visible": false
						},
						"bindTo": "Title",
						"isMiniPageModelItem": true
					},
					"index": 1
				},
				{
					"operation": "insert",
					"name": "OpportunityButtonsContainer",
					"parentName": "HeaderContainer",
					"propertyName": "items",
					"values": {
						"visible": {"bindTo": "isViewMode"},
						"wrapClass": ["opportunity-header-buttons"],
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"items": [
							{
								"name": "CurrentOpportunityLinkedEntityButton",
								"itemType": BPMSoft.ViewItemType.BUTTON,
								"imageConfig": miniPageResources.resources.localizableImages.AddButtonImage,
								"extendedMenu": {
									"Name": "LinkedEntities",
									"PropertyName": "CurrentOpportunity",
									"Click": {"bindTo": "prepareLinkedEntitiesButtonMenu"}
								}
							}
						]
					},
					"index": 3
				},
				{
					"operation": "insert",
					"parentName": "MiniPage",
					"propertyName": "items",
					"name": "Client",
					"values": {
						"visible": {"bindTo": "isNotViewMode"},
						"tip": {
							"content": {"bindTo": "Resources.Strings.ClientTip"}
						},
						"controlWrapConfig": {
							"classes": {"wrapClassName": ["client-edit-field"]}
						},
						"dataValueType": BPMSoft.DataValueType.ENUM,
						"controlConfig": {
							"enableLeftIcon": true,
							"focused": true,
							"leftIconConfig": {"bindTo": "getMultiLookupIconConfig"}
						},
						"layout": {"column": 0, "row": 1, "colSpan": 24},
						"isMiniPageModelItem": true,
						"placeholder": "Введите клиента"
					}
				},
				{
					"operation": "insert",
					"name": "Title",
					"parentName": "MiniPage",
					"propertyName": "items",
					"values": {
						"visible": {"bindTo": "isNotViewMode"},
						"layout": {"column": 0, "row": 2, "colSpan": 24},
						"placeholder": "Название продажи"
					}
				},
				{
					"operation": "insert",
					"name": "Stage",
					"parentName": "MiniPage",
					"propertyName": "items",
					"values": {
						"labelConfig": {
							"visible": {"bindTo": "isNotViewMode"}
						},
						"dataValueType": BPMSoft.DataValueType.ENUM,
						"layout": {"column": 0, "row": 3, "colSpan": 24},
						"isMiniPageModelItem": true
					}
				},
				{
					"operation": "insert",
					"name": "Budget",
					"parentName": "MiniPage",
					"propertyName": "items",
					"values": {
						"wrapClass": ["number-control-wrap"],
						"dataValueType": BPMSoft.DataValueType.MONEY,
						"layout": {"column": 0, "row": 4, "colSpan": 24},
						"isMiniPageModelItem": true,
						"placeholder": "0.00"
					}
				},
				{
					"operation": "insert",
					"name": "Account",
					"parentName": "MiniPage",
					"propertyName": "items",
					"values": {
						"visible": {
							"bindTo": "Account",
							"bindConfig": {
								converter: "isNotEmptyColumnVisibleInViewMode"
							}
						},
						"layout": {"column": 0, "row": 5, "colSpan": 18},
						"labelConfig": {
							"caption": {"bindTo": "Resources.Strings.Client"}
						},
						"isMiniPageModelItem": true
					}
				},
				{
					"operation": "insert",
					"name": "AccountContainer",
					"parentName": "MiniPage",
					"propertyName": "items",
					"values": {
						"visible": {
							"bindTo": "Account",
							"bindConfig": {
								converter: "isNotEmptyColumnVisibleInViewMode"
							}
						},
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"layout": {"column": 18, "row": 5, "colSpan": 6},
						"items": [
							{
								"name": "AccountClientCallButton",
								"itemType": BPMSoft.ViewItemType.BUTTON,
								"imageConfig": miniPageResources.resources.localizableImages.CallButtonImage,
								"extendedMenu": {
									"Name": "Call",
									"PropertyName": "Account",
									"Click": {"bindTo": "prepareCallButtonMenu"}
								}
							},
							{
								"name": "AccountClientEmailButton",
								"itemType": BPMSoft.ViewItemType.BUTTON,
								"imageConfig": miniPageResources.resources.localizableImages.EmailButtonImage,
								"extendedMenu": {
									"Name": "Email",
									"PropertyName": "Account",
									"Click": {"bindTo": "prepareEmailButtonMenu"}
								}
							}
						]
					}
				},
				{
					"operation": "insert",
					"name": "Contact",
					"parentName": "MiniPage",
					"propertyName": "items",
					"values": {
						"visible": {
							"bindTo": "Account",
							"bindConfig": {
								converter: "isEmptyColumnVisibleInViewMode"
							}
						},
						"layout": {"column": 0, "row": 6, "colSpan": 18},
						"labelConfig": {
							"caption": {"bindTo": "Resources.Strings.Client"}
						},
						"isMiniPageModelItem": true
					}
				},
				{
					"operation": "insert",
					"name": "ContactContainer",
					"parentName": "MiniPage",
					"propertyName": "items",
					"values": {
						"visible": {
							"bindTo": "Account",
							"bindConfig": {
								converter: "isEmptyColumnVisibleInViewMode"
							}
						},
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"layout": {"column": 18, "row": 6, "colSpan": 6},
						"items": [
							{
								"name": "ContactClientEmailButton",
								"itemType": BPMSoft.ViewItemType.BUTTON,
								"imageConfig": miniPageResources.resources.localizableImages.EmailButtonImage,
								"extendedMenu": {
									"Name": "Email",
									"PropertyName": "Contact",
									"Click": {"bindTo": "prepareEmailButtonMenu"}
								}
							},
							{
								"name": "ContactClientCallButton",
								"itemType": BPMSoft.ViewItemType.BUTTON,
								"imageConfig": miniPageResources.resources.localizableImages.CallButtonImage,
								"extendedMenu": {
									"Name": "Call",
									"PropertyName": "Contact",
									"Click": {"bindTo": "prepareCallButtonMenu"}
								}
							},
						]
					}
				},
				{
					"operation": "insert",
					"name": "Owner",
					"parentName": "MiniPage",
					"propertyName": "items",
					"values": {
						"visible": {"bindTo": "isViewMode"},
						"layout": {"column": 0, "row": 7, "colSpan": 18},
						"isMiniPageModelItem": true
					}
				},
				{
					"operation": "insert",
					"name": "OwnerButtonContainer",
					"parentName": "MiniPage",
					"propertyName": "items",
					"values": {
						"visible": {"bindTo": "isViewMode"},
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"layout": {"column": 18, "row": 7, "colSpan": 6},
						"items": [
							{
								"name": "OwnerCallButton",
								"itemType": BPMSoft.ViewItemType.BUTTON,
								"imageConfig": miniPageResources.resources.localizableImages.CallButtonImage,
								"extendedMenu": {
									"Name": "Call",
									"PropertyName": "Owner",
									"Click": {"bindTo": "prepareCallButtonMenu"}
								}
							},
							{
								"name": "OwnerEmailButton",
								"itemType": BPMSoft.ViewItemType.BUTTON,
								"imageConfig": miniPageResources.resources.localizableImages.EmailButtonImage,
								"extendedMenu": {
									"Name": "Email",
									"PropertyName": "Owner",
									"Click": {"bindTo": "prepareEmailButtonMenu"}
								}
							}
						]
					}
				},
				{
					"operation": "insert",
					"name": "PrimaryContact",
					"parentName": "MiniPage",
					"propertyName": "items",
					"values": {
						"visible": {"bindTo": "isViewMode"},
						"layout": {"column": 0, "row": 8, "colSpan": 18},
						"labelConfig": {
							"caption": {"bindTo": "Resources.Strings.PrimaryContact"}
						},
						"isMiniPageModelItem": true
					}
				},
				{
					"operation": "insert",
					"name": "PrimaryContactButtonContainer",
					"parentName": "MiniPage",
					"propertyName": "items",
					"values": {
						"visible": {"bindTo": "isViewMode"},
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"layout": {"column": 18, "row": 8, "colSpan": 6},
						"items": [
							{
								"name": "PrimaryContactCallButton",
								"itemType": BPMSoft.ViewItemType.BUTTON,
								"imageConfig": miniPageResources.resources.localizableImages.CallButtonImage,
								"extendedMenu": {
									"Name": "Call",
									"PropertyName": "PrimaryContact",
									"Click": {"bindTo": "prepareCallButtonMenu"}
								}
							},
							{
								"name": "PrimaryContactEmailButton",
								"itemType": BPMSoft.ViewItemType.BUTTON,
								"imageConfig": miniPageResources.resources.localizableImages.EmailButtonImage,
								"extendedMenu": {
									"Name": "Email",
									"PropertyName": "PrimaryContact",
									"Click": {"bindTo": "prepareEmailButtonMenu"}
								}
							}
						]
					}
				},
				{
					"operation": "insert",
					"name": "LastActivity",
					"parentName": "MiniPage",
					"propertyName": "items",
					"values": {
						"visible": {
							"bindTo": "LastActivity",
							"bindConfig": {
								converter: "isNotEmptyColumnVisibleInViewMode"
							}
						},
						"bindTo": "LastActivity",
						"layout": {"column": 0, "row": 9, "colSpan": 24},
						"labelConfig": {
							"caption": {"bindTo": "LastActivityCaption"}
						},
						"isMiniPageModelItem": true
					}
				}
			]/**SCHEMA_DIFF*/
		};
	});
