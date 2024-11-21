// D9 Team
define("QuickSearchModule", ["QuickSearchModuleResources", "BaseModule"],
	function(resources) {
		/**
		 * @class BPMSoft.configuration.QuickSearchModule
		 * ##### QuickSearchModule ############ ### ####### ########## # #### ####### #########
		 */
		Ext.define("BPMSoft.configuration.QuickSearchModule", {
			alternateClassName: "BPMSoft.QuickSearchModule",
			extend: "BPMSoft.BaseModule",

			Ext: null,
			sandbox: null,
			BPMSoft: null,

			/**
			 * ######### ### ###### ######## ######
			 * @private
			 * @type {Object}
			 */
			config: null,

			/**
			 * ######## ######### ### #########
			 * @private
			 * @type {Object}
			 */
			container: null,

			/**
			 * ######## ###### ######### ######
			 * @protected
			 * @type {Object}
			 */
			messages: {

				/**
				 * @message UpdateQuickSearchFilter
				 * ######## # ######### #######
				 * @param {Object} ########## # ##### #######
				 */
				"UpdateQuickSearchFilter": {
					mode: BPMSoft.MessageMode.BROADCAST,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				},

				/**
				 * @message UpdateQuickSearchFilterString
				 * ########## ###### ###### ## ###
				 * @param {String} ##### ###### ######
				 * @param {Bool} ######### ##### ###### ######
				 */
				"UpdateQuickSearchFilterString": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				},
				/**
				 * @message QuickSearchFilterInfo
				 * ######### ############ ######
				 * @return {Object} ############ ### ############# ######
				 */
				"QuickSearchFilterInfo": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				}
			},

			/**
			 * ###### ############# ######### #####.
			 * @private
			 * @type {Object}
			 */
			viewModel: null,

			/**
			 * ########### ######### ######.
			 * @private
			 */
			registerMessages: function() {
				if (this.messages) {
					this.sandbox.registerMessages(this.messages);
				}
			},

			/**
			 * ########## ############ ############# ######
			 * @returns {Object} ########## ############ ### ############# #############.
			 */
			getView: function()
			{
				return {
					className: "BPMSoft.Container",
					id: "quickSearchModule-container",
					selectors: {wrapEl: "#quickSearchModule-container"},
					classes: {
						wrapClassName: ["quickSearchModule-container"]
					},
					items: [
						{
							className: "BPMSoft.Container",
							id: "quickSearchModuleSearchTextEdit-container",
							selectors: {wrapEl: "#quickSearchModuleSearchTextEdit-container"},
							classes: {
								wrapClassName: ["quickSearchModuleSearchTextEdit-container"]
							},
							items: [
								{
									className: "BPMSoft.TextEdit",
									id: "QuickSearchTextEdit",
									selectors: {wrapEl: "#QuickSearchTextEdit"},
									value: {bindTo: "SearchString"},
									placeholder: {bindTo: "SearchStringPlaceHolder"},
									enterkeypressed: {bindTo: "onApplyQuickSearchFilterButtonClick"},
									hasClearIcon: false,
									hint: resources.localizableStrings.SearchLineHint,
									markerValue: "QuickSearchTextEdit"
								}
							]
						},
						{
							className: "BPMSoft.Container",
							id: "quickSearchModuleButtons-container",
							selectors: {wrapEl: "#quickSearchModuleButtons-container"},
							classes: {
								wrapClassName: ["quickSearchModuleButtons-container"]
							},
							items: [
								{
									className: "BPMSoft.Container",
									id: "quickSearchModuleApplyFilterButton-container",
									selectors: {wrapEl: "#quickSearchModuleApplyFilterButton-container"},
									classes: {
										wrapClassName: ["quickSearchModuleApplyFilterButton-container"]
									},
									items: [
										{
											className: "BPMSoft.Button",
											imageConfig: resources.localizableImages.ApplyButtonImage,
											id: "ApplyQuickSearchFilterButton",
											selectors: {wrapEl: "#ApplyQuickSearchFilterButton"},
											tag: "ApplyQuickSearchFilterButton",
											hint: resources.localizableStrings.ApplyFilterButtonHint,
											style: BPMSoft.controls.ButtonEnums.style.ORANGE,
											visible: true,
											markerValue: "ApplyQuickFilterButton",
											click: {bindTo: "onApplyQuickSearchFilterButtonClick"}
										}
									]
								},
								{
									className: "BPMSoft.Container",
									id: "quickSearchModuleClearFilterButton-container",
									selectors: {wrapEl: "#quickSearchModuleClearFilterButton-container"},
									classes: {
										wrapClassName: ["quickSearchModuleClearFilterButton-container"]
									},
									items: [
										{
											className: "BPMSoft.Button",
											imageConfig: resources.localizableImages.CancelButtonImage,
											id: "ClearQuickSearchFilterButton",
											selectors: {wrapEl: "#ClearQuickSearchFilterButton"},
											tag: "ClearQuickSearchFilterButton",
											hint: resources.localizableStrings.ResetFilterButtonHint,
											style: BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
											visible: true,
											markerValue: "CancelQuickFilterButton",
											click: {bindTo: "onClearQuickSearchFilterButtonClick"}
										}
									]
								}
							]
						}
					]
				};
			},

			/**
			 * ########## ############ ###### ############# ######.
			 * @returns {Object} ########## ############ ### ############# ###### #############.
			 */
			getViewModel: function(sandbox, BPMSoft, Ext, config)
			{
				return {
					values: {

						/**
						 * ######## ###### ######
						 * @type {String}
						 */
						SearchString: "",

						/**
						 * ######, ####### ############ ### ###### ###### ######
						 * @type {String}
						 */
						SearchStringPlaceHolder: "",

						/**
						 * #######, ## ###### ####### ########### ######
						 * @type {Array}
						 */
						FilterColumns: null,

						/**
						 * ######### #############
						 * @private
						 * @type {Array}
						 */
						config: config || null
					},
					methods: {

						/**
						 * ############# ###### #############.
						 * @param {Object} config ######### ############ ###### #############.
						 */
						init: function(config) {
							var filterColumns = config.FilterColumns || [
								{
									Column: "Name",
									ComparisonType: BPMSoft.ComparisonType.START_WITH
								}
							];
							this.set("FilterColumns", filterColumns);
							this.set("SearchStringPlaceHolder", config.SearchStringPlaceHolder ||
								resources.localizableStrings.SearchStringPlaceHolder);
							this.set("SearchString", config.InitSearchString || "");
							if (!Ext.isEmpty(config.InitSearchString)) {
								this.createAndPublishFilterGroup();
							}

							this.subscribeForUpdateQuickSearchFilterString();
						},

						/**
						 * ############## ######## ## ####### UpdateQuickSearchFilterString
						 */
						subscribeForUpdateQuickSearchFilterString: function() {
							sandbox.subscribe("UpdateQuickSearchFilterString", function(args) {
								args = args || {};
								this.set("SearchString", args.newSearchStringValue || "");
								if (args.autoApply) {
									this.createAndPublishFilterGroup();
								}
							}, this);
						},

						/**
						 * ########## ####### ## ###### ####### ###### ##########
						 * @protected
						 */
						onClearQuickSearchFilterButtonClick: function() {
							this.clearAndApplyFilter();
						},

						/**
						 * ########## ####### ## ###### ########## ##########
						 * @protected
						 */
						onApplyQuickSearchFilterButtonClick: function() {
							this.createAndPublishFilterGroup();
						},

						/**
						 * ####### ###### ## ###### ######### ######## # ###### ######
						 * @returns {BPMSoft.data.filters.FilterGroup}
						 * @protected
						 * @virtual
						 */
						createFilterGroup: function() {
							var searchString = this.get("SearchString");
							var filterColumns = this.get("FilterColumns");
							var filterGroup = BPMSoft.createFilterGroup();
							if (Ext.isEmpty(searchString) ||
								!filterColumns ||
								filterColumns.length === 0) {
								return filterGroup;
							}
							BPMSoft.each(filterColumns, function(column) {
								filterGroup.addItem(
									BPMSoft.createColumnFilterWithParameter(
										column.ComparisonType, column.Column, searchString)
								);
							}, this);
							filterGroup.logicalOperation = BPMSoft.LogicalOperatorType.OR;
							return filterGroup;
						},

						/**
						 * ######## # ######### ####### UpdateQuickSearchFilter # ##### ########
						 * @protected
						 * @virtual
						 */
						createAndPublishFilterGroup: function() {
							var filterGroup = this.createFilterGroup();
							var filterItem = {
								key: "QuickSearchFilterItem",
								filters: filterGroup,
								filtersValue: this.get("SearchString")
							};
							sandbox.publish("UpdateQuickSearchFilter", filterItem);
						},

						/**
						 * ####### ###### ###### # ########## ####### #######
						 * @protected
						 */
						clearAndApplyFilter: function() {
							this.set("SearchString", "");
							this.createAndPublishFilterGroup();
						}
					}
				};
			},

			/**
			 * ############# ######. ############ ######### # ######## ######### ############.
			 * @param {Function} callback ####### ######### ######.
			 * @param {Object} scope ######## ########## callback.
			 * @protected
			 * @virtual
			 */
			init: function() {
				this.registerMessages();
				this.config = this.sandbox.publish("QuickSearchFilterInfo") || {};
			},

			/**
			 * ######### ######### ############# # ####### #########.
			 * @param {String} renderTo ####### ######### ### #########.
			 */
			render: function(renderTo) {
				this.container = renderTo;
				this.initializeModule();
			},

			/**
			 * ######### ############# ######### ###### - ############# # ###### #############
			 * @protected
			 * @virtual
			 */
			initializeModule: function() {
				var viewConfig = this.getView();
				var view = Ext.create(viewConfig.className || "BPMSoft.Container", viewConfig);
				if (!this.viewModel) {
					var viewModelConfig = this.getViewModel(this.sandbox, this.BPMSoft, this.Ext, this.config);
					this.viewModel = this.Ext.create("BPMSoft.BaseViewModel", viewModelConfig);
					this.viewModel.init(this.config);
				}
				view.bind(this.viewModel);
				view.render(this.container);
			}
		});

		return BPMSoft.QuickSearchModule;
	});
