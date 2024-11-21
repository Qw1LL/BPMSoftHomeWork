define("SectionDesignerStartPageModule", [
	"ext-base", "BPMSoft", "sandbox", "SectionDesignerStartPageModuleResources",
	"SectionDesignerUtils", "SectionDesignDataModule", "SectionDesignerEnums", "ImageCustomGeneratorV2"
],
	function(Ext, BPMSoft, sandbox, resources, SectionDesignerUtils, SectionDesignDataModule) {

		/**
		 * ################ ###### ########.
		 * @private
		 * @type {Object}
		 */
		var localizableStrings = resources.localizableStrings;

		/**
		 * ################ ########### ########.
		 * @private
		 * @type {Object}
		 */
		var localizableImages = resources.localizableImages;

		/**
		 * ###### ########### ###### ######### ########.
		 * @private
		 * @type {BPMSoft.BaseViewModel}
		 */
		var viewModel;

		/**
		 * ####### ###### #######.
		 * @private
		 * @type {Boolean}
		 */
		var isNewSection = true;

		/**
		 * #### ###### ######### ####### #########.
		 * @private
		 * @type {Boolean}
		 */
		var doNotFireChange = false;

		/**
		 * #### ######## ###### ######### #### ####### ##############/###############.
		 * @private
		 * @type {Boolean}
		 */
		var isMultiPageEditValueRollback = false;

		/**
		 * #### ######## ###### #########.
		 * @private
		 * @type {Boolean}
		 */
		var isDesignDataLoadingInProgress = false;

		/**
		 * ### ##########, # ####### ##### ######## ###### ############## ##### ####### ##############.
		 * @private
		 * @type {String}
		 */
		var multiPagesEditContainerName = "multiPagesEditContainer";

		/**
		 * ####### EntitySchema, ####### ##### #### ######## ####.
		 * @private
		 * @type {BPMSoft.Collection}
		 */
		var workplaceList = Ext.create("BPMSoft.Collection");

		function getWorkplaces() {
			var select = Ext.create("BPMSoft.EntitySchemaQuery", {
				rootSchemaName: "SysWorkplace"
			});
			select.addColumn("Id");
			select.addColumn("Name");
			select.getEntityCollection(function(response) {
				workplaceList = Ext.create("BPMSoft.Collection");
				if (response.success) {
					var items = response.collection.getItems();
					BPMSoft.each(items, function(item) {
						var workplaceId = item.get("Id");
						var workplace = {
							value: workplaceId,
							displayValue: item.get("Name")
						};
						workplaceList.add(workplace);
					}, this);
				}
			}, this);
		}

		/**
		 * ########## ######### #####.
		 * @private
		 * @returns {Boolean}
		 */
		function validateTypes() {
			var isMultiPage = viewModel.get("isMultiPageEdit");
			var typesValidationResult = true;
			if (isMultiPage) {
				typesValidationResult = sandbox.publish("ValidateTypes");
			}
			return typesValidationResult;
		}

		/**
		 * ######### ###### #########.
		 * @private
		 * @param {Object} data ###### #########.
		 */
		function applySectionData(data) {
			doNotFireChange = true;
			var caption = null;
			var sectionIcon = null;
			var sectionLogo = null;
			var isMultiPageEdit = false;
			var moduleData = data.module[data.mainModuleName] || {};
			if (data.mainModuleName) {
				caption = moduleData.caption;
				isMultiPageEdit = !SectionDesignerUtils.isEmptyOrEmptyGUID(moduleData.typeColumnId);
				sectionIcon = moduleData.sectionIconId ? {value: moduleData.sectionIconId} : null;
				sectionLogo = moduleData.sectionLogoId ? {value: moduleData.sectionLogoId} : null;
				viewModel.set("sectionCode", data.mainModuleName);
				viewModel.set("sectionCaption", caption);
				viewModel.set("sectionIcon", sectionIcon);
				viewModel.set("sectionLogo", sectionLogo);
				viewModel.set("dataLoaded", true);
			}
			viewModel.set("moduleData", moduleData);
			isNewSection = Ext.Object.isEmpty(moduleData) || moduleData.isNew;
			viewModel.set("isMultiPageEdit", isMultiPageEdit);
			viewModel.set("isSectionCodeEnabled", getCanModifySectionCode());
			viewModel.set("isPageRadioEnabled", viewModel.validateColumn("sectionCode") && !isMultiPageEdit);
			viewModel.set("isWorkplacesComboBoxEditVisible", isNewSection);
			viewModel.set("workplaceValue", data.workplaceId);
			sandbox.publish("OnSectionSchemaChanged", data);
			doNotFireChange = false;
		}

		function getCanModifySectionCode() {
			return !(viewModel && !Ext.Object.isEmpty(viewModel.get("moduleData")));
		}

		/**
		 * ####### ######### ########### ######.
		 * @private
		 * @returns {Object} ###########.
		 */
		function getView() {
			function getContainer(id, wrapClasses, items) {
				return {
					className: "BPMSoft.Container",
					id: id + "Container",
					selectors: {wrapEl: "#" + id + "Container"},
					classes: {wrapClassName: wrapClasses},
					afterrender: {
						bindTo: "onViewRendered"
					},
					items: items
				};
			}
			function getTextControlView(id, required) {
				var controlView = getContainer(id, ["control-width-15", "control-left", "control-right"], [
					getContainer(id + "Label", ["label-wrap"], [{
						className: "BPMSoft.Label",
						caption: localizableStrings["module" + id + "Label"],
						classes: {
							labelClass: (required) ? ["required-caption"] : null
						}
					}]),
					getContainer(id + "Control", ["control-wrap"], [{
						className: "BPMSoft.TextEdit",
						enabled: {
							bindTo: "isSection" + id + "Enabled"
						},
						value: {
							bindTo: "section" + id
						},
						markerValue: id
					}])
				]);
				return controlView;
			}
			function getWorkplacesComboBoxEditView() {
				var id = "Workplace";
				var controlView = getContainer(id, ["control-width-15", "control-left", "control-right"], [
					getContainer(id + "Label", ["label-wrap"], [{
						className: "BPMSoft.Label",
						caption: localizableStrings["module" + id + "Label"],
						visible: {
							bindTo: "isWorkplacesComboBoxEditVisible"
						}
					}]),
					getContainer(id + "Control", ["control-wrap"], [{
						className: "BPMSoft.ComboBoxEdit",
						value: {
							bindTo: "workplaceValue"
						},
						list: {
							bindTo: "workplaceList"
						},
						prepareList: {
							bindTo: "prepareWorkplaceList"
						},
						visible: {
							bindTo: "isWorkplacesComboBoxEditVisible"
						},
						markerValue: id
					}])
				]);
				return controlView;
			}

			var config = {
				id: "sectionDesignerStartPage",
				selectors: {
					wrapEl: "#sectionDesignerStartPage"
				},
				classes: {
					wrapClassName: ["start-page-main-container"]
				},
				items: [
					getContainer("icon", ["image-edit-container", "start-page-icon"], [{
						className: "BPMSoft.Label",
						caption: localizableStrings.MenuCaption,
						classes: {
							labelClass: ["start-page-image-label"]
						}
					}, {
						className: "BPMSoft.ImageEdit",
						imageSrc: {bindTo: "getIconSrc"},
						defaultImageSrc: BPMSoft.ImageUrlBuilder.getUrl(localizableImages.DefaultIcon),
						change: {bindTo: "onIconChange"},
						tag: "sectionIcon"
					}]),
					//getContainer("logo", ["image-edit-container", "start-page-icon"], [{
					//	className: "BPMSoft.Label",
					//	caption: localizableStrings.LogoCaption,
					//	classes: {
					//		labelClass: ["start-page-image-label"]
					//	}
					//}, {
					//	className: "BPMSoft.ImageEdit",
					//	imageSrc: { bindTo: "getIconSrc" },
					//	defaultImageSrc: BPMSoft.ImageUrlBuilder.getUrl(localizableImages.DefaultLogo),
					//	change: { bindTo: "onIconChange" },
					//	tag: "sectionLogo"
					//}]),
					getContainer("fields", ["start-page-controls"], [
						getTextControlView("Code", true),
						getTextControlView("Caption"),
						getWorkplacesComboBoxEditView()
					]),
					getContainer("pages", ["start-page-pages-container"], [
						{
							className: "BPMSoft.Container",
							id: "multiPageContainer",
							selectors: {
								wrapEl: "#multiPageContainer"
							},
							classes: {
								wrapClassName: ["start-page-page-container"]
							},
							visible: true,
							items: [
								{
									className: "BPMSoft.CheckBoxEdit",
									checked: {
										bindTo: "isMultiPageEdit"
									},
									enabled: {
										bindTo: "isPageRadioEnabled"
									},
									markerValue: localizableStrings.MultiPageButtonCaption
								},
								{
									className: "BPMSoft.Label",
									caption: localizableStrings.MultiPageButtonCaption,
									classes: {
										labelClass: ["start-page-radio-button-caption"]
									}
								},
								{
									className: "BPMSoft.Label",
									caption: localizableStrings.MultiPageHint,
									classes: {
										labelClass: ["start-page-hint-label"]
									}
								},
								{
									className: "BPMSoft.Container",
									id: multiPagesEditContainerName,
									selectors: {
										wrapEl: "#" + multiPagesEditContainerName
									},
									classes: {
										wrapClassName: ["start-page-multi-pages-edit-container"]
									},
									items: [
									]
								}
							]
						}
					])
				]
			};
			var view = Ext.create("BPMSoft.Container", config);
			return view;
		}

		/**
		 * ######## ###### ###########.
		 * @private
		 * @returns {Object} ###### ###########.
		 */
		function getViewModel() {
			var config = {
				entitySchema: Ext.create("BPMSoft.BaseEntitySchema", {
					name: "SectionDesignerEntitySchema",
					columns: {
						sectionIcon: {
							dataValueType: BPMSoft.DataValueType.IMAGE,
							name: "sectionIcon"
						},
						sectionCode: {
							dataValueType: BPMSoft.DataValueType.TEXT,
							isRequired: true,
							name: "sectionCode"
						},
						sectionCaption: {
							dataValueType: BPMSoft.DataValueType.TEXT,
							isRequired: true,
							size: 50,
							name: "sectionCaption"
						}
					}
				}),
				columns: {
					sectionCode: {
						dataValueType: BPMSoft.DataValueType.TEXT,
						isRequired: true,
						name: "sectionCode",
						maxEntitySchemaNameLength: 14
					},
					sectionCaption: {
						dataValueType: BPMSoft.DataValueType.TEXT,
						isRequired: true,
						columnPath: "sectionCaption",
						name: "sectionCaption"
					},
					sectionIcon: {
						dataValueType: BPMSoft.DataValueType.IMAGE,
						name: "sectionIcon"
					},
					sectionLogo: {
						dataValueType: BPMSoft.DataValueType.IMAGE,
						name: "sectionLogo"
					},
					dataLoaded: {
						dataValueType: BPMSoft.DataValueType.BOOLEAN,
						isRequired: true,
						name: "dataLoaded"
					}
				},
				values: {
					isMultiPageEdit: true,
					isPageRadioEnabled: false,
					isSectionCodeEnabled: false,
					isSectionCaptionEnabled: true,
					workplaceList: new BPMSoft.Collection(),
					workplaceValue: null,
					isWorkplacesComboBoxEditVisible: false,
					header: localizableStrings.Header,
					sectionCode: "",
					sectionCaption: "",
					sectionIcon: null,
					sectionLogo: null
				},
				methods: {
					onIconChange: function(photo, tag) {
						if (photo) {
							var data = {
								file: photo,
								onComplete: function(imageId) {
									var newImageValue = {value: imageId};
									this.set(tag, newImageValue);
								},
								onError: function() {},
								scope: this
							};
							BPMSoft.ImageApi.upload(data);
						} else {
							this.set(tag, null);
						}
					},
					getIconSrc: function(tag) {
						var result = "";
						var primaryImageColumnValue = this.get(tag);
						if (primaryImageColumnValue) {
							result = this.getSchemaImageUrl(primaryImageColumnValue);
						}
						return result;
					},
					prepareWorkplaceList: function(filter, list) {
						list.clear();
						list.loadAll(workplaceList);
					},
					getSchemaImageUrl: function(primaryImageColumnValue) {
						if (!primaryImageColumnValue) {
							return null;
						}
						var imageConfig = {
							source: BPMSoft.ImageSources.SYS_IMAGE,
							params: {
								primaryColumnValue: primaryImageColumnValue.value
							}
						};
						return BPMSoft.ImageUrlBuilder.getUrl(imageConfig);
					},
					onViewRendered: function() {
						sandbox.publish("ModuleLoaded");
					}
				},
				validationConfig: {
					sectionCode: [
						function(value, column) {
							var result = SectionDesignerUtils.validateSystemName(value, {
								maxLength: column.maxEntitySchemaNameLength
							}, isNewSection);
							return result;
						}
					]
				}
			};
			var viewModel = Ext.create("BPMSoft.BaseViewModel", config);
			viewModel.on("change:isMultiPageEdit", function(bbModel, value) {
				viewModel.set("isPageRadioEnabled", !value);
				if (isMultiPageEditValueRollback) {
					return;
				}
				BPMSoft.chain({
					isMultiPageEdit: Boolean(value)
				}, [
					function(context) {
						if (viewModel && !Ext.Object.isEmpty(viewModel.get("moduleData"))) {
							context.next();
						} else {
							var sectionCode =  viewModel.get("sectionCode");
							var sectionCaption =  viewModel.get("sectionCaption") || sectionCode;
							var icon = viewModel.get("sectionIcon");
							var logo = viewModel.get("sectionLogo");
							var workplaceValue =  viewModel.get("workplaceValue");
							var maskId = BPMSoft.Mask.show();
							sandbox.publish("OnSectionCodeChanged", {
								sectionCode: sectionCode,
								workplaceId: workplaceValue,
								sectionCaption: sectionCaption,
								sectionIconId: icon ? icon.value : null,
								sectionLogoId: logo ? logo.value : null,
								callback: function(data) {
									applySectionData(data);
									BPMSoft.Mask.hide(maskId);
									viewModel.set("isMultiPageEdit", context.isMultiPageEdit);
									context.next();
								}
							});
						}
					},
					function(context) {
						sandbox.publish("OnMultiPageChanged", context.isMultiPageEdit);
					}
				]);
			});
			viewModel.on("change:sectionCode", function() {
				if (viewModel) {
					var isMultiPageEdit = viewModel.get("isMultiPageEdit");
					viewModel.set("isPageRadioEnabled", viewModel.validateColumn("sectionCode") && !isMultiPageEdit);
				}
			});
			viewModel.on("change:sectionCaption", function(bbModel, value) {
				if (!doNotFireChange && viewModel.validate()) {
					isDesignDataLoadingInProgress = true;
					var maskId = BPMSoft.Mask.show();
					SectionDesignerUtils.setSectionCaption(value, function() {
						isDesignDataLoadingInProgress = false;
						BPMSoft.Mask.hide(maskId);
					}, viewModel);
				}
			});
			viewModel.on("change:workplaceValue", function(bbModel, value) {
				SectionDesignerUtils.setSectionWorkplace(value);
			});
			viewModel.on("change:sectionIcon", function() {
				if (!doNotFireChange && viewModel.validate()) {
					isDesignDataLoadingInProgress = true;
					var maskId = BPMSoft.Mask.show();
					var icon = viewModel.get("sectionIcon");
					var sectionIconId = icon ? icon.value : null;
					SectionDesignerUtils.setSectionIcon(sectionIconId, function() {
						isDesignDataLoadingInProgress = false;
						BPMSoft.Mask.hide(maskId);
					}, viewModel);
				}
			});
			viewModel.on("change:sectionLogo", function() {
				if (!doNotFireChange && viewModel.validate()) {
					isDesignDataLoadingInProgress = true;
					var maskId = BPMSoft.Mask.show();
					var logo = viewModel.get("sectionLogo");
					var sectionLogoId = logo ? logo.value : null;
					SectionDesignerUtils.setSectionLogo(sectionLogoId, function() {
						isDesignDataLoadingInProgress = false;
						BPMSoft.Mask.hide(maskId);
					}, viewModel);
				}
			});
			return viewModel;
		}

		/**
		 * ############# ###########.
		 * @param {Object} renderTo ######### ### ######### ######.
		 */
		function initView(renderTo) {
			getWorkplaces();
			var view  = getView();
			view.bind(viewModel);
			view.render(renderTo);
		}

		/**
		 * ########## ################ ###### ####### ######.
		 * @return{Object} ################ ###### ####### ######.
		 */
		function getHeaderConfig() {
			return {
				header: localizableStrings.Header,
				buttons: {
					Previous: {
						enabled: false
					}
				}
			};
		}

		/**
		 * ####### ############# ######.
		 */
		function init() {
			sandbox.publish("SetPageHeaderInfo", getHeaderConfig());
			sandbox.subscribe("GetHeaderConfig", getHeaderConfig);
		}

		/**
		 * ####### ######### ######.
		 * @param {Object} renderTo ######### ### ######### ######.
		 */
		function render(renderTo) {
			if (viewModel) {
				initView(renderTo);
			} else {
				viewModel = getViewModel();
				initView(renderTo);
				var multiPagesEditContainer = Ext.getCmp(multiPagesEditContainerName);
				sandbox.loadModule("SectionDesignerPageTypeModule", {
					renderTo: multiPagesEditContainer.getRenderToEl()
				});
				SectionDesignDataModule.getDesignData(applySectionData);
				sandbox.subscribe("IsStepReady", function(callback) {
					var codeValid = viewModel.validateColumn("sectionCode");
					if (!doNotFireChange && codeValid) {
						isDesignDataLoadingInProgress = true;
						var sectionCode = viewModel.get("sectionCode");
						var maskId = BPMSoft.Mask.show();
						SectionDesignDataModule.getDesignData(function(data) {
							if (data.mainModuleName !== sectionCode) {
								var icon = viewModel.get("sectionIcon");
								var logo = viewModel.get("sectionLogo");
								sandbox.publish("OnSectionCodeChanged", {
									sectionCode: sectionCode,
									sectionCaption: viewModel.get("sectionCaption"),
									sectionIconId: icon ? icon.value : null,
									sectionLogoId: logo ? logo.value : null,
									workplaceId: viewModel.get("workplaceValue"),
									callback: function(data, result) {
										if (result === false) {
											applySectionData(data);
										}
										BPMSoft.Mask.hide(maskId);
										callback(result);
									}
								});
							} else {
								BPMSoft.Mask.hide(maskId);
								isDesignDataLoadingInProgress = false;
								var result = viewModel.validate() && validateTypes();
								callback(result);
							}
						});
					} else if (!codeValid) {
						callback(false);
					}
					return false;
				});
				SectionDesignerUtils.getMaxEntitySchemaNameLength(function(result) {
					viewModel.columns.sectionCode.maxEntitySchemaNameLength = result;
				}, this);
			}
		}

		return {
			init: init,
			render: render
		};
	}
);
