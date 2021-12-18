using Aplication.Auth.User.Domain.Write.Commands;
using Aplication.Auth.User.Domain.Write.States;
using System;

namespace Application.Auth.User.Domain.Write.Aggregates
{
    public class UserAggregate
    {
        public UserState State;


        public UserAggregate(UserState state)
        {
            State = state;
        }

        public UserAggregate(CreateUser cmd)
        {
            validateUserCommand(cmd);
            State = new UserState
            {
                Id = cmd.Id,
                UserName = cmd.UserName,
                Password = cmd.Password,
                Role = cmd.Role
            };
        }

        public void Change(UpdateUser cmd)
        {
            validateUserCommand(cmd);
            State.Id = cmd.Id;
            State.UserName = cmd.UserName;
            State.Password = cmd.Password;
            State.Role = cmd.Role;
        }

        private void validateUserCommand(UserCommand cmd)
        {
            if (string.IsNullOrEmpty(cmd.UserName))
            {
                throw new Exception("Não existe nome de usuário.");
            }
            else if (string.IsNullOrEmpty(cmd.Password))
            {
                throw new Exception("Não existe password do usuário.");
            }
            else if (string.IsNullOrEmpty(cmd.Role))
            {
                throw new Exception("Não existe Papel do trabalhador.");
            }
            else if (cmd.Id == Guid.Empty)
            {
                throw new Exception("Não existe Id do usuário.");
            }
        }
    }
}
