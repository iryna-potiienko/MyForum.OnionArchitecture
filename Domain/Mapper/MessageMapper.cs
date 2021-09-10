using Model.Dto;
using Model.Model;

namespace Domain.Mapper
{
    public class MessageMapper
    {
        public Message MapToMessage(MessageDto messageDto)
        {
            var message = new Message()
            {
                Id = messageDto.Id,
                MessageText = messageDto.MessageText,
                CreatedAt = messageDto.CreatedAt,
                SubjectId = messageDto.SubjectId,
                UserName = messageDto.UserName
            };
            return message;
        }

        public MessageDto MapToMessageDto(Message message)
        {
            var messageDto = new MessageDto()
            {
                Id = message.Id,
                MessageText = message.MessageText,
                CreatedAt = message.CreatedAt,
                SubjectId = message.SubjectId,
                UserName = message.UserName
            };
            return messageDto;
        }
    }
}