define("DuplicatesModuleView", ["ext-base", "BPMSoft", "DuplicatesModuleViewResources"],
	function(Ext, BPMSoft, resources) {
		/*var entitySchemaName;*/
		function generate(entitySchemaName) {
			this.entitySchemaName = entitySchemaName;

			var columnsConfig = [];
			if (entitySchemaName === "Account") {
				columnsConfig = [{
					cols: 6,
					key: [{
						name: resources.localizableStrings["GridTitle" + this.entitySchemaName],
						type: "caption"
					}, {
						name: {
							bindTo: "Name"
						}
					}]
				}, {
					cols: 6,
					key: [{
						name: resources.localizableStrings.GridTitleAccountPhone,
						type: "caption"
					}, {
						name: {
							bindTo: "Phone"
						}
					}]
				}, {
					cols: 6,
					key: [{
						name: resources.localizableStrings.GridTitleAccountAdditionalPhone,
						type: "caption"
					}, {
						name: {
							bindTo: "AdditionalPhone"
						}
					}]
				}, {
					cols: 6,
					key: [{
						name: resources.localizableStrings.GridTitleAccountWeb,
						type: "caption"
					}, {
						name: {
							bindTo: "Web"
						}
					}]
				}];
			} else {
				columnsConfig = [{
					cols: 6,
					key: [{
						name: resources.localizableStrings["GridTitle" + this.entitySchemaName],
						type: "caption"
					}, {
						name: {
							bindTo: "Name"
						}
					}]
				}, {
					cols: 6,
					key: [{
						name: resources.localizableStrings.GridTitleContactMobilePhone,
						type: "caption"
					}, {
						name: {
							bindTo: "MobilePhone"
						}
					}]
				}, {
					cols: 6,
					key: [{
						name: resources.localizableStrings.GridTitleContactHomePhone,
						type: "caption"
					}, {
						name: {
							bindTo: "HomePhone"
						}
					}]
				}, {
					cols: 6,
					key: [{
						name: resources.localizableStrings.GridTitleContactEmail,
						type: "caption"
					}, {
						name: {
							bindTo: "Email"
						}
					}]
				}];
			}

			function getActionsConfig(actions, id) {
				return {
					className: "BPMSoft.Container",
					id: id || "settings-container",
					selectors: {
						wrapEl: "#" + (id || "settings-container")
					},
					items: [
						{
							id: "settings-buttom",
							selectors: {
								wrapEl: "#settings-buttom"
							},
							className: "BPMSoft.Button",
							/*classes: {
								wrapperClass: ["open-button-wrapperEl"],
								imageClass: ["open-button-image-size"],
								markerClass: ["open-button-markerEl"]
							},*/
							caption: resources.localizableStrings.SettingsButtonCaption,
							/*style: BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
							imageConfig: resources.localizableImages.ImageOpenButton,
							margin: "0px 10px 0px 0px",*/
							menu: {
								items: actions
							}
						}
					]
				};
			}

			var viewConfig = {
				id: "duplicatesModuleContainer",
				selectors: {
					wrapEl: "#duplicatesModuleContainer"
				},
				items: [{
					className: "BPMSoft.Container",
					id: "buttonsContainer",
					selectors: {
						wrapEl: "#buttonsContainer"
					},
					items: [{
						className: "BPMSoft.Button",
						id: "startButton",
						caption: resources.localizableStrings.StartCaption,
						style: BPMSoft.controls.ButtonEnums.style.ORANGE,
						tag: "StartButton",
						markerValue: "StartButton",
						enabled: {
							bindTo: "startButtonEnabled"
						},
						click: {
							bindTo: "onStartClick"
						}
					}, {
						className: "BPMSoft.Button",
						id: "stopButton",
						caption: resources.localizableStrings.StopCaption,
						tag: "StopButton",
						enabled: {
							bindTo: "stopButtonEnabled"
						},
						click: {
							bindTo: "onStopClick"
						}
					}, {
						className: "BPMSoft.Button",
						id: "cancelButton",
						caption: resources.localizableStrings.CancelButtonCaption,
						tag: "CancelButton",
						click: {
							bindTo: "cancelClick"
						}
					}, getActionsConfig([{
						caption: resources.localizableStrings.ScheduleCaption,
						tag: "ScheduleButton",
						click: {
							bindTo: "onScheduleClick"
						}
					}])]
				}, {
					className: "BPMSoft.Container",
					id: "DescriptionContainer",
					selectors: {
						wrapEl: "#DescriptionContainer"
					},
					items: [{
						className: "BPMSoft.Label",
						caption: {
							bindTo: "statusDescription"
						}
					}]
				}, {
					className: "BPMSoft.Container",
					id: "gridContainer",
					selectors: {
						wrapEl: "#gridContainer"
					},
					items: [{
						id: "duplicateGrid",
						className: "BPMSoft.Grid",
						type: "tiled",
						watchRowInViewport: 2,
						multiSelect: true,
						primaryColumnName: "Id",
						hierarchical: true,
						hierarchicalColumnName: "Parent",
						columnsConfig: [columnsConfig],
						activeRow: {
							bindTo: "activeRow"
						},
						selectedRows: {
							bindTo: "selectedRows"
						},
						/*
						selectRow: {
							bindTo: "onRowsSelectionChanged"
						},
						unSelectRow: {
							bindTo: "onRowsSelectionChanged"
						},*/
						isLoading: {
							bindTo: "gridLoading"
						},
						isEmpty: {
							bindTo: "gridEmpty"
						},
						watchedRowInViewport: {
							bindTo: "loadNext"
						},
						collection: {
							bindTo: "gridData"
						},
						activeRowAction: {
							bindTo: "onActiveRowAction"
						},
						expandHierarchyLevels: {
							bindTo: "expandHierarchyLevels"
						},
						updateExpandHierarchyLevels: {
							bindTo: "onExpandHierarchyLevels"
						},
						activeRowActions: [{
							className: "BPMSoft.Button",
							style: BPMSoft.controls.ButtonEnums.style.ORANGE,
							caption: resources.localizableStrings.MergeButtonCaption,
							tag: "MergeDuplicate",
							enabled: {
								bindTo: "getGridButtonEnabled"
							},
							visible: {
								bindTo: "getGridButtonVisible"
							}
						}, {
							className: "BPMSoft.Button",
							caption: resources.localizableStrings.NotDuplicatesButtonCaption,
							tag: "IsNotDuplicate",
							enabled: {
								bindTo: "getGridButtonEnabled"
							},
							visible: {
								bindTo: "getGridButtonVisible"
							}
						}]
					}]
				}]
			};
			return viewConfig;
		}

		function getMainHeaderCaption(entitySchemaName) {
			return resources.localizableStrings[entitySchemaName + "Caption"];
		}

		return {
			generate: generate,
			getMainHeaderCaption: getMainHeaderCaption
		};
	});
