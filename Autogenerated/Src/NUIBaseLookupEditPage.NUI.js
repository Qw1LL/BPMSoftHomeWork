define("NUIBaseLookupEditPage", ["ext-base", "BPMSoft", "sandbox", "NUIBaseLookupEditPageResources", "MaskHelper"],
	function(Ext, BPMSoft, sandbox, resources, MaskHelper) {
		var entityInfo;
		var viewModel;

		function createView(schema) {
			var primaryDisplayCaptionClasses = schema.primaryDisplayColumn.isRequired ?
				["control-caption", "required-caption"] :
				["control-caption"];
			var view;
			view = Ext.create("BPMSoft.Container", {
				id: "lookupEditPageContainer",
				selectors: {
					el: "#lookupEditPageContainer",
					wrapEl: "#lookupEditPageContainer"
				},
				classes: {
					wrapClassName: ["lookup-edit-page-container"]
				},
				items: [
					{
						className: "BPMSoft.Container",
						id: "topSettings",
						selectors: {
							wrapEl: "#topSettings"
						},
						classes: {
							wrapClassName: ["top-settings-container"]
						},
						items: [
							{
								id: "SaveButton",
								tag: "SaveButton",
								className: "BPMSoft.Button",
								style: BPMSoft.controls.ButtonEnums.style.ORANGE,
								caption: resources.localizableStrings.SaveButtonCaption,
								click: {
									bindTo: "saveButtonClick"
								}
							},
							{
								id: "CancelButton",
								className: "BPMSoft.Button",
								style: BPMSoft.controls.ButtonEnums.style.DEFAULT,
								caption: resources.localizableStrings.CancelButtonCaption,
								classes: {
									textClass: ["cancel-button"]
								},
								click: {
									bindTo: "cancelButtonClick"
								}
							}
						]
					},
					{
						className: "BPMSoft.Container",
						id: "controlsContainer",
						selectors: {
							wrapEl: "#controlsContainer"
						},
						classes: {
							wrapClassName: ["controls-container"]
						},
						items: [
							{
								className: "BPMSoft.Label",
								id: "captionLabel",
								caption: {
									bindTo: "captionLabel"
								},
								classes: {
									labelClass: primaryDisplayCaptionClasses
								}
							},
							{
								id: "NameEdit",
								className: "BPMSoft.TextEdit",
								classes: {
									wrapClass: ["name-edit"]
								},
								value: {
									bindTo: schema.primaryDisplayColumnName
								}
							},
							{
								className: "BPMSoft.Label",
								id: "descriptionLabel",
								caption: {
									bindTo: "descriptionLabel"
								},
								classes: {
									labelClass: ["control-caption"]
								}
							},
							{
								id: "DescriptionEdit",
								className: "BPMSoft.MemoEdit",
								classes: {
									wrapClass: ["description-edit"]
								},
								value: {
									bindTo: "Description"
								},
								visible: {
									bindTo: "isDescription"
								}
							}
						]
					}
				]
			});
			return view;
		}

		function createViewModel(schema) {
			var viewModel = Ext.create("BPMSoft.BaseViewModel", {
				entitySchema: schema,
				values: {
					pageCaption: "",
					Description: "",
					descriptionLabel: "",
					captionLabel: "",
					isDescription: true
				},
				methods: {
					saveButtonClick: function() {
						this.saveEntity(this.goBack, this);
					},
					cancelButtonClick: function() {
						this.goBack();
					},
					goBack: function() {
						var selectedRows = new BPMSoft.Collection();
						selectedRows.add(0, {
							Code: viewModel.get("Code"),
							Id: viewModel.get("Id"),
							Name: viewModel.get("Name"),
							displayValue: viewModel.get("Name"),
							value: viewModel.get("Id")
						});
						sandbox.publish("ResultSelectedRows", {
							columnName: entityInfo.lookupInfo.columnName,
							selectedRows: selectedRows
						}, [sandbox.id.substring(0, sandbox.id.lastIndexOf("_"))]);
						sandbox.publish("BackHistoryState");
					}
				}
			});
			viewModel.values[schema.primaryColumnName] = "";
			viewModel.values[schema.primaryDisplayColumnName] = "";
			return viewModel;
		}

		function init() {
			var state = sandbox.publish("GetHistoryState");
			var currentHash = state.hash;
			var currentState = state.state || {};
			if (currentState.moduleId === sandbox.id) {
				return;
			}
			sandbox.publish("ReplaceHistoryState", {
				stateObj: {
					moduleId: sandbox.id
				},
				pageTitle: null,
				hash: currentHash.historyState,
				silent: true
			});
			entityInfo = sandbox.publish("CardModuleEntityInfo", null, [sandbox.id]);
		}

		function render(renderTo) {
			var headerCaption = entityInfo.lookupCaption;
			sandbox.publish("ChangeHeaderCaption", {
				caption: headerCaption,
				dataViews: new BPMSoft.Collection()
			});
			sandbox.subscribe("NeedHeaderCaption", function() {
				sandbox.publish("InitDataViews", { caption: headerCaption });
			}, this);

			require([entityInfo.entitySchemaName], function(schema) {
				viewModel = createViewModel(schema);
				viewModel.set("pageCaption", entityInfo.lookupCaption);
				viewModel.set("captionLabel", schema.primaryDisplayColumn.caption);
				if (schema.columns.Description) {
					viewModel.set("descriptionLabel", schema.columns.Description.caption);
					viewModel.set("isDescription", true);
				} else {
					viewModel.set("descriptionLabel", "");
					viewModel.set("isDescription", false);
				}
				viewModel.entitySchema = schema;
				viewModel.isNew = entityInfo.action === "add" || entityInfo.action === "copy";
				BPMSoft.each(schema.columns, function(entitySchemaColumn, columnName) {
					viewModel.columns[columnName] = {
						type: BPMSoft.ViewModelColumnType.ENTITY_COLUMN,
						columnPath: entitySchemaColumn.name,
						isLookup: false,
						isRequired: entitySchemaColumn.isRequired
					};
				});
				var container = this.renderTo = renderTo;
				if (entityInfo.activeRow && entityInfo.action !== "add") {
					viewModel.loadEntity(entityInfo.activeRow, function() {
						renderView.call(this, schema, container);
					}, viewModel);
				} else {
					viewModel.setDefaultValues(function() {
						renderView.call(viewModel, schema, container);
					});
				}
			});
		}

		function renderView(schema, renderTo) {
			var view = createView(schema);
			view.bind(this);
			view.render(renderTo);
			MaskHelper.HideBodyMask();
		}

		return {
			init: init,
			render: render
		};
	});
