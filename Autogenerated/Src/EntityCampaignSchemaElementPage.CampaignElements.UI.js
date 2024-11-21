/**
 * Base properties page for entity oriented elements in campaign.
 * This page includes base logic for select entity to lookup and set properties from entity to page.
 */
define("EntityCampaignSchemaElementPage",  ["BaseFiltersGenerateModule", "LookupUtilities",
		"CampaignElementMixin", "DropdownLookupMixin"],
	function(BaseFiltersGenerateModule, LookupUtilities) {
		return {
			mixins: {
				campaignElementMixin: "BPMSoft.CampaignElementMixin",
				dropdownLookupMixin: "BPMSoft.DropdownLookupMixin"
			},
			attributes: {

				/**
				 * Entity record for lookup. It also includes Id which save to campaign element.
				 * @type {BPMSoft.dataValueType.LOOKUP}
				 */
				"EntityRecord": {
					"dataValueType": this.BPMSoft.DataValueType.LOOKUP,
					"isLookup": true,
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"referenceSchemaName": "",
					"isRequired": true
				},

				/**
				 * Attribute that signals about fully loaded entity record.
				 * @type {BPMSoft.DataValueType.BOOLEAN}
				 */
				"IsEntityLoaded": {
					"dataValueType": this.BPMSoft.DataValueType.BOOLEAN,
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},

				/**
				 * Collection of entity records for loading to lookup.
				 * @type {BPMSoft.DataValueType.COLLECTION}
				 */
				"RecordCollection": {
					"dataValueType": this.BPMSoft.DataValueType.COLLECTION,
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				}
			},
			methods: {

				/**
				 * Loads entity by id.
				 * @private
				 * @param {Guid} itemId Identifier of element's record which will be loaded to property page.
				 * @param {Object} scope Callback function context.
				 */
				_loadEntity: function(itemId, callback, scope) {
					var columns = this.getColumnsForEntitySelect();
					this.loadLinkedEntity(itemId,
						this.getEntitySchemaName(), columns, function(entity) {
							if (entity) {
								this.$IsEntityLoaded = true;
								this.setPageParameters(entity);
							}
							callback.call(scope);
						}, this);
				},

				/**
				 * Sets EntityRecord attribute to an object
				 * with fields: displayValue and value, for correct view in lookupedit control.
				 * @private
				 * @param {Object} entity Loaded Entity from storage that contains Id and Name.
				 */
				_setCampaignEntityLookup: function(entity) {
					var lookupObject = entity.values;
					lookupObject.displayValue = entity.$Name;
					lookupObject.value = entity.$Id;
					this.$EntityRecord = lookupObject;
				},

				/**
				 * Sets parameters from entity to page attributes.
				 * @protected
				 * @param {Object} eventEntity Event entity object.
				 */
				setPageParameters: function(entity) {
					this._setCampaignEntityLookup(entity);
				},

				/**
				 * Clears all parameters attributes after set EntityRecord to null.
				 * @protected
				 */
				clearPageParameters: BPMSoft.emptyFn,

				/**
				 * Inits entity lookup filters
				 * @protected
				 * @return {Object}. Filters for lookup query.
				 */
				getEntityLookupFilters: function() {
					return this.BPMSoft.createFilterGroup();
				},

				/**
				 * @inheritdoc BaseCampaignSchemaElementPage#initPageAsync
				 * @override
				 */
				initPageAsync: function(element, callback, scope) {
					this.$IsEntityLoaded = false;
					var entityId = this.getEntityRecordIdFromElement(element);
					if (entityId) {
						this._loadEntity(entityId, callback, scope);
					} else {
						this.$IsEntityLoaded = true;
						callback.call(scope);
					}
				},

				/**
				 * @inheritdoc BaseCampaignSchemaElementPage#saveValues
				 * @override
				 */
				saveValues: function() {
					this.callParent(arguments);
					var element = this.$ProcessElement;
					var recordId = null;
					if (!Ext.isEmpty(this.$EntityRecord)) {
						recordId = this.$EntityRecord.value;
					}
					this.setRecordIdToElement(element, recordId);
				},

				/**
				 * Opens lookup for choose entity record.
				 * @protected
				 */
				openEntityLookup: function() {
					var config = this.getEntityLookupConfig();
					LookupUtilities.Open(this.sandbox, config, this.onEntityLookupSelected, this, null, false, false);
				},

				/**
				 * Handles event "change" in lookupedit for EntityRecord.
				 * @protected
				 * @param {Object} selectedItem Selected lookup item from dropdown.
				 */
				onEntityLookupChanged: function(selectedItem) {
					this.loadEntityRecord(selectedItem);
				},

				/**
				 * Loads EntityRecord item for current page by selected item.
				 * @protected
				 * @param {Object} selectedItem Selected lookup item info.
				 */
				loadEntityRecord: function(selectedItem) {
					if (selectedItem) {
						this._loadEntity(selectedItem.value, BPMSoft.emptyFn, this);
					} else {
						this.clearPageParameters();
					}
				},

				/**
				 * Handles event after selected item in lookup.
				 * @protected
				 * @param {Object} args Contains information about selected rows from lookup.
				 */
				onEntityLookupSelected: function(args) {
					var selectedRows = args.selectedRows;
					if (!selectedRows.isEmpty()) {
						var selectedItem = selectedRows.first();
						this._loadEntity(selectedItem.Id, BPMSoft.emptyFn, this);
					}
				},

				/**
				 * Gets entity lookup config.
				 * @protected
				 * @return {Object} Lookup config with filters for select entity record.
				 */
				getEntityLookupConfig: function() {
					var config = {
						entitySchemaName: this.getEntitySchemaName(),
						multiSelect: false,
						hideActions: true,
						settingsButtonVisible: false
					};
					var filters = this.getEntityLookupFilters();
					if (filters) {
						config.filters = filters;
					}
					return config;
				},

				/**
				 * Loads data to init source collection of Entity record to display in lookup dropdown.
				 * @protected
				 * @param {String} filterParameter text to search.
				 * @param {BPMSoft.Collection} list collection of items to display in lookup dropdown.
				 */
				prepareEntityList: function(filterParameter, list) {
					if (list && list instanceof this.BPMSoft.Collection) {
						list.clear();
					}
					var filters = this.getEntityLookupFilters();
					this.prepareLookupList(filters, filterParameter,
						this.getEntitySchemaName(), "RecordCollection", this);
				},

				/**
				 * Returns is selected EntityRecord object.
				 * @protected
				 * @return {Boolean} Returns true when EntityRecord is filled and false in otherwise.
				 */
				isEntitySelected: function() {
					return Boolean(this.$EntityRecord);
				},

				/**
				 * @inheritdoc BaseCampaignSchemaElementPage#getContextHelpCode
				 * @override
				 */
				getContextHelpCode: function() {
					return "";
				},

				/**
				 * @inheritdoc BaseSchemaViewModel#getLinkConfig
				 * @override
				 */
				getLinkConfig: function() {
					return { isSimpleUrl: true };
				},

				/**
				 * Returns collection of column names, which will be used in select query for load entity.
				 * @protected
				 * @returns {Array} Collection of colum names.
				 */
				getColumnsForEntitySelect: function() {
					return [];
				},

				/**
				 * Returns entity record identifier froim campaign element.
				 * @protected
				 * @param {Object} element Campaign element.
				 * @returns {Guid} Entity record's identifier.
				 */
				getEntityRecordIdFromElement: function() {
					return undefined;
				},

				/**
				 * Set reidentifier of selected entity to an element of campaign.
				 * @protected
				 * @param element Campaign element.
				 * @param recordId Entity record identifier which will be set to an element.
				 */
				setRecordIdToElement: BPMSoft.emptyFn,

				/**
				 * Returns text for CampaignEntityTextLabel.
				 * @protected
				 * @returns {string} Label's text.
				 */
				getEntityLookupCaption: function() {
					return "";
				},

				/**
				 * Returns root schema name for entity
				 * @protected
				 * @returns {string} Root schema name.
				 */
				getEntitySchemaName: function() {
					return "";
				},

				/**
				 * Constructor for EntityCampaignSchemaElementPage
				 */
				constructor: function() {
					this.callParent(arguments);
					this.columns.EntityRecord.referenceSchemaName = this.getEntitySchemaName();
				}
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"name": "ContentContainer",
					"propertyName": "items",
					"parentName": "EditorsContainer",
					"className": "BPMSoft.GridLayoutEdit",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.GRID_LAYOUT,
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "CampaignEntityTextLabel",
					"parentName": "ContentContainer",
					"propertyName": "items",
					"values": {
						"layout": {
							"column": 0,
							"row": 0,
							"colSpan": 24
						},
						"itemType": this.BPMSoft.ViewItemType.LABEL,
						"caption": {
							"bindTo": "getEntityLookupCaption"
						},
						"classes": {
							"labelClass": ["t-title-label-proc"]
						}
					}
				},
				{
					"operation": "insert",
					"name": "EntityRecord",
					"parentName": "ContentContainer",
					"propertyName": "items",
					"values": {
						"bindTo": "EntityRecord",
						"dataValueType": this.BPMSoft.DataValueType.LOOKUP,
						"isRequired": true,
						"openLinkInNewTab": true,
						"change": "$onEntityLookupChanged",
						"controlConfig": {
							"loadVocabulary": "$openEntityLookup",
							"prepareList": "$prepareEntityList",
							"list": "$RecordCollection",
							"tag": "EntityRecord"
						},
						"wrapClass": ["no-caption-control"],
						"layout": {
							"column": 0,
							"row": 1,
							"colSpan": 24
						},
						"labelConfig": {
							"visible": false
						},
						"enabled": "$IsEntityLoaded"
					}
				}
			]/**SCHEMA_DIFF*/
		};
	}
);
