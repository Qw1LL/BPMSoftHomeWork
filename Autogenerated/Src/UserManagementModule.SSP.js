define("UserManagementModule", ["ext-base", "BPMSoft", "sandbox"],
		function(Ext, BPMSoft, sandbox) {

	var render = function(renderTo) {
		switch (BPMSoft.action) {
			case "register":
				sandbox.loadModule("Registration", {
					renderTo: renderTo,
					id: sandbox.id + "-Registration",
					keepAlive: true
				});
				break;
			case "remindPassword":
				sandbox.loadModule("RemindPassword", {
					renderTo: renderTo,
					id: sandbox.id + "-RemindPassword",
					keepAlive: true
				});
				break;
		}
	};

	return {
		render: render,
		renderTo: Ext.getBody()
	};
});
