define("SocialMessageViewModel", ["SocialMessageViewModelResources", "StorageUtilities", "NetworkUtilities",
		"SocialFeedUtilities", "SocialMentionUtilities", "MiniPageUtilities"
	],
	function(resources, StorageUtilities, NetworkUtilities) {
		/**
		 * @class BPMSoft.configuration.SocialMessageViewModel
		 */
		Ext.define("BPMSoft.model.SocialMessageViewModel", {

			extend: "BPMSoft.BaseViewModel",
			alternateClassName: "BPMSoft.SocialMessageViewModel",

			Ext: null,
			BPMSoft: null,
			sandbox: null,

			mixins: {
				SocialFeedUtilities: "BPMSoft.SocialFeedUtilities",
				SocialMentionUtilities: "BPMSoft.SocialMentionUtilities",
				/**
				 * @class MiniPageUtilities Mixin, used for Mini Pages
				 */
				MiniPageUtilitiesMixin: "BPMSoft.MiniPageUtilities"
			},

			columns: {
				CreatedBy: {
					dataValueType: BPMSoft.DataValueType.LOOKUP,
					isLookup: true,
					referenceSchemaName: "Contact",
					primaryImageColumnName: "Photo"
				}
			},

			//region Properties: Private

			/**
			 * ViewModule page url.
			 * @type {String}
			 * @private
			 */
			viewModuleUrl: "ViewModule.aspx#",

			//endregion

			//region Methods: Private

			/**
			 * Reloads page.
			 * @private
			 */
			reloadPage: function() {
				window.location.reload();
			},

			//endregion

			//region Methods: Protected

			/**
			 * Initializes resources.
			 * @protected
			 * @param {Object} schemaResources Resources.
			 */
			initResources: function(schemaResources) {
				schemaResources = schemaResources || {};
				this.BPMSoft.each(schemaResources.localizableStrings, function(value, key) {
					this.set("Resources.Strings." + key, value);
				}, this);
				this.BPMSoft.each(schemaResources.localizableImages, function(value, key) {
					this.set("Resources.Images." + key, value);
				}, this);
			},

			/**
			 * Handles on "Message" attribute changed.
			 * @protected
			 * @param {Backbone.Model} model Model instance.
			 * @param {String} value Message value.
			 */
			onMessageChanged: function(model, value) {
				this.setUrlMessage(value);
			},

			/**
			 * Sets url message.
			 * @protected
			 * @param {String} message Attribute value.
			 */
			setUrlMessage: function(message) {
				var urlCommentVisible = false;
				if (!Ext.isEmpty(message)) {
					message = BPMSoft.stripTags(message).trim();
					urlCommentVisible = BPMSoft.isUrl(message);
					var urlMessage = urlCommentVisible ? message : null;
					this.set("UrlMessage", urlMessage);
				}
			},

			/**
			 * Handles on change visible.
			 * @protected
			 */
			changeVisible: function() {
				this.mixins.SocialFeedUtilities.changeVisible.apply(this, arguments);
				var message = this.get("Message");
				this.setUrlMessage(message);
			},

			//endregion

			//region Methods: Public

			/**
			 * @inheritdoc BPMSoft.BaseViewModel#constructor
			 * @override
			 */
			constructor: function() {
				this.callParent(arguments);
				this.on("change:Message", this.onMessageChanged, this);
				this.initResources(resources);
			},

			/**
			 * Initializes view model instance.
			 * @param {Object} config View model configuration.
			 * @param {Object} config.rawData Columns' values.
			 * @param {Object} config.rowConfig Columns' types.
			 * @param {Object} config.viewModel View model.
			 */
			createViewModel: function(config) {
				var socialMessageConfig = {
					rowConfig: config.rowConfig,
					values: config.rawData,
					Ext: this.Ext,
					BPMSoft: this.BPMSoft,
					sandbox: this.sandbox
				};
				var viewModel = this.Ext.create("BPMSoft.SocialMessageViewModel", socialMessageConfig);
				viewModel.mixins.SocialMentionUtilities.init.call(viewModel);
				config.viewModel = viewModel;
			},

			/**
			 * Gets object schema caption by name.
			 * @param {String} entitySchemaName Object entity schema name.
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Execution context.
			 */
			getEntitySchemaByName: function(entitySchemaName, callback, scope) {
				var schema = BPMSoft[entitySchemaName];
				if (schema) {
					callback.call(scope, schema.caption);
				} else {
					BPMSoft.require([entitySchemaName], function(schema) {
						if (schema) {
							callback.call(scope, schema.caption);
						}
					});
				}
			},

			/**
			 * Returns marker value for "UsersWhoLikeIt" button.
			 * @return {String}
			 */
			getUsersWhoLikeItMarkerValue: function() {
				return "UsersWhoLikeItButton";
			},

			/**
			 * Initializes viewModel properties.
			 */
			init: function() {
				this.mixins.SocialFeedUtilities.init.call(this);
				this.mixins.SocialMentionUtilities.init.call(this);

				this.set("isCommentInEditMode", false);
				this.set("Comments", Ext.create("BPMSoft.BaseViewModelCollection"));
				this.set("LoadedComments", Ext.create("BPMSoft.BaseViewModelCollection"));
				this.set("LoadedCommentCount", 0);
				this.set("Visible", false);
				this.set("CommentsExpanded", false);
				this.set("LikeTextVisible", true);
				this.set("LikeImageVisible", true);
				this.set("EditCommentVisible", false);
				this.set("CommentVisible", true);
				this.set("ActionsContainerVisible", true);
				this.set("PublishContainerVisible", false);
				this.set("CommentToEditContainerVisible", false);
				this.set("NewCommentButtonsVisible", false);
				this.set("CommentToEditButtonsVisible", false);
				this.set("EditedCommentContainerVisible", false);
				var message = this.get("Message");
				this.setUrlMessage(message);

				var entitySchemaUId = this.get("EntitySchemaUId") || BPMSoft.GUID_EMPTY;
				var entityId = this.get("EntityId") || BPMSoft.GUID_EMPTY;
				if (!BPMSoft.isEmptyGUID(entitySchemaUId) && !BPMSoft.isEmptyGUID(entityId)) {
					var entitySchemaName = this.$EntitySchemaName;
					var entitySchemaCaption = this.$EntitySchemaCaption;
					this.loadAnyEntity(entitySchemaName, entityId, function(entity) {
					entity.caption = entitySchemaCaption;
					entity.name = entitySchemaName;
					this.set("Entity", entity);
					}, this);
				} else {
					this.set("Entity", null);
				}
			},

			/**
			 * Caches schema name and caption. Sets Entity property.
			 * @param {BPMSoft.Collection} schemasCollection Cached schemas.
			 * @param {Object} schemaConfig Entity schema configuration.
			 * @param {String} schemaConfig.UId Entity schema unique identifier.
			 * @param {String} schemaConfig.Name Entity schema name.
			 * @param {String} schemaConfig.Caption Entity schema caption.
			 * @param {String} schemaConfig.EntityId Entity identifier.
			 *
			 */
			setEntity: function(schemasCollection, schemaConfig) {
				if (!schemasCollection.contains(schemaConfig.UId)) {
					schemasCollection.add(schemaConfig.UId, {
						entitySchemaName: schemaConfig.Name,
						entitySchemaCaption: schemaConfig.Caption
					});
				}
				this.loadAnyEntity(schemaConfig.Name, schemaConfig.EntityId, function(entity) {
					entity.caption = schemaConfig.Caption;
					entity.name = schemaConfig.Name;
					this.set("Entity", entity);
				}, this);
			},

			/**
			 * @inheritdoc BPMSoft.MiniPageUtilities#linkMouseOver
			 * @override
			 */
			linkMouseOver: function(options, entityInfo) {
				if (options && options.targetId) {
					var columnName = Ext.isObject(entityInfo) ? entityInfo.columnName : entityInfo;
					var entitySchemaName = Ext.isObject(entityInfo) ? entityInfo.referenceSchemaName : null;
					if (columnName === "Entity") {
						var entity = this.get(columnName);
						entitySchemaName = entity ? entity.name : null;
					}
					var config = {
						columnName: columnName,
						targetId: options.targetId,
						entitySchemaName: entitySchemaName
					};
					this.openMiniPage(config);
				}
			},

			/**
			 * Click event handler on entity url.
			 * @return {Boolean} Determines if link click handler must be called.
			 */
			onEntityClick: function() {
				return true;
			},

			/**
			 * Click event handler on author url.
			 * @return {Boolean} Determines if link click handler must be called.
			 */
			onCreateByClick: function() {
				return !this.isSSPUser();
			},

			/**
			 * Gets social message channel link.
			 */
			getCreatedPublishUrl: function() {
				var entity = this.get("Entity");
				var url;
				if (entity) {
					var typeId = entity.type ? entity.type.value : null;
					var hash = NetworkUtilities.getEntityUrl(entity.name, entity.value, typeId);
					url = this.viewModuleUrl + hash;
				}
				return url;
			},

			/**
			 * Gets social message author link.
			 */
			getCreatedUrlContact: function() {
				var createdBy = this.get("CreatedBy");
				var url;
				if (createdBy) {
					var hash = NetworkUtilities.getEntityUrl("Contact", createdBy.value, createdBy.TypedValue);
					url = this.viewModuleUrl + hash;
				}
				return url;
			},

			/**
			 * Returns link preview visible value.
			 * @return {Boolean}
			 */
			getLinkPreviewVisible: function() {
				return !Ext.isEmpty(this.get("LinkPreviewData"));
			}

			//endregion

		});
	});
