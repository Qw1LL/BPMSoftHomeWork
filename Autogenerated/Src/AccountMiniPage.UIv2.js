define("AccountMiniPage", ["MiniPageResourceUtilities", "AccountMiniPageResources", "css!AccountMiniPageCSS",
	"AccountPageMixin"],
	function(miniPageResources) {
		return {
			entitySchemaName: "Account",
			details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
			messages: {},
			mixins: {
				/**
				 * @class AccountPageMixin Mixin, implements common business logic for Account.
				 */
				AccountPageMixin: "BPMSoft.AccountPageMixin"
			},
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
				 * Object with current account information.
				 */
				"CurrentAccount": {
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					referenceSchemaName: "Account"
				},

				/**
				 * Object with account full address (Address, City, Country, Zip).
				 */
				"FullAddress": {
					dataValueType: BPMSoft.DataValueType.TEXT,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				}
			},
			methods: {

				/**
				 * @inheritDoc BaseMiniPage#init
				 * @protected
				 * @overridden
				 */
				init: function() {
					this.callParent(arguments);
					this.initEmailExtendedMenuButtonCollections(["CurrentAccount", "Owner", "PrimaryContact"],
						this.close);
					this.initCallExtendedMenuButtonCollections(["CurrentAccount", "Owner", "PrimaryContact"],
						this.close);
					this.initLinkedEntitiesMenuButtonCollections(["CurrentAccount"], this.close);
				},

				/**
				 * @inheritDoc BaseMiniPage#onEntityInitialized
				 * @protected
				 * @overridden
				 */
				onEntityInitialized: function() {
					this.set("CurrentAccount", {
						value: this.get("Id"),
						displayValue: this.get("Name")
					});
					this.initFullAddressInMiniPage();
					this.fillEmailExtendedMenuButtonCollections(["CurrentAccount", "Owner", "PrimaryContact"]);
					this.fillCallExtendedMenuButtonCollections(["CurrentAccount", "Owner", "PrimaryContact"]);
					this.fillLinkedEntitiesMenuButtonCollections(["CurrentAccount"]);
					this.callParent(arguments);
				},

				/**
				 * Builds FullAddress like Address + City + Country + Zip.
				 */
				initFullAddressInMiniPage: function() {
					var fullAddress = "";
					var city = this.get("City") ? this.get("City").displayValue : "";
					var country = this.get("Country") ? this.get("Country").displayValue : "";
					var addressParts = [this.get("Address"), city, country, this.get("Zip")];
					addressParts.forEach(function(addressPart) {
						if (!Ext.isEmpty(addressPart)) {
							fullAddress += this.Ext.isEmpty(fullAddress) ? "" : ", ";
							fullAddress += addressPart;
						}
					});
					this.set("FullAddress", fullAddress);
				},

				/**
				 * Returns true if entity have PrimaryContact.
				 * @return {Boolean} True if PrimaryContact has value.
				 */
				isPrimaryContactExist: function() {
					return this.get("PrimaryContact") && this.get("PrimaryContact").displayValue ? true : false;
				},

				/**
				 * Returns true if entity have Owner.
				 * @return {Boolean} True if Owner has value.
				 */
				isOwnerExist: function() {
					return this.get("Owner") && this.get("Owner").displayValue ? true : false;
				},

				/**
				 * Return account photo image url.
				 * @return {String} Photo image url.
				 */
				getAccountImage: function() {
					var primaryImageColumnValue = this.get(this.primaryImageColumnName);
					if (primaryImageColumnValue) {
						return this.getSchemaImageUrl(primaryImageColumnValue);
					}
					return this.getAccountDefaultImage();
				},

				/**
				 * Return account default photo image url.
				 * @protected
				 * @virtual
				 * @return {String} Photo image url.
				 */
				getAccountDefaultImage: function() {
					return BPMSoft.ImageUrlBuilder.getUrl(this.get("Resources.Images.DefaultPhoto"));
				},

				/**
				 * @inheritDoc BaseMiniPage#onSaved
				 * @protected
				 * @overridden
				 */
				onSaved: function(callback, scope) {
					this.callParent([
						function() {
							this.updatePrimaryContact(function() {
								this.Ext.callback(callback, scope);
							}, this);
						}, this
					]);
				},

				/**
				 * Updates primary contact.
				 * @private
				 * @param {Function} callback Callback function.
				 * @param {Object} scope Callback function context.
				 */
				updatePrimaryContact: function(callback, scope) {
					var primaryContact = this.get("PrimaryContact");
					if (!primaryContact) {
						this.Ext.callback(callback, scope);
						return;
					}
					this.getPrimaryContactAccount(function(account) {
						var recordId = this.get("Id");
						var primaryContactAccountId = account && account.value;
						if (primaryContactAccountId === recordId) {
							this.Ext.callback(callback, scope);
						} else {
							var careerConfig = {
								contactId: primaryContact.value,
								isPrimary: false,
								isCurrent: true
							};
							this.addContactCareer(callback, careerConfig, scope);
						}
					}, this);
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
							"wrapClassName": ["account-mini-page-container"]
						}
					}
				},
				{
					"operation": "merge",
					"name": "RequiredColumnsContainer",
					"values": {
						"classes": {
							"wrapClassName": ["required-columns-container", "grid-layout",
								"account-mini-page-container"]
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "HeaderContainer",
					"propertyName": "items",
					"name": "PhotoContainer",
					"values": {
						"visible": {"bindTo": "isViewMode"},
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["account-photo-container"],
						"items": []
					},
					"index": 0
				},
				{
					"operation": "insert",
					"name": "NameInViewMode",
					"parentName": "HeaderContainer",
					"propertyName": "items",
					"values": {
						"bindTo": "Name",
						"visible": {"bindTo": "isViewMode"},
						"labelConfig": {
							"visible": false
						},
						"isMiniPageModelItem": true
					},
					"index": 1
				},
				{
					"operation": "insert",
					"parentName": "PhotoContainer",
					"propertyName": "items",
					"name": "MiniPhoto",
					"values": {
						"getSrcMethod": "getAccountImage",
						"readonly": true,
						"defaultImage": {"bindTo": "getAccountDefaultImage"},
						"generator": "MiniPageViewGenerator.generateRoundImageControl"
					}
				},
				{
					"operation": "insert",
					"name": "HeaderButtonsContainer",
					"parentName": "PhotoContainer",
					"propertyName": "items",
					"values": {
						"wrapClass": ["account-header-buttons"],
						"visible": {"bindTo": "isViewMode"},
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"items": []
					},
					"index": 1
				},
				{
					"operation": "insert",
					"name": "CurrentAccountCallButton",
					"parentName": "HeaderButtonsContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"imageConfig": miniPageResources.resources.localizableImages.CallButtonImage,
						"extendedMenu": {
							"Name": "Call",
							"PropertyName": "CurrentAccount",
							"Click": {"bindTo": "prepareCallButtonMenu"}
						}
					},
					"index": 1
				},
				{
					"operation": "insert",
					"parentName": "HeaderButtonsContainer",
					"propertyName": "items",
					"name": "CurrentAccountEmailButton",
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"imageConfig": miniPageResources.resources.localizableImages.EmailButtonImage,
						"extendedMenu": {
							"Name": "Email",
							"PropertyName": "CurrentAccount",
							"Click": {"bindTo": "prepareEmailButtonMenu"}
						}
					},
					"index": 0
				},
				{
					"operation": "insert",
					"parentName": "HeaderButtonsContainer",
					"propertyName": "items",
					"name": "CurrentAccountLinkedEntityButton",
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"imageConfig": miniPageResources.resources.localizableImages.AddButtonImage,
						"extendedMenu": {
							"Name": "LinkedEntities",
							"PropertyName": "CurrentAccount",
							"Click": {"bindTo": "prepareLinkedEntitiesButtonMenu"}
						}
					},
					"index": 2
				},
				{
					"operation": "insert",
					"name": "OpenCurrentEntityPageInViewMode",
					"parentName": "HeaderButtonsContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"imageConfig": {
							"bindTo": "Resources.Images.OpenCurrentEntityPageImage"
						},
						"click": {"bindTo": "openCurrentEntityPage"}
					}
				},
				{
					"operation": "move",
					"name": "OpenEditMode",
					"parentName": "HeaderButtonsContainer",
					"propertyName": "items"
				},
				{
					"operation": "insert",
					"name": "WebContainer",
					"parentName": "MiniPage",
					"propertyName": "items",
					"values": {
						"visible": {"bindTo": "isViewMode"},
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"items": [],
						"layout": {
							"column": 0,
							"row": 1,
							"colSpan": 24
						}
					}
				},
				{
					"operation": "insert",
					"name": "Web",
					"parentName": "WebContainer",
					"propertyName": "items",
					"values": {
						"visible": {"bindTo": "isViewMode"},
						"itemType": BPMSoft.ViewItemType.HYPERLINK,
						"target": BPMSoft.controls.HyperlinkEnums.target.BLANK,
						"caption": {
							"bindTo": "Web"
						},
						"click": {
							"bindTo": "onExternalLinkClick"
						},
						"tag": "Web"
					}
				},
				{
					"operation": "insert",
					"name": "FullAddress",
					"parentName": "MiniPage",
					"propertyName": "items",
					"values": {
						"visible": {"bindTo": "isViewMode"},
						"bindTo": "FullAddress",
						"layout": {
							"column": 0,
							"row": 2,
							"colSpan": 24
						},
						"labelConfig": {
							"visible": false
						},
						"isMiniPageModelItem": true
					}
				},
				{
					"operation": "insert",
					"name": "Owner",
					"parentName": "MiniPage",
					"propertyName": "items",
					"values": {
						"bindTo": "Owner",
						"visible": {"bindTo": "isViewMode"},
						"labelConfig": {
							"useColon": true
						},
						"layout": {
							"column": 0,
							"row": 3,
							"colSpan": 18
						},
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
						"wrapClass": ["buttons-container"],
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"items": [],
						"layout": {
							"column": 18,
							"row": 3,
							"colSpan": 6
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "OwnerButtonContainer",
					"propertyName": "items",
					"name": "OwnerCallButton",
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"imageConfig": miniPageResources.resources.localizableImages.CallButtonImage,
						"extendedMenu": {
							"Name": "Call",
							"PropertyName": "Owner",
							"Click": {"bindTo": "prepareCallButtonMenu"}
						}
					},
					"index": 2
				},
				{
					"operation": "insert",
					"parentName": "OwnerButtonContainer",
					"propertyName": "items",
					"name": "OwnerEmailButton",
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"imageConfig": miniPageResources.resources.localizableImages.EmailButtonImage,
						"extendedMenu": {
							"Name": "Email",
							"PropertyName": "Owner",
							"Click": {"bindTo": "prepareEmailButtonMenu"}
						}
					},
					"index": 3
				},
				{
					"operation": "insert",
					"name": "PrimaryContact",
					"parentName": "MiniPage",
					"propertyName": "items",
					"values": {
						"bindTo": "PrimaryContact",
						"visible": {"bindTo": "isViewMode"},
						"labelConfig": {
							"useColon": true
						},
						"layout": {
							"column": 0,
							"row": 4,
							"colSpan": 18
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
						"wrapClass": ["buttons-container"],
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"items": [],
						"layout": {
							"column": 18,
							"row": 4,
							"colSpan": 6
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "PrimaryContactButtonContainer",
					"propertyName": "items",
					"name": "PrimaryContactCallButton",
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"imageConfig": miniPageResources.resources.localizableImages.CallButtonImage,
						"extendedMenu": {
							"Name": "Call",
							"PropertyName": "PrimaryContact",
							"Click": {"bindTo": "prepareCallButtonMenu"}
						}
					},
					"index": 2
				},
				{
					"operation": "insert",
					"parentName": "PrimaryContactButtonContainer",
					"propertyName": "items",
					"name": "PrimaryContactEmailButton",
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"imageConfig": miniPageResources.resources.localizableImages.EmailButtonImage,
						"extendedMenu": {
							"Name": "Email",
							"PropertyName": "PrimaryContact",
							"Click": {"bindTo": "prepareEmailButtonMenu"}
						}
					},
					"index": 3
				},
				{
					"operation": "merge",
					"name": "CloseMiniPageButton",
					"values": {
						"visible": {"bindTo": "isNotViewMode"}
					}
				},
				{
					"operation": "merge",
					"name": "OpenCurrentEntityPage",
					"values": {
						"visible": {"bindTo": "isNotViewMode"}
					}
				},
				{
					"operation": "merge",
					"name": "SaveEditButton",
					"values": {
						"visible": {"bindTo": "isNotViewMode"}
					}
				},
				{
					"operation": "merge",
					"name": "CancelEditButton",
					"values": {
						"visible": {"bindTo": "isNotViewMode"}
					}
				},
				{
					"operation": "insert",
					"parentName": "MiniPage",
					"propertyName": "items",
					"name": "MiniPageEditModeContainer",
					"values": {
						"visible": {"bindTo": "isNotViewMode"},
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"items": [],
						"layout": {
							"column": 0,
							"row": 5,
							"colSpan": 24
						}
					}
				},
				{
					"operation": "insert",
					"name": "NameInAddMode",
					"parentName": "MiniPageEditModeContainer",
					"propertyName": "items",
					"values": {
						"visible": {"bindTo": "isNotViewMode"},
						"bindTo": "Name",
						"layout": {
							"column": 0,
							"row": 0,
							"colSpan": 24
						},
						"controlConfig": {
							"focused": true
						},
						"isMiniPageModelItem": true
					}
				},
				{
					"operation": "insert",
					"name": "PrimaryContactEdit",
					"parentName": "MiniPageEditModeContainer",
					"propertyName": "items",
					"values": {
						"visible": {"bindTo": "isNotViewMode"},
						"bindTo": "PrimaryContact",
						"dataValueType": BPMSoft.DataValueType.ENUM,
						"layout": {
							"column": 0,
							"row": 1,
							"colSpan": 24
						},
						"isMiniPageModelItem": true
					}
				},
				{
					"operation": "insert",
					"name": "Phone",
					"parentName": "MiniPageEditModeContainer",
					"propertyName": "items",
					"values": {
						"className": "BPMSoft.PhoneEdit",
						"visible": {"bindTo": "isNotViewMode"},
						"bindTo": "Phone",
						"layout": {
							"column": 0,
							"row": 2,
							"colSpan": 24
						},
						"isMiniPageModelItem": true
					}
				},
				{
					"operation": "insert",
					"name": "WebInEditMode",
					"parentName": "MiniPageEditModeContainer",
					"propertyName": "items",
					"values": {
						"visible": {"bindTo": "isNotViewMode"},
						"bindTo": "Web",
						"isMiniPageModelItem": true,
						"layout": {
							"column": 0,
							"row": 3,
							"colSpan": 24
						}
					}
				},
				{
					"operation": "insert",
					"name": "OwnerEdit",
					"parentName": "MiniPageEditModeContainer",
					"propertyName": "items",
					"values": {
						"bindTo": "Owner",
						"visible": {"bindTo": "getAdditionalColumnVisibility"},
						"layout": {
							"column": 0,
							"row": 4,
							"colSpan": 24
						},
						"tag": "Owner",
						"isMiniPageModelItem": true
					}
				}
			]/**SCHEMA_DIFF*/
		};
	});
