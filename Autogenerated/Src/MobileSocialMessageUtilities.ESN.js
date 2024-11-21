/* globals VwMobileSysSchema: false */
/* globals SysImage: false */
/* globals Contact: false */
Ext.ns("BPMSoft.configuration.ESNUtils");

BPMSoft.configuration.ESNUtils.LinkTypes = {
	Module: "module",
	Uri: "uri",
	Email: "email",
	Phone: "phone"
};

BPMSoft.configuration.LinkTypes = BPMSoft.configuration.ESNUtils.LinkTypes;

BPMSoft.configuration.ESNUtils.getSysSchemaUIdByName = function(modelName) {
	var store = VwMobileSysSchema.Store;
	if (!store) {
		return null;
	}
	var data = store.data;
	var modelSchema = data.findBy(function(item) {
		return item.data.Name === modelName;
	});
	return modelSchema ? modelSchema.data.Id : null;
};

BPMSoft.configuration.getSysSchemaUIdByName = BPMSoft.configuration.ESNUtils.getSysSchemaUIdByName;

/**
 * Opens the link.
 * @param {BPMSoft.configuration.LinkTypes} config.type Type of link.
 * @param {BPMSoft.configuration.LinkTypes} config.type Type of the link.
 * @param {String} config.modelname Related model's name.
 * @param {String} config.recordid Related record's id.
 * @param {Object} config.url URL.
 * @param {Object} config.email E-mail.
 * @param {Object} config.phone Phone number.
 */
BPMSoft.configuration.ESNUtils.openLink = function(config) {
	var linkTypes = BPMSoft.configuration.LinkTypes;
	switch (config.type) {
		case linkTypes.Module:
			var recordId = config.recordid;
			var modelName = config.modelname;
			if (modelName !== "SocialChannel" && recordId) {
				BPMSoft.util.openPreviewPage(modelName, {
					recordId: recordId,
					isStartRecord: true
				});
			}
			break;
		case linkTypes.Uri:
			BPMSoft.util.openUrl(config.url, true);
			break;
		case linkTypes.Email:
			BPMSoft.EmailManager.sendEmail({
				to: config.email
			});
			break;
		case linkTypes.Phone:
			BPMSoft.util.callByPhone(config.phone);
			break;
		default:
			break;
	}
};

BPMSoft.configuration.openLink = BPMSoft.configuration.ESNUtils.openLink;

/**
 * Sets current user in 'CreatedBy' column and as author of social message.
 * @param {Object} config Configuration object:
 * @param {SocialMessage} config.socialMessageRecord Social message record.
 * @param {Function} config.callback Callback function.
 * @param {Object} config.scope Scope of callback function.
 * @param {String} config.cancellationId Cancellation id. If parameter is set, operation can be cancelled.
*/
BPMSoft.configuration.ESNUtils.setCreatedByForCurrentUser = function(config) {
	var record = config.record;
	BPMSoft.configuration.getCurrentUserImage({
		cancellationId: config.cancellationId,
		callback: function(image) {
			var photo = SysImage.create({
				PreviewData: image
			});
			var createdBy = record.get("CreatedBy");
			if (!(createdBy instanceof Contact)) {
				createdBy = BPMSoft.evaluateMacrosValue(BPMSoft.ValueMacros.CurrentUserContact);
				record.set("CreatedBy", createdBy);
				record.set("CreatedOn",
					BPMSoft.evaluateMacrosValue(BPMSoft.ValueMacros.CurrentDateTime));
			}
			createdBy.set("Photo", photo);
			Ext.callback(config.callback, config.scope);
		},
		scope: this
	});
};

BPMSoft.configuration.setCreatedByForCurrentUser = BPMSoft.configuration.ESNUtils.setCreatedByForCurrentUser;

/**
 * Returns true if 'Feed' works in hybrid mode.
 * @returns {Boolean} True if 'Feed' works in hybrid mode.
*/
BPMSoft.configuration.ESNUtils.isFeedInHybridMode = function() {
	return BPMSoft.Features.getIsEnabled("UseHybridModeInMobileFeed") &&
		!BPMSoft.ApplicationUtils.isOnlineMode() && BPMSoft.Connection.isOnline();
};

BPMSoft.configuration.isFeedInHybridMode = BPMSoft.configuration.ESNUtils.isFeedInHybridMode;
