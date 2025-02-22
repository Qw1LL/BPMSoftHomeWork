﻿define("DcmStageViewConfigBuilder", ["DcmStageViewConfigBuilderResources"], function(resources) {
	Ext.define("BPMSoft.configuration.DcmStageViewConfigBuilder", {
		extend: "BPMSoft.BaseObject",
		alternateClassName: "BPMSoft.DcmStageViewConfigBuilder",

		// region Properties: Private

		/**
		 * Dcm stage view model instance.
		 * @private
		 * @type {BPMSoft.DcmStageViewModel}
		 */
		viewModel: null,

		// endregion

		// region Methods: Private

		/**
		 * Returns stage caption label config.
		 * @private
		 * @return {Object}
		 */
		getStageCaptionConfig: function() {
			return {
				className: "BPMSoft.Label",
				wordWrap: false,
				caption: {
					bindTo: "Caption"
				}
			};
		},

		/**
		 * Returns stage remove button config.
		 * @private
		 * @return {Object}
		 */
		getStageRemoveButtonConfig: function() {
			return {
				className: "BPMSoft.Button",
				classes: {
					imageClass: ["remove-stage-image"],
					wrapperClass: ["btn-remove-stage-wrap"]
				},
				imageConfig: resources.localizableImages.CloseButtonImage,
				style: BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
				visible: {
					bindTo: "IsVisibleStageRemoveButton"
				},
				click: {
					bindTo: "onStageRemoveButtonClick"
				}
			};
		},


		/**
		 * Returns stage items container config.
		 * @private
		 * @return {Object}
		 */
		getStageItemsContainerConfig: function() {
			var id = this.viewModel.get("Id");
			return {
				className: "BPMSoft.DcmReorderableContainer",
				tag: id,
				align: BPMSoft.enums.ReorderableContainer.Align.VERTICAL,
				dropGroupName: "dcm-stage-items",
				groupName: "dcm-stage-items",
				classes: {
					wrapClassName: ["dcm-stage-items"]
				},
				viewModelItems: {
					bindTo: "ViewModelItems"
				},
				reorderableIndex: {
					bindTo: "ReorderableIndex"
				},
				onDragEnter: {
					bindTo: "onDragOver"
				},
				onDragOver: {
					bindTo: "onDragOver"
				},
				onDragDrop: {
					bindTo: "onDragDrop"
				},
				onDragOut: {
					bindTo: "onDragOut"
				},
				itemsEventMap: {
					select: "elementSelected",
					dblclick: "elementDblClick",
					removeBtnClick: "elementRemoveBtnClick"
				}
			};
		},

		/**
		 * Returns add element container config.
		 * @private
		 * @return {Object}
		 */
		getAddElementContainerConfig: function() {
			return {
				className: "BPMSoft.Container",
				classes: {
					wrapClassName: [
						"add-dcm-stage-element",
						this.getAddDcmStageElementControlClassName()
					]
				},
				items: [
					this.getAddElementButtonConfig(),
					this.getNewDcmStageElementCaptionConfig()
				]
			};
		},

		/**
		 * Returns add dcm stage element control class name.
		 * @private
		 * @return {String}
		 */
		getAddDcmStageElementControlClassName: function() {
			return this.viewModel.get("Id") + this.viewModel.addDcmStageElementClassName;
		},

		/**
		 * Returns add element button config.
		 * @private
		 * @return {Object}
		 */
		getAddElementButtonConfig: function() {
			var controlClassName = this.getAddDcmStageElementControlClassName();
			return {
				className: "BPMSoft.Button",
				markerValue: {
					bindTo: "Caption"
				},
				classes: {
					wrapperClass: [controlClassName],
					imageClass: [controlClassName]
				},
				style: BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
				iconAlign: BPMSoft.controls.ButtonEnums.iconAlign.LEFT,
				imageConfig: {
					bindTo: "AddDcmStageElementTypeButtonImageConfig"
				},
				menu: {
					ulClass: "add-dcm-stage-item-type-menu",
					items: {
						bindTo: "AvailableDcmStageElementTypesCollection"
					}
				}
			};
		},

		/**
		 * Returns new dcm stage element caption config.
		 * @private
		 * @return {Object}
		 */
		getNewDcmStageElementCaptionConfig: function() {
			var controlClassName = this.getAddDcmStageElementControlClassName();
			return {
				className: "BPMSoft.TextEdit",
				markerValue: {
					bindTo: "Caption"
				},
				classes: {
					editInputClass: [controlClassName]
				},
				enterkeypressed: {
					bindTo: "onAddDcmStageElementByEnterPressed"
				},
				focus: {
					bindTo: "onAddDcmStageElementFocused"
				},
				value: {
					bindTo: "NewDcmStageElementCaption"
				},
				placeholder: {
					bindTo: "NewDcmStageElementPlaceholder"
				}
			};
		},

		// endregion

		// region Methods: Public

		/**
		 * Builds dcm stage view config.
		 * @return {Object}
		 */
		build: function() {
			var id = this.viewModel.get("Id");
			var stageClassName = this.viewModel.get("StageClassName");
			return {
				className: "BPMSoft.DcmStage",
				groupName: "dcm-stages",
				tag: id,
				id: id,
				markerValue: {bindTo: "DataItemMarker"},
				headerColorWarpClassName: stageClassName,
				addButtonClick: {bindTo: "onAddDcmStageButtonClick"},
				addButtonStyle: {bindTo: "AddButtonStyle"},
				headerColor: {bindTo: "StageColor"},
				classes: {
					wrapClassName: ["dcm-stage-wrap"],
					innerContainerClassName: ["load-dcm-properties-page-on-click"]
				},
				selected: {bindTo: "Selected"},
				isValidateExecuted: {bindTo: "IsValidateExecuted"},
				isValid: {bindTo: "IsValid"},
				visible: {bindTo: "Visible"},
				beforeStartDrag: {bindTo: "onBeforeStartDrag"},
				alternativeStagesUIds: {bindTo: "AlternativeStagesUIds"},
				itemsEventMap: {
					"elementSelected": "elementSelected",
					"elementDblClick": "elementDblClick",
					"elementRemoveBtnClick": "elementRemoveBtnClick",
					"onDragDrop": "elementDragDrop"
				},
				tools: [
					this.getStageCaptionConfig(),
					this.getStageRemoveButtonConfig()
				],
				items: [
					this.getStageItemsContainerConfig(),
					this.getAddElementContainerConfig()
				]
			};
		}

		// endregion

	});

	return BPMSoft.DcmStageViewConfigBuilder;
});
