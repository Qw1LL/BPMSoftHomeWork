﻿define("BaseVisaProvider", ["BaseVisaProviderResources", "ConfigurationConstants", "LookupUtilities", "RightUtilities",
	"ProcessModuleUtilities", "MaskHelper", "ServiceHelper", "css!VisaHelper"
], function(resources, ConfigurationConstants, LookupUtilities, RightUtilities, ProcessModuleUtilities,
            MaskHelper, ServiceHelper) {
	Ext.define("BPMSoft.configuration.BaseVisaProvider", {
		extend: "BPMSoft.BaseObject",
		alternateClassName: "BPMSoft.BaseVisaProvider",

		__privateMembers: [
			"setStatus"
		],

		statics: {
			_getSendToVisaProcces: function(schemaName, callback, scope) {
				var sysSettingName = schemaName + "VisaProcess";
				BPMSoft.SysSettings.querySysSettings([sysSettingName], function(result) {
					var processId = result[sysSettingName];
					if (Ext.isEmpty(processId)) {
						BPMSoft.showInformation(resources.localizableStrings.SendToVisaSysSettingNotExistsError);
						return;
					}
					var processIdValue = Ext.isObject(processId) ? processId.value : processId;
					callback.call(scope, processIdValue);
				}, this);
			},

			_getProcessRecordId: function(viewModel) {
				var activeRow = viewModel.get("ActiveRow") || viewModel.get("activeRow");
				var selectedRows = viewModel.get("SelectedRows") || viewModel.get("selectedRows");
				var recordId = viewModel.get(viewModel.entitySchema.primaryColumnName);
				return recordId || activeRow || (Ext.isEmpty(selectedRows) ? BPMSoft.GUID_EMPTY : selectedRows[0]);
			}
		},

		resources: resources,

		VisaLookupCaption: resources.localizableStrings.VisaLookupCaption,

		SendToVisaMenuItem: {
			caption: resources.localizableStrings.SendToVisaCaption,
			methodName: "sendToVisa"
		},

		/**
		 * Called in the context of another's view model scope.
		 */
		SendToVisaMethod: function() {
			var viewModel = this;
			var entity = viewModel.get("Id") || viewModel.getActiveRow();
			entity = Ext.isObject(entity) ? entity.get("Id") : entity;
			var schemaName = viewModel.entitySchema.name;
			RightUtilities.checkCanEdit({
				schemaName: schemaName,
				primaryColumnValue: entity,
				isNew: false
			}, function(result) {
				if (!Ext.isEmpty(result)) {
					BPMSoft.showInformation(result);
					return;
				}
				BPMSoft.BaseVisaProvider._getSendToVisaProcces(schemaName, function(processUId) {
					var recordId = BPMSoft.BaseVisaProvider._getProcessRecordId(viewModel);
					ProcessModuleUtilities.executeProcess({
						sysProcessId: processUId,
						parameters: {
							RecordId: recordId
						}
					});
				});
			});
		},

		approve: function(entity, comment, callback, scope) {
			var approveStatus = ConfigurationConstants.VisaStatus.positive;
			this.setStatus(entity, approveStatus, comment, callback, scope);
		},

		reject: function(entity, comment, callback, scope) {
			var rejectStatus = ConfigurationConstants.VisaStatus.negative;
			this.setStatus(entity, rejectStatus, comment, callback, scope);
		},

		_callApprovalService: function(entity, methodName, addData, callback, scope) {
			var recordId = entity.get(entity.entitySchema.primaryColumn.name);
			ServiceHelper.callService({
				serviceName: "ApprovalService",
				methodName: methodName,
				scope: scope,
				data: {
					request: {
						schemaName: entity.entitySchema.name,
						id: recordId,
						additionalColumnValues: addData
					}
				},
				callback: callback
			});
		},

		setStatus: function(entity, status, comment, callback, scope) {
			var methodName = status === ConfigurationConstants.VisaStatus.positive ? "Approve" : "Reject";
			var additionalColumnValues = [];
			if (!Ext.isEmpty(comment)) {
				additionalColumnValues.push({"Key": "Comment", "Value": comment});
			}
			this._callApprovalService(entity, methodName, additionalColumnValues, function(result) {
				callback.call(scope, {success: result.ApproveResult || result.RejectResult});
			}, scope);
		},

		approveAction: function(entity, callback, scope) {
			BPMSoft.SysSettings.querySysSettingsItem("AcceptApprovalWithoutComment", function(value) {
				if (value === true) {
					this.approve(entity, "", callback, scope);
				} else {
					var caption = resources.localizableStrings.WarningBeforeApprove;
					var buttonCaption = resources.localizableStrings.ApproveButtonCaption;
					this._baseAction(caption, buttonCaption, entity, this.approve, callback, scope);
				}
			}, this);
		},

		rejectAction: function(entity, callback, scope) {
			var caption = resources.localizableStrings.WarningBeforeRejecting;
			var buttonCaption = resources.localizableStrings.RejectButtonAction;
			this._baseAction(caption, buttonCaption, entity, this.reject, callback, scope);
		},

		changeVizierAction: function(selectedItem, filterPath, sandbox, renderTo, callback, scope) {
			var lookupUtilitiesCallback = function(result) {
				const newVisaOwner = result && result.selectedRows.first();
				if (newVisaOwner) {
					sandbox.requireModuleDescriptors(["force!" + filterPath], function() {
						BPMSoft.require([filterPath], function(schema) {
							this._getVisaEntity(schema, selectedItem, function(result) {
								if (result.success) {
									const entity = result.entity;
									this._updateVizier(entity, newVisaOwner, callback, scope);
								} else {
									Ext.callback(callback, scope, [{success: false}]);
								}
							}, this);
						}, this);
					}, this);
				} else {
					Ext.callback(callback, scope, [{success: false}]);
				}
			};
			var checkRightCallback = function(result) {
				if (result) {
					const lookupConfig = {
						entitySchemaName: "SysAdminUnit",
						captionLookup: resources.localizableStrings.VisaLookupCaption,
						actionsButtonVisible: false
					};
					const cancelCallbackFn = function() {
						Ext.callback(callback, scope, [{success: false}]);
					};
					LookupUtilities.OpenLookup({
						sandbox: sandbox,
						lookupConfig: lookupConfig,
						renderTo: renderTo || Ext.get("centerPanel"),
						cancelCallback: cancelCallbackFn
					}, lookupUtilitiesCallback, this);
				}
			};
			var checkIsAllowedToDelegateCallback = function(result) {
				if (result) {
					this.checkRight(selectedItem, filterPath, checkRightCallback, this);
				}
			};
			this._checkIsAllowedToDelegate(selectedItem, filterPath, checkIsAllowedToDelegateCallback, this);
		},

		checkRight: function(selectedItem, schemaName, callback, scope) {
			RightUtilities.checkCanEdit({
				schemaName: schemaName,
				primaryColumnValue: selectedItem,
				isNew: false
			}, function(result) {
				if (result) {
					BPMSoft.showInformation(resources.localizableStrings.NotRigth);
				} else {
					callback.call(scope, {
						success: true
					});
				}
			});
		},

		openLookup: function(sandbox, viewModel) {
			var lookUpConfig = {
				entitySchemaName: "SysAdminUnit"
			};
			LookupUtilities.ThrowOpenLookupMessage(sandbox, lookUpConfig, viewModel.addCallBack, viewModel,
				viewModel.getCardModuleSandboxId());
		},

		_updateVizier: function(entity, visaOwner, callback, scope) {
			MaskHelper.showBodyMask();
			BPMSoft.each(entity.columns, function(column) {
				column.type = BPMSoft.ViewModelColumnType.ENTITY_COLUMN;
			}, this);
			var delegatedFrom = entity.get("DelegatedFrom");
			var prevVisaOwner = entity.get("VisaOwner");
			var updateObject = {
				DelegatedFrom: delegatedFrom || prevVisaOwner,
				VisaOwner: visaOwner
			};
			BPMSoft.each(updateObject, function(value, column) {
				entity.set(column, value);
			}, this);
			entity.saveEntity(function(response) {
				MaskHelper.hideBodyMask();
				callback.call(scope, response, updateObject);
			}, this);
		},

		_getVisaEntity: function(schema, primaryColumnValue, callback, scope) {
			const select = Ext.create("BPMSoft.EntitySchemaQuery", {
				rootSchema: schema
			});
			select.addColumn("Id");
			select.addColumn("VisaOwner");
			select.addColumn("DelegatedFrom");
			select.getEntity(primaryColumnValue, callback, scope);
		},

		_checkIsAllowedToDelegate: function(selectedItem, filterPath, callback, scope) {
			if (!selectedItem) {
				return;
			}
			var select = Ext.create("BPMSoft.EntitySchemaQuery", {
				rootSchemaName: filterPath
			});
			select.addColumn("IsAllowedToDelegate");
			select.addColumn("DelegatedFrom");
			select.addColumn("VisaOwner");
			var isAllowedToDelegateFilter = BPMSoft.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL,
				"IsAllowedToDelegate", true);
			var idFilter = BPMSoft.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL,
				"Id", selectedItem);
			select.filters.addItem(isAllowedToDelegateFilter);
			select.filters.addItem(idFilter);
			var filtersOrGroup = Ext.create("BPMSoft.FilterGroup");
			filtersOrGroup.logicalOperation = BPMSoft.LogicalOperatorType.OR;

			var filters1 = Ext.create("BPMSoft.FilterGroup");
			filters1.addItem(BPMSoft.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL,
				"[SysAdminUnitInRole:SysAdminUnitRoleId:DelegatedFrom].SysAdminUnit",
				BPMSoft.SysValue.CURRENT_USER.value));
			filters1.addItem(BPMSoft.createColumnIsNotNullFilter("DelegatedFrom"));
			filtersOrGroup.addItem(filters1);

			var filters2 = Ext.create("BPMSoft.FilterGroup");
			filters2.addItem(BPMSoft.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL,
				"[SysAdminUnitInRole:SysAdminUnitRoleId:VisaOwner].SysAdminUnit",
				BPMSoft.SysValue.CURRENT_USER.value));
			filtersOrGroup.addItem(filters2);

			var filters3 = BPMSoft.createColumnIsNullFilter("VisaOwner");
			filtersOrGroup.addItem(filters3);

			select.filters.addItem(filtersOrGroup);
			select.getEntityCollection(function(response) {
				var collection = response.collection;
				if (response.success && collection && collection.getCount() > 0) {
					callback.apply(scope, arguments);
				} else {
					BPMSoft.showInformation(resources.localizableStrings.IsAllowedToDelegate);
				}
			}, this);
		},

		_requestActionComment: function(caption, buttonCaption, maxCommentSize, callback, scope) {
			var controls = {
				comment: {
					dataValueType: BPMSoft.DataValueType.TEXT,
					caption: resources.localizableStrings.Comments,
					customConfig: {
						className: "BPMSoft.MemoEdit",
						height: "77px",
						maxlength: maxCommentSize
					}
				}
			};
			var config = {
				defaultButton: 0,
				style: {
					borderStyle: "ts-messagebox-border-style-blue visa-action",
					buttonStyle: "orange"
				}
			};
			var yesButton = {
				className: "BPMSoft.Button",
				caption: buttonCaption,
				returnCode: "yes"
			};
			BPMSoft.utils.inputBox(caption, function(result, arg) {
					if (result === yesButton.returnCode) {
						var comment = arg.comment.value;
						if (comment && maxCommentSize && comment.length > maxCommentSize) {
							comment = comment.substring(0, maxCommentSize);
						}
						callback.call(scope, comment);
					}
				}, [yesButton, "cancel"], this, controls, config
			);
		},

		_baseAction: function(caption, buttonCaption, entity, action, callback, scope) {
			var itemId = entity.get(entity.entitySchema.primaryColumn.name);
			var schemaName = entity.entitySchema.name;
			this.checkRight(itemId, schemaName, function() {
				var maxCommentSize = entity.entitySchema.columns.Comment.size;
				this._requestActionComment(caption, buttonCaption, maxCommentSize, function(comment) {
					action.call(this, entity, comment, callback, scope);
				}, this);
			}, this);
		}

	});
	return {};
});
