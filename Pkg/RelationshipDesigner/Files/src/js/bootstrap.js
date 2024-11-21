(function() {
	require.config({
		paths: {
			"RelationshipDiagramComponent": BPMSoft.getFileContentUrl("RelationshipDesigner", "src/js/relationship-diagram-component/relationship-diagram-component.js")
		},
		shim: {
			"RelationshipDiagramComponent": {
				deps: ["ng-core"]
			}
		}
	});
}());
