Ext.define("BPMSoft.configuration.VisaActionsUtilities", {
	singleton: true,

	updateVisaStatusInCache: function(sourceRecord, parentModelName, statusId) {
		return new Promise(function(resolve) {
			var modelName = sourceRecord.self.modelName;
			if (!BPMSoft.ApplicationUtils.isOnlineMode() ||
					BPMSoft.ModelCache.isEnabledForModel(modelName, parentModelName)) {
				var queryConfig = Ext.create("BPMSoft.QueryConfig", {
					isLogged: false,
					updateSysColumns: false,
					modelName: modelName,
					columns: ["Status"],
					autoSetProxy: false
				});
				var record = sourceRecord.clone();
				record.setProxyType(BPMSoft.ProxyType.Offline);
				record.set("Status", statusId);
				record.save({
					isCancelable: false,
					queryConfig: queryConfig,
					success: function() {
						resolve();
					},
					failure: function() {
						resolve();
					}
				}, this);
			} else {
				resolve();
			}
		});
	}

});

/**
 * @class BPMSoft.VisaApproveAction
 * Performs approval of visa.
 */
Ext.define("BPMSoft.configuration.VisaApproveAction", {
	extend: "BPMSoft.ActionBase",

	execute: function() {
		this.callParent(arguments);
		var record = this.getRecord();
		var actionConfig = this.getActionConfig() || {};
		var modelName = record.self.modelName;
		BPMSoft.NativeServices.ApprovalService.approve(
				modelName, record.getPrimaryColumnValue()).then(function(result) {
			if (result) {
				BPMSoft.configuration.VisaActionsUtilities.updateVisaStatusInCache(
						record, actionConfig.parentModelName, BPMSoft.VisaStatusId.Positive).then(function() {
					this.executionEnd(true);
				}.bind(this));
			} else {
				this.executionEnd(true);
			}
		}.bind(this)).catch(function(exception) {
			BPMSoft.MessageBox.showException(exception);
			this.executionEnd(false);
		}.bind(this));
	}

});

/**
 * @class BPMSoft.VisaRejectAction
 * Performs rejection of visa.
 */
Ext.define("BPMSoft.configuration.VisaRejectAction", {
	extend: "BPMSoft.ActionBase",

	execute: function() {
		this.callParent(arguments);
		var record = this.getRecord();
		var actionConfig = this.getActionConfig() || {};
		BPMSoft.NativeServices.ApprovalService.reject(
				record.self.modelName, record.getPrimaryColumnValue(), actionConfig.comment).then(function(result) {
			if (result) {
				BPMSoft.configuration.VisaActionsUtilities.updateVisaStatusInCache(
						record, actionConfig.parentModelName, BPMSoft.VisaStatusId.Negative).then(function() {
					this.executionEnd(true);
				}.bind(this));
			} else {
				this.executionEnd(true);
			}
		}.bind(this)).catch(function(exception) {
			BPMSoft.MessageBox.showException(exception);
			this.executionEnd(false);
		}.bind(this));
	}

});
