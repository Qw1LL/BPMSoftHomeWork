define("CtiPanel", ["BPMSoft", "ProcessModuleUtilities", "CtiConstants", "CtiPanelResources",
		"ContainerListGenerator", "css!CTIProcessActionsCSS"],
	function(BPMSoft, ProcessModuleUtilities, CtiConstants, Resources) {
		return {
			attributes: {
				/**
				 * ######### ####### ######## ####### ######### cti ######.
				 * @private
				 * @type {BPMSoft.Collection}
				 */
				"ProcessActionsCollection": {
					"dataValueType": BPMSoft.DataValueType.COLLECTION
				},

				/**
				 * ######### ######## ####### #########.
				 * @private
				 * @type {Boolean}
				 */
				"IsProcessActionExists": {
					"dataValueType": BPMSoft.DataValueType.BOOLEAN,
					"value": false
				},

				/**
				 * ####### ####, ### ####### ########## - ######## ####### ######.
				 * @private
				 * @type {Boolean}
				 */
				"IsCurrentUserContactCenterOperator": {
					"dataValueType": BPMSoft.DataValueType.BOOLEAN,
					"value": false
				}
			},
			methods: {

				//region Methods: Private

				/**
				 * ############# ######### ###### ######## ## ####### #########.
				 * @private
				 * @param {Function} callback ####### ######### ######.
				 */
				setProcessActionsVisibility: function(callback) {
					BPMSoft.SysSettings.querySysSettings(["ContactCenterOperatorsFolder"],
						function(sysSettingsValue) {
							var contactCenterOperatorsFolder = sysSettingsValue.ContactCenterOperatorsFolder;
							if (Ext.isEmpty(contactCenterOperatorsFolder)) {
								return;
							}
							var esq = Ext.create("BPMSoft.EntitySchemaQuery", {
								rootSchemaName: "SysUserInRole"
							});
							esq.addAggregationSchemaColumn("Id", BPMSoft.AggregationType.COUNT, "Count");
							esq.filters.add("ContactCenterOperatorsFilter", BPMSoft.createColumnFilterWithParameter(
								BPMSoft.ComparisonType.EQUAL, "SysRole", contactCenterOperatorsFolder.value));
							esq.filters.add("CurrentUserFilter", BPMSoft.createColumnFilterWithParameter(
								BPMSoft.ComparisonType.EQUAL, "SysUser", BPMSoft.SysValue.CURRENT_USER.value));
							esq.getEntityCollection(function(result) {
								if (!result.success) {
									return;
								}
								var item = result.collection.getByIndex(0);
								this.set("IsCurrentUserContactCenterOperator", item.get("Count") > 0);
								callback();
							}, this);
						}, this);
				},

				/**
				 * ######### ## ## ###### ########.
				 * @private
				 * @param {Function} callback ####### ######### ######. ########## ### ###### ###### ########.
				 */
				selectProcessActions: function(callback) {
					var esq = Ext.create("BPMSoft.EntitySchemaQuery", {
						rootSchemaName: "CTIProcessAction"
					});
					esq.isDistinct = true;
					esq.addColumn("Id", "Id");
					esq.addColumn("Name", "Name");
					esq.addColumn("ProcessSchema.Name", "ProcessSchemaName");
					var positionColumn = esq.addColumn("Position");
					positionColumn.orderDirection = BPMSoft.OrderDirection.ASC;
					esq.getEntityCollection(function(result) {
						if (!result.success) {
							return;
						}
						var actions = result.collection;
						actions.each(function(action) {
							callback(action);
						});
					});
				},

				/**
				 * Add new action to cti panel actions.
				 * @protected
				 * @param {BPMSoft.BaseViewModel} entity Action entity.
				 * @param {BPMSoft.Collection} actions Cti panel actions.
				 */
				addProcessAction: function(entity, actions) {
					const actionId = entity.get("Id");
					const action = Ext.create("BPMSoft.BaseViewModel", {
						values: {
							"Id": actionId,
							"Name": entity.get("Name"),
							"ProcessName": entity.get("ProcessSchemaName")
						},
						methods: {
							onProcessActionClick: function() {
								let processName = this.get("ProcessName");
								let parameters = this.getActionProcessParameters(processName);
								ProcessModuleUtilities.runProcess(processName, parameters);
							},
							getActionProcessParameters: this.getActionProcessParameters.bind(this)
						}
					});
					action.sandbox = this.sandbox;
					actions.add(actionId, action);
					this.set("IsProcessActionExists", true);
				},

				/**
				 * Gets process run parameters.
				 * @private
				 * @return {Object} parameters Process run parameters.
				 * @return {String} parameters.PhoneNumber Phone number.
				 * @return {Guid} parameters.DatabaseUId Call unique identifier.
				 * @return {String} [parameters.ContactId] Contact identifier.
				 * @return {String} [parameters.AccountId] Account identifier.
				 */
				getActionProcessParameters: function() {
					let parameters = {
						PhoneNumber: this.getLastAbonentNumber(),
						CallId: this.getCurrentDatabaseUId()
					};
					const subscriberKey = this.get("IdentifiedSubscriberKey");
					if (!subscriberKey) {
						return parameters;
					}
					const subscriberCollection = this.get("IdentifiedSubscriberPanelCollection");
					const subscriberPanel = subscriberCollection.get(subscriberKey);
					switch (subscriberPanel.get("Type")) {
						case CtiConstants.SubscriberTypes.Contact:
						case CtiConstants.SubscriberTypes.Employee:
							parameters.ContactId = subscriberPanel.get("Id");
							break;
						case CtiConstants.SubscriberTypes.Account:
							parameters.AccountId = subscriberPanel.get("Id");
							break;
						default:
							break;
					}
					return parameters;
				},

				/**
				 * ########## ########## ###### ######## ####### #########.
				 * @return {Boolean} #### ###### ######## ######## - true, ##### - false.
				 */
				getIsProcessActionsGroupVisible: function() {
					return this.get("IsProcessActionExists") && this.getIsCallExists();
				},

				//endregion

				//region Methods: Protected

				/**
				 * @inheritdoc CtiPanel#initCollections
				 * @overridden
				 */
				initCollections: function() {
					this.set("ProcessActionsCollection", Ext.create("BPMSoft.Collection"));
					this.callParent(arguments);
				},

				/**
				 * @inheritdoc
				 * @protected
				 * @overridden
				 */
				initOnConnected: function() {
					this.callParent(arguments);
					this.setProcessActionsVisibility(this.loadProcessActions.bind(this));
				},

				/**
				 * ######### ########### ######## ####### #########.
				 * @protected
				 */
				loadProcessActions: function() {
					var actions = this.get("ProcessActionsCollection");
					if (!actions.isEmpty() || !this.get("IsCurrentUserContactCenterOperator")) {
						return;
					}
					this.selectProcessActions(function(entity) {
						this.addProcessAction(entity, actions);
					}.bind(this));
				}

				//endregion

			},
			diff: [
				{
					"operation": "insert",
					"parentName": "ctiPanelMainContainer",
					"name": "ProcessActionsGroupContainer",
					"propertyName": "items",
					"values": {
						"id": "ProcessActionsGroupContainer",
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "ProcessActionsGroupContainer",
					"name": "ProcessActionsGroup",
					"propertyName": "items",
					"values": {
						"id": "ProcessActionsGroup",
						"itemType": BPMSoft.ViewItemType.CONTROL_GROUP,
						"markerValue": "ProcessActionsGroup",
						"selectors": {"wrapEl": "#ProcessActionsGroup"},
						"caption": {"bindTo": "Resources.Strings.ProcessActionsGroupCaption"},
						"visible": {"bindTo": "getIsProcessActionsGroupVisible"},
						"items": [],
						"controlConfig": {
							"collapsed": false
						}
					}
				},
				{
					"operation": "insert",
					"name": "ProcessActionsListContainer",
					"parentName": "ProcessActionsGroup",
					"propertyName": "items",
					"values": {
						"id": "ProcessActionsListContainer",
						"itemType": BPMSoft.ViewItemType.GRID,
						"markerValue": "ProcessActionsListContainer",
						"selectors": {"wrapEl": "#ProcessActionsListContainer"},
						"idProperty": "Id",
						"collection": {"bindTo": "ProcessActionsCollection"},
						"generator": "ContainerListGenerator.generatePartial",
						"defaultItemConfig": {
							"className": "BPMSoft.Container",
							"id": "processActionContainer",
							"classes": {
								"wrapClassName": ["cti-process-action-container"]
							},
							"items": [
								{
									"className": "BPMSoft.Button",
									"caption": {"bindTo": "Name"},
									"style": this.BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
									"iconAlign": BPMSoft.controls.ButtonEnums.iconAlign.LEFT,
									"classes": {
										"wrapperClass": ["cti-process-action-button"],
										"textClass": "cti-process-action-button-text",
										"imageClass": "cti-process-action-button-image"
									},
									"imageConfig": Resources.localizableImages.ProcessActionImage,
									"click": {"bindTo": "onProcessActionClick"},
									"markerValue": {"bindTo": "Name"}
								}
							]
						}
					}
				}
			]
		};
	}
);
