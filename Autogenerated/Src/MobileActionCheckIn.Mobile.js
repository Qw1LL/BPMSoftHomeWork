﻿Ext.define("BPMSoft.ActionCheckIn", {
	extend: "BPMSoft.ActionBase",

	execute: function(record, config) {
		this.callParent(arguments);
		var positionXColumn = config.positionXColumn;
		var positionYColumn = config.positionYColumn;
		var positionDateTimeColumn = config.positionDateTimeColumn;
		var positionParentColumn = config.positionParentColumn;
		var activityDateColumn = config.activityDateColumn;
		var me = this;
		var geo = Ext.create("Ext.util.Geolocation", {
			autoUpdate: false,
			maximumAge: 3000,
			timeout: 30000,
			listeners: {
				locationupdate: function(position) {
					var queryConfig = Ext.create("BPMSoft.QueryConfig");
					queryConfig.setColumns([positionXColumn, positionYColumn, positionDateTimeColumn,
						positionParentColumn]);
					var modelName = config.modelName;
					queryConfig.setModelName(modelName);
					var detailRecord = Ext.create(modelName);
					detailRecord.set(positionXColumn, position.getLatitude());
					detailRecord.set(positionYColumn, position.getLongitude());
					detailRecord.set(positionDateTimeColumn, position.getTimestamp());
					detailRecord.set(positionParentColumn, record);
					detailRecord.save({
						queryConfig: queryConfig
					});
					if (!Ext.isEmpty(activityDateColumn)) {
						var now = new Date();
						record.set(activityDateColumn, now);
						var recordQueryConfig = Ext.create("BPMSoft.QueryConfig");
						recordQueryConfig.setColumns([activityDateColumn]);
						recordQueryConfig.setModelName(record.self.modelName);
						record.save({
							queryConfig: recordQueryConfig
						});
					}
					me.fireEvent("executionend", me);
					BPMSoft.MessageBox.showMessage(BPMSoft.LS["Sys.Action.CheckIn.CompletedSuccessfully"]);
				},
				locationerror: function(geo, bTimeout, bPermissionDenied, bLocationUnavailable, message) {
					var errorMessage;
					if (bTimeout) {
						errorMessage = BPMSoft.LS["Sys.Exception.Geolocation.Timeout"];
					} else if (bPermissionDenied) {
						errorMessage = BPMSoft.LS["Sys.Exception.Geolocation.PermissionDenied"];
					} else if (bLocationUnavailable) {
						errorMessage = BPMSoft.LS["Sys.Exception.Geolocation.LocationCouldNotBeDetermined"];
					} else {
						errorMessage = message;
					}
					me.fireEvent("executionend", me);
					BPMSoft.MessageBox.showException(Ext.create("BPMSoft.Exception", {
						message: errorMessage
					}));
				}
			}
		});
		geo.updateLocation();
	}

});
