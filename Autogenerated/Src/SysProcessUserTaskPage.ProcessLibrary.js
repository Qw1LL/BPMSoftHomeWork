define("SysProcessUserTaskPage", ["SysProcessUserTaskPageResources", "GeneralDetails"],
function(resources) {
	return {
		entitySchemaName: "SysProcessUserTask",
		details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "insert",
				"parentName": "Header",
				"propertyName": "items",
				"name": "ImageContainer",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["image-edit-container"],
					"layout": {"column": 0, "row": 0, "rowSpan": 3, "colSpan": 3},
					"items": []
				}
			},
			{
				"operation": "insert",
				"parentName": "ImageContainer",
				"propertyName": "items",
				"name": "Photo",
				"values": {
					"getSrcMethod": "getSrcMethod",
					"onPhotoChange": "onImageChange",
					"readonly": false,
					"defaultImage": {"bindTo": "getDefaultImageURL"},
					"generator": "ImageCustomGeneratorV2.generateCustomImageControl"
				}
			},
			{
				"operation": "insert",
				"name": "Caption",
				"values": {
					"layout": {
						"column": 3,
						"row": 0,
						"colSpan": 21
					},
					"bindTo": "Caption",
					"enabled": true
				},
				"parentName": "Header",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "SysUserTaskSchema",
				"parentName": "Header",
				"propertyName": "items",
				"values": {
					"controlConfig": {
						"prepareList": {
							"bindTo": "onPrepareSysUserTaskSchemaList"
						}
					},
					"layout": {
						"column": 3,
						"row": 1,
						"colSpan": 21
					}
				}
			},
			{
				"operation": "insert",
				"name": "QuickModelEditPageSchema",
				"parentName": "Header",
				"propertyName": "items",
				"values": {
					"controlConfig": {
						"prepareList": {
							"bindTo": "onPrepareQuickModelEditPageSchemaList"
						}
					},
					"layout": {
						"column": 3,
						"row": 2,
						"colSpan": 21
					}
				}
			}
		]/**SCHEMA_DIFF*/,
		attributes: {
			"SysUserTaskSchema": {
				dataValueType: BPMSoft.DataValueType.ENUM,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				isRequired: true,
				caption: resources.localizableStrings.SysProcessUserTaskSchemaCaption,
				isLookup: true,
				referenceSchemaName: "VwSysSchemaInfo"
			},
			/**
			 * ###### #######, ############ ### ###### ######## ## ###########
			 */
			"SysUserTaskSchemaList": {
				dataValueType: BPMSoft.DataValueType.ENUM,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				isCollection: true,
				value: Ext.create("BPMSoft.Collection")
			},
			"QuickModelEditPageSchema": {
				dataValueType: BPMSoft.DataValueType.ENUM,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				isRequired: true,
				caption: resources.localizableStrings.QuickModelPageSchemaCaption,
				isLookup: true,
				referenceSchemaName: "VwSysSchemaInfo"
			},
			/**
			 * ###### #######, ############ ### ###### ######## ## ###########
			 */
			"QuickModelEditPageSchemaList": {
				dataValueType: BPMSoft.DataValueType.ENUM,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				isCollection: true,
				value: Ext.create("BPMSoft.Collection")
			}
		},
		methods: {
			/**
			 * @overridden
			 */
			onEntityInitialized: function() {
				if (this.isEditMode()) {
					var sysUserTaskSchemaUId = this.get("SysUserTaskSchemaUId");
					var quickModelEditPageSchemaUId = this.get("QuickModelEditPageSchemaUId");
					if (this.BPMSoft.isGUID(sysUserTaskSchemaUId)) {
						//TODO ######## ###### ## Workspc-#
						this.loadLookupDisplayValue("SysUserTaskSchema", sysUserTaskSchemaUId);
					}
					if (this.BPMSoft.isGUID(sysUserTaskSchemaUId)) {
						//TODO ######## ###### ## Workspc-#
						this.loadLookupDisplayValue("QuickModelEditPageSchema", quickModelEditPageSchemaUId);
					}
				}
				this.callParent(arguments);
			},
			/**
			 * TODO
			 * @returns {*}
			 */
			getSrcMethod: function() {
				var primaryImageColumnValue = this.get(this.primaryImageColumnName);
				if (primaryImageColumnValue) {
					return this.getSchemaImageUrl(primaryImageColumnValue);
				}
				return this.getDefaultImageURL();
			},

			/**
			 * Returns default image url.
			 * @return {String} Default image url.
			 */
			getDefaultImageURL: function() {
				return this.BPMSoft.ImageUrlBuilder.getUrl(resources.localizableImages.DefaultImage);
			},

			/**
			 * TODO
			 * @param image
			 */
			onImageChange: function(image) {
				if (!image) {
					this.set(this.primaryImageColumnName, null);
					return;
				}
				this.BPMSoft.ImageApi.upload({
					file: image,
					onComplete: this.onImageUploaded,
					onError: this.BPMSoft.emptyFn,
					scope: this
				});
			},
			/**
			 * TODO
			 * @param imageId
			 */
			onImageUploaded: function(imageId) {
				var imageData = {
					value: imageId,
					displayValue: "SysImage"
				};
				this.set(this.primaryImageColumnName, imageData);
			},
			/**
			 * ########## ####### ########## ###### ### ########### ###### #### ################ ########
			 * @filter {Object} ###### ### ########## ######
			 * @list {BPMSoft.Collection} ###### ### ########### ######
			 * @protected
			 */
			onPrepareSysUserTaskSchemaList: function(filter, list) {
				list.clear();
				var esq = Ext.create("BPMSoft.EntitySchemaQuery", {
					rootSchemaName: "VwSysSchemaInfo"
				});
				esq.addColumn("Id");
				esq.addColumn("Caption");
				esq.filters.add("SysWorkspace", BPMSoft.createColumnFilterWithParameter(
					BPMSoft.ComparisonType.EQUAL, "SysWorkspace",
					BPMSoft.SysValue.CURRENT_WORKSPACE.value));
				esq.filters.add("ManagerName", BPMSoft.createColumnFilterWithParameter(
					BPMSoft.ComparisonType.EQUAL, "ManagerName", "ProcessUserTaskSchemaManager"));
// TODO ######## ###### ## ## QuickModel #########
//				esq.filters.add("NotQuickModel", BPMSoft.createColumnFilterWithParameter(
//					BPMSoft.ComparisonType.EQUAL, "[SysProcessUserTask:SysUserTaskSchemaUId:Id].IsQuickModel",
//					false));
				esq.getEntityCollection(function(response) {
					var collection = response.collection;
					var rows = {};
					if (collection && collection.collection.length > 0) {
						BPMSoft.each(collection.collection.items, function(item) {
							var listValue = {
								value: item.values.Id,
								displayValue: item.values.Caption
							};
							rows[item.values.Id] = listValue;
						}, this);
					}
					var sortedList = Ext.create("BPMSoft.Collection");
					sortedList.loadAll(rows);
					sortedList.sort("displayValue", BPMSoft.OrderDirection.ASC);
					list.loadAll(sortedList);
				}, this);
			},
			/**
			 * ########## ####### ########## ###### ### ########### ###### #### ####### ##############
			 * @filter {Object} ###### ### ########## ######
			 * @list {BPMSoft.Collection} ###### ### ########### ######
			 * @protected
			 */
			onPrepareQuickModelEditPageSchemaList: function(filter, list) {
				list.clear();
				var esq = Ext.create("BPMSoft.EntitySchemaQuery", {
					rootSchemaName: "VwSysSchemaInfo"
				});
				esq.addColumn("Id");
				esq.addColumn("Caption");
				esq.filters.add("SysWorkspace", BPMSoft.createColumnFilterWithParameter(
					BPMSoft.ComparisonType.EQUAL, "SysWorkspace",
					BPMSoft.SysValue.CURRENT_WORKSPACE.value));
				esq.filters.add("ManagerName", BPMSoft.createColumnFilterWithParameter(
					BPMSoft.ComparisonType.EQUAL, "ManagerName", "ClientUnitSchemaManager"));
				esq.getEntityCollection(function(response) {
					var collection = response.collection;
					var rows = {};
					if (collection && collection.collection.length > 0) {
						BPMSoft.each(collection.collection.items, function(item) {
							var listValue = {
								value: item.values.Id,
								displayValue: item.values.Caption
							};
							rows[item.values.Id] = listValue;
						}, this);
					}
					var sortedList = Ext.create("BPMSoft.Collection");
					sortedList.loadAll(rows);
					sortedList.sort("displayValue", BPMSoft.OrderDirection.ASC);
					list.loadAll(sortedList);
				}, this);
			},
			/**
			 * @overridden
			 */
			saveEntityInChain: function(next) {
				this.set("IsQuickModel", true);
				this.set("SysUserTaskSchemaUId", this.get("SysUserTaskSchema").value);
				this.set("QuickModelEditPageSchemaUId", this.get("QuickModelEditPageSchema").value);
				var saveEntity = function() {
					this.saveEntity(function(response) {
						if (this.validateResponse(response)) {
							this.cardSaveResponse = response;
							next();
						}
					}, this);
				};
				if (!this.BPMSoft.isGUID(this.primaryColumnValue)) {
					var esq = Ext.create("BPMSoft.EntitySchemaQuery", {
						rootSchemaName: "SysProcessUserTask"
					});
					esq.addColumn("Id");
					esq.filters.add("SysUserTaskSchemaUId", BPMSoft.createColumnFilterWithParameter(
						BPMSoft.ComparisonType.EQUAL, "SysUserTaskSchemaUId", this.get("SysUserTaskSchema").value));
					esq.getEntityCollection(function(response) {
						var entities = response.collection;
						if (entities.getCount() === 0) {
							saveEntity.call(this);
							return;
						}
						var entity = response.collection.getByIndex(0);
						this.primaryColumnValue = entity.get("Id");
						this.set("Id", this.primaryColumnValue);
						this.isNew = false;
						saveEntity.call(this);
					});
				} else {
					saveEntity.call(this);
				}
			}
		},
		rules: {},
		userCode: {}
	};
});
