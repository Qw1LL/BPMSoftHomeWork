﻿define("ImageListViewModel", ["BaseGridRowViewModel"],
		function() {
	Ext.define("BPMSoft.configuration.ImageListViewModel", {
		alternateClassName: "BPMSoft.ImageListViewModel",
		extend: "BPMSoft.BaseGridRowViewModel",

		Ext: null,
		sandbox: null,
		BPMSoft: null,

		/**
		 * Entity unique identifier.
		 */
		entityId: null,

		/**
		 * #######, ####### ######### ## ##, ### ######## - ######.
		 * @readonly
		 * @type {Boolean}
		 */
		isLink: false,

		/**
		 * #######, ####### ######### ## ##, ### ######## - ####.
		 * @readonly
		 * @type {Boolean}
		 */
		isFile: false,

		/**
		 * #######, ####### ######### ## ##, ### ######## - ###### ## ######.
		 * @readonly
		 * @type {Boolean}
		 */
		isEntityLink: false,

		/**
		 * ########## ####### ## ###########.
		 * @private
		 */
		onEntityImageClick: BPMSoft.emptyFn,

		/**
		 * @inheritDoc FileDetailV2#getEntityLinkConfigById
		 * @overridden
		 */
		getEntityLinkConfigById: BPMSoft.emptyFn,

		/**
		 * @inheritDoc FileDetailV2#openCardEntity
		 * @overridden
		 */
		openCardEntity: BPMSoft.emptyFn,

		/**
		 * @inheritDoc FileDetailV2#defineEntityType
		 * @overridden
		 */
		defineEntityType: BPMSoft.emptyFn,

		/**
		 * @inheritDoc FileDetailV2#setDefaultEntityType
		 * @overridden
		 */
		setDefaultEntityType: BPMSoft.emptyFn,

		/**
		 * @inheritDoc FileDetailV2#getSysSettingImageByEntityName
		 * @overridden
		 */
		getSysSettingImageByEntityName: BPMSoft.emptyFn,

		/**
		 * @inheritDoc BPMSoft.BaseViewModel#constructor
		 * @overridden
		 */
		constructor: function() {
			this.callParent(arguments);
			this.on("change:Name", this.onNameChanged, this);
			this.initPropertyValue();
		},

		/**
		 * ############ ####### ######### ######## ####### "########".
		 * @private
		 */
		onNameChanged: function() {
			if (this.mode === "tiled") {
				this.insertEntityLink();
			}
		},

		/**
		 * Data initialization.
		 */
		initPropertyValue: function() {
			this.entityId = this.get("Id");
		},

		/**
		 * ####### ############## ######.
		 * @private
		 * @return {Boolean} ####### ########## ## ######### checkbox'#.
		 */
		getIsMultiSelect: function() {
			return this.isMultiSelect;
		},

		/**
		 * ########## ####### "dataLoaded" ######### BPMSoft.Collection
		 * @protected
		 * @param {Object} items
		 * @param {Object} newItems
		 */
		onCollectionDataLoaded: function(items, newItems) {
			this.observableRowHistory = [];
			this.selectableRows = null;
			items = newItems || items;
			if (items && items.getCount() > 0) {
				this.addItems(items.getItems());
			}
		},

		/**
		 * ########## ###### ###########.
		 * ######## ############## ########## ########### # ######.
		 * @param {Boolean} checked ####, ###########, ####### ## ###########.
		 */
		onSelectItem: function(checked) {
			var detail = this.detail;
			var detailSelectedRows = detail.get("SelectedRows");
			var selectedRows = this.BPMSoft.deepClone(detailSelectedRows);
			var itemId = this.get("Id");
			var itemIndex = selectedRows.indexOf(itemId);
			if (checked && (itemIndex === -1)) {
				selectedRows.push(itemId);
			} else if (!checked && (itemIndex !== -1)) {
				selectedRows.splice(itemIndex, 1);
			}
			detail.set("SelectedRows", selectedRows);
		},

		/**
		 * ######### ########## # ### ####### ####### ###########, ### ###.
		 * @private
		 * @return {Boolean} ########## # ### ####### ####### ###########, ### ###.
		 */
		getCheckItems: function() {
			var itemId = this.get("Id");
			var selectedRows = this.detail.get("SelectedRows");
			if (!selectedRows) {
				return false;
			}
			var indexOfItem = selectedRows.indexOf(itemId);
			return indexOfItem !== -1;
		},

		/**
		 * ######### #### ######### ######### ########.
		 * ######### ###### ## #######.
		 * @private
		 */
		insertEntityLink: function() {
			var entityText = this.getEntityText();
			var href = "";
			var target = "";
			if (this.isFile) {
				var workspaceBaseUrl = BPMSoft.utils.uri.getConfigurationWebServiceBaseUrl();
				href = workspaceBaseUrl + "/rest/FileService/GetFile/" + this.entitySchema.uId + "/" + this.entityId;
				target = "_self";
			}
			if (this.isLink) {
				href = BPMSoft.addProtocolPrefix(entityText);
				target = "_blank";
			}
			if (this.isEntityLink) {
				var config = this.getEntityLinkConfigById(this.entityId);
				href = config.url;
			}
			var linkHtmlConfig = this.Ext.DomHelper.createHtml({
				tag: "a",
				target: target,
				html: BPMSoft.utils.string.encodeHtml(entityText),
				href: href
			});
			var container = this.getLinkContainer();
			if (this.isEntityLink) {
				container.wrapEl.el.on("click", this.onClickEntityLink, this);
			}
			container.wrapEl.update(linkHtmlConfig);
		},

		/**
		 * Returns link container.
		 * @return {Ext.Component}
		 */
		getLinkContainer: function() {
			var containerId = "entity-link-container-" + this.entityId + "-" + this.sandbox.id;
			return Ext.getCmp(containerId);
		},

		/**
		 * ######### ##### ######.
		 * @protected
		 * @param {Event} event
		 */
		onClickEntityLink: function(event) {
			event.stopEvent();
			this.openCardEntity(this.entityId);
		},

		/**
		 * ########## ###### ## ###########.
		 * @private
		 * @return {String} ###### ## ###########.
		 */
		getEntityImage: function() {
			this.defineEntityType(this);
			var imageUrl = this.get("imageUrl");
			var imageId = this.get("Id");
			return imageUrl ? imageUrl : this.getImageUrl(this.entitySchema.name, imageId);
		},

		/**
		 * ########## Url ## ###########.
		 * @overridden
		 * @param {String} entitySchemaName ######## ########.
		 * @param {String} Id ############# ###########.
		 * @return {String} ###### ## ###########.
		 */
		getImageUrl: function(entitySchemaName, Id) {
			if (this.isEntityLink) {
				var entity = this.getEntityLinkCacheById(Id);
				return BPMSoft.ImageUrlBuilder.getUrl({
					source: BPMSoft.ImageSources.SYS_SETTING,
					params: {
						r: this.getSysSettingImageByEntityName(entity.entityName)
					}
				});
			} else {
				return BPMSoft.ImageUrlBuilder.getUrl({
					source: BPMSoft.ImageSources.ENTITY_COLUMN,
					params: {
						schemaName: entitySchemaName,
						columnName: "Data",
						primaryColumnValue: Id
					}
				});
			}
		},

		/**
		 * ########## ####### ###########.
		 * @private
		 * @return {String} ####### ###########.
		 */
		getEntityText: function() {
			var entityText = this.get("Name");
			return entityText ? entityText : "";
		},

		/**
		 * @obsolete
		 */
		getEntityImageVisible: function() {
			return true;
		},

		/**
		 * @inheritDoc BPMSoft.Component#onDestroy
		 */
		onDestroy: function() {
			var container = this.getLinkContainer();
			if (container && this.rendered) {
				container.wrapEl.el.un("click", this.onClickEntityLink, this);
			}
			this.callParent(arguments);
		}
	});
});
