/* globals Contact: false */
Ext.define("BPMSoft.ActivityFilterModule", {
	extend: "BPMSoft.BaseFilterModule",
	xtype: "tsactivityfiltermodule",

	config: {
		component: {
			xtype: "label"
		}
	},

	_filterName: null,

	initialize: function() {
		this.callParent(arguments);
		this.setName("ActivityOnlyAuthorFilterModule");
		if (!this._filterName) {
			this._filterName = "MyActivities";
		}
	},

	getFilter: function() {
		if (this._filterName === "MyActivities") {
			return Ext.create("BPMSoft.Filter", {
				name: "ActivityOnlyAuthorFilter",
				property: "Participant",
				modelName: "ActivityParticipant",
				assocProperty: "Activity",
				operation: BPMSoft.FilterOperations.Any,
				valueIsMacros: true,
				value: BPMSoft.ValueMacros.CurrentUserContact
			});
		}
		return null;
	}

});

Ext.define("BPMSoft.configuration.util.Utils", {
	alternateClassName: "BPMSoft.CFUtils",
	singleton: true,

	/**
	 * @private
	 */
	findParentSchemaRecord: function(records) {
		var record;
		top:
		for (var i = 0, ln = records.length; i < ln; i++) {
			record = records[i];
			for (var j = 0, lnj = records.length; j < lnj; j++) {
				var recordj = records[j];
				if (record.get("Parent.Id") === recordj.get("Id")) {
					continue top;
				}
			}
			break;
		}
		return record;
	},

	/**
	 * Gets preview config for address embedded detail.
	 * @return {Object} Preview config.
	 */
	getAddressEmbeddedDetailPreviewConfig: function() {
		return {
			valueColumn: "Address",
			displayColumn: function(record) {
				var columns = ["Address", "City", "Region", "Zip", "Country"];
				var separator = ", ";
				var templateKey = "AddressEmbededDetail_inplaceEdit_displayValueTpl";
				var formatArguments = [BPMSoft.LocalizableStrings[templateKey]];
				for (var i = 0, ln = columns.length; i < ln; i++) {
					var column = columns[i];
					var columnValue = record.get(column);
					if (columnValue instanceof BPMSoft.model.BaseModel) {
						columnValue = columnValue.getPrimaryDisplayColumnValue();
					}
					if (!Ext.isEmpty(columnValue)) {
						columnValue += separator;
					} else {
						columnValue = "";
					}
					formatArguments.push(columnValue);
				}
				var value = Ext.String.format.apply(this, formatArguments);
				return value.replace(new RegExp(separator + "$"), "");
			},
			label: function(record) {
				var type = record.get("AddressType");
				var stringKey;
				if (type) {
					stringKey = "AddressEmbededDetail_inplaceEdit_titleWithType";
					var typeDisplayValue = type.getPrimaryDisplayColumnValue();
					return Ext.String.format(BPMSoft.LocalizableStrings[stringKey], typeDisplayValue);
				} else {
					stringKey = "AddressEmbededDetail_inplaceEdit_title";
					return BPMSoft.LocalizableStrings[stringKey];
				}
			}
		};
	},

	/**
	 * Loads UId of schema by name.
	 * @param {Object} config Configuration object:
	 * @param {String} config.modelName Name of schema.
	 * @param {Function} config.success Success callback.
	 * @param {Function} config.failure Failure callback.
	 * @param {Object} config.scope Value of 'this' in the above function.
	 * @param {String} config.cancellationId Cancellation id. If parameter is set, operation can be cancelled.
	 */
	loadSysSchemaUIdByName: function(config) {
		var filters = Ext.create("BPMSoft.Filter", {
			property: "Name",
			value: config.modelName
		});
		BPMSoft.DataUtils.loadRecords({
			isCancelable: false,
			cancellationId: config.cancellationId,
			modelName: "VwSysEntitySchemaInWorkspace",
			columns: ["UId", "Parent"],
			filters: filters,
			success: function(records) {
				if (records && records.length > 0) {
					var record = this.findParentSchemaRecord(records);
					Ext.callback(config.success, config.scope, [record.get("UId")]);
				} else {
					var exception = Ext.create("BPMSoft.Exception", {
						message: Ext.String.format(BPMSoft.LS["VwSysEntitySchemaInWorkspace.RecordNotFound"],
							config.modelName)
					});
					Ext.callback(config.failure, config.scope, [exception]);
				}
			},
			failure: function(exception) {
				Ext.callback(config.failure, config.scope, [exception]);
			},
			scope: this
		});
	},

	/**
	 * Gets user's image url.
	 * @param {Object} config Configuration object:
	 * @param {String} config.contactId Contact id.
	 * @param {Boolean} config.autoSetProxy If true, auto set proxy.
	 * @param {Boolean} config.cachePriority If true, finds image and cache.
	 * @param {BPMSoft.Proxies} config.onlineProxy Proxy for online mode.
	 * @param {BPMSoft.ProxyType} config.proxyType Proxy type.
	 * @param {Function} config.callback Called when data is obtained.
	 * @param {Object} config.scope Value of `this` in the above function.
	 * @param {String} config.cancellationId Cancellation id. If parameter is set, operation can be cancelled.
	 */
	getUserImageUrl: function(config) {
		var contactId = config.contactId || config.ownerId;
		var loadConfig = {
			isCancelable: true,
			cancellationId: config.cancellationId,
			queryConfig: Ext.create("BPMSoft.QueryConfig", {
				modelName: "Contact",
				columns: ["Photo.PreviewData", "Photo.Id"],
				autoSetProxy: Ext.isBoolean(config.autoSetProxy) ? config.autoSetProxy : true,
				onlineProxy: config.onlineProxy
			}),
			proxyType: config.proxyType,
			success: function(record) {
				var imageUrl;
				if (record) {
					var imageRecord = record.get("Photo");
					var imageRecordId = imageRecord && imageRecord.getId();
					if (!Ext.isEmpty(imageRecordId) && (config.cachePriority || BPMSoft.Platform.isIOS)) {
						BPMSoft.FileCache.get({
							addIfNotExist: {
								fileColumnName: "PreviewData",
								fileName: imageRecordId,
							},
							id: imageRecordId,
							cancellationId: config.cancellationId,
							fileRecord: imageRecord,
							proxyType: config.proxyType,
							success: function(fileUrl) {
								fileUrl = BPMSoft.util.toAbsoluteUrl(fileUrl);
								Ext.callback(config.callback, config.scope, [fileUrl]);
							},
							failure: function() {
								Ext.callback(config.callback, config.scope);
							},
							scope: this
						});
						return;
					} else if (!BPMSoft.Platform.isIOS) {
						imageUrl = BPMSoft.ImageUtils.getImageUrl(imageRecord, "PreviewData");
					}
				}
				Ext.callback(config.callback, config.scope, [imageUrl]);
			},
			failure: function() {
				Ext.callback(config.callback, config.scope);
			}
		};
		Contact.load(contactId, loadConfig, this);
	}

});

