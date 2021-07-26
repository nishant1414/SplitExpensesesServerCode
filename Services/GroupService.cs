using SplitExpenses.Entities;
using SplitExpenses.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SplitExpenses.Services
{
    public class GroupService
    {
        private readonly IUnitOfWork _unitOfWork;
        public GroupService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<Group> GetAllGroup()
        {
           return _unitOfWork.Repository<Group>().GetAll().ToList();
        }

        public Group GetGroupById(int id)
        {
            return _unitOfWork.Repository<Group>().GetById(id);
        }

        public void CreateGroup(Group group)
        {
            _unitOfWork.Repository<Group>().Insert(group);
            _unitOfWork.Commit();
            var participant = _unitOfWork.Repository<Participant>().FindBy(p => p.Id == group.adminParticipantId).First();
            if (participant != null)
            {
                var groupParticipant = new GroupParticipant();
                groupParticipant.GroupId = group.Id;
                groupParticipant.ParticipantId = participant.Id;
                groupParticipant.IsActive = true;
                _unitOfWork.Repository<GroupParticipant>().Insert(groupParticipant);
                _unitOfWork.Commit();

            }
            
        }

        public List<Group> GetGroupsByParticipantId(int participantId)
        {
            var groupParticipant = _unitOfWork.Repository<GroupParticipant>().FindBy(x => x.ParticipantId == participantId && x.IsActive == true).ToList();
            var groupIds = groupParticipant.Select(x => x.GroupId);
            return _unitOfWork.Repository<Group>().FindBy(x => groupIds.Contains(x.Id)).ToList();

        }

        public List<Group> GetGroupsByEmail(string email)
        {
            var participant = _unitOfWork.Repository<Participant>().FindBy(p => p.EmailId == email).FirstOrDefault();
            if (participant == null)
                throw new Exception($"No participant found with this email {email}");
            var participantGroups = _unitOfWork.Repository<GroupParticipant>().FindBy(pg => pg.ParticipantId == participant.Id).ToList();
            if (participantGroups == null)
                throw new Exception("no group found");
            var groupIds = participantGroups.Select(g => g.Id).ToList();
            var groups =  _unitOfWork.Repository<Group>().FindBy(g => groupIds.Contains(g.Id)).ToList();
            return groups;

        }


    }
}
