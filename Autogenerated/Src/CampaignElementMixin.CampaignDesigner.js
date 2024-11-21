Ext.define("BPMSoft.configuration.mixins.CampaignElementMixin", {
	alternateClassName: "BPMSoft.CampaignElementMixin",

	/**
	 * Adds 0 to number string with one numeric.
	 * @private
	 * @param  {number} number maybe days count or month number.
	 * @return {string} string repersentation of number.
	 */
	_convertToDoubleNumeralString: function(number) {
		if (number > 9) {
			return number.toString();
		}
		return "0" + number;
	},

	/**
	 * @inheritdoc BPMSoft.manager.ProcessBaseElementSchema#getImageConfig
	 * @overridden
	 */
	getImageConfig: function(localizableImage) {
		var imageUrl = BPMSoft.ImageUrlBuilder.getUrl(localizableImage);
		return {
			"source": BPMSoft.ImageSources.URL,
			"url": imageUrl
		};
	},

	/**
	 * @inheritdoc BPMSoft.manager.ProcessBaseElementSchema#getSmallImage
	 * @overridden
	 */
	getImage: function(imageResource) {
		return this.getImageConfig(imageResource);
	},

	/**
	 * Creates entity schema query for linked entity. It will be use for select entity by Id.
	 * @private
	 * @param {String} rootSchemaName Name of the entity schema.
	 * @returns {BPMSoft.EntitySchemaQuery} Instance of the entity schema query.
	 */
	getEsq: function(rootSchemaName, columns) {
		var esq = Ext.create("BPMSoft.EntitySchemaQuery", {
			rootSchemaName: rootSchemaName
		});
		columns.forEach(function(el) {
			esq.addColumn(el);
		});
		return esq;
	},

	/**
	 * Loads linked entity
	 * @private
	 * @param {Guid} entityId Entity identifier.
	 * @param {string} rootSchemaName Name of root schema
	 * @param {Array[string]} columns array of column names
	 * @param {Function} callback The callback function.
	 * @param {Object} scope The callback execution context.
	 */
	loadLinkedEntity: function(entityId, rootSchemaName, columns, callback, scope) {
		var esq = this.getEsq(rootSchemaName, columns);
		esq.getEntity(entityId, function(response) {
			callback.call(scope || this, response.entity || null);
		}, this);
	},

	/**
	 * Creates TimeZone entity schema query.
	 * @private
	 * @return {BPMSoft.EntitySchemaQuery} Instance of the entity schema query.
	 */
	createTimeZoneQuery: function() {
		var esq = Ext.create("BPMSoft.EntitySchemaQuery", {
			rootSchemaName: "TimeZone"
		});
		esq.addColumn("Id");
		esq.addColumn("Name");
		esq.addColumn("Code");
		esq.serverESQCacheParameters = {
			cacheLevel: BPMSoft.ESQServerCacheLevels.SESSION,
			cacheGroup: "CampaignDesigner",
			cacheItemName: "TimeZoneList"
		};
		return esq;
	},

	/**
	 * Loads time zones from lookup.
	 * @param callback
	 * @param scope
	 */
	loadTimeZones: function(callback, scope) {
		var esq = this.createTimeZoneQuery();
		this.loadEntityCollection(esq, callback, scope);
	},

	/**
	 * Loads specific by query entity collection
	 * and calls callback with result collection.
	 * If request is failed execution is stopped.
	 * @param {BPMSoft.EntitySchemaQuery} esq Instance of the entity schema query.
	 * @param {Function} callback
	 * @param {Object} scope
	 */
	loadEntityCollection: function(esq, callback, scope) {
		esq.getEntityCollection(function(response) {
			if (!response || !response.success) {
				return;
			}
			Ext.callback(callback, scope, [response.collection]);
		}, this);
	},

	/**
	 * @protected
	 * @returns {Array} Names of the properties to save in campaign template.
	 */
	getElementSpecificPropertiesNames: function() {
		return []; 
	},

	/**
	 * @protected
	 */
	getElementSpecificProperties: function() {
		var config = {}
		var self = this;
		this.getElementSpecificPropertiesNames().forEach(function(propName) {
			config[propName] = self[propName];
		});
		return config;
	},

	/**
	 * @protected
	 */
	setElementSpecificProperties: function(config) {
		var self = this;
		this.getElementSpecificPropertiesNames().forEach(function(propName) {
			self[propName] = config[propName];
		});
	},

	/**
	 * @protected
	 */
	getElementConfigInsert: function(name, elementConfig, elementType) {
		var insertQuery = Ext.create("BPMSoft.InsertQuery", {
			rootSchemaName: "CampaignElementTemplate"
		});
		insertQuery.setParameterValue("Caption", name, BPMSoft.DataValueType.TEXT);
		insertQuery.setParameterValue("ElementConfig", elementConfig, BPMSoft.DataValueType.TEXT);
		insertQuery.setParameterValue("ElementType", elementType, BPMSoft.DataValueType.TEXT);
		return insertQuery;
	},

	/**
	 * @protected
	 */
	getElementType: function() {
		return this.typeName.replaceAll("BPMSoft.Configuration", "").replaceAll(".", "").replaceAll(",", "").trim();
	},

	/**
	 * @protected
	 */
	saveElementConfig:function(name, callback, scope) {
		var elementConfig = this.serialize();
		var elementType = this.getElementType()
		var insert = this.getElementConfigInsert(name, elementConfig, elementType);
		insert.execute(function(result) {
			callback.call(scope, result);
		}, this);
	},

	/**
	 * Returns custom string representation of Date object to send.
	 * @param  {Date} date current StartTime property date.
	 * @return {string} string representation of date.
	 */
	convertDateToString: function(date) {
		var year = date.getFullYear();
		var month = this._convertToDoubleNumeralString(date.getMonth() + 1);
		var day = this._convertToDoubleNumeralString(date.getDate());
		var hours = this._convertToDoubleNumeralString(date.getHours());
		var minutes = this._convertToDoubleNumeralString(date.getMinutes());
		var template = "{0}-{1}-{2} {3}:{4}";
		return Ext.String.format(template, year, month, day, hours, minutes);
	}
});
