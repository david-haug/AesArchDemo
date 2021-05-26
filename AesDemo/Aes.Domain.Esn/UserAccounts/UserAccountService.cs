using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Aes.Data.Core;
using Aes.Data.Esn.UserAccounts;
using Aes.Data.Esn.UserAccounts.Commands;
using Aes.Domain.Core;
using Aes.Domain.Core.Exceptions;
using FluentValidation;
using FluentValidation.Results;

namespace Aes.Domain.Esn.UserAccounts
{
    public class UserAccountService:IUserAccountService
    {
        private IUser _user;
        public UserAccountService(IUser user)
        {
            _user = user;
        }

        public IEnumerable<UserAccount> GetUserAccounts()
        {
            var repository = new UserAccountJsonRepository();
            return repository.GetAll();
        }

        public UserAccount GetUserAccount(int userId)
        {
            var repository = new UserAccountJsonRepository();
            var user =  repository.Get(userId);

            if (user == null)
                throw new NotFoundException($"User not found with id: {userId}");

            return user;
        }

        public UserAccount CreateUserAccount(CreateUserAccountCommand command)
        {
            //creator has rights...
            if (!_user.HasRole(RoleTypes.ADMIN))
                throw new NotAuthorizedException();

            //validate
            var validator = new CreateUserAccountValidator();
            var validation = validator.Validate(command);
            HandleValidation(validation);

            //addl biz logic?

            //persist
            var repository = new UserAccountJsonRepository();
            var user = new UserAccount {
                UserName = command.UserName,
                FirstName = command.FirstName,
                LastName = command.LastName,
                Email = command.Email,
                CorrespondenceEmail = command.CorrespondenceEmail,
                OfficePhone = command.OfficePhone,
                CellPhone = command.CellPhone,
                Fax = command.Fax,
                Address1 = command.Address1,
                Address2 = command.Address2,
                City = command.City,
                Country = command.Country,
                State = command.State,
                PostalCode = command.PostalCode,
                IsActive = true,
                OrganizationId = 47,
                IsAquilon = false,
                Created = DateTime.Now,
                CreatedBy = _user.UserId,
                Modified = DateTime.Now,
                ModifiedBy = _user.UserId
            };

            repository.Add(user);
            //need to log errors here
            return user;
        }

        public UserAccount UpdateUserAccount(UpdateUserAccountCommand command)
        {
            //get existing user account
            var repository = new UserAccountJsonRepository();
            var existing = repository.Get(command.UserAccountId);

            if (existing == null)
                throw new NotFoundException($"User not found with id: {command.UserAccountId}");

            if (_user.UserId != existing.UserAccountId && !_user.HasRole(RoleTypes.ADMIN))
                throw new NotAuthorizedException();

            //validate
            var validator = new UpdateUserAccountValidator();
            var validation = validator.Validate(command);
            HandleValidation(validation);

            //update fields
            existing.UserAccountId = command.UserAccountId;
            existing.UserName = command.UserName;
            existing.FirstName = command.FirstName;
            existing.LastName = command.LastName;
            existing.Email = command.Email;
            existing.CorrespondenceEmail = command.CorrespondenceEmail;
            existing.OfficePhone = command.OfficePhone;
            existing.CellPhone = command.CellPhone;
            existing.Fax = command.Fax;
            existing.Address1 = command.Address1;
            existing.Address2 = command.Address2;
            existing.City = command.City;
            existing.Country = command.Country;
            existing.State = command.State;
            existing.PostalCode = command.PostalCode;
            existing.Modified = DateTime.Now;
            existing.ModifiedBy = _user.UserId;

            repository.Update(existing);
            return existing;
        }

        public void DeleteUserAccount(int userId)
        {
            //get existing user account
            var repository = new UserAccountJsonRepository();
            var existing = repository.Get(userId);

            if (existing == null)
                throw new NotFoundException($"User not found with id: {userId}");

            if (_user.UserId != existing.UserAccountId && !_user.HasRole(RoleTypes.ADMIN))
                throw new NotAuthorizedException();

            repository.Delete(userId);
        }

        //TODO: need cleaner way to throw validation ex
        private void HandleValidation(ValidationResult validation)
        {
            if (!validation.IsValid)
            {
                var errors = validation.Errors
                    .Select(failure => new ValidationError
                    {
                        Code = failure.ErrorCode,
                        Message = failure.ErrorMessage,
                        Name = failure.PropertyName
                    }).ToList();

                throw new Aes.Domain.Core.Exceptions.ValidationException("Validation error.", errors);
            }

        }


    }
}
