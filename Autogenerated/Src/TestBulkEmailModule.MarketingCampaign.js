define("TestBulkEmailModule", ["TestBulkEmailModuleResources", "LookupUtilities", "EmailHelperModule",
		"ModalBox", "MaskHelper", "SendTestEmailContentMixin"
	],
	function(resources, LookupUtilities, EmailHelperModule, modalbox, MaskHelper) {
		var Ext;
		var sandbox;
		var BPMSoft;
		var viewConfig;
		var viewModel;

		function createConstructor(context) {
			Ext = context.Ext;
			sandbox = context.sandbox;
			BPMSoft = context.BPMSoft;
			return Ext.define("TestBulkEmailModule", {
				init: init
			});
		}

		function init() {
			innerRender();
		}

		function innerRender() {
			MaskHelper.HideBodyMask();
			var renderTo = modalbox.show({
				minWidth: 10,
				maxWidth: 90,
				minHeight: 10,
				maxHeight: 90
			});
			viewModel = getViewModel();
			viewModel.init();
			viewModel.Ext = this.Ext;
			viewModel.sandbox = this.sandbox;
			viewModel.BPMSoft = this.BPMSoft;
			viewModel.set("headMessage", resources.localizableStrings.PageCaption);
			viewConfig = getView(renderTo);
			viewConfig.bind(viewModel);
			modalbox.setSize(600, 230);
		}

		/**
		 * ########## ###### ############ ######.
		 * @private
		 * @return {Object}
		 */
		var getViewModel = function() {
			return Ext.create("BPMSoft.BaseViewModel", {
				mixins: {
					SendTestEmailContentMixin: "BPMSoft.SendTestEmailContentMixin"
				},
				columns: {
					/**
					 * Bulk email.
					 */
					BulkEmail: {
						dataValueType: BPMSoft.DataValueType.LOOKUP,
						isLookup: true,
						caption: resources.localizableStrings.BulkEmailCaption,
						referenceSchemaName: "BulkEmail",
						isRequired: true
					},
					/**
					 * Contact.
					 */
					Contact: {
						dataValueType: BPMSoft.DataValueType.LOOKUP,
						isLookup: true,
						caption: resources.localizableStrings.ContactCaption,
						referenceSchemaName: "Contact"
					},
					/**
					 * EmailAddress
					 */
					EmailAddress: {
						dataValueType: BPMSoft.DataValueType.TEXT,
						caption: resources.localizableStrings.EmailCaption,
						isRequired: true
					}
				},
				values: {
					BulkEmail: null,
					Contact: null,
					EmailAddress: "",
					maskId: null
				},
				methods: {

					/**
					 * Cancel click handler.
					 */
					onCancelClick: function() {
						this.close();
					},

					/**
					 * Closes module.
					 */
					close: function() {
						modalbox.close();
					},

					/**
					 * ######### ######### ### ######### #######.
					 * @param {String} columnName ### ####### ### #########.
					 * @param {Function} validatorFn ####### #########.
					 */
					addColumnValidator: function(columnName, validatorFn) {
						var columnValidationConfig = this.validationConfig[columnName] ||
							(this.validationConfig[columnName] = []);
						columnValidationConfig.push(validatorFn);
					},

					/**
					 * ####### ######### ########## Email.
					 * @return {Object} ########## ######### #########.
					 */
					checkEmailValidator: function() {
						var invalidMessage = "";
						var email = this.get("EmailAddress");
						if (!EmailHelperModule.isEmailValid(email)) {
							invalidMessage = resources.localizableStrings.IncorrectEmailMessage;
						}
						return {
							fullInvalidMessage: invalidMessage,
							invalidMessage: invalidMessage
						};
					},

					/**
					 * #############.
					 */
					init: function() {
						this.addColumnValidator("EmailAddress", this.checkEmailValidator);
						var moduleId = sandbox.id;
						var bulkEmail = sandbox.publish("GetBulkEmail", moduleId, [moduleId]);
						this.set("BulkEmail", bulkEmail);
						BPMSoft.SysSettings.querySysSettingsItem("TestSendingBulkEmailContact",
							function(sysSetting) {
								this.set("Contact", sysSetting);
							}, this);
					},

					/**
					 * ######### ######## ###########.
					 * @param {Object} args #########.
					 * @param {Object} tag ###.
					 */
					loadVocabulary: function(args, tag) {
						var config = {
							entitySchemaName: tag,
							multiSelect: false,
							columnName: tag,
							searchValue: args.searchValue
						};
						var callback = function(args) {
							var columnName = args.columnName;
							var collection = args.selectedRows;
							if (collection.getCount() > 0) {
								this.set(columnName, collection.getItems()[0]);
							}
						};
						LookupUtilities.Open(sandbox, config, callback, this, null, false, false);
					},

					//region Methods: Public

					/**
					 * Send button click handler.
					 */
					onSendClick: function() {
						this.send();
					}

					//endregion
				}
			});
		};

		/**
		 * ########## ############# ######.
		 * @private
		 * @return {Object}
		 */
		var getView = function(renderTo) {
			var labelConfig = Ext.create("BPMSoft.Label", {
				caption: {
					bindTo: "headMessage"
				},
				labelClass: "head-label-user-class"
			});
			var buttonsConfig = Ext.create("BPMSoft.Button", {
				imageConfig: resources.localizableImages.CloseIcon,
				style: BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
				classes: {
					wrapperClass: "close-btn-user-class"
				},
				selectors: {
					wrapEl: "#closeTestBulkEmailButton"
				},
				click: {
					bindTo: "close"
				}
			});

			var controlsConfig = Ext.create("BPMSoft.Container", {
				id: "mainContainer",
				selectors: {
					wrapEl: "#mainContainer"
				},
				items: [{
					className: "BPMSoft.Container",
					id: "TestBulkEmailModuleFieldsContainer",
					selectors: {
						wrapEl: "#TestBulkEmailModuleFieldsContainer"
					},
					classes: {
						wrapClassName: ["control-user-class", "control-width-15"]
					},
					items: [{
						className: "BPMSoft.Container",
						id: "TestBulkEmailModuleFieldsContainer_BulkEmailLabel",
						selectors: {
							wrapEl: "#TestBulkEmailModuleFieldsContainer_BulkEmailLabel"
						},
						classes: {
							wrapClassName: ["label-wrap"]
						},
						items: [{
							markerValue: "bulkEmailLabel",
							className: "BPMSoft.Label",
							caption: resources.localizableStrings.BulkEmailCaption
						}]
					}, {
						className: "BPMSoft.Container",
						id: "TestBulkEmailModuleFieldsContainer_BulkEmailControl",
						selectors: {
							wrapEl: "#TestBulkEmailModuleFieldsContainer_BulkEmailControl"
						},
						classes: {
							wrapClassName: ["control-wrap"]
						},
						items: [{
							markerValue: "bulkEmailLookupEdit",
							className: "BPMSoft.LookupEdit",
							enabled: false,
							value: {
								bindTo: "BulkEmail"
							},
							loadVocabulary: {
								bindTo: "loadVocabulary"
							},
							tag: "BulkEmail"
						}]
					}, {
						className: "BPMSoft.Container",
						id: "TestBulkEmailModuleFieldsContainer_EmailLabel",
						selectors: {
							wrapEl: "#TestBulkEmailModuleFieldsContainer_EmailLabel"
						},
						classes: {
							wrapClassName: ["label-wrap"]
						},
						items: [{
							markerValue: "EmailLabel",
							className: "BPMSoft.Label",
							caption: resources.localizableStrings.EmailCaption,
							isRequired: true
						}]
					}, {
						className: "BPMSoft.Container",
						id: "TestBulkEmailModuleFieldsContainer_EmailControl",
						selectors: {
							wrapEl: "#TestBulkEmailModuleFieldsContainer_EmailControl"
						},
						classes: {
							wrapClassName: ["control-wrap"]
						},
						items: [{
							markerValue: "emailEdit",
							className: "BPMSoft.TextEdit",
							value: {
								bindTo: "EmailAddress"
							}
						}]
					}]
				}, {
					className: "BPMSoft.Container",
					id: "buttonsContainer",
					selectors: {
						wrapEl: "#buttonsContainer"
					},
					classes: {
						wrapClassName: ["control-buttons"]
					},
					items: [{
							className: "BPMSoft.Button",
							markerValue: "sendButton",
							caption: resources.localizableStrings.SendButtonCaption,
							style: BPMSoft.controls.ButtonEnums.style.ORANGE,
							click: {
								bindTo: "onSendClick"
							},
							classes: {
								textClass: ["actions-button-margin-right"]
							}
						},
						{
							className: "BPMSoft.Button",
							markerValue: "cancelButton",
							caption: resources.localizableStrings.CancelButtonCaption,
							click: {
								bindTo: "onCancelClick"
							},
							classes: {
								textClass: ["actions-button-margin-right"]
							}
						}
					]
				}]
			});

			return Ext.create("BPMSoft.Container", {
				id: "testBulkEmailContainer",
				selectors: {
					wrapEl: "#testBulkEmailContainer"
				},
				classes: {
					wrapClassName: ["main-container"]
				},
				renderTo: renderTo,
				items: [
					labelConfig,
					buttonsConfig,
					controlsConfig
				]
			});
		};

		return createConstructor;
	});
