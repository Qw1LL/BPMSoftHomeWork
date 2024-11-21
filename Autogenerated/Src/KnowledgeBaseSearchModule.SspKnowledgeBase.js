define("KnowledgeBaseSearchModule", ["KnowledgeBaseSearchModuleResources"], function(resources) {
	function createConstructor(context) {
		var Ext = context.Ext;
		var sandbox = context.sandbox;
		var BPMSoft = context.BPMSoft;

		/**
		 * ####### ViewConfig ###### ###### ## #### ######.
		 * @protected
		 * @returns {Object} ###### #############.
		 */
		function createViewConfig() {
			return {
				className: "BPMSoft.Container",
				id: "knowledgeBaseSearchContainer",
				selectors: {
					el: "#knowledgeBaseSearchContainer",
					wrapEl: "#knowledgeBaseSearchContainer"
				},
				items: [
					{
						className: "BPMSoft.CommandLine",
						bigSize: false,
						placeholder: resources.localizableStrings.PlaceHolderMessage,
						classes: ["placeholderOpacity"],
						commandLineExecute: {bindTo: "executeCommand"},
						markerValue: "knowledgeBase-search-line",
						minSearchCharsCount: 3,
						searchDelay: 350,
						width: "100%"
					}
				]
			};
		}

		/**
		 * ####### ViewModel ###### ###### ## #### ######.
		 * @protected
		 * @returns {BPMSoft.BaseViewModel} ###### #############.
		 */
		function createViewModel() {
			var viewModel = Ext.create("BPMSoft.BaseViewModel", {
				values: {
					selectedValue: null,
					commandInsertValue: null,
					commandSelectionText: ""
				}
			});
			return viewModel;
		}

		/**
		 * ########## ###### ### ######## # ###### # ######## ##### ####### ## ##### #######.
		 * @protected
		 * @param {String} schemaName ### ##### ####### ### ########.
		 * @returns {Object} url - ###### ## #### ######, sectionSchema - ######## ##### #######.
		 */
		function tryGetModuleInfo(schemaName) {
			var moduleStructure = BPMSoft.configuration.ModuleStructure;
			var module = moduleStructure[schemaName];
			var url = module.sectionModule + "/";
			if (module.sectionSchema) {
				url += module.sectionSchema + "/";
			}
			return {
				url : url,
				sectionSchema : module.sectionSchema
			};
		}

		/**
		 * ######### ######### ###### # #########.
		 * @protected
		 * @param {Object} renderTo ######### # ####### ##### ######### ######.
		 */
		function render(renderTo) {
			var container = this.renderTo = renderTo;
			if (!container.dom) {
				return;
			}
			var viewConfig = createViewConfig();
			var view = Ext.create(viewConfig.className || "BPMSoft.Container", viewConfig);
			var viewModel = createViewModel();
			viewModel.executeCommand = function(input) {
				if (!input) {
					return;
				}
				var searchSchemaName = "KnowledgeBase";
				var value = "%" + input.trim() + "%";
				var moduleInfo = tryGetModuleInfo(searchSchemaName);
				var url = moduleInfo.url;
				var filterModule = moduleInfo.sectionSchema;
				var storage = BPMSoft.configuration.Storage.Filters =
					BPMSoft.configuration.Storage.Filters || {};
				var sessionFilters = storage[filterModule] =
					storage[filterModule] || {};
				sessionFilters.CustomFilters = {
					value: value,
					displayValue: value,
					primaryDisplayColumn: true
				};
				sandbox.publish("PushHistoryState", {
					hash: url
				});
			};
			view.render(container);
			view.bind(viewModel);
		}
		var instance = Ext.define("KnowledgeBaseSearchModule", {
			render: render
		});
		return instance;
	}
	return createConstructor;
});
