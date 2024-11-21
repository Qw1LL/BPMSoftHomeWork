define("ProcessExecutingDetailGridRowViewModel", ["ext-base", "BaseSectionGridRowViewModel"],
		function(Ext) {
	Ext.define("BPMSoft.configuration.ProcessExecutingDetailGridRowViewModel", {
		extend: "BPMSoft.BaseSectionGridRowViewModel",
		alternateClassName: "BPMSoft.ProcessExecutingDetailGridRowViewModel",

		/**
		 * Returns process designer edit page url.
		 * @private
		 * @return {String}
		 */
		getProcessEditPageUrl: function() {
			return Ext.String.format("{0}{1}{2}",
				this.getBaseUrl(), "?vm=SchemaDesigner#process/", this.get("SysSchemaUId"));
		},

		/**
		 * Returns base view module url.
		 * @private
		 * @return {String}
		 */
		getBaseUrl: function() {
			return BPMSoft.workspaceBaseUrl + "/Nui/ViewModule.aspx";
		},

		/**
		 * @inheritdoc BPMSoft.configuration.BaseGridRowViewModel#getLinkColumnConfig
		 * @overridden
		 */
		getLinkColumnConfig: function(column) {
			var config = null;
			if (column.columnPath === "ProcessName") {
				var value = this.get(column.columnPath);
				config = {
					title: value,
					caption: value,
					target: "_blank",
					url: this.getProcessEditPageUrl()
				};
			}
			return config;
		}
	});
	return BPMSoft.ProcessExecutingDetailGridRowViewModel;
});
