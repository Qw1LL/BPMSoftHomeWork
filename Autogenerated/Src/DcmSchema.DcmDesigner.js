define("DcmSchema", ["ext-base", "BPMSoft", "DcmSchemaResources", "DcmSchemaStage", "DcmSchemaElement",
		"DcmSchemaStageTarget", "DcmSchemaStageConnections", "DcmSchemaElementTransitionFactory"],
	function(Ext, BPMSoft, resources) {
		/**
		 * @class BPMSoft.Designers.DcmSchema
		 * Dcm schema class.
		 */
		Ext.define("BPMSoft.Designers.DcmSchema", {
			extend: "BPMSoft.manager.BaseProcessSchema",
			alternateClassName: "BPMSoft.DcmSchema",

			//region Properties: Public

			/**
			 * @inheritdoc BPMSoft.manager.BaseProcessSchema#contractName
			 * @overridden
			 */
			contractName: "ContractDcmSchema",

			/**
			 * @inheritdoc BPMSoft.manager.BaseProcessSchema#managerName
			 * @overridden
			 */
			managerName: "DcmSchemaManager",

			/**
			 * @inheritdoc BPMSoft.manager.BaseProcessSchema#typeName
			 * @overridden
			 */
			typeName: "BPMSoft.Core.DcmProcess.DcmSchema",

			/**
			 * @inheritdoc BPMSoft.manager.BaseProcessSchema#typeCaption
			 * @overridden
			 */
			typeCaption: resources.localizableStrings.TypeCaption,

			/**
			 * @inheritdoc BPMSoft.manager.BaseProcessSchema#color
			 * @overridden
			 */
			color: "#F9763D",

			/**
			 * Stages.
			 * @type {BPMSoft.Collection}
			 */
			stages: null,

			/**
			 * Stage targets.
			 * @type {BPMSoft.DcmSchemaStageConnections}
			 */
			stageConnections: null,

			/**
			 * DcmSchema elements transitions
			 * @type {BPMSoft.Collection}
			 */
			transitions: null,

			/**
			 * Stage entity schema unique identifier.
			 * @type {String}
			 */
			entitySchemaUId: null,

			/**
			 * Entity schema stage column identifier.
			 * @type {String}
			 */
			stageColumnUId: null,

			/**
			 * Schema methods.
			 * @type {BPMSoft.Collection}
			 */
			methods: null,

			/**
			 * Collection of usings.
			 * @type {BPMSoft.Collection}
			 */
			usings: null,

			/**
			 * Localizable strings.
			 * @type {BPMSoft.Collection}
			 */
			localizableStrings: null,

			/**
			 * Entity schema.
			 * @type {BPMSoft.EntitySchema}
			 */
			entitySchema: null,

			/**
			 * Filters.
			 * @type {String}
			 */
			filters: "",

			/**
			 * System elements.
			 * @type {BPMSoft.Collection}
			 */
			systemElements: null,

			//endregion

			//region Constructors: Public

			/**
			 * @inheritdoc BPMSoft.manager.BaseProcessSchema#constructor
			 * @overridden
			 */
			constructor: function() {
				this.callParent(arguments);
				this.initCollection("stages", "BPMSoft.DcmSchemaStage", this);
				this.initStageConnections();
				this.initFlowElements();
				this.iniTransitions();
				// Refactoring: DcmSchema. Remove from the use of the method synchronizeParameters BaseProcessSchema.Mappings
				this.initMappings();
				this.synchronizeDynamicParameters();
			},

			//endregion

			//region Methods: Private

			/**
			 * Initialize dcmSchema elements transitions collection.
			 * @private
			 */
			iniTransitions: function() {
				var metaData = this.transitions || [];
				var transitions = this.transitions = Ext.create("BPMSoft.Collection");
				metaData.forEach(function(transitionMetaData) {
					var transition = BPMSoft.DcmSchemaElementTransitionFactory.createTransitionByTypeName(
						transitionMetaData.typeName,
						transitionMetaData
					);
					this.addTransition(transition);
				}, this);
				transitions.on("add", this.onTransitionAdd, this);
			},

			/**
			 * DcmSchemaElement transition add event handler. Fires changed event for DcmSchema.
			 * @private
			 * @param {BPMSoft.DefaultDcmSchemaElementTransition} transition DcmSchemaElement transition.
			 */
			onTransitionAdd: function(transition) {
				this.fireEvent("changed", {
					eventName: "transitionChanged",
					operation: "add",
					elementUId: transition.elementUId
				});
			},

			/**
			 * Initializes stage connections.
			 * @private
			 */
			initStageConnections: function() {
				var metaData = this.stageConnections;
				var result = Ext.create("BPMSoft.DcmSchemaStageConnections");
				result.on("changed", this.onConnectionsChange, this);
				if (metaData && metaData.connections) {
					var connectionsArray = metaData.connections;
					connectionsArray.forEach(function(item) {
						result.addConnection(item.source, item.target);
					}, this);
				}
				this.stageConnections = result;
			},

			/**
			 * On connections change handler.
			 * @private
			 */
			onConnectionsChange: function() {
				this.fireEvent("changed", {
					item: this.stageConnections
				});
			},

			/**
			 * Initializes process elements.
			 * @private
			 */
			initFlowElements: function() {
				var flowElements = this.flowElements = Ext.create("BPMSoft.Collection");
				this.stages.each(function(stage) {
					stage.elements.each(function(item) {
						flowElements.add(item.uId, item);
					});
				});
			},

			/**
			 * Removes dcm element from parent stage and from flowElements.
			 * @private
			 * @param {String} itemKey Element identifier.
			 */
			removeElement: function(itemKey) {
				var flowElements = this.flowElements;
				var schema = this;
				this.stages.each(function(stage) {
					var elements = stage.elements;
					var element = elements.find(itemKey);
					if (element) {
						elements.removeByKey(itemKey);
						flowElements.removeByKey(itemKey);
						schema.removeMapping(element);
						this.removeTransitionByElementUId(itemKey);
						return false;
					}
				}, this);
			},

			/**
			 * Initializes "ShowExecutionPage" process element parameter with default value.
			 * @private
			 * @param {BPMSoft.manager.BaseProcessSchemaElement} processElement Process element.
			 */
			initProcessElementShowExecutionPageParameter: function(processElement) {
				var parameter = processElement.findParameterByName("ShowExecutionPage");
				if (parameter) {
					parameter.setValue({
						source: BPMSoft.ProcessSchemaParameterValueSource.ConstValue,
						value: "false"
					});
				}
			},

			/**
			 * Adds default stage connections, from all to all stages.
			 * @private
			 * @param {String} stageUId Stage identifier.
			 */
			addStageDefaultConnections: function(stageUId) {
				var stages = this.stages;
				var connections = this.stageConnections;
				stages.each(function(item) {
					if (item.uId !== stageUId) {
						connections.addConnection(stageUId, item.uId);
						connections.addConnection(item.uId, stageUId);
					}
				}, this);
			},

			/**
			 * Returns DcmSchema transitions for serialization. Returns all transitions except default transitions.
			 * @private
			 * @return {BPMSoft.DefaultDcmSchemaElementTransition[]}
			 */
			getSerializableTransitions: function() {
				var transitionsCollection = this.transitions.filterByFn(function(transition) {
					return transition.getTransitionTypeUId() !==
						BPMSoft.DcmSchemaElementTransitionFactory.defaultTransitionTypeUId;
				}, this);
				return transitionsCollection.getItems();
			},

			/**
			 * Finds entity connection parameter.
			 * @private
			 * @param {BPMSoft.ProcessSchemaElement} element Process element.
			 */
			_findEntityConnectionParameter: function(element) {
				var entitySchema = this.entitySchema;
				if (!element.parameters || !entitySchema) {
					return null;
				}
				var parameter = element.findParameterByName(entitySchema.name);
				if (parameter && (parameter.dataValueType === BPMSoft.DataValueType.GUID ||
					parameter.referenceSchemaUId === entitySchema.uId)) {
					return parameter;
				}
				parameter = element.findParameterByReferenceSchemaUId(entitySchema.uId);
				return parameter;
			},

			//endregion

			//region Methods: Protected

			/**
			 * @inheritdoc BPMSoft.core.BaseObject#onDestroy
			 * @overridden
			 * @protected
			 */
			onDestroy: function() {
				this.transitions.un("add", this.onTransitionAdd, this);
				this.callParent(arguments);
			},

			/**
			 * @inheritdoc BPMSoft.manager.BaseProcessSchema#getEditPageSchemaName
			 * @overridden
			 */
			getEditPageSchemaName: function(callback, scope) {
				callback.call(scope, "DcmSchemaPropertiesPage");
			},

			/**
			 * @inheritdoc BPMSoft.manager.BaseSchema#getSerializableProperties
			 * @overridden
			 */
			getSerializableProperties: function() {
				var properties = this.callParent(arguments);
				return Ext.Array.push(properties, ["entitySchemaUId", "stageColumnUId", "filters", "systemElements"]);
			},

			/**
			 * @inheritdoc BPMSoft.manager.BaseProcessSchema#getTitleImage
			 * @overridden
			 */
			getTitleImage: function() {
				return resources.localizableImages.TitleImage;
			},

			/**
			 * @inheritdoc BPMSoft.manager.BaseProcessSchema#collectItemsValidationResults
			 * @overridden
			 */
			collectItemsValidationResults: function(validationInfo) {
				this.collectValidationResults(this.stages, validationInfo);
				this.collectValidationResults(this.flowElements, validationInfo);
			},

			/**
			 * @inheritdoc BPMSoft.manager.BaseSchema#getSerializableProperties
			 * @overridden
			 */
			getSerializableObject: function(serializableObject) {
				this.callParent(arguments);
				this.setSerializableCollectionProperty(serializableObject, "stages");
				this.setSerializableCollectionProperty(serializableObject, "mappings");
				var transitions = this.getSerializableTransitions();
				serializableObject.transitions = this.getSerializableProperty(transitions);
				this.mixins.parametrizedProcessSchemaElement.getSerializableObject.apply(this, arguments);
				this.setSerializableProperty(serializableObject, "stageConnections");
			},

			/**
			 * @inheritdoc BPMSoft.manager.BaseProcessSchema#loadLocalizableValues
			 * @overridden
			 */
			loadLocalizableValues: function(localizableValues) {
				this.callParent(arguments);
				if (!localizableValues) {
					return;
				}
				var stagesLocalizableValues = localizableValues.Stages || {};
				this.stages.each(function(stage) {
					var stageLocalizableValue = stagesLocalizableValues[stage.name];
					stage.loadLocalizableValues(stageLocalizableValue || {});
				}, this);
			},

			/**
			 * @inheritdoc BPMSoft.manager.BaseProcessSchema#loadLocalizableValuesByUIds
			 * @overridden
			 */
			loadLocalizableValuesByUIds: function(localizableValues) {
				this.callParent(arguments);
				if (!localizableValues) {
					return;
				}
				this.stages.each(function(stage) {
					stage.loadLocalizableValuesByUIds(localizableValues);
					stage.elements.each(function(element) {
						element.loadLocalizableValuesByUIds(localizableValues);
					});
				}, this);
			},

			/**
			 * @inheritdoc BPMSoft.manager.BaseProcessSchema#getLocalizableValues
			 * @overridden
			 */
			getLocalizableValues: function(localizableValues) {
				this.callParent(arguments);
				this.stages.each(function(stage) {
					stage.getLocalizableValues(localizableValues);
				}, this);
			},

			/**
			 * Adds dcm element to stage.
			 * @param {BPMSoft.configuration.DcmSchemaElement} item Dcm schema item.
			 */
			addElement: function(item) {
				var itemKey = item.uId;
				var stage = this.stages.get(item.containerUId);
				item.parentSchema = this;
				stage.elements.add(itemKey, item);
				var flowElement = item.processFlowElement;
				if (flowElement) {
					flowElement.parentSchema = this;
					this.synchronizeParameters(flowElement);
					item.applyParametersDefValues();
					this.initProcessElementShowExecutionPageParameter(flowElement);
					this.setEntityConnectionParameterDefaultValue(flowElement);
					item.parameters = flowElement.parameters;
					this.flowElements.add(item.uId, item);
				}
				var createdInSchemaUId = this.uId;
				item.createdInSchemaUId = createdInSchemaUId;
				item.modifiedInSchemaUId = createdInSchemaUId;
				item.createdInPackageId = this.packageUId;
				item.parentSchema = this;
				this.fireEvent("changed", {
					item: item
				});
			},

			/**
			 * Sets default entity connection parameter value.
			 * @private
			 * @param {BPMSoft.manager.BaseProcessSchemaElement} element Flow element.
			 */
			setEntityConnectionParameterDefaultValue: function(element) {
				var parameter = this._findEntityConnectionParameter(element);
				if (!parameter) {
					return;
				}
				this.setParameterDefaultValue(parameter);
			},

			/**
			 * Sets default parameter value.
			 * @protected
			 * @param {BPMSoft.manager.ProcessSchemaParameter} parameter Parameter.
			 */
			setParameterDefaultValue: function(parameter) {
				var entitySchema = this.entitySchema;
				var macrosCaption = resources.localizableStrings.DefaultParameterMacrosCaption;
				var value = this.formatMacrosString([entitySchema.uId, entitySchema.primaryColumn.uId]);
				var displayValue = Ext.String.format("{0}{1}{2}{3}", BPMSoft.process.constants.LEFT_MACROS_BRACKET,
					macrosCaption, ".Id", BPMSoft.process.constants.RIGHT_MACROS_BRACKET);
				parameter.setMappingValue({
					value: value,
					displayValue: displayValue,
					dataValueType: parameter.dataValueType,
					referenceSchemaUId: parameter.referenceSchemaUId,
					source: BPMSoft.ProcessSchemaParameterValueSource.Script
				});
			},

			/**
			 * Returns entity connection parameter default value.
			 * @param {Array} values MacrosValues.
			 * @return {String} Macros value.
			 */
			formatMacrosString: function(values) {
				var macrosString = "ColumnValue";
				values.map(function(item) {
					macrosString = macrosString + ".{" + item + "}";
					return item;
				});
				return Ext.String.format("{0}{1}{2}",
					BPMSoft.process.constants.LEFT_MACROS_BRACKET,
					macrosString,
					BPMSoft.process.constants.RIGHT_MACROS_BRACKET);
			},

			/**
			 * Adds stage to the schema by specified position.
			 * @param {BPMSoft.Designers.DcmSchemaStage} stage Stage element.
			 * @param {Number} [index] Stage position index.
			 */
			addStage: function(stage, index) {
				var stageUId = stage.uId;
				stage.parentSchema = this;
				stage.createdInSchemaUId = this.uId;
				stage.modifiedInSchemaUId = this.uId;
				stage.createdInPackageId = this.packageUId;
				this.stages.add(stageUId, stage, index);
				this.addStageDefaultConnections(stageUId);
				this.fireEvent("changed", {
					item: stage
				});
			},

			/**
			 * @inheritdoc BPMSoft.manager.BaseProcessSchema#remove
			 * @overridden
			 */
			remove: function(itemKey) {
				this.clearAlternativeStages(itemKey);
				this.removeElement(itemKey);
				this.stageConnections.removeStage(itemKey);
				this.stages.removeByKey(itemKey);
				this.fireEvent("changed", {
					itemName: itemKey
				});
			},

			/**
			 * Clears alternative stages' parentStageUId on stage removal.
			 * @private
			 * @param {String} itemKey Stage identifier.
			 */
			clearAlternativeStages: function(itemKey) {
				var stage = this.stages.find(itemKey);
				if (stage) {
					var childStages = stage.getChildren();
					childStages.each(function(childrenStage) {
						childrenStage.setPropertyValue("parentStageUId", null, {silent: true});
					});
				}
			},

			/**
			 * @inheritdoc BPMSoft.manager.BaseProcessSchema#contains
			 * @overridden
			 */
			contains: function(itemKey) {
				var result = false;
				result = result || this.stages.contains(itemKey);
				this.stages.each(function(stage) {
					result = result || stage.elements.contains(itemKey);
				});
				result = result || this.flowElements.contains(itemKey);
				return result;
			},

			//endregion

			//region Methods: Public

			/**
			 * Search DcmSchemaElement transition by element uId.
			 * @param {String} uId Element uId
			 * @return {BPMSoft.DefaultDcmSchemaElementTransition|null}
			 */
			findTransitionByElementUId: function(uId) {
				return this.transitions.find(uId);
			},

			/**
			 * Returns transitions where passed element is source element.
			 * @param {String} uId Element identifier.
			 * @return {BPMSoft.DefaultDcmSchemaElementTransition[]}
			 */
			findTransitionsBySourceElementUId: function(uId) {
				var transitions = [];
				this.transitions.each(function(transition) {
					var sourceElement = transition.findSourceElement();
					if (sourceElement && sourceElement.uId === uId) {
						transitions.push(transition);
					}
				}, this);
				return transitions;
			},

			/**
			 * Returns dependent elements for element with passed identifier.
			 * @param {String} elementUId Element identifier.
			 * @return {BPMSoft.DcmSchemaElement[]}
			 */
			findDependentElements: function(elementUId) {
				var dependentTransitions = this.findTransitionsBySourceElementUId(elementUId);
				return dependentTransitions.map(function(transition) {
					return transition.findElement();
				}, this);
			},

			/**
			 * Removes DcmSchemaElement transition by element uId.
			 * @param {string} uId Element uId.
			 */
			removeTransitionByElementUId: function(uId) {
				this.transitions.removeByKey(uId);
			},

			/**
			 * Adds DcmSchemaElement transition.
			 * @param {BPMSoft.DefaultDcmSchemaElementTransition} transition DcmSchemaElement transition.
			 */
			addTransition: function(transition) {
				transition.parentSchema = this;
				this.transitions.add(transition.elementUId, transition);
			},

			/**
			 * Moves stage.
			 * @param {String} itemKey Item id.
			 * @param {Number} toIndex Item position.
			 */
			moveStage: function(itemKey, toIndex) {
				var stages = this.stages;
				var stage = stages.get(itemKey);
				var fromIndex = stages.indexOf(stage);
				stages.move(fromIndex, toIndex);
				this.fireEvent("changed", {
					eventName: "moveStage",
					itemKey: itemKey,
					fromIndex: fromIndex,
					toIndex: toIndex
				});
			},

			/**
			 * Moves group of alternative stages. First move parent stage, then moves each alternative stage.
			 * @throws BPMSoft.InvalidOperationException if stageUId is not uId for parent stage of group.
			 * @param {String} stageUId Unique identifier of parent stage of group.
			 * @param {Number} index New index
			 */
			moveStageGroup: function(stageUId, index) {
				var stages = this.stages;
				var stage = stages.get(stageUId);
				if (stage.getIsParent() !== true) {
					throw new BPMSoft.InvalidOperationException();
				}
				var fromIndex = stages.indexOf(stage);
				var alternativeStages = stage.getChildren();
				this.moveStage(stageUId, index);
				var alternativeStageIndex = index;
				var alternativeStageIndexIncrement = (fromIndex < index) ? 0 : 1;
				alternativeStages.each(function(alternativeStage) {
					alternativeStageIndex += alternativeStageIndexIncrement;
					this.moveStage(alternativeStage.uId, alternativeStageIndex);
				}, this);
			},

			/**
			 * Moves element.
			 * @param {String} itemKey Item id.
			 * @param {String} targetStageKey Target stage id.
			 * @param {Number} toIndex Item position.
			 */
			moveElement: function(itemKey, targetStageKey, toIndex) {
				var stages = this.stages;
				var targetStage = stages.get(targetStageKey);
				var element = this.findItemByUId(itemKey);
				var sourceStage = stages.get(element.containerUId);
				var sourceElements = sourceStage.getItems();
				var targetElements = targetStage.getItems();
				sourceElements.remove(element);
				element.containerUId = targetStageKey;
				targetElements.insert(toIndex, element.uId, element);
				this.fireEvent("changed", {
					eventName: "moveElement",
					itemKey: itemKey
				});
			},

			/**
			 * Finds element by key.
			 * @param {String} itemKey Item key.
			 * @return {BPMSoft.DcmSchemaElement|null}
			 */
			findItemByUId: function(itemKey) {
				var stages = this.stages;
				var item = stages.find(itemKey);
				if (item) {
					return item;
				}
				stages.each(function(stage) {
					var elements = stage.getItems();
					elements.each(function(element) {
						if (element.uId === itemKey) {
							item = element;
							return false;
						}
					}, this);
				}, this);
				return item || null;
			},

			/**
			 * Finds stage or element by name.
			 * @param {String} name Item name.
			 * @return {BPMSoft.manager.BaseProcessSchemaElement|BPMSoft.manager.DcmSchemaStage}
			 */
			findItemByName: function(name) {
				var elements = this.flowElements.filter(function(element) {
					return element.name === name;
				});
				var item = elements.first();
				if (item) {
					return item;
				}
				this.stages.each(function(stage) {
					if (stage.name === name) {
						item = stage;
					} else {
						var dcmElements = stage.elements.filter(function(element) {
							return element.name === name;
						});
						item = dcmElements.first();
					}
					return !item;
				}, this);
				return item || null;
			},

			/**
			 * Finds element by caption.
			 * @param {String} caption Item caption.
			 * @return {BPMSoft.DcmSchemaElement|null}
			 */
			findItemByCaption: function(caption) {
				var designerUtilities = BPMSoft.ProcessSchemaDesignerUtilities;
				var result = this.flowElements.filterByFn(function(item) {
					var itemCaption = designerUtilities.getElementCaption(item);
					return itemCaption === caption;
				});
				return result.first();
			},

			/**
			 * Returns flag that indicates final stage or not.
			 * @param {BPMSoft.Designers.DcmSchemaStage} stage Stage.
			 * @return {Boolean}
			 */
			getIsFinalStage: function(stage) {
				var final = this.stages.last();
				var stageUId = stage.uId;
				var finalParentUId = final.parentStageUId;
				var result = (final.uId === stageUId) ||
					(finalParentUId === stageUId) ||
					(stage.parentStageUId && (finalParentUId === stage.parentStageUId));
				return result;
			},

			/**
			 * Changes stage parentStageUId property and changes stage position.
			 * @protected
			 * @param {String} stageUId Stage identifier.
			 * @param {String} oldParentStageUId Old parent stage identifier.
			 * @param {String} newParentStageUId New parent stage identifier.
			 */
			changeParentStage: function(stageUId, oldParentStageUId, newParentStageUId) {
				var stage = this.stages.get(stageUId);
				var stageIndex = this.stages.indexOf(stage);
				stage.setPropertyValue("parentStageUId", newParentStageUId);
				var moveToIndex;
				if (newParentStageUId) {
					moveToIndex = this.getAddToGroupIndex(newParentStageUId);
					if (stageIndex < moveToIndex) {
						moveToIndex--;
					}
				} else {
					moveToIndex = this.getRemoveFromGroupIndex(stageUId, oldParentStageUId);
				}
				this.moveStage(stageUId, moveToIndex);
			},

			/**
			 * Returns index to move stage out of group.
			 * @private
			 * @param {String} stageUId Stage identifier.
			 * @param {String} fromParentStageUId Group parent identifier.
			 * @return {Number} New stage index.
			 */
			getRemoveFromGroupIndex: function(stageUId, fromParentStageUId) {
				var stage = this.stages.get(stageUId);
				var currentIndex = this.stages.indexOf(stage);
				var isLastStage = stage.getIsLastStage();
				var fromParentStage = this.stages.get(fromParentStageUId);
				var children = fromParentStage.getChildren();
				if (isLastStage || children.isEmpty()) {
					return currentIndex;
				} else {
					var lastChild = children.last();
					var lastChildIndex = this.stages.indexOf(lastChild);
					return Math.max(currentIndex, lastChildIndex);
				}
			},

			/**
			 * Returns index to move stage in group.
			 * @private
			 * @param {String} newParentStageUId New parents stage identifier.
			 * @return {Number} New stage index.
			 */
			getAddToGroupIndex: function(newParentStageUId) {
				var parentStage = this.stages.get(newParentStageUId);
				var parentStageIndex = this.stages.indexOf(parentStage);
				var children = parentStage.getChildren();
				var childrenCount = children.getCount();
				return parentStageIndex + childrenCount;
			},

			/**
			 * Initializes entity schema.
			 * @param {Function} callback The callback function.
			 * @param {Object} [scope] The context of callback function.
			 */
			initEntitySchema: function(callback, scope) {
				var config = {
					schemaUId: this.entitySchemaUId,
					packageUId: this.packageUId
				};
				BPMSoft.EntitySchemaManager.findBundleSchemaInstance(config, function(entitySchema) {
					this.entitySchema = entitySchema;
					Ext.callback(callback, scope);
				}, this);
			},

			/**
			 * @inheritdoc BPMSoft.manager.BaseProcessSchema#getValidateFormulaServerMethodName
			 * @overridden
			 */
			getValidateFormulaServerMethodName: function() {
				return "ValidateDcmFormula";
			}

			//endregion

		});

		return BPMSoft.Designers.DcmSchema;
	}
);
