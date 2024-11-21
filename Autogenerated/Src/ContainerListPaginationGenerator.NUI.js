define("ContainerListPaginationGenerator", ["ContainerListGenerator", "ContainerListPagination"],
	function() {
		Ext.define("BPMSoft.configuration.ContainerListPaginationGenerator", {
			extend: "BPMSoft.ContainerListGenerator",
			alternateClassName: "BPMSoft.ContainerListPaginationGenerator",
			/**
			 * @inheritdoc
			 * @overridden BPMSoft.configuration.ContainerListGenerator#itemClassName
			 */
			itemClassName: "BPMSoft.ContainerListPagination"
		});
		return Ext.create("BPMSoft.ContainerListPaginationGenerator");
	});

