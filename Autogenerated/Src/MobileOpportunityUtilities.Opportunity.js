/* Hides SysDashboard module - if mobile application in online mode */
if (!BPMSoft.Features.getIsEnabled("ShowMobileDashboards") && BPMSoft.ApplicationUtils.isOnlineMode()) {
	BPMSoft.ApplicationConfig.moduleGroups.get("sales").modules.splice(0, 1);
}
