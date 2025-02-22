﻿define('WorkResourceElementServiceHelper', ['ext-base', 'BPMSoft'],
	function(Ext, BPMSoft) {
		var callServiceMethod = function(name, data, callback, scope) {
			var ajaxProvider = BPMSoft.AjaxProvider;
			scope = scope || this;
			var requestUrl = BPMSoft.workspaceBaseUrl + '/rest/WorkResourceElementService/' + name;
			ajaxProvider.request({
				url: requestUrl,
				headers: {
					'Accept': 'application/json',
					'Content-Type': 'application/json'
				},
				method: 'POST',
				jsonData: data || {},
				callback: function(request, success, response) {
					var responseObject = {};
					if (success) {
						responseObject =  BPMSoft.decode(response.responseText);
					}
					callback.call(scope, responseObject);
				},
				scope: scope
			});
		};
		var getCanCreate = function(workResourceElementId, projectResourceElementId, projectId, callback, scope) {
			var dataSet = {
				workResourceElementId: workResourceElementId,
				projectResourceElementId: projectResourceElementId,
				projectId: projectId
			};
			callServiceMethod('GetCanCreate', dataSet, function(response) {
				callback.call(this, response.GetCanCreateResult);
			}, scope || this);
		};

		var getCanEdit = function(workResourceElementId, projectResourceElementId, work, callback, scope) {
			var dataSet = {
				workResourceElementId: workResourceElementId,
				projectResourceElementId: projectResourceElementId,
				work: work
			};
			callServiceMethod('GetCanEdit', dataSet, function(response) {
				callback.call(this, response.GetCanEditResult);
			}, scope || this);
		};
		var getCanDelete = function(workResourceElementId, callback, scope) {
			var dataSet = {
				workResourceElementId: workResourceElementId
			};
			callServiceMethod('GetCanDelete', dataSet, function(response) {
				callback.call(this, response.GetCanDeleteResult);
			}, scope || this);
		};
		return {
			GetCanCreate: getCanCreate,
			GetCanEdit: getCanEdit,
			GetCanDelete: getCanDelete
		};
	});
