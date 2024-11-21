define("ColumnSettingsUtilities",["ModalBox", "MaskHelper"], function(modalBox) {
	var columnSettingsId;
	var isPopup;
	function openColumnSettings(sandbox, config, callback, renderTo, scope) {
		columnSettingsId = sandbox.id + "_ColumnSettings";
		const loadModuleConfig = config && config.loadModuleConfig;
		isPopup = config.isPopup;
		var isNestedColumnSettingModule;
		if(isPopup) {
			isNestedColumnSettingModule = true;
			this.sandbox = sandbox;
			var modalBoxSize = getModalBoxSize(config);
			renderTo = modalBox.show(modalBoxSize, 
				function(destroy) {
					if (destroy) {
						sandbox.unloadModule(columnSettingsId);
					}
				}, this);
		} else {
			isNestedColumnSettingModule = loadModuleConfig && loadModuleConfig.isNestedColumnSettingModule;
		}
		renderTo = loadModuleConfig && loadModuleConfig.columnSettingsContainerName || renderTo;
		const handler = function(args) {
			if (isNestedColumnSettingModule) {
				sandbox.unloadModule(columnSettingsId);
				const state = sandbox.publish("GetHistoryState");
				const hash = state && state.hash;
				sandbox.publish("ReplaceHistoryState", {
					stateObj: {
						moduleId: sandbox.id
					},
					hash: hash && hash.historyState,
					silent: true
				});
			}
			callback.call(scope, args);
		};
		sandbox.subscribe("ColumnSettingsInfo", function() {
			return config;
		}, [columnSettingsId]);
		if (!isNestedColumnSettingModule) {
			const params = sandbox.publish("GetHistoryState");
			sandbox.publish("PushHistoryState", {hash: params.hash.historyState});
		}
		sandbox.loadModule("ColumnSettings", {
			renderTo: renderTo,
			id: columnSettingsId,
			keepAlive: !Boolean(isNestedColumnSettingModule),
			instanceConfig: {
				isNestedColumnSettingModule: isNestedColumnSettingModule,
				hidePageCaption: loadModuleConfig && loadModuleConfig.hidePageCaption
			}
		}); 
		sandbox.subscribe("ColumnSetuped", handler, [columnSettingsId]);
	}

	var mbBaseSize = {
		widthPixels: 568,
		heightPixels: 420
	};

	function getModalBoxSize(config) {
		if (config.widthPixels && config.heightPixels) {
			return {
				widthPixels: config.widthPixels,
				heightPixels: config.heightPixels
			};
		} 
		if (config.minWidth && config.minHeight && config.maxHeight && config.maxWidth) {
			return {
				minWidth: config.minWidth,
				minHeight: config.minHeight,
				maxHeight: config.maxHeight,
				maxWidth: config.maxWidth
			};
		}
		return {
				widthPixels: mbBaseSize.widthPixels,
				heightPixels: mbBaseSize.heightPixels
			};
	}

	function closeColumnSettings() {
		if (modalBox.getInnerBox()) {
			modalBox.close();
		}
		if (this.sandbox) {
			this.sandbox.unloadModule(columnSettingsId);
		}
		columnSettingsId = null;
	}
	function isPopupWindow() {
		return isPopup;
	}
	
	return {
		Close: closeColumnSettings,
		isPopupWin: isPopupWindow,
		Open: openColumnSettings
	};
});
