define('ViewModuleHelper', ['ext-base', 'BPMSoft', 'ViewModuleHelperResources'],
	function(Ext, BPMSoft, resources) {

	function getSideBarDefaultConfig(callback) {
		var menuConfig = {
			items: [{
				name: 'LeftPanelTopMenuModule',
				id: 'leftPanelTopMenu',
				showInHeader: true
			}, {
				name: 'LeftPanelClientWorkplaceMenu',
				id: 'leftPanelClientWorkplaceMenu',
				showInHeader: true
			}, {
				name: 'SectionMenuModule',
				id: 'sectionMenuModule'
			}]
		};
		callback(menuConfig);
	}

	return {
		getSideBarDefaultConfig: getSideBarDefaultConfig
	};
});
