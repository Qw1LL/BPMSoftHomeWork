define('SectionDesignerLogModule', ['SectionDesignerLogModuleResources', 'ModalBox', "ViewUtilities"],
	function(resources, ModalBox, viewUtilities) {
    	var Ext;
		var sandbox;
		var BPMSoft;
		var viewConfig;
		var viewModel;

		function createConstructor(context) {
			Ext = context.Ext;
			sandbox = context.sandbox;
			BPMSoft = context.BPMSoft;

			return Ext.define('SectionDesignerLogModule', {
				init: init,
				render: render
			});
		}

		function init() { }

		/**
		 * ######### ######### ###### # #########
		 * @protected
		 * @param {Object} renderTo ######### # ####### ##### ######### ######
		 */
		function render(renderTo) {
			var moduleId = sandbox.id;
			var errorRows = sandbox.publish('GetErrorsConfig', moduleId, [moduleId]);
			var viewModel = getViewModel();
			var fixedViewConfig = getFixedAreaConfig();
			var fixedView = Ext.create("BPMSoft.Container", fixedViewConfig);
			fixedView.bind(viewModel);
			fixedView.render(ModalBox.getFixedBox());
			var gridViewConfig = getGridAreaConfig(errorRows);
			var gridView = Ext.create("BPMSoft.Container", gridViewConfig);
			gridView.render(renderTo);
		}

		function getViewModel() {
			return Ext.create("BPMSoft.BaseViewModel", {
				values: {
					header: resources.localizableStrings.HeaderCaption
				},
				methods: {
					cancelClick: function() {
						ModalBox.close();
					}
				}
			});
		}

		function getFixedAreaConfig(args) {
			var fixedAreaContainer = viewUtilities.getContainerConfig("fixed-area",	["modal-area", "modal-fixed-area"]);
			var headerContainer = getHeaderConfig(args);
			var buttonsContainer = viewUtilities.getContainerConfig("modal-buttons", ["modal-header-buttons"]);
			buttonsContainer.items = [{
				className: "BPMSoft.Button",
				caption: resources.localizableStrings.CloseCaption,
				click: { bindTo: "cancelClick" }
			}];
			fixedAreaContainer.items = [
				headerContainer,
				buttonsContainer
			];
			return fixedAreaContainer;
		}
		function getGridAreaConfig(gridRows) {
			var gridContainer = viewUtilities.getContainerConfig("grid-area", ["modal-area", "modal-grid-area"]);
			var gridConfig = getGridConfig(gridRows);
			gridContainer.items = [gridConfig];
			return gridContainer;
		}
		function getHeaderConfig(args) {
			var headerContainer  = viewUtilities.getContainerConfig("modal-header", ["modal-header"]);
			var headerNameContainer  = viewUtilities.getContainerConfig("modal-header-name", ["modal-header-inline"]);
			headerNameContainer.items = [{
				className: "BPMSoft.Label",
				caption: { bindTo: "header" }
			}];
			var closeIconContainer  = viewUtilities.getContainerConfig("modal-close-icon", ["modal-header-inline"]);
			closeIconContainer.items = [{
				className: "BPMSoft.Button",
				style: BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
				imageConfig: resources.localizableImages.CloseIcon,
				classes: { wrapperClass: ["modal-close-button"] },
				click: { bindTo: "cancelClick" }
			}];
			headerContainer.items = [headerNameContainer, closeIconContainer];
			return headerContainer;
		}

		function getGridConfig(gridRows) {
			return {
				className: 'BPMSoft.Grid',
				type: 'listed',
				rows: gridRows,
				columnsConfig: [
					{
						cols: 6,
						key: [{ name: 'fileName' }]
					},
					{
						cols: 3,
						key: [{ name: 'line' }]
					},
					{
						cols: 15,
						key: [{ name: 'errorText' }]
					}
				],
				captionsConfig: [
					{
						cols: 6,
						name: resources.localizableStrings.FileNameCaption
					},
					{
						cols: 3,
						name: resources.localizableStrings.LineCaption
					},
					{
						cols: 15,
						name: resources.localizableStrings.ErrorTextCaption
					}
				]
			};
		}

		return createConstructor;
	});
