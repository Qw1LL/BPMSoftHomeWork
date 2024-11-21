define("ContactCommunicationDetail", ["ViewUtilities", "Contact",
		"ConfigurationEnums", "ConfigurationConstants"],
	function(ViewUtilities, Contact, ConfigurationEnums, ConfigurationConstants) {
		return {
			entitySchemaName: "ContactCommunication",
			messages: {
				/**
				 * @message ReloadCard
				 * Notify about the card is reload.
				 */
				"ReloadCard": {
					"mode": BPMSoft.MessageMode.PTP,
					"direction": BPMSoft.MessageDirectionType.PUBLISH
				}
			},
			attributes: {

				/**
				 * ######### ######### #### "###### ## #############"
				 */
				RestrictionsMenuItems: {dataValueType: BPMSoft.DataValueType.COLLECTION},

				/**
				 * ######### ######## ## #############
				 */
				RestrictionsCollection: {dataValueType: BPMSoft.DataValueType.COLLECTION},

				/**
				 * Primary tag column name.
				 */
				"PrimaryTagColumnName": {
					dataValueType: BPMSoft.DataValueType.TEXT,
					value: "IsCreatedBySynchronization"
				}

			},
			methods: {
				/**
				 * ####### ######## ##### LinkedIn ## ####### ####.
				 * @param esq ###### ####### #####.
				 */
				initCommunicationTypesFilters: function(esq) {
					this.callParent(arguments);
					var columns = Contact.columns;
					if (columns !== null) {
						if (columns.LinkedIn && columns.LinkedIn.usageType === ConfigurationEnums.EntitySchemaColumnUsageType.None) {
							var linkedInFilter = BPMSoft.createColumnFilterWithParameter(
								BPMSoft.ComparisonType.NOT_EQUAL, "Id", ConfigurationConstants.CommunicationTypes.LinkedIn);
							esq.filters.addItem(linkedInFilter);
						}
					}
				},

				/**
				 * ######### ######### #### ###### ###### "########" ########## #### "###### ## #############".
				 * @overridden
				 * @return {BPMSoft.BaseViewModelCollection} ######### ####### ####.
				 */
				getToolsMenuItems: function() {
					var menuItems = this.callParent(arguments);
					var restrictionsItem = this.getRestrictionsMenuItem();
					menuItems.addItem(restrictionsItem);
					return menuItems;
				},

				/**
				 * ########## ##### #### #### "###### ## #########".
				 * @protected
				 * @return {BPMSoft.BaseViewModel} ###### ############# ###### ####.
				 */
				getRestrictionsMenuItem: function() {
					var restrictionsMenuItems = Ext.create("BPMSoft.BaseViewModelCollection");
					var restrictionsItem = Ext.create("BPMSoft.BaseViewModel", {
						values: {
							Caption: this.get("Resources.Strings.DoNotUseCommunicationCaption"),
							Id: BPMSoft.generateGUID(),
							Items: restrictionsMenuItems
						}
					});
					var restrictions = this.getRestrictions();
					BPMSoft.each(restrictions, function(restrictionConfig, restrictionName) {
						var restrictionMenuItem = this.Ext.create("BPMSoft.BaseViewModel", {
							values: {
								Id: BPMSoft.generateGUID(),
								Caption: restrictionConfig.Caption,
								Tag: restrictionName,
								Click: { bindTo: "doNotUseCommunication" }
							}
						});
						restrictionsMenuItems.addItem(restrictionMenuItem);
					}, this);
					return restrictionsItem;
				},

				/**
				 * ########## ####### ## #############.
				 * @protected
				 * @return {Object} ######, ####### ######## ######## ######## ## #############.
				 */
				getRestrictions: function() {
					return {
						"DoNotUseEmail": {
							"RestrictCaption": this.get("Resources.Strings.DoNotUseEmail"),
							"Caption": this.get("Resources.Strings.DoNotUseEmailCaption")
						},
						"DoNotUseCall": {
							"RestrictCaption": this.get("Resources.Strings.DoNotUseCall"),
							"Caption": this.get("Resources.Strings.DoNotUseCallCaption")
						},
						"DoNotUseSms": {
							"RestrictCaption": this.get("Resources.Strings.DoNotUseSms"),
							"Caption": this.get("Resources.Strings.DoNotUseSmsCaption")
						},
						"DoNotUseFax": {
							"RestrictCaption": this.get("Resources.Strings.DoNotUseFax"),
							"Caption": this.get("Resources.Strings.DoNotUseFaxCaption")
						},
						"DoNotUseMail": {
							"RestrictCaption": this.get("Resources.Strings.DoNotUseMail"),
							"Caption": this.get("Resources.Strings.DoNotUseMailCaption")
						}
					};
				},

				/**
				 * ########## ####### ####### #### ######## ## ############# ####### #####.
				 * @protected
				 * @param {String} tag ############# ####### ## #############.
				 */
				doNotUseCommunication: function(tag) {
					if (this.get("IsDetailCollapsed")) {
						return;
					}
					var restrictions = this.getRestrictions();
					var collection = this.get("RestrictionsCollection");
					if (!collection.contains(tag)) {
						collection.add(tag, this.getRestrictionsCollectionItem(tag, restrictions[tag].RestrictCaption));
						this.changeCardPageButtonsVisibility(true);
					}
				},

				/**
				 * ########## ############ ############# ######## "###### ## #############"
				 * @protected
				 * @param {Object} itemConfig ###### ## ############ ######## # ContainerList.
				 * @param {BPMSoft.BaseViewModel} item #######, ### ######## ###### ########## ########## view.
				 */
				getRestrictionsItemConfig: function(itemConfig, item) {
					//todo: lazy init
					var config = ViewUtilities.getContainerConfig(
						"restrictions-container", ["restrictions-container-class", "control-width-15"]);
					itemConfig.config = config;
					var checkBoxLabelConfig = {
						className: "BPMSoft.Label",
						caption: {bindTo: "Name"},
						classes: {labelClass: ["detail-label-user-class"]},
						inputId: item.get("Id") + "-el"
					};
					var checkBoxEditConfig = {
						className: "BPMSoft.CheckBoxEdit",
						id: item.get("Id"),
						checked: {bindTo: "Value"}
					};
					config.items.push(checkBoxLabelConfig, checkBoxEditConfig);
				},

				/**
				 * ########## ####### ######### "###### ## #############".
				 * @protected
				 * @param {String} id ############# ####### ## #############.
				 * @param {String} name ### ####### ## #############.
				 * @return {BPMSoft.BaseViewModel} ###### ############# ########## ########.
				 */
				getRestrictionsCollectionItem: function(id, name) {
					var collectionItem = Ext.create("BPMSoft.BaseViewModel", {
						values: {
							Name: name,
							Id: id,
							Value: true
						}
					});
					collectionItem.sandbox = this.sandbox;
					collectionItem.setSaveDiscardButtonsVisible = this.setSaveDiscardButtonsVisible;
					return collectionItem;
				},

				/**
				 * Loads restrictions collection.
				 * @protected
				 * @param {Function} callback Callback function.
				 * @param {BPMSoft.BaseSchemaViewModel} scope Context.
				 */
				getEntityRestrictions: function(callback, scope) {
					if (this.get("IsDetailCollapsed") || this.isEmpty(this.get("MasterRecordId"))) {
						this.Ext.callback(callback, scope);
						return;
					}
					var restrictions = ["DoNotUseEmail", "DoNotUseCall", "DoNotUseSms", "DoNotUseFax", "DoNotUseMail"];
					var select = this.Ext.create("BPMSoft.EntitySchemaQuery", {rootSchemaName: "Contact"});
					this.BPMSoft.each(restrictions, function(item) {
						select.addColumn(item);
					});
					select.getEntity(this.get("MasterRecordId"), function(response) {
						if (!response.success) {
							return;
						}
						if (response.entity) {
							var entity = response.entity;
							var collection = this.get("RestrictionsCollection");
							collection.clear();
							var newItemsCollection = this.Ext.create("BPMSoft.BaseViewModelCollection");
							this.BPMSoft.each(restrictions, function(restrictionName) {
								if (entity.get(restrictionName)) {
									var restrictionCaption = this.get("Resources.Strings." + restrictionName);
									var restrictionsCollectionItem =
										this.getRestrictionsCollectionItem(restrictionName, restrictionCaption);
									newItemsCollection.add(restrictionName, restrictionsCollectionItem);
								}
							}, this);
							collection.loadAll(newItemsCollection);
						}
						this.set("IsDataLoaded", true);
						callback.call(scope);
					}, this);
				},

				/**
				 * ########## ######### ####### ## #############.
				 * @protected
				 */
				onRestrictionItemChanged: function() {
					if (this.get("IsDataLoaded")) {
						this.setSaveDiscardButtonsVisible(true);
					}
				},

				/**
				 * ########## ######## ######## ## #############.
				 * @overridden
				 * @param {Function} callback ####### ######### ######.
				 * @param {BPMSoft.BaseSchemaViewModel} scope ######## ########## ####### ######### ######.
				 */
				loadContainerListData: function(callback, scope) {
					this.callParent([function() {
						this.set("IsDataLoaded", false);
						this.getEntityRestrictions(callback, scope);
					}, this]);
				},

				/**
				 * ############## ######### ######## ## #############.
				 * @overridden
				 */
				initCollections: function() {
					this.callParent(arguments);
					this.set("RestrictionsCollection", Ext.create("BPMSoft.BaseViewModelCollection"));
					var collection = this.get("RestrictionsCollection");
					collection.on("itemChanged", this.onRestrictionItemChanged, this);
				},

				/**
				 * ########## ###### ## ########## ######## ## #############.
				 * @protected
				 * @return {BPMSoft.UpdateQuery} ###### ## ########## ######## ## #############.
				 */
				getSaveRestrictionsQuery: function() {
					var collection = this.get("RestrictionsCollection");
					if (collection.isEmpty()) {
						return null;
					}
					var update = Ext.create("BPMSoft.UpdateQuery", { rootSchemaName: "Contact" });
					update.enablePrimaryColumnFilter(this.get("MasterRecordId"));
					collection.each(function(item) {
						update.setParameterValue(item.get("Id"), item.get("Value"), BPMSoft.DataValueType.BOOLEAN);
					}, this);
					return update;
				},

				/**
				 * ######### ######### ######. ########### ### ####### ## ###### ######### ########, ####### ########
				 * ######.
				 * @overridden
				 */
				save: function() {
					var restrictionsQuery = this.getSaveRestrictionsQuery();
					var queries = restrictionsQuery ? [restrictionsQuery] : [];
					var saveQueries = this.getSaveItemsQueries();
					queries = queries.concat(saveQueries);
					var deleteQueries = this.getDeleteItemsQueries();
					queries = queries.concat(deleteQueries);
					if (Ext.isEmpty(queries)) {
						this.publishSaveResponse({
							success: true
						});
						return true;
					}
					var batchQuery = Ext.create("BPMSoft.BatchQuery");
					BPMSoft.each(queries, function(query) {
						batchQuery.add(query);
					}, this);
					batchQuery.execute(this.onSaved, this);
					return true;
				},

				/**
				 * @inheritdoc BPMSoft.BaseCommunicationDetail#onSaved
				 * @overridden
				 */
				onSaved: function() {
					this.callParent(arguments);
					this.sandbox.publish("ReloadCard", null, [this.sandbox.id]);
				},

				/**
				 * @inheritdoc BPMSoft.BaseCommunicationDetail#initMasterDetailColumnMapping
				 * @overridden
				 */
				initMasterDetailColumnMapping: function() {
					this.set("MasterDetailColumnMapping", [
						{
							"CommunicationType": ConfigurationConstants.CommunicationTypes.Email,
							"MasterEntityColumn": "Email"
						},
						{
							"CommunicationType": ConfigurationConstants.CommunicationTypes.Phone,
							"MasterEntityColumn": "Phone"
						},
						{
							"CommunicationType": ConfigurationConstants.CommunicationTypes.MobilePhone,
							"MasterEntityColumn": "MobilePhone"
						},
						{
							"CommunicationType": ConfigurationConstants.CommunicationTypes.HomePhone,
							"MasterEntityColumn": "HomePhone"
						},
						{
							"CommunicationType": ConfigurationConstants.CommunicationTypes.Skype,
							"MasterEntityColumn": "Skype"
						}
					]);
				}
			},

			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "merge",
					"name": "CommunicationsContainer",
					"values": {
						"generateId": false,
					}
				},
				{
					"operation": "insert",
					"name": "RestrictionsContainer",
					"parentName": "Detail",
					"propertyName": "items",
					"values":
					{
						"generateId": false,
						"generator": "ConfigurationItemGenerator.generateContainerList",
						"idProperty": "Id",
						"collection": "RestrictionsCollection",
						"observableRowNumber": 10,
						"onGetItemConfig": "getRestrictionsItemConfig"
					}
				}
			]/**SCHEMA_DIFF*/
		};
	});
