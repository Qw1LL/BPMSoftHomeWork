namespace BPMSoft.Configuration
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using BPMSoft.Common;
    using BPMSoft.Core.DB;

    #region Class: EventConditionalTransitionFlowElement

    /// <summary>
    /// Event conditional transition process element.
    /// </summary>
    public class EventConditionalTransitionFlowElement : ConditionalTransitionFlowElement
    {

        #region Properties: Public

        /// <summary>
        /// Unique identifier of event.
        /// </summary>
        public Guid EventId { get; set; }

        /// <summary>
        /// Collection of selected event response ids.
        /// </summary>
        public IEnumerable<Guid> EventResponses { get; set; }

        #endregion

        #region Methods: Private

        private void ExtendWithResponses() {
            TransitionQuery.CheckArgumentNull("TransitionQuery");
            Query responseSelect = GetSelectByParticipantResponses();
            if (responseSelect != null) {
                TransitionQuery.And("ContactId").In(responseSelect);
            }
        }

        private Query GetSelectByParticipantResponses() {
            if (EventId == default(Guid) || !EventResponses.Any()) {
                return null;
            }
            var responseSelect = new Select(UserConnection)
                .Column("ContactId")
                .From("EventTarget")
                .Where("EventId").IsEqual(Column.Parameter(EventId))
                    .And("EventResponseId").In(Column.Parameters(EventResponses)) as Select;
            responseSelect.SpecifyNoLockHints(true);
            return responseSelect;
        }

        #endregion

        #region Methods: Protected

        /// <summary>
        /// Returns query that includes additional logic.
        /// </summary>
        /// <returns>Base <see cref="Update"/> extended with time and filter conditions.</returns>
        protected override void CreateQuery() {
            base.CreateQuery();
            ExtendWithResponses();
        }

        #endregion

    }

    #endregion

}

