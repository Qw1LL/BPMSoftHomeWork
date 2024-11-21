define("BusinessRuleCaptionGenerator", ["BusinessRuleSchemaManager", "ExpressionEnums", "BusinessRuleSchemaManager"],
function() {
	Ext.define("BPMSoft.manager.BusinessRuleCaptionGenerator", {
		extend: "BPMSoft.BaseObject",
		alternateClassName: "BPMSoft.BusinessRuleCaptionGenerator",

		//region Method: Private

		/**
		 * Returns if expression is instance of class by type.
		 * @private
		 * @param {BPMSoft.ExpressionEdit} expression Expression.
		 * @param {String} type Expression type.
		 * @return {Boolean} Is instance of class by type.
		 */
		isInstanceOfClassByType: function(expression, type) {
			const className = BPMSoft.BusinessRuleElementHelper.getClassNameByType(type);
			return BPMSoft.isInstanceOfClass(expression, className);
		},

		_getItemCaptionFromCache: function(cacheKeyPrefix, schemaUId, itemName) {
			const item = BPMSoft.ClientPageSessionCache.getItem(cacheKeyPrefix + schemaUId)
				.find(function(item) {return item.name === itemName});
			return item && item.caption;
		},

		_getItemCaptionFromCacheBySourceType: function(schemaUId, itemName, sourceType) {
			switch (sourceType) {
				case BPMSoft.BusinessRuleActionSourceType.TAB_SOURCE:
					return this._getItemCaptionFromCache("tabs_", schemaUId, itemName);
				case BPMSoft.BusinessRuleActionSourceType.DETAIL_SOURCE:
					return this._getItemCaptionFromCache("details_", schemaUId, itemName);
				case BPMSoft.BusinessRuleActionSourceType.COUNTROL_GROUP_SOURCE:
					return this._getItemCaptionFromCache("groups_", schemaUId, itemName);
				case BPMSoft.BusinessRuleActionSourceType.ATTRIBUTE_SOURCE:
					return this._getItemCaptionFromCache("attributes_", schemaUId, itemName);
				case BPMSoft.BusinessRuleActionSourceType.MODULE_SOURCE:
					return this._getItemCaptionFromCache("modules_", schemaUId, itemName);
			}
			return undefined;
		},
		
		_generateUniquePopulateBusinessRuleCaption: function(config, callback, scope) {
			const element = config.element;
			const tpl = element.designConfig.captionTpl;
			const listCaption = element.designConfig.listCaption;
			const leftExpression = config.action.leftExpression;
			let caption;
			if (BPMSoft.isInstanceOfClass(leftExpression, "BPMSoft.manager.ColumnBusinessRuleExpression")) {
				const pageSchemaUId = config.schema.pageSchemaUId;
				const entitySchema = BPMSoft.BusinessRuleSchemaManager.getEntitySchemaByDataModel(leftExpression.dataModelName, pageSchemaUId);
				const columnUId = leftExpression.getExpressionValue();
				const column = Object.values(entitySchema.columns).find(function(x) {
					return x.uId === columnUId;
				});
				caption = column && column.caption;
			} else {
				caption = leftExpression.attributeName;
			}
			const formattedCaption = Ext.String.format(tpl, caption, listCaption);
			Ext.callback(callback, scope, [formattedCaption]);
		},
		
		//endregion

		//region Method: Protected

		/**
		 * Generates unique bind action caption.
		 * @protected
		 * @param {Object} config Configuration object.
		 * @param {BPMSoft.manager.BusinessRuleSchema} config.schema Business rule schema.
		 * @param {Object} config.element Action element.
		 * @param {BPMSoft.BaseBusinessRuleAction} config.action Action.
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Callback scope.
		 */
		generateUniqueBindActionCaption: function(config, callback, scope) {
			const element = config.element;
			const action = config.action;
			const tpl = element.designConfig.captionTpl;
			const listCaption = element.designConfig.listCaption;
			const attributeName = action.attributeName;
			const entitySchema = config.schema.entitySchema;
			const pageSchemaUId = config.schema.pageSchemaUId;
			let caption = this._getItemCaptionFromCacheBySourceType(pageSchemaUId, attributeName, action.sourceType);
			BPMSoft.chain(
				function(next) {
					if (!caption && entitySchema) {
						if (action.columnUId) {
							caption = entitySchema.getColumnByUId(action.columnUId).caption.getValue();
						} else {
							const column = entitySchema.columns.findByPath("name", attributeName);
							if (column) {
								caption = column.caption.getValue();
							}
						}
					}
					next(caption);
				},
				function(next, caption) {
					if (!caption && pageSchemaUId) {
						BPMSoft.ClientUnitSchemaManager.getInstanceByUId(pageSchemaUId, function(schema) {
							const parameter = schema.parameters.findByPath("name", attributeName);
							next(parameter && parameter.caption.getValue());
						}, this);
					} else {
						next(caption);
					}
				},
				function(next, caption) {
					const formattedCaption = Ext.String.format(tpl, caption || attributeName, listCaption);
					Ext.callback(callback, scope, [formattedCaption]);
				}, this
			);
		},

		/**
		 * Generates unique filtration action caption.
		 * @protected
		 * @param {Object} config Configuration object.
		 * @param {BPMSoft.BusinessRuleSchema} config.schema Business rule schema.
		 * @param {BPMSoft.BaseBusinessRuleAction} config.action Action.
		 * @param {Object} config.element Action element.
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Callback scope.
		 */
		generateUniqueFiltrationCaption: function(config, callback, scope) {
			let leftExpressionCaption;
			BPMSoft.chain(
				function(next) {
					const leftExpression = config.action.condition.leftExpression;
					if (leftExpression.dataModelName) {
						this.getColumnExpressionCaption(config.schema, leftExpression, next, this);
					} else {
						this.getParameterExpressionCaption(config.schema, leftExpression.columnMetaPath, next, this);
					}
				},
				function(next, captionPath) {
					leftExpressionCaption = captionPath.split(".")[0];
					this.getRightExpressionCaption(config.schema, config.action.condition, next, this);
				},
				function(next, captionPath) {
					const rightExpressionCaption = captionPath;
					const caption = Ext.String.format(config.element.designConfig.captionTpl,
						leftExpressionCaption, rightExpressionCaption);
					callback.call(scope, caption);
				},
				this
			);
		},

		/**
		 * Returns expression caption.
		 * @protected
		 * @param {BPMSoft.manager.BusinessRuleSchema} schema Business rule schema.
		 * @param {String} metaPath Column path.
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Callback scope.
		 */
		getParameterExpressionCaption: function(schema, metaPath, callback, scope) {
			var paths = metaPath.split(".");
			var parameterUId = paths[0];
			var columnMetaPath = paths.splice(1);
			var captionPath = "";
			BPMSoft.chain(
				function(next) {
					BPMSoft.ClientUnitSchemaManager.findParameterByUId({
						schemaUId: schema.pageSchemaUId,
						parameterUId: parameterUId
					}, next, this);
				},
				function(next, parameter) {
					if (!parameter) {
						Ext.callback(callback, scope, [""]);
						return;
					}
					captionPath = parameter.caption.toString();
					BPMSoft.EntitySchemaManager.getSchemaInstance(parameter.referenceSchemaUId, next, this);
				},
				function(next, entitySchema) {
					entitySchema.getColumnCaptionPathByMetaPath(columnMetaPath, next, this);
				},
				function(next, columnCaptionPath) {
					captionPath += "." + columnCaptionPath;
					Ext.callback(callback, scope, [captionPath]);
				}, this
			);
		},

		/**
		 * Returns expression caption.
		 * @protected
		 * @param {BPMSoft.manager.BusinessRuleSchema} schema Business rule schema.
		 * @param {BPMSoft.control.ExpressionEdit} expression Expression.
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Callback scope.
		 */
		getColumnExpressionCaption: function(schema, expression, callback, scope) {
			const entitySchema = BPMSoft.BusinessRuleSchemaManager
				.getEntitySchemaByDataModel(expression.dataModelName, this.pageSchemaUId);
			const metaPath = entitySchema.uId + "." + expression.columnMetaPath;
			BPMSoft.SchemaDesignerUtilities.getColumnCaptionPathByMetaPath(metaPath, callback, scope);
		},

		/**
		 * Returns right expression caption.
		 * @protected
		 * @param {BPMSoft.manager.BusinessRuleSchema} schema Business rule schema.
		 * @param {BPMSoft.manager.ComparisonBusinessRuleCondition} condition Condition.
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Callback scope.
		 */
		getRightExpressionCaption: function(schema, condition, callback, scope) {
			const expressionTypeEnum = BPMSoft.ExpressionEnums.ExpressionType;
			const rightExpression = condition.rightExpression;
			const leftExpression = condition.leftExpression;
			BPMSoft.chain(
				function(next) {
					if (this.isInstanceOfClassByType(rightExpression, expressionTypeEnum.COLUMN)) {
						this.getColumnExpressionCaption(schema, rightExpression, callback, scope);
					} else if (this.isInstanceOfClassByType(rightExpression, expressionTypeEnum.CONSTANT)) {
						if (leftExpression.dataModelName) {
							this.getRightExpressionConstantCaption(schema, condition, next, this);
						} else {
							this.getRightExpressionParameterConstantCaption(schema, condition, next, this);
						}
					} else {
						next();
					}
				},
				function(next, caption) {
					callback.call(scope, caption || rightExpression.getExpressionValue());
				}, this
			);
		},

		/**
		 * Returns right expression caption for constant.
		 * @protected
		 * @param {BPMSoft.manager.BusinessRuleSchema} schema Business rule schema.
		 * @param {BPMSoft.manager.ComparisonBusinessRuleCondition} condition Condition.
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Callback scope.
		 */
		getRightExpressionConstantCaption: function(schema, condition, callback, scope) {
			const leftExpression = condition.leftExpression;
			const entitySchema = BPMSoft.BusinessRuleSchemaManager
				.getEntitySchemaByDataModel(leftExpression.dataModelName, this.pageSchemaUId);
			const expressionValue = condition.rightExpression && condition.rightExpression.getExpressionValue();
			const config = {
				entitySchemaUId: entitySchema.extendParent ? entitySchema.parentUId : entitySchema.uId,
				metaPath: condition.leftExpression && condition.leftExpression.columnMetaPath,
				lookupId: expressionValue
			};
			this.getEntitySchemaLookupValue(config, function(lookupDisplayValue) {
				callback.call(scope, lookupDisplayValue || expressionValue);
			}, this);
		},

		/**
		 * Returns right expression parameter caption for constant.
		 * @protected
		 * @param {BPMSoft.manager.BusinessRuleSchema} schema Business rule schema.
		 * @param {BPMSoft.manager.ComparisonBusinessRuleCondition} condition Condition.
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Callback scope.
		 */
		getRightExpressionParameterConstantCaption: function(schema, condition, callback, scope) {
			var paths = condition.leftExpression.columnMetaPath.split(".");
			var parameterUId = paths[0];
			BPMSoft.chain(
				function(next) {
					BPMSoft.ClientUnitSchemaManager.findParameterByUId({
						schemaUId: schema.pageSchemaUId,
						parameterUId: parameterUId
					}, next, this);
				},
				function(next, parameter) {
					var schemaUId = parameter.referenceSchemaUId;
					if (!schemaUId) {
						callback.call(scope, null);
						return;
					}
					var config = {
						entitySchemaUId: schemaUId,
						metaPath: paths.slice(1).join("."),
						lookupId: condition.rightExpression.getExpressionValue()
					};
					this.getEntitySchemaLookupValue(config, callback, scope);
				}, this
			);
		},

		/**
		 * Returns lookup display value of entity schema by UId and path.
		 * @protected
		 * @param {Object} config Configuration object.
		 * @param {String} config.entitySchemaUId Entity schema UId.
		 * @param {String} config.metaPath Column meta path,
		 * @param {String} config.lookupId Lookup id.
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Callback scope.
		 */
		getEntitySchemaLookupValue: function(config, callback, scope) {
			BPMSoft.chain(
				function(next) {
					BPMSoft.SchemaDesignerUtilities.getEntitySchemaColumnPathByMetaPath({
						entitySchemaUId: config.entitySchemaUId,
						schemaColumnMetaPath: config.metaPath
					}, next, this);
				},
				function(next, response) {
					const schemaUId = response.referenceSchemaUId;
					if (!schemaUId) {
						callback.call(scope, null);
						return;
					}
					BPMSoft.EntitySchemaManager.getCurrentPackageSchemaByUId(schemaUId, next, this);
				},
				function(next, instance) {
					if (!instance) {
						callback.call(scope, null);
						return;
					}
					const lookupConfig = {
						schemaName: instance.getName(),
						entitySchema: instance,
						lookupId: config.lookupId
					};
					this.getLookupDisplayValue(lookupConfig, callback, scope);
				}, this
			);
		},

		/**
		 * Returns lookup display value.
		 * @protected
		 * @param {Object} config Configuration object.
		 * @param {String} config.schemaName Root schema name.
		 * @param {BPMSoft.EntitySchema} config.entitySchema Lookup entity schema.
		 * @param {String} config.lookupId Lookup id.
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Callback scope.
		 */
		getLookupDisplayValue: function(config, callback, scope) {
			var displayColumnName = config.entitySchema.primaryDisplayColumn.name;
			var esq = Ext.create("BPMSoft.EntitySchemaQuery", {
				"rootSchemaName": config.schemaName
			});
			esq.addColumn(displayColumnName);
			esq.getEntity(config.lookupId, function(response) {
				if (response.success && response.entity) {
					var caption = response.entity.get(displayColumnName);
					callback.call(scope, caption);
				} else {
					callback.call(scope, config.lookupId);
				}
			});
		},

		//endregion

		//region Method: Public

		/**
		 * Generate unique caption.
		 * @param {BPMSoft.BusinessRuleSchema} schema Business rule schema.
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Callback scope.
		 */
		generateUniqueCaption: function(schema, callback, scope) {
			var ruleSwitch = schema.ruleSwitch;
			var cases = ruleSwitch && ruleSwitch.cases;
			var actions = cases && cases[0] && cases[0].action;
			var action = actions && actions.items[0];
			if (action) {
				var typeInfo = action.getTypeInfo();
				var element = BPMSoft.BusinessRuleElementHelper.getElementByClassName(typeInfo.fullTypeName);
				var config = {
					schema: schema,
					action: action,
					element: element
				};
				switch (element.type) {
					case "FiltrationBusinessRuleAction":
						this.generateUniqueFiltrationCaption(config, callback, scope);
						break;
					case "PopulateBusinessRuleAction":
						this._generateUniquePopulateBusinessRuleCaption(config, callback, scope);
						break;
					default:
						this.generateUniqueBindActionCaption(config, callback, scope);
						break;
				}
			} else {
				callback.call(scope);
			}
		},

		/**
		 * Updates schema caption.
		 * @param {BPMSoft.BusinessRuleSchema} schema Business rule schema.
		 * @param {String} generatedCaption Generated caption.
		 * @param {Boolean} isNew Is new schema.
		 */
		updateSchemaCaption: function(schema, generatedCaption, isNew) {
			var captionNumbers = [];
			var schemaCaption = schema.getCaption();
			var needChangeCaption = isNew || !(schemaCaption && schemaCaption.indexOf(generatedCaption) === 0);
			if (needChangeCaption) {
				var items = BPMSoft.BusinessRuleSchemaManager.getItems();
				var collection = items.filter(function(item) {
					return !item.getRemoved() && !item.getInvalid();
				});
				collection.each(function(item) {
					var localCaption = item.getCaption();
					var caption = localCaption.getValue();
					if (caption.indexOf(generatedCaption) === 0) {
						var endOfCaption = caption.substring(generatedCaption.length);
						var captionNumber = endOfCaption.length > 0
							? parseInt(endOfCaption.substring(1), 10)
							: 0;
						if (captionNumber === 0) {
							item.instance.initLocalizableStringValue("caption", caption + "_1");
						}
						captionNumbers.push(captionNumber);
					}
				}, this);
				if (captionNumbers.length > 0) {
					var max = Ext.Array.max(captionNumbers);
					generatedCaption += "_" + (max + 1);
				}
				schema.initLocalizableStringValue("caption", generatedCaption);
			}
		},

		/**
		 * Updates duplicate item captions.
		 * @param {BPMSoft.Collection} collection Business rule item collection.
		 * @private
		 */
		updateDuplicateCaptions: function(collection) {
			var groups = {};
			collection.each(function(item) {
				if (!item.getRemoved() && !item.getInvalid()) {
					var caption = item.caption.getValue();
					if (!Ext.isDefined(groups[caption])) {
						groups[caption] = [];
					}
					groups[caption].push(item);
				}
			}, this);
			BPMSoft.each(groups, function(group, caption) {
				if (group.length > 1) {
					BPMSoft.each(group, function(item, index) {
						if (index !== 0) {
							item.instance.initLocalizableStringValue("caption", caption + "_" + (index));
						}
					}, this);
				}
			}, this);
		}

		//endregion

	});
});
