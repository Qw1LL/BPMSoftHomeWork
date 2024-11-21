define("SummarySettingsViewGenerator", ["ext-base", "BPMSoft", "SummarySettingsViewGeneratorResources"],
	function(Ext, BPMSoft, resources) {

		function generateRow(renderTo, key) {
			var view = {
				renderTo: renderTo,
				id: "row-summary-settings-view-" + key,
				selectors: {
					el: "#row-summary-settings-view-" + key,
					wrapEl: "#row-summary-settings-view-" + key
				},
				classes: {
					wrapClassName: ["grid-listed-row", "label-grid-listed-row"]
				},
				items: [
					{
						className: "BPMSoft.Container",
						id: "path-container" + key,
						selectors: {
							wrapEl: "#path-container" + key
						},
						classes: {
							wrapClassName: ["grid-cols-9", "grid-cols-summary"]
						},
						items: [
							{
								className: "BPMSoft.Label",
								classes: {
									labelClass: ["row-label-column"]
								},
								caption: {
									bindTo: "path"
								}
							},
							{
								className: "BPMSoft.Label",
								caption: {
									bindTo: "columnPath"
								},
								visible: false
							}
						]
					},
					{
						className: "BPMSoft.Container",
						id: "combo-box-container" + key,
						selectors: {
							wrapEl: "#combo-box-container" + key
						},
						classes: {
							wrapClassName: ["grid-cols-6", "grid-cols-summary-button"]
						},
						items: [
							{
								className: "BPMSoft.Button",
								style: BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
								caption: {
									bindTo: "funcSelectedCaption"
								},
								classes: {
									wrapperClass: ["function-button"]
								},
								menu: {
									items: [
										{
											caption: {
												bindTo: "funcSumCaption"
											},
											click: {
												bindTo: "functionChanged"
											},
											visible : {
												bindTo: "funcSumVisible"
											},
											tag: "SUM"
										},
										{
											caption: {
												bindTo: "funcAvgCaption"
											},
											click: {
												bindTo: "functionChanged"
											},
											visible : {
												bindTo: "funcAvgVisible"
											},
											tag: "AVG"
										},
										{
											caption: {
												bindTo: "funcMaxCaption"
											},
											click: {
												bindTo: "functionChanged"
											},
											visible : {
												bindTo: "funcMaxVisible"
											},
											tag: "MAX"
										},
										{
											caption: {
												bindTo: "funcMinCaption"
											},
											click: {
												bindTo: "functionChanged"
											},
											visible : {
												bindTo: "funcMinVisible"
											},
											tag: "MIN"
										}
									]
								}
							}
						]
					},
					{
						className: "BPMSoft.Container",
						id: "caption-container" + key,
						selectors: {
							wrapEl: "#caption-container" + key
						},
						classes: {
							wrapClassName: ["grid-cols-9"]
						},
						items: [
							{
								className: "BPMSoft.Container",
								id: "display-caption-container" + key,
								selectors: {
									wrapEl: "#display-caption-container" + key
								},
								classes: {
									wrapClassName: ["display-caption-container"]
								},
								visible: {
									bindTo: "displayCaptionContainerVisible"
								},
								items: [
									{
										className: "BPMSoft.Label",
										classes: {
											labelClass: ["row-label-column"]
										},
										caption: {
											bindTo: "columnCaption"
										},
										click: {
											bindTo: "captionLabelClick"
										}
									},
									{
										className: "BPMSoft.Button",
										style: BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
										imageConfig: resources.localizableImages.ImageDeleteButton,
										classes: {
											wrapperClass: ["delete-button-wrapperEl"],
											imageClass: ["delete-button-image-size"]
										},
										click: {
											bindTo: "deleteRow"
										},
										markerValue: {
											bindTo: "columnCaption"
										}
									}
								]
							},
							{
								className: "BPMSoft.Container",
								id: "edit-caption-container" + key,
								selectors: {
									wrapEl: "#edit-caption-container" + key
								},
								classes: {
									wrapClassName: ["edit-caption-container"]
								},
								visible: {
									bindTo: "editCaptionContainerVisible"
								},
								items: [
									{
										className: "BPMSoft.Container",
										id: "edit-buttons-caption-container" + key,
										selectors: {
											wrapEl: "#edit-buttons-caption-container" + key
										},
										classes: {
											wrapClassName: ["edit-buttons-caption-container"]
										},
										items: [
											{
												className: "BPMSoft.Button",
												style: BPMSoft.controls.ButtonEnums.style.ORANGE,
												imageConfig: resources.localizableImages.ImageConfirmButton,
												classes: {
													wrapperClass: ["edit-button-wrapperEl"],
													imageClass: ["edit-button-image-size"]
												},
												click: {
													bindTo: "confirmChangeCaption"
												}
											},
											{
												className: "BPMSoft.Button",
												style: BPMSoft.controls.ButtonEnums.style.DEFAULT,
												imageConfig: resources.localizableImages.ImageDiscardButton,
												classes: {
													wrapperClass: ["edit-button-wrapperEl"],
													imageClass: ["edit-button-image-size"]
												},
												click: {
													bindTo: "discardChangeCaption"
												}
											}
										]
									},
									{
										className: "BPMSoft.Container",
										id: "edit-text-caption-container" + key,
										selectors: {
											wrapEl: "#edit-text-caption-container" + key
										},
										classes: {
											wrapClassName: ["edit-text-caption-container"]
										},
										items: [
											{
												id: "caption-edit-" + key,
												className: "BPMSoft.TextEdit",
												classes: {
													wrapClass: ["caption-edit"]
												},
												value: {
													bindTo: "columnEditCaption"
												},
												keydown: {
													bindTo: "keyPressed"
												}
											}
										]
									}
								]
							}
						]
					}
				]
			};
			return view;
		}

		function getTopButtonsContainerItems() {
			return [
				{
					className: "BPMSoft.Button",
					style: BPMSoft.controls.ButtonEnums.style.ORANGE,
					caption: resources.localizableStrings.SaveButtonCaption,
					classes: {
						textClass: ["main-buttons"]
					},
					click: {
						bindTo: "saveToProfile"
					}
				},
				{
					className: "BPMSoft.Button",
					style: BPMSoft.controls.ButtonEnums.style.DEFAULT,
					caption: resources.localizableStrings.CancelButtonCaption,
					classes: {
						textClass: ["main-buttons"]
					},
					click: {
						bindTo: "cancel"
					}
				}
			];
		}
		
		function getContentUpperContainerItems() {
			return [
				{
					className: "BPMSoft.Container",
					id: "check-box-container",
					selectors: {
						wrapEl: "#check-box-container"
					},
					classes: {
						wrapClassName: ["check-box-container"]
					},
					items: [
						{
							id: "summary-count-check-box",
							className: "BPMSoft.CheckBoxEdit",
							checked: {
								bindTo: "isChecked"
							},
							markerValue: resources.localizableStrings.DisplayRecordCountCaption
						},
						{
							className: "BPMSoft.Label",
							caption: resources.localizableStrings.DisplayRecordCountCaption,
							classes: {
								labelClass: ["check-box-label"]
							},
							inputId : "summary-count-check-box-el",
							width: "auto"
						}
					]
				},
				{
					className: "BPMSoft.Button",
					style: BPMSoft.controls.ButtonEnums.style.DEFAULT,
					caption: resources.localizableStrings.AddButtonCaption,
					classes: {
						wrapperClass: ["main-buttons"]
					},
					click: {
						bindTo: "addRow"
					}
				}
			];
		}
		
		function getTableGridItems() {
			return [
				{
					className: "BPMSoft.Container",
					id: "table-grid-caption-container",
					selectors: {
						wrapEl: "#table-grid-caption-container"
					},
					classes: {
						wrapClassName: ["grid-captions", "grid-captions-summary"]
					},
					items: [
						{
							className: "BPMSoft.Label",
							caption: resources.localizableStrings.ColumnHeaderCaption,
							classes: {
								labelClass: ["grid-cols-9", "caption-label-column"]
							}
						},
						{
							className: "BPMSoft.Label",
							caption: resources.localizableStrings.ColumnFuncCaption,
							classes: {
								labelClass: ["grid-cols-6", "caption-label-column"]
							}
						},
						{
							className: "BPMSoft.Label",
							caption: resources.localizableStrings.ColumnTitleCaption,
							classes: {
								labelClass: ["grid-cols-9", "caption-label-column"]
							}
						}
					]
				}
			];
		}
		
		function generate(renderTo) {
			var view = {
				id: "main-summary-settings-view",
				selectors: {
					el: "#main-summary-settings-view",
					wrapEl: "#main-summary-settings-view"
				},
				items: [
					{
						className: "BPMSoft.Container",
						id: "top-container",
						selectors: {
							wrapEl: "#top-container"
						},
						classes: {
							wrapClassName: ["top-container"]
						},
						items: [
							{
								className: "BPMSoft.Container",
								id: "top-buttons-container",
								selectors: {
									wrapEl: "#top-buttons-container"
								},
								classes: {
									wrapClassName: ["top-buttons-container"]
								},
								items: getTopButtonsContainerItems()
							},
							{
								className: "BPMSoft.Container",
								id: "content-container",
								selectors: {
									wrapEl: "#content-container"
								},
								classes: {
									wrapClassName: ["content-container"]
								},
								items: [
									{
										className: "BPMSoft.Container",
										id: "content-upper-container",
										selectors: {
											wrapEl: "#content-upper-container"
										},
										classes: {
											wrapClassName: ["content-upper-container"]
										},
										items: getContentUpperContainerItems()
									},
									{
										className: "BPMSoft.Container",
										id: "content-down-container",
										selectors: {
											wrapEl: "#content-down-container"
										},
										classes: {
											wrapClassName: ["content-down-container"]
										},
										items: [
											{
												className: "BPMSoft.Container",
												id: "table-grid-container",
												selectors: {
													wrapEl: "#table-grid-container"
												},
												classes: {
													wrapClassName: ["grid"]
												},
												items: getTableGridItems()
											}
										]
									}
								]
							}
						]
					}
				]
			};
			return view;
		}

		return {
			generate: generate,
			generateRow: generateRow
		};
	});