/**
 * @deprecated
 */
BPMSoft.configuration.getUserImage = BPMSoft.CFUtils.getUserImageUrl.bind(BPMSoft.CFUtils);

/**
 * @deprecated
 */
BPMSoft.configuration.loadSysSchemaUIdByName = BPMSoft.CFUtils.loadSysSchemaUIdByName.bind(BPMSoft.CFUtils);

/**
 * @deprecated
 */
BPMSoft.configuration.util.getAddressEmbeddedDetailPreviewConfig =
	BPMSoft.CFUtils.getAddressEmbeddedDetailPreviewConfig.bind(BPMSoft.CFUtils);

BPMSoft.Configuration.updateParentAddressColumns = function(config, record, parentModelName, parentColumnName) {
	var successFn = config.success;
	var failureFn = config.failure;
	var callbackScope = config.scope;
	var parent = record.get(parentColumnName);
	if (parent) {
		var parentId = parent.getId();
		var sqlText =
			"select a.Id as RecordId " +
			"from " + record.modelName + " a " +
			"where a." + parentColumnName + "Id = '" + parentId + "' " +
			"order by a.CreatedOn asc limit 1";
		BPMSoft.Sql.DBExecutor.executeSql({
			sqls: [sqlText],
			success: function(data) {
				var recordId;
				if (data.length > 0) {
					var records = data[0].rows;
					if (records.length > 0) {
						var sqlData = records.item(0);
						recordId = sqlData.RecordId;
					}
				}
				if (!recordId || recordId === record.getId()) {
					var parentModel = Ext.ModelManager.getModel(parentModelName);
					var queryConfig = Ext.create("BPMSoft.QueryConfig", {
						columns: ["Address", "AddressType", "City", "Country", "Region", "Zip",
							"GPSN", "GPSE"],
						modelName: parentModelName
					});
					parentModel.load(parentId, {
						isCancelable: true,
						queryConfig: queryConfig,
						success: function(parentRecord) {
							if (parentRecord) {
								parentRecord.set("Address", record.get("Address"));
								parentRecord.set("AddressType", record.get("AddressType"));
								parentRecord.set("City", record.get("City"));
								parentRecord.set("Country", record.get("Country"));
								parentRecord.set("Region", record.get("Region"));
								parentRecord.set("Zip", record.get("Zip"));
								parentRecord.set("GPSN", null);
								parentRecord.set("GPSE", null);
								parentRecord.save({
									isCancelable: false,
									queryConfig: queryConfig,
									success: successFn,
									failure: failureFn,
									scope: callbackScope
								}, this);
							} else {
								Ext.callback(successFn, callbackScope);
							}
						},
						failure: failureFn,
						scope: callbackScope
					});
				} else {
					Ext.callback(successFn, callbackScope);
				}
			},
			failure: failureFn,
			scope: callbackScope
		});
	} else {
		Ext.callback(successFn, callbackScope);
	}
};

