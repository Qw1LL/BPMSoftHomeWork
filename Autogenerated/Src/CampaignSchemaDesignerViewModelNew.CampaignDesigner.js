define("CampaignSchemaDesignerViewModelNew", ["CampaignSchemaDesignerViewModelNewResources",
		"CampaignConnectorManager", "CampaignFlowSchemaValidator", "ModalBox", "LookupUtilities",
		"CampaignDiagramSvgRenderer", "CampaignEnums", "StorageUtilities", "CampaignSchemaManager",
		"CampaignDiagramElementManager", "CampaignSchemaDesignerViewModelMixin", "CampaignTemplateGalleryModule",
		"CampaignTemplateGalleryPage"],
	function(resources, campaignConnectorManager, campaignFlowSchemaValidator, ModalBox, LookupUtilities,
			svgRenderer, CampaignEnums, StorageUtilities) {
		Ext.define("BPMSoft.Designers.CampaignSchemaDesignerViewModelNew", {
			extend: "BPMSoft.Designers.ProcessSchemaDesignerViewModelNew",
			alternateClassName: "BPMSoft.CampaignSchemaDesignerViewModelNew",

			mixins: {
				campaignElementMixin: "BPMSoft.CampaignElementMixin",
				schemaDesignerMixin: "BPMSoft.CampaignSchemaDesignerViewModelMixin"
			},
			messages: {

				/**
				 * @message TemplateSaved
				 * Indicates user choice to save the template.
				 */
				"TemplateSaved": {
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE,
					mode: BPMSoft.MessageMode.PTP
				},

				/**
				 * @message SaveTemplateCancel
				 * Indicates user choice to cancel template saving process.
				 */
				"SaveTemplateCancel": {
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE,
					mode: BPMSoft.MessageMode.PTP
				},

				/**
				 * @message CampaignTemplateSelected
				 * Emit campaign template selected action.
				 */
				"CampaignTemplateSelected": {
					"mode": this.BPMSoft.MessageMode.PTP,
					"direction": this.BPMSoft.MessageDirectionType.SUBSCRIBE
				},

				/**
				 * @message CampaignTemplateGalleryCanceled
				 * Emit campaign template gallery canceled action.
				 */
				"CampaignTemplateGalleryCanceled": {
					"mode": this.BPMSoft.MessageMode.PTP,
					"direction": this.BPMSoft.MessageDirectionType.SUBSCRIBE
				},

				/**
				 * @message LookupInfo
				 */
				"LookupInfo": {
					"mode": BPMSoft.MessageMode.PTP,
					"direction": BPMSoft.MessageDirectionType.SUBSCRIBE
				},

				/**
				 * @message ResultSelectedRows
				 */
				"ResultSelectedRows": {
					"mode": BPMSoft.MessageMode.PTP,
					"direction": BPMSoft.MessageDirectionType.SUBSCRIBE
				},

				/**
				 * @message IsDesignerReadOnlyMode
				 */
				"IsDesignerReadOnlyMode": {
					"mode": BPMSoft.MessageMode.PTP,
					"direction": BPMSoft.MessageDirectionType.SUBSCRIBE
				}
			},

			/**
			 * @inheritdoc BPMSoft.Designers.BaseProcessSchemaDesignerViewModel#schemaManager
			 * @override
			 */
			schemaManager: BPMSoft.CampaignSchemaManager,

			/**
			 * @inheritdoc BPMSoft.Designers.BaseProcessSchemaDesignerViewModel#contextHelpCode
			 * @override
			 */
			contextHelpCode: "CampaignDesigner",

			/**
			 * @inheritdoc BPMSoft.Designers.ProcessSchemaDesignerViewModel#elementSchemaManager
			 * @override
			 */
			elementSchemaManager: BPMSoft.CampaignElementSchemaManager,

			/**
			 * Instance of campaign diagram element manager.
			 * @type {BPMSoft.CampaignDiagramElementManager}
			 */
			diagramElementManager: BPMSoft.CampaignDiagramElementManager,

			/**
			 * Instance of CampaignConnectorManager
			 * @type {BPMSoft.CampaignConnectorManager}
			 */
			connectorManager: campaignConnectorManager,

			/**
			 * Instance of CampaignFlowSchemaValidator
			 * @type {BPMSoft.CampaignFlowSchemaValidator}
			 */
			flowSchemaValidator: campaignFlowSchemaValidator,

			/**
			 * Defines if campaign version have to be updated.
			 * @type {Boolean}
			 */
			needUpdateVersionPreview: false,

			/**
			 * @inheritdoc BPMSoft.model.BaseViewModel#constructor
			 * @override
			 */
			constructor: function() {
				this.callParent(arguments);
				this.addEvents(
					/**
					 * @event highlightConnection
					 * Triggers when highlight connection on diagram.
					 */
					"highlightConnection",
					/**
					 * @event elementDescriptionChange
					 * Triggers when need to update element description on diagram.
					 */
					"elementDescriptionChange",
					/**
					 * @event reloadBadges
					 * Triggers to update all diagram data.
					 */
					"reloadDiagram"
				);
			},

			/**
			 * @private
			 */
			_getPaletteElementConfig: function(element) {
				return {
					type: element.type,
					title: element.caption,
					imageUrl: element.paletteImage,
					shapeFormType: element.shapeFormType
				};
			},

			/**
			 * @private
			 */
			_getDiagramElementConfig: function(element) {
				return {
					caption: element.caption,
					height: element.size.height,
					width: element.size.width,
					largeImage: element.titleImage,
					smallImage: element.paletteImage,
					type: element.type,
					shapeFormType: element.shapeFormType,
					diagramNodeType: element.diagramNodeType
				};
			},

			/**
			 * @private
			 */
			_getDiagramElements: function() {
				var runtimeElements = {};
				var diagramElementsCollection = this.diagramElementManager.getDiagramElements();
				BPMSoft.each(diagramElementsCollection, function(element) {
					runtimeElements[element.type] = this._getDiagramElementConfig(element);
				}, this);
				return runtimeElements;
			},

			/**
			 * @private
			 */
			_getPaletteElements: function() {
				var paletteElements = {};
				var diagramElementsCollection = this.diagramElementManager.getDiagramElements();
				if (!BPMSoft.Features.getIsEnabled("EnableOldCampaignEventElement")) {
					diagramElementsCollection
						.removeByKey("BPMSoft.Configuration.CampaignEventElement, BPMSoft.Configuration");
				}
				if (!BPMSoft.Features.getIsEnabled("CampaignStartEventElement")) {
					diagramElementsCollection
						.removeByKey("BPMSoft.Configuration.CampaignStartEventElement, BPMSoft.Configuration");
				}
				if (!BPMSoft.Features.getIsEnabled("CampaignAddToEventElement")) {
					diagramElementsCollection
						.removeByKey("BPMSoft.Configuration.CampaignAddToEventElement, BPMSoft.Configuration");
				}
				if (!BPMSoft.Features.getIsEnabled("EnableOldCampaignLandingElement")) {
					diagramElementsCollection
						.removeByKey("BPMSoft.Configuration.CampaignLandingElement, BPMSoft.Configuration");
				}
				if (!BPMSoft.Features.getIsEnabled("CampaignStartLandingElement")) {
					diagramElementsCollection
						.removeByKey("BPMSoft.Configuration.CampaignStartLandingElement, BPMSoft.Configuration");
				}
				if (!BPMSoft.Features.getIsEnabled("CampaignSplitGatewayElement")) {
					diagramElementsCollection
						.removeByKey("BPMSoft.Configuration.CampaignSplitGatewayElement, BPMSoft.Configuration");
				}
				if (!BPMSoft.Features.getIsEnabled("CampaignDeduplicatorElement")) {
					diagramElementsCollection
						.removeByKey("BPMSoft.Configuration.CampaignDeduplicatorElement, BPMSoft.Configuration");
				}
				if (!BPMSoft.Features.getIsEnabled("CampaignRandomSplitElement")) {
					diagramElementsCollection
						.removeByKey("BPMSoft.Configuration.RandomSplitElement, BPMSoft.Configuration")
				}
				BPMSoft.each(diagramElementsCollection, function(element) {
					paletteElements[element.type] = this._getPaletteElementConfig(element);
				}, this);
				return paletteElements;
			},

			/**
			 * @private
			 */
			_findDiagramElementByType: function(type) {
				return this.diagramElementManager.getItems().findByFn(function(el) {
					return el.type === type;
				});
			},

			/**
			 * @private
			 */
			_getItemByUId: function(itemUId) {
				return this.$Items.findByFn(function(item) {
					return item.uId === itemUId;
				});
			},

			/**
			 * @private
			 */
			_parseConfig: function(config) {
				var result = {};
				var obj = JSON.parse(config);
				for (var key in obj) {
					if (!key.match(/[A-Z]\d+/g)) {
						var newKey = key.charAt(0).toLowerCase() + key.slice(1);
						result[newKey] = obj[key];
					}
					if (key === "A2") {
						result.name = obj[key];
					}
				}
				result.flowElements = obj.FlowElements.map(this._parseFlowElement);
				return result;
			},

			/**
			 * @private
			 */
			_parseFlowElement: function(flowElement) {
				var result = {};
				for (var key in flowElement) {
					if (!key.match(/[A-Z]\d+/g)) {
						var newKey = key.charAt(0).toLowerCase() + key.slice(1);
						result[newKey] = flowElement[key];
					}
					switch (key) {
						case 'A2':
							result.name = flowElement[key];
						  break;
						case 'A3':
							result.createdInSchemaUId = flowElement[key];
						break;
						case 'A4':
							result.modifiedInSchemaUId = flowElement[key];
							break;
						case 'A5':
							result.createdInPackageId = flowElement[key];
						break;
						case 'BL1':
							result.typeName = flowElement[key];
						  break;
						default:
							break;
					}
				}
				result.caption = "";
				if (result.hasOwnProperty("filterId") && BPMSoft.isEmptyGUID(result.filterId)) {
					result.filterId = null;
				}
				if (!flowElement.VisualType) {
					delete result.priority;
					return result;
				}
				delete result.isExpanded;
				delete result.size;
				delete result.stepCompletedCondition;
				var newPolylinePointPositions = {};
				for (var key in flowElement.PolylinePointPositions) {
					var newKey = key.charAt(0).toLowerCase() + key.slice(1);
					newPolylinePointPositions[newKey] = flowElement.PolylinePointPositions[key];
				}
				result.polylinePointPositions = newPolylinePointPositions;
				return result;
			},

			/**
			 * @private
			 */
			_parseResources: function(resourcesConfig) {
				var result = {
					"Description": {
						"en-US": ""
					}
				};
				var config = JSON.parse(resourcesConfig);
				config.forEach(function(item) {
					if (!result.hasOwnProperty(item.Key)) {
						result[item.Key] = {};
					}
					if (item.SysCultureId === "a5420246-0a8e-e111-84a3-00155d054c03") {
						result[item.Key]["en-US"] = item.Value;
					}
				});
				return result;
			},

			/**
			 * @private
			 */
			_getTemplateInsert: function(name, templateData, imageId) {
				var insertQuery = Ext.create("BPMSoft.InsertQuery", {
					rootSchemaName: "CampaignTemplate"
				});
				var config = JSON.stringify(templateData);
				insertQuery.setParameterValue("Caption", name, BPMSoft.DataValueType.TEXT);
				insertQuery.setParameterValue("TemplateConfig", config, BPMSoft.DataValueType.TEXT);
				insertQuery.setParameterValue("PreviewImage", imageId, BPMSoft.DataValueType.GUID);
				return insertQuery;
			},

			/**
			 * @private
			 */
			_getElementType: function(className) {
				var types = this.diagramElementManager.getDiagramElements();
				var type = types.findByFn(function(type) {
					return type.className === className;
				});
				return type && type.type;
			},

			/**
			 * @private
			 */
			_getTemplateElements: function(schema) {
				var elements = [];
				BPMSoft.each(schema.flowElements, function(flowElement) {
					if (flowElement.isContainer === true) {
						return;
					}
					if (flowElement.nodeType !== BPMSoft.diagram.UserHandlesConstraint.Connector) {
						var element = {
							caption: flowElement.caption.getCultureValue(),
							name: flowElement.name,
							type: this._getElementType(flowElement.typeName),
							position: flowElement.position,
							id: flowElement.uId
						};
						Object.assign(element, flowElement.getElementSpecificProperties());
						elements.push(element);
					}
				}, this);
				return elements;
			},

			/**
			 * @private
			 */
			_getTemplateConnections: function(schema) {
				var connections = [];
				var sequenceFlows = schema.flowElements.filter(function(flowElement) {
					return flowElement.nodeType === BPMSoft.diagram.UserHandlesConstraint.Connector;
				});
				BPMSoft.each(sequenceFlows, function(sequenceFlow) {
					if (sequenceFlow.sourceRefUId && sequenceFlow.targetRefUId) {
						var connection = {
							caption: sequenceFlow.caption.getCultureValue(),
							name: sequenceFlow.name,
							type: sequenceFlow.type || "connection",
							source: sequenceFlow.sourceRefUId,
							target: sequenceFlow.targetRefUId,
							polylinePointPositions: sequenceFlow.polylinePointPositions,
							portPositions: {
								source: {
									position: sequenceFlow.startPoint
								},
								target: {
									position: sequenceFlow.endPoint
								}
							},
							sourceRefUId: sequenceFlow.sourceRefUId,
							targetRefUId: sequenceFlow.targetRefUId,
							id: sequenceFlow.uId
						};
						Object.assign(connection, sequenceFlow.getElementSpecificProperties());
						connections.push(connection);
					}
				}, this);
				return connections;
			},

			/**
			 * @private
			 */
			_replaceTemplateElementId: function(connections, id, newId) {
				BPMSoft.each(connections, function(flow) {
					if (flow.source === id) {
						flow.source = newId;
						flow.sourceRefUId = newId;
					}
					if (flow.target === id) {
						flow.target = newId;
						flow.targetRefUId = newId;
					}
				}, this);
			},

			/**
			 * @private
			 */
			_clearFlowElements: function() {
				var schema = this.$Schema;
				var lane = schema.lanes.getByIndex(0);
				var laneSet = schema.laneSets.getByIndex(0);
				laneSet.lanes.clear();
				schema.lanes.clear();
				schema.labels.clear();
				schema.flowElements.clear();
				this.clearSchemaItems();
				this.$Items.add(lane.name, lane);
			},

			/**
			 * @private
			 */
			_getTemplateData: function(schema) {
				return {
					elements: this._getTemplateElements(schema),
					connections: this._getTemplateConnections(schema)
				};
			},

			/**
			 * @private
			 */
			_getTemplateGalleryModuleId: function() {
				return this.sandbox.id + "_CampaignTemplateGalleryModule";;
			},

			/**
			 * @private
			 */
			_getGalleryPopupConfig: function() {
				return {
					widthPixels: 870,
					heightPixels: 580,
					innerBoxStyles: {
						"height": "100%",
						"width": "100%"
					}
				};
			},

			/**
			 * @private
			 */
			_openCampaignTemplateGallery: function() {
				var config = this._getGalleryPopupConfig();
				var moduleId = this._getTemplateGalleryModuleId();
				var renderTo = this._showModalBox(moduleId, config);
				var loadModuleConfig = {
					renderTo: renderTo,
					id: moduleId
				};
				this.sandbox.loadModule("CampaignTemplateGalleryModule", loadModuleConfig);
			},

			/**
			 * @private
			 */
			_openCampaignTemplateGalleryPage: function() {
				var config = this._getGalleryPopupConfig();
				var moduleId = this._getTemplateGalleryModuleId();
				var renderTo = this._showModalBox(moduleId, config);
				var loadModuleConfig = {
					renderTo: renderTo,
					id: moduleId,
					keepAlive: false,
					instanceConfig: {
						useHistoryState: false,
						schemaName: "CampaignTemplateGalleryPage",
						isSchemaConfigInitialized: true
					}
				};
				this.sandbox.loadModule("BaseSchemaModuleV2", loadModuleConfig);
			},

			/**
			 * Shows modal box for module.
			 * @private
			 */
			_showModalBox: function(moduleId, modalBoxConfig) {
				var renderTo = ModalBox.show(modalBoxConfig, function() {
					this.sandbox.unloadModule(moduleId, renderTo);
				}, this);
				return renderTo.id;
			},

			/**
			 * @private
			 */
			_isSchemaEmpty: function() {
				return this.$Items && this.$Items.filterByFn(function(item) {
					return item.alternateClassName !== "BPMSoft.ProcessLaneSchema";
				}).isEmpty();
			},

			/**
			 * @private
			 */
			_getCampaignVersionLookupFilters: function() {
				var filters = BPMSoft.createFilterGroup();
				filters.logicalOperation = BPMSoft.LogicalOperatorType.AND;
				var campaignFilter = BPMSoft.createColumnFilterWithParameter(
					BPMSoft.ComparisonType.EQUAL, "Campaign", this.$Schema.entityId);
				filters.addItem(campaignFilter);
				var formatFilter = BPMSoft.createColumnFilterWithParameter(
					BPMSoft.ComparisonType.GREATER, "DataFormat", 0);
				filters.addItem(formatFilter);
				return filters;
			},

			/**
			 * @private
			 */
			_getCampaignVersionUpdate: function(campaignVersionId, imageId) {
				var update = Ext.create("BPMSoft.UpdateQuery", {
					rootSchemaName: "CampaignVersion"
				});
				update.filters.addItem(BPMSoft.createColumnFilterWithParameter(
					BPMSoft.ComparisonType.EQUAL, "Id", campaignVersionId));
				update.setParameterValue("PreviewImage", imageId, BPMSoft.DataValueType.GUID);
				return update;
			},

			/**
			 * @private
			 */
			_updateCampaignVersionPreviewImage: function(campaignVersionId) {
				var svgSelector = "ts-campaign-diagram svg[data-element-id='root1']";
				var targetWidth = 600;
				var targetHeight = 400;
				var scope = this;
				var virtualCanvas = null;
				BPMSoft.chain(
					function(next) {
						svgRenderer.svgToCanvas(svgSelector, targetWidth, targetHeight, next);
					},
					function(next, canvas) {
						virtualCanvas = canvas;
						var image = canvas.toDataURL();
						if (!image) {
							return;
						}
						BPMSoft.ImageApi.uploadUsingDataUrl({
							fileName: "CampaignVersion" + campaignVersionId + ".png",
							dataUrl: image,
							onComplete: next,
							scope: scope
						});
					},
					function(next, imageId) {
						var update = scope._getCampaignVersionUpdate(campaignVersionId, imageId);
						update.execute(next, scope);
					},
					function() {
						virtualCanvas.remove();
					}
				);
			},

			/**
			 * Returns style for Save button depends on whether has schema changes or not.
			 * @return {BPMSoft.controls.ButtonEnums.style}
			 */
			getSaveButtonStyle: function() {
				return BPMSoft.isDebug && !this.get("IsSchemaChanged")
					? BPMSoft.controls.ButtonEnums.style.ORANGE
					: BPMSoft.controls.ButtonEnums.style.ORANGE;
			},

			/**
			 * @inheritdoc BPMSoft.ProcessSchemaDesignerViewModelNew#onItemUpdatingType
			 * @override
			 */
			onItemUpdatingType: BPMSoft.emptyFn,

			/**
			 * @inheritdoc BPMSoft.ProcessSchemaDesignerViewModelNew#setPortPosition
			 * @override
			 */
			setPortPosition: function(connector, sequenceFlow) {
				sequenceFlow.endPoint = connector.portPositions.target.position;
				sequenceFlow.startPoint = connector.portPositions.source.position;
			},

			/**
			 * @inheritdoc BPMSoft.ProcessSchemaDesignerViewModelNew#getDiagramConfig
			 * @override
			 */
			getDiagramConfig: function() {
				return {
					customElementToolsConfig: { addItems: [], tools: {
						connect: {
							imageUrl: BPMSoft.ImageUrlBuilder.getUrl(resources.localizableImages.ArrowToolImage),
							title: BPMSoft.Resources.ProcessSchemaDesigner.ElementTools.ConnectHint
						},
						delete: {
							imageUrl: BPMSoft.ImageUrlBuilder.getUrl(resources.localizableImages.DeleteToolImage),
							title: BPMSoft.Resources.ProcessSchemaDesigner.ElementTools.RemoveHint
						}
					} },
					customElementMarkers: {
						ExitFolder: {
							smallImage: BPMSoft.ImageUrlBuilder.getUrl(resources.localizableImages.ExitFolderMarker),
							type: "folder",
							x: 35,
							y: 30,
							size: 12
						},
						AddFolder: {
							smallImage: BPMSoft.ImageUrlBuilder.getUrl(resources.localizableImages.AddFolderMarker),
							type: "folder",
							x: 35,
							y: 30,
							size: 12
						},
						ExitFilter: {
							smallImage: BPMSoft.ImageUrlBuilder.getUrl(resources.localizableImages.ExitFilterMarker),
							type: "filter",
							x: 35,
							y: 30,
							size: 12
						},
						AddFilter: {
							smallImage: BPMSoft.ImageUrlBuilder.getUrl(resources.localizableImages.AddFilterMarker),
							type: "filter",
							x: 35,
							y: 30,
							size: 12
						},
						Goal: {
							smallImage: BPMSoft.ImageUrlBuilder.getUrl(resources.localizableImages.GoalMarker),
							type: "goal",
							x: 34,
							y: 11,
							size: 12
						},
						Recurring: {
							smallImage: BPMSoft.ImageUrlBuilder.getUrl(resources.localizableImages.RecurringMarker),
							type: "recurring",
							x: 35,
							y: 11,
							size: 12
						}
					},
					customDiagramElements: this._getDiagramElements(),
					customPaletteElements: this._getPaletteElements(),
					customLocalizableStrings: this.getCustomLocalizableStrings()
				};
			},

			/**
			 * @inheritdoc
			 * BPMSoft.ProcessSchemaDesignerViewModelNew#getFlowElementSchemaManagerItemByTypeName
			 * @override
			 */
			getFlowElementSchemaManagerItemByTypeName: function(type) {
				var diagramItem = this._findDiagramElementByType(type);
				if (!diagramItem) {
					return null;
				}
				return this.elementSchemaManager.getItems().findByFn(function(item) {
					return item.instance.instanceId === diagramItem.schemaInstanceId;
				}, this);
			},

			/**
			 * @inheritdoc BPMSoft.ProcessSchemaDesignerViewModelNew#getClassName
			 * @override
			 */
			getClassName: function(element) {
				if (element.type === "connection") {
					var source = this._getItemByUId(element.source);
					return this.connectorManager.getConnectorType(source.getTypeInfo().typeName);
				}
				var managerItem = this.getFlowElementSchemaManagerItemByTypeName(element.type);
				return managerItem.instance.getTypeInfo().fullTypeName;
			},

			/**
			 * @inheritdoc BPMSoft.ProcessSchemaDesignerViewModelNew#onItemCreate
			 * @override
			 */
			onItemCreate: function(element) {
				if (!element || !this.getFlowElementSchemaManagerItemByTypeName(element.type)) {
					return;
				}
				this.callParent(arguments);
			},

			/**
			 * @inheritdoc BPMSoft.ProcessSchemaDesignerViewModelNew#createFlow
			 * @override
			 */
			createFlow: function(connection) {
				var flow = this.callParent(arguments);
				flow.isValid = true;
				flow.caption = new BPMSoft.LocalizableString(connection.caption);
				return flow;
			},

			/**
			 * @inheritdoc BPMSoft.ProcessSchemaDesignerViewModelNew#onConnectorCreate
			 * @override
			 */
			onConnectorCreate: function(connector) {
				this.callParent(arguments);
				var source = this.$Items.findByFn(function(el) {
					return el.uId === connector.source;
				}, this);
				if (source && source instanceof BPMSoft.CampaignSplitGatewaySchema) {
					source.onFlowAdded();
				}
			},

			/**
			 * @inheritdoc BPMSoft.BaseProcessSchemaDesignerViewModel#getSchemaInstance
			 * @override
			 */
			getSchemaInstance: function(schemaUId, callback, scope) {
				var callbackFn = this.getSchemaInstanceCallbackFn(callback, scope);
				var parentMethod = this.getParentMethod();
				this.initToggleState(function(res) {
					if (res && res.hasOwnProperty("showDescriptions")) {
						this.$ShowDescriptions = res.showDescriptions
					}
					parentMethod.call(this, schemaUId, callbackFn, scope);
				}, this);
			},

			/**
			 * @inheritdoc BPMSoft.Designers.BaseProcessSchemaDesignerViewModel#onSchemaLoaded
			 * @override
			 */
			onSchemaLoaded: function(schema) {
				this.mixins.schemaDesignerMixin.onSchemaLoaded.call(this, schema);
			},

			/**
			 * Reloads diagram data.
			 * @protected
			 */
			onReloadDiagramClick: function() {
				this.fireEvent("reloadDiagram", this);
			},

			/**
			 * @inheritdoc BPMSoft.BaseProcessSchemaDesignerViewModel#onAfterSchemaSaved
			 * @override
			 */
			onAfterSchemaSaved: function() {
				this.callParent(arguments);
				this.mixins.schemaDesignerMixin.onAfterSchemaSaved.call(this);
			},

			/**
			 * @inheritdoc BPMSoft.BaseProcessSchemaDesignerViewModel#onItemChanged
			 * @override
			 */
			onItemChanged: function(changes, item) {
				this.callParent(arguments);
				if (changes.hasOwnProperty("highlight")) {
					this.fireEvent("highlightConnection", changes.highlight);
				}
				if (changes.hasOwnProperty("description") && this.$ShowDescriptions) {
					this.fireEvent("elementDescriptionChange", changes.description);
				}
			},

			/**
			 * @inheritdoc BPMSoft.BaseViewModel#validate
			 * @override
			 */
			validate: function() {
				var baseResult = this.callParent(arguments);
				return this.mixins.schemaDesignerMixin.validate.call(this, baseResult);
			},

			/**
			 * @inheritdoc BPMSoft.Designers.BaseProcessSchemaDesignerViewModel#validateViewModel
			 * @override
			 */
			validateViewModel: function(callback, scope) {
				this.mixins.schemaDesignerMixin.validateViewModel.call(this, callback, scope);
				this.needUpdateVersionPreview = true;
			},

			/**
			 * @inheritdoc BPMSoft.Designers.BaseProcessSchemaDesignerViewModel#loadPropertiesPage
			 * @override
			 */
			loadPropertiesPage: function(key) {
				var element = this.findItemByKey(key);
				if (element instanceof BPMSoft.ProcessLabelSchema) {
					var parent = this.findItemByUId(element.parentUId);
					if (!parent) {
						return;
					}
					key = parent.name;
				}
				this.callParent([key]);
			},

			/**
			 * Returns diagram readonly mode state.
			 * @returns {Boolean}
			 */
			isDesignerReadOnly: function() {
				return Boolean(this.get("IsReadOnly"));
			},

			/**
			 * @inheritdoc BPMSoft.BaseSchemaDesigner#onSandboxInitialized
			 * @override
			 */
			onSandboxInitialized: function() {
				this.callParent(arguments);
				this.registerSandboxMessages(this.sandbox);
				this.sandbox.registerMessages(this.messages);
				var templateEditPageModuleId = this.sandbox.id + "_CampaignTemplateEditPage";
				var galleryModuleId = this._getTemplateGalleryModuleId();
				this.sandbox.subscribe("TemplateSaved", this.onTemplateSaved, this, [templateEditPageModuleId]);
				this.sandbox.subscribe("SaveTemplateCancel", this.onSaveTemplateCancel, this, [templateEditPageModuleId]);
				this.sandbox.subscribe("CampaignTemplateSelected", this.onTemplateSelected, this, [galleryModuleId]);
				this.sandbox.subscribe("CampaignTemplateGalleryCanceled", this.onTemplateViewCanceled, this, [galleryModuleId]);
				this.sandbox.subscribe("IsDesignerReadOnlyMode", this.isDesignerReadOnly, this);
				BPMSoft.ServerChannel.on(BPMSoft.EventName.ON_MESSAGE, this.onChannelMessage, this);
			},

			/**
			 * @inheritdoc BPMSoft.BaseSchemaViewModel#destroy
			 * @override
			 */
			destroy: function() {
				this.callParent(arguments);
				BPMSoft.ServerChannel.un(BPMSoft.EventName.ON_MESSAGE, this.onChannelMessage, this);
			},

			/**
			 * Handles the message from server communications channel.
			 * @protected
			 * @param {BPMSoft.ServerChannel} channel BPMCRM server communication channel.
			 * @param {Object} message Message object.
			 */
			onChannelMessage: function(channel, message) {
				if (!this.needUpdateVersionPreview || !Ext.isObject(message)) {
					return;
				}
				if (message.Header.Sender !== "Campaign") {
					return;
				}
				var messageObject = BPMSoft.decode(message.Body || "{}");
				if (messageObject.campaignId !== this.$Schema.entityId
					|| !messageObject.versionId) {
					return;
				}
				if (messageObject.operation === CampaignEnums.CampaignPageOperations.UPDATE_VERSION) {
					var campaignVersionId = messageObject.versionId;
					this._updateCampaignVersionPreviewImage(campaignVersionId);
				}
				this.needUpdateVersionPreview = false;
			},

			/**
			 * @inheritdoc BPMSoft.ProcessSchemaDesignerViewModelNew#createItemCopy
			 * @override
			 */
			createItemCopy: function(sourceItem, element) {
				var instance = this.callParent(arguments);
				instance = instance.prepareCopy();
				instance.caption = new BPMSoft.LocalizableString(element.caption);
				return instance;
			},

			/**
			 * @inheritdoc BPMSoft.BaseProcessSchemaDesignerViewModel#handleCtrlAltKeyDown
			 * @override
			 */
			handleCtrlAltKeyDown: function(event) {
				return false;
			},

			/**
			 * @inheritdoc BPMSoft.BaseProcessSchemaDesignerViewModel#getSaveButtonMenuItems
			 * @override
			 */
			getSaveButtonMenuItems: function() {
				return [];
			},

			/**
			 * @protected
			 */
			getImportFromTemplateCaption: function() {
				return resources.localizableStrings.CampaignTemplateImportButtonCaption;
			},

			/**
			 * @protected
			 */
			getSaveAsTemplateCaption: function() {
				return resources.localizableStrings.CampaignTemplateSaveButtonCaption;
			},

			/**
			 * @protected
			 */
			getManageCampaignVersionCaption: function() {
				return resources.localizableStrings.ManageCampaignVersionCaption;
			},

			/**
			 * Loads template from CampaignTemplate.
			 * @protected
			 */
			importTemplate: function(templateConfig) {
				this.unloadCurrentPropertyPage();
				var template = JSON.parse(templateConfig);
				var schema = this.$Schema;
				this._clearFlowElements();
				BPMSoft.each(template.elements, function(elConfig) {
					var newId = BPMSoft.generateGUID();
					this._replaceTemplateElementId(template.connections, elConfig.id, newId);
					elConfig.id = newId;
					var item = this._createElement(elConfig);
					item.setElementSpecificProperties(elConfig);
					item.parentSchema = schema;
					this.$Items.add(item.name, item);
				}, this);
				BPMSoft.each(template.connections, function(flowConfig) {
					flowConfig.id = BPMSoft.generateGUID();
					var item = this.createFlow(flowConfig);
					item.setElementSpecificProperties(flowConfig);
					item.parentSchema = schema;
					this.$Items.add(item.name, item);
				}, this);
				this.onSchemaLoaded(schema);
				this.hideBodyMask();
			},

			/**
			 * Loads template config by template unique identifier.
			 * @protected
			 */
			loadTemplateConfigById: function(templateId) {
				var esq = Ext.create("BPMSoft.EntitySchemaQuery", {
					rootSchemaName: "CampaignTemplate"
				});
				esq.addColumn("TemplateConfig");
				esq.getEntity(templateId, function(response) {
					if (response) {
						var templateConfig = response.entity.$TemplateConfig;
						this.importTemplate(templateConfig);
					}
				}, this);
			},

			/**
			 * Loads template from CampaignTemplate.
			 * @protected
			 */
			onImportTemplateClick: function() {
				if (BPMSoft.Features.getIsEnabled("CampaignGalleryComponent")) {
					this._openCampaignTemplateGallery();
					return;
				}
				this._openCampaignTemplateGalleryPage();
			},

			/**
			 * Returns lookup config to view actual schema versions of current campaign.
			 * @protected
			 * @returns Lookup config.
			 */
			getCampaignVersionLookupConfig: function() {
				return {
					entitySchemaName: "CampaignVersion",
					multiSelect: false,
					hideActions: true,
					settingsButtonVisible: false,
					filters: this._getCampaignVersionLookupFilters()
				};
			},

			/**
			 * Handler on manage campaign version action button click event.
			 * @protected
			 */
			onManageCampaignVersion: function() {
				var config = this.getCampaignVersionLookupConfig();
				LookupUtilities.Open(this.sandbox, config, this.onRestoreCampaignVersion, this, null, false, false);
			},

			/**
			 * @protected
			 * @param {String} versionId Unique identifier of campaign version.
			 */
			 restoreVersion: function(versionId) {
				var esq = Ext.create("BPMSoft.EntitySchemaQuery", {
					rootSchemaName: "CampaignVersion"
				});
				esq.addColumn("Data");
				esq.addColumn("LocalizableData");
				esq.getEntity(versionId, function(response) {
					if (response) {
						var templateConfig = response.entity.$Data;
						var resourcesConfig = response.entity.$LocalizableData;
						var metaData = {
							metaData: {
								schema: this._parseConfig(templateConfig)
							}
						};
						var config = {
							metaData: BPMSoft.encode(metaData),
							resources: this._parseResources(resourcesConfig)
						 };
						var response = Ext.create("BPMSoft.CampaignSchemaResponse");
						var schema = response.createSchemaInstance(config);
						schema.parentSchemaUId = this.get("Schema").parentSchemaUId;
						var managerItem = this.get("SchemaManagerItem");
						managerItem.clearInstance();
						this.clearSchemaItems();
						managerItem.setInstance(schema);
						managerItem.setStatus(BPMSoft.ModificationStatus.UPDATED);
						this.set("IsSchemaChanged", true);
						this.initSchema(schema, function() {
							this.onAfterGetSchemaInstance(schema, function() {
								this.loadItems(schema);
								var lastSelectedItemName = this.localStore.getItem(this.storageLoadedPropertiesItemName);
								var element = this.findItemByKey(lastSelectedItemName);
								if (element) {
									this.set("LastSelectedItemUId", null);
									this.selectItem(lastSelectedItemName);
									this.loadPropertiesPage(lastSelectedItemName);
								} else {
									this.clearSelection();
									this.loadSchemaPropertiesPage();
								}
							}, this);
						}, this);
					}
				}, this);
			},

			/**
			 * Handler on select campaign version to restore event.
			 * @protected
			 * @param {Object} result Lookup select result.
			 */
			onRestoreCampaignVersion: function(result) {
				var selectedRows = result.selectedRows;
				if (selectedRows.getCount() <= 0) {
					return;
				}
				var version = selectedRows.first();
				if (version) {
					this.restoreVersion(version.Id);
				}
			},

			/**
			 * Handler on campaign template selected for import.
			 * @protected
			 * @param {Guid} templateId Campaign template id.
			 */
			onTemplateSelected: function(templateId) {
				this.showBodyMask({
					opacity: 0.5,
					showHidden: true,
					clearMasks: true
				});
				ModalBox.close();
				this.loadTemplateConfigById(templateId);
			},

			/**
			 * Handler on campaign template gallery view cancelation event.
			 * @protected
			 */
			onTemplateViewCanceled: function() {
				ModalBox.close();
			},

			/**
			 * Saves campaign schema as template.
			 */
			saveAsTemplate: function() {
				this.saveElementProperties();
				var isCampaignSchemaEmpty = this._isSchemaEmpty();
				if (isCampaignSchemaEmpty) {
					var caption = resources.localizableStrings.EmptySchemaMessageBoxCaption;
					var message = resources.localizableStrings.EmptySchemaMessageBoxMessage;
					this._showMessageBox(caption, message, [BPMSoft.MessageBoxButtons.OK], BPMSoft.emptyFn, this);
					return;
				}
				var moduleName = "CampaignTemplateEditModule";
				var moduleId = this.sandbox.id + "_CampaignTemplateEditPage";
				var modalBoxConfig = {
					heightPixels: 600,
					widthPixels: 640
				};
				var windowRenderTo = this._showModalBox(moduleId, modalBoxConfig);
				this.sandbox.loadModule(moduleName, {
					renderTo: windowRenderTo,
					id: moduleId,
					parameters: {
						viewModelConfig: {
							CampaignId: this.$Schema.entityId
						}
					}
				});
			},

			/**
			 * Handler on campaign template saved event.
			 * @protected
			 */
			onTemplateSaved: function(args) {
				var schema = this.get("Schema");
				var templateData = this._getTemplateData(schema);
				BPMSoft.ImageApi.uploadUsingDataUrl({
					fileName: "CampaignTemplate" + args.templateName + ".png",
					dataUrl: args.previewImage,
					onComplete: function(imageId) {
						var insert = this._getTemplateInsert(args.templateName, templateData, imageId);
						insert.execute(function(result) {
							if (!result.success) {
								//TODO: show error message
							}
						}, this);
					},
					scope: this
				});
				ModalBox.close();
			},

			/**
			 * Handler on save campaign template cancelation event.
			 * @protected
			 */
			onSaveTemplateCancel: function() {
				ModalBox.close();
			},

			/**
			 * Handler on show description toggle state change event.
			 * @protected
			 */
			onToggleDescriptions: function() {
				this.$ShowDescriptions = !this.$ShowDescriptions;
				this.saveToggleState();
			},

			/**
			 * Returns unique profile key for description toggle.
			 * @returns {String}
			 */
			getToggleProfileKey: function() {
				return this.sandbox.moduleName + "_showDescriptionsToggleState";
			},

			/**
			 * Saves description toggle state to local storage and profile.
			 * @protected
			 */
			saveToggleState: function() {
				var profileKey = this.getToggleProfileKey();
				var toggleState = {
					showDescriptions: this.$ShowDescriptions
				};
				BPMSoft.saveUserProfile(profileKey, toggleState, false);
				StorageUtilities.setItem(toggleState, "ShowDescriptions", profileKey);
			},

			/**
			 * Initializes description toggle state for current user.
			 * @protected
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Context.
			 */
			initToggleState: function(callback, scope) {
				if (!BPMSoft.Features.getIsEnabled("CampaignConditionalTransitionDescription")) {
					callback.call(scope, { showDescriptions: false });
					return;
				}
				var profileKey = this.getToggleProfileKey();
				var toggleState = StorageUtilities.getItem("ShowDescriptions", profileKey);
				if (BPMSoft.isEmpty(toggleState)) {
					BPMSoft.ProfileUtilities.getProfile({ profileKey: profileKey }, callback, scope);
					return;
				}
				callback.call(scope, toggleState);
			}
		});
	});
