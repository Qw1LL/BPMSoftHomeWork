namespace BPMSoft.Configuration.ESN
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security;
    using global::Common.Logging;
    using BPMSoft.Common;
    using BPMSoft.Core;
    using BPMSoft.Core.Entities;
    using BPMSoft.Core.Factories;
    using BPMSoft.Nui.ServiceModel.DataContract;

    #region Class: EsnLogContext
    
    public class EsnLogContext
    {
        #region Properties: Public
        
        public bool LogEnabled { get; set; }

        public string UserName { get; set; }

        public Guid UserId { get; set; }
        
        #endregion
    }
    
    #endregion

    #region Class: EsnCenter

    /// <inheritdoc />
    [DefaultBinding(typeof(IEsnCenter))]
    public class EsnCenter : IEsnCenter
    {

        #region Constants: Private

        private readonly IEsnLikeRepository _likeRepository;
        private readonly IEsnMessageReader _messageReader;
        private readonly IEsnMessageRedactor _messageRedactor;
        private readonly IEsnSecurityEngine _esnSecurityEngine;
        private readonly EsnLogContext _logContext;
        private ILog _log;

        #endregion

        #region Properties: Private

        private ILog Logger => _log ?? (_log = LogManager.GetLogger("EsnCenterLogger"));

        private bool LogEnabled => _logContext?.LogEnabled ?? false;

        #endregion

        #region Constructors: Public

        public EsnCenter(IEsnLikeRepository esnLikeRepository, IEsnMessageReader esnMessageReader,
            IEsnMessageRedactor esnMessageRedactor, IEsnSecurityEngine esnSecurityEngine,
            EsnLogContext logContext = null) {
            _likeRepository = esnLikeRepository;
            _messageReader = esnMessageReader;
            _messageRedactor = esnMessageRedactor;
            _esnSecurityEngine = esnSecurityEngine;
            _logContext = logContext;
        }

        #endregion

        #region Methods: Private

        private LookupColumnValue GetParent(Entity entity) {
            var parentId = entity.GetTypedColumnValue<Guid>("ParentId");
            return parentId == Guid.Empty
                ? null
                : new LookupColumnValue {
                    Value = parentId.ToString()
                };
        }

        private static EsnCreatedByDto GetCreatedBy(Entity entity) {
            if (!Guid.TryParse(entity.GetColumnValue("CreatedByTypedValue")?.ToString(), out Guid typedColumnValue)) {
                typedColumnValue = Guid.Empty;
            }
            return new EsnCreatedByDto {
                DisplayValue = FindColumnValue(entity, "CreatedByName"),
                PrimaryImageValue = FindColumnValue(entity, "CreatedByPrimaryImage"),
                Value = FindColumnValue(entity, "CreatedById"),
                TypedValue = typedColumnValue
            };
        }

        private bool InnerDeletePost(Guid schemaUId, Guid entityId, Guid messageId, bool isComment) {
            var messageEntity = _messageReader.ReadMessageAllColumnsEntity(messageId);
            if (messageEntity == null) {
                throw new ItemNotFoundException();
            }
            var messageAuthorId = messageEntity.GetTypedColumnValue<Guid>("CreatedById");
            if (_esnSecurityEngine.CanDeletePost(schemaUId, entityId, messageAuthorId)) {
                if (isComment) {
                    return _messageRedactor.DeleteComment(messageEntity);
                } else {
                    return _messageRedactor.DeleteMessage(messageEntity);
                }
            }
            throw new SecurityException(string.Format(
                new LocalizableString("BPMSoft.Core", "DBSecurityEngine.Exception.CurrentUserHasNotRightsForObject"),
                "SocialMessage"));
        }

        private static string FindColumnValue(Entity entity, string columnName) {
            EntityColumnValue columnValue = entity.FindEntityColumnValue(columnName);
            return columnValue?.Value?.ToString() ?? string.Empty;
        }

        private void WriteLog(string message) {
            if (!LogEnabled) {
                return;
            }
            Logger.Info(message);
        }

        #endregion

        #region Methods: Protected

        /// <summary>
        /// Create DTO for response.
        /// </summary>
        /// <param name="entity">Instance of <see cref="BPMSoft.Core.Entities.Entity" />.</param>
        /// <returns>Instance of <see cref="BPMSoft.Configuration.ESN.EsnLikeDTO" />.</returns>
        protected virtual EsnLikeDTO CreateEsnLikeDTO(Entity entity) =>
            new EsnLikeDTO {
                Id = entity.PrimaryColumnValue,
                SocialMessageId = entity.GetTypedColumnValue<Guid>("SocialMessageId"),
                UserId = entity.GetTypedColumnValue<Guid>("UserId"),
                ContactId = entity.GetTypedColumnValue<Guid>("CreatedById"),
                ContactName = entity.GetColumnValue("CreatedByName").ToString(),
                ContactPrimaryImageId = entity.GetTypedColumnValue<Guid>("CreatedByPrimaryImage")
            };

        /// <summary>
        /// Create message DTO for response.
        /// </summary>
        /// <param name="entity">Instance of <see cref="Entity" />.</param>
        /// <returns>Instance of <see cref="EsnReadMessageDTO" />.</returns>
        protected virtual EsnReadMessageDTO CreateEsnMessageDTO(Entity entity) =>
            new EsnReadMessageDTO {
                Id = entity.PrimaryColumnValue,
                Color = entity.GetTypedColumnValue<string>("Color"),
                CommentCount = entity.GetTypedColumnValue<int>("CommentCount"),
                CreatedBy = GetCreatedBy(entity),
                CreatedOn = GetSerializedDateTime(entity.GetTypedColumnValue<DateTime>("CreatedOn")),
                EntityId = entity.GetTypedColumnValue<Guid>("EntityId"),
                EntitySchemaName = entity.GetTypedColumnValue<string>("EntitySchemaName"),
                EntitySchemaCaption = entity.GetTypedColumnValue<string>("EntitySchemaCaption"),
                LinkPreviewData = entity.FindEntityColumnValue("LinkPreviewData") != null
                    ? entity.GetBytesValue("LinkPreviewData")
                    : null,
                EntitySchemaUId = entity.GetTypedColumnValue<Guid>("EntitySchemaUId"),
                LastActionOn = GetSerializedDateTime(entity.GetTypedColumnValue<DateTime>("LastActionOn")),
                LikeCount = entity.GetTypedColumnValue<int>("LikeCount"),
                Message = entity.GetTypedColumnValue<string>("Message"),
                Parent = GetParent(entity),
            };

        /// <summary>
        /// Create serialized date in Utc time zone.
        /// </summary>
        protected string GetSerializedDateTime(DateTime dateTime) {
            return DateTimeDataValueType.Serialize(dateTime, TimeZoneInfo.Utc);
        }

        #endregion

        #region Methods: Public

        /// <inheritdoc />
        public IEnumerable<EsnLikeDTO> GetMessageLikesForUser(Guid userId, IEnumerable<Guid> messageIds) =>
            _likeRepository.GetUserLikesByMessages(userId, messageIds).Select(CreateEsnLikeDTO);

        /// <inheritdoc />
        public IEnumerable<EsnLikeDTO> GetWhoLikedMessage(Guid messageId) =>
            _likeRepository.GetWhoLikedMessage(messageId).Select(CreateEsnLikeDTO);

        /// <inheritdoc />
        public Guid LikeMessage(Guid userId, Guid messageId) => _likeRepository.AddLike(userId, messageId);

        /// <inheritdoc />
        public bool UnLikeMessage(Guid userId, Guid messageId) => _likeRepository.DeleteLike(userId, messageId);

        /// <inheritdoc />
        public IEnumerable<EsnReadMessageDTO> ReadComments(Guid schemaUId, Guid entityId, Guid messageId) {
            if (_esnSecurityEngine.CanReadEntityMessage(schemaUId, entityId)) {
                return _messageReader.ReadComments(messageId).Select(CreateEsnMessageDTO);
            }
            throw new SecurityException(string.Format(
                new LocalizableString("BPMSoft.Core", "DBSecurityEngine.Exception.CurrentUserHasNotRightsForObject"),
                "SocialMessage"));
        }

        /// <inheritdoc />
        public EsnReadMessageDTO ReadMessage(Guid schemaUId, Guid entityId, Guid messageId) {
            if (_esnSecurityEngine.CanReadEntityMessage(schemaUId, entityId)) {
                return CreateEsnMessageDTO(_messageReader.ReadMessage(messageId));
            }
            throw new SecurityException(string.Format(
                new LocalizableString("BPMSoft.Core", "DBSecurityEngine.Exception.CurrentUserHasNotRightsForObject"),
                "SocialMessage"));
        }

        /// <inheritdoc />
        public IEnumerable<EsnReadMessageDTO> ReadEntityMessage(Guid schemaUId, Guid entityId,
            EsnReadMessageOptions options) {
            if (_esnSecurityEngine.CanReadEntityMessage(schemaUId, entityId)) {
                return _messageReader.ReadEntityMessage(entityId, options).Select(CreateEsnMessageDTO);
            }
            throw new SecurityException(string.Format(
                new LocalizableString("BPMSoft.Core", "DBSecurityEngine.Exception.CurrentUserHasNotRightsForObject"),
                "SocialMessage"));
        }

        /// <inheritdoc />
        public IEnumerable<EsnReadMessageDTO> ReadFeedMessage(EsnReadMessageOptions readOptions) {
            var messages = new List<EsnReadMessageDTO>();
            var readOptionLocal = new EsnReadMessageOptions {
                SortedBy = readOptions.SortedBy,
                ReadMessageCount = readOptions.ReadMessageCount,
                OffsetDate = readOptions.OffsetDate,
                IncludeComments = readOptions.IncludeComments
            };
            var sortedColumnName = readOptionLocal.SortedBy.ToString();
            WriteLog($"Start read feed for user - {_logContext?.UserId} - {_logContext?.UserName}");
            do {
                var messagesFromDb = _messageReader.ReadFeedMessage(readOptionLocal);
                WriteLog($"Loaded {messagesFromDb.Count()} messages");
                foreach (var message in messagesFromDb) {
                    readOptionLocal.OffsetDate = message.GetTypedColumnValue<DateTime>(sortedColumnName);
                    var entityId = message.GetTypedColumnValue<Guid>("EntityId");
                    var entitySchemaUId = message.GetTypedColumnValue<Guid>("EntitySchemaUId");
                    if (_esnSecurityEngine.CanReadEntityMessage(entitySchemaUId, entityId)) {
                        var messageDto = CreateEsnMessageDTO(message);
                        messages.Add(messageDto);
                        WriteLog($"Checked messageId {messageDto.Id}");
                        if (messages.Count == readOptions.ReadMessageCount) {
                            break;
                        }
                    } else {
                        WriteLog($"Can't read message with entityId - {entityId} " 
                            + $"and entitySchemaUId - {entitySchemaUId} ");
                    }
                }
                if (messagesFromDb.Count() != readOptions.ReadMessageCount) {
                    break;
                }
            } while (messages.Count < readOptions.ReadMessageCount);
            WriteLog($"Finish, messages read: {messages.Count}");
            return messages;
        }

        /// <inheritdoc />
        public Guid PostMessage(EsnWriteMessageDTO messageData) {
            if (_esnSecurityEngine.CanCreateMessage(messageData.SchemaUId, messageData.EntityId)) {
                return _messageRedactor.PostMessage(messageData);
            }
            throw new SecurityException(string.Format(
                new LocalizableString("BPMSoft.Core", "DBSecurityEngine.Exception.CurrentUserHasNotRightsForObject"),
                "SocialMessage"));
        }

        /// <inheritdoc />
        public Guid PostComment(Guid messageId, EsnWriteMessageDTO commentData) {
            if (_esnSecurityEngine.CanCreateComment(commentData.SchemaUId, commentData.EntityId)) {
                return _messageRedactor.PostComment(messageId, commentData);
            }
            throw new SecurityException(string.Format(
                new LocalizableString("BPMSoft.Core", "DBSecurityEngine.Exception.CurrentUserHasNotRightsForObject"),
                "SocialMessage"));
        }

        /// <inheritdoc />
        public bool EditMessage(Guid messageId, EsnWriteMessageDTO messageData) {
            var messageEntity = _messageReader.ReadMessageAllColumnsEntity(messageId);
            var messageAuthorId = messageEntity.GetTypedColumnValue<Guid>("CreatedById");
            if (_esnSecurityEngine.CanEditPost(messageData.SchemaUId, messageData.EntityId, messageAuthorId)) {
                return _messageRedactor.EditMessage(messageEntity, messageData.Message);
            }
            throw new SecurityException(string.Format(
                new LocalizableString("BPMSoft.Core", "DBSecurityEngine.Exception.CurrentUserHasNotRightsForObject"),
                "SocialMessage"));
        }

        /// <inheritdoc />
        public bool EditComment(Guid commentId, EsnWriteMessageDTO commentData) {
            var commentEntity = _messageReader.ReadMessageAllColumnsEntity(commentId);
            var commentAuthorId = commentEntity.GetTypedColumnValue<Guid>("CreatedById");
            if (_esnSecurityEngine.CanEditPost(commentData.SchemaUId, commentData.EntityId, commentAuthorId)) {
                return _messageRedactor.EditComment(commentEntity, commentData.Message);
            }
            throw new SecurityException(string.Format(
                new LocalizableString("BPMSoft.Core", "DBSecurityEngine.Exception.CurrentUserHasNotRightsForObject"),
                "SocialMessage"));
        }

        /// <inheritdoc />
        public bool DeleteMessage(Guid schemaUId, Guid entityId, Guid messageId) {
            return InnerDeletePost(schemaUId, entityId, messageId, false);
        }

        /// <inheritdoc />
        public bool DeleteComment(Guid schemaUId, Guid entityId, Guid commentId) {
            return InnerDeletePost(schemaUId, entityId, commentId, true);
        }

        #endregion

    }

    #endregion

}