BPMSoft.Configuration.getFirstRecordInFileDetail = function(config) {
	var fileDetailModelName = config.fileDetailModelName;
	var parentRecordColumnName = config.parentRecordColumnName;
	var parentRecordId = config.parentRecordId;
	var withEntityLinks = config.withEntityLinks;
	var success = config.success;
	var failure = config.failure;
	var scope = config.scope;
	var store = Ext.create("BPMSoft.store.BaseStore", {
		model: fileDetailModelName
	});
	store.setPageSize(1);
	var queryConfig = Ext.create("BPMSoft.QueryConfig", {
		columns: ["Name", "Data", "Type", parentRecordColumnName],
		modelName: fileDetailModelName
	});
	var filters = Ext.create("BPMSoft.Filter", {
		type: BPMSoft.FilterTypes.Group,
		logicalOperation: BPMSoft.FilterLogicalOperations.And
	});
	filters.addFilter(Ext.create("BPMSoft.Filter", {
		property: parentRecordColumnName,
		value: parentRecordId
	}));
	if (withEntityLinks) {
		var subfilters = Ext.create("BPMSoft.Filter", {
			property: "Type",
			funcType: BPMSoft.FilterFunctions.In,
			funcArgs: [BPMSoft.Configuration.FileTypeGUID.File, BPMSoft.Configuration.FileTypeGUID.EntityLink]
		});
		filters.addFilter(subfilters);
	}
	store.loadPage(1, {
		isCancelable: true,
		cancellationId: config.cancellationId,
		queryConfig: queryConfig,
		filters: filters,
		callback: function(records, operation, isLoadedSuccessfully) {
			if (isLoadedSuccessfully) {
				var fileRecord = records[0];
				Ext.callback(success, scope, [fileRecord]);
			} else {
				Ext.callback(failure, scope, [operation.getError()]);
			}
		},
		scope: this
	});
};

BPMSoft.Configuration.openFirstFileInFileDetail = function(config) {
	var modelName = config.modelName;
	var fileDetailModelName = config.fileDetailModelName;
	var recordId = config.recordId;
	var success = config.success;
	var failure = config.failure;
	var scope = config.scope;
	BPMSoft.Configuration.getFirstRecordInFileDetail({
		cancellationId: config.cancellationId,
		fileDetailModelName: fileDetailModelName,
		parentRecordColumnName: modelName,
		parentRecordId: recordId,
		withEntityLinks: true,
		success: function(fileRecord) {
			if (fileRecord) {
				BPMSoft.util.downloadRecordFile({
					record: fileRecord,
					dataColumnName: "Data",
					fileName: fileRecord.getPrimaryDisplayColumnValue(),
					success: function(path) {
						var typeId = fileRecord.get("Type").getId();
						if (typeId === BPMSoft.Configuration.FileTypeGUID.EntityLink) {
							BPMSoft.Configuration.openFileByEntityLink({
								cancellationId: config.cancellationId,
								fileUrl: path,
								success: success,
								failure: failure,
								scope: scope
							});
						} else {
							BPMSoft.FileIntent.open({
								path: path,
								success: success,
								failure: failure,
								scope: scope
							});
						}
					},
					failure: failure,
					scope: scope
				});
			} else {
				Ext.callback(failure, scope, [{
					fileNotFound: true
				}]);
			}
		},
		failure: failure,
		scope: scope
	});
};

