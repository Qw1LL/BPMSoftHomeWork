define("TagUtilitiesV2", ["BPMSoft", "MaskHelper", "ModalBox", "TagConstantsV2"],
	function(BPMSoft, MaskHelper, ModalBox, TagConstants) {
		/**
		 * @class BPMSoft.configuration.mixins.TagUtilities
		 * ######, ########### ###### ###### ##### # ######## # ######### ##############.
		 */
		Ext.define("BPMSoft.configuration.mixins.TagUtilities", {
			alternateClassName: "BPMSoft.TagUtilities",

			modalBoxContainer: null,

			/**
			 * ######## ##### ##### #######
			 * @Type {string}
			 */
			tagSchemaName: null,

			/**
			 * ######## ##### ##### # ###### #######
			 * @Type {string}
			 */
			inTagSchemaName: null,

			modalBoxSize: {
				widthPixels: "560",
          		heightPixels: "310"
			},

			/**
			 * ########## ############# ######### # ######### ####.
			 * @protected
			 * @return {Object}
			 */
			getFixedHeaderContainer: function() {
				return ModalBox.getFixedBox();
			},

			/**
			 * ########## ######## ######### # ######### ####.
			 * @protected
			 * @return {Object}
			 */
			getGridContainer: function() {
				return this.modalBoxContainer;
			},

			/**
			 * ########## ###### ## ###### ##### (### ######) # ## ######### #####.
			 * @private
			 * @return {BPMSoft.FilterGroup}
			 */
			getCurrentUserAndTypesFilter: function() {
				var filterGroup = new this.BPMSoft.createFilterGroup();
				filterGroup.logicalOperation = this.BPMSoft.LogicalOperatorType.OR;
				var innerFilterGroupCreatedBy = new this.BPMSoft.createFilterGroup();
				innerFilterGroupCreatedBy.add("CurrentUser", this.BPMSoft.createColumnFilterWithParameter(
					this.BPMSoft.ComparisonType.EQUAL, "Tag.CreatedBy", this.BPMSoft.SysValue.CURRENT_USER_CONTACT.value));
				innerFilterGroupCreatedBy.add("PrivateType", this.BPMSoft.createColumnFilterWithParameter(
					this.BPMSoft.ComparisonType.EQUAL, "Tag.Type", TagConstants.TagType.Private));
				var innerFilterGroupOtherTypes = new this.BPMSoft.createFilterGroup();
				var types = [TagConstants.TagType.Corporate, TagConstants.TagType.Public];
				innerFilterGroupOtherTypes.add("OtherTypes", this.BPMSoft.createColumnInFilterWithParameters(
					"Tag.Type", types));
				filterGroup.addItem(innerFilterGroupCreatedBy);
				filterGroup.addItem(innerFilterGroupOtherTypes);
				return filterGroup;
			},

			/**
			 * ######### ####### #### # ############ # #########.
			 * @public
			 */
			updateSize: function() {
				ModalBox.updateSizeByContent();
			},

			/**
			 * ############## ######### #### ### ######## #### ###### #####.
			 * @private
			 */
			prepareModalBox: function() {
				this.modalBoxContainer = ModalBox.show(this.modalBoxSize);
				ModalBox.setSize(1, 1);
			},

			/**
			 * ######### ######### #### Lookup-# # ######### ######.
			 * @public
			 */
			closeModalBox: function() {
				if (this.modalBoxContainer) {
					ModalBox.close();
					this.modalBoxContainer = null;
				}
			},

			/**
			 * ######### id ############ ###### #####.
			 * @protected
			 * @param {object} sandbox
			 * @return {string} id ######
			 */
			getTagModulePageId: function(sandbox) {
				return sandbox.id + "_TagModule";
			},

			/**
			 * ######### ###### #####
			 * @protected
			 * @param {object} config ###### ######
			 */
			openTagModule: function(config) {
				var scope = config.scope;
				var sandbox = config.sandbox || scope.sandbox;
				var tagModulePageId = this.getTagModulePageId(sandbox);
				this.prepareModalBox();
				var tagModuleConfig = {
					renderTo: this.getGridContainer(),
					id: tagModulePageId,
					parameters: {
						TagSchemaName: config.entityTagSchemaName,
						InTagSchemaName: config.entityInTagSchemaName,
						RecordId: config.entityRecordId
					}
				};
				sandbox.loadModule("TagModule", tagModuleConfig);
			},

			/**
			 * ######### ######### ###### ##### (########## ##### ## ######).
			 * @protected
			 * @param {string} recordId - ############# ######
			 */
			reloadTagCount: function(recordId) {
				if (recordId) {
					this.initTagButtonCaption(recordId);
				} else {
					this.initTagButtonCaption();
				}
			},

			/**
			 * Initializes section tag properties.
			 * @protected
			 * @param {String} schemaName Section schema name.
			 */
			initTags: function(schemaName) {
				if (this.get("UseTagModule")) {
					this.on("change:TagButtonVisible", this.initTagButtonCaption.bind(this, null));
					this.checkSchemaExists((this.inTagSchemaName || (schemaName + "InTag")), function(schemaName) {
						var tagSchemaExists = (schemaName !== null);
						this.set("TagButtonVisible", tagSchemaExists);
					});
				} else {
					this.set("TagButtonVisible", false);
				}
			},

			/**
			 * ############### ###### #####.
			 * @protected
			 */
			initTagButton: function() {
				if (this.get("UseTagModule") && this.get("TagButtonVisible")) {
					BPMSoft.delay(this.initTagButtonCaption, this, 500);
				}
			},

			/**
			 * ############## ######### ###### (########## ##### # ######).
			 * @protected
			 * @param {String} primaryColumnValue  ############# ######
			 */
			initTagButtonCaption: function(primaryColumnValue) {
				if (!this.destroyed && this.get("TagButtonVisible")) {
					var recordId = null;
					if (!primaryColumnValue) {
						recordId = this.getCurrentRecordId();
					} else {
						recordId = primaryColumnValue;
					}
					if (recordId && recordId !== null && !this.Ext.isArray(recordId)) {
						var esq = Ext.create("BPMSoft.EntitySchemaQuery", {
							rootSchemaName: (this.inTagSchemaName) || (this.entitySchemaName + "InTag")
						});
						esq.addColumn("Tag");
						var filter = this.getCurrentUserAndTypesFilter();
						var filterGroup = this.Ext.create("BPMSoft.FilterGroup");
						filterGroup.addItem(this.BPMSoft.createColumnFilterWithParameter(this.BPMSoft.ComparisonType.EQUAL,
								"Entity", recordId));
						filterGroup.addItem(filter);
						esq.filters.add(filterGroup);
						esq.getEntityCollection(function(result) {
							if (result.success) {
								var collection = result.collection;
								if (collection) {
									if (collection.getCount() > 0) {
										this.set("TagButtonCaption", collection.getCount());
									} else {
										this.set("TagButtonCaption", "");
									}
								}
							}
						}, this);
					} else {
						this.set("TagButtonCaption", "");
					}
				}
			},

			/**
			 * ######### ####### ####### ### ###### #####.
			 * @protected
			 * @param {string} name ######## #######
			 * @param {Function} callback #######-callback
			 */
			checkSchemaExists: function(name, callback) {
				this.BPMSoft.EntitySchemaManager.initialize(function() {
					var item = this.BPMSoft.EntitySchemaManager.getItems()
						.filterByFn(function(item) {
							return item.name === name;
						})
						.first();
					callback.call(this, (item && item.name) || null);
				}, this);
			},

			/**
			 * ########## ###### "###".
			 * @protected
			 */
			onTagButtonClick: function() {
				this.showTagModule();
			},

			/**
			 * ######### ######, #### ### ########,
			 * # ########## ####### # ###### # ############# ####### ###### #####.
			 * @protected
			 */
			saveCardAndLoadTagsFromSection: function() {
				if (this.isChanged()) {
					var config = {
						callback: this.publishSectionMessage,
						isSilent: true,
						callBaseSilentSavedActions: true
					};
					this.save(config);
				} else {
					this.publishSectionMessage();
				}
			},

			/**
			 * ########## ######### # ###### # ############# ####### ###### #####.
			 * @protected
			 */
			publishSectionMessage: function() {
				this.sandbox.publish("CardChanged", {
					key: "CanShowTags",
					value: true
				}, [this.sandbox.id]);
			},

			/**
			 * ######### ########## ###### ##### ######### ###### #####.
			 * @protected
			 */
			saveCardAndLoadTags: function() {
				if (this.isChanged()) {
					var config = {
						callback: this.showTagModule,
						isSilent: true,
						callBaseSilentSavedActions: true
					};
					this.save(config);
				} else {
					this.showTagModule();
				}
			},

			/**
			 * ########## ###### #####.
			 * @protected
			 */
			showTagModule: function() {
				var config = {
					scope: this,
					sandbox: this.sandbox,
					entityTagSchemaName: (this.tagSchemaName) || (this.entitySchemaName + "Tag"),
					entityInTagSchemaName: (this.inTagSchemaName) || (this.entitySchemaName + "InTag"),
					entityRecordId: this.getCurrentRecordId()
				};
				this.openTagModule(config);
			},

			/**
			 * ########## ############# ####### ######## ######.
			 * @virtual
			 * @protected
			 */
			getCurrentRecordId: this.BPMSoft.emptyFn
		});
	}
);
