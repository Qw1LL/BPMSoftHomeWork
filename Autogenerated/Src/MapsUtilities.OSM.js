define("MapsUtilities", ["MapsUtilitiesResources", "MapsHelper", "ServiceHelper", "BaseMapsModule"], 
	function(resources, MapsHelper, ServiceHelper) {
	Ext.define("BPMSoft.configuration.MapsUtilities", {
		extend: "BPMSoft.BaseObject",
		alternateClassName: "BPMSoft.MapsUtilities",

		singleton: true,

		/**
		 * Opens OSM maps module.
		 * @param {Object} config Configuration object.
		 * @param {Object} config.scope Execution context.
		 * @param {Object} config.sandbox Sandbox instance.
		 * @param {Object} config.renderTo Id or element where to render maps.
		 * @param {Boolean} config.keepAlive Keep alive chain module.
		 * @param {Array} config.mapsConfig Config for showing objects on the map.
		 * @param {Object} config.mapsProviderConfig Connection config for maps provider.
		 * @param {String} config.mapsModuleSandboxId Maps module sandbox id.
		 * @param {Function} config.afterRender After render function callback.
		 */
		open: function(config) {
			var scope = config.scope;
			var sandbox = config.sandbox || scope.sandbox;
			var renderTo = config.renderTo;
			var mapsConfig = config.mapsConfig;
			var afterRenderFunction = config.afterRender;
			var mapsModuleSandboxId = config.mapsModuleSandboxId || (sandbox.id + "_MapsModule");
			var keepAlive = config.keepAlive;
			if (Ext.isEmpty(renderTo)) {
				mapsModuleSandboxId += BPMSoft.generateGUID();
				keepAlive = true;
				mapsConfig.isModalBox = true;
			} else {
				mapsConfig.renderTo = renderTo;
			}
			MapsHelper.showMask();
			if (Ext.isFunction(afterRenderFunction)) {
				sandbox.subscribe("AfterRenderMap", function() {
					afterRenderFunction.call(scope);
				}, [mapsModuleSandboxId]);
			}
			sandbox.subscribe("GetMapsConfig", function() {
				return mapsConfig;
			}, [mapsModuleSandboxId]);
			
			let mapsProviderConfig = config.mapsProviderConfig;

			/* По умолчанию грузится OsmMapsModule, если конфиг не определён. Необходимо для того,
			 * чтобы была возможность открыть модуль и пробросить в него неверные параметры,
			 * которые затем там же и провалидируются и на странице пользователя корректно 
			 * отобразятся ошибки согласно ЧТЗ. Не представляется возможным грузить BaseMapsModuel
			 * так как там присутствуют абстрактные функции, требующие реализации.
			 */
			let mapsModuleName = mapsProviderConfig?.mapsProviderId
				? this.getMapsModuleNameByMapsProviderId(mapsProviderConfig.mapsProviderId)
				: "OsmMapsModule";

			sandbox.loadModule(mapsModuleName, {
				id: mapsModuleSandboxId,
				keepAlive: keepAlive,
				instanceConfig: {
					mapsProviderConfig: mapsProviderConfig
				}
			});
		},

		/**
		 * @param {String} mapsProviderId Maps provider Id.
		 * @returns {String} Maps module name.
		 */
		getMapsModuleNameByMapsProviderId: function(mapsProviderId) {
			switch (mapsProviderId) {
				case undefined || null || BPMSoft.emptyString:
					let mapsProviderIsNotDefined = 
						resources.localizableStrings.MapsProviderIsNotDefined;

					throw new Error(mapsProviderIsNotDefined);
				case resources.localizableStrings.RuMapsModuleId:
					return "RuMapsModule";
				case resources.localizableStrings.OsmMapsModuleId:
					return "OsmMapsModule";
				default:
					let choosenMapsModuleIsNotImplemented = 
						resources.localizableStrings.ChoosenMapsModuleIsNotImplemented;

					throw new Error(choosenMapsModuleIsNotImplemented);
			}
		},

    	/**
    	 * Call MapsService for getting maps api key.
    	 */
    	getMapsProviderApiKeyAsync: async function() {
    	    let response = await ServiceHelper.callServiceAsync(
    	        "MapsService", "GetMapsApiKey", null, this, null);

			return response.GetMapsApiKeyResult;
    	},

		/**
     	 * Get maps provider config by Id from SysCartographicServicesLibrary in DB,
     	 * @returns {Object} Maps provider config,
     	 */
		getMapsProviderConfigAsync: async function() {
			let mapsProviderId = 
				BPMSoft.SysSettings.cachedSettings.DefaultCartographicServicesLibrary?.value;

			if (!mapsProviderId) {
				return null;
			}

			const useApiKeyColumnName = "ApiKey";
			const urlForGettingAddressesColumnName = "UrlGetAddress";
			const urlForGettingTilesColumnName = "UrlGetTiles";
	
			var esq = Ext.create("BPMSoft.EntitySchemaQuery", {
				rootSchemaName: "SysCartographicServicesLibrary"
			});
	
			esq.addColumn(useApiKeyColumnName, useApiKeyColumnName);        
			esq.addColumn(urlForGettingAddressesColumnName, urlForGettingAddressesColumnName);        
			esq.addColumn(urlForGettingTilesColumnName, urlForGettingTilesColumnName);
	
			let response = await esq.getEntityAsync(mapsProviderId, this);
			let sysCartographicService = response.entity;
			let useApiKey = sysCartographicService.get(useApiKeyColumnName);
	
			let mapsProviderConfig = {
				mapsProviderId: mapsProviderId,
				useApiKey: useApiKey,
				apiKey: useApiKey ? await this.getMapsProviderApiKeyAsync() : null,
				urlForGettingAddresses: sysCartographicService.get(urlForGettingAddressesColumnName),
				urlForGettingTiles: sysCartographicService.get(urlForGettingTilesColumnName)
			};

			let isMapsProviderConfigValid = this.validateMapsProviderConfig(mapsProviderConfig);
			mapsProviderConfig.isValid = isMapsProviderConfigValid;

			return mapsProviderConfig;
		},

		validateMapsProviderConfig: function(mapsProviderConfig) {
			if (
				(
					mapsProviderConfig 
					&& mapsProviderConfig.mapsProviderId
					&& mapsProviderConfig.urlForGettingTiles 
					&& mapsProviderConfig.urlForGettingAddresses
					&& mapsProviderConfig.useApiKey !== undefined
				)
				&&
				(
					(
						mapsProviderConfig.useApiKey === true
						&& mapsProviderConfig.apiKey
					)
					||
					(
						mapsProviderConfig.useApiKey === false
					)
				)
			) {
				return true;
			}

			return false;
		},
	});
	return BPMSoft.MapsUtilities;
});
