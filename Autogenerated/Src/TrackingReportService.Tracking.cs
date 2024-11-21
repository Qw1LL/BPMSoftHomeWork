namespace BPMSoft.Configuration.Tracking
{
    using System;
    using System.ServiceModel;
    using System.ServiceModel.Activation;
    using System.ServiceModel.Web;
    using System.Web.SessionState;
    using System.Collections.Generic;
    using BPMSoft.Web.Common;

    #region Class: TrackingReportService

    /// <summary>
    /// Class to work with report service.
    /// </summary>
    [ServiceContract]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    public class TrackingReportService : BaseService, IReadOnlySessionState
    {

        #region Class: EventFeedRequest

        /// <summary>
        /// Request DTO for gets contact feed.
        /// </summary>
        public class EventFeedRequest
        {
            #region Properties: Public

            /// <summary>
            /// Contact identifier for whose get feed.
            /// </summary>
            public Guid EntityId { get; set; }

            /// <summary>
            /// Offset of requested feed records.
            /// </summary>
            public string Offset { get; set; }

            /// <summary>
            /// Count of requested feed records.
            /// </summary>
            public int Count { get; set; }

            #endregion

        }

        #endregion

        #region Class: EventFeedResponse

        /// <summary>
        /// Dto response for gets contact feed.
        /// </summary>
        public class EventFeedResponse
        {
            #region Properties: Public

            /// <summary>
            /// Offset of records.
            /// </summary>
            public string Offset { get; set; }

            /// <summary>
            /// Feed records.
            /// </summary>
            public IEnumerable<EventFeedRecord> Events { get; set; }

            /// <summary>
            /// Contains error message when operation unsuccessfully completed.
            /// </summary>
            public string ErrorMessage { get; set; }

            #endregion
        }

        #endregion

        #region Methods: Public

        /// <summary>
        /// Returns contact feed from parameters.
        /// </summary>
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "GetContactFeed", BodyStyle = WebMessageBodyStyle.Wrapped,
            RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public EventFeedResponse GetContactFeed(EventFeedRequest feedRequest) {
            var eventDataProvider = new EventDataProvider(UserConnection);
            var eventDataProviderContactDecorator = new EventDataProviderSchemaDecorator(UserConnection, eventDataProvider);
            var eventDataProviderContactDecoratorResponse = eventDataProviderContactDecorator.GetContactFeed(feedRequest.EntityId,
                feedRequest.Offset, feedRequest.Count);
            return new EventFeedResponse
            {
                ErrorMessage = eventDataProviderContactDecoratorResponse.ErrorMessage,
                Offset = eventDataProviderContactDecoratorResponse.Offset,
                Events = eventDataProviderContactDecoratorResponse.Events
            };
        }


        /// <summary>
        /// Returns lead feed from parameters.
        /// </summary>
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "GetLeadFeed", BodyStyle = WebMessageBodyStyle.Wrapped,
            RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public EventFeedResponse GetLeadFeed(EventFeedRequest feedRequest) {
            var eventDataProvider = new EventDataProvider(UserConnection);
            var eventDataProviderContactDecorator = new EventDataProviderSchemaDecorator(UserConnection, eventDataProvider);
            var eventDataProviderContactDecoratorResponse = eventDataProviderContactDecorator.GetLeadFeed(feedRequest.EntityId,
                feedRequest.Offset, feedRequest.Count);
            return new EventFeedResponse
            {
                ErrorMessage = eventDataProviderContactDecoratorResponse.ErrorMessage,
                Offset = eventDataProviderContactDecoratorResponse.Offset,
                Events = eventDataProviderContactDecoratorResponse.Events
            };
        }

        #endregion

    }

    #endregion

}
