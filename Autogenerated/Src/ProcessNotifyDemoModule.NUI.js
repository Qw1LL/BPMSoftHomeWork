define('ProcessNotifyDemoModule', ['ext-base', 'BPMSoft', 'sandbox',
		'ProcessNotifyDemoModuleResources', 'ProcessNotifyDemoView', 'ProcessNotifyDemoViewModel'],

	function(Ext, BPMSoft, sandbox, resources, demoView, demoViewModel) {
		var router = BPMSoft.router.Router;
		var view;
		var viewModel;
		var viewRenderTo;
		var logContainer;

		function getFullViewModelSchema(sourceViewModelSchema) {
			var viewModelSchema = BPMSoft.utils.common.deepClone(sourceViewModelSchema);
			return viewModelSchema;
		}

		function applyUserCode(viewModelSchema, sourceViewModelSchema) {
			sourceViewModelSchema.userCode.call(viewModelSchema);
		}

		function render(renderTo) {
			//var params = router.clientUrl.split('/');
			viewModel = demoViewModel.generate();
			var viewConfig = demoView.generateMainView(viewModel);
			view = Ext.create(viewConfig.className || 'BPMSoft.Container', viewConfig);
			var viewRenderTo = renderTo;
			view.bind(viewModel);
			view.render(viewRenderTo);
			var onmsg = function(scope, msg) {
				logMsg("Msg from: '" + msg.Header.Sender + "' Content: " + msg.Body);
			};
			BPMSoft.ServerChannel.on(BPMSoft.EventName.ON_MESSAGE, onmsg, this);
			logContainer = demoView.getServerLogContainer();
			logMsg("We listen server: " + BPMSoft.ServerChannel.serviceUrl);
		}

		function connect() {
			var onmsg = function(msg) {
				logMsg("Msg from: '" + msg.Header.Sender + "' Content: " + msg.Body);
			};
			BPMSoft.ServerChannel.on(BPMSoft.EventName.ON_MESSAGE, onmsg, this);
			logMsg("We listen server: " + BPMSoft.ServerChannel.serviceUrl);
		}

		function logMsg(msg) {
			logContainer.innerHTML += '<div class="header-name">' + msg + '</div>';
		}

		return {
			//init: init,
			render: render
		};
	});
