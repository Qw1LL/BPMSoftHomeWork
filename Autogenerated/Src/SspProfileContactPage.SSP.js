define("SspProfileContactPage", ["EmailHelper", "SspProfileContactPageResources", "CommunicationSynchronizerMixin", "css!ContactPageV2CSS"],
	function(EmailHelper, resources) {
		return {
			entitySchemaName: "Contact",
			mixins: {
				CommunicationSynchronizerMixin: "BPMSoft.CommunicationSynchronizerMixin"
			},
			attributes: {
				"Email": {
					"dataValueType": BPMSoft.DataValueType.TEXT,
					"type": BPMSoft.ViewModelColumnType.ENTITY_COLUMN,
					"isRequired": true,
					"dependencies": [
						{
							"columns": ["Email"],
							"methodName": "syncEntityWithCommunicationDetail"
						}
					]
				},

				"MobilePhone": {
					"dependencies": [
						{
							"columns": ["MobilePhone"],
							"methodName": "syncEntityWithCommunicationDetail"
						}
					]
				},

				"Phone": {
					"dependencies": [
						{
							"columns": ["Phone"],
							"methodName": "syncEntityWithCommunicationDetail"
						}
					]
				},

				/**
				* @inheritdoc BPMSoft.BaseDataView#UseTagModule
				* @override
				*/
				"UseTagModule": {
					dataValueType: this.BPMSoft.DataValueType.BOOLEAN,
					value: false
				},

				"CommunicationDetailName": {
					dataValueType: BPMSoft.DataValueType.TEXT,
					value: "ContactCommunication"
				},

				"JobTitle": {
					dependencies: [
						{
							columns: ["Job"],
							methodName: "jobChanged"
						}
					]
				}
			},
			messages: {
				/**
				 * @message GetCommunicationsSynchronizedByDetail
				 * Requests communications synchronized by detail.
				 */
				"GetCommunicationsSynchronizedByDetail": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				},
				/**
				 * @message SyncCommunication
				 * Synchronizes communications.
				 */
				"SyncCommunication": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				}
			},
			details: /**SCHEMA_DETAILS*/{
				ContactCommunication: {
					schemaName: "SspContactCommunicationDetail",
					filter: {
						masterColumn: "Id",
						detailColumn: "Contact"
					}
				},
				ContactAddress: {
					schemaName: "ContactAddressDetailV2",
					filter: {
						masterColumn: "Id",
						detailColumn: "Contact"
					}
				}
			}/**SCHEMA_DETAILS*/,
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "remove",
					"name": "ESNTab"
				},
				{
					"operation": "insert",
					"parentName": "ProfileContainer",
					"propertyName": "items",
					"name": "ContactPhotoContainer",
					"values": {
						"layout": {
							"column": 0,
							"row": 0,
							"colSpan": 24,
							"rowSpan": 1
						},
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["image-edit-container",'profile-image-container'],
						"items": []
					},
					"alias": {
						"name": "PhotoContainer",
						"excludeOperations": ["remove", "move"]
					}
				},
				{
					"operation": "insert",
					"parentName": "ContactPhotoContainer",
					"propertyName": "items",
					"name": "Photo",
					"values": {
						"getSrcMethod": "_getContactImage",
						"onPhotoChange": "_onPhotoChange",
						"readonly": false,
						"width": "100%",
						"height": "100%",
						"defaultImage": {"bindTo": "_getContactDefaultImage"},
						"generator": "ImageCustomGeneratorV2.generateCustomImageControl"
					}
				},
				{
					"operation": "insert",
					"name": "Name",
					"values": {
						"layout": {
							"column": 0,
							"row": 1,
							"colSpan": 24,
							"rowSpan": 1
						},
						"bindTo": "Name"
					},
					"parentName": "ProfileContainer",
					"propertyName": "items"
				},
				{
					"operation": "insert",
					"name": "SalutationType",
					"values": {
						"contentType": this.BPMSoft.ContentType.ENUM,
						"layout": {
							"column": 0,
							"row": 2,
							"colSpan": 24,
							"rowSpan": 1
						},
						"bindTo": "SalutationType"
					},
					"parentName": "ProfileContainer",
					"propertyName": "items"
				},
				{
					"operation": "insert",
					"name": "Gender",
					"values": {
						"layout": {
							"column": 0,
							"row": 3,
							"colSpan": 24,
							"rowSpan": 1
						},
						"bindTo": "Gender"
					},
					"parentName": "ProfileContainer",
					"propertyName": "items"
				},
				{
					"operation": "insert",
					"name": "Job",
					"values": {
						"contentType": this.BPMSoft.ContentType.ENUM,
						"layout": {
							"column": 0,
							"row": 4,
							"colSpan": 24,
							"rowSpan": 1
						},
						"bindTo": "Job"
					},
					"parentName": "ProfileContainer",
					"propertyName": "items"
				},
				{
					"operation": "insert",
					"name": "JobTitle",
					"values": {
						"layout": {
							"column": 0,
							"row": 5,
							"colSpan": 24,
							"rowSpan": 1
						},
						"bindTo": "JobTitle"
					},
					"parentName": "ProfileContainer",
					"propertyName": "items"
				},
				{
					"operation": "insert",
					"name": "MobilePhone",
					"values": {
						"layout": {
							"column": 0,
							"row": 6,
							"colSpan": 24,
							"rowSpan": 1
						},
						"bindTo": "MobilePhone"
					},
					"parentName": "ProfileContainer",
					"propertyName": "items"
				},
				{
					"operation": "insert",
					"name": "Phone",
					"values": {
						"layout": {
							"column": 0,
							"row": 7,
							"colSpan": 24,
							"rowSpan": 1
						},
						"bindTo": "Phone"
					},
					"parentName": "ProfileContainer",
					"propertyName": "items"
				},
				{
					"operation": "insert",
					"name": "Email",
					"values": {
						"layout": {
							"column": 0,
							"row": 8,
							"colSpan": 24,
							"rowSpan": 1
						},
						"bindTo": "Email"
					},
					"parentName": "ProfileContainer",
					"propertyName": "items"
				},
				{
					"operation": "insert",
					"name": "GeneralInfoTab",
					"parentName": "Tabs",
					"propertyName": "tabs",
					"index": 0,
					"values": {
						"caption": {"bindTo": "Resources.Strings.GeneralInfoTabCaption"},
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "GeneralInfoTab",
					"propertyName": "items",
					"name": "ContactCommunication",
					"values": {
						"itemType": BPMSoft.ViewItemType.DETAIL,
						"classes": {
							"wrapClassName": ["page-contact-communication-container"]
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "GeneralInfoTab",
					"propertyName": "items",
					"name": "ContactAddress",
					"values": {
						"itemType": BPMSoft.ViewItemType.DETAIL
					}
				}
			]/**SCHEMA_DIFF*/,
			methods: {
				/**
				 * @inheritDoc BPMSoft.BasePageV2#save
				 * @override
				 */
				save: function() {
					this.clearChangedValuesSynchronizedByDetail();
					this.callParent(arguments);
				},

				/**
				 * @inherit#oc BPMSoft.configuration.BaseSchemaViewModel#setValidationConfig
				 * @override
				 */
				setValidationConfig: function() {
					this.callParent(arguments);
					this.addColumnValidator("Email", EmailHelper.getEmailValidator);
				},

				jobChanged: function() {
					const job = this.get("Job");
					const jobTitle = this.get("JobTitle");
					if (this.isNotEmpty(job) && this.isEmpty(jobTitle)) {
						this.set("JobTitle", job.displayValue);
					}
				},

				_getContactImage: function() {
					const primaryImageColumnValue = this.get(this.primaryImageColumnName);
					if (primaryImageColumnValue) {
						return this.getSchemaImageUrl(primaryImageColumnValue);
					}
					return this._getContactDefaultImage();
				},

				_getContactDefaultImage: function() {
					return BPMSoft.ImageUrlBuilder.getUrl(this.get("Resources.Images.DefaultPhoto"));
				},

				_onPhotoChange: function(photo) {
					if (!photo) {
						this.set(this.primaryImageColumnName, null);
						return;
					}
					BPMSoft.ImageApi.upload({
						file: photo,
						onComplete: this._onPhotoUploaded,
						onError: this._onPhotoChangeError,
						scope: this
					});
				},

				_onPhotoChangeError: function(imageId, error, xhr) {
					if (xhr.response) {
						const response = BPMSoft.decode(xhr.response);
						if (response.error) {
							BPMSoft.showMessage(response.error);
						}
					}
				},

				_onPhotoUploaded: function(imageId) {
					const imageData = {
						value: imageId,
						displayValue: "Photo"
					};
					this.set(this.primaryImageColumnName, imageData);
				},

				/**
				* @inheritDoc BPMSoft.BaseDataView#initActionButtonMenu
				* @override
				*/
				initActionButtonMenu: BPMSoft.emptyFn,

				/**
				 * @inheritDoc DuplicatesSearchUtilitiesV2#initPerformSearchOnSave
				 * @override
				 */
				initPerformSearchOnSave: BPMSoft.emptyFn

			}
		};
	});
