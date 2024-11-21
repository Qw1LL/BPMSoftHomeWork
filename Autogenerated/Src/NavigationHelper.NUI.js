define("NavigationHelper", ["NavigationHelperResources"], function(resources) {
	Ext.define("BPMSoft.NUI.NavigationHelper", {
		alternateClassName: "BPMSoft.NavigationHelper",
		extend: "BPMSoft.core.BaseObject",
		Ext: null,
		_sandbox: null,

		_waitOpenWindowTimeout: 1000,

		/**
		 * @private
		 */
		_createStateObject: function(options, hash) {
			const newState = {
				hash: hash
			};
			if (Boolean(options.silent)) {
				newState.silent = true;
			}
			return newState;
		},

		/**
		 * @private
		 */
		_navigateToSection: function(options) {
			const moduleConfig = this._getModuleConfig(options.sectionSchema);
			const sectionUrl = this._getSectionUrl(moduleConfig);
			this._getSectionFilters(moduleConfig.entitySchemaName, options, function(filters) {
				const newState = this._createStateObject(options, sectionUrl);
				if (!BPMSoft.isEmptyObject(filters)) {
					newState.stateObj = {
						filterStates: filters
					};
				}
				this._navigate({
					newTab: options.newTab,
					url: sectionUrl,
					state: newState,
					replaceState: options.replaceState
				});
			});
		},

		/**
		 * @private
		 */
		_navigateToPage: function(options) {
			const moduleConfig = this._getModuleConfig(options.sectionSchema);
			const pageUrl = this._getPageUrl(options, moduleConfig);
			const newState = this._createStateObject(options, pageUrl);
			this._navigate({
				newTab: options.newTab,
				url: pageUrl,
				state: newState,
				replaceState: options.replaceState
			});
		},

		/**
		 * @private
		 */
		_navigate: function(options) {
			if (Boolean(options.newTab)) {
				const url = this.Ext.String.format("ViewModule.aspx#{0}", options.url);
				const popup = window.open(url);
				setTimeout(function() {
					if (!popup || popup.outerHeight === 0) {
						this.BPMSoft.showInformation(resources.localizableStrings.PopupBlockedMessage);
					}
				}, this._waitOpenWindowTimeout);
			} else {
				const messageName = Boolean(options.replaceState) ? "ReplaceHistoryState" : "PushHistoryState";
				this._sandbox.publish(messageName, options.state);
			}
		},

		/**
		 * @private
		 */
		_getSectionFilters: function(entitySchemaName, options, callback) {
			const filter = { };
			if (options.hideFilterBlock) {
				filter.isExtendedFiltersContainerExpanded = false;
				filter.isExtendedFolderContainerExpanded = false;
				filter.isFoldersContainerExpanded = false;
			}
			if (options.filters) {
				filter.CustomFilters = options.filters;
				filter.ignoreFixedFilters = true;
				Ext.callback(callback, this, [filter]);
			} else if (options.folderId) {
				this._getFolderFilterByFolderId(entitySchemaName, options.folderId, function(folderFilter) {
					if (!Ext.isEmpty(folderFilter)) {
						filter.FolderFilters = [folderFilter];
					}
					Ext.callback(callback, this, [filter]);
				});
			} else {
				Ext.callback(callback, this, [filter]);
			}
		},

		/**
		 * @private
		 */
		_getFolderESQ: function(schemaName) {
			const esq = this.Ext.create("BPMSoft.EntitySchemaQuery", {
				rootSchemaName: schemaName
			});
			esq.addColumn("Id");
			esq.addColumn("Name");
			esq.addColumn("FolderType.Id", "FolderTypeId");
			esq.addColumn("FolderType.Name", "FolderTypeName");
			esq.addColumn("FolderType.Image.Id", "FolderImageId");
			return esq;
		},

		/**
		 * @private
		 */
		_getFolderFilterFromResult: function(entitySchemaName, entity) {
			return {
				displayValue: entity.get("Name"),
				folderType: {
					displayValue: entity.get("FolderTypeName"),
					primaryImageValue: entity.get("FolderImageId"),
					value: entity.get("FolderTypeId")
				},
				sectionEntityScheamName: entitySchemaName,
				value: entity.get("Id")
			};
		},

		/**
		 * @private
		 */
		_getFolderFilterByFolderId: function(entitySchemaName, folderId, callback) {
			const esq = this._getFolderESQ(entitySchemaName + "Folder");
			return esq.getEntity(folderId, function(result) {
				let folderFilter;
				if (result.success && result.entity) {
					folderFilter = this._getFolderFilterFromResult(entitySchemaName, result.entity);
				} else {
					const warningMessage = this.Ext.String.format("Folder with id '{0}' not found in {1}",
						folderId, entitySchemaName);
					this.warning(warningMessage);
				}
				Ext.callback(callback, this, [folderFilter]);
			}, this);
		},

		/**
		 * @private
		 */
		_getSectionUrl: function(moduleConfig) {
			let url = moduleConfig.sectionModule + "/";
			if (moduleConfig.sectionSchema) {
				url += moduleConfig.sectionSchema + "/";
			}
			return url;
		},

		/**
		 * @private
		 */
		_getPageUrl: function(options, moduleConfig) {
			if (moduleConfig.cardSchema) {
				const cardSchemaParams = this._getCardSchemaParams(options, moduleConfig);
				const cardSchemaName = cardSchemaParams.cardSchema || moduleConfig.cardSchema;
				return options.mode === "edit"
					? Ext.String.format("{0}/{1}/{2}/{3}", moduleConfig.cardModule, cardSchemaName, options.mode, options.recordId)
					: Ext.String.format("{0}/{1}/{2}", moduleConfig.cardModule, cardSchemaName, options.mode);
			}
		},

		/**
		 * @private
		 */
		_getCardSchemaParams: function(config, module) {
			const attribute = module.attribute;
			const cardType = config.cardType;
			if (cardType && attribute) {
				const pages = module.pages;
				for (let i = 0; i < pages.length; i++) {
					const page = pages[i];
					if (page.name === cardType || page.UId === cardType) {
						return page;
					}
				}
			}
			return module;
		},

		/**
		 * @private
		 */
		_getModuleConfig: function(sectionSchema) {
			let result = null;
			BPMSoft.each(BPMSoft.configuration.ModuleStructure, function(item) {
				if (item && item.sectionSchema && item.sectionSchema === sectionSchema) {
					result = item;
				}
			}, this);
			if (!result) {
				this.warning("Cant find a module by supplied section schema name: " + sectionSchema);
				return;
			}
			return result;
		},

		/**
		 * Initializes a new instance of the BPMSoft.NavigationHelper.
		 */
		constructor: function(config) {
			this.Ext = config.Ext;
			this._sandbox = config.sandbox;
		},

		/**
		 * Performs navigation.
		 * @param config {Object} Navigation config.
		 * @param {String} config.target Target to navigate to. Possible values: 'Section', 'Page.
		 * @param {Object} config.options Navigation options.
		 * @param {String} config.options.sectionSchema Name of the schema to navigate to.
		 * @param {String} config.options.mode Mode of the page to open. Possible values: 'edit', 'add'.
		 * @param {Boolean} config.options.newTab Determines whether to navigate to a new tab or not.
		 * @param {Boolean} config.options.replaceState Determines whether to replace state or to push a new one.
		 * @param {Boolean} config.options.silent Determines whether to navigate silently or not.
		 * @param {GUID} config.options.recordId Identifier of the record to edit.
		 * @param {GUID} config.options.folderId Static folder identifier to set folder filter on.
		 * @param {Boolean} config.options.hideFilterBlock Hides filter block.
		 */
		navigateTo: function(config) {
			if (config.target === 'Section') {
				this._navigateToSection(config.options);
			} else if (config.target === 'Page') {
				this._navigateToPage(config.options);
			} else {
				const warningMessage = this.Ext.String.format("Unsupported target: {0}", config.target);
				this.warning(warningMessage);
			}
		}
	});
})
