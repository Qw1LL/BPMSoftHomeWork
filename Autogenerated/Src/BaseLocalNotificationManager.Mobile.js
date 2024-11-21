/**
 * @class BPMSoft.BaseLocalNotificationManager
 * ####### ##### ######### ## ###### # ########## #############.
 */
Ext.define("BPMSoft.Configuration.BaseLocalNotificationManager", {
	alternateClassName: "BPMSoft.BaseLocalNotificationManager",

	/**
	 * @private
	 */
	initFlag: false,

	/**
	 * @private
	 */
	getToProcessNotifications: function() {
		return BPMSoft.SysSettingsValue.getBooleanValue("ShowMobileLocalNotifications") &&
			(BPMSoft.core.Platform !== BPMSoft.ExecutionPlatforms.WebKit) &&
			!BPMSoft.util.isWindowsPlatform();
	},

	/**
	 * @private
	 */
	initializeLocalNotificationEvents: function(callback) {
		var me = this;
		BPMSoft.LocalNotification.onClick(function(notification) {
			Ext.callback(me.onNotificationClick, me, [notification]);
		});
		BPMSoft.LocalNotification.onClear(function(notification) {
			Ext.callback(me.onNotificationClear, me, [notification]);
		});
		if (BPMSoft.ApplicationUtils.isOnlineMode()) {
			var onResumeBinded = Ext.bind(this.onResume, this);
			BPMSoft.DocumentEventManager.subscribe("resume", onResumeBinded, false);
		}
		Ext.callback(callback, this);
	},

	/**
	 * @private
	 */
	setLocalNotificationPermission: function(callback) {
		BPMSoft.LocalNotification.promptForPermission({
			callback: function(granted) {
				if (granted) {
					this.initializeLocalNotificationEvents(callback);
				}
			},
			scope: this
		});
	},

	/**
	 * ############# #########.
	 * @protected
	 * @virtual
	 */
	initialize: function(callback) {
		if (this.initFlag) {
			Ext.callback(callback, this);
			return;
		}
		this.initFlag = true;
		BPMSoft.LocalNotification.hasPermission({
			callback: function(hasPermission) {
				if (!hasPermission) {
					this.setLocalNotificationPermission(callback);
				} else {
					this.initializeLocalNotificationEvents(callback);
				}
			},
			scope: this
		});
	},

	/**
	 * ########## ########### ##########, ##### ## ####### ######.
	 * @protected
	 * @virtual
	 */
	onResume: function() {
		var toProcessNotifications = this.getToProcessNotifications();
		if (!toProcessNotifications) {
			return;
		}
		BPMSoft.AsyncManager.callInOrder([
			this.getNotifications,
			this.createNotifications
		], this);
	},

	/**
	 * ######### ###### ########### #######.
	 * @protected
	 * @virtual
	 */
	loadModels: function(callback) {
		BPMSoft.StructureLoader.loadModels({
			modelNames: ["VwRemindings", "Activity"],
			success: function() {
				Ext.callback(callback, this);
			},
			scope: this
		});
	},

	/**
	 * ######## ###### ####### ###########.
	 * @protected
	 * @virtual
	 */
	getNotifications: function(callback) {
	},

	/**
	 * ####### ########### ## ###### ###### ####### ###########.
	 * @protected
	 * @virtual
	 */
	createNotifications: function(callback) {
	},

	/**
	 * ########## ####### ## ###########.
	 * @protected
	 * @virtual
	 */
	onNotificationClick: function(notification) {
	},

	/**
	 * ########## ###### ###########.
	 * @protected
	 * @virtual
	 */
	onNotificationClear: function(notification) {
	},

	/**
	 * ######### ###########.
	 */
	processNotifications: function() {
		var toProcessNotifications = this.getToProcessNotifications();
		if (!toProcessNotifications) {
			return;
		}
		BPMSoft.AsyncManager.callInOrder([
			this.loadModels,
			this.initialize,
			this.getNotifications,
			this.createNotifications
		], this);
	}

});
