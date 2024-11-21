define('SummaryView', ['ext-base', 'BPMSoft', 'SummaryViewResources'],
	function(Ext, BPMSoft, resources) {
		var entitySchema;

		function generateItem(renderTo, key) {
			var view = {
				renderTo: renderTo,
				id: 'itemSummaryView' + key,
				selectors: {
					el: "#itemSummaryView" + key,
					wrapEl: "#itemSummaryView" + key
				},
				classes: {
					wrapClassName: ['summary-item-container']
				},
				items: [
					{
						className: 'BPMSoft.Label',
						caption: {
							bindTo: 'columnCaption'
						},
						classes: {
							labelClass: ['summary-item-caption']
						},
						width: 'auto'
					},
					{
						className: 'BPMSoft.Label',
						caption: {
							bindTo: 'columnValue'
						},
						classes: {
							labelClass: ['summary-item-value']
						},
						width: 'auto'
					},
					{
						className: 'BPMSoft.Button',
						style: BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
						imageConfig: resources.localizableImages.ImageDeleteButton,
						classes: {
							wrapperClass: ['summary-delete-button-wrapperEl'],
							imageClass: ['summary-delete-button-image-size']
						},
						click: {
							bindTo: 'deleteItem'
						}
					}
				]
			};
			return view;
		}

		function generate(renderTo) {
			var view = {
				renderTo: renderTo,
				id: 'summariesContainer',
				selectors: {
					wrapEl: '#summariesContainer'
				},
				classes: {
					wrapClassName: ['summaries-container']
				},
				items: []
			};
			return view;
		}

		return {
			generate : generate,
			generateItem : generateItem
		};
	});
