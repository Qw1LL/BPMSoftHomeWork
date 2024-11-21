define("ActionButtonHelper", ["BPMSoft", "ActionButtonHelperResources", "ViewUtilities", "css!ActionButtonHelper"],
	function(BPMSoft, resources, ViewUtilities) {
	function getActionButtonConfig(action) {
		var color = action.color || "orange";
		var iconUrl = BPMSoft.ImageUrlBuilder.getUrl(resources.localizableImages[color + 'ButtonImage']);
		var containerConfig = ViewUtilities.getContainerConfig(action.name);
		var config = {
			className: 'BPMSoft.Button',
			caption: action.caption,
			style: BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
			iconAlign: BPMSoft.controls.ButtonEnums.iconAlign.LEFT,
			imageConfig: {
				source: BPMSoft.ImageSources.URL,
				url: iconUrl
			},
			classes: {
				imageClass: ['action-btn-image'],
				wrapperClass: ['action-btn-wrapper']
			}
		};
		if (action.click) {
			config.click = action.click;
		}
		if (action.visible) {
			config.visible = action.visible;
		}
		if (action.enabled) {
			config.enabled = action.enabled;
		}
		containerConfig.items = [Ext.merge(config, action.buttonConfig)];
		return containerConfig;
	}
	function getActionButtonsConfig(config) {
		var id = config.id || "actionsButtonsContainer";
		var result = ViewUtilities.getContainerConfig(id, ['action-container-wrapper']);
		var actions = config.actions;
		BPMSoft.each(actions, function(action) {
			var actionConfig = getActionButtonConfig(action);
			result.items.push(actionConfig);
		});
		return result;
	}
	return {
		getActionButtonsConfig: getActionButtonsConfig,
		getActionButtonConfigL: getActionButtonConfig
	};
});
