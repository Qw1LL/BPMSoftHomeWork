/* globals Contact: false */
/**
 * @class BPMSoft.configuration.SysAdminUnitCacheManager
 * Implementation of cache manager for SysAdminUnit object.
 */
Ext.define("BPMSoft.configuration.SysAdminUnitCacheManager", {
	extend: "BPMSoft.core.BaseModelCacheManager",

	//region Methods: Private

	/**
	 * @private
	 */
	checkIfCachedForContact: function(contactId) {
		return BPMSoft.Data.load({
			modelName: "SysAdminUnit",
			proxyType: BPMSoft.ProxyType.Offline,
			columns: ["Id"],
			filters: Ext.create("BPMSoft.Filter", {
				property: "Contact",
				value: contactId
			})
		}).then(function(records) {
			return records.length > 0;
		}).catch(function() {
			return false;
		});
	},

	/**
	 * @private
	 */
	getUserRecords: function(recordId) {
		var userFilter = Ext.create("BPMSoft.Filter", {
			property: "Contact",
			value: recordId
		});
		return BPMSoft.Data.load({
			proxyType: BPMSoft.ProxyType.Online,
			modelName: "SysAdminUnit",
			columns: ["Name", "Contact", "Active"],
			filters: userFilter
		});
	},

	/**
	 * @private
	 */
	cacheRecord: function(record) {
		return new Promise(function(resolve, reject) {
			var sqls = [];
			var sql = BPMSoft.Sql.InsertBuilder.buildCachingSql(record, true);
			if (sql) {
				sqls.push(sql);
			}
			var lookupSqls = BPMSoft.DataUtils.getLookupCachingSqls(record, false, false, true);
			sqls = sqls.concat(lookupSqls);
			if (sqls.length > 0) {
				BPMSoft.Sql.DBExecutor.executeSql({
					isCancelable: false,
					sqls: sqls,
					success: function() {
						resolve();
					},
					failure: function() {
						reject();
					}
				});
			} else {
				resolve();
			}
		});
	},

	/**
	 * @private
	 */
	cacheUserRecord: function(contactId) {
		return this.getUserRecords(contactId).then(function(loadedUsers) {
			var promises = [];
			loadedUsers.forEach(function(userRecord) {
				promises.push(this.cacheRecord(userRecord));
			}.bind(this));
			return Promise.all(promises);
		}.bind(this));
	},

	//endregion

	//region Methods: Public

	/**
	 * @inheritdoc
	 * @overridden
	 */
	putRecord: function(record) {
		var promises = [];
		var contactId;
		if (record instanceof Contact) {
			contactId = record.getPrimaryColumnValue();
			promises.push(this.cacheRecord(record));
		} else {
			contactId = record.get("Contact.Id");
		}
		if (contactId === BPMSoft.CurrentUserInfo.contactId) {
			return Promise.resolve();
		}
		return this.checkIfCachedForContact(contactId).then(function(isCached) {
			if (isCached) {
				return Promise.resolve();
			} else {
				promises.push(this.cacheUserRecord(contactId));
				return Promise.all(promises);
			}
		}.bind(this));
	}

	//endregion

});

BPMSoft.ModelCache.registerManagerClassName("SysAdminUnit", "BPMSoft.configuration.SysAdminUnitCacheManager");
