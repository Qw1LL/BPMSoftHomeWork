﻿/* globals SocialLike: false */
Ext.define("BPMSoft.configuration.SocialMessageLikeManager", {

	/**
	 * @private
	 */
	updateSocialLike: function(socialMessageRecord, isLiked) {
		var socialMessageId = socialMessageRecord.getId();
		var modelName = "SocialLike";
		var proxyType = socialMessageRecord.getProxyType();
		var queryConfig = Ext.create("BPMSoft.QueryConfig", {
			modelName: modelName,
			columns: ["SocialMessage", "User"]
		});
		if (!isLiked) {
			var store = Ext.create("BPMSoft.store.BaseStore", {
				model: modelName,
				proxyType: proxyType
			});
			var filters = Ext.create("BPMSoft.Filter", {
				type: BPMSoft.FilterTypes.Group,
				subfilters: [
					{
						property: "User",
						value: BPMSoft.CurrentUserInfo.userId
					},
					{
						property: "SocialMessage",
						value: socialMessageId
					}
				]
			});
			store.loadPage(1, {
				queryConfig: queryConfig,
				filters: filters,
				callback: function(records) {
					if (records && records.length !== 0) {
						var foundRecord = records[0];
						foundRecord.erase({}, this);
					}
				},
				scope: this
			});
		} else {
			var newSocialLikeRecord = SocialLike.create({
				"SocialMessage": socialMessageId,
				"User": BPMSoft.CurrentUserInfo.userId
			});
			newSocialLikeRecord.setProxyType(proxyType);
			newSocialLikeRecord.save({
				isCancelable: false,
				queryConfig: queryConfig
			}, this);
		}
	},

	/**
	 * @private
	 */
	updateLikeCount: function(socialMessageRecord, isLiked) {
		var likeCount = socialMessageRecord.get("LikeCount");
		var newLikeCount = isLiked ? likeCount + 1 : likeCount - 1;
		/* HACK: Sometimes value in LikeCount field is not actual (possibly, error on server side) and calculated value
		can be negative, what is wrong. */
		if (newLikeCount < 0) {
			newLikeCount = 0;
		}
		socialMessageRecord.set("LikeCount", newLikeCount);
		socialMessageRecord.save({
			queryConfig: Ext.create("BPMSoft.QueryConfig", {
				modelName: socialMessageRecord.modelName,
				columns: ["LikeCount"],
				isLogged: false
			}),
			success: function() {
				socialMessageRecord.commit();
			}
		}, this);
	},

	setLiked: function(socialMessageRecord, isLiked) {
		this.updateSocialLike(socialMessageRecord, isLiked);
		this.updateLikeCount(socialMessageRecord, isLiked);
	},

	loadForCurrentUser: function(config) {
		var records = config.records;
		if (records.length === 0) {
			Ext.callback(config.callback, config.scope, [[]]);
			return;
		}
		var store = Ext.create("BPMSoft.store.BaseStore", {
			model: "SocialLike",
			proxyType: config.proxyType
		});
		var queryConfig = Ext.create("BPMSoft.QueryConfig", {
			modelName: "SocialLike",
			columns: ["SocialMessage.Id"],
			isBatch: BPMSoft.ApplicationUtils.isOnlineMode()
		});
		var ids = [];
		for (var i = 0, ln = records.length; i < ln; i++) {
			ids.push(records[i].getPrimaryColumnValue());
		}
		var inFilter = Ext.create("BPMSoft.Filter", {
			property: "SocialMessage",
			funcType: BPMSoft.FilterFunctions.In,
			funcArgs: ids
		});
		var userFilter = Ext.create("BPMSoft.Filter", {
			property: "User",
			value: BPMSoft.CurrentUserInfo.userId
		});
		var filters = Ext.create("BPMSoft.Filter", {
			type: BPMSoft.FilterTypes.Group,
			subfilters: [userFilter, inFilter]
		});
		store.setPageSize(BPMSoft.AllRecords);
		store.load({
			isCancelable: true,
			queryConfig: queryConfig,
			filters: filters,
			callback: function(likeRecords) {
				Ext.callback(config.callback, config.scope, [likeRecords]);
			},
			scope: this
		});
	}

});
