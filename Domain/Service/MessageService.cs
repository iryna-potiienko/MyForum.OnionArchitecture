using System.Collections.Generic;
using Domain.Mapper;
using Model.Dto;
using Persistence.Repository;

namespace Domain.Service
{
    public class MessageService
    {
        private readonly MessageMapper _messageMapper;
        
                private readonly MessageRepository _messageRepository;
        
                public MessageService(MessageMapper messageMapper, MessageRepository messageRepository)
                {
                    _messageMapper = messageMapper;
                    _messageRepository = messageRepository;
                }
                
                public MessageDto Create(MessageDto messageDto)
                {
                    var message = _messageMapper.MapToMessage(messageDto);
        
                    var createdMessage = _messageRepository.Create(message);
                    return _messageMapper.MapToMessageDto(createdMessage.Result);
                }
        
                public List<MessageDto> GetAll()
                {
                    return _messageRepository.FindAll()
                        .Result
                        .ConvertAll(input => _messageMapper.MapToMessageDto(input));
                }
        
                public MessageDto GetMessage(int id)
                {
                    var message = _messageRepository.FindById(id);
                    return message != null ? _messageMapper.MapToMessageDto(message) : null;
                }
        
                public bool Update(int id, MessageDto messageDto)
                {
                    var message = _messageRepository.FindById(id);
                    
                    if (message == null)
                    {
                        return true;
                    }
        
                    message.MessageText = messageDto.MessageText;
                    message.CreatedAt = messageDto.CreatedAt;
                    message.SubjectId = messageDto.SubjectId;
                    message.UserId = messageDto.UserId;
        
                    _messageRepository.Update(message);
                    return false;
                }
        
                public bool Delete(int id)
                {
                    var message = _messageRepository.FindById(id);
                    
                    if (message == null)
                    {
                        return true;
                    }
                    
                    _messageRepository.Delete(message);
                    return false;
                }
    }
}