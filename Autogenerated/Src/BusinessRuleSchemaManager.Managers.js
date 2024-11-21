define("BusinessRuleSchemaManager", ["BusinessRulesApplierV2", "PackageSchemaBuilder",
	"BusinessRuleSchemaManagerResources", "BusinessRuleConverter", "BusinessRuleSchemaManagerItem",
	"SysModuleEditManager", "SysModuleEntityManager", "BusinessRuleCaptionGenerator", "ViewModelSchemaDesignerUtils"
], function(BusinessRulesApplier, SchemaBuilder, resources) {

	/**
	 * @class BPMSoft.manager.BusinessRuleSchemaManager
	 * Business rule schema manager class
	 */
	Ext.define("BPMSoft.manager.BusinessRuleSchemaManager", {
		extend: "BPMSoft.BaseSchemaManager",
		alternateClassName: "BPMSoft.BusinessRuleSchemaManager",

		singleton: true,

		//region Properties: Private

		/**
		 * @private
		 */
		viewModelClassCollection: null,

		/**
		 * @private
		 */
		dataSourceCollection: null,

		// endregion

		//region Properties: Protected

		/**
		 * @inheritdoc BPMSoft.BaseManager#itemClassName
		 * @overridden
		 */
		itemClassName: "BPMSoft.BusinessRuleSchemaManagerItem",

		/**
		 * Current package uId.
		 * @protected
		 * @type {String}
		 */
		currentPackageUId: null,

		/**
		 * Entity schema name.
		 * @protected
		 * @type {String}
		 */
		entitySchemaName: null,

		/**
		 * Entity schema uId.
		 * @protected
		 */
		entitySchemaUId: null,

		/**
		 * Business rule converter.
		 * @protected
		 */
		converter: null,

		/**
		 * Array of client unit schemas for which manager is initialized.
		 * @protected
		 * @type {Array}
		 */
		initializedClientUnitSchemas: [],

		/**
		 * Entity schema.
		 * @protected
		 * @type {BPMSoft.EntitySchema}
		 */
		entitySchema: null,

		/**
		 * Business rule caption generator.
		 * @protected
		 * @type {BPMSoft.BusinessRuleCaptionGenerator}
		 */
		businessRuleCaptionGenerator: null,

		// endregion

		// region Methods: Private

		/**
		 * Generates business rule schema manager items for certain client unit schema.
		 * @private
		 * @param {String} pageSchemaUId Page schema uId.
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Callback function context.
		 */
		generateClientUnitSchemaBusinessRuleItems: function(pageSchemaUId, callback, scope) {
			if (BPMSoft.contains(this.initializedClientUnitSchemas, pageSchemaUId)) {
				callback.call(scope);
				return;
			}
			BPMSoft.chain(
				function(next) {
					if (this.entitySchemaName) {
						BPMSoft.EntitySchemaManager.getPackageSchemaInstanceBySchemaName(
							this.entitySchemaName, this.currentPackageUId, function(instance) {
								this.entitySchema = instance;
								next();
							}, this
						);
					} else {
						next();
					}
				},
				function(next) {
					this._initViewModelClass(pageSchemaUId, next, this);
				},
				function(next) {
					this._initDataSource(pageSchemaUId, next, this);
				},
				function(next) {
					this.converter.pageSchemaUId = pageSchemaUId;
					const viewModelClass = this.viewModelClassCollection.get(pageSchemaUId);
					this.getBusinessRuleMetaItemConfig(viewModelClass.prototype.rules, next, this);
				},
				function(next, newRuleConfig) {
					const ruleCollection = this.generateBusinessRuleSchemaCollection(newRuleConfig, pageSchemaUId);
					this.initManagerItems(ruleCollection, pageSchemaUId, next, this);
				},
				function() {
					this.initializedClientUnitSchemas.push(pageSchemaUId);
					callback.call(scope);
				},
				this
			);
		},

		/**
		 * @private
		 * @param {String} pageSchemaUId Unique identifier of client schema.
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Callback function context.
		 */
		_initDataSource: function(pageSchemaUId, callback, scope) {
			const viewModelClass = this._getViewModelClassByPageSchemaUId(pageSchemaUId);
			const dataModelsConfig = viewModelClass.prototype.dataModelCollection.dataModelsConfig;
			const config = {
				schemaUId: pageSchemaUId,
				packageUId: this.currentPackageUId
			};
			const dataSource = {};
			BPMSoft.ClientUnitSchemaManager.designPageSchema(config, function(schema) {
				BPMSoft.each(dataModelsConfig, function(dataModel, key) {
					const entitySchemaName = dataModel.entitySchemaName;
					const resourcesName = BPMSoft.ViewModelSchemaDesignerUtils
						.generateDataModelCaptionResourcesName(key);
					const stringValue = schema.localizableStrings.find(resourcesName);
					const displayValue = stringValue && stringValue.toString();
					if (!Ext.isEmpty(entitySchemaName)) {
						dataSource[key] = {
							value: key,
							displayValue: displayValue || key,
							entitySchemaName: entitySchemaName
						};
					}
				}, this);
				this.dataSourceCollection.add(pageSchemaUId, dataSource);
				callback.call(scope);
			}, this);
		},

		_cacheViewModelItems: function(config, callback, scope) {
			const schema = config.schema;
			const generatedSchema = config.generatedSchema;
			const viewModelClass = config.viewModelClass;
			const clientUnitSchemaUId = config.clientUnitSchemaUId;
			BPMSoft.chain(
				function(next) {
					this._cacheViewModelDetails({
						viewModelClass: viewModelClass,
						clientUnitSchemaUId: clientUnitSchemaUId
					}, next, this);
				},
				function() {
					this._cacheViewModelAttributes({
						clientUnitSchemaUId: clientUnitSchemaUId,
						viewModelClass: viewModelClass,
						schema: schema
					});
					this._cacheViewModelTabs({
						viewModelClass: viewModelClass,
						clientUnitSchemaUId: clientUnitSchemaUId
					});
					const data = {
						groups: [],
						modules: []
					};
					this._getViewModelGroupsAndModules(data, viewModelClass, generatedSchema.viewConfig);
					this._cacheViewModelModules({
						modules: data.modules,
						clientUnitSchemaUId: clientUnitSchemaUId
					});
					this._cacheViewModelGroups({
						groups: data.groups,
						clientUnitSchemaUId: clientUnitSchemaUId
					});
					this.viewModelClassCollection.add(clientUnitSchemaUId, viewModelClass);
					callback.call(scope);
				}, this);
		},

		/**
		 * Returns view model class.
		 * @private
		 * @param {String} clientUnitSchemaUId Client unit schema uId.
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Callback function context.
		 */
		_initViewModelClass: function(clientUnitSchemaUId, callback, scope) {
			let schema;
			let viewModelClass;
			let viewModelClassConfig;
			let generatedSchema;
			BPMSoft.chain(
				function(next) {
					const config = {
						schemaUId: clientUnitSchemaUId,
						packageUId: this.currentPackageUId
					};
					BPMSoft.ClientUnitSchemaManager.findBundleSchemaInstance(config, function(result) {
						schema = result;
						next();
					}, this);
				},
				function(next) {
					const config = {
						schemaName: this.getSchemaHierarchyName(schema.name),
						entitySchemaName: this.entitySchemaName,
						useCache: false,
						customAttributes: this._getCustomAttributes(schema),
						packageUId: this.currentPackageUId
					};
					SchemaBuilder.build(config, function(viewModelClassItem, viewModelClassItemConfig, buildedSchema) {
						viewModelClass = viewModelClassItem;
						viewModelClassConfig = viewModelClassItemConfig;
						generatedSchema = buildedSchema;
						next();
					}, this);
				},
				function() {
					this._cacheViewModelItems({
						schema: schema,
						generatedSchema: generatedSchema,
						viewModelClass: viewModelClass,
						clientUnitSchemaUId: clientUnitSchemaUId,
						viewModelClassConfig: viewModelClassConfig
					}, callback, scope);
				}, this);
		},

		/**
		 * Returns name for client unit schema in hierarchy.
		 * @private
		 * @param {String} schemaName Client unit schema name.
		 * @return {String} Hierarchy schema name.
		 */
		getSchemaHierarchyName: function(schemaName) {
			let name = schemaName + this.currentPackageUId;
			name = requirejs.specified(name) ? name : schemaName;
			return name;
		},

		/**
		 * Returns business rule schema meta item config.
		 * @private
		 * @param {Array} businessRuleConfig Business rules config.
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Callback function context.
		 */
		getBusinessRuleMetaItemConfig: function(businessRuleConfig, callback, scope) {
			this.converter.convertToMetaItemConfig(businessRuleConfig, function(newRuleConfig) {
				callback.call(scope, newRuleConfig);
			}, this);
		},

		/**
		 * Returns business rule schema collection.
		 * @private
		 * @param {Object} newRuleConfig Business rule meta items config.
		 * @param {String} pageSchemaUId Client unit schema UId.
		 * @return {Array} Business rule schemas.
		 */
		generateBusinessRuleSchemaCollection: function(newRuleConfig, pageSchemaUId) {
			const businessRuleSchemaCollection = [];
			BPMSoft.each(newRuleConfig, function(configItem) {
				const itemClassName = BPMSoft.BusinessRuleElementHelper.getClassNameByType(configItem.type);
				delete configItem.type;
				configItem.pageSchemaUId = pageSchemaUId;
				let businessRuleSchema;
				try {
					businessRuleSchema = Ext.create(itemClassName, configItem);
				} catch (e) {
					console.warn(Ext.String.format("{0}: {1} ({2})", configItem.name,
						BPMSoft.Resources.Exception.ItemNotFoundException, e.message));
					delete configItem.ruleSwitch;
					const className = BPMSoft.BusinessRuleElementHelper.getClassNameByType("InvalidBusinessRule");
					businessRuleSchema = Ext.create(className, configItem);
				}
				businessRuleSchemaCollection.push(businessRuleSchema);
			});
			return businessRuleSchemaCollection;
		},

		/**
		 * Return business rule caption generator.
		 * @private
		 * @return {BPMSoft.BusinessRuleCaptionGenerator} Business rule caption generator.
		 */
		getBusinessRuleCaptionGenerator: function() {
			if (!this.businessRuleCaptionGenerator) {
				this.businessRuleCaptionGenerator = Ext.create("BPMSoft.BusinessRuleCaptionGenerator");
			}
			return this.businessRuleCaptionGenerator;
		},

		/**
		 * Initialize new manager items.
		 * @private
		 * @param {Array} businessRuleSchemas Business rule schema collection.
		 * @param {String} clientUnitSchemaUId Base client unit schema uId.
		 * @param {Function} callback The callback function.
		 * @param {Object} scope The scope of callback function.
		 */
		initManagerItems: function(businessRuleSchemas, clientUnitSchemaUId, callback, scope) {
			const businessRuleCaptionGenerator = this.getBusinessRuleCaptionGenerator();
			BPMSoft.eachAsync(
				businessRuleSchemas,
				function(schema, next) {
					schema.entitySchema = this.entitySchema;
					businessRuleCaptionGenerator.generateUniqueCaption(schema, function(generateCaption) {
						schema.initLocalizableStringValue("caption", generateCaption);
						const initialConfig = {
							id: schema.uId,
							uId: schema.uId,
							name: schema.name,
							caption: schema.caption,
							instance: schema,
							clientUnitSchemaUId: clientUnitSchemaUId,
							status: BPMSoft.ModificationStatus.NOT_MODIFIED
						};
						const managerItem = this.createManagerItem(initialConfig);
						this.addItem(managerItem);
						next();
					}, this);
				},
				function() {
					businessRuleCaptionGenerator.updateDuplicateCaptions(this.getItems());
					callback.call(scope);
				}, this
			);
		},

		/**
		 * Returns sorted business rule collection by client unit schemas.
		 * @private
		 * @param {BPMSoft.core.collections.Collection|BPMSoft.BusinessRuleSchemaManagerItem[]} items Collection of manager items.
		 * @returns {Object} Sorted business rule collection.
		 */
		getClientUnitSchemasBusinessRulesCollection: function(items) {
			const rules = {};
			BPMSoft.each(items, function(item) {
				const schemaUId = item.getClientUnitSchemaUId();
				rules[schemaUId] = rules[schemaUId] || [];
				rules[schemaUId].push(item.instance);
			}, this);
			return rules;
		},

		/**
		 * Returns client unit schema instance in current package.
		 * @private
		 * @param {String} clientUnitSchemaUId client unit schema uid.
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Callback function context.
		 */
		getClientUnitSchemaInstance: function(clientUnitSchemaUId, callback, scope) {
			BPMSoft.chain(
				function(next) {
					BPMSoft.ClientUnitSchemaManager.forceGetPackageSchema({
						packageUId: this.currentPackageUId,
						schemaUId: clientUnitSchemaUId
					}, next, this);
				},
				function(next, clientUnitSchema) {
					if (!BPMSoft.ClientUnitSchemaManager.contains(clientUnitSchema.uId)) {
						clientUnitSchema.setDefaultSchemaBody(BPMSoft.SchemaType.EDIT_VIEW_MODEL_SCHEMA,
							{"entitySchemaName": this.entitySchemaName});
						BPMSoft.ClientUnitSchemaManager.addSchema(clientUnitSchema);
						callback.call(scope, clientUnitSchema);
					} else {
						callback.call(scope, clientUnitSchema);
					}
				},
				this
			);
		},

		/**
		 * Saves client unit schema business rule.
		 * @private
		 * @param {String} clientUnitSchemaUId Client unit schema uid.
		 * @param {Object} rulesCollection Sorted business rule collection by client unit schemas.
		 * @param {Function} callback The callback function.
		 * @param {Object} scope The scope of callback function.
		 */
		saveClientUnitSchemaBusinessRule: function(clientUnitSchemaUId, rulesCollection, callback, scope) {
			this.getClientUnitSchemaInstance(clientUnitSchemaUId, function(clientUnitSchema) {
				const rules = rulesCollection[clientUnitSchemaUId];
				this.converter.convertFromMetaItems(rules, function(newRuleConfig) {
					const oldRuleConfigStr = clientUnitSchema.getSchemaBusinessRules();
					const oldRuleConfig = JSON.parse(oldRuleConfigStr);
					this.removeDuplicatedRules(oldRuleConfig, newRuleConfig);
					const ruleConfig = BusinessRulesApplier.mergeRules(oldRuleConfig, newRuleConfig);
					clientUnitSchema.setSchemaBusinessRules(ruleConfig);
					clientUnitSchema.define(callback, scope);
				}, this);
			}, this);
		},

		/**
		 * Returns business rule paths. Path contains action column name, rule name and rule uId.
		 * @private
		 * @param {Object} businessRuleConfig Source business rule config.
		 * @return {Array} Business rule paths.
		 */
		getBusinessRulePaths: function(businessRuleConfig) {
			const result = [];
			BPMSoft.each(businessRuleConfig, function(columnRules, columnName) {
				BPMSoft.each(columnRules, function(rule, ruleName) {
					result.push({
						columnName: columnName,
						ruleName: ruleName,
						uId: rule.uId
					});
				}, this);
			}, this);
			return result;
		},

		/**
		 * Finds duplicates in old business rule config.
		 * @private
		 * @param {Object} oldBusinessRuleConfig Old business rule config.
		 * @param {Object} newBusinessRuleConfig New business rule config.
		 * @return {Array} Duplicated business rule paths.
		 */
		findDuplicatedPaths: function(oldBusinessRuleConfig, newBusinessRuleConfig) {
			const oldPaths = this.getBusinessRulePaths(oldBusinessRuleConfig);
			const newPaths = this.getBusinessRulePaths(newBusinessRuleConfig);
			let result = [];
			BPMSoft.each(newPaths, function(newPath) {
				const duplicatePaths = oldPaths.filter(function(oldPath) {
					return oldPath.uId === newPath.uId &&
						(oldPath.columnName !== newPath.columnName || oldPath.ruleName !== newPath.ruleName);
				}, this);
				result = result.concat(duplicatePaths);
			}, this);
			return result;
		},

		/**
		 * Removes duplicates from old business rule config.
		 * @private
		 * @param {Object} oldBusinessRuleConfig Old business rule config.
		 * @param {Object} newBusinessRuleConfig New business rule config.
		 */
		removeDuplicatedRules: function(oldBusinessRuleConfig, newBusinessRuleConfig) {
			const duplicatedPaths = this.findDuplicatedPaths(oldBusinessRuleConfig, newBusinessRuleConfig);
			BPMSoft.each(duplicatedPaths, function(path) {
				delete oldBusinessRuleConfig[path.columnName][path.ruleName];
				if (Ext.Object.isEmpty(oldBusinessRuleConfig[path.columnName])) {
					delete oldBusinessRuleConfig[path.columnName];
				}
			}, this);
		},

		/**
		 * Initialize business rule schema converter.
		 * @private
		 * @param {Object|BPMSoft.EntitySchema} [config] Initial converter config or entity schema.
		 */
		initBusinessRuleSchemaConverter: function(config) {
			if (BPMSoft.isInstanceOfClass(config, "BPMSoft.BaseEntitySchema")) {
				config = {entitySchema: config};
			}
			this.converter = Ext.create("BPMSoft.BusinessRuleConverter", config);
		},

		/**
		 * @private
		 */
		_getEntitySchemaInstance: function(entitySchemaId, callback) {
			if (Ext.isEmpty(entitySchemaId)) {
				callback(null);
				return;
			}
			const moduleEntityItem = BPMSoft.SysModuleEntityManager.getItem(entitySchemaId);
			const entitySchemaUId = moduleEntityItem.getEntitySchemaUId();
			BPMSoft.EntitySchemaManager.getItemByUId(entitySchemaUId, function(entityItem) {
				BPMSoft.require([entityItem.name], function(entitySchema) {
					callback(entitySchema);
				}, this);
			}, this);
		},

		/**
		 * @private
		 */
		_getClientUnitSchemaUIds: function(entitySchemaId, callback) {
			const moduleEntityItem = BPMSoft.SysModuleEntityManager.getItem(entitySchemaId);
			moduleEntityItem.getSysModuleEditManagerItems(function(sysModuleEditItems) {
				let clientUnitSchemaUIds = sysModuleEditItems.mapArray(function(item) {
					return item.isDeleted ? null : item.getCardSchemaUId();
				}, this);
				clientUnitSchemaUIds = BPMSoft.compact(clientUnitSchemaUIds);
				callback(clientUnitSchemaUIds);
			}, this);
		},

		/**
		 * @private
		 */
		_initClientUnitSchemas: function(clientUnitSchemaUIds, callback) {
			BPMSoft.eachAsync(
				clientUnitSchemaUIds,
				function(clientUnitSchemaUId, callbackFn) {
					this.generateClientUnitSchemaBusinessRuleItems(clientUnitSchemaUId, callbackFn, this);
				},
				callback,
				this
			);
		},

		/**
		 * Remove module edit manager item handler.
		 * @private
		 * @param {Object} removedManagerItem Removed manager item.
		 */
		onRemoveSysModuleEditManagerItem: function(removedManagerItem) {
			const removedClientUnitSchema = removedManagerItem.getCardSchemaUId();
			const removeIndex = this.initializedClientUnitSchemas.indexOf(removedClientUnitSchema);
			if (BPMSoft.contains(this.initializedClientUnitSchemas, removedClientUnitSchema)) {
				this.initializedClientUnitSchemas.splice(removeIndex, 1);
				const managerItems = this.getItems();
				managerItems.each(function(item) {
					if (item.getClientUnitSchemaUId() === removedClientUnitSchema) {
						item.remove();
					}
				});
			}
		},

		/**
		 * @private
		 */
		_initCurrentPackageUId: function(callback, scope) {
			BPMSoft.PackageManager.getCurrentPackageUId(function(currentPackageUId) {
				this.currentPackageUId = currentPackageUId;
				callback.call(scope);
			}, this);
		},

		/**
		 * @private
		 */
		_initManagers: function(callback, scope) {
			BPMSoft.chain(
				function(next) {
					BPMSoft.ClientUnitSchemaManager.initialize(next);
				},
				function(next) {
					BPMSoft.SysModuleEntityManager.initialize(next);
				},
				function(next) {
					BPMSoft.SysModuleEditManager.initialize(next);
				},
				function() {
					callback.call(scope);
				}, this
			);
		},

		/**
		 * Removes business rule from client unit schema.
		 * @private
		 * @param {BPMSoft.manager.ClientUnitSchema} schema Client unit schema.
		 * @param {Object} rules Business rules for delete.
		 */
		_removeRulesFromClientUnitSchema: function(rules, schema) {
			const oldRuleConfigStr = schema.getSchemaBusinessRules();
			const oldRuleConfig = JSON.parse(oldRuleConfigStr);
			BPMSoft.each(rules, function(rule) {
				BPMSoft.each(oldRuleConfig, function(columnRules, columnName) {
					if (columnRules[rule.name]) {
						delete columnRules[rule.name];
					}
					if (BPMSoft.isEmptyObject(columnRules)) {
						delete oldRuleConfig[columnName];
					}
				}, this);
			}, this);
			schema.setSchemaBusinessRules(oldRuleConfig);
		},

		/**
		 * @private
		 */
		_getViewModelClassByPageSchemaUId: function(pageSchemaUId) {
			return pageSchemaUId
				? this.viewModelClassCollection.get(pageSchemaUId)
				: this.viewModelClassCollection.first();
		},

		/**
		 * @private
		 */
		_getCustomAttributes: function(schema) {
			const parameters = schema.parameters;
			const attributes = {};
			parameters.each(function(parameter) {
				attributes[parameter.name] = {
					caption: parameter.caption.toString(),
					dataValueType: parameter.dataValueType,
					isLookup: !Ext.isEmpty(parameter.referenceSchemaName),
					isRequired: parameter.isRequired,
					referenceSchemaName: parameter.referenceSchemaName
				};
			}, this);
			return attributes;
		},

		/**
		 * @private
		 */
		_cacheViewModelAttributes: function(config) {
			const clientUnitSchemaUId = config.clientUnitSchemaUId;
			const columns = config.viewModelClass.prototype.columns;
			const parameters = config.schema.parameters;
			const attributes = [];
			BPMSoft.each(columns, function(column, name) {
				if (this._isPageSchemaVirtualColumn(column) && !parameters.filterByPath("name", name).first()) {
					attributes.push({
						name: name,
						dataValueType: column.dataValueType,
						caption: Ext.isString(column.caption) ? column.caption : name,
						type: column.type,
						referenceSchema: column.referenceSchema,
						referenceSchemaName: column.referenceSchemaName
					});
				}
			}, this);
			const cacheKey = "attributes_" + clientUnitSchemaUId;
			BPMSoft.ClientPageSessionCache.setItem(cacheKey, attributes);
		},

		/**
		 * @private
		 */
		_cacheViewModelModules: function(config) {
			const clientUnitSchemaUId = config.clientUnitSchemaUId;
			const modules = config.modules;
			const cacheKey = "modules_" + clientUnitSchemaUId;
			BPMSoft.ClientPageSessionCache.setItem(cacheKey, modules);
		},

		/**
		 * @private
		 */
		_cacheViewModelTabs: function(config) {
			const clientUnitSchemaUId = config.clientUnitSchemaUId;
			const tabCollectionNames =_.unique(Object.values(config.viewModelClass.prototype.columns)
				.filter(function(column) {
					return column.extraProperties && column.extraProperties.isTabContainer;
				})
				.map(function(column) {
					return column.extraProperties.tabCollectionName;
				}));
			const tabs = [];
			BPMSoft.each(tabCollectionNames, function(tabCollectionName) {
				const tabsCollection = config.viewModelClass.prototype.columns[tabCollectionName].value;
				BPMSoft.each(tabsCollection, function(tab) {
					const name = tab.$Name;
					const caption = tab.$Caption;
					tabs.push({
						name: name,
						caption: Ext.isString(caption) ? caption : name
					});
				}, this);
			}, this);
			const cacheKey = "tabs_" + clientUnitSchemaUId;
			BPMSoft.ClientPageSessionCache.setItem(cacheKey, tabs);
		},

		/**
		 * @private
		 */
		_getNotFilledDetailManagerItems: function(notFindDetailSchemaNames) {
			const managerItems = BPMSoft.ClientUnitSchemaManager.getItems();
			const notFilledDetailManagerItems = [];
			BPMSoft.each(notFindDetailSchemaNames, function(detail) {
				const hasSchema = notFilledDetailManagerItems.some(function(item) {
					return item.getName() === detail.schemaName;
				});
				if (!hasSchema) {
					const managerItem = managerItems.firstOrDefault(function(item) {
						return item.getName() === detail.schemaName && !item.getExtendParent();
					}, this);
					if (managerItem) {
						notFilledDetailManagerItems.push(managerItem);
					}
				}
			}, this);
			return notFilledDetailManagerItems;
		},

		/**
		 * @private
		 */
		_getNotFilledDetailResources: function(config, callback, scope) {
			const details = [];
			const notFilledDetails = config.notFilledDetails;
			const notFilledDetailManagerItems =
				this._getNotFilledDetailManagerItems(notFilledDetails);
			const promiseChain = notFilledDetailManagerItems.map(function(item) {
				const clientUnitSchemaManagerConfig = {
					schemaUId: item.uId,
					packageUId: this.currentPackageUId
				};
				return new Promise(function(resolve) {
					BPMSoft.ClientUnitSchemaManager.findBundleSchemaInstance(clientUnitSchemaManagerConfig, function(instance) {
						resolve(instance);
					}, this);
				}.bind(this));
			}, this);
			Promise.all(promiseChain).then(function(instances) {
				BPMSoft.each(notFilledDetails, function(detail) {
					const designSchema = instances.filter(function(instance) {
						return instance.name === detail.schemaName;
					})[0];
					const caption = designSchema && designSchema.localizableStrings.get("Caption");
					const captionValue = caption && caption.getValue();
					details.push({
						name: detail.name,
						caption: Ext.isString(captionValue) ? captionValue: detail.name
					});
				}, this);
				Ext.callback(callback, scope, [details]);
			}.bind(this));
		},

		/**
		 * @private
		 */
		_setCacheViewModelDetails: function(config, callback, scope) {
			const cacheKey = "details_" + config.clientUnitSchemaUId;
			BPMSoft.ClientPageSessionCache.setItem(cacheKey, config.details);
			callback.call(scope);
		},

		/**
		 * @private
		 */
		_cacheViewModelDetails: function(config, callback, scope) {
			const clientUnitSchemaUId = config.clientUnitSchemaUId;
			const detailsCollection = config.viewModelClass.prototype.details;
			const details = [];
			const notFilledDetails = [];
			BPMSoft.each(detailsCollection, function(detail, name) {
				const resourcesName = BPMSoft.ViewModelSchemaDesignerUtils
					.generateDetailCaptionResourcesName(name);
				const resource = config.viewModelClass.prototype.columns["Resources.Strings." + resourcesName];
				const caption = resource && resource.value;
				if (!caption) {
					notFilledDetails.push({
						name: name,
						schemaName: detail.schemaName
					});
				} else {
					details.push({
						name: name,
						caption: caption
					});
				}
			}, this);
			if(notFilledDetails.length > 0) {
				this._getNotFilledDetailResources({
					notFilledDetails: notFilledDetails
				}, function(filledDetails) {
					const detailsWithCaptions = details.concat(filledDetails);
					this._setCacheViewModelDetails({
						details: detailsWithCaptions,
						clientUnitSchemaUId: clientUnitSchemaUId
					}, callback, this);
				}, scope);
			} else {
				this._setCacheViewModelDetails({
					details: details,
					clientUnitSchemaUId: clientUnitSchemaUId
				}, callback, scope);
			}
		},

		/**
		 * @private
		 */
		_cacheViewModelGroups: function(config) {
			const clientUnitSchemaUId = config.clientUnitSchemaUId;
			const groups = config.groups;
			const cacheKey = "groups_" + clientUnitSchemaUId;
			BPMSoft.ClientPageSessionCache.setItem(cacheKey, groups);
		},

		/**
		 * @private
		 */
		_getViewModelGroupsAndModules: function(result, viewModelClass, collection) {
			const emptyControlGroupCaptionTpl = resources.localizableStrings.EmptyControlGroupCaptionTpl;
			BPMSoft.each(collection, function(item) {
				if (item.itemType === BPMSoft.ViewItemType.CONTROL_GROUP) {
					let caption = BPMSoft.getFormattedString(emptyControlGroupCaptionTpl, item.name);
					if (item.caption) {
						if (item.caption.bindTo) {
							const resource = viewModelClass.prototype.columns[item.caption.bindTo];
							if (resource && resource.value) {
								caption = resource.value;
							}
						} else {
							caption = item.caption;
						}
					}
					result.groups.push({
						name: item.name,
						caption: caption
					});
				} else if (item.itemType === BPMSoft.ViewItemType.MODULE) {
					result.modules.push({
						name: item.name,
						caption: Ext.isString(item.moduleName) ? item.moduleName : item.name
					});
				} else if (item.items) {
					this._getViewModelGroupsAndModules(result, viewModelClass, item.items);
				} else if (item.tabs) {
					this._getViewModelGroupsAndModules(result, viewModelClass, item.tabs);
				}
			}, this);
		},

		/**
		 * @private
		 */
		_isPageSchemaVirtualColumn: function(attribute) {
			return Ext.isEmpty(attribute.type) || attribute.type === BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN;
		},

		/**
		 * @private
		 */
		_getActualItems: function() {
			return this.filterByFn(function(item) {
				return !item.getRemoved();
			}, this);
		},

		// endregion

		// region Methods: Protected

		/**
		 * @inheritdoc BPMSoft.BaseSchemaManager#initialize
		 * @override
		 */
		initialize: function() {
			throw new BPMSoft.NotImplementedException({
				message: "initialize not implemented, use initializeRules instead."
			});
		},

		/**
		 * @inheritdoc BPMSoft.BaseSchemaManager#saveSchema
		 * @override
		 */
		saveSchema: BPMSoft.emptyFn,

		/**
		 * @inheritdoc BPMSoft.BaseManager#clear
		 * @override
		 */
		clear: function() {
			this.callParent(arguments);
			this.dataSourceCollection.clear();
			this.viewModelClassCollection.clear();
			this.initializedClientUnitSchemas = [];
		},

		// endregion

		// region Methods: Public

		/**
		 * @inheritdoc BPMSoft.manager.BaseSchemaManager#constructor
		 * @override
		 */
		constructor: function() {
			this.callParent(arguments);
			this.viewModelClassCollection = new BPMSoft.Collection();
			this.dataSourceCollection = new BPMSoft.Collection();
			BPMSoft.SysModuleEditManager.on("removeManagerItem", this.onRemoveSysModuleEditManagerItem, this);
		},

		/**
		 * Initialize business rules for client unit schemas.
		 * @param {Object} initConfig Configuration of initialize rules.
		 * @param {String?} initConfig.entitySchemaId Entity schema id.
		 * @param {String} initConfig.pageSchemaUId Page schema UId.
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Callback function context.
		 */
		initializeRules: function(initConfig, callback, scope) {
			const entitySchemaId = initConfig.entitySchemaId;
			const pageSchemaUId = initConfig.pageSchemaUId;
			BPMSoft.chain(
				function(next) {
					this._initManagers(next, this);
				},
				function(next) {
					this._initCurrentPackageUId(next, this);
				},
				function(next) {
					this._getEntitySchemaInstance(entitySchemaId, next);
				},
				function(next, entitySchema) {
					this.initBusinessRuleSchemaConverter({
						entitySchema: entitySchema
					});
					if (entitySchema) {
						this.entitySchemaName = entitySchema.name;
					}
					if (pageSchemaUId) {
						next([pageSchemaUId]);
					} else {
						this._getClientUnitSchemaUIds(entitySchemaId, next);
					}
				},
				function(next, clientUnitSchemaUIds) {
					this._initClientUnitSchemas(clientUnitSchemaUIds, next);
				},
				function() {
					this.isInitialized = true;
					Ext.callback(callback, scope);
				}, this
			);
		},

		/**
		 * Saves all changed items to Client unit schema manager.
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Callback function context.
		 */
		saveToClientUnitSchemaManager: function(callback, scope) {
			const response = {
				success: true
			};
			if (!this.isInitialized) {
				callback.call(scope, response);
				return;
			}
			const changedItemsCollection = this.getItems({
				useFilterFn: true
			});
			const rulesCollection = this.getClientUnitSchemasBusinessRulesCollection(changedItemsCollection);
			BPMSoft.eachAsync(
				Ext.Object.getKeys(rulesCollection),
				function(clientUnitSchemaUId, next) {
					this.saveClientUnitSchemaBusinessRule(clientUnitSchemaUId, rulesCollection, next, this);
				},
				function() {
					callback.call(scope, response);
				},
				this
			);
		},

		/**
		 * Saves all changed items.
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Callback function context.
		 */
		save: function(callback, scope) {
			this.saveToClientUnitSchemaManager(function() {
				BPMSoft.ClientUnitSchemaManager.save(function(response) {
					callback.call(scope, response);
				}, this);
			}, this);
		},

		/**
		 * Returns manager item by entity schema uId.
		 * @param {String} entitySchemaUId Entity schema uId.
		 * @param {Object} initConfig Initialization config.
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Callback function context.
		 */
		getItemsByEntitySchemaUId: function(entitySchemaUId, initConfig, callback, scope) {
			BPMSoft.chain(
				function(next) {
					this.initializeRules(initConfig, next, this);
				},
				function() {
					const filteredItems = this.items.filterByFn(function(item) {
						return item.getEntitySchemaUId() === entitySchemaUId;
					}, this);
					callback.call(scope, filteredItems);
				},
				this
			);
		},

		/**
		 * Creates new manager item.
		 */
		createNewManagerItem: function() {
			const id = BPMSoft.generateGUID();
			const pageSchemaUId = this.initializedClientUnitSchemas.length === 1
				? this.initializedClientUnitSchemas[0]
				: null;
			const schema = Ext.create("BPMSoft.BusinessRuleSchema", {
				uId: id,
				name: id,
				ruleSwitch: {
					type: "BusinessRuleSwitch",
					cases: []
				},
				entitySchema: this.entitySchema,
				pageSchemaUId: pageSchemaUId
			});
			const config = {
				id: id,
				uId: id,
				name: id,
				caption: "",
				instance: schema,
				clientUnitSchemaUId: pageSchemaUId,
				status: BPMSoft.ModificationStatus.NEW
			};
			return this.createManagerItem(config);
		},

		/**
		 * Returns business rules depends on column.
		 * @param {Object} config
		 * @param {String} config.columnName Column name.
		 * @param {String} config.pageSchemaUId Client unit schema UId.
		 * @param {Function} callback The callback function.
		 * @param {BPMSoft.BusinessRuleSchemaManagerItem[]} callback.dependsRules Array of rule depends on column.
		 * @param {Object} scope The scope of callback function.
		 */
		getRulesDependsOnColumn: function(config, callback, scope) {
			const columnName = config.columnName;
			const pageSchemaUId = config.pageSchemaUId;
			const initConfig = {pageSchemaUId: pageSchemaUId};
			this.initializeRules(initConfig, function() {
				const dependsRules = [];
				const actualItems = this._getActualItems();
				BPMSoft.eachAsync(actualItems.getItems(), function(item, next) {
					item.getInstance(function(instance) {
						if (instance.hasDependsOnColumn(columnName)) {
							dependsRules.push(item);
						}
						next();
					}, this);
				}, function() {
					callback.call(scope, dependsRules);
				}, this);
			}, this);
		},

		/**
		 * Returns business rules depends on column.
		 * @param {Object} config Parameters config.
		 * @param {String} config.dataModel Data model name.
		 * @param {String} config.pageSchemaUId Client unit schema UId.
		 * @param {Function} callback The callback function.
		 * @param {BPMSoft.BusinessRuleSchemaManagerItem[]} callback.dependsRules Array of rule depends on column.
		 * @param {Object} scope The scope of callback function.
		 */
		getRulesDependsOnDataModel: function(config, callback, scope) {
			const dataModel = config.dataModel;
			const entitySchema = dataModel.get("Schema");
			const pageSchemaUId = config.pageSchemaUId;
			const initConfig = {pageSchemaUId: pageSchemaUId};
			const dataModelName = dataModel.get("Name");
			this.initializeRules(initConfig, function() {
				const dependsRules = [];
				const actualItems = this._getActualItems();
				BPMSoft.eachAsync(actualItems.getItems(), function(item, next) {
					item.getInstance(function(instance) {
						BPMSoft.each(entitySchema.columns, function(column) {
							const columnPath = dataModel.getColumnPath(column.name);
							if (instance.hasDependsOnColumn(columnPath, dataModelName)) {
								dependsRules.push(item);
								return false;
							}
						}, this);
						next();
					}, this);
				}, function() {
					Ext.callback(callback, scope, [dependsRules]);
				}, this);
			}, this);
		},

		/**
		 * Removes business rules from client unit schema.
		 * @param {BPMSoft.core.collections.Collection} rules Rules for delete.
		 * @param {Function} callback The callback function.
		 * @param {Object} scope The scope of callback function.
		 */
		removeRules: function(rules, callback, scope) {
			this.checkIsInitialized();
			const rulesCollection = this.getClientUnitSchemasBusinessRulesCollection(rules);
			const clientUnitSchemaUIds = Ext.Object.getKeys(rulesCollection);
			BPMSoft.eachAsync(clientUnitSchemaUIds,
				function(schemaUId, next) {
					const schemaRules = rulesCollection[schemaUId];
					this.getClientUnitSchemaInstance(schemaUId, function(schema) {
						this._removeRulesFromClientUnitSchema(schemaRules, schema);
						schema.define(next, this);
					}, this);
				},
				function() {
					BPMSoft.each(rules, function(rule) {
						this.remove(rule.uId);
					}, this);
					callback.call(scope);
				}, this
			);
		},

		/**
		 * Finds entity schema by attribute.
		 * @param {String} attributeName Attribute name.
		 * @param {String} pageSchemaUId Page schema uId.
		 * @return {BPMSoft.data.models.BaseEntitySchema}
		 */
		findEntitySchemaByAttribute: function(attributeName, pageSchemaUId) {
			let entitySchema = null;
			const modelName = this.findDataModelNameByAttribute(attributeName, pageSchemaUId);
			if (modelName) {
				const viewModelClass = this._getViewModelClassByPageSchemaUId(pageSchemaUId);
				const dataModelCollection = viewModelClass.prototype.dataModelCollection;
				const dataModel = dataModelCollection.get(modelName);
				entitySchema = dataModel.schema;
			}
			return entitySchema;
		},

		/**
		 * Finds entity schema column by attribute.
		 * @param {String} attributeName Attribute name.
		 * @param {String} pageSchemaUId Page schema uId.
		 * @return {Object}
		 */
		findEntitySchemaColumnByAttribute: function(attributeName, pageSchemaUId) {
			const viewModelClass = this._getViewModelClassByPageSchemaUId(pageSchemaUId);
			const columns = viewModelClass.prototype.columns;
			const column = columns[attributeName];
			const entityColumnName = column && column.columnPath;
			const entitySchema = this.findEntitySchemaByAttribute(attributeName, pageSchemaUId);
			return entitySchema && entityColumnName && entitySchema.columns[entityColumnName];
		},

		/**
		 * Finds data model name by attribute.
		 * @param {String} attributeName Attribute name.
		 * @param {String} pageSchemaUId Page schema uId.
		 * @return {String}
		 */
		findDataModelNameByAttribute: function(attributeName, pageSchemaUId) {
			const viewModelClass = this._getViewModelClassByPageSchemaUId(pageSchemaUId);
			const columns = viewModelClass.prototype.columns;
			const column = columns[attributeName];
			return column && column.modelName;
		},

		/**
		 * Returns data sources config
		 * @param {String} pageSchemaUId Page schema uId.
		 * @return {Object}
		 */
		getDataSourcesConfig: function(pageSchemaUId) {
			return pageSchemaUId ? this.dataSourceCollection.get(pageSchemaUId) : this.dataSourceCollection.first();
		},

		/**
		 * Returns entity schema.
		 * @param {String} dataModelName Data model name.
		 * @param {String} pageSchemaUId Page schema uId.
		 * @return {BPMSoft.data.models.BaseEntitySchema}
		 */
		getEntitySchemaByDataModel: function(dataModelName, pageSchemaUId) {
			const viewModelClass = this._getViewModelClassByPageSchemaUId(pageSchemaUId);
			const dataModel = viewModelClass.prototype.dataModelCollection.get(dataModelName);
			return dataModel.schema;
		},

		/**
		 * Returns attribute name
		 * @param {String} columnName Column name.
		 * @param {String} dataModelName Name of the model in collection of models.
		 * @param {String} pageSchemaUId Unique identifier of the page.
		 * @return {string}
		 */
		getAttributeName: function(columnName, dataModelName, pageSchemaUId) {
			const viewModelClass = this._getViewModelClassByPageSchemaUId(pageSchemaUId);
			const dataModel = viewModelClass.prototype.dataModelCollection.get(dataModelName);
			return dataModel.getAttributeName(columnName);
		},

		/**
		 * @inheritdoc BPMSoft.core.BaseObject#onDestroy
		 * @override
		 */
		onDestroy: function() {
			this.callParent(arguments);
			BPMSoft.SysModuleEditManager.un("removeManagerItem", this.onRemoveSysModuleEditManagerItem, this);
		}

		// endregion

	});

	return BPMSoft.BusinessRuleSchemaManager;

});