BPMSoft.Configuration.openFileByEntityLink = function(config) {
	var fileUrl = config.fileUrl;
	var modelName = config.modelName || "KnowledgeBase";
	var fileDetailModelName = config.fileDetailModelName || "KnowledgeBaseFile";
	var success = config.success;
	var scope = config.scope;
	var callFailure = function(exception, isFileNotFound) {
		if (isFileNotFound || BPMSoft.FileSystemManager.isFileNotFoundError(exception)) {
			Ext.callback(config.failure, scope, [{
				fileNotFound: true
			}]);
		} else {
			BPMSoft.MessageBox.showException(exception);
			Ext.callback(config.failure, scope);
		}
	};
	fileUrl = BPMSoft.util.toRelativeUrl(fileUrl);
	if (BPMSoft.String.startsWith(fileUrl, "/")) {
		fileUrl = fileUrl.substring(1, fileUrl.length);
	}
	BPMSoft.File.readToEnd({
		name: fileUrl,
		success: function(text) {
			var fileInfo;
			try {
				fileInfo = JSON.parse(text);
			} catch (e) {
				var exception = Ext.create("BPMSoft.Exception", {message: e});
				BPMSoft.MessageBox.showException(exception);
				Ext.callback(config.failure, scope);
				return;
			}
			BPMSoft.Configuration.getFirstRecordInFileDetail({
				cancellationId: config.cancellationId,
				fileDetailModelName: fileDetailModelName,
				parentRecordColumnName: modelName,
				parentRecordId: fileInfo.recordId,
				withEntityLinks: false,
				success: function(fileRecord) {
					if (fileRecord) {
						var dataColumnName = "Data";
						BPMSoft.util.downloadRecordFile({
							record: fileRecord,
							dataColumnName: dataColumnName,
							fileName: fileRecord.getPrimaryDisplayColumnValue(),
							success: function(path) {
								BPMSoft.FileIntent.open({
									path: path,
									success: success,
									failure: config.failure,
									scope: scope
								});
							},
							failure: function(exception) {
								callFailure(exception);
							},
							scope: scope
						});
					} else {
						callFailure(null, true);
					}
				},
				failure: config.failure,
				scope: scope
			});
		},
		failure: function(exception) {
			callFailure(exception);
		},
		scope: this
	});
};

BPMSoft.Configuration.focusDetailItemFieldByColumnName = function(columnName, detailItem) {
	var itemsCollection = detailItem.getItems();
	var items = itemsCollection.items;
	var targetField;
	for (var i = 0, ln = items.length; i < ln; i++) {
		var item = items[i];
		if (item.getName() === columnName) {
			targetField = item;
			break;
		}
	}
	if (targetField) {
		if (targetField instanceof Ext.BPMSoft.LookupEdit) {
			var picker = targetField.getPicker();
			var filterPanel = picker.getFilterPanel();
			var searchModule = filterPanel.getModuleByName("LookupSearch");
			var searchComponent = searchModule.getComponent();
			searchComponent.addListener({
				painted: {
					single: true,
					fn: function() {
						if (Ext.os.is.iOS) {
							var me = this;
							setTimeout(function() {
								me.focus(true);
							}, 1000);
						} else {
							this.focus(true);
						}
					}
				}
			});
		}
		targetField.focus();
	}
};

BPMSoft.Configuration.getDefaultOwnerImage = function() {
	var defaultImageName  = "MobileImageListDefaultContactPhoto"
	
	var base64str = BPMSoft.IconsConfiguration.get(defaultImageName);
	return BPMSoft.util.getBase64ImageUrl(base64str);
};

/**
 * Gets current user's photo.
 * @param {Object} config Configuration object:
 * @param {Function} config.callback Called when data is obtained.
 * @param {Object} config.scope Value of `this` in the above function.
 * @param {String} config.cancellationId Cancellation id. If parameter is set, operation can be cancelled.
 */
BPMSoft.Configuration.getCurrentUserImage = function(config) {
	BPMSoft.CFUtils.getUserImageUrl({
		cancellationId: config.cancellationId,
		ownerId: BPMSoft.CurrentUserInfo.contactId,
		callback: function(previewData) {
			var callbackFn = function(callBackFnConfig) {
				Ext.callback(callBackFnConfig.callback, callBackFnConfig.scope, [previewData]);
			};
			BPMSoft.Configuration.getCurrentUserImage = callbackFn;
			callbackFn(config);
		},
		scope: this
	});
};
