define("JsonResponseBuilder", [], function() {
	return {
		attributes: {
			SetupRequestParameters: { value: false },
			SetupResponseParameters: { value: true }
		},
		methods: {

			//region Methods: Protected

			/**
			 * @inheritdoc BPMSoft.JsonRequestBuilder#prepareMethodJsonStructure
			 * @override
			 */
			prepareMethodJsonStructure: function(body) {
				return { response: { body: body } };
			},

			/**
			 * @inheritdoc BPMSoft.ServiceMethodBuilder#getMergeOptions
			 * @override
			 */
			getMergeOptions: function() {
				return {
					skipUri: true,
					skipHttpMethodType: true
				};
			},

			/**
			 * @inheritdoc BPMSoft.ServiceMethodBuilder#getServiceBuilderTags
			 * @override
			 */
			getServiceBuilderTags: function() {
				return ["ServiceResponseMethodBuilder"];
			}

			//endregion

		}
	};
});
